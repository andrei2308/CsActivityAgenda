using Assignment_1_Agenda.Clase;
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
using System.Media;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Printing;
using System.Threading;

namespace Assignment_1_Agenda
{
    public partial class CreareAgenda : Form
    {
        List<Activitati> listaActiv = new List<Activitati>();

        public CreareAgenda()
        {
            InitializeComponent();
            this.BackColor = Color.Azure;
        }

        public CreareAgenda(object sender, EventArgs e)
        {
            InitializeComponent();
            importToolStripMenuItem_Click(sender, e);
            this.BackColor = Color.Azure;
        }

        private void CreareAgenda_Load(object sender, EventArgs e)
        {

        }

        #region ErrorProviders
        private void tbDenumire_Validating(object sender, CancelEventArgs e)
        {
            String value = tbDenumire.Text;
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                errorProviderDenumire.SetError((Control)sender, "Completeaza denumirea");
                e.Cancel = true;
            }
        }

        private void tbDenumire_Validated(object sender, EventArgs e)
        {
            errorProviderDenumire.Clear();
        }

        private void textBoxResurse_Validating(object sender, CancelEventArgs e)
        {
            String value = textBoxResurse.Text;
            if (checkBoxResurse.Checked == false && (!String.IsNullOrEmpty(value) || !String.IsNullOrWhiteSpace(value)))
            {
                errorProviderResurse.SetError((Control)sender, "Acest domeniu nu necesita resurse");
                e.Cancel = true;
            }

            if (checkBoxResurse.Checked == true && (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value)))
            {
                errorProviderResurse.SetError((Control)sender, "Acest domeniu necesita resurse");
                e.Cancel = true;
            }
        }

        private void textBoxResurse_Validated(object sender, EventArgs e)
        {
            errorProviderResurse.Clear();
        }

        private void cbTipActiv_Validating(object sender, CancelEventArgs e)
        {
            if (cbTipActiv.SelectedIndex == -1)
            {
                errorProviderTipActiv.SetError((Control)sender, "Selectati un tip de activitate");
                e.Cancel = true;
            }
        }

        private void cbTipActiv_Validated(object sender, EventArgs e)
        {
            errorProviderTipActiv.Clear();
        }

        private void dateTimeIncheiere_Validating(object sender, CancelEventArgs e)
        {
            DateTime dataIncepere = dateTimePickerIncepere.Value;
            DateTime dataIncheiere = dateTimeIncheiere.Value;

            if (DateTime.Compare(dataIncepere, dataIncheiere) > 0)
            {
                errorProviderDataIncheiere.SetError((Control)sender, "Data incheiere mai devreme decat Data incepere");
                e.Cancel = true;
            }
        }

        private void dateTimeIncheiere_Validated(object sender, EventArgs e)
        {
            errorProviderDataIncheiere.Clear();
        }

        private void textBoxDomeniu_Validating(object sender, CancelEventArgs e)
        {
            String value = textBoxDomeniu.Text;
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                errorProviderDomeniu.SetError((Control)sender, "Trebuie sa existe un domeniu");
                e.Cancel = true;
            }
        }

        private void textBoxDomeniu_Validated(object sender, EventArgs e)
        {
            errorProviderDomeniu.Clear();
        }

        private void textBoxProiect_Validating(object sender, CancelEventArgs e)
        {
            String value = textBoxProiect.Text;
            if (checkBoxProiect.Checked == false && (!String.IsNullOrEmpty(value) || !String.IsNullOrWhiteSpace(value)))
            {
                errorProviderProiect.SetError((Control)sender, "Acesta activitate nu include si un proiect");
                e.Cancel = true;
            }

            if (checkBoxProiect.Checked == true && (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value)))
            {
                errorProviderProiect.SetError((Control)sender, "Acesta activitate include un proiect");
                e.Cancel = true;
            }
        }

        private void textBoxProiect_Validated(object sender, EventArgs e)
        {
            errorProviderProiect.Clear();
        }

        private void textBoxCoord_Validating(object sender, CancelEventArgs e)
        {
            String value = textBoxCoord.Text;
            if (checkBoxProiect.Checked == false && (!String.IsNullOrEmpty(value) || !String.IsNullOrWhiteSpace(value)))
            {
                errorProviderProiect.SetError((Control)sender, "Acesta activitate nu include si un proiect");
                e.Cancel = true;
            }

            if (checkBoxProiect.Checked == true && (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value)))
            {
                errorProviderProiect.SetError((Control)sender, "Acesta activitate include un proiect");
                e.Cancel = true;
            }
        }

        private void textBoxCoord_Validated(object sender, EventArgs e)
        {
            errorProviderProiect.Clear();
        }

        private void dateTimePickerDeadLine_Validating(object sender, CancelEventArgs e)
        {
            DateTime datadeadline = dateTimePickerDeadLine.Value;
            DateTime dataIncepere = dateTimePickerIncepere.Value;
            DateTime dataIncheiere = dateTimeIncheiere.Value;

            if (checkBoxProiect.Checked == false)
            {
                errorProviderDeadLine.SetError((Control)sender, "Aceasta activitate nu include realizarea unui proiect");
                e.Cancel = true;
            }

            if (DateTime.Compare(dataIncepere, datadeadline) > 0)
            {
                errorProviderDeadLine.SetError((Control)sender, "DeadLine-ul nu se incadreaza in intervalul alocat activitatii");
                e.Cancel = true;
            }

            if (DateTime.Compare(datadeadline, dataIncheiere) > 0)
            {
                errorProviderDeadLine.SetError((Control)sender, "DeadLine-ul nu se incadreaza in intervalul alocat activitatii");
                e.Cancel = true;
            }
        }

        private void dateTimePickerDeadLine_Validated(object sender, EventArgs e)
        {
            errorProviderDeadLine.Clear();
        }


        #endregion

        #region CRUD
        private void buttonCurata_Click(object sender, EventArgs e)
        {
            CurataCampuri();
        }

        private void CurataCampuri()
        {
            tbDenumire.Clear();
            cbTipActiv.SelectedIndex = -1;
            dateTimePickerIncepere.Value = DateTime.Now;
            dateTimeIncheiere.Value = DateTime.Now;
            textBoxDomeniu.Clear();
            checkBoxResurse.Checked = false;
            textBoxResurse.Clear();
            textBoxProiect.Clear();
            textBoxCoord.Clear();
            dateTimePickerDeadLine.Value = DateTime.Now;
            checkBoxProiect.Checked = false;
        }

        private void buttonAdaugaActiv_Click(object sender, EventArgs e)
        {

            String denumire = tbDenumire.Text;
            Enum.TryParse(cbTipActiv.Text, out EnumTipActivitati tipActiv);
            DateTime incepere = dateTimePickerIncepere.Value;
            DateTime incheiere = dateTimeIncheiere.Value;
            Domenii domeniul = new Domenii(textBoxDomeniu.Text, checkBoxResurse.Checked, textBoxResurse.Text);
            bool necesitaproiect = checkBoxProiect.Checked;
            Proiecte proiectul = new Proiecte();
            if (checkBoxProiect.Checked == true)
            {
                proiectul.denumire = textBoxProiect.Text;
                proiectul.coord = textBoxCoord.Text;
                proiectul.deadLine = dateTimePickerDeadLine.Value;
            }
            else
            {
                proiectul.denumire = String.Empty;
                proiectul.coord = String.Empty;
                proiectul.deadLine = DateTime.MaxValue;
            }

            Activitati ActivitateFinala = new Activitati(denumire, tipActiv, incepere, incheiere, necesitaproiect, domeniul, proiectul);
            listaActiv.Add(ActivitateFinala);

            populareListView();
            toolStripStatusLabelNrActiv.Text = "Activitati totale: " + listaActiv.Count;
            CurataCampuri();
        }

        private void populareListView()
        {
            listViewActivitati.Items.Clear();
            foreach (Activitati each in listaActiv)
            {
                if (each.domeniu.NecesitateResurse == true)
                {
                    if (each.necesitaProiect == true)
                    {
                        ListViewItem item = new ListViewItem(new String[] { each.denumire, each.tipAct.ToString(),
                    each.timpStart.ToString(), each.timpFinish.ToString(),
                    each.domeniu.DenumireDomeniu, each.domeniu.Resursa, each.proiect.denumire, each.proiect.coord,
                    each.proiect.deadLine.ToString() });
                        listViewActivitati.Items.Add(item);
                    }
                    else
                    {
                        ListViewItem item = new ListViewItem(new String[] { each.denumire, each.tipAct.ToString(),
                    each.timpStart.ToString(), each.timpFinish.ToString(),
                    each.domeniu.DenumireDomeniu, each.domeniu.Resursa, " "," "," " });
                        listViewActivitati.Items.Add(item);
                    }
                }
                else
                {
                    if (each.necesitaProiect == true)
                    {
                        ListViewItem item = new ListViewItem(new String[] { each.denumire, each.tipAct.ToString(),
                    each.timpStart.ToString(), each.timpFinish.ToString(),
                    each.domeniu.DenumireDomeniu, " ", each.proiect.denumire, each.proiect.coord,
                    each.proiect.deadLine.ToString() });
                        listViewActivitati.Items.Add(item);
                    }
                    else
                    {
                        ListViewItem item = new ListViewItem(new String[] { each.denumire, each.tipAct.ToString(),
                    each.timpStart.ToString(), each.timpFinish.ToString(),
                    each.domeniu.DenumireDomeniu, " ", " "," "," " });
                        listViewActivitati.Items.Add(item);
                    }
                }
            }
        }

        private void buttonStergeActiv_Click(object sender, EventArgs e)
        {
            if (listViewActivitati.SelectedItems.Count != 0)
            {
                if (MessageBox.Show("Stergeti Activitatea?", "Sterge", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listaActiv.RemoveAt(listViewActivitati.SelectedIndices[0]);
                    toolStripStatusLabelNrActiv.Text = "Activitati totale: " + listaActiv.Count;
                    populareListView();
                }
            }
        }

        private void buttonModifica_Click(object sender, EventArgs e)
        {
            if (listViewActivitati.SelectedItems.Count != 0)
            {
                Activitati activitatzi = listaActiv.ElementAt(listViewActivitati.SelectedIndices[0]);
                EditareActivitate editareActivitate = new EditareActivitate(activitatzi);
                editareActivitate.ShowDialog();
                toolStripStatusLabelNrActiv.Text = "Activitati totale: " + listaActiv.Count;
                populareListView();
            }
        }

        #endregion

        #region Handlers
        private void whoMadeThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aceasta aplicatie a fost facuta de Chitoiu Andrei din grupa 1053.");
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editeazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonModifica_Click(sender, e);
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonStergeActiv_Click(sender, e);
        }

        private void listViewActivitati_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cms.Show(Cursor.Position.X + 5, Cursor.Position.Y + 5);
            }
        }

        private void listViewActivitati_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && listViewActivitati.FocusedItem.Bounds.Contains(e.Location))
            {
                buttonModifica_Click(sender, e);
            }
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CurataCampuri();
            populareListView();
        }

        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AgendaActiv av = new AgendaActiv();
            av.ShowDialog();
            this.Close();
        }
        #endregion

        #region Alt Shortcuts
        private void listViewActivitati_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                toolStripButtonPrint_Click(sender, e);
            }
        }

        private void tbDenumire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.C)
            {
                CurataCampuri();
            }
        }


        #endregion

        #region Serializare/Deserializare
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Activitati Text.txt");
            foreach (Activitati each in listaActiv)
            {
                sw.Write(each.denumire + "," + each.tipAct.ToString() + "," + each.timpStart.ToString()
                    + "," + each.timpFinish.ToString() + "," + each.necesitaProiect.ToString() + "," + each.domeniu.DenumireDomeniu + ","
                    + each.domeniu.NecesitateResurse.ToString() + "," + each.domeniu.Resursa + "," + each.proiect.denumire + "," + each.proiect.coord + "," + each.proiect.deadLine.ToString()
                    +"\n");
            }
            sw.Close();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Deschide un fisier text";
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.FilterIndex = 1;


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);

                string line;

                listaActiv.Clear();

                while ((line = streamReader.ReadLine()) != null)
                {
                    String[] tokens = line.Split(',');

                    try
                    {
                        String denumireLocala = tokens[0];
                        Enum.TryParse(tokens[1], out EnumTipActivitati tipLocal);
                        DateTime.TryParse(tokens[2], out DateTime timpStartLocal);
                        DateTime.TryParse(tokens[3], out DateTime timpFinishLocal);
                        bool.TryParse(tokens[4], out bool necesitaProiectLocal);
                        String denumireDomeniuLocala = tokens[5];
                        bool.TryParse(tokens[6], out bool necesitaResurseLocal);
                        String resursaLocala = tokens[7];
                        String denumireProiectLocala = tokens[8];
                        String coordLocala = tokens[9];
                        DateTime.TryParse(tokens[10], out DateTime deadLineLocal);

                        Domenii domeniuLocal = new Domenii(denumireDomeniuLocala, necesitaResurseLocal, resursaLocala);
                        Proiecte proiecteLocal = new Proiecte(denumireProiectLocala, coordLocala, deadLineLocal);
                        Activitati activitatiLocala = new Activitati(denumireLocala, tipLocal, timpStartLocal, timpFinishLocal, necesitaProiectLocal, domeniuLocal, proiecteLocal);
                        listaActiv.Add(activitatiLocala);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Informatiile din fisier nu permit instantierea.");
                        continue;
                    }
                }
                streamReader.Close();
                toolStripStatusLabelNrActiv.Text = "Activitati totale: " + listaActiv.Count;
                populareListView();
            }

        }

        private void serializareXML_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Activitati>));

            FileStream fs = File.Create("lista.xml");
            xmlSerializer.Serialize(fs, listaActiv);

            fs.Close();

            MessageBox.Show("Serializare cu succes in lista.xml");
        }

        private void deserializareXML_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Activitati>));

            try
            {
                FileStream fs = File.OpenRead("lista.xml");
                listaActiv = xmlSerializer.Deserialize(fs) as List<Activitati>;

                fs.Close();
                toolStripStatusLabelNrActiv.Text = "Activitati totale: " + listaActiv.Count;
                populareListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void serializareBinara_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fs = new FileStream("binary.dat", FileMode.Create);
            formatter.Serialize(fs, listaActiv);

            fs.Close();
        }

        private void deserializareBinara_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecteaza fisier binar";
            ofd.Filter = "Binary files (*.dat)|*.dat|All files (*.*)|*.*";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);

                listaActiv = formatter.Deserialize(fs) as List<Activitati>;
                fs.Close();
                toolStripStatusLabelNrActiv.Text = "Activitati totale: " + listaActiv.Count;
                populareListView();
            }
        }
        #endregion

        #region Drag&Drop
        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            String[] filepath = e.Data.GetData(DataFormats.FileDrop, false) as String[];

            StreamReader streamReader = new StreamReader(filepath[0]);
            string line;
            listaActiv.Clear();

            while ((line = streamReader.ReadLine()) != null)
            {
                String[] tokens = line.Split(',');
                try
                {
                    String denumireLocala = tokens[0];
                    Enum.TryParse(tokens[1], out EnumTipActivitati tipLocal);
                    DateTime.TryParse(tokens[2], out DateTime timpStartLocal);
                    DateTime.TryParse(tokens[3], out DateTime timpFinishLocal);
                    bool.TryParse(tokens[4], out bool necesitaProiectLocal);
                    String denumireDomeniuLocala = tokens[5];
                    bool.TryParse(tokens[6], out bool necesitaResurseLocal);
                    String resursaLocala = tokens[7];
                    String denumireProiectLocala = tokens[8];
                    String coordLocala = tokens[9];
                    DateTime.TryParse(tokens[10], out DateTime deadLineLocal);

                    Domenii domeniuLocal = new Domenii(denumireDomeniuLocala, necesitaResurseLocal, resursaLocala);
                    Proiecte proiecteLocal = new Proiecte(denumireProiectLocala, coordLocala, deadLineLocal);
                    Activitati activitatiLocala = new Activitati(denumireLocala, tipLocal, timpStartLocal, timpFinishLocal, necesitaProiectLocal, domeniuLocal, proiecteLocal);
                    listaActiv.Add(activitatiLocala);
                }
                catch (Exception)
                {
                    MessageBox.Show("Informatiile din fisier nu permit instantierea.");
                    continue;
                }
            }
            streamReader.Close();
            toolStripStatusLabelNrActiv.Text = "Activitati totale: " + listaActiv.Count;
            populareListView();
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        #endregion

        #region Statistics & UserControl
        private void toolStripButtonStats_Click(object sender, EventArgs e)
        {
            Stats stats = new Stats(listaActiv);
            stats.ShowDialog();
        }
        #endregion

        #region PrintPreview
        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            pageSetupDialogActiv.Document = printDocumentActiv;
            pageSetupDialogActiv.PageSettings = printDocumentActiv.DefaultPageSettings;

            if (pageSetupDialogActiv.ShowDialog() == DialogResult.OK)
            {
                printDocumentActiv.DefaultPageSettings = pageSetupDialogActiv.PageSettings;
                printPreviewDialogActiv.Document = printDocumentActiv;
                printPreviewDialogActiv.ShowDialog();
            }
        }

        private void printDocumentActiv_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Brush brush = Brushes.Black;
            Font font2 = new Font("Times New Roman", 20, FontStyle.Bold);
            Font font = new Font("Times New Roman", 12);
            Pen pen = new Pen(brush);

            PageSettings settings = printDocumentActiv.DefaultPageSettings;
            var totalDrawableW = settings.PaperSize.Width - settings.Margins.Left - settings.Margins.Right;
            var totalDrawableH = settings.PaperSize.Height - settings.Margins.Bottom - settings.Margins.Top;

            if (settings.Landscape)
            {
                var temp = totalDrawableH;
                totalDrawableH = totalDrawableW;
                totalDrawableW = temp;
            }

            int cellWitdh = totalDrawableW / 3;
            int cellHeight = 25;

            int x = settings.Margins.Left;
            int y = 100;

            graphics.DrawString("Lista Activitati", font2, brush, totalDrawableW / 2, y);
            y += 100;

            graphics.DrawRectangle(pen, x, y, cellWitdh, cellHeight);
            graphics.DrawRectangle(pen, x + cellWitdh, y, cellWitdh, cellHeight);
            graphics.DrawRectangle(pen, x + cellWitdh * 2, y, cellWitdh, cellHeight);

            graphics.DrawString("Denumire Activitate", font, brush, x, y);
            graphics.DrawString("Timp Start", font, brush, x + cellWitdh, y);
            graphics.DrawString("Timp Finsih", font, brush, x + cellWitdh * 2, y);

            y += cellHeight;
            foreach (Activitati each in listaActiv)
            {
                graphics.DrawRectangle(pen, x, y, cellWitdh, cellHeight);
                graphics.DrawRectangle(pen, x + cellWitdh, y, cellWitdh, cellHeight);
                graphics.DrawRectangle(pen, x + cellWitdh * 2, y, cellWitdh, cellHeight);

                graphics.DrawString(each.denumire, font, brush, x, y);
                graphics.DrawString(each.timpStart.ToString(), font, brush, x + cellWitdh, y);
                graphics.DrawString(each.timpFinish.ToString(), font, brush, x + cellWitdh * 2, y);

                y += cellHeight;
            }
        }
        #endregion

        #region Clipboard
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewActivitati.SelectedItems.Count != 0)
            {
                ListViewItem lvItem = listViewActivitati.SelectedItems[0];
                string text = String.Empty;
                foreach(ListViewItem.ListViewSubItem lvsi in lvItem.SubItems)
                {
                    text += lvsi.Text+" ";
                }
                Clipboard.SetText(text);
                toolStripStatusLabelClipboard.Text = "Copiat in Clipboard: " + text;
            }
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listViewActivitati_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewActivitati.SelectedItems.Count > 0)
            {
                
                listViewActivitati.SelectedItems[0].ForeColor = Color.White;
                listViewActivitati.SelectedItems[0].BackColor = Color.Blue;

                
                foreach (ListViewItem item in listViewActivitati.Items)
                {
                    if (!item.Selected)
                    {
                        item.ForeColor = SystemColors.WindowText;
                        item.BackColor = SystemColors.Window;
                    }
                }
            }
        }
    }
}
