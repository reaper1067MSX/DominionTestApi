using Dominion.Test.CommonDomain.ViewModels;
using Dominion.Test.Infrastructure.Entities;
using Dominion.Test.Infrastructure.Reposiroty.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dominion.Test.Infrastructure.Reposiroty.Service
{
    public class DealerRepository: GenericRepository<Car, DominionContext>, IDealerRepository
    {
        public DealerRepository(DominionContext _context): base(_context) {}

        public List<CarVM> GetCarsByEnterprise(Guid idLocation)
        {
            var result =    (from c in _context.Car
                                join m in _context.Model on new { c.Location, c.Model } equals new { m.Location, Model = m.Id }
                                join e in _context.Enterprise on c.Location equals e.Id
                                where c.Status == true && e.Status == true && c.Location == idLocation
                             select new CarVM
                                {
                                    Id = c.Id,
                                    IdEnterprise = c.Location,
                                    Price = c.Price,
                                    Model = c.Model,
                                    ModelDescription = m.Description,
                                    Milleage = c.Milleage,
                                    Color = c.Color,
                                    Status = c.Status
                                }
                             ).ToList();
            return result;
        }

        public CarVM GetCarByIdAndEnterprise(Guid idLocation, Guid idCar)
        {
            var result =    (from c in _context.Car
                                join m in _context.Model on new { c.Location, c.Model } equals new { m.Location, Model = m.Id }
                                join e in _context.Enterprise on c.Location equals e.Id
                                where c.Status == true && e.Status == true && c.Location == idLocation && c.Id == idCar
                                select new CarVM
                                {
                                    Id = c.Id,
                                    IdEnterprise = c.Location,
                                    Price = c.Price,
                                    Model = c.Model,
                                    ModelDescription = m.Description,
                                    Milleage = c.Milleage,
                                    Color = c.Color,
                                    Status = c.Status
                                }
                            ).FirstOrDefault();
            return result;
        }
    }
}
