using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using IEJPApps.Infrastructure;
using IEJPApps.Repositories.Interfaces;

namespace IEJPApps.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        private DbSet<T> set;

        public Repository()
        {
            set = _context.Set<T>();
        }

        protected IPrincipal CurrentUser
        {
            get { return HttpContext.Current.User; }
        }

        protected DbSet<T> Set
        {
            get { return set; }
        }

        public T GetByID(Guid id)
        {
            return Set.Find(id);
        }

        public List<T> GetAll()
        {
            return Set.ToList();
        }

        public T Create(T entity)
        {
            set.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public T Update(T entity)
        {
            // once we return the response to the user, the object is disconnected
            // from the context. In order for updates and deletes to work, the object
            // must be added back on
            //set.Attach(entity);

            // Must tell the context the object is changed
            _context.Entry(entity).State = EntityState.Modified;

            _context.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            set.Attach(entity);
            set.Remove(entity);
            _context.SaveChanges();
        }
    }
}