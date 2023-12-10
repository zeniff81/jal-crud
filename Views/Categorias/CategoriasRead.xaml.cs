using jal_crud.ViewModels;

namespace jal_crud.Views.Categorias;

public partial class CategoriasRead : ContentPage
{
    public CategoriasRead()
    {
        InitializeComponent();
        BindingContext = new CategoriasViewModel();
    }
}