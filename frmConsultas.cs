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
    public partial class frmConsultas : Form
    {
        public frmConsultas()
        {
            InitializeComponent();
        }

        private void CargarEstudiantes()
        {
            cmbEstudiantes.Items.Clear();
            var dao = new EstudianteDAO();
            var lista = dao.ObtenerTodos();
            foreach(var est in lista)
            {
                cmbEstudiantes.Items.Add(est);
            }
            cmbEstudiantes.DisplayMember = "Nombre";
            cmbEstudiantes.ValueMember = "IdEstudiante";
        }

        private void frmConsultas_Load(object sender, EventArgs e)
        {
            dgvConsultas.Columns.Clear();
            dgvConsultas.Columns.Add("Id", "ID");
            dgvConsultas.Columns.Add("Estudiante", "Estudiante");
            dgvConsultas.Columns.Add("Fecha", "Fecha");
            dgvConsultas.Columns.Add("Diagnostico", "Diagnostico");
            dgvConsultas.Columns.Add("Tratamiento", "Tratamiento");
            dgvConsultas.Columns.Add("Justifica", "Justifica Falta");
            CargarEstudiantes();
            CargarConsultas();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(cmbEstudiantes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un estudiante");
                return;
            }
            var estudiante = (Estudiante)cmbEstudiantes.SelectedItem;
            var consulta = new ConsultaMedica
            {
                IdEstudiante = estudiante.IdEstudiante,
                Fecha = dtpFecha.Value,
                Diagnostico = txtDiagnostico.Text.Trim(),
                Tratamiento = txtTratamiento.Text.Trim(),
                JustificaFalta = chkJustificaFalta.Checked
            };
            new ConsultaMedicaDAO().Insertar(consulta);
            MessageBox.Show("Consulta Mèdica registrada");
            CargarConsultas();
        }
        private void CargarConsultas()
        {
            dgvConsultas.Rows.Clear();
            var dao = new ConsultaMedicaDAO();
            var lista = dao.ObtenerTodasConEstudiantes();
            foreach(var c in lista)
            {
                dgvConsultas.Rows.Add(c.IdConsulta,c.NombreEstudiante,c.Fecha.ToShortDateString(),c.Diagnostico,c.Tratamiento,c.JustificaFalta ? "Si":"No");
            }
        }
    }
}
