using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shoelace.Models
{
    public class TopNavModel
    {
        public string usersDisplayName { get; set; }
        public bool canManageUsers { get; set; }



    }

    public class SideNavModel
    {
        
        public SideNavModel()
        {
            menuItems = new List<SideNavItems>();
        }

        public List<SideNavItems> menuItems { get; set; }

        public class SideNavItems
        {

            public string name { get; set; }
            public int badgeCnt { get; set; }
            public string badgeType { get; set; }
            public string action { get; set; }
            public string controller { get; set; }
        }
    }
}