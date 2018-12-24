using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.Models
{
    /// <summary>
    /// 作品著作权
    /// </summary>
    public class CopyrightWorks : EntityBase
    {
        /// <summary>
        /// 作品名称
        /// </summary>
        public string WorksName { get; set; }
        /// <summary>
        /// 登记号
        /// </summary>
        public string Registration { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 创作完成日期
        /// </summary>
        public DateTime FinishTime { get; set; }
        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime RegistrationTime { get; set; }
        /// <summary>
        /// 首次发布日期
        /// </summary>
        public DateTime FirstPublish { get; set; }
    }
}
