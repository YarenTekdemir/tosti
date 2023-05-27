using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tostiş
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
            }
        }
        const string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=WEB;Integrated Security=True ";
        const string IsSelect = "SELECT COUNT(*) FROM USERS WHERE user_mail = @user_mail";
        public int rowExist()
        {

            int rowAffected = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd1 = new SqlCommand(IsSelect, con);
            cmd1.Parameters.AddWithValue("@user_mail", (txtmail.Text));


            cmd1.ExecuteNonQuery();
            rowAffected = (int)cmd1.ExecuteScalar();

            return rowAffected;
        }
        public int A()
        {
            string stmt = "SELECT COUNT(*) FROM USERS";
            int count = 0;

            using (SqlConnection thisConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=WEB;Integrated Security=True"))
            {
                using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                {
                    thisConnection.Open();
                    count = (int)cmdCount.ExecuteScalar();
                }
            }
            return count;
        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "" || txtsurname.Text == "" || txtpass.Text == "" || txtpass2.Text == "" || txtmail.Text == "")
            {
                lblFailure.Text = "All fields must be filled";
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=WEB;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO USERS (user_id,username,usersurname,user_mail,userpass) Values('" + A() + "','" + txtname.Text + "','" + txtsurname.Text + "','" + txtmail.Text + "','" + txtpass.Text + "')", conn);



                int rows = rowExist();
                if (rows == 0)
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Response.Redirect("login.aspx");


                }
                else
                {
                    lblFailure.Text = "Email is already taken!!";



                }


            }

        }
        void Clear()
        {
            txtname.Text = txtsurname.Text = txtpass.Text = txtmail.Text = lblSuccess.Text = lblFailure.Text = "";
        }
    }
}