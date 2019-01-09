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

namespace SokingTreasure.OsSys.Controllers
{
    public class CompanyController : Controller
    {
        /// <summary>
        /// 企业信息
        /// </summary>
        /// <returns></returns>
        // GET: Company
        public ActionResult CompanyInfo()
        {
            return View();
        }

        /// <summary>
        /// 企业信息数据接口
        /// </summary>
        /// <returns></returns>
        public ActionResult CompanyInfoShow(int index, int limit)
        {
            //查询条件(企业名称)
            var companyName = Request.Params["companyName"] == "" ? null : Request.Params["companyName"];
            int count;
            DataTable table = CompanyInfoManage.GetCompanyNameByWhere(index, limit,companyName, out count);
            List<CompanyInfo> companyList = new List<Models.CompanyInfo>();
            foreach (DataRow reader in table.Rows)
            {
                CompanyInfo cf = new CompanyInfo();
                cf.NumberId = reader["numberId"].ToString();
                cf.CompanyId = (int)reader["CompanyId"];
                cf.CompanyName = reader["CompanyName"].ToString();
                cf.LegalRepresentative = reader["LegalRepresentative"].ToString();
                cf.CompanyPhone = reader["CompanyPhone"].ToString();
                cf.CompanyEmail = reader["CompanyEmail"].ToString();
                cf.CompanyUrl = reader["CompanyUrl"].ToString();
                cf.CompanyProfile = reader["CompanyProfile"].ToString();
                companyList.Add(cf);
            }
            return Json(new { code = 0, msg = "", tatol = count, data = companyList.ToList() }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 文件导出/上传
        /// </summary>
        /// <returns></returns>
        //public ActionResult ExcelDerive()
        //{
        //    //判断是否有文件上传
        //    if (Request.Files.Count > 0)
        //    {
        //        //得到文件名
        //        string filename = Request.Files[0].FileName;
        //        //得到后缀名
        //        string suffix = filename.Substring(filename.LastIndexOf("."));
        //        if (suffix.ToLower() == ".xls")
        //        {
        //            //得到新路径
        //            string path = Server.MapPath("~/E:/ExcelDerive" + Guid.NewGuid() + suffix);
        //            Request.Files[0].SaveAs(path);
        //            FileStream fs = new FileStream(path, FileMode.Open);
        //            //读取全部Excel表
        //            HSSFWorkbook workbook = new HSSFWorkbook(fs);
        //            //查询Excel中的表
        //            HSSFSheet sheet = workbook.GetSheet("Sheet1") as HSSFSheet;
        //            CompanyInfoService cis = new CompanyInfoService();
        //            for (int i = 0; i < sheet.LastRowNum + 1; i++)
        //            {
        //                CompanyInfo cf = new CompanyInfo();
        //                HSSFRow row = sheet.GetRow(i) as HSSFRow;

        //                //企业名称
        //                var ce = row.GetCell(0);
        //                if (ce.CellType == NPOI.SS.UserModel.CellType.String)
        //                {
        //                    cf.CompanyName = ce.StringCellValue;
        //                }
        //                if (ce.CellType == NPOI.SS.UserModel.CellType.Numeric)
        //                {
        //                    cf.CompanyName = ce.NumericCellValue.ToString();
        //                }

        //                //企业电话
        //                ce = row.GetCell(1);
        //                if (ce.CellType == NPOI.SS.UserModel.CellType.String)
        //                {
        //                    cf.CompanyPhone = ce.StringCellValue;
        //                }
        //                if (ce.CellType == NPOI.SS.UserModel.CellType.Numeric)
        //                {
        //                    cf.CompanyPhone = ce.NumericCellValue.ToString();
        //                }

        //                //企业邮箱
        //                ce = row.GetCell(2);
        //                if (ce.CellType == NPOI.SS.UserModel.CellType.String)
        //                {
        //                    cf.CompanyEmail = ce.StringCellValue;
        //                }
        //                if (ce.CellType == NPOI.SS.UserModel.CellType.Numeric)
        //                {
        //                    cf.CompanyEmail = ce.NumericCellValue.ToString();
        //                }

        //                //企业网址
        //                ce = row.GetCell(3);
        //                if (ce.CellType == NPOI.SS.UserModel.CellType.String)
        //                {
        //                    cf.CompanyUrl = ce.StringCellValue;
        //                }
        //                if (ce.CellType == NPOI.SS.UserModel.CellType.Numeric)
        //                {
        //                    cf.CompanyUrl = ce.NumericCellValue.ToString();
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Response.Write("选择文件格式有误");
        //        }
        //    }
        //    return View();
        //}

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


    }

}
