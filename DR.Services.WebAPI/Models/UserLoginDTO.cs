using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DR.Services.WebAPI.Models
{
    public class UserLoginDTO
    {
        public string LoginName { get; set; }
        public string Password { get; set; }
    }
}