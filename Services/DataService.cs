using jal_crud.Data;
using jal_crud.Models;
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
    }
}
