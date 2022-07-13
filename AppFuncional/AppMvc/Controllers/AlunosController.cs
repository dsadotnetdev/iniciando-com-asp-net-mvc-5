using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using AppMvc.Models;

namespace AppMvc.Controllers
{
    public class AlunosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<ActionResult> Index()
        {
            return View(await db.Alunos.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Aluno aluno = await db.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }

            return View(aluno);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Email,CPF,DataMatricula,Ativo")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(aluno);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Aluno aluno = await db.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Email,CPF,DataMatricula,Ativo")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Aluno aluno = await db.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }

            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Aluno aluno = await db.Alunos.FindAsync(id);
            db.Alunos.Remove(aluno);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
