using Dominion.Test.Infrastructure.Reposiroty.Interface;
using Dominion.Test.Infrastructure.Reposiroty.Service;
using Dominion.Test.Services.Interfaces;
using Dominion.Test.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominion.Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpriseController : ControllerBase
    {
        private readonly IEnterpriseServices _enterpriseServices;
        private readonly IResponseService _responseServices;
        private readonly IContext<DominionContext> _context;
        

        public EnterpriseController(IResponseService responseServices, DominionContext context)
        {
            _responseServices = responseServices;
            _context = new Context(context);
            _enterpriseServices = new EnterpriseServices(_context);
        }

        [HttpGet]
        [Route("All")]
        public IActionResult GetAllEnterprises()
        {
            try
            {
                var result = _enterpriseServices.GetAllEnterprises();
                return Ok(_responseServices.Ok(result));
            }
            catch (Exception ex)
            {
                return Conflict(_responseServices.Error(409, _responseServices.GetErrors("Error interno del servidor", ex)));
            }
        }    
    }
}
