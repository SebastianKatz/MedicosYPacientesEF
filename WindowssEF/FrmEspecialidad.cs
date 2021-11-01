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
    public partial class FrmEspecialidad : Form
    {
        public FrmEspecialidad()
        {
            InitializeComponent();
        }

        private void FrmEspecialidad_Load(object sender, EventArgs e)
        {
            mostrarEspecialidades();
        }
        private void mostrarEspecialidades()
        {
            gridMedico.DataSource = AdmEspecialidad.Listar();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Especialidad especialidad = new Especialidad()
            {
                Nombre = txtEspecialidad.Text
            };
            int filasAfectadas = AdmEspecialidad.Insertar(especialidad);
            if (filasAfectadas > 0)
            {
                mostrarEspecialidades();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Especialidad especialidadModificada = new Especialidad()
            {
                Id = Convert.ToInt32(txtId.Text),
                Nombre = txtEspecialidad.Text
            };
            int filasAfectadas = AdmEspecialidad.Modificar(especialidadModificada);
            if (filasAfectadas > 0)
            {
                mostrarEspecialidades();
            }
        }

        private void btnTraer_Click(object sender, EventArgs e)
        {
            mostrarEspecialidades();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            AdmEspecialidad.Eliminar(Convert.ToInt32(txtId.Text));
            mostrarEspecialidades();
        }
    }
}
