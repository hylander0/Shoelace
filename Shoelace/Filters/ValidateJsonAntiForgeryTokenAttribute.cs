using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;


namespace Shoelace.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ValidateJsonAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            var httpContext = filterContext.HttpContext;
            var cookie = httpContext.Request.Cookies[AntiForgeryConfig.CookieName];
            AntiForgery.Validate(cookie != null ? cookie.Value : null,
                                 httpContext.Request.Headers["__RequestVerificationToken"]);


            //var httpContext = new JsonAntiForgeryHttpContextWrapper(HttpContext.Current);
            //AntiForgery.Validate(httpContext, Salt ?? string.Empty);
        }


        public string Salt
        {
            get;
            set;
        }
    }

}