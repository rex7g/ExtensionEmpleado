using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExtensionEmpleado.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ExtensionEmpleado
{
    public class DataContext : IdentityDbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<ExtensionEmpleado.Models.Empleado> Empleado { get; set; }
    }
}
