using System;

namespace PeopleRepository.Interface
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Rating { get; set; }
        public DateTime StartDate { get; set; }
    }
}