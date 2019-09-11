using System.Collections.Generic;

namespace PeopleRepository.Interface
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> GetPeople();
    }
}
