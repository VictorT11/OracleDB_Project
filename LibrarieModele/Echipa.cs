using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Echipa
    {
        public int IdEchipa { get; set; }
        public string Nume { get; set; }
        public string Oras { get; set; }  
        public string Conferinta { get; set; }
        public DateTime AnulInfiintarii { get; set; }

        public Echipa() { }

        public Echipa(string nume, string oras, string conferinta, DateTime anulInfiintarii, int idEchipa = 0)
        {
            IdEchipa = idEchipa;
            Nume = nume ?? throw new ArgumentNullException(nameof(nume));
            Oras = oras ?? throw new ArgumentNullException(nameof(oras));
            Conferinta = conferinta ?? throw new ArgumentNullException(nameof(conferinta));
            AnulInfiintarii = anulInfiintarii;
        }

        public Echipa(DataRow linieBD)
        {
            IdEchipa = Convert.ToInt32(linieBD["idEchipa"].ToString());
            Nume = linieBD["nume"].ToString();
            Oras = linieBD["oras"].ToString();
            Conferinta = linieBD["conferenta"].ToString();
            AnulInfiintarii = Convert.ToDateTime(linieBD["anulInfiintarii"].ToString());

        }
    }
}
