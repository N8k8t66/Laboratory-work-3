using System.Web.Mvc;
using System.Web.Routing;

namespace DatabaseApp.Controllers
{
    public class StartController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            string actionName =
                requestContext.RouteData.Values["action"]?.ToString();

            string idValue =
                requestContext.HttpContext.Request.QueryString["id"];

            if (actionName == "start" && idValue == "0")
            {
                var homeController = new HomeController();

                homeController.ControllerContext =
                    new ControllerContext(
                        requestContext,
                        homeController);

                var result =
                    homeController.Index() as ActionResult;

                result.ExecuteResult(
                    homeController.ControllerContext);
            }
            else
            {
                var response =
                    requestContext.HttpContext.Response;

                response.Write("<h2>Ошибка</h2>");
                response.Write("<p>Условия не выполнены</p>");

                string fullUrl =
                    requestContext.HttpContext.Request.Url.ToString();

                response.Write("<p>Полный URL:</p>");
                response.Write(fullUrl);
            }
        }
    }
}
