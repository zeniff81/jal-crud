using jal_crud.ViewModels;

namespace jal_crud.Views.Productos;

public partial class ProductosRead : ContentPage
{
    public ProductosRead()
    {
        InitializeComponent();
        BindingContext = new ProductosViewModel();
    }
}