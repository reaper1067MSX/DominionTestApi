using Dominion.Test.CommonDomain.ViewModels;
using Dominion.Test.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Test.Infrastructure.Reposiroty.Interface
{
    public interface IDealerRepository : IGenericRepository<Car>
    {
        public List<CarVM> GetCarsByEnterprise(Guid idLocation);

        public CarVM GetCarByIdAndEnterprise(Guid idLocation, Guid idCar);
    }
}
