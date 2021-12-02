using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Models;

namespace XY57LW_HFT_2021221.Data
{
    public class StudentNetfitDbContext : DbContext
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
            modelBuilder.Entity<Student>(entity =>
            {
                entity
                .HasOne(student => student.Sch)
                .WithMany(school => school.Students)
                .HasForeignKey(student => student.SchoolID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity
                .HasOne(student => student.Netfit)
                .WithOne(measurement => measurement.Student)
                .HasForeignKey<Student>(student => student.NetfitID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            School jedlik = new School() { SchID = 1, Name = "Jedlik Ányos Gimnázium", Headmaster = "Bese Benő", Location = "Budapest, Táncsics Mihály utca 92.", Phone = "06 1 276 1133" };
            School baár = new School() { SchID = 2, Name = "Baár-Madas Református Gimnázium", Headmaster = "Tombor László", Location = "Budapest, Lorántffy Zsuzsanna utca 3.", Phone = "06 1 212 1494" };
            School moricz = new School() { SchID = 3, Name = "Móricz Zsigmond Gimnázium", Headmaster = "Farkas Barabásné", Location = "Budapest, Törökvész út 48-54.", Phone = "06 1 394 4965" };
            School kolcsey = new School() { SchID = 4, Name = "Kölcsey Ferenc Gimnázium", Headmaster = "Fazekas Csaba", Location = "Budapest, Munkácsy Mihály utca 26.", Phone = "06 1 311 4684" };
            School fazekas = new School() { SchID = 5, Name = "Fazekas Mihály Gimnázium", Headmaster = "Aranyi Imre", Location = "Debrecen, Hatvan utca 44.", Phone = "06 52 535 372" };

            Measurement one = new Measurement() { ID = 1, BMI = 21.4, Bodyfat = 6.5, Pushup = 40, Situp = 100, Jump = 250 };
            Measurement two = new Measurement() { ID = 2, BMI = 20.2, Bodyfat = 10, Pushup = 39, Situp = 99, Jump = 230 };
            Measurement three = new Measurement() { ID = 3, BMI = 19, Bodyfat = 14.2, Pushup = 32, Situp = 85, Jump = 240 };
            Measurement four = new Measurement() { ID = 4, BMI = 27.2, Bodyfat = 8.2, Pushup = 25, Situp = 34, Jump = 150 };
            Measurement five = new Measurement() { ID = 5, BMI = 35.4, Bodyfat = 23.1, Pushup = 12, Situp = 25, Jump = 170 };
            Measurement six = new Measurement() { ID = 6, BMI = 17.4, Bodyfat = 7.8, Pushup = 5, Situp = 12, Jump = 260 };
            Measurement seven = new Measurement() { ID = 7, BMI = 23.2, Bodyfat = 12, Pushup = 23, Situp = 45, Jump = 176 };
            Measurement eight = new Measurement() { ID = 8, BMI = 22.1, Bodyfat = 14.5, Pushup = 31, Situp = 63, Jump = 234 };
            Measurement nine = new Measurement() { ID = 9, BMI = 19.8, Bodyfat = 19.8, Pushup = 11, Situp = 34, Jump = 211 };
            Measurement ten = new Measurement() { ID = 10, BMI = 24, Bodyfat = 21, Pushup = 18, Situp = 65, Jump = 178 };
            Measurement eleven = new Measurement() { ID = 11, BMI = 23.4, Bodyfat = 27.3, Pushup = 22, Situp = 67, Jump = 156 };

            Student norbi = new Student() { StudentID = 1, SchoolID = jedlik.SchID, NetfitID = one.ID, Name = "Gyéresi Norbert", City = "Halásztelek", MothersName = "Dali Melinda", BirthDate = new DateTime(2000, 08, 08) };
            Student noel = new Student() { StudentID = 2, SchoolID = baár.SchID, NetfitID = two.ID, Name = "Maklári Noel", City = "Budapest", BirthDate = new DateTime(2005, 10, 21) };
            Student atti = new Student() { StudentID = 3, SchoolID = jedlik.SchID, NetfitID = three.ID, Name = "Mészáros Attila", City = "Szigetszentmiklós", BirthDate = new DateTime(2000, 07, 07) };
            Student csongi = new Student() { StudentID = 4, SchoolID = moricz.SchID, NetfitID = four.ID, Name = "Róka Csongor", City = "Halásztelek", BirthDate = new DateTime(2000, 11, 23) };
            Student gabor = new Student() { StudentID = 5, SchoolID = jedlik.SchID, NetfitID = five.ID, Name = "Imre Gábor", City = "Szigethalom", BirthDate = new DateTime(2000, 01, 05) };
            Student laura = new Student() { StudentID = 6, SchoolID = kolcsey.SchID, NetfitID = six.ID, Name = "Lakatos Laura", City = "Budapest", MothersName = "Lakatos Éva", BirthDate = new DateTime(1999, 05, 25) };
            Student melinda = new Student() { StudentID = 7, SchoolID = fazekas.SchID, NetfitID = seven.ID, Name = "Gyéresi Melinda", City = "Debrecen", BirthDate = new DateTime(2000, 04, 11) };
            Student david = new Student() { StudentID = 8, SchoolID = kolcsey.SchID, NetfitID = eight.ID, Name = "Dadogó Dávid", City = "Budapest", BirthDate = new DateTime(2000, 09, 11) };
            Student mozes = new Student() { StudentID = 9, SchoolID = moricz.SchID, NetfitID = nine.ID, Name = "Mágikus Mózes", City = "Budapest", BirthDate = new DateTime(2000, 12, 24) };
            Student emilio = new Student() { StudentID = 10, SchoolID = baár.SchID, NetfitID = ten.ID, Name = "Kolompár Emilió", City = "Budapest", BirthDate = new DateTime(2000, 03, 04) };
            Student csaba = new Student() { StudentID = 11, SchoolID = moricz.SchID, NetfitID = eleven.ID, Name = "Gyéresi Csaba", City = "Budapest", MothersName = "Dali Melinda", BirthDate = new DateTime(2000, 09, 25) };

            modelBuilder.Entity<School>().HasData(jedlik, baár, moricz, kolcsey, fazekas);
            modelBuilder.Entity<Measurement>().HasData(one, two, three, four, five, six, seven, eight, nine, ten, eleven);
            modelBuilder.Entity<Student>().HasData(norbi, noel, atti, csongi, gabor, laura, melinda, david, mozes, emilio, csaba);
        }
    }
}
