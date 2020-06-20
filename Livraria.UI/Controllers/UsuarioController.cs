using Livraria.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.UI.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(UsuarioCadastroModel model)
        {
            return View();
        }
    }
}
