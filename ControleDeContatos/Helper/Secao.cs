using ControleDeContatos.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ControleDeContatos.Helper
{
    public class Secao : ISecao
    {

        private readonly IHttpContextAccessor _httpContext;

        public Secao (IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public UsuarioModel BuscarSessaoUsuario()
        {
            string secaoUsuario = _httpContext.HttpContext.Session.GetString("SecaoUsuarioLogado");

            if (string.IsNullOrEmpty(secaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(secaoUsuario);
        }

        public void CriarSessaoUsuario(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("SecaoUsuarioLogado", valor);
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("SecaoUsuarioLogado");
        }
    }
}
