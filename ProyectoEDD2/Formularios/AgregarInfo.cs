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
        string[] divisor = { "|" };
        string encabezado;
        #endregion


        private void lectura()
        {
            using (StreamReader sr = new StreamReader(label2.Text))
            {
                string text = "";
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
                string text = "";
                for (text = sr.ReadLine(); text != null; text = sr.ReadLine())
                {
                    string[] fila = text.Split(new char[] { '|' });
                    dataGridView2.Rows.Add(fila);
                }
                sr.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string nombre;
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] archivo = openFileDialog1.FileName.Split('.');
                nombre = archivo[0] + ".txt";
                label2.Text = nombre;
                label1.Text = archivo[0] + "Header.txt";
                reader = new StreamReader(archivo[0]+"Header.txt");
                encabezado = reader.ReadLine();
                string[] fila = encabezado.Split(divisores, StringSplitOptions.RemoveEmptyEntries);
                int x = 0;
                int y = 1;
                for (int i = 2; i < fila.Length; i += 3)
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.Name = fila[x];
                    column.HeaderText = fila[x];
                    column.MaxInputLength= Convert.ToInt32(fila[y]);
                    column.DefaultCellStyle.BackColor = Color.LightGray;
                    column.ValueType = typeof(int);
                    dataGridView1.Columns.Add(column);
                    //dataGridView1.Columns.Add(fila[x], fila[x]);
                    //dataGridView1.Columns[fila[x]].Width = 150;
                    //((DataGridViewTextBoxColumn)dataGridView1.Columns[fila[x]]).MaxInputLength = Convert.ToInt32(fila[y]);
                    //if (fila[i].Equals("int"))
                    //{
                    //((DataGridViewTextBoxColumn)dataGridView1.Columns[fila[x]]).
                    //    CellTemplate.ValueType = typeof(int);
                    //}
                    //Grid 2
                    dataGridView2.Columns.Add(fila[x], fila[x]);
                    dataGridView2.Columns[fila[x]].Width = 150;
                    ((DataGridViewTextBoxColumn)dataGridView2.Columns[fila[x]]).MaxInputLength = Convert.ToInt32(fila[y]);
                    x = x + 3;
                    y = y + 3;
                }
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
            if (dataGridView3.Rows.Count != 0)
            {
                int fila = Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value);
                DataGridViewRow nuevo = dataGridView2.Rows[fila];
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    nuevo.Cells[i].Value = dataGridView1.Rows[0].Cells[i].Value.ToString();
                }
                dataGridView3.Rows.RemoveAt(0);
                guardardatos();
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
            }
        }

    }
}