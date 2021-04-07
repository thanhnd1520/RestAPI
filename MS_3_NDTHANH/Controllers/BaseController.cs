using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS_3_NDTHANH.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_3_NDTHANH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        DatabaseConnector _dbConnector;
        public BaseController()
        {
            _dbConnector = new DatabaseConnector();
        }
        [HttpGet]
        public IEnumerable<T> Get()
        {
            var entity = _dbConnector.get<T>();
            return entity;
        }

        [HttpGet("{entityId}")]
        public T getById(Guid entityId)
        {
            var entity = _dbConnector.getById<T>(entityId);
            return entity;
        }

        [HttpPost]
        public virtual int Post([FromBody] T t)
        {
            var effectRow = _dbConnector.insert<T>(t);
            return effectRow;
        }
        [HttpDelete]
        public int DeledeById(Guid entityId)
        {
            var effectRow = _dbConnector.deleteById<T>(entityId);
            return effectRow;
        }
    }
}
