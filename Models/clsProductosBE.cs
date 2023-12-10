using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jal_crud.Models
{
    [Table("Productos")]
    public class clsProductosBE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("Categorias")]
        public int CategoriaId { get; set; }
        public virtual clsCategoriasBE Categoria { get; set; }

        public virtual ICollection<clsDetalleFacturasBE> DetalleFacturas { get; set; }
    }
}
