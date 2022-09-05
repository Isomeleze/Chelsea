using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chelsea.core.Models;
using Chelsea.Data.AccessMemory;

namespace Chelsea.uii.Controllers
{
    public class CategoryController : Controller
    {
        CatergoryRepository context;
        public CategoryController()
        {
            context = new CatergoryRepository();
        }
        // GET: Category
        public ActionResult Index()
        {
            List<ProductCatergory> categories = context.Collection().ToList();
            return View(categories);
        }
        public ActionResult Create()
        {
            ProductCatergory productCategory = new ProductCatergory();
            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCatergory category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            else
            {
                context.Insert(category);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ProductCatergory category = context.Find(Id);
            if (category == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(category);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductCatergory category, string Id)
        {
            ProductCatergory CategoryToEdit = context.Find(Id);
            if (CategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }
                CategoryToEdit.Category = category.Category;
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCatergory CategoryToDelete = context.Find(Id);
            if (CategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(CategoryToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCatergory CategoryToDelete = context.Find(Id);
            if (CategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                return RedirectToAction("Index");
            }
        }
    }
}
