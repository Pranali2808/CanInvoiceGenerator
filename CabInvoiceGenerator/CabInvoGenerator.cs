using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CabInvoGenerator
    {
        public readonly int MINIMUM_FARE;
        public readonly int COST_PER_KM;
        public readonly int COST_PER_MINUTE;

        // Parameterized constructor
        public CabInvoGenerator(RideType type)
        {
            if (type.Equals(RideType.NORMAL))
            {
                COST_PER_KM = 10;
                COST_PER_MINUTE = 1;
                MINIMUM_FARE = 5;
            }
        }

        // UC1 - Method to calculate fare for single ride
        public double CalculateFare(int time, double distance)
        {
            double totalFare;
            try
            {
                if (time <= 0)
                    throw new CabInvoGeneratorException(CabInvoGeneratorException.ExceptionType.INVALID_TIME, "Invalid Time");
                if (distance <= 0)
                    throw new CabInvoGeneratorException(CabInvoGeneratorException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                //Total fare for single ride
                totalFare = (distance * COST_PER_KM) + (time * COST_PER_MINUTE);
                //Comparing minimum fare and calculated fare to return the maximum fare
                return Math.Max(totalFare, MINIMUM_FARE);
            }
            catch (CabInvoGeneratorException ex)
            {
                throw ex;
            }
        }
        public InvoiceSummary CalculateAgreegateFare(Ride[] rides)
        {
            double totalFare = 0;
            if (rides.Length == 0)
                throw new CabInvoGeneratorException(CabInvoGeneratorException.ExceptionType.NULL_RIDES, "No Rides Found");
            foreach (var ride in rides)
            {
                totalFare += CalculateFare(ride.time, ride.distance);
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }
    }
}