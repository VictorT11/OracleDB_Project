using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NivelAccesDate;
using System.Configuration;
using LibrarieModele;

namespace ProiectBD
{
    public class StocareFactory
    {
        public IStocareFactory GetTipStocare(Type tipEntitate)
        {
            var formatSalvare = ConfigurationManager.AppSettings["FormatSalvare"];
            if (formatSalvare != null)
            {
                switch (formatSalvare)
                {
                    default:
                    case "BazaDateOracle":

                        if (tipEntitate == typeof(Jucator))
                        {
                            return new AdministrareJucatori();
                        }
                        if (tipEntitate == typeof(Echipa))
                        {
                            return new AdministrareEchipe();
                        }
                        if (tipEntitate == typeof(Meci))
                        {
                            return new AdministrareMeciuri();
                        }
                        if (tipEntitate == typeof(Contract))
                        {
                            return new AdministrareContracte();
                        }
                        break;

                    case "BIN":
                        //instantiere clase care realizeaza salvarea in fisier binar
                        break;
                }
            }
            return null;
        }
    }
}
