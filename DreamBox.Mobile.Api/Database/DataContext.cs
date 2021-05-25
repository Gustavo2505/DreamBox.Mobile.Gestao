using DreamBox.Mobile.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamBox.Mobile.Api.Database
{
    public class DataContext : DbContext

    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Items> Items { get; set; }
        public DbSet<Vendas> Vendas { get; set; }

    }
}
