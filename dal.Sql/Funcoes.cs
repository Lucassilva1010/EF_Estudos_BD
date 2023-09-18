using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
