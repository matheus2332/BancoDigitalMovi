using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DevOpsController : Controller
    {
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "A Api esta OK!!!" };
        }
    }
}