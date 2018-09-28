using Blog.DAO;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public PostController()
        {

        }

        public ActionResult Index()
        {
            PostDAO dao = new PostDAO();
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
                PostDAO dao = new PostDAO();
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
            PostDAO dao = new PostDAO();
            IList<Post> lista = dao.FiltraPorCategoria(c);
            return View("Index", lista);
        }

        public ActionResult RemovePost(int id)
        {
            PostDAO dao = new PostDAO();
            dao.RemovePost(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            PostDAO dao = new PostDAO();
            Post p = dao.ReadById(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Editar(Post p)
        {
            if (ModelState.IsValid)
            {
                PostDAO dao = new PostDAO();
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
            PostDAO dao = new PostDAO();
            dao.Publica(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutoComplete(string termoDigitado)
        {
            PostDAO dao = new PostDAO();
            var model = dao.ListaCategoriasPorTermo(termoDigitado);
            return Json(model);
        }
    }
}