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
    public partial class TeamsForm : Form
    {
        private const int PRIMA_COLOANA = 0;
        private const bool SUCCES = true;

        IStocareJucatori stocareJucatori = (IStocareJucatori)new StocareFactory().GetTipStocare(typeof(Jucator));
        IStocareEchipe stocareEchipe = (IStocareEchipe)new StocareFactory().GetTipStocare(typeof(Echipa));
        IStocareMeciuri stocareMeciuri = (IStocareMeciuri)new StocareFactory().GetTipStocare(typeof(Meci));
        IStocareContracte stocareContracte = (IStocareContracte)new StocareFactory().GetTipStocare(typeof(Contract));

        public TeamsForm()
        {
            InitializeComponent();
            
            if (stocareEchipe == null)
            {
                MessageBox.Show("Eroare la initializare");
            }
        }
        

        private void TeamsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void AfiseazaCatalog()
        {
            try
            {

                var echipe = stocareEchipe.GetEchipe();


                if (echipe != null && echipe.Any())
                {
                    dataGridView2.DataSource = echipe.Select(m => new { m.IdEchipa, m.Nume, m.Oras, m.Conferinta, m.AnulInfiintarii }).ToList();

                    dataGridView2.Columns["IdEchipa"].Visible = false;
                    dataGridView2.Columns["Nume"].HeaderText = "Nume";
                    dataGridView2.Columns["Oras"].HeaderText = "Oras";
                    dataGridView2.Columns["Conferinta"].HeaderText = "Conferinta";
                    dataGridView2.Columns["AnulInfiintarii"].HeaderText = "AnulInfiintarii";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TeamsForm_Load(object sender, EventArgs e)
        {
            AfiseazaCatalog();
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridView2.CurrentCell.RowIndex;
            string idEchipa = dataGridView2[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            try
            {
                Echipa ech = stocareEchipe.GetEchipa(Int32.Parse(idEchipa));
                label1.Text = ech.Nume + " Roster";

                //incarcarea datelor in controalele de pe forma
                if (ech != null)
                {
                    var contracte = stocareContracte.GetContracte();
                    var jucatori = new List<Jucator>();

                    foreach (var contract in contracte)
                    {
                        if (contract.IdEchipa == ech.IdEchipa)
                        {
                            var jucator = stocareJucatori.GetJucator(contract.IdJucator);
                            if (jucator != null)
                                jucatori.Add(jucator);
                        }
                    }

                  
                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add("Nume", "Nume");
                    dataGridView1.Columns.Add("Pozitie", "Pozitie");

                  
                    foreach (var jucator in jucatori)
                    {
                        dataGridView1.Rows.Add(jucator.Nume + jucator.Prenume, jucator.Pozitie);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
           
        }
    }
}
