using tostiş;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace tostiş
{
    public partial class login : signup
    {
        static string userName = Environment.UserName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
            }
        }
        void Clear()
        {
            txtmail.Text = txtpass.Text =  "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAPTOP-4KLGVEG1\SQLEXPRESS;Initial Catalog=WEB;Integrated Security=True"))
            {
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM USERS WHERE user_mail=@user_mail AND userpass=@userpass", sqlCon);
                sqlCmd.Parameters.AddWithValue("@user_mail", txtmail.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@userpass", txtpass.Text.Trim());
                SqlDataReader readuser = sqlCmd.ExecuteReader();
                if (readuser.Read())
                {
                    Session["userName"] = readuser["username"];
                    Session["userSurname"] = readuser["usersurname"];
                    Session["userMail"] = readuser["user_mail"];
                    Session["userPass"] = readuser["userpass"];
                    Session["userID"] = readuser["user_id"];
                    Session["btnrun1"] = "0";
                    Session["btnrun2"] = "0";
                    Session["test1id"] = "T1217";
                    Session["test1desc"] = "Browser Bookmark Discovery";
                    Session["test2id"] = "T1056";
                    Session["test2desc"] = "Input Capture";
                    Session["device"] = userName.Trim();
                    Response.Redirect("home.aspx");

                }
                else
                {
                }

                readuser.Close();
                sqlCon.Close();
                sqlCon.Dispose();
            }


        }
    }
}
