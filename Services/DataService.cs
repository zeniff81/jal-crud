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
        public DataService(){}
                
        public string ContactosSave(string newNombres, string newApellidos, string newDireccion, string newTelefono, int newCiudadId)
        {
            try
            {
                db = new Context();
                int Id = (db.clsContactosBE.Count() == 0 ? 100000 : db.clsContactosBE.Max(x => x.ContactosId)) +1 ;

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
            catch(Exception ex) { return ex.Message; }
        }

        public List<clsContactosBE> ContactosGet()
        {
            Context db = new Context();

            var result = from Ci in db.clsCiudadesBE join C in db.clsContactosBE on Ci.CiudadId equals C.CiudadId select new clsContactosBE 
            { 
                ContactosId = C.ContactosId,
                CiudadId = C.CiudadId,
                Nombres = C.Nombres,
                Apellidos = C.Apellidos,
                Telefono = C.Telefono,
                Direccion = C.Direccion,
                Ciudades =  new clsCiudadesBE
                {
                    CiudadId = Ci.CiudadId,
                    Ciudad = Ci.Ciudad
                }
            };

            return result.ToList();

        }   
    }
}
