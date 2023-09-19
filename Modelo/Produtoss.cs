using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Produtoss
    {
        public Produtoss()
        {
            ProdutoCategorias = new HashSet<ProdutoCategoria>();
        }
        public int Id { get; set; }
        public string  Nome { get; set; }
        public string  Cor { get; set; }

        public virtual Estoqueee ? Estoqueee { get; set; }
        public virtual ICollection<ProdutoCategoria> ProdutoCategorias { get; set; }

    }
}
