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
    public partial class NewGroup : System.Web.UI.Page
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
            chkboxfornewgroup.Checked = false;

        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {

                        UserCommand = new SqlCommand("SP_SaveGroup", UserCon);
                        UserCommand.Connection = UserCon;
                        UserCommand.CommandType = CommandType.StoredProcedure;
                        UserCommand.Parameters.AddWithValue("@Group_Name", txtGroupName.Text);
                        UserCommand.Parameters.AddWithValue("@Color", txtColor.Text);
                        UserCommand.Parameters.AddWithValue("@Shortdescription", txtshortDescribtion.Text);
                        UserCommand.Parameters.AddWithValue("@order", txtorder.Text);
                        UserCommand.Parameters.AddWithValue("@Disabled", chkboxfornewgroup.Checked);
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
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Group Save Successfully!')", true);

                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Group Already Available!')", true);
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
       

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        
    }
}