using System;
using System.Collections.Generic;

namespace dal.Mysql.Models
{
    public partial class Estoque
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public int? Exemplo { get; set; }

        public virtual Produtoss Produto { get; set; } = null!;
    }
}
