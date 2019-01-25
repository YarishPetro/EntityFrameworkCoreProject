using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DALModel;
using BLL;

namespace PresentationLayer
{
    static class Presenter
    {
        public static void GetAll()
        {
            using (UnitOfWork content = new UnitOfWork())
            {
                var players = content.PlayersRepository.Get(includeProperties: "Team");
                foreach (Players player in players)
                {
                    Console.WriteLine($"Id: {player.Id} FirstName: {player.FirstName} - LastName: {player.LastName} -> Position: {player.Position} - Age: {player.Age} \nTeam: {player.Team.Name} from {player.Team.Country}\n");
                }
            }
        }

        public static void GetPlayerById(int id)
        {
            using (UnitOfWork context = new UnitOfWork())
            {
                Players player = context.PlayersRepository.GetByID(id);
                Teams team = context.TeamsRepository.GetByID(player.TeamId);

                Console.WriteLine($"Id: {player.Id} FirstName: {player.FirstName} - LastName: {player.LastName} -> Position: {player.Position} - Age: {player.Age} \nTeam: {team.Name} from {team.Country}");
            }
        }

        public static void AddPlayer()
        {
            using (UnitOfWork context = new UnitOfWork())
            {
                context.PlayersRepository.Insert(CreatePlayer());
                context.Save();
            }
        }

        public static void DeleteById(int id)
        {
            using (UnitOfWork context = new UnitOfWork())
            {
                context.PlayersRepository.Delete(id);
                context.Save();
            }
        }

        public static void MakeTransfer(int playerId, int teamId)
        {
            Transfer tr = new Transfer(new UnitOfWork());

            try
            {
                tr.MakeTransfer(playerId, teamId);
                Console.WriteLine("The transfer was successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Info()
        {
            Console.WriteLine("Choose one option from the list:");
            Console.WriteLine("1. Get all players from all teams");
            Console.WriteLine("2. Get information about player by id");
            Console.WriteLine("3. Add new player to database");
            Console.WriteLine("4. Delete player by id");
            Console.WriteLine("5. Make transfer");
            Console.WriteLine("6. Close application");
        }
        public static void Clear()
        {
            Console.WriteLine("\nPress Enter to continue");
            Console.ReadKey();
            Console.Clear();
        }

        private static Players CreatePlayer()
        {
            Players player = null;

            Console.Write("Enter player`s name: ");
            string name = Console.ReadLine();

            Console.Write("Enter player`s surname: ");
            string surname = Console.ReadLine();

            int age = 0;
            bool isIncorrect = true;

            Console.Write("Enter player`s age: ");

            while (isIncorrect)
            {
                age = Convert.ToInt32(Console.ReadLine());

                if (age > 0 && age < 100)
                {
                    isIncorrect = false;
                }
                else
                {
                    Console.WriteLine("You have entered incorrect age, try once more (0 < age < 100):");
                }
            }

            Console.WriteLine("Choose one of positions:");
            Console.WriteLine("1. Goalkeeper");
            Console.WriteLine("2. Defender");
            Console.WriteLine("3. Middefender");
            Console.WriteLine("4. Striker");

            int input = 0;
            string position = null;

            isIncorrect = true;

            while (isIncorrect)
            {
                input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1: position = "Goalkeeper"; isIncorrect = false; break;

                    case 2: position = "Defender"; isIncorrect = false; break;

                    case 3: position = "Middefender"; isIncorrect = false; break;

                    case 4: position = "Striker"; isIncorrect = false; break;

                    default: Console.WriteLine("You have choosen incorrect option!!!\nPlease try once more"); break;
                }
            }

            Console.WriteLine("Choose player`s team:");
            Console.WriteLine("1. Dynamo Kyiv");
            Console.WriteLine("2. Real Madrid");

            int teamId = 0;
            isIncorrect = true;

            while (isIncorrect)
            {
                input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1: teamId = 1; isIncorrect = false; break;

                    case 2: teamId = 2; isIncorrect = false; break;

                    default: Console.WriteLine("You have choosen incorrect option!!!\nPlease try once more"); break;
                }
            }

            player = new Players
            {
                FirstName = name,
                LastName = surname,
                Age = age,
                Position = position,
                TeamId = teamId
            };

            return player;
        }
    }
}
