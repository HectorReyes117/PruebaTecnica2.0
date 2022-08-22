using System;
using System.Collections.Generic;

namespace ApiPruebaTecnica.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Direcciones = new HashSet<Direcciones>();
        }

        public int IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Clave { get; set; }

        public virtual ICollection<Direcciones> Direcciones { get; set; }
    }
}
