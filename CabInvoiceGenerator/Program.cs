using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to cab invoice generator");
            CabInvoGenerator cabInvoiceGenerator = new CabInvoGenerator(RideType.NORMAL);
            Console.WriteLine(cabInvoiceGenerator.CalculateFare(10, 15));//UC1

            Ride[] multiRides = { new Ride(10, 15), new Ride(10, 15) };//UC2
            Console.WriteLine(cabInvoiceGenerator.CalculateAgreegateFare(multiRides));
            Console.ReadLine();
        }
    }
}
