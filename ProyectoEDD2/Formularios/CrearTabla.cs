using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProyectoEDD2.Formularios
{
    public partial class CrearTabla : Form
    {
        public CrearTabla()
        {
            InitializeComponent();
        }

        private void CrearTabla_Load(object sender, EventArgs e)
        {

        }
        void limpiar()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            comboBox1.Text = string.Empty;        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string[] fila = { textBox1.Text, comboBox1.SelectedItem.ToString(), textBox2.Text };
            this.dataGridView1.Rows.Add(fila);
            limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text != string.Empty)
            {
                saveFileDialog1.FileName = txtNombre.Text;
                saveFileDialog1.Filter = "Archivos txt (*.txt)|*.txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        sw.WriteLine(dataGridView1.Rows[i].Cells[0].Value.ToString()+"\t"+ dataGridView1.Rows[i].Cells[1].Value.ToString()+"\t"+ dataGridView1.Rows[i].Cells[2].Value.ToString()+"\n");
                    }
                    sw.Close();
                }
            }
            else
            {
                MessageBox.Show("Falta el nombre del archivo.");
            }

        }
    }
}
