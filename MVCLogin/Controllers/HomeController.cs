using MVCLogin.Layers.BusinessLayer;
using MVCLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLogin.Controllers
{
    public class HomeController : Controller
    {
        public User _user = new User();


        IBusinessAuthentication _ibac = new BusinessAuthentication();

        //public HomeController(User user)
        //{
        //    _user = user;
        //}

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string email, string password)
        {
           
            string result;
            _user.Email = email;
            _user.Password = password;
            try
            {
                result = _ibac.IsValidUser(email, password);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
            if(result != " ")
            { 
                return RedirectToAction("DashBoard", "Home", new {rep =result});
            }
            else
            {
                ViewBag.Message = "Invalid User";
                return View();
            }
        }


        [HttpGet]
        public ActionResult DashBoard(string rep)
        {
            try
            {
                if (rep != null)
                {
                    ViewBag.Message= "Welcome User!!";
                    return View();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            { 
                ViewBag.Message = "OOPS!! 404 Not Found";
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

    }
}