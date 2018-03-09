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
using FarmaciaBien.LecturaArchivo;

namespace FarmaciaBien
{
    /// <summary>
    /// Lógica de interacción para Cliente.xaml
    /// </summary>
    public partial class Cliente : Window
    {
        RepositorioDeCliente repositorio;
        bool esNuevo;
        public Cliente()
        {
            InitializeComponent();
            repositorio = new RepositorioDeCliente();
           inabilitado(false);
           HabilitarBotones(true);
            ActualizarTabla();
        }
        private void inabilitado(bool habilitado)
        {
            txbTelefono.Clear();
            txbRFC.Clear();
            txbDireccion.Clear();
            txbNombre.Clear();
            txbCorreo.Clear();
            txbApellido.Clear();
            txbTelefono.IsEnabled = habilitado;
            txbRFC.IsEnabled = habilitado;
            txbNombre.IsEnabled = habilitado;
            txbDireccion.IsEnabled = habilitado;
            txbCorreo.IsEnabled = habilitado;
            txbApellido.IsEnabled = habilitado;
        }


        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            inabilitado(true);
            HabilitarBotones(false);
            esNuevo = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombre.Text) || string.IsNullOrEmpty(txbDireccion.Text) || string.IsNullOrEmpty(txbTelefono.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                ClientesFarmacia a = new ClientesFarmacia()
                {
                    Apellido = txbApellido.Text,
                    Correo = txbCorreo.Text,
                    Direccion = txbDireccion.Text,
                    ERF = txbRFC.Text,
                    Nombre = txbNombre.Text,
                    Telefono = txbTelefono.Text
                };
                if (repositorio.AgregarCliente(a))
                {
                    MessageBox.Show("Guardado con Éxito", "Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    inabilitado(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar Cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                ClientesFarmacia original = dtgCliente.SelectedItem as ClientesFarmacia;
                ClientesFarmacia a = new ClientesFarmacia();
                a.Apellido = txbApellido.Text;
                a.Correo = txbCorreo.Text;
                a.Direccion = txbDireccion.Text;
                a.ERF = txbRFC.Text;
                a.Nombre = txbNombre.Text;
                a.Telefono = txbTelefono.Text;
                if (repositorio.ModificarCliente(original, a))
                {
                    HabilitarBotones(true);
                    inabilitado(false);
                    ActualizarTabla();
                    MessageBox.Show("Cliente Actualizado", "Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar a cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerCliente().Count==0)
            {
                MessageBox.Show("No tiene ningun cliente a editar", "Cliente", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgCliente.SelectedItem != null)
                {
                    ClientesFarmacia clientes = dtgCliente.SelectedItem as ClientesFarmacia;
                    inabilitado(true);
                    txbApellido.Text = clientes.Apellido;
                    txbCorreo.Text = clientes.Correo;
                    txbDireccion.Text = clientes.Direccion;
                    txbNombre.Text = clientes.Nombre;
                    txbTelefono.Text = clientes.Telefono;
                    txbRFC.Text = clientes.ERF;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("No ha seleccionado a ningun cliente", "Cliente", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ActualizarTabla()
        {
            dtgCliente.ItemsSource = null;
            dtgCliente.ItemsSource = repositorio.LeerCliente();

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {


            if (repositorio.LeerCliente().Count == 0)
            {
                MessageBox.Show("No cuenta con ningun Cliente", "Cliente", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgCliente.SelectedItem != null)
                {
                    ClientesFarmacia a = dtgCliente.SelectedItem as ClientesFarmacia;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.Nombre + "?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.EliminarCliente(a))
                        {
                            MessageBox.Show("Cliente eliminado", "Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Cliente No eliminado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Cliente", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta Seguro de cancelar la operación", "???", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                inabilitado(false);
                HabilitarBotones(true);
            }
        }

        private void HabilitarBotones(bool habilitados)
        {
            btnCancelar.IsEnabled = !habilitados;
            btnEditar.IsEnabled = habilitados;
            btnGuardar.IsEnabled = !habilitados;
            btnNuevo.IsEnabled = habilitados;
            btnEliminar.IsEnabled = habilitados;

        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }


    }
}
