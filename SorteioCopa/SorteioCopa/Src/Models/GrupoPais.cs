using SorteioCopa.Models;

namespace SorteioCopa.Src.Models
{
    public class GrupoPais
    {
        public int IdGrupoPais { get; set; }
        public int IdGrupo { get; set; }
        public int IdPais { get; set; }
        public Grupos Grupos { get; set; }
        public paises paises { get; set; }


    }
}
