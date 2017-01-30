using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeApplication.Models;

namespace TimeApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBContext dbContext;

        public HomeController(DBContext db)
        {
            dbContext = db;
        }


    public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

       

    }
}
