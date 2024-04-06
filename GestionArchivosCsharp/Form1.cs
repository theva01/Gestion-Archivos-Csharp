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
    }
}
