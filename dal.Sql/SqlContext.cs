using Microsoft.EntityFrameworkCore;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.Sql
{
    public class SqlContext: DbContext
    {
        public SqlContext()
        {
            
        }
        public SqlContext(DbContextOptions<SqlContext>op) : base(op)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=(localdb)\MSSQLLocalDB;Database=Aula;");//String de conexão SQL
        }
       public DbSet<Produtoss> Produtoss { get; set; }//Provider de referência a tabela do banco em execução
        public DbSet<Estoqueee> Estoqueee { get; set; }//Provider de referência a tabela
        public DbSet<Categoria> Categoria { get; set; }//criado sem ter no banco... para ser aplicado a partir do codigo
    }
}
