using Datos.Admin;
using Datos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowssEF
{
    public partial class FrmMedico : Form
    {
        public FrmMedico()
        {
            InitializeComponent();
            llenarComboEspecialidad();
            llenarComboBuscar();
        }

        private void FrmMedico_Load(object sender, EventArgs e)
        {
            mostrarMedicos();
        }
        private void mostrarMedicos()
        {
            gridMedico.DataSource = AdmMedico.Listar();
        }
        private void llenarComboEspecialidad()
        {
            List<Especialidad> especialidades = AdmEspecialidad.Listar();
            cbEspecialidad.DataSource = especialidades;
            cbEspecialidad.DisplayMember = "Nombre";
            cbEspecialidad.ValueMember = "Id";

        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Matricula = Convert.ToInt32(txtMatricula.Text),
                EspecialidadId = Convert.ToInt32(cbEspecialidad.SelectedValue)
            };
            int filasAfectadas = AdmMedico.Insertar(medico);
            if (filasAfectadas > 0)
            {
                mostrarMedicos();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            AdmMedico.Eliminar(Convert.ToInt32(txtId.Text));
            mostrarMedicos();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Medico medicoModificado = new Medico()
            {
                MedicoId = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Matricula = int.Parse(txtMatricula.Text),
                EspecialidadId = (int)cbEspecialidad.SelectedValue
            };
            int filasAfectadas = AdmMedico.Modificar(medicoModificado);
            if(filasAfectadas > 0)
            {
                mostrarMedicos();
            }
        }
        private void cbBuscar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int especialidadId = Convert.ToInt32(cbBuscar.SelectedValue);
            if(especialidadId == 0)
            {
                mostrarMedicos();
            } else
            {
                gridMedico.DataSource = AdmMedico.ListarEspecilidadId(especialidadId);
            }
        }
        private void llenarComboBuscar()
        {
            List<Especialidad> especialidades = AdmEspecialidad.Listar();
            especialidades.Insert(0, new Especialidad()
            {
                Id = 0,
                Nombre = "Todas"
            });
            cbBuscar.DataSource = especialidades;
            cbBuscar.DisplayMember = "Nombre";
            cbBuscar.ValueMember = "Id";
        }
    }
}
