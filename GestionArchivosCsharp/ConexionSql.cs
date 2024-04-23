using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using System.Data;

namespace GestionArchivosCsharp
{
    public class ConexionSql
    {
        private static string cCnx = "Host=pg-7f663dc-oeduardo263psql.k.aivencloud.com; Port=19331; Username=avnadmin; Password=AVNS_ptSfvROP0tOnGWke-Fe; Database=defaultdb; SSL Mode=Require";
        NpgsqlConnection npgCx = new NpgsqlConnection(cCnx);

        public static string CCnx { get => cCnx; set => cCnx = value; }

        public void sms(string m) { MessageBox.Show(m); }
        public void conectar()
        {

            try {

                npgCx.Open();
                sms("Conectado listo");

            }
            catch (Exception ex)
            {
                sms("Mensaje de excepción: " + ex.Message);
            }
        }

        public void desconectar()
        {
            try
            {

                npgCx.Close();
                sms("Desconectado");

            }
            catch (Exception ex)
            {
                sms("Mensaje de excepción: " + ex.Message);
            }
        }

        public DataTable consultar(string op, string valor)
        {
            string opcion = "";
            try
            {
                opcion = op;
            }
            catch (Exception er)
            {

                sms(er.ToString());
            }

            // Definir la consulta SQL base
            string query = "SELECT * FROM Persona";
            // Agregar condición según la opción seleccionada
            switch (opcion)
            {
                case "Nombre":
                    query += $" WHERE Nombre = '{valor}'";
                    break;
                case "ID":
                    query += $" WHERE Id = {valor}";
                    break;
                case "Pais":
                    query += $" WHERE Pais = '{valor}'";
                    break;
                case "Todos":
                    query+="";
                    break;
                default:
                    
                    break;
            }

            // Crear la conexión a la base de datos
            using (NpgsqlConnection connection = new NpgsqlConnection(CCnx))
            {
                try
                {
                    conectar();
                    // Crear el adaptador de datos y el DataSet
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    
                    // Llenar el DataSet con los datos del adaptador
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    // Mostrar los datos en el DataGridView
                    desconectar();
                    return dt;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al consultar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                
            }
        }

        public void eliminar(string n)
        {

            // Consulta SQL para eliminar registros basados en el nombre
            string query = "DELETE FROM Persona WHERE Nombre = @Nombre";

            // Crear la conexión a la base de datos
            using (NpgsqlConnection connection = new NpgsqlConnection(cCnx))
            {
                try
                {
                    connection.Open();
                    // Crear el comando con la consulta SQL y la conexión
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                    {
                        // Agregar parámetros para el nombre
                        cmd.Parameters.AddWithValue("@Nombre", n);
                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();
                        desconectar();
                    }
                    
                    sms($"Registro de {n} eliminado");
                  
                }
                catch (Exception ex)
                {
                    sms($"Error al eliminar registros: {ex.Message}");
                }
            }

        }

        public void actualizar(int id, string nuevoNombre, int nuevaEdad, string nuevoPais, int nuevoId)
        {
            // Consulta SQL para actualizar registros basados en el ID
            string query = $"UPDATE Persona SET Id = @Id, Nombre = @Nombre, Edad = @Edad, Pais = @Pais WHERE Id = @{id}";

            // Crear la conexión a la base de datos
            using (NpgsqlConnection connection = new NpgsqlConnection(cCnx))
            {
                try
                {
                    connection.Open();
                    // Crear el comando con la consulta SQL y la conexión
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                    {
                        // Agregar parámetros para el ID, nuevo ID, nuevo nombre, nueva edad y nuevo país
                        cmd.Parameters.AddWithValue("@Id", nuevoId);
                        cmd.Parameters.AddWithValue("@Nombre", nuevoNombre);
                        cmd.Parameters.AddWithValue("@Edad", nuevaEdad);
                        cmd.Parameters.AddWithValue("@Pais", nuevoPais);
                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    sms($"Error al actualizar registros: {ex.Message}");
                }
            }
        
        }



    }
}
