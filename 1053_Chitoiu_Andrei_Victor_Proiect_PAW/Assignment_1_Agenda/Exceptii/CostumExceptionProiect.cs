using System;
using System.Runtime.Serialization;

namespace Assignment_1_Agenda
{

    internal class CostumExceptionProiect : Exception
    {
        public override string Message
        {
            get
            {
                return "Adaugati un Proiect si un Coordonator";
            }
        }
    }
}