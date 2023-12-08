using jal_crud.ViewModels;

namespace jal_crud.Views.Categorias;

public partial class CategoriasCreate : ContentPage
{
    public CategoriasCreate()
    {
        InitializeComponent();
        BindingContext = new CategoriasViewModel();
    }

}