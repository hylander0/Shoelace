using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Shoelace.Filters;
using Shoelace.Models;
using WebMatrix.WebData;

namespace Shoelace.Controllers
{
    
    [InitializeSimpleMembership]
    [Authorize]
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(new UserLoginModel.UserLoginRequestModel());
        }

        [AllowAnonymous]
        [ValidateHttpAntiForgeryToken]
        [HttpPost]
        public JsonResult LoginUser(UserLoginModel.UserLoginRequestModel model)
        {
            var result = new UserLoginModel.UserLoginResponseModel();
            if (WebSecurity.Login(model.userName, model.password, persistCookie: model.rememberMe))
            {
                FormsAuthentication.SetAuthCookie(model.userName, model.rememberMe);
                result.validLogin = true;
                if (!string.IsNullOrEmpty(model.returnUrl))
                    result.validLoginUrl = model.returnUrl;
                else
                    result.validLoginUrl = @"/";
                return Json(result);
            }
            return Json(result);
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View(new UserLoginModel.UserRegistrationModel());
        }
        [AllowAnonymous]
        [ValidateHttpAntiForgeryToken]
        [HttpPost]
        public JsonResult RegisterUser(UserLoginModel.UserRegistrationModel model)
        {
            // Attempt to register the user
            try
            {
                WebSecurity.CreateUserAndAccount(
                    model.userName, 
                    model.password,
                    new {   
                            FirstName = model.firstName,
                            LastName = model.lastName

                        },
                    false
                );

            }
            catch (MembershipCreateUserException e)
            {
                //ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                return Json(new { success = false, error = e.StatusCode });
            }
            return Json(new { success = true });
        }

        public ActionResult LogOffUser()
        {
            //Clears out Session
            Session.Clear();
            Session.Abandon();

            //Signs out of WebSecurity and FormsAuthentication
            WebSecurity.Logout();
            FormsAuthentication.SignOut();


            return RedirectToAction("Index", "Login");
        }

    }
}
