using System.Threading.Channels;

namespace dal.Sql
{
    public class Class1
    {
        public Class1()
        {
            Console.WriteLine("Camada 02 - SQL -- Iniciando a retornar os dados");
            using (SqlContext ctx = new SqlContext())// cria uma conexão
            {
                ctx.Produtoss.ToList().ForEach(x => Console.WriteLine(x.Nome));//executando um select

                Console.WriteLine("---------Quantidade Itens no Estoque----------");
                ctx.Estoqueee.ToList().ForEach(x => Console.WriteLine(x.Quantidade));

                Console.WriteLine("---------categoria de Itens----------");
                ctx.Categoria.ToList().ForEach(x => Console.WriteLine(x.Nome));
            }        

        }


    }
}