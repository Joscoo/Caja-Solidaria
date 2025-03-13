namespace Caja_Solidaria
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlinformacion = new System.Windows.Forms.Panel();
            this.btnMostrarOcultarContraseña = new System.Windows.Forms.Button();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.txtcontraseña = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblbienvenida = new System.Windows.Forms.Label();
            this.pcblogo = new System.Windows.Forms.PictureBox();
            this.pnlInterfaz = new System.Windows.Forms.Panel();
            this.pnlinformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcblogo)).BeginInit();
            this.pnlInterfaz.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlinformacion
            // 
            this.pnlinformacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(182)))));
            this.pnlinformacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlinformacion.Controls.Add(this.btnMostrarOcultarContraseña);
            this.pnlinformacion.Controls.Add(this.lblContraseña);
            this.pnlinformacion.Controls.Add(this.lblUsuario);
            this.pnlinformacion.Controls.Add(this.btnIniciarSesion);
            this.pnlinformacion.Controls.Add(this.txtusuario);
            this.pnlinformacion.Controls.Add(this.txtcontraseña);
            this.pnlinformacion.Controls.Add(this.btnSalir);
            this.pnlinformacion.Location = new System.Drawing.Point(6, 245);
            this.pnlinformacion.Name = "pnlinformacion";
            this.pnlinformacion.Size = new System.Drawing.Size(572, 210);
            this.pnlinformacion.TabIndex = 8;
            // 
            // btnMostrarOcultarContraseña
            // 
            this.btnMostrarOcultarContraseña.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMostrarOcultarContraseña.BackgroundImage")));
            this.btnMostrarOcultarContraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMostrarOcultarContraseña.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarOcultarContraseña.Location = new System.Drawing.Point(424, 114);
            this.btnMostrarOcultarContraseña.MaximumSize = new System.Drawing.Size(27, 27);
            this.btnMostrarOcultarContraseña.MinimumSize = new System.Drawing.Size(27, 27);
            this.btnMostrarOcultarContraseña.Name = "btnMostrarOcultarContraseña";
            this.btnMostrarOcultarContraseña.Size = new System.Drawing.Size(27, 27);
            this.btnMostrarOcultarContraseña.TabIndex = 3;
            this.btnMostrarOcultarContraseña.UseVisualStyleBackColor = true;
            this.btnMostrarOcultarContraseña.Click += new System.EventHandler(this.btnMostrarOcultarContraseña_Click);
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseña.Location = new System.Drawing.Point(121, 90);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(97, 19);
            this.lblContraseña.TabIndex = 7;
            this.lblContraseña.Text = "Contraseña:";
            this.lblContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(121, 30);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(70, 19);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion.Location = new System.Drawing.Point(208, 153);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(160, 35);
            this.btnIniciarSesion.TabIndex = 4;
            this.btnIniciarSesion.Text = "&Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // txtusuario
            // 
            this.txtusuario.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusuario.Location = new System.Drawing.Point(125, 53);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(326, 27);
            this.txtusuario.TabIndex = 1;
            this.txtusuario.Text = "Ingrese su usuario";
            this.txtusuario.Enter += new System.EventHandler(this.txtusuario_Enter_1);
            this.txtusuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtusuario_KeyPress);
            // 
            // txtcontraseña
            // 
            this.txtcontraseña.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontraseña.Location = new System.Drawing.Point(125, 114);
            this.txtcontraseña.Name = "txtcontraseña";
            this.txtcontraseña.Size = new System.Drawing.Size(293, 27);
            this.txtcontraseña.TabIndex = 2;
            this.txtcontraseña.Text = "Ingrese su contraseña";
            this.txtcontraseña.Enter += new System.EventHandler(this.txtcontraseña_Enter_1);
            this.txtcontraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcontraseña_KeyPress);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(481, 170);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(86, 35);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblbienvenida
            // 
            this.lblbienvenida.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblbienvenida.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbienvenida.Location = new System.Drawing.Point(0, 0);
            this.lblbienvenida.Name = "lblbienvenida";
            this.lblbienvenida.Size = new System.Drawing.Size(584, 33);
            this.lblbienvenida.TabIndex = 1;
            this.lblbienvenida.Text = "Bievenido/a a Semillas de Ahorro!";
            this.lblbienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pcblogo
            // 
            this.pcblogo.BackColor = System.Drawing.Color.Transparent;
            this.pcblogo.Image = ((System.Drawing.Image)(resources.GetObject("pcblogo.Image")));
            this.pcblogo.Location = new System.Drawing.Point(197, 39);
            this.pcblogo.Name = "pcblogo";
            this.pcblogo.Size = new System.Drawing.Size(200, 200);
            this.pcblogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcblogo.TabIndex = 6;
            this.pcblogo.TabStop = false;
            // 
            // pnlInterfaz
            // 
            this.pnlInterfaz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(121)))));
            this.pnlInterfaz.Controls.Add(this.pcblogo);
            this.pnlInterfaz.Controls.Add(this.pnlinformacion);
            this.pnlInterfaz.Controls.Add(this.lblbienvenida);
            this.pnlInterfaz.Location = new System.Drawing.Point(0, 0);
            this.pnlInterfaz.Name = "pnlInterfaz";
            this.pnlInterfaz.Size = new System.Drawing.Size(584, 464);
            this.pnlInterfaz.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.pnlInterfaz);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesión";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlinformacion.ResumeLayout(false);
            this.pnlinformacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcblogo)).EndInit();
            this.pnlInterfaz.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlinformacion;
        private System.Windows.Forms.TextBox txtusuario;
        private System.Windows.Forms.Label lblbienvenida;
        private System.Windows.Forms.TextBox txtcontraseña;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pcblogo;
        private System.Windows.Forms.Panel pnlInterfaz;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnMostrarOcultarContraseña;
    }
}

