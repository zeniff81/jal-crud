using jal_crud.Data;
using jal_crud.Views;
using jal_crud.Views.CRUDMenu;
using Microsoft.EntityFrameworkCore;
using jal_crud.Views.Clientes;
using jal_crud.Views.Categorias;
using jal_crud.Views.TipoFacturas;
using jal_crud.Views.Productos;
using jal_crud.Views.Facturas;
using jal_crud.Models;

namespace jal_crud;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        CrearDatosDeEjemplo();
    }

    private async void ButtonCategorias_Clicked(object sender, EventArgs e)
    {
        ContentPage Create = new CategoriasCreate();
        ContentPage Read = new CategoriasRead();
        ContentPage Update = new CategoriasUpdate();
        ContentPage Delete = new CategoriasDelete();

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
        ContentPage Create = new TipoFacturasCreate();
        ContentPage Read = new TipoFacturasRead();
        ContentPage Update = new TipoFacturasUpdate();
        ContentPage Delete = new TipoFacturasDelete();

        await Navigation.PushAsync(new CRUDMenu("Tipo de Facturas", Create, Read, Update, Delete));
    }
    private async void ButtonFacturas_Clicked(object sender, EventArgs e)
    {
        ContentPage Create = new FacturasCreate();
        ContentPage Read = new FacturasRead();
        ContentPage Update = new FacturasUpdate();
        ContentPage Delete = new FacturasDelete();

        await Navigation.PushAsync(new CRUDMenu("Facturas", Create, Read, Update, Delete));
    }
    private async void ButtonProductos_Clicked(object sender, EventArgs e)
    {
        ContentPage Create = new ProductosCreate();
        ContentPage Read = new ProductosRead();
        ContentPage Update = new ProductosUpdate();
        ContentPage Delete = new ProductosDelete();

        await Navigation.PushAsync(new CRUDMenu("Productos", Create, Read, Update, Delete));
    }
    private async void ButtonDetalleFacturas_Clicked(object sender, EventArgs e)
    {
    }

    private void Borrar_Button_Clicked_1(object sender, EventArgs e)
    {
        using (var context = new Context())
        {
            var dbSetProperties = context.GetType().GetProperties()
                .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

            foreach (var property in dbSetProperties)
            {
                var dbSet = (IEnumerable<object>)property.GetValue(context);

                foreach (var entity in dbSet.ToList())
                {
                    context.Entry(entity).State = EntityState.Deleted;
                }
            }
                        
            context.SaveChanges();
        }

        CrearDatosDeEjemplo();
    }

    private void CrearDatosDeEjemplo()
    {
        using (var db = new Context())
        {
            // Clientes
            if (!db.clsClientesBE.Any())
            {
                db.clsClientesBE.Add(new Models.clsClientesBE()
                {
                    Nombres = "Maria",
                    Apellidos = "Perez",
                    Direccion = "Calle Duarte",
                    Telefono = "809-809-4564"
                });
                db.clsClientesBE.Add(new Models.clsClientesBE()
                {
                    Nombres = "Juan",
                    Apellidos = "Hernandez",
                    Direccion = "Calle Sanchez",
                    Telefono = "809-809-9999"
                });
                db.SaveChanges();
                
            }

            // TipoFacturas
            if (!db.clsTipoFacturasBE.Any())
            {

                List<clsTipoFacturasBE> tipoFacturasList = new List<clsTipoFacturasBE>
            {
                new clsTipoFacturasBE { TipoFactura = "Comprobante estándar" },
                new clsTipoFacturasBE { TipoFactura = "Sin comprobante" }
            };
                db.clsTipoFacturasBE.AddRange(tipoFacturasList);
                db.SaveChanges();
            }

            // Categorias
            if (!db.clsCategoriasBE.Any())
            {
                List<clsCategoriasBE> CategoriasList = new List<clsCategoriasBE>
                {
                    new clsCategoriasBE {Categoria = "Tecnologia"},
                    new clsCategoriasBE {Categoria = "Alimentos"},
                    new clsCategoriasBE {Categoria = "Hogar"},
                };
                db.clsCategoriasBE.AddRange(CategoriasList);
                db.SaveChanges();
                
            }

            // Productos
            if (!db.clsProductosBE.Any())
            {   
                List<clsProductosBE> ProductosList = new List<clsProductosBE>
                {
                    new clsProductosBE { Producto = "Computadora Asus", Cantidad = 10, Costo = 100, Precio = 150, CategoriaId = GetRandomId<clsCategoriasBE>(db, "CategoriaId")},
                    new clsProductosBE { Producto = "Cereal Kellog", Cantidad = 10, Costo = 55, Precio = 110, CategoriaId = GetRandomId<clsCategoriasBE>(db, "CategoriaId")},
                    new clsProductosBE { Producto = "Mueble Rojo", Cantidad = 5, Costo = 300, Precio = 500, CategoriaId = GetRandomId<clsCategoriasBE>(db, "CategoriaId")},
                    new clsProductosBE { Producto = "Mueble Verde", Cantidad = 5, Costo = 300, Precio = 400, CategoriaId = GetRandomId<clsCategoriasBE>(db, "CategoriaId")},
                };

                db.clsProductosBE.AddRange(ProductosList);
                db.SaveChanges();
                
            }
        }
    }

    public static int GetRandomId<TEntity>(DbContext context, string primaryKeyPropertyName = "Id") where TEntity : class
    {
        DbSet<TEntity> dbSet = context.Set<TEntity>();

        var entityIds = dbSet.Select(e => EF.Property<int>(e, primaryKeyPropertyName)).ToList();

        if (entityIds.Any())
        {
            Random random = new Random();
            int randomIndex = random.Next(0, entityIds.Count);

            return entityIds[randomIndex];
        }
        else
        {
            throw new InvalidOperationException($"No {typeof(TEntity).Name} exists.");
        }
    }


    private async void Pruebas_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Test());
    }
}