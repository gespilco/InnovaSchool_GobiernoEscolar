using System.Web.Mvc;

namespace InnovaSchool.UserLayer.Areas.GobiernoEscolar
{
    public class GobiernoEscolarAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GobiernoEscolar";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GobiernoEscolar_default",
                "GobiernoEscolar/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}