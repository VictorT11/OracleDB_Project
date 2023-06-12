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

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ProiectBD
{
    public partial class AdminForm : Form
    {
        int idMeciiii;
        int idJucatoriii;
        int idContracteee;

        private const int PRIMA_COLOANA = 0;
        private const bool SUCCES = true;

        IStocareJucatori stocareJucatori = (IStocareJucatori)new StocareFactory().GetTipStocare(typeof(Jucator));
        IStocareEchipe stocareEchipe = (IStocareEchipe)new StocareFactory().GetTipStocare(typeof(Echipa));
        IStocareMeciuri stocareMeciuri = (IStocareMeciuri)new StocareFactory().GetTipStocare(typeof(Meci));
        IStocareContracte stocareContracte = (IStocareContracte)new StocareFactory().GetTipStocare(typeof(Contract));

        public AdminForm()
        {
            InitializeComponent();
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            IncarcaEchipe();
            IncarcaJucatori();
            IncarcaLocatii();

           
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void IncarcaEchipe()
        {
            try
            {
                //se elimina itemii deja adaugati
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                comboBox2.Items.Clear();
                var companii = stocareEchipe.GetEchipe();
                if (companii != null && companii.Any())
                {
                    foreach (var companie in companii)
                    {
                        comboBox3.Items.Add(new ComboItem(companie.Nume, (Int32)companie.IdEchipa));
                        comboBox4.Items.Add(new ComboItem(companie.Nume, (Int32)companie.IdEchipa));
                        comboBox2.Items.Add(new ComboItem(companie.Nume, (Int32)companie.IdEchipa));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void IncarcaJucatori()
        {
            try
            {
                //se elimina itemii deja adaugati
                comboBox1.Items.Clear();
               
                var companii = stocareJucatori.GetJucatori();
                if (companii != null && companii.Any())
                {
                    foreach (var companie in companii)
                    {
                        comboBox1.Items.Add(new ComboItem(companie.Prenume + " " + companie.Nume, (Int32)companie.IdJucator));
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void IncarcaLocatii()
        {
            try
            {
                //se elimina itemii deja adaugati
                comboBox5.Items.Clear();

                comboBox5.Items.Add("State Farm Arena(ATL)");
                comboBox5.Items.Add("TD Garden(BOS)");
                comboBox5.Items.Add("Barclays Center(BRK)");
                comboBox5.Items.Add("Spectrum Center(CHAR)");
                comboBox5.Items.Add("United Center(CHI)");
                comboBox5.Items.Add("Rocket Mortgage FieldHouse(CLE)");
                comboBox5.Items.Add("American Airlines Center(DALL)");
                comboBox5.Items.Add("Ball Arena(DEN)");
                comboBox5.Items.Add("Little Caesars Arena(DET)");
                comboBox5.Items.Add("Chase Center(GSW)");
                comboBox5.Items.Add("Toyota Center(HSR)");
                comboBox5.Items.Add("Bankers Life Fieldhouse(IND)"); 
                comboBox5.Items.Add("Staples Center(LAC)"); 
                comboBox5.Items.Add("Staples Center(LAL)");
                comboBox5.Items.Add("FedExForum(MEM)");
                comboBox5.Items.Add("American Airlines Arena(HEAT)");
                comboBox5.Items.Add("Fiserv Forum(MIL)");
                comboBox5.Items.Add("Target Center(MIN)");
                comboBox5.Items.Add("Smoothie King Center(NOPel)");
                comboBox5.Items.Add("Madison Square Garden(NY)");
                comboBox5.Items.Add("Chesapeake Energy Arena(OKT)");
                comboBox5.Items.Add("Amway Center(ORL)");
                comboBox5.Items.Add("Wells Fargo Center(76ERS)");
                comboBox5.Items.Add("Talking Stick Resort Arena(PHNX)");
                comboBox5.Items.Add("Moda Center(PORT)");
                comboBox5.Items.Add("Golden 1 Center(SKR)");
                comboBox5.Items.Add("AT&T Center(SPURS)");
                comboBox5.Items.Add("Scotiabank Arena(TOR)");
                comboBox5.Items.Add("Vivint Arena(UTAH)");
                comboBox5.Items.Add("Capital One Arena(WASH)");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker1.Value.Date > DateTime.Now.Date)
                {
                    MessageBox.Show("Data de naștere nu poate fi în viitor!");
                    return;
                }

                var rezultat = stocareJucatori.AddJucator(new Jucator(
                    textBox1.Text, 
                    textBox2.Text, 
                    dateTimePicker1.Value, 
                    textBox4.Text, 
                    Convert.ToInt32(textBox5.Text),
                    textBox6.Text));
               
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Jucator adaugat");

                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    dateTimePicker1.Value = DateTime.Now;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                    textBox6.Text = string.Empty;
                    dataGridView1.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Eroare la adaugare companie");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                var rezultat = stocareMeciuri.AddMeci(new Meci(
                    dateTimePicker2.Value, 
                    comboBox5.SelectedItem.ToString(), 
                    Convert.ToInt32(textBox8.Text), 
                    Convert.ToInt32(textBox7.Text), 
                    ((ComboItem)comboBox3.SelectedItem).Value,
                    ((ComboItem)comboBox4.SelectedItem).Value));

                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Meci adaugat");
                    dateTimePicker2.Value = DateTime.Now;
                    comboBox5.Text = string.Empty;
                    comboBox4.SelectedItem = null;
                    comboBox3.SelectedItem = null;
                    textBox8.Text = string.Empty;
                    textBox7.Text = string.Empty;
                    dataGridView1.Columns.Clear();
                }
                else
                {
                    MessageBox.Show("Eroare la adaugare Meci");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker4.Value.Date < dateTimePicker3.Value.Date)
                {
                    MessageBox.Show("Data Inceput nu poate fi mai tarziu de cat data sfarsit!");
                    return;
                }

                var rezultat = stocareContracte.AddContract(new Contract(
                    ((ComboItem)comboBox1.SelectedItem).Value, 
                    ((ComboItem)comboBox2.SelectedItem).Value, 
                    dateTimePicker3.Value, 
                    dateTimePicker4.Value, 
                    Convert.ToInt32(textBox14.Text)));

                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Contract adaugat");
                    comboBox1.SelectedItem = null;
                    comboBox2.SelectedItem = null;
                    dateTimePicker3.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now;
                    textBox14.Text = string.Empty;
                    dataGridView1.Columns.Clear();
                }
                else
                {
                    MessageBox.Show("Eroare la adaugare Contract");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;

            button9.Enabled = true;

            
            button4.Enabled = false;
            button7.Enabled = false;
        
            if (checkBox3.Checked)
            {
                AfiseazaContracte();
            }
            else
            {   comboBox1.SelectedItem = null;
                comboBox2.SelectedItem = null;
                dateTimePicker3.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                textBox14.Text = string.Empty;
                dataGridView1.Columns.Clear();

               
                button4.Enabled = true;
                button7.Enabled = true;
               
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox3.Checked = false;

            button7.Enabled = true;
           

           
            button4.Enabled = false;
         
            button9.Enabled = false;
            if (checkBox2.Checked)
            {
                AfiseazaMeciuri();
            }
            else
            {
                dateTimePicker2.Value = DateTime.Now;
                comboBox5.Text = string.Empty;
                comboBox4.SelectedItem = null;
                comboBox3.SelectedItem = null;
                textBox8.Text = string.Empty;
                textBox7.Text = string.Empty;
                dataGridView1.Columns.Clear();

               
                button4.Enabled = true;
               
                button9.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = false;
            checkBox2.Checked = false;
           
            button4.Enabled = true;

           
            button7.Enabled = false;
           
            button9.Enabled = false;
            if (checkBox1.Checked)
            {
                AfiseazaJucatori();
            }
            else
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                dateTimePicker1.Value = DateTime.Now;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                textBox6.Text = string.Empty;
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

               
                button7.Enabled = true;
               
                button9.Enabled = true;
            }
        }
       
        private void AfiseazaJucatori()
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
        private void AfiseazaMeciuri()
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

        private void AfiseazaContracte()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentCell.RowIndex;
            string idSelectat = dataGridView1[PRIMA_COLOANA, currentRowIndex].Value.ToString();

            if (checkBox1.Checked)
            {
                try
                {
                   Jucator j = stocareJucatori.GetJucator(Int32.Parse(idSelectat));

                    //incarcarea datelor in controalele de pe forma
                    if (j != null)
                    {
                        idJucatoriii = j.IdJucator;
                        textBox1.Text = j.Nume;
                        textBox2.Text = j.Prenume;
                        dateTimePicker1.Value = j.DataNasterii;
                        textBox4.Text = j.TaraNatala;
                        textBox5.Text = j.DraftPick.ToString();
                        textBox6.Text = j.Pozitie;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else if(checkBox2.Checked) 
            {
                try
                {
                    Meci m = stocareMeciuri.GetMeci(Int32.Parse(idSelectat));

                    //incarcarea datelor in controalele de pe forma
                    if (m != null)
                    {
                        idMeciiii = m.IdMeci;
                        dateTimePicker2.Value = m.Data;
                        comboBox5.Text = m.Locatie;
                        comboBox4.SelectedItem = new ComboItem(m.EchipaGazda.Nume, m.IdEchipaGazda);
                        comboBox3.SelectedItem = new ComboItem(m.EchipaOaspeti.Nume, m.IdEchipaOaspeti);
                        textBox8.Text = m.ScorGazda.ToString();
                        textBox7.Text = m.ScorOaspeti.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else if(checkBox3.Checked)
            {
                try
                {
                    Contract c = stocareContracte.GetContract(Int32.Parse(idSelectat));

                   
                    if (c != null)
                    {
                        Echipa echipa = stocareEchipe.GetEchipa(c.IdEchipa);
                        Jucator jucator = stocareJucatori.GetJucator(c.IdJucator);

                        if (echipa != null)
                        {
                            comboBox2.SelectedItem = new ComboItem(echipa.Nume, echipa.IdEchipa);
                        }

                        if (jucator != null)
                        {
                            comboBox1.SelectedItem = new ComboItem(jucator.Prenume + " " + jucator.Nume, jucator.IdJucator);
                        }

                        idContracteee = c.IdContract;
                        dateTimePicker3.Value = c.DataInceput;
                        dateTimePicker2.Value = c.DataSfarsit;
                        textBox14.Text = c.SalariuAnual.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                var Jucator = new Jucator(
                    textBox1.Text, 
                    textBox2.Text,
                    dateTimePicker1.Value, 
                    textBox4.Text, 
                    Convert.ToInt32(textBox5.Text), 
                    textBox6.Text, 
                    idJucatoriii);
               

                var rezultat = stocareJucatori.UpdateJucator(Jucator);
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Jucator actualizata");
                    AfiseazaJucatori();
                }
                else
                {
                    MessageBox.Show("Eroare la actualizare jucator");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                var meci = new Meci(
                  dateTimePicker2.Value,
                  comboBox5.SelectedItem.ToString(),
                  Convert.ToInt32(textBox8.Text),
                  Convert.ToInt32(textBox7.Text),
                  ((ComboItem)comboBox3.SelectedItem).Value,
                  ((ComboItem)comboBox4.SelectedItem).Value,
                  idMeciiii);


                var rezultat = stocareMeciuri.UpdateMeci(meci);
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Meci actualizat");
                    AfiseazaMeciuri();
                }
                else
                {
                    MessageBox.Show("Eroare la actualizare meci");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                var cont = new Contract(
                ((ComboItem)comboBox1.SelectedItem).Value,
                ((ComboItem)comboBox2.SelectedItem).Value,
                dateTimePicker3.Value,
                dateTimePicker4.Value,
                Convert.ToInt32(textBox14.Text),
                idContracteee);


                var rezultat = stocareContracte.UpdateContract(cont);
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Contract actualizata");
                    AfiseazaMeciuri();
                }
                else
                {
                    MessageBox.Show("Eroare la actualizare contract");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
              


                var rezultat = stocareMeciuri.DelMeci(idMeciiii);
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Meci actualizat");
                    AfiseazaMeciuri();
                }
                else
                {
                    MessageBox.Show("Eroare la actualizare meci");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {



                var rezultat = stocareMeciuri.DelMeci(idMeciiii);
                if (rezultat == SUCCES)
                {
                    MessageBox.Show("Meci sters");
                    AfiseazaMeciuri();
                }
                else
                {
                    MessageBox.Show("Eroare la stergere meci");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }

        }
    }
}

