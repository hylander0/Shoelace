using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Shoelace.Migrations
{
    public class Setup
    {
        public static void ConfigureSecurityRolesIfNotExist()
        {
            foreach(var role in Common.Constants.SystemRoles())
            {
                
                if (!Roles.RoleExists(role))
                {
                    Roles.CreateRole(role);
                }
            }
        }
    }
}