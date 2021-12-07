using System;
using System.Collections.Generic;
using System.IO;

namespace Kerites
{
    class Fence
    {
        public int Width { get; set; } = 0;
        public string Color { get; set; } = "";
    }
    class Plot
    {
        public int Side { get; set; } = 0;
        public int Number { get; set; } = 0;
        public Fence Fence = new();
    }
    class Sale
    {
        public Plot Plot = new();
        public Sale()
        {

        }
        public Sale(string line)
        {
            ParseLine(line);
        }
        void ParseLine(string line)
        {
            string[] values = line.Split(' ');
            Plot.Side = int.Parse(values[0]);
            Plot.Fence.Width = int.Parse(values[1]);
            Plot.Fence.Color = values[2];
        }
    }
    class Program
    {
        static List<Sale> Sales = new();
        static List<Sale> Even = new();
        static List<Sale> Uneven = new();

        static void Main(string[] args)
        {
            ParseFile("kerites.txt");
        }

        static void ParseFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            int lastEven = 2;
            int lastUneven = 1;

            foreach(string line in lines)
            {
                Sale sale = new(line);

                if(sale.Plot.Side == 0)
                {
                    sale.Plot.Number = lastEven;
                    lastEven += 2;
                    Even.Add(sale);
                }
                else if(sale.Plot.Side == 1)
                {
                    sale.Plot.Number = lastUneven;
                    lastUneven += 2;
                    Uneven.Add(sale);
                }

                Sales.Add(sale);
            }
        }
    }
}
