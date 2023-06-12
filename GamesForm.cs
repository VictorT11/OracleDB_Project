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
    public partial class GamesForm : Form
    {

        private const int PRIMA_COLOANA = 0;
        private const bool SUCCES = true;

        IStocareJucatori stocareJucatori = (IStocareJucatori)new StocareFactory().GetTipStocare(typeof(Jucator));
        IStocareEchipe stocareEchipe = (IStocareEchipe)new StocareFactory().GetTipStocare(typeof(Echipa));
        IStocareMeciuri stocareMeciuri = (IStocareMeciuri)new StocareFactory().GetTipStocare(typeof(Meci));
        IStocareContracte stocareContracte = (IStocareContracte)new StocareFactory().GetTipStocare(typeof(Contract));
        public GamesForm()
        {
            InitializeComponent();
            if (stocareMeciuri == null)
            {
                MessageBox.Show("Eroare la initializare");
            }
        }

        private void GamesForm_Load(object sender, EventArgs e)
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

                var meciuri = stocareMeciuri.GetMeciuri();


                if (meciuri != null && meciuri.Any())
                {
                    var meciuriAfisare = meciuri.Select(m => new
                    {
                        m.IdMeci,
                        m.Data,
                        m.Locatie,
                        m.ScorGazda,
                        m.ScorOaspeti,
                        EchipaGazda = stocareEchipe.GetEchipa(m.IdEchipaGazda)?.Nume,
                        EchipaOaspeti = stocareEchipe.GetEchipa(m.IdEchipaOaspeti)?.Nume
                    }).ToList();

                    dataGridView1.DataSource = meciuriAfisare;

                    dataGridView1.Columns["IdMeci"].Visible = false;
                    dataGridView1.Columns["Data"].HeaderText = "Data";
                    dataGridView1.Columns["Locatie"].HeaderText = "Locatie";
                    dataGridView1.Columns["ScorGazda"].HeaderText = "Scor Gazda";
                    dataGridView1.Columns["ScorOaspeti"].HeaderText = "Scor Oaspeti";
                    dataGridView1.Columns["EchipaGazda"].HeaderText = "Echipa Gazda";
                    dataGridView1.Columns["EchipaOaspeti"].HeaderText = "Echipa Oaspeti";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
    }
}
