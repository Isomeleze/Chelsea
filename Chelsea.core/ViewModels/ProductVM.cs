using Chelsea.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chelsea.core.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<ProductCatergory> ProductCatergories { get; set; }
        public IQueryable<ProductCatergory> ProductCatergory { get; set; }
    }
}
    
