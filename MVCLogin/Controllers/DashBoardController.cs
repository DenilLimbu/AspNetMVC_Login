using MVCLogin.Layers.BusinessLayer;
using MVCLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLogin.Controllers
{
    public class DashBoardController : Controller
    {
        IBusinessAuthentication _ibac = new BusinessAuthentication();

        [HttpGet]
        public ActionResult Index()
        {
            object UserId = Session["UserId"];
            try
            {
                if (Session["UserId"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                Guid GUserID = Guid.Parse(UserId.ToString());

                List<UserProfile> result = new List<UserProfile>();

                result = _ibac.GetUserProfile(GUserID);

                if (result != null)
                {
                    ViewBag.Message = "Welcome " + result[0].FirstName + result[0].LastName + "!!";
                    ViewBag.Message1 = "Your Email id is " + result[0].Email;
                    return View(result);
                }
                else
                {   //should throw internal exception
                    return RedirectToAction("Index", "Error");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", ex);
            }
        }

        public ActionResult Logout()
        {
            try
            {
                Session["UserId"] = null;
                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", ex);
            }
        }
    }
}