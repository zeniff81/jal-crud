using jal_crud.Views.Categorias;

namespace jal_crud.Views.CRUDMenu;

public partial class CRUDMenu : ContentPage
{   
    ContentPage Create;
    ContentPage Read;
    ContentPage Update;
    ContentPage Delete;

	public CRUDMenu(string Title, ContentPage Create, ContentPage Read, ContentPage Update, ContentPage Delete)
	{
		InitializeComponent();
        this.Create = Create;
        this.Read = Read;   
        this.Update = Update;
        this.Delete = Delete;
        this.Title = Title;

        Titulo.Text = $"Menú de {Title}";
        Pagina.Title = Title;

    }

    private void Button_Crear_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(Create);
    }

    private void Button_Ver_Clicked_2(object sender, EventArgs e)
    {
        Navigation.PushAsync(Read);
    }

    private void Button_Editar_Clicked_3(object sender, EventArgs e)
    {
        Navigation.PushAsync(Update);
    }

    private void Button_Borrar_Clicked_4(object sender, EventArgs e)
    {
        Navigation.PushAsync(Delete);
    }
}