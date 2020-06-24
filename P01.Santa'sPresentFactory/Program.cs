namespace P01.Santa_sPresentFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Dictionary<int, string> presents = new Dictionary<int, string>
            {
                {150, "Doll" },
                {250, "Wooden train"},
                {300, "Teddy bear"},
                {400, "Bicycle"}
            };

            int[] first = GetArrayFromConsole();
            int[] second = GetArrayFromConsole();

            Stack<int> materials = new Stack<int>(first);
            Queue<int> magic = new Queue<int>(second);
            Dictionary<string, int> createdPrsents = new Dictionary<string, int>();

            while (materials.Any() && magic.Any())
            {
                int combination = materials.Peek() * magic.Peek();

                if (presents.ContainsKey(combination))
                {
                    if (!createdPrsents.ContainsKey(presents[combination]))
                    {
                        createdPrsents.Add(presents[combination], 0);
                    }

                    createdPrsents[presents[combination]]++;
                    materials.Pop();
                    magic.Dequeue();
                }
                else
                {
                    if (combination < 0)
                    {
                        combination = materials.Peek() + magic.Peek();
                        materials.Pop();
                        materials.Push(combination);
                        magic.Dequeue();
                    }

                    else if (combination > 0)
                    {
                        combination = materials.Peek() + 15;
                        materials.Pop();
                        materials.Push(combination);
                        magic.Dequeue();
                    }

                    else if (combination == 0)
                    {
                        if (materials.Peek() == 0)
                        {
                            materials.Pop();
                        }
                        if (magic.Peek() == 0)
                        {
                            magic.Dequeue();
                        }
                    }
                }
            }

            if (createdPrsents.ContainsKey("Doll") && createdPrsents.ContainsKey("Wooden train")
                || createdPrsents.ContainsKey("Teddy bear") && createdPrsents.ContainsKey("Bicycle"))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }

            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Any())
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }

            if (magic.Any())
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magic)}");
            }

            foreach (var present in createdPrsents.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{present.Key}: {present.Value}");
            }
        }

        public static int[] GetArrayFromConsole()
        {
            return Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
        }
    }
}
