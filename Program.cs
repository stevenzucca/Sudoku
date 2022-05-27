using System;

namespace Sudoku
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Sudoku Solver!");
            Console.WriteLine("When prompted, enter . for a blank tile");
            try
            {
                Sudoku sudoku = new Sudoku();
                sudoku.Print();
                sudoku.Solve();
                sudoku.Print();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }

}
