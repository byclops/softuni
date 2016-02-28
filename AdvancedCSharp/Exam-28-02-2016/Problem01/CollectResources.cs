using System;
using System.Collections.Generic;

namespace Problem01
{
    class CollectResources
    {
        static HashSet<string> validResources = new HashSet<string>() {"stone", "gold", "wood", "food" };

        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(' ');
            var resources = ParseResources(line);

            int n = int.Parse(Console.ReadLine());

            int maxValue = 0;
            for (int i = 0; i < n; i++)
            {
                string[] pathData = Console.ReadLine().Split(' ');
                int start = int.Parse(pathData[0]);
                int step = int.Parse(pathData[1]);

                int currentValue = CalculatePath(resources, start, step);
                if (currentValue > maxValue) maxValue = currentValue;
            }

            Console.WriteLine(maxValue);
        }

        static int CalculatePath(List<int> resources, int start, int step)
        {
            int result = 0;
            var collected = new HashSet<int>();
            int index = start;
            while (true)
            {
                if (collected.Contains(index)) break;
                result += resources[index];
                collected.Add(index);
                index += step;
                if (index >= resources.Count)
                {
                    index = index%resources.Count;
                }
            }

            return result;
        }

        static List<int> ParseResources(string[] input)
        {
            var result = new List<int>();
            foreach (var element in input)
            {
                string[] data = element.Split('_');
                int value = 1;
                if (data.Length > 1) value = int.Parse(data[1]);
                if (!validResources.Contains(data[0])) result.Add(0);
                else
                {
                    result.Add(value);
                }
            }

            return result;
        }
    }
}
