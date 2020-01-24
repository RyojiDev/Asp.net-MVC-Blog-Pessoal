using BlogPessoal.Web.Data.Contexto;
using BlogPessoal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogPessoal.Web.Controllers
{
    public class CategoriasDeArtigoController : Controller
    {
        // GET: CategoriasDeArtigo
        private BlogPessoalContexto _ctx = new BlogPessoalContexto();
        public ActionResult Index()
        {
            var categorias = _ctx.CategoriasDeArtigo
                .OrderBy(t => t.Nome)
                .ToList();
            return View(categorias);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoriaDeArtigo categoria)
        {
            if (ModelState.IsValid)
            {
                _ctx.CategoriasDeArtigo.Add(categoria);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var categoria = _ctx.CategoriasDeArtigo.Find(id);
            if (categoria == null)
                return HttpNotFound();
            return View(categoria);
        }
    }
}