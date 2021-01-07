using TableTopCatalogDemoApp.Data.Entities;

namespace TableTopCatalogDemoApp.Data.Design.DataSeed.DataPacks._001
{
    class DataPack001 : IDataSeedPack
    {
        public string GetUniqueId()
        {
            return "00000000-0000-0000-0000-000000000001";
        }

        public void Apply(TableTopDataContext context)
        {
            var roles = new[]
            {
                new Role {Title = "Game designer"},
                new Role {Title = "Illustrator"}
            };

            var persons = new[]
            {
                new Person {FirstName = "Alan", LastName = "Moon"},
                new Person {FirstName = "Delval", LastName = "Delval"},
                new Person {FirstName = "Cyrille", LastName = "Daujean"},
                new Person {FirstName = "Antoine", LastName = "Bauza"}
            };

            var publishers = new[]
            {
                new Publisher {Title = "Days of Wonder"},
                new Publisher {Title = "Bombyx"},
            };

            var games = new[]
            {
                new Game
                {
                    Title = "Ticket to Ride",
                    AgeFrom = 6,
                    PlayersFrom = 2,
                    PlayersTo = 5,
                    Publisher = publishers[0],
                    YearPublished = 2004,
                    SessionFrom = 60,
                    SessionTo = 120
                },
                new Game
                {
                    Title = "Takenoko",
                    AgeFrom = 8,
                    PlayersFrom = 2,
                    PlayersTo = 4,
                    Publisher = publishers[1],
                    YearPublished = 2011,
                    SessionFrom = 45
                }
            };

            var teamMembers = new[]
            {
                new TeamMember {Game = games[0], Person = persons[0], Role = roles[0]},
                new TeamMember {Game = games[0], Person = persons[1], Role = roles[1]},
                new TeamMember {Game = games[0], Person = persons[2], Role = roles[1]},
                new TeamMember {Game = games[1], Person = persons[3], Role = roles[0]},
            };

            context.Roles.AddRange(roles);
            context.Persons.AddRange(persons);
            context.Publishers.AddRange(publishers);
            context.Games.AddRange(games);
            context.TeamMembers.AddRange(teamMembers);
        }
    }
}
