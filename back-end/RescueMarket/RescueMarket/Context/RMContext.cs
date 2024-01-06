using Microsoft.EntityFrameworkCore;
using RescueMarket.Model;
using RescueMarket.DTO;
using MySql.EntityFrameworkCore;
using RescueMarket.Controllers;

namespace RescueMarket.Context
{
    public class RMContext : DbContext
    {
        public DbSet <Cliente>Clientes { get; set; } 
        public DbSet <Compra> Compras { get; set; }
        public DbSet <Direccion> Direcciones { get; set;}
        public DbSet <Producto> Productos { get; set; }
        public DbSet <Productor> Productores {  get; set; }

        public DbSet <DTO_Cliente> ClientesDTO { get; set; }
        public DbSet <DTO_Compra> CompraDTO { get; set; }
        public DbSet <DTO_Producto> ProductoDTO { get; set; }

        public DbSet <DTO_Productor> ProductorDTO { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL("server = localhost; database = proyectoweb; user=root;password =Pasword123456");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(c => c.Correo);
                entity.Property(c => c.Nombre_Usuario);
                entity.Property(c => c.Contrasena);
                entity.Property(c => c.Apellido_Paterno);
                entity.Property(c => c.Apellido_Materno);
                entity.Property(c => c.Nombre);
                entity.Property(c => c.Fecha_nacimiento);
            });
            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.Property(d => d.id);
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
                entity.Property(p => p.URL);
            });
            modelBuilder.Entity<Productor>(entity =>
            {
                entity.HasKey(u => u.Correo);
                entity.Property(u => u.Nombre_Usuario);
                entity.Property(u => u.Contrasena);
                entity.Property(u => u.Apellido_Paterno);
                entity.Property(u => u.Apellido_Materno);
                entity.Property(u => u.Nombre);
                entity.Property(u => u.Fecha_nacimiento);
                entity.Property(u => u.Telefono);
                entity.Property(u => u.Num_ext);
                entity.Property(u => u.Calle);
                entity.Property(u => u.Ciudad);
                entity.Property(u => u.Codigo_Postal);
            });
            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(b => b.NumCompra);
                entity.Property(b => b.FechaCompra);
                entity.Property(b => b.Cantidad);
                entity.Property(b => b.ID_cliente);
                entity.Property(b => b.ID_productor);
                entity.Property(b => b.ID_producto);
            });

            //DTO
            modelBuilder.Entity<DTO_Cliente>(entity =>
            {
                entity.HasKey(a => a.Correo);
                entity.Property(a => a.Nombre_Usuario);
                entity.Property(a => a.Nombre);
            });

            modelBuilder.Entity<DTO_Productor>(entity =>
            {
                entity.HasKey(a => a.Correo);
                entity.Property(a => a.Nombre_Usuario);
                entity.Property(a => a.Nombre);
                entity.Property(a => a.Telefono);
                entity.Property(a => a.Num_ext);
                entity.Property(a => a.Calle);
                entity.Property(a => a.Ciudad);
                entity.Property(a => a.Codigo_Postal);
            });

            modelBuilder.Entity<DTO_Compra>(entity =>
            {
                entity.HasKey(a => a.NumCompra);
                entity.Property(a => a.FechaCompra);
                entity.Property(a => a.Cantidad);
                entity.Property(a => a.ID_producto);
            });

            modelBuilder.Entity<DTO_Producto>(entity =>
            {
                entity.HasKey(a => a.ID_producto);
                entity.Property(a => a.Nombre_Producto);
                entity.Property(a => a.Descripcion);
                entity.Property(a => a.Precio);
                entity.Property(a => a.URL);
            });
        }
    }
}
