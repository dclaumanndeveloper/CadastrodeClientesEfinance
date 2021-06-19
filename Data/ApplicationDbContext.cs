using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CadastrodeClientes.Models;

namespace CadastrodeClientes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CadastrodeClientes.Models.Estado> Estado { get; set; }
        public DbSet<CadastrodeClientes.Models.Cidade> Cidade { get; set; }
    }
}
