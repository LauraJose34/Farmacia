using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBien
{
   public  class ClientesFarmacia : PersonaFarmacia
    {
        public string ERF { get; set; }
        public override string ToString()
        {
            return Nombre + ' '+ Apellido;
        }
    }
}
