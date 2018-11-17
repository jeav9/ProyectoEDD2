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
         }
        void leer()
        {
            string[] separador = { "|","||" };
            openFileDialog1.FileName = string.Empty;
            openFileDialog1.Filter = "txt file (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtNombre.Text = openFileDialog1.FileName;
                StreamReader reader = new StreamReader(openFileDialog1.FileName);
                string encabezado = reader.ReadLine();
                string[] columnas = encabezado.Split(separador, StringSplitOptions.RemoveEmptyEntries);
                string[] fila=new string[2];
                int x = 0;
                for (int i = 1; i <columnas.Length; i+= 2)
                {
                    fila[0] = columnas[x];
                    fila[1] = columnas[i];
                    this.dataGridView1.Rows.Add(fila);
                    x=x+2;
                }
                reader.Close();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show("No puede dejar campos vacios", "Archivos de texto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string[] fila = { textBox1.Text, textBox2.Text };
                this.dataGridView1.Rows.Add(fila);
                limpiar();
            }
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
                    string[] ruta = saveFileDialog1.FileName.Split('.');
                    StreamWriter sw = new StreamWriter(ruta[0]+"Header.txt");
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        sw.Write(dataGridView1.Rows[i].Cells[0].Value.ToString()+"|"+ dataGridView1.Rows[i].Cells[1].Value.ToString()+"||");
                    }
                    sw.Write(Environment.NewLine);
                    sw.Write("*");
                    sw.Close();
                    dataGridView1.Rows.Clear();
                    StreamWriter datos = new StreamWriter(ruta[0]+".txt");
                    datos.Close();
                }
                
                
            }
            else
            {
                MessageBox.Show("Falta el nombre del archivo", "Archivos de texto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            leer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string valor = textBox3.Text;
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folderNom = Path.Combine(ruta, textBox3.Text);
            if (valor == "")
            {
                if (!Directory.Exists(folderNom))
                {
                    MessageBox.Show("El folder ha sido creado exitosamente", "Archivo de texto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Directory.CreateDirectory(folderNom);
                    textBox3.Text = "";
                }
                else
                {
                    MessageBox.Show("El nombre de este folder ya existe en sus documentos, intente de nuevo", "Archivo de texto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Text = "";
                }
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
