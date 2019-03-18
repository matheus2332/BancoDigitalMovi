using System;
using Dtos.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Emprestimos;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : BaseController
    {
        private readonly IEmprestimoServices _emprestimoServices;

        public EmprestimoController(IEmprestimoServices emprestimoServices)
        {
            _emprestimoServices = emprestimoServices;
        }

        [HttpPost]
        public JsonResult Post([FromBody]EmprestimoFormDto formDto)
        {
            formDto.ClienteId = GetClienteId();
            return Json(_emprestimoServices.Save(formDto));
        }
    }
}