using firstMvcProject.Models.DBModel;
using firstMvcProject.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace firstMvcProject.Controllers
{
    public class ProductController : Controller
    {
        ÜrünlerRepository ÜP = new ÜrünlerRepository(new Models.DBModel.NorthwindEntities());
        KategoriRepository KP = new KategoriRepository(new Models.DBModel.NorthwindEntities());
        // GET: Product
        public ActionResult Index()
        {
            return View(ÜP.getAll());
        }
        public ActionResult Create()
        {
            ViewBag.Kategoriler = KP.getAll();
            ViewBag.Tedarikciler = ÜP.GetSuppliers();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Urunler model)
        {    
            if(ModelState.IsValid)
            {
                ÜP.save(model);
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            //var selectedCategory = ÜP.get(id).KategoriID;
            //var selectedSupplier = ÜP.get(id).TedarikciID;

            //ViewBag.Kategoriler = new SelectList(KP.getAll),
            //return View(ÜP.get(id));
            ViewBag.Kategoriler = KP.getAll();
            ViewBag.Tedarikciler = ÜP.GetSuppliers();
            return View(ÜP.get(id));
        }

        [HttpPost]
        public ActionResult Edit(Urunler model)
        {
            if (ModelState.IsValid)
            {
                ÜP.update(model);
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(ÜP.get(id));
        }
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteÜrünler(int id)
        {
            if (ModelState.IsValid)
            {
                ÜP.delete(ÜP.get(id));

            }
            return RedirectToAction("index");
        }
    }
}