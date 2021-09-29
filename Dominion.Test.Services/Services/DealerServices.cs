using Dominion.Test.CommonDomain.ViewModels;
using Dominion.Test.Infrastructure.Reposiroty.Interface;
using Dominion.Test.Infrastructure.Reposiroty.Service;
using Dominion.Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Test.Services.Services
{
    public class DealerServices: IDealerServices
    {
        private readonly IContext<DominionContext> _context;

        public DealerServices(IContext<DominionContext> context)
        {
            _context = context;
        }

        public List<CarVM> GetCarsByEnterprise(Guid idLocation)
        {
            var result = _context.GetDealerRepository.GetCarsByEnterprise(idLocation);
            return result;
        }

        public CarVM GetCarByIdAndEnterprise(Guid idLocation, Guid idCar)
        {
            var result = _context.GetDealerRepository.GetCarByIdAndEnterprise(idLocation, idCar);
            return result;
        }

        public List<CarVM> ProcessDealerSettings(List<CarVM> model)
        {
            var dealers = _context.GetEnterpriseRepository.GetAllEnterprises();
            if(dealers.Count > 0)
            {
                foreach (var item in model)
                {
                    if (item.IdEnterprise == dealers[0].Id)
                    {
                        item.Display = "FOR SALE";
                    }
                    else
                    {
                        item.Display = "ACTIVE";
                    }
                }
            }
            
            return model;
        }
    }
}
