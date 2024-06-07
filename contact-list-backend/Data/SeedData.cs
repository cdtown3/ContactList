using contact_list_backend.Models;

namespace contact_list_backend.Data
{
    public static class SeedData
    {
        /// <summary>
        /// Seeds the database with 10 contact records, all states, and necessary contact frequencies
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            var contactFrequencies = new List<ContactFrequency>
            {
                new ContactFrequency
                {
                    Id = 1,
                    Name = "Contact only about account information"
                }, new ContactFrequency
                {
                    Id = 2,
                    Name = "OK to contact with marketing information"
                }, new ContactFrequency
                {
                    Id = 3,
                    Name = "OK to contact with third-party marketing information"
                }
            };

            context.ContactFrequencies.AddRange(contactFrequencies);

            var contacts = new List<Contact>
            {
                new Contact {
                    Id = 1,
                    FirstName = "Drew",
                    LastName = "Doe",
                    EmailAddress = "drew@example.com",
                    PhoneNumber = "1234567890",
                    Address = new Address
                    {
                        Street = "123 Test St",
                        City = "Knoxville",
                        State = "TN",
                        Zip = "37938"
                    },
                    ContactFrequencyId = 1
                }, new Contact {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Dough",
                    EmailAddress = "john@example.com",
                    PhoneNumber = "9876543210",
                    Address = new Address
                    {
                        Street = "321 Example St",
                        City = "Memphis",
                        State = "TN",
                        Zip = "12345"
                    },
                    ContactFrequencyId = 2
                }, new Contact {
                    Id = 3,
                    FirstName = "Oli",
                    LastName = "Dean",
                    EmailAddress = "olidean@test.com",
                    PhoneNumber = "5551234567",
                    Address = new Address
                    {
                        Street = "8550 Example Ave",
                        City = "St. Petersburg",
                        State = "FL",
                        Zip = "33703"
                    },
                    ContactFrequencyId = 3
                }, new Contact {
                    Id = 4,
                    FirstName = "Samuel",
                    LastName = "Jackson",
                    EmailAddress = "sammy@jackson.com",
                    PhoneNumber = "5554671640",
                    Address = new Address
                    {
                        Street = "404 Not Found Rd",
                        City = "Seattle",
                        State = "WA",
                        Zip = "88041"
                    },
                    ContactFrequencyId = 1
                }, new Contact {
                    Id = 5,
                    FirstName = "Jacob",
                    LastName = "Doe",
                    EmailAddress = "jacob@example.com",
                    PhoneNumber = "5557981345",
                    Address = new Address
                    {
                        Street = "789 Another St",
                        City = "Knoxville",
                        State = "TN",
                        Zip = "37938"
                    },
                    ContactFrequencyId = 1
                }, new Contact {
                    Id = 6,
                    FirstName = "Fred",
                    LastName = "Smith",
                    EmailAddress = "fred@smith.com",
                    PhoneNumber = "5550216402",
                    Address = new Address
                    {
                        Street = "2 Fred's Place",
                        City = "Corryton",
                        State = "TN",
                        Zip = "37721"
                    },
                    ContactFrequencyId = 2
                }, new Contact {
                    Id = 7,
                    FirstName = "Dolly",
                    LastName = "Parton",
                    EmailAddress = "dolly@dollywood.com",
                    PhoneNumber = "8003655996",
                    Address = new Address
                    {
                        Street = "2700 Dollywood Parks Blvd",
                        City = "Pigeon Forge",
                        State = "TN",
                        Zip = "37863"
                    },
                    ContactFrequencyId = 3
                }, new Contact {
                    Id = 8,
                    FirstName = "Christopher",
                    LastName = "Pratt",
                    EmailAddress = "chris@example.com",
                    PhoneNumber = "5558569874",
                    Address = new Address
                    {
                        Street = "840 French St",
                        City = "Los Angeles",
                        State = "CA",
                        Zip = "90001"
                    },
                    ContactFrequencyId = 3
                }, new Contact {
                    Id = 9,
                    FirstName = "Shawn",
                    LastName = "Spencer",
                    EmailAddress = "Shawn@example.com",
                    PhoneNumber = "5551234567",
                    Address = new Address
                    {
                        Street = "654 Example Ave",
                        City = "Egypt",
                        State = "IN",
                        Zip = "47978"
                    },
                    ContactFrequencyId = 2
                }, new Contact {
                    Id = 10,
                    FirstName = "Gus",
                    LastName = "Doe",
                    EmailAddress = "gus@test.com",
                    PhoneNumber = "5557439435",
                    Address = new Address
                    {
                        Street = "412 Done Ct",
                        City = "Nashville",
                        State = "TN",
                        Zip = "37845"
                    },
                    ContactFrequencyId = 3
                },
            };

