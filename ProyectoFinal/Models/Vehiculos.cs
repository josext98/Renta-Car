using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Vehiculos
    {
        public enum Status
        {
            Rentado,
            Disponible,
            Inspeccion,
            Procesando
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("No. Chasis")]
        public String NoChasis { get; set; }
        [Required]
        public String Descripción { get; set; }

        [DisplayName ("No. Placa")]
        [Required]
        public String NoPlaca { get; set; }

        public int? TipoVehiculoId { get; set; }
        public TipodeVehiculo TipoVehiculo { get; set; }
        
        public int? MarcaId { get; set; }
        public Marcas Marca { get; set; }
     
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