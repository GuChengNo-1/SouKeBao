using NPOI.SS.UserModel;
using SokingTreasure.OsSys.BLL;
using SokingTreasure.OsSys.Common;
using SokingTreasure.OsSys.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SokingTreasure.OsSys.Controllers
{
    public class CopyrightController : Controller
    {
        private static DataTable table;
        // GET: Copyright
        public ActionResult CopyrightWorksShow()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "User");
        }
        /// <summary>
        /// 展示作品信息
        /// </summary>
        /// <param name="index"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public ActionResult CopyrightListShow(int index, int limit)
        {
            //查询条件（企业名称）
            var companyName = Request.Params["companyName"] == "" ? null : Request.Params["companyName"];
            //查询条件（作品名称）
            var worksName = Request.Params["worksName"] == "" ? null : Request.Params["worksName"];
            //查询条件（登记类别）
            var category = Request.Params["category"] == "" ? null : Request.Params["category"];
            int count;
            table = CopyrightManage.GetCopyrightByWhere(index, limit, companyName, worksName, category, out count);
            List<CompanyAndCopyright> copyrightList = new List<CompanyAndCopyright>(); 
            foreach (DataRow reader in table.Rows)
            {
                CompanyAndCopyright cac = new CompanyAndCopyright()
                {
                    NumberId = reader["numberId"].ToString(),
                    Id = (int)reader["Id"],
                    CompanyId = (int)reader["CompanyId"],
                    CompanyName = reader["CompanyName"].ToString(),
                    CompanyUrl = reader["CompanyUrl"].ToString(),
                    CompanyType = reader["CompanyType"].ToString(),
                    CompanyPhone = reader["LegalRepresentative"].ToString(),
                    CompanyEmail = reader["CompanyEmail"].ToString(),
                    LegalRepresentative = reader["LegalRepresentative"].ToString(),
                    Category = reader["Category"].ToString(),
                    WorksName = reader["WorksName"].ToString(),
                    Registration = reader["Registration"].ToString(),
                    FinishTime = (DateTime)reader["FinishTime"],
                    RegistrationTime = (DateTime)reader["RegistrationTime"],
                    FirstPublish = (DateTime)reader["FirstPublish"]
                };
                copyrightList.Add(cac);
            }
            return Json(new { code = 0, msg = "", tatol = count, data = copyrightList.ToList() }, JsonRequestBehavior.AllowGet);
        }
        #region 企业作品信息导出
        public ActionResult CopyrightDown()
        {
            DataTable MyDt = new DataTable();
            DataColumn dc = new DataColumn();
            dc = MyDt.Columns.Add("序号", typeof(string));
            dc = MyDt.Columns.Add("企业名称", typeof(string));
            dc = MyDt.Columns.Add("联系人", typeof(string));
            dc = MyDt.Columns.Add("联系电话", typeof(string));
            try
            {
                foreach (DataRow item in table.Rows)
                {
                    DataRow dr = MyDt.NewRow();
                    dr["序号"] = item["NumberId"].ToString();
                    dr["企业名称"] = item["CompanyName"].ToString();
                    dr["联系人"] = item["LegalRepresentative"].ToString();
                    dr["联系电话"] = item["CompanyPhone"].ToString();
                    MyDt.Rows.Add(dr);
                }
                IWorkbook workbook = ExcelHelper.DataTableToExcel(MyDt);
                string path = Server.MapPath("/File/导出.xlsx");
                FileStream fs = new FileStream(path, FileMode.Create);
                workbook.Write(fs);
                return File(path, "application/ms-excel", "企业信息.xlsx");
            }
            catch (Exception ex)
            {
                return Json(new { suses = false }, JsonRequestBehavior.AllowGet);
                throw ex;
            }
        }
        #endregion 企业作品信息导出

    }
}