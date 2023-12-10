using jal_crud.ViewModels;

namespace jal_crud.Views.TipoFacturas;

public partial class TipoFacturasCreate : ContentPage
{
	public TipoFacturasCreate()
	{
		InitializeComponent();
        BindingContext = new TipoFacturasViewModel();        
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        TipoFactura_Entry.Text = "";
    }
}