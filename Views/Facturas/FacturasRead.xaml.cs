using jal_crud.ViewModels;

namespace jal_crud.Views.Facturas;

public partial class FacturasRead : ContentPage
{
    public FacturasRead()
    {
        InitializeComponent();
        BindingContext = new FacturasViewModel();
    }
}