            context.Contacts.AddRange(contacts);

            var states = new List<State>
            {
                new State { Id = 1, Name = "Alabama", Abbreviation = "AL" },
                new State { Id = 2, Name = "Alaska", Abbreviation = "AK" },
                new State { Id = 3, Name = "Arizona", Abbreviation = "AZ" },
                new State { Id = 4, Name = "Arkansas", Abbreviation = "AR" },
                new State { Id = 5, Name = "California", Abbreviation = "CA" },
                new State { Id = 6, Name = "Colorado", Abbreviation = "CO" },
                new State { Id = 7, Name = "Connecticut", Abbreviation = "CT" },
                new State { Id = 8, Name = "Delaware", Abbreviation = "DE" },
                new State { Id = 9, Name = "Florida", Abbreviation = "FL" },
                new State { Id = 10, Name = "Georgia", Abbreviation = "GA" },
                new State { Id = 11, Name = "Hawaii", Abbreviation = "HI" },
                new State { Id = 12, Name = "Idaho", Abbreviation = "ID" },
                new State { Id = 13, Name = "Illinois", Abbreviation = "IL" },
                new State { Id = 14, Name = "Indiana", Abbreviation = "IN" },
                new State { Id = 15, Name = "Iowa", Abbreviation = "IA" },
                new State { Id = 16, Name = "Kansas", Abbreviation = "KS" },
                new State { Id = 17, Name = "Kentucky", Abbreviation = "KY" },
                new State { Id = 18, Name = "Louisiana", Abbreviation = "LA" },
                new State { Id = 19, Name = "Maine", Abbreviation = "ME" },
                new State { Id = 20, Name = "Maryland", Abbreviation = "MD" },
                new State { Id = 21, Name = "Massachusetts", Abbreviation = "MA" },
                new State { Id = 22, Name = "Michigan", Abbreviation = "MI" },
                new State { Id = 23, Name = "Minnesota", Abbreviation = "MN" },
                new State { Id = 24, Name = "Mississippi", Abbreviation = "MS" },
                new State { Id = 25, Name = "Missouri", Abbreviation = "MO" },
                new State { Id = 26, Name = "Montana", Abbreviation = "MT" },
                new State { Id = 27, Name = "Nebraska", Abbreviation = "NE" },
                new State { Id = 28, Name = "Nevada", Abbreviation = "NV" },
                new State { Id = 29, Name = "New Hampshire", Abbreviation = "NH" },
                new State { Id = 30, Name = "New Jersey", Abbreviation = "NJ" },
                new State { Id = 31, Name = "New Mexico", Abbreviation = "NM" },
                new State { Id = 32, Name = "New York", Abbreviation = "NY" },
                new State { Id = 33, Name = "North Carolina", Abbreviation = "NC" },
                new State { Id = 34, Name = "North Dakota", Abbreviation = "ND" },
                new State { Id = 35, Name = "Ohio", Abbreviation = "OH" },
                new State { Id = 36, Name = "Oklahoma", Abbreviation = "OK" },
                new State { Id = 37, Name = "Oregon", Abbreviation = "OR" },
                new State { Id = 38, Name = "Pennsylvania", Abbreviation = "PA" },
                new State { Id = 39, Name = "Rhode Island", Abbreviation = "RI" },
                new State { Id = 40, Name = "South Carolina", Abbreviation = "SC" },
                new State { Id = 41, Name = "South Dakota", Abbreviation = "SD" },
                new State { Id = 42, Name = "Tennessee", Abbreviation = "TN" },
                new State { Id = 43, Name = "Texas", Abbreviation = "TX" },
                new State { Id = 44, Name = "Utah", Abbreviation = "UT" },
                new State { Id = 45, Name = "Vermont", Abbreviation = "VT" },
                new State { Id = 46, Name = "Virginia", Abbreviation = "VA" },
                new State { Id = 47, Name = "Washington", Abbreviation = "WA" },
                new State { Id = 48, Name = "West Virginia", Abbreviation = "WV" },
                new State { Id = 49, Name = "Wisconsin", Abbreviation = "WI" },
                new State { Id = 50, Name = "Wyoming", Abbreviation = "WY" },
                new State { Id = 51, Name = "District of Columbia", Abbreviation = "DC" }
            };

            context.States.AddRange(states);

            context.SaveChanges();
        }
    }
}
