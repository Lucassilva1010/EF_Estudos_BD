using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Estoqueee
    {
        public Estoqueee()
        {
        }
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public int? Exemplo { get; set; }

        public virtual Produtoss Produto { get; set; }
    }
}
