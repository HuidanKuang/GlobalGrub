using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalGrub.Models
{
    public class Category
    {
        //all pk(primary key) fields in asp.net mvc should be called either {Model}Id or Id
        //property names should always use PascalCase



        [Range(0,999999)]
        [Display(Name = "Category Id")] //this set an alias for all labels globally

        //1st step: add a primary key of the Category model
        public int CategoryId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "And no empty strings!")]

        //2nd step: add a "name" property
        [MaxLength(100)]
        public string Name { get; set; }

        //child ref
        public List<Product> Products { get; set; }
    }
}
