using jal_crud.Services;
using jal_crud.ViewModels;

namespace jal_crud.Views.Categorias;

public partial class CategoriasUpdate : ContentPage
{
    private DataService dataService;
    private CategoriasViewModel viewModel;

    public CategoriasUpdate()
    {
        InitializeComponent();
        dataService = new DataService();
        viewModel = new CategoriasViewModel();
        BindingContext = viewModel;
    }

    private void Button_Buscar_Clicked(object sender, EventArgs e)
    {
        try
        {
            int categoryId = int.Parse(CategoryIdEntry.Text);
            var categoria = dataService.CategoriasGetById(categoryId);

            if (categoria != null)
            {
                Label_CategoriaId.Text = categoria.CategoriaId.ToString();
                Entry_Categoria.Text = categoria.Categoria;
                Label_error.Text = "";
                Edicion.IsVisible = true;
            }
            else
            {                
                Label_error.Text = "Este elemento no existe";
                Edicion.IsVisible = false;
            }

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
            int categoryId = int.Parse(CategoryIdEntry.Text);
            string Texto = Entry_Categoria.Text;
            var categoria = dataService.CategoriasUpdate(categoryId, Texto);

            

        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Aceptar");
        }
    }
}