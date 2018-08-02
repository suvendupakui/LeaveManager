using System.Web.Mvc;

namespace LeaveManager.Areas.ApplyLeave
{
    public class ApplyLeaveAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ApplyLeave";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ApplyLeave_default",
                "ApplyLeave/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}