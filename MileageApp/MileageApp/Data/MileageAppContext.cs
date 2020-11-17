using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MileageApp.Models;

namespace MileageApp.Data
{
    public class MileageAppContext : DbContext
    {
        public MileageAppContext (DbContextOptions<MileageAppContext> options)
            : base(options)
        {
        }

        public DbSet<MileageApp.Models.Employee> Employee { get; set; }
    }
}
