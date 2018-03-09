using FarmaciaBien.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBien
{
   public class ProductosFarmacia : Inventario
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string PrecioCompra { get; set; }
        public string PrecioVenta { get; set; }
        public string Presentacion { get; set; }
        public string ProductoCategoria { get; set; }
        public override string ToString()
        {
            return Nombre ;
        }

    }
}
