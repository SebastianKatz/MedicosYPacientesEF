using Datos.Data;
using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Admin
{
    public static class AdmEspecialidad
    {
        static DbClinicaContext context = new DbClinicaContext();

        public static List<Especialidad> Listar()
        {
            return context.Especialidades.ToList(); // retornamos todos los pacientes
        }
        public static int Insertar(Especialidad especialidad)
        {
            context.Especialidades.Add(especialidad);
            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;
        }
        public static int Modificar(Especialidad especialidad)
        {
            Medico especialidadOrigen = context.Medicos.Find(especialidad.Id);
            if (especialidadOrigen != null)
            {
                especialidadOrigen.Nombre = especialidad.Nombre;
                especialidadOrigen.MedicoId = especialidad.Id;
                return context.SaveChanges();
            }
            return 0;
        }
        public static Especialidad TraerPorId(int id)
        {
            return context.Especialidades.Find(id);
        }
    }
}
