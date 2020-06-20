using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Livraria.UI.Models
{
    public class LivroConsultaModel
    {
        [JsonPropertyName("idLivro")]
        public int IdLivro { get; set; }
        
        [JsonPropertyName("isbn")]
        public int ISBN { get; set; }

        [JsonPropertyName("autor")]
        public string Autor { get; set; }

        [JsonPropertyName("nome")]
        [Display(Name = "Nome do Livro")]
        public string Nome { get; set; }

        [JsonPropertyName("preco")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [JsonPropertyName("dataPublicacao")]
        [Display(Name = "Data de Publicação")]
        public DateTime DataPublicacao { get; set; }
        
        [JsonPropertyName("imagemCapaUrl")]
        [Display(Name = "URL da Capa do Livro")]
        public string ImagemCapaUrl { get; set; }
    }
}
