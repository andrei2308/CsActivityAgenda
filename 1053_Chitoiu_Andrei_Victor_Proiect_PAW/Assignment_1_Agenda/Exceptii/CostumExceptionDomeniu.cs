using System;
using System.Runtime.Serialization;

namespace Assignment_1_Agenda
{

    internal class CostumExceptionDomeniu : Exception
    {
        public override string Message
        {
            get
            {
                return "Completati cu un domeniu";
            }
        }
    }
}