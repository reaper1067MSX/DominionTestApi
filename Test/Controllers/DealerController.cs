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
    public class DealerController : ControllerBase
    {
        private readonly IDealerServices _dealerServices;
        private readonly IResponseService _responseServices;
        private readonly IContext<DominionContext> _context;

        public DealerController(IResponseService responseServices, DominionContext context)
        {
            _responseServices = responseServices;
            _context = new Context(context);
            _dealerServices = new DealerServices(_context);
        }

        [HttpGet]
        [Route("Cars/Location/{idLocation}")]
        public IActionResult GetAllCarsByLocation(string idLocation)
        {
            try
            {
                return Ok(_responseServices.Ok(_dealerServices.ProcessDealerSettings(_dealerServices.GetCarsByEnterprise(Guid.Parse(idLocation)))));
            }
            catch (Exception ex)
            {
                return Conflict(_responseServices.Error(409, _responseServices.GetErrors("Error interno del servidor", ex)));
            }
        }

        [HttpGet]
        [Route("Car/{idCar}/Location/{idLocation}")]
        public IActionResult GetAllCarsByLocation([FromBody] string idCar, string idLocation)
        {
            try
            {
                return Ok(_dealerServices.GetCarsByEnterprise(Guid.Parse(idLocation)));
            }
            catch (Exception ex)
            {
                return Conflict(_responseServices.Error(409, _responseServices.GetErrors("Error interno del servidor", ex)));
            }
        }
    }
}
