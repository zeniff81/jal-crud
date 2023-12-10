using jal_crud.Services;
using jal_crud.ViewModels;

namespace jal_crud.Views.Facturas;

public partial class FacturasUpdate : ContentPage
{
    private DataService dataService;
    private FacturasViewModel viewModel;

    public FacturasUpdate()
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
            int categoryId = int.Parse(FacturaIdEntry.Text);
            var Factura = dataService.FacturasGetById(categoryId);

            if (Factura != null)
            {
                Label_FacturaId.Text = Factura.FacturaId.ToString();
                
                Label_FacturaId.Text = Factura.FacturaId.ToString();
                Entry_Subtotal.Text = Factura.Subtotal.ToString();
                Entry_Descuento.Text = Factura.Descuento.ToString();
                Entry_Monto.Text = Factura.Monto.ToString();
                Entry_ClienteId.Text = Factura.ClienteId.ToString();
                Entry_TipoFacturaId.Text = Factura.TipoFacturaId.ToString();
                Label_error.Text = "";
                Edicion.IsVisible = true;
            }
            else
            {
                Label_error.Text = "Este Tipo de Factura no existe";
                Edicion.IsVisible = false;
            }
            FacturaIdEntry.Focus();
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
            int FacturaId = int.Parse(FacturaIdEntry.Text);
            decimal Subtotal= decimal.Parse(Entry_Subtotal.Text);
            decimal Descuento = decimal.Parse(Entry_Descuento.Text);
            decimal Monto = decimal.Parse(Entry_Monto.Text);
            int ClienteId= int.Parse(Entry_ClienteId.Text);
            int TipoFacturaId= int.Parse(Entry_TipoFacturaId.Text);
            dataService.FacturasUpdate(FacturaId, Subtotal, Descuento, Monto, ClienteId, TipoFacturaId);

        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Aceptar");
        }        
    }

    private void FacturaIdEntry_Completed(object sender, EventArgs e)
    {
        Button_Buscar_Clicked(sender, e);
    }
}