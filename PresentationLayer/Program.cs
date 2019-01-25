using System;

namespace PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isBeginning = true;
            int input, id, teamId;

            while (isBeginning)
            {
                Presenter.Info();
                input = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (input)
                {
                    case 1:
                        {
                            Console.WriteLine("All players from all teams:");
                            Presenter.GetAll();
                            Presenter.Clear();
                        } break;

                    case 2:
                        {
                            Console.Write("Enter player`s id: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            Presenter.GetPlayerById(id);
                            Presenter.Clear();
                        } break;

                    case 3:
                        {
                            Presenter.AddPlayer();
                            Console.WriteLine("A new player was added!");
                            Presenter.Clear();
                        } break;

                    case 4:
                        {
                            Console.Write("Enter player`s id: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            Presenter.DeleteById(id);
                            Console.WriteLine("The player was deleted!");
                            Presenter.Clear();
                        } break;

                    case 5:
                        {
                            Console.Write("Enter player`s id: ");
                            id = Convert.ToInt32(Console.ReadLine());


                            Console.WriteLine("Choose player`s team:");
                            Console.WriteLine("1. Dynamo Kyiv");
                            Console.WriteLine("2. Real Madrid");
                            teamId = Convert.ToInt32(Console.ReadLine());

                            Presenter.MakeTransfer(id, teamId);
                            Presenter.Clear();

                        } break;

                    case 6: isBeginning = false; break;

                    default: Console.WriteLine("You have choosen incorrect option!!!\nPlease try once more"); break;
                }
            }
        }    
    }
}
