using System;
using System.Runtime.Serialization;

namespace Assignment_1_Agenda
{
    internal class CostumExceptionTipActiv : Exception
    {
        public override string Message
        {
            get
            {
                return "Selectati un tip de activitate";
            }
        }
    }
}