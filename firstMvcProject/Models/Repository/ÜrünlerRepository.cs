using firstMvcProject.Models.DBModel;
using firstMvcProject.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace firstMvcProject.Models.Repository
{ 
    public class ÜrünlerRepository : IRepository<Urunler>
{ 
    private NorthwindEntities db;

    public ÜrünlerRepository(NorthwindEntities _db)
    {
        db = _db;
    }
    public void delete(Urunler model)
    {
        db.Urunler.Remove(model);
        db.SaveChanges();
    }

    public Urunler get(int Id)
    {
        return db.Urunler.Find(Id);

    }

    public List<Urunler> getAll()
    {
        return db.Urunler.ToList();
    }

    public void save(Urunler model)
    {
        db.Urunler.Add(model);
        db.SaveChanges();
    }

    public void update(Urunler model)
    {
        db.Entry(model).State = EntityState.Modified;
        db.SaveChanges();
    }
        public List<Tedarikciler> GetSuppliers()
        {
            return db.Tedarikciler.ToList();
        }
        
    }
}
