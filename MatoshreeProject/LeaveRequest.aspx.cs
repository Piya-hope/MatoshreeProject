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
using System.Web.UI.DataVisualization.Charting;
using System.Web.Services;
using System.Xml.Linq;

#endregion

namespace MatoshreeProject
{
    public partial class LeaveRequest : System.Web.UI.Page
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
        public DataTable ViewLeaveRequestDetail()
        {

            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewLeaveManagementDetails", con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridLeaveRequest.DataSource = table;
                GridLeaveRequest.DataBind();
                ViewState["LRData"] = table;
            }

            return table;
        }

        public DataTable ViewLeaveRequestDetailEmpID(int UserID)
        {

            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewLeaveRequestDetailsEmpID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Staff_ID", UserID);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridLeaveRequest.DataSource = table;
                GridLeaveRequest.DataBind();
                ViewState["LRData"] = table;
                return table;
            }


        }
        public DataTable ViewFileRequestDetails()
        {

            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                SqlCommand com = new SqlCommand("SP_ViewFileLeaveRequestDetails", con1);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@UniqueNo", lblInitialNumber.Text);
                // com.Parameters.AddWithValue("@BelongTo", "Office Expenses");
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridLeaveRequestFile.DataSource = dt;
                    GridLeaveRequestFile.DataBind();
                    GridLeaveRequestFile.Visible = true;

                    foreach (GridViewRow gridviedrow in GridLeaveRequestFile.Rows)
                    {

                        LinkButton btnDownload = (LinkButton)gridviedrow.FindControl("btnDownload");

                        btnDownload.Visible = true;

                    }
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridLeaveRequestFile.DataSource = dt;
                    GridLeaveRequestFile.DataBind();
                    int totalcolums = GridLeaveRequestFile.Rows[0].Cells.Count;
                    GridLeaveRequestFile.Visible = false;
                }
            }

            return table;



        }

        //public DataTable ViewFileRequestDetails(string InitialNumber)
        //{

        //        DataTable table = new DataTable();
        //        using (SqlConnection con1 = new SqlConnection(strconnect))
        //        {
        //            SqlCommand com = new SqlCommand("SP_ViewFileLeaveRequestDetails", con1);
        //            com.CommandType = CommandType.StoredProcedure;

        //            com.Parameters.AddWithValue("@UniqueNo", lblInitialNumber.Text);
        //            // com.Parameters.AddWithValue("@BelongTo", "Office Expenses");
        //            SqlDataAdapter da = new SqlDataAdapter(com);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            if (dt.Rows.Count > 0)
        //            {
        //                GridLeaveRequestFile.DataSource = dt;
        //                GridLeaveRequestFile.DataBind();
        //                GridLeaveRequestFile.Visible = true;

        //                foreach (GridViewRow gridviedrow in GridLeaveRequestFile.Rows)
        //                {

        //                    LinkButton btnDownload = (LinkButton)gridviedrow.FindControl("btnDownload");

        //                    btnDownload.Visible = true;

        //                }
        //            }
        //            else
        //            {
        //                dt.Rows.Add(dt.NewRow());
        //                GridLeaveRequestFile.DataSource = dt;
        //                GridLeaveRequestFile.DataBind();
        //                int totalcolums = GridLeaveRequestFile.Rows[0].Cells.Count;
        //                GridLeaveRequestFile.Visible = false;
        //            }
        //        }

        //    return table;



        //}

        public void GetCompanyAddress()
        {
            try
            {

                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetCompanyAddress", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lbladdCompany11.Text = dt.Rows[0]["Company_Name"].ToString() + ",";
                    lbladdress11.Text = dt.Rows[0]["Address"].ToString();
                    lblcompanyaddCity1.Text = dt.Rows[0]["City"].ToString() + ",";
                    lblcompanyaddDistrict1.Text = dt.Rows[0]["District"].ToString() + ",";
                    lblcompanyaddState1.Text = dt.Rows[0]["State"].ToString() + ",";
                    lblcompanyaddCountry1.Text = "India" + ",";
                    lblcompanyaddZIPCode11.Text = dt.Rows[0]["Zip_Code"].ToString() + ",";
                    lblphoneNo1.Text = dt.Rows[0]["Phone"].ToString() + ".";
                    lblVatNo1.Text = dt.Rows[0]["VAT_Number"].ToString() + ",";
                    lblGSTNo1A.Text = dt.Rows[0]["GST_NO"].ToString() + ",";
                    Image1.ImageUrl = dt.Rows[0]["Company_Logo"].ToString();
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

        private string generateOrderNo(string code, long id)
        {
            string oID = code;
            string space = "-";
            oID += space + id.ToString("00000");

            return oID;
        }
        public string GETReceiptINITIAL()
        {

            SqlConnection conn = new SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand("SP_GeReceriptInitial", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReceiptFor", "LeaveRequest");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ReceiptFor = dt.Rows[0]["ReceiptFor"].ToString();
                Initial = dt.Rows[0]["Initial"].ToString();
                Size = dt.Rows[0]["size"].ToString();
                lblInitialNumber.Text = year + "-" + Day + ":";
                Initial = lblInitialNumber.Text + Initial;

            }
            return generateOrderNo(Initial, long.Parse(Size));
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
                            ViewLeaveRequestDetail();

                            GetCompanyAddress();

                            if (Create == "True")
                            {

                                btnLeaveRequest.Visible = true;
                            }
                            else
                            {

                                btnLeaveRequest.Visible = false;
                            }

                            if (Edit == "True")
                            {

                                GridLeaveRequest.Columns[8].Visible = true;
                            }
                            else
                            {

                                GridLeaveRequest.Columns[8].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                GridLeaveRequest.Columns[9].Visible = true;
                            }
                            else
                            {

                                GridLeaveRequest.Columns[9].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {
                            ViewLeaveRequestDetailEmpID(UserId);

                            GetCompanyAddress();

                            if (Create == "True")
                            {

                                btnLeaveRequest.Visible = true;
                            }
                            else
                            {

                                btnLeaveRequest.Visible = false;
                            }

                            if (Edit == "True")
                            {

                                GridLeaveRequest.Columns[8].Visible = true;
                            }
                            else
                            {

                                GridLeaveRequest.Columns[8].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                GridLeaveRequest.Columns[9].Visible = true;
                            }
                            else
                            {

                                GridLeaveRequest.Columns[9].Visible = false;
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
        public void GetMessageFromModules()
        {
            try
            {
                string MSGdata = HttpUtility.UrlDecode(Request.QueryString["svd1"]);
                string EdidDATA = HttpUtility.UrlDecode(Request.QueryString["edit1"]);
                if (MSGdata == "fgsave123q" && EdidDATA == null)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Leave Request Details Save Successfully";
                }
                //else if (EdidDATA == "xcvfedit" && MSGdata == null)
                //{
                //    Toasteralert.Visible = true;
                //    lblMessage.Text = "Leave Management Details Edit Successfully";
                //}
                else if (MSGdata == null && MSGdata == null)
                {
                    Toasteralert.Visible = false;
                    //load customer page
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

        public void Leavecount()
        {
            try
            {
                //  -------------totalLeaveCount----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetTotalLeaveCount", con);
                    command.CommandType = CommandType.StoredProcedure;
                    int totalLeaveCount = (int)command.ExecuteScalar();

                    lblTotalLeaveCount.Text = Convert.ToString(totalLeaveCount);
                }


                //-------------SickLeaveCount----------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetTotalSickLeaveCount", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    int SickLeaveCount = (int)command.ExecuteScalar();

                    lblSickLeaveCount.Text = Convert.ToString(SickLeaveCount);
                }

                ////-------------CasualLeaveCount----------------------//

                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetTotalCasualLeaveCount", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    int CasualLeaveCount = (int)command.ExecuteScalar();

                    lblCasualLeaveCount.Text = Convert.ToString(CasualLeaveCount);
                }
                //-------------YourLeaveCount----------------------//


                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetTotalLeaveDayCount", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    command.Parameters.AddWithValue("@Staffid", Convert.ToInt32(UserId));
                    int TotalLeaveDayCount = (int)command.ExecuteScalar();

                    lblYourLeaveCount.Text = Convert.ToString(TotalLeaveDayCount);

                    int totalLeaveCount1 = Convert.ToInt32(lblTotalLeaveCount.Text);
                    int YourLeaveCount = Convert.ToInt32(lblYourLeaveCount.Text);

                    //-------------RemainingLeaveCount----------------------//
                    int RemainingLeaveCount = totalLeaveCount1 - YourLeaveCount;
                    lblRemainingLeaveCount.Text = RemainingLeaveCount.ToString();

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



        public void LeavecountEmpId()
        {
            try
            {
                //  -------------totalLeaveCount----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetTotalLeaveCountEmpID", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserId);
                    int totalLeaveCount = (int)command.ExecuteScalar();

                    lblTotalLeaveCount.Text = Convert.ToString(totalLeaveCount);
                }

                //-------------SickLeaveCount----------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetTotalSickLeaveCountEmpId", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserId);
                    int SickLeaveCount = (int)command.ExecuteScalar();

                    lblSickLeaveCount.Text = Convert.ToString(SickLeaveCount);
                }

                ////-------------CasualLeaveCount----------------------//

                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetTotalCasualLeaveCountEmpId", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserId);
                    int CasualLeaveCount = (int)command.ExecuteScalar();

                    lblCasualLeaveCount.Text = Convert.ToString(CasualLeaveCount);
                }
                //-------------YourLeaveCount----------------------//


                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetTotalLeaveDayCountEmpId", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Staffid", Convert.ToInt32(UserId));
                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    int TotalLeaveDayCount = (int)command.ExecuteScalar();

                    lblYourLeaveCount.Text = Convert.ToString(TotalLeaveDayCount);

                    int totalLeaveCount1 = Convert.ToInt32(lblTotalLeaveCount.Text);
                    int YourLeaveCount = Convert.ToInt32(lblYourLeaveCount.Text);

                    //-------------RemainingLeaveCount----------------------//
                    int RemainingLeaveCount = totalLeaveCount1 - YourLeaveCount;
                    lblRemainingLeaveCount.Text = RemainingLeaveCount.ToString();

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

        protected void bindLeaveType()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetLeaveType", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlLeaveType.DataSource = ds.Tables[0];
                    ddlLeaveType.DataTextField = "LeaveType";
                    ddlLeaveType.DataValueField = "ID";
                    ddlLeaveType.DataBind();
                    ddlLeaveType.Items.Insert(0, new ListItem("Select Leave Type", "0"));
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

        protected void bindDepartment()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetDeptName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlDepartment.DataSource = ds.Tables[0];
                    ddlDepartment.DataTextField = "Dept_Name";
                    ddlDepartment.DataValueField = "Dept_ID";
                    ddlDepartment.DataBind();
                    ddlDepartment.Items.Insert(0, new ListItem("Select Department", "0"));
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



        protected void GetStaffdetails()
        {
            try
            {
                UserId = Convert.ToInt32(Session["UserID"]);
                lblstaffid.Text = UserId.ToString();
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetStaffByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@Staff_ID", UserId);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        txtStaffName.Text = dt.Rows[0]["Full_Name"].ToString();
                        txtDesignation.Text = dt.Rows[0]["Role"].ToString();
                        txtPhone.Text = dt.Rows[0]["PhoneNumber"].ToString();
                        ddlDepartment.SelectedItem.Text = dt.Rows[0]["Dept_Name"].ToString();
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


        public void Clear()
        {

            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            txtReason.Text = string.Empty;
            ddlDepartment.SelectedIndex = 0;
            ddlLeaveType.SelectedIndex = 0;
            chkFullDay.Checked = false;
            chkHalfDay.Checked = false;
            txtno.Text = string.Empty;
        }



        public void GETCredentials()
        {
            //----Domail ID Password----//
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmailCreadential", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DevEmail = Convert.ToString(dt.Rows[0]["UserEmail_ID"].ToString());
                    DevPassword = Convert.ToString(dt.Rows[0]["Password"].ToString());
                    DevHost = Convert.ToString(dt.Rows[0]["Host"].ToString());
                    DevPort = Convert.ToString(dt.Rows[0]["PortNumber"].ToString());
                }
                con.Close();
            }
        }
        public void GETStaffEmail(string EmpNAME)
        {
            //----Domail ID Password----//
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmailbyStaffName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffName", EmpNAME);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    lblStaffEmail.Text = Convert.ToString(dt.Rows[0]["Email"].ToString());
                    lblStaffDesignation.Text = Convert.ToString(dt.Rows[0]["Role"].ToString());

                }
                con.Close();

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
                            Leavecount();
                            //  LeavecountEmpId();
                            string ReceiptNumner = GETReceiptINITIAL();
                            lblInitialNumber.Text = ReceiptNumner;
                            // GetLeaveFilebyid();
                            ViewLeaveRequestDetail();
                            //ViewFileRequestDetails();
                            GetCompanyAddress();
                            ViewLeaveRequestDetail();
                            bindDepartment();
                            bindLeaveType();
                            GetStaffdetails();

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
                                Leavecount();
                                LeavecountEmpId();
                                string ReceiptNumner = GETReceiptINITIAL();
                                lblInitialNumber.Text = ReceiptNumner;
                                //  ViewFileRequestDetails();
                                //GetLeaveFilebyid();
                                StaffOperationPermission();
                                GetMessageFromModules();
                                bindDepartment();
                                bindLeaveType();
                                GetStaffdetails();
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


        private static void DrawLine(iTextSharp.text.pdf.PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(Color.BLACK);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.Colspan = 4;
            cell.BorderColor = Color.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 3f;
            cell.PaddingTop = 0f;
            return cell;
        }


        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = Color.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 4f;
            cell.PaddingTop = 2f;
            return cell;
        }

        protected void linkbtnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    int _totalColumns = 9;//gridvie clumns
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));

                    Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(9);//change
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;

                    iTextSharp.text.Document _document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 0f, 0f, 0f, 0f);
                    _document.SetPageSize(iTextSharp.text.PageSize.A4);
                    _document.SetMargins(20f, 20f, 20f, 20f);
                    _pdfPTable.WidthPercentage = 500;
                    _pdfPTable.TotalWidth = 500f;
                    _pdfPTable.LockedWidth = true;
                    _pdfPTable.HorizontalAlignment = Element.ALIGN_CENTER;
                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

                    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                    {
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(_document, memoryStream);
                        //Phrase phrase = null;
                        //PdfPCell cell = null;
                        //PdfPTable table = null;
                        //Color color = new Color();

                        _document.Open();
                        _pdfPTable.SetWidths(new float[] { 3f, 9f, 9f, 9f, 9f, 9f, 9f, 9f, 9f });//column width in doc       
                                                                                                 //----Header PDF--------------------------//
                                                                                                 //Company Logo
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 3;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPTable.AddCell(cell);

                        //...!..image logo..// 
                        Phrase phrase = null;
                        phrase = new Phrase();
                        phrase.Add(new Chunk(lbladdCompany11.Text + "\n", FontFactory.GetFont("Arial", 14, Font.BOLD, Color.BLACK)));
                        phrase.Add(new Chunk(lbladdress11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCity1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddDistrict1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddState1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        _pdfPCell = new PdfPCell(phrase);
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.BorderColor = Color.WHITE;
                        _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.PaddingBottom = 1f;
                        _pdfPCell.PaddingTop = 0f;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = Color.BLACK;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("LeaveManagmentDetails_", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //-------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 4;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();


                        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*-------------------------------------", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = ViewLeaveRequestDetail();
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Name", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Department", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StartDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("EndDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("LeaveType", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Reason", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ApprovalStatus", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Remark", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);



                        _pdfPTable.CompleteRow();
                        #endregion


                        //DataRow newRow = dtExport.NewRow();

                        #region "Table Body"
                        _fontStyle = FontFactory.GetFont("Tahoma", 10f, 0);
                        int serialnumber = 1;

                        foreach (DataRow row in _Vhrlist.Rows)//Stored columns name
                        {
                            _pdfPCell = new PdfPCell(new Phrase(serialnumber++.ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Name"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Department"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["StartDate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["EndDate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["LeaveType"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Reason"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["ApprovalStatus"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["RejectedReason"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);



                        }
                        #endregion

                        #region "Table Footer"
                        String text = "Page " + writer.PageNumber + " of ";
                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        PdfContentByte cb = writer.DirectContent;
                        PdfTemplate footerTemplate = cb.CreateTemplate(40, 40);

                        //Move the pointer and draw line to separate footer section from rest of page  
                        cb.MoveTo(40, _document.PageSize.GetBottom(40));
                        cb.LineTo(_document.PageSize.Width - 40, _document.PageSize.GetBottom(40));
                        cb.Stroke();

                        cb.BeginText();
                        cb.SetFontAndSize(bf, 9);
                        cb.SetTextMatrix(_document.PageSize.GetRight(100), _document.PageSize.GetBottom(30));
                        cb.ShowText(text);
                        cb.EndText();
                        float len = bf.GetWidthPoint(text, 9);
                        cb.AddTemplate(footerTemplate, _document.PageSize.GetRight(100) + len, _document.PageSize.GetBottom(30));

                        footerTemplate.BeginText();
                        footerTemplate.SetFontAndSize(bf, 9);
                        footerTemplate.SetTextMatrix(0, 0);
                        footerTemplate.ShowText((writer.PageNumber - 1).ToString());
                        footerTemplate.EndText();

                        #endregion

                        //-------------------- PDF Generation------------------------------------//
                        _pdfPTable.HeaderRows = 1; //header method
                        _document.Add(_pdfPTable);

                        _document.Close();
                        byte[] bytes = memoryStream.ToArray();
                        DateTime dTime = DateTime.Now;
                        string PDFFileName = string.Format("LeaveRequestDetails_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=" + PDFFileName);
                        Response.Buffer = true;
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.BinaryWrite(bytes);
                        Response.End();

                    }
                }
                else if (RoleType == Designation)
                {
                    int _totalColumns = 9;//gridvie clumns
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));

                    Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(9);//change
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;

                    iTextSharp.text.Document _document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 0f, 0f, 0f, 0f);
                    _document.SetPageSize(iTextSharp.text.PageSize.A4);
                    _document.SetMargins(20f, 20f, 20f, 20f);
                    _pdfPTable.WidthPercentage = 500;
                    _pdfPTable.TotalWidth = 500f;
                    _pdfPTable.LockedWidth = true;
                    _pdfPTable.HorizontalAlignment = Element.ALIGN_CENTER;
                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

                    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                    {
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(_document, memoryStream);
                        //Phrase phrase = null;
                        //PdfPCell cell = null;
                        //PdfPTable table = null;
                        //Color color = new Color();

                        _document.Open();
                        _pdfPTable.SetWidths(new float[] { 3f, 9f, 9f, 9f, 9f, 9f, 9f, 9f, 9f });//column width in doc       
                                                                                                 //----Header PDF--------------------------//
                                                                                                 //Company Logo
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 3;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPTable.AddCell(cell);

                        //...!..image logo..// 
                        Phrase phrase = null;
                        phrase = new Phrase();
                        phrase.Add(new Chunk(lbladdCompany11.Text + "\n", FontFactory.GetFont("Arial", 14, Font.BOLD, Color.BLACK)));
                        phrase.Add(new Chunk(lbladdress11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCity1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddDistrict1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddState1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                        _pdfPCell = new PdfPCell(phrase);
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.BorderColor = Color.WHITE;
                        _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.PaddingBottom = 1f;
                        _pdfPCell.PaddingTop = 0f;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = Color.BLACK;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("LeaveManagmentDetails_", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //-------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 4;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();


                        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*-------------------------------------", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = (DataTable)ViewState["LRData"];
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Name", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Department", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StartDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("EndDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("LeaveType", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Reason", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ApprovalStatus", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Remark", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);



                        _pdfPTable.CompleteRow();
                        #endregion


                        //DataRow newRow = dtExport.NewRow();

                        #region "Table Body"
                        _fontStyle = FontFactory.GetFont("Tahoma", 10f, 0);
                        int serialnumber = 1;

                        foreach (DataRow row in _Vhrlist.Rows)//Stored columns name
                        {
                            _pdfPCell = new PdfPCell(new Phrase(serialnumber++.ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Name"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Department"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["StartDate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["EndDate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["LeaveType"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Reason"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["ApprovalStatus"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["RejectedReason"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);



                        }
                        #endregion

                        #region "Table Footer"
                        String text = "Page " + writer.PageNumber + " of ";
                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        PdfContentByte cb = writer.DirectContent;
                        PdfTemplate footerTemplate = cb.CreateTemplate(40, 40);

                        //Move the pointer and draw line to separate footer section from rest of page  
                        cb.MoveTo(40, _document.PageSize.GetBottom(40));
                        cb.LineTo(_document.PageSize.Width - 40, _document.PageSize.GetBottom(40));
                        cb.Stroke();

                        cb.BeginText();
                        cb.SetFontAndSize(bf, 9);
                        cb.SetTextMatrix(_document.PageSize.GetRight(100), _document.PageSize.GetBottom(30));
                        cb.ShowText(text);
                        cb.EndText();
                        float len = bf.GetWidthPoint(text, 9);
                        cb.AddTemplate(footerTemplate, _document.PageSize.GetRight(100) + len, _document.PageSize.GetBottom(30));

                        footerTemplate.BeginText();
                        footerTemplate.SetFontAndSize(bf, 9);
                        footerTemplate.SetTextMatrix(0, 0);
                        footerTemplate.ShowText((writer.PageNumber - 1).ToString());
                        footerTemplate.EndText();

                        #endregion

                        //-------------------- PDF Generation------------------------------------//
                        _pdfPTable.HeaderRows = 1; //header method
                        _document.Add(_pdfPTable);

                        _document.Close();
                        byte[] bytes = memoryStream.ToArray();
                        DateTime dTime = DateTime.Now;
                        string PDFFileName = string.Format("LeaveRequestDetails_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=" + PDFFileName);
                        Response.Buffer = true;
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.BinaryWrite(bytes);
                        Response.End();

                    }
                }
                else
                {
                    Response.Redirect("~/Expired.html", true);
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

        protected void lnkbtnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {

                    DataTable dt = ViewLeaveRequestDetail();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "LeaveRequest_Details" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));

                        Response.Charset = " ";

                        // Create a new DataTable with only the desired columns
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("Staff Name");
                        dtExport.Columns.Add("Department");
                        dtExport.Columns.Add("Start Date");
                        dtExport.Columns.Add("End Date");
                        dtExport.Columns.Add("Leave Type");
                        dtExport.Columns.Add("Reason");
                        dtExport.Columns.Add("Approval Status");
                        dtExport.Columns.Add("Remark");


                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["ID"];
                            newRow["Staff Name"] = row["Name"];
                            newRow["Department"] = row["Department"];
                            newRow["Start Date"] = row["StartDate"];
                            newRow["End Date"] = row["EndDate"];
                            newRow["Leave Type"] = row["LeaveType"];
                            newRow["Reason"] = row["Reason"];
                            newRow["Approval Status"] = row["ApprovalStatus"];
                            newRow["Remark"] = row["RejectedReason"];

                            dtExport.Rows.Add(newRow);
                        }

                        StringWriter sw = new StringWriter();
                        HtmlTextWriter htw = new HtmlTextWriter(sw);

                        // Create a GridView to help render the data
                        GridView gridView = new GridView();
                        gridView.DataSource = dtExport;
                        gridView.DataBind();

                        gridView.RenderControl(htw);
                        Response.Write(sw.ToString());
                        Response.End();
                    }
                }
                else if (RoleType == Designation)
                {
                    DataTable dt = (DataTable)ViewState["LRData"];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "LeaveRequest_Details " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));

                        Response.Charset = " ";

                        // Create a new DataTable with only the desired columns
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("Staff Name");
                        dtExport.Columns.Add("Department");
                        dtExport.Columns.Add("Start Date");
                        dtExport.Columns.Add("End Date");
                        dtExport.Columns.Add("Leave Type");
                        dtExport.Columns.Add("Reason");
                        dtExport.Columns.Add("Approval Status");
                        dtExport.Columns.Add("Remark");

                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["ID"];
                            newRow["Staff Name"] = row["Name"];
                            newRow["Department"] = row["Department"];
                            newRow["Start Date"] = row["StartDate"];
                            newRow["End Date"] = row["EndDate"];
                            newRow["Leave Type"] = row["LeaveType"];
                            newRow["Reason"] = row["Reason"];
                            newRow["Approval Status"] = row["ApprovalStatus"];
                            newRow["Remark"] = row["RejectedReason"];


                            dtExport.Rows.Add(newRow);
                        }

                        StringWriter sw = new StringWriter();
                        HtmlTextWriter htw = new HtmlTextWriter(sw);

                        // Create a GridView to help render the data
                        GridView gridView = new GridView();
                        gridView.DataSource = dtExport;
                        gridView.DataBind();

                        gridView.RenderControl(htw);
                        Response.Write(sw.ToString());
                        Response.End();
                    }
                }
                else
                {
                    Response.Redirect("~/Expired.html", true);
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
            finally { }
        }

        protected void BTN_Visibility_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    DataTable table = new DataTable();
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_ViewLeaveManagementDetailsVisibility", con);
                        cmd.CommandTimeout = 600;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(table);
                        GridLeaveRequest.DataSource = table;
                        GridLeaveRequest.DataBind();
                        ViewState["LRData"] = table;
                    }
                }
                else if (RoleType == Designation)
                {
                    StaffOperationPermission();
                }
                else
                {
                    Response.Redirect("~/Expired.html", true);
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

        protected void Btn_Reload_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    ViewLeaveRequestDetail();
                }
                else if (RoleType == Designation)
                {
                    StaffOperationPermission();
                }
                else
                {
                    Response.Redirect("~/Expired.html", true);
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
        protected void GridLeaveRequest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridLeaveRequest.Rows)
                {
                    // string  Status = Convert.ToString(e.Row.Cells[8].Text);
                    //
                    System.Web.UI.WebControls.Label lblID1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblID1");
                    System.Web.UI.WebControls.Label lblStaffName1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblStaffName1");
                    System.Web.UI.WebControls.Label lblDepartment1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblDepartment1");
                    System.Web.UI.WebControls.Label lblStartDate1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblStartDate1");
                    System.Web.UI.WebControls.Label lblEndDate1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblEndDate1");
                    System.Web.UI.WebControls.Label lblLeaveType1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblLeaveType1");
                    System.Web.UI.WebControls.Label lblReason1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblReason1");
                    System.Web.UI.WebControls.Label lblApprovalStatus1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblApprovalStatus1");
                    System.Web.UI.WebControls.Label lblRejectedReason1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblRejectedReason1");
                    // System.Web.UI.WebControls.Label lblUniqueNo1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblUniqueNo1");


                    LinkButton lnkbtnresult = (LinkButton)e.Row.FindControl("btnfileAttachment");
                    string status = ((System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblStatus1")).Text;
                    if (status == "True")
                    {

                        lblID1.ForeColor = System.Drawing.Color.Blue;

                        lblStaffName1.ForeColor = System.Drawing.Color.Blue;
                        lblDepartment1.ForeColor = System.Drawing.Color.Black;
                        lblStartDate1.ForeColor = System.Drawing.Color.Black;
                        lblEndDate1.ForeColor = System.Drawing.Color.Black;
                        lblLeaveType1.ForeColor = System.Drawing.Color.Blue;
                        lblReason1.ForeColor = System.Drawing.Color.Black;
                        lblApprovalStatus1.ForeColor = System.Drawing.Color.Blue;
                        lblRejectedReason1.ForeColor = System.Drawing.Color.Black;

                    }
                    else
                    {


                        lblID1.ForeColor = System.Drawing.Color.Red;
                        lblStaffName1.ForeColor = System.Drawing.Color.Red;
                        lblDepartment1.ForeColor = System.Drawing.Color.Red;
                        lblStartDate1.ForeColor = System.Drawing.Color.Red;
                        lblEndDate1.ForeColor = System.Drawing.Color.Red;
                        lblLeaveType1.ForeColor = System.Drawing.Color.Red;
                        lblReason1.ForeColor = System.Drawing.Color.Red;
                        lblApprovalStatus1.ForeColor = System.Drawing.Color.Red;
                        lblRejectedReason1.ForeColor = System.Drawing.Color.Red;

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

        protected void chkFullDay_CheckedChanged(object sender, EventArgs e)
        {
            bool sttus = chkFullDay.Checked;
            if (sttus == true)
            {
                txtno.Visible = true;
            }
            else
            {
                txtno.Visible = false;
            }

        }


        //-----------------------------------------------------------------------------------------------------//
        // Add leave request
        //-----------------------------------------------------------------------------------------------------//

        protected void btnSaveLM_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        double duration = 0.0;

                        if (chkHalfDay.Checked)
                        {
                            duration += 0.5;
                        }

                        if (chkFullDay.Checked && !string.IsNullOrEmpty(txtno.Text))
                        {
                            int numberOfFullDays;
                            if (int.TryParse(txtno.Text, out numberOfFullDays))
                            {
                                duration += numberOfFullDays;
                            }
                            else
                            {

                                //MessageBox.Show("Please enter a valid number of full days.");

                            }
                        }

                        // SqlConnection con = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_SaveLeaveRequest", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", txtStaffName.Text);
                        cmd.Parameters.AddWithValue("@Staffid", UserId);
                        cmd.Parameters.AddWithValue("@Department", ddlDepartment.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@StartDate", txtStartDate.Text);
                        cmd.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                        cmd.Parameters.AddWithValue("@LeaveType", ddlLeaveType.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Reason", txtReason.Text);
                        cmd.Parameters.AddWithValue("@Designation", txtDesignation.Text);
                        cmd.Parameters.AddWithValue("@Duration", duration);
                        cmd.Parameters.AddWithValue("@UniqueNo", lblInitialNumber.Text);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {
                            GETStaffEmail(UserName);
                            SendEmail(UserName);
                            Clear();
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Leave Request Details Save Successfully!";

                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Leave Request Details already Available";

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
            finally { }
        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }


        public void SendEmail(string EMPNamE)
        {
            try
            {
                //-----------------Sending Email------------------------//
                GETCredentials();//method for domain password

                EmailID1 = lblStaffEmail.Text;
                Designation1 = lblStaffDesignation.Text;
                lblEmpName11.Text = EMPNamE;
                UserEmpName = lblEmpName11.Text;

                if (!string.IsNullOrEmpty(EmailID1))
                {
                    using (MailMessage mm = new MailMessage(DevEmail, EmailID1))
                    {
                        //  MailBody
                        mm.Subject = "Leave Request  From      " + txtStaffName.Text;
                        mm.Bcc.Add(new MailAddress(EmailID1));
                        // mm.cc.Add(new MailAddress(EmailID1));
                        string leaveType = ddlLeaveType.SelectedItem.Text;
                        DateTime startDate = Convert.ToDateTime(txtStartDate.Text);
                        DateTime endDate = Convert.ToDateTime(txtEndDate.Text);
                        int totalDays = (endDate - startDate).Days + 1;
                        int fullDays = 0;
                        int halfDays = 0;

                        if (chkFullDay.Checked)
                        {
                            fullDays = string.IsNullOrEmpty(txtno.Text) ? totalDays : Convert.ToInt32(txtno.Text);
                        }

                        if (chkHalfDay.Checked)
                        {
                            halfDays = 1;
                        }

                        string body = "<p>Subject: Leave Request for " + leaveType + " from " + startDate.ToShortDateString() + " to " + endDate.ToShortDateString() + "</p>";
                        body += "<p>Dear Sir/Ma'am,</p>";
                        body += "<p>I hope this email finds you well. I would like to request " + ddlLeaveType.SelectedItem.Text + " for a duration of " + ((Convert.ToDateTime(txtEndDate.Text) - Convert.ToDateTime(txtStartDate.Text)).Days + 1) + " days,( " +
                             +fullDays + " full day(s) and " + halfDays + " half day)   from " + startDate.ToShortDateString() + " to " + endDate.ToShortDateString() + ", for " + txtReason.Text + ". During this period, I will ensure that my ongoing tasks are either completed or delegated to a colleague. I apologize for any inconvenience this may cause and assure you that I will make up for any missed work. During my absence, I will be reachable via email or phone for any urgent matters and will do my best to address them promptly.</p>";
                        body += "<p>Please let me know if you need any further information or if there are additional steps I need to take. I appreciate your understanding and support in this matter.</p>";
                        body += "<p>Thank you for considering my request.</p>";
                        body += "<p>Sincerely,</p>";
                        body += "<p>" + txtStaffName.Text + "</p>";
                        body += "<br /><br />Thanks";
                        mm.Body = body;
                        mm.IsBodyHtml = true;
                        mm.Priority = MailPriority.Normal;


                        using (SqlConnection conn = new SqlConnection(strconnect))
                        {
                            SqlCommand com = new SqlCommand("SP_ViewFileLeaveRequestDetails", conn);
                            com.CommandType = CommandType.StoredProcedure;

                            com.Parameters.AddWithValue("@UniqueNo", lblInitialNumber.Text);
                            conn.Open();
                            using (SqlDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string fileName = reader["FileName"].ToString();
                                    string filePath = reader["FilePath"].ToString();
                                    mm.Attachments.Add(new System.Net.Mail.Attachment(filePath));
                                }
                            }
                        }

                        SmtpClient smtp = new SmtpClient();
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Host = DevHost;
                        NetworkCredential NetworkCred = new NetworkCredential(DevEmail, DevPassword);
                        smtp.Credentials = NetworkCred;
                        smtp.Port = Convert.ToInt32(DevPort);

                        try
                        {
                            smtp.Send(mm);
                            //ViewBag.Message = "Email Send Successfully";
                        }
                        catch (Exception ex)
                        {
                            //Response.Write("<script>alert('Email Not Send '); </script>");
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
            finally { }
        }
        //-----------------------------------------------------------------------------------------------------//
        // Leave File Upload
        //-----------------------------------------------------------------------------------------------------//

        protected void ShowDetails_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;

                System.Web.UI.WebControls.Label lblID1 = (System.Web.UI.WebControls.Label)row.FindControl("lblID1");
                string ID = lblID1.Text;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetLeaveManagementDetailsByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@ID", ID);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblInitialNumber.Text = dt.Rows[0]["UniqueNo"].ToString();

                    }
                    ViewFileRequestDetails();

                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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

        }

        protected void Btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload.PostedFile == null && lblInitialNumber.Text == "")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ticket Not In Draft!')", true);
                }
                else
                {
                    if (FileUpload.PostedFile.FileName.Length > 1)
                    {
                        string uploadDirectory = Server.MapPath("~/Leave_File/");

                        if (!Directory.Exists(uploadDirectory))
                        {
                            Directory.CreateDirectory(uploadDirectory);
                        }
                        string fileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
                        string filePath = System.IO.Path.Combine(uploadDirectory, fileName);
                        string extention = System.IO.Path.GetExtension(FileUpload.PostedFile.FileName);


                        FileUpload.PostedFile.SaveAs(filePath);
                        string contenttype = String.Empty;
                        switch (extention.ToLower())
                        {
                            case ".doc":
                                contenttype = "application/vnd.ms-word";
                                break;
                            case ".docx":
                                contenttype = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;
                            case ".xls":
                                contenttype = "application/vnd.ms-excel";
                                break;
                            case ".xlsx":
                                contenttype = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                break;
                            case ".jpg":
                                contenttype = "image/jpg";
                                break;
                            case ".png":
                                contenttype = "image/png";
                                break;
                            case ".gif":
                                contenttype = "image/gif";
                                break;
                            case ".pdf":
                                contenttype = "application/pdf";
                                break;
                        }

                        if (contenttype != String.Empty)
                        {
                            Stream fs = FileUpload.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            using (SqlConnection con = new SqlConnection(strconnect))
                            {
                                SqlCommand cmd = new SqlCommand("SP_UploadLeaveAttachmentFile", con);
                                cmd.Connection = con;

                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@Extention", extention);
                                cmd.Parameters.AddWithValue("@FilePath", filePath);
                                cmd.Parameters.AddWithValue("@EmpID", UserId);
                                cmd.Parameters.AddWithValue("@Designation", Designation);
                                cmd.Parameters.AddWithValue("@Createby", UserName);
                                cmd.Parameters.AddWithValue("@UniqueNo", lblInitialNumber.Text);
                                cmd.Parameters.AddWithValue("@ContentType", contenttype);
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                int i = cmd.ExecuteNonQuery();
                                if (i < 0)
                                {

                                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Leave Request File Uploaded Successfully!')", true);
                                    //ViewFileRequestDetails();
                                }
                                else
                                {
                                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Leave Request File  Uploaded Successfully!')", true);
                                }

                            }
                        }
                    }
                    else
                    {
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Choose File For Uploaded!')", true);
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
            finally { }
        }


        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowIndex = row.RowIndex;

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    Leaveid = ((System.Web.UI.WebControls.Label)GridLeaveRequestFile.Rows[rowIndex].FindControl("lblfileid")).Text;
                    lbdLeaveMID.Text = Leaveid;
                    SqlCommand cmd = new SqlCommand("SP_GetLeaveManagementFileDetailsByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ID", lbdLeaveMID.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string name = dt.Rows[0]["FileName"].ToString();
                        string FilePath = dt.Rows[0]["FilePath"].ToString();
                        string Extention = dt.Rows[0]["Extention"].ToString();
                        string UniqueNo = dt.Rows[0]["UniqueNo"].ToString();
                        string contentType = dt.Rows[0]["ContentType"].ToString();
                        Byte[] bytes = (Byte[])dt.Rows[0]["Data"];

                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.ContentType = contentType;
                        Response.AddHeader("content-disposition", "attachment;filename=" + name);
                        Response.BinaryWrite(bytes);
                        Response.Flush();
                        Response.End();
                    }
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


        [WebMethod]
        public void GetDetails(string UniqueNo)
        {
            object[] details = null;
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(constr))
            {
                SqlCommand com = new SqlCommand("SP_ViewFileLeaveRequestDetails", con1);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@UniqueNo", UniqueNo);
                // com.Parameters.AddWithValue("@BelongTo", "Office Expenses");
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridLeaveRequestFile.DataSource = dt;
                    GridLeaveRequestFile.DataBind();
                    GridLeaveRequestFile.Visible = true;

                    foreach (GridViewRow gridviedrow in GridLeaveRequestFile.Rows)
                    {

                        LinkButton btnDownload = (LinkButton)gridviedrow.FindControl("btnDownload");

                        btnDownload.Visible = true;

                    }
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridLeaveRequestFile.DataSource = dt;
                    GridLeaveRequestFile.DataBind();
                    int totalcolums = GridLeaveRequestFile.Rows[0].Cells.Count;
                    GridLeaveRequestFile.Visible = false;
                }
            }

        }

        #endregion
    }
}