using System;
using System.Globalization;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace People.Service.Services
{
    public class PeopleService : People.Service.PeopleService.PeopleServiceBase
    {
        public override Task<GetPeopleResponse> GetPeople(GetPeopleRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GetPeopleResponse
            {
                People =
                {
                    new Person { 
                        FirstName = "John", 
                        LastName = "Elmer", 
                        StartDate = Timestamp.FromDateTime(DateTime.ParseExact("1975-10-17T22:20:29.055Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)), 
                        Rating = 6
                    }, 
                    new Person
                    {
                        FirstName = "Francis", 
                        LastName = "Hunt", 
                        StartDate = Timestamp.FromDateTime(DateTime.ParseExact("2000-02-06T22:20:29.055Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)), 
                        Rating = 7
                    }, 
                    new Person
                    {
                        FirstName = "Amanda", 
                        LastName = "Montana", 
                        StartDate = Timestamp.FromDateTime(DateTime.ParseExact("1999-08-25T22:20:29.055Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)), 
                        Rating = 6
                    }, 
                    new Person
                    {
                        FirstName = "Steven", 
                        LastName = "Sheridan", 
                        StartDate = Timestamp.FromDateTime(DateTime.ParseExact("1991-11-11T22:20:29.055Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)), 
                        Rating = 8
                    }, 
                    new Person
                    {
                        FirstName = "Eleanor", 
                        LastName = "Gampu", 
                        StartDate = Timestamp.FromDateTime(DateTime.ParseExact("1996-12-09T22:20:29.055Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)), 
                        Rating = 5
                    }, 
                    new Person
                    {
                        FirstName = "Paul", 
                        LastName = "Koenig", 
                        StartDate = Timestamp.FromDateTime(DateTime.ParseExact("1981-04-20T22:20:29.055Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)), 
                        Rating = 9
                    }, 
                    new Person
                    {
                        FirstName = "Gabriela", 
                        LastName = "Lister", 
                        StartDate = Timestamp.FromDateTime(DateTime.ParseExact("1984-04-19T22:20:29.055Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)), 
                        Rating = 4
                    }
                }
            });
        }
    }
}