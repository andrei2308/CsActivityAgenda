using System;
using System.Runtime.Serialization;

namespace Assignment_1_Agenda
{

    internal class CostumExceptionResurseNull : Exception
    {
        public override string Message
        {
            get
            {
                return "Aceasta domeniu nu necesita resurse";
            }
        }
    }
}