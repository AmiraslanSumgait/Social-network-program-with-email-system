using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminNamespace
{
    class Admin
    {
        public int ID { get; set; } = 0;
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Admin()
        {
            Id = ++ID;
        }
    }
}
