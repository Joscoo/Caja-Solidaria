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
        string rutaImagen = "C:\\Cajas\\Caja Solidaria\\Imagenes\\";
        bool estaOculto = true; // Variable para saber si la contraseña está oculta
        string usuario, contraseña; // Variables para guardar el usuario y la contraseña

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            txtusuario.Focus(); // Enfocar el campo de usuario
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


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnMostrarOcultarContraseña_Click(object sender, EventArgs e)
        {
            if (estaOculto) // Si la contraseña está oculta
            {
                txtcontraseña.UseSystemPasswordChar = false; // Mostrar la contraseña
                estaOculto = false; // Cambiar el estado de la contraseña
                btnMostrarOcultarContraseña.BackgroundImage = Image.FromFile(rutaImagen + "mostrado.png"); // Cambiar la imagen del botón
            }
            else
            {
                txtcontraseña.UseSystemPasswordChar = true;  // Ocultar la contraseña
                estaOculto = true; // Cambiar el estado de la contraseña
                btnMostrarOcultarContraseña.BackgroundImage = Image.FromFile(rutaImagen + "oculto.png"); // Cambiar la imagen del botón
            }
        }

        private void txtusuario_Enter_1(object sender, EventArgs e)
        {
            txtusuario.Text = "";
        }

        private void txtcontraseña_Enter_1(object sender, EventArgs e)
        {
            txtcontraseña.Text = "";
            txtcontraseña.UseSystemPasswordChar = true;  // Ocultar la contraseñada
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (estaEnBlanco(txtusuario))  // Si el campo de usuario está vacío
                {
                    throw new Exception("El usuario no puede estar en blanco"); // Lanzar una excepción

                }
                if (estaEnBlanco(txtcontraseña))
                {
                    throw new Exception("La contraseña no puede estar en blanco");
                }
                else
                {
                    usuario = txtusuario.Text; // Guardar el usuario
                    contraseña = txtcontraseña.Text; // Guardar la contraseña

                    if (usuario == "admin" && contraseña == "admin") // Si el usuario y la contraseña son correctos
                    {
                        MessageBox.Show("Bienvenido " + usuario, "Inicio de sesión correcto", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mostrar mensaje de bienvenida
                        //Abrir un formulario de inicio

                        Form2 pnlimagen2 = new Form2();
                        pnlimagen2.Show();
                        this.Hide(); // Ocultar el formulario actual
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Mostrar mensaje de error
                        txtusuario.Text = "Usuario"; // Restablecer el texto del usuario
                        txtcontraseña.Text = "Contraseña"; // Restablecer el texto de la contraseña
                        txtusuario.Focus(); // Enfocar el campo de usuario
                        txtcontraseña.UseSystemPasswordChar = false;  // Mostrar la contraseñada

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13) // Si se presiona la tecla Enter
                {
                    if (estaEnBlanco(txtusuario)) // Si el campo de usuario está vacío
                    {
                        throw new Exception("El usuario no puede estar en blanco"); // Lanzar una excepción
                    }

                    e.Handled = true; // Manejar el evento

                    usuario = txtusuario.Text; // Guardar el usuario

                    txtcontraseña.Focus(); // Enfocar el campo de contraseña

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Mostrar un mensaje de error
            }
        }

        private void txtcontraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13) // Si se presiona la tecla Enter
                {
                    if (estaEnBlanco(txtcontraseña)) // Si el campo de usuario está vacío
                    {
                        throw new Exception("La contraseña no puede estar en blanco"); // Lanzar una excepción
                    }

                    e.Handled = true; // Manejar el evento

                    contraseña = txtcontraseña.Text; // Guardar la contraseña

                    btnIniciarSesion.PerformClick(); // Hacer clic en el botón de iniciar sesión

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Mostrar un mensaje de error
            }
        }

        private bool estaEnBlanco(TextBox texto)  // Método para verificar si un campo de texto está en blanco
        {
            return string.IsNullOrEmpty(texto.Text);  // Devolver si el campo de texto está vacío
        }
    }
}
