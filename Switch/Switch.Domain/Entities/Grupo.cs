﻿using System.Collections.Generic;

namespace Switch.Domain.Entities
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlFoto { get; set; }
        public virtual ICollection<Postagem> Postagens { get; set; }
    }
}
