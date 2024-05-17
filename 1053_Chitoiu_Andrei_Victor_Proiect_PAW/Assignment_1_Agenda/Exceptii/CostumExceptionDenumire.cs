using System;
using System.Runtime.Serialization;

namespace Assignment_1_Agenda
{

    internal class CostumExceptionDenumire : Exception
    {
        public override string Message
        {
            get
            {
                return "Denumire necompletata";
            }
        }
    }
}