using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalGrub.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        [Range(1, 999999)]
        public int Quantity { get; set; }

        [Range(0.01, 999999)]
        public double Price { get; set; }

        public int ProductId { get; set; }

        public string UserId { get; set; }

        public Product Product { get; set; }//represent the parent object(1 product to many cartitems)

    }
}
