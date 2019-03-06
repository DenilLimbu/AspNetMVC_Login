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
                    ViewBag.Message = "Welcome " + result[0].FirstName + " " + result[0].LastName + "!!";
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
                throw ex;
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
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            try
            {
                if (Session["UserId"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserProfile Model)
        {
            if (ModelState.IsValid)
            {
                object UserId = Session["UserId"];

                Guid GUserID = Guid.Parse(UserId.ToString());

                Guid result;
                try
                {
                    if (Session["UserId"] == null)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }

                    result = _ibac.Register(GUserID, Model.PhoneNumber, Model.BirthDate, Model.FirstLineAddress, Model.PostCode, Model.State, Model.Country, Model.MaritalStatus);
                    if (result != null)
                    {
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
            return View(Model);
        }
    }
}