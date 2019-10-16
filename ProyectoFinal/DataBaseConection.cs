namespace ProyectoFinal
{
    using ProyectoFinal.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataBaseConection : DbContext
    {
        // Your context has been configured to use a 'DataBaseConection' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProyectoFinal.DataBaseConection' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DataBaseConection' 
        // connection string in the application configuration file.
        public DataBaseConection()  : base("name=DataBaseConection")
        {
        }

         public virtual DbSet<TipodeVehiculo> TipodeVehiculo { get; set; }
         public virtual DbSet<Marcas> Marcas { get; set; }
         public virtual DbSet<Modelos> Modelos { get; set; }
         public virtual DbSet<Vehiculos> Vehiculos { get; set; }
         public virtual DbSet<Clientes> Clientes { get; set; }
         public virtual DbSet<Empleados> Empleados { get; set; }
         public virtual DbSet<PedidoRenta> Pedido { get; set; }
         public virtual DbSet<Combustibles> Combustibles { get; set; }
         public virtual DbSet<InspeccionTable> InspeccionTable { get; set; }
    }
}