using System.IO;
using System.Data;
using System.Collections;
using Npgsql;

namespace Library
{
    class Authorization
    {
        public static bool admin = false;
        public static bool employee = false;
        public static bool user = false;
        public static string nameUser = "";
        //private const string filePath = @"D:\my folder\study\practice\3. Third Level\5 семестр\Проектирование БД\Library\Library\bin\Debug\info.txt";
        
        public bool checkingUser(string login, string password)
        {
            return (validation(login, password));
        }

        

        private bool validation(string login, string password)
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
            DBAction.getData(ref dt, ref dataAdapter, "login");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string correctLogin = dt.Rows[i][0].ToString();
                string correctPassword = dt.Rows[i][1].ToString();

                #region Other Login (not user)
                const string loginAdmin = "admin",
                    passwordAdmin = "bestadmin",
                    loginEmployee = "employee",
                    passwordEmployee = "em";
                #endregion

                if ((correctLogin == login) && (correctPassword == password))
                {
                    user = true;
                    nameUser = login;
                    return user;
                }
                else if ((login == loginEmployee) && (password == passwordEmployee))
                {
                    employee = true;
                    return employee;

                }
                else if ((login == loginAdmin) && (password == passwordAdmin))
                {
                    admin = true;
                    return admin;
                }
                
            }
            return false;
        }
    }
}
