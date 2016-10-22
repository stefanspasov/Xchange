namespace Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;

    public class GamesRepo
    {
        public static List<Customer> Customers = new List<Customer>
                                                     {
                                                         new Customer { Id = 1, username = "User 1" },
                                                         new Customer { Id = 2, username = "User 2" }
                                                     };

        public static readonly List<BoardGame> Games = new List<BoardGame>
                                            {
                                                new BoardGame
                                                    {
                                                        Customer = Customers.FirstOrDefault(c=> c.Id == 1),
                                                        Description = "Lame game",
                                                        Id = 1,
                                                        Name = "Dominion"
                                                    },
                                                new BoardGame
                                                    {
                                                         Customer = Customers.FirstOrDefault(c=> c.Id == 2),
                                                        Description = "Lamer game",
                                                        Id = 2,
                                                        Name = "Munchkin"
                                                    },
                                                new BoardGame
                                                    {
                                                         Customer = Customers.FirstOrDefault(c=> c.Id == 1),
                                                        Description = "Nice game",
                                                        Id = 3,
                                                        Name = "Citadels"
                                                    }
                                            };

        

        public static BoardGame GetGameById(int id)
        {
            return Games.FirstOrDefault(g => g.Id == id);
        }

        public static List<BoardGame> GetGamesByCustomerId(int customerId)
        {
            return Games.FindAll(g => g.Customer.Id == customerId);
        }

        public static void SaveGame(BoardGame game)
        {
            var oldGame = Games.FirstOrDefault(g => g.Id == game.Id);
            if (oldGame == null)
            {
                return;
            }

            oldGame.Customer.Id = game.Customer.Id;
            oldGame.Description = game.Description;
            oldGame.Name = game.Name;
        }

        public static void AddGame(BoardGame game)
        {
            Games.Add(game);
        }
    }
}
