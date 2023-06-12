using System.Collections.Generic;
using System.Data;
using LibrarieModele;
using Oracle.DataAccess.Client;



namespace NivelAccesDate
{
    public class AdministrareEchipe: IStocareEchipe
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Echipa> GetEchipe()
        {
            var result = new List<Echipa>();
            var dsEchipe = SqlDBHelper.ExecuteDataSet("select * from Echipe", CommandType.Text);

            foreach (DataRow linieDB in dsEchipe.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Echipa(linieDB));
            }
            return result;
        }

        public Echipa GetEchipa(int id)
        {
            Echipa result = null;
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from Echipe where IdEchipa = :IdEchipa", CommandType.Text,
                new OracleParameter(":IdEchipa", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsCompanii.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsCompanii.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Echipa(linieDB);
            }
            return result;
        }

        public bool AddEchipa(Echipa ech)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO Echipe VALUES (seq_Echipe.nextval, :Nume, :Oras, :Conferinta, :AnulInfiintarii)", CommandType.Text,
                new OracleParameter(":Nume", OracleDbType.NVarchar2, ech.Nume, ParameterDirection.Input),
                new OracleParameter(":Oras", OracleDbType.NVarchar2, ech.Oras, ParameterDirection.Input),
                new OracleParameter(":Conferinta", OracleDbType.NVarchar2, ech.Conferinta, ParameterDirection.Input),
                new OracleParameter(":AnulInfiintarii", OracleDbType.Date, ech.AnulInfiintarii, ParameterDirection.Input));
        }

        public bool UpdateEchipa(Echipa ech)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE Echipe set Nume = :Nume, Oras = :Oras, Conferinta = :Conferinta, AnulInfiintarii = :AnulInfiintarii where IdEchipa = :IdEchipa", CommandType.Text,
                new OracleParameter(":Nume", OracleDbType.NVarchar2, ech.Nume, ParameterDirection.Input),
                new OracleParameter(":Oras", OracleDbType.NVarchar2, ech.Oras, ParameterDirection.Input),
                new OracleParameter(":Conferinta", OracleDbType.NVarchar2, ech.Conferinta, ParameterDirection.Input),
                new OracleParameter(":AnulInfiintarii", OracleDbType.Date, ech.AnulInfiintarii, ParameterDirection.Input),
                new OracleParameter(":IdEchipa", OracleDbType.Int32, ech.IdEchipa, ParameterDirection.Input));
        }
        public bool DelEchipa(int id)
        {
            return SqlDBHelper.ExecuteNonQuery("DELETE FROM Echipe WHERE IdEchipa = :IdEchipa", CommandType.Text,
                new OracleParameter(":IdEchipa", OracleDbType.Int32, id, ParameterDirection.Input));
        }
    }
}
