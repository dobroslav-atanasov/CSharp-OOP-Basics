namespace CatLady
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<Cat> cats = new List<Cat>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputParts = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string catType = inputParts[0];
                string name = inputParts[1];
                switch (catType)
                {
                    case "Siamese":
                        double earSize = double.Parse(inputParts[2]);
                        Siamese siamese = new Siamese(name, earSize);
                        cats.Add(siamese);
                        break;
                    case "Cymric":
                        double furLength = double.Parse(inputParts[2]);
                        Cymric cymric = new Cymric(name, furLength);
                        cats.Add(cymric);
                        break;
                    case "StreetExtraordinaire":
                        double decibelsOfMeows = double.Parse(inputParts[2]);
                        StreetExtraordinaire streetExtraordinaire = new StreetExtraordinaire(name, decibelsOfMeows);
                        cats.Add(streetExtraordinaire);
                        break;
                }
                input = Console.ReadLine();
            }

            string searchedCat = Console.ReadLine();
            Cat cat = cats.FirstOrDefault(c => c.Name == searchedCat);
            Console.WriteLine(cat);
        }
    }
}