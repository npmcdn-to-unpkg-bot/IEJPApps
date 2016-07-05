using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IEJPApps.Models.Infrastructure;
using System.Security.Principal;
using System.Web;

namespace IEJPApps.Models.Repositories
{
    public class Repository<T> where T : class, new()
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        private DbSet<T> set;

        public Repository()
        {
            set = context.Set<T>();
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

        public void Create(T entity)
        {
            set.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            // once we return the response to the user, the object is disconnected
            // from the context. In order for updates and deletes to work, the object
            // must be added back on
            set.Attach(entity);

            // Must tell the context the object is changed
            context.Entry<T>(entity).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            set.Attach(entity);
            set.Remove(entity);
            context.SaveChanges();
        }
    }
}