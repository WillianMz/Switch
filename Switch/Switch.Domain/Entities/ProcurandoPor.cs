using Switch.Domain.Enums;

namespace Switch.Domain.Entities
{
    public class ProcurandoPor
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public bool NaoEspecificado
        {
            get { return Id == (int)ProcurandoEnum.NaoEspecificado; }
        }

        public bool Amizade
        {
            get { return Id == (int)ProcurandoEnum.Amizade; }
        }

        public bool Namoro
        {
            get { return Id == (int)ProcurandoEnum.Namoro; }
        }

        public bool RelacionamentoSerio
        {
            get { return Id == (int)ProcurandoEnum.RelacionamentoSerio; }
        }
    }
}
