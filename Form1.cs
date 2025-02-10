using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caja_Solidaria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtusuario_Enter(object sender, EventArgs e)
        {
            if (txtusuario.Text == "Usuario")
            {
                txtusuario.Text = "";
                txtusuario.ForeColor = Color.Black;
            }
        }

        private void txtusuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusuario.Text))
            {
                txtusuario.Text = "Usuario";
                txtusuario.ForeColor = Color.Gray;
            }
        }

        private void txtcontraseña_Enter(object sender, EventArgs e)
        {
            if (txtcontraseña.Text == "Contraseña")
            {
                txtcontraseña.Text = "";
                txtcontraseña.ForeColor = Color.Black;
                txtcontraseña.UseSystemPasswordChar = true; // Hacerlo de tipo contraseña
            }
        }

        private void txtcontraseña_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcontraseña.Text))
            {
                txtcontraseña.Text = "Contraseña";
                txtcontraseña.ForeColor = Color.Gray;
                txtcontraseña.UseSystemPasswordChar = false; // Mostrar texto plano
            }
        }


        private void btniniciar_Click(object sender, EventArgs e)
        {
            // Verificar si los campos están vacíos
            if (string.IsNullOrWhiteSpace(txtusuario.Text) || string.IsNullOrWhiteSpace(txtcontraseña.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Lógica para iniciar sesión (puedes conectar con una base de datos aquí)
                MessageBox.Show("Bienvenido, " + txtusuario.Text + "!", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnlimagen2 frmfuncionalidad = new pnlimagen2();
                frmfuncionalidad.Show();
                
            }
        }

        private void lblregistrar_Click(object sender, EventArgs e)
        {
            //Abrir un formulario de registro
            //FrmRegistro frmRegistro = new FrmRegistro();
            //frmRegistro.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pcblogo_Click(object sender, EventArgs e)
        {

        }
    }
}
