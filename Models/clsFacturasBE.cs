using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jal_crud.Models
{
    [Table("Facturas")]
    public class clsFacturasBE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacturaId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Monto{ get; set; }

        public int ClientId { get; set; }
        public int TipoFacturaId { get; set; }
        public virtual clsClientesBE Clientes { get; set; }
        public virtual clsTipoFacturasBE TipoFacturas { get; set; }

        public virtual ICollection<clsDetalleFacturasBE> DetalleFacturas { get; set; }
    }
}
