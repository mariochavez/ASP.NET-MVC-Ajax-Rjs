using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DecisionesInteligentes.Rjs.Mvc;
using DecisionesInteligentes.Rjs.Web.Models;

namespace DecisionesInteligentes.Rjs.Web.Controllers
{
    [HandleError]
    public class HomeController : RjsController
    {
		DataService dataService = null;
		public HomeController ()
		{
			dataService = new DataService();
		}
		
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
				
			ViewData["States"] = BuildSelectList(dataService.GetStates(), "Id", "Value");
			ViewData["Cities"] = BuildSelectList(dataService.GetCities(1), "Id", "Value");

            return View();
        }
		
		//[ValidateAntiForgeryToken]
		[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddName(string name)
        {
            var person = new Person
                              {
                                  Name = name,
                                  Id = (new Random()).Next()
                              };
			
			System.Threading.Thread.Sleep(5000);
            ViewData.Model = person;
            return Rjs();
        }
		
		//[ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Delete)]
        public ActionResult DelName(int id)
        {
            ViewData.Model = new Person {Id = id};
            return Rjs();
        }
		
		//[ValidateAntiForgeryToken]
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult StateChange(int id)
		{
			System.Threading.Thread.Sleep(5000);
			ViewData.Model = dataService.GetCities(id);
			return Rjs();
		}

        public ActionResult About()
        {
            return View();
        }
		
		SelectList BuildSelectList(IEnumerable<DataValue> data, string dataField, string valueField)
		{
			return new SelectList(data, dataField, valueField); 
		}
		
    }
}
