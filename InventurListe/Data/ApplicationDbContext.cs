using InventurListe.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventurListe.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Abteilung> Abteilung { get; set; }

        public DbSet<Betriebssystem> Betriebssystem { get; set; }
        public DbSet<Gerät> Gerät { get; set; }
        public DbSet<GeräteTyp> GeräteTyp { get; set; }
        public DbSet<Haus> Haus { get; set; }
        public DbSet<Raum> Raum { get; set; }
        public DbSet<Standort> Standort { get; set; }
        public DbSet<Stockwerk> Stockwerk { get; set; }
    }
}
