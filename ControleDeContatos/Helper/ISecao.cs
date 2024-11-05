using ControleDeContatos.Models;

namespace ControleDeContatos.Helper
{
    public interface ISecao
    {
        void CriarSessaoUsuario(UsuarioModel usuario);
        void RemoverSessaoUsuario();
        UsuarioModel BuscarSessaoUsuario();
    }
}
