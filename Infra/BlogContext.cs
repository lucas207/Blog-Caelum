using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Infra
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("name=blog")
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}