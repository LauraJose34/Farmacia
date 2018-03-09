using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaBien
{
    public class AccionesArchivo
    {
        public string Archivo { get; set; }
        public AccionesArchivo(string archivo)
        {
            Archivo = archivo;
        }
        public bool GuardarDatos(string elementos)
        {
            try
            {
                StreamWriter row = new StreamWriter(Archivo);
                row.Write(elementos);
                row.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string Leer()
        {
            try
            {
                StreamReader row = new StreamReader(Archivo);
                string elementos = row.ReadToEnd();
                row.Close();
                return elementos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

       
}
