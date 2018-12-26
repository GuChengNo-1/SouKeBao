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
    public class CopyrightManage
    {
        //public static List<CompanyAndCopyright> GetCopyrightByWhere( string companyName, string worksName, string category)
        //{
        //    return CopyrightCRUD.GetCopyrightByWhere(companyName, worksName, category);
        //}
        public static DataTable GetCopyrightByWhere(int PageIndex, int PageSize, string companyName, string worksName, string category, out int counts)
        {
            return CopyrightCRUD.GetCopyrightByWhere(PageIndex, PageSize, companyName,worksName,category, out counts);
        }
    }
}
