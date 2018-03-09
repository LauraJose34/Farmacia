using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBien.LecturaArchivo //Amigo
{
    public class RepositorioDeCliente
    {
        AccionesArchivo archivoCliente;
        List<ClientesFarmacia> Clintes;
        public RepositorioDeCliente()
        {
            archivoCliente = new AccionesArchivo("Clientes2.poo");
            Clintes = new List<ClientesFarmacia>();
        }

        public bool AgregarCliente(ClientesFarmacia client)
        {
            Clintes.Add(client);
            bool resultado = ActualizarArchivo();
            Clintes = LeerCliente();
            return resultado;
        }

        public bool EliminarCliente(ClientesFarmacia client)
        {
            ClientesFarmacia temporal = new ClientesFarmacia();
            foreach (var item in Clintes)
            {
                if (item.Telefono == client.Telefono)
                {
                    temporal = item;
                }
            }
            Clintes.Remove(temporal);
            bool resultado = ActualizarArchivo();
            Clintes = LeerCliente();
            return resultado;
        }

        public bool ModificarCliente(ClientesFarmacia o, ClientesFarmacia m)
        {
            ClientesFarmacia temporal = new ClientesFarmacia();
            foreach (var item in Clintes)
            {
                if (o.Telefono == item.Telefono)
                {
                    temporal = item;
                }
            }
            temporal.Nombre = m.Nombre;
            temporal.Apellido = m.Apellido;
            temporal.Direccion = m.Direccion;
            temporal.Telefono = m.Telefono;
            temporal.Correo = m.Correo;
            temporal.ERF = m.ERF;
            bool resultado = ActualizarArchivo();
            Clintes = LeerCliente();
            return resultado;
        }

        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (ClientesFarmacia item in Clintes)
            {
                datos += string.Format("{0}|{1}|{2}|{3}|{4}|{5}\n", item.Nombre, item.Apellido, item.Direccion, item.Telefono, item.Correo, item.ERF);
            }
            return archivoCliente.GuardarDatos(datos);
        }
        public List<ClientesFarmacia> LeerCliente()
        {
            string datos = archivoCliente.Leer();
            if (datos != null)
            {
                List<ClientesFarmacia> clientes = new List<ClientesFarmacia>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    ClientesFarmacia a = new ClientesFarmacia()
                    {
                        Nombre = campos[0],
                        Apellido = campos[1],
                        Direccion = campos[2],
                        Telefono = campos[3],
                        Correo = campos[4],
                         ERF= campos[5]
                    };
                    clientes.Add(a);
                }
                Clintes = clientes;
                return clientes;
            }
            else
            {
                return null;
            }
        }
    }
}
