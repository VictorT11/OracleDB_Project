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
    public partial class PlayersForm : Form
    {

        private const int PRIMA_COLOANA = 0;
        private const bool SUCCES = true;

        IStocareJucatori stocareJucatori = (IStocareJucatori)new StocareFactory().GetTipStocare(typeof(Jucator));
        IStocareEchipe stocareEchipe = (IStocareEchipe)new StocareFactory().GetTipStocare(typeof(Echipa));
        IStocareMeciuri stocareMeciuri = (IStocareMeciuri)new StocareFactory().GetTipStocare(typeof(Meci));
        IStocareContracte stocareContracte = (IStocareContracte)new StocareFactory().GetTipStocare(typeof(Contract));

        public PlayersForm()
        {
            InitializeComponent();
          
            if (stocareJucatori == null)
            {
                MessageBox.Show("Eroare la initializare");
            }
        }
        private void PlayersForm_Load(object sender, EventArgs e)
        {
            
            AfiseazaCatalog();
          
        }
        
            private void PlayersForm_FormClosed(object sender, FormClosedEventArgs e)
            {
                Application.Exit();
            }

        private void AfiseazaCatalog()
        {
            try
            {
                
                var jucatori = stocareJucatori.GetJucatori();
                var contracte = stocareContracte.GetContracte();
                
                if (jucatori != null && jucatori.Any())
                {
                    var jucatoriAfisare = new List<dynamic>();

                    foreach (var jucator in jucatori)
                    {
                        var contractJucator = contracte.FirstOrDefault(c => c.IdJucator == jucator.IdJucator);
                        var echipaContract = contractJucator != null ? stocareEchipe.GetEchipa(contractJucator.IdEchipa) : null;

                        jucatoriAfisare.Add(new
                        {
                            jucator.IdJucator,
                            jucator.Nume,
                            jucator.Prenume,
                            jucator.DataNasterii,
                            jucator.TaraNatala,
                            jucator.DraftPick,
                            jucator.Pozitie,
                            Echipa = echipaContract != null ? echipaContract.Nume : "N/A"
                        });
                    }
                    dataGridView1.DataSource = jucatoriAfisare;



                    dataGridView1.Columns["IdJucator"].Visible = false;
                    dataGridView1.Columns["Nume"].HeaderText = "Nume";
                    dataGridView1.Columns["Prenume"].HeaderText = "Prenume";
                    dataGridView1.Columns["DataNasterii"].HeaderText = "Data Nasterii";
                    dataGridView1.Columns["TaraNatala"].HeaderText = "Tara Natala";
                    dataGridView1.Columns["DraftPick"].HeaderText = "Draft Pick";
                    dataGridView1.Columns["Pozitie"].HeaderText = "Pozitie";
                    dataGridView1.Columns["Echipa"].HeaderText = "Echipa";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
               
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

        
    }
