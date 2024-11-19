#region " Class Description "


#endregion

#region " Primary Namespaces "

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


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

using iTextSharp.text;
using iTextSharp.text.pdf;
using Color = iTextSharp.text.BaseColor;

using iTextSharp.tool.xml.html;
using Font = iTextSharp.text.Font;

using AjaxControlToolkit;
using System.Net.Mail;
using System.Net;
using System.Web.UI.WebControls;
using System.Web.UI;

#endregion

namespace MatoshreeProject
{
    public partial class LeaveAnalysis : System.Web.UI.Page
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
        public void Clear()
        {
            // txtStartDate.Text = string.Empty;
            //txtEndDate.Text = string.Empty;
            ddlYear.SelectedIndex = 0;
            ddlStaffName.SelectedIndex = 0;
            ddlMonth.SelectedIndex = 0;
        }

        protected void bindStaffName()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetStaffName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    ddlStaffName.DataSource = ds;
                    ddlStaffName.DataTextField = "First_Name";
                    ddlStaffName.DataValueField = "Staff_ID";
                    ddlStaffName.DataBind();
                    ddlStaffName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Staff Name", "0"));
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
        protected void BindYear()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetYear", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlYear.DataSource = ds.Tables[0];
                    ddlYear.DataTextField = "Year";
                    ddlYear.DataValueField = "Year";
                    ddlYear.DataBind();
                    ddlYear.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Year", "0"));
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
        public DataTable ViewLeaveAnalysisDetail()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewLeaveAnalysisDetails", con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);

