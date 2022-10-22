using System;
using System.Collections.Generic;

namespace MaestroDetalleMVC.Models
{
    public partial class DetalleFactura
    {
        public int NroDetalle { get; set; }
        public int NroFactura { get; set; }
        public string Producto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        public virtual Factura NroFacturaNavigation { get; set; }
    }
}
