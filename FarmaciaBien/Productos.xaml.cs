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
    /// Lógica de interacción para Productos.xaml
    /// </summary>
    public partial class Productos : Window
    {
        HerramientaProductos herramientas;
        HerramientaCategoria herramientaCategoria;
        bool N;
        public Productos()
        {
            InitializeComponent();
            herramientas = new HerramientaProductos();
            ActualizarTabla();
            CargarCombox();
            habilitarBotones(true);
            habilitado(false);
        }

        private void CargarCombox()
        {
            herramientaCategoria = new HerramientaCategoria();
            cmbCategoria.ItemsSource = herramientaCategoria.Leer();
           
        }

        private void ActualizarTabla()
        {
            dtgProductos.ItemsSource = null;
            dtgProductos.ItemsSource = herramientas.Leer();
        }
        
        private void habilitarBotones(bool habilitar)
        {
            btnCancelar.IsEnabled = !habilitar;
            btnEditar.IsEnabled = habilitar;
            btnEliminar.IsEnabled = habilitar;
            btnGuardar.IsEnabled = !habilitar;
            btnNuevo.IsEnabled = habilitar;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            habilitado(true);
            HabilitarBotones(false);
            N = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombre.Text))
            {
                MessageBox.Show("Faltan agregar el Nombre del Producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbPrecioCompra.Text))
            {
                MessageBox.Show("Faltan agregar el Precio de Compra del producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbPrecioVenta.Text))
            {
                MessageBox.Show("Faltan agregar el Precio de la venta", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbPresentacion.Text))
            {
                MessageBox.Show("Faltan agregar la presentación del producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbDescricpion.Text))
            {
                MessageBox.Show("Faltan agregar la descripción del producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (N)
            {
                ProductosFarmacia a = new ProductosFarmacia()
                {
                    Descripcion = txbDescricpion.Text,
                    Id = txbId.Text,
                    PrecioCompra= txbPrecioCompra.Text,
                    PrecioVenta= txbPrecioVenta.Text,
                    Presentacion= txbPresentacion.Text,
                    Nombre = txbNombre.Text,
                    ProductoCategoria= cmbCategoria.Text,
                    Stock=txtCantidad.Text,
                };
                if (herramientas.Agregar(a))
                {
                    MessageBox.Show("Guardado con Éxito", "Productos", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    habilitado(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar Productos", "Productos", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                ProductosFarmacia o = dtgProductos.SelectedItem as ProductosFarmacia;
                ProductosFarmacia a = new ProductosFarmacia();
                a.Nombre = txbNombre.Text;
                a.Descripcion = txbDescricpion.Text;
                a.Id = txbId.Text;
                a.PrecioCompra = txbPrecioCompra.Text;
                a.PrecioVenta = txbPrecioVenta.Text;
                a.Presentacion = txbPresentacion.Text;
                a.ProductoCategoria = cmbCategoria.Text;
                a.Stock = txtCantidad.Text;
                if (herramientas.Modificar(o, a))
                {
                    HabilitarBotones(true);
                    habilitado(false);
                    ActualizarTabla();
                    MessageBox.Show("Producto Actualizado", "Producto", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar al Producto", "Producto", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (herramientas.Leer().Count == 0)
            {
                MessageBox.Show("No cuenta con ningun Producto", "Producto", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgProductos.SelectedItem != null)
                {
                    ProductosFarmacia pro = dtgProductos.SelectedItem as ProductosFarmacia;
                    habilitado(true);
                    txbPresentacion.Text = pro.Presentacion;
                    txbPrecioVenta.Text = pro.PrecioVenta;
                    txbPrecioCompra.Text = pro.PrecioCompra;
                    txbNombre.Text = pro.Nombre;
                    txbId.Text = pro.Id;
                    cmbCategoria.Text = pro.ProductoCategoria;
                    txbDescricpion.Text = pro.Descripcion;
                    txtCantidad.Text = pro.Stock;
                    HabilitarBotones(false);
                    N = false;
                }
                else
                {
                    MessageBox.Show("No ha seleccionado a ningun Producto", "Producto", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void HabilitarBotones(bool v)
        {
            btnCancelar.IsEnabled = !v;
            btnEditar.IsEnabled = v;
            btnGuardar.IsEnabled = !v;
            btnNuevo.IsEnabled = v;
            btnEliminar.IsEnabled = v;
        }

        private void habilitado(bool habilitado)
        {
         ;
            txbNombre.Clear();
            txbNombre.IsEnabled = habilitado;
            txbDescricpion.Clear();
            txbDescricpion.IsEnabled = habilitado;
            txbId.Clear();
            txbId.IsEnabled = habilitado;
            txbPrecioCompra.Clear();
            txbPrecioCompra.IsEnabled = habilitado;
            txbPrecioVenta.Clear();
            txbPrecioVenta.IsEnabled = habilitado;
            txbPresentacion.Clear();
            txbPresentacion.IsEnabled = habilitado;
            cmbCategoria.IsEnabled = habilitado;
            txtCantidad.Clear();
            txtCantidad.IsEnabled = habilitado;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (herramientas.Leer().Count == 0)
            {
                MessageBox.Show("No cuenta con ningun registro", "Producto", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgProductos.SelectedItem != null)
                {
                    ProductosFarmacia a = dtgProductos.SelectedItem as ProductosFarmacia;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.Nombre + "?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (herramientas.Eliminar(a))
                        {
                            MessageBox.Show("Producto eliminado", "Producto", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Producto No eliminado", "Producto", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No ha seleccionado ningun Producto", "Producto", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta Seguro de cancelar la operación", "Producto", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                habilitado(false);
                HabilitarBotones(true);
            }
        }

        private void btnNuevaCategoria_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoria = new Categoria();
            categoria.Show();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

       
    }
}
