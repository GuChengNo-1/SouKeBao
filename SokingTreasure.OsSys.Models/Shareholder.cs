using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.Models
{
    /// <summary>
    /// 股东信息
    /// </summary>
    public class Shareholder:EntityBase
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string NumberId { get; set; }
        /// <summary>
        /// 股东（发起人）
        /// </summary>
        public string ShareholderName { get; set; }
        /// <summary>
        /// 出资比例
        /// </summary>
        public string CapitalKey { get; set; }
        /// <summary>
        /// 认缴出资
        /// </summary>
        public string Contributive { get; set; }
        /// <summary>
        /// 出资时间
        /// </summary>
        public DateTime ContributiveTime { get; set; }
    }
}
