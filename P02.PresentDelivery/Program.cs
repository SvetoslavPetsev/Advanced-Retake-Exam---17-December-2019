namespace P02.PresentDelivery
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            int santaRow = 0;
            int santaCol = 0;

            char[,] playground = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                char[] row = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();
                for (int j = 0; j < row.Length; j++)
                {
                    if (row[j] == 'S')
                    {
                        santaRow = i;
                        santaCol = j;
                        row[j] = '-';
                    }
                    playground[i, j] = row[j];
                }
            }
            int niceChildWithGift = 0;
            string command;
            while ((command = Console.ReadLine()) != "Christmas morning")
            {
                playground[santaRow, santaCol] = '-';

                if (command == "up")
                {
                    santaRow--;
                }
                else if (command == "down")
                {
                    santaRow++;
                }
                else if (command == "left")
                {
                    santaCol--;
                }
                else if (command == "right")
                {
                    santaCol++;
                }

                if (playground[santaRow, santaCol] == 'C')
                {
                    int[] coordArea = new int[4] { 1, -1, 1, -1 };
                    for (int i = 0; i < coordArea.Length; i++)
                    {
                        int addRow = 0;
                        int addCol = 0;
                        if (i < 2)
                        {
                            addRow += coordArea[i];
                        }
                        else
                        {
                            addCol += coordArea[i];
                        }
                        int newSantaRow = santaRow + addRow;
                        int newSantaCol = santaCol + addCol;
                        if (playground[newSantaRow, newSantaCol] != '-')
                        {
                            if (playground[newSantaRow, newSantaCol] == 'V')
                            {
                                niceChildWithGift++;
                            }
                            playground[newSantaRow, newSantaCol] = '-';
                            presentsCount--;
                        }
                    }
                }
                else if (playground[santaRow, santaCol] != '-')
                {
                    if (playground[santaRow, santaCol] == 'V')
                    {
                        niceChildWithGift++;
                        presentsCount--;
                    }

                }
                playground[santaRow, santaCol] = 'S';

                if (presentsCount == 0)
                {
                    Console.WriteLine("Santa ran out of presents!");
                    break;
                }
            }
            int countNoPresent = 0;
            for (int i = 0; i < playground.GetLength(0); i++)
            {
                for (int j = 0; j < playground.GetLength(1); j++)
                {
                    char symbol = playground[i, j];
                    if (symbol == 'V')
                    {
                        countNoPresent++;
                    }
                    Console.Write(playground[i, j] + " ");
                }
                Console.WriteLine();
            }

            if (countNoPresent > 0)
            {
                Console.WriteLine($"No presents for {countNoPresent} nice kid/s.");
            }
            else
            {
                Console.WriteLine($"Good job, Santa! {niceChildWithGift} happy nice kid/s.");
            }
        }
    }
}
