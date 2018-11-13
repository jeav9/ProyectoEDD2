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
    public partial class EliminarT : Form
    {
        public EliminarT()
        {
            InitializeComponent();
        }
        #region variables
        StreamReader reader;
        string[] divisores = { "|", "||" };
        string encabezado;
        #endregion
        private void CargarDatos(string name)
        {
            using (StreamReader sr = new StreamReader(name))
            {
                string text = "";
                for (text = sr.ReadLine(); text != null; text = sr.ReadLine())
                {
                    string[] fila = text.Split(new char[] { '|' });
                    dataGridView1.Rows.Add(fila);
                }
                sr.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] archivo = openFileDialog1.FileName.Split('.');
                label1.Text = archivo[0]+"Header.txt";
                nombre = archivo[0] + ".txt";
                label2.Text = nombre;
                reader = new StreamReader(label1.Text);
                encabezado = reader.ReadLine();
                string[] fila = encabezado.Split(divisores, StringSplitOptions.RemoveEmptyEntries);
                int x = 0;
                for (int i = 1; i < fila.Length; i += 2)
                {
                    dataGridView1.Columns.Add(fila[x], fila[x]);
                    dataGridView1.Columns[fila[x]].Width = 150;
                    ((DataGridViewTextBoxColumn)dataGridView1.Columns[fila[x]]).MaxInputLength = Convert.ToInt32(fila[i]);
                    x = x + 2;
                }
                CargarDatos(nombre);
            }
            string Slinea = reader.ReadLine();
            if (Slinea == "*")
            {
                reader.Close();
                return;
            }
            else
            {
                listaDllenado();
            }
            reader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string valor = textBox1.Text;
            int rowIndex = -1;
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(valor))
                {
                            rowIndex = row.Index;
                            DataGridViewRow eliminar = dataGridView1.Rows[rowIndex];
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                eliminar.Cells[i].Value = "";
                            }
                            dataGridView2.Rows.Add(rowIndex.ToString());
                            break;
                }
            }
            textBox1.Text = "";
        }

        void listaD()
        {
            //Actualizando el archivo con la lista de disponibles actual
            string[] arrLine = File.ReadAllLines(label1.Text);
            List<int> lista = new List<int>();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                lista.Add(int.Parse(row.Cells[0].Value.ToString()));
            }

            int[] array = lista.ToArray();
            arrLine[1] = "";
            for(int i = 0; i < array.Length; i++)
            {
                arrLine[1] += array[i].ToString() + "|";
            }
            File.WriteAllLines(label1.Text, arrLine);
        }

        void listaDllenado()
        {
            string[] divisor = { "|" };
            StreamReader writer = new StreamReader(label1.Text);
            string linea = writer.ReadLine();
            string linea2 = writer.ReadLine();
            string[] fila = linea2.Split(divisor, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < fila.Length; i++)
            {
                dataGridView2.Rows.Add(fila[i]);
            }
            writer.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextWriter texto = new StreamWriter(label2.Text);
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    texto.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "|");
                }
                texto.WriteLine("");
            }
            texto.Close();
            listaD();
            MessageBox.Show("La lista de disponibles se ha actualizado exitosamente en su respectivo archivo");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
