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
    public partial class AgendaActiv : Form
    {

        public AgendaActiv()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            this.BackColor = Color.LightBlue;
            this.Text = "Agenda activitati";

            CustomizeButton(btnCreare, "Creare agenda", Color.Teal);
            CustomizeButton(btnDeschide, "Deschide agenda", Color.Teal);
            CustomizeButton(buttonExit, "Exit", Color.Red);

        }
        private void CustomizeButton(Button button, string text, Color backColor)
        {
            button.Text = text;
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = backColor;
            button.ForeColor = Color.White;
            button.Font = new Font("Arial", 12, FontStyle.Bold);
            button.FlatAppearance.BorderSize = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCreare_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreareAgenda creareAgenda = new CreareAgenda();
            creareAgenda.ShowDialog();
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeschide_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreareAgenda creareAgenda = new CreareAgenda(sender, e);
            creareAgenda.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
