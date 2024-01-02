using Microsoft.EntityFrameworkCore;
using RescueMarket.Model;
namespace RescueMarket.Context
{
    public class RMContext : DbContext
    {
        public DbSet <Cliente>Clientes { get; set; } 
        public DbSet <Compra> Compras { get; set; }
        public DbSet <Direccion> Direcciones { get; set;}
        public DbSet <Producto> Productos { get; set; }
        public DbSet <Productor> Productores {  get; set; }
        public DbSet <Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL("server=localhost; database=proyectoweb; user=root; password=admin");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(c => c.ID_cliente);
                entity.Property(c => c.Nombre_Usuario);
                entity.Property(c => c.Correo);
                entity.Property(c => c.Contraseña);
                entity.Property(c => c.Apellido_Paterno);
                entity.Property(c => c.Apellido_Materno);
                entity.Property(c => c.Nombre);
                entity.Property(c => c.Fecha_nacimiento);
            });
            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.Property(d => d.Num_ext);
                entity.Property(d => d.Calle);
                entity.Property(d => d.Ciudad);
                entity.Property(d => d.Codigo_Postal);
            });
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(p => p.ID_producto);
                entity.Property(p => p.Nombre_Producto);
                entity.Property(p => p.Descripcion);
                entity.Property(p => p.Precio);
            });
            modelBuilder.Entity<Productor>(entity =>
            {
                entity.HasKey(u => u.Id_productor);
                entity.Property(u => u.NombreUsuario);
                entity.Property(u => u.Correo);
                entity.Property(u => u.Contrasena);
                entity.Property(u => u.ApellidoPaterno);
                entity.Property(u => u.ApellidoMaterno);
                entity.Property(u => u.Nombre);
                entity.Property(u => u.FechaNacimiento);
                entity.Property(u => u.Telefono);
                entity.Property(u => u.Direccion);
            });
            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(b => b.NumCompra);
                entity.Property(b => b.FechaCompra);
                entity.Property(b => b.Cantidad);
                entity.Property(b => b.Id_cliente);
                entity.Property(b => b.Id_productor);
                entity.Property(b => b.Id_producto);
            });
        }
    }
}
