using Assignment_1_Agenda.Clase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Agenda.NewFolder1
{
    [Serializable]
    public class Activitati
    {
        public int ID { get; set; }
        public String denumire { get; set; }
        public EnumTipActivitati tipAct { get; set; }
        public DateTime timpStart { get; set; }
        public DateTime timpFinish { get; set; }
        public bool necesitaProiect { get; set; }
        public Domenii domeniu { get; set; }
        public Proiecte proiect { get; set; }

        public Activitati(){}

        public Activitati(string denumire, EnumTipActivitati tipAct, DateTime timpStart, DateTime timpFinish, bool NecesitaProiect, Domenii domeniu, Proiecte proiect)
        {
            this.denumire = denumire;
            this.tipAct = tipAct;
            this.timpStart = timpStart;
            this.timpFinish = timpFinish;
            this.necesitaProiect = NecesitaProiect;
            this.domeniu = domeniu;
            this.proiect = proiect;
        }
    }
}
