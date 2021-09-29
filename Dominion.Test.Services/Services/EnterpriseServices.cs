using Dominion.Test.CommonDomain.ViewModels;
using Dominion.Test.Infrastructure.Reposiroty.Interface;
using Dominion.Test.Infrastructure.Reposiroty.Service;
using Dominion.Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Dominion.Test.Services.Services
{
    public class EnterpriseServices: IEnterpriseServices
    {
        private readonly IContext<DominionContext> _context;

        public EnterpriseServices(IContext<DominionContext> context)
        {
            _context = context;
        }  

        public List<EnterpriseVM> GetAllEnterprises()
        {
            var result = _context.GetEnterpriseRepository.GetAllEnterprises();
            return result;
        }
    }
}
