using RESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTAPI.Controllers
{
    public class NewController : ApiController
    {
        web_api_crud_dbEntities db = new web_api_crud_dbEntities();

        public IHttpActionResult GetData()
        {
            List<Employee> list = db.Employees.ToList();
            return Ok(list);
        }

        public IHttpActionResult GetDataById(int id)
        {
            var details = db.Employees.Where(x=>x.id==id).FirstOrDefault();
            return Ok(details);
        }

        [HttpPost]
        public IHttpActionResult InsertEmployee(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateEmp(Employee e)
        {
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmp(int id)
        {
            var emp = db.Employees.Where(x => x.id == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}
