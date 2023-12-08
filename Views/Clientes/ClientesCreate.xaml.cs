using jal_crud.ViewModels;

namespace jal_crud.Views.Clientes;

public partial class ClientesCreate : ContentPage
{
	public ClientesCreate()
	{
		InitializeComponent();
        BindingContext = new ClientesViewModel();        
    }
    
}