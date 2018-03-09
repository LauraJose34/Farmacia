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
    /// Lógica de interacción para Empleado.xaml
    /// </summary>
    public partial class Empleado : Window
    {
        HerramientaEmpleados herramientaEmpleados;
        bool N;
        public Empleado()
        {
            InitializeComponent();
            herramientaEmpleados = new HerramientaEmpleados();
            ActualizarTabla();
            habilitado(false);
            HabilitarBotones(true);

        }

        private void ActualizarTabla()
        {
            dtgEmpleado.ItemsSource = null;
            dtgEmpleado.ItemsSource = herramientaEmpleados.Leer();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            habilitado(true);
            HabilitarBotones(false);
            N = true;
        }

        private void HabilitarBotones(bool v)
        {
            btnCancelar.IsEnabled = !v;
            btnEditar.IsEnabled = v;
            btnGuardar.IsEnabled = !v;
            btnNuevo.IsEnabled = v;
            btnEliminar.IsEnabled = v;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombre.Text))
            {
                MessageBox.Show("Falta el nombre del Empleado!!", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbCorreo.Text))
            {
                MessageBox.Show("Falta el correo del Empleado!!", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbDireccion.Text))
            {
                MessageBox.Show("Falta la dirección del Empleado!!", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbHorario.Text))
            {
                MessageBox.Show("Falta el horario del Empleado!!", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbSueldo.Text))
            {
                MessageBox.Show("Falta el sueldo del Empleado!!", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbTelefono.Text))
            {
                MessageBox.Show("Falta el telefono del Empleado!!", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (N)
            {
                EmpleadoFarmacia a = new EmpleadoFarmacia()
                {
                    Apellido= txbApellido.Text,
                    Nombre = txbNombre.Text,
                    Telefono = txbTelefono.Text,
                    Correo= txbCorreo.Text,
                    Direccion= txbDireccion.Text,
                    Horario= txbHorario.Text,
                    Sueldo= txbSueldo.Text
                };
                if (herramientaEmpleados.Agregar(a))
                {
                    MessageBox.Show("Dato guardado sadisfactoriamnete", "Empleados", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    habilitado(false);
                }
                else
                {
                    MessageBox.Show("No se guardo correctamente el empleado", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                EmpleadoFarmacia original = dtgEmpleado.SelectedItem as EmpleadoFarmacia;
                EmpleadoFarmacia a = new EmpleadoFarmacia();
                a.Apellido = txbApellido.Text;
                a.Correo = txbCorreo.Text;
                a.Direccion = txbDireccion.Text;
                a.Nombre = txbNombre.Text;
                a.Sueldo = txbSueldo.Text;
                a.Telefono = txbTelefono.Text;
               // a.Sueldo = txbSueldo.Text;
                a.Horario = txbHorario.Text;
                if (herramientaEmpleados.Modificar(original, a))
                {
                    HabilitarBotones(true);
                    habilitado(false);
                    ActualizarTabla();
                    MessageBox.Show("Empleado editado correctamente", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("No se edito correctamnete el empleado", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }




        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if(herramientaEmpleados.Leer().Count == 0)
            {
                MessageBox.Show("No cuenta con ningun empleado", "Empleados", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgEmpleado.SelectedItem != null)
                {
                    EmpleadoFarmacia a = dtgEmpleado.SelectedItem as EmpleadoFarmacia;
                    habilitado(true);
                    txbApellido.Text = a.Apellido;
                    txbCorreo.Text = a.Correo;
                    txbDireccion.Text = a.Direccion;
                    txbHorario.Text = a.Horario;
                    txbNombre.Text = a.Nombre;
                    txbTelefono.Text = a.Telefono;
                    txbSueldo.Text = a.Sueldo;
                    HabilitarBotones(false);
                    N = false;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar en la tabla a quien desea editar", "Empleados", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

            if (herramientaEmpleados.Leer().Count == 0)
            {
                MessageBox.Show("No cuenta con ningun empleado", "Empleados", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgEmpleado.SelectedItem != null)
                {
                    EmpleadoFarmacia a = dtgEmpleado.SelectedItem as EmpleadoFarmacia;
                    if (MessageBox.Show("Esta seguro de dar de baja a " + a.Nombre , "Empleado", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (herramientaEmpleados.Eliminar(a))
                        {
                            MessageBox.Show("Empleado dado de baja", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido eliminar tu empleado", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar a un empleado de la tabla", "Empleado", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea cancelar la operación?", "Empleados", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                habilitado(false);
                HabilitarBotones(true);
            }
        }

        private void habilitado(bool habilitado)
        {
            txbTelefono.Clear();
            txbSueldo.Clear();
            txbNombre.Clear();
            txbHorario.Clear();
            txbDireccion.Clear();
            txbCorreo.Clear();
            txbApellido.Clear();
            txbTelefono.IsEnabled = habilitado;
            txbSueldo.IsEnabled = habilitado;
            txbNombre.IsEnabled = habilitado;
            txbHorario.IsEnabled = habilitado;
            txbDireccion.IsEnabled = habilitado;
            txbCorreo.IsEnabled = habilitado;
            txbApellido.IsEnabled = habilitado;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
        
    }
}
