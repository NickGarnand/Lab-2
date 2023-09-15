using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class Videogames : IComparable<Videogames>
    {
        public string Name { get; set; }
        public string Platform { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string NASales { get; set; }
        public string EUSales { get; set; }
        public string JPSales { get; set; }
        public string OtherSales { get; set; }
        public string GlobalSales { get; set; }

        public Videogames() { } 

        public Videogames(string name, string platform, string year, string genre, string publisher, string nASales, string eUSales, string jPSales, string otherSales, string globalSales)
        {
            Name = name;
            Platform = platform;
            Year = year;
            Genre = genre;
            Publisher = publisher;
            NASales = nASales;
            EUSales = eUSales;
            JPSales = jPSales;
            OtherSales = otherSales;
            GlobalSales = globalSales;
        }

        public int CompareTo(Videogames? other)
        {
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            string toReturn = "---------------------------------------------------------------\n";
            toReturn += $"Name: {Name}\n";
            toReturn += $"Platform:  {Platform}\n";
            toReturn += $"Year: {Year}\n";
            toReturn += $"Genre: {Genre}\n";
            toReturn += $"Publisher: {Publisher}\n";
            toReturn += $"North America Sales: {NASales}\n";
            toReturn += $"European Sales: {EUSales}\n";
            toReturn += $"Japan Sales: {JPSales}\n";
            toReturn += $"Other Sales: {OtherSales}\n";
            toReturn += $"Global Sales: {GlobalSales}\n";
            toReturn += $"-------------------------------------------------------------------\n";
            return toReturn;
        }
    }
}
