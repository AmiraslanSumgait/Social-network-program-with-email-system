using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostNamespace
{
    class Post
    {
        public static int ID { get; set; } = 50;
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }
        private Random gen = new Random();
        DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60));
        }
        public Post(string content)
        {
           
            Id = ++ID;
            Content = content;
            CreationDateTime = RandomDay();
            LikeCount = 0;
            ViewCount = 0;

        }
        public void show()
        {
            Console.WriteLine($"Id:{Id}");
            Console.WriteLine($"Content:{Content}");
            Console.WriteLine($"CreationDateTime:{CreationDateTime}");
            Console.WriteLine($"LikeCount:{LikeCount}");
            Console.WriteLine($"ViewCount:{ViewCount}");
        }
    }
}
