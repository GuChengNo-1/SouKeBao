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
    public class UserLogin : EntityBase
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
        /// 用户姓名
        /// </summary>
        public string UserRealName { get; set; }
        /// <summary>
        /// 用户年龄
        /// </summary>
        public int UserAge { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public string UserSex { get; set; }
        /// <summary>
        /// 用户地址
        /// </summary>
        public string UserAddress { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string UserEmail { get; set; }
        /// <summary>
        /// 用户手机号码
        /// </summary>
        public string UserPhone { get; set; }
        /// <summary>
        /// 用户登录次数
        /// </summary>
        public int LoginCount { get; set; }
        /// <summary>
        /// 用户注册日期
        /// </summary>
        public DateTime UserRegistrTime { get; set; }
        /// <summary>
        /// 用户最后登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 状态编号(用户状态表）
        /// </summary>
        public int StateId { get; set; }
    }
}
