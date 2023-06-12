using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarieModele;
namespace NivelAccesDate
{
    public interface IStocareMeciuri: IStocareFactory
    {
        List<Meci> GetMeciuri();
        Meci GetMeci(int id);
        bool AddMeci(Meci m);

        bool UpdateMeci(Meci m);
        bool DelMeci(int id);
    }
}
