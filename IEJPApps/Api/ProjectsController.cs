using System;
using IEJPApps.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using IEJPApps.Exceptions;
using IEJPApps.Infrastructure;

namespace IEJPApps.Api
{
    [Authorize]
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        [Route("")]
        public List<Project> GetAll()
        {
            return _db.Projects
                .Include(x => x.TimeTransactions)
                .OrderBy(x => x.ProjectNumber)
                .ToList();
        }

        [Route("{id}")]
        public Project GetById(Guid id)
        {
            return _db.Projects
                .Include(x => x.TimeTransactions)
                .Include(x => x.ExpenditureTransactions)
                .SingleOrDefault(x => x.Id == id);
        }

        [HttpPost]
        [Route("")]
        public Project Create([FromBody] Project project)
        {
            if (!ModelState.IsValid) throw new HttpApiException("Invalid project model");

            project.Id = Guid.NewGuid();
            project.Created = DateTime.Now;

            _db.Projects.Add(project);
            _db.SaveChanges();

            return project;
        }

        [HttpPut]
        [Route("")]
        public Project Update([FromBody] Project project)
        {
            if (!ModelState.IsValid) throw new HttpApiException("Invalid project model");

            project.Updated = DateTime.Now;

            _db.Entry(project).State = EntityState.Modified;
            _db.SaveChanges();

            return project;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            var project = _db.Projects.Find(id);

            if (project == null)
                throw new HttpApiException("Project not found");

            _db.Projects.Remove(project);
            _db.SaveChanges();
        }
    }
}
