using SokingTreasure.OsSys.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.BLL
{
    /// <summary>
    /// 股东信息业务逻辑类
    /// </summary>
    public class ShareholderManage
    {
        /// <summary>
        /// 按条件查询股东信息
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="shareholderName"></param>
        /// <param name="counts"></param>
        /// <returns></returns>
        public static DataTable GetShareholderByWhere(int PageIndex, int PageSize, string shareholderName, out int counts)
        {
            return ShareholderCRUD.GetShareholderByWhere(PageIndex, PageSize, shareholderName, out counts);
        }
    }
}
