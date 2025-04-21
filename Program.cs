using System.Globalization;
using System.Runtime.CompilerServices;

namespace Mahjong
{
    class Program
    {
        public static void Main()
        {
            ComponentManager componentManager = new();
            BoardManager board = new(componentManager);
            /*
            foreach (int num in board.tileEntities)
            {
                Console.Write("\n\n" + num + ". " + componentManager.GetComponent<TileCodeComponent>(num).Code);

                Console.Write("\n\n" + num + ". " + componentManager.GetComponent<TileComponent>(num).Suit + ": ");
                foreach (var comp in componentManager.GetEntityComponents(num))
                {
                    Console.Write(comp);
                    Console.Write(", ");
                }
            }

            */

            
            board.VerifyTiles(componentManager, false);

            Console.WriteLine("\n\n=======\n\n");

            board.Shuffle();
            board.VerifyTiles(componentManager, false);
        }
    }
}