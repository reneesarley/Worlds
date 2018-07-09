using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using World.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace World.Controllers
{
    public class CountryController : Controller
    {
        // GET: /<controller>/
        public IActionResult CountryList()
        {
            return View(Country.GetAll());
        }

        public IActionResult CountryForm()
        {
            return View(Country.AllColumnsList());
        }

        [HttpGet("/result")]
        public IActionResult FormResult()
        {   
            
            //if (Request.Query["selection"].GetType() == string)
            //{
                
            //}
            object userSelections = Request.Query["selection"];  
            return View(Country.AllResults(userSelections));
        }


    }
}
