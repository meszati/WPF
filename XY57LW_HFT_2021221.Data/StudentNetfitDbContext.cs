using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Models;

namespace XY57LW_HFT_2021221.Data
{
    class StudentNetfitDbContext : DbContext
    {
        public DbSet<School> Schools { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Measurement> Measurements { get; set; }

        public StudentNetfitDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            School jedlik = new School() { SchoolID = 1, Name = "Jedlik Ányos Gimnázium", Headmaster = "Bese Benő", Location = "Budapest, Táncsics Mihály utca 92.", Phone = "06 1 276 1133" };
            School baár = new School() { SchoolID = 2, Name = "Baár-Madas Református Gimnázium", Headmaster = "Tombor László", Location = "Budapest, Lorántffy Zsuzsanna utca 3.", Phone = "06 1 212 1494" };
            School moricz = new School() { SchoolID = 3, Name = "Móricz Zsigmond Gimnázium", Headmaster = "Farkas Barabásné", Location = "Budapest, Törökvész út 48-54.", Phone = "06 1 394 4965" };
            School kolcsey = new School() { SchoolID = 4, Name = "Kölcsey Ferenc Gimnázium", Headmaster = "Fazekas Csaba", Location = "Budapest, Munkácsy Mihály utca 26.", Phone = "06 1 311 4684" };
            School fazekas = new School() { SchoolID = 5, Name = "Fazekas Mihály Gimnázium", Headmaster = "Aranyi Imre", Location = "Debrecen, Hatvan utca 44.", Phone = "06 52 535 372" };
        }
    }
}
