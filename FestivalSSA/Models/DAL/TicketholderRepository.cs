using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalSSA.Models.DAL
{
    public class TicketholderRepository
    {
        public static List<Ticketholder> GetReservaties()
        {
            string sSQL = "SELECT * FROM [Ticketholders] ORDER BY TickettypeID, Name";

            return GetList(sSQL);
        }

        public static void InsertReservatie(Ticketholder reservatie)
        {
            string sSQL = null;
            //1. SQL instructie + parameters
            sSQL = "INSERT INTO Ticketholders(Name, FirstName, Email, Amount, TickettypeID) ";
            sSQL += "VALUES (@Name,@FirstName,@Email,@Amount,@TypeID)";
            DbParameter parName = Database.AddParameter("@Name", reservatie.Name);
            DbParameter parFirstName = Database.AddParameter("@FirstName", reservatie.FirstName);
            DbParameter parEmail = Database.AddParameter("@Email", reservatie.Email);
            DbParameter parTypeID = Database.AddParameter("@TypeID", reservatie.TypeID);
            DbParameter parAmount = Database.AddParameter("@Amount", reservatie.Amount);

            string sSQL2 = "UPDATE Tickettypes SET Tickettypes.Available=Tickettypes.Available-@Aantal ";
            sSQL2 += "FROM Tickettypes INNER JOIN Ticketholders ON Tickettypes.ID = Ticketholders.TickettypeID ";
            sSQL2 += "WHERE Tickettypes.ID=@TypeID";
            DbParameter parAantal = Database.AddParameter("@Aantal", reservatie.Amount);
            DbParameter parType = Database.AddParameter("@TypeID", reservatie.TypeID);

            //2. Execute met SQL parameters
            Database.GetData(sSQL, parName, parFirstName, parEmail, parTypeID, parAmount);
            Database.GetData(sSQL2, parAantal, parType);
        }

        private static List<Ticketholder> GetList(string sSQL, params DbParameter[] dbParams)
        {
            List<Ticketholder> list = new List<Ticketholder>();

            DbDataReader reader = Database.GetData(sSQL, dbParams);
            while (reader.Read())
            {
                list.Add(Fill(reader));
            }
            return list;
        }

        private static Ticketholder Fill(DbDataReader reader)
        {
            Ticketholder reservatie = new Ticketholder();
            reservatie.ID = (int)reader["ID"];
            reservatie.Name = reader["Name"].ToString();
            reservatie.FirstName = reader["FirstName"].ToString();
            reservatie.Email = reader["Email"].ToString();
            reservatie.Amount = (int)reader["Amount"];
            reservatie.TypeID = (int)reader["TickettypeID"];
            reservatie.Type = TickettypeRepository.FindById(reservatie.TypeID);
            return reservatie;
        }
    }
}