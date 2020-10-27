using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Models;

    public class DataContext : DbContext
    {
    
        public DataContext (DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> AppUser { get; set; }
    }
