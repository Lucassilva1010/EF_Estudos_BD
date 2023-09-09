using dal.Mysql.Models;

namespace dal.Mysql
{
    public class Class1
    {
        public Class1()
        {
            Console.WriteLine("Camada 02 - MySql");
            
           
            using (Mysql.Models.aulasContext ctx = new aulasContext())// cria uma conexão
            {
                Console.Write("---------Produtos Itens no Estoque do MySQL----------");
                ctx.Produtosses.ToList().ForEach(x => Console.WriteLine(x.Nomee));//executando um select

                Console.WriteLine("---------Quantidade Itens no Estoque do MySQL----------");
                ctx.Estoques.ToList().ForEach(x => Console.WriteLine(x.Quantidade));

            }
        }

        //Comando para Gerar o Scaffold quando vamos usar a forma de DBFirst
            //Scaffold-DbContext "Server=localhost;Database=aulas;Uid=root;Pwd=root;" Pomelo.EntityFrameworkCore.MySql -o Models -f;
        }
    }