using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.Models
{
    public class CompanyAndTrademark : EntityBase
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
        /// 公司类型
        /// </summary>
        public string CompanyType { get; set; }
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime ApplyTime { get; set; }
        /// <summary>
        /// 商标
        /// </summary>
        public string TrademarkName { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }
        /// <summary>
        /// 注册号
        /// </summary>
        public string Registration { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 流程状态
        /// </summary>
        public string ProcessState { get; set; }
    }
}
