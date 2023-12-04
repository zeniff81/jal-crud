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
    }
}
