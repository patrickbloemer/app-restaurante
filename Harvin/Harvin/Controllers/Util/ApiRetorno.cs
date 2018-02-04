using System.Web.Mvc;

namespace Harvin.Controllers.Util
{
    public class ApiRetorno
    {
        public bool Sucesso { get; set; }
        public object Retorno { get; set; }
        public string Mensagem { get; set; }

        public ApiRetorno(bool sucesso)
        {
            Sucesso = sucesso;
        }

        public ApiRetorno(bool sucesso, object retorno)
        {
            Sucesso = sucesso;
            Retorno = retorno;
        }

        public ApiRetorno(bool sucesso, object retorno, string mensagem)
        {
            Sucesso = sucesso;
            Retorno = retorno;
            Mensagem = mensagem;
        }

        public JsonResult ToJson()
        {
            return new JsonResult
            {
                Data = this,
                MaxJsonLength = int.MaxValue,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}