using System.Collections.Generic;
using Grpc.Net.Client;
using People.Service;
using PeopleRepository.Interface;
using Person = PeopleRepository.Interface.Person;

namespace PeopleRepository.Service
{
    public class ServiceRepository : IPeopleRepository
    {
        private readonly PeopleService.PeopleServiceClient _client;

        public ServiceRepository(string host)
        {
            var channel = GrpcChannel.ForAddress(host);
            _client = new PeopleService.PeopleServiceClient(channel);
        }

        public IEnumerable<Person> GetPeople()
        {
            var reply = _client.GetPeople(new GetPeopleRequest() {});
            foreach (var person in reply.People)
            {
                yield return new Person
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Rating = person.Rating,
                    StartDate = person.StartDate.ToDateTime()
                };
            }
        }
    }
}