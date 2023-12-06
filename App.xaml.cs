using jal_crud.Data;
using jal_crud.Views;

namespace jal_crud
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Context db = new Context();
            db.clsCiudadesBE.Add(new Models.clsCiudadesBE
            {                
                Ciudad = "Santiago"
            });
            db.SaveChanges();

            //MainPage = new ContactoView();
            MainPage = new ContactosView();
        }
    }
}