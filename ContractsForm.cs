using LibrarieModele;
using NivelAccesDate;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectBD
{
    public partial class ContractsForm : Form
    {

        private const int PRIMA_COLOANA = 0;
        private const bool SUCCES = true;

        IStocareJucatori stocareJucatori = (IStocareJucatori)new StocareFactory().GetTipStocare(typeof(Jucator));
        IStocareEchipe stocareEchipe = (IStocareEchipe)new StocareFactory().GetTipStocare(typeof(Echipa));
        IStocareMeciuri stocareMeciuri = (IStocareMeciuri)new StocareFactory().GetTipStocare(typeof(Meci));
        IStocareContracte stocareContracte = (IStocareContracte)new StocareFactory().GetTipStocare(typeof(Contract));

        public ContractsForm()
        {
            InitializeComponent();
            if (stocareContracte == null)
            {
                MessageBox.Show("Eroare la initializare");
            }
        }

        private void ContractsForm_Load(object sender, EventArgs e)
        {
            AfiseazaCatalog();
        }
        private void ContractsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AfiseazaCatalog()
        {
            try
            {

                var contracte = stocareContracte.GetContracte();


                if (contracte != null && contracte.Any())
                {
                    var contracteAfisare = contracte.Select(c => new
                    {
                        c.IdContract,
                        Jucator = stocareJucatori.GetJucator(c.IdJucator)?.Prenume + " " + stocareJucatori.GetJucator(c.IdJucator)?.Nume + " ",
                        Echipa = stocareEchipe.GetEchipa(c.IdEchipa)?.Nume,
                        c.DataInceput,
                        c.DataSfarsit,
                        c.SalariuAnual
                    }).ToList();

                    dataGridView1.DataSource = contracteAfisare;

                    dataGridView1.Columns["IdContract"].Visible = false;
                    dataGridView1.Columns["Jucator"].HeaderText = "Jucator";
                    dataGridView1.Columns["Echipa"].HeaderText = "Echipa";
                    dataGridView1.Columns["DataInceput"].HeaderText = "DataInceput";
                    dataGridView1.Columns["DataSfarsit"].HeaderText = "DataSfarsit";
                    dataGridView1.Columns["SalariuAnual"].HeaderText = "SalariuAnual";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
    }
}
