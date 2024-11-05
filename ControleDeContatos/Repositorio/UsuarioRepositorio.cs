using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly BancoContext _context;

        public UsuarioRepositorio(BancoContext bancoContext) { 
            this._context = bancoContext;
        }

        public UsuarioModel BuscarPorId(int id)
        {
            return _context.UsuariosContato.FirstOrDefault(x => x.Id == id);
        }

        public UsuarioModel BuscarLogin(string login)
        {
            return _context.UsuariosContato.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarCadastro(string email, string login)
        {
            return _context.UsuariosContato.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _context.UsuariosContato.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetHash();
            _context.UsuariosContato.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = BuscarPorId(usuario.Id);

            if (usuarioDb == null) throw new System.Exception("Ocorreu um erro na atualização do usuário.");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.LogData = DateTime.Now;

            _context.UsuariosContato.Update(usuarioDb);
            _context.SaveChanges();

            return usuarioDb;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDb = BuscarPorId(id);

            if (usuarioDb == null) throw new System.Exception("Houve um erro na exclusão do usuário.");

            _context.UsuariosContato.Remove(usuarioDb);
            _context.SaveChanges();

            return true;
        }
    }
}
