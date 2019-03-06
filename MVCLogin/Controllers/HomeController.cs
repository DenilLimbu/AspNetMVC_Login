using MVCLogin.Layers.BusinessLayer;
using MVCLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLogin.Controllers
{
    [RequireHttps]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public User _user = new User();
        IBusinessAuthentication _ibac = new BusinessAuthentication();

        [HttpGet]
        public ActionResult Index()
        {
            try { 
                if (Session["UserId"] != null)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string email, string password)
        { 
            
            string result;
            _user.Email = email;
            _user.Password = password;
            try
            {
                result = _ibac.IsValidUser(email, password);
                if (result != " ")
                {
                    Session["UserId"] = result;
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.Message = "Invalid User";
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        public ActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string firstname, string lastname, string email, string password)
        {

            //if (ModelState.IsValid)
            //{

            //    return RedirectToAction("Index", "Dashboard");
            //}
            Guid result;

            try
            {
                result = _ibac.InsertUserDetails(firstname, lastname, email, password);
                if (result != null)
                {
                    Session["UserId"] = result;
                    return RedirectToAction("Register", "Dashboard");
                }
                else
                {
                    TempData["SignupMessage"] = "Unsucessful SignUp";
                    ViewBag.Message = "User Is not created";
                    return RedirectToAction("Index", "Dashboard", TempData["SignupMessage"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}