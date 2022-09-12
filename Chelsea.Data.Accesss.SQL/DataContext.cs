using Chelsea.core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chelsea.Data.Accesss.SQL
{
   public class DataContext : DbContext
    {

        public DataContext()
           :base("DefaultConnection")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCatergory> ProductCatergories { get; set; }
    }
}
