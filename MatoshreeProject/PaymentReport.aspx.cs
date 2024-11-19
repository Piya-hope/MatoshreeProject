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
using System.Diagnostics.Contracts;

using System.Web.UI.DataVisualization.Charting;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.pdf.draw;
using Font = iTextSharp.text.Font;
using Color = iTextSharp.text.BaseColor;
using Paragraph = iTextSharp.text.Paragraph;
#endregion;

namespace MatoshreeProject
{
    public partial class PaymentReport : System.Web.UI.Page
    {
        #region " Class Level Variable "
        string strconnect = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
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

        #region " Protected Functions "


        #endregion

        #region " Private Functions "
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
        #endregion

        #region " Public Functions "
        public void GetCompanyAddress()
        {
            try
            {
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetCompanyDetailsByID", UserCon);
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
        protected void bindproject()
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
                    ddlProject.DataSource = ds.Tables[0];
                    ddlProject.DataTextField = "ProjectName";
                    ddlProject.DataValueField = "ID";
                    ddlProject.DataBind();
                    ddlProject.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Project", "0"));
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

        protected void bindprojectEmpID(int UserID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetProjectByStaffID", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", UserID);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlProject.DataSource = ds.Tables[0];
                    ddlProject.DataTextField = "ProjectName";
                    ddlProject.DataValueField = "ID";
                    ddlProject.DataBind();
                    ddlProject.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Project", "0"));
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
        public void BindCustomer()
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
                    ddlCustomer.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Customer", "0"));
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

        public void BindInvoice()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetInvoiceName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlInvoiceNumber.DataSource = ds.Tables[0];
                    ddlInvoiceNumber.DataTextField = "InvoiceNo";
                    ddlInvoiceNumber.DataValueField = "ID";
                    ddlInvoiceNumber.DataBind();
                    ddlInvoiceNumber.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Invoice Number", "0"));
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
        public void Clear()
        {
            
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            ddlCustomer.SelectedIndex = 0;
            ddlProject.SelectedIndex = 0;
            ddlInvoiceNumber.SelectedIndex = 0;
            ViewPaymentReportDetails();
        }
        public DataTable ViewPaymentReportDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewPaymentReport", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 120;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridPaymentReport.DataSource = table;
                GridPaymentReport.DataBind();

            }
            return table;
        }


