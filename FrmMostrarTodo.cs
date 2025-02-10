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
    public partial class FrmMostrarTodo : Form
    {
        public FrmMostrarTodo()
        {
            InitializeComponent();
        }

        private void FrmMostrarTodo_Load(object sender, EventArgs e)
        {
            mostrarTodo();
        }

        private void mostrarTodo()
        {
            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "SELECT * FROM v_InformacionCompleta;\r\n";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    // Asignar el DataTable como fuente de datos del DataGridView
                    dgvTodaInfo.DataSource = dataTable;
                    conn.Close();
                }
                    ConfigurarColumnasDataGridView(dgvTodaInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigurarColumnasDataGridView(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Configurar la altura de las filas para que llenen todo el espacio del DataGridView
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.RowTemplate.Height = dgv.ClientSize.Height / dgv.RowCount;
        }
    }
}
