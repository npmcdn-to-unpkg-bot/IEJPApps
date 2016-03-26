using System;
using IEJPApps.Models;
using IEJPApps.Models.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;

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
            return _db.Projects.OrderBy(x => x.ProjectNumber).ToList();
        }

        [Route("{id}")]
        public Project GetById(Guid id)
        {
            return _db.Projects.Find(id); ;
        }

        [HttpPost]
        [Route("")]
        public Project Create([FromBody] Project project)
        {
            if (ModelState.IsValid)
            {
                project.Id = Guid.NewGuid();
                project.Created = DateTime.Now;

                _db.Projects.Add(project);
                _db.SaveChanges();

                return project;
            }

            throw new Exception("Invalid Project Model");
        }

        [HttpPut]
        [Route("")]
        public Project Update([FromBody] Project project)
        {
            if (ModelState.IsValid)
            {
                project.Updated = DateTime.Now;

                _db.Entry(project).State = EntityState.Modified;
                _db.SaveChanges();

                return project;
            }

            throw new Exception("Invalid Project Model");
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            var project = _db.Projects.Find(id);

            if (project == null)
                throw new Exception("Project Not Found");

            _db.Projects.Remove(project);
            _db.SaveChanges();
        }
    }
}
