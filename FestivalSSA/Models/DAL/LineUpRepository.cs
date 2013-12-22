using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalSSA.Models.DAL
{
    public class LineUpRepository
    {
        public static List<LineUp> GetLineUp(string stageid,string dateid)
        {
            if ((stageid == null || stageid == "") && (dateid == null || dateid == ""))
            {
                string sql = "SELECT id,start,finish,bandid,stageid,festivaldagid FROM LineUp ORDER BY festivaldagid,start";
                return GetList(sql);
            }
            else if ((stageid != null) && (dateid == null || dateid == ""))
            {
                string sql = "SELECT id,start,finish,bandid,stageid,festivaldagid FROM LineUp WHERE stageid=@stageid ORDER BY FestivaldagID,start";
                DbParameter parstage = Database.AddParameter("@stageid", stageid);
                return GetList(sql, parstage);
            }
            else if ((stageid == null || stageid == "") && (dateid != null))
            {
                string sql = "SELECT id,start,finish,bandid,stageid,festivaldagid FROM LineUp WHERE festivaldagid=@dagid ORDER BY StageID,start";
                DbParameter pardag = Database.AddParameter("@dagid", dateid);
                return GetList(sql, pardag);
            }
            else if ((stageid != null) && (dateid != null))
            {
                string sql = "SELECT id,start,finish,bandid,stageid,festivaldagid FROM LineUp WHERE festivaldagid=@dagid AND stageid=@stageid ORDER BY FestivaldagID,start";
                DbParameter pardag = Database.AddParameter("@dagid", dateid);
                DbParameter parstage = Database.AddParameter("@stageid", stageid);
                return GetList(sql, pardag, parstage);
            }
            else
                return null;
        }

        private static List<LineUp> GetList(string sSQL, params DbParameter[] dbParams)
        {
            List<LineUp> list = new List<LineUp>();

            DbDataReader reader = Database.GetData(sSQL, dbParams);
            while (reader.Read())
            {
                list.Add(Fill(reader));
            }
            return list;
        }

        private static LineUp Fill(DbDataReader reader)
        {
            LineUp lineup = new LineUp();
            lineup.Start = reader["Start"].ToString();
            lineup.Finish = reader["Finish"].ToString();
            lineup.BandID =(int)reader["BandID"];
            lineup.Band = BandRepository.FindById(lineup.BandID);
            lineup.StageID = (int)reader["StageID"];
            lineup.Stage = StageRepository.FindById(lineup.StageID);
            lineup.FestivaldagID = (int)reader["FestivaldagID"];
            lineup.Festivaldag = FestivaldagRepository.FindById(lineup.FestivaldagID);
            return lineup;
        }

    }
}