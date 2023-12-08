using jal_crud.Data;
using jal_crud.Views;
using jal_crud.Views.CRUDMenu;
using Microsoft.EntityFrameworkCore;
using jal_crud.Views.Clientes;
using jal_crud.Views.Categorias;

namespace jal_crud;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();        
    }

    private async void ButtonCategorias_Clicked(object sender, EventArgs e)
    {
        ContentPage Create = new CategoriasCreate();
        ContentPage Read= new CategoriasRead();
        ContentPage Update= new CategoriasUpdate();
        ContentPage Delete= new CategoriasDelete();

        await Navigation.PushAsync(new CRUDMenu("Categorías", Create, Read, Update, Delete));
    }
    private async void ButtonClientes_Clicked(object sender, EventArgs e)
    {
        ContentPage Create = new ClientesCreate();
        ContentPage Read = new ClientesRead();
        ContentPage Update = new ClientesUpdate();
        ContentPage Delete = new ClientesDelete();

        await Navigation.PushAsync(new CRUDMenu("Clientes", Create, Read, Update, Delete));
    }
    private async void ButttonTipoFactura_Clicked(object sender, EventArgs e)
    {
    }
    private async void ButtonFacturas_Clicked(object sender, EventArgs e)
    {
    }
    private async void ButtonProductos_Clicked(object sender, EventArgs e)
    {
    }
    private async void ButtonDetalleFacturas_Clicked(object sender, EventArgs e)
    {
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        using (var context = new Context())
        {
            // Get all DbSet properties from the context
            var dbSetProperties = context.GetType().GetProperties()
                .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

            foreach (var property in dbSetProperties)
            {
                // Get the DbSet property value
                var dbSet = (IEnumerable<object>)property.GetValue(context);

                // Remove all entities from the DbSet
                foreach (var entity in dbSet.ToList())
                {
                    context.Entry(entity).State = EntityState.Deleted;
                }
            }

            // Save changes to the database
            context.SaveChanges();
        }


    }
}