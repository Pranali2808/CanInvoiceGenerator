using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CabInvoGeneratorException : Exception
    {
        public ExceptionType exceptionType;

        //Enum for Declaring constants
        public enum ExceptionType
        {
            INVALID_TIME,
            INVALID_DISTANCE,
            NULL_RIDES
        }

        //Parametrized constructor for custom exception
        public CabInvoGeneratorException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}