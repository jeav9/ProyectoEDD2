using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEDD2.Clases
{
    class ArchivoHeader : ICrearArchivo
    {
        private string nombre;
        private DataGridView data;

        public ArchivoHeader(string nombre, DataGridView data)
        {
            this.nombre = nombre;
            this.data = data;
        }
        public void CrearArchivo()
        {
            StreamWriter file = new StreamWriter(nombre + "Header.txt");
            for (int i = 0; i < data.RowCount; i++)
            {
                file.Write(data.Rows[i].Cells[0].Value.ToString() + "|" + data.Rows[i].Cells[1].Value.ToString() + "||");
            }
            file.Write(Environment.NewLine);
            file.Write("*");
            file.Close();
        }
    }
}
