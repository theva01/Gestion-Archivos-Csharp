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

namespace GestionArchivosCsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEscribir_Click(object sender, EventArgs e)
        {
            TextWriter escribe = new StreamWriter("Test.txt");
            escribe.WriteLine("Hola PC MAster!");
            escribe.Close();
            StreamWriter agregar = File.AppendText("Test.txt");
            agregar.WriteLine("Hola agrego mas lineas");
            agregar.Close();
            MessageBox.Show("Listo");
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            TextReader leer = new StreamReader("Test.txt");
            MessageBox.Show(leer.ReadToEnd());
            leer.Close();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "Busca tu archivo - DH";
                openFileDialog1.ShowDialog();
                string texto = openFileDialog1.FileName;
                if (File.Exists(openFileDialog1.FileName))
                {

                    TextReader leer = new StreamReader(texto);
                    rTxtContenido.Text = leer.ReadToEnd();
                    leer.Close();
                }
                txtDireccion.Text = texto;
            }
            catch (Exception ed)
            {

                MessageBox.Show("Error al abrrir: " + ed);
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)//confirma encontrar un archivo donde guardar la informacion
                {
                    if (File.Exists(saveFileDialog1.FileName))
                    {
                        string txt = saveFileDialog1.FileName;

                        StreamWriter textoGuardar = File.CreateText(txt);
                        textoGuardar.WriteLine(rTxtContenido.Text);
                        textoGuardar.Flush();//Libreara memoria
                        textoGuardar.Close();
                        txtDireccion.Text = txt;
                    }
                    else
                    {
                        string txt = saveFileDialog1.FileName;

                        StreamWriter textoGuardar = File.CreateText(txt);
                        textoGuardar.WriteLine(rTxtContenido.Text);
                        textoGuardar.Flush();//Libreara memoria
                        textoGuardar.Close();
                        txtDireccion.Text = txt;
                    }
                }
            }
            catch (Exception err)
            {

                MessageBox.Show("Error al guardar: " + err);
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {

        }
    }
}
