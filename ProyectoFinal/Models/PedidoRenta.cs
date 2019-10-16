using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class PedidoRenta
    {

        public enum RentaEstado
        {
            Liberado,
            Rentado,
            Inspeccion
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int ProcesoId { get; set; }
        [Required]
        public String MatriculaVehiculo { get; set; }
        [Required]
        public int MontoFactura { get; set; }
        [Required]
        public String CodeCliente { get; set; }
        [Required]
        public String FechaSalida { get; set; }
        [Required]
        public String FechaEntrada { get; set; }

        [Required]
        public int EmpleadoAsignado { get; set; }

        [Required]
        public RentaEstado Estado { get; set; }

    }
}
