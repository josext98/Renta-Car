using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Marcas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int MarcaId { get; set; }

        [Required, Display(Name = "Marca") ]
        public String MarcaName { get; set; }

        [NotMapped]
        public virtual ICollection<Modelos> MarcaList { get;set;}
    }
}