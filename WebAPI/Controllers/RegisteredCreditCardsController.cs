using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredCreditCardsController : ControllerBase
    {
        private IRegisteredCreditCardService _registeredCreditCardService;

        public RegisteredCreditCardsController(IRegisteredCreditCardService registeredCreditCardService)
        {
            _registeredCreditCardService = registeredCreditCardService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _registeredCreditCardService.GetCustomersByRegisteredCreditCard();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _registeredCreditCardService.GetCustomerByRegisteredCreditCard(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(RegisteredCreditCard registeredCreditCard)
        {
            var result = _registeredCreditCardService.Add(registeredCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(RegisteredCreditCard registeredCreditCard)
        {
            var result = _registeredCreditCardService.Delete(registeredCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
