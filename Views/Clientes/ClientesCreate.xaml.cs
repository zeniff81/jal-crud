using jal_crud.ViewModels;

namespace jal_crud.Views.Clientes;

public partial class ClientesCreate : ContentPage
{
	public ClientesCreate()
	{
		InitializeComponent();
        BindingContext = new ClientesViewModel();        
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Nombres_Entry.Text = "";
        Apellidos_Entry.Text = "";
        Direccion_Entry.Text = "";
        Telefono_Entry.Text = "";
    }
}