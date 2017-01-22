using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogg.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogg.Models.ViewModels
{
    public class BlogNewPostViewModel
    {
        public Post Post { get; set; }
        public List<SelectListItem> Category { get; set; }
       
    }
}
