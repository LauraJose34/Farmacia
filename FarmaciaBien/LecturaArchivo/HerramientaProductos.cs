using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBien.LecturaArchivo
{
   public class HerramientaProductos
    {
        AccionesArchivo accionesArchivo;
        List<ProductosFarmacia> Productos;
        public HerramientaProductos()
        {
            accionesArchivo = new AccionesArchivo("Productos.poo");
            Productos = new List<ProductosFarmacia>();
        }

        public bool Agregar(ProductosFarmacia pro)
        {
            Productos.Add(pro);
            bool resultado = ActualizarArchivo();
            Productos = Leer();
            return resultado;
        }

        public bool Eliminar(ProductosFarmacia pro)
        {
            ProductosFarmacia temporal = new ProductosFarmacia();
            foreach (var Buscador in Productos)
            {
                if (Buscador.Id == pro.Id)
                {
                    temporal = Buscador;
                }
            }
            Productos.Remove(temporal);
            bool resultado = ActualizarArchivo();
            Productos = Leer();
            return resultado;
        }

        public bool Modificar(ProductosFarmacia original, ProductosFarmacia modificado)
        {
            ProductosFarmacia t = new ProductosFarmacia();
            foreach (var buscador in Productos)
            {
                if (original.Id == buscador.Id)
                {
                    t = buscador;
                }
            }
            t.Id = modificado.Id;
            t.Nombre = modificado.Nombre;
            t.PrecioCompra = modificado.PrecioCompra;
            t.PrecioVenta = modificado.PrecioVenta;
            t.Presentacion = modificado.Presentacion;
            t.Descripcion = modificado.Descripcion;
            t.ProductoCategoria = modificado.ProductoCategoria;
            t.Stock = modificado.Stock;
            bool resultado = ActualizarArchivo();
            Productos = Leer();
            return resultado;
        }

        private bool ActualizarArchivo()
        {
            string elemntos = "";
            foreach (ProductosFarmacia item in Productos)
            {
                elemntos += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}\n", item.Id, item.Nombre,  item.Descripcion, item.PrecioCompra, item.PrecioVenta, item.Presentacion, item.ProductoCategoria, item.Stock);
            }
            return accionesArchivo.GuardarDatos(elemntos);
        }
        public List<ProductosFarmacia> Leer()
        {
            string elementos = accionesArchivo.Leer();
            if (elementos != null)
            {
                List<ProductosFarmacia> prod = new List<ProductosFarmacia>();
                string[] fila = elementos.Split('\n');
                for (int i = 0; i < fila.Length - 1; i++)
                {
                    string[] espacio = fila[i].Split('|');
                    ProductosFarmacia a = new ProductosFarmacia()
                    {
                        Id = espacio[0],
                        Nombre = espacio[1],
                        Descripcion = espacio[2],
                        PrecioCompra = espacio[3],
                        PrecioVenta = espacio[4],
                        Presentacion = espacio[5],
                        ProductoCategoria = espacio[6],
                        Stock = espacio[7]
                    };
                    prod.Add(a);
                }
                Productos = prod;
                return prod;
            }
            else
            {
                return null;
            }
        }

    }
}
