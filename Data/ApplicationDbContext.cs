using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProtonComputers.Models;

namespace ProtonComputers.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProtonComputers.Models.Manufacturers> Manufacturers { get; set; }
        public DbSet<ProtonComputers.Models.Products> Products { get; set; }
    }
}
