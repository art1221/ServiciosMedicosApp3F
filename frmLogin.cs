using ServiciosMedicosLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiciosMedicosApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var usuarioDAO = new UsuarioDAO();
            var user = usuarioDAO.ValidarLogin(txtUsuario.Text, txtClave.Text);
            if(user != null)
            {
                frmPrincipal f = new frmPrincipal(user);
                f.FormClosed += (s, args) => Program.loginForm.Show();
                this.Hide();
                f.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}
