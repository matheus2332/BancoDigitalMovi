using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Clientes;
using Services.Emprestimos;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : BaseController
    {
        private readonly IClienteServices _clienteServices;
        private readonly IEmprestimoServices _emprestimoServices;

        public ClienteController(IClienteServices clienteServices, IEmprestimoServices emprestimoServices)
        {
            _clienteServices = clienteServices;
            _emprestimoServices = emprestimoServices;
        }

        [Route("dados")]
        public JsonResult Get()
        {
            return Json(_clienteServices.GetDadosParaEmprestimo(GetClienteId()));
        }

        [Route("meus-emprestimos")]
        public JsonResult GetEmprestimos() => Json(_emprestimoServices.GetMeusEmprestimos(GetClienteId()));
    }
}