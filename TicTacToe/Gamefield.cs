using System.Runtime.CompilerServices;

namespace TicTacToe
{
    public enum Player
    {
        X,
        O,
        Draw,
        Noone
    }

    public class Gamefield
    {
        // Next time i will use not static fields and methods
        public static char[,] fields = new char[3, 3] {
        {' ', ' ', ' '},
        {' ', ' ', ' '},
        {' ', ' ', ' '}};

        public static void Draw()
        {
            for (int y = 0; y < fields.GetLength(0); y++)
            {
                for (int x = 0; x < fields.GetLength(1); x++)
                {
                    Console.Write(fields[y, x] + " ");
                }
                Console.Write('\n');
            }
        }

        public static Player GetWinner(char[,] fields)
        {
            Player Winner;
            Winner = GetRowWinner(fields);
            if (Winner != Player.Noone) return Winner;
            Winner = GetColumnWinner(fields);
            if (Winner != Player.Noone) return Winner;
            Winner = GetDiagonalWinner(fields);
            if (Winner != Player.Noone) return Winner;

            if (IsGameDraw(fields)) return Player.Draw;
            return Player.Noone;
        }

        private static Player GetRowWinner(char[,] fields)
        {
            for (int y = 0; y < fields.GetLength(0); y++)
            {
                char winCandidate = fields[y, 0];
                if (Char.IsWhiteSpace(winCandidate)) continue;
                bool isCandidateWon = true;
                for (int x = 1; x < fields.GetLength(1); x++)
                {
                    if (fields[y, x] != winCandidate)
                    {
                        isCandidateWon = false;
                        break;
                    }
                }
                if (isCandidateWon) return CharToPlayer(winCandidate);
            }
            return Player.Noone;
        }

        private static Player GetColumnWinner(char[,] fields)
        {
            for (int x = 0; x < fields.GetLength(1); x++)
            {
                char winCandidate = fields[0, x];
                if (Char.IsWhiteSpace(winCandidate)) continue;
                bool isCandidateWon = true;
                for (int y = 1; y < fields.GetLength(0); y++)
                {
                    if (fields[y, x] != winCandidate)
                    {
                        isCandidateWon = false;
                        break;
                    }
                }
                if (isCandidateWon) return CharToPlayer(winCandidate);
            }
            return Player.Noone;
        }

        private static Player GetDiagonalWinner(char[,] fields)
        {
            //Check main diagonal
            char winCandidate = fields[0, 0];
            if (!Char.IsWhiteSpace(winCandidate))
            {
                if (winCandidate == fields[1, 1] && winCandidate == fields[2, 2])
                {
                    return CharToPlayer(winCandidate);
                }
            }
            //Check another diagonal
            winCandidate = fields[2, 0];
            if (!Char.IsWhiteSpace(winCandidate))
            {
                if (winCandidate == fields[1, 1] && winCandidate == fields[0, 2])
                {
                    return CharToPlayer(winCandidate);
                }
            }
            return Player.Noone;
        }

        private static bool IsGameDraw(char[,] fields)
        {
            foreach (char field in fields)
            {
                if (Char.IsWhiteSpace(field)) return false;
            }
            return true;
        }

        private static Player CharToPlayer(char toPlayer)
        {
            if (toPlayer == 'O') return Player.O;
            else if (toPlayer == 'X') return Player.X;
            return Player.Noone;
        }

        public static char PlayerToChar(Player toChar)
        {
            if (toChar == Player.O) return 'O';
            else if (toChar == Player.X) return 'X';
            return ' ';
        }
    }
}
