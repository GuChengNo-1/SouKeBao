using SokingTreasure.OsSys.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokingTreasure.OsSys.DAL
{
    /// <summary>
    /// 用户(增删查改)
    /// </summary>
    public class UserCRUD
    {
        /// <summary>
        /// 检查用户(登录)
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        public static bool CheckUser(UserLogin user) {
            string sql = $"select * from UserLogin where LoginName=@LoginName and LoginPwd=@LoginPwd";
            SqlParameter[] param = {
                 new SqlParameter("@LoginName",user.LoginName),
                 new SqlParameter("@LoginPwd",user.LoginPwd)
             };
            SqlDataReader reader = DbHelper.ExectueReader(sql, false, param);
            while (reader.Read())
            {
                return true;
            }
            return false;
        }

        public static UserLogin GetWhereByUser(UserLogin user)
        {
            string sql = $"select * from UserLogin where LoginName=@LoginName and LoginPwd=@LoginPwd";
            SqlParameter[] param = {
                 new SqlParameter("@LoginName",user.LoginName),
                 new SqlParameter("@LoginPwd",user.LoginPwd)
             };
            DataTable table = DbHelper.GetDataTable(sql, false,param);
            UserLogin ul = new UserLogin();
            foreach (DataRow item in table.Rows)
            {
                ul.Id = (int)item["Id"];
                ul.LoginName = item["LoginName"].ToString();
                ul.LoginPwd = item["LoginPwd"].ToString();
                ul.LoginEmail = item["LoginEmail"].ToString();
                ul.StateId = (int)item["StateId"];
            }
            return ul;
        }

        public static bool InsertUser(UserLogin model)
        {
            string sql = $"insert into UserLogin values('@LoginName','@LoginPwd','@LoginEmail',1)";
            SqlParameter[] param = {
                 new SqlParameter("@LoginName",model.LoginName),
                 new SqlParameter("@LoginPwd",model.LoginPwd),
                 new SqlParameter("@LoginEmail",model.LoginEmail)
             };
            if (DbHelper.ExecuteNonQuery(sql, false, param) >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
