using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chelsea.core.Models;
using Chelsea.Data.AccessMemory;

namespace Chelsea.uii.Controllers
{
    public class CatergoryController : Controller
    {
        InMemoryRepository<ProductCatergory> context;
        public CatergoryController()
        {
            context = new InMemoryRepository<ProductCatergory>();
        }


            // GET: Catergory
            public ActionResult Index()
            {
                
                List<ProductCatergory> catergories = context.Collection().ToList();
                return View(catergories);
            }
            public ActionResult Create()
            {
                ProductCatergory productCatergory = new ProductCatergory();
                return View(productCatergory);
            }
            [HttpPost]
            public ActionResult Create(ProductCatergory productCatergory)
            {
                if (!ModelState.IsValid)
                {
                    return View(productCatergory);
                }
                else
                {
                    context.Insert(productCatergory);
                    context.Commit();
                    return RedirectToAction("Index");
                }
            }

            public ActionResult Edit(string Id)
            {
                ProductCatergory productCatergory = context.Find(Id);
                if (productCatergory == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(productCatergory);
                }
            }
            [HttpPost]
            public ActionResult Edit(ProductCatergory productCatergory, string Id)
            {
                ProductCatergory CatergoryToEdit = context.Find(Id);
                if (CatergoryToEdit == null)
                {
                    return HttpNotFound();
                }
                else
                {
                   CatergoryToEdit.Catergory = productCatergory.Catergory;
                   context.Commit();
                   return RedirectToAction("Index");
                }
            }

            public ActionResult Delete(string Id)
            {
                ProductCatergory CatergoryToDelete = context.Find(Id);
                if (CatergoryToDelete == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(CatergoryToDelete);
                }
            }
            [HttpPost]
            [ActionName("Delete")]
            public ActionResult ConfirmDelete(string Id)
            {
                ProductCatergory CatergoryToDelete = context.Find(Id);
                if (CatergoryToDelete == null)
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
