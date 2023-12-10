using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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

        [ForeignKey("Clientes")]
        public int ClienteId { get; set; }
        public virtual clsClientesBE Cliente { get; set; }
        [ForeignKey("TipoFacturas")]
        public int TipoFacturaId { get; set; }
        public virtual clsTipoFacturasBE TipoFactura { get; set; }

        public virtual ICollection<clsDetalleFacturasBE> DetalleFacturas { get; set; }

        public clsFacturasBE()
        {
            Fecha = DateTime.Now;
        }

    }
}
