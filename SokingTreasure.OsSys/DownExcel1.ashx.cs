using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SokingTreasure.OsSys
{
    /// <summary>
    /// DownExcel1 的摘要说明
    /// </summary>
    public class DownExcel1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/x-excel";
            string filename = HttpUtility.UrlEncode("企业信息数据.xls");
            context.Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)hssfworkbook.CreateSheet();
            HSSFRow row = (HSSFRow)sheet.CreateRow(0);
            row.CreateCell(0, NPOI.SS.UserModel.CellType.String).SetCellValue("企业名称");
            row.CreateCell(1, NPOI.SS.UserModel.CellType.String).SetCellValue("企业电话");
            row.CreateCell(2, NPOI.SS.UserModel.CellType.String).SetCellValue("企业邮箱");
            row.CreateCell(3, NPOI.SS.UserModel.CellType.String).SetCellValue("企业网址");
            using (SqlConnection conn = new SqlConnection("Data Source=SERVER;Initial Catalog=database;User ID=sa;Password="))
            {
                conn.Open();
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select CompanyName,CompanyPhone,CompanyEmail,CompanyUrl from CompanyInfo";
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        int rownum = 1;
                        while (reader.Read())
                        {
                            string name = reader.GetString(reader.GetOrdinal ("CompanyName"));
                            string phone = reader.GetString(reader.GetOrdinal("CompanyPhone"));
                            string email = reader.GetString(reader.GetOrdinal("CompanyEmail"));
                            string urls = reader.GetString(reader.GetOrdinal("CompanyUrl"));

                            row = (HSSFRow)sheet.CreateRow(rownum);
                            row.CreateCell(0, NPOI.SS.UserModel.CellType.String).SetCellValue(name);
                            row.CreateCell(1, NPOI.SS.UserModel.CellType.String).SetCellValue(phone);
                            row.CreateCell(2, NPOI.SS.UserModel.CellType.String).SetCellValue(email);
                            row.CreateCell(3, NPOI.SS.UserModel.CellType.String).SetCellValue(urls);
                            rownum++;
                        }
                    }
                }
            }
            hssfworkbook.Write(context.Response.OutputStream);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}