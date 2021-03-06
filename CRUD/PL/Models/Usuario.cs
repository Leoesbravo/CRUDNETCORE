using System;
using System.Collections.Generic;

namespace PL.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string? UserName { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public int? IdRol { get; set; }
        public virtual Rol? IdRolNavigation { get; set; }
    }
}
