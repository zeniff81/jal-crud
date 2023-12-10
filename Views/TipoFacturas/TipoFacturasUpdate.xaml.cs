using jal_crud.Services;
using jal_crud.ViewModels;

namespace jal_crud.Views.TipoFacturas;

public partial class TipoFacturasUpdate : ContentPage
{
    private DataService dataService;
    private TipoFacturasViewModel viewModel;

    public TipoFacturasUpdate()
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
            int categoryId = int.Parse(TipoFacturaIdEntry.Text);
            var TipoFactura = dataService.TipoFacturasGetById(categoryId);

            if (TipoFactura != null)
            {
                Label_TipoFacturaId.Text = TipoFactura.TipoFacturaId.ToString();
                Entry_TipoFactura.Text = TipoFactura.TipoFactura;
                Label_error.Text = "";
                Edicion.IsVisible = true;
            }
            else
            {
                Label_error.Text = "Este Tipo de Factura no existe";
                Edicion.IsVisible = false;
            }
            TipoFacturaIdEntry.Focus();
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
            int tipoFacturaId = int.Parse(TipoFacturaIdEntry.Text);

            string TipoFactura= Entry_TipoFactura.Text;
            dataService.TipoFacturasUpdate(tipoFacturaId, TipoFactura);

        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Aceptar");
        }        
    }

    private void TipoFacturaIdEntry_Completed(object sender, EventArgs e)
    {
        Button_Buscar_Clicked(sender, e);
    }
}