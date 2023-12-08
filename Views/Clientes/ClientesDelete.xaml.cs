using jal_crud.Services;
using jal_crud.ViewModels;

namespace jal_crud.Views.Clientes;

public partial class ClientesDelete : ContentPage
{
    private DataService dataService;
    private ClientesViewModel viewModel;

    public ClientesDelete()
	{
		InitializeComponent();
        dataService = new DataService();
        viewModel = new ClientesViewModel();
        BindingContext = viewModel;
    }

    private void Button_Buscar_Clicked(object sender, EventArgs e)
    {
        try
        {
            int categoryId = int.Parse(CategoryIdEntry.Text);
            var Cliente = dataService.ClientesGetById(categoryId);

            if (Cliente != null)
            {
                Label_ClienteId.Text = Cliente.ClienteId.ToString();
                Label_Nombres.Text = Cliente.Nombres;
                Label_Apellidos.Text = Cliente.Apellidos;
                Label_Direccion.Text = Cliente.Direccion;
                Label_Telefono.Text = Cliente.Telefono;
                Label_error.Text = "";
                Edicion.IsVisible = true;
            }
            else
            {
                Label_error.Text = "Este Cliente no existe";
                Edicion.IsVisible = false;
            }

        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Aceptar");
        }
    }

    private void CategoryIdEntry_HandlerChanged(object sender, EventArgs e)
    {
        Label_error.Text = "";
    }

    private async void Button_Borrar_Clicked(object sender, EventArgs e)
    {
        bool confirmacion = await DisplayAlert("Borrar Cliente", "¿Está seguro que desea borra este Cliente?", "Sí", "No");
        if (!confirmacion) { return; }
        try
        {
            int categoryId = int.Parse(CategoryIdEntry.Text);            
            var Cliente = dataService.ClientesDeleteGetById(categoryId);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Aceptar");
        }
    }
}