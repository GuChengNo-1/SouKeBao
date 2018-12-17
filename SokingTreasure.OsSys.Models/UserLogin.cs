using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.Models
{
    /// <summary>
    /// 用户登录
    /// </summary>
    public class UserLogin:EntityBase
    {
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 用户登录密码
        /// </summary>
        public string LoginPwd { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string LoginEmail { get; set; }
        /// <summary>
        /// 状态编号(用户状态表）
        /// </summary>
        public int StateId { get; set; }
    }
}
