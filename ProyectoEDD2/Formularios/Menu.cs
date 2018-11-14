using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEDD2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Formularios.CrearTabla table = new Formularios.CrearTabla();
            table.MdiParent = this;
            table.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Formularios.AgregarInfo agregar = new Formularios.AgregarInfo();
            agregar.MdiParent = this;
            agregar.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Formularios.EliminarT eliminar = new Formularios.EliminarT();
            eliminar.MdiParent = this;
            eliminar.Show();
        }
    }
}