        public DataTable ViewPaymentReportDetailsEmpID(int UserID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewPaymentReportEmpID", con);
                cmd.Parameters.AddWithValue("@EmpID", UserID);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 120;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridPaymentReport.DataSource = table;
                GridPaymentReport.DataBind();

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
                    command.Parameters.AddWithValue("@SubModule", "PaymentReport");
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
                            GetCompanyAddress();
                            BindCustomer();
                            bindproject();
                            BindInvoice();
                            ViewPaymentReportDetails();

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

                                //GridCustomer.Columns[9].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {                           
                            GetCompanyAddress();                    
                            BindCustomer();
                            bindprojectEmpID(UserId);
                            ViewPaymentReportDetailsEmpID(UserId);
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

                                ////GridCustomer.Columns[8].Visible = false;
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

                        if (!IsPostBack)
                        {
                          
                            GetCompanyAddress();
                            BindCustomer();
                            bindproject();
                            BindInvoice();
                            ViewPaymentReportDetails();
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
                                ViewPaymentReportDetails();
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
         protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int CustID = Convert.ToInt32(ddlCustomer.SelectedItem.Value);
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd1 = new SqlCommand("SP_GetProjectNameByCustID", conn);
                cmd1.Connection = conn;
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@CustID", CustID);
                using (SqlDataAdapter sda1 = new SqlDataAdapter(cmd1))
                {
                    DataSet ds = new DataSet();
                    sda1.Fill(ds);
                    ddlProject.DataSource = ds.Tables[0];
                    ddlProject.DataTextField = "ProjectName";
                    ddlProject.DataValueField = "ID";
                    ddlProject.DataBind();
                    ddlProject.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Project", "0"));             
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
       
        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ProjectID = Convert.ToInt32(ddlProject.SelectedItem.Value);
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_InvoiceNameByProjectID", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlInvoiceNumber.DataSource = ds.Tables[0];
                    ddlInvoiceNumber.DataTextField = "InvoiceNo";
                    ddlInvoiceNumber.DataValueField = "ID";
                    ddlInvoiceNumber.DataBind();
                    ddlInvoiceNumber.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select InvoiceNumber", "0"));
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear(); 
        }

        protected void btnSearchRerort_Click(object sender, EventArgs e)
        
        {
            try
            {
                string Invoice;
                string customer;
                string project;
                string startDate;
                string endDate;

                if (ddlInvoiceNumber.SelectedIndex == 0)
                {
                    Invoice = null;
                }
                else
                {
                    Invoice = ddlInvoiceNumber.SelectedItem.Text;
                }

                if (ddlCustomer.SelectedIndex == 0)
                {
                    customer = null;
                }
                else
                {
                    customer = ddlCustomer.SelectedItem.Value;
                }

                if (ddlProject.SelectedIndex == 0)
                {
                    project = null;
                }

                else
                {
                    project = ddlProject.SelectedItem.Value;
                }

                if (txtEndDate.Text == "" && txtStartDate.Text == "")
                {
                    startDate = null;
                    endDate = null;
                }
                else if (txtStartDate.Text == "")
                {
                    startDate = null;
                    endDate = txtEndDate.Text;
                }
                else if (txtEndDate.Text == "")
                {
                    startDate = txtStartDate.Text;
                    endDate = null;
                }
                else
                {
                    startDate = txtStartDate.Text;
                    endDate = txtEndDate.Text;
                }

                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_SearchPaymentReport", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 120;
                    cmd.Parameters.AddWithValue("@Customer", customer);
                    cmd.Parameters.AddWithValue("@Project", project);
                    cmd.Parameters.AddWithValue("@InvoiceNumber", Invoice);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridPaymentReport.DataSource = dt;
                    GridPaymentReport.DataBind();

                }
                //Clear();
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

        protected void lnkbtnExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = ViewPaymentReportDetails();
            if (dt != null && dt.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/ms-excel";
                //Response.AddHeader("Content-Disposition", "attachment;filename=PaymentReport.xls");
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "PaymentReport " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));

                Response.Charset = " ";

                DataTable dtExport = new DataTable();
                dtExport.Columns.Add("ID");
                dtExport.Columns.Add("TransationID");
                dtExport.Columns.Add("PaymentDate");
                dtExport.Columns.Add("AmountRecived");
                dtExport.Columns.Add("Invoice"); 
                dtExport.Columns.Add("TotalAmount");
                dtExport.Columns.Add("InvoiceDate");
                dtExport.Columns.Add("AmountDeo");
                dtExport.Columns.Add("PaymentMode");
                dtExport.Columns.Add("Customer");
                dtExport.Columns.Add("Project");
              
                foreach (DataRow row in dt.Rows)
                {
                    DataRow newRow = dtExport.NewRow();
                    newRow["ID"] = row["ID"];
                    newRow["TransationID"] = row["Transation_ID"];
                    newRow["PaymentDate"] = row["Payment_date"];
                    newRow["AmountRecived"] = row["Amount_Recived"];
                    newRow["Invoice"] = row["InvoiceNo"];
                    newRow["TotalAmount"] = row["TotalAmount"];
                    newRow["InvoiceDate"] = row["InvoiceDate"];
                    newRow["AmountDeo"] = row["AmountDeo"];
                    newRow["PaymentMode"] = row["Payment_Mode"];
                    newRow["Customer"] = row["Cust_Name"];
                    newRow["Project"] = row["ProjectName"];

                    dtExport.Rows.Add(newRow);


                }

                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                GridView gridView = new GridView();
                gridView.DataSource = dtExport;
                gridView.DataBind();

                gridView.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();
            }
        }

       

