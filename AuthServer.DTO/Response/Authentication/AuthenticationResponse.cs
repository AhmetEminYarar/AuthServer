using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.DTO.Response.Authentication
{
    public class AuthenticationResponse
    {
        public string CreateToken { get; set; }=string.Empty;
    }
}
