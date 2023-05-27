using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tostiş.pages
{
    public partial class profile : System.Web.UI.Page
    {
        static string userName = Environment.UserName;
        string directory1 = @"C:\Users\" + userName + "\\Desktop\\T1217\\Bookmarks.txt";
        string directory2 = @"C:\Users\" + userName + "\\Desktop\\T1056\\Result.txt";
        const string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WEB;Integrated Security=True ";
        const string IsSelect = "SELECT COUNT(*) FROM USED_TESTS WHERE test_id = @testid AND user_id=@userid";

        public int rowExist1()
        {

            int rowAffected = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd1 = new SqlCommand(IsSelect, con);
            cmd1.Parameters.AddWithValue("@testid", Session["test1id"]);
            cmd1.Parameters.AddWithValue("@userid", Session["userID"]);
            cmd1.ExecuteNonQuery();
            rowAffected = (int)cmd1.ExecuteScalar();

            return rowAffected;
        }
        public int rowExist2()
        {

            int rowAffected = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd2 = new SqlCommand(IsSelect, con);
            cmd2.Parameters.AddWithValue("@testid", Session["test2id"]);
            cmd2.Parameters.AddWithValue("@userid", Session["userID"]);
            cmd2.ExecuteNonQuery();
            rowAffected = (int)cmd2.ExecuteScalar();

            return rowAffected;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lbluser.Text = "" + Session["userName"];
            lblusers.Text = " " + Session["userSurname"];
            lblmail.Text = "" + Session["userMail"];

            int rows = rowExist1();
            int rows1 = rowExist2();
            if (rows == 1)
            {
                btnread1.Visible = true;
            }
            if (rows1 == 1)
            {
                btnread2.Visible = true;
            }
        }
        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session["userName"] = "";
            Session["userSurname"] = "";
            Session["userMail"] = "";
            Session["userPass"] = "";
            Session["userID"] = "";
            Response.Redirect("loginpage.aspx");


        }

        protected void btnread1_Click(object sender, EventArgs e)
        {


            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = directory1;
            info.Arguments = "";
            info.WindowStyle = ProcessWindowStyle.Normal;
            info.WorkingDirectory = Path.GetDirectoryName(directory1);
            Process p = Process.Start(info);

            p.StartInfo.UseShellExecute = false;
        }

        protected void btnread2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = directory2;
            info.Arguments = "";
            info.WindowStyle = ProcessWindowStyle.Normal;
            info.WorkingDirectory = Path.GetDirectoryName(directory2);
            Process p = Process.Start(info);
        }
    }
}