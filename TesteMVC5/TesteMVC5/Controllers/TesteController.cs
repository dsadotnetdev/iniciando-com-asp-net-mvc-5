﻿using System.Web.Mvc;

namespace TesteMVC5.Controllers
{
    [RoutePrefix("testes")]
    public class TesteController : Controller
    {
        [Route]
        public ViewResult IndexTeste()
        {
            return View();
        }

        [Route("um-outro-teste")]
        public ViewResult IndexTeste2()
        {
            return View("IndexTeste");
        }
    }
}