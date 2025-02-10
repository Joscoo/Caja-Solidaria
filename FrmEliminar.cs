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

namespace Caja_Solidaria
{
    public partial class FrmEliminar : Form
    {
        public FrmEliminar()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Supongamos que tienes un TextBox llamado txtCedulaUsuario para ingresar la cédula del usuario
            string cedulaUsuario = txtcedula.Text;

            // Obtener el nombre del usuario basado en la cédula
            string nombreUsuario = ObtenerNombreUsuario(cedulaUsuario);

            if (string.IsNullOrEmpty(nombreUsuario))
            {
                MessageBox.Show("No se encontró el usuario con la cédula proporcionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mostrar mensaje de confirmación
            DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar al usuario {nombreUsuario}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Lógica para eliminar el usuario
                EliminarUsuario(cedulaUsuario);
            }
        }

        private string ObtenerNombreUsuario(string cedula)
        {
            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";
            string nombreUsuario = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "SELECT Nombre FROM Miembros WHERE Cedula = @Cedula";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        nombreUsuario = reader["Nombre"].ToString();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el nombre del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return nombreUsuario;
        }

        private void EliminarUsuario(string cedula)
        {
            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "DELETE FROM Miembros WHERE Cedula = @Cedula";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Usuario eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
