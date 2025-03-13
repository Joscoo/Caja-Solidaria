using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;

namespace Caja_Solidaria
{
    public partial class Form2 : Form
    {

        string cedula, nombres, correo, fechaRegistro;

        public Form2()
        {
            InitializeComponent();
        }

        // Propiedad estática para la cadena de conexión
        public static string ConexionString
        {
            get
            {
                return "Data Source = JOSE-BONILLA\\SQLEXPRESS; Initial Catalog = CajaSolidaria; Integrated Security = True";
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CargarMiembros(); // Cargar los miembros al iniciar
            CargarPrestamos(); // Cargar los préstamos al iniciar
            CargarCuotas(); // Cargar las cuotas al iniciar
            CargarPagos(); // Cargar los pagos al iniciar
            CargarAportes(); // Cargar los aportes al iniciar

            // Establecer la fecha máxima para el DateTimePicker
            dtpfecharegistro.MaxDate = DateTime.Today;
            txtcedula.Focus();
        }

        private void ConfigurarColumnasDataGridView(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Configurar la altura de las filas para que llenen todo el espacio del DataGridView
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void CargarMiembros()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConexionString))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    ID_Miembro, 
                    Cedula, 
                    Nombre, 
                    Correo, 
                    FechaRegistro 
                FROM Miembros
                ORDER BY FechaRegistro DESC;"; // Ordena del más reciente al más antiguo

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asignar el DataTable al DataGridView
                        dgvtablamiembros.DataSource = dataTable;
                    }
                }

                // Aplicar configuración a las columnas del DataGridView
                ConfigurarColumnasDataGridView(dgvtablamiembros);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los miembros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarPrestamos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConexionString))
                {
                    conn.Open();

                    // Consulta mejorada con más información de los préstamos
                    string query = @"
                SELECT 
                    m.Cedula,
                    m.Nombre AS NombreMiembro,
                    p.ID_Prestamo,
                    p.Monto,
                    p.FechaInicio,
                    p.FechaFin,
                    p.Estado,
                    p.TasaInteres,
                    p.Cuotas,
                    p.InteresTotal,
                    p.MontoTotal,
                    p.DiaPago
                FROM Miembros m
                JOIN Prestamos p ON p.ID_Miembro = m.ID_Miembro";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Asignar el DataTable como fuente de datos del DataGridView
                    dgvtablaprestamos.DataSource = dataTable;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los préstamos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCuotas()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConexionString))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    m.Cedula,
                    m.Nombre AS NombreMiembro,
                    p.ID_Prestamo,
                    p.Monto AS MontoPrestamo,
                    p.FechaInicio AS FechaInicioPrestamo,
                    p.FechaFin AS FechaFinPrestamo,
                    p.Estado AS EstadoPrestamo,
                    c.ID_Cuota,
                    c.Monto AS MontoCuota,
                    c.FechaVencimiento,
                    c.Estado AS EstadoCuota
                FROM Miembros m
                INNER JOIN Prestamos p ON m.ID_Miembro = p.ID_Miembro
                INNER JOIN Cuotas c ON p.ID_Prestamo = c.ID_Prestamo
                ORDER BY m.Cedula, p.ID_Prestamo, c.FechaVencimiento;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asignar el DataTable al DataGridView
                        dgvCuotas.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las cuotas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarPagos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConexionString))
                {
                    conn.Open();

                    string query = @"
            SELECT 
                m.Cedula, 
                m.Nombre AS NombreMiembro, 
                pr.ID_Prestamo,
                pr.Monto AS MontoPrestamo, 
                pr.Estado AS EstadoPrestamo, 
                c.ID_Cuota, 
                c.Monto AS MontoCuota, 
                c.FechaVencimiento, 
                c.Estado AS EstadoCuota, 
                ISNULL(p.MontoPago, 0) AS MontoPago, 
                p.FechaPago,
                CASE 
                    WHEN c.Estado = 'Pagado' THEN 'Pagado' 
                    ELSE 'Pendiente' 
                END AS PagoRealizado  
            FROM Miembros m
            JOIN Prestamos pr ON pr.ID_Miembro = m.ID_Miembro
            JOIN Cuotas c ON c.ID_Prestamo = pr.ID_Prestamo
            LEFT JOIN Pagos p ON p.ID_Cuota = c.ID_Cuota  
            ORDER BY m.Cedula, pr.ID_Prestamo, c.FechaVencimiento;";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Asignar el DataTable como fuente de datos del DataGridView
                    dgvtablapagos.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pagos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void CargarAportes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConexionString))
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



        private void btnguardarmiembros_Click(object sender, EventArgs e)
        {
            string cedula = txtcedula.Text;
            string nombre = txtnombre.Text;
            string correo = txtcorreo.Text;
            string fechaRegistro = dtpfecharegistro.Value.ToString("yyyy-MM-dd");

            if (nombre != "Ingrese su nombre completo")
            {
                try
                {
                    if (estaEnBlanco(txtcedula))
                    {
                        throw new Exception("La cédula no puede estar en blanco");
                    }
                    if (estaEnBlanco(txtnombre))
                    {
                        throw new Exception("El nombre no puede estar en blanco");
                    }
                    if (estaEnBlanco(txtcorreo))
                    {
                        correo = "Sin correo";
                    }

                    using (SqlConnection conn = new SqlConnection(ConexionString))
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
        }


        private void btnguardarpr_Click(object sender, EventArgs e)
        {
            // Obtener los valores del formulario
            string cedula = txtCedulaPr.Text;
            decimal monto = decimal.Parse(txtmonto.Text);
            string fechaInicio = dtpfechainicio.Value.ToString("yyyy-MM-dd");
            string estado = cmbestado.SelectedItem.ToString();
            int cuotas = int.Parse(cmbCuotas.SelectedItem.ToString()); // Obtener cuotas (6, 12, 24, 36)
            int diaPago = int.Parse(txtDiaPago.Text); // Obtener día de pago (1 - 28)
            decimal tasaInteres = decimal.Parse(txtInteres.Text);

            try
            {
                using (SqlConnection conn = new SqlConnection(ConexionString))
                {
                    conn.Open();

                    // Obtener el ID del miembro basado en la cédula
                    string queryMiembro = "SELECT ID_Miembro FROM Miembros WHERE Cedula = @Cedula";
                    SqlCommand cmdMiembro = new SqlCommand(queryMiembro, conn);
                    cmdMiembro.Parameters.AddWithValue("@Cedula", cedula);
                    object result = cmdMiembro.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("No se encontró un miembro con esa cédula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int idMiembro = (int)result;

                    // Ejecutar el procedimiento almacenado con los nuevos parámetros
                    string queryPrestamo = "EXEC sp_RegistrarPrestamo @ID_Miembro, @Monto, @FechaInicio, @Cuotas, @DiaPago, @TasaInteres";
                    SqlCommand cmdPrestamo = new SqlCommand(queryPrestamo, conn);
                    cmdPrestamo.Parameters.AddWithValue("@ID_Miembro", idMiembro);
                    cmdPrestamo.Parameters.AddWithValue("@Monto", monto);
                    cmdPrestamo.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmdPrestamo.Parameters.AddWithValue("@Cuotas", cuotas);
                    cmdPrestamo.Parameters.AddWithValue("@DiaPago", diaPago);
                    cmdPrestamo.Parameters.AddWithValue("@TasaInteres", tasaInteres);

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


        private void btnConsultarCuotas_Click(object sender, EventArgs e)
        {
            string cedula = txtCedulaC.Text.Trim();
            string idPrestamoTexto = txtIdPrestamoC.Text.Trim();

            // Validar que al menos uno de los filtros esté presente
            if (string.IsNullOrEmpty(cedula) && string.IsNullOrEmpty(idPrestamoTexto))
            {
                MessageBox.Show("Ingrese una cédula o un ID de préstamo para consultar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPrestamo = 0;
            if (!string.IsNullOrEmpty(idPrestamoTexto) && !int.TryParse(idPrestamoTexto, out idPrestamo))
            {
                MessageBox.Show("El ID del préstamo debe ser un número válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConexionString))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    c.ID_Cuota,
                    m.Cedula,
                    m.Nombre AS NombreMiembro,
                    p.ID_Prestamo,
                    c.Monto AS MontoCuota,
                    c.FechaVencimiento,
                    c.Estado
                FROM Cuotas c
                INNER JOIN Prestamos p ON c.ID_Prestamo = p.ID_Prestamo
                INNER JOIN Miembros m ON p.ID_Miembro = m.ID_Miembro
                WHERE (@Cedula IS NULL OR m.Cedula = @Cedula)
                  AND (@ID_Prestamo IS NULL OR p.ID_Prestamo = @ID_Prestamo)
                ORDER BY c.FechaVencimiento ASC;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Cedula", string.IsNullOrEmpty(cedula) ? (object)DBNull.Value : cedula);
                        cmd.Parameters.AddWithValue("@ID_Prestamo", idPrestamo == 0 ? (object)DBNull.Value : idPrestamo);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asignar el DataTable al DataGridView
                        dgvCuotas.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar las cuotas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnguardarpagos_Click(object sender, EventArgs e)
        {
            string cedula = txtCedulaPagos.Text.Trim();
            string fechaPago = dtpfechapagos.Value.ToString("yyyy-MM-dd");

            if (!int.TryParse(txtidcuota.Text, out int idCuota))
            {
                MessageBox.Show("Ingrese un ID de cuota válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConexionString))
                {
                    conn.Open();

                    string queryMiembro = "SELECT ID_Miembro FROM Miembros WHERE Cedula = @Cedula";
                    using (SqlCommand cmdMiembro = new SqlCommand(queryMiembro, conn))
                    {
                        cmdMiembro.Parameters.AddWithValue("@Cedula", cedula);
                        object result = cmdMiembro.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("No se encontró un miembro con esta cédula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        int idMiembro = Convert.ToInt32(result);

                        // Registrar el pago de la cuota
                        string queryPago = "EXEC sp_RegistrarPago @ID_Miembro, @ID_Cuota, @FechaPago";
                        using (SqlCommand cmdPago = new SqlCommand(queryPago, conn))
                        {
                            cmdPago.Parameters.AddWithValue("@ID_Miembro", idMiembro);
                            cmdPago.Parameters.AddWithValue("@ID_Cuota", idCuota);
                            cmdPago.Parameters.AddWithValue("@FechaPago", fechaPago);

                            // ✅ En lugar de verificar "rowsAffected", verificamos si la cuota está realmente pagada
                            cmdPago.ExecuteNonQuery();

                            // ✅ Verificar si la cuota cambió a estado "Pagado"
                            string verificarPago = "SELECT Estado FROM Cuotas WHERE ID_Cuota = @ID_Cuota";
                            using (SqlCommand cmdVerificar = new SqlCommand(verificarPago, conn))
                            {
                                cmdVerificar.Parameters.AddWithValue("@ID_Cuota", idCuota);
                                string estadoCuota = cmdVerificar.ExecuteScalar()?.ToString();

                                if (estadoCuota == "Pagado")
                                {
                                    MessageBox.Show("Pago de cuota registrado correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CargarPagos(); // ✅ Actualiza la tabla después del pago
                                }
                                else
                                {
                                    MessageBox.Show("El pago se procesó, pero la cuota no cambió a 'Pagado'. Verifique la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("El ID de cuota ingresado no existe.", "Error de clave foránea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el pago de la cuota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnguardaraportes_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los controles del formulario
            string cedula = txtCedulaAportes.Text;
            decimal montoAporte = decimal.Parse(txtmontoaportes.Text);

            try
            {
                using (SqlConnection conn = new SqlConnection(ConexionString))
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



        private void txtcedula_Enter(object sender, EventArgs e)
        {
            txtcedula.Text = "";
        }

        private void txtcedula_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(e.KeyChar == (char)Keys.Enter){
                    if (estaEnBlanco(txtcedula))
                    {
                        throw new Exception("La cédula no puede estar en blanco");
                    }

                    if (txtcedula.Text.Length != 10)
                    {
                        throw new Exception("La cédula debe tener 10 dígitos");
                    }
                    if (soloNumeros(txtcedula))
                    {
                        throw new Exception("La cédula debe contener solo números");
                    }

                    e.Handled = true;
                    cedula = txtcedula.Text;
                    txtnombre.Focus();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtcedula.Text = "";
                txtcedula.Focus();
            }

        }



        private void txtnombre_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (estaEnBlanco(txtnombre))
                    {
                        throw new Exception("El nombre no puede estar en blanco");
                    }

                    if (soloLetrasEspacios(txtnombre))
                    {
                        throw new Exception("El nombre debe contener solo letras");
                    }

                    e.Handled = true;
                    nombres = txtnombre.Text;
                    txtcorreo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtcorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (estaEnBlanco(txtcorreo))
                    {
                        e.Handled = true;
                        correo = "Sin correo";
                        dtpfecharegistro.Focus();
                    }
                    else if (!esCorreoValido(txtcorreo.Text))
                    {
                        throw new Exception("Debe ingresar un correo valido");
                    }

                    e.Handled = true;
                    correo = txtcorreo.Text;
                    dtpfecharegistro.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpfecharegistro_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                fechaRegistro = dtpfecharegistro.Value.ToString("yyyy-MM-dd");
                btnguardarmiembros.PerformClick();

            }
            catch
            {
                MessageBox.Show("Error: La fecha no puede ser mayor a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtnombre_Enter(object sender, EventArgs e)
        {
            txtnombre.Text = "";
        }

        private void txtcorreo_Enter(object sender, EventArgs e)
        {
            txtcorreo.Text = "";
        }

        private void btnLogOutC_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }




        private void frmPanelPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }


        private void btnLogOutPre_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btnLogOutPagos_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btnMostrarTodoNuevamente_Click(object sender, EventArgs e)
        {
            CargarCuotas();
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

        private bool estaEnBlanco(TextBox texto)  // Método para verificar si un campo de texto está en blanco
        {
            return string.IsNullOrEmpty(texto.Text);  // Devolver si el campo de texto está vacío
        }



        private bool esCorreoValido(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }

        private bool soloLetrasEspacios(TextBox texto)
        {
            foreach (char c in texto.Text)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return true;
                }
            }
            return false;
        }

        private bool soloNumeros(TextBox texto)
        {
            foreach (char c in texto.Text)
            {
                if (!char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

