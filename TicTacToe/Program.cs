/*
    Author: WenyaTheGoose
    Creation Date: 30.01.2023
    Version: 1.1.0
    Comment: Written without tutorials.
*/

namespace TicTacToe
{
    internal class Program
    {
        static void Main()
        {
            Player winner = Player.Noone;
            Player currentPlayer = Player.X;
            Gamefield.Draw();

            while (winner == Player.Noone)
            {
                if (Turn(currentPlayer))
                {
                    currentPlayer = SwapCurrentPlayer(currentPlayer);
                }
                Gamefield.Draw();
                winner = Gamefield.GetWinner(Gamefield.fields);
            }

            Console.WriteLine("Game has ended!");
            Console.WriteLine(Gamefield.PlayerToChar(winner) + " won!");
            Console.WriteLine("\nYou can close the game by pressing the enter key");
            Console.ReadLine();
        }

        private static bool Turn(Player player)
        {
            Console.Write("Enter X position to take: ");
            if (!int.TryParse(Console.ReadLine(), out int x)) return false;
            x = PosToGamepos(x);

            Console.Write("Enter Y position to take: ");
            if (!int.TryParse(Console.ReadLine(), out int y)) return false;
            y = PosToGamepos(y);

            if (Gamefield.fields.GetLength(0) <= y || Gamefield.fields.GetLength(1) <= x || y < 0 || x < 0)
            {
                Console.WriteLine("Entered wrong position!");
                return false;
            }

            if (Gamefield.fields[y, x] != ' ')
            {
                Console.WriteLine("Entered occupied position!");
                return false;
            }

            Gamefield.fields[y, x] = Gamefield.PlayerToChar(player);
            return true;
        }

        private static Player SwapCurrentPlayer(Player player)
        {
            if (player == Player.O) return Player.X;
            return Player.O;
        }

        private static int PosToGamepos(int num)
        {
            return num - 1;
        }
    }
}