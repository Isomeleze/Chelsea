using Chelsea.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chelsea.core.ViewModels
{
    public class ProductListVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductCatergory> ProductCatergories { get; set; }
    }
}
