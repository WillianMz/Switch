using System;

namespace Switch.Domain.Entities
{
    public class Postagem
    {
        public int Id { get; private set; }
        public DateTime DataPublicacao { get; private set; }
        public string Texto { get; private set; }
        public string UrlConteudo { get; set; }

        //chave
        public int UsuarioId { get; set; }
        //propriedade de navegação apontado para instacia de usuario
        public virtual Usuario Usuario { get; set; }

        public int GrupoId { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
