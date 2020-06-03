using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NumizmatDictionary.Models;

namespace NumizmatDictionary.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NumizmatDictionary.Models.Coins> Coins { get; set; }
        public DbSet<NumizmatDictionary.Models.Collectors> Collectors { get; set; }
    }
}
