using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace SchoolSystem.data
{
    public class DatabaseModels: DbContext
    {
        public DatabaseModels(DbContextOptions<DatabaseModels> options) : base(options)
        {  
        }

        public DbSet<Courses>? Courses { get; set; }
    }
}