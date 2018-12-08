using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEDD2.Clases
{
    class MainArchivo : ICrearArchivo
    {
        private string nombre { get; set; }
        public MainArchivo(string nombre)
        {
            this.nombre = nombre;
        }
        public void CrearArchivo()
        {
            StreamWriter datos = new StreamWriter(nombre+".txt");
            datos.Close();
        }
    }
}
