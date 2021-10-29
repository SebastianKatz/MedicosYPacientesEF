using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Models;
using Datos.Admin;

namespace WindowssEF
{
    public partial class FrmPaciente : Form
    {
        public FrmPaciente()
        {
            InitializeComponent();
        }

        private void FrmPaciente_Load(object sender, EventArgs e)
        {
            TraerPacientes();
            
        }
        private void TraerPacientes()
        {
            gridPaciente.DataSource = AdmPaciente.Listar();
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente() { Nombre = "Sebastian", Apellido = "Katz", fechaNacimiento = new DateTime(1999, 01, 12), NroHistoriaClinica = 111, MedicoId = 1 };
            int filasAfectadas = AdmPaciente.Insertar(paciente);
            if (filasAfectadas > 0) {
                TraerPacientes();
            }
        }
    }
}
