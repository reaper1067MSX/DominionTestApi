using Dominion.Test.CommonDomain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Test.CommonDomain.ViewModels
{
    public class CarVM: CarEntity
    {
        public Guid IdEnterprise { get; set; }

        public bool Status { get; set; }

        public string Display { get; set; }

        public string ModelDescription { get; set; }
    }
}
