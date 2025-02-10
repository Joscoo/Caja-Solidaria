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
    public partial class FrmMostraPorMiembro : Form
    {
        public FrmMostraPorMiembro()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtener el número de cédula del TextBox
            string cedula = txtCedula.Text;

            // Llenar los DataGridView con las vistas
            LlenarDataGridView(dgvPrestamos, "v_MiembrosPrestamos", cedula);
            LlenarDataGridView(dgvPagos, "v_MiembrosPagos", cedula);
            LlenarDataGridView(dgvAportes, "v_MiembrosAportes", cedula);
        }

        private void LlenarDataGridView(DataGridView dgv, string vista, string cedula)
        {
            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = $"SELECT * FROM {vista} WHERE ID_Miembro IN (SELECT ID_Miembro FROM Miembros WHERE Cedula = @Cedula)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Asignar el DataTable como fuente de datos del DataGridView
                    dgv.DataSource = dataTable;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


