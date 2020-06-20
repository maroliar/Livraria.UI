using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using Livraria.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.UI.Controllers
{
    public class LoginController : BaseController
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioLoginModel model)
        {
            if (ModelState.IsValid)
            {

                var jsonContent = JsonSerializer.Serialize(model);
                var postContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");


                using (var client = new HttpClient())
                {
                    var post = client.PostAsync("https://localhost:44376/api/login", postContent).GetAwaiter().GetResult();
                    var retorno = post.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    JWT jwt = JsonSerializer.Deserialize<JWT>(retorno);
                    HttpContext.Session.SetString("token", jwt.accessToken);

                    ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(model.Login, "Login"),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                            new Claim(JwtRegisteredClaimNames.UniqueName, model.Login),
                            new Claim(ClaimTypes.Sid, jwt.accessToken)
                        }
                    );

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                }

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View("Index");
        }

    }
}
