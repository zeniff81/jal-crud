using jal_crud.ViewModels;

namespace jal_crud.Views.Clientes;

public partial class ClientesRead : ContentPage
{
    public ClientesRead()
    {
        InitializeComponent();
        BindingContext = new ClientesViewModel();
    }
}