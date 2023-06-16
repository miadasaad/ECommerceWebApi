using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Repos.GenericRepo
{
    public interface IGenericRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById (int id);
        T add (T item);
        T remove (int id);
        void update (T item);
    }
}
