using System;
using IEJPApps.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using IEJPApps.Exceptions;
using IEJPApps.Infrastructure;
using IEJPApps.ViewModels;

namespace IEJPApps.Api
{
    [Authorize]
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        [Route("")]
        public List<ProjectViewModel> GetAll()
        {
            //return _db.Projects
            //    .Include(x => x.TimeTransactions)
            //    .OrderBy(x => x.ProjectNumber)
            //    .ToList();
            
            var query = _db.Projects
                .Include(x => x.TimeTransactions)
                .Include(x => x.ExpenditureTransactions)
                .Select(x => new ProjectViewModel
                {
                    Id = x.Id,
                    Active = x.Active,
                    Visible = x.Visible,
                    ProjectNumber = x.ProjectNumber,
                    Customer = x.Customer,
                    Description = x.Description,
                    TimeCount = x.TimeTransactions.Count(),
                    TimeTotal = x.TimeTransactions.Sum(t => t.Time),
                    ExpenditureCount = x.ExpenditureTransactions.Count(),
                    ExpenditureTotal = x.ExpenditureTransactions.Sum(e => e.Amount),
                    Started = x.Started,
                    Completed = x.Completed
                });
            
                //from project in _db.Projects
                //join timesheet in _db.TimeTransactions on project.Id equals timesheet.ProjectId //into timegrp
                //join expenditure in _db.ExpenditureTransactions on project.Id equals expenditure.ProjectId //into expgrp
                //group timesheet by timesheet.ProjectId into timegrp
                //group expenditure by expenditure.pr
                //select new ProjectViewModel
                //{
                //    Id = project.Id,
                //    Active = project.Active,
                //    Visible = project.Visible,
                //    ProjectNumber = project.ProjectNumber,
                //    Customer = project.Customer,
                //    Description = project.Description,
                //    TimeTotal = timegrp.Sum(x => x.Time),
                //    //ExpenditureTotal = expgrp.Sum(x => x.Amount),
                //    Started = project.Started,
                //    Completed = project.Completed
                //};

            return query.ToList();

            //public class ProjectViewModel
            //{
            //    public Guid Id { get; set; }
            //    public bool Active { get; set; }
            //    public bool Visible { get; set; }
            //    public string ProjectNumber { get; set; }
            //    public string Customer { get; set; }
            //    public string Description { get; set; }
            //    public decimal TimeTotal { get; set; }
            //    public decimal ExpenditureTotal { get; set; }
            //    public string FullDescription { get; set; }
            //    public DateTime? Started { get; set; }
            //    public DateTime? Completed { get; set; }
            //}
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