                GridLeaveAnalysis.DataSource = table;
                GridLeaveAnalysis.DataBind();
                ViewState["CustData"] = table;

            }
            return table;
        }

        public DataTable ViewLeaveRequestDetailEmpID(int UserID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewLeaveAnalysisDetailsEmpID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Staff_ID", UserID);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridLeaveAnalysis.DataSource = table;
                GridLeaveAnalysis.DataBind();
                ViewState["CustData"] = table;
                
            }
            return table;
        }


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
            finally
            {
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
                            ViewLeaveAnalysisDetail();
                            GetCompanyAddress();

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
                            GetCompanyAddress();
                            BindYear();
                            bindStaffName();
                       
                            ViewLeaveRequestDetailEmpID(UserId);
                           

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
                            GetCompanyAddress();
                            BindYear();
                            bindStaffName();
                            ViewLeaveAnalysisDetail();
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


        protected void ddlStaffName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string departmentId = ddlStaffName.SelectedItem.Value;

                if (ddlStaffName.SelectedIndex == 0)
                {
                    ViewLeaveAnalysisDetail();

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
                        lblMessage.Visible = false;
                        lblMessage.Text = "Error Details Save Successfully";
                    }
                    else
                    {
                        lblMessage.Visible = false;
                        lblMessage.Text = "Error Details Not Save Successfully";
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
                    int _totalColumns = 7;//gridvie clumns
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(7);//change
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
                        _pdfPTable.SetWidths(new float[] { 3f, 8f, 6f, 7f, 7f, 5f, 4f });
                        //----Header PDF--------------------------//

                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 2;//change
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
                        _pdfPCell.Colspan = 5;
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
                        _pdfPCell.Colspan = 7;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = Color.BLACK;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("LeaveAnalysisReport", _fontStyle));
                        _pdfPCell.Colspan = 4;//change
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //-------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 3;
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
                        _Vhrlist = ViewLeaveAnalysisDetail();
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StaffName", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Role", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("InTime", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("OutTime", _fontStyle));
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

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("WorkHRs", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["StaffName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Role"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["InTime"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);




                            _pdfPCell = new PdfPCell(new Phrase(row["OutTime"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);



                            _pdfPCell = new PdfPCell(new Phrase(row["Remark"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["TotalHRS"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("LeaveAnalysisReport_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
                else if (RoleType == Designation)
                {
                    int _totalColumns = 7;//gridvie clumns
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(7);//change
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
                        _pdfPTable.SetWidths(new float[] { 3f, 8f, 6f, 7f, 7f, 5f, 4f });
                        //----Header PDF--------------------------//

                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 2;//change
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
                        _pdfPCell.Colspan = 5;
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
                        _pdfPCell.Colspan = 7;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = Color.BLACK;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("LeaveAnalysisReport", _fontStyle));
                        _pdfPCell.Colspan = 4;//change
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //-------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 3;
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
                        _Vhrlist = (DataTable)ViewState["CustData"];
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StaffName", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Role", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("InTime", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("OutTime", _fontStyle));
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

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("WorkHRs", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["StaffName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Role"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["InTime"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);




                            _pdfPCell = new PdfPCell(new Phrase(row["OutTime"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);



                            _pdfPCell = new PdfPCell(new Phrase(row["Remark"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = Color.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["TotalHRS"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("LeaveAnalysisReport_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
                        lblMessage.Visible = false;
                        lblMessage.Text = "Error Details Save Successfully";
                    }
                    else
                    {
                        lblMessage.Visible = false;
                        lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }
        }
        protected void lnkbtnExcel_Click(object sender, EventArgs e)
        {
            RoleType = Session["LoginType"].ToString();
            Designation = Session["Role"].ToString();
            UserId = Convert.ToInt32(Session["UserID"]);
            if (Session["LoginType"].ToString() == "Administrator")
            {
                DataTable dt = ViewLeaveAnalysisDetail();
                if (dt != null && dt.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment;filename=LeaveAnalysisReport.xls");

                    Response.Charset = " ";


                    DataTable dtExport = new DataTable();
                    dtExport.Columns.Add("ID");
                    dtExport.Columns.Add("StaffName");
                    dtExport.Columns.Add("Role");
                    dtExport.Columns.Add("InTime");
                    dtExport.Columns.Add("OutTime");
                    dtExport.Columns.Add("Remark");
                    dtExport.Columns.Add("WorkHRs");
                    dtExport.Columns.Add("Status");


                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow newRow = dtExport.NewRow();
                        newRow["ID"] = row["ID"];
                        newRow["StaffName"] = row["StaffName"];
                        newRow["Role"] = row["Role"];
                        newRow["InTime"] = row["InTime"];
                        newRow["OutTime"] = row["OutTime"];
                        newRow["Remark"] = row["Remark"];
                        newRow["WorkHRs"] = row["TotalHRS"];
                        newRow["Status"] = row["Status"];
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
            else if (RoleType == Designation)
            {
                DataTable dt = (DataTable)ViewState["CustData"];
                if (dt != null && dt.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment;filename=LeaveAnalysisReport.xls");

                    Response.Charset = " ";


                    DataTable dtExport = new DataTable();
                    dtExport.Columns.Add("ID");
                    dtExport.Columns.Add("StaffName");
                    dtExport.Columns.Add("Role");
                    dtExport.Columns.Add("InTime");
                    dtExport.Columns.Add("OutTime");
                    dtExport.Columns.Add("Remark");
                    dtExport.Columns.Add("WorkHRs");
                    dtExport.Columns.Add("Status");


                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow newRow = dtExport.NewRow();
                        newRow["ID"] = row["ID"];
                        newRow["StaffName"] = row["StaffName"];
                        newRow["Role"] = row["Role"];
                        newRow["InTime"] = row["InTime"];
                        newRow["OutTime"] = row["OutTime"];
                        newRow["Remark"] = row["Remark"];
                        newRow["WorkHRs"] = row["TotalHRS"];
                        newRow["Status"] = row["Status"];
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
            else
            {
                Response.Redirect("~/Expired.html", true);
            }

        }

        protected void GridLeaveAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    System.Web.UI.WebControls.Label lblStaffID = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblStaffID");
                    System.Web.UI.WebControls.Label lblRemark = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblRemark");
                    System.Web.UI.WebControls.Label lblStaffName1 = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblStaffName1");
                    System.Web.UI.WebControls.Label lblInTime1 = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblInTime1");
                    System.Web.UI.WebControls.Label lblOutTime1 = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblOutTime1");
                    System.Web.UI.WebControls.Label lblRole1 = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblRole1");
                    System.Web.UI.WebControls.Label lblTotalHours = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblTotalHours");
                    System.Web.UI.WebControls.Label lblDuration1 = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblDuration1");

                    string staffid = lblStaffID.Text;
                    string Remark = lblRemark.Text;
                    string Duration1 = lblDuration1.Text;
                    double DurationLeave, HalfTOleaveDays = 0, MonthlyDurationLeave, MonthlyDuration = 1.5;
                    int TotalLeave, YourLeave, HalfDayCount;

                    DateTime IntimeLeave, stratdate;

                    double totalFinalYearlyLeaveCount, totalFinalMonthlyLeaveCount;
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {

                        SqlCommand command = new SqlCommand("SP_GetTotalLeaveCount", con);
                        command.CommandType = CommandType.StoredProcedure;

                        con.Open();
                        int totalLeaveCount = (int)command.ExecuteScalar();
                        TotalLeave = totalLeaveCount;

                    }

                    using (SqlConnection con11 = new SqlConnection(strconnect))
                    {

                        SqlCommand command = new SqlCommand("SP_GetLeaveMonthlyDurationByStaffid", con11);
                        command.CommandType = CommandType.StoredProcedure;
                        con11.Open();
                        command.Parameters.AddWithValue("@Staffid", staffid);

                        MonthlyDurationLeave = (double)command.ExecuteScalar();
                        con11.Close();
                    }

                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {

                        SqlCommand command = new SqlCommand("SP_GetLeaveDurationByStaffid", con1);
                        command.CommandType = CommandType.StoredProcedure;
                        con1.Open();
                        command.Parameters.AddWithValue("@Staffid", staffid);
                        DurationLeave = (double)command.ExecuteScalar();
                        con1.Close();
                    }

                    using (SqlConnection con2 = new SqlConnection(strconnect))
                    {

                        SqlCommand command = new SqlCommand("SP_GetLeaveMaxStratDateByStaffid", con2);
                        command.CommandType = CommandType.StoredProcedure;
                        con2.Open();
                        command.Parameters.AddWithValue("@Staffid", staffid);
                        IntimeLeave = (DateTime)command.ExecuteScalar();

                        con2.Close();
                    }


                    using (SqlConnection con3 = new SqlConnection(strconnect))
                    {

                        SqlCommand command = new SqlCommand("SP_GetLeaveHalfDayByStaffid", con3);
                        command.CommandType = CommandType.StoredProcedure;
                        con3.Open();
                        command.Parameters.AddWithValue("@Staffid", staffid);
                        HalfDayCount = (int)command.ExecuteScalar();
                        con3.Close();
                    }


                    using (SqlConnection con4 = new SqlConnection(strconnect))
                    {
                        SqlCommand command = new SqlCommand("SP_GetTotalLeaveDayCount", con4);
                        command.CommandType = CommandType.StoredProcedure;
                        con4.Open();
                        command.Parameters.AddWithValue("@Staffid", Convert.ToInt32(staffid));
                        SqlDataAdapter sda = new SqlDataAdapter(command);
                        YourLeave = (int)command.ExecuteScalar();
                        int totalLeaveCount1 = Convert.ToInt32(TotalLeave);
                        double totalLeaveCount12 = Convert.ToDouble(totalLeaveCount1);
                        int YourLeaveCount = Convert.ToInt32(YourLeave);
                        string FinalIntime = Convert.ToString(IntimeLeave);

                        string InTime = lblInTime1.Text;
                        if (Remark == "HalfDay")
                        {
                            int fullLeaves = HalfDayCount / 2;
                            int remainingHalfDays = HalfDayCount % 2;

                            HalfTOleaveDays = fullLeaves + (remainingHalfDays * 0.5);

                        }
                        totalFinalMonthlyLeaveCount = MonthlyDurationLeave + HalfTOleaveDays;
                        totalFinalYearlyLeaveCount = DurationLeave + HalfTOleaveDays;
                        //Monthly highlite record 

                        using (SqlConnection con21 = new SqlConnection(strconnect))
                        {
                            SqlCommand cmd = new SqlCommand("SP_GetLeaveStratDateByStaffid", con21);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            SqlDataAdapter adt = new SqlDataAdapter(cmd);
                            cmd.Parameters.AddWithValue("@Staffid", staffid);
                            DataTable dt = new DataTable();
                            adt.Fill(dt);



                            for (int i = 0; i < dt.Rows.Count; i++)
                            {

                                string stratdate1 = dt.Rows[i]["Intime"].ToString();

                                if (totalFinalMonthlyLeaveCount >= MonthlyDuration && lblInTime1.Text == stratdate1)
                                {

                                    lblRemark.ForeColor = System.Drawing.Color.Orange;
                                    lblStaffName1.ForeColor = System.Drawing.Color.Orange;
                                    lblInTime1.ForeColor = System.Drawing.Color.Orange;
                                    lblOutTime1.ForeColor = System.Drawing.Color.Orange;
                                    lblRole1.ForeColor = System.Drawing.Color.Orange;
                                    lblTotalHours.ForeColor = System.Drawing.Color.Orange;

                                }
                                else
                                {

                                }
                            }

                            con21.Close();
                        }
                        //Yearly highlite record 
                        if (totalFinalYearlyLeaveCount >= totalLeaveCount12 && lblInTime1.Text == FinalIntime)
                        {

                            lblRemark.ForeColor = System.Drawing.Color.Red;
                            lblStaffName1.ForeColor = System.Drawing.Color.Red;
                            lblInTime1.ForeColor = System.Drawing.Color.Red;
                            lblOutTime1.ForeColor = System.Drawing.Color.Red;
                            lblRole1.ForeColor = System.Drawing.Color.Red;
                            lblTotalHours.ForeColor = System.Drawing.Color.Red;


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
        protected void btnview_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = Convert.ToInt32(((sender as LinkButton).NamingContainer as GridViewRow).RowIndex);
                GridViewRow row = GridLeaveAnalysis.Rows[rowIndex];

                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);

                string StaffID;
                var rows = GridLeaveAnalysis.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row1 = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                StaffID = ((System.Web.UI.WebControls.Label)rows[rowindex].FindControl("lblStaffID")).Text;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GETLeaveAnalysisByStaffID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@StaffID", StaffID);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblempname.Text = dt.Rows[0]["StaffName"].ToString();
                    }
                }

                //-------------Attendance----------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetPresentStaffByStaffID", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StaffID", StaffID);
                    int Attendance = (int)command.ExecuteScalar();

                    lblAttendanceCount.Text = Convert.ToString(Attendance);
                }

                //-------------SickLeaveCount----------------------//Attendance
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetSickLeaveByStaffID", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StaffID", StaffID);
                    int SickLeaveCount = (int)command.ExecuteScalar();

                    lblSickLeaveCount.Text = Convert.ToString(SickLeaveCount);
                }

                ////-------------CasualLeaveCount----------------------//

                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetCasualLeaveByStaffID", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StaffID", StaffID);
                    int CasualLeaveCount = (int)command.ExecuteScalar();

                    lblCasualLeaveCount.Text = Convert.ToString(CasualLeaveCount);
                }
                ////-------------PaidCount----------------------//

                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetPaidByStaffID", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StaffID", StaffID);
                    int PaidCount = (int)command.ExecuteScalar();

                    lblPaidCount.Text = Convert.ToString(PaidCount);
                }
                ////-------------UnpaidCount----------------------//

                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetCasualLeaveByStaffID", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StaffID", StaffID);
                    int UnpaidCount = (int)command.ExecuteScalar();

                    lblUnpaidCount.Text = Convert.ToString(UnpaidCount);
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
            Clear();
        }

        protected void btnSearchRerort_Click(object sender, EventArgs e)
        {
            try
            {
                string StaffID;
                string StaffName;
                string month;
                string year;

                if (ddlStaffName.SelectedIndex == 0)
                {
                    StaffID = null;
                }
                else
                {

                    StaffID = Convert.ToString(ddlStaffName.SelectedItem.Value);
                }

                if (ddlMonth.SelectedIndex == 0)
                {
                    month = null;
                }
                else
                {

                    month = Convert.ToString(ddlMonth.SelectedItem.Value);
                }



                if (ddlYear.SelectedIndex == 0)
                {
                    year = null;
                }
                else
                {

                    year = Convert.ToString(ddlYear.SelectedValue);
                }

                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_SearchLeaveAnalysis", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 120;
                    cmd.Parameters.AddWithValue("@StaffId", StaffID);
                    cmd.Parameters.AddWithValue("@Month", month);
                    cmd.Parameters.AddWithValue("@Year", year);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    sda.Fill(dt);
                    GridLeaveAnalysis.DataSource = dt;
                    GridLeaveAnalysis.DataBind();

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
                        //    lblMessage.Visible = false;
                        //    lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }
        }

        #endregion

    }
}