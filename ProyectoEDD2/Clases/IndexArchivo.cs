using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEDD2.Clases
{
    class IndexArchivo : ICrearArchivo
    {
        private string nombre { get; set; }
        public IndexArchivo(string nombre)
        {
            this.nombre = nombre;
        }
        public void CrearArchivo()
        {
            StreamWriter datos = new StreamWriter(nombre + "Index.txt");
            datos.Close();
        }
    }
}
