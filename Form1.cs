using ServiciosMedicosLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
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

            switch (usuarioActual.Rol)
            {
                case "admin":
                    CargarPestaña(new frmEstudiantes(), "Estudiantes");
                    CargarPestaña(new frmConsultas(), "Consultas Medicas");
                    CargarPestaña(new frmJustificaciones(), "Justificaciones");
                    break;
                case "enfermera":
                    CargarPestaña(new frmEstudiantes(), "Estudiantes");
                    CargarPestaña(new frmConsultas(), "Consultas Medicas");
                    break;
                case "docente":
                    CargarPestaña(new frmJustificaciones(), "Justificaciones");
                    break;
                case "estudiante":
                    CargarPestaña(new frmHistorial(), "Mihistorial Medico");
                    break;
            }
        }

        private void CargarPestaña(Form formHijo, string titulo)
        {
            TabPage nuevaPestaña = new TabPage(titulo);
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            nuevaPestaña.Controls.Add(formHijo);
            formHijo.Show();
            tabControlPrincipal.TabPages.Add(nuevaPestaña);
        }
    }
}
