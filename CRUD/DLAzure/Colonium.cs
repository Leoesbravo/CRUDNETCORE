using System;
using System.Collections.Generic;

namespace DLAzure
{
    public partial class Colonium
    {
        public Colonium()
        {
            Direccions = new HashSet<Direccion>();
        }

        public int IdColonia { get; set; }
        public string? Nombre { get; set; }
        public string? CodigoPostal { get; set; }
        public int? IdMunicipio { get; set; }

        public virtual Municipio? IdMunicipioNavigation { get; set; }
        public virtual ICollection<Direccion> Direccions { get; set; }
    }
}
