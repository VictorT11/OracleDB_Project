using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Jucator
    {
        public int IdJucator { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public DateTime DataNasterii { get; set; }
        public string TaraNatala { get; set; }
        public int DraftPick { get; set; }
        public string Pozitie { get; set; }
       

        public Jucator() { }

        public Jucator(string nume, string prenume, DateTime dataNasterii, string taraNatala, int draftPick, string pozitie, int idJucator = 0)
        {
            IdJucator = idJucator;
            Nume = nume ?? throw new ArgumentNullException(nameof(nume));
            Prenume = prenume ?? throw new ArgumentNullException(nameof(prenume));
            TaraNatala = taraNatala ?? throw new ArgumentNullException(nameof(taraNatala));
            DataNasterii = dataNasterii;
            DraftPick = draftPick;
            Pozitie = pozitie ?? throw new ArgumentNullException(nameof(pozitie));
        }

        public Jucator(DataRow linieBD)
        {
            IdJucator = Convert.ToInt32(linieBD["idJucator"].ToString());
            Nume = linieBD["nume"].ToString();
            Prenume = linieBD["prenume"].ToString();
            TaraNatala = linieBD["taraNatala"].ToString();
            DataNasterii = Convert.ToDateTime(linieBD["dataNasterii"].ToString());
            DraftPick = Convert.ToInt32(linieBD["draftPick"].ToString());
            Pozitie = linieBD["pozitie"].ToString();
        }


    }
}
