﻿using System;
using System.Collections.Generic;

namespace DLAzure
{
    public partial class Municipio
    {
        public Municipio()
        {
            Colonia = new HashSet<Colonium>();
        }

        public int IdMunicipio { get; set; }
        public string? Nombre { get; set; }
        public int? IdEstado { get; set; }

        public virtual Estado? IdEstadoNavigation { get; set; }
        public virtual ICollection<Colonium> Colonia { get; set; }
    }
}
