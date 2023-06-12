using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarieModele;

namespace NivelAccesDate
{
    public interface IStocareEchipe: IStocareFactory
    {
        List<Echipa> GetEchipe();
        Echipa GetEchipa(int id);
        bool AddEchipa(Echipa e);

        bool UpdateEchipa(Echipa e);
        bool DelEchipa(int id);
    }
}
