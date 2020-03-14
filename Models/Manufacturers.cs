using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProtonComputers.Models
{
    public class Manufacturers
    {
        public Manufacturers()
        {
            this.ManufacturerName = "";
            this.WebsiteName = "";
            this.ProductList = new List<Products>();
        }

        [Key]
        public int ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        public string WebsiteName { get; set; }
        public DateTime Founded { get; set; }

        public virtual ICollection<Products> ProductList { get; set; }
    }
}
