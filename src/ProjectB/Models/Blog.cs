using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
