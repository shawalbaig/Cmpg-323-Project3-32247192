using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Linq.Expressions;
using DeviceManagement_WebApp.Generic;
using DeviceManagement_WebApp.Interface;


namespace DeviceManagement_WebApp.Generic
{
    public class GinericRepository<T> : IGinericRepository<T> where T : class
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();
        public GinericRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);

        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> exspression)
        {
            return _context.Set<T>().Where(exspression);

        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);

        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);

        }
    }
   
}
