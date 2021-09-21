using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalGrub.Models
{
    public class Category
    {
        //all pk fields in asp.net mvc should be called either {Model}Id or Id
        //property names should always use PascalCase

        [Range(0,999999)]
        [Display(Name = "Category Id")] //this set an alias for all labels globally
        public int CategoryId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "And no empty strings!")]
        public string Name { get; set; }
    }
}
