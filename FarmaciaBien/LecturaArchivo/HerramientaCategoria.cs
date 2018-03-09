using FarmaciaBien.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBien.LecturaArchivo
{
    public class HerramientaCategoria
    {
        AccionesArchivo accionesArchivo;
        List<CategoriaFarmacia> categoria;
        public HerramientaCategoria() {
            accionesArchivo = new AccionesArchivo("Categorias.poo");
            categoria = new List<CategoriaFarmacia>();
        }

        public bool Agregar(CategoriaFarmacia inv) {
            categoria.Add(inv);
            bool accion = ActualizarArchivo();
            categoria = Leer();
            return accion;
        }

        private bool ActualizarArchivo()
        {
            string elementos = "";
            foreach (CategoriaFarmacia item in categoria)
            {
                elementos += string.Format("{0}\n", item.Descripcion);
            }
            return accionesArchivo.GuardarDatos(elementos);
        }

        public List<CategoriaFarmacia> Leer()
        {
            string elementos = accionesArchivo.Leer();
            if (elementos != null)
            {
                List<CategoriaFarmacia> inv = new List<CategoriaFarmacia>();
                string[] fila = elementos.Split('\n');
                for (int i = 0; i < fila.Length - 1; i++)
                {
                    string[] espacio = fila[i].Split('|');
                    CategoriaFarmacia a = new CategoriaFarmacia();
                    a.Descripcion = (espacio[0]);

                    inv.Add(a);
                }
                categoria = inv;
                return inv;
            }
            else {
                return null;
            }
        }

        public bool Eliminar(CategoriaFarmacia cat) {
            CategoriaFarmacia categori = new CategoriaFarmacia();
            foreach (var Buscador in categoria) {
                if (Buscador.Descripcion == cat.Descripcion) {
                    categori = Buscador;
                }
            }
            categoria.Remove(categori);
            bool accion = ActualizarArchivo();
            categoria = Leer();
            return accion;
        }

        public bool Modificar(CategoriaFarmacia original, CategoriaFarmacia modificado)
        {
            CategoriaFarmacia t = new CategoriaFarmacia();
            foreach (var buscador in categoria)
            {
                if (original.Descripcion == buscador.Descripcion)
                {
                    t = buscador;
                }
            }
            t.Descripcion = modificado.Descripcion;
            bool resultado = ActualizarArchivo();
            categoria = Leer();
            return resultado;
        }
    }
}
