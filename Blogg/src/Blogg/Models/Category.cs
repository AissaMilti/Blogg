using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogg.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Post> Posts { get; set; }
    }
}
