using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jal_crud.Models
{
    [Table("DetalleFacturas")]
    public  class clsDetalleFacturasBE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int clsDetalleFacturaId { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public virtual clsFacturasBE Facturas {  get; set; }
        public virtual clsProductosBE Productos { get; set; }

    }
}
