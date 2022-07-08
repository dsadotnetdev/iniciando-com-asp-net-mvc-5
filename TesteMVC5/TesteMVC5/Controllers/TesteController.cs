using System.Web.Mvc;

namespace TesteMVC5.Controllers
{
    [RoutePrefix("testes")]
    public class TesteController : Controller
    {
        [Route("{id2:int}/{texto:maxlength(50)}")]
        public ViewResult IndexTeste(int id2, string texto)
        {
            return View();
        }

        [Route("{texto:maxlength(50)}/um-outro-teste/{id2:int}")]
        public ViewResult IndexTeste2(int id2, string texto)
        {
            return View("IndexTeste");
        }
    }
}