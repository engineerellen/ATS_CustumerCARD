using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Domain.Models
{
    public class CustomerCard : BaseEntity
    {

        public int customerId { get; set; }
        public long cardNumber { get; set; }
        public int cvv { get; set; }
        public DateTime registrationDate { get; set; }
        public long token { get; set; }
        public int cardId { get; set; }


    }
}
