using System.Collections.Generic;
using System.Linq;
using ATS.Domain.Interfaces;
using ATS.Domain.Models;
using ATS.Infra.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ATS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCardController : ControllerBase
    {

        private readonly ICustomerCardRepository _ccRepository;

        public CustomerCardController(ICustomerCardRepository custCardRepository)
        {
            _ccRepository = custCardRepository;
        }

        [HttpGet]
        public IEnumerable<CustomerCard> Get()
        {
            var lista = _ccRepository.GetAll();

            return lista;
        }


        [HttpPost]
        public IActionResult Save([FromBody] CustomerCardRequest entity)
        {
            try
            {
                if (entity == null)
                    return NotFound();

               var retorno =  _ccRepository.SaveCustomerCard(entity);
                return Ok(retorno);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }


        }

        [HttpPut]
        public IActionResult Update([FromBody] CustomerCard entity)
        {
            if (entity == null)
                return NotFound();

            _ccRepository.Update(entity);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return NotFound();

            _ccRepository.Delete(id);

            return Ok();
        }
    }
}