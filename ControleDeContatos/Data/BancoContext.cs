using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        { 
            
        }

        public DbSet<ContatoModel> Contatos2 { get; set; }
        public DbSet<UsuarioModel> UsuariosContato { get; set; }
    }
}
