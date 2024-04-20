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
using System.Collections;

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
        private void mensaje(string msm) { MessageBox.Show(msm); }
        private void actualizaTabla(string query) {
            SqlCommand consulta = new SqlCommand(query, conexion);
            SqlDataAdapter data = new SqlDataAdapter(consulta);
            DataTable table = new DataTable();
            data.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtPais.Text = "";
            txtId.Text = "";
        }
        
        public void consultar()
        {
            actualizaTabla("Select * from Persona");
        }
       
        private void btnConsulta_Click(object sender, EventArgs e)
        {
            string pais = txtConsulta.Text;

            if (string.IsNullOrEmpty(pais))
            {
                consultar();
            }
            else
            {
                try
                {
                    actualizaTabla($"SELECT * FROM Persona WHERE Pais = '{pais}'");
                }
                catch (Exception exe)
                {

                    mensaje(exe.ToString());
                }
                
            }
        }
        
        private int opcionQuery(string query)
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            string cadenaQuery = query;
            SqlCommand sqlConector = new SqlCommand(cadenaQuery, conexion);
            try
            {
                return sqlConector.ExecuteNonQuery();//ejecuta el query
            }
            catch (Exception)
            {
                return 2;
            }
            
        }

        private void crUD(string query, string UD)
        {
            int flag = opcionQuery(query);

            switch (flag)
            {
                case 0:
                    mensaje($"No hay registro que coinsida para {UD}");
                    
                    break;

                case 1:
                    if (UD == "eliminar")
                    {
                        mensaje("Se elemino el registro correctamente");
                    }
                    else if (UD == "actualizar")
                    {
                        mensaje("Se actualizo el registro correctamente");
                    }
                    consultar();
                    break;

                 case 2:
                    mensaje(UD);
                    break;

                default:
                    mensaje("Opción no válida");
                    break;
            }
            limpiarCampos();
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtEdad.Text != "" && txtPais.Text != "" && txtId.Text != "")
            {

                if (!int.TryParse(txtEdad.Text, out int edad))
                {
                    mensaje("La edad debe ser un número entero válido.");
                    return;
                }

                if (edad <= 0)
                {
                    mensaje("La edad debe ser mayor que cero.");
                    return;
                }
                crUD("INSERT INTO Persona (Nombre, Edad, Pais, id)" +
                $" VALUES ('{txtNombre.Text}', '{txtEdad.Text}', '{txtPais.Text}', '{txtId.Text}')", $"La persona: {txtNombre.Text} se agrego correctamente");
            }
            else
            {
                mensaje("Todos los campos son obligatorios.");
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            crUD($"DELETE FROM Persona WHERE Nombre = '{txtNombre.Text}'", "eliminar");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            crUD($"UPDATE Persona SET Nombre = '{txtNombre.Text}', Edad = '{txtEdad.Text}', Pais = '{txtPais.Text}', id = '{txtId.Text}' WHERE id = '{txtBuscarId.Text}'", "actualizar");
        }
    }
}
