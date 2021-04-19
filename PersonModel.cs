using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_With_Dotnet
{
    public class PersonModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel PrimaryAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}