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
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.lblbienvenida = new System.Windows.Forms.Label();
            this.txtcontraseña = new System.Windows.Forms.TextBox();
            this.btniniciar = new System.Windows.Forms.Button();
            this.pcblogo = new System.Windows.Forms.PictureBox();
            this.pnlInterfaz = new System.Windows.Forms.Panel();
            this.pnlinformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcblogo)).BeginInit();
            this.pnlInterfaz.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlinformacion
            // 
            this.pnlinformacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pnlinformacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlinformacion.Controls.Add(this.txtusuario);
            this.pnlinformacion.Controls.Add(this.lblbienvenida);
            this.pnlinformacion.Controls.Add(this.txtcontraseña);
            this.pnlinformacion.Controls.Add(this.btniniciar);
            this.pnlinformacion.Location = new System.Drawing.Point(25, 248);
            this.pnlinformacion.Name = "pnlinformacion";
            this.pnlinformacion.Size = new System.Drawing.Size(536, 194);
            this.pnlinformacion.TabIndex = 8;
            // 
            // txtusuario
            // 
            this.txtusuario.Location = new System.Drawing.Point(96, 64);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(326, 21);
            this.txtusuario.TabIndex = 2;
            // 
            // lblbienvenida
            // 
            this.lblbienvenida.AutoSize = true;
            this.lblbienvenida.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbienvenida.Location = new System.Drawing.Point(64, 8);
            this.lblbienvenida.Name = "lblbienvenida";
            this.lblbienvenida.Size = new System.Drawing.Size(425, 33);
            this.lblbienvenida.TabIndex = 1;
            this.lblbienvenida.Text = "Bievenido/a a Semillas de Ahorro!";
            this.lblbienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtcontraseña
            // 
            this.txtcontraseña.Location = new System.Drawing.Point(104, 112);
            this.txtcontraseña.Name = "txtcontraseña";
            this.txtcontraseña.Size = new System.Drawing.Size(326, 21);
            this.txtcontraseña.TabIndex = 3;
            // 
            // btniniciar
            // 
            this.btniniciar.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btniniciar.Location = new System.Drawing.Point(190, 144);
            this.btniniciar.Name = "btniniciar";
            this.btniniciar.Size = new System.Drawing.Size(160, 35);
            this.btniniciar.TabIndex = 4;
            this.btniniciar.Text = "Iniciar Sesión";
            this.btniniciar.UseVisualStyleBackColor = true;
            this.btniniciar.Click += new System.EventHandler(this.btniniciar_Click);
            // 
            // pcblogo
            // 
            this.pcblogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(79)))));
            this.pcblogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcblogo.Image = ((System.Drawing.Image)(resources.GetObject("pcblogo.Image")));
            this.pcblogo.Location = new System.Drawing.Point(200, 8);
            this.pcblogo.Name = "pcblogo";
            this.pcblogo.Size = new System.Drawing.Size(200, 200);
            this.pcblogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcblogo.TabIndex = 6;
            this.pcblogo.TabStop = false;
            this.pcblogo.Click += new System.EventHandler(this.pcblogo_Click);
            // 
            // pnlInterfaz
            // 
            this.pnlInterfaz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(79)))));
            this.pnlInterfaz.Controls.Add(this.pcblogo);
            this.pnlInterfaz.Controls.Add(this.pnlinformacion);
            this.pnlInterfaz.Location = new System.Drawing.Point(0, 0);
            this.pnlInterfaz.Name = "pnlInterfaz";
            this.pnlInterfaz.Size = new System.Drawing.Size(584, 464);
            this.pnlInterfaz.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.ControlBox = false;
            this.Controls.Add(this.pnlInterfaz);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private System.Windows.Forms.Button btniniciar;
        private System.Windows.Forms.PictureBox pcblogo;
        private System.Windows.Forms.Panel pnlInterfaz;
    }
}

