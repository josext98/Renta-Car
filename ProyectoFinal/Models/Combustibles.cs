using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Combustibles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int TipoId { get; set; }
        public String Descripcion { get; set; }
        public int Estado { get; set; }
    }
}