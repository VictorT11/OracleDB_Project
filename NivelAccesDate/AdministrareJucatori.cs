using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using LibrarieModele;
using Oracle.DataAccess.Client;


namespace NivelAccesDate
{
    public class AdministrareJucatori: IStocareJucatori
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Jucator> GetJucatori()
        {
           
            var result = new List<Jucator>();
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from Jucatori", CommandType.Text);
 
            foreach (DataRow linieDB in dsCompanii.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Jucator(linieDB));
            }
            return result;
        }

        public Jucator GetJucator(int id)
        {
            Jucator result = null;
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from Jucatori where IdJucator = :IdJucator", CommandType.Text,
                new OracleParameter(":IdJucator", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsCompanii.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsCompanii.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Jucator(linieDB);
            }
            return result;
        }

        public bool AddJucator(Jucator juca)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO Jucatori VALUES (seq_Jucatori.nextval, :Nume, :Prenume, :DataNasterii, :TaraNatala, :DraftPick, :Pozitie)", CommandType.Text,
                new OracleParameter(":Nume", OracleDbType.NVarchar2, juca.Nume, ParameterDirection.Input),
                new OracleParameter(":Prenume", OracleDbType.NVarchar2, juca.Prenume, ParameterDirection.Input),
                new OracleParameter(":DataNasterii", OracleDbType.Date, juca.DataNasterii, ParameterDirection.Input),
                new OracleParameter(":TaraNatala", OracleDbType.NVarchar2, juca.TaraNatala, ParameterDirection.Input),
                new OracleParameter(":DraftPick", OracleDbType.Int64, juca.DraftPick, ParameterDirection.Input),
                new OracleParameter(":Pozitie", OracleDbType.NVarchar2, juca.Pozitie, ParameterDirection.Input)
                );
        }

        public bool UpdateJucator(Jucator juca)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE Jucatori set Nume = :Nume, Prenume = :Prenume, DataNasterii = :DataNasterii, TaraNatala = :TaraNatala, DraftPick = :DraftPick, Pozitie = :Pozitie, where IdJucator = :IdJucator", CommandType.Text,
                new OracleParameter(":Nume", OracleDbType.NVarchar2, juca.Nume, ParameterDirection.Input),
                new OracleParameter(":Prenume", OracleDbType.NVarchar2, juca.Prenume, ParameterDirection.Input),
                new OracleParameter(":DataNasterii", OracleDbType.Date, juca.DataNasterii, ParameterDirection.Input),
                new OracleParameter(":TaraNatala", OracleDbType.NVarchar2, juca.TaraNatala, ParameterDirection.Input),
                new OracleParameter(":DraftPick", OracleDbType.Int64, juca.DraftPick, ParameterDirection.Input),
                new OracleParameter(":Pozitie", OracleDbType.NVarchar2, juca.Pozitie, ParameterDirection.Input),
                new OracleParameter(":IdJucator", OracleDbType.Int32, juca.IdJucator, ParameterDirection.Input)
                );
        }

        public bool DelJucator(int id)
        {
            return SqlDBHelper.ExecuteNonQuery("DELETE FROM Jucatori WHERE IdJucator = :IdJucator", CommandType.Text,
                new OracleParameter(":IdJucator", OracleDbType.Int32, id, ParameterDirection.Input));
        }


    }
}
    