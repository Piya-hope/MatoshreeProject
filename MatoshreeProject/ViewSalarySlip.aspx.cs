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
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using System.Xml.Linq;
using iTextSharp.tool.xml;
using Image = iTextSharp.text.Image;
using iTextSharp.text.pdf.draw;
using ListItem = System.Web.UI.WebControls.ListItem;
using Font = iTextSharp.text.Font;
using iTextSharp.tool.xml.html.pdfelement;
using iText.Kernel.Pdf;
using System.IO.MemoryMappedFiles;
using System.Reflection;
using System.Dynamic;
using Color = System.Drawing.Color;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
//using static MatoshreeProject.ViewLeaveManagement;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
#endregion

namespace MatoshreeProject
{
    public partial class ViewSalarySlip : System.Web.UI.Page
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
        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;


        Decimal HalfDays, UpaidLeave, MonthlyDediction, MonthyAddition, PerDaySalary, HalfDaySalary, NetSalary, FinalNetSalary;


        // Phrase phrase = null;


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
        public DataTable GridViewSalarySlipEmpID(int UserID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewSalarySlipDetailbyEmpID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", UserID);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridViewSlip.DataSource = table;
                GridViewSlip.DataBind();
                ViewState["SlipData"] = table;
            }
            return table;
        }
        public void GridViewSalarySlip()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ViewSalarySlipDetails", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        DataTable ds = new DataTable();
                        sda.Fill(ds);
                        if (ds.Rows.Count > 0)
                        {
                            GridViewSlip.DataSource = ds;
                            GridViewSlip.DataBind();
                            ViewState["SlipData"] = ds;
                        }
                        else
                        {
                            ds.Rows.Add(ds.NewRow());
                            GridViewSlip.DataSource = ds;
                            GridViewSlip.DataBind();
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

        public void MonthBind()
        {
            try
            {
                System.Globalization.DateTimeFormatInfo info = System.Globalization.DateTimeFormatInfo.GetInstance(null);
                int currentMonth = DateTime.Now.Month;
                for (int i = currentMonth; i < 13; i++)
                {
                    ddlMonth.Items.Add(new ListItem(info.GetMonthName(i), i.ToString()));
                }

                if (DateTime.Now.Day <= 10)
                {
                    ddlMonth.Items.Insert(0, new ListItem(info.GetMonthName(currentMonth - 1), currentMonth.ToString()));
                }

                if (ddlMonth.Items.FindByValue(currentMonth.ToString()) != null)
                {
                    ddlMonth.Items.FindByValue(currentMonth.ToString()).Selected = true;
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

        public void YearBind()
        {
            try
            {


                int currentYear = DateTime.Now.Year;
                int endYear = 2100;

                for (int i = currentYear; i <= endYear; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                if (DateTime.Now.Day <= 10 && currentYear > 1)
                {
                    ddlYear.Items.Insert(0, new ListItem((currentYear - 1).ToString(), (currentYear - 1).ToString()));
                }

                if (ddlYear.Items.FindByValue(currentYear.ToString()) != null)
                {
                    ddlYear.Items.FindByValue(currentYear.ToString()).Selected = true;
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

        //---------------------------------------------------------------------------------//
        public void GetMessageFromModules()
        {
            try
            {
                string MSGdata = HttpUtility.UrlDecode(Request.QueryString["svd1"]);
                string EdidDATA = HttpUtility.UrlDecode(Request.QueryString["edit1"]);
                if (MSGdata == "fgsave123q" && EdidDATA == null)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Employee Salary Slip Details Save Successfully";
                }
                else if (EdidDATA == "xcvfedit" && MSGdata == null)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Employee Salary Slip Details Edit Successfully";
                }
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
                    command.Parameters.AddWithValue("@SubModule", "EmpSalarySlip");
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
                            MonthBind();
                            YearBind();
                            GridViewSalarySlipEmpID(UserId);

                            if (Create == "True")
                            {
                                //addnew.Visible = true;
                                //btnNewPreSalaryStructure.Visible = true;
                            }
                            else
                            {
                                //addnew.Visible = false;
                                //btnNewPreSalaryStructure.Visible = false;
                            }

                            if (Edit == "True")
                            {

                               // GridViewPreSalaryStructure.Columns[4].Visible = true;
                            }
                            else
                            {

                               // GridViewPreSalaryStructure.Columns[4].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                //GridViewPreSalaryStructure.Columns[5].Visible = true;
                            }
                            else
                            {

                                //GridViewPreSalaryStructure.Columns[5].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {

                            MonthBind();
                            YearBind();
                            GridViewSalarySlipEmpID(UserId);


                            if (Create == "True")
                            {
                                //addnew.Visible = true;
                                //btnNewPreSalaryStructure.Visible = true;
                            }
                            else
                            {
                                //addnew.Visible = false;
                                //btnNewPreSalaryStructure.Visible = false;
                            }

                            if (Edit == "True")
                            {

                                //GridViewPreSalaryStructure.Columns[4].Visible = true;
                            }
                            else
                            {

                                //GridViewPreSalaryStructure.Columns[4].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                //GridViewPreSalaryStructure.Columns[5].Visible = true;
                            }
                            else
                            {

                                //GridViewPreSalaryStructure.Columns[5].Visible = false;
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
                            if (!IsPostBack)
                            {
                                MonthBind();
                                YearBind();
                                GridViewSalarySlip();
                            }

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
                                GetMessageFromModules();
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

        protected void GridViewSlip_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridViewSlip.Rows)
                {
                    Label lblMonthGrid = (Label)gridviedrow.FindControl("lblMonthGrid");
                    Label lblYearGrid = (Label)gridviedrow.FindControl("lblYearGrid");

                    lblMonthGrid.Text = Convert.ToString(ddlMonth.SelectedItem.Text);
                    lblYearGrid.Text = Convert.ToString(ddlYear.SelectedItem.Text);
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime currentDate = DateTime.Now;

                //if (currentDate.Day == 30)
                //{
                    foreach (GridViewRow gridviedrow in GridViewSlip.Rows)
                    {
                        Label lblID = (Label)gridviedrow.FindControl("lblStaffID");
                        Label lblHalfDays = (Label)gridviedrow.FindControl("lblHalfDays");
                        Label lblUpaidLeave = (Label)gridviedrow.FindControl("lblUpaidLeave");

                        Label lblMonthlySalaryComp = (Label)gridviedrow.FindControl("lblMonthlySalaryComp");
                        Label lblMonthlySalaryContri = (Label)gridviedrow.FindControl("lblMonthlySalaryContri");
                        Label lblNetSalary = (Label)gridviedrow.FindControl("lblNetSalary");
                        using (SqlConnection con = new SqlConnection(strconnect))
                        {
                            SqlCommand cmd = new SqlCommand("SP_GetHalfDay", con);
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Staff_ID", lblID.Text);
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable ds = new DataTable();
                                sda.Fill(ds);
                                if (ds.Rows.Count > 0)
                                {
                                    lblHalfDays.Text = ds.Rows[0]["HalfDay"].ToString();
                                }
                                else
                                {
                                    lblHalfDays.Text = "0";
                                }

                            }
                            HalfDays = Convert.ToDecimal(lblHalfDays.Text);
                        }

                        using (SqlConnection conn = new SqlConnection(strconnect))
                        {

                            SqlCommand cmd1 = new SqlCommand("SP_GetUnpaidLeave", conn);
                            cmd1.Connection = conn;
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@Staff_ID", lblID.Text);
                            using (SqlDataAdapter sda1 = new SqlDataAdapter(cmd1))
                            {
                                DataTable ds1 = new DataTable();
                                sda1.Fill(ds1);
                                if (ds1.Rows.Count > 0)
                                {
                                    lblUpaidLeave.Text = ds1.Rows[0]["UnPaid"].ToString();
                                }
                                else
                                {
                                    lblUpaidLeave.Text = "0";
                                }

                            }
                            UpaidLeave = Convert.ToDecimal(lblUpaidLeave.Text);
                        }


                        //if (HalfDays > 0 || UpaidLeave > 0)
                        //{
                        MonthyAddition = Convert.ToDecimal(lblMonthlySalaryComp.Text);
                        MonthlyDediction = Convert.ToDecimal(lblMonthlySalaryContri.Text);

                        NetSalary = MonthyAddition - MonthlyDediction;
                        PerDaySalary = NetSalary / 30;
                        HalfDaySalary = PerDaySalary / 2;
                        FinalNetSalary = NetSalary - UpaidLeave * PerDaySalary - HalfDays * HalfDaySalary;
                        decimal roundedFinalSal = Math.Round(FinalNetSalary, 2);
                        lblNetSalary.Text = Convert.ToString(roundedFinalSal);
                        //}
                        //else if(HalfDays > 0 && UpaidLeave > 0)
                        //{
                        //    MonthyAddition = Convert.ToDecimal(lblMonthlySalaryComp.Text);
                        //    MonthlyDediction = Convert.ToDecimal(lblMonthlySalaryContri.Text);

                        //    NetSalary = MonthyAddition - MonthlyDediction;
                        //    PerDaySalary = NetSalary / 30;
                        //    HalfDaySalary = PerDaySalary / 2;
                        //    FinalNetSalary = NetSalary - UpaidLeave * PerDaySalary - HalfDays * HalfDaySalary;
                        //    decimal roundedFinalSal1 = Math.Round(FinalNetSalary, 2);
                        //    lblNetSalary.Text = Convert.ToString(roundedFinalSal1);
                        //}
                        //else
                        //{
                        //    NetSalary = MonthyAddition - MonthlyDediction;
                        //    lblNetSalary.Text = Convert.ToString(NetSalary);
                        //}
                    }

                    foreach (GridViewRow gridviedrow in GridViewSlip.Rows)
                    {
                        Label lblID = (Label)gridviedrow.FindControl("lblStaffID");
                        Label lblName = (Label)gridviedrow.FindControl("lblName");
                        Label lblStaffEmaill = (Label)gridviedrow.FindControl("lblStaffEmaill");
                        Label lblPackage = (Label)gridviedrow.FindControl("lblPackage");
                        Label lblAnnualSalaryComp = (Label)gridviedrow.FindControl("lblAnnualSalaryComp");
                        Label lblMonthlySalaryComp = (Label)gridviedrow.FindControl("lblMonthlySalaryComp");
                        Label lblMonthlySalaryContri = (Label)gridviedrow.FindControl("lblMonthlySalaryContri");
                        Label lblAnnualSalaryContri = (Label)gridviedrow.FindControl("lblAnnualSalaryContri");
                        Label lblUpaidLeave = (Label)gridviedrow.FindControl("lblUpaidLeave");
                        Label lblHalfDays = (Label)gridviedrow.FindControl("lblHalfDays");
                        Label lblNetSalary = (Label)gridviedrow.FindControl("lblNetSalary");

                        using (SqlConnection con = new SqlConnection(strconnect))
                        {
                            SqlCommand cmd = new SqlCommand("SP_SaveSalarySlipGenerate", con);
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@StaffID", lblID.Text);
                            cmd.Parameters.AddWithValue("@StaffName", lblName.Text);
                            cmd.Parameters.AddWithValue("@StaffEmail", lblStaffEmaill.Text);
                            cmd.Parameters.AddWithValue("@Package", lblPackage.Text);
                            cmd.Parameters.AddWithValue("@AnnualAddition", lblAnnualSalaryComp.Text);
                            cmd.Parameters.AddWithValue("@MonthlyAddition", lblMonthlySalaryComp.Text);
                            cmd.Parameters.AddWithValue("@MonthlyDeduction", lblMonthlySalaryContri.Text);
                            cmd.Parameters.AddWithValue("@AnnualDeduction", lblAnnualSalaryContri.Text);
                            cmd.Parameters.AddWithValue("@UnpaidLeave", lblUpaidLeave.Text);
                            cmd.Parameters.AddWithValue("@HalfDays", lblHalfDays.Text);
                            cmd.Parameters.AddWithValue("@NetSalary", lblNetSalary.Text);
                            cmd.Parameters.AddWithValue("@Month", ddlMonth.SelectedItem.Text);
                            cmd.Parameters.AddWithValue("@Year", ddlYear.SelectedItem.Text);
                            cmd.Parameters.AddWithValue("@SendEmail", chkSendEmail.Checked);
                            cmd.Parameters.AddWithValue("@EmpID", UserId);
                            cmd.Parameters.AddWithValue("@Createby", UserName);

                            con.Open();
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                result = dr[0].ToString();
                            }
                            Result = int.Parse(result);
                            if (Result > 0)
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Employee Monthly Salary Slip Save Successfully!";
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Employee Monthly Salary Slip Not Save Yet!";
                            }

                            con.Close();
                        }
                    }

                //}
                //else
                //{
                //    Toasteralert.Visible = false;
                //    deleteToaster.Visible = true;
                //    lblMesDelete.Text = "Submission failed. Today is not the 30th.!";
                    
                //}

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

        protected void btnViewEmpSalDetails_Click(object sender, EventArgs e)
        {
            try
            {
                string ID;
                var rows = GridViewSlip.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ID = ((Label)rows[rowindex].FindControl("lblStaffID")).Text;

                Response.Redirect("~/EmpSalarySlip.aspx?XCEEMPIDdfd=" + ID, false);
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

        #endregion
    }
}