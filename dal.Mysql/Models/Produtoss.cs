﻿using System;
using System.Collections.Generic;

namespace dal.Mysql.Models
{
    public partial class Produtoss
    {
        public Produtoss()
        {
            Estoques = new HashSet<Estoque>();
        }

        public int Id { get; set; }
        public string Nomee { get; set; } = null!;
        public string Corr { get; set; } = null!;

        public virtual ICollection<Estoque> Estoques { get; set; }
    }
}
