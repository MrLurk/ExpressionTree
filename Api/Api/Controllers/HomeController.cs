using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var services = new ExpressionServices();
            services.NoParaPlusExpressionTest();
            services.ParaPlusMultiplyExpressionTest();
            services.ParaObjectExpressionTest();
            return Ok(1);
        }


        [HttpGet("get2")]
        public ActionResult Get2()
        {
            var services = new StudentServices();
            services.GetAllStudent();
            return Ok(1);
        }
    }
}
