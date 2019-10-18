using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Vehiculos
    {
        const String Value = "Matricula debe contener una cadena alfanumerica de 7 valores";

        public enum Status
        {
            Rentado,
            Disponible,
            Inspeccion,
            //Procesando
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Matricula"), MaxLength(7, ErrorMessage = Value), MinLength(7, ErrorMessage = Value)]
        public String NoChasis { get; set; }
        [Required]
        public String Descripción { get; set; }

        [DisplayName ("No. Placa")]
        [Required]
        public String NoPlaca { get; set; }
        [Required]

        public int? TipoVehiculoId { get; set; }
        public TipodeVehiculo TipoVehiculo { get; set; }
        [Required]

        public int? MarcaId { get; set; }
        public Marcas Marca { get; set; }
        [Required]

        public int? ModeloId { get; set; }
        public Modelos Modelo { get; set; }
        
        public int? TipoCombustibleId { get; set; }
        public Combustibles TipoCombustible { get; set; }

        [Required]
        public Status Estado { get; set; }

        #region Not Maped Fields

        [NotMapped]
        [DisplayName("Marca")]
        public String MarcaName { get; set; }
        [NotMapped]
        [DisplayName("Tipo")]
        public String TipoVehiculoName { get; set; }
        [NotMapped]
        [DisplayName("Modelo")]
        public String ModeloName { get; set; }
        [NotMapped]
        [DisplayName("Combustible")]
        public String TipoCombustibleName { get; set; }
      
        #endregion

    }
}