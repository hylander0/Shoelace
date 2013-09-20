using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shoelace.Common
{

    public class Constants
    {
        public const string ROLES_ADMINISTRATOR = "Administrator";
        public static List<String> SystemRoles()
        {
            return new List<String>()
            {
                ROLES_ADMINISTRATOR
            };
        }



        public static string UI_BADGE_TYPE_SUCCESS = "success";
        public static string UI_BADGE_TYPE_INFORMATION = "info";
        public static string UI_BADGE_TYPE_IMPORTANT = "important";
        public static string UI_BADGE_TYPE_WARNING = "warning";

    }
}