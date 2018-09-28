using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Titulo não pode ser nulo!")] [StringLength(50)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required] [Display(Name = "Resumo")]
        public string Resumo { get; set; }

        [Display(Name = "Categoria")]
        public string Categoria { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public Boolean Publicado { get; set; }
    }
}