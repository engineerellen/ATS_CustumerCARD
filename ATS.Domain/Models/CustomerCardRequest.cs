using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ATS.Domain.Validator;

namespace ATS.Domain.Models
{
    public class CustomerCardRequest
    {
        [Required(ErrorMessage = "ID do Cliente é obrigatório!")]
        public int customerId { get; set; }

        [Required(ErrorMessage = "Número do cartão de crédito é obrigatório!")]
        [CreditCardValidator(ErrorMessage = "Número do cartão de crédito inválido!")]
        public long cardNumber { get; set; }

        [Required(ErrorMessage = "CVV é obrigatório!")]
        [CVVValidator(ErrorMessage ="CVV inválido!")]
        public int cvv { get; set; }
    }
}
