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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String rutaDb = string.Empty;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    {
                        rutaDb = Path.Combine(FileSystem.AppDataDirectory, "unad.db3");
                    }break;
                case Device.MacCatalyst:
                    {
                        rutaDb = Path.Combine(FileSystem.AppDataDirectory, "unad.db3");
                    }
                    break;
                case Device.Android:
                    {
                        rutaDb = Path.Combine(FileSystem.AppDataDirectory, "unad.db3");
                    }
                    break;
            }
            optionsBuilder.UseSqlite($"FileName={rutaDb}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
