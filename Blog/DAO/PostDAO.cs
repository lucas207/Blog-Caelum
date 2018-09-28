using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.DAO
{
    public class PostDAO
    {
        private BlogContext contexto;

        public PostDAO(BlogContext contexto)
        {
            this.contexto = contexto;
        }
        public IList<Post> Read()
        {
            IList<Post> lista = new List<Post>();

            lista = contexto.Posts.ToList();

            return lista;
        }

        public void Create(Post p)
        {
            contexto.Posts.Add(p);
            contexto.SaveChanges();

        }

        public IList<Post> FiltraPorCategoria(string categoria)
        {
            return contexto.Posts.Where(p => p.Categoria.Contains(categoria)).ToList();

        }

        public void RemovePost(int id)
        {
            Post p = new Post() { Id = id };
            contexto.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            //contexto.Posts.Remove(p); //Precisa do post inteiro para apagar
            contexto.SaveChanges();

        }

        public Post ReadById(int id)
        {
            return contexto.Posts.Find(id);

        }

        public void Editar(Post p)
        {
            contexto.Entry(p).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();

        }

        public void Publica(int id)
        {
            var post = contexto.Posts.Find(id);
            post.Publicado = true;
            post.DataPublicacao = DateTime.Now;
            contexto.SaveChanges();

        }

        public IList<string> ListaCategoriasPorTermo(string termo)
        {
            return contexto.Posts.Where(p => p.Categoria.Contains(termo))
                .Select(p => p.Categoria)
                .Distinct().ToList();

        }

        public IList<Post> ListaPublicados()

        {
            return contexto.Posts.Where(p => p.Publicado).OrderByDescending(p => p.DataPublicacao).ToList();

        }

        public IList<Post> BuscaPorTermo(string termo)
        {
            return contexto.Posts.Where(p => p.Publicado && (p.Titulo.Contains(termo) ||
                p.Resumo.Contains(termo))).ToList();

        }
    }
}