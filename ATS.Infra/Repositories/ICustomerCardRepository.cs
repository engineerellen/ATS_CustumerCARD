using ATS.Domain.Interfaces;
using ATS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Infra.Repositories
{
    public interface ICustomerCardRepository : IRepository<CustomerCard>
    {
        public CustomerCardResponse SaveCustomerCard(CustomerCardRequest customerRequest);

        public TokenValidateResponse ValidateToken(TokenValidate tokenValidate);
    }
}
