using System;

namespace ConnectFourGame
{
    public class GameBoard
    {
        private char[,] board = new char[6, 7];

        public GameBoard()
        {
            for (int r = 0; r < 6; r++)
                for (int c = 0; c < 7; c++)
                    board[r, c] = '.';
        }

        public void Display()
        {
            Console.WriteLine("\n1 2 3 4 5 6 7");
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 7; c++)
                    Console.Write(board[r, c] + " ");
                Console.WriteLine();
            }
        }

        public bool DropPiece(int column, char symbol)
        {
            for (int r = 5; r >= 0; r--)
            {
                if (board[r, column] == '.')
                {
                    board[r, column] = symbol;
                    return true;
                }
            }
            return false; // Column full
        }

        public bool IsFull()
        {
            for (int c = 0; c < 7; c++)
                if (board[0, c] == '.')
                    return false;
            return true;
        }

        public bool CheckWin(char symbol)
        {
            // Horizontal
            for (int r = 0; r < 6; r++)
                for (int c = 0; c < 4; c++)
                    if (board[r, c] == symbol && board[r, c + 1] == symbol &&
                        board[r, c + 2] == symbol && board[r, c + 3] == symbol)
                        return true;

            // Vertical
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 7; c++)
                    if (board[r, c] == symbol && board[r + 1, c] == symbol &&
                        board[r + 2, c] == symbol && board[r + 3, c] == symbol)
                        return true;

            // Diagonal (down-right)
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 4; c++)
                    if (board[r, c] == symbol && board[r + 1, c + 1] == symbol &&
                        board[r + 2, c + 2] == symbol && board[r + 3, c + 3] == symbol)
                        return true;

            // Diagonal (up-right)
            for (int r = 3; r < 6; r++)
                for (int c = 0; c < 4; c++)
                    if (board[r, c] == symbol && board[r - 1, c + 1] == symbol &&
                        board[r - 2, c + 2] == symbol && board[r - 3, c + 3] == symbol)
                        return true;

            return false;
        }
    }
}
