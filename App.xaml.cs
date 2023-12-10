using jal_crud.Data;
using jal_crud.Views;

namespace jal_crud
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            // MainPage = new Test();

        }
    }
}