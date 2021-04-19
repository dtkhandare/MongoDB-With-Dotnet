using System;

namespace MongoDB_With_Dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoCURD db = new MongoCURD("AddressBook");

            // Inserts a single records
            db.InsertRecord("Users", new PersonModel { FirstName = "John", LastName = "Smith" });

            PersonModel person = new PersonModel
            {
                FirstName = "Dattatray",
                LastName = "Khandare",
                PrimaryAddress = new AddressModel
                {
                    StreetAddress = "NDA Road",
                    City = "Pune",
                    State = "MH"
                }
            };

            // Inserts a single record
            db.InsertRecord("Users", person);

            // Print all the records 
            var persons = db.LoadRecords<PersonModel>("Users");
            foreach (var rec in persons)
            {
                Console.WriteLine($"{rec.Id}:{rec.FirstName} {rec.LastName}");
                if (rec.PrimaryAddress != null)
                    Console.WriteLine($"{rec.PrimaryAddress.StreetAddress}:{rec.PrimaryAddress.City} {rec.PrimaryAddress.State} {rec.PrimaryAddress.ZipCode}");
                Console.WriteLine("===================================");
            }

            var firstRecord = persons[0];
            // Load a record by Id
            var record = db.LoadRecordById<PersonModel>("Users", firstRecord.Id);
            firstRecord.DateOfBirth = new DateTime(1987, 10, 10, 0, 0, 0, DateTimeKind.Utc);

            // Upsert record: Insert the record if it doesn't already exist.
            db.UpsertRecord<PersonModel>("Users", firstRecord.Id, firstRecord);

            // Deletes a single record.
            db.DeleteRecord<PersonModel>("Users", firstRecord.Id);
        }
    }

}
