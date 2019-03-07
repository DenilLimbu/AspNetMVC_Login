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
        public ActionResult Index(string message)
        {
            
            try { 
                if (Session["UserId"] != null)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.Message = message;
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
        public ActionResult Index(User Model)
        {
            Guid result;
            try
            {
                if (ModelState.IsValid)
                {
                    result = _ibac.InsertUserDetails(Model.FirstName, Model.LastName, Model.Email, Model.Password);
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
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(Model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {

            string result;
            _user.Email = email;
            _user.Password = password;
            try
            {
                //make implementation whether user has enter the details
                result = _ibac.IsValidUser(email, password);
                if (result != " ")
                {
                    Session["UserId"] = result;
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    string message = "Invalid User";
                    return RedirectToAction("Index", "Home", new {message});
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}