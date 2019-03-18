using System;
using System.Collections.Generic;
using Dtos.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Emprestimos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEmprestimoServices _emprestimoServices;

        public ValuesController(IEmprestimoServices emprestimoServices)
        {
            _emprestimoServices = emprestimoServices;
        }

        public ActionResult<IEnumerable<string>> Get()
        {
            _emprestimoServices.Save(new EmprestimoFormDto
            {
                ValorDoEmprestimo = 100,
                ClienteId = Guid.Parse("DDD0366C-8651-4A2A-A0F0-08D925E0D348"),
                DataDoEmprestimo = DateTime.Now,
            });
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}