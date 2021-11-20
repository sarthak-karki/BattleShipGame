using System;
using System.Collections.Generic;

namespace BattleShipGame
{
    public class Board
    {
        public IList<Cells> Cells { get; set; }

        public Board()
        {
            Cells = new List<Cells>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Cells.Add(new Cells(i, j));
                }
            }
        }

        public void DisplayBoard()
        {
            Console.WriteLine("Board:");

            for (int row = 1; row <= 10; row++)
            {
                for (int ownColumn = 1; ownColumn <= 10; ownColumn++)
                {
                    Console.Write(Cells.At(row, ownColumn).CellStatus + " ");
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
