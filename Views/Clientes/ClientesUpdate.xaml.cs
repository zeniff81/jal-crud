using jal_crud.Services;
using jal_crud.ViewModels;

namespace jal_crud.Views.Clientes;

public partial class ClientesUpdate : ContentPage
{
    private DataService dataService;
    private ClientesViewModel viewModel;

    public ClientesUpdate()
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
            int categoryId = int.Parse(ClienteIdEntry.Text);
            var Cliente = dataService.ClientesGetById(categoryId);

            if (Cliente != null)
            {
                Label_ClienteId.Text = Cliente.ClienteId.ToString();
                Entry_Nombres.Text = Cliente.Nombres;
                Entry_Apellidos.Text = Cliente.Apellidos;
                Entry_Direccion.Text = Cliente.Direccion;
                Entry_Telefono.Text = Cliente.Telefono;
                Label_error.Text = "";
                Edicion.IsVisible = true;
            }
            else
            {
                Label_error.Text = "Este cliente no existe";
                Edicion.IsVisible = false;
            }
            ClienteIdEntry.Focus();
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

    private void Button_Guardar_Clicked(object sender, EventArgs e)
    {
        try
        {
            int categoryId = int.Parse(ClienteIdEntry.Text);

            string Nombres = Entry_Nombres.Text;
            string Apellidos = Entry_Apellidos.Text;
            string Direccion = Entry_Direccion.Text;
            string Telefono = Entry_Telefono.Text;
            var Cliente = dataService.ClientesUpdate(categoryId, Nombres, Apellidos, Direccion, Telefono);

        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Aceptar");
        }        
    }

    private void ClienteIdEntry_Completed(object sender, EventArgs e)
    {
        Button_Buscar_Clicked(sender, e);
    }
}