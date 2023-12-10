using jal_crud.Services;
using jal_crud.ViewModels;

namespace jal_crud.Views.TipoFacturas;

public partial class TipoFacturasDelete : ContentPage
{
    private DataService dataService;
    private TipoFacturasViewModel viewModel;

    public TipoFacturasDelete()
	{
		InitializeComponent();
        dataService = new DataService();
        viewModel = new TipoFacturasViewModel();
        BindingContext = viewModel;
    }

    private void Button_Buscar_Clicked(object sender, EventArgs e)
    {
        try
        {
            int categoryId = int.Parse(CategoryIdEntry.Text);
            var TipoFactura = dataService.TipoFacturasGetById(categoryId);

            if (TipoFactura != null)
            {
                Label_TipoFacturaId.Text = TipoFactura.TipoFacturaId.ToString();
                Label_TipoFactura.Text = TipoFactura.TipoFactura;
                Label_error.Text = "";
                Edicion.IsVisible = true;
            }
            else
            {
                Label_error.Text = "Este Tipo de Factura no existe";
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
        bool confirmacion = await DisplayAlert("Borrar Tipo de Factura", "¿Está seguro que desea borra este Tipo de Factura?", "Sí", "No");
        if (!confirmacion) { return; }
        try
        {
            int categoryId = int.Parse(CategoryIdEntry.Text);            
            var TipoFactura = dataService.TipoFacturasDeleteGetById(categoryId);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Aceptar");
        }
    }
}