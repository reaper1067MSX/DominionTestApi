using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Test.CommonDomain.Entity
{
    public abstract class CarEntity
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public string Model { get; set; }

        public decimal Milleage { get; set; }

        public string Color { get; set; }
    }
}
