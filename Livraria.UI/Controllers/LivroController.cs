using Livraria.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

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
            if (ModelState.IsValid)
            {
                var token = HttpContext.Session.GetString("token");

                if (string.IsNullOrEmpty(token))
                {
                    ViewBag.Message = "Usuario não logado, ou token expirado. Por favor, faça o login novamente.";
                    return View();
                }

                var jsonContent = JsonSerializer.Serialize(model);
                var postContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");


                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

                    var post = client.PostAsync("https://localhost:44376/api/livro", postContent).GetAwaiter().GetResult();
                    var retorno = post.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    if (!string.IsNullOrEmpty(retorno))
                    {
                        ViewBag.Message = retorno;
                    }
                }
            }

            ModelState.Clear();

            return View();
        }

        public IActionResult Consulta()
        {
            var token = HttpContext.Session.GetString("token");

            if (string.IsNullOrEmpty(token))
            {
                ViewBag.Message = "Usuario não logado, ou token expirado. Por favor, faça o login novamente.";
                return View();
            }


            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

                var post = client.GetAsync("https://localhost:44376/api/livro").GetAwaiter().GetResult();
                var retorno = post.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (!string.IsNullOrEmpty(retorno))
                {
                    var collection = JsonSerializer.Deserialize<ICollection<LivroConsultaModel>>(retorno);


                    return View(collection);
                }
            }

            return View();
        }

        public IActionResult Edicao(int id)
        {
            var token = HttpContext.Session.GetString("token");

            if (string.IsNullOrEmpty(token))
            {
                ViewBag.Message = "Usuario não logado, ou token expirado. Por favor, faça o login novamente.";
                return View();
            }


            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

                var post = client.GetAsync("https://localhost:44376/api/livro/" + id).GetAwaiter().GetResult();
                var retorno = post.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (!string.IsNullOrEmpty(retorno))
                {
                    var model = JsonSerializer.Deserialize<LivroEdicaoModel>(retorno);

                    return View(model);
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edicao(LivroEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                var token = HttpContext.Session.GetString("token");

                if (string.IsNullOrEmpty(token))
                {
                    ViewBag.Message = "Usuario não logado, ou token expirado. Por favor, faça o login novamente.";
                    return View();
                }

                var jsonContent = JsonSerializer.Serialize(model);
                var postContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");


                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

                    var post = client.PutAsync("https://localhost:44376/api/livro", postContent).GetAwaiter().GetResult();
                    var retorno = post.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    if (!string.IsNullOrEmpty(retorno))
                    {
                        ViewBag.Message = retorno;
                    }
                }
            }

            ModelState.Clear();

            return View();
        }

        public IActionResult Exclusao(int id)
        {
            if (id > 0)
            {
                var token = HttpContext.Session.GetString("token");

                if (string.IsNullOrEmpty(token))
                {
                    ViewBag.Message = "Usuario não logado, ou token expirado. Por favor, faça o login novamente.";
                    return View();
                }

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

                    var post = client.DeleteAsync("https://localhost:44376/api/livro?id=" + id).GetAwaiter().GetResult();
                    var retorno = post.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    if (!string.IsNullOrEmpty(retorno))
                    {
                        ViewBag.Message = retorno;
                    }
                }
            }

            return View("Consulta");
        }



    }
}
