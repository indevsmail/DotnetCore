using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiAuthCrud.Models
{
    public class ResponseBase
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
