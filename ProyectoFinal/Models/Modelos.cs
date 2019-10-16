using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Modelos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int ModelosId { get; set; }

        [Required, Display(Name = "Modelos")]
        public String ModelosName { get; set; }

        public int? MarcaId { get; set; }
        public Marcas Marca { get; set; }

    }
}