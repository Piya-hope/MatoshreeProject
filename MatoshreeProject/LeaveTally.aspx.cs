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
using System.Runtime.InteropServices.ComTypes;
using Org.BouncyCastle.Utilities;
using ListItem = System.Web.UI.WebControls.ListItem;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Color = iTextSharp.text.BaseColor;

using System.Net.Mail;
using System.Net;
using iTextSharp.tool.xml.html;
using Font = iTextSharp.text.Font;
//using Microsoft.Office.Interop.Access;
using AjaxControlToolkit;

using System.Data.Common.CommandTrees.ExpressionBuilder;


#endregion


namespace MatoshreeProject
{
    public partial class LeaveTally : System.Web.UI.Page
    {
        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result;

        int UserId; int StaffId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        string DevEmail, DevPassword, DevPort, DevHost;


        //int FinalCount = 0;
        int FinalCount = 0;
        string previousStaffID = string.Empty;

        string UserEmpName, Password, EmailID1, Designation1;



        string Size, Initial, ReceiptFor, Cash, Bank, reminder, Leaveid;


        string Day = Convert.ToString(DateTime.Today.Day);



        string year = Convert.ToString(DateTime.Today.Year);





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

        public DataTable ViewLeaveTallyDetail()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewLeaveTallyDetails", con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridLeaveAnalysis.DataSource = table;
                GridLeaveAnalysis.DataBind();
                ViewState["LTData"] = table;
            }

