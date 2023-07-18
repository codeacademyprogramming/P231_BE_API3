using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Service.Exceptions
{
    public class RestException:Exception
    {
        public RestException(HttpStatusCode code,string message)
        {
            Message = message;
            Code = code;
        }
        public RestException(HttpStatusCode code, string key, string errorMessage, string?message=null)
        {
            Message = message;
            Code = code;
            Errors = new List<RestExceptionErrorItem> { new RestExceptionErrorItem(key,errorMessage)};
        }

        public RestException(HttpStatusCode code, List<RestExceptionErrorItem> errors, string? message=null)
        {
            Message = message;
            Code = code;
            Errors = errors;
        }

        public string? Message { get; set; } 
        public HttpStatusCode Code { get; set; }
        public List<RestExceptionErrorItem> Errors { get; set; }
    }

    public class RestExceptionErrorItem
    {
        public string Key { get; set; }
        public string ErrorMessage { get; set; }

        public RestExceptionErrorItem(string key, string errorMessage)
        {
            Key = key;
            ErrorMessage = errorMessage;    
        }
    }
}
