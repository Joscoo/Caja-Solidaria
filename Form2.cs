using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Caja_Solidaria
{
    public partial class pnlimagen2 : Form
    {
        public pnlimagen2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CargarMiembros(); // Cargar los miembros al iniciar
            CargarPrestamos(); // Cargar los préstamos al iniciar
            CargarPagos(); // Cargar los pagos al iniciar
            CargarAportes(); // Cargar los aportes al iniciar
        }

        private void CargarMiembros()
        {
            // TODO: This line of code loads data into the 'cajaSolidariaDataSet.Miembros' table. You can move, or remove it, as needed.
            this.miembrosTableAdapter.Fill(this.cajaSolidariaDataSet.Miembros);
            ConfigurarColumnasDataGridView(dgvtablamiembros);

        }

        private void CargarPrestamos()
        {
            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "SELECT m.Cedula, m.Nombre, p.ID_Prestamo, p.Monto, p.FechaInicio, p.FechaFin, p.Estado FROM Miembros m JOIN Prestamos p on p.ID_Miembro = m.ID_Miembro";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Asignar el DataTable como fuente de datos del DataGridView
                    dgvtablaprestamos.DataSource = dataTable;
                    conn.Close();
                }
                ConfigurarColumnasDataGridView(dgvtablaprestamos);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPagos()
        {
            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "SELECT m.Cedula, m.Nombre, pr.Monto as \"Monto Prestamo\", pr.Estado as \"Estado Prestamo\", c.Id_Cuota, c.Monto as \"Monto Cuota\", c.Estado as \"Estado Cuota\", p.MontoPago as \"Monto Pago\", p.FechaPago\r\nFROM Miembros m\r\nJOIN Prestamos pr on pr.ID_Miembro = m.ID_Miembro\r\nJOIN Cuotas c on c.ID_Prestamo =pr.ID_Prestamo\r\nJOIN Pagos p on p.ID_Cuota = c.ID_Cuota\r\n";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Asignar el DataTable como fuente de datos del DataGridView
                    dgvtablapagos.DataSource = dataTable;
                    conn.Close();
                }
                ConfigurarColumnasDataGridView(dgvtablapagos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAportes()
        {
            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "SELECT m.Cedula, m.Nombre, av.Id_Aporte, av.Monto, av.FechaAporte\r\nFROM Miembros m\r\nJOIN AportesVoluntarios av on av.ID_Miembro = m.ID_Miembro\r\n";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Asignar el DataTable como fuente de datos del DataGridView
                    dgvtablaaportes.DataSource = dataTable;
                    conn.Close();
                }
                ConfigurarColumnasDataGridView(dgvtablaaportes);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void Form2_Resize(object sender, EventArgs e)
        {
            AjustarComponentes(); // Ajustar los componentes al cambiar el tamaño del formulario
        }

        private void AjustarComponentes()
        {
            // Ajustar el tamaño del TabControl al formulario
            tabfuncionalidades.Dock = DockStyle.Fill;

            // Ajustar las TabPages dentro del TabControl
            foreach (TabPage tabPage in tabfuncionalidades.TabPages)
            {
                tabPage.Dock = DockStyle.Fill;
            }

            // --- Código para `tabpmiembros` ---
            pnlimagen.Dock = DockStyle.Fill; // Panel principal de `tabpmiembros`

            // Ajustar tamaño de los elementos de `tabpmiembros`
            AjustarTamaño(pnlformulario);
            AjustarTamaño(pnlinformacion);
            AjustarTamaño(btnguardarmiembros);
            AjustarTamaño(dtpfecharegistro);
            AjustarTamaño(lblfecharegistro);
            AjustarTamaño(txtcorreo);
            AjustarTamaño(lblcorreo);
            AjustarTamaño(txtnombre);
            AjustarTamaño(lblnombre);
            AjustarTamaño(txtcedula);
            AjustarTamaño(lblcedula);
            AjustarTamaño(lblregistro);

            // Ajustar tamaño de los elementos de interacción en `tabpmiembros`
            AjustarTamaño(pnlinteraccion);
            AjustarTamaño(btnbuscar);
            AjustarTamaño(btnmostrar);
            AjustarTamaño(btneliminar);
            AjustarTamaño(btnactualizar);
            AjustarTamaño(pnltablamiembros);
            AjustarTamaño(dgvtablamiembros);
            AjustarTamaño(pnlregistromiembros);
            AjustarTamaño(lblregistromiembros);

            // Personalizar botones en `tabpmiembros`
            PersonalizarBoton(btnbuscar, Color.Green);
            PersonalizarBoton(btnmostrar, Color.Green);
            PersonalizarBoton(btneliminar, Color.Green);
            PersonalizarBoton(btnactualizar, Color.Green);
            PersonalizarBoton(btnguardarmiembros, Color.Green);
            // --- Fin de código para `tabpmiembros` ---

            // --- Código para `tabpprestamos` ---
            pnlimagenpr.Dock = DockStyle.Fill; // Panel principal de `tabpprestamos`

            // Ajustar tamaño de los elementos de `tabpprestamos`
            AjustarTamaño(pnlinteraccionpr);
            AjustarTamaño(btnbuscarpr);
            AjustarTamaño(btnmostrarpr);
            AjustarTamaño(btneliminarpr);
            AjustarTamaño(btnactualizarpr);
            AjustarTamaño(pnltablaprestamos);
            AjustarTamaño(dgvtablaprestamos);
            AjustarTamaño(pnlregistroprestamos);
            AjustarTamaño(lblregistroprestamos);
            AjustarTamaño(pnlformulariopr);
            AjustarTamaño(pnlinformacionpr);
            AjustarTamaño(cmbestado);
            AjustarTamaño(lblestado);
            AjustarTamaño(dtpfechainicio);
            AjustarTamaño(btnguardarpr);
            AjustarTamaño(dtpfechafin);
            AjustarTamaño(lblfin);
            AjustarTamaño(lblinicio);
            AjustarTamaño(txtmonto);
            AjustarTamaño(lblmontopr);
            AjustarTamaño(txtCedulaPr);
            AjustarTamaño(lblCedulaPr);
            AjustarTamaño(lblregistropr);

            // Personalizar botones en `tabpprestamos`
            PersonalizarBoton(btnbuscarpr, Color.Green);
            PersonalizarBoton(btnmostrarpr, Color.Green);
            PersonalizarBoton(btneliminarpr, Color.Green);
            PersonalizarBoton(btnactualizarpr, Color.Green);
            PersonalizarBoton(btnguardarpr, Color.Green);
            // --- Fin de código para `tabpprestamos` ---

            // --- Código para `tabppagos` ---
            pnlimagenpa.Dock = DockStyle.Fill; // Panel principal de `tabppagos`

            // Ajustar tamaño de los elementos de `tabppagos`
            AjustarTamaño(pnlinteraccionpa);
            AjustarTamaño(btnbuscarpagos);
            AjustarTamaño(btnmostrarpagos);
            AjustarTamaño(btneliminarpagos);
            AjustarTamaño(btnactualizarpagos);
            AjustarTamaño(pnltablapagos);
            AjustarTamaño(dgvtablapagos);
            AjustarTamaño(pnlregistropagos);
            AjustarTamaño(lblregistropagos);
            AjustarTamaño(pnlformulariopagos);
            AjustarTamaño(pnlinformacionpagos);
            AjustarTamaño(btnguardarpagos);
            AjustarTamaño(txtidcuota);
            AjustarTamaño(lblidcuota);
            AjustarTamaño(dtpfechapagos);
            AjustarTamaño(lblfechapagos);
            AjustarTamaño(txtmontopagos);
            AjustarTamaño(lblmontopagos);
            AjustarTamaño(txtCedulaPagos);
            AjustarTamaño(lblnombrepagos);
            AjustarTamaño(lblregistropa);

            // Personalizar botones en `tabppagos`
            PersonalizarBoton(btnbuscarpagos, Color.Green);
            PersonalizarBoton(btnmostrarpagos, Color.Green);
            PersonalizarBoton(btneliminarpagos, Color.Green);
            PersonalizarBoton(btnactualizarpagos, Color.Green);
            PersonalizarBoton(btnguardarpagos, Color.Green);
            // --- Fin de código para `tabppagos` ---

            // --- Código para `tabpaportesvo` ---
            pnlimagenap.Dock = DockStyle.Fill; // Panel principal de `tabpaportesvo`

            // Ajustar tamaño de los elementos de `tabpaportesvo`
            AjustarTamaño(pnlinformacionap);
            AjustarTamaño(btnmostraraportes);
            AjustarTamaño(btnbuscaraportes);
            AjustarTamaño(btneliminaraportes);
            AjustarTamaño(btnactualizaraportes);
            AjustarTamaño(pnltablaaportes);
            AjustarTamaño(dgvtablaaportes);
            AjustarTamaño(pnlregistroaportes);
            AjustarTamaño(lblregistroaportes);
            AjustarTamaño(pnlformularioaportes);
            AjustarTamaño(pnlinformacionaportes);
            AjustarTamaño(btnguardaraportes);
            AjustarTamaño(dtpfechaaportes);
            AjustarTamaño(lblfechaaportes);
            AjustarTamaño(txtmontoaportes);
            AjustarTamaño(lblmontoaportes);
            AjustarTamaño(txtCedulaAportes);
            AjustarTamaño(lblCedulaAportes);
            AjustarTamaño(lblregistroap);

            // Personalizar botones en `tabpaportesvo`
            PersonalizarBoton(btnmostraraportes, Color.Green);
            PersonalizarBoton(btnbuscaraportes, Color.Green);
            PersonalizarBoton(btneliminaraportes, Color.Green);
            PersonalizarBoton(btnactualizaraportes, Color.Green);
            PersonalizarBoton(btnguardaraportes, Color.Green);
            // --- Fin de código para `tabpaportesvo` ---
        }

        private void AjustarTamaño(Control control)
        {
            // Ajustar tamaño y posición al 1.5x
            control.Width = (int)(control.Width * 1.5);
            control.Height = (int)(control.Height * 1.5);
            control.Left = (int)(control.Left * 1.5);
            control.Top = (int)(control.Top * 1.5);

            // Ajustar la fuente de los controles si es un Label, TextBox, Button, etc.
            if (control is Label || control is TextBox || control is Button || control is DateTimePicker || control is ComboBox)
            {
                control.Font = new Font("Arial", 14, FontStyle.Bold); // Arial 14 negrita
            }
        }

        private void PersonalizarBoton(Button button, Color color)
        {
            // Personalizar los botones con color y estilo
            button.BackColor = color;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
        }

        private void btnguardarmiembros_Click(object sender, EventArgs e)
        {
            string cedula = txtcedula.Text;
            string nombre = txtnombre.Text;
            string correo = txtcorreo.Text;
            string fechaRegistro = dtpfecharegistro.Value.ToString("yyyy-MM-dd");

            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = "EXEC sp_RegistrarMiembro @Cedula, @Nombre, @Correo, @FechaRegistro";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@FechaRegistro", fechaRegistro);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Miembro Registrado Correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el miembro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            CargarMiembros();
        }

        private void btnactualizarpr_Click(object sender, EventArgs e)
        {
            CargarPrestamos();
        }

        private void btnactualizarpagos_Click(object sender, EventArgs e)
        {
            CargarPagos();
        }

        private void btnactualizaraportes_Click(object sender, EventArgs e)
        {
            CargarAportes();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            FrmEliminar frmEliminar = new FrmEliminar();
            frmEliminar.ShowDialog();
        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {
            FrmMostrarTodo frmMostrarTodo = new FrmMostrarTodo();
            frmMostrarTodo.ShowDialog();
        }

        private void btnmostrarpr_Click(object sender, EventArgs e)
        {
            FrmMostrarTodo frmMostrarTodo = new FrmMostrarTodo();
            frmMostrarTodo.ShowDialog();
        }

        private void btnmostrarpagos_Click(object sender, EventArgs e)
        {
            FrmMostrarTodo frmMostrarTodo = new FrmMostrarTodo();
            frmMostrarTodo.ShowDialog();
        }

        private void btnmostraraportes_Click(object sender, EventArgs e)
        {
            FrmMostrarTodo frmMostrarTodo = new FrmMostrarTodo();
            frmMostrarTodo.ShowDialog();
        }

        private void btneliminarpr_Click(object sender, EventArgs e)
        {
            FrmEliminarPr frmEliminarPr = new FrmEliminarPr();
            frmEliminarPr.ShowDialog();

        }

        private void btneliminarpagos_Click(object sender, EventArgs e)
        {
            FrmEliminarPago frmEliminarPago = new FrmEliminarPago();
            frmEliminarPago.ShowDialog();
        }

        private void btneliminaraportes_Click(object sender, EventArgs e)
        {
            FrmEliminarAporte frmEliminarAporte = new FrmEliminarAporte();
            frmEliminarAporte.ShowDialog();
        }

        private void btnguardarpr_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los controles del formulario
            string cedula = txtCedulaPr.Text;
            decimal monto = decimal.Parse(txtmonto.Text);
            string fechaInicio = dtpfechainicio.Value.ToString("yyyy-MM-dd");
            string fechaFin = dtpfechafin.Value.ToString("yyyy-MM-dd");
            string estado = cmbestado.SelectedItem.ToString();

            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();

                    // Obtener el ID del miembro basado en la cédula
                    string queryMiembro = "SELECT ID_Miembro FROM Miembros WHERE Cedula = @Cedula";
                    SqlCommand cmdMiembro = new SqlCommand(queryMiembro, conn);
                    cmdMiembro.Parameters.AddWithValue("@Cedula", cedula);
                    int idMiembro = (int)cmdMiembro.ExecuteScalar();

                    // Ejecutar el procedimiento almacenado para registrar el préstamo
                    string queryPrestamo = "EXEC sp_RegistrarPrestamo @ID_Miembro, @Monto, @FechaInicio, @FechaFin, @Estado";
                    SqlCommand cmdPrestamo = new SqlCommand(queryPrestamo, conn);
                    cmdPrestamo.Parameters.AddWithValue("@ID_Miembro", idMiembro);
                    cmdPrestamo.Parameters.AddWithValue("@Monto", monto);
                    cmdPrestamo.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmdPrestamo.Parameters.AddWithValue("@FechaFin", fechaFin);
                    cmdPrestamo.Parameters.AddWithValue("@Estado", estado);

                    cmdPrestamo.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Préstamo registrado correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el préstamo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnguardarpagos_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los controles del formulario
            string cedula = txtCedulaPagos.Text;
            int idCuota = int.Parse(txtidcuota.Text);
            decimal montoPago = decimal.Parse(txtmontopagos.Text);
            string fechaPago = dtpfechapagos.Value.ToString("yyyy-MM-dd");

            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();

                    // Obtener el ID del miembro basado en la cédula
                    string queryMiembro = "SELECT ID_Miembro FROM Miembros WHERE Cedula = @Cedula";
                    SqlCommand cmdMiembro = new SqlCommand(queryMiembro, conn);
                    cmdMiembro.Parameters.AddWithValue("@Cedula", cedula);
                    int idMiembro = (int)cmdMiembro.ExecuteScalar();

                    // Ejecutar el procedimiento almacenado para registrar el pago
                    string queryPago = "EXEC sp_RegistrarPago @ID_Miembro, @ID_Cuota, @MontoPago, @FechaPago";
                    SqlCommand cmdPago = new SqlCommand(queryPago, conn);
                    cmdPago.Parameters.AddWithValue("@ID_Miembro", idMiembro);
                    cmdPago.Parameters.AddWithValue("@ID_Cuota", idCuota);
                    cmdPago.Parameters.AddWithValue("@MontoPago", montoPago);
                    cmdPago.Parameters.AddWithValue("@FechaPago", fechaPago);

                    cmdPago.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Pago registrado correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnguardaraportes_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los controles del formulario
            string cedula = txtCedulaAportes.Text;
            decimal montoAporte = decimal.Parse(txtmontoaportes.Text);

            string conexion = "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();

                    // Obtener el ID del miembro basado en la cédula
                    string queryMiembro = "SELECT ID_Miembro FROM Miembros WHERE Cedula = @Cedula";
                    SqlCommand cmdMiembro = new SqlCommand(queryMiembro, conn);
                    cmdMiembro.Parameters.AddWithValue("@Cedula", cedula);
                    int idMiembro = (int)cmdMiembro.ExecuteScalar();

                    // Ejecutar el procedimiento almacenado para registrar el aporte
                    string queryAporte = "EXEC sp_RegistrarAporte @ID_Miembro, @Monto";
                    SqlCommand cmdAporte = new SqlCommand(queryAporte, conn);
                    cmdAporte.Parameters.AddWithValue("@ID_Miembro", idMiembro);
                    cmdAporte.Parameters.AddWithValue("@Monto", montoAporte);

                    cmdAporte.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Aporte registrado correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el aporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            FrmMostraPorMiembro frmMostraPorMiembro = new FrmMostraPorMiembro();
            frmMostraPorMiembro.ShowDialog();
        }

        private void btnbuscarpr_Click(object sender, EventArgs e)
        {
            FrmMostraPorMiembro frmMostraPorMiembro = new FrmMostraPorMiembro();
            frmMostraPorMiembro.ShowDialog();
        }

        private void btnbuscarpagos_Click(object sender, EventArgs e)
        {
            FrmMostraPorMiembro frmMostraPorMiembro = new FrmMostraPorMiembro();
            frmMostraPorMiembro.ShowDialog();
        }

        private void btnbuscaraportes_Click(object sender, EventArgs e)
        {
            FrmMostraPorMiembro frmMostraPorMiembro = new FrmMostraPorMiembro();
            frmMostraPorMiembro.ShowDialog();
        }
    }
}












