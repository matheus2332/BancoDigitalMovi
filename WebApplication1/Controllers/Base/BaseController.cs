using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace WebApi.Controllers.Base
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        public Guid GetClienteId()
        {
            var claim = ((ClaimsIdentity)User.Identity);
            return Guid.Parse(claim.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault());
        }
    }
}