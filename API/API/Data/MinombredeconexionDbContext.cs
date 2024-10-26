using API.Controllers;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MinombredeconexionDbContext : DbContext
    {
        public MinombredeconexionDbContext(DbContextOptions<MinombredeconexionDbContext> options)
            : base(options) { }

        //1 id
        //2 nombre
        //3 apellidos
        //4 estado
        //5 email
        //6 telefono
        //7 provincia
        //8 direccion
        //int (ll)
        //varchsr(100)
        //varchar(200)
        //int (l)
        //varchsr(100) utf8mb4_unicode_ci
        //varchsr(20)
        //varchar(20) utf8mb4_u nicode_ci
        //varchar(200)
        //O fechanacimiento date
        //SELECT `id`, `nombre`, `apellidos`, `estado`, `email`, `telefono`, `provincia`, `direccion`, `fechanacimiento` FROM `prof_usuarios` WHERE 1

        public DbSet<UsuarioModel> prof_usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>().ToTable("prof_usuarios");
        }

        //"ConnectionString": {
        //  "Minombredeconexion": "Server=srv863.hstgr.io;Port=3306;User=u484426513_pac324;Password=B&XWouC#9Ef;Database=u484426513_pac324;"
        //},

    }
}
