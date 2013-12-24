using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalSSA.Models.DAL
{
    public class TickettypeRepository
    {
        public static List<Tickettype> GetTypes()
        {
            string sSQL = "SELECT * FROM [Tickettypes]";

            return GetList(sSQL);
        }

        public static Tickettype FindById(int typeID)
        {
            //0.vars          
            //1. SQL instructie 
            string sSQL = "SELECT * FROM [Tickettypes]";
            sSQL += " WHERE [Tickettypes].[Id] = @typeID";

            //2. SQL parameters
            DbParameter idPar = Database.AddParameter("@TypeID", typeID);

            //3. Haal data op en controleer op null/lege velden
            return GetList(sSQL, idPar)[0];
        }

        private static List<Tickettype> GetList(string sSQL, params DbParameter[] dbParams)
        {
            List<Tickettype> list = new List<Tickettype>();

            DbDataReader reader = Database.GetData(sSQL, dbParams);
            while (reader.Read())
            {
                list.Add(Fill(reader));
            }
            return list;
        }

        private static Tickettype Fill(DbDataReader reader)
        {
            Tickettype type = new Tickettype();
            type.ID = (int)reader["ID"];
            type.Name = reader["Name"].ToString();
            type.Price = (double)reader["Price"];
            type.Available = (int)reader["Available"];
            return type;
        }
    }
}