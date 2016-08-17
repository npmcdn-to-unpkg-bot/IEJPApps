using System;
using System.Collections.Generic;
using System.Web.Http;
using IEJPApps.Exceptions;
using IEJPApps.Models;
using IEJPApps.Repositories;

namespace IEJPApps.Api
{
    [Authorize]
    [RoutePrefix("api/expenditures")]
    public class ExpendituresController : ApiController
    {
        private readonly ExpenditureRepository _expenditures = new ExpenditureRepository();

        [Route("")]
        public List<ExpenditureTransaction> GetAll()
        {
            return _expenditures.GetAll();
        }

        [Route("{id}")]
        public ExpenditureTransaction GetById(Guid id)
        {
            return _expenditures.GetByID(id);
        }

        [HttpPost]
        [Route("")]
        public ExpenditureTransaction Create([FromBody] ExpenditureTransaction transaction)
        {
            if (!ModelState.IsValid)
                throw new HttpApiException("Invalid Expenditure Transaction Model");
            
            return _expenditures.Create(transaction);
        }

        [HttpPut]
        [Route("")]
        public ExpenditureTransaction Update([FromBody] ExpenditureTransaction transaction)
        {
            if (!ModelState.IsValid)
                throw new HttpApiException("Invalid Expenditure Transaction Model");
            
            return _expenditures.Update(transaction);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            var transaction = _expenditures.GetByID(id);

            if (transaction == null)
                throw new HttpApiException("Expenditure Transaction Not Found");
            
            _expenditures.Delete(transaction);
        }
    }
}