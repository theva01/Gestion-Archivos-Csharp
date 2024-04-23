namespace GestionArchivosCsharp
{
    partial class Form1
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
            this.btnEscribir = new System.Windows.Forms.Button();
            this.btnLeer = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rTxtContenido = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnDesconectar = new System.Windows.Forms.Button();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnCnx = new System.Windows.Forms.Button();
            this.btnClosePsql = new System.Windows.Forms.Button();
            this.btnAdminPsql = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEscribir
            // 
            this.btnEscribir.Location = new System.Drawing.Point(394, 64);
            this.btnEscribir.Name = "btnEscribir";
            this.btnEscribir.Size = new System.Drawing.Size(133, 31);
            this.btnEscribir.TabIndex = 0;
            this.btnEscribir.Text = "Escribir";
            this.btnEscribir.UseVisualStyleBackColor = true;
            this.btnEscribir.Click += new System.EventHandler(this.btnEscribir_Click);
            // 
            // btnLeer
            // 
            this.btnLeer.Location = new System.Drawing.Point(543, 67);
            this.btnLeer.Name = "btnLeer";
            this.btnLeer.Size = new System.Drawing.Size(129, 28);
            this.btnLeer.TabIndex = 1;
            this.btnLeer.Text = "Leer";
            this.btnLeer.UseVisualStyleBackColor = true;
            this.btnLeer.Click += new System.EventHandler(this.btnLeer_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(543, 28);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(129, 30);
            this.btnAbrir.TabIndex = 2;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(392, 27);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(135, 31);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(98, 27);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(288, 20);
            this.txtDireccion.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Direccion";
            // 
            // rTxtContenido
            // 
            this.rTxtContenido.Location = new System.Drawing.Point(31, 62);
            this.rTxtContenido.Name = "rTxtContenido";
            this.rTxtContenido.Size = new System.Drawing.Size(355, 273);
            this.rTxtContenido.TabIndex = 6;
            this.rTxtContenido.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(31, 353);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(95, 63);
            this.btnConectar.TabIndex = 7;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.Location = new System.Drawing.Point(155, 353);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(104, 63);
            this.btnDesconectar.TabIndex = 8;
            this.btnDesconectar.Text = "Desconectar";
            this.btnDesconectar.UseVisualStyleBackColor = true;
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(282, 353);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(104, 63);
            this.btnConsulta.TabIndex = 9;
            this.btnConsulta.Text = "Administrar";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnCnx
            // 
            this.btnCnx.Location = new System.Drawing.Point(394, 272);
            this.btnCnx.Name = "btnCnx";
            this.btnCnx.Size = new System.Drawing.Size(95, 63);
            this.btnCnx.TabIndex = 10;
            this.btnCnx.Text = "Conectar SQL";
            this.btnCnx.UseVisualStyleBackColor = true;
            this.btnCnx.Click += new System.EventHandler(this.btnCnx_Click);
            // 
            // btnClosePsql
            // 
            this.btnClosePsql.Location = new System.Drawing.Point(508, 272);
            this.btnClosePsql.Name = "btnClosePsql";
            this.btnClosePsql.Size = new System.Drawing.Size(109, 63);
            this.btnClosePsql.TabIndex = 11;
            this.btnClosePsql.Text = "Desconectar SQL";
            this.btnClosePsql.UseVisualStyleBackColor = true;
            this.btnClosePsql.Click += new System.EventHandler(this.btnClosePsql_Click);
            // 
            // btnAdminPsql
            // 
            this.btnAdminPsql.Location = new System.Drawing.Point(396, 194);
            this.btnAdminPsql.Name = "btnAdminPsql";
            this.btnAdminPsql.Size = new System.Drawing.Size(221, 63);
            this.btnAdminPsql.TabIndex = 12;
            this.btnAdminPsql.Text = "Administrar PSQL";
            this.btnAdminPsql.UseVisualStyleBackColor = true;
            this.btnAdminPsql.Click += new System.EventHandler(this.btnAdminPsql_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 450);
            this.Controls.Add(this.btnAdminPsql);
            this.Controls.Add(this.btnClosePsql);
            this.Controls.Add(this.btnCnx);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.btnDesconectar);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.rTxtContenido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnLeer);
            this.Controls.Add(this.btnEscribir);
            this.Name = "Form1";
            this.Text = "Gestor de datos nivel basico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEscribir;
        private System.Windows.Forms.Button btnLeer;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rTxtContenido;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnDesconectar;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Button btnCnx;
        private System.Windows.Forms.Button btnClosePsql;
        private System.Windows.Forms.Button btnAdminPsql;
    }
}

