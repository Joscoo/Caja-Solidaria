namespace Caja_Solidaria
{
    partial class FrmMostrarTodo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblregistropr = new System.Windows.Forms.Label();
            this.dgvTodaInfo = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodaInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblregistropr
            // 
            this.lblregistropr.AutoSize = true;
            this.lblregistropr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregistropr.Location = new System.Drawing.Point(416, 9);
            this.lblregistropr.Name = "lblregistropr";
            this.lblregistropr.Size = new System.Drawing.Size(326, 24);
            this.lblregistropr.TabIndex = 1;
            this.lblregistropr.Text = "Información de todos los Usuarios";
            // 
            // dgvTodaInfo
            // 
            this.dgvTodaInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodaInfo.Location = new System.Drawing.Point(24, 48);
            this.dgvTodaInfo.Name = "dgvTodaInfo";
            this.dgvTodaInfo.Size = new System.Drawing.Size(1148, 564);
            this.dgvTodaInfo.TabIndex = 2;
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Location = new System.Drawing.Point(1062, 618);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(110, 31);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmMostrarTodo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvTodaInfo);
            this.Controls.Add(this.lblregistropr);
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "FrmMostrarTodo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMostrarTodo";
            this.Load += new System.EventHandler(this.FrmMostrarTodo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodaInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblregistropr;
        private System.Windows.Forms.DataGridView dgvTodaInfo;
        private System.Windows.Forms.Button btnSalir;
    }
}