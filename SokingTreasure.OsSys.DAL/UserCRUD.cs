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
        public static bool CheckUser(UserLogin user)
        {
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
            DataTable table = DbHelper.GetDataTable(sql, false, param);
            UserLogin ul = new UserLogin();
            foreach (DataRow item in table.Rows)
            {
                ul.Id = (int)item["Id"];
                ul.LoginName = item["LoginName"].ToString();
                ul.LoginPwd = item["LoginPwd"].ToString();
                ul.UserEmail = item["UserEmail"].ToString();
                ul.UserPhone = item["UserPhone"].ToString();
                ul.StateId = (int)item["StateId"];
            }
            return ul;
        }
        /// <summary>
        /// 用户名是否已存在
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public static bool UserIfExist(string loginName)
        {
            string sql = $"select * from UserLogin where LoginName=@LoginName";
            SqlParameter[] param = {
                 new SqlParameter("@LoginName",loginName)
             };
            SqlDataReader reader = DbHelper.ExectueReader(sql, false, param);
            while (reader.Read())
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 更改用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public static bool UpdateUser(UserLogin model)
        {
            string sql = $"update UserLogin set UserRealName = '{model.UserRealName}',UserAge = '{model.UserAge}',UserSex = '{model.UserSex}',UserPhone = '{model.UserPhone}',UserEmail = '{model.UserEmail}',UserAddress = '{model.UserAddress}' where Id = {model.Id}";
            if (DbHelper.ExecuteNonQuery(sql,false) >= 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据用户名查询该用户所有信息
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public static UserLogin GetUserByLoginName(string loginName)
        {
            string sql = $"select * from UserLogin where LoginName=@LoginName";
            SqlParameter[] param = {
                 new SqlParameter("@LoginName",loginName)
             };
            SqlDataReader reader = DbHelper.ExectueReader(sql, false, param);
            UserLogin user = new UserLogin();
            while (reader.Read())
            {
                user.Id = (int)reader["Id"];
                user.LoginName = reader["LoginName"].ToString();
                user.LoginCount = (int)reader["LoginCount"];
                user.LastLoginTime = (DateTime)reader["LastLoginTime"];
                user.LoginPwd = reader["LoginPwd"].ToString();
                user.UserRealName = reader["UserRealName"].ToString();
                user.UserAge = (int)reader["UserAge"];
                user.UserSex = reader["UserSex"].ToString();
                user.UserEmail = reader["UserEmail"].ToString();
                user.UserPhone = reader["UserPhone"].ToString();
                user.UserAddress = reader["UserAddress"].ToString();
                user.UserRegistrTime = (DateTime)reader["UserRegistrTime"];
                user.StateId = (int)reader["StateId"];
            }
            return user;
        }
        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="secrecyPwd"></param>
        /// <returns></returns>
        public static bool AlterUserPwd(int userId, string secrecyPwd)
        {
            string sql = $"update UserLogin set LoginPwd = '{secrecyPwd}' where Id = {userId}";
            if (DbHelper.ExecuteNonQuery(sql) >= 1)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 验证用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserLogin VerifyUser(UserLogin model)
        {
            string sql = $"select * from UserLogin where LoginName=@LoginName and UserPhone=@UserPhone and UserEmail=@UserEmail";
            SqlParameter[] param = {
                 new SqlParameter("@LoginName",model.LoginName),
                 new SqlParameter("@UserPhone",model.UserPhone),
                 new SqlParameter("@UserEmail",model.UserEmail)
             };
            DataTable table = DbHelper.GetDataTable(sql, false, param);
            UserLogin ul = new UserLogin();
            foreach (DataRow item in table.Rows)
            {
                ul.Id = (int)item["Id"];
                ul.LoginName = item["LoginName"].ToString();
                ul.LoginPwd = item["LoginPwd"].ToString();
                ul.UserEmail = item["UserEmail"].ToString();
                ul.UserPhone = item["UserPhone"].ToString();
                ul.StateId = (int)item["StateId"];
            }
            return ul;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool InsertUser(UserLogin model)
        {
            string sql = $"insert into UserLogin(LoginName,LoginPwd,UserEmail,UserPhone,LoginCount,UserRegistrTime,LastLoginTime,UserAge,StateId) values('{model.LoginName}','{model.LoginPwd}','{model.UserEmail}','{model.UserPhone}',0,'{DateTime.Now}','{DateTime.Now}',0,1)";
            if (DbHelper.ExecuteNonQuery(sql, false) >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
