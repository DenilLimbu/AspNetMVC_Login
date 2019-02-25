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

        [HttpGet]
        public ActionResult Index()
        {
            object UserId = Session["UserId"];
            try { 
                if (UserId != null)
                {
                    return RedirectToAction("DashBoard", "Home");
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                return RedirectToAction("DError", "Home", ex);
            }
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
                if (result != " ")
                {
                    Session["UserId"] = result;
                    return RedirectToAction("DashBoard", "Home");
                }
                else
                {
                    ViewBag.Message = "Invalid User";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("DError", "Home", ex);
            }

        }

        [HttpGet]
        public ActionResult DashBoard()
        {
            object UserId = Session["UserId"];
            try
            {
                if (UserId == null)
                {
                    return RedirectToAction("DError", "Home");
                }

                Guid GUserID = Guid.Parse(UserId.ToString());

                List<string> result = new List<string>();

                result = _ibac.GetUserProfile(GUserID);

                if (result != null)
                {
                    ViewBag.Message= "Welcome" + result[0] + result [1] + ".";
                    ViewBag.Message1 = "Your Email id is " + result[2];
                    return View();
                }
                else
                {
                    return RedirectToAction("DError", "Home");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("DError", "Home", ex);
            }
        }

        public ActionResult Logout()
        {
            Session["UserId"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DError(Exception ex)
        {
            ViewBag.Message = ex;
            return View();
        }
    }
}