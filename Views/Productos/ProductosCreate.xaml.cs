using jal_crud.ViewModels;

namespace jal_crud.Views.Productos;

public partial class ProductosCreate : ContentPage
{
	public ProductosCreate()
	{
		InitializeComponent();
        BindingContext = new ProductosViewModel();

        // GenerarCategorias();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Producto_Entry.Text = "";
    }
}