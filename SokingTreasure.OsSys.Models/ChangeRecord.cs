using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.Models
{
    /// <summary>
    /// 变更记录
    /// </summary>
    public class ChangeRecord : EntityBase
    {
        /// <summary>
        /// 变更时间
        /// </summary>
        public DateTime ChangeRecordTime { get; set; }
        /// <summary>
        /// 变更项目
        /// </summary>
        public string ChangeRecordItem { get; set; }
        /// <summary>
        /// 变更前
        /// </summary>
        public string ChangeRecordAgo { get; set; }
        /// <summary>
        /// 变更后
        /// </summary>
        public string ChangeRecordLater { get; set; }

    }
}
