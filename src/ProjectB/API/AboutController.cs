using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectB.Data;
using ProjectB.Models;
using ProjectB.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectB.API
{
    [Route("api/[controller]")]
    public class AboutController : Controller
    {
        private IAboutService _service;
        public AboutController(IAboutService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllQuotes());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetQuoteById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Quote _quote)
        {

            if(ModelState.IsValid)
            {
                _service.SaveQuote(_quote);
                return Ok(_quote);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
