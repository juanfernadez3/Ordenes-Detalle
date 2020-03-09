using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrdenesDeCompra.Entidades
{
    public class Clientes
    {
        [Key]
        public int CLienteId { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public String Direccion { get; set; }
        public string Telefono { get; set; }
        public ICollection<Ordenes> Ordenes { get; set; }
        public Clientes()
        {
            CLienteId = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
        }
    }
}
