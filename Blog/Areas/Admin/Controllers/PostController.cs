using Blog.DAO;
using Blog.Filters;
using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [AutorizacaoFilter]
    public class PostController : Controller
    {
        private PostDAO dao;
        // GET: Post
        public PostController(BlogContext contexto)
        {
            this.dao = new PostDAO(contexto);
        }

        public ActionResult Index()
        {
            return View(dao.Read());
        }

        public ActionResult Novo()
        {
            return View(new Post());
        }

        [HttpPost]
        public ActionResult Salvar(Post p)
        {
            if (ModelState.IsValid)
            {
                dao.Create(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Novo", p);
            }
        }

        public ActionResult Categoria([Bind(Prefix = "id")] string c)
        {
            IList<Post> lista = dao.FiltraPorCategoria(c);
            return View("Index", lista);
        }

        public ActionResult RemovePost(int id)
        {
            dao.RemovePost(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Post p = dao.ReadById(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Editar(Post p)
        {
            if (ModelState.IsValid)
            {
                dao.Editar(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Editar", p);
            }
        }

        public ActionResult PublicaPost(int id)
        {
            dao.Publica(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutoComplete(string termoDigitado)
        {
            var model = dao.ListaCategoriasPorTermo(termoDigitado);
            return Json(model);
        }
    }
}