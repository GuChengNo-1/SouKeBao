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
    /// <summary>
    /// 股东信息数据访问类
    /// </summary>
    public class ShareholderCRUD
    {
        Shareholder shareholder = new Shareholder();

        private static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        /// <summary>
        /// 根据股东姓名查询股东信息
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="shareholderName"></param>
        /// <param name="counts"></param>
        /// <returns></returns>
        public static DataTable GetShareholderByWhere(int PageIndex, int PageSize, string shareholderName, out int counts)
        {
            int count = 0;
            string sql = "proc_shareholder_Paging";
            SqlParameter[] parame = {
                new SqlParameter("@PageIndex",PageIndex),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@shareholderName",shareholderName),
                new SqlParameter("@count",count)
            };

            parame[4].Direction = ParameterDirection.Output;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parame);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    counts = (int)cmd.Parameters[4].Value;
                    return ds.Tables[0];
                }
            }
        }

        /// <summary>
        /// 添加股东信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool AddShareholder(Shareholder model)
        {
            string sql = $"insert into Shareholder values('{model.ShareholderName}','{model.CapitalKey}','{model.Contributive}','{model.ContributiveTime}')";
            if (DbHelper.ExecuteNonQuery(sql, false) >= 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改股东信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateShareholder(Shareholder model)
        {
            string sql = $"update Shareholder set ShareholderName='{model.ShareholderName}',CapitalKey='{model.CapitalKey}'";
            if (DbHelper.ExecuteNonQuery(sql, false) >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
