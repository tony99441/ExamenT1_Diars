using ExamenT1.BD.Mapeo;
using ExamenT1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT1.BD
{
    public class T1Context : DbContext
    {
        public DbSet<Persona> Personas
        { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-BIGBBRB\\SQLEXPRESS;Database=ExamenT1;Trusted_Connection=True;MultipleActiveResultSets=true");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CiudadMapeo());
            modelBuilder.ApplyConfiguration(new PersonaMapeo());


        }

    }
}
