using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleRepository.Sql
{
    public class PersonDto
    {
        public string FirstName { get; set; }
        [Key]
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public int Rating { get; set; }
    }
}