using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Api
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class BaseEntityController<TEntity> : ControllerBase
    {
        #region Declare
        IBaseService<TEntity> _baseService;
        #endregion

        #region Constructor
        public BaseEntityController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Method
        // GET: api/<BaseEntityController>
        [HttpGet]
        public IEnumerable<TEntity> Get()
        {
            return _baseService.GetEntities();
        }

        // GET api/<BaseEntityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BaseEntityController>
        [HttpPost]
        public int Post([FromBody] TEntity value)
        {
            var rowAffect = _baseService.AddCustomer(value);
            return rowAffect;
        }

        // PUT api/<BaseEntityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BaseEntityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion
    }
}
