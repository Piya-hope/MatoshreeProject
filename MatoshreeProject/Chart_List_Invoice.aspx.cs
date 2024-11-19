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
#endregion

namespace MatoshreeProject
{
    public partial class Chart_List_Invoice : System.Web.UI.Page
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

        Phrase phrase = null;

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
        public void GetMessageFromModules()
        {
            try
            {
                string MSGdata = HttpUtility.UrlDecode(Request.QueryString["svd1"]);
                string EdidDATA = HttpUtility.UrlDecode(Request.QueryString["edit1"]);
                string Draft = HttpUtility.UrlDecode(Request.QueryString["Draft1"]);
                if (MSGdata == "fgsave123q" && EdidDATA == null)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Invoice Details Save Successfully";
                }
                else if (EdidDATA == "xcvfedit" && MSGdata == null)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Invoice Details Edit Successfully";
                }
                else if (Draft == "fgdraft1234q" && MSGdata == null)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "New Invoice Details Draft Added Successfully";
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
        //------------------------Employee ID-------------------------------------------//
        public DataTable ViewInvoiceDetailsByEmpID(int UserID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_InvoiceDetailsbyEmpID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", UserID);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridInvoice.DataSource = table;
                GridInvoice.DataBind();
                ViewState["InvoiceData"] = table;
            }
            return table;
        }

        public void InvoiceStatusEmpIDCount(int UserID)
        {
            try
            {
                //-------------totalInvoiceTotal----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceTotalCountByEmpID", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int totalInvoiceTotal = (int)command.ExecuteScalar();

                    lblTotalInvoiceCount.Text = Convert.ToString(totalInvoiceTotal);
                    //TotalInvoiceCount = totalInvoiceTotal;
                }
                double TotalInvoiceCount;
                TotalInvoiceCount = Convert.ToDouble(lblTotalInvoiceCount.Text);

                //-------------InvoiceOverdue----------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceOverdueCountByEmpID", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int InvoiceOverdue = (int)command.ExecuteScalar();

                    lblInvoiceOverDue.Text = Convert.ToString(InvoiceOverdue) + "/" + lblTotalInvoiceCount.Text;

                    decimal PercentOverDue = Convert.ToDecimal((InvoiceOverdue / TotalInvoiceCount) * 100);
                    decimal totalOverDue = decimal.Round(PercentOverDue, 1);
                    lblInvoiceOverDuePercent.Text = Convert.ToString(totalOverDue) + "%";

                    PgBarInvoiceOverDue.Style.Add("width", lblInvoiceOverDuePercent.Text);
                }

                //-------------InvoiceDraft----------------------//
                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceDraftCountbyEmpID", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int InvoiceDraft = (int)command.ExecuteScalar();

                    lblInvoiceDraft.Text = Convert.ToString(InvoiceDraft) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoiceDraft = Convert.ToDecimal((InvoiceDraft / TotalInvoiceCount) * 100);
                    decimal totalDraft = decimal.Round(TotalInvoiceDraft, 1);
                    lblInvoiceDraftPercent.Text = Convert.ToString(totalDraft) + "%";

                    PgBarInvoiceDraft.Style.Add("width", lblInvoiceDraftPercent.Text);
                }

                //-------------InvoiceUnpaid----------------------//

                using (SqlConnection con3 = new SqlConnection(strconnect))
                {
                    con3.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceUnpaidCountByEmpID", con3);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int InvoiceUnpaid = (int)command.ExecuteScalar();

                    lblUnpaid.Text = Convert.ToString(InvoiceUnpaid) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoiceUnpaid = Convert.ToDecimal((InvoiceUnpaid / TotalInvoiceCount) * 100);

                    decimal totalunpaid = decimal.Round(TotalInvoiceUnpaid, 1);
                    lblPercentUnpaid.Text = Convert.ToString(totalunpaid) + "%";

                    ProgressUnpaid.Style.Add("width", lblPercentUnpaid.Text);
                }

                //-------------InvoicePaid----------------------//

                using (SqlConnection con4 = new SqlConnection(strconnect))
                {
                    con4.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoicePaidCountByEmpID", con4);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int InvoicePaid = (int)command.ExecuteScalar();

                    lblPaid.Text = Convert.ToString(InvoicePaid) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoicePaid = Convert.ToDecimal((InvoicePaid / TotalInvoiceCount) * 100);

                    decimal totalpaid = decimal.Round(TotalInvoicePaid, 1);
                    lblPercentPaid.Text = Convert.ToString(totalpaid) + "%";

                    ProgressPercentPaid.Style.Add("width", lblPercentPaid.Text);
                }

                //-------------InvoicePartiallyPaid----------------------//

                using (SqlConnection con5 = new SqlConnection(strconnect))
                {
                    con5.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoicePartiallyPaidCountbyEmpID", con5);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int InvoicePartiallyPaid = (int)command.ExecuteScalar();

                    lblPartallyPaid.Text = Convert.ToString(InvoicePartiallyPaid) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoicePartiallyPaid = Convert.ToDecimal((InvoicePartiallyPaid / TotalInvoiceCount) * 100);
                    decimal totalPartiallyPaid = decimal.Round(TotalInvoicePartiallyPaid, 1);
                    lblPartallyPaidpercent.Text = Convert.ToString(totalPartiallyPaid) + "%";

                    ProgressPartallyPaid.Style.Add("width", lblPartallyPaidpercent.Text);
                }


                //-------------InvoiceCancel----------------------//

                using (SqlConnection con5 = new SqlConnection(strconnect))
                {
                    con5.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceCancelledCountByEmpID", con5);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int InvoiceCancel = (int)command.ExecuteScalar();

                    lblCancelled.Text = Convert.ToString(InvoiceCancel) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalCancel = Convert.ToDecimal((InvoiceCancel / TotalInvoiceCount) * 100);
                    decimal totalCancel = decimal.Round(TotalCancel, 1);
                    lblCancelledPercent.Text = Convert.ToString(totalCancel) + "%";

                    PgBarCancelled.Style.Add("width", lblCancelledPercent.Text);
                }

                //---------------OverdueAmount Invoice Amount----------------------//
                using (SqlConnection conOver = new SqlConnection(strconnect))
                {
                    conOver.Open();
                    SqlCommand commandOver = new SqlCommand("SP_GetInvoiceOverdueAmountEMPID", conOver);
                    commandOver.CommandType = CommandType.StoredProcedure;
                    commandOver.Parameters.AddWithValue("@EmpID", UserID);
                    string totalInvoiceOverdueAmount = (string)commandOver.ExecuteScalar();

                    if (totalInvoiceOverdueAmount == null)
                    {
                        lbl_Past_Due_Invoice.Text = "₹" + Convert.ToString("0");
                    }
                    else
                    {
                        lbl_Past_Due_Invoice.Text = Convert.ToString(totalInvoiceOverdueAmount);
                    }


                }

                //---------------OutStanding Invoice Amount----------------------//
                using (SqlConnection const1 = new SqlConnection(strconnect))
                {
                    const1.Open();
                    SqlCommand commandst = new SqlCommand("SP_GetInvoiceOutStandingAmountEMPID", const1);
                    commandst.CommandType = CommandType.StoredProcedure;
                    commandst.Parameters.AddWithValue("@EmpID", UserID);
                    string totalInvoiceOutStAmount = (string)commandst.ExecuteScalar();

                    if (totalInvoiceOutStAmount == null)
                    {
                        lbl_Outstanding_Invoice.Text = "₹" + Convert.ToString("0");
                    }
                    else
                    {
                        lbl_Outstanding_Invoice.Text = Convert.ToString(totalInvoiceOutStAmount);
                    }

                }

                //---------------PAID Invoice Amount----------------------//
                using (SqlConnection conpaid = new SqlConnection(strconnect))
                {
                    conpaid.Open();
                    SqlCommand commandpaid = new SqlCommand("SP_GetInvoicePaidAmountEMPID", conpaid);
                    commandpaid.CommandType = CommandType.StoredProcedure;
                    commandpaid.Parameters.AddWithValue("@EmpID", UserID);
                    string totalInvoicepaid = (string)commandpaid.ExecuteScalar();

                    if (totalInvoicepaid == null)
                    {
                        lbl_Paid_Invoice.Text = "₹" + Convert.ToString("0");
                    }
                    else
                    {
                        lbl_Paid_Invoice.Text = Convert.ToString(totalInvoicepaid);
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

        //---------------------------------------------------------------------------//
        public void InvoiceStatusCount()
        {
            try
            {
                //-------------totalInvoiceTotal----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceTotalCount", con);
                    command.CommandType = CommandType.StoredProcedure;
                    int totalInvoiceTotal = (int)command.ExecuteScalar();

                    lblTotalInvoiceCount.Text = Convert.ToString(totalInvoiceTotal);
                    //TotalInvoiceCount = totalInvoiceTotal;
                }
                double TotalInvoiceCount;
                TotalInvoiceCount = Convert.ToDouble(lblTotalInvoiceCount.Text);

                //-------------InvoiceOverdue----------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceOverdueCount", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    int InvoiceOverdue = (int)command.ExecuteScalar();

                    lblInvoiceOverDue.Text = Convert.ToString(InvoiceOverdue) + "/" + lblTotalInvoiceCount.Text;

                    decimal PercentOverDue = Convert.ToDecimal((InvoiceOverdue / TotalInvoiceCount) * 100);
                    decimal totalOverDue = decimal.Round(PercentOverDue, 1);
                    lblInvoiceOverDuePercent.Text = Convert.ToString(totalOverDue) + "%";

                    PgBarInvoiceOverDue.Style.Add("width", lblInvoiceOverDuePercent.Text);
                }

                //-------------InvoiceDraft----------------------//
                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceDraftCount", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    int InvoiceDraft = (int)command.ExecuteScalar();

                    lblInvoiceDraft.Text = Convert.ToString(InvoiceDraft) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoiceDraft = Convert.ToDecimal((InvoiceDraft / TotalInvoiceCount) * 100);
                    decimal totalDraft = decimal.Round(TotalInvoiceDraft, 1);
                    lblInvoiceDraftPercent.Text = Convert.ToString(totalDraft) + "%";

                    PgBarInvoiceDraft.Style.Add("width", lblInvoiceDraftPercent.Text);
                }

                //-------------InvoiceUnpaid----------------------//

                using (SqlConnection con3 = new SqlConnection(strconnect))
                {
                    con3.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceUnpaidCount", con3);
                    command.CommandType = CommandType.StoredProcedure;
                    int InvoiceUnpaid = (int)command.ExecuteScalar();

                    lblUnpaid.Text = Convert.ToString(InvoiceUnpaid) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoiceUnpaid = Convert.ToDecimal((InvoiceUnpaid / TotalInvoiceCount) * 100);

                    decimal totalunpaid = decimal.Round(TotalInvoiceUnpaid, 1);
                    lblPercentUnpaid.Text = Convert.ToString(totalunpaid) + "%";

                    ProgressUnpaid.Style.Add("width", lblPercentUnpaid.Text);
                }

                //-------------InvoicePaid----------------------//

                using (SqlConnection con4 = new SqlConnection(strconnect))
                {
                    con4.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoicePaidCount", con4);
                    command.CommandType = CommandType.StoredProcedure;
                    int InvoicePaid = (int)command.ExecuteScalar();

                    lblPaid.Text = Convert.ToString(InvoicePaid) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoicePaid = Convert.ToDecimal((InvoicePaid / TotalInvoiceCount) * 100);

                    decimal totalpaid = decimal.Round(TotalInvoicePaid, 1);
                    lblPercentPaid.Text = Convert.ToString(totalpaid) + "%";

                    ProgressPercentPaid.Style.Add("width", lblPercentPaid.Text);
                }

                //-------------InvoicePartiallyPaid----------------------//

                using (SqlConnection con5 = new SqlConnection(strconnect))
                {
                    con5.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoicePartiallyPaidCount", con5);
                    command.CommandType = CommandType.StoredProcedure;
                    int InvoicePartiallyPaid = (int)command.ExecuteScalar();

                    lblPartallyPaid.Text = Convert.ToString(InvoicePartiallyPaid) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoicePartiallyPaid = Convert.ToDecimal((InvoicePartiallyPaid / TotalInvoiceCount) * 100);
                    decimal totalPartiallyPaid = decimal.Round(TotalInvoicePartiallyPaid, 1);
                    lblPartallyPaidpercent.Text = Convert.ToString(totalPartiallyPaid) + "%";

                    ProgressPartallyPaid.Style.Add("width", lblPartallyPaidpercent.Text);
                }

                //-------------InvoiceCancel----------------------//

                using (SqlConnection con5 = new SqlConnection(strconnect))
                {
                    con5.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceCancelledCount", con5);
                    command.CommandType = CommandType.StoredProcedure;
                    int InvoiceCancel = (int)command.ExecuteScalar();

                    lblCancelled.Text = Convert.ToString(InvoiceCancel) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalCancel = Convert.ToDecimal((InvoiceCancel / TotalInvoiceCount) * 100);
                    decimal totalCancel = decimal.Round(TotalCancel, 1);
                    lblCancelledPercent.Text = Convert.ToString(totalCancel) + "%";

                    PgBarCancelled.Style.Add("width", lblCancelledPercent.Text);
                }

                //---------------OverdueAmount Invoice Amount----------------------//
                using (SqlConnection conOver = new SqlConnection(strconnect))
                {
                    conOver.Open();
                    SqlCommand commandOver = new SqlCommand("SP_GetInvoiceOverdueAmount", conOver);
                    commandOver.CommandType = CommandType.StoredProcedure;
                    string totalInvoiceOverdueAmount = (string)commandOver.ExecuteScalar();

                    if (totalInvoiceOverdueAmount == null)
                    {
                        lbl_Past_Due_Invoice.Text = "₹" + Convert.ToString("0");
                    }
                    else
                    {
                        lbl_Past_Due_Invoice.Text = Convert.ToString(totalInvoiceOverdueAmount);
                    }

                }

                //---------------OutStanding Invoice Amount----------------------//
                using (SqlConnection const1 = new SqlConnection(strconnect))
                {
                    const1.Open();
                    SqlCommand commandst = new SqlCommand("SP_GetInvoiceOutStandingAmount", const1);
                    commandst.CommandType = CommandType.StoredProcedure;
                    string totalInvoiceOutStAmount = (string)commandst.ExecuteScalar();

                    if (totalInvoiceOutStAmount == null)
                    {
                        lbl_Outstanding_Invoice.Text = "₹" + Convert.ToString("0");
                    }
                    else
                    {
                        lbl_Outstanding_Invoice.Text = Convert.ToString(totalInvoiceOutStAmount);
                    }
                }

                //---------------PAID Invoice Amount----------------------//
                using (SqlConnection conpaid = new SqlConnection(strconnect))
                {
                    conpaid.Open();
                    SqlCommand commandpaid = new SqlCommand("SP_GetInvoicePaidAmount", conpaid);
                    commandpaid.CommandType = CommandType.StoredProcedure;
                    string totalInvoicepaid = (string)commandpaid.ExecuteScalar();

                    if (totalInvoicepaid == null)
                    {
                        lbl_Paid_Invoice.Text = "₹" + Convert.ToString("0");
                    }
                    else
                    {
                        lbl_Paid_Invoice.Text = Convert.ToString(totalInvoicepaid);
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

        protected void bindInvoiceYear()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetInvoiceYear", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    if (ds.Tables.Count == 0)
                    {
                        //DataSet is empty                    
                        string Year = Convert.ToString(DateTime.Now.Year);
                        ddlYear.DataSource = ds.Tables[0];
                        ddlYear.DataTextField = Year;
                        ddlYear.DataValueField = Year;
                        ddlYear.DataBind();
                    }
                    else
                    {
                        ddlYear.DataSource = ds.Tables[0];
                        ddlYear.DataTextField = "Year";
                        ddlYear.DataValueField = "Year";
                        ddlYear.DataBind();
                        ddlYear.Items.Insert(0, new ListItem("Select Year", "0"));
                    }

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
                    //Response.Write("<script> alert('Error Log Inserted !!') </script>");
                }
                else
                {
                    //Response.Write("<script> alert('Error Log Inserted !!') </script>");
                }
            }
            finally { }

        }
        public DataTable ViewInvoiceDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_InvoiceDetails", con))
                {
                    ad.Fill(table);
                    GridInvoice.DataSource = table;
                    GridInvoice.DataBind();
                    ViewState["InvoiceData"] = table;
                }
            }
            return table;
        }

        //--------------------------------Permission---------------------------------------//
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
                    command.Parameters.AddWithValue("@SubModule", "INVOICES");
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
                            InvoiceStatusCount();
                            ViewInvoiceDetails();
                            bindInvoiceYear();
                            GetCompanyAddress();
                            if (Create == "True")
                            {
                                addnew.Visible = true;
                            }
                            else
                            {
                                addnew.Visible = false;
                            }

                            if (Edit == "True")
                            {

                                GridInvoice.Columns[10].Visible = true;
                            }
                            else
                            {

                                GridInvoice.Columns[10].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                GridInvoice.Columns[11].Visible = true;
                            }
                            else
                            {

                                GridInvoice.Columns[11].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {
                            ViewInvoiceDetailsByEmpID(UserId);
                            InvoiceStatusEmpIDCount(UserId);
                            bindInvoiceYear();
                            GetCompanyAddress();
                            if (Create == "True")
                            {
                                addnew.Visible = true;
                            }
                            else
                            {
                                addnew.Visible = false;
                            }

                            if (Edit == "True")
                            {

                                GridInvoice.Columns[10].Visible = true;
                            }
                            else
                            {

                                GridInvoice.Columns[10].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                GridInvoice.Columns[11].Visible = true;
                            }
                            else
                            {

                                GridInvoice.Columns[11].Visible = false;
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

        #region " Event"
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

                        if (!this.IsPostBack)
                        {
                            InvoiceStatusCount();
                            ViewInvoiceDetails();
                            bindInvoiceYear();
                            GetCompanyAddress();
                            GetMessageFromModules();
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

        protected void btn_Create_New_Invoice_Click(object sender, EventArgs e)
        {
            Response.Redirect("New_Invoice.aspx");
        }

        protected void LinkInvoiceNumber_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string Invoice1;
                var rows = GridInvoice.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                Invoice1 = ((Label)rows[rowindex].FindControl("lblInvoice1")).Text;

                Response.Redirect("~/SingleInvoiceDetails.aspx?Invoice1=" + Invoice1 + "", false);
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



        protected void GridInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow gridviedrow in GridInvoice.Rows)
            {
                // string  Status = Convert.ToString(e.Row.Cells[8].Text);

                Label lblID1 = (Label)gridviedrow.FindControl("lblID1");
                Label lblInvoice1 = (Label)gridviedrow.FindControl("lblInvoice1");
                Label lblAmount1 = (Label)gridviedrow.FindControl("lblAmount1");

                Label lblCustomer1 = (Label)gridviedrow.FindControl("lblCustomer1");
                Label lblProject1 = (Label)gridviedrow.FindControl("lblProject1");
                Label lblSales_Agent1 = (Label)gridviedrow.FindControl("lblSales_Agent1");
                Label lblDate1 = (Label)gridviedrow.FindControl("lblDate1");
                Label lblDue_Date1 = (Label)gridviedrow.FindControl("lblDue_Date1");
                Label lblStats6 = (Label)gridviedrow.FindControl("lblStats6");

                DropDownList ddlStatus = (DropDownList)gridviedrow.FindControl("ddlStatus");
                string status = ((Label)gridviedrow.FindControl("lblStats6")).Text;

                ddlStatus.SelectedItem.Text = status;
                if (status == "Unpaid")
                {
                    lblStats6.CssClass = "btn btn-sm btn-warning";

                }
                else if (status == "Paid")
                {
                    lblStats6.CssClass = "btn btn-sm btn-success";

                }
                else if (status == "Partially Paid")
                {
                    lblStats6.CssClass = "btn btn-sm btn-secondary";

                }
                else if (status == "Overdue")
                {
                    lblStats6.CssClass = "btn btn-sm btn-warning";

                }
                else if (status == "Draft")
                {
                    lblStats6.CssClass = "btn btn-sm btn-light";
    
                }
                else if (status == "Send")
                {
                    lblStats6.CssClass = "btn btn-sm btn-info";
                }
                else
                {
                    lblStats6.CssClass = "btn btn-sm btn-light";
                }
            }
        }


        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btn_Reload_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    InvoiceStatusCount();
                    ViewInvoiceDetails();
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
            finally { }
        }

        protected void Btn_Visibility_Click(object sender, EventArgs e)
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
                        using (SqlDataAdapter ad = new SqlDataAdapter("SP_InvoiceDetailsbyVisibility", con))
                        {
                            ad.Fill(table);
                            GridInvoice.DataSource = table;
                            GridInvoice.DataBind();
                        }
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
                //return table;
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

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    DeviceCon = new SqlConnection(strconnect);
                    string Invoice1, ddlStatus;
                    var rows = GridInvoice.Rows;
                    DropDownList btn = (DropDownList)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    Invoice1 = ((Label)rows[rowindex].FindControl("lblInvoice1")).Text;
                    ddlStatus = ((DropDownList)rows[rowindex].FindControl("ddlStatus")).SelectedItem.Text;

                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {
                        UserCon.Open();
                        using (SqlCommand UserCommand = new SqlCommand("SP_UpdateInvoiceStatus", UserCon))
                        {
                            UserCommand.CommandType = CommandType.StoredProcedure;
                            UserCommand.Parameters.AddWithValue("@InvoiceNo", Invoice1);
                            UserCommand.Parameters.AddWithValue("@status", ddlStatus);
                            UserCommand.Parameters.AddWithValue("@EmpID", UserId);//session 
                            UserCommand.Parameters.AddWithValue("@Designation", Designation);
                            UserCommand.Parameters.AddWithValue("@created_by", UserName);
                            int i = UserCommand.ExecuteNonQuery();
                            if (i < 0)
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Invoice Status Change Successfully";
                                ViewInvoiceDetails();
                                InvoiceStatusCount();
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Invoice Status Not Change Successfully";
                            }
                           
                        }
                    }
                }
                else if (RoleType == Designation)
                {
                    DeviceCon = new SqlConnection(strconnect);
                    string Invoice1, ddlStatus;
                    var rows = GridInvoice.Rows;
                    DropDownList btn = (DropDownList)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    Invoice1 = ((Label)rows[rowindex].FindControl("lblInvoice1")).Text;
                    ddlStatus = ((DropDownList)rows[rowindex].FindControl("ddlStatus")).SelectedItem.Text;

                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {
                        UserCon.Open();
                        using (SqlCommand UserCommand = new SqlCommand("SP_UpdateInvoiceStatus", UserCon))
                        {
                            UserCommand.CommandType = CommandType.StoredProcedure;
                            UserCommand.Parameters.AddWithValue("@InvoiceNo", Invoice1);
                            UserCommand.Parameters.AddWithValue("@status", ddlStatus);
                            UserCommand.Parameters.AddWithValue("@EmpID", UserId);//session 
                            UserCommand.Parameters.AddWithValue("@Designation", Designation);
                            UserCommand.Parameters.AddWithValue("@created_by", UserName);
                            int i = UserCommand.ExecuteNonQuery();

                            if (i < 0)
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Invoice Status Change Successfully";
                                StaffOperationPermission();
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Invoice Status Not Change Successfully";
                            }
                        }
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

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_ShowFilterInvoiceDetailsByYear", UserCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ByYear", Convert.ToInt32(ddlYear.SelectedItem.Text));
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(table);
                    GridInvoice.DataSource = table;
                    GridInvoice.DataBind();
                }

                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("ShowInvoiceAmountByYear", con1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ByYear", Convert.ToInt32(ddlYear.SelectedItem.Text));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string Paid = Convert.ToString(dt.Rows[0]["PaidAmount"]);
                        string UnPaid = Convert.ToString(dt.Rows[0]["UnpaidPaidAmount"]);
                        string OverDue = Convert.ToString(dt.Rows[0]["OverdueAmount"]);

                        if (Paid == "")
                        {
                            lbl_Paid_Invoice.Text = Convert.ToString("₹ ") + "0.0";
                        }
                        else
                        {
                            lbl_Paid_Invoice.Text = Convert.ToString("₹ ") + Paid.ToString();
                        }


                        if (UnPaid == "")
                        {
                            lbl_Outstanding_Invoice.Text = Convert.ToString("₹ ") + "0.0";
                        }
                        else
                        {
                            lbl_Outstanding_Invoice.Text = Convert.ToString("₹ ") + Paid.ToString();
                        }

                        if (OverDue == "")
                        {
                            lbl_Past_Due_Invoice.Text = Convert.ToString("₹ ") + "0.0";
                        }
                        else
                        {
                            lbl_Past_Due_Invoice.Text = Convert.ToString("₹ ") + Paid.ToString();
                        }

                    }
                    else
                    {
                        lbl_Past_Due_Invoice.Text = Convert.ToString("₹ ") + "0.0";
                        lbl_Paid_Invoice.Text = Convert.ToString("₹ ") + "0.0";
                        lbl_Outstanding_Invoice.Text = Convert.ToString("₹ ") + "0.0";
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
        }

        protected void btnEditInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string tableID;
                var rows = GridInvoice.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                tableID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                Response.Redirect("~/EditInvoice.aspx?ID=" + tableID + "", false);
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

        protected void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    string ID;
                    var rows = GridInvoice.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                    SqlConnection DeviceCon = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteInvoice", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Created_by", UserName);
                    cmd.Parameters.AddWithValue("@UserID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Invoice Details Deleted Successfully";
                        ViewInvoiceDetails();
                        InvoiceStatusCount();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Invoice Details Not Deleted";
                    }
                }
                else if (RoleType == Designation)
                {
                    string ID;
                    var rows = GridInvoice.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                    SqlConnection DeviceCon = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteInvoiceForEmpID", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Created_by", UserName);
                    cmd.Parameters.AddWithValue("@UserID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Invoice Details Deleted Successfully";
                        StaffOperationPermission();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Invoice Details Not Deleted";
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
                SqlConnection UserCon = new SqlConnection(strconnect);
                string ErrorMessgage = ex.Message;
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();

            }
        }

        private static void DrawLine(iTextSharp.text.pdf.PdfWriter writer, float x1, float y1, float x2, float y2, BaseColor color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(BaseColor.BLACK);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.Colspan = 4;
            cell.BorderColor = BaseColor.WHITE;
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
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 4f;
            cell.PaddingTop = 2f;
            return cell;
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
                    DataTable dt = ViewInvoiceDetails();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        // Response.AddHeader("Content-Disposition", "attachment;filename=InvoiceDetails.xls");
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "InvoiceDetails " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));

                        Response.Charset = " ";

                        // Create a new DataTable with only the desired columns
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("InvoiceNumber");
                        dtExport.Columns.Add("Amount");
                        dtExport.Columns.Add("Invoice_Date");
                        dtExport.Columns.Add("Customer");
                        dtExport.Columns.Add("Project");
                        dtExport.Columns.Add("Sales_Agent");
                        dtExport.Columns.Add("Status");
                        dtExport.Columns.Add("Due_Date");
                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["ID"];
                            newRow["InvoiceNumber"] = row["InvoiceNo"];
                            newRow["Amount"] = row["InvoiceTotalAmont"];
                            newRow["Invoice_Date"] = row["InvoiceDate"];
                            newRow["Customer"] = row["Cust_Name"];
                            newRow["Project"] = row["ProjectName"];
                            newRow["Sales_Agent"] = row["Sales_Agent"];
                            newRow["Status"] = row["Status"];
                            newRow["Due_Date"] = row["Expiry_Date"];

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
                        ViewState["Data"] = null;
                    }
                }
                else if (RoleType == Designation)
                {
                    DataTable dt = (DataTable)ViewState["InvoiceData"];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        Response.AddHeader("Content-Disposition", "attachment;filename=InvoiceDetails.xls");

                        Response.Charset = " ";

                        // Create a new DataTable with only the desired columns
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("InvoiceNumber");
                        dtExport.Columns.Add("Amount");
                        dtExport.Columns.Add("Invoice_Date");
                        dtExport.Columns.Add("Customer");
                        dtExport.Columns.Add("Project");
                        dtExport.Columns.Add("Sales_Agent");
                        dtExport.Columns.Add("Status");
                        dtExport.Columns.Add("Due_Date");
                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["ID"];
                            newRow["InvoiceNumber"] = row["InvoiceNo"];
                            newRow["Amount"] = row["InvoiceTotalAmont"];
                            newRow["Invoice_Date"] = row["InvoiceDate"];
                            newRow["Customer"] = row["Cust_Name"];
                            newRow["Project"] = row["ProjectName"];
                            newRow["Sales_Agent"] = row["Sales_Agent"];
                            newRow["Status"] = row["Status"];
                            newRow["Due_Date"] = row["Expiry_Date"];

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
                        ViewState["Data"] = null;
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

        protected void linkbtnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    int _totalColumns = 10;//
                    string path = Image1.ImageUrl;

                    //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(10);//change
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;


                    Document _document = new Document(PageSize.A4, 0, 0, 0, 0);
                    _document.SetPageSize(PageSize.A4);
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
                        _pdfPTable.SetWidths(new float[] { 4f, 10f, 9f, 12f, 10f, 9f, 10f, 10f, 10f, 9f });//column width in doc       
                                                                                                           //----Header PDF--------------------------//
                                                                                                           //Company Logo
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 3;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPTable.AddCell(cell);

                        //...!..image logo..// 

                        phrase = new Phrase();
                        phrase.Add(new Chunk(lbladdCompany11.Text + "\n", FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lbladdress11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCity1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddDistrict1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddState1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        _pdfPCell = new PdfPCell(phrase);
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.BorderColor = BaseColor.WHITE;
                        _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.PaddingBottom = 1f;
                        _pdfPCell.PaddingTop = 0f;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("InvoiceList", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //-------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 4;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();


                        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*-------------------------------------", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = ViewInvoiceDetails();
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("InvoiceNo", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Amount", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("InvoiceDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);


                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Customer", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Project", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("SalesAgent", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Status", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ExpiryDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("CreateBy", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPTable.CompleteRow();
                        #endregion

                        #region "Table Body"
                        _fontStyle = FontFactory.GetFont("Tahoma", 10f, 0);
                        int serialnumber = 1;

                        foreach (DataRow row in _Vhrlist.Rows)
                        {
                            _pdfPCell = new PdfPCell(new Phrase(serialnumber++.ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["InvoiceNo"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["InvoiceTotalAmont"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["InvoiceDate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Cust_Name"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);


                            _pdfPCell = new PdfPCell(new Phrase(row["ProjectName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Sales_Agent"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Status"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Expiry_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Created_by"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
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
                        string PDFFileName = string.Format("InvoiceList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
                    int _totalColumns = 10;//
                    string path = Image1.ImageUrl;

                    //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(10);//change
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;


                    Document _document = new Document(PageSize.A4, 0, 0, 0, 0);
                    _document.SetPageSize(PageSize.A4);
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
                        _pdfPTable.SetWidths(new float[] { 4f, 10f, 9f, 12f, 10f, 9f, 10f, 10f, 10f, 9f });//column width in doc       
                                                                                                           //----Header PDF--------------------------//
                                                                                                           //Company Logo
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 3;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPTable.AddCell(cell);

                        //...!..image logo..// 

                        phrase = new Phrase();
                        phrase.Add(new Chunk(lbladdCompany11.Text + "\n", FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lbladdress11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCity1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddDistrict1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddState1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        _pdfPCell = new PdfPCell(phrase);
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.BorderColor = BaseColor.WHITE;
                        _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.PaddingBottom = 1f;
                        _pdfPCell.PaddingTop = 0f;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("InvoiceList", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //-------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 4;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();


                        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*-------------------------------------", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = (DataTable)ViewState["InvoiceData"];
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("InvoiceNo", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Amount", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("InvoiceDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);


                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Customer", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Project", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("SalesAgent", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Status", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ExpiryDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("CreateBy", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPTable.CompleteRow();
                        #endregion

                        #region "Table Body"
                        _fontStyle = FontFactory.GetFont("Tahoma", 10f, 0);
                        int serialnumber = 1;

                        foreach (DataRow row in _Vhrlist.Rows)
                        {
                            _pdfPCell = new PdfPCell(new Phrase(serialnumber++.ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["InvoiceNo"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["InvoiceTotalAmont"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["InvoiceDate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Cust_Name"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);


                            _pdfPCell = new PdfPCell(new Phrase(row["ProjectName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Sales_Agent"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Status"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Expiry_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Created_by"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
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
                        string PDFFileName = string.Format("InvoiceList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
        #endregion
    }
}