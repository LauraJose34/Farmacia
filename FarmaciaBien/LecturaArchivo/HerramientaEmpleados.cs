using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBien.LecturaArchivo
{
   public class HerramientaEmpleados
    {
        AccionesArchivo accionesArchivo;
        List<EmpleadoFarmacia> Empleados;
        public HerramientaEmpleados()
        {
            accionesArchivo = new AccionesArchivo("Empleados.poo");
            Empleados = new List<EmpleadoFarmacia>();
        }

        public bool Agregar(EmpleadoFarmacia emple)
        {
            Empleados.Add(emple);
            bool resultado = ActualizarArchivo();
            Empleados = Leer();
            return resultado;
        }

        public bool Eliminar(EmpleadoFarmacia emple)
        {
            EmpleadoFarmacia tiempo = new EmpleadoFarmacia();
            foreach (var Buscador in Empleados)
            {
                if (Buscador.Telefono == emple.Telefono)
                {
                    tiempo = Buscador;
                }
            }
            Empleados.Remove(tiempo);
            bool resultado = ActualizarArchivo();
            Empleados = Leer();
            return resultado;
        }

        public bool Modificar(EmpleadoFarmacia original, EmpleadoFarmacia modificado)
        {
            EmpleadoFarmacia t = new EmpleadoFarmacia();
            foreach (var buscador in Empleados)
            {
                if (original.Telefono == buscador.Telefono)
                {
                    t = buscador;
                }
            }
            t.Apellido = modificado.Apellido;
            t.Correo = modificado.Correo;
            t.Direccion = modificado.Direccion;
            t.Horario = modificado.Horario;
            t.Nombre = modificado.Nombre;
            t.Sueldo = modificado.Sueldo;
            t.Telefono = modificado.Telefono;
            bool resultado = ActualizarArchivo();
            Empleados = Leer();
            return resultado;
        }

        private bool ActualizarArchivo()
        {
            string elemntos = "";
            foreach (EmpleadoFarmacia item in Empleados)
            {
                elemntos += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}\n", item.Nombre, item.Apellido, item.Direccion,  item.Telefono, item.Correo, item.Sueldo, item.Horario);
            }
            return accionesArchivo.GuardarDatos(elemntos);
        }
        public List<EmpleadoFarmacia> Leer()
        {
            string elementos = accionesArchivo.Leer();
            if (elementos != null)
            {
                List<EmpleadoFarmacia> emp = new List<EmpleadoFarmacia>();
                string[] fila = elementos.Split('\n');
                for (int i = 0; i < fila.Length - 1; i++)
                {
                    string[] espacio = fila[i].Split('|');
                    EmpleadoFarmacia a = new EmpleadoFarmacia();
                    a.Nombre = espacio[0];
                    a.Apellido = espacio[1];
                    a.Direccion = espacio[2];
                    a.Telefono = espacio[3];
                    a.Correo = espacio[4];
                    a.Sueldo = espacio[5];
                    a.Horario = espacio[6];                    
                    emp.Add(a);
                }
                Empleados = emp;
                return emp;
            }
            else
            {
                return null;
            }
        }
    }
}
