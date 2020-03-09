using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OrdenesDeCompra.Entidades;

namespace OrdenesDeCompra.Entidades
{
    public class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }

        [ForeignKey("Clientes")]
        public int ClienteID { get; set; }

        public DateTime FechaOrden { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("OrdenId")]
        public virtual List<OrdenDetalle> Detalles { get; set; }


        public Ordenes()
        {
            OrdenId = 0;
            FechaOrden = DateTime.Now;
            ClienteID = 0;
            Total = 0;
            Detalles = new List<OrdenDetalle>();
        }
    }
}
