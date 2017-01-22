using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogg.Models.ViewModels
{
    public class BlogSearchViewModel
    {
        public List<Post> Posts { get; set; }
        public List<Category> Categories { get; set; }
    }
}
