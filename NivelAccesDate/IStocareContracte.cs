using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarieModele;


namespace NivelAccesDate
{
    public interface IStocareContracte: IStocareFactory
    {
        List<Contract> GetContracte();
        Contract GetContract(int id);
        bool AddContract(Contract c);

        bool UpdateContract(Contract c);
        bool DelContract(int id);
    }
}
