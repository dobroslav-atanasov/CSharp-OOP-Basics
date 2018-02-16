namespace GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> bag = new Dictionary<string, Dictionary<string, long>>();
            bag.Add("Gold", new Dictionary<string, long>());
            bag.Add("Gem", new Dictionary<string, long>());
            bag.Add("Cash", new Dictionary<string, long>());

            long bagCapacity = long.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length - 1; i += 2)
            {
                string item = input[i];
                long quantity = long.Parse(input[i + 1]);

                long currentBagCapacity = CalculateTotalBagCapacity(bag);
                if (currentBagCapacity + quantity > bagCapacity)
                {
                    continue;
                }

                long amountOfCash = CalculateItemInBag(bag, "Cash");
                long amountOfGem = CalculateItemInBag(bag, "Gem");
                long amountOfGold = CalculateItemInBag(bag, "Gold");

                if (item.ToLower() == "gold")
                {
                    if (amountOfGold + quantity >= amountOfGem)
                    {
                        if (!bag["Gold"].ContainsKey(item))
                        {
                            bag["Gold"][item] = 0;
                        }
                        bag["Gold"][item] += quantity;
                    }
                }

                if (item.Length >= 4 && item.ToLower().EndsWith("gem"))
                {
                    if (amountOfGold >= amountOfGem + quantity && amountOfGem + quantity >= amountOfCash)
                    {
                        if (!bag["Gem"].ContainsKey(item))
                        {
                            bag["Gem"][item] = 0;
                        }
                        bag["Gem"][item] += quantity;
                    }
                }

                if (item.Length == 3)
                {
                    if (amountOfGem >= amountOfCash + quantity)
                    {
                        if (!bag["Cash"].ContainsKey(item))
                        {
                            bag["Cash"][item] = 0;
                        }
                        bag["Cash"][item] += quantity;
                    }
                }
            }

            foreach (KeyValuePair<string, Dictionary<string, long>> item in bag.Where(b => b.Value.Count > 0).OrderByDescending(i => i.Value.Sum(x => x.Value)))
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Sum(i => i.Value)}");
                foreach (KeyValuePair<string, long> kvp in item.Value.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
                {
                    Console.WriteLine($"##{kvp.Key} - {kvp.Value}");
                }
            }
        }

        private static long CalculateItemInBag(Dictionary<string, Dictionary<string, long>> bag, string item)
        {
            long sum = 0;
            foreach (KeyValuePair<string, Dictionary<string, long>> kvp in bag.Where(i => i.Key == item))
            {
                sum += kvp.Value.Sum(i => i.Value);
            }
            return sum;
        }

        private static long CalculateTotalBagCapacity(Dictionary<string, Dictionary<string, long>> bag)
        {
            long sum = 0;
            foreach (KeyValuePair<string, Dictionary<string, long>> item in bag)
            {
                foreach (KeyValuePair<string, long> kvp in item.Value)
                {
                    sum += kvp.Value;
                }
            }
            return sum;
        }
    }
}