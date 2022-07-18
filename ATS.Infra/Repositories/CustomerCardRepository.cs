using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATS.Domain.Models;
using ATS.Infra.Context;

namespace ATS.Infra.Repositories
{
    public class CustomerCardRepository :  Repository<CustomerCard>, ICustomerCardRepository
    {
        public CustomerCardRepository(AppDbContext context) : base(context)
        {}

        public override CustomerCard GetById(int id)
        {
            var query = _context.Set<CustomerCard>().Where(e => e.Id == id);

            if(query.Any())
                return query.First();

            return null;
        }

        public  CustomerCard GetByCustomerId(int customerID,int cardID)
        {
            var query = _context.Set<CustomerCard>().Where(e => e.customerId == customerID && e.cardId == cardID);

            if (query.Any())
                return query.First();

            return null;
        }

        public int GetLastCardID(int customerID)
        {
            var query = _context.Set<CustomerCard>().Where(e => e.customerId == customerID ).OrderByDescending(p=> p.cardId);

            if (query.Any())
                return query.First().cardId;

            return 0;
        }


        public override IEnumerable<CustomerCard> GetAll()
        {
            var query = _context.Set<CustomerCard>();

            return query.Any() ? query.ToList() : new List<CustomerCard>();
        }

        public CustomerCardResponse SaveCustomerCard(CustomerCardRequest customerRequest)
        {
            var creditCardResponse = new CustomerCardResponse();

            string LastDigitCreditCard = customerRequest.cardNumber.ToString().Substring(customerRequest.cardNumber.ToString().Length - 4);
            int[] arrayToken = new int[4];
            int index = 0;

            foreach (var item in LastDigitCreditCard)
            {
                int valor = 0;

                int.TryParse(item.ToString(), out valor);

                arrayToken[index] = valor;
                index++;
            }

            int[] token = circularArrayRotation(arrayToken, customerRequest.cvv);
            StringBuilder strToken = new StringBuilder();

            foreach (var item in token)
            {
                strToken.Append(item.ToString());
            }

            long lgToken = 0;
            long.TryParse(strToken.ToString(), out lgToken);

            var customerTransfer = new CustomerCard();
            customerTransfer.customerId = customerRequest.customerId;
            customerTransfer.cvv = customerRequest.cvv;
            customerTransfer.cardNumber = customerRequest.cardNumber;
            customerTransfer.registrationDate = DateTime.Now;
            customerTransfer.token = lgToken;
            customerTransfer.cardId = GetLastCardID(customerRequest.customerId) + 1;
            _context.Add<CustomerCard>(customerTransfer);

            _context.SaveChanges();

            customerTransfer = new CustomerCard();
            customerTransfer = _context.Set<CustomerCard>().ToList().Where(p => p.cardNumber == customerRequest.cardNumber).FirstOrDefault();

            creditCardResponse.token = lgToken;
            creditCardResponse.registrationDate = customerTransfer.registrationDate;
            creditCardResponse.cardId = customerTransfer.cardId;

            return creditCardResponse;
        }


        public long GetCreditCardNumber(int customerID, int cardID)
        {
            var query = _context.Set<CustomerCard>().Where(e => e.customerId == customerID && e.cardId == cardID);

            if (query.Any())
                return query.First().cardNumber;

            return 0;
        }

        public TokenValidateResponse ValidateToken(TokenValidate tokenVal)
        {
            TokenValidateResponse retorno = new TokenValidateResponse();

            var customerCard = GetByCustomerId(tokenVal.customerId,tokenVal.cardId);

            if(customerCard is null)
            {
                retorno.Return = false;
            }

            var intervalo = (DateTime.Now - customerCard.registrationDate) / 60;


            if ( intervalo.TotalMinutes > 30)
            {
                retorno.Return = false;
            }

            long creditCard = GetCreditCardNumber(tokenVal.customerId, tokenVal.cardId);

            string LastDigitCreditCard = creditCard.ToString().Substring(creditCard.ToString().Length - 4);


            int[] arrayToken = new int[4];
            int index = 0;

            foreach (var item in LastDigitCreditCard)
            {
                int valor = 0;

                int.TryParse(item.ToString(), out valor);

                arrayToken[index] = valor;
                index++;
            }

            int[] token = circularArrayRotation(arrayToken, tokenVal.cvv);

            StringBuilder strToken = new StringBuilder();

            foreach (var item in token)
            {
                strToken.Append(item.ToString());
            }

            long lgToken = 0;
            long.TryParse(strToken.ToString(), out lgToken);

            retorno.Return =tokenVal.token == lgToken;
            retorno.CardNumber = creditCard;

            return retorno;
        }


        private int[] circularArrayRotation(int[] a, int k)
        {
            int[] rotatedArray = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                if (i + k > a.Length - 1)
                {
                    rotatedArray[(i + k) % a.Length] = a[i];
                }
                else
                {
                    rotatedArray[i + k] = a[i];
                }
            }

            return rotatedArray;
        }


    }
}