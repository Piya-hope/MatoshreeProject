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


using System.Text.RegularExpressions;

namespace MatoshreeProject
{
    public partial class Edit_Group : System.Web.UI.Page
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
        //string Contractid;
        string GroupID;
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

        #region " Public Functions "
        public void Clear()
        {
            txtGroupName.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtshortDescribtion.Text = string.Empty;
            txtorder.Text = string.Empty;

        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetGroupByID();
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

                        UserCommand = new SqlCommand("SP_UpdateGroup", UserCon);
                        UserCommand.Connection = UserCon;
                        UserCommand.CommandType = CommandType.StoredProcedure;
                        UserCommand.Parameters.AddWithValue("@Group_ID", lblGroupNameWGV.Text);
                        UserCommand.Parameters.AddWithValue("@Group_Name", txtGroupName.Text);
                        UserCommand.Parameters.AddWithValue("@Color", txtColor.Text);
                        UserCommand.Parameters.AddWithValue("@Shortdescription", txtshortDescribtion.Text);
                        UserCommand.Parameters.AddWithValue("@order", txtorder.Text);
                        UserCommand.Parameters.AddWithValue("@Disabled", chkboxfornewgroup.Checked);
                        UserCommand.Parameters.AddWithValue("@Created_by", UserName); //Session value
                        UserCommand.Parameters.AddWithValue("@EmpID", UserId);//Session value
                        UserCommand.Parameters.AddWithValue("@Designation", Designation);//Session value
                        UserCommand.Parameters.AddWithValue("@Status", RadioButtonListGroup.SelectedValue);
                        UserCon.Open();
                        
                       int i = UserCommand.ExecuteNonQuery();
                        if (i < 0)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Group Details Update Successfully!')", true);
                        Response.Redirect("Group.aspx", true);
                    }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Group Details not  Update Successfully!')", true);
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Group.aspx", true);

        }

        public void GetGroupByID()
        {
            try
            {
                String Status;
              
                String Disabled;

                GroupID = HttpUtility.UrlDecode(Request.QueryString["group"]);
                lblGroupNameWGV.Text = GroupID;

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {

                    UserCommand = new SqlCommand("SP_GetGroupByID", UserCon);
                    UserCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(UserCommand);

                    UserCommand.Parameters.AddWithValue("@Group_ID", lblGroupNameWGV.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                  

                 
                    if (dt.Rows.Count > 0)
                    {
                        txtGroupName.Text = dt.Rows[0]["Group_Name"].ToString();
                        txtColor.Text = dt.Rows[0]["Color"].ToString();
                        txtshortDescribtion.Text = dt.Rows[0]["Shortdescription"].ToString();
                        txtorder.Text = dt.Rows[0]["order"].ToString();

                        Status = dt.Rows[0]["Status"].ToString();
                        if (Status == "True")
                        {
                            RadioButtonListGroup.SelectedValue = "1";
                        }
                        else
                        {
                            RadioButtonListGroup.SelectedValue = "0";
                        }

                        Disabled = dt.Rows[0]["Disabled"].ToString();
                        if (Disabled == "True")
                        {
                            chkboxfornewgroup.Checked = true;
                        }
                        else
                        {
                            chkboxfornewgroup.Checked = false;
                          
                        }


                    }
                    else
                    {
                        Response.Redirect("Group.aspx",true);
                       
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}