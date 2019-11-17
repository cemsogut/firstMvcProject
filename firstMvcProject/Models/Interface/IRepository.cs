using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMvcProject.Models.Interface
{
    interface IRepository<T>
    {
        void save(T model);
        void update(T model);
        void delete(T model);
        T get(int Id);
        List<T> getAll();

    }
}
