using System.IO;
using System.Data;
using System.Collections;
using Npgsql;
using System.Text;
using System;
using System.Security.Cryptography;

namespace Library
{
    class Authorization
    {
        public static bool admin = false;
        public static bool employee = false;
        public static bool user = false;
        public static string nameUser = "";
        
        public static bool checkingUser(string login, string e_mail)
        {
            for (int i = 0; i < DBAction.libraryDS.Tables["reader"].Rows.Count; i++)
            {
                string correctLogin = DBAction.libraryDS.Tables["reader"].Rows[i][0].ToString();
                string correctEmail = DBAction.libraryDS.Tables["reader"].Rows[i][4].ToString();

                if ((login == correctLogin) && (e_mail == correctEmail))
                {
                    nameUser = DBAction.libraryDS.Tables["reader"].Rows[i][1].ToString();
                    return true;
                }
            }
            return false;
        }

        public bool validation(string login, string password)
        {
            DataTable dt = DBAction.libraryDS.Tables["login"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string correctLogin = dt.Rows[i][0].ToString();
                string correctPassword = dt.Rows[i][1].ToString();
               
                #region Other Login (not user)
                string loginAdmin = "admin",
                    passwordAdmin = "b1d466cf639b362790f1eab0627e942c4c16921c",//bestadmin
                    //passwordAdmin = "bestadmin",
                    loginEmployee = "employee",
                    passwordEmployee = "03fb18f49a5b829acf984d8ccd3b04b6e304d856";//em
                #endregion

                if ((correctLogin == login) && (correctPassword.ToLower() == password))
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

        public static string SHAdigest(string pass)
        {
            byte[] bytes = new byte[pass.Length];
            int count = 0;
            foreach (var temp in pass)
            {
                bytes[count++] = Convert.ToByte(temp);
            }

            SHA1 sha = new SHA1CryptoServiceProvider();
            var result = sha.ComputeHash(sha.ComputeHash(bytes));

            StringBuilder hex = new StringBuilder(result.Length * 2);
            foreach (byte b in result)
            { hex.AppendFormat("{0:x2}", b); }
            return hex.ToString();
        }


        //public string blabla(string password)
        //{
        //    //DataTable dt = new DataTable();
        //    //NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
        //    //DBAction.getData(ref dt, ref dataAdapter, "login");
            
        //    System.IO.StreamWriter textFile = new System.IO.StreamWriter(@"D:\textfile.txt");
        //    //for (int i = 0; i < dt.Rows.Count; i++)
        //    //{
        //        //string pass = dt.Rows[i][1].ToString();
        //    string pass = password;
        //        byte[] bytes = new byte[pass.Length];
        //        int count = 0;
        //        foreach (var temp in pass)
        //        {
        //            bytes[count++] = Convert.ToByte(temp);
        //        }


        //        SHA1 sha = new SHA1CryptoServiceProvider();
        //        var result = sha.ComputeHash(sha.ComputeHash(bytes));
        //        //var result = sha.ComputeHash(bytes);
        //        //string hex = "";
        //        //foreach (var temp in result)
        //        //{
        //        //    hex += Convert.ToString(temp);
        //        //}

        //        //string hex = Convert.ToBase64String(bytes);

        //        StringBuilder hex = new StringBuilder(result.Length * 2);
        //        foreach (byte b in result)
        //        { hex.AppendFormat("{0:x2}", b); }

            
        //        textFile.WriteLine(hex.ToString() + "    " + password);

        //    //}
        //    textFile.Close();
        //    return hex.ToString();
        //}


        public void changePassword(string login, string password, string newPassword)
        {

        }

        public void toIssuePassword(string login)
        {

        }
    }
}
