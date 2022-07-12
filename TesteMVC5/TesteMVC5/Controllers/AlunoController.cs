using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TesteMVC5.Data;
using TesteMVC5.Models;

namespace TesteMVC5.Controllers
{
    public class AlunoController : Controller
    {
        private readonly AppDbContext context = new AppDbContext();
        
        [HttpGet]
        [Route("novo-aluno")]
        public ActionResult NovoAluno()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("novo-aluno")]
        public ActionResult NovoAluno(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return View(aluno);
            }

            aluno.DataMatricula = DateTime.Now;
            context.Alunos.Add(aluno);
            context.SaveChanges();
            return View(aluno);
        }

        [HttpGet]
        [Route("obter-alunos")]
        public ActionResult ObterAlunos()
        {
            List<Aluno> alunos = context.Alunos.ToList();
            return View("NovoAluno", alunos.FirstOrDefault());
        }

        [HttpGet]
        [Route("editar-aluno")]
        public ActionResult EditarAluno()
        {
            Aluno aluno = context.Alunos.FirstOrDefault(a => a.Nome == "Eduardo Pires");
            aluno.Nome = "João";
            var entry = context.Entry(aluno);
            context.Set<Aluno>().Attach(aluno);
            entry.State = EntityState.Modified;
            context.SaveChanges();
            var alunoNovo = context.Alunos.Find(aluno.Id);
            return View("NovoAluno", alunoNovo);
        }

        [HttpGet]
        [Route("excluir-aluno")]
        public ActionResult ExcluirAluno()
        {
            Aluno aluno = context.Alunos.FirstOrDefault(a => a.Nome == "João");
            context.Alunos.Remove(aluno);
            context.SaveChanges();
            var alunos = context.Alunos.ToList();
            return View("NovoAluno", alunos.FirstOrDefault());
        }
    }
}