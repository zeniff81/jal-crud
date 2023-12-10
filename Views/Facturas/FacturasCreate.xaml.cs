using jal_crud.Data;
using jal_crud.Models;
using jal_crud.ViewModels;

namespace jal_crud.Views.Facturas;

public partial class FacturasCreate : ContentPage
{
    public FacturasCreate()
    {
        InitializeComponent();
        BindingContext = new FacturasViewModel();
        CargarProductos();
        CargarClientes();
        CargarTipoFacturas();
    }

    private void CargarTipoFacturas()
    {
        using (Context db = new Context())
        {
            var tipoFacturas = db.clsTipoFacturasBE.ToList();
            TipoFacturasListView.ItemsSource = tipoFacturas;
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Subtotal_Entry.Text = "";
        Descuento_Entry.Text = "";
        Monto_Entry.Text = "";
        Cliente_Label.Text = "";
        TipoFacturaId_Entry.Text = "";
    }

    #region Botones Ocultar
    private void MostrarOcultarSecciones(bool mostrarFactura, bool mostrarDetalles, bool mostrarProductos, bool mostrarClientes, bool mostrarTipoFactura, bool mostrarBotonesNavegacion)
    {
        Seccion_Botones_Navegacion.IsVisible = mostrarBotonesNavegacion;
        Seccion_Factura.IsVisible = mostrarFactura;
        Seccion_Detalles.IsVisible = mostrarDetalles;
        Seccion_Productos.IsVisible = mostrarProductos;
        Seccion_Cliente.IsVisible = mostrarClientes;
        Seccion_TipoFactura.IsVisible = mostrarTipoFactura;
    }

    private void MostrarFacturas()
    {
        MostrarOcultarSecciones(true, true, false, false, false, true);
    }

    private void Mostrar_Seccion_Productos(object sender, EventArgs e)
    {
        MostrarOcultarSecciones(false, false, true, false, false, false);        
    }

    private void Ocultar_Seccion_Producto(object sender, EventArgs e)
    {
        MostrarFacturas();
    }

    private void Mostrar_Seccion_Clientes(object sender, EventArgs e)
    {
        MostrarOcultarSecciones(false, false, false, true, false, false);
    }
    #endregion
    private void CargarProductos()
    {
        using (Context db = new Context())
        {
            var productos = db.clsProductosBE.ToList();
            ProductosListView.ItemsSource = productos;
        }
    }
    
    private void CargarClientes()
    {
        using (Context db = new Context())
        {
            var clientes = db.clsClientesBE.ToList();
            ClientesListView.ItemsSource = clientes;
        }
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

    private void Clientes_Lista_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is clsClientesBE selectedCliente)
        {
            // Use the properties of selectedCliente
            int clienteId = selectedCliente.ClienteId;
            string nombres = selectedCliente.Nombres;
            string apellidos = selectedCliente.Apellidos;
            string nombreCompleto = $"{nombres} {apellidos}";

            ClienteId_label.Text = clienteId.ToString();
            Cliente_Label.Text = nombreCompleto;
        }

    ((ListView)sender).SelectedItem = null;

    }

    private void Ocultar_Clientes_Button_Clicked(object sender, EventArgs e)
    {
        MostrarFacturas();
    }

    private void Mostrar_Seccion_TipoFactura(object sender, EventArgs e)
    {
        MostrarOcultarSecciones(false, false, false, false, true, false);   
    }

    private void Ocultar_Seccion_TipoFactura(object sender, EventArgs e)
    {
        MostrarFacturas();
    }

    private void Tipo_Factura_ItemTapped(object sender, ItemTappedEventArgs e)
    {

    }
}