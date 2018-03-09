using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBien
{
    public class EmpleadoFarmacia: PersonaFarmacia
    {
        public string Sueldo { get; set; }
        public string Horario { get; set; }
        public override string ToString()
        {
            return Nombre + ' '+ Apellido ;
        }
    }
}
