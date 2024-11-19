
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
#endregion


namespace MatoshreeProject
{
    public partial class ProjectReport : System.Web.UI.Page
    {
        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result, CustID;

        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        int UserId;



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

        #region " Public Functions "
        public DataTable ViewProjectReport()
        {
            DataTable table1 = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewReportProjectDetails", con))
                {
                    ad.Fill(table1);
                    GridProjectReport.DataSource = table1;
                    GridProjectReport.DataBind();
                }
            }
            return table1;
        }

        public void ClearDepartment()
        {

            //txtDepartmentName.Text = string.Empty;
            //txtdesc.Text = string.Empty;



        }
        protected void bindProjectName()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetProjectName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlProjectName.DataSource = ds.Tables[0];
                    ddlProjectName.DataTextField = "ProjectName";
                    ddlProjectName.DataValueField = "ID";
                    ddlProjectName.DataBind();
                    ddlProjectName.Items.Insert(0, new ListItem("Select Project Name", "0"));
                }
            }
            catch (Exception ex)
            {
                SqlConnection DeviceCon = new SqlConnection(strconnect);
                string ErrorMessgage = ex.Message;
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();

            }



        }

        protected void btnViewRerort_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ProjectReports", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(ddlProjectName.SelectedValue));
                    cmd.Parameters.AddWithValue("@Cust_ID", Convert.ToInt32(ddlCustomer.SelectedValue));
                    cmd.Parameters.AddWithValue("@SearchProject", ddlProjectName.SelectedValue);
                    cmd.Parameters.AddWithValue("@SearchCustomer", ddlCustomer.SelectedValue);
                    cmd.Parameters.AddWithValue("@Start_Date", txtStartDate.Text);
                    cmd.Parameters.AddWithValue("@Deadline", txtEndDate.Text);
                    cmd.Parameters.AddWithValue("@StatusName", txtStatusNam.Text);

                    con.Open();

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable table2 = new DataTable();
                        ad.Fill(table2);
                        GridProjectReport.DataSource = table2;
                        GridProjectReport.DataBind();
                    }
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void btnExportReport_Click(object sender, EventArgs e)
        {

        }

     
        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int CustID = Convert.ToInt32(ddlCustomer.SelectedValue);
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetProjectNameByCustID", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustID", CustID);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlProjectName.DataSource = ds.Tables[0];
                    ddlProjectName.DataTextField = "ProjectName";
                    ddlProjectName.DataValueField = "ID";
                    ddlProjectName.DataBind();
                    ddlProjectName.Items.Insert(0, new ListItem("Select Project Name", "0"));
                }

            }
            catch (Exception ex)
            {
                using (SqlConnection DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();

                }

            }
            finally { }
        }

        protected void bindCustomerName()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetCustomerName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlCustomer.DataSource = ds.Tables[0];
                    ddlCustomer.DataTextField = "Cust_Name";
                    ddlCustomer.DataValueField = "Cust_ID";
                    ddlCustomer.DataBind();
                    ddlCustomer.Items.Insert(0, new ListItem("Select Customer Name", "0"));
                }
            }
            catch (Exception ex)
            {
                SqlConnection DeviceCon = new SqlConnection(strconnect);
                string ErrorMessgage = ex.Message;
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();

            }



        }
        //protected void bindInvoiceName()
        //{
        //    try
        //    {
        //        SqlConnection conn = new SqlConnection(strconnect);
        //        SqlCommand cmd = new SqlCommand("SP_GetInvoiceName", conn);
        //        cmd.Connection = conn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //        {
        //            DataSet ds = new DataSet();
        //            sda.Fill(ds);
        //            ddlInvoice.DataSource = ds.Tables[0];
        //            ddlInvoice.DataTextField = "InvoiceNo";
        //            ddlInvoice.DataValueField = "ID";
        //            ddlInvoice.DataBind();
        //            ddlInvoice.Items.Insert(0, new ListItem("Select Invoice Name", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SqlConnection DeviceCon = new SqlConnection(strconnect);
        //        string ErrorMessgage = ex.Message;
        //        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
        //        string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
        //        string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
        //        Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();

        //    }



        //}
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindCustomerName();
                bindProjectName();
                ViewProjectReport();
              // bindInvoiceName();
            }
        }
    }
}