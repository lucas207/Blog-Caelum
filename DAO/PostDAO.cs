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
        public IList<Post> Read()
        {
            IList<Post> lista = new List<Post>();
            using (BlogContext contexto = new BlogContext())
            {
                lista = contexto.Posts.ToList();
            }
            return lista;
        }

        public void Create(Post p)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Posts.Add(p);
                contexto.SaveChanges();
            }
        }

        public IList<Post> FiltraPorCategoria(string categoria)
        {
            using(BlogContext contexto = new BlogContext())
            {
                return contexto.Posts.Where(p => p.Categoria.Contains(categoria)).ToList();
            }
        }

        public void RemovePost(int id)
        {
            using(BlogContext contexto = new BlogContext())
            {
                Post p = new Post(){Id = id };
                contexto.Entry(p).State = System.Data.Entity.EntityState.Deleted;
                //contexto.Posts.Remove(p); //Precisa do post inteiro para apagar
                contexto.SaveChanges();
            }
        }

        public Post ReadById(int id)
        {
            using(BlogContext contexto = new BlogContext())
            {
                return contexto.Posts.Find(id);
            }
        }

        public void Editar(Post p)
        {
            using(BlogContext contexto = new BlogContext())
            {
                contexto.Entry(p).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Publica(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                var post = contexto.Posts.Find(id);
                post.Publicado = true;
                post.DataPublicacao = DateTime.Now;
                contexto.SaveChanges();
            }
        }

        public IList<string> ListaCategoriasPorTermo(string termo)
        {
            using(BlogContext contexto = new BlogContext())
            {
                return contexto.Posts.Where(p => p.Categoria.Contains(termo))
                    .Select(p => p.Categoria)
                    .Distinct().ToList();
            }
        }
    }
}