using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.Models
{
    /// <summary>
    /// 商标信息
    /// </summary>
    public class Trademark:EntityBase
    {
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime ApplyTime { get; set; }
        /// <summary>
        /// 商标
        /// </summary>
        public string TrademarkName { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }
        /// <summary>
        /// 注册号
        /// </summary>
        public string Registration { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 流程状态
        /// </summary>
        public string ProcessState { get; set; }
    }
}
