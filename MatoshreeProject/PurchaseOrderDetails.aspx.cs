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
using System.Net.Mail;
using System.Net;
using Org.BouncyCastle.Asn1.Ocsp;
using DataTable = System.Data.DataTable;
#endregion

namespace MatoshreeProject
{
    public partial class PurchaseOrderDetails : System.Web.UI.Page
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

        string Size, Initial, ReceiptFor, Cash, Bank, reminder, filePath, fileName;

        string Day = Convert.ToString(DateTime.Today.Day);
        string year = Convert.ToString(DateTime.Today.Year);
        Double TenderTOTALAMONT;

        Double DiscountItem1 = 0, Adjustment1, TaxTotalItem1, SubtotalItem1;
        decimal TotalTEnderAmont;

        string DevEmail, DevPassword, DevPort, DevHost;
        string UserEmpName, Password, EmailID1, EmailIDCC, Designation1;
        string PurchaseOrderNo;
        string Leaveid;
        string PurchaseOrderID, chkReminder;

        Phrase phrase = null;

        private static String[] units = { "Zero", "One", "Two", "Three",
        "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
        "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
        "Seventeen", "Eighteen", "Nineteen" };
        private static String[] tens = { "", "", "Twenty", "Thirty", "Forty",
        "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
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
        public void Clear()
        {
            //txt_LongDescription.Text = string.Empty;
            //txt_Description.Text = string.Empty;
            //txt_Rate.Text = string.Empty;
            //txtHSNCode.Text = string.Empty;
            //ddlTax.SelectedIndex = -1;
            //ddlTax1.SelectedIndex = -1;

            //txtPOName.Text = string.Empty;
            //txtAmount.Text = string.Empty;
            //ddlCustomers.SelectedIndex = -1;
            //ddlProjects.SelectedIndex = -1;
            //ddlStatus.SelectedIndex = -1;
            //ddlSalesAgent.SelectedIndex = -1;
            //ddllocationcountry.SelectedIndex = -1;
            //ddllocationstate.SelectedIndex = -1;
            //ddllocationdistrict.SelectedIndex = -1;
            //ddllocationcity.SelectedIndex = -1;
            //txtaddressLine1.Text = string.Empty;
            //txtlocationflatno.Text = string.Empty;
            //txtlocationpincode.Text = string.Empty;

            //txtClientNote.Text = string.Empty;
            //txtTermsAndConditions.Text = string.Empty;
            txtDateNotified.Text = string.Empty;
            // txtDescription.Text = string.Empty;

            ddlreminderMember.SelectedIndex = -1;

            chksetRemainderforEmail.Checked = false;
            TextBox1.Text = string.Empty;
            txtNoteDescription.Text = string.Empty;
        }


        #endregion

        #region " Protected Functions "


        #endregion

        #region " Public Functions "

        #endregion

        #region " Protected Functions "
        public DataTable ViewProjectOrder()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewPurchaseOrder", con))
                {
                    ad.Fill(table);
                    GridSinglePurchaseOrderlist.DataSource = table;
                    GridSinglePurchaseOrderlist.DataBind();
                    ViewState["PurchaseOrderData"] = table;
                }
            }
            return table;
        }

        public DataTable ViewCustomerDetailsByEmpID(int UseID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_PurchaseOrderDetailsbyEmpID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", UseID);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridSinglePurchaseOrderlist.DataSource = table;
                GridSinglePurchaseOrderlist.DataBind();
                ViewState["PurchaseOrderData"] = table;
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
                    command.Parameters.AddWithValue("@SubModule", "PurchaseOrder");
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
                            ViewProjectOrder();
                            //CustomerCount();
                            // CustomerDetailReport();
                            GetCompanyAddress();

                            if (Create == "True")
                            {
                                //  addnew.Visible = true;
                                btn_CreatePurchaseOrder.Visible = true;
                            }
                            else
                            {
                                // addnew.Visible = false;
                                btn_CreatePurchaseOrder.Visible = false;
                            }

                            if (Edit == "True")
                            {

                                GridSinglePurchaseOrderlist.Columns[10].Visible = true;
                            }
                            else
                            {

                                GridSinglePurchaseOrderlist.Columns[10].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                GridSinglePurchaseOrderlist.Columns[11].Visible = true;
                            }
                            else
                            {

                                GridSinglePurchaseOrderlist.Columns[11].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {
                            ViewCustomerDetailsByEmpID(UserId);
                            //CustomerCountByEmpID(UserId);
                            // CustomerDetailReportByEmpID(UserId);
                            GetCompanyAddress();

                            if (Create == "True")
                            {
                                // addnew.Visible = true;
                                btn_CreatePurchaseOrder.Visible = true;
                            }
                            else
                            {
                                //addnew.Visible = false;
                                btn_CreatePurchaseOrder.Visible = false;
                            }

                            if (Edit == "True")
                            {

                                GridSinglePurchaseOrderlist.Columns[10].Visible = true;
                            }
                            else
                            {

                                GridSinglePurchaseOrderlist.Columns[10].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                GridSinglePurchaseOrderlist.Columns[11].Visible = true;
                            }
                            else
                            {

                                GridSinglePurchaseOrderlist.Columns[11].Visible = false;
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

        public static String ConvertAmount(double amount)
        {
            try
            {
                Int64 amount_int = (Int64)amount;
                Int64 amount_dec = (Int64)Math.Round((amount - (double)(amount_int)) * 100);
                if (amount_dec == 0)
                {
                    return Convert1(amount_int) + " Only Rupees.";
                }
                else
                {
                    return Convert1(amount_int) + " Point " + Convert1(amount_dec) + " Only Rupees.";
                }
            }
            catch (Exception e)
            {
                // TODO: handle exception  
            }
            return "";
        }
        public static String Convert1(Int64 i)
        {
            if (i < 20)
            {
                return units[i];
            }
            if (i < 100)
            {
                return tens[i / 10] + ((i % 10 > 0) ? " " + Convert1(i % 10) : "");
            }
            if (i < 1000)
            {
                return units[i / 100] + " Hundred"
                        + ((i % 100 > 0) ? " And " + Convert1(i % 100) : "");
            }
            if (i < 100000)
            {
                return Convert1(i / 1000) + " Thousand "
                + ((i % 1000 > 0) ? " " + Convert1(i % 1000) : "");
            }
            if (i < 10000000)
            {
                return Convert1(i / 100000) + " Lakh "
                        + ((i % 100000 > 0) ? " " + Convert1(i % 100000) : "");
            }
            if (i < 1000000000)
            {
                return Convert1(i / 10000000) + " Crore "
                        + ((i % 10000000 > 0) ? " " + Convert1(i % 10000000) : "");
            }
            return Convert1(i / 1000000000) + " Arab "
                    + ((i % 1000000000 > 0) ? " " + Convert1(i % 1000000000) : "");
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
                    lblMessage.Text = "Purchase Order Details Save Successfully";
                }
                else if (EdidDATA == "xcvfedit" && MSGdata == null)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Purchase Order Details Edit Successfully";
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
        public void SendEmail(string ProNamE)//DevEmail
        {
            try
            {
                //-----------------Accepting Email------------------------//
                GETCredentials();//method for domain password
                //GETProposalEmail(ProNamE);
                EmailID = Session["EmailID"].ToString();
                EmailID1 = lblEmailPO.Text;
                EmailIDCC = txtemailID.Text;
                //Designation1 = lblDesignation.Text;
                lblcustname.Text = ProNamE;
                string ProjectName = lblPOprojectname.Text;
                string ProposalNumber = lblProjectNameId.Text;
                UserEmpName = lblcustname.Text;
                //DataTable dt = new DataTable();
                //DataTable dt = Calculatefilldata();
                //Send Email User Password....//
                if (!string.IsNullOrEmpty(EmailID1))
                {
                    using (MailMessage mm = new MailMessage(DevEmail, EmailID1))
                    {

                        mm.Subject = "Purchase Order Request/Confirmation";
                        mm.CC.Add(new MailAddress(EmailIDCC));
                        // mm.Bcc.Add(new MailAddress(EmailID));

                        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                        string body = "Dear " + ProNamE + ",<br/>";
                        if (txtEmailWrite.Text == "")
                        {
                            body += "I am writing to formally  confirm a purchase order." + " <br/> " + " Please find the attached purchase order " + ProposalNumber + " for your reference. Kindly review the details and confirm receipt of this order. If there are any discrepancies or additional information required, do not hesitate to contact me. " + "<br/>";

                        }
                        else
                        {
                            body += txtEmailWrite.Text + ",<br/>";
                        }
                        body += "We look forward to your prompt confirmation and timely delivery." + "Thank you for your support and cooperation." + "<br/>";

                        body += "Best regards," + "<br/>";
                        body += UserEmpName + "<br />";
                        body += Designation1;



                       string urllocal= HttpUtility.HtmlEncode("https://crm.matoshreeinteriors.com/LogIn");
                        ///string url = HttpUtility.HtmlEncode("https://minteriors.lissomtech.in/LogIn");
                        body += "<html><body><br/><br/><a href=\"" + urllocal + "\">Click here to login </a></body></html>";
                        body += "<br /><br />Thanks";
                        mm.Body = body;
                        mm.IsBodyHtml = true;
                        mm.Priority = MailPriority.Normal;
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
        protected void btn_CreatePurchaseOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewPurchaseOrder.aspx");
        }

        protected void lnkbtnExcel_Click(object sender, EventArgs e)
        {

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

        //---------------------------------------------------------------
        //PurchaseOrderList_
        //-----------------------------------------------------
        protected void linkbtnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    //GetCompanyAddress();
                    int _totalColumns = 9;//
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(9);//change
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;


                    Document _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
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
                        _pdfPTable.SetWidths(new float[] { 4f, 13f, 13f, 9f, 14f, 15f, 14f, 15f, 13f });//column width in doc       
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
                        _pdfPCell.Colspan = 9;
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
                        _pdfPCell.Colspan = 9;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("PurchaseOrderList", _fontStyle));
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
                        _pdfPCell.Colspan = 3;
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
                        _Vhrlist = ViewProjectOrder();
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("PONumber", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("POName", _fontStyle));
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
                        _pdfPCell = new PdfPCell(new Phrase("PODate", _fontStyle));
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
                        _pdfPCell = new PdfPCell(new Phrase("ProjectName", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("POExpireDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);


                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StatusName", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["PONumber"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["POName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Amount"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["PODate"].ToString(), _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["POExpireDate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["StatusName"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("PurchaseOrderList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
                    int _totalColumns = 9;//
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(9);//change
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;


                    Document _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
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
                        _pdfPTable.SetWidths(new float[] { 4f, 13f, 13f, 9f, 14f, 15f, 14f, 15f, 13f });//column width in doc       
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
                        _pdfPCell.Colspan = 9;
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
                        _pdfPCell.Colspan = 9;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("PurchaseOrderList", _fontStyle));
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
                        _pdfPCell.Colspan = 3;
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
                        _Vhrlist = (DataTable)ViewState["PurchaseOrderData"];
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("PONumber", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("POName", _fontStyle));
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
                        _pdfPCell = new PdfPCell(new Phrase("PODate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Cust_Name", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ProjectName", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("POExpireDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);


                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StatusName", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["PONumber"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["POName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Amount"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["PODate"].ToString(), _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["POExpireDate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["StatusName"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("PurchaseOrderList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
                        SqlCommand cmd = new SqlCommand("SP_CustomerVisiblityDetails", con);
                        cmd.CommandTimeout = 600;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(table);
                        GridSinglePurchaseOrderlist.DataSource = table;
                        GridSinglePurchaseOrderlist.DataBind();
                        ViewState["PurchaseOrderData"] = table;
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

        }

        protected void GridSinglePurchaseOrderlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                foreach (GridViewRow gridviedrow in GridSinglePurchaseOrderlist.Rows)
                {
                    LinkButton LinkPONumber = (LinkButton)gridviedrow.FindControl("LinkPONumber");
                    Label lblAmount1 = (Label)gridviedrow.FindControl("lblAmount1");
                    Label lblContactPerson1 = (Label)gridviedrow.FindControl("lblContactPerson1");
                    Label lblPOExpireDate1 = (Label)gridviedrow.FindControl("lblPOExpireDate1");
                    Label lblProjectName1 = (Label)gridviedrow.FindControl("lblProjectName1");
                    Label lblStatusName1 = (Label)gridviedrow.FindControl("lblStatusName1");


                    string status = ((Label)gridviedrow.FindControl("lblStatusbit")).Text;
                    if (status == "True")
                    {
                        LinkPONumber.ForeColor = System.Drawing.Color.Blue;
                        lblAmount1.ForeColor = System.Drawing.Color.Blue;
                        lblContactPerson1.ForeColor = System.Drawing.Color.Blue;
                        lblPOExpireDate1.ForeColor = System.Drawing.Color.Blue;

                    }
                    else
                    {
                        LinkPONumber.ForeColor = System.Drawing.Color.Red;
                        lblAmount1.ForeColor = System.Drawing.Color.Red;
                        lblContactPerson1.ForeColor = System.Drawing.Color.Red;
                        lblPOExpireDate1.ForeColor = System.Drawing.Color.Red;


                    }


                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    DropDownList ddlStatus = (e.Row.FindControl("ddlStatus") as DropDownList);


                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_GetStatusname", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BelongTo", "PurchaseOrder");
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlStatus.DataSource = ds.Tables[0];
                        ddlStatus.DataTextField = "ProgessStatus";
                        ddlStatus.DataValueField = "Status_ID";
                        ddlStatus.DataBind();
                        ddlStatus.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Status", "0"));
                        //--------------------------------------------------------------------------------------------//
                        //Select the Country of Customer in DropDownList
                        string statusNm = (e.Row.FindControl("lblStatusName1") as Label).Text;
                        ddlStatus.Items.FindByText(statusNm).Selected = true;
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

        protected void Linkbtnedit_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = lblPurchaseID.Text;

                Response.Redirect("~/EditPurchaseOrder.aspx?ID=" + ID + "", false);
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

        //---------------------------------------------------------------
        //PurchaseOrder Receipt
        //-----------------------------------------------------
        protected void lnkbtnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                int ProjectID = Convert.ToInt32(lblProjectNameId.Text);
                GetCompanyAddress();
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")

                {
                    string path = Image1.ImageUrl;
                    DataTable table2 = new DataTable();
                    DataTable table13 = ViewPurchaseOrderServices(ProjectID);
                    DataTable table12 = ViewPurchaseOrderProcurement(ProjectID);

                    // DataTable TaxDatatable = ProposalTaxName(lblProposalNumber.Text);

                    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
                    MemoryStream memoryStream = new MemoryStream();
                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, memoryStream);

                    doc.Open();
                    //doc.Add(new Paragraph(" "));
                    PdfPTable table = new PdfPTable(2);
                    table.WidthPercentage = 100;
                    PdfPCell leftCell1 = new PdfPCell();
                    leftCell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
                    // iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(@"D:\Company\Matoshree\MatoshreeProject\MatoshreeProject\Img_logo\Logo.png");
                    image.ScaleToFit(100f, 100f);
                    leftCell1.AddElement(image);
                    table.AddCell(leftCell1);
                    Font Pagename = new Font(Font.FontFamily.HELVETICA, 16f, Font.BOLD);
                    Font Page1 = new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.RED);
                    Font Page2 = new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL);
                    Font Page3 = new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD);
                    Font Page3BLUE = new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLUE);
                    Font Page4 = new Font(Font.FontFamily.HELVETICA, 10f);
                    Font Page5 = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL);

                    Font Page5red = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.RED);
                    Font Page5orange = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.ORANGE);
                    Font Page5green = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.GREEN);
                    Font Page5blue = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.BLUE);

                    PdfPCell rightCell1 = new PdfPCell();
                    rightCell1.Border = PdfPCell.NO_BORDER;
                    rightCell1.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    Paragraph paragraph1 = new Paragraph("Purchase Order", Pagename);
                    paragraph1.Alignment = Element.ALIGN_RIGHT;
                    rightCell1.AddElement(paragraph1);
                    Paragraph paragraph2 = new Paragraph(lblPurchaseOrderidNO.Text, Page3BLUE);
                    paragraph2.Alignment = Element.ALIGN_RIGHT;
                    rightCell1.AddElement(paragraph2);
                    table.AddCell(rightCell1);

                    string status1 = btnStatus.Text;
                    Paragraph paragraph3 = new Paragraph();
                    if (status1 == "Declined")
                    {
                        paragraph3 = new Paragraph(btnStatus.Text, Page5red);
                        paragraph3.Alignment = Element.ALIGN_RIGHT;
                        rightCell1.AddElement(paragraph3);
                        table.AddCell(rightCell1);
                    }
                    else if (status1 == "Revised")
                    {
                        paragraph3 = new Paragraph(btnStatus.Text, Page5green);
                        paragraph3.Alignment = Element.ALIGN_RIGHT;
                        rightCell1.AddElement(paragraph3);
                        table.AddCell(rightCell1);
                    }
                    else if (status1 == "Open")
                    {
                        paragraph3 = new Paragraph(btnStatus.Text, Page5orange);
                        paragraph3.Alignment = Element.ALIGN_RIGHT;
                        rightCell1.AddElement(paragraph3);
                        table.AddCell(rightCell1);
                    }

                    else if (status1 == "Accepted")
                    {
                        paragraph3 = new Paragraph(btnStatus.Text, Page5blue);
                        paragraph3.Alignment = Element.ALIGN_RIGHT;
                        rightCell1.AddElement(paragraph3);
                        table.AddCell(rightCell1);
                    }

                    else
                    {
                        paragraph3 = new Paragraph(btnStatus.Text, Page5blue);
                        paragraph3.Alignment = Element.ALIGN_RIGHT;
                        rightCell1.AddElement(paragraph3);
                        table.AddCell(rightCell1);
                    }

                    doc.Add(table);
                    doc.Add(new Paragraph(" "));
                    // -------------------------------------------------Purchase Order---------------------------------------------------------
                    PdfPTable table1 = new PdfPTable(2);
                    table1.WidthPercentage = 100;
                    PdfPCell leftCell = new PdfPCell();
                    leftCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    leftCell.AddElement(new Paragraph("", new Font(Font.FontFamily.HELVETICA, 10f)));
                    leftCell.AddElement(new Paragraph(lbladdCompany11.Text, new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD)));
                    leftCell.AddElement(new Paragraph(lbladdress11.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    leftCell.AddElement(new Paragraph(lblcompanyaddCity1.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    leftCell.AddElement(new Paragraph(lblcompanyaddDistrict1.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    leftCell.AddElement(new Paragraph(lblcompanyaddState1.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    leftCell.AddElement(new Paragraph(lblcompanyaddCountry1.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    leftCell.AddElement(new Paragraph("PIN:" + lblcompanyaddZIPCode11.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    Chunk PhoneChunk = new Chunk("Phone No: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk PhoneValueChunk = new Chunk(lblphoneNo1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrase5 = new Phrase
                {
                  PhoneChunk,
                     PhoneValueChunk
                };
                    leftCell.AddElement(phrase5);
                    Chunk VatNoChunk = new Chunk("VAT No: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk VatNoValueChunk = new Chunk(lblVatNo1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrase6 = new Phrase
                  {
                     VatNoChunk,
                     VatNoValueChunk
                  };
                    leftCell.AddElement(phrase6);
                    Chunk GstNoChunk = new Chunk("GST No: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk GstNoValueChunk = new Chunk(lblGSTNo1A.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrase7 = new Phrase
                  {
                     GstNoChunk,
                     GstNoValueChunk
                  };
                    leftCell.AddElement(phrase7);
                    table1.AddCell(leftCell);

                    PdfPCell rightCell = new PdfPCell();
                    rightCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    Paragraph paragraph11 = new Paragraph("To,", Page3);
                    paragraph11.Alignment = Element.ALIGN_RIGHT;
                    rightCell.AddElement(paragraph11);

                    //Paragraph paragraph4 = new Paragraph(lblName1.Text, Page3);
                    //paragraph4.Alignment = Element.ALIGN_RIGHT;
                    //rightCell.AddElement(paragraph4);
                    Chunk Name1 = new Chunk(lblcustname.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Chunk Block = new Chunk(lblblock.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Chunk Address1 = new Chunk(lbladdressLine1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Chunk City1 = new Chunk(lblcompanyaddCity.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Chunk District1 = new Chunk(lblcompanyaddDistrict.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Chunk State1 = new Chunk(lblcompanyaddState.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Chunk ZipCode1 = new Chunk(lblcompanyaddZIPCode.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    // Chunk Phone1 = new Chunk(lblPhone1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    //Chunk Address8 = new Chunk(",", new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase ph1 = new Phrase
                    {
                        Name1,
                        Address1,
                        City1,
                        District1,
                        State1,
                        ZipCode1,
                       // Address8
                    };
                    Paragraph paragraphs1 = new Paragraph(ph1);
                    paragraphs1.Alignment = Element.ALIGN_RIGHT;
                    rightCell.AddElement(paragraphs1);

                    Chunk TenderDate = new Chunk("PO Date: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk TenderDatevalue = new Chunk(lblPOdate1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrase1 = new Phrase
                    {
                   TenderDate,
                   TenderDatevalue
                    };

                    Paragraph paragraph7 = new Paragraph(phrase1);
                    paragraph7.Alignment = Element.ALIGN_RIGHT;

                    rightCell.AddElement(paragraph7);

                    Chunk TenderExDate = new Chunk(" Expiry Date:: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk TenderExDatevalue = new Chunk(lblPOdate1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phraseEx = new Phrase
                    {
                   TenderExDate,
                   TenderExDatevalue
                    };

                    Paragraph paragraphEx = new Paragraph(phraseEx);
                    paragraphEx.Alignment = Element.ALIGN_RIGHT;

                    rightCell.AddElement(paragraphEx);

                    Chunk Projectname = new Chunk("Project Name: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk Projectnamevalue = new Chunk(lblPOprojectname.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrase4 = new Phrase
                    {
                    Projectname,
                    Projectnamevalue
                   };
                    Paragraph paragraph10 = new Paragraph(phrase4);
                    paragraph10.Alignment = Element.ALIGN_RIGHT;
                    rightCell.AddElement(paragraph10);


                    Chunk SaleAgent = new Chunk("Sale Agent: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk SaleAgentvalue = new Chunk(lblsaleagentName.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrase3 = new Phrase
                    {
                        SaleAgent,
                        SaleAgentvalue
                    };
                    Paragraph paragraph9 = new Paragraph(phrase3);
                    paragraph9.Alignment = Element.ALIGN_RIGHT;
                    rightCell.AddElement(paragraph9);

                    table1.AddCell(rightCell);
                    doc.Add(table1);
                    doc.Add(new Paragraph(" "));
                    //---------------------------------------------------------------------//
                    PdfPTable Invtable1C = new PdfPTable(1);
                    Invtable1C.WidthPercentage = 100;
                    PdfPCell InvleftCell1 = new PdfPCell();
                    InvleftCell1.HorizontalAlignment = Element.ALIGN_RIGHT;
                    Invtable1C.AddCell(InvleftCell1);
                    doc.Add(Invtable1C);
                    //---------------------------------------------------------------------//


                    //----------------------------------Rupees---------------------------------------------------//
                    BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    Font font = new Font(bf, 10);
                    Chunk chunkRupee = new Chunk(" \u20B9 ", font);
                    //---------------------------------------------------------Table-----------------------

                    PdfPTable Potable1 = new PdfPTable(1);
                    Potable1.WidthPercentage = 100;
                    PdfPCell PoleftCell = new PdfPCell();
                    PoleftCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    Chunk PO1 = new Chunk("Purchase Order Procurement List ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Phrase phraset1 = new Phrase
                    {
                      PO1

                    };

                    Paragraph paragrapht1 = new Paragraph(phraset1);
                    paragrapht1.Alignment = Element.ALIGN_LEFT;

                    PoleftCell.AddElement(paragrapht1);
                    Potable1.AddCell(PoleftCell);
                    doc.Add(Potable1);
                    doc.Add(new Paragraph(" "));

                    if (table12 != null && table12.Rows.Count > 0)
                    {
                        // Create a new DataTable with only the desired columns
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("Product");
                        dtExport.Columns.Add("Description");

                        dtExport.Columns.Add("Quantity");
                        dtExport.Columns.Add("Price");
                        dtExport.Columns.Add("Amount");



                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in table12.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();

                            newRow["Product"] = row["ProductName"];
                            newRow["Description"] = row["Description"];
                            newRow["Quantity"] = row["Quantity"];
                            newRow["Price"] = row["Price"];
                            newRow["Amount"] = row["TotalAmont"];


                            dtExport.Rows.Add(newRow);
                            table2 = dtExport;
                        }

                        float[] columnWidths = new float[table2.Columns.Count];
                        for (int i = 0; i < table2.Columns.Count; i++)
                        {
                            if (table2.Columns[i].ColumnName == "Description")
                            {
                                columnWidths[i] = 9f;
                            }
                            else if (table2.Columns[i].ColumnName == "ProductName")
                            {
                                columnWidths[i] = 3f;
                            }
                            else if (table2.Columns[i].ColumnName == "TotalAmont")
                            {
                                columnWidths[i] = 4f;
                            }
                            else
                            {
                                columnWidths[i] = 3f;
                            }
                        }
                        Font tableHeaderFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.WHITE);
                        Font tableDataFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL);
                        PdfPTable pdfTable = new PdfPTable(table2.Columns.Count);
                        pdfTable.SetWidths(columnWidths);
                        pdfTable.WidthPercentage = 100;
                        foreach (DataColumn column in table2.Columns)
                        {
                            string columnName = (column.ColumnName == "ID") ? "#" : column.ColumnName;

                            PdfPCell pdfCell = new PdfPCell(new Phrase(columnName, tableHeaderFont));
                            pdfCell.BackgroundColor = new BaseColor(85, 85, 85);
                            pdfCell.Padding = 6;
                            pdfTable.AddCell(pdfCell);
                        }
                        foreach (DataRow row in table2.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                PdfPCell dataCell = new PdfPCell(new Phrase(item.ToString(), tableDataFont));
                                dataCell.Padding = 6;
                                pdfTable.AddCell(dataCell);
                            }
                        }
                        doc.Add(pdfTable);
                    }

                    //doc.Add(new Paragraph(" "));

                    PdfPTable labelsTable1 = new PdfPTable(1);
                    labelsTable1.WidthPercentage = 100;
                    PdfPCell labelCell1 = new PdfPCell();
                    labelCell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    Chunk TotalTax = new Chunk("Total Purchase Order Amount :", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk TotalTaxspace = new Chunk("   "); // Add spaces as needed
                    Chunk TotalTaxvalue = new Chunk(lblTotalAmountProcurement.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phraseTotalTax = new Phrase
                {
                    TotalTax,
                    TotalTaxspace,
                    chunkRupee,
                    TotalTaxvalue
                };
                    Paragraph paragraphTotalTax = new Paragraph(phraseTotalTax);
                    paragraphTotalTax.Alignment = Element.ALIGN_RIGHT;
                    labelCell1.AddElement(paragraphTotalTax);
                    labelCell1.HorizontalAlignment = Element.ALIGN_RIGHT;
                    labelCell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                    labelsTable1.AddCell(labelCell1);
                    doc.Add(labelsTable1);
                    // doc.Add(new Paragraph(" "));

                    //  ================================================table2======================================================

                    PdfPTable Potable2 = new PdfPTable(1);
                    Potable1.WidthPercentage = 100;
                    PdfPCell PoleftCel1 = new PdfPCell();
                    PoleftCel1.Border = iTextSharp.text.Rectangle.NO_BORDER;


                    Chunk PO2 = new Chunk("Purchase Order Services List", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Phrase phraset2 = new Phrase
                    {
                      PO2

                    };

                    Paragraph paragrapht2 = new Paragraph(phraset2);
                    paragrapht2.Alignment = Element.ALIGN_LEFT;
                    paragrapht2.Alignment = Element.ALIGN_JUSTIFIED;
                    PoleftCel1.AddElement(paragrapht2);
                    Potable2.AddCell(PoleftCel1);
                    doc.Add(Potable2);
                    doc.Add(new Paragraph(" "));

                    if (table13 != null && table13.Rows.Count > 0)
                    {
                        // Create a new DataTable with only the desired columns
                        DataTable dtExport1 = new DataTable();
                        dtExport1.Columns.Add("Services");
                        dtExport1.Columns.Add("Duration/Day");
                        dtExport1.Columns.Add("Description");
                        dtExport1.Columns.Add("Quantity");
                        dtExport1.Columns.Add("Price");
                        dtExport1.Columns.Add("Amount");


                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in table13.Rows)
                        {
                            DataRow newRow = dtExport1.NewRow();

                            newRow["Services"] = row["ServiceName"];
                            newRow["Duration/Day"] = row["Duration"];
                            newRow["Description"] = row["Description"];
                            newRow["Quantity"] = row["Quantity"];
                            newRow["Price"] = row["Price"];
                            newRow["Amount"] = row["TotalAmont"];

                            dtExport1.Rows.Add(newRow);
                            table2 = dtExport1;
                        }

                        float[] columnWidths = new float[table2.Columns.Count];
                        for (int i = 0; i < table2.Columns.Count; i++)
                        {
                            if (table2.Columns[i].ColumnName == "Description")
                            {
                                columnWidths[i] = 9f;
                            }
                            else if (table2.Columns[i].ColumnName == "ServiceName")
                            {
                                columnWidths[i] = 3f;
                            }

                            else if (table2.Columns[i].ColumnName == "Quantity")
                            {
                                columnWidths[i] = 2f;
                            }
                            else if (table2.Columns[i].ColumnName == "TotalAmont")
                            {
                                columnWidths[i] = 4f;
                            }
                            else
                            {
                                columnWidths[i] = 3f;
                            }
                        }
                        Font tableHeaderFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.WHITE);
                        Font tableDataFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL);
                        PdfPTable pdfTable = new PdfPTable(table2.Columns.Count);
                        pdfTable.SetWidths(columnWidths);
                        pdfTable.WidthPercentage = 100;
                        foreach (DataColumn column in table2.Columns)
                        {
                            string columnName = (column.ColumnName == "ID") ? "#" : column.ColumnName;

                            PdfPCell pdfCell = new PdfPCell(new Phrase(columnName, tableHeaderFont));
                            pdfCell.BackgroundColor = new BaseColor(85, 85, 85);
                            pdfCell.Padding = 6;
                            pdfTable.AddCell(pdfCell);
                        }
                        foreach (DataRow row in table2.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                PdfPCell dataCell = new PdfPCell(new Phrase(item.ToString(), tableDataFont));
                                dataCell.Padding = 6;
                                pdfTable.AddCell(dataCell);
                            }
                        }
                        doc.Add(pdfTable);
                    }

                    // doc.Add(new Paragraph(" "));


                    PdfPTable labelsTableTSA = new PdfPTable(1);
                    labelsTableTSA.WidthPercentage = 100;
                    PdfPCell labelCellTSA = new PdfPCell();
                    labelCellTSA.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    Chunk subtotal = new Chunk("Total Services Amount:", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk subtotalspace = new Chunk("   "); // Add spaces as needed
                    Chunk subtotalvalue = new Chunk(lblTotalServiceAmount.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrase13 = new Phrase
                {
                    subtotal,
                    subtotalspace,
                    chunkRupee,
                    subtotalvalue
                };
                    Paragraph paragraph12 = new Paragraph(phrase13);
                    paragraph12.Alignment = Element.ALIGN_RIGHT;
                    labelCellTSA.AddElement(paragraph12);
                    labelCellTSA.HorizontalAlignment = Element.ALIGN_RIGHT;
                    labelCellTSA.BackgroundColor = BaseColor.LIGHT_GRAY;
                    labelsTableTSA.AddCell(labelCellTSA);
                    doc.Add(labelsTableTSA);
                    doc.Add(new Paragraph(" "));




                    //---------Add Total:-----------------------------------
                    PdfPTable Potable4 = new PdfPTable(1);
                    Potable4.WidthPercentage = 100;
                    PdfPCell PoleftCell4 = new PdfPCell();
                    PoleftCell4.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    Chunk PO3 = new Chunk("Purchase Order Costing", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Phrase phrasel1 = new Phrase
                    {
                      PO3

                    };

                    Paragraph paragraphl1 = new Paragraph(phrasel1);
                    paragraphl1.Alignment = Element.ALIGN_LEFT;

                    PoleftCell4.AddElement(paragraphl1);
                    Potable4.AddCell(PoleftCell4);
                    doc.Add(Potable4);
                    doc.Add(new Paragraph(" "));
                    //---------------------------------------------------------------------//
                    PdfPTable Invtable2C = new PdfPTable(1);
                    Invtable2C.WidthPercentage = 100;
                    PdfPCell InvleftCell2 = new PdfPCell();
                    InvleftCell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                    Invtable2C.AddCell(InvleftCell2);
                    doc.Add(Invtable2C);
                    //---------------------------------------------------------------------//
                    //---------POTotalCost:----------------------------------

                    PdfPTable Potable5 = new PdfPTable(1);
                    Potable5.WidthPercentage = 100;
                    PdfPCell PoleftCell5 = new PdfPCell();
                    PoleftCell5.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    Chunk PO5 = new Chunk("Purchase Order Costing:", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk Grandtotalspace = new Chunk("   "); // Add spaces as needed
                    Chunk Grandtotalvalue = new Chunk(lblTotalAmountProcu.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrasel5 = new Phrase
                    {
                      PO5,
                      Grandtotalspace,
                      Grandtotalvalue
                    };

                    Paragraph paragraphl5 = new Paragraph(phrasel5);
                    paragraphl5.Alignment = Element.ALIGN_LEFT;

                    PoleftCell5.AddElement(paragraphl5);
                    Potable5.AddCell(PoleftCell5);
                    doc.Add(Potable5);
                    doc.Add(new Paragraph(" "));


                    //---------POTotalCost:----------------------------------

                    PdfPTable Potable6 = new PdfPTable(1);
                    Potable6.WidthPercentage = 100;
                    PdfPCell PoleftCell6 = new PdfPCell();
                    PoleftCell6.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    Chunk PO6 = new Chunk("Total Purchase Order Cost :", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk GrandtotalAmtspace = new Chunk("   "); // Add spaces as needed
                    Chunk GrandtotalAmtvalue = new Chunk(lblTotalProjectCost.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrasel6 = new Phrase
                    {
                      PO6,
                      GrandtotalAmtspace,
                      GrandtotalAmtvalue
                    };

                    Paragraph paragraphl6 = new Paragraph(phrasel6);
                    paragraphl6.Alignment = Element.ALIGN_LEFT;
                    PoleftCell6.BackgroundColor = BaseColor.LIGHT_GRAY;
                    PoleftCell6.AddElement(paragraphl6);
                    Potable6.AddCell(PoleftCell6);

                    doc.Add(Potable6);
                    doc.Add(new Paragraph(" "));

                    //---Invoice Total in Words-------------------------------//
                    string TotalPOCost1 = lblTotalProjectCost.Text;
                    string TotalPOCost = TotalPOCost1.Replace("₹", "").Trim();

                    PdfPTable InvoiceCostInword = new PdfPTable(1);
                    InvoiceCostInword.WidthPercentage = 100;
                    PdfPCell invoiceWord = new PdfPCell();
                    invoiceWord.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    double invTotalAmount1 = Convert.ToDouble(TotalPOCost);
                    string number = ConvertAmount(invTotalAmount1);
                    Chunk Inword = new Chunk("In words: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk Inwordvalue = new Chunk(number, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phraseInword = new Phrase
                 {
                  Inword,
                 Inwordvalue
                 };
                    Paragraph paraInword = new Paragraph(phraseInword);
                    paraInword.Alignment = Element.ALIGN_LEFT;
                    invoiceWord.AddElement(paraInword);

                    InvoiceCostInword.AddCell(invoiceWord);

                    doc.Add(InvoiceCostInword);
                    doc.Add(new Paragraph(" "));
                    //-----------------------------------------------------------------------------------------------//
                    //Note & Term Conditions
                    PdfPTable NoteTable = new PdfPTable(1);
                    NoteTable.WidthPercentage = 100;
                    PdfPCell NoteCell = new PdfPCell();
                    NoteCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    NoteCell.AddElement(new Paragraph("Note", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD)));
                    NoteCell.AddElement(new Paragraph(lblNote1.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    NoteCell.AddElement(new Paragraph("  "));
                    NoteCell.AddElement(new Paragraph("Terms & Condition :", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD)));
                    NoteCell.AddElement(new Paragraph(lbltermsandcodition.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    NoteCell.AddElement(new Paragraph("  "));
                    NoteCell.AddElement(new Paragraph("Thank You", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD)));
                    NoteTable.AddCell(NoteCell);
                    doc.Add(NoteTable);
                    doc.Add(new Paragraph(" "));

                    doc.Close();
                    writer.Close();
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + lblPurchaseOrderidNO.Text + " .pdf ");
                    HttpContext.Current.Response.BinaryWrite(memoryStream.ToArray());
                    HttpContext.Current.Response.End();

                }

                else if (RoleType == Designation)
                {
                    string path = Image1.ImageUrl;
                    DataTable table2 = new DataTable();
                    DataTable table13 = ViewPurchaseOrderServices(ProjectID);
                    DataTable table12 = ViewPurchaseOrderProcurement(ProjectID);

                    // DataTable TaxDatatable = ProposalTaxName(lblProposalNumber.Text);

                    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
                    MemoryStream memoryStream = new MemoryStream();
                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, memoryStream);

                    doc.Open();
                    //doc.Add(new Paragraph(" "));
                    PdfPTable table = new PdfPTable(2);
                    table.WidthPercentage = 100;
                    PdfPCell leftCell1 = new PdfPCell();
                    leftCell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
                    // iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(@"D:\Company\Matoshree\MatoshreeProject\MatoshreeProject\Img_logo\Logo.png");
                    image.ScaleToFit(100f, 100f);
                    leftCell1.AddElement(image);
                    table.AddCell(leftCell1);
                    Font Pagename = new Font(Font.FontFamily.HELVETICA, 16f, Font.BOLD);
                    Font Page1 = new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.RED);
                    Font Page2 = new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL);
                    Font Page3 = new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD);
                    Font Page3BLUE = new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD, BaseColor.BLUE);
                    Font Page4 = new Font(Font.FontFamily.HELVETICA, 10f);
                    Font Page5 = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL);

                    Font Page5red = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.RED);
                    Font Page5orange = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.ORANGE);
                    Font Page5green = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.GREEN);
                    Font Page5blue = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.BLUE);

                    PdfPCell rightCell1 = new PdfPCell();
                    rightCell1.Border = PdfPCell.NO_BORDER;
                    rightCell1.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    Paragraph paragraph1 = new Paragraph("Purchase Order", Pagename);
                    paragraph1.Alignment = Element.ALIGN_RIGHT;
                    rightCell1.AddElement(paragraph1);
                    Paragraph paragraph2 = new Paragraph(lblPurchaseOrderidNO.Text, Page3BLUE);
                    paragraph2.Alignment = Element.ALIGN_RIGHT;
                    rightCell1.AddElement(paragraph2);
                    table.AddCell(rightCell1);

                    string status1 = btnStatus.Text;
                    Paragraph paragraph3 = new Paragraph();
                    if (status1 == "Declined")
                    {
                        paragraph3 = new Paragraph(btnStatus.Text, Page5red);
                        paragraph3.Alignment = Element.ALIGN_RIGHT;
                        rightCell1.AddElement(paragraph3);
                        table.AddCell(rightCell1);
                    }
                    else if (status1 == "Revised")
                    {
                        paragraph3 = new Paragraph(btnStatus.Text, Page5green);
                        paragraph3.Alignment = Element.ALIGN_RIGHT;
                        rightCell1.AddElement(paragraph3);
                        table.AddCell(rightCell1);
                    }
                    else if (status1 == "Open")
                    {
                        paragraph3 = new Paragraph(btnStatus.Text, Page5orange);
                        paragraph3.Alignment = Element.ALIGN_RIGHT;
                        rightCell1.AddElement(paragraph3);
                        table.AddCell(rightCell1);
                    }

                    else if (status1 == "Accepted")
                    {
                        paragraph3 = new Paragraph(btnStatus.Text, Page5blue);
                        paragraph3.Alignment = Element.ALIGN_RIGHT;
                        rightCell1.AddElement(paragraph3);
                        table.AddCell(rightCell1);
                    }

                    else
                    {
                        paragraph3 = new Paragraph(btnStatus.Text, Page5blue);
                        paragraph3.Alignment = Element.ALIGN_RIGHT;
                        rightCell1.AddElement(paragraph3);
                        table.AddCell(rightCell1);
                    }

                    doc.Add(table);
                    doc.Add(new Paragraph(" "));
                    // -------------------------------------------------Purchase Order---------------------------------------------------------
                    PdfPTable table1 = new PdfPTable(2);
                    table1.WidthPercentage = 100;
                    PdfPCell leftCell = new PdfPCell();
                    leftCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    leftCell.AddElement(new Paragraph("", new Font(Font.FontFamily.HELVETICA, 10f)));
                    leftCell.AddElement(new Paragraph(lbladdCompany11.Text, new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD)));
                    leftCell.AddElement(new Paragraph(lbladdress11.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    leftCell.AddElement(new Paragraph(lblcompanyaddCity1.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    leftCell.AddElement(new Paragraph(lblcompanyaddDistrict1.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    leftCell.AddElement(new Paragraph(lblcompanyaddState1.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    leftCell.AddElement(new Paragraph(lblcompanyaddCountry1.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    leftCell.AddElement(new Paragraph("PIN:" + lblcompanyaddZIPCode11.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    Chunk PhoneChunk = new Chunk("Phone No: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk PhoneValueChunk = new Chunk(lblphoneNo1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrase5 = new Phrase
                {
                  PhoneChunk,
                     PhoneValueChunk
                };
                    leftCell.AddElement(phrase5);
                    Chunk VatNoChunk = new Chunk("VAT No: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk VatNoValueChunk = new Chunk(lblVatNo1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrase6 = new Phrase
                  {
                     VatNoChunk,
                     VatNoValueChunk
                  };
                    leftCell.AddElement(phrase6);
                    Chunk GstNoChunk = new Chunk("GST No: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk GstNoValueChunk = new Chunk(lblGSTNo1A.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrase7 = new Phrase
                  {
                     GstNoChunk,
                     GstNoValueChunk
                  };
                    leftCell.AddElement(phrase7);
                    table1.AddCell(leftCell);

                    PdfPCell rightCell = new PdfPCell();
                    rightCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    Paragraph paragraph11 = new Paragraph("To,", Page3);
                    paragraph11.Alignment = Element.ALIGN_RIGHT;
                    rightCell.AddElement(paragraph11);

                    //Paragraph paragraph4 = new Paragraph(lblName1.Text, Page3);
                    //paragraph4.Alignment = Element.ALIGN_RIGHT;
                    //rightCell.AddElement(paragraph4);
                    Chunk Name1 = new Chunk(lblcustname.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Chunk Block = new Chunk(lblblock.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Chunk Address1 = new Chunk(lbladdressLine1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Chunk City1 = new Chunk(lblcompanyaddCity.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Chunk District1 = new Chunk(lblcompanyaddDistrict.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Chunk State1 = new Chunk(lblcompanyaddState.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Chunk ZipCode1 = new Chunk(lblcompanyaddZIPCode.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    // Chunk Phone1 = new Chunk(lblPhone1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    //Chunk Address8 = new Chunk(",", new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase ph1 = new Phrase
                    {
                        Name1,
                        Address1,
                        City1,
                        District1,
                        State1,
                        ZipCode1,
                       // Address8
                    };
                    Paragraph paragraphs1 = new Paragraph(ph1);
                    paragraphs1.Alignment = Element.ALIGN_RIGHT;
                    rightCell.AddElement(paragraphs1);

                    Chunk TenderDate = new Chunk("PO Date: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk TenderDatevalue = new Chunk(lblPOdate1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrase1 = new Phrase
                    {
                   TenderDate,
                   TenderDatevalue
                    };

                    Paragraph paragraph7 = new Paragraph(phrase1);
                    paragraph7.Alignment = Element.ALIGN_RIGHT;

                    rightCell.AddElement(paragraph7);

                    Chunk TenderExDate = new Chunk(" Expiry Date:: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk TenderExDatevalue = new Chunk(lblPOdate1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phraseEx = new Phrase
                    {
                   TenderExDate,
                   TenderExDatevalue
                    };

                    Paragraph paragraphEx = new Paragraph(phraseEx);
                    paragraphEx.Alignment = Element.ALIGN_RIGHT;

                    rightCell.AddElement(paragraphEx);

                    Chunk Projectname = new Chunk("Project Name: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk Projectnamevalue = new Chunk(lblPOprojectname.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrase4 = new Phrase
                    {
                    Projectname,
                    Projectnamevalue
                   };
                    Paragraph paragraph10 = new Paragraph(phrase4);
                    paragraph10.Alignment = Element.ALIGN_RIGHT;
                    rightCell.AddElement(paragraph10);


                    Chunk SaleAgent = new Chunk("Sale Agent: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk SaleAgentvalue = new Chunk(lblsaleagentName.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrase3 = new Phrase
                    {
                        SaleAgent,
                        SaleAgentvalue
                    };
                    Paragraph paragraph9 = new Paragraph(phrase3);
                    paragraph9.Alignment = Element.ALIGN_RIGHT;
                    rightCell.AddElement(paragraph9);

                    table1.AddCell(rightCell);
                    doc.Add(table1);
                    doc.Add(new Paragraph(" "));
                    //---------------------------------------------------------------------//
                    PdfPTable Invtable1C = new PdfPTable(1);
                    Invtable1C.WidthPercentage = 100;
                    PdfPCell InvleftCell1 = new PdfPCell();
                    InvleftCell1.HorizontalAlignment = Element.ALIGN_RIGHT;
                    Invtable1C.AddCell(InvleftCell1);
                    doc.Add(Invtable1C);
                    //---------------------------------------------------------------------//


                    //----------------------------------Rupees---------------------------------------------------//
                    BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    Font font = new Font(bf, 10);
                    Chunk chunkRupee = new Chunk(" \u20B9 ", font);
                    //---------------------------------------------------------Table-----------------------

                    PdfPTable Potable1 = new PdfPTable(1);
                    Potable1.WidthPercentage = 100;
                    PdfPCell PoleftCell = new PdfPCell();
                    PoleftCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    Chunk PO1 = new Chunk("Purchase Order Procurement List ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Phrase phraset1 = new Phrase
                    {
                      PO1

                    };

                    Paragraph paragrapht1 = new Paragraph(phraset1);
                    paragrapht1.Alignment = Element.ALIGN_LEFT;

                    PoleftCell.AddElement(paragrapht1);
                    Potable1.AddCell(PoleftCell);
                    doc.Add(Potable1);
                    doc.Add(new Paragraph(" "));

                    if (table12 != null && table12.Rows.Count > 0)
                    {
                        // Create a new DataTable with only the desired columns
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("Product");
                        dtExport.Columns.Add("Description");

                        dtExport.Columns.Add("Quantity");
                        dtExport.Columns.Add("Price");
                        dtExport.Columns.Add("Amount");



                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in table12.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();

                            newRow["Product"] = row["ProductName"];
                            newRow["Description"] = row["Description"];
                            newRow["Quantity"] = row["Quantity"];
                            newRow["Price"] = row["Price"];
                            newRow["Amount"] = row["TotalAmont"];


                            dtExport.Rows.Add(newRow);
                            table2 = dtExport;
                        }

                        float[] columnWidths = new float[table2.Columns.Count];
                        for (int i = 0; i < table2.Columns.Count; i++)
                        {
                            if (table2.Columns[i].ColumnName == "Description")
                            {
                                columnWidths[i] = 9f;
                            }
                            else if (table2.Columns[i].ColumnName == "ProductName")
                            {
                                columnWidths[i] = 3f;
                            }
                            else if (table2.Columns[i].ColumnName == "TotalAmont")
                            {
                                columnWidths[i] = 4f;
                            }
                            else
                            {
                                columnWidths[i] = 3f;
                            }
                        }
                        Font tableHeaderFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.WHITE);
                        Font tableDataFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL);
                        PdfPTable pdfTable = new PdfPTable(table2.Columns.Count);
                        pdfTable.SetWidths(columnWidths);
                        pdfTable.WidthPercentage = 100;
                        foreach (DataColumn column in table2.Columns)
                        {
                            string columnName = (column.ColumnName == "ID") ? "#" : column.ColumnName;

                            PdfPCell pdfCell = new PdfPCell(new Phrase(columnName, tableHeaderFont));
                            pdfCell.BackgroundColor = new BaseColor(85, 85, 85);
                            pdfCell.Padding = 6;
                            pdfTable.AddCell(pdfCell);
                        }
                        foreach (DataRow row in table2.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                PdfPCell dataCell = new PdfPCell(new Phrase(item.ToString(), tableDataFont));
                                dataCell.Padding = 6;
                                pdfTable.AddCell(dataCell);
                            }
                        }
                        doc.Add(pdfTable);
                    }

                    //doc.Add(new Paragraph(" "));

                    PdfPTable labelsTable1 = new PdfPTable(1);
                    labelsTable1.WidthPercentage = 100;
                    PdfPCell labelCell1 = new PdfPCell();
                    labelCell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    Chunk TotalTax = new Chunk("Total Purchase Order Amount :", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk TotalTaxspace = new Chunk("   "); // Add spaces as needed
                    Chunk TotalTaxvalue = new Chunk(lblTotalAmountProcurement.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phraseTotalTax = new Phrase
                {
                    TotalTax,
                    TotalTaxspace,
                    chunkRupee,
                    TotalTaxvalue
                };
                    Paragraph paragraphTotalTax = new Paragraph(phraseTotalTax);
                    paragraphTotalTax.Alignment = Element.ALIGN_RIGHT;
                    labelCell1.AddElement(paragraphTotalTax);
                    labelCell1.HorizontalAlignment = Element.ALIGN_RIGHT;
                    labelCell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                    labelsTable1.AddCell(labelCell1);
                    doc.Add(labelsTable1);
                    // doc.Add(new Paragraph(" "));

                    //  ================================================table2======================================================

                    PdfPTable Potable2 = new PdfPTable(1);
                    Potable1.WidthPercentage = 100;
                    PdfPCell PoleftCel1 = new PdfPCell();
                    PoleftCel1.Border = iTextSharp.text.Rectangle.NO_BORDER;


                    Chunk PO2 = new Chunk("Purchase Order Services List", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Phrase phraset2 = new Phrase
                    {
                      PO2

                    };

                    Paragraph paragrapht2 = new Paragraph(phraset2);
                    paragrapht2.Alignment = Element.ALIGN_LEFT;
                    paragrapht2.Alignment = Element.ALIGN_JUSTIFIED;
                    PoleftCel1.AddElement(paragrapht2);
                    Potable2.AddCell(PoleftCel1);
                    doc.Add(Potable2);
                    doc.Add(new Paragraph(" "));

                    if (table13 != null && table13.Rows.Count > 0)
                    {
                        // Create a new DataTable with only the desired columns
                        DataTable dtExport1 = new DataTable();
                        dtExport1.Columns.Add("Services");
                        dtExport1.Columns.Add("Duration/Day");
                        dtExport1.Columns.Add("Description");
                        dtExport1.Columns.Add("Quantity");
                        dtExport1.Columns.Add("Price");
                        dtExport1.Columns.Add("Amount");


                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in table13.Rows)
                        {
                            DataRow newRow = dtExport1.NewRow();

                            newRow["Services"] = row["ServiceName"];
                            newRow["Duration/Day"] = row["Duration"];
                            newRow["Description"] = row["Description"];
                            newRow["Quantity"] = row["Quantity"];
                            newRow["Price"] = row["Price"];
                            newRow["Amount"] = row["TotalAmont"];

                            dtExport1.Rows.Add(newRow);
                            table2 = dtExport1;
                        }

                        float[] columnWidths = new float[table2.Columns.Count];
                        for (int i = 0; i < table2.Columns.Count; i++)
                        {
                            if (table2.Columns[i].ColumnName == "Description")
                            {
                                columnWidths[i] = 9f;
                            }
                            else if (table2.Columns[i].ColumnName == "ServiceName")
                            {
                                columnWidths[i] = 3f;
                            }

                            else if (table2.Columns[i].ColumnName == "Quantity")
                            {
                                columnWidths[i] = 2f;
                            }
                            else if (table2.Columns[i].ColumnName == "TotalAmont")
                            {
                                columnWidths[i] = 4f;
                            }
                            else
                            {
                                columnWidths[i] = 3f;
                            }
                        }
                        Font tableHeaderFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.WHITE);
                        Font tableDataFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL);
                        PdfPTable pdfTable = new PdfPTable(table2.Columns.Count);
                        pdfTable.SetWidths(columnWidths);
                        pdfTable.WidthPercentage = 100;
                        foreach (DataColumn column in table2.Columns)
                        {
                            string columnName = (column.ColumnName == "ID") ? "#" : column.ColumnName;

                            PdfPCell pdfCell = new PdfPCell(new Phrase(columnName, tableHeaderFont));
                            pdfCell.BackgroundColor = new BaseColor(85, 85, 85);
                            pdfCell.Padding = 6;
                            pdfTable.AddCell(pdfCell);
                        }
                        foreach (DataRow row in table2.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                PdfPCell dataCell = new PdfPCell(new Phrase(item.ToString(), tableDataFont));
                                dataCell.Padding = 6;
                                pdfTable.AddCell(dataCell);
                            }
                        }
                        doc.Add(pdfTable);
                    }

                    // doc.Add(new Paragraph(" "));


                    PdfPTable labelsTableTSA = new PdfPTable(1);
                    labelsTableTSA.WidthPercentage = 100;
                    PdfPCell labelCellTSA = new PdfPCell();
                    labelCellTSA.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    Chunk subtotal = new Chunk("Total Services Amount:", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk subtotalspace = new Chunk("   "); // Add spaces as needed
                    Chunk subtotalvalue = new Chunk(lblTotalServiceAmount.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrase13 = new Phrase
                {
                    subtotal,
                    subtotalspace,
                    chunkRupee,
                    subtotalvalue
                };
                    Paragraph paragraph12 = new Paragraph(phrase13);
                    paragraph12.Alignment = Element.ALIGN_RIGHT;
                    labelCellTSA.AddElement(paragraph12);
                    labelCellTSA.HorizontalAlignment = Element.ALIGN_RIGHT;
                    labelCellTSA.BackgroundColor = BaseColor.LIGHT_GRAY;
                    labelsTableTSA.AddCell(labelCellTSA);
                    doc.Add(labelsTableTSA);
                    doc.Add(new Paragraph(" "));




                    //---------Add Total:-----------------------------------
                    PdfPTable Potable4 = new PdfPTable(1);
                    Potable4.WidthPercentage = 100;
                    PdfPCell PoleftCell4 = new PdfPCell();
                    PoleftCell4.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    Chunk PO3 = new Chunk("Purchase Order Costing", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Phrase phrasel1 = new Phrase
                    {
                      PO3

                    };

                    Paragraph paragraphl1 = new Paragraph(phrasel1);
                    paragraphl1.Alignment = Element.ALIGN_LEFT;

                    PoleftCell4.AddElement(paragraphl1);
                    Potable4.AddCell(PoleftCell4);
                    doc.Add(Potable4);
                    doc.Add(new Paragraph(" "));
                    //---------------------------------------------------------------------//
                    PdfPTable Invtable2C = new PdfPTable(1);
                    Invtable2C.WidthPercentage = 100;
                    PdfPCell InvleftCell2 = new PdfPCell();
                    InvleftCell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                    Invtable2C.AddCell(InvleftCell2);
                    doc.Add(Invtable2C);
                    //---------------------------------------------------------------------//
                    //---------POTotalCost:----------------------------------

                    PdfPTable Potable5 = new PdfPTable(1);
                    Potable5.WidthPercentage = 100;
                    PdfPCell PoleftCell5 = new PdfPCell();
                    PoleftCell5.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    Chunk PO5 = new Chunk("Purchase Order Costing:", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk Grandtotalspace = new Chunk("   "); // Add spaces as needed
                    Chunk Grandtotalvalue = new Chunk(lblTotalAmountProcu.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrasel5 = new Phrase
                    {
                      PO5,
                      Grandtotalspace,
                      Grandtotalvalue
                    };

                    Paragraph paragraphl5 = new Paragraph(phrasel5);
                    paragraphl5.Alignment = Element.ALIGN_LEFT;

                    PoleftCell5.AddElement(paragraphl5);
                    Potable5.AddCell(PoleftCell5);
                    doc.Add(Potable5);
                    doc.Add(new Paragraph(" "));


                    //---------POTotalCost:----------------------------------

                    PdfPTable Potable6 = new PdfPTable(1);
                    Potable6.WidthPercentage = 100;
                    PdfPCell PoleftCell6 = new PdfPCell();
                    PoleftCell6.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    Chunk PO6 = new Chunk("Total Purchase Order Cost :", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk GrandtotalAmtspace = new Chunk("   "); // Add spaces as needed
                    Chunk GrandtotalAmtvalue = new Chunk(lblTotalProjectCost.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phrasel6 = new Phrase
                    {
                      PO6,
                      GrandtotalAmtspace,
                      GrandtotalAmtvalue
                    };

                    Paragraph paragraphl6 = new Paragraph(phrasel6);
                    paragraphl6.Alignment = Element.ALIGN_LEFT;
                    PoleftCell6.BackgroundColor = BaseColor.LIGHT_GRAY;
                    PoleftCell6.AddElement(paragraphl6);
                    Potable6.AddCell(PoleftCell6);

                    doc.Add(Potable6);
                    doc.Add(new Paragraph(" "));

                    //---Invoice Total in Words-------------------------------//
                    string TotalPOCost1 = lblTotalProjectCost.Text;
                    string TotalPOCost = TotalPOCost1.Replace("₹", "").Trim();

                    PdfPTable InvoiceCostInword = new PdfPTable(1);
                    InvoiceCostInword.WidthPercentage = 100;
                    PdfPCell invoiceWord = new PdfPCell();
                    invoiceWord.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    double invTotalAmount1 = Convert.ToDouble(TotalPOCost);
                    string number = ConvertAmount(invTotalAmount1);
                    Chunk Inword = new Chunk("In words: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                    Chunk Inwordvalue = new Chunk(number, new Font(Font.FontFamily.HELVETICA, 10f));
                    Phrase phraseInword = new Phrase
                 {
                  Inword,
                 Inwordvalue
                 };
                    Paragraph paraInword = new Paragraph(phraseInword);
                    paraInword.Alignment = Element.ALIGN_LEFT;
                    invoiceWord.AddElement(paraInword);

                    InvoiceCostInword.AddCell(invoiceWord);

                    doc.Add(InvoiceCostInword);
                    doc.Add(new Paragraph(" "));
                    //-----------------------------------------------------------------------------------------------//
                    //Note & Term Conditions
                    PdfPTable NoteTable = new PdfPTable(1);
                    NoteTable.WidthPercentage = 100;
                    PdfPCell NoteCell = new PdfPCell();
                    NoteCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    NoteCell.AddElement(new Paragraph("Note", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD)));
                    NoteCell.AddElement(new Paragraph(lblNote1.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    NoteCell.AddElement(new Paragraph("  "));
                    NoteCell.AddElement(new Paragraph("Terms & Condition :", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD)));
                    NoteCell.AddElement(new Paragraph(lbltermsandcodition.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                    NoteCell.AddElement(new Paragraph("  "));
                    NoteCell.AddElement(new Paragraph("Thank You", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD)));
                    NoteTable.AddCell(NoteCell);
                    doc.Add(NoteTable);
                    doc.Add(new Paragraph(" "));

                    doc.Close();
                    writer.Close();
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + lblPurchaseOrderidNO.Text + " .pdf ");
                    HttpContext.Current.Response.BinaryWrite(memoryStream.ToArray());
                    HttpContext.Current.Response.End();

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

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                GETCredentials();
                SendEmail(lblcustname.Text);
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

        protected void lnkbtnviewascustmer_Click(object sender, EventArgs e)
        {

        }
        //-------------------------------------Task Start-------------------------------------------
        //----------------------------------------------------------------------------------------//

        public DataTable ViewTaskDetails()
        {
            DataTable table = new DataTable();
            string PurchaseOrderNo = HttpUtility.UrlDecode(Request.QueryString["PurchaseOrderID"]);
            lblPurchaseOrderid.Text = PurchaseOrderNo;


            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewTaskByPurchaseOrderNumber", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PONumber", PurchaseOrderNo);

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridTask1.DataSource = table;
                GridTask1.DataBind();
                ViewState["Data"] = table;
            }
            return table;
        }

        protected void btn_New_Task_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewTaskStaff.aspx");
        }

        protected void btn_Task_Overview_Click(object sender, EventArgs e)
        {
            Response.Redirect("Task_Detail_Overview.aspx");
        }
        protected void GridTask1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridTask1.Rows)
                {
                    //---------------Status-------------------------------///
                    string Status = ((Button)gridviedrow.FindControl("btnStatus")).Text;
                    Button btnStatusAssign = (Button)gridviedrow.FindControl("btnStatus");

                    Label lbltaskName1 = (Label)gridviedrow.FindControl("lbltaskName1");
                    Label lblStart_Date1 = (Label)gridviedrow.FindControl("lblStart_Date1");
                    Label lblDue_Date1 = (Label)gridviedrow.FindControl("lblDue_Date1");
                    Label lblTaskStatus1 = (Label)gridviedrow.FindControl("lblTaskStatus1");
                    DropDownList ddlTaskStatus1 = (DropDownList)gridviedrow.FindControl("ddlTaskStatus");

                    ddlTaskStatus1.SelectedItem.Text = lblTaskStatus1.Text;
                    Label lblstatus1 = (Label)gridviedrow.FindControl("lblstatus1");

                    Label lblReapet_Every1 = (Label)gridviedrow.FindControl("lblReapet_Every1");

                    Label lblPriority1 = (Label)gridviedrow.FindControl("lblPriority1");
                    DropDownList ddlPriority1 = (DropDownList)gridviedrow.FindControl("ddlPriority");
                    ddlPriority1.SelectedItem.Text = lblPriority1.Text;

                    Label lblBillable1 = (Label)gridviedrow.FindControl("lblBillable1");
                    LinkButton btnDeleteTask = (LinkButton)gridviedrow.FindControl("btnDeleteTask");
                    System.Web.UI.WebControls.Image Img1 = (System.Web.UI.WebControls.Image)gridviedrow.FindControl("img1");

                    //////////////////////////////////////////////////////////////////////////////////////////


                    BulletedList bulletListRelatedTo = (BulletedList)gridviedrow.FindControl("bulletlist1");

                    string task = lbltaskName1.Text;

                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    if (Status.Equals("True"))
                    {
                        btnStatusAssign.Text = "True";
                        btnStatusAssign.CssClass = "btn btn-sm btn-outline-success";
                        lbltaskName1.ForeColor = Color.Blue;
                        lblStart_Date1.ForeColor = Color.Blue;
                        lblDue_Date1.ForeColor = Color.Blue;
                        //lblReletd_To1.ForeColor = Color.Blue;
                        lblstatus1.ForeColor = Color.Blue;
                        lblReapet_Every1.ForeColor = Color.Blue;

                        lblBillable1.ForeColor = Color.Blue;

                        DataTable table = GetStaffnamebytaskname(task);

                        bulletListRelatedTo.DataSource = table;
                        bulletListRelatedTo.DataTextField = "AssignTo";
                        bulletListRelatedTo.DataValueField = "AssignTo";
                        bulletListRelatedTo.DataBind();
                    }
                    else
                    {
                        btnDeleteTask.Visible = false;
                        btnStatusAssign.Text = "False";
                        btnStatusAssign.CssClass = "btn btn-sm btn-outline-dark";
                        lbltaskName1.ForeColor = Color.Red;
                        lblStart_Date1.ForeColor = Color.Red;
                        lblDue_Date1.ForeColor = Color.Red;
                        lblstatus1.ForeColor = Color.Red;
                        lblReapet_Every1.ForeColor = Color.Red;
                        lblBillable1.ForeColor = Color.Red;

                        using (SqlConnection con = new SqlConnection(strconnect))
                        {
                            SqlCommand sqlCommand = new SqlCommand("[SP_ViewTaskInActiveStatus]", con);//storeprocedure madhe status 0
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@Subject", task);

                            SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                            DataTable dt = new DataTable();
                            ad.Fill(dt);

                            bulletListRelatedTo.DataSource = dt;
                            bulletListRelatedTo.DataTextField = "AssignTo";
                            bulletListRelatedTo.DataValueField = "AssignTo";
                            bulletListRelatedTo.DataBind();

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
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

        protected void linkbtnExcelTask_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "TaskDetails " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    using (StringWriter sw = new StringWriter())
                    {
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        //To Export all pages
                        GridTask1.AllowPaging = false;
                        DataTable dt = (DataTable)ViewState["Data"];
                        DataTable dt2 = new DataTable();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            dt2.Columns.Add(dt.Columns[i].ColumnName, typeof(string));
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt2.ImportRow(dt.Rows[i]);

                        }
                        this.GridTask1.DataSource = dt2;
                        this.GridTask1.DataBind();
                        GridTask1.HeaderRow.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in GridTask1.HeaderRow.Cells)
                        {
                            cell.BackColor = GridTask1.HeaderStyle.BackColor;
                        }
                        foreach (GridViewRow row in GridTask1.Rows)
                        {
                            row.BackColor = System.Drawing.Color.White;
                            foreach (TableCell cell in row.Cells)
                            {
                                if (row.RowIndex % 2 == 0)
                                {
                                    cell.BackColor = GridTask1.AlternatingRowStyle.BackColor;
                                }
                                else
                                {
                                    cell.BackColor = GridTask1.RowStyle.BackColor;
                                }
                                cell.CssClass = "textmode";
                            }
                        }
                        GridTask1.RenderControl(hw);
                        //style to format numbers to string
                        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                        Response.Write(style);
                        Response.Output.Write(sw.ToString());
                        Response.Flush();
                        Response.End();
                    }
                }
                else if (RoleType == Designation)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "TaskDetails " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    using (StringWriter sw = new StringWriter())
                    {
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        //To Export all pages
                        GridTask1.AllowPaging = false;
                        DataTable dt = (DataTable)ViewState["Data"];
                        DataTable dt2 = new DataTable();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            dt2.Columns.Add(dt.Columns[i].ColumnName, typeof(string));
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt2.ImportRow(dt.Rows[i]);

                        }
                        this.GridTask1.DataSource = dt2;
                        this.GridTask1.DataBind();
                        GridTask1.HeaderRow.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in GridTask1.HeaderRow.Cells)
                        {
                            cell.BackColor = GridTask1.HeaderStyle.BackColor;
                        }
                        foreach (GridViewRow row in GridTask1.Rows)
                        {
                            row.BackColor = System.Drawing.Color.White;
                            foreach (TableCell cell in row.Cells)
                            {
                                if (row.RowIndex % 2 == 0)
                                {
                                    cell.BackColor = GridTask1.AlternatingRowStyle.BackColor;
                                }
                                else
                                {
                                    cell.BackColor = GridTask1.RowStyle.BackColor;
                                }
                                cell.CssClass = "textmode";
                            }
                        }
                        GridTask1.RenderControl(hw);
                        //style to format numbers to string
                        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                        Response.Write(style);
                        Response.Output.Write(sw.ToString());
                        Response.Flush();
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
                using (DeviceCon = new SqlConnection(strconnect))
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
        public DataTable GetTaskbyLeadsID(String LeadIDD)
        {
            LeadIDD = lblLeadIdd.Text;
            DataTable table = new DataTable();
            try
            {
                DataColumn dataColumn = new DataColumn();
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand sqlCommand = new SqlCommand("SP_ViewTaskStaffByLeadID", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@LeadID", LeadIDD);
                    SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                    ad.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        GridTask1.DataSource = table;
                        GridTask1.DataBind();
                        ViewState["TaskLead"] = table;
                    }
                    else
                    {
                        GridTask1.DataSource = table;
                        GridTask1.DataBind();
                    }
                }
                return table;
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
                return table;
            }
            finally
            {
            }
        }
        public DataTable GetTaskbyLeadsID(String LeadIDD, int UserID)
        {
            LeadIDD = lblLeadIdd.Text;
            DataTable table = new DataTable();
            try
            {
                DataColumn dataColumn = new DataColumn();
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand sqlCommand = new SqlCommand("SP_ViewTaskStaffByLeadIDEmpID", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@LeadID", LeadIDD);
                    sqlCommand.Parameters.AddWithValue("@EmpID", UserID);
                    SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                    ad.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        GridTask1.DataSource = table;
                        GridTask1.DataBind();
                        ViewState["TaskLead"] = table;
                    }
                    else
                    {
                        GridTask1.DataSource = table;
                        GridTask1.DataBind();
                    }
                }
                return table;
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
                return table;
            }
            finally
            {
            }
        }

        public DataTable GetStaffnamebytaskname(string task)
        {
            string str;
            DataTable table = new DataTable();
            DataRow dtrow;
            DataColumn dataColumn = new DataColumn();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_GetTaskDetailsByTaskname", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Subject", task);
                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                ad.Fill(table);

                //if (table.Rows.Count > 0)
                //{
                //    str = table.Rows[0]["Reletd_To"].ToString();

                //    string[] s2 = str.Split(',');
                //    int cnt = s2.Length;
                //    table.Clear();

                //    foreach (string s3 in s2)
                //    {
                //        table.Rows.Add(s3);
                //    }
                //}
            }
            return table;
        }

        //---------------------------------------------------------------
        //taskList
        //-----------------------------------------------------
        protected void linkbtnPDFTask_Click(object sender, EventArgs e)
        {
            try
            {
                GetCompanyAddress();
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    int _totalColumns = 10;
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(_totalColumns);
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
                        _document.Open();
                        _pdfPTable.SetWidths(new float[] { 3f, 12f, 10f, 10f, 10f, 12f, 8f, 6f, 7f, 8f });
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 10;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPTable.AddCell(cell);
                        //.....image logo.....// 
                        phrase = new Phrase();
                        phrase.Add(new Chunk(lbladdCompany11.Text + "\n", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lbladdress11.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCity1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddDistrict1.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddState1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
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
                        _pdfPCell = new PdfPCell(new Phrase("TaskStaffList", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //----------------------Date------------------------------//
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
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*------------------------------------", _fontStyle));
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
                        _Vhrlist = ViewTaskDetails();
                        #region "Table Header"
                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);


                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Subject", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StartDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("DueDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("AssignTo", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("TaskStatus", _fontStyle));
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
                        _pdfPCell = new PdfPCell(new Phrase("Reapet", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);//Billable
                        _pdfPCell = new PdfPCell(new Phrase("Priority", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);//Billable
                        _pdfPCell = new PdfPCell(new Phrase("Billable", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["Subject"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Start_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Due_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            DataTable taskassign = GetStaffnamebytaskname(row["Subject"].ToString());
                            Phrase Pharse1 = new Phrase();
                            foreach (DataRow Rowassign in taskassign.Rows)
                            {

                                Pharse1.Add(new Chunk(Rowassign["AssignTo"].ToString() + ",", _fontStyle));


                            }

                            _pdfPCell = new PdfPCell(Pharse1);
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);


                            _pdfPCell = new PdfPCell(new Phrase(row["TaskStatus"].ToString(), _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["Reapet_Every"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Priority"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Billable"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("TaskStaffList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
                    int _totalColumns = 10;
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(_totalColumns);
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
                        _document.Open();
                        _pdfPTable.SetWidths(new float[] { 3f, 12f, 10f, 10f, 10f, 12f, 8f, 6f, 7f, 8f });
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 10;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPTable.AddCell(cell);
                        //.....image logo.....// 
                        phrase = new Phrase();
                        phrase.Add(new Chunk(lbladdCompany11.Text + "\n", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lbladdress11.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCity1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddDistrict1.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddState1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
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
                        _pdfPCell = new PdfPCell(new Phrase("TaskStaffList", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //----------------------Date------------------------------//
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
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*------------------------------------", _fontStyle));
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
                        _Vhrlist = (DataTable)ViewState["Data"];
                        #region "Table Header"
                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);


                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Subject", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StartDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("DueDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("AssignTo", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("TaskStatus", _fontStyle));
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
                        _pdfPCell = new PdfPCell(new Phrase("Reapet", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);//Billable
                        _pdfPCell = new PdfPCell(new Phrase("Priority", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);//Billable
                        _pdfPCell = new PdfPCell(new Phrase("Billable", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["Subject"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Start_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Due_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            DataTable taskassign = GetStaffnamebytaskname(row["Subject"].ToString());
                            Phrase Pharse1 = new Phrase();
                            foreach (DataRow Rowassign in taskassign.Rows)
                            {

                                Pharse1.Add(new Chunk(Rowassign["AssignTo"].ToString() + ",", _fontStyle));


                            }

                            _pdfPCell = new PdfPCell(Pharse1);
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);


                            _pdfPCell = new PdfPCell(new Phrase(row["TaskStatus"].ToString(), _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["Reapet_Every"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Priority"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Billable"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("TaskStaffList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
                using (DeviceCon = new SqlConnection(strconnect))
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

        protected void btnVisibilityTask_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);


                if (Session["LoginType"].ToString() == "Administrator")
                {
                    DataTable table = new DataTable();
                    string PurchaseOrderNo = HttpUtility.UrlDecode(Request.QueryString["PurchaseOrderID"]);
                    lblPurchaseOrderid.Text = PurchaseOrderNo;

                    DataColumn dataColumn = new DataColumn();
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand sqlCommand = new SqlCommand("SP_ViewTaskByPurchaseOrderNumberVisibility", con);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@PONumber", PurchaseOrderNo);
                        // sqlCommand.Parameters.AddWithValue("@ProjectID", ProjectID);

                        SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                        ad.Fill(table);
                        GridTask1.DataSource = table;
                        GridTask1.DataBind();
                        ViewState["Data"] = table;
                    }
                }
                else if (RoleType == Designation)
                {
                    // StaffOperationTaskPermission();
                }
                else
                {
                    Response.Redirect("~/Expired.html", true);
                }
            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
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

        protected void btnReloadTask_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    //string ProjectID1 = lblProjectID.Text;
                    //GetTaskbyProjectID(ProjectID1);

                }
                else if (RoleType == Designation)
                {
                    //StaffOperationTaskPermission();
                }
                else
                {
                    Response.Redirect("~/Expired.html", true);
                }


            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
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

        protected void btnEditTask_Click(object sender, EventArgs e)
        {
            try
            {
                string task;
                var rows = GridTask1.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;
                Response.Redirect("~/EditStaffTask.aspx?task=" + task + "", false);
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


        protected void btnDeleteTask_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    //string PurchaseOrderNo = HttpUtility.UrlDecode(Request.QueryString["PurchaseOrderID"]);
                    //lblPurchaseOrderid.Text = PurchaseOrderNo;
                    string ProjectID1 = lblPurchaseOrderid.Text;
                    DeviceCon = new SqlConnection(strconnect);
                    string task;
                    var rows = GridTask1.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;

                    SqlCommand cmd = new SqlCommand("SP_DeleteTaskbyTaskname", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Subject", task);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Details Deleted Successfully";
                        GridTask1.EditIndex = -1;
                        GetbyPurchaseOrderNo();
                        //GetTaskbyProjectID(ProjectID1);
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Details not Deleted Successfully";
                    }
                }
                else if (RoleType == Designation)
                {
                    string ProjectID1 = lblPurchaseOrderid.Text;
                    DeviceCon = new SqlConnection(strconnect);
                    string task;
                    var rows = GridTask1.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;

                    SqlCommand cmd = new SqlCommand("SP_DeleteTaskbyTasknameForEmpID", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Subject", task);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Details Deleted Successfully";
                        GridTask1.EditIndex = -1;

                        //StaffOperationTaskPermission();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Details not Deleted Successfully";
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

        //-------------------------------------Task End-------------------------------------------

        //-------------------------------------Activity Log Start-------------------------------------------
        public DataTable ViewActivityDetailsByPurchaseOrderID(int Projectid)
        {
            DataTable table = new DataTable();
            string PurchaseOrderNo = HttpUtility.UrlDecode(Request.QueryString["PurchaseOrderID"]);
            lblPurchaseOrderid.Text = PurchaseOrderNo;

            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ActivityDetailsByPurchaseOrderID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@PurchaseID", Projectid);

                ad.Fill(table);
                if (table.Rows.Count > 0)
                {
                    GridViewAct1.DataSource = table;
                    GridViewAct1.DataBind();

                    //Get the Row that contains this button 
                    //foreach (GridViewRow gridviedrow in GridProcurement.Rows)
                    //{
                    //    LinkButton btnEditProcurement = (LinkButton)gridviedrow.FindControl("btnEditProcurement");
                    //    LinkButton btnDeleteProcurement = (LinkButton)gridviedrow.FindControl("btnDeleteProcurement");


                    //    //btnEditProcurement.Visible = true;
                    //    //btnDeleteProcurement.Visible = true;
                    //}
                }
                else
                {
                    table.Rows.Add(table.NewRow());
                    GridViewAct1.DataSource = table;
                    GridViewAct1.DataBind();
                    int totalcolumns = GridViewAct1.Rows[0].Cells.Count;

                }
                return table;
            }

        }

        protected void GridViewAct1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        //-------------------------------------Activity Log End-------------------------------------------

        protected void ddlTaskStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string TaskStatus1, ddlTaskStatus1, task;

                var rows = GridTask1.Rows;
                DropDownList btn = (DropDownList)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;
                TaskStatus1 = ((Label)rows[rowindex].FindControl("lblTaskStatus1")).Text;
                ddlTaskStatus1 = ((DropDownList)rows[rowindex].FindControl("ddlTaskStatus")).SelectedItem.Text;

                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateTaskStaffStatus", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Subject", task);
                    cmd.Parameters.AddWithValue("@TaskStatus", ddlTaskStatus1);
                    cmd.Parameters.AddWithValue("@Updateby", UserName); // Use SelectedValue
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    conn.Open();
                    int Result = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (Result < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Status Change Successfully";

                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Status not Change Successfully";

                    }
                }
            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
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

        protected void ddlPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string PriorityTo, ddlPriority1, task;

                var rows = GridTask1.Rows;
                DropDownList btn = (DropDownList)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;
                PriorityTo = ((Label)rows[rowindex].FindControl("lblPriority1")).Text;
                ddlPriority1 = ((DropDownList)rows[rowindex].FindControl("ddlPriority")).SelectedItem.Text;

                using (SqlConnection sqlConnection = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateTaskPriority", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Subject", task);
                    cmd.Parameters.AddWithValue("@Priority", ddlPriority1);
                    cmd.Parameters.AddWithValue("@Updateby", UserName); // Use SelectedValue
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    sqlConnection.Open();
                    int Result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (Result < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Priority Change Successfully";
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Priority Not Change Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
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

        protected void GridviewRemainder1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnPDFbtnPaid_Click(object sender, EventArgs e)
        {

        }

        protected void linkbtnSendOverDue_Click(object sender, EventArgs e)
        {

        }

        protected void LinkStatusUnpaid_Click(object sender, EventArgs e)
        {

        }

        protected void lnkbtnsent_Click(object sender, EventArgs e)
        {

        }

        protected void lnkbtnNotsend_Click(object sender, EventArgs e)
        {

        }

        protected void LinkStatusPaid_Click(object sender, EventArgs e)
        {

        }
        public DataTable ViewFileLeadDetails()
        {

            DataTable table = new DataTable();

            using (SqlConnection con1 = new SqlConnection(strconnect))
            {

                SqlCommand com = new SqlCommand("SP_ViewPurchaseFilesByID", con1);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@PurchaseID", lblPurchaseID.Text);
                com.Parameters.AddWithValue("@BelongTo", "PurchaseOrder");


                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    GridLeadFile.DataSource = dt;
                    GridLeadFile.DataBind();
                    GridLeadFile.Visible = true;

                    foreach (GridViewRow gridviedrow in GridLeadFile.Rows)
                    {

                        LinkButton btnDownload = (LinkButton)gridviedrow.FindControl("btnDownload");

                        btnDownload.Visible = true;
                        LinkButton DeleteLeadFile = (LinkButton)gridviedrow.FindControl("btnDeleteLeadFile");

                        DeleteLeadFile.Visible = true;

                    }
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridLeadFile.DataSource = dt;
                    GridLeadFile.DataBind();
                    int totalcolums = GridLeadFile.Rows[0].Cells.Count;
                    GridLeadFile.Visible = false;
                }
            }

            return table;



        }

        public DataTable ViewFileLeadDetails(int UserId)
        {

            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                SqlCommand com = new SqlCommand("SP_ViewFilePODetailsEmpID", con1);
                com.CommandType = CommandType.StoredProcedure;

                //com.Parameters.AddWithValue("@LeadID", LeadIDD);
                com.Parameters.AddWithValue("@ID", lblLeadIdd.Text);
                com.Parameters.AddWithValue("@EmpID", UserId);

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    GridLeadFile.DataSource = dt;
                    GridLeadFile.DataBind();
                    GridLeadFile.Visible = true;

                    foreach (GridViewRow gridviedrow in GridLeadFile.Rows)
                    {

                        LinkButton btnDownload = (LinkButton)gridviedrow.FindControl("btnDownload");

                        btnDownload.Visible = true;
                        LinkButton DeleteLeadFile = (LinkButton)gridviedrow.FindControl("btnDeleteLeadFile");

                        DeleteLeadFile.Visible = true;

                    }
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridLeadFile.DataSource = dt;
                    GridLeadFile.DataBind();
                    int totalcolums = GridLeadFile.Rows[0].Cells.Count;
                    GridLeadFile.Visible = false;
                }
            }

            return table;



        }
        protected void Btn_POUpload_Click(object sender, EventArgs e)
        {
            try
            {

                if (FileUpload.PostedFile == null)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Lead Not In Draft!')", true);
                }
                else
                {
                    if (FileUpload.PostedFile.FileName.Length > 1)
                    {
                        string uploadDirectory = Server.MapPath("~/PurchaseOrderFile/");

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
                                SqlCommand cmd = new SqlCommand("SP_UploadPurchaseOrderAttachmentFile", con);
                                cmd.Connection = con;

                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@FileExtension", extention);
                                cmd.Parameters.AddWithValue("@FilePath", filePath);
                                cmd.Parameters.AddWithValue("@EmpID", UserId);
                                cmd.Parameters.AddWithValue("@Designation", Designation);
                                cmd.Parameters.AddWithValue("@Createdby", UserName);
                                cmd.Parameters.AddWithValue("@PurchaseID", lblPurchaseID.Text);
                                cmd.Parameters.AddWithValue("@PONumber", lblPurchaseOrderid.Text);
                                cmd.Parameters.AddWithValue("@Belong", "PurchaseOrder");
                                cmd.Parameters.AddWithValue("@Description", txtArea.Text);


                                //cmd.Parameters.AddWithValue("@ContentType", contenttype);
                                //cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                int i = cmd.ExecuteNonQuery();
                                if (i < 0)
                                {
                                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Leave Request File Uploaded Successfully!')", true);
                                    ViewFileLeadDetails();
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
                string FileID;
                var rows = GridLeadFile.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = row.RowIndex;  // No need for Convert.ToInt32
                FileID = ((Label)rows[rowindex].FindControl("lblfileid")).Text;

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    string PurchaseOrderNo = HttpUtility.UrlDecode(Request.QueryString["PurchaseOrderID"]);
                    lblPurchaseOrderid.Text = PurchaseOrderNo;

                    SqlCommand cmd = new SqlCommand("SP_GetPurchaseOrderFileDetailsByID", UserCon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PurchaseID", lblPurchaseID.Text);
                    cmd.Parameters.AddWithValue("@BelongTo", "PurchaseOrder");
                    cmd.Parameters.AddWithValue("@FileID", FileID);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        string name = dt.Rows[0]["FileName"].ToString();
                        string FilePath = dt.Rows[0]["FilePath"].ToString();
                        string extension = System.IO.Path.GetExtension(FilePath).ToLower();
                        string contentType = GetContentType(extension);


                        if (!string.IsNullOrEmpty(contentType) && System.IO.File.Exists(FilePath))
                        {
                            Response.ContentType = contentType;
                            Response.AppendHeader("Content-Disposition", $"attachment; filename={Path.GetFileName(FilePath)}");
                            Response.WriteFile(FilePath);
                            Response.End();
                        }
                        else
                        {
                            // lblMessage.Text = "Unsupported file type or file not found.";
                        }
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
        private string GetContentType(string extension)
        {
            switch (extension)
            {
                case ".doc":
                    return "application/vnd.ms-word";
                case ".docx":
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case ".xls":
                    return "application/vnd.ms-excel";
                case ".xlsx":
                    return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                case ".jpg":
                    return "image/jpeg"; // Correct mime type for jpg
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                case ".pdf":
                    return "application/pdf";
                default:
                    return string.Empty;
            }
        }

        protected void btnDeleteLeadFile_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);

                if (Session["LoginType"].ToString() == "Administrator")
                {
                    string ID;
                    var rows = GridLeadFile.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    ID = ((Label)rows[rowindex].FindControl("lblfileid")).Text;

                    SqlConnection DeviceCon = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteLeadFile", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", ID);
                    cmd.Parameters.AddWithValue("@LeadName", lblNameLead.Text);
                    cmd.Parameters.AddWithValue("@CreateBy", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();

                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Leads File Details Deleted Successfully";
                        ViewFileLeadDetails();


                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Leads File Details Not Deleted";
                    }

                }

                else if (RoleType == Designation)
                {
                    string ID;
                    var rows = GridLeadFile.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    ID = ((Label)rows[rowindex].FindControl("lblfileid")).Text;

                    SqlConnection DeviceCon = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteLeadFile", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", ID);
                    //cmd.Parameters.AddWithValue("@LeadName", lblNameLead.Text);
                    cmd.Parameters.AddWithValue("@CreateBy", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();

                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Leads File Details Deleted Successfully";
                        //StaffOperationPermission();
                        ViewFileLeadDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Leads File Details Not Deleted";
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

        protected void linkbtnPaid_Click(object sender, EventArgs e)
        {

        }
        //-------------------------------------Notes Start-------------------------------------------

        protected void btnNotesSave_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {

                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_UpdatePurchaseOrderNote", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", lblPurchaseID.Text);
                    cmd.Parameters.AddWithValue("@PONumber", lblPurchaseOrderid.Text);
                    cmd.Parameters.AddWithValue("@Notes", txtNoteDescription.Text);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Createdby", UserName);
                    //cmd.Parameters.AddWithValue("@Belong", "PurchaseOrder");

                    con.Open();
                    int Result = cmd.ExecuteNonQuery();
                    if (Result < 0)
                    {

                        // ViewReminderPurchaseOrderDetails();
                        Clear();
                        Toasteralert.Visible = true;
                        lblMessage.Visible = true;
                        lblMessage.Text = "PurchaseOrder Note Details Update Successfully";

                    }
                    else
                    {

                        Toasteralert.Visible = true;
                        lblMessage.Visible = true;
                        lblMessage.Text = "PurchaseOrder Note Not Update Successfully";
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
                    //lblMessage.Visible = false;
                    //lblMessage.Text = "Error Details Save Successfully";
                }
                else
                {
                    //lblMessage.Visible = false;
                    //lblMessage.Text = "Error Details Not Save Successfully";
                }
                DeviceCon.Close();
            }
            finally

            {

            }
        }

        protected void btnNoteClear_Click(object sender, EventArgs e)
        {

        }



        //-------------------------------------Notes Start-------------------------------------------
        protected void LinkStatusPartiallyPaid_Click(object sender, EventArgs e)
        {

        }

        protected void LinkStatusOverdue_Click(object sender, EventArgs e)
        {

        }

        protected void LinkStatusCancelled_Click(object sender, EventArgs e)
        {

        }


        protected void LinkStatusDraft_Click(object sender, EventArgs e)
        {

        }

        protected void lnkbtnInvoiceswithnopayment_Click(object sender, EventArgs e)
        {

        }

        protected void lnkbtncopyestimate_Click(object sender, EventArgs e)
        {

        }

        protected void lnkbtndelInvoice_Click(object sender, EventArgs e)
        {

        }

        protected void lnkbtnALL_Click(object sender, EventArgs e)
        {

        }

        protected void LinkViewNotsend_Click(object sender, EventArgs e)
        {

        }

        //==================================== Reminder Start ====================================//
        //===============================================================================//

        public DataTable ViewReminderPurchaseOrderDetails()
        {

            DataTable table = new DataTable();


            using (SqlConnection con1 = new SqlConnection(strconnect))
            {


                SqlCommand com = new SqlCommand("SP_ViewRemainderPurchaseOrderDetails", con1);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@PONumber", lblPurchaseOrderid.Text);

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridLeadReminder.DataSource = dt;
                GridLeadReminder.DataBind();
                ViewState["PurchaseOrder"] = dt;
            }

            return table;



        }
        public DataTable ViewReminderPurchaseOrderDetails(int UseID)
        {

            DataTable table = new DataTable();


            using (SqlConnection con1 = new SqlConnection(strconnect))
            {


                SqlCommand com = new SqlCommand("SP_ViewRemainderPurchaseOrderDetailsEmpID", con1);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@PONumber", lblPurchaseOrderid.Text);
                com.Parameters.AddWithValue("@EmpID", UseID);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridLeadReminder.DataSource = dt;
                GridLeadReminder.DataBind();
                ViewState["PurchaseOrder"] = dt;

            }

            return table;



        }

        public void bindStaff()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetStaffName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);


                    ddlreminderMember.DataSource = ds.Tables[0];
                    ddlreminderMember.DataTextField = "First_Name";
                    ddlreminderMember.DataValueField = "Staff_ID";
                    ddlreminderMember.DataBind();
                    ddlreminderMember.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select AssignTo", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkbtnCreateRemainder_Click(object sender, EventArgs e)
        {
            if (craeteButton.Visible == false)
            {
                craeteButton.Visible = true;
            }

            else
            {
                craeteButton.Visible = false;
            }
        }

        protected void btnCreateRemainder_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    if (chksetRemainderforEmail.Checked)
                    {
                        chkReminder = "true";
                    }
                    else
                    {
                        chkReminder = "false";
                    }


                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_SaveRemainderPurchaseOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DateTime dateNotifiedDate = Convert.ToDateTime(txtDateNotified.Text);
                    cmd.Parameters.AddWithValue("@RelatedToID", lblPurchaseID.Text);
                    cmd.Parameters.AddWithValue("@NotifyDate", Convert.ToDateTime(txtDateNotified.Text));
                    cmd.Parameters.AddWithValue("@SetToReminder", ddlreminderMember.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Description", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@SendMail", chkReminder);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@Belong", "PurchaseOrder");
                    cmd.Parameters.AddWithValue("@RelatedTo", lblPurchaseOrderid.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i < 0)
                    {

                        bindStaff();

                        ViewReminderPurchaseOrderDetails();
                        Toasteralert.Visible = true;
                        lblMessage.Visible = true;
                        lblMessage.Text = "PurchaseOrder Reminders Details Save Successfully";

                        Clear();
                        //Response.Redirect("~/NewLead.aspx", false);
                    }
                    else
                    {
                        Toasteralert.Visible = true;
                        lblMessage.Visible = true;
                        lblMessage.Text = "PurchaseOrder Reminders Not Save Successfully";

                    }



                }


            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;

            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btnupdateLeadReminder_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    string chkReminder1;
                    if (chksetRemainderforEmail.Checked)
                    {
                        chkReminder1 = "true";
                    }
                    else
                    {
                        chkReminder1 = "false";
                    }
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_UpdateRemainderPurchaseOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@R_ID", lblRID.Text);
                    cmd.Parameters.AddWithValue("@RelatedToID", lblPurchaseID.Text);
                    cmd.Parameters.AddWithValue("@NotifyDate", Convert.ToDateTime(txtDateNotified.Text));
                    cmd.Parameters.AddWithValue("@SetToReminder", ddlreminderMember.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Description", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@SendMail", chkReminder1);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@Belong", "PurchaseOrder");
                    cmd.Parameters.AddWithValue("@RelatedTo", lblPurchaseOrderid.Text);
                    con.Open();
                    int Result = cmd.ExecuteNonQuery();
                    if (Result < 0)
                    {

                        ViewReminderPurchaseOrderDetails();
                        Clear();
                        Toasteralert.Visible = true;
                        lblMessage.Visible = true;
                        lblMessage.Text = "Leads Reminders Details Update Successfully";

                    }
                    else
                    {

                        Toasteralert.Visible = true;
                        lblMessage.Visible = true;
                        lblMessage.Text = "Leads Reminder Not Update Successfully";
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
                    //lblMessage.Visible = false;
                    //lblMessage.Text = "Error Details Save Successfully";
                }
                else
                {
                    //lblMessage.Visible = false;
                    //lblMessage.Text = "Error Details Not Save Successfully";
                }
                DeviceCon.Close();
            }
            finally

            {

            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PurchaseOrderDetails.aspx", false);
        }
        protected void LnkBtnReminderExcel_Click(object sender, EventArgs e)
        {

        }

        protected void LnkBtnReminderPDF_Click(object sender, EventArgs e)
        {

        }

        protected void LnkBtnReminderVisibility_Click(object sender, EventArgs e)
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
                        SqlCommand cmd = new SqlCommand("SP_ViewRemainderPurchaseOrderDetailsVisibility", con);
                        cmd.CommandTimeout = 600;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(table);
                        GridLeadReminder.DataSource = table;
                        GridLeadReminder.DataBind();
                        ViewState["PurchaseOrder"] = table;
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

        protected void LnkBtnReminderReload_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);

                if (Session["LoginType"].ToString() == "Administrator")
                {
                    ViewReminderPurchaseOrderDetails();
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

        protected void GridLeadReminder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridLeadReminder.Rows)
                {

                    //  System.Web.UI.WebControls.Label lblID1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblID1");
                    System.Web.UI.WebControls.Label lblRowNumber = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblRowNumber");
                    System.Web.UI.WebControls.Label lblnotifyDate1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblnotifyDate1");
                    System.Web.UI.WebControls.Label lblSetToReminder1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblSetToReminder1");
                    System.Web.UI.WebControls.Label lblDescription1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblDescription1");


                    LinkButton lnkbtnresult = (LinkButton)e.Row.FindControl("btnfileAttachment");
                    string status = ((System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblStatuse1")).Text;
                    if (status == "True")
                    {
                        //lblID1.ForeColor = System.Drawing.Color.Black;
                        lblRowNumber.ForeColor = System.Drawing.Color.Blue;
                        lblnotifyDate1.ForeColor = System.Drawing.Color.Blue;
                        lblSetToReminder1.ForeColor = System.Drawing.Color.Blue;
                        lblDescription1.ForeColor = System.Drawing.Color.Blue;

                    }
                    else
                    {

                        //lblID1.ForeColor = System.Drawing.Color.Red;
                        lblRowNumber.ForeColor = System.Drawing.Color.Red;
                        lblnotifyDate1.ForeColor = System.Drawing.Color.Red;
                        lblSetToReminder1.ForeColor = System.Drawing.Color.Red;
                        lblDescription1.ForeColor = System.Drawing.Color.Red;


                    }

                }
            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
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

        protected void btnEditReminder_Click(object sender, EventArgs e)
        {
            try
            {
                //activeRemainder.Disabled = true;

                btnupdateLeadReminder.Visible = true;
                btnClose.Visible = true;
                ///btnCloseLeadReminder.Visible = false;
                btnCreateRemainder.Visible = false;
                btnClear.Visible = false;
                //lnkbtnCreateRemainder.Visible = false;

                string SendMail;
                DeviceCon = new SqlConnection(strconnect);
                string remainderID;
                var rows = GridLeadReminder.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                remainderID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                lblRID.Text = remainderID;  //
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {

                    UserCommand = new SqlCommand("SP_GetRemainderByID", UserCon);
                    UserCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(UserCommand);
                    UserCommand.Parameters.AddWithValue("@R_ID", remainderID);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        // txtDateNotified.Text = dt.Rows[0]["NotifyDate"].ToString();
                        DateTime notifyDate = Convert.ToDateTime(dt.Rows[0]["NotifyDate"]);
                        txtDateNotified.Text = notifyDate.ToString("yyyy-MM-ddTHH:mm");
                        // txtDateNotified.Attributes["value"] = DateTime.Parse(dt.Rows[0]["NotifyDate"].ToString()).ToString("0:dd/MM/yyyy");

                        ddlreminderMember.SelectedItem.Text = dt.Rows[0]["SetToReminder"].ToString();
                        TextBox1.Text = dt.Rows[0]["Description"].ToString();
                        SendMail = dt.Rows[0]["SendMail"].ToString();
                        if (SendMail == "True")
                        {
                            chksetRemainderforEmail.Checked = true;
                        }
                        else
                        {
                            chksetRemainderforEmail.Checked = false;

                        }
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

        protected void btnDeleteReminder_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);

                if (Session["LoginType"].ToString() == "Administrator")
                {
                    string ID;
                    var rows = GridLeadReminder.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                    SqlConnection DeviceCon = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteRemainderPurchaseOrder", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@R_ID", ID);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();

                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "PurchaseOrder Reminder Details Deleted Successfully";



                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "PurchaseOrder Reminder Details Not Deleted";
                    }
                    ViewReminderPurchaseOrderDetails();
                }

                else if (RoleType == Designation)
                {
                    string ID;
                    var rows = GridLeadReminder.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                    SqlConnection DeviceCon = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteRemainderPurchaseOrder", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@R_ID", ID);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();

                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "PurchaseOrder Reminder Details Deleted Successfully";
                        GridLeadReminder.EditIndex = -1;
                        //StaffOperationPermission();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "PurchaseOrder Reminder Details Not Deleted";
                    }
                    ViewReminderPurchaseOrderDetails();

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

        //-------------------------------------Remainder End-------------------------------------------


        public DataTable ViewPurchaseOrderServices(int Projectid)
        {
            DataTable table = new DataTable();
            string PurchaseOrderNo = HttpUtility.UrlDecode(Request.QueryString["PurchaseOrderID"]);
            lblPurchaseOrderid.Text = PurchaseOrderNo;

            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewPurchaseOrderServices", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@ProjectID", Projectid);
                cmd.Parameters.AddWithValue("@PONumber", PurchaseOrderNo);
                ad.Fill(table);
                if (table.Rows.Count > 0)
                {
                    GridServicesList.DataSource = table;
                    GridServicesList.DataBind();

                    //Get the Row that contains this button 
                    foreach (GridViewRow gridviedrow in GridServicesList.Rows)
                    {
                        LinkButton btnEditServices = (LinkButton)gridviedrow.FindControl("btnEditServices");
                        LinkButton btnDeleteServices = (LinkButton)gridviedrow.FindControl("btnDeleteServices");

                        //btnDeleteServices.Visible = true;
                        //btnEditServices.Visible = true;
                    }
                }
                else
                {
                    table.Rows.Add(table.NewRow());
                    GridServicesList.DataSource = table;
                    GridServicesList.DataBind();
                    int totalcolumns = GridServicesList.Rows[0].Cells.Count;

                }
                return table;
            }

        }

        public DataTable ViewPurchaseOrderProcurement(int Projectid)
        {
            DataTable table = new DataTable();
            string PurchaseOrderNo = HttpUtility.UrlDecode(Request.QueryString["PurchaseOrderID"]);
            lblPurchaseOrderid.Text = PurchaseOrderNo;

            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewPurchaseOrderProcurement", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@ProjectID", Projectid);
                cmd.Parameters.AddWithValue("@PONumber", PurchaseOrderNo);
                ad.Fill(table);
                if (table.Rows.Count > 0)
                {
                    GridProcurement.DataSource = table;
                    GridProcurement.DataBind();

                    //Get the Row that contains this button 
                    foreach (GridViewRow gridviedrow in GridProcurement.Rows)
                    {
                        LinkButton btnEditProcurement = (LinkButton)gridviedrow.FindControl("btnEditProcurement");
                        LinkButton btnDeleteProcurement = (LinkButton)gridviedrow.FindControl("btnDeleteProcurement");


                        //btnEditProcurement.Visible = true;
                        //btnDeleteProcurement.Visible = true;
                    }
                }
                else
                {
                    table.Rows.Add(table.NewRow());
                    GridProcurement.DataSource = table;
                    GridProcurement.DataBind();
                    int totalcolumns = GridProcurement.Rows[0].Cells.Count;

                }
                return table;
            }

        }

        public void GetPOProcurementAmount()
        {
            try
            {
                string PurchaseOrderNo = HttpUtility.UrlDecode(Request.QueryString["PurchaseOrderID"]);
                lblPurchaseOrderid.Text = PurchaseOrderNo;

                using (SqlConnection Usercon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetPurchaseOrderProcurementTotalAmount", Usercon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PONumber", PurchaseOrderNo);
                    cmd.Parameters.AddWithValue("@ProjectID", lblProjectNameId.Text);
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblTotalAmountProcurement.Text = dt.Rows[0]["TotalProAmont"].ToString();
                    }
                    else
                    {
                        lblTotalAmountProcurement.Text = "₹" + "0.0";
                    }
                }

                using (SqlConnection Usercon1 = new SqlConnection(strconnect))
                {

                    SqlCommand cmd = new SqlCommand("SP_GetPurchaseOrderServiceTotalAmount", Usercon1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PONumber", PurchaseOrderNo);
                    cmd.Parameters.AddWithValue("@ProjectID", lblProjectNameId.Text);
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblTotalServiceAmount.Text = dt.Rows[0]["TotalServiceAmont"].ToString();
                    }
                    else
                    {
                        lblTotalServiceAmount.Text = "₹" + "0.0";
                    }

                    //--------------------------------------------------------------------//
                    // TotalAmount Purchase Order Costing
                    //----------------------------------------------------------------------//
                    double totalCostAmount = 0, totalProcurement, totalservise;
                    totalProcurement = Convert.ToDouble(lblTotalAmountProcurement.Text);
                    totalservise = Convert.ToDouble(lblTotalServiceAmount.Text);
                    totalCostAmount = totalProcurement + totalservise;
                    lblTotalProjectCost.Text = "₹" + totalCostAmount.ToString();

                    lblTotalServiceAmount.Text = "₹" + totalservise.ToString();
                    lblTotalAmountProcurement.Text = "₹" + totalProcurement.ToString();
                    //lblTotalcost.Text= lblTotalAmountProcu.Text + "+" + lblServicelistTotal.Text;

                    lblTotalAmountProcu.Text = lblTotalAmountProcurement.Text + "+" + lblTotalServiceAmount.Text;
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
        public void GetbyPurchaseOrderNo()
        {
            try
            {
                string PurchaseOrderNo = HttpUtility.UrlDecode(Request.QueryString["PurchaseOrderID"]);
                lblPurchaseOrderid.Text = PurchaseOrderNo;

                using (SqlConnection Usercon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetPurchaseOrderByNumber", Usercon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@PONumber", lblPurchaseOrderid.Text);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        lblPurchaseOrderid.Text = dt.Rows[0]["PONumber"].ToString();
                        lblPurchaseOrderidNO.Text = dt.Rows[0]["PONumber"].ToString();
                        lblProjectNamenamee.Text = dt.Rows[0]["ProjectName"].ToString();
                        lblProjectNameId.Text = dt.Rows[0]["ProjectID"].ToString();
                        lblPoName.Text = dt.Rows[0]["POName"].ToString();
                        lblPurchaseID.Text = dt.Rows[0]["ID"].ToString();


                        GetCompanyAddress();
                        lblcustname.Text = dt.Rows[0]["Cust_Name"].ToString();
                        lblblock.Text = dt.Rows[0]["AddBlock"].ToString() + ",";
                        lbladdressLine1.Text = dt.Rows[0]["AddStreet"].ToString();
                        lblcompanyaddCity.Text = dt.Rows[0]["AddCity"].ToString() + ",";
                        lblcompanyaddDistrict.Text = dt.Rows[0]["AddDistrict"].ToString() + ",";
                        lblcompanyaddState.Text = dt.Rows[0]["AddState"].ToString() + ",";
                        lblcompanyaddCountry1.Text = "India" + ",";
                        lblcompanyaddZIPCode.Text = dt.Rows[0]["Pincode"].ToString() + ",";

                        lblPOdate1.Text = DateTime.Parse(dt.Rows[0]["PODate"].ToString()).ToString("yyyy-MM-dd");
                        lblPOExpiry_Date1.Text = DateTime.Parse(dt.Rows[0]["POExpireDate"].ToString()).ToString("yyyy-MM-dd");
                        btnStatus.Text = dt.Rows[0]["StatusName"].ToString();
                        lblsaleagent1.Text = dt.Rows[0]["SaleAgent"].ToString();
                        lblsaleagentName.Text = dt.Rows[0]["SalesName"].ToString();
                        lblPOprojectname.Text = dt.Rows[0]["ProjectName"].ToString();
                        lblNote1.Text = dt.Rows[0]["ClientNote"].ToString();
                        lbltermsandcodition.Text = dt.Rows[0]["Termcondition"].ToString();
                        txtNoteDescription.Text = dt.Rows[0]["Notes"].ToString();
                        lblEmailPO.Text = dt.Rows[0]["Cust_Email"].ToString();
                        int ProjectID = Convert.ToInt32(lblProjectNameId.Text);

                        ViewPurchaseOrderProcurement(ProjectID);

                        ViewPurchaseOrderServices(ProjectID);

                        GetPOProcurementAmount();
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
        protected void bindStatus()
        {
            //try
            //{
            //    string BelongTo = "Lead";
            //    using (SqlConnection conn = new SqlConnection(strconnect))
            //    {
            //        SqlCommand cmd = new SqlCommand("SP_GetStatusname", conn);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@BelongTo", "Leads");
            //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            //        {
            //            DataSet ds = new DataSet();
            //            sda.Fill(ds);
            //            ddlStatus.DataSource = ds.Tables[0];
            //            ddlStatus.DataTextField = "ProgessStatus";
            //            ddlStatus.DataValueField = "Status_ID";
            //            ddlStatus.DataBind();
            //            ddlStatus.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Status", "0"));
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    using (SqlConnection DeviceCon = new SqlConnection(strconnect))
            //    {
            //        string ErrorMessgage = ex.Message;
            //        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
            //        string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
            //        string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
            //        Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
            //        SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
            //        cmdex.CommandType = CommandType.StoredProcedure;
            //        cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
            //        cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
            //        cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
            //        cmdex.Parameters.AddWithValue("@Method", method);
            //        cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
            //        DeviceCon.Open();
            //        int RowEx = cmdex.ExecuteNonQuery();
            //        if (RowEx < 0)
            //        {
            //            //lblMessage.Visible = false;
            //            //lblMessage.Text = "Error Details Save Successfully";
            //        }
            //        else
            //        {
            //            //lblMessage.Visible = false;
            //            //lblMessage.Text = "Error Details Not Save Successfully";
            //        }
            //    }
            //}

        }

        #endregion

        #region "Event"


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
                            GetbyPurchaseOrderNo();
                            ViewProjectOrder();
                            GetTaskbyLeadsID(lblLeadIdd.Text);
                            int ProjectID = Convert.ToInt32(lblProjectNameId.Text);
                            ViewActivityDetailsByPurchaseOrderID(ProjectID);
                            ViewTaskDetails();
                            ViewReminderPurchaseOrderDetails();

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
                                bindStatus();
                                bindStaff();
                                GetCompanyAddress();
                                GetbyPurchaseOrderNo();
                                ViewFileLeadDetails();
                                ViewProjectOrder();
                                GetTaskbyLeadsID(lblLeadIdd.Text);
                                int ProjectID = Convert.ToInt32(lblProjectNameId.Text);
                                ViewActivityDetailsByPurchaseOrderID(ProjectID);
                                ViewTaskDetails();
                                ViewReminderPurchaseOrderDetails();
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











        #endregion
    }
}