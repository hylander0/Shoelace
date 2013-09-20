using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Shoelace.Filters;
using Shoelace.Models;
namespace Shoelace.Controllers
{
    [Authorize]
    //[InitializeSimpleMembership]
    public class AccountController : Controller
    {
        //[ValidateAntiForgeryToken]
        public ActionResult ManageProfile()
        {
            Shoelace.Models.UserProfile model = new Shoelace.Models.UserProfile();
            Repository.UserProfile profile;
            using (var cxt = new Repository.RepoContext())
            {
                profile = cxt.UserProfiles.Where(w => w.UserName == WebSecurity.CurrentUserName).FirstOrDefault();
            }
            model.firstName = profile.FirstName;
            model.lastName = profile.LastName;

            model.userId = WebSecurity.CurrentUserId;
            model.userName = WebSecurity.CurrentUserName;
            return View(model);
        }

        [ValidateHttpAntiForgeryToken]
        [HttpPost]
        public JsonResult SaveProfileInfo(Models.UserProfile p)
        {
            Repository.UserProfile profile;
            using (var cxt = new Repository.RepoContext())
            {
                profile = cxt.UserProfiles.Where(w => w.UserName == WebSecurity.CurrentUserName).FirstOrDefault();
                profile.FirstName = p.firstName;
                profile.LastName = p.lastName;
                cxt.SaveChanges();
            }
            return Json(new { success = true });
        }


        //
        // POST: /Account/JsonLogin

        [AllowAnonymous]
        [HttpPost]
        public JsonResult JsonLogin(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    return Json(new { success = true, redirect = returnUrl });
                }
                //else
                //{
                //    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                //}
            }

            // If we got this far, something failed
            return Json(new { success = false });
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }


        [Authorize(Roles=Common.Constants.ROLES_ADMINISTRATOR)]
        public ActionResult UserList()
        {
            UserListModel mdl = new UserListModel();
            mdl.logedInUserName = WebSecurity.CurrentUserName;
            using (var cxt = new Repository.RepoContext())
            {
                cxt.UserProfiles.ToList().ForEach(f1 => {
                    UserListModel.UserListItem item = new UserListModel.UserListItem()
                    {
                        userId = f1.UserId,
                        userName = f1.UserName,
                        firstName = f1.FirstName,
                        lastName = f1.LastName
                    };
                    item.userRoles = new List<UserListModel.UserListItem.UserRole>();
                    Common.Constants.SystemRoles().ForEach(f2 => {
                        item.userRoles.Add(new UserListModel.UserListItem.UserRole()
                        {
                            roleName = f2,
                            roleDisplayName = f2,
                            isMember = Roles.IsUserInRole(f1.UserName, f2)
                           
                        });
                    });
                    mdl.users.Add(item);
                    
                });
            }

 
            return View(mdl);
        }

        [Authorize(Roles = Common.Constants.ROLES_ADMINISTRATOR)]
        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult SaveUserRoles(UserListModel.UserListItem userToSave)
        {
            foreach (var role in userToSave.userRoles)
            {
                //If the user is marked as isMember and not currenty a member, add them
                if (!Roles.IsUserInRole(userToSave.userName, role.roleName) && role.isMember)
                    Roles.AddUserToRole(userToSave.userName, role.roleName);
                else if (Roles.IsUserInRole(userToSave.userName, role.roleName) && !role.isMember) //If the user is marked as not a Member and is currenty a member, remove them
                    Roles.RemoveUserFromRole(userToSave.userName, role.roleName);
            }
            return Json(new { success = true });
        }


        [Authorize(Roles = Common.Constants.ROLES_ADMINISTRATOR)]
        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult DeleteUser(int UserId)
        {
            return Json(new { success = true });
        }

    }
}