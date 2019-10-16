using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Empleados
    {
        public enum Status
        {
            Activo,
            Despedido,
            Eliminado
        }

        public enum Tanda
        {
            Mañana,
            Tarde,
            Noche
        }

        public enum EstadoE
        {
            Activo,
            Incativo
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int EmpleadoId { get; set; }
        [Required]
        public String Nombre { get; set; }
        [Required]
        public String Cedula { get; set; }

        [Required]
        public DateTime FechaIngreso { get; set; }
        [Required]
        public EstadoE Estado { get; set; }

        [Required]
        public Tanda TandaLabor { get; set; }
    }
}