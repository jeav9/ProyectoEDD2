﻿using System;
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
        string nombreIndice;
        string[] divisores = { "|", "||" };
        string encabezado;
        #endregion

        void ActualizarIndice()
        {//Cargar Archivo
            string[] divisor = { "|" };
            StreamReader streamReader = new StreamReader(nombreIndice);
            string tipo = streamReader.ReadLine();
            DataTable dt = new DataTable();
            dt.Columns.Add("index");
            dt.Columns.Add("reference");
            string contenido = streamReader.ReadToEnd();
            string[] columnas = contenido.Split(divisor, StringSplitOptions.RemoveEmptyEntries);
            int x = 0;
            for(int i=1; i < columnas.Length; i += 2)
            {
                dt.Rows.Add(columnas[x], columnas[i]);
                x += 2;
            }
            streamReader.Close();
            //buscar
            int pos=0;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].Equals(textBox1.Text))
                {
                    pos = i;
                    break;
                }
            }
            dt.Rows[pos][1] = "*";
            //actualizar
            StreamWriter streamWriter = new StreamWriter(nombreIndice);
            streamWriter.WriteLine(tipo);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                streamWriter.Write(dt.Rows[i][0]+"|"+dt.Rows[i][1]+"|");
            }
            streamWriter.Close();
        }
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
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            string nombre;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] archivo = openFileDialog1.FileName.Split('.');
                label1.Text = archivo[0]+"Header.txt";
                nombreIndice = archivo[0] + "Index.txt";
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
            reader.Close();
            if (Slinea == "*")
            {
                return;
            }
            else
            {
                listaDllenado();

            }           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string valor = textBox1.Text;
            int Indice = -1;
            bool encontrado=false;
            if (valor == "")
            {
                MessageBox.Show("No puede dejar campos vacios", "Archivos de texto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(valor))
                    {
                        ActualizarIndice();
                        encontrado = true;
                        Indice = row.Index;
                        DataGridViewRow eliminar = dataGridView1.Rows[Indice];
                        eliminar.Selected = true;
                        DialogResult Resultado = MessageBox.Show("¿Desea eliminar este registro?", "Archivos de texto", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                          if (Resultado == DialogResult.Yes)
                          {
                             eliminar.Selected = false;
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                              eliminar.Cells[i].Value = "";
                            }
                            //Aqui agregamos los eliminados a la lista de disponibles
                            dataGridView2.Rows.Add(Indice.ToString());
                            break;
                          }
                          else if (Resultado == DialogResult.No)
                          {
                            eliminar.Selected = false;
                            MessageBox.Show("Registro no eliminado", "Archivos de texto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                          }
                    }
                }
            if (encontrado==false)
            {
                MessageBox.Show("Su codigo no se encontro en este archivo, intente de nuevo", "Archivos de texto", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    texto.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "|");
                }
                texto.WriteLine("");
            }
            texto.Close();
            listaD();
            MessageBox.Show("Los registros y la lista de disponibles se han actualizado exitosamente en su respectivo archivo", "Archivos de texto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
