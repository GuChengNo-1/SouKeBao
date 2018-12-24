using SokingTreasure.OsSys.DAL;
using SokingTreasure.OsSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.BLL
{
    public class TrademarkManage
    {
        public static List<CompanyAndTrademark> GetTrademarkByWhere(int index, int limit, string companyName, string applyTimeBegin,string applyTimeOver, string commodityName)
        {
            return TrademarkCRUD.GetTrademarkByWhere(index,limit, companyName, applyTimeBegin, applyTimeOver, commodityName);
        }
    }
}
