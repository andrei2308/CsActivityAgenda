using Assignment_1_Agenda.NewFolder1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_1_Agenda
{
    public partial class Stats : Form
    {
        List<Activitati> _instance;
        public Stats(List<Activitati> listactiv)
        {
            InitializeComponent();
            _instance = listactiv;

            int[] vect = new int[_instance.Count];
            int i = 0;
            foreach(Activitati each in _instance)
            {
                vect[i] = (each.timpFinish - each.timpStart).Days;
                i++;
            }
            grh.Observatii = vect;
        }
    }

    public class Histo : UserControl
    {
        int[] vobs = null;

        public int[] Observatii
        {
            get { return vobs; }
            set { vobs = value; Invalidate(); }
        }

        Rectangle[] get_rects(int x, int y, int w, int h)
        {
            Rectangle[] vr = new Rectangle[vobs.Length];
            int maxobs = vobs.Max();
            int db, lb, stg, hobs;
            db = w / (4 * vobs.Length + 1);
            lb = 3 * db;
            stg = x + db;
            for (int iter = 0; iter < vobs.Length; iter++)
            {
                hobs = (h * vobs[iter]) / maxobs;
                vr[iter].X = stg;
                vr[iter].Y = y + (h - hobs);
                vr[iter].Width = lb;
                vr[iter].Height = hobs;
                stg += lb + db;
            }
            return vr;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle r = this.ClientRectangle;
            Graphics g = e.Graphics;
            Pen pen = new Pen(Brushes.Black, 1);
            g.DrawRectangle(pen, r.X + 10, r.Y + 10, r.Width - 20, r.Height - 20);
            if (vobs != null)
            {
                g.FillRectangles(Brushes.DarkGreen, get_rects(r.X + 10, r.Y + 10, r.Width - 20, r.Height - 20));
            }
        }
    }

}
