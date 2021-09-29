using Dominion.Test.CommonDomain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Test.Services.Interfaces
{
    public interface IDealerServices
    {
        List<CarVM> GetCarsByEnterprise(Guid idLocation);

        List<CarVM> ProcessDealerSettings(List<CarVM> model);
    }
}
