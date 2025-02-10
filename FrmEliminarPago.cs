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
    public partial class FrmEliminarPago : Form
    {
        public FrmEliminarPago()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Supongamos que tienes un TextBox llamado txtCedula y otro llamado txtIDCuota para ingresar la cédula y el ID de cuota
            string cedula = txtcedula.Text;
            int idCuota = int.Parse(txtIDCuota.Text);

            // Obtener el nombre del usuario y el monto del pago basado en la cédula y el ID de cuota
            (string nombreUsuario, decimal montoPago) = ObtenerDatosPago(cedula, idCuota);

            if (string.IsNullOrEmpty(nombreUsuario))
            {
                MessageBox.Show("No se encontró el pago con la cédula y el ID de cuota proporcionados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mostrar mensaje de confirmación
            DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar el pago de {nombreUsuario} por un monto de {montoPago:C}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Lógica para eliminar el pago
                EliminarPago(cedula, idCuota);
            }
        }

        private (string, decimal) ObtenerDatosPago(string cedula, int idCuota)
        {
            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";
            string nombreUsuario = null;
            decimal montoPago = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "SELECT m.Nombre, p.MontoPago FROM Pagos p JOIN Cuotas c ON p.ID_Cuota = c.ID_Cuota JOIN Prestamos pr ON c.ID_Prestamo = pr.ID_Prestamo JOIN Miembros m ON pr.ID_Miembro = m.ID_Miembro WHERE m.Cedula = @Cedula AND p.ID_Cuota = @ID_Cuota";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);
                    cmd.Parameters.AddWithValue("@ID_Cuota", idCuota);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        nombreUsuario = reader["Nombre"].ToString();
                        montoPago = (decimal)reader["MontoPago"];
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los datos del pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (nombreUsuario, montoPago);
        }

        private void EliminarPago(string cedula, int idCuota)
        {
            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "DELETE FROM Pagos WHERE ID_Cuota = @ID_Cuota AND ID_Cuota IN (SELECT c.ID_Cuota FROM Cuotas c JOIN Prestamos pr ON c.ID_Prestamo = pr.ID_Prestamo JOIN Miembros m ON pr.ID_Miembro = m.ID_Miembro WHERE m.Cedula = @Cedula)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);
                    cmd.Parameters.AddWithValue("@ID_Cuota", idCuota);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Pago eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


