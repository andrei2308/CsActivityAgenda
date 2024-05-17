using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Agenda.Clase
{
    [Serializable]
    public class Domenii
    {
        public int ID { get; set; }
        public String DenumireDomeniu { get; set; }
        public bool NecesitateResurse { get; set; }
        public String Resursa { get; set; }

        public Domenii(string denumireDomeniu, bool necesitateResurse, string resurse)
        {
            DenumireDomeniu = denumireDomeniu;
            NecesitateResurse = necesitateResurse;
            Resursa = resurse;
        }

        public Domenii() { }
    };
}
