using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace PeopleRepository.Sql
{
    public class PeopleDbContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<PersonDto> People { get; set; }

        public PeopleDbContext()
        {
            _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PeopleDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public PeopleDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonDto>().HasData(
                new PersonDto
                {
                    FirstName = "John",
                    LastName = "Elmer",
                    StartDate = DateTime.ParseExact("1975-10-17T22:20:29.055Z", "yyyy-MM-ddTHH:mm:ss.fffZ",
                        CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                    Rating = 6

                },
                new PersonDto
                {
                    FirstName = "Francis",
                    LastName = "Hunt",
                    StartDate = DateTime.ParseExact("2000-02-06T22:20:29.055Z", "yyyy-MM-ddTHH:mm:ss.fffZ",
                        CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                    Rating = 7
                },
                new PersonDto
                {
                    FirstName = "Amanda",
                    LastName = "Montana",
                    StartDate = DateTime.ParseExact("1999-08-25T22:20:29.055Z", "yyyy-MM-ddTHH:mm:ss.fffZ",
                        CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                    Rating = 6
                },
                new PersonDto
                {
                    FirstName = "Steven",
                    LastName = "Sheridan",
                    StartDate = DateTime.ParseExact("1991-11-11T22:20:29.055Z", "yyyy-MM-ddTHH:mm:ss.fffZ",
                        CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                    Rating = 8
                },
                new PersonDto
                {
                    FirstName = "Eleanor",
                    LastName = "Gampu",
                    StartDate = DateTime.ParseExact("1996-12-09T22:20:29.055Z", "yyyy-MM-ddTHH:mm:ss.fffZ",
                        CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                    Rating = 5
                },
                new PersonDto
                {
                    FirstName = "Paul",
                    LastName = "Koenig",
                    StartDate = DateTime.ParseExact("1981-04-20T22:20:29.055Z", "yyyy-MM-ddTHH:mm:ss.fffZ",
                        CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                    Rating = 9
                },
                new PersonDto
                {
                    FirstName = "Gabriela",
                    LastName = "Lister",
                    StartDate = DateTime.ParseExact("1984-04-19T22:20:29.055Z", "yyyy-MM-ddTHH:mm:ss.fffZ",
                        CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                    Rating = 4
                },
                new PersonDto
                {
                    FirstName = "Petra",
                    LastName = "Stephens",
                    StartDate = DateTime.ParseExact("2005-02-10T22:20:29.055Z", "yyyy-MM-ddTHH:mm:ss.fffZ",
                        CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                    Rating = 9
                }
            );
        }
    }
}