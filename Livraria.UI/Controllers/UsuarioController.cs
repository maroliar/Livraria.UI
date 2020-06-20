using Livraria.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;

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
            if (ModelState.IsValid)
            {

                var jsonContent = JsonSerializer.Serialize(model);
                var postContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");


                using (var client = new HttpClient())
                {
                    var post = client.PostAsync("https://localhost:44376/api/usuario", postContent).GetAwaiter().GetResult();
                    var retorno = post.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    
                    if(!string.IsNullOrEmpty(retorno))
                    {
                        ViewBag.Message = retorno;
                    }
                }
            }

            ModelState.Clear();

            return View();
        }
    }
}
