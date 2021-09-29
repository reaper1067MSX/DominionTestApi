using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Test.CommonDomain.Entity
{
    public class ResponseEntity
    {
        public int StatusCode { get; set; }

        public string DescripcionId { get; set; }

        public dynamic Response { get; set; }

        public List<string> ErrorList { get; set; }
    }
}
