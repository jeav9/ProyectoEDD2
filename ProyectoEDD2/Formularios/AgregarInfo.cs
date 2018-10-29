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
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
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
                    //Grid 2
                    dataGridView2.Columns.Add(fila[x], fila[x]);
                    dataGridView2.Columns[fila[x]].Width = 150;
                    ((DataGridViewTextBoxColumn)dataGridView2.Columns[fila[x]]).MaxInputLength = Convert.ToInt32(fila[i]);
                    x = x + 2;
                }
            }
            reader.Close();
            lectura();
        }

        private void lectura()
        {
            int cont = 0;
            using (StreamReader sr = new StreamReader(label1.Text))
            {
                string line=String.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    string text = "";
                    for (text = sr.ReadLine(); text != null; text = sr.ReadLine())
                    {
                        string[] fila = text.Split(new char[] { '|' });
                        dataGridView2.Rows.Add(fila);
                        cont++;
                    }
                }
                sr.Close();
                MessageBox.Show("Cantidad de registros: "+cont);
            }
            

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var stream = File.Open(label1.Text, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            using (var readers = new StreamReader(stream))
            using (var writer = new StreamWriter(stream))
            {
                long posicion = stream.Length == 0 ? 0 : -1;
                stream.Seek(posicion, SeekOrigin.End);
                string final = readers.ReadToEnd();
                if (final.Length != 0 && !final.Equals("\n", StringComparison.Ordinal))
                {
                    writer.Write(Environment.NewLine);
                }

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "|");
                    }
                }
            }
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            lectura();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}