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
    public partial class FrmEliminarAporte : Form
    {
        public FrmEliminarAporte()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Supongamos que tienes un TextBox llamado txtCedula y otro llamado txtIDAporte para ingresar la cédula y el ID del aporte
            string cedula = txtcedula.Text;
            int idAporte = int.Parse(txtBxIDAporte.Text);

            // Obtener el nombre del usuario y el monto del aporte basado en la cédula y el ID del aporte
            (string nombreUsuario, decimal montoAporte) = ObtenerDatosAporte(cedula, idAporte);

            if (string.IsNullOrEmpty(nombreUsuario))
            {
                MessageBox.Show("No se encontró el aporte con la cédula y el ID proporcionados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mostrar mensaje de confirmación
            DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar el aporte de {nombreUsuario} por un monto de {montoAporte:C}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Lógica para eliminar el aporte
                EliminarAporte(cedula, idAporte);
            }
        }

        private (string, decimal) ObtenerDatosAporte(string cedula, int idAporte)
        {
            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";
            string nombreUsuario = null;
            decimal montoAporte = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "SELECT m.Nombre, av.Monto FROM AportesVoluntarios av JOIN Miembros m ON av.ID_Miembro = m.ID_Miembro WHERE m.Cedula = @Cedula AND av.ID_Aporte = @ID_Aporte";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);
                    cmd.Parameters.AddWithValue("@ID_Aporte", idAporte);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        nombreUsuario = reader["Nombre"].ToString();
                        montoAporte = (decimal)reader["Monto"];
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los datos del aporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (nombreUsuario, montoAporte);
        }

        private void EliminarAporte(string cedula, int idAporte)
        {
            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "DELETE FROM AportesVoluntarios WHERE ID_Aporte = @ID_Aporte AND ID_Miembro IN (SELECT ID_Miembro FROM Miembros WHERE Cedula = @Cedula)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);
                    cmd.Parameters.AddWithValue("@ID_Aporte", idAporte);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Aporte eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el aporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el aporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



