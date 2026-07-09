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
    public partial class frmPrincipal : Form
    {
        private Usuario usuarioActual;
        public frmPrincipal(ServiciosMedicosLib.Usuario user)
        {
            InitializeComponent();
            usuarioActual = user;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = $"Bienvenido: {usuarioActual.Nombreusuario} ({usuarioActual.Rol})";
        }
    }
}
