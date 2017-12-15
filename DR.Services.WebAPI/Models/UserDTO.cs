using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Services.WebAPI.Models
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string UserRole { get; set; }
    }
}
