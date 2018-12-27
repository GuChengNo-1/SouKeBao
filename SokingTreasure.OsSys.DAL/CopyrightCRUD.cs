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
    public class CopyrightCRUD
    {
        private static string connStr =
            ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        /// <summary>
        /// 根据条件获取作品信息
        /// </summary>
        /// <param name="index"></param>
        /// <param name="limit"></param>
        /// <param name="companyName"></param>
        /// <param name="worksName"></param>
        /// <param name="category"></param>
        /// <param name="commodityName"></param>
        public static DataTable GetCopyrightByWhere(int PageIndex, int PageSize, string companyName, string worksName, string category, out int counts)
        {
            int count = 0;
            string sql = "proc_copyrightWorks_Paging";
            SqlParameter[] parame =
            {
                new SqlParameter("@PageIndex",PageIndex),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@companyName",companyName),
                new SqlParameter("@worksName",worksName),
                new SqlParameter("@category",category),
                new SqlParameter("@count",count)
            };
            //将数据库返回页数赋值参数化6
            parame[5].Direction = ParameterDirection.Output;
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
                    counts = (int)cmd.Parameters[5].Value;
                    return dataset.Tables[0];
                }
            }
        }
        /// <summary>
        /// 作品著作权添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool InsertCopyright(CopyrightWorks model)
        {
            string sql = $"insert into	CopyrightWorks values('{model.WorksName}','{model.Registration}','{model.Category}','{model.FinishTime}','{model.RegistrationTime}','{model.FirstPublish}')";
            if (DbHelper.ExecuteNonQuery(sql,false) >= 1)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 修改作品著作权
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateCopyright(CopyrightWorks model)
        {
            string sql = $"update CopyrightWorks set WorksName=('{model.WorksName}',Registration='{model.Registration}',Category='{model.Category}',FinishTime='{model.FinishTime}',RegistrationTime='{model.RegistrationTime}',FirstPublish='{model.FirstPublish}' where id ={model.Id})";
            if (DbHelper.ExecuteNonQuery(sql, false) >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
