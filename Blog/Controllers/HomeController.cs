using Blog.DAO;
using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private PostDAO dao;
        public HomeController(BlogContext contexto)
        {
            this.dao = new PostDAO(contexto);
        }
        // GET: Home
        public ActionResult Index()
        {
            IList<Post> publicados = dao.ListaPublicados();
            return View(publicados);
        }

        public ActionResult Busca (string termo)
        {
            IList<Post> lista = dao.BuscaPorTermo(termo);
            return View("Index", lista);
        }
    }
}