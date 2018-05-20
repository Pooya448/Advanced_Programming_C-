using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment11
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines(@"..\..\Titanic.csv")
                .Skip(1)
                .Select(line => new TitanicData(line));

            Console.WriteLine($"Paid the highest fare: {data.GetMostExpensiveFare().Name}");
            Console.WriteLine($"Oldest person's name: {data.EldestPersonList().First().Name}");
            Console.WriteLine($"Oldest female's name: {data.EldestPersonList().EldestFemale().Name}");
            Console.WriteLine($"Total passengers: {data.TotalPassengers()}");
            Console.WriteLine($"Total Female passengers: {data.TotalFemalePassengers()}");
            Console.WriteLine($"Total number of survivors: {data.TotalNumberOfSurvivors()}");
            Console.WriteLine($"Percent of passengers who survived: {data.SurvivedPercent()}");
            Console.WriteLine($"Number of female Survivors: {data.TotalFemaleSurvived()}");
            Console.WriteLine($"Percent of females who survived: {data.TotalFemaleSurvivedPercent()}");
            Console.WriteLine($"Percent of survivors who were female: {data.WholeFemaleSurvivedPercent()}");
            Console.WriteLine($"Percent of kids under 10 who survived: {data.PercentOfUnder10Survived()}");
            Console.WriteLine($"Port of boarding with most survivors: {data.MostSurvivalPort().BoardingPort}");
            Console.WriteLine($"Port of boarding with most survivors percent: {data.PortWithMostPercent()}");
            Console.WriteLine($"The age group (age/10) with most passengers: {data.MostPassengerAgeGroup()}");
            Console.WriteLine($"The age group (age/10) with most survivors: {data.MostPassengerAgeGroupPercent()}");
            Console.ReadKey();
        }
    }


    public static class Extensions
    {
        public static Nullable<int> ParseIntOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? int.Parse(str) as Nullable<int> : null;

        public static Nullable<double> ParseDoubleOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? double.Parse(str) as Nullable<double> : null;

        public static TitanicData GetMostExpensiveFare(this IEnumerable<TitanicData> data)
            => data.OrderByDescending(x => x.Fare).First();

        public static IEnumerable<TitanicData> EldestPersonList(this IEnumerable<TitanicData> data)
            => data.OrderByDescending(z => z.Age);

        public static TitanicData EldestFemale(this IEnumerable<TitanicData> data)
            => data.Where(x => x.IsFemale).First();

        public static int TotalPassengers(this IEnumerable<TitanicData> data)
            => data.Count();

        public static int TotalFemalePassengers(this IEnumerable<TitanicData> data)
            => data.Where(x => x.IsFemale).Count();

        public static int TotalNumberOfSurvivors(this IEnumerable<TitanicData> data)
            => data.Where(x => x.Survived).Count();

        public static double SurvivedPercent(this IEnumerable<TitanicData> data)
            => 100 * ((double)data.TotalNumberOfSurvivors() / data.TotalPassengers());

        public static int TotalFemaleSurvived(this IEnumerable<TitanicData> data)
            => data.Where(x => x.IsFemale && x.Survived).Count();

        public static double TotalFemaleSurvivedPercent(this IEnumerable<TitanicData> data)
            => 100 * ((double)data.TotalFemaleSurvived() / data.TotalFemalePassengers());

        public static double WholeFemaleSurvivedPercent(this IEnumerable<TitanicData> data)
            => 100 * ((double)data.TotalFemaleSurvived() / data.TotalNumberOfSurvivors());

        public static double PercentOfUnder10Survived(this IEnumerable<TitanicData> data)
            => 100 * ((double)data.Where(x => x.Age < 10 && x.Survived).Count() / data.Where(x => x.Age < 10).Count());

        public static TitanicData MostSurvivalPort (this IEnumerable<TitanicData> data)
            => data.Where(x => x.Survived).GroupBy(x => x.BoardingPort).OrderByDescending(x => x.Count()).First().First();
        
        public static string PortWithMostPercent (this IEnumerable<TitanicData> data)
            => data.Where(x => x.BoardingPort != "").GroupBy(x => x.BoardingPort).Select(x => new
            {
                SurvivePercent = (double)((double)(x.Where(y => y.Survived).Count()) / (double)(x.Count())),
                PortName = x.First().BoardingPort
            }).OrderByDescending(r => r.SurvivePercent).First().PortName;

        public static string MostPassengerAgeGroup(this IEnumerable<TitanicData> data)
            => data.Where(x => x.Age != null).GroupBy(y => y.Age / 10).Select(p => new
            {
                groupRangeofAge = $"{10 * (int)p.Key} - {10 * (int)p.Key + 9}",
                numberOfGroup = p.Count()
            }).OrderByDescending(p => p.numberOfGroup).First().groupRangeofAge;

        public static string MostPassengerAgeGroupPercent(this IEnumerable<TitanicData> data)
           => data.Where(x => x.Age != null).GroupBy(y => y.Age / 10).Select(p => new
           {
               groupRangeofAge = $"{10 * (int)p.Key} - {10 * (int)p.Key + 9}",
               numberOfSurvivedInGroup = p.Where(r => r.Survived).Count()
           }).OrderByDescending(p => p.numberOfSurvivedInGroup).First().groupRangeofAge;
    }

    public class TitanicData
    {
        public TitanicData(string line)
        {
            var toks = line.Split(',');
            PassengerId = toks[0];
            Survived = toks[1] == "1";
            PClass = toks[2];
            Name = toks[3];
            IsFemale = toks[4] == "female";
            Age = toks[5].ParseDoubleOrNull();
            SibilingsOnBoard = toks[6].ParseIntOrNull();
            ParentsOnBoard = toks[7].ParseIntOrNull();
            Ticket = toks[8];
            Fare = double.Parse(toks[9]);
            Cabin = toks[10];
            BoardingPort = toks[11];
        }
        public string PassengerId;
        public bool Survived;
        public string PClass;
        public string Name;
        public bool IsFemale;
        public Nullable<double> Age;
        public Nullable<int> SibilingsOnBoard;
        public Nullable<int> ParentsOnBoard;
        public string Ticket;
        public double Fare;
        public string Cabin;
        public string BoardingPort;
    }
}
