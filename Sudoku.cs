using System;
using System.Collections.Generic;

namespace Sudoku
{
    internal partial class Program
    {
        public class Sudoku
        {
            public char[,] Board { get; set; }

            public Sudoku()
            {
                Board = new char[9, 9];
                for (int i = 0; i < 9; i++)
                {
                    Console.Write($"Enter row {i + 1}, separated by spaces: ");
                    string line = Console.ReadLine();
                    string[] lineArray = line.Split(' ');
                    if (lineArray.Length != 9)
                        throw new Exception("Invalid entry");
                    for (int j = 0; j < 9; j ++)
                    {
                        Board[i,j] = lineArray[j][0];
                    }
                }
            }
            public void Solve()
            {
                bool madeAChange = true;
                while (madeAChange)
                {
                    madeAChange = false;
                    for (int row = 0; row < 9; row++)
                    {
                        for (int col = 0; col < 9; col++)
                        {
                            if (Board[row, col] != '.')
                            {
                                continue;
                            }
                            List<char> possible = GetAvailableNumbers(row, col);
                            if (possible.Count == 1)
                            {
                                Board[row, col] = possible[0];
                                madeAChange = true;
                                continue;
                            }
                            //with remaining numbers, check across, exclude immediates
                            CheckAcross(row, col, possible);
                            if (possible.Count == 1)
                            {
                                Board[row, col] = possible[0];
                                madeAChange = true;
                                continue;
                            }
                            //with remaining numbers, check down, exclude immediates
                            CheckDown(row, col, possible);
                            if (possible.Count == 1)
                            {
                                Board[row, col] = possible[0];
                                madeAChange = true;
                                continue;
                            }
                        }
                    }
                }
                if(!IsSolved())
                    Console.WriteLine("I couldn't solve this one.");
            }
            private List<char> GetAvailableNumbers(int row, int col)
            {
                int rowAdjustment = row / 3;
                int colAdjustment = col / 3;
                List<char> numbers = new List<char>() { '1','2','3','4','5','6','7','8','9'};
                for(int i = rowAdjustment * 3; i < 3 + (rowAdjustment * 3); i++)
                {
                    for(int j = colAdjustment * 3; j < 3 + (colAdjustment * 3); j++)
                    {
                        if (Board[i, j] != '.')
                            numbers.Remove(Board[i, j]);
                    }
                }
                return numbers;
            }
            private void CheckAcross(int row, int col, List<char> possible)
            {
                int rowAdjustment = row / 3;
                for (int i = 0; i < 9; i++)
                {
                        if (Board[row, i] != '.')
                            possible.Remove(Board[row, i]);

                }
            }
            private void CheckDown(int row, int col, List<char> possible)
            {
                int colAdjustment = col / 3;
                for (int i = 0; i < 9; i++)
                {
                        if (Board[i, col] != '.')
                            possible.Remove(Board[i, col]);

                }
            }
            public void Print()
            {
                for(int row = 0; row < 9; row ++)
                {
                    for(int col = 0; col < 9; col ++)
                    {
                        if(Board[row, col] != '.')
                            Console.Write(Board[row, col] + " ");
                        else
                            Console.Write("  ");
                        if (col % 3 == 2 && col != 8)
                            Console.Write("| ");
                    }
                    Console.WriteLine();
                    if(row % 3 == 2 && row!=8)
                        Console.WriteLine("_ _ _   _ _ _   _ _ _\n");
                }
                Console.WriteLine();
            }
            private bool IsSolved()
            {
                for(int i = 0; i < 9; i ++)
                {
                    for(int j = 0; j < 9; j ++)
                    {
                        if (Board[i, j] == '.')
                            return false;
                    }
                }
                return true;
            }
        }
    }

}
