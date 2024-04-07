using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestionArchivosCsharp
{
    public partial class FormDBmanagement : Form
    {
        static string conexionString = "data source=holamundodev.eastus2.cloudapp.azure.com; initial catalog=AndersonDB; user id=andersonorozco; password=Holamundo123*";
        public SqlConnection conexion = new SqlConnection(conexionString);
        public FormDBmanagement()
        {
            InitializeComponent();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            string pais = txtConsulta.Text;

            if (string.IsNullOrEmpty(pais))
            {
                string query = "Select * from Persona";
                SqlCommand consulta = new SqlCommand(query, conexion);
                SqlDataAdapter data = new SqlDataAdapter(consulta);
                DataTable table = new DataTable();
                data.Fill(table);
                dataGridView1.DataSource = table;
            }
            else
            {
                try
                {
                    string query = $"SELECT * FROM Persona WHERE Pais = '{pais}'";
                    SqlCommand consulta = new SqlCommand(query, conexion);
                    SqlDataAdapter data = new SqlDataAdapter(consulta);
                    DataTable table = new DataTable();
                    data.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception exe)
                {

                    MessageBox.Show(exe.ToString());
                }
                
            }
        }
    }
}
