using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem04
{
    class Events
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"^#([a-zA-Z]*): *@([a-zA-Z]*) *(\d?\d:[0-5]?\d)$";
            var events = new Dictionary<string,SortedDictionary<string,List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                if (!Regex.IsMatch(line, pattern)) continue;
                string[] elements = Regex.Split(line, pattern);
                if (int.Parse(elements[3].Split(':')[0]) > 23) continue;
                var person = elements[1];
                var city = elements[2];
                if (events.ContainsKey(city))
                {
                    if (!events[city].ContainsKey(person))
                    {
                        events[city].Add(person, new List<string>());
                    }
                }
                else
                {
                    events.Add(city,new SortedDictionary<string, List<string>>());
                    events[city].Add(person, new List<string>());
                }

                events[city][person].Add(elements[3]);
            }

            var locations = Console.ReadLine().Split(',').ToList();
            locations.Sort();
            foreach (var location in locations)
            {
                if (!events.ContainsKey(location)) continue;
                Console.WriteLine("{0}:",location);

                int count = 1;
                foreach (var person in events[location].Keys)
                {
                    events[location][person].Sort();
                    Console.WriteLine("{0}. {1} -> {2}", count, person, string.Join(", ", events[location][person]));
                    count++;
                }
            }
        }
    }
}
