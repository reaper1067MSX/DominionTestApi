using Dominion.Test.CommonDomain.ViewModels;
using Dominion.Test.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Test.Infrastructure.Reposiroty.Interface
{
    public interface IEnterpriseRepository: IGenericRepository<Enterprise>
    {
        List<EnterpriseVM> GetAllEnterprises();
    }
}
