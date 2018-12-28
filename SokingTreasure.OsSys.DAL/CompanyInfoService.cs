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

        private static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        /// <summary>
        /// 企业信息初始化加载
        /// </summary>        
        public DataTable GetCompanyInfoDT()
        {
            return SqlHelper.Execute(CommandType.Text, "select * from CompanyInfo order by CompanyId");
        }

        /// <summary>
        /// 根据企业名称查询企业信息
        /// </summary>
        public static DataTable GetCompanyNameByWhere(int PageIndex, int PageSize, string companyName, out int counts)
        {
            int count = 0;
            string sql = "proc_company_Paging";
            SqlParameter[] prms = {
                new SqlParameter("@PageIndex",PageIndex),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@companyName",companyName),
                new SqlParameter("@count",count)
            };
            prms[3].Direction = ParameterDirection.Output;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(prms);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    counts = (int)cmd.Parameters[3].Value;
                    return ds.Tables[0];
                }
            }
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
        /// 根据企业id获取企业信息和工商信息
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public static CompanyAndBusiness GetCompanyAndBusinessById(string id)
        {
            string sql = $"select * from CompanyInfo as t1,BusinessInfo as t2 where t1.BusinessId = t2.BusinessId and t1.CompanyId = {id}";
            SqlDataReader reader = DbHelper.ExectueReader(sql, false);
            CompanyAndBusiness model = new CompanyAndBusiness();
            while (reader.Read())
            {
                model.BusinessId = (int)reader["BusinessId"];
                model.CompanyId = (int)reader["CompanyId"];
                model.CompanyName = reader["CompanyName"].ToString();
                model.CompanyUrl = reader["CompanyUrl"].ToString();
                model.CompanyType = reader["CompanyType"].ToString();
                model.LegalRepresentative = reader["LegalRepresentative"].ToString();
                model.CompanyPhone = reader["CompanyPhone"].ToString();
                model.CompanyEmail = reader["CompanyEmail"].ToString();
                model.CompanyProfile = reader["CompanyProfile"].ToString();
                model.RegisteredCapital = reader["RegisteredCapital"].ToString();
                model.RealinviteCapital = reader["RealinviteCapital"].ToString();
                model.Management = reader["Management"].ToString();
                model.RegisteredTime = (DateTime)reader["RegisteredTime"];
                model.CreditCode = reader["CreditCode"].ToString();
                model.Taxpayer = reader["Taxpayer"].ToString();
                model.IndustryInvolved = reader["IndustryInvolved"].ToString();
                model.RegistrationNumber = reader["RegistrationNumber"].ToString();
                model.OrganizingCode = reader["OrganizingCode"].ToString();
                model.ApprovalDate = (DateTime)reader["ApprovalDate"];
                model.RegistrationAuthority = reader["RegistrationAuthority"].ToString();
                model.BelongArea = reader["BelongArea"].ToString();
                model.EnglishName = reader["EnglishName"].ToString();
                model.FormerName = reader["FormerName"].ToString();
                model.ContributorsIn = (int)reader["ContributorsIn"];
                model.StaffSize = (int)reader["StaffSize"];
                model.BusnissTerm = reader["BusnissTerm"].ToString();
                model.BusinessAddress = reader["BusinessAddress"].ToString();
                model.BusinessScope = reader["BusinessScope"].ToString();
            }
            return model;
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
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
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
