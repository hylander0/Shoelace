namespace Shoelace.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using Shoelace.Common;
    using Shoelace.Models;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.RepoContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;


        }
        
        protected override void Seed(Repository.RepoContext context)
        {
            if (!WebMatrix.WebData.WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            }

            Migrations.Setup.ConfigureSecurityRolesIfNotExist();

            if (!WebSecurity.UserExists("admin@admin.com"))
            {
                WebSecurity.CreateUserAndAccount("admin@admin.com", "admin1");
            }

            if (!Roles.GetRolesForUser("admin@admin.com").Contains(Constants.ROLES_ADMINISTRATOR))
            {
                Roles.AddUsersToRoles(new[] { "admin@admin.com" }, new[] { Constants.ROLES_ADMINISTRATOR });
            }

            //Add Initial User
            int userId = WebSecurity.GetUserId("admin@admin.com");
            Repository.UserProfile profile = context.UserProfiles
                                                .Where(w => w.UserId == userId)
                                                .FirstOrDefault();
            profile.FirstName = "Admin";
            context.SaveChanges();
        }

        
    }
}
