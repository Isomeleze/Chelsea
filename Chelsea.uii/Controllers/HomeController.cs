using Chelsea.core.Contracts;
using Chelsea.core.Models;
using Chelsea.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chelsea.uii.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCatergory> productCatergories;
        public HomeController(IRepository<Product> productContext, IRepository<ProductCatergory> catergoryContext)
        {
            context = productContext;
            productCatergories = catergoryContext;

        }
        public ActionResult Index(string Category = null)
        {
            List<Product> products;
            List<ProductCatergory> categories = productCatergories.Collection().ToList();
            if (Category == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Catergory == Category).ToList();
            }
            ProductListVM model = new ProductListVM();
            model.Products = products;
            model.ProductCatergories = categories;
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}