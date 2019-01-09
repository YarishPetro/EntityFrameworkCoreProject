﻿using System;
using System.Linq;

namespace DALModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("All players from all teams:\n");
            GetAll();

            Clear();

            Console.Write("Enter id of player to get information about him: ");
            int id = Convert.ToInt32(Console.ReadLine());
            GetPlayerById(id);

            Clear();

            Console.WriteLine("Adding of new player\n");
            Players newPlayer = new Players { FirstName = "Daniel", LastName = "Ceballos",
                Position = "Middefender", Age = 22, TeamId = 2 };

            AddPlayer(newPlayer);           

            Console.WriteLine("New player has benn added!");

            GetAll();

            Clear();

            Console.ReadKey();
        }

        static void Clear()
        {
            Console.WriteLine("\nPress Enter to continue");
            Console.ReadKey();
            Console.Clear();
        }

        static void GetAll()
        {
            using (UnitOfWork content = new UnitOfWork())
            {
                var players = content.PlayersRepository.Get(includeProperties: "Team");
                foreach (Players player in players)
                {
                    Console.WriteLine($"FirstName: {player.FirstName} - LastName: {player.LastName} -> Position: {player.Position} - Age: {player.Age}" +
                        $"\nTeam: {player.Team.Name} from {player.Team.Country}");
                }
            }
        }

        static void GetPlayerById(int id)
        {
            using (UnitOfWork context = new UnitOfWork())
            {
                Players player = context.PlayersRepository.GetByID(id);

                Console.WriteLine($"FirstName: {player.FirstName} - LastName: {player.LastName} -> Position: {player.Position} - Age: {player.Age}");
            }
        }

        static void AddPlayer(Players pl)
        {
            using (UnitOfWork context = new UnitOfWork())
            {
                context.PlayersRepository.Insert(pl);
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

    }
}
