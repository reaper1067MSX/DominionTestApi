using System;
using System.Collections.Generic;

namespace Dominion.Test.Infrastructure.Entities
{
    public partial class Model
    {
        public Model()
        {
            Car = new HashSet<Car>();
        }

        public Guid Location { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public virtual Enterprise LocationNavigation { get; set; }
        public virtual ICollection<Car> Car { get; set; }
    }
}
