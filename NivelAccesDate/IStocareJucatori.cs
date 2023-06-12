using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LibrarieModele;
namespace NivelAccesDate
{
    public interface IStocareJucatori: IStocareFactory
    {
        List<Jucator> GetJucatori();
        Jucator GetJucator(int id);

        bool AddJucator(Jucator j);

        bool UpdateJucator(Jucator j);

        bool DelJucator(int id);


    }
}
