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
    public partial class FrmEliminarPr : Form
    {
        public FrmEliminarPr()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Supongamos que tienes un TextBox llamado txtIDPrestamo para ingresar el ID del préstamo
            int idPrestamo = int.Parse(txtIDPrestamo.Text);

            // Obtener el nombre del dueño del préstamo y el monto del préstamo basado en el ID del préstamo
            (string nombreUsuario, decimal montoPrestamo) = ObtenerDatosPrestamo(idPrestamo);

            if (string.IsNullOrEmpty(nombreUsuario))
            {
                MessageBox.Show("No se encontró el préstamo con el ID proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mostrar mensaje de confirmación
            DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar el préstamo de {nombreUsuario} por un monto de {montoPrestamo:C}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Lógica para eliminar el préstamo
                EliminarPrestamo(idPrestamo);
            }
        }

        private (string, decimal) ObtenerDatosPrestamo(int idPrestamo)
        {
            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";
            string nombreUsuario = null;
            decimal montoPrestamo = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "SELECT m.Nombre, p.Monto FROM Prestamos p JOIN Miembros m ON p.ID_Miembro = m.ID_Miembro WHERE p.ID_Prestamo = @ID_Prestamo";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID_Prestamo", idPrestamo);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        nombreUsuario = reader["Nombre"].ToString();
                        montoPrestamo = (decimal)reader["Monto"];
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los datos del préstamo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (nombreUsuario, montoPrestamo);
        }

        private void EliminarPrestamo(int idPrestamo)
        {
            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "DELETE FROM Prestamos WHERE ID_Prestamo = @ID_Prestamo";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID_Prestamo", idPrestamo);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Préstamo eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el préstamo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el préstamo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

