
#region " Class Description ";


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
using System.Diagnostics.Contracts;

//using System.Web.UI.DataVisualization.Charting;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Linq;
using AjaxControlToolkit;
//using DocumentFormat.OpenXml.VariantTypes;
//using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
#endregion



namespace MatoshreeProject
{
    public partial class EditTestArticle : System.Web.UI.Page
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

        int UserId;
        /*  int UserId='1'; *///empId chya paramaeter la hi string jayla pahije
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        string Contractid;
        string ArticleID;
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

        public void Clear()
        {
            txtSubjectName.Text = string.Empty;
            ddlGroup.SelectedIndex = 0;

            txtArticleDescribtion.Text = string.Empty;

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
        public void GetArticleByID()
        {
            

            try
            {
                String Status;
                String InternalArticle;
                String Disabled;

                ArticleID = HttpUtility.UrlDecode(Request.QueryString["article"]);
                lblArticleNameWGV.Text = ArticleID;

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    UserCommand = new SqlCommand("SP_GetArticleByID", UserCon);
                    UserCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(UserCommand);

                    UserCommand.Parameters.AddWithValue("@Article_ID", lblArticleNameWGV.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        txtSubjectName.Text = dt.Rows[0]["SubjectName"].ToString();
                        ddlGroup.SelectedItem.Text = dt.Rows[0]["Group"].ToString();

                        Status = dt.Rows[0]["Status"].ToString();
                        if (Status == "True")
                        {
                            RadioButtonListArticle.SelectedValue = "1";
                        }
                        else
                        {
                            RadioButtonListArticle.SelectedValue = "0";
                        }

                        InternalArticle = dt.Rows[0]["InternalArticle"].ToString();
                        if (InternalArticle == "True")
                        {
                            chkinternalArticle.Checked = true;
                        }
                        else
                        {
                            chkinternalArticle.Checked = false;
                        }

                        Disabled = dt.Rows[0]["Disabled"].ToString();
                        if (Disabled == "True")
                        {
                            chkDisabled.Checked = true;
                        }
                        else
                        {
                            chkDisabled.Checked = false;
                           
                        }
                        txtArticleDescribtion.Text = dt.Rows[0]["Articledescription"].ToString();
                    }
                    else
                    {
                        Response.Redirect("Article.aspx", true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindArticleDetails();
                GetArticleByID();
                
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {

                        UserCommand = new SqlCommand("SP_UpdateArticle", UserCon);
                        UserCommand.Connection = UserCon;
                        UserCommand.CommandType = CommandType.StoredProcedure;
                        UserCommand.Parameters.AddWithValue("@Article_ID", lblArticleNameWGV.Text);
                        UserCommand.Parameters.AddWithValue("@SubjectName", txtSubjectName.Text);
                        UserCommand.Parameters.AddWithValue("@Group", ddlGroup.SelectedItem.Text);
                        UserCommand.Parameters.AddWithValue("@InternalArticle", chkinternalArticle.Checked);
                        UserCommand.Parameters.AddWithValue("@Disabled", chkDisabled.Checked);
                        UserCommand.Parameters.AddWithValue("@Articledescription", txtArticleDescribtion.Text);
                        UserCommand.Parameters.AddWithValue("@Created_by", UserName); //Session value
                        UserCommand.Parameters.AddWithValue("@EmpID", UserId);//Session value
                        UserCommand.Parameters.AddWithValue("@Designation", Designation);//Session value
                        UserCommand.Parameters.AddWithValue("@Status", RadioButtonListArticle.SelectedValue);
                        //UserCommand.Parameters.AddWithValue("@Updateby", UserName);
                        UserCon.Open();

                        int i = UserCommand.ExecuteNonQuery();
                        if (i < 0)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Article Details Update Successfully!')", true);
                            Response.Redirect("Article.aspx", true);
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Article Details not  Update Successfully!')", true);
                        }

                        Clear();
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
                finally { }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Article.aspx");

        }
    }
}