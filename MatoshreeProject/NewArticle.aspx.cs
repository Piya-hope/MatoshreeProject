#region " Class Description "


#endregion

#region " Primary Namespaces "

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

#endregion

#region " Additional Namespaces "

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Drawing;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
#endregion




namespace MatoshreeProject
{
    public partial class NewArticle : System.Web.UI.Page
    {
        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result, TaskName;

        int UserId = 1;
        /*  int UserId='1'; *///empId chya paramaeter la hi string jayla pahije
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        string Contractid;

        public string Today { get; private set; }
        #endregion

        #region " Constructor "
        #endregion

        #region " Private Variables "
        #endregion

        #region " Shared Variables "
        #endregion

        #region " Public Variables "
        #endregion

        #region " Public Properties "
        #endregion

        #region " Private Functions "
        #endregion

        #region " Protected Functions "

        #endregion

        #region " Protected Functions "


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindArticleDetails();
            }
        }
        public void Clear()
        {
            txtSubject.Text = string.Empty;
            ddlGroup.SelectedIndex = 0;
          
            txtArticleDescribtion.Text = string.Empty;
            chkinternalArticle.Checked = false;
            chkDisabled.Checked = false;

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {

                        UserCommand = new SqlCommand("SP_SaveArticle", UserCon);
                        UserCommand.Connection = UserCon;
                        UserCommand.CommandType = CommandType.StoredProcedure;
                        UserCommand.Parameters.AddWithValue("@SubjectName", txtSubject.Text);
                        UserCommand.Parameters.AddWithValue("@Group", ddlGroup.SelectedItem.Text);
                        UserCommand.Parameters.AddWithValue("@InternalArticle", chkinternalArticle.Checked);
                        UserCommand.Parameters.AddWithValue("@Disabled" , chkDisabled.Checked);
                        UserCommand.Parameters.AddWithValue("@Articledescription", txtArticleDescribtion.Text);
                        UserCommand.Parameters.AddWithValue("@Created_by", UserName); //Session value
                        UserCommand.Parameters.AddWithValue("@EmpID", UserId);//Session value
                        UserCommand.Parameters.AddWithValue("@Designation", Designation);//Session value
                        UserCon.Open();
                        dr = UserCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Article Save Successfully!')", true);

                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Article Already Available!')", true);
                        }

                        Clear();
                        //UserCon.Close();

                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
                finally { }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void BindArticleDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewGroup", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    ddlGroup.DataSource = ds.Tables[0];
                    ddlGroup.DataTextField = "Group_Name";
                    ddlGroup.DataValueField = "Group_ID";
                    ddlGroup.DataBind();
                    ddlGroup.Items.Insert(0, new ListItem("Select Group", "0"));
                }
            }
            catch (Exception ex)
            {
                string ErrorMessgage = ex.Message;
            }
        }

    }
}