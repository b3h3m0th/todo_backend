using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDo_Backend.Model
{
    public class ToDosContext : DbContext
    {
        public virtual DbSet<ToDo> ToDos { get; set; }
        public virtual DbSet<Person> Personen { get; set; }

        public ToDosContext(DbContextOptions<ToDosContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                .UseMySql("DataSource=localhost;DataBase=ToDosDB;UserID=root;", ServerVersion.Parse("10.4.18-mariadb"));
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Person>().HasData(
                new Person()
                {
                    ID = 1,
                    Vorname = "Herta",
                    Nachname = "Prinz",
                    Geburtsdatum = new DateTime(1978, 4, 3)
                },
                new Person()
                {
                    ID = 2,
                    Vorname = "Hubert",
                    Nachname = "Adalbert",
                    Geburtsdatum = new DateTime(1980, 7, 1)
                }
            );

            modelbuilder.Entity<ToDo>().HasData(
                 new ToDo()
                 {
                     ID = 1,
                     Titel = "Webservice fertig implementieren",
                     Beschreibung = "Alle CRUD-Operatioen umsetzen",
                     Deadline = new DateTime(2022, 01, 31),
                     Erledigt = false,
                     VerfasserID = 1
                 },
                 new ToDo()
                 {
                     ID = 2,
                     Titel = "Mathe lernen",
                     Beschreibung = "Sollte man eh immer machen :)",
                     Deadline = new DateTime(2022, 04, 20),
                     Erledigt = false,
                     VerfasserID = 2
                 }
            );
        }
    }
}
