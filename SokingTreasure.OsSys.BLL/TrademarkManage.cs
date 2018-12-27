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
    public class TrademarkManage
    {
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
            return TrademarkCRUD.GetTrademarkByWhere(PageIndex, PageSize, companyName, applyTimeBegin, applyTimeOver, commodityName, out counts);
        }
    }
}
