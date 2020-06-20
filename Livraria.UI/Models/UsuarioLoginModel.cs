using System.ComponentModel.DataAnnotations;
using Livraria.UI.Resources;

namespace Livraria.UI.Models
{
    public class UsuarioLoginModel
    {
        [Required(ErrorMessageResourceType = typeof(UsuarioResource), ErrorMessageResourceName = "CampoLoginObrigatorio")]
        public string Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(UsuarioResource), ErrorMessageResourceName = "CampoSenhaObrigatorio")]
        public string Senha { get; set; }
    }
}
