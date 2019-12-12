using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotesAppFinal.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        //Added this controller so when you log out it doesn't crash
        //all it does is redirects to index in notes
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Notes");
        }
    }
}
