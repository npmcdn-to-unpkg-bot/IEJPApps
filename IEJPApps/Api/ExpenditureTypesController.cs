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
    [RoutePrefix("api/expenditures-types")]
    public class ExpenditureTypesController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        [Route("")]
        public List<ExpenditureType> GetAll() // TODO : Parametre visible/invisible
        {
            return _db.ExpenditureTypes
                //.Where(x => x.Visible)
                .OrderByDescending(x => x.Name)
                .ToList();
        }

        [Route("{id}")]
        public ExpenditureType GetById(Guid id)
        {
            return _db.ExpenditureTypes.Find(id);
        }

        [HttpPost]
        [Route("")]
        public ExpenditureType Create([FromBody] ExpenditureType entity)
        {
            if (ModelState.IsValid)
            {
                entity.Id = Guid.NewGuid();

                _db.ExpenditureTypes.Add(entity);
                _db.SaveChanges();

                return entity;
            }

            throw new Exception("Invalid Expenditure Type Model");
        }

        [HttpPut]
        [Route("")]
        public ExpenditureType Update([FromBody] ExpenditureType entity)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();

                return entity;
            }

            throw new Exception("Invalid Expenditure Type Model");
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            var entity = _db.ExpenditureTypes.Find(id);

            if (entity == null)
                throw new Exception("Expenditure Type Not Found");

            _db.ExpenditureTypes.Remove(entity);
            _db.SaveChanges();
        }
    }
}