using System.Linq;

namespace TableTopCatalogDemoApp.Data.Design.DataSeed.DataPacks._002
{
    class DataPack002 : IDataSeedPack
    {
        public string GetUniqueId()
        {
            return "00000000-0000-0000-0000-000000000002";
        }

        public void Apply(TableTopDataContext context)
        {
            var takenoko = context.Games
                .Single(x => x.Title == "Takenoko");

            var ticketToRide = context.Games
                .Single(x => x.Title == "Ticket to Ride");

            takenoko.Description = @"
                A long time ago at the Japanese Imperial court, the Chinese Emperor offered a giant panda bear as a symbol of peace to the Japanese Emperor. Since then, the Japanese Emperor has entrusted his court members (the players) with the difficult task of caring for the animal by tending to his bamboo garden.

                In Takenoko, the players will cultivate land plots, irrigate them, and grow one of the three species of bamboo (Green, Yellow, and Pink) with the help of the Imperial gardener to maintain this bamboo garden. They will have to bear with the immoderate hunger of this sacred animal for the juicy and tender bamboo. The player who manages his land plots best, growing the most bamboo while feeding the delicate appetite of the panda, will win the game.
            ";

            ticketToRide.Description = @"
                With elegantly simple gameplay, Ticket to Ride can be learned in under 15 minutes. Players collect cards of various types of train cars they then use to claim railway routes in North America. The longer the routes, the more points they earn. Additional points come to those who fulfill Destination Tickets – goal cards that connect distant cities; and to the player who builds the longest continuous route.

                'The rules are simple enough to write on a train ticket – each turn you either draw more cards, claim a route, or get additional Destination Tickets,' says Ticket to Ride author, Alan R. Moon. 'The tension comes from being forced to balance greed – adding more cards to your hand, and fear – losing a critical route to a competitor.'

                Ticket to Ride continues in the tradition of Days of Wonder's big format board games featuring high-quality illustrations and components including: an oversize board map of North America, 225 custom-molded train cars, 144 illustrated cards, and wooden scoring markers.

                Since its introduction and numerous subsequent awards, Ticket to Ride has become the BoardGameGeek epitome of a 'gateway game' - simple enough to be taught in a few minutes, and with enough action and tension to keep new players involved and in the game for the duration.
            ";
        }
    }
}
