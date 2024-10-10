using csvAccess.core.Models.Data.Columns;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataColumn dc = new DataColumn();
            dc.DataType = typeof(string);

            Console.WriteLine($"der typ ist {dc.DataType}");
        }
    }
}
