using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Shoelace.Common;
using Shoelace.Models;
using WebMatrix.WebData;

namespace Shoelace.Controllers
{
    [ChildActionOnly]
    public class NavigationController : Controller
    {
        //
        // GET: /Navigation/TopNav

        public PartialViewResult _NavbarTop()
        {
            TopNavModel mdl = new TopNavModel();
            Repository.UserProfile profile;
            using(var cxt = new Repository.RepoContext())
            {
                profile = cxt.UserProfiles.Where(w => w.UserName == WebSecurity.CurrentUserName).FirstOrDefault();
            }
            mdl.usersDisplayName = profile.FirstName;
            mdl.canManageUsers = Roles.GetRolesForUser(profile.UserName).Contains(Constants.ROLES_ADMINISTRATOR);
            return PartialView(mdl);
        }

        public PartialViewResult _NavbarSide()
        {
            return PartialView(new SideNavModel()
            {
                menuItems = new List<SideNavModel.SideNavItems>()
                {
                    new SideNavModel.SideNavItems
                    {
                       name = "Home",
                       controller = "Home",
                       action = "Index"
                    },
                    new SideNavModel.SideNavItems
                    {
                       name = "Dashboard Sample",
                       badgeCnt = 4,
                       badgeType = Common.Constants.UI_BADGE_TYPE_INFORMATION,
                       controller = "Samples",
                       action = "Dashboard"
                    },
                    new SideNavModel.SideNavItems
                    {
                       name = "Forms Sample",
                       badgeCnt = 10,
                       badgeType = Common.Constants.UI_BADGE_TYPE_SUCCESS,
                       controller = "Samples",
                       action = "Forms"
                    },
                    new SideNavModel.SideNavItems
                    {
                       name = "Buttons & Icons",
                       badgeCnt = 2,
                       badgeType = Common.Constants.UI_BADGE_TYPE_WARNING,
                       controller = "Samples",
                       action = "Buttons_Icons"
                    },
                    new SideNavModel.SideNavItems
                    {
                       name = "UI & Interface",
                       badgeCnt = 101,
                       badgeType = Common.Constants.UI_BADGE_TYPE_IMPORTANT,
                       controller = "Samples",
                       action = "UI_Interface"
                    }
                }
            });
        }

    }
}
