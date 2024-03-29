﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class UserCabInvoService
    {
        public UserCabInvoService(List<Ride> rides, InvoiceSummary invoiceSummary1)
        {
            Rides = rides;
            InvoiceSummary = invoiceSummary1;
        }

        public List<Ride> Rides { get; }
        public InvoiceSummary InvoiceSummary { get; }

        //Method to check the specified object is equal to the instance
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is UserCabInvoService))
                return false;
            UserCabInvoService userCabService = (UserCabInvoService)obj;
            return this.Rides == userCabService.Rides && this.InvoiceSummary.totalFare == userCabService.InvoiceSummary.totalFare;
        }
    }
}

