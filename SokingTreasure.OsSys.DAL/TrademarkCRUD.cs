using SokingTreasure.OsSys.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.DAL
{
    public class TrademarkCRUD
    {
        public static List<CompanyAndTrademark> GetTrademarkByWhere(int index, int limit, string companyName, string applyTimeBegin,string applyTimeOver, string commodityName)
        {
            string sql = $"exec proc_trademark_Paging {index},{limit},'{companyName}','{applyTimeBegin}','{applyTimeOver}','{commodityName}'";
            SqlDataReader reader = DbHelper.ExectueReader(sql, false);
            List<CompanyAndTrademark> list = new List<CompanyAndTrademark>();
            while (reader.Read())
            {
                CompanyAndTrademark cat = new CompanyAndTrademark();
                cat.NumberId = reader["numberId"].ToString();
                cat.Id = (int)reader["Id"];
                cat.CompanyId = (int)reader["CompanyId"];
                cat.CompanyName = reader["CompanyName"].ToString();
                cat.CompanyUrl = reader["CompanyUrl"].ToString();
                cat.CompanyType = reader["CompanyType"].ToString();
                cat.ApplyTime = (DateTime)reader["ApplyTime"];
                cat.Category = reader["Category"].ToString();
                cat.CommodityName = reader["CommodityName"].ToString();
                cat.TrademarkName = reader["TrademarkName"].ToString();
                cat.LegalRepresentative = reader["LegalRepresentative"].ToString();
                cat.ProcessState = reader["ProcessState"].ToString();
                cat.Registration = reader["Registration"].ToString();
                cat.CompanyPhone = reader["LegalRepresentative"].ToString();
                cat.CompanyEmail = reader["CompanyEmail"].ToString();
                list.Add(cat);
            }
            return list;
        }
    }
}
