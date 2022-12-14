using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chelsea.core.Models
{
    public class Product : BaseEntity
    {


        [StringLength(25)]
        [DisplayName("""Product Name""")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, 100000)]
        public decimal Price { get; set; }
        public string Catergory { get; set; }
        public string Image { get; set; }

    }
}
 
