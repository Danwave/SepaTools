using Common;
using FinancialFileFormats.SEPA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SepaTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SepaDebitTransfer sepa;
        private void FindFileButton_Click(object sender, EventArgs e)
        {
            var Ofd = new OpenFileDialog();
            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                filenameTextBox.Text = Ofd.FileName;
                sepa = new SepaDebitTransfer(Ofd.FileName, "EUR");
                creditorName.Text = sepa.Creditor.Name;
                NIF.Text = sepa.InitiatingPartyId.Substring(7);
                NifCode.Text = "N.I.F./C.I.F. SEPA: " + sepa.InitiatingPartyId;
                Iban.Text = sepa.Creditor.Iban.Substring(0, 4);
                bank.Text = sepa.Creditor.Iban.Substring(4, 4);
                office.Text = sepa.Creditor.Iban.Substring(8, 4);
                dc.Text = sepa.Creditor.Iban.Substring(12, 2);
                ccc.Text = sepa.Creditor.Iban.Substring(14, 10);
                dateTimePicker1.Value = sepa.RequestedExecutionDate;
                bic.Text = sepa.InitiatingPartyId.Substring(4, 3);
                messageid.Text = sepa.MessageIdentification;
                var source = new BindingSource();
                source.DataSource = sepa.GetTransactions();
                dataGridView1.DataSource = sepa.GetTransactions();
                dataGridView1.Refresh();
                label7.Text = string.Format("Registros: {0} / Importe: {1:f} €", sepa.GetTransactions().Count(), sepa.HeaderControlSumInCents / 100m);
            }
        }

        private void generarXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sepa.MessageIdentification))
            {
                MessageBox.Show("Es necesario indicar un identificador de mensaje");
                messageid.Focus();
            }
            else
            {
                var sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                    sepa.Save(sfd.FileName);
            }
        }
        private void messageid_TextChanged(object sender, EventArgs e)
        {
            sepa.MessageIdentification = messageid.Text;
        }

        private void NIF_TextChanged(object sender, EventArgs e)
        {
            sepa.InitiatingPartyId = Utils.SEPACodeCIF(NIF.Text, bic.Text);
            NifCode.Text = "N.I.F./C.I.F. SEPA: " + sepa.InitiatingPartyId;
        }

        private void bic_TextChanged(object sender, EventArgs e)
        {
            sepa.InitiatingPartyId = Utils.SEPACodeCIF(NIF.Text, bic.Text);
            NifCode.Text = "N.I.F./C.I.F. SEPA: " + sepa.InitiatingPartyId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string iban = Utils.generateIban(Clipboard.GetText().Replace(" ", ""));
            sepa.Creditor.Iban = iban;
            sepa.Creditor.Bic = Utils.GetBicFromBanKCode(bank.Text);
            Iban.Text = iban.Substring(0, 4);
            bank.Text = iban.Substring(4, 4);
            office.Text = iban.Substring(8, 4);
            dc.Text = iban.Substring(12, 2);
            ccc.Text = iban.Substring(14, 10);
        }
    }
}
