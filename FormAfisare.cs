using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NivelAccesDate;
using LibrarieModele;
using System.Data.OracleClient;

namespace ProiectBD
{
    public partial class FormAfisare : Form
    {
        
        public FormAfisare()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayersForm p = new PlayersForm();
            p.Show();
            //this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoginForm f = new LoginForm();
            f.Show();
            //this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TeamsForm t = new TeamsForm();
            t.Show();
            //this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GamesForm g = new GamesForm();
            g.Show();
           // this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ContractsForm c = new ContractsForm();
            c.Show();
           // this.Close();
        }

       
    }
}
