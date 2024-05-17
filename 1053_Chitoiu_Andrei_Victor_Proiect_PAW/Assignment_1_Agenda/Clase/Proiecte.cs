using Assignment_1_Agenda.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Agenda.Clase
{
    [Serializable]
    public class Proiecte
    {
        public int ID { get; set; }
        public String denumire { get; set; }
        public String coord { get; set; }
        public DateTime deadLine { get; set; }
        public Proiecte() {}

        public Proiecte(string denumire, string coord, DateTime deadLine)
        {
            this.denumire = denumire;
            this.coord = coord;
            this.deadLine = deadLine;
        }
    }
}
