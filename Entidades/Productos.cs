using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrdenesDeCompra.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }

        public Productos()
        {
            ProductoId = 0;
            Precio = 0;
            Cantidad = 0;
            Descripcion = string.Empty;
        }
    }
    
}
