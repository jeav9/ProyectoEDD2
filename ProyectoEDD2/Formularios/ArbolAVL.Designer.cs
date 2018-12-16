namespace ProyectoEDD2.Formularios
{
    partial class ArbolAVL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.valor = new System.Windows.Forms.TextBox();
            this.InsertarBtn = new System.Windows.Forms.Button();
            this.Eliminarbtn = new System.Windows.Forms.Button();
            this.Buscarbtn = new System.Windows.Forms.Button();
            this.Salirbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblaltura = new System.Windows.Forms.Label();
            this.errores = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.BTNCargarTabla = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.idlbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // valor
            // 
            this.valor.Location = new System.Drawing.Point(345, 44);
            this.valor.Name = "valor";
            this.valor.Size = new System.Drawing.Size(100, 20);
            this.valor.TabIndex = 0;
            this.valor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valor_KeyPress);
            // 
            // InsertarBtn
            // 
            this.InsertarBtn.Location = new System.Drawing.Point(696, 12);
            this.InsertarBtn.Name = "InsertarBtn";
            this.InsertarBtn.Size = new System.Drawing.Size(75, 23);
            this.InsertarBtn.TabIndex = 1;
            this.InsertarBtn.Text = "Insertar";
            this.InsertarBtn.UseVisualStyleBackColor = true;
            this.InsertarBtn.Visible = false;
            this.InsertarBtn.Click += new System.EventHandler(this.InsertarBtn_Click);
            // 
            // Eliminarbtn
            // 
            this.Eliminarbtn.Location = new System.Drawing.Point(696, 41);
            this.Eliminarbtn.Name = "Eliminarbtn";
            this.Eliminarbtn.Size = new System.Drawing.Size(75, 23);
            this.Eliminarbtn.TabIndex = 2;
            this.Eliminarbtn.Text = "Eliminar";
            this.Eliminarbtn.UseVisualStyleBackColor = true;
            this.Eliminarbtn.Visible = false;
            this.Eliminarbtn.Click += new System.EventHandler(this.Eliminarbtn_Click);
            // 
            // Buscarbtn
            // 
            this.Buscarbtn.Location = new System.Drawing.Point(358, 66);
            this.Buscarbtn.Name = "Buscarbtn";
            this.Buscarbtn.Size = new System.Drawing.Size(75, 23);
            this.Buscarbtn.TabIndex = 3;
            this.Buscarbtn.Text = "Buscar";
            this.Buscarbtn.UseVisualStyleBackColor = true;
            this.Buscarbtn.Click += new System.EventHandler(this.Buscarbtn_Click);
            // 
            // Salirbtn
            // 
            this.Salirbtn.Location = new System.Drawing.Point(787, 477);
            this.Salirbtn.Name = "Salirbtn";
            this.Salirbtn.Size = new System.Drawing.Size(75, 23);
            this.Salirbtn.TabIndex = 4;
            this.Salirbtn.Text = "Salir";
            this.Salirbtn.UseVisualStyleBackColor = true;
            this.Salirbtn.Click += new System.EventHandler(this.Salirbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Altura del arbol:";
            // 
            // lblaltura
            // 
            this.lblaltura.AutoSize = true;
            this.lblaltura.Location = new System.Drawing.Point(642, 9);
            this.lblaltura.Name = "lblaltura";
            this.lblaltura.Size = new System.Drawing.Size(35, 13);
            this.lblaltura.TabIndex = 6;
            this.lblaltura.Text = "label2";
            // 
            // errores
            // 
            this.errores.ContainerControl = this;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(179, 365);
            this.dataGridView1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Archivo de indices";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblaltura);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(198, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 365);
            this.panel1.TabIndex = 15;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(220, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Cargar Tabla";
            // 
            // BTNCargarTabla
            // 
            this.BTNCargarTabla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTNCargarTabla.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNCargarTabla.Image = global::ProyectoEDD2.Properties.Resources._003_subir;
            this.BTNCargarTabla.Location = new System.Drawing.Point(243, 44);
            this.BTNCargarTabla.Name = "BTNCargarTabla";
            this.BTNCargarTabla.Size = new System.Drawing.Size(42, 42);
            this.BTNCargarTabla.TabIndex = 16;
            this.BTNCargarTabla.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTNCargarTabla.UseVisualStyleBackColor = true;
            this.BTNCargarTabla.Click += new System.EventHandler(this.BTNCargarTabla_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(350, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Buscar dato";
            // 
            // idlbl
            // 
            this.idlbl.AutoSize = true;
            this.idlbl.Location = new System.Drawing.Point(523, 25);
            this.idlbl.Name = "idlbl";
            this.idlbl.Size = new System.Drawing.Size(44, 13);
            this.idlbl.TabIndex = 22;
            this.idlbl.Text = "Nombre";
            this.idlbl.Visible = false;
            // 
            // ArbolAVL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 512);
            this.ControlBox = false;
            this.Controls.Add(this.idlbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BTNCargarTabla);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Salirbtn);
            this.Controls.Add(this.Buscarbtn);
            this.Controls.Add(this.Eliminarbtn);
            this.Controls.Add(this.InsertarBtn);
            this.Controls.Add(this.valor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArbolAVL";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArbolAVL";
            this.Load += new System.EventHandler(this.ArbolAVL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox valor;
        private System.Windows.Forms.Button InsertarBtn;
        private System.Windows.Forms.Button Eliminarbtn;
        private System.Windows.Forms.Button Buscarbtn;
        private System.Windows.Forms.Button Salirbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblaltura;
        private System.Windows.Forms.ErrorProvider errores;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BTNCargarTabla;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label idlbl;
    }
}