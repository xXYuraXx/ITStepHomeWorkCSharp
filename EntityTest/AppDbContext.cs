using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTest
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection_string = "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;TrustServerCertificate=true;";
            optionsBuilder.UseSqlServer(connection_string);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
