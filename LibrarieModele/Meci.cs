using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Meci
    {
        public int IdMeci { get; set; }
        public DateTime Data { get; set; }
        public string Locatie { get; set; }
        public int ScorGazda { get; set; }
        public int ScorOaspeti { get; set; }    
        public int IdEchipaOaspeti { get; set; }
        public int IdEchipaGazda { get; set; }  


        public virtual Echipa EchipaGazda { get; set; }
        public virtual Echipa EchipaOaspeti { get; set; }

        public Meci() { }    

        public Meci(DateTime data, string locatie, int scorGazda, int scorOaspeti, int idEchipaOaspeti, int idEchipaGazda, int idMeci = 0)
        {
            IdMeci = idMeci;
            Data = data;
            Locatie = locatie ?? throw new ArgumentNullException(nameof(locatie));
            ScorGazda = scorGazda;
            ScorOaspeti = scorOaspeti;
            IdEchipaOaspeti = idEchipaOaspeti;
            IdEchipaGazda = idEchipaGazda;
           
        }

        public Meci(DataRow linieBD)
        {
            IdMeci = Convert.ToInt32(linieBD["idMeci"].ToString());
            Data = Convert.ToDateTime(linieBD["data"].ToString());
            Locatie = linieBD["locatie"].ToString();
            ScorGazda = Convert.ToInt32(linieBD["scorGazda"].ToString());
            ScorOaspeti = Convert.ToInt32(linieBD["scorOaspeti"].ToString());
            IdEchipaGazda = Convert.ToInt32(linieBD["idEchipaGazda"].ToString());
            IdEchipaOaspeti = Convert.ToInt32(linieBD["idEchipaOaspeti"].ToString());

        }
    }
}
