using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ProdutoCategoria
    {

        public int ProdutoId { get; set; }
        public int CategoriaId { get; set; }
        public virtual Produtoss Produtoss { get; set; }//Relaciona as tabelas
        public virtual Categoria Categoria { get; set;}//relaciona as tabelas
    }
}
