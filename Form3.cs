using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPfinalProgramacion1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string contraseña = textBox2.Text;

            // Verifica las credenciales (puedes cambiar estas credenciales)
            if (usuario == "admin" && contraseña == "admin")
            {
                // Las credenciales son válidas, establece el resultado de DialogResult como OK
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Inténtalo de nuevo.");
            }
        }

    }
}
