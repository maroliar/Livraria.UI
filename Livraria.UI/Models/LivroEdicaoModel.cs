using Livraria.UI.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Livraria.UI.Models
{
    public class LivroEdicaoModel
    {
        [JsonPropertyName("idLivro")]
        public int IdLivro { get; set; }

        [JsonPropertyName("isbn")]
        [Required(ErrorMessageResourceType = typeof(LivroResource), ErrorMessageResourceName = "CampoISBNObrigatorio")]
        public int ISBN { get; set; }

        [JsonPropertyName("autor")]
        [Required(ErrorMessageResourceType = typeof(LivroResource), ErrorMessageResourceName = "CampoAutorObrigatorio")]
        public string Autor { get; set; }

        [JsonPropertyName("nome")]
        [Required(ErrorMessageResourceType = typeof(LivroResource), ErrorMessageResourceName = "CampoNomeLivroObrigatorio")]
        [Display(Name = "Nome do Livro")]
        public string Nome { get; set; }

        [JsonPropertyName("preco")]
        [Required(ErrorMessageResourceType = typeof(LivroResource), ErrorMessageResourceName = "CampoPrecoObrigatorio")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [JsonPropertyName("dataPublicacao")]
        [Required(ErrorMessageResourceType = typeof(LivroResource), ErrorMessageResourceName = "CampoDataPublicacaoObrigatorio")]
        [Display(Name = "Data de Publicação")]
        public DateTime DataPublicacao { get; set; }

        [JsonPropertyName("imagemCapaUrl")]
        [Display(Name = "URL da Capa do Livro")]
        public string ImagemCapaUrl { get; set; }

    }
}
