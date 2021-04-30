using System;
using System.Collections.Generic;
using System.Linq;
namespace BoardForSudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            bool s = ValidateSolution(new int[9][]
            {
                new int[]{8, 2, 6, 3, 4, 7, 5, 9, 1},
                new int[]{7, 3, 5, 8, 1, 9, 6, 4, 2},
                new int[]{1, 9, 4, 2, 6, 5, 8, 7, 3},
                new int[]{3, 1, 7, 5, 8, 4, 2, 6, 9},
                new int[]{6, 5, 9, 1, 7, 2, 4, 3, 8},
                new int[]{4, 8, 2, 9, 3, 6, 7, 1, 5},
                new int[]{9, 4, 8, 7, 5, 1, 3, 2, 6},
                new int[]{5, 6, 1, 4, 2, 3, 9, 8, 7},
                new int[]{2, 7, 3, 6, 9, 8, 1, 5, 4}
            });
            Console.WriteLine(s);
        }
        public static bool ValidateSolution(int[][] board)
        {
            
            for (int i = 0; i < 9; i++)
            {
                if (!MakeOneCheck(board[i])) return false;
            }
            for (int i = 0; i < 9; i++)
            {
                if (!MakeOneCheck(GetColumn(board, i))) return false;
            }
            for (int i = 0; i < 9; i++)
            {
                if (!MakeOneCheck(GetSquare(board, i))) return false;
            }
            return true;
        }
        private static int[] GetColumn(int[][] board, int col)
        {
            var column = new int[9];
            for (int i = 0; i < 9; i++)
            {
                column[i] = board[i][col];
            }
            return column;
        }
        private static int[] GetSquare(int[][] board, int NumberSquare)
        {
            var square = new int[9];
            for (int i = 0; i < 9;)
            {
                int startRow = (NumberSquare / 3) * 3;
                int startCol = (NumberSquare % 3) * 3;
                for (int j = startRow; j < startRow + 3; j++)
                {
                    for (int k = startCol; k < startCol + 3; k++)
                    {
                        square[i] = board[j][k];
                        i++;
                    }
                }
            }
            return square;
        }
        private static bool MakeOneCheck(int[] line)
        {
            var bLine = new bool[9];
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] >= 1 && line[i] <= 9)
                    bLine[line[i] - 1] = true;
                else
                    return false;
            }
            for (int i = 0; i < 9; i++)
            {
                if (!bLine[i]) return false;
            }
            return true;
        }
    }
}
