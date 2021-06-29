using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserNamespace
{
    class User
    {
        public static int ID { get; set; } = 10;
        public int Id { get; set; } 
        public string Username { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public User()
        {
            Id = ++ID;
        }
       
        public void show()
        {
            Console.WriteLine($"Id:{Id}");
            Console.WriteLine($"Username:{Username}");
            Console.WriteLine($"Email:{Email}");
            Console.WriteLine($"Age:{Age}");
            Console.WriteLine($"Password:{Password}");

        }
    }
}   
