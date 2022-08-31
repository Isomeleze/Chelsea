using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chelsea.core.Models;
using Chelsea.Data.AccessMemory;


namespace Chelsea.uii.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository contex;

        public ProductController()
        {
            contex = new ProductRepository();
        }
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = contex.Collection().ToList();
            return View(products);
        }
    }
}