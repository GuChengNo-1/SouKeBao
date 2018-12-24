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
        /// 企业名称
        /// </summary>
        private string CompanyName;

        public string getCompanyName()
        {
            return CompanyName;
        }

        public void setCompanyName(string companyName)
        {
            this.CompanyName = companyName;
        }

        /// <summary>
        /// 法定代表人
        /// </summary>
        private string LegalRepresentative;

        public string getLegalRepresentative()
        {
            return LegalRepresentative;
        }

        public void setLegalRepresentative(string legalRepresentative)
        {
            this.LegalRepresentative = legalRepresentative;
        }

        /// <summary>
        /// 企业电话
        /// </summary>
        private string CompanyPhone;

        public string getCompanyPhone()
        {
            return CompanyPhone;
        }

        public void setCompanyPhone(string companyPhone)
        {
            this.CompanyPhone = companyPhone;
        }

        /// <summary>
        /// 企业邮箱
        /// </summary>
        private string CompanyEmail;

        public string getCompanyEmail()
        {
            return CompanyEmail;
        }

        public void setCompanyEmail(string companyEmail)
        {
            this.CompanyEmail = companyEmail;
        }

        /// <summary>
        /// 企业网址
        /// </summary>
        public string CompanyUrl { get; set; }

        /// <summary>
        /// 公司类型
        /// </summary>
        public string CompanyType { get; set; }
        /// <summary>
        /// 工商信息（外键约束）
        /// </summary>
        public int BusinessId { get; set; }
        /// <summary>
        /// 股东信息（外键约束）
        /// </summary>
        public int ShareholderId { get; set; }
        /// <summary>
        /// 变更记录（外键约束）
        /// </summary>
        public int ChangeRecordId { get; set; }
        /// <summary>
        /// 商标信息（外键约束）
        /// </summary>
        public int TrademarkId { get; set; }
        /// <summary>
        /// 作品著作权（外键约束）
        /// </summary>
        public int CopyrightWorksId { get; set; }
    }
}
