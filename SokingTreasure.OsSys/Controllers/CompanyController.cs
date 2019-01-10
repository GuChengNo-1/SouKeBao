using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Data;
using System.Collections;
using SokingTreasure.OsSys.BLL;
using SokingTreasure.OsSys.Models;
using SokingTreasure.OsSys.DAL;
using SokingTreasure.OsSys.Common;

namespace SokingTreasure.OsSys.Controllers
{
    public class CompanyController : Controller
    {
        private static DataTable table;

        /// <summary>
        /// 企业信息
        /// </summary>
        /// <returns></returns>
        // GET: Company
        public ActionResult CompanyInfo()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "User");
        }

        /// <summary>
        /// 企业信息数据接口
        /// </summary>
        /// <returns></returns>
        public ActionResult CompanyInfoList(int index, int limit)
        {
            //查询条件（企业名称）
            var companyName = Request.Params["companyName"] == "" ? null : Request.Params["companyName"];
            int count;
            table = CompanyInfoManage.GetCompanyNameByWhere(index, limit, companyName, out count);
            List<CompanyInfo> companyList = new List<Models.CompanyInfo>();
            foreach (DataRow reader in table.Rows)
            {
                CompanyInfo co = new CompanyInfo()
                {
                    NumberId = reader["numberId"].ToString(),
                    CompanyName = reader["CompanyName"].ToString(),
                    LegalRepresentative = reader["LegalRepresentative"].ToString(),
                    CompanyPhone = reader["LegalRepresentative"].ToString(),
                    CompanyEmail = reader["CompanyEmail"].ToString(),
                    CompanyUrl = reader["CompanyUrl"].ToString(),
                    CompanyProfile = reader["CompanyProfile"].ToString()
                };
                companyList.Add(co);
            }
            return Json(new { code = 0, msg = "", tatol = count, data = companyList.ToList() }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 企业数据展示页面
        /// </summary>
        /// <returns></returns>
        public ActionResult CompanyShow(string id)
        {
            ViewData["companyId"] = id;
            if (id != null)
            {
                return View();
            }
            return RedirectToAction("HomePage", "Home");
        }

        /// <summary>
        /// 企业详情数据展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetCompanyAndBusiness(string id)
        {
            var data = CompanyInfoManage.GetCompanyAndBusinessById(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 企业信息导出数据
        /// </summary>
        /// <returns></returns>
        public ActionResult CompanyDown()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc = dt.Columns.Add("序号", typeof(string));
            dc = dt.Columns.Add("企业名称", typeof(string));
            dc = dt.Columns.Add("联系人", typeof(string));
            dc = dt.Columns.Add("联系电话", typeof(string));
            try
            {
                foreach (DataRow item in table.Rows)
                {
                    DataRow dr = dt.NewRow();
                    dr["序号"] = item["NumberId"].ToString();
                    dr["企业名称"] = item["CompanyName"].ToString();
                    dr["联系人"] = item["LegalRepresentative"].ToString();
                    dr["联系电话"] = item["CompanyPhone"].ToString();
                    dt.Rows.Add(dr);
                }
                IWorkbook workbook = ExcelHelper.DataTableToExcel(dt);
                string path = Server.MapPath("/File/导出.xlsx");
                FileStream fs = new FileStream(path, FileMode.Create);
                workbook.Write(fs);
                return File(path, "application/ms-excel", "企业信息.xlsx");
            }
            catch (Exception ex)
            {
                return Json(new { suces = false }, JsonRequestBehavior.AllowGet);
                throw ex;
            }
        }
    }

}
