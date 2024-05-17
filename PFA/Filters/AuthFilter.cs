using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PFA.Filters
{
    public class AuthFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if(context.HttpContext.Session.GetString("Login")==null) 
            {
                context.Result = new RedirectResult("/User/Login");
            }
        }
    }
}
