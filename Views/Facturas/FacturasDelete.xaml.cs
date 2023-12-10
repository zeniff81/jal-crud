using jal_crud.Services;
using jal_crud.ViewModels;

namespace jal_crud.Views.Facturas;

public partial class FacturasDelete : ContentPage
{
    private DataService dataService;
    private FacturasViewModel viewModel;

    public FacturasDelete()
	{
		InitializeComponent();
        dataService = new DataService();
        viewModel = new FacturasViewModel();
        BindingContext = viewModel;
    }

    private void Button_Buscar_Clicked(object sender, EventArgs e)
    {
        try
        {
            int categoryId = int.Parse(CategoryIdEntry.Text);
            var Factura = dataService.FacturasGetById(categoryId);

            if (Factura != null)
            {
                Label_FacturaId.Text = Factura.FacturaId.ToString();
                Subtotal_Label.Text = Factura.Subtotal.ToString();
                Descuento_Label.Text = Factura.Descuento.ToString();
                Monto_Label.Text = Factura.Monto.ToString();
                ClienteId_Label.Text = Factura.ClienteId.ToString();
                TipoFacturaId_Label.Text = Factura.TipoFacturaId.ToString();

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
            var Factura = dataService.FacturasDeleteGetById(categoryId);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Aceptar");
        }
    }
}