using Dominion.Test.CommonDomain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Test.Services.Interfaces
{
    public interface IEnterpriseServices
    {
        public List<EnterpriseVM> GetAllEnterprises();
    }
}
