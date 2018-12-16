using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ProyectoEDD2.Clases;

namespace ProyectoEDD2.Formularios
{
    public partial class ArbolAVL : Form
    {
        public ArbolAVL()
        {
            InitializeComponent();
        }
        #region variables
        string[] divisores = { "|", "||" };
        string[] divisor = { "|" };
        int cont = 0;
        int dato = 0;
        int datb = 0;
        int cont2 = 0;
        A_DibujarAVL arbolAVL = new A_DibujarAVL(null);
        A_DibujarAVL arbolAVL_Letra = new A_DibujarAVL(null);
        Graphics g;
        DataTable dta = new DataTable();
        DataTable dt = new DataTable();
        string encabezado;
        #endregion variables
        private void ArbolAVL_Paint(object sender, PaintEventArgs en)
        {
            
        }

        private void InsertarBtn_Click(object sender, EventArgs e)
        {
            errores.Clear();
            if (valor.Text == "")
            {
                errores.SetError(valor, "Valor obligatorio");
            }
            else
            {
                try
                {
                    dato = int.Parse(valor.Text);

                    arbolAVL.Insertar(dato);
                    valor.Clear();
                    valor.Focus();
                    lblaltura.Text = arbolAVL.Raiz.getAltura(arbolAVL.Raiz).ToString();
                    cont++;
                    Refresh();
                    Refresh();
                }
                catch (Exception ex)
                {
                    errores.SetError(valor, "Debe ser numérico");
                }
            }
        }

        private void Salirbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int pintaR = 0;
        private void Buscarbtn_Click(object sender, EventArgs e)
        {
            bool encontrado = false;
            string[] registro = { "" };
            int cont = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string val = "";
                val = dataGridView1.Rows[i].Cells[1].Value.ToString();
                idlbl.Text = val;
                cont++;
                if (valor.Text == idlbl.Text)
                {
                    int indice = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    encontrado = true;
                    //Recorrido del arbol
                    try
                    {
                        datb = int.Parse(valor.Text);
                        arbolAVL.buscar(datb);
                        pintaR = 2;
                        Refresh();
                        valor.Clear();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    for (int j = 0; j < dta.Columns.Count; j++)
                    {
                        registro[0] += dta.Rows[indice][j].ToString() + "|";
                    }

                        MessageBox.Show("Existe un registro con la respectiva ID", "Archivos de texto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(registro[0], "Archivos de texto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }
            if (encontrado == false)
            {
                MessageBox.Show("No existe un registro con la respectiva ID", "Archivos de texto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errores.SetError(valor, "No existe");
            }

            errores.Clear();
            
        }

        private void Eliminarbtn_Click(object sender, EventArgs e)
        {
            errores.Clear();
            if (valor.Text == "")
            {
                errores.SetError(valor, "Valor obligatorio");
            }
            else
            {
                try
                {
                    dato = int.Parse(valor.Text);
                    valor.Clear();
                    arbolAVL.Eliminar(dato);
                    lblaltura.Text = arbolAVL.Raiz.getAltura(arbolAVL.Raiz).ToString();
                    Refresh();
                    Refresh();
                    cont2++;
                }
                catch (Exception ex)
                {

                    errores.SetError(valor, "Debe ser numérico");
                }
            }
            Refresh(); Refresh(); Refresh();

        }


        private void ArbolAVL_Load(object sender, EventArgs e)
        {

        }

        private void BTNCargarTabla_Click(object sender, EventArgs e)
        {
            string nombre;
            string header;
            string indice;
            dataGridView1.Columns.Clear();
            dta.Clear();
            dt.Clear();
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] archivo = openFileDialog1.FileName.Split('.');
                nombre = archivo[0] + ".txt";
                header = archivo[0] + "Header.txt";
                indice = archivo[0] + "Index.txt";
                StreamReader reader = new StreamReader(header);
                encabezado = reader.ReadLine();
                string[] fila = encabezado.Split(divisores, StringSplitOptions.RemoveEmptyEntries);
                for (int x = 0; x < fila.Length; x += 2)
                {
                    dta.Columns.Add(fila[x]);
                }
                reader.Close();
                CargarDatos(nombre);
                CargarIndice(indice);
            }
        }

        private void CargarDatos(string name)
        {
            using (StreamReader sr = new StreamReader(name))
            {
                string text = String.Empty;
                for (text = sr.ReadLine(); text != null; text = sr.ReadLine())
                {
                    string[] fila = text.Split(divisor, StringSplitOptions.RemoveEmptyEntries);
                    dta.Rows.Add(fila);
                }
                sr.Close();
            }
        }

        private void CargarIndice(String name)
        {
            StreamReader reader = new StreamReader(name);
            string tipo = reader.ReadLine();
            dt.Columns.Add("Posicion");
            dt.Columns.Add("Referencia");
            string contenido = reader.ReadToEnd();
            string[] filas = contenido.Split(divisor, StringSplitOptions.RemoveEmptyEntries);
            int x = 0;
            for (int i = 1; i < filas.Length; i += 2)
            {
                dt.Rows.Add(filas[x], filas[i]);
                x += 2;
            }
            reader.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 70;
            arbolI();
        }

        void arbolI()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string val = "";
                val = dataGridView1.Rows[i].Cells[1].Value.ToString();
                valor.Text = val;
                Insertaravl();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g = e.Graphics;

            arbolAVL.DibujarArbol(g, this.Font,
            Brushes.White, Brushes.Black, Pens.White, datb, Brushes.Black);
            datb = 0;
            if (pintaR == 2)
            {
                arbolAVL.colorearB(g, this.Font, Brushes.White, Brushes.Red, Pens.White, arbolAVL.Raiz,
               int.Parse(valor.Text));
                pintaR = 0;
            }
        }

        void Insertaravl()
        {
            errores.Clear();
            if (valor.Text == "")
            {
                errores.SetError(valor, "Valor obligatorio");
            }
            else
            {
                try
                {
                    dato = int.Parse(valor.Text);

                    arbolAVL.Insertar(dato);
                    valor.Clear();
                    valor.Focus();
                    lblaltura.Text = arbolAVL.Raiz.getAltura(arbolAVL.Raiz).ToString();
                    cont++;
                    Refresh();
                    Refresh();
                }
                catch (Exception ex)
                {
                    errores.SetError(valor, "Debe ser numérico");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                bool encontrado = false;
                string[] registro = { "" };
                int cont = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string val = "";
                    val = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    idlbl.Text = val;
                    cont++;
                    if (valor.Text == idlbl.Text)
                    {
                        int indice = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                        encontrado = true;
                        //Recorrido del arbol
                        try
                        {
                            datb = int.Parse(valor.Text);
                            arbolAVL.buscar(datb);
                            pintaR = 2;
                            Refresh();
                            valor.Clear();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        //busqueda en el archivo de registros basandose en el indice
                        for (int j = 0; j < dta.Columns.Count; j++)
                        {
                            registro[0] += dta.Rows[indice][j].ToString() + "|";
                        }

                        MessageBox.Show("Existe un registro con la respectiva ID", "Archivos de texto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(registro[0], "Archivos de texto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
                if (encontrado == false)
                {
                    MessageBox.Show("No existe un registro con la respectiva ID", "Archivos de texto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errores.SetError(valor, "No existe");
                }

                errores.Clear();
            }
        }
    }
}
