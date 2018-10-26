using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEDD2.Formularios
{
    public partial class AgregarInfo : Form
    {
        public AgregarInfo()
        {
            InitializeComponent();
        }
        #region variables
        StreamReader reader;
        string[] divisores = { "|", "||" };
        string encabezado;
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = openFileDialog1.FileName;
                reader = new StreamReader(openFileDialog1.FileName);
                encabezado = reader.ReadLine();
                string[] fila = encabezado.Split(divisores, StringSplitOptions.RemoveEmptyEntries);
                int x = 0;
                for (int i = 1; i < fila.Length; i += 2)
                {
                    dataGridView1.Columns.Add(fila[x],fila[x]);
                    dataGridView1.Columns[fila[x]].Width = 150;
                    ((DataGridViewTextBoxColumn)dataGridView1.Columns[fila[x]]).MaxInputLength = Convert.ToInt32(fila[i]);
                    x = x + 2;
                }

            }

        }


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
