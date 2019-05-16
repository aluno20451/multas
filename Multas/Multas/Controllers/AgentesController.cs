using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Multas.Models;

namespace Multas.Controllers
{
    public class AgentesController : Controller
    {
        // cria uma variavel que representa a BD
        private MultasDB db = new MultasDB();

        // GET: Agentes
        public ActionResult Index()
        {
            var listaAgentes = db.Agentes.OrderBy(a => a.Nome).ToList();

            return View(listaAgentes);
        }

        // GET: Agentes/Details/5
        /// <summary>
        /// Mostra os dados do agente cujo id é dado
        /// </summary>
        /// <param name="id">identifica o agente</param>
        /// <returns>Devolve a view preenchida com os dados</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                // vamos alterar esta resposta por defeito
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //
                // este ocorre porque o utilizador anda a fazer asaneiras
                return RedirectToAction("Index");
            }
            // SELECT * FROM Agentes WHERE Id=id
            Agentes agente = db.Agentes.Find(id);

            // O agente foi encontrado?
            if (agente == null)
            // o agente não foi encontrado, porque o utilizador está à pesca 
            {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            return View(agente);
        }

        // GET: Agentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Esquadra,Fotografia")] Agentes agente)
        {
            if (ModelState.IsValid)
            {
                db.Agentes.Add(agente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agente);
        }

        // GET: Agentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                // vamos alterar esta resposta por defeito
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //
                // este ocorre porque o utilizador anda a fazer asaneiras
                return RedirectToAction("Index");
            }
            // SELECT * FROM Agentes WHERE Id=id
            Agentes agentes = db.Agentes.Find(id);

            // O agente foi encontrado?
            if (agentes == null)
            // o agente não foi encontrado, porque o utilizador está à pesca 
            {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            return View(agentes);
        }

        // POST: Agentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Esquadra,Fotografia")] Agentes agentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agentes).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(agentes);
        }

        // GET: Agentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                // vamos alterar esta resposta por defeito
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //
                // este ocorre porque o utilizador anda a fazer asaneiras
                return RedirectToAction("Index");
            }
            // SELECT * FROM Agentes WHERE Id=id
            Agentes agente = db.Agentes.Find(id);

            // O agente foi encontrado?
            if (agente == null)
            // o agente não foi encontrado, porque o utilizador está à pesca 
            {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }

            // o agente foi encontrado
            // vou salvaguardar os dados para posterior validação
            // - guardar o ID do agente num cookie cifrado
            // - guardar o ID numa variável de Sessão (se usar o ASP .NET Core, esta ferramenta já não existe...)
            Session["Agente"] = agente.ID;

            //mostra na View os dados do Agente
            return View(agente);
        }

        // POST: Agentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null) {
                // há um xico esperto a darm-me a volta ao codigo 
                return RedirectToAction("Index");
            }

            // será que o ID é o que eu espero?
            // vamos validar se o ID está correto
            if ((int)Session["Agente"] != id) {
                // o ID é diferente do esperado
                return RedirectToAction("Index");
            }

            // procura o agente a remover
            Agentes agente = db.Agentes.Find(id);

            if (agente == null) {
                return RedirectToAction("Index");
            }

            try
            {               
                // dá a ordem de remoção do agente 
                db.Agentes.Remove(agente);
                // consolida a remoção
                db.SaveChanges();
            }
            catch (Exception)
            {
                // deve aqui ser escritas todas as instruções que são consideradas necessárias

                //informa que houve um erro
                ModelState.AddModelError("", "Não é possível remover o agente "+agente.Nome+". Ele tem multas associadas");

                //redirecionar para a pagina onde o erro foi gerado
                return View(agente);
            }
              
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
