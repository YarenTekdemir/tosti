using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tostiş.pages
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtname.Text = "" + Session["userName"];
                txtsurname.Text = "" + Session["userSurname"];
                txtpass.Text = "" + Session["userPass"];
                txtpass2.Text = "" + Session["userPass"];

                Clear();
            }
        }
        const string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WEB;Integrated Security=True ";
        const string IsSelect = "SELECT COUNT(*) FROM USERS WHERE user_id = @userid";
        public int rowChange()
        {

            int rowAffected = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd1 = new SqlCommand(IsSelect, con);
            cmd1.Parameters.AddWithValue("@user_id", Session["userID"]);

            cmd1.ExecuteNonQuery();
            rowAffected = (int)cmd1.ExecuteScalar();

            return rowAffected;
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAPTOP-4KLGVEG1\SQLEXPRESS;Initial Catalog=WEB;Integrated Security=True"))
            {

                sqlCon.Open();




                if (txtname.Text == "" || txtsurname.Text == "" || txtpass.Text == "" || txtpass2.Text == "")
                {
                    lblErrorMessage1.Text = "All fields must be filled !!";
                }
                else
                {

                    SqlCommand cmd = new SqlCommand("UPDATE USERS SET username= @username ,usersurname=@usersurname,userpass= @userpass  WHERE user_id = '" + Session["userID"] + "'", sqlCon);
                    cmd.Parameters.AddWithValue("@username", txtname.Text.Trim());
                    cmd.Parameters.AddWithValue("@usersurname", txtsurname.Text.Trim());
                    cmd.Parameters.AddWithValue("@userpass", txtpass.Text.Trim());
                    cmd.ExecuteNonQuery();
                    SqlCommand sqlCmd = new SqlCommand("SELECT * FROM USERS WHERE user_id=@userid", sqlCon);
                    sqlCmd.Parameters.AddWithValue("@userid", Session["userID"]);
                    SqlDataReader readuser = sqlCmd.ExecuteReader();
                    if (readuser.Read())
                    {
                        if (readuser["user_mail"] != Session["userMail"] || readuser["username"] != Session["userName"] || readuser["usersurname"] != Session["userSurname"] || readuser["userpass"] != Session["userPass"])
                        {
                            Session["userName"] = txtname.Text.Trim();
                            Session["userSurname"] = txtsurname.Text.Trim();

                            Session["userPass"] = txtpass.Text.Trim();
                            Response.Redirect("home.aspx");
                        }
                        else
                        {
                            lblErrorMessage1.Text = "Update Failed";
                        }
                    }
                    readuser.Close();
                    sqlCon.Close();
                    Response.Redirect("home.aspx");
                }




            }



        }
        void Clear()
        {
            lblErrorMessage1.Text = "";
        }
    }
}