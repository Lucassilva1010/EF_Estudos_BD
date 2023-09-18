using System;
using System.Collections.Generic;

namespace dal.Mysql.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Produtoss = new HashSet<Produtoss>();
        }
        public int Id { get; set; }
        public string? Nome { get; set; }

        public virtual ICollection<Produtoss> Produtoss { get; set; }   
    }
}
