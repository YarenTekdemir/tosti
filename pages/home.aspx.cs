using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICSharpCode.SharpZipLib.Zip;


namespace tostiş.pages
{
    public partial class home : System.Web.UI.Page
    {
        static string userName = Environment.UserName;
        string directory1 = @"C:\Users\" + userName + "\\Desktop\\T1217\\T1217.py";
        string directory2 = @"C:\Users\" + userName + "\\Desktop\\T1056\\T1056.py";
        string directory3 = @"C:\Users\" + userName + "\\Downloads\\T1217.zip";
        string directory4 = @"C:\Users\" + userName + "\\Downloads\\T1056.zip";
        string directory5 = @"C:\Users\" + userName + "\\Desktop\\";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }
        const string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WEB;Integrated Security=True ";
        const string IsSelect = "SELECT COUNT(*) FROM USED_TESTS WHERE test_id = @testid AND test_device=@testdevice";
        public int rowExist1()
        {

            int rowAffected = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd1 = new SqlCommand(IsSelect, con);
            cmd1.Parameters.AddWithValue("@testid", Session["test1id"]);
            cmd1.Parameters.AddWithValue("@testdevice", userName);
            cmd1.ExecuteNonQuery();
            rowAffected = (int)cmd1.ExecuteScalar();

            return rowAffected;
        }
        public int rowExist2()
        {

            int rowAffected = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd1 = new SqlCommand(IsSelect, con);
            cmd1.Parameters.AddWithValue("@testid", Session["test2id"]);
            cmd1.Parameters.AddWithValue("@testdevice", userName);
            cmd1.ExecuteNonQuery();
            rowAffected = (int)cmd1.ExecuteScalar();

            return rowAffected;
        }
        protected void btndownload_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/zip";
            Response.AddHeader("Content-Disposition", "attachment; filename=T1217.zip");
            Response.WriteFile(Server.MapPath("~/pscript/T1217.zip"));
            Response.End();
        }

        protected void btnrun_Click(object sender, EventArgs e)
        {
            if (File.Exists(directory3))
            {
                if (!File.Exists(directory1))
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(directory3, directory5);
                    SqlConnection sqlCon = new SqlConnection(ConnectionString);
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("INSERT INTO USED_TESTS (test_id, user_id,test_desc,test_device) Values ('" + Session["test1id"] + "', '" + Session["userID"] + "', '" + Session["test1desc"] + "','" + userName + "')", sqlCon);
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = directory1;
                    info.Arguments = "";
                    info.WindowStyle = ProcessWindowStyle.Normal;
                    info.WorkingDirectory = Path.GetDirectoryName(directory1);
                    Process p = Process.Start(info);
                    p.StartInfo.UseShellExecute = false;
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                else
                {
                    SqlConnection sqlCon = new SqlConnection(ConnectionString);
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("INSERT INTO USED_TESTS (test_id, user_id,test_desc,test_device) Values ('" + Session["test1id"] + "', '" + Session["userID"] + "', '" + Session["test1desc"] + "','" + userName + "')", sqlCon);
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = directory1;
                    info.Arguments = "";
                    info.WindowStyle = ProcessWindowStyle.Normal;
                    info.WorkingDirectory = Path.GetDirectoryName(directory1);
                    Process p = Process.Start(info);
                    p.StartInfo.UseShellExecute = false;
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            else
                lblErrorMessage.Visible = true;

            lblErrorMessage.Text = "First Download Test !!! ";
        }


        protected void btnrun1_Click(object sender, EventArgs e)
        {
            if (File.Exists(directory4))
            {
                if (!File.Exists(directory2))
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(directory4, directory5);
                    SqlConnection sqlCon = new SqlConnection(ConnectionString);
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("INSERT INTO USED_TESTS (test_id, user_id,test_desc,test_device) Values ('" + Session["test2id"] + "', '" + Session["userID"] + "', '" + Session["test2desc"] + "','" + userName + "')", sqlCon);
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = directory2;
                    info.Arguments = "";
                    info.WindowStyle = ProcessWindowStyle.Normal;
                    info.WorkingDirectory = Path.GetDirectoryName(directory2);
                    Process p = Process.Start(info);
                    p.StartInfo.UseShellExecute = false;
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                else
                {

                    SqlConnection sqlCon = new SqlConnection(ConnectionString);
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("INSERT INTO USED_TESTS (test_id, user_id,test_desc,test_device) Values ('" + Session["test2id"] + "', '" + Session["userID"] + "', '" + Session["test2desc"] + "','" + userName + "')", sqlCon);
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = directory2;
                    info.Arguments = "";
                    info.WindowStyle = ProcessWindowStyle.Normal;
                    info.WorkingDirectory = Path.GetDirectoryName(directory2);
                    Process p = Process.Start(info);
                    p.StartInfo.UseShellExecute = false;
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }

            }
            else
            {
                lblErrorMessage.Visible = true;

                lblErrorMessage.Text = "First Download Test !!! ";
            }


        }

        protected void btndownload1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/zip";
            Response.AddHeader("Content-Disposition", "attachment; filename=T1056.zip");
            Response.WriteFile(Server.MapPath("~/pscript/T1056.zip"));
            Response.End();
        }
    }
}