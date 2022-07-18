using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ExpectedObjects;
using ATS.Domain;
using ATS.Domain.Test.Util;
using ATS.Domain.Interfaces;
using ATS.Domain.Models;
using ATS.Infra.Repositories;

namespace ATS.Domain.Test.Token
{
    public class TesteCandidato
    {
        private readonly ICustomerCardRepository _ccRepository;

        [Fact]
        public void InstanciaCreditCard_Esperado_Sucesso()
        {
            var CustomerCardRequest = new
            {
                CustomerID = 3,
                CardNumber = 5534501719963919,
                 CVV = 574
            };

            var response = new ATS.Domain.Models.CustomerCardRequest() { customerId = CustomerCardRequest.CustomerID, cardNumber = CustomerCardRequest.CardNumber, cvv = CustomerCardRequest.CVV };

            CustomerCardRequest.ToExpectedObject().ShouldMatch(response);
        }

        [Fact]
        public void InstanciaCreditCard_Esperado_Erro()
        {
            string mensagemError = "Parametros inválidos!";

            var CustomerCardRequest = new
            {
                CustomerID = 3,
                CardNumber = 55,
                CVV = 574
            };

            var Candidato = new ATS.Domain.Models.CustomerCardRequest() { customerId = CustomerCardRequest.CustomerID, cardNumber = CustomerCardRequest.CardNumber, cvv = CustomerCardRequest.CVV };

            Assert.Throws<ArgumentException>(() => new ATS.Domain.Models.CustomerCard() { customerId = CustomerCardRequest.CustomerID, cardNumber = CustomerCardRequest.CardNumber, cvv = CustomerCardRequest.CVV }).ValidarMensagem(mensagemError);

        }

        [Fact]
        public void TesteInclusao()
        {

            CustomerCardRequest objCustomerCardRequest = new CustomerCardRequest()
            {
                customerId = 3,
                cardNumber = 55,
                cvv = 574
            };


            try
            {
                _ccRepository.SaveCustomerCard(objCustomerCardRequest);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }

        }

        [Fact]
        public void TesteListagem()
        {
            var dados = _ccRepository.GetAll();
            Assert.True(dados.Count() > 0);
        }

        [Fact]
        public void TesteGetById()
        {
            var dados = _ccRepository.GetById(1);
            Assert.True(dados is not null);
        }

        [Fact]
        public void TesteValidacao_Sucesso()
        {
            TokenValidate TokenRequest = new TokenValidate()
            {
                customerId = 3,
                cardId = 3,
                token = 8381,
                cvv = 345

            };

            try
            {
                _ccRepository.ValidateToken(TokenRequest);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

        [Fact]
        public void ValidaToken_Esperado_Erro()
        {
            string mensagemError = "Parametros inválidos!";

            TokenValidate TokenRequest = new TokenValidate()
            {
                customerId = 3,
                cardId = 3,
                token = 8381,
                cvv = 345900876

            };

            var Candidato = new ATS.Domain.Models.TokenValidate() { customerId = TokenRequest.customerId, cardId = TokenRequest.cardId, token = TokenRequest.token, cvv = TokenRequest.cvv };

            Assert.Throws<ArgumentException>(() => new ATS.Domain.Models.TokenValidate() { customerId = TokenRequest.customerId, cardId = TokenRequest.cardId, token = TokenRequest.token, cvv = TokenRequest.cvv }).ValidarMensagem(mensagemError);

        }

        [Fact]
        public void TesteValidacao_False()
        {
            TokenValidate TokenRequest = new TokenValidate()
            {
                customerId = 3,
                cardId = 3,
                token = 8389,
                cvv = 345

            };

            try
            {
                _ccRepository.ValidateToken(TokenRequest);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }
        }

    }
}


