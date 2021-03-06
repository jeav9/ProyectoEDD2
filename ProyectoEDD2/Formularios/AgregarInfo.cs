﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoEDD2.Clases;

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
        DataTable IndicesDS = new DataTable("Indices");
        string TipoArbol;
        string nombreIndice;
        string[] divisores = { "|", "||" };
        string[] divisor = { "|" };
        string encabezado;
        #endregion


        private void lectura()
        {
            using (StreamReader sr = new StreamReader(label2.Text))
            {
                string text = String.Empty;
                for (text = sr.ReadLine(); text != null; text = sr.ReadLine())
                {
                    string[] fila = text.Split(new char[] { '|' });
                    dataGridView2.Rows.Add(fila);
                }
                sr.Close();
            }

        }

      private void CargarDatos(string name)
        {
            using (StreamReader sr = new StreamReader(name))
            {
                string text = String.Empty;
                for (text = sr.ReadLine(); text != null; text = sr.ReadLine())
                {
                    string[] fila = text.Split(new char[] { '|' });
                    dataGridView2.Rows.Add(fila);
                }
                sr.Close();
            }
        }

        private void CargarIndices(string name)
        {
            StreamReader indices = new StreamReader(name);
            TipoArbol = indices.ReadLine();
            string lineas = indices.ReadToEnd();
            string[] lista = lineas.Split(divisor,StringSplitOptions.RemoveEmptyEntries);
            int x = 0;
            for(int i=1; i<lista.Length; i+=2)
            {
                IndicesDS.Rows.Add(lista[x],lista[i]);
                x += 2;
            }
            indices.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Agregar columnas al dataset de indices
            IndicesDS.Clear();
            IndicesDS.Columns.Add("Index");
            IndicesDS.Columns.Add("Id");
            string IndicesName;
            //
            string nombre;
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            dataGridView3.Rows.Clear();
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] archivo = openFileDialog1.FileName.Split('.');
                IndicesName = archivo[0];
                nombre = archivo[0] + ".txt";
                label2.Text = nombre;
                label1.Text = archivo[0] + "Header.txt";
                reader = new StreamReader(archivo[0]+"Header.txt");
                encabezado = reader.ReadLine();
                string[] fila = encabezado.Split(divisores, StringSplitOptions.RemoveEmptyEntries);
                int x = 0;
                for (int i = 1; i < fila.Length; i += 2)
                {
                    dataGridView1.Columns.Add(fila[x], fila[x]);
                    dataGridView1.Columns[fila[x]].Width = 150;
                    ((DataGridViewTextBoxColumn)dataGridView1.Columns[fila[x]]).MaxInputLength = Convert.ToInt32(fila[i]);
                    //Grid 2
                    dataGridView2.Columns.Add(fila[x], fila[x]);
                    dataGridView2.Columns[fila[x]].Width = 150;
                    ((DataGridViewTextBoxColumn)dataGridView2.Columns[fila[x]]).MaxInputLength = Convert.ToInt32(fila[i]);
                    x = x + 2;
                }
                CargarIndices(IndicesName + "Index.txt");
                CargarDatos(nombre);
                string Slinea = reader.ReadLine();
                reader.Close();
                if (Slinea == "*")
                {
                    return;
                }
                else
                {
                    listaD(archivo[0] + "Header.txt" );
                }
            }
        }

        void listaD(string name)
        {
            string linea = File.ReadLines(name).Skip(1).Take(1).First();
            string[] fila = linea.Split(divisor, StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < fila.Length; i++)
            {
                dataGridView3.Rows.Add(fila[i]);
            }
        }
     
        void guardardatos()
        {
            TextWriter texto = new StreamWriter(label2.Text);
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    texto.Write(dataGridView2.Rows[i].Cells[j].Value.ToString() + "|");
                }
                texto.WriteLine("");
            }
            texto.Close();
        }

        void guardarIndices()
        {
            string[] nombre = this.label2.Text.Split('.');
            nombreIndice = nombre[0] + "index.txt";
            StreamWriter writer = new StreamWriter(nombreIndice);
            writer.WriteLine(TipoArbol);
            for (int i=0; i < dataGridView2.Rows.Count; i++)
            {
                writer.WriteLine(i + "|" + this.dataGridView2.Rows[i].Cells[0].Value+"|");
            }
            writer.Close();
        }

        void lista()
        {
            //Actualizando el archivo con la lista de disponibles actual
            string[] arrLine = File.ReadAllLines(label1.Text);
            List<int> lista = new List<int>();
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                lista.Add(int.Parse(row.Cells[0].Value.ToString()));
            }

            int[] array = lista.ToArray();
            arrLine[1] = "";
            for (int i = 0; i < array.Length; i++)
            {
                arrLine[1] += array[i].ToString() + "|";
            }
            File.WriteAllLines(label1.Text, arrLine);
        }

        private void button6_Click(object sender, EventArgs e)
        {
                //AGREGAR NUEVA LINEA EN EL DATAGRID
                errorProvider1.Clear();
                if (!Buscar())
                {
                    if (dataGridView3.Rows.Count != 0)
                    {
                        int fila = Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value);
                        DataGridViewRow nuevo = dataGridView2.Rows[fila];
                        for (int i = 0; i < dataGridView2.Columns.Count; i++)
                        {
                            nuevo.Cells[i].Value = dataGridView1.Rows[0].Cells[i].Value.ToString();
                        }
                        dataGridView3.Rows.RemoveAt(0);
                        dataGridView1.Rows.Clear();
                        guardardatos();
                        guardarIndices();
                        lista();
                    }
                    else
                    {
                        using (var stream = File.Open(label2.Text, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                        using (var readers = new StreamReader(stream))
                        using (var writer = new StreamWriter(stream))
                        {
                            //NUEVA LINEA EN EL TEXTO
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
                        guardarIndices();
                    }
                }
                else
                {
                    errorProvider1.SetError(BTNGuardar, "El numero de ID ya existe en este archivo, ingrese otro distinto.");
                }
        }

        bool Buscar()
        {
            for (int i=0; i < dataGridView2.Rows.Count; i++)
            {
                if(dataGridView2.Rows[i].Cells[0].Value.Equals(dataGridView1.Rows[0].Cells[0].Value))
                {
                    return true;
                }
            }
            return false;
        }

    }
}