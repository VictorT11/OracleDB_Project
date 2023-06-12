using System.Collections.Generic;
using System.Data;
using LibrarieModele;
using Oracle.DataAccess.Client;



namespace NivelAccesDate
{
    public class AdministrareMeciuri: IStocareMeciuri
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Meci> GetMeciuri()
        {
            var result = new List<Meci>();
            var dsMasini = SqlDBHelper.ExecuteDataSet("select * from Meciuri", CommandType.Text);

            foreach (DataRow linieBD in dsMasini.Tables[PRIMUL_TABEL].Rows)
            {
                var meci = new Meci(linieBD);
                //incarca entitatile aditionale
                meci.EchipaGazda = new AdministrareEchipe().GetEchipa(meci.IdEchipaGazda);
                meci.EchipaOaspeti = new AdministrareEchipe().GetEchipa(meci.IdEchipaOaspeti);
                result.Add(meci);
            }
            return result;
        }

        public Meci GetMeci(int id)
        {
            Meci result = null;
            var dsMeci = SqlDBHelper.ExecuteDataSet("select * from Meciuri where IdMeci = :IdMeci", CommandType.Text,
                new OracleParameter(":IdMeci", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsMeci.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsMeci.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Meci(linieBD);
                //incarca entitatile aditionale
                result.EchipaGazda = new AdministrareEchipe().GetEchipa(result.IdEchipaGazda);
                result.EchipaOaspeti = new AdministrareEchipe().GetEchipa(result.IdEchipaOaspeti);
            }
            return result;
        }

        public bool AddMeci(Meci m)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "insert into Meciuri VALUES (seq_Meciuri.nextval, :Data, :Locatie, :ScorGazda, :ScorOaspeti, :IdEchipaGazda, :IdEchipaOaspeti)", CommandType.Text,
                new OracleParameter(":Data", OracleDbType.Date, m.Data, ParameterDirection.Input),
                new OracleParameter(":Locatie", OracleDbType.NVarchar2, m.Locatie, ParameterDirection.Input),
                new OracleParameter(":ScorGazda", OracleDbType.Int64, m.ScorGazda, ParameterDirection.Input),
                new OracleParameter(":ScorOaspeti", OracleDbType.Int64, m.ScorOaspeti, ParameterDirection.Input),
                new OracleParameter(":IdEchipaGazda", OracleDbType.Int64, m.IdEchipaGazda, ParameterDirection.Input),
                new OracleParameter(":IdEchipaOaspeti", OracleDbType.Int64, m.IdEchipaOaspeti, ParameterDirection.Input)
            );
        }

        public bool UpdateMeci(Meci m)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE Meciuri set Data = :Data, Locatie = :Locatie, ScorGazda =:ScorGazda, ScorOaspeti =:ScorOaspeti, IdEchipaGazda =:IdEchipaGazda, IdEchipaOaspeti =:IdEchipaOaspeti where idMeci=:IdMeci", CommandType.Text,
                new OracleParameter(":Data", OracleDbType.Date, m.Data, ParameterDirection.Input),
                new OracleParameter(":Locatie", OracleDbType.NVarchar2, m.Locatie, ParameterDirection.Input),
                new OracleParameter(":ScorGazda", OracleDbType.Int64, m.ScorGazda, ParameterDirection.Input),
                new OracleParameter(":ScorOaspeti", OracleDbType.Int64, m.ScorOaspeti, ParameterDirection.Input),
                new OracleParameter(":IdEchipaGazda", OracleDbType.Int64, m.IdEchipaGazda, ParameterDirection.Input),
                new OracleParameter(":IdEchipaOaspeti", OracleDbType.Int64, m.IdEchipaOaspeti, ParameterDirection.Input),
                new OracleParameter(":IdMeci", OracleDbType.Int32, m.IdMeci, ParameterDirection.Input)
            );
        }
        public bool DelMeci(int id)
        {
            return SqlDBHelper.ExecuteNonQuery("DELETE FROM Meciuri WHERE IdMeci = :IdMeci", CommandType.Text,
                new OracleParameter(":IdMeci", OracleDbType.Int32, id, ParameterDirection.Input));
        }

    }
}
