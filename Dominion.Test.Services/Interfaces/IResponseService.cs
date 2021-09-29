using Dominion.Test.CommonDomain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Test.Services.Interfaces
{
    public interface IResponseService
    {
        ResponseEntity Ok(dynamic response);

        ResponseEntity Created(dynamic response);

        ResponseEntity Error(int statusCode, List<string> errorMessages);

        List<string> GetErrors(string message, Exception ex = null);
    }
}
