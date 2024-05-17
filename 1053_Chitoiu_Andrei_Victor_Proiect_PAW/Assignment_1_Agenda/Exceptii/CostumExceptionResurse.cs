using System;
using System.Runtime.Serialization;

namespace Assignment_1_Agenda
{
    internal class CostumExceptionResurse : Exception
    {
        public override string Message
        {
            get
            {
                return "Adaugati resursa";
            }
        }
    }
}