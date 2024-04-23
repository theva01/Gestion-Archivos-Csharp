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
using System.Data.SqlClient;
using Npgsql;

namespace GestionArchivosCsharp
{
    public partial class PsqlAdmin : Form
    {
        ConexionSql iCnx = new ConexionSql();
        public PsqlAdmin()
        {
            InitializeComponent();
            cmbOpciones.Items.Add("Todos");
            cmbOpciones.Items.Add("ID");
            cmbOpciones.Items.Add("Nombre");
            cmbOpciones.Items.Add("Pais");
            cmbOpciones.SelectedIndex = 0;
        }

        private bool ValidarCampos()
        {
            // Validar el campo Nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }

            // Validar el campo Edad
            if (!int.TryParse(txtEdad.Text, out int edad) || edad <= 0)
            {
                MessageBox.Show("Por favor, ingrese una edad válida (un número entero mayor que cero).", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEdad.Focus();
                return false;
            }

            // Validar el campo País
            if (string.IsNullOrWhiteSpace(txtPais.Text))
            {
                MessageBox.Show("Por favor, ingrese un país.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPais.Focus();
                return false;
            }

            // Validar el campo Id
            if (!int.TryParse(txtId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Por favor, ingrese un ID válido (un número entero mayor que cero).", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtId.Focus();
                return false;
            }

            // Todos los campos son válidos
            return true;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string opcion = "";
            try
            {
                 opcion = cmbOpciones.SelectedItem.ToString();
            }
            catch (Exception ee)
            {

                iCnx.sms(ee.ToString());
            }
            
            string valor ="";

            // Asignar el valor correspondiente según la opción seleccionada en el ComboBox
            if (opcion == "ID")
            {
                valor = txtId.Text;
            }
            else if (opcion == "Nombre")
            {
                valor = txtNombre.Text;
            }
            else if (opcion == "Pais")
            {
                valor = txtPais.Text;
            }
            else if (opcion == "Todos")
            {
                opcion = (cmbOpciones.SelectedIndex = 0).ToString();
            }
            else
            {
                
                MessageBox.Show("Por favor, seleccione una opción de consulta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llamar al método Consultar de la clase Consultas
            dataGridView1.DataSource = iCnx.consultar(opcion, valor);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los TextBoxes
            if (ValidarCampos()) {

                string nombre = txtNombre.Text;
                int edad = Convert.ToInt32(txtEdad.Text);
                string pais = txtPais.Text;
                int id = Convert.ToInt32(txtId.Text);

                // Crear la conexión a la base de datos
                using (NpgsqlConnection connection = new NpgsqlConnection(ConexionSql.CCnx))
                {
                    try
                    {
                        connection.Open();
                        
                        string insertQuery = "INSERT INTO Persona (id, Nombre, Edad, Pais) VALUES (@Id, @Nombre, @Edad, @Pais)";
                        // Crear el comando con la consulta SQL y la conexión
                        using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.Parameters.AddWithValue("@Nombre", nombre);
                            cmd.Parameters.AddWithValue("@Edad", edad);
                            cmd.Parameters.AddWithValue("@Pais", pais);
                            // Ejecutar la consulta
                            cmd.ExecuteNonQuery();
                        }
                        iCnx.sms("Registro insertado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        iCnx.sms("Error: " + ex.Message);
                    }
                }
            }
            
        }

        private void btnCrearTablas_Click(object sender, EventArgs e)
        {
            // Obtener el nombre de la tabla desde el TextBox
            string nombreTabla = txtNombreTabla.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombreTabla))
            {
                MessageBox.Show("Por favor, ingrese un nombre para la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear la conexión a la base de datos
            using (NpgsqlConnection connection = new NpgsqlConnection(ConexionSql.CCnx))
            {
                try
                {
                    connection.Open();
                    // Definir la consulta SQL para crear la tabla
                    string createTableQuery = $"CREATE TABLE {nombreTabla} (Id SERIAL PRIMARY KEY, Nombre VARCHAR(100), Edad INT, Pais VARCHAR(100))";
                    // Crear el comando con la consulta SQL y la conexión
                    using (NpgsqlCommand cmd = new NpgsqlCommand(createTableQuery, connection))
                    {
                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show($"La tabla '{nombreTabla}' ha sido creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al crear la tabla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            iCnx.eliminar(txtNombre.Text);
            dataGridView1.DataSource = iCnx.consultar("Todos", "");
            txtNombre.Text = "";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int idOld = Convert.ToInt32(txtIdOld.Text);
                int id = Convert.ToInt32(txtId.Text);
                string nuevoNombre = txtNombre.Text;
                int nuevaEdad = Convert.ToInt32(txtEdad.Text);
                string nuevoPais = txtPais.Text;

                // Llamar al método actualizar de la clase OperacionesBD
                iCnx.actualizar(idOld, nuevoNombre, nuevaEdad, nuevoPais, id);

                // Mostrar un mensaje de éxito
                MessageBox.Show("Registro actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {

                throw;
            }


            // Limpiar los campos de entrada
            txtId.Clear();
            txtNombre.Clear();
            txtEdad.Clear();
            txtPais.Clear();
        }
    }
}
