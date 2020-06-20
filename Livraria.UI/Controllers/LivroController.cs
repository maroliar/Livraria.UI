using Livraria.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.UI.Controllers
{
    [Authorize]
    public class LivroController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(LivroCadastroModel model)
        {
            return View();
        }

        public IActionResult Consulta()
        {
            return View();
        }

        public IActionResult Edicao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edicao(LivroEdicaoModel model)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Exclusao(int id)
        {
            return View();
        }



    }
}
