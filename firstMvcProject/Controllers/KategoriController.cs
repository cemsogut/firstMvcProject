using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using firstMvcProject.Models.DBModel;
using firstMvcProject.Models.Repository;

namespace firstMvcProject.Controllers
{
   
    public class KategoriController : Controller
    {
        KategoriRepository KP = new KategoriRepository(new Models.DBModel.NorthwindEntities());
        // GET: Kategori
        public ActionResult Index()
        {
            return View (KP.getAll());
        }
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(Kategoriler model)
        {
            if(ModelState.IsValid)
            {
                KP.save(model);
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View(KP.get(id));
        }

        [HttpPost]
        public ActionResult Edit (Kategoriler model)
        {
            if (ModelState.IsValid)
            {
                KP.update(model);
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete (int id)
        {
            return View (KP.get(id));
        }
        [HttpPost,ActionName("Delete")]

        public ActionResult DeleteKategori (int id)
        {
            if (ModelState.IsValid)
            {
                KP.delete(KP.get(id));
                
            }
            return RedirectToAction("index");
        }
    }
}