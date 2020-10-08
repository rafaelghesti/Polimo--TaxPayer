using Polimo__TaxPayer.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Polimo__TaxPayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            List<TaxPayer> collection = new List<TaxPayer>();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"\n## Tax payer #{i} ##");
                Console.Write("Individual(i) or Company(c): ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual Income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(ch == 'i')
                {
                    Console.Write("Health expediture: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    collection.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());
                    collection.Add(new Company(name, anualIncome, numberOfEmployees));
                }
            }

            Console.WriteLine("\n## TAXES PAID ##");
            double sum = 0;
            foreach (TaxPayer payer in collection)
            {
                double tax = payer.Tax();
                Console.WriteLine($"{payer.Name}: ${tax.ToString("F2", CultureInfo.InvariantCulture)}");
                sum += tax;
            }
            Console.WriteLine($"\n## TOTAL TAXES: ${sum.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}
