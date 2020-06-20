using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.UI.Controllers
{
    public class BaseController : Controller 
    {
        protected IList<string> MensagensErro
        {
            get
            {
                object erros = TempData["MENSAGEM_ERRO"];
                if (erros == null)
                {
                    erros = new List<string>();
                    TempData["MENSAGEM_ERRO"] = erros;
                }
                return (IList<string>)erros;
            }
            set
            {
                TempData["MENSAGEM_ERRO"] = value;
            }
        }

        protected IList<string> MensagensSucesso
        {
            get
            {
                object msgs = TempData["MENSAGEM_SUCESSO"];
                if (msgs == null)
                {
                    msgs = new List<string>();
                    TempData["MENSAGEM_SUCESSO"] = msgs;
                }
                return (IList<string>)msgs;
            }
            set
            {
                TempData["MENSAGEM_SUCESSO"] = value;
            }
        }

        protected IList<string> GetModelErrors(ModelStateDictionary modelState)
        {
            return modelState.Values.Where(x => x.Errors.Count > 0)
                .SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
        }

        protected string GetModelErrorsStringify(ModelStateDictionary modelState)
        {
            return string.Join("; ", modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
        }
    }
}