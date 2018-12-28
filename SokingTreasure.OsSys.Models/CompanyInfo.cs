using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.Models
{
    /// <summary>
    /// 企业信息
    /// </summary>
    public class CompanyInfo : EntityBase
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string NumberId { get; set; }

        /// <summary>
        /// 企业编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 法定代表人
        /// </summary>
        public string LegalRepresentative { get; set; }
        /// <summary>
        /// 企业电话
        /// </summary>
        public string CompanyPhone { get; set; }
        /// <summary>
        /// 企业邮箱
        /// </summary>
        public string CompanyEmail { get; set; }
        /// <summary>
        /// 企业网址
        /// </summary>
        public string CompanyUrl { get; set; }
        /// <summary>
        /// 企业简介
        /// </summary>
        public string CompanyProfile { get; set; }
        /// <summary>
        /// 企业类型
        /// </summary>
        public string CompanyType { get; set; }
        /// <summary>
        /// 工商信息
        /// </summary>
        public int BusinessId { get; set; }

        /// <summary>
        /// 股东信息
        /// </summary>
        public int ShareholderId { get; set; }

        /// <summary>
        /// 变更记录
        /// </summary>
        public int ChangeRecordId { get; set; }

        /// <summary>
        /// 商标信息
        /// </summary>
        public int TrademarkId { get; set; }

        /// <summary>
        /// 作品著作权
        /// </summary>
        public int CopyrightWorksId { get; set; }
    }
}

