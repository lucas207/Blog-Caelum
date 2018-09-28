using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.DAO
{
    public class UsuarioDAO
    {
        private BlogContext contexto;

        public UsuarioDAO(BlogContext contexto)
        {
            this.contexto = contexto;
        }

        public Usuario Busca(string nome, string senha)
        {
            return contexto.Usuarios.Where(u => u.Nome.Equals(nome) && u.Senha.Equals(senha)).FirstOrDefault();
        }
    }
}