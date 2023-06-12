using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Contract
    {
        public int IdContract { get; set; }
        public int IdJucator { get; set; }
        public int IdEchipa { get; set; }
        public DateTime DataInceput {get; set; }
        public DateTime DataSfarsit { get; set; }
        public int SalariuAnual { get; set; }

        public virtual Jucator  Jucatori { get; set; }
        public virtual Echipa Echipe { get; set; }
        public Contract() { }

        public Contract(int idJucator, int idEchipa, DateTime dataInceput, DateTime dataSfarsit, int salariuAnual, int idContract = 0 )
        {
            IdContract = idContract;
            IdJucator = idJucator;
            IdEchipa = idEchipa;
            DataInceput = dataInceput;
            DataSfarsit = dataSfarsit;
            SalariuAnual = salariuAnual;
        }

        public Contract(DataRow linieBD)
        {
            IdContract = Convert.ToInt32(linieBD["idContract"].ToString());
            IdJucator = Convert.ToInt32(linieBD["idJucator"].ToString());
            IdEchipa = Convert.ToInt32(linieBD["idEchipa"].ToString());
            DataInceput = Convert.ToDateTime(linieBD["dataInceput"].ToString());
            DataSfarsit = Convert.ToDateTime(linieBD["dataSfarsit"].ToString());
            SalariuAnual = Convert.ToInt32(linieBD["salariuAnual"].ToString());

        }
    }
}
