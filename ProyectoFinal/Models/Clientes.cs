using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Clientes
    {
        public enum PesonaType
        {
            Fisica,
            Juridica,
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int PersonaId { get; set; }
        [Required]
        public String Nombre { get; set; }

        [Required, Display(Name = "Cedula/RNC")]
        public String Cedula { get; set; }
        [Required]
        public String Telefono { get; set; }

        [Required, MaxLength(16, ErrorMessage ="No puede contener mas de 16 caracteres numericos"), MinLength(16, ErrorMessage = "No debe contener menos de 16 caracteres numericos")]
        public String NoTarjetaCr { get; set; }

        [Required]
        public int LímiteCredito { get; set; }

        [Required]
        public PesonaType TipoPersona { get; set; }

        [Required, EmailAddress(ErrorMessage ="Correo Invalido")]
        public String Email { get; set; }
    }
}