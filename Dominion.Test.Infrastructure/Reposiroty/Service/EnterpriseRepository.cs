using Dominion.Test.CommonDomain.ViewModels;
using Dominion.Test.Infrastructure.Entities;
using Dominion.Test.Infrastructure.Reposiroty.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Dominion.Test.Infrastructure.Reposiroty.Service
{
    public class EnterpriseRepository: GenericRepository<Enterprise, DominionContext>, IEnterpriseRepository
    {
        public EnterpriseRepository(DominionContext _context) : base(_context) { }
        
        public List<EnterpriseVM> GetAllEnterprises()
        {
            var result =    (from e in _context.Enterprise
                                where e.Status == true
                                select new EnterpriseVM
                                { 
                                    Id = e.Id,
                                    Description = e.Description
                                }
                            ).ToList();

            return result;
        }
    }
}