        protected void linkbtnPDF_Click(object sender, EventArgs e)
        {
            try          
            {
                //if (Session["LoginType"].ToString() == "Administrator")
                //{
                int _totalColumns = 11;//gridvie clumns
                string path = Image1.ImageUrl;
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                Font _fontStyle;
                PdfPTable _pdfPTable = new PdfPTable(11);//change
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
                    _pdfPTable.SetWidths(new float[] { 3f, 7f, 7f, 5f, 7f, 5f, 7f, 6f, 5f, 5f, 5f });//column width in doc       
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
                    _pdfPCell.Colspan = 11;
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
                    _pdfPCell.Colspan = 11;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.Border = 2;
                    _pdfPCell.BorderColorBottom = Color.BLACK;
                    _pdfPCell.BackgroundColor = Color.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 4;
                    _pdfPTable.AddCell(_pdfPCell);
                    _pdfPTable.CompleteRow();

                    _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                    _pdfPCell = new PdfPCell(new Phrase("PaymentReport", _fontStyle));
                    _pdfPCell.Colspan = 7;
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
                    _Vhrlist = ViewPaymentReportDetails();
                    #region "Table Header"
                   
                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("TransationID", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("PaymentDate", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("RecivedAmt", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("Invoice", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("InvoiceAmt", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("InvoiceDate", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("AmtDeo", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);
                   
                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("PaymentMode", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("Customer", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("Project", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _pdfPTable.CompleteRow();
                    #endregion

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

                        _pdfPCell = new PdfPCell(new Phrase(row["Transation_ID"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["Payment_date"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);


                        BaseFont bf11 = BaseFont.CreateFont("c:/windows/fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        Font font11 = new Font(bf11, 10);
                        Chunk chunkRupee11 = new Chunk(" \u20B9 ", font11);

                        Chunk Amount_Recivedchnk = new Chunk(row["Amount_Recived"].ToString(), _fontStyle);
                        Phrase Amount_RecivedPh6 = new Phrase
                        {
                        chunkRupee11,
                        Amount_Recivedchnk
                         };
                        _pdfPCell = new PdfPCell(Amount_RecivedPh6);
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        //_pdfPCell = new PdfPCell(new Phrase(row["Amount_Recived"].ToString(), _fontStyle));
                        //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        //_pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //_pdfPCell.BackgroundColor = Color.WHITE;
                        //_pdfPCell.ExtraParagraphSpace = 1;
                        //_pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["InvoiceNo"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);


                        BaseFont bf1 = BaseFont.CreateFont("c:/windows/fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        Font font = new Font(bf1, 10);
                        Chunk chunkRupee = new Chunk(" \u20B9 ", font);

                        Chunk InvoiceAmontchnk = new Chunk(row["TotalAmount"].ToString(), _fontStyle);
                        Phrase InvoiceAmontPh6 = new Phrase
                        {
                        chunkRupee,
                        InvoiceAmontchnk
                         };
                        _pdfPCell = new PdfPCell(InvoiceAmontPh6);
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor =Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);




                        //_pdfPCell = new PdfPCell(new Phrase(row["TotalAmount"].ToString(), _fontStyle));
                        //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        //_pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //_pdfPCell.BackgroundColor = Color.WHITE;
                        //_pdfPCell.ExtraParagraphSpace = 1;
                        //_pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["InvoiceDate"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);


                        BaseFont bf12 = BaseFont.CreateFont("c:/windows/fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        Font font1 = new Font(bf12, 10);
                        Chunk chunkRupee1 = new Chunk(" \u20B9 ", font1);

                        Chunk AmountDeochnk = new Chunk(row["AmountDeo"].ToString(), _fontStyle);
                        Phrase AmountDeoPh6 = new Phrase
                        {
                        chunkRupee1,
                        AmountDeochnk
                         };
                        _pdfPCell = new PdfPCell(AmountDeoPh6);
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                       

                        //_pdfPCell = new PdfPCell(new Phrase(row["AmountDeo"].ToString(), _fontStyle));
                        //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        //_pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //_pdfPCell.BackgroundColor = Color.WHITE;
                        //_pdfPCell.ExtraParagraphSpace = 1;
                        //_pdfPTable.AddCell(_pdfPCell);n 

                        _pdfPCell = new PdfPCell(new Phrase(row["Payment_Mode"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["Cust_Name"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["ProjectName"].ToString(), _fontStyle));
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
                    string PDFFileName = string.Format("PaymentReport_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + PDFFileName);
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();

                    //}
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

       #endregion
    }

}