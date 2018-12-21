using SokingTreasure.OsSys.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.DAL
{
    /// <summary>
    /// 企业信息的数据访问层
    /// </summary>
    public class CompanyInfoDAL
    {
        /// <summary>
        /// 加载全部企业信息数据
        /// </summary>
        public void GetAllCompanyInfo()
        {
            //try
            //{
            //    string sql = "select * from CompanyInfo";
            //    ResultSet rs = DbHelper.GetDataTable(sql);
            //    List companys = new ArrayList();
            //    while (rs.next())
            //    {
            //        CompanyInfo com = new CompanyInfo();
            //        com.setCompanyName(rs.getString("CompanyName"));
            //        com.setLegalRepresentative(rs.getString("LegalRepresentative"));
            //        com.setCompanyPhone(rs.getString("CompanyPhone"));
            //        com.setCompanyEmail(rs.getString("CompanyEmail"));
            //        com.setCompanyUrl(rs.getString("CompanyUrl"));
            //        companys.Add(com);
            //    }
            //    return companys;
            //}
            //catch (Exception ex)
            //{
            //    ex.GetBaseException();
            //    return null;
           //}
       
        }

    }
}
