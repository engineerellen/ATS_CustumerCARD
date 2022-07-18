using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ATS.Domain.Validator;

namespace ATS.Domain.Models
{
    public class TokenValidate
    {
        [Required(ErrorMessage = "Id do Cliente é obrigatório!")]
        public int customerId { get; set; }

        [Required(ErrorMessage = "Id Do cartão é obrigatório!")]
        public int cardId { get; set; }

        [Required(ErrorMessage = "Token é obrigatório!")]
        public long token { get; set; }


        [Required(ErrorMessage = "CVV é obrigatório!")]
        [CVVValidator(ErrorMessage = "CVV inválido!")]
        public int cvv { get; set; }

    }
}
