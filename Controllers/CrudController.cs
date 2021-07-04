using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaConocimiento.Models;
using PruebaConocimiento.Entity;

namespace PruebaConocimiento.Controllers
{
    public class CrudController : Controller
    {

        private UsersCrudImp usersCrud;
        private readonly ILogger<CrudController> _logger;

        public CrudController(ILogger<CrudController> logger)  {
            usersCrud = new UsersCrudImp();
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult InputScreen() {
            return View();
        }

        public ActionResult InputUser(String id, String name, String lastname,String tel) {
            try {
                return Content(usersCrud.create(new PruebaConocimiento.Entity.User(id,name,lastname,tel)).toJson());
            } catch(Exception e) {
                return Content(e.Message);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
