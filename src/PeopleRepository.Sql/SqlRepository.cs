using System.Collections.Generic;
using System.Linq;
using PeopleRepository.Interface;

namespace PeopleRepository.Sql
{
    public class SqlRepository : IPeopleRepository
    {
        private readonly string _connectionString;

        public SqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Person> GetPeople()
        {
            using (var db = new PeopleDbContext(_connectionString))
            {
                var people = db.People.Select(dto => 
                    new Person {
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        StartDate = dto.StartDate,
                        Rating = dto.Rating
                    }
                );

                return people.ToList();
            }
        }
    }
}
