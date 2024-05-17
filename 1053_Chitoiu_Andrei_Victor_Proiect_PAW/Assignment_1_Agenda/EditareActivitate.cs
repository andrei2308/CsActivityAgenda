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
    public partial class EditareActivitate : Form
    {
        Activitati _instance;
        public EditareActivitate(Activitati activitateDeEditat)
        {
            InitializeComponent();

            _instance = activitateDeEditat; 
            tbDenumire.Text = activitateDeEditat.denumire;
            cbTipActiv.Text = activitateDeEditat.tipAct.ToString();
            dateTimePickerIncepere.Value = activitateDeEditat.timpStart;
            dateTimeIncheiere.Value = activitateDeEditat.timpFinish;
            textBoxDomeniu.Text = activitateDeEditat.domeniu.DenumireDomeniu;
            if (activitateDeEditat.domeniu.NecesitateResurse == true) {
                checkBoxResurse.Checked = true;
                textBoxResurse.Text = activitateDeEditat.domeniu.Resursa;
            }
            if (activitateDeEditat.necesitaProiect == true)
            {
                checkBoxProiect.Checked = activitateDeEditat.necesitaProiect;
                textBoxProiect.Text = activitateDeEditat.proiect.denumire;
                textBoxCoord.Text = activitateDeEditat.proiect.coord;
                dateTimePickerDeadLine.Value = activitateDeEditat.proiect.deadLine;
            }
        }

        private void EditareActivitate_Load(object sender, EventArgs e)
        {

        }

        #region Butoane
        private void buttonConfirma_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(tbDenumire.Text) || String.IsNullOrWhiteSpace(tbDenumire.Text))
                    throw new CostumExceptionDenumire();
                _instance.denumire = tbDenumire.Text;

                if (cbTipActiv.SelectedIndex == -1) throw new CostumExceptionTipActiv();
                Enum.TryParse(cbTipActiv.Text, out EnumTipActivitati tip);
                _instance.tipAct = tip;

                _instance.timpStart = dateTimePickerIncepere.Value;
                _instance.timpFinish = dateTimeIncheiere.Value;

                if (String.IsNullOrEmpty(textBoxDomeniu.Text) || String.IsNullOrWhiteSpace(textBoxDomeniu.Text))
                    throw new CostumExceptionDomeniu();
                _instance.domeniu.DenumireDomeniu = textBoxDomeniu.Text;

                if (checkBoxResurse.Checked == true && (String.IsNullOrEmpty(textBoxResurse.Text) || String.IsNullOrWhiteSpace(textBoxResurse.Text)))
                    throw new CostumExceptionResurse();
                _instance.domeniu.NecesitateResurse = checkBoxResurse.Checked;
                if (checkBoxResurse.Checked == false && (!String.IsNullOrEmpty(textBoxResurse.Text) || !String.IsNullOrWhiteSpace(textBoxResurse.Text)))
                    throw new CostumExceptionResurseNull();
                _instance.domeniu.Resursa = textBoxResurse.Text;

                _instance.necesitaProiect = checkBoxProiect.Checked;
                if (checkBoxProiect.Checked == true)
                {
                    if (String.IsNullOrEmpty(textBoxProiect.Text) || String.IsNullOrWhiteSpace(textBoxProiect.Text))
                        throw new CostumExceptionProiect();
                    _instance.proiect.denumire = textBoxProiect.Text;
                    if (String.IsNullOrEmpty(textBoxCoord.Text) || String.IsNullOrWhiteSpace(textBoxCoord.Text))
                        throw new CostumExceptionProiect();
                    _instance.proiect.coord = textBoxCoord.Text;
                    _instance.proiect.deadLine = dateTimePickerDeadLine.Value;

                    this.Close();
                }
                else
                {
                    if (!String.IsNullOrEmpty(textBoxProiect.Text) || !String.IsNullOrWhiteSpace(textBoxProiect.Text))
                        throw new CostumExceptionProiectNull();
                    _instance.proiect.denumire = String.Empty;
                    if (!String.IsNullOrEmpty(textBoxCoord.Text) || !String.IsNullOrWhiteSpace(textBoxCoord.Text))
                        throw new CostumExceptionProiectNull();
                    _instance.proiect.coord = String.Empty;
                    _instance.proiect.deadLine = DateTime.MaxValue;

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        private void buttonAnuleaza_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ErrorProviders
        private void dateTimeIncheiere_Validating(object sender, CancelEventArgs e)
        {
            DateTime dataIncepere = dateTimePickerIncepere.Value;
            DateTime dataIncheiere = dateTimeIncheiere.Value;

            if (DateTime.Compare(dataIncepere, dataIncheiere) > 0)
            {
                errorProviderDataIncheiere.SetError((Control)sender, "Data de incheiere nu trebuie sa fie inaintea Datei de incepere");
                e.Cancel = true;
            }
        }
        
        private void dateTimeIncheiere_Validated(object sender, EventArgs e)
        {
            errorProviderDataIncheiere.Clear();
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
    }
}
