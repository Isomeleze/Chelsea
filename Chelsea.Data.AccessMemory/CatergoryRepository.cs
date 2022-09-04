using Chelsea.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Chelsea.Data.AccessMemory
{
    public class CatergoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCatergory> categories = new List<ProductCatergory>();
        public CatergoryRepository()
        {
            categories = cache["categories"] as List<ProductCatergory>;
            if (categories == null)
            {
                categories = new List<ProductCatergory>();
            }
        }

        public void Commit()
        {
            cache["categories"] = categories;
        }

        public void Insert(ProductCatergory c)
        {
            categories.Add(c);
        }

        public void Update(ProductCatergory category)
        {
            ProductCatergory categoryToUpdate = categories.Find(c => c.Id == category.Id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate = category;
            }
            else
            {
                throw new Exception("Category Was not Find");
            }
        }
        public ProductCatergory Find(string Id)
        {
            ProductCatergory category = categories.Find(c => c.Id == Id);
            if (category != null)
            {
                return category;
            }
            else
            {
                throw new Exception("Category Was not Find");
            }
        }
        public IQueryable<ProductCatergory> Collection()
        {
            return categories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCatergory categoryToDelete = categories.Find(c => c.Id == Id);
            if (categoryToDelete != null)
            {
                categories.Remove(categoryToDelete);
            }
            else
            {
                throw new Exception("Category Was not Find");
            }
        }
    }
}

