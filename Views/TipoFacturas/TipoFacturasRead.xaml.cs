using jal_crud.ViewModels;

namespace jal_crud.Views.TipoFacturas;

public partial class TipoFacturasRead : ContentPage
{
    public TipoFacturasRead()
    {
        InitializeComponent();
        BindingContext = new TipoFacturasViewModel();
    }
}