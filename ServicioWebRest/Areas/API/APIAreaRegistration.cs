using System.Web.Mvc;

namespace ServicioWebRest.Areas.API
{
    public class APIAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "API";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
"ClientAccess",
"API/Clients/Client/{id}",
new
{
    controller = "Clients",
    action = "Client",
    id = UrlParameter.Optional
}
);
            context.MapRoute(
    "ClientsAccess",
    "API/Clients",
    new
    {
        controller = "Clients",
        action = "Clients"
    }
);

        }
    }
}
