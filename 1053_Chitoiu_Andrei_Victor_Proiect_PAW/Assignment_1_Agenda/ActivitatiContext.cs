using Assignment_1_Agenda.NewFolder1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Agenda
{
    [Serializable]
    public class ActivitatiContext:DbContext
    {
        public ActivitatiContext()
        {
            try
            {
                Database.Migrate();
            }
            catch (Exception)
            {
                Console.WriteLine("Baza deja existenta");
            }
        }

        public DbSet<Activitati> Activitatis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Activitati.db");
        }
    }
}
