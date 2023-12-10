using jal_crud.Data;
using jal_crud.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jal_crud.Services
{
    public class DataService
    {
        Context db;
        public DataService() { }

        #region Contactos
        public string ContactosSave(string newNombres, string newApellidos, string newDireccion, string newTelefono, int newCiudadId)
        {
            try
            {
                db = new Context();
                int Id = (db.clsContactosBE.Count() == 0 ? 100000 : db.clsContactosBE.Max(x => x.ContactosId)) + 1;

                db.clsContactosBE.Add(new Models.clsContactosBE
                {
                    ContactosId = Id,
                    Nombres = newNombres,
                    Apellidos = newApellidos,
                    Telefono = newTelefono,
                    Direccion = newDireccion,
                    CiudadId = newCiudadId
                });

                db.SaveChanges();
                return "Guardado Correctamente";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string ContactosUpdate(int newContactoId, string newNombres, string newApellidos, string newDireccion, string newTelefono, int newCiudadId)
        {
            try
            {

                db = new Context();
                var row = db.clsContactosBE.Where(x => x.ContactosId == newContactoId).FirstOrDefault();
                if (row != null)
                {
                    row.Nombres = newNombres;
                    row.Apellidos = newApellidos;
                    row.Direccion = newDireccion;
                    row.Telefono = newTelefono;
                    row.CiudadId = newCiudadId;

                    db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Modificado correctamente";
        }

        public string ContactosDeleteGetById(int newContactoId)
        {
            try
            {

                db = new Context();
                var row = db.clsContactosBE.Where(x => x.ContactosId == newContactoId).FirstOrDefault();
                if (row != null)
                {
                    db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Eliminado correctamente";
        }

        public clsContactosBE ContactosGetById(int newContactoId)
        {
            try
            {

                db = new Context();
                return db.clsContactosBE.Where(x => x.ContactosId == newContactoId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new clsContactosBE();
            }
        }

        public List<clsContactosBE> ContactosGet()
        {
            Context db = new Context();

            var result = from Ci in db.clsCiudadesBE
                         join C in db.clsContactosBE on Ci.CiudadId equals C.CiudadId
                         select new clsContactosBE
                         {
                             ContactosId = C.ContactosId,
                             CiudadId = C.CiudadId,
                             Nombres = C.Nombres,
                             Apellidos = C.Apellidos,
                             Telefono = C.Telefono,
                             Direccion = C.Direccion,
                             Ciudades = new clsCiudadesBE
                             {
                                 CiudadId = Ci.CiudadId,
                                 Ciudad = Ci.Ciudad
                             }
                         };

            return result.ToList();

        }
        #endregion

        #region Ciudades
        public string CiudadesSave(string newCiudad)
        {
            try
            {
                db = new Context();
                int Id = (db.clsCiudadesBE.Count() == 0 ? 100000 : db.clsCiudadesBE.Max(x => x.CiudadId)) + 1;

                db.clsCiudadesBE.Add(new Models.clsCiudadesBE
                {
                    CiudadId = Id,
                    Ciudad = newCiudad,
                });

                db.SaveChanges();
                return "Guardado Correctamente";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string CiudadesUpdate(int newCiudadId, string newCiudad)
        {
            try
            {

                db = new Context();
                var row = db.clsCiudadesBE.Where(x => x.CiudadId == newCiudadId).FirstOrDefault();
                if (row != null)
                {
                    row.Ciudad = newCiudad;

                    db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Modificado correctamente";
        }

        public string CiudadesDeleteGetById(int CiudadId)
        {
            try
            {

                db = new Context();
                var row = db.clsCiudadesBE.Where(x => x.CiudadId == CiudadId).FirstOrDefault();
                if (row != null)
                {
                    db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Eliminado correctamente";
        }

        public clsCiudadesBE CiudadesGetById(int newCiudadId)
        {
            try
            {

                db = new Context();
                return db.clsCiudadesBE.Where(x => x.CiudadId == newCiudadId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new clsCiudadesBE();
            }
        }

        public List<clsCiudadesBE> CiudadesGet()
        {
            Context db = new Context();

            return db.clsCiudadesBE.ToList();

        }
        #endregion

        #region Categorias
        public string CategoriasSave(string newCategoria)
        {
            try
            {
                db = new Context();

                db.clsCategoriasBE.Add(new Models.clsCategoriasBE
                {
                    Categoria = newCategoria,
                });

                db.SaveChanges();
                return "Guardado Correctamente";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string CategoriasUpdate(int newCategoriaId, string newCategoria)
        {
            try
            {

                db = new Context();
                var row = db.clsCategoriasBE.Where(x => x.CategoriaId == newCategoriaId).FirstOrDefault();
                if (row != null)
                {
                    row.Categoria = newCategoria;

                    db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Modificado correctamente";
        }

        public string CategoriasDeleteGetById(int CategoriaId)
        {
            try
            {

                db = new Context();
                var row = db.clsCategoriasBE.Where(x => x.CategoriaId == CategoriaId).FirstOrDefault();
                if (row != null)
                {
                    db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Eliminado correctamente";
        }

        public clsCategoriasBE CategoriasGetById(int newCategoriaId)
        {
            try
            {

                db = new Context();
                return db.clsCategoriasBE.Where(x => x.CategoriaId == newCategoriaId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new clsCategoriasBE();
            }
        }

        public List<clsCategoriasBE> CategoriasGet()
        {
            Context db = new Context();

            var result = from Ca in db.clsCategoriasBE
                         select new clsCategoriasBE
                         {
                             CategoriaId = Ca.CategoriaId,
                             Categoria = Ca.Categoria
                         };

            return result.ToList();

        }
        #endregion

        #region Clientes
        public string ClientesSave(string newNombres, string newApellidos, string newDireccion, string newTelefono)
        {
            try
            {
                db = new Context();

                db.clsClientesBE.Add(new Models.clsClientesBE
                {
                    Nombres = newNombres,
                    Apellidos = newApellidos,
                    Telefono = newTelefono,
                    Direccion = newDireccion
                });

                db.SaveChanges();
                return "Cliente guardado Correctamente";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string ClientesUpdate(int newClienteId, string newNombres, string newApellidos, string newDireccion, string newTelefono)
        {
            try
            {

                db = new Context();
                var row = db.clsClientesBE.Where(x => x.ClienteId == newClienteId).FirstOrDefault();
                if (row != null)
                {
                    row.Nombres = newNombres;
                    row.Apellidos = newApellidos;
                    row.Direccion = newDireccion;
                    row.Telefono = newTelefono;

                    db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Modificado correctamente";
        }

        public string ClientesDeleteGetById(int ClienteId)
        {
            try
            {

                db = new Context();
                var row = db.clsClientesBE.Where(x => x.ClienteId == ClienteId).FirstOrDefault();
                if (row != null)
                {
                    db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Eliminado correctamente";
        }

        public clsClientesBE ClientesGetById(int newClienteId)
        {
            try
            {

                db = new Context();
                return db.clsClientesBE.Where(x => x.ClienteId == newClienteId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new clsClientesBE();
            }
        }

        public List<clsClientesBE> ClientesGet()
        {
            Context db = new Context();

            var result = from Ca in db.clsClientesBE
                         select new clsClientesBE
                         {
                             ClienteId = Ca.ClienteId,
                             Nombres = Ca.Nombres,
                             Apellidos = Ca.Apellidos,
                             Direccion = Ca.Direccion,
                             Telefono = Ca.Telefono,
                         };

            return result.ToList();

        }
        #endregion

        #region TipoFacturas
        public string TipoFacturasSave(string newTipoFactura)
        {
            try
            {
                db = new Context();

                db.clsTipoFacturasBE.Add(new Models.clsTipoFacturasBE
                {
                    TipoFactura = newTipoFactura
                });

                db.SaveChanges();
                return "Tipo de Factura guardado Correctamente";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string TipoFacturasUpdate(int newTipoFacturaId, string newTipoFacturas)
        {
            try
            {

                db = new Context();
                var row = db.clsTipoFacturasBE.Where(x => x.TipoFacturaId == newTipoFacturaId).FirstOrDefault();
                if (row != null)
                {
                    row.TipoFactura = newTipoFacturas;

                    db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Modificado correctamente";
        }

        public string TipoFacturasDeleteGetById(int TipoFacturaId)
        {
            try
            {

                db = new Context();
                var row = db.clsTipoFacturasBE.Where(x => x.TipoFacturaId == TipoFacturaId).FirstOrDefault();
                if (row != null)
                {
                    db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Eliminado correctamente";
        }

        public clsTipoFacturasBE TipoFacturasGetById(int newTipoFacturaId)
        {
            try
            {

                db = new Context();
                return db.clsTipoFacturasBE.Where(x => x.TipoFacturaId == newTipoFacturaId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new clsTipoFacturasBE();
            }
        }

        public List<clsTipoFacturasBE> TipoFacturasGet()
        {
            Context db = new Context();

            var result = from Ca in db.clsTipoFacturasBE
                         select new clsTipoFacturasBE
                         {
                             TipoFacturaId = Ca.TipoFacturaId,
                             TipoFactura = Ca.TipoFactura,
                         };

            return result.ToList();

        }
        #endregion

        #region Productos
        public string ProductosSave(string newProducto, decimal newPrecio, decimal newCosto, int newCantidad, int newCategoriaId)
        {
            try
            {
                db = new Context();

                db.clsProductosBE.Add(new Models.clsProductosBE
                {
                    Producto = newProducto,
                    Precio = newPrecio,
                    Costo = newCosto,
                    Cantidad = newCantidad,
                    CategoriaId = newCategoriaId
                });

                db.SaveChanges();
                return "Producto guardado Correctamente";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string ProductosUpdate(int newProductoId, string newProducto, decimal newPrecio, decimal newCosto, int newCantidad, int newCategoriaId)
        {
            try
            {

                db = new Context();
                var row = db.clsProductosBE.Where(x => x.ProductoId == newProductoId).FirstOrDefault();
                if (row != null)
                {
                    row.Producto = newProducto;
                    row.Precio = newPrecio;
                    row.Costo = newCosto;
                    row.Cantidad = newCantidad;
                    row.CategoriaId = newCategoriaId;

                    db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Producto Modificado correctamente";
        }

        public string ProductosDeleteGetById(int ProductoId)
        {
            try
            {

                db = new Context();
                var row = db.clsProductosBE.Where(x => x.ProductoId == ProductoId).FirstOrDefault();
                if (row != null)
                {
                    db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Producto Eliminado correctamente";
        }

        public clsProductosBE ProductosGetById(int newProductoId)
        {
            try
            {

                db = new Context();
                return db.clsProductosBE.Where(x => x.ProductoId == newProductoId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new clsProductosBE();
            }
        }

        public List<clsProductosBE> ProductosGet()
        {
            Context db = new Context();

            var result = from Pro in db.clsProductosBE
                         select new clsProductosBE
                         {
                             ProductoId = Pro.ProductoId,
                             Producto = Pro.Producto,
                             Precio = Pro.Precio,
                             Costo = Pro.Costo,
                             Cantidad = Pro.Cantidad,
                             CategoriaId = Pro.CategoriaId,
                             Categoria = Pro.Categoria
                         };

            return result.ToList();

        }
        #endregion

        #region Facturas
        public string FacturasSave(
            DateTime newFecha,
            decimal newSubtotal, 
            decimal newDescuento, 
            decimal newMonto,
            int newClienteId,
            int newTipoFacturaId
            )
        {
            try
            {
                db = new Context();

                db.clsFacturasBE.Add(new Models.clsFacturasBE
                {
                    Fecha = newFecha,
                    Subtotal = newSubtotal,
                    Descuento = newDescuento,
                    Monto = newMonto,
                    ClienteId = newClienteId,
                    TipoFacturaId = newTipoFacturaId
                });

                db.SaveChanges();
                return "Factura guardada Correctamente";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string FacturasUpdate(   
            int FacturaId,
            decimal newSubtotal,
            decimal newDescuento,
            decimal newMonto,
            int newClienteId,
            int newTipoFacturaId
            )
        {
            try
            {

                db = new Context();
                var row = db.clsFacturasBE.Where(x => x.FacturaId == FacturaId).FirstOrDefault();
                if (row != null)
                {
                    row.Subtotal = newSubtotal;
                    row.Descuento = newDescuento ;
                    row.Monto= newMonto;
                    row.ClienteId = newClienteId ;
                    row.TipoFacturaId= newTipoFacturaId;

                    db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Factura Modificado correctamente";
        }

        public string FacturasDeleteGetById(int FacturaId)
        {
            try
            {

                db = new Context();
                var row = db.clsFacturasBE.Where(x => x.FacturaId == FacturaId).FirstOrDefault();
                if (row != null)
                {
                    db.Entry(row).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Factura Eliminado correctamente";
        }

        public clsFacturasBE FacturasGetById(int newFacturaId)
        {
            try
            {

                db = new Context();
                return db.clsFacturasBE.Where(x => x.FacturaId == newFacturaId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new clsFacturasBE();
            }
        }

        public List<clsFacturasBE> FacturasGet()
        {
            Context db = new Context();

            var result = from Fac in db.clsFacturasBE
                         select new clsFacturasBE
                         {
                             Fecha = Fac.Fecha,
                             Subtotal = Fac.Subtotal,
                             Descuento = Fac.Descuento,
                             Monto = Fac.Monto,
                             ClienteId = Fac.ClienteId,
                             TipoFacturaId = Fac.TipoFacturaId
                         };

            return result.ToList();

        }
        #endregion
    }
}
