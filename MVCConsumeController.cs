using RESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace RESTAPI.Controllers
{
    public class MVCConsumeController : Controller
    {
        // GET: MVCConsume
        HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            List<Employee> emp = new List<Employee>();
            client.BaseAddress = new Uri("http://localhost:49620/api/New");
            var response = client.GetAsync("New");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee>>();
                display.Wait();
                emp = display.Result;
            }

            return View(emp);
        }

        public ActionResult Details(int id)
        {
            Employee emp = null;
            client.BaseAddress = new Uri("http://localhost:49620/api/New");
            var response = client.GetAsync("New?id="+id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                emp = display.Result;
            }

            return View(emp);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee e)
        {
            client.BaseAddress = new Uri("http://localhost:49620/api/New");
            var response = client.PostAsJsonAsync<Employee>("New",e);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Edit(int id)
        {
            Employee emp = null;
            client.BaseAddress = new Uri("http://localhost:49620/api/New");
            var response = client.GetAsync("New?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                emp = display.Result;
            }

            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            client.BaseAddress = new Uri("http://localhost:49620/api/New");
            var response = client.PutAsJsonAsync<Employee>("New",e);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            Employee emp = null;
            client.BaseAddress = new Uri("http://localhost:49620/api/New");
            var response = client.GetAsync("New?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                emp = display.Result;
            }

            return View(emp);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("http://localhost:49620/api/New");
            var response = client.DeleteAsync("New/" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Delete");
        }
    }
}