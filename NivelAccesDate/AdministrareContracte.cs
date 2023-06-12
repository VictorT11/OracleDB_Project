using System.Collections.Generic;
using System.Data;
using LibrarieModele;
using Oracle.DataAccess.Client;



namespace NivelAccesDate
{
    public class AdministrareContracte: IStocareContracte
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Contract> GetContracte()
        {
            var result = new List<Contract>();
            var dsMasini = SqlDBHelper.ExecuteDataSet("select * from Contracte", CommandType.Text);

            foreach (DataRow linieBD in dsMasini.Tables[PRIMUL_TABEL].Rows)
            {
                var masina = new Contract(linieBD);
                //incarca entitatile aditionale
                masina.Echipe = new AdministrareEchipe().GetEchipa(masina.IdEchipa);
                masina.Jucatori = new AdministrareJucatori().GetJucator(masina.IdJucator);
                result.Add(masina);
            }
            return result;
        }

        public Contract GetContract(int id)
        {
            Contract result = null;
            var dsMasini = SqlDBHelper.ExecuteDataSet("select * from Contracte where IdContract = :IdContract", CommandType.Text,
                new OracleParameter(":IdContract", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsMasini.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsMasini.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Contract(linieBD);
                //incarca entitatile aditionale
                result.Echipe = new AdministrareEchipe().GetEchipa(result.IdEchipa);
                result.Jucatori = new AdministrareJucatori().GetJucator(result.IdJucator);
            }
            return result;
        }

        public bool AddContract(Contract c)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "insert into Contracte VALUES (seq_Contracte.nextval, :IdJucator, :IdEchipa, :DataInceput, :DataSfarsit, :SalariuAnual)", CommandType.Text,
                new OracleParameter(":IdJucator", OracleDbType.Int32, c.IdJucator, ParameterDirection.Input),
                new OracleParameter(":IdEchipa", OracleDbType.Int32, c.IdEchipa, ParameterDirection.Input),
                new OracleParameter(":DataInceput", OracleDbType.Date, c.DataInceput, ParameterDirection.Input),
                new OracleParameter(":DataSfarsit", OracleDbType.Date, c.DataSfarsit, ParameterDirection.Input),
                new OracleParameter(":SalariuAnual", OracleDbType.Int64, c.SalariuAnual, ParameterDirection.Input)
            );
        }

        public bool UpdateContract(Contract c)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE Contracte set IdJucator = :IdJucator, IdEchipa = :IdEchipa, DataInceput =:DataInceput, DataSfarsit =:DataSfarsit, SalariuAnual =:SalariuAnual where idContract=:IdContract", CommandType.Text,
                new OracleParameter(":IdJucator", OracleDbType.Int32, c.IdJucator, ParameterDirection.Input),
                new OracleParameter(":IdEchipa", OracleDbType.Int32, c.IdEchipa, ParameterDirection.Input),
                new OracleParameter(":DataInceput", OracleDbType.Date, c.DataInceput, ParameterDirection.Input),
                new OracleParameter(":DataSfarsit", OracleDbType.Date, c.DataSfarsit, ParameterDirection.Input),
                new OracleParameter(":SalariuAnual", OracleDbType.Int64, c.SalariuAnual, ParameterDirection.Input),
                new OracleParameter(":IdContract", OracleDbType.Int32, c.IdContract, ParameterDirection.Input)
            );
        }
        public bool DelContract(int id)
        {
            return SqlDBHelper.ExecuteNonQuery("DELETE FROM Contracte WHERE IdContract = :IdContract", CommandType.Text,
                new OracleParameter(":IdContract", OracleDbType.Int32, id, ParameterDirection.Input));
        }
    }
}
