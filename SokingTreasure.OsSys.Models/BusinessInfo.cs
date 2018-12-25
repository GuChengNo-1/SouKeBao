using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.Models
{
    /// <summary>
    /// 工商信息表
    /// </summary>
    public class BusinessInfo:EntityBase
    {
        /// <summary>
        /// 注册资本
        /// </summary>
        public string RegisteredCapital { get; set; }
        /// <summary>
        /// 实邀资本
        /// </summary>
        public string RealinviteCapital { get; set; }
        /// <summary>
        /// 经营状态
        /// </summary>
        public string Management { get; set; }
        /// <summary>
        /// 成立时间
        /// </summary>
        public DateTime RegisteredTime { get; set; }
        /// <summary>
        /// 统一社会信用代码
        /// </summary>
        public string CreditCode { get; set; }
        /// <summary>
        /// 纳税人识别号
        /// </summary>
        public string Taxpayer { get; set; }
        /// <summary>
        /// 所属行业
        /// </summary>
        public string IndustryInvolved { get; set; }
        /// <summary>
        /// 注册号
        /// </summary>
        public string RegistrationNumber { get; set; }
        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string OrganizingCode { get; set; }
        /// <summary>
        /// 核准日期
        /// </summary>
        public DateTime ApprovalDate { get; set; }
        /// <summary>
        /// 登记机关
        /// </summary>
        public string RegistrationAuthority { get; set; }
        /// <summary>
        /// 所属地区
        /// </summary>
        public string BelongArea { get; set; }
        /// <summary>
        /// 英文名
        /// </summary>
        public string EnglishName { get; set; }
        /// <summary>
        /// 曾用名
        /// </summary>
        public string FormerName { get; set; }
        /// <summary>
        /// 参保人数
        /// </summary>
        public int ContributorsIn { get; set; }
        /// <summary>
        /// 人员规模
        /// </summary>
        public int StaffSize { get; set; }
        /// <summary>
        /// 营业期限
        /// </summary>
        public string BusnissTerm { get; set; }
        /// <summary>
        /// 企业地址
        /// </summary>
        public string BusinessAddress { get; set; }
        /// <summary>
        /// 经营范围
        /// </summary>
        public string BusinessScope { get; set; }
    }
}
