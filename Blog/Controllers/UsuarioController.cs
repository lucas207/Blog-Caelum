using Blog.DAO;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO dao;
        public UsuarioController(UsuarioDAO dao)
        {
            this.dao = dao;
        }
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Autentica(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario user = dao.Busca(model.LoginName, model.Password);
                if (user != null)
                {
                    Session["usuario"] = user;
                    return RedirectToAction("Index", "Post", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
                }
            }
            return View("Login", model);
        }
    }
}