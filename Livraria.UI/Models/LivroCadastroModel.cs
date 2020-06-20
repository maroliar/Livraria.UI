﻿using Livraria.UI.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Livraria.UI.Models
{
    public class LivroCadastroModel
    {
        [Required(ErrorMessageResourceType = typeof(LivroResource), ErrorMessageResourceName = "CampoISBNObrigatorio")]
        public int ISBN { get; set; }

        [Required(ErrorMessageResourceType = typeof(LivroResource), ErrorMessageResourceName = "CampoAutorObrigatorio")]
        public string Autor { get; set; }

        [Required(ErrorMessageResourceType = typeof(LivroResource), ErrorMessageResourceName = "CampoNomeLivroObrigatorio")]
        [Display(Name = "Nome do Livro")]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceType = typeof(LivroResource), ErrorMessageResourceName = "CampoPrecoObrigatorio")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessageResourceType = typeof(LivroResource), ErrorMessageResourceName = "CampoDataPublicacaoObrigatorio")]
        [Display(Name = "Data de Publicação")]
        public DateTime DataPublicacao { get; set; }

        [Display(Name = "URL da Capa do Livro")]
        public string ImagemCapaUrl { get; set; }
    }
}
