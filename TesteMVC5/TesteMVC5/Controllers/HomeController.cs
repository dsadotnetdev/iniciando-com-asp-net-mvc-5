using System.Web.Mvc;

namespace TesteMVC5.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ContentResult ContentResult()
        {
            return Content("Olá");
        }

        public FileContentResult FileContentResult()
        {
            var foto = System.IO.File.ReadAllBytes(Server.MapPath("/content/images/capa.png"));
            return File(foto, "image/png", "capa.png");
        }

        public HttpUnauthorizedResult HttpUnauthorizedResult()
        {
            return new HttpUnauthorizedResult();
        }

        public JsonResult JsonResult()
        {
            return Json("teste: 'teste'", JsonRequestBehavior.AllowGet);
        }

        public RedirectResult RedirectResult()
        {
            return new RedirectResult("https://desenvolvedor.io");
        }

        public RedirectToRouteResult RedirectToRouteResult()
        {
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public RedirectToRouteResult RedirectToRouteResult2()
        {
            return RedirectToAction("IndexTeste", "Teste");
        }
    }
}