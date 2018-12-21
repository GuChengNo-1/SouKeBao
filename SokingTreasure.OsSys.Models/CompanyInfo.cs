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
        private string CompanyUrl;

        public string getCompanyUrl()
        {
            return CompanyUrl;
        }

        public void setCompanyUrl(string companyUrl)
        {
            this.CompanyUrl = companyUrl;
        }

        /// <summary>
        /// 工商信息
        /// </summary>
        private int BusinessId;

        public int getBusinessId()
        {
            return BusinessId;
        }

        public void setBusinessId(int businessId)
        {
            this.BusinessId = businessId;
        }

    }
}
