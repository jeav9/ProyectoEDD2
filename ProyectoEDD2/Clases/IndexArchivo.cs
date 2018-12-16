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
        private string TipoArbol { get; set; }
        public IndexArchivo(string nombre,string TipoArbol)
        {
            this.nombre = nombre;
            this.TipoArbol = TipoArbol;
        }

        private string TArbol()
        {
            if(TipoArbol == "Arboles AVL")
            {
                return "AVL";
            }
            else if(TipoArbol == "Arboles B")
            {
                return "B";
            }
            else if(TipoArbol == "Arboles B+")
            {
                return "B+";
            }
            return "";
        }
        public void CrearArchivo()
        {
            StreamWriter datos = new StreamWriter(nombre + "Index.txt");
            datos.WriteLine(TArbol());

            datos.Close();
        }
    }
}
