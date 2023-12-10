using jal_crud.Services;
using jal_crud.ViewModels;

namespace jal_crud.Views.Productos;

public partial class ProductosUpdate : ContentPage
{
    private DataService dataService;
    private ProductosViewModel viewModel;

    public ProductosUpdate()
    {
        InitializeComponent();
        dataService = new DataService();
        viewModel = new ProductosViewModel();
        BindingContext = viewModel;
    }

    private void Button_Buscar_Clicked(object sender, EventArgs e)
    {
        try
        {
            int categoryId = int.Parse(ProductoIdEntry.Text);
            var Producto = dataService.ProductosGetById(categoryId);

            if (Producto != null)
            {
                Label_ProductoId.Text = Producto.ProductoId.ToString();
                Entry_Producto.Text = Producto.Producto;
                Label_error.Text = "";
                Edicion.IsVisible = true;
            }
            else
            {
                Label_error.Text = "Este Tipo de Factura no existe";
                Edicion.IsVisible = false;
            }
            ProductoIdEntry.Focus();
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
            int ProductoId = int.Parse(ProductoIdEntry.Text);

            string Producto= Entry_Producto.Text;
            decimal Precio = decimal.Parse(Entry_Precio.Text);
            decimal Costo = decimal.Parse(Entry_Costo.Text);
            int Cantidad= int.Parse(Entry_Cantidad.Text);
            int CategoriaId = int.Parse(Entry_CategoriaId.Text);
            dataService.ProductosUpdate(ProductoId, Producto, Precio, Costo, Cantidad, CategoriaId);

        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Aceptar");
        }        
    }

    private void ProductoIdEntry_Completed(object sender, EventArgs e)
    {
        Button_Buscar_Clicked(sender, e);
    }
}