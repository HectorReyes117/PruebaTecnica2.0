using System;
using System.Collections.Generic;

namespace ApiPruebaTecnica.Models
{
    public partial class Direcciones
    {
        public int IdDireccion { get; set; }
        public string? Direccion { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
