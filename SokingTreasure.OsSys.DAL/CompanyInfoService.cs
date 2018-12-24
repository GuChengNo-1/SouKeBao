using DAL;
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
    /// 企业信息数据访问类
    /// </summary>
    public class CompanyInfoService
    {
        CompanyInfo company = new CompanyInfo();

        readonly string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        /// <summary>
        /// 企业信息初始化加载
        /// </summary>        
        public DataTable GetCompanyInfoDT()
        {
            return SqlHelper.Execute(CommandType.Text, "select * from CompanyInfo order by CompanyId");
        }

        /// <summary>
        /// 判断是否有重复的企业编号存在
        /// </summary>
        public int FindCompanyId(int CompanyId)
        {
            string sql = "select count(*) from CompanyInfo where CompanyId=@Cid";
            SqlParameter[] pars = {
                new SqlParameter("@Cid",CompanyId)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.Text, sql, pars));
        }

        /// <summary>
        /// 企业信息添加功能
        /// </summary>      
        public int AddCompanyInfo(CompanyInfo company)
        {
            string sql = "insert into CompanyInfo values(@CompanyId,@CompanyName,@LegalRepresentative,@CompanyPhone,@CompanyEmail,@CompanyUrl,@CompanyProfile,@CompanyType)";
            SqlParameter[] pars = {
                new SqlParameter("@CompanyId",""),
                new SqlParameter("@CompanyName",company.CompanyName),
                new SqlParameter("@LegalRepresentative",company.LegalRepresentative),
                new SqlParameter("@CompanyPhone",company.CompanyPhone),
                new SqlParameter("@CompanyEmail",company.CompanyEmail),
                new SqlParameter("@CompanyUrl",company.CompanyUrl),
                new SqlParameter("@CompanyProfile",company.CompanyProfile),
                new SqlParameter("@CompanyType",company.CompanyType)
            };
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// 企业信息编辑功能
        /// </summary>
        /// <returns></returns>
        public int EditCompanyInfo(CompanyInfo company)
        {
            string sql = "update CompanyInfo set CompanyName=@Cname,LegalRepresentative=@Legal,CompanyPhone=@Cphone,CompanyEmail=@Cemail,CompanyUrl=@Curl,CompanyProfile=@Cprofile,CompanyType=@Ctype where CompanyId=@Cid";
            SqlParameter[] pars = {
                new SqlParameter("@Cname",company.CompanyName),
                new SqlParameter("@Legal",company.LegalRepresentative),
                new SqlParameter("@Cphone",company.CompanyPhone),
                new SqlParameter("@Cemail",company.CompanyEmail),
                new SqlParameter("@Curl",company.CompanyUrl),
                new SqlParameter("@Cprofile",company.CompanyProfile),
                new SqlParameter("@Ctype",company.CompanyType),
                new SqlParameter("@Cid",company.CompanyId)
            };
            return SqlHelper.ExecuteNonQuery(sql,CommandType.Text, pars);
        }

        /// <summary>
        /// 企业信息删除功能
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public int DelCompanyInfo(int CompanyId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from CompanyInfo where CompanyId=@Cid", conn);
                cmd.Parameters.AddWithValue("@Cid", CompanyId);
                return cmd.ExecuteNonQuery();
            }
        }

    }
}
