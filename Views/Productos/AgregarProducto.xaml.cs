using jal_crud.Models;
using jal_crud.ViewModels;

namespace jal_crud.Views.Productos;

public partial class AgregarProducto : ContentPage
{
	public AgregarProducto()
	{
		InitializeComponent();
        BindingContext = new ProductosViewModel();
    }

    private void ProductosLista_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is clsProductosBE productoSeleccionado)
        {
            int productoId = productoSeleccionado.ProductoId;
            DisplayAlert("Producto Seleccionado", $"ProductoId: {productoId}", "Aceptar");
        }

            ((ListView)sender).SelectedItem = null;
    }
}