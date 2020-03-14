using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProtonComputers.Models
{
    public class Products
    {
        public Products()
        {
            this.ProductName = "";
            this.ProductDescription = "";
        }

        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }

        [ForeignKey("Manufacturers")]
        public int ManufacturerID { get; set; }
        public virtual Manufacturers Manufacturers { get; set; }
    }
}
