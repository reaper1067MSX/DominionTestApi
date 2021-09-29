using System;
using System.Collections.Generic;

namespace Dominion.Test.Infrastructure.Entities
{
    public partial class Car
    {
        public Guid Location { get; set; }
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Model { get; set; }
        public decimal Milleage { get; set; }
        public string Color { get; set; }
        public bool Status { get; set; }

        public virtual Enterprise LocationNavigation { get; set; }
        public virtual Model ModelNavigation { get; set; }
    }
}
