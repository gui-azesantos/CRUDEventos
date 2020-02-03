using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CrudBandas.Models;

namespace CrudBandas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CrudBandas.Models.CasaDeShow> CasaDeShow { get; set; }
        public DbSet<CrudBandas.Models.Evento> Evento { get; set; }
    }
}
