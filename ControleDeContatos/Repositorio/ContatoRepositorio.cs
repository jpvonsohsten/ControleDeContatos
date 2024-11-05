using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {

        private readonly BancoContext _Context;

        public ContatoRepositorio(BancoContext bancoContext) { 
            this._Context = bancoContext;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _Context.Contatos2.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _Context.Contatos2.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _Context.Contatos2.Add(contato);
            _Context.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorId(contato.Id);

            if (contatoDb == null) throw new System.Exception("Ocorreu um erro na atualização do contato.");

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _Context.Contatos2.Update(contatoDb);
            _Context.SaveChanges();

            return contatoDb;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDb = ListarPorId(id);

            if (contatoDb == null) throw new System.Exception("Houve um erro na exclusão do contato.");

            _Context.Contatos2.Remove(contatoDb);
            _Context.SaveChanges();

            return true;
        }

    }
}
