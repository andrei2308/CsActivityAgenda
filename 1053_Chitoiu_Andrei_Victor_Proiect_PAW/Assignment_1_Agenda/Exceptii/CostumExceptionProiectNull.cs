using System;
using System.Runtime.Serialization;

namespace Assignment_1_Agenda
{

    internal class CostumExceptionProiectNull : Exception
    {
        public override string Message
        {
            get
            {
                return "Aceasta activitate nu include un proiect";
            }
        }
    }
}