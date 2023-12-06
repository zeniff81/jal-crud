using jal_crud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jal_crud.Data
{
    public class Context: DbContext
    {
        public Context()
        {
            if (DeviceInfo.Platform == DevicePlatform.iOS || DeviceInfo.Platform == DevicePlatform.MacCatalyst)
            {
                SQLitePCL.Batteries_V2.Init();
            }

            this.Database.EnsureCreated();
            this.Database.Migrate();
        }

        public DbSet<clsContactosBE> clsContactosBE { get; set; }
        public DbSet<clsCiudadesBE> clsCiudadesBE { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String rutaDB = string.Empty;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    {
                        rutaDB = Path.Combine(FileSystem.AppDataDirectory, "unad3.db3");
                    }break;
                case Device.MacCatalyst:
                    {
                        rutaDB = Path.Combine(FileSystem.AppDataDirectory, "unad3.db3");
                    }
                    break;
                case Device.Android:
                    {
                        rutaDB = Path.Combine(FileSystem.AppDataDirectory, "unad3.db3");
                    }
                    break;
            }
            optionsBuilder.UseSqlite($"FileName={rutaDB}");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<clsCiudadesBE>()
                .HasMany(x => x.Contactos)
                .WithOne(x => x.Ciudades)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
