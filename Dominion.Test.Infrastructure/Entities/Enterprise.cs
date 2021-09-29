using System;
using System.Collections.Generic;

namespace Dominion.Test.Infrastructure.Entities
{
    public partial class Enterprise
    {
        public Enterprise()
        {
            Car = new HashSet<Car>();
            Model = new HashSet<Model>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Direction { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Car> Car { get; set; }
        public virtual ICollection<Model> Model { get; set; }
    }
}
