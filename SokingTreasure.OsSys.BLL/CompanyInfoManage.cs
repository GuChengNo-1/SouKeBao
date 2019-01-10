using SokingTreasure.OsSys.DAL;
using SokingTreasure.OsSys.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.BLL
{
    /// <summary>
    /// 企业信息业务逻辑类
    /// </summary>
    public class CompanyInfoManage
    {
        CompanyInfoCRUD service = new CompanyInfoCRUD();

        /// <summary>
        /// 企业信息初始化加载
        /// </summary>
        /// <returns></returns>
        public DataTable GetCompanyIndoDT()
        {
            return service.GetCompanyInfoDT();
        }

        /// <summary>
        /// 企业信息添加
        /// </summary>
        /// <returns></returns>
        public bool AddCompanyInfo(CompanyInfo company)
        {
            //判断是否具有重复的企业信息编号
            int i = service.FindCompanyId(company.CompanyId);
            if (i==0)
            {
                //判断无误后才可做添加功能
                return service.AddCompanyInfo(company) == 1;
            }
            return false;
        }
        /// <summary>
        /// 根据企业id获取企业信息和工商信息
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public static CompanyAndBusiness GetCompanyAndBusinessById(string id)
        {
            return CompanyInfoCRUD.GetCompanyAndBusinessById(id);
        }

        /// <summary>
        /// 企业信息编辑
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public bool EditCompanyInfo(CompanyInfo company)
        {                   
            return service.EditCompanyInfo(company) == 1;
        }

        /// <summary>
        /// 根据企业名称查询企业信息
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="companyName"></param>
        /// <param name="counts"></param>
        /// <returns></returns>
        public static DataTable GetCompanyNameByWhere(int PageIndex, int PageSize, string companyName, out int counts)
        {
            return CompanyInfoCRUD.GetCompanyNameByWhere(PageIndex, PageSize, companyName, out counts);
        }

    }
}