            return table;
        }
        public DataTable ViewLeaveTallyDetailEmpID(int UserID)
        {

            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewLeaveTallyDetailsEmpID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Staff_ID", UserID);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridLeaveAnalysis.DataSource = table;
                GridLeaveAnalysis.DataBind();
                ViewState["LTData"] = table;
                
            }


            return table;


        }
        public void StaffOperationPermission()
        {
            try
            {
                UserId = Convert.ToInt32(Session["UserID"]);

                string View, Create, Edit, Delete, Globalview;
                //-------------Permission Modules----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand command = new SqlCommand("SP_ViewWebPagesPemissionByStaffID", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StaffID", UserId);
                    command.Parameters.AddWithValue("@SubModule", "CUSTOMERS");
                    DataTable dt = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter(command);
                    ad.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Globalview = dt.Rows[0]["GlobalView"].ToString();
                        View = dt.Rows[0]["View"].ToString();
                        Edit = dt.Rows[0]["Edit"].ToString();
                        Delete = dt.Rows[0]["Delete"].ToString();
                        Create = dt.Rows[0]["Create"].ToString();
                        if (Globalview == "True")
                        {
                            ViewLeaveTallyDetail();


                            if (Create == "True")
                            {
                                //addnew.Visible = true;
                                //btnNewCustomer.Visible = true;
                            }
                            else
                            {
                                //addnew.Visible = false;
                                //btnNewCustomer.Visible = false;
                            }

                            if (Edit == "True")
                            {

                                //    GridCustomer.Columns[8].Visible = true;
                            }
                            else
                            {

                                //GridCustomer.Columns[8].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                //GridCustomer.Columns[9].Visible = true;
                            }
                            else
                            {

                                //GridCustomer.Columns[9].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {

                            ViewLeaveTallyDetailEmpID(UserId);


                            if (Create == "True")
                            {
                                //addnew.Visible = true;
                                //btnNewCustomer.Visible = true;
                            }
                            else
                            {
                                //addnew.Visible = false;
                                //btnNewCustomer.Visible = false;
                            }

                            if (Edit == "True")
                            {

                                //GridCustomer.Columns[8].Visible = true;
                            }
                            else
                            {

                                //GridCustomer.Columns[8].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                //GridCustomer.Columns[9].Visible = true;
                            }
                            else
                            {

                                // GridCustomer.Columns[9].Visible = false;
                            }

                        }
                        else
                        {
                            Response.Redirect("~/permission.html", true);
                        }

                    }
                    else
                    {

                    }

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
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Save Successfully";
                    }
                    else
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }
        }

     

        public void GetShiftDetails(string Staffid)
        {
            try
            {
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetShiftDetailsByStaffID", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", Staffid);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    lblshiftstaffid.Text = dt.Rows[0]["Staff_ID"].ToString();
                    lblNameShift11.Text = dt.Rows[0]["ShiftName"].ToString();
                    lblShiftID.Text = dt.Rows[0]["ID"].ToString();
                    lblshiftHours.Text = dt.Rows[0]["Hours"].ToString();

                }
            }
            catch (Exception ex)
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", UserCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    UserCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Save Successfully";
                    }
                    else
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }
            finally
            {
            }
        }

        public void GetMarkDetails(string ReMark)
        {
            try
            {
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetLeaveMarksDetailsByMarkName", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MarkName", ReMark);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblLeabveMarkID.Text = dt.Rows[0]["ID"].ToString();
                    lblMarkName.Text = dt.Rows[0]["MarkName"].ToString();
                    lblMarkCount.Text = dt.Rows[0]["MarkCount"].ToString();
                }
            }
            catch (Exception ex)
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", UserCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    UserCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Save Successfully";
                    }
                    else
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }
            finally
            {
            }
        }
        #endregion

        #region " Event "
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["LoginType"] != null)
                {
                    RoleType = Session["LoginType"].ToString();
                    Designation = Session["Role"].ToString();

                    if (Session["LoginType"].ToString() == "Administrator")

                    {
                        UserId = Convert.ToInt32(Session["UserID"]);
                        UserName = Session["UserName"].ToString();
                        EmailID = Session["EmailID"].ToString();
                        Designation = Session["Role"].ToString();
                        DeptID = Session["DeptID"].ToString();

                        if (!IsPostBack)
                        {
                            ViewLeaveTallyDetail();
                        }
                    }
                    else if (RoleType == Designation)
                    {
                        UserId = Convert.ToInt32(Session["UserID"]);
                        UserName = Session["UserName"].ToString();
                        EmailID = Session["EmailID"].ToString();
                        Designation = Session["Role"].ToString();
                        Permission = Session["Permission"].ToString();
                        DeptID = Session["DeptID"].ToString();

                        if (Permission == "True")
                        {
                            if (!IsPostBack)
                            {                             
                                StaffOperationPermission();
                            }
                        }
                        else
                        {
                            Response.Redirect("~/permission.html", true);
                        }

                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx", false);
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
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Save Successfully";
                    }
                    else
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {

                    foreach (GridViewRow gvrow in GridLeaveAnalysis.Rows)
                    {
                        var checkbox = gvrow.FindControl("chkItem") as System.Web.UI.WebControls.CheckBox;
                        if (checkbox.Checked)
                        {

                            System.Web.UI.WebControls.Label lblRemark = (System.Web.UI.WebControls.Label)gvrow.FindControl("lblRemark");
                            System.Web.UI.WebControls.Label lblStaffID = (System.Web.UI.WebControls.Label)gvrow.FindControl("lblStaffID");
                            System.Web.UI.WebControls.Label lblInTime1 = (System.Web.UI.WebControls.Label)gvrow.FindControl("lblInTime1");


                            SqlCommand cmd1 = new SqlCommand("SP_UpdatePresesnty", con1);
                            cmd1.Connection = con1;
                            cmd1.CommandType = CommandType.StoredProcedure;
                            DateTime parsedDateTime = DateTime.Parse(lblInTime1.Text);
                            cmd1.Parameters.AddWithValue("@Remark", lblRemark.Text);

                            cmd1.Parameters.AddWithValue("@Staffid", lblStaffID.Text);

                            //cmd1.Parameters.AddWithValue("@Datetime", lblInTime1.Text);

                            cmd1.Parameters.AddWithValue("@Datetime", parsedDateTime);

                            con1.Open();
                            int Result1 = cmd1.ExecuteNonQuery();
                            if (Result1 < 0)
                            {
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Leave Presenty Tally Done";
                                //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses  Item Approval Added  Successfully!')", true);
                                //    //ViewFileExpensesDetails();
                            }
                            else
                            {
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Leave Presenty Tally Not Happen";
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses Item Approval Not Added  Successfully!')", true);
                            }


                            con1.Close();


                        }
                    }
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
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Save Successfully";
                    }
                    else
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in GridLeaveAnalysis.Rows)
                {
                    System.Web.UI.WebControls.CheckBox chckITem = (System.Web.UI.WebControls.CheckBox)row.FindControl("chkItem");


                    if (chckITem != null)
                    {
                        chckITem.Text = string.Empty;
                    }

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
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Save Successfully";
                    }
                    else
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }

        }
        protected void GridLeaveAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    System.Web.UI.WebControls.Label lblStaffID = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblStaffID");
                    System.Web.UI.WebControls.Label lblInTime1 = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblInTime1");
                    System.Web.UI.WebControls.Label lblOutTime1 = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblOutTime1");
                    System.Web.UI.WebControls.Label lblRemark = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblRemark");
                    System.Web.UI.WebControls.Label lblTotalHours = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblTotalHours");
                    System.Web.UI.WebControls.Label lblLateTime1 = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblLateTime1");
                    System.Web.UI.WebControls.Label lblLeaveType1 = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblLeaveType1");
                    string staffID = lblStaffID.Text;
                    string LeaveType = lblLeaveType1.Text;
                    var dataItem = e.Row.DataItem;
                    lblTotalHours.Text = DataBinder.Eval(dataItem, "TotalHRS").ToString();

                    GetShiftDetails(staffID);
                    int TotalHours = Convert.ToInt32(lblTotalHours.Text);
                    int shiftHours = Convert.ToInt32(lblshiftHours.Text);
                    int lCount = Convert.ToInt32(lblLateTime1.Text);
                    int sID = Convert.ToInt32(staffID);

                    //previousStaffID = staffID;
                    if (staffID != previousStaffID)
                    {
                        FinalCount = 0;
                        previousStaffID = staffID;
                    }
                    string intime = lblInTime1.Text;

                    DateTime Intime = DateTime.Parse(intime);
                    TimeSpan INtimeString = Intime.TimeOfDay;
                    string OutTime = lblOutTime1.Text;
                    DateTime Outime = DateTime.Parse(OutTime);
                    TimeSpan OuttimeString = Outime.TimeOfDay;

                    string timeString = "09:30:00";
                    TimeSpan timeEarly = TimeSpan.Parse(timeString);
                    string timeString1 = "15:00:00";

                    TimeSpan timeMid = TimeSpan.Parse(timeString1);
                    string timeString2 = "18:00:00";

                    TimeSpan timeAfter = TimeSpan.Parse(timeString2);

                    string Remark;



                    if (TotalHours == shiftHours)
                    {
                        Remark = "Regulartime";
                        lblRemark.Text = Remark;
                    }
                    else if (TotalHours > shiftHours)
                    {
                        Remark = "Overtime";

                        lblRemark.Text = Remark;
                    }


                    else
                    {

                        Remark = "Late";
                        lblRemark.Text = Remark;
                        GetMarkDetails(Remark);
                        if (TotalHours < 0)
                        {

                            lblRemark.Text = LeaveType;
                        }

                        if (lCount == 1)
                        {
                            FinalCount = FinalCount + lCount;
                        }
                        if (FinalCount >= 4)
                        {

                            if (INtimeString > timeEarly)
                            {
                                Remark = "HalfDay";
                                lblRemark.Text = Remark;
                            }
                            else if (OuttimeString < timeMid)
                            {
                                Remark = "HalfDay";
                                lblRemark.Text = Remark;
                            }
                            else if ((OuttimeString < timeMid) && (INtimeString > timeEarly))
                            {
                                Remark = "HalfDay";
                                lblRemark.Text = Remark;
                            }
                            else if ((OuttimeString < timeAfter) && (TotalHours < shiftHours))
                            {
                                Remark = "Early Leave";
                                lblRemark.Text = Remark;
                            }
                        }
                    }
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
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Save Successfully";
                    }
                    else
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }

        }

        protected void chkAll_CheckedChanged1(object sender, EventArgs e)
        {
            try
            {
                System.Web.UI.WebControls.CheckBox ChkBoxHeader = (System.Web.UI.WebControls.CheckBox)GridLeaveAnalysis.HeaderRow.FindControl("chkAll");
                foreach (GridViewRow row in GridLeaveAnalysis.Rows)
                {
                    System.Web.UI.WebControls.CheckBox ChkBoxRows = (System.Web.UI.WebControls.CheckBox)row.FindControl("chkItem");


                    if (ChkBoxHeader.Checked == true)
                    {
                        ChkBoxRows.Checked = true;
                    }
                    else
                    {
                        ChkBoxRows.Checked = false;
                    }
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
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Save Successfully";
                    }
                    else
                    {
                        //lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }
        }


        #endregion

    }
}