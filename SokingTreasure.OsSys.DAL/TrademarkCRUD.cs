using SokingTreasure.OsSys.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.DAL
{
    public class TrademarkCRUD
    {
        private static string connStr =
            ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        /// <summary>
        /// 根据条件获取商标信息
        /// </summary>
        /// <param name="index"></param>
        /// <param name="limit"></param>
        /// <param name="companyName"></param>
        /// <param name="applyTimeBegin"></param>
        /// <param name="applyTimeOver"></param>
        /// <param name="commodityName"></param>
        /// <returns></returns>
        public static DataTable GetTrademarkByWhere(int PageIndex, int PageSize, string companyName, string applyTimeBegin, string applyTimeOver, string commodityName, out int counts)
        {
            int count = 0;
            string sql = "proc_trademark_Paging";
            SqlParameter[] parame =
            {
                new SqlParameter("@PageIndex",PageIndex),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@companyName",companyName),
                new SqlParameter("@applyTimeStart",applyTimeBegin),
                new SqlParameter("@applyTimeOver",applyTimeOver),
                new SqlParameter("@commodityName",commodityName),
                new SqlParameter("@count",count)
            };
            //将数据库返回页数赋值参数化7
            parame[6].Direction = ParameterDirection.Output;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parame);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet dataset = new DataSet();
                    //写入数据表
                    adapter.Fill(dataset);
                    counts = (int)cmd.Parameters[6].Value;
                    return dataset.Tables[0];
                }
            }
        }
        /// <summary>
        /// 添加商标信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool InsertTrademark(Trademark model)
        {
            string sql = $"insert into Trademark  values('{model.ApplyTime}','{model.TrademarkName}','{model.CommodityName}','{model.Registration}','{model.Category}','{model.ProcessState}')";
            if (DbHelper.ExecuteNonQuery(sql,false) >= 1)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 修改商标信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateTrademark(Trademark model)
        {
            string sql = $"update Trademark set ApplyTime='{model.ApplyTime}',TrademarkName='{model.TrademarkName}',CommodityName='{model.CommodityName}',Registration='{model.Registration}',Category='{model.Category}',ProcessState='{model.ProcessState}' where id = {model.Id})";
            if (DbHelper.ExecuteNonQuery(sql, false) >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
