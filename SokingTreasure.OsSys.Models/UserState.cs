using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.Models
{
    /// <summary>
    /// 用户状态
    /// </summary>
    public class UserState:EntityBase
    {
        /// <summary>
        /// 状态类型
        /// </summary>
        public string StateType { get; set; }
    }
}
