using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class InspeccionTable
    {
        public enum EstadoTanque
        {
            Full, 
            Medio,
            Reserva,
            Vacio
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int id { get; set; }
        public String Matricula { get; set; }
        public EstadoTanque Combustible { get; set; }
        public Boolean Gomas { get; set; }
        public Boolean Puertas { get; set; }
        public Boolean Frenos { get; set; }
        public String EmpleadoInspector { get; set; }
        public String Cliente { get; set; }
        public DateTime Fecha_Proceso { get; set; }
        public String Comentario { get; set; }
    }
}