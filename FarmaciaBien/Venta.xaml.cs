using FarmaciaBien.Clases;
using FarmaciaBien.LecturaArchivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FarmaciaBien
{
    /// <summary>
    /// Lógica de interacción para Venta.xaml
    /// </summary>
    public partial class Venta : Window
    {
        List<VentaVenta> venta;
        HerramientaEmpleados herramientaEmpleados;
        RepositorioDeCliente repositorioDeCliente;
        HerramientaProductos herramientaProductos;
        bool N;
        float iva =0.16f ;
      //  VentaVenta ventaVenta;
        public Venta()
        {
            InitializeComponent();
            CargarFormulario();
            venta = new List<VentaVenta>();
        }

        private void CargarFormulario() {
            CargarCombox();
            CargarFolioFecha();
        }

        private void CargarFolioFecha() {
            txbFecha.Text = DateTime.Now.ToShortDateString();//cargar fecha
            Random random = new Random();//cargar folio
            int num;
            num = random.Next(100000000, 999999999);//DateTime.Now.ToShortTimeString();
            txbFolio.Text = num.ToString(); ;
        }

        private void CargarCombox() {
            herramientaEmpleados = new HerramientaEmpleados();
            repositorioDeCliente = new RepositorioDeCliente();
            herramientaProductos = new HerramientaProductos();
            cmbEmpleado.ItemsSource = herramientaEmpleados.Leer();
            cmbCliente.ItemsSource = repositorioDeCliente.LeerCliente();
            cmbProductos.ItemsSource = herramientaProductos.Leer();
        }

        private void btnRegre_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbProductos.Text))
            {
                MessageBox.Show("No ha colocado que producto!!!", "Productos", MessageBoxButton.YesNo, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text)) {
                MessageBox.Show("No ha colocado la cantidad del producto: " + cmbProductos.Text, "Productos", MessageBoxButton.YesNo, MessageBoxImage.Error);
                return;
            }
            
            if (int.Parse(txtCantidad.Text) <= 0) {
                MessageBox.Show("Cantidad invalida", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                txtCantidad.Clear();
                return;
            }
            if (N == false)
            {
                VentaVenta ventaVenta = new VentaVenta();
                ProductosFarmacia a = cmbProductos.ItemsSource as ProductosFarmacia;
                foreach (var item in herramientaProductos.Leer())
                {
                    if (item.Nombre == cmbProductos.Text)
                    {
                        a = item;
                    }
                }
                /*Aqui comienza lo modificado*/
                if (int.Parse(a.Stock) < int.Parse(txtCantidad.Text)) {
                    MessageBox.Show("No hay suficiente Stock. Almacenamiento: "+ a.Stock+" De: " + txtCantidad.Text, "Venta", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtCantidad.Clear();
                    return;
                }                
                /*Aqui comienza lo modificado*/
                ventaVenta.Producto = a.Nombre;
                ventaVenta.Precio = float.Parse(a.PrecioVenta);
                ventaVenta.Cantidad = int.Parse(txtCantidad.Text);
                ventaVenta.Total = (float.Parse(a.PrecioVenta)) * (int.Parse(txtCantidad.Text));
                venta.Add(ventaVenta);
                ActualizarTabla();      
            }
            else
            {
                VentaVenta a = cmbProductos.ItemsSource as VentaVenta;
                foreach (var item in venta)
                {
                    if (item.Producto == cmbProductos.Text)
                    {
                        a = item;
                    }
                }
                a.Producto = cmbProductos.Text;
                a.Cantidad = int.Parse(txtCantidad.Text);
                a.Precio = (a.Precio);
                a.Total = ((a.Precio)) * (int.Parse(txtCantidad.Text));
                ActualizarTabla();
                txtCantidad.Clear();
            }
        }

        private void ModificarProductos() {
            //aqui va el stock
            /*   HerramientaProductos herramientaProductos = new HerramientaProductos();
               VentaVenta p = dtgProductoVenta.ItemsSource as VentaVenta;
               ProductosFarmacia a = new ProductosFarmacia();
               foreach (var item in herramientaProductos.Leer())
               {
                   if (item.Nombre== p.Producto) {
                       a.Id = item.Id;
                       a.Nombre = p.Producto;
                       a.PrecioCompra = item.PrecioCompra;
                       a.PrecioVenta = item.PrecioVenta;
                       a.Presentacion = item.Presentacion;
                       a.ProductoCategoria = item.ProductoCategoria;
                       a.Stock = (int.Parse(item.Stock) - p.Cantidad).ToString();
                       if (herramientaProductos.Modificar(a, item)) {
                           ActualizarTabla();
                           MessageBox.Show("Producto Actualizado");
                       }
                   }
               }*/
            List<VentaVenta> b = new List<VentaVenta>();
            List<ProductosFarmacia> j = new List<ProductosFarmacia>();


            foreach (var item in b)
            {
                foreach (var item2 in j)
                {
                    if (item.Producto == item2.Nombre) {
                       

                        item2.Id = item2.Id;
                        item2.Nombre = item.Producto;
                        item2.PrecioCompra = item2.PrecioCompra;
                        item2.PrecioVenta = item2.PrecioVenta;
                        item2.Presentacion = item2.Presentacion;
                        item2.ProductoCategoria = item2.ProductoCategoria;
                        item2.Stock = ((int.Parse(item2.Stock)) - item.Cantidad).ToString();
                        if (herramientaProductos.Modificar(item2, item2))
                        {
                            MessageBox.Show("Producto Actualizado");
                        }
                        else {
                            MessageBox.Show("Error");
                        }
                    }
                }
            }
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            float total = 0;
            foreach (VentaVenta item in venta)
            {
                total += item.Total;
            }
            txtSubtotal.Text = (total).ToString();
            txbIva.Text = (total * iva).ToString();
            float operacion = total + (total * iva);
            txtTotal.Text = operacion.ToString();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (venta.Count == 0)
            {
                MessageBox.Show("No cuenta con ningun producto en venta", "Venta", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else {
                if (dtgProductoVenta.SelectedItem != null) {

                    VentaVenta u = dtgProductoVenta.SelectedItem as VentaVenta;
                    if (MessageBox.Show("Esta seguro de eliminar este producto de la venta" ,"Venta", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes) {
                        venta.Remove(u);
                        ActualizarTabla();
                        MessageBox.Show("Producto eliminado", "Producto", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                } else {
                    MessageBox.Show("Seleccione un elemento de la tabla", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ActualizarTabla()
        {
            dtgProductoVenta.ItemsSource = null;
            dtgProductoVenta.ItemsSource = venta;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (venta.Count == 0)
            {
                MessageBox.Show("No cuenta con ningun producto en venta", "Venta", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (dtgProductoVenta.SelectedItem != null)
                {
                    VentaVenta u = dtgProductoVenta.SelectedItem as VentaVenta;
                    cmbProductos.Text = u.Producto;
                    txtCantidad.Text = (u.Cantidad).ToString();
                    N = true;
                }
                else
                {
                    MessageBox.Show("Seleccione un elemento de la tabla", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta realmente seguro de cancelar la venta", "Venta", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes) {// dtgProductoVenta.ItemsSource = null;// VentaVenta ventaVenta = new VentaVenta();//para no agregar la misma venta
                Venta ventas = new Venta();
                ventas.Show();
                this.Close();
            }
        }

        private void btnCambio_Click(object sender, RoutedEventArgs e)
        {
            if (txtPagoEfectivo.Text == "")
            {
                MessageBox.Show("No ha llenado el campo de Pago de efectivo", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (float.Parse(txtPagoEfectivo.Text) <= 0)
                {
                    MessageBox.Show("Pago de efectivo no valido. Debe de ser Mayor a cero", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPagoEfectivo.Clear();
                    return;
                }
                if (float.Parse(txtPagoEfectivo.Text) >= float.Parse(txtTotal.Text))
                {
                    float devolucion = 0;
                    devolucion = float.Parse(txtPagoEfectivo.Text) - float.Parse(txtTotal.Text);
                    txtCambio.Text = devolucion.ToString();
                }
                else
                {
                    MessageBox.Show("Pago de efectivo menor al total de la venta", "Venta", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtPagoEfectivo.Clear();
                }
            }
        }

        private void btnNuevaVenta_Click(object sender, RoutedEventArgs e)
        {
            Venta ventas = new Venta();
            ventas.Show();
            this.Close();
        }

        private void btnReporte_Click(object sender, RoutedEventArgs e)
        {
            if (cmbEmpleado.Text == "")
            {
                MessageBox.Show("No ha seleccionado el nombre del Empleado", "Reporte", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cmbCliente.Text == "")
            {
                MessageBox.Show("No ha seleccionado el nombre del Cliente", "Reporte", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (dtgProductoVenta.ItemsSource ==null) {
                MessageBox.Show("No cuenta con ninguna venta", "Reporte", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtSubtotal.Text == "")
            {
                MessageBox.Show("No ha calculado el total de la venta", "Reporte", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtPagoEfectivo.Text == "")
            {
                MessageBox.Show("No ha colocado la cantidad de Pago", "Reporte", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtCambio.Text == "")
            {
                MessageBox.Show("No ha calculado el cambio", "Reporte", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            AccionesArchivo archivoFactura = new AccionesArchivo(txbFolio.Text + ".poo");
            string datos = "";
            //datos generales
            datos = string.Format("Farmacia 'Mi Querido Enfermito'\nFolio: {0}\n{1}\nEmpleado: {2}\nCliente: {3}\n", txbFecha.Text, txbFolio.Text, cmbEmpleado.Text, cmbCliente.Text);
            //datos de la tabla
            string elementos = "";
            foreach (VentaVenta item in venta)
            {
                elementos += string.Format("{0} ${1} {2} ${3}\n", item.Producto, item.Precio, item.Cantidad, item.Total);
            }
            //datos de cuenta
            string informacion = "";
            informacion = string.Format("Subtotal: ${0}\nIva: ${1}\nTotal: ${2}\nPago Efectivo: ${3}\nCambio: ${4}\nVuelva Pronto\nAv. Vicente Guerrero", txtSubtotal.Text, txbIva.Text, txtTotal.Text, txtPagoEfectivo.Text, txtCambio.Text);
            archivoFactura.GuardarDatos(datos + elementos + informacion);
            MessageBox.Show("Reporte Guardado con Exito: "+ txbFolio.Text+".poo", "Reporte", MessageBoxButton.OK, MessageBoxImage.Information);

            ModificarProductos();

            Venta ventas = new Venta();
            ventas.Show();
            this.Close();

            //aqui va el descuento
            //    ModificarProductos();

            
          //  BuscarProducto();
        }
    }

}
