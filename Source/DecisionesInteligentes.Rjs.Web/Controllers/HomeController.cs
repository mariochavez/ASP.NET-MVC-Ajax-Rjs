using System;
using System.Web.Mvc;
using DecisionesInteligentes.Rjs.Mvc;
using DecisionesInteligentes.Rjs.Web.Models;

namespace DecisionesInteligentes.Rjs.Web.Controllers
{
    [HandleError]
    public class HomeController : RjsController
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult AddName(string name)
        {
            var person = new Person
                              {
                                  Name = name,
                                  Id = (new Random()).Next()
                              };

            ViewData.Model = person;
            return Rjs();
        }

        [AcceptVerbs(HttpVerbs.Delete)]
        public ActionResult DelName(int id)
        {
            ViewData.Model = new Person {Id = id};
            return Rjs();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
