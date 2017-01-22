using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogg.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ange titel")]
        [StringLength(50, ErrorMessage = "Max 50 tecken")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Inlägget är tomt. Vänligen fyll i")]
        [StringLength(2000, ErrorMessage = "Max 2000 tecken")]
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
       
    }
}
