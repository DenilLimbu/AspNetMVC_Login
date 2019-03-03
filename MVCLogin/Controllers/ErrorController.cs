using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLogin.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        //External Exception
        [HttpGet]
        public ActionResult Index(Exception ex)
        {
            ViewBag.Message = ex;
            return View();
        }
    }
}