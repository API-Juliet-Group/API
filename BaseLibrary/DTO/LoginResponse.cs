using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTO
{
    public class LoginResponse
    {
        public string Id {  get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
