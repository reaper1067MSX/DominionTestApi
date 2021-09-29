using Dominion.Test.CommonDomain.Entity;
using Dominion.Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Test.Services.Services
{
    public class ResponseService: IResponseService
    {
        private readonly ResponseEntity _entity = new ResponseEntity();

        public ResponseEntity Error(int statusCode, List<string> errorMessages)
        {
            _entity.StatusCode = statusCode;
            _entity.DescripcionId = "ERROR";
            _entity.Response = null;
            _entity.ErrorList.AddRange(errorMessages);
            return _entity;
        }

        public ResponseEntity Ok(dynamic response)
        {
            _entity.StatusCode = 200;
            _entity.DescripcionId = "OK";
            _entity.Response = response;

            return _entity;
        }

        public ResponseEntity Created(dynamic response)
        {
            _entity.StatusCode = 201;
            _entity.DescripcionId = "OK";
            _entity.Response = response;

            return _entity;
        }

        public List<string> GetErrors(string message, Exception ex = null)
        {
            List<string> errors = new List<string>();

            errors.Add(message);

            if (ex != null)
            {
                errors.Add(ex.Message);
                if (ex.InnerException != null)
                {
                    errors.Add(ex.InnerException.Message);
                }
            }

            return errors;
        }
    }
}
