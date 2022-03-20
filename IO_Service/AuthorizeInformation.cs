using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_Service
{
    internal class AuthorizeInformation
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
