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
                
        public string ContactosSave(string newNombres, string newApellidos, string newDireccion, string newTelefono)
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
                    Direccion = newDireccion
                });

                db.SaveChanges();
                return "Guardado Correctamente";
            }
            catch(Exception ex) { return ex.Message; }
        }

        public List<clsContactosBE> ContactosGet()
        {
            Context db = new Context();
            return db.clsContactosBE.ToList();

        }
    }
}
