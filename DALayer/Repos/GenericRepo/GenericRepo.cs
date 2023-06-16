using DALayer.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Repos.GenericRepo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ECommerceDb context;
        public GenericRepo(ECommerceDb _context)
        {
            context = _context;
        }

        public ECommerceDb Context { get; }

        public T add(T item)
        {
            context.Set<T>().Add(item);
            return item;
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public T? GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T? remove(int id)
        {
            var item = context.Set<T>().Find(id);
            context.Remove(item);
            return item;
        }

        public void update(T item)
        {
            
        }
    }
}
