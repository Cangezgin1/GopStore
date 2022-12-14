using DataAccsessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GopStore.Controllers
{
    public class HomeController : Controller
    {

        Context c = new Context();

        public IActionResult StudentList()   
        {
            var values = c.Users.ToList();
            return View(values);
        }

    }
}
