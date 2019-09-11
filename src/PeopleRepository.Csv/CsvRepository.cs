using System;
using System.Collections.Generic;
using System.IO;
using PeopleRepository.Interface;

namespace PeopleRepository.Csv
{
    public class CsvRepository : IPeopleRepository
    {
        private readonly string _path;

        public CsvRepository(string path)
        {
            _path = path;
        }

        public IEnumerable<Person> GetPeople()
        {
            var people = new List<Person>();
            if (File.Exists(_path))
            {
                var lines = File.ReadLines(_path);
                foreach (var line in lines)
                {
                    var splitLines = line.Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries);
                    string firstName = splitLines[0];
                    string lastName = splitLines[1];
                    DateTime startDate = DateTime.Parse(splitLines[2]);
                    int rating = Int32.Parse(splitLines[3]);

                    people.Add(
                        new Person
                        {
                            FirstName = firstName, 
                            LastName = lastName, 
                            StartDate = startDate, 
                            Rating = rating
                        });
                }
                return people;
            }

            throw new FileNotFoundException($"Can't find the file {_path}");
        }
    }
}
