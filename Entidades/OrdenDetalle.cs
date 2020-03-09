using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrdenesDeCompra.Entidades
{
    public class OrdenDetalle
    {
        [Key]
        public int ID { get; set; }
        public int ProductoId { get; set; }
        public int OrdenId { get; set; }
        public int Cantidad { get; set; }

        public OrdenDetalle()
        {
            ID = 0;
            ProductoId = 0;
            OrdenId = 0;
            Cantidad = 0;
        }
    }
}
