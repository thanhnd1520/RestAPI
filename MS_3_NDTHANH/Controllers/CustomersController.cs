using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS_3_NDTHANH.Data;
using MS_3_NDTHANH.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MS_3_NDTHANH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController<Customer>
    {
        public override int Post([FromBody] Customer customer)
        {
            customer.CustomerId = Guid.NewGuid();
            var dbconnector = new DatabaseConnector();
            var effectRow = dbconnector.insert<Customer>(customer);
            return effectRow;
        }
    }
}
