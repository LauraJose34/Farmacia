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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnVenta_Click(object sender, RoutedEventArgs e)
        {
            Venta venta = new Venta();
            venta.Show();
            this.Close();
        }

        private void btnEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Empleado Empleado = new Empleado();
            Empleado.Show();
            this.Close();
        }

        private void btnCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Show();
            this.Close();
        }

        private void btnProductos_Click(object sender, RoutedEventArgs e)
        {
            Productos productos = new Productos();
            productos.Show();
            this.Close();
        }

        private void btnCategoria_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoria = new Categoria();
            categoria.Show();
            this.Close();
        }

        private void btnVenta_Click_1(object sender, RoutedEventArgs e)
        {
            Venta venta = new Venta();
            venta.Show();
            this.Close();
        }
    }
}
