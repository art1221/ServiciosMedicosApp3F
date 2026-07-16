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
    public partial class frmEstudiantes : Form
    {
        public frmEstudiantes()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var estudiante = new Estudiante
            { 
                Nombre = txtNombre.Text.Trim(),
                Matricula = txtMatricula.Text.Trim(),
                Carrera = txtCarrera.Text.Trim()

            };
            if(string.IsNullOrEmpty(estudiante.Nombre) || string.IsNullOrEmpty(estudiante.Matricula))
            {
                MessageBox.Show("Nombre y matricula obligatorios.");
                return;
            }
            var dao = new EstudianteDAO();
            dao.Insertar(estudiante);

            MessageBox.Show("Estudiante resgitrado correctamente");
            txtNombre.Clear();
            txtMatricula.Clear();
            txtCarrera.Clear();
            CargarEstudiantes();
        }

        private void CargarEstudiantes()
        {
            dgvEstudiantes.Rows.Clear();
            var dao = new EstudianteDAO();
            var lista = dao.ObtenerTodos();
            foreach (var est in lista)
            {
                dgvEstudiantes.Rows.Add(est.IdEstudiante, est.Nombre, est.Matricula, est.Carrera);
            }
        }

        private void frmEstudiantes_Load(object sender, EventArgs e)
        {
            dgvEstudiantes.Columns.Add("Id", "ID");
            dgvEstudiantes.Columns.Add("Nombre", "Nombre");
            dgvEstudiantes.Columns.Add("Matricula", "Matricula");
            dgvEstudiantes.Columns.Add("Carrera", "Carrera");
            CargarEstudiantes();
        }
    }
}
