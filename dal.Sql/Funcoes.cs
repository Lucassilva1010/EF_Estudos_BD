using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Modelo;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace dal.Sql
{
    public class Funcoes
    {
        public void Adicionar(Produtoss p)
        {
            using (SqlContext ctx = new SqlContext())// cria uma conexão
            {
                Console.WriteLine("Inserindo os produtos.");


                //produto.Estoques = estoqueee;//Passando os campos de Esrtoque para produtos vindo do relacionamento

                ctx.Produtoss.Add(p);// Isso vai fazer com que os produtos sejam aplicados a tabela
                ctx.SaveChanges();//Isso faz o processo de insserssão de dados seja salvo



                Console.WriteLine("Mostrando os produtos: ");
                ctx.Produtoss.ToList().ForEach(x => Console.WriteLine(x.Nome));//executando um select

                //Console.WriteLine("---------Quantidade Itens no Estoque----------");
                //ctx.Estoqueee.ToList().ForEach(x => Console.WriteLine(x.Quantidade));

                //Console.WriteLine("---------categoria de Itens----------");
                //ctx.Categoria.ToList().ForEach(x => Console.WriteLine(x.Nome));
            }
        }

        public void Atualizar(Produtoss p)
        {
            using (SqlContext ctx = new SqlContext())//cria a conexaõ
            {
                var encontrado = ctx.Produtoss.FirstOrDefault(o => o.Id == p.Id);//Faz a busca pelo o ID
                if (encontrado == null) return;//Verifica se é nulo e se for para por ai mesmo

                encontrado.Nome = p.Nome;// recebe o novo valor a ser atualizado
                encontrado.Cor = p.Cor;
                ctx.SaveChanges();//salva na tabela o novo valor


                Console.WriteLine("Mostrando os produtos: ");
                ctx.Produtoss.ToList().ForEach(x => Console.WriteLine(x.Nome));//executando um select
                ctx.Produtoss.ToList().ForEach(x => Console.WriteLine(x.Cor));//executando um select
            }

        }
        public void Alterar(Produtoss p)
        {
            using (SqlContext ctx = new SqlContext())//cria a conexaõ
            {


                ctx.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                ctx.SaveChanges();//salva na tabela o novo valor


                Console.WriteLine("Mostrando os produtos com o novo metodo de Alterar: ");
                ctx.Produtoss.ToList().ForEach(x => Console.WriteLine(x.Nome));//executando um select
                ctx.Produtoss.ToList().ForEach(x => Console.WriteLine(x.Cor));//executando um select
            }

        }

        public void Deletrar(Produtoss p)
        {
            using (SqlContext ctx = new SqlContext())//cria a conexaõ
            {
                ctx.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                ctx.SaveChanges();//salva na tabela o novo valor

                Console.WriteLine("Removido pela referencia e campo da tabela");

            }
        }

        public void Remover(int id)
        {
            using (SqlContext ctx = new SqlContext())//cria a conexaõ
            {
                var encontrado = ctx.Produtoss.FirstOrDefault(o => o.Id == id);//Faz a busca pelo o ID
                if (encontrado == null) return;//Verifica se é nulo e se for para por ai mesmo

                ctx.Remove(encontrado);//Remove o campo a partir do seu ID
                ctx.SaveChanges();//salva na tabela o novo valor

                Console.WriteLine("Removido por ID");

            }
        }

        public void Selecionar(int id)
        {
            using (SqlContext ctx = new SqlContext())
            {
                Produtoss p1 = ctx.Produtoss.Find(id);
                Produtoss p2 = ctx.Produtoss.FirstOrDefault(p=> p.Id==id);//Lambda 
                Console.WriteLine($"Lista de Produtos{p1.Nome} com Find" );
                Console.WriteLine($"Lista de Produtos{p2.Nome} com FirstOrDefault" );

            }
        }
        public void SelecionarLinq(int id)
        {
            using (SqlContext ctx = new SqlContext())
            {
                Produtoss p1 = (from a in ctx.Produtoss where a.Id == id select a).FirstOrDefault(); //Listagem usando o tipo LINQ
                
                //Lembrar de sempre apontar a saida 
                Console.WriteLine(  $"{p1.Nome} | {p1.Cor}");
            }
        }

        public void Listar()
        {
            using (SqlContext ctx =  new SqlContext())
            {
                var lista = ctx.Produtoss.Where(l=> l.Nome != "TV" && l.Cor != "Dourado");
                lista.ToList().ForEach(o=> { Console.WriteLine($"{o.Nome} - {o.Cor}");} );
            }
        }
        
        public void ListarDinamico( string nome, string cor, int? quantidade = null, int? exemplo = null )
        {
            using(SqlContext ctx = new SqlContext())
            {
                IQueryable<Produtoss> a = ctx.Produtoss.Include(o => o.Estoqueee);//Para poder carregar mais de uma tabela, é preciso usar o include

                if (!string.IsNullOrEmpty(nome)) {
                    a = a.Where(o => o.Nome.Contains(nome));
                }

                if (!string.IsNullOrEmpty(cor))
                {
                    a= a.Where(o => o.Cor.Equals(cor));
                }

                if (quantidade.HasValue)
                {
                    a= a.Where(o => o.Estoqueee.Quantidade > quantidade.Value);

                }
                if (exemplo.HasValue)
                {
                    a= a.Where(o => o.Estoqueee.Exemplo > exemplo.Value);

                }

                a.ToList().ForEach(o=> { Console.WriteLine($"{o.Nome} - {o.Cor} - "); });
            }
        }

    }
}
