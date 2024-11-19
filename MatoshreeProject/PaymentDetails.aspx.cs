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

using System.Threading;
using System.Diagnostics.Contracts;

using System.Web.UI.DataVisualization.Charting;
using CheckBox = System.Web.UI.WebControls.CheckBox;

using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.pdf.draw;
using Font = iTextSharp.text.Font;
using Color = iTextSharp.text.BaseColor;
using Paragraph = iTextSharp.text.Paragraph;
using System.Net.Mail;
using System.Net;
#endregion

namespace MatoshreeProject
{
    public partial class PaymentDetails : System.Web.UI.Page
    {
        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();

        float Amount_Deo;
        string result, MID, ApprovalStatus;


        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        Phrase phrase = null;

        string DevEmail, DevPassword, DevPort, DevHost;
        string UserEmpName, Password, EmailID1, Designation1, Fname, Lname;
        string StaffEmail1;
        #endregion

        #region " Constructor "


        #endregion

        #region " Private Variables "

        int Id;

      

        private object lblAccept;

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

        public void GetbyInvoiceNo()
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetInvoiceByNumber", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@InvoiceNo", lblInvNo12.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        //---------------------ID--------------------//
                        iblinvoiceid.Text = dt.Rows[0]["ID"].ToString();
                        lblCustID.Text = dt.Rows[0]["CustomerID"].ToString();
                        lblProjectID.Text = dt.Rows[0]["ProjectID"].ToString();

                        lblcustname.Text = dt.Rows[0]["Cust_Name"].ToString();

                        lblInvoicedate1.Text = dt.Rows[0]["InvoiceDate"].ToString();
                        lblExpiry_Date1.Text = dt.Rows[0]["Expiry_Date"].ToString();

                        lblprojectname1.Text = dt.Rows[0]["ProjectName"].ToString();

                        lblInvoiceTotalAMT.Text = dt.Rows[0]["TotalAmount"].ToString();

                        string Todaydate = Convert.ToString(DateTime.Today);

                        //  txtpaymentDate.Attributes["value"] = DateTime.Parse(Todaydate.ToString()).ToString("yyyy-MM-dd");

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
        public void GetCustomerContact()
        {

            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewContactsDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cust_ID", lblCustID.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblContactID.Text = dt.Rows[0]["id"].ToString();
                    lblFitstName.Text = dt.Rows[0]["FullName"].ToString();
                    lblContactPosition.Text = dt.Rows[0]["Position"].ToString();
                    lblContactEmail.Text = dt.Rows[0]["email"].ToString();
                    txtEmailto.Text = dt.Rows[0]["email"].ToString();
                    lblContactPhone.Text = dt.Rows[0]["phonenumber"].ToString();
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

       
        public void SendEmailInvoiceReminder()
        {
            try
            {
                UserName = Session["UserName"].ToString();
                EmailID = Session["EmailID"].ToString();
                Designation = Session["Role"].ToString();
                DeptID = Session["DeptID"].ToString();
                //-----------------Sending Email------------------------//
                GETCredentials();//method for domain password
                EmailID1 = lblContactEmail.Text;
                //Send Email User Password....//
                if (!string.IsNullOrEmpty(DevEmail))
                {
                    using (MailMessage mm = new MailMessage(DevEmail, EmailID1))
                    {
                        //  MailBody
                        mm.Subject = "Reminder of balance due for " + lblInvNo12.Text;
                        string body = "Dear" + lblFitstName.Text + "<br />";

                        body += "I hope you’re doing well!.";
                        body += "This is a friendly reminder that invoice" + lblInvNo12.Text + "is due for payment on one week from today";
                        body += "Please feel free to contact me if you have any questions about the invoice or payment details";
                        body += "Thank you,";
                        body += UserName;
                        body += Designation;
                        body += EmailID;
                        body += lblCompanyName.Text;
                        mm.Body = body;
                        mm.IsBodyHtml = true;
                        mm.Priority = MailPriority.Normal;
                        SmtpClient smtp = new SmtpClient();
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Host = DevHost;
                        //"mail.shinedatameterms.in"
                        //smtp.EnableSsl = false;
                        //smtp.Host = "relay-hosting.secureserver.net";
                        //smtp.UseDefaultCredentials = true;
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

        public void GetPaymentDetailsByID()
        {
            try
            {
                MID = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                lblRefPRimary.Text = MID;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetPaymentDetailsByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", lblRefPRimary.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtAmount.Text = dt.Rows[0]["Amount_Recived"].ToString();
                        txttransationid.Text = dt.Rows[0]["Transation_ID"].ToString();
                        txtnote.Text = dt.Rows[0]["Note"].ToString();
                        txtpaymentDate.Text = DateTime.Parse(dt.Rows[0]["Payment_date"].ToString()).ToString("yyyy-MM-dd");
                        ddlpaymentType.SelectedItem.Text = dt.Rows[0]["Payment_Mode"].ToString();
                        Lblpdate1.Text = DateTime.Parse(dt.Rows[0]["Payment_date"].ToString()).ToString("yyyy-MM-dd");
                        lblpayMode1.Text = dt.Rows[0]["Payment_Mode"].ToString();
                        lblPaytransaction1.Text = dt.Rows[0]["Transation_ID"].ToString();

                        lblcustomerName.Text = dt.Rows[0]["Cust_Name"].ToString();
                        lblAdd_Block.Text = dt.Rows[0]["Add_Block"].ToString();
                        lblAdd_Street.Text = dt.Rows[0]["Add_Street"].ToString();
                        lblAdd_City.Text = dt.Rows[0]["Add_City"].ToString();
                        lblAdd_State.Text = dt.Rows[0]["Add_State"].ToString();
                        lblAdd_PinCode.Text = dt.Rows[0]["Add_PinCode"].ToString();
                        lbltotalamt.Text = "₹ " + dt.Rows[0]["Amount_Recived"].ToString();


                        txtEmailEditor.Text = "Payment recorded for invoice # {invoice_number}" + "\n" +
                            "{ invoice_link}" + "\n" + "Kind regards," + "\n" + "{ email_signature}";
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

        public void GetPaymentDetailsForInvoceByID()
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetPaymentDetailsforInvoiceByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", lblRefPRimary.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblPaymentAmount.Text = dt.Rows[0]["Amount_Recived"].ToString();
                        lblinvoiceAmount.Text = dt.Rows[0]["TotalAmount"].ToString();
                        lblInvNo12.Text = dt.Rows[0]["InvoiceNo"].ToString();
                        lblAmtDeo.Text = dt.Rows[0]["AmountDeo"].ToString();
                    
                        //float  = (float)Convert.ToDouble(lblinvoiceAmount.Text);
                        //float PlaymentAmount = (float)Convert.ToDouble(lblPaymentAmount.Text);
                        //Amount_Deo = InvoiceAmount - PlaymentAmount;
                        //lblAmtDeo.Text = Amount_Deo.ToString();;
                        //float InvoiceAmount = (float)Convert.ToDouble(dt.Rows[0]["TotalAmount"].ToString());
                        //float PaymentAmount = (float)Convert.ToDouble(dt.Rows[0]["Amount_Recived"].ToString());

                        //Amount_Deo = InvoiceAmount - PaymentAmount;

                        //lblAmountDeo1.Text = Amount_Deo.ToString();
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
                    lblCompanyName.Text = dt.Rows[0]["Company_Name"].ToString();
                    lblCompanyaddress.Text = dt.Rows[0]["Address"].ToString();
                    lblcompanycity.Text = dt.Rows[0]["City"].ToString();
                    companydist.Text = dt.Rows[0]["District"].ToString();
                    lblcomapnystate.Text = dt.Rows[0]["State"].ToString();
                    lblcompanyPincode.Text = dt.Rows[0]["Zip_Code"].ToString();
                    lblCountry_Code.Text = dt.Rows[0]["Country_Code"].ToString();
                    lblcompnyphnnum.Text = dt.Rows[0]["Phone"].ToString();
                    lblGstno1.Text = dt.Rows[0]["GST_NO"].ToString();

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

        public DataTable ViewInvoiceDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewInvoiceDetails", con))
                {
                    ad.Fill(table);
                    GridInvoice.DataSource = table;
                    GridInvoice.DataBind();
                }
            }
            return table;
        }

        //public void StaffOperationPermission()
        //{
        //    try
        //    {
        //        UserId = Convert.ToInt32(Session["UserID"]);

        //        string View, Create, Edit, Delete, Globalview;
        //        //-------------Permission Modules----------------------//
        //        using (SqlConnection con = new SqlConnection(strconnect))
        //        {
        //            SqlCommand command = new SqlCommand("SP_ViewWebPagesPemissionByStaffID", con);
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@StaffID", UserId);
        //            command.Parameters.AddWithValue("@SubModule", "Payments");
        //            DataTable dt = new DataTable();
        //            SqlDataAdapter ad = new SqlDataAdapter(command);
        //            ad.Fill(dt);
        //            if (dt.Rows.Count > 0)
        //            {
        //                Globalview = dt.Rows[0]["GlobalView"].ToString();
        //                View = dt.Rows[0]["View"].ToString();
        //                Edit = dt.Rows[0]["Edit"].ToString();
        //                Delete = dt.Rows[0]["Delete"].ToString();
        //                Create = dt.Rows[0]["Create"].ToString();

        //                if (Globalview == "True")
        //                {
        //                    GetPaymentDetailsByID();
        //                    GetPaymentDetailsForInvoceByID();
        //                    GetCompanyAddress();
        //                    ViewInvoiceDetails();
        //                    GetCompanyAddress();
        //                    if (Create == "True")
        //                    {
        //                        addnew.Visible = true;
        //                    }
        //                    else
        //                    {
        //                        addnew.Visible = false;
        //                    }

        //                    if (Edit == "True")
        //                    {

        //                        GridProject.Columns[8].Visible = true;
        //                    }
        //                    else
        //                    {

        //                        GridProject.Columns[8].Visible = false;
        //                    }

        //                    if (Delete == "True")
        //                    {

        //                        GridProject.Columns[9].Visible = true;
        //                    }
        //                    else
        //                    {

        //                        GridProject.Columns[9].Visible = false;
        //                    }
        //                }
        //                else if (View == "True")
        //                {
        //                    //GetPaymentDetailsByID();
        //                    //GetPaymentDetailsForInvoceByID();
        //                    //GetCompanyAddress();
        //                    //ViewInvoiceDetails();
        //                    //GetCompanyAddress();
        //                    if (Create == "True")
        //                    {
        //                        addnew.Visible = true;
        //                    }
        //                    else
        //                    {
        //                        addnew.Visible = false;
        //                    }

        //                    if (Edit == "True")
        //                    {

        //                        GridProject.Columns[8].Visible = true;
        //                    }
        //                    else
        //                    {

        //                        GridProject.Columns[8].Visible = false;
        //                    }

        //                    if (Delete == "True")
        //                    {

        //                        GridProject.Columns[9].Visible = true;
        //                    }
        //                    else
        //                    {

        //                        GridProject.Columns[9].Visible = false;
        //                    }

        //                }
        //                else
        //                {
        //                    Response.Redirect("~/permission.html", true);
        //                }

        //            }
        //            else
        //            {

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        using (SqlConnection DeviceCon = new SqlConnection(strconnect))
        //        {
        //            string ErrorMessgage = ex.Message;
        //            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
        //            string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
        //            string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
        //            Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
        //            SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
        //            cmdex.CommandType = CommandType.StoredProcedure;
        //            cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
        //            cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
        //            cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
        //            cmdex.Parameters.AddWithValue("@Method", method);
        //            cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
        //            DeviceCon.Open();
        //            int RowEx = cmdex.ExecuteNonQuery();
        //            if (RowEx < 0)
        //            {
        //                //lblMessage.Visible = false;
        //                //lblMessage.Text = "Error Details Save Successfully";
        //            }
        //            else
        //            {
        //                //lblMessage.Visible = false;
        //                //lblMessage.Text = "Error Details Not Save Successfully";
        //            }
        //        }
        //    }
        //}
        #endregion

        #region " Event "
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    if (!IsPostBack)
                    {
                        GetPaymentDetailsByID();               
                        GetPaymentDetailsForInvoceByID();
                        GetbyInvoiceNo();
                        GetCustomerContact();
                        GetCompanyAddress();
                        ViewInvoiceDetails();
                    }
                }
                else if (RoleType == Designation)
                {
                    GetPaymentDetailsByID();
                    GetPaymentDetailsForInvoceByID();
                    GetbyInvoiceNo();
                    GetCustomerContact();
                    GetCompanyAddress();
                    ViewInvoiceDetails();
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

        protected void GridInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridInvoice.Rows)
                {  // string  Status = Convert.ToString(e.Row.Cells[8].Text);

                    Label lblInvoiceNumber1 = (Label)gridviedrow.FindControl("lblInvoiceNumber1");
                    Label lblInvoiceDate1 = (Label)gridviedrow.FindControl("lblInvoiceDate1");
                    Label lblInvoiceAmount1 = (Label)gridviedrow.FindControl("lblInvoiceAmount1");
                    Label lblPaymentAmount1 = (Label)gridviedrow.FindControl("lblPaymentAmount1");
                    Label lblAmountDeo1 = (Label)gridviedrow.FindControl("lblAmountDeo1");
                    // float InvoiceAmount = (float)Convert.ToDouble("lblPaymentAmount1");
                    //float PlaymentAmount = (float)Convert.ToDouble("Amount_Recived");
                    //float InvoiceAmount = (float)Convert.ToDouble(lblInvoiceAmount1.Text);
                    //float PlaymentAmount = (float)Convert.ToDouble(lblPaymentAmount1.Text);
                    //Amount_Deo = InvoiceAmount - PlaymentAmount;
                    //lblAmountDeo1.Text = Amount_Deo.ToString();
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

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_UpdatePayment", con);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", lblRefPRimary.Text);
                    cmd.Parameters.AddWithValue("@Transation_ID", txttransationid.Text);
                    cmd.Parameters.AddWithValue("@Payment_Mode", ddlpaymentType.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Payment_date", Convert.ToDateTime(txtpaymentDate.Text).Date);
                    cmd.Parameters.AddWithValue("@Amount_Recived", txtAmount.Text);
                    cmd.Parameters.AddWithValue("@updateby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@Note", txtnote.Text);
                    cmd.Parameters.AddWithValue("@Payment_Method", txtPaymentMethod.Text);
                    con.Open();
                    int Result = cmd.ExecuteNonQuery();
                    if (Result < 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Payment Details Edit Successfully!')", true);

                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Payment Details Not Edit Successfully!')", true);
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
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Payments.aspx", true);
        }

        protected void linkbtnPDF_Click1(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    DataTable table2 = new DataTable();
                    DataTable tableC = new DataTable();
                    DataTable GridInvoice = ViewInvoiceDetails();

                    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
                    MemoryStream memoryStream = new MemoryStream();


                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, memoryStream);
                    doc.Open();
                    PdfPTable tablePaymentInfo = new PdfPTable(2);
                    tablePaymentInfo.WidthPercentage = 100;
                    PdfPCell LeftPaymentInfo = new PdfPCell();
                    LeftPaymentInfo.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    Chunk paymentfrom = new Chunk(lblCompanyName.Text, new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD, Color.BLACK));
                    Phrase paymentfromPh1 = new Phrase
                {
                paymentfrom
                };
                    Paragraph paymentfromparagraph1 = new Paragraph(paymentfromPh1);
                    paymentfromparagraph1.Alignment = Element.ALIGN_LEFT;
                    LeftPaymentInfo.AddElement(paymentfromparagraph1);

                    Chunk paymentaddno16 = new Chunk(lblCompanyaddress.Text, new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.NORMAL, Color.BLACK));
                    Phrase paymentaddPh6 = new Phrase
                {
               paymentaddno16
                };
                    Paragraph tendaddparagraph6 = new Paragraph(paymentaddPh6);
                    tendaddparagraph6.Alignment = Element.ALIGN_LEFT;
                    LeftPaymentInfo.AddElement(tendaddparagraph6);

                    Chunk paymentaddnoD1 = new Chunk("", new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Chunk paymentaddnoD = new Chunk(lblcompanycity.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase paymentaddPhD = new Phrase
                {
                paymentaddnoD1,
                paymentaddnoD
                };
                    Paragraph tendaddparagraphD = new Paragraph(paymentaddPhD);
                    tendaddparagraphD.Alignment = Element.ALIGN_LEFT;
                    LeftPaymentInfo.AddElement(tendaddparagraphD);

                    Chunk paymentaddnoS = new Chunk(companydist.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Chunk paymentaddnoS1 = new Chunk(" ", new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Chunk paymentaddnoS2 = new Chunk(lblcomapnystate.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase paymentaddPhS = new Phrase
                {
                paymentaddnoS,
                paymentaddnoS1,
                paymentaddnoS2
                };
                    Paragraph tendaddparagraphS = new Paragraph(paymentaddPhS);
                    tendaddparagraphS.Alignment = Element.ALIGN_LEFT;
                    LeftPaymentInfo.AddElement(tendaddparagraphS);


                    Chunk paymentaddno29 = new Chunk(lblcompanyPincode.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase paymentaddPh10 = new Phrase
                {
                paymentaddno29
                };
                    Paragraph tendaddparagraph10 = new Paragraph(paymentaddPh10);
                    tendaddparagraph10.Alignment = Element.ALIGN_LEFT;
                    LeftPaymentInfo.AddElement(tendaddparagraph10);

                    Chunk paymentpinaddno2 = new Chunk("Phone:", new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, Color.BLACK));
                    Chunk paymentaddnoP = new Chunk(lblCountry_Code.Text + lblcompnyphnnum.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase paymentaddPh2 = new Phrase
                {
               paymentpinaddno2,
               paymentaddnoP
                };
                    Paragraph tendaddparagraph2 = new Paragraph(paymentaddPh2);
                    tendaddparagraph2.Alignment = Element.ALIGN_LEFT;
                    LeftPaymentInfo.AddElement(tendaddparagraph2);

                    Chunk paymentpinaddno31 = new Chunk("GST No:", new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, Color.BLACK));
                    Chunk paymentaddnoP31 = new Chunk(lblGstno1.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase paymentaddPh31 = new Phrase
                {
               paymentpinaddno31,
               paymentaddnoP31
                };
                    Paragraph tendaddparagraph31 = new Paragraph(paymentaddPh31);
                    tendaddparagraph31.Alignment = Element.ALIGN_LEFT;
                    LeftPaymentInfo.AddElement(tendaddparagraph31);

                    tablePaymentInfo.AddCell(LeftPaymentInfo);

                    //Right 
                    PdfPCell RightPaymentInfo = new PdfPCell();
                    RightPaymentInfo.Border = iTextSharp.text.Rectangle.NO_BORDER;


                    Chunk payment12 = new Chunk(lblcustomerName.Text, new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD, Color.BLACK));
                    Phrase payment1Ph2 = new Phrase
               {
                 payment12
               };
                    Paragraph payment1paragraph2 = new Paragraph(payment1Ph2);
                    payment1paragraph2.Alignment = Element.ALIGN_RIGHT;
                    RightPaymentInfo.AddElement(payment1paragraph2);

                    Chunk payment1addno16 = new Chunk(lblAdd_Block.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase payment1addPh6 = new Phrase
               {
                payment1addno16
               };
                    Paragraph payment1addparagraph6 = new Paragraph(payment1addPh6);
                    payment1addparagraph6.Alignment = Element.ALIGN_RIGHT;
                    RightPaymentInfo.AddElement(payment1addparagraph6);


                    Chunk payment1addno6 = new Chunk(lblAdd_Street.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase payment1addPh1 = new Phrase
                {

                 payment1addno6
                   };
                    Paragraph payment1addparagraph1 = new Paragraph(payment1addPh1);
                    payment1addparagraph1.Alignment = Element.ALIGN_RIGHT;
                    RightPaymentInfo.AddElement(payment1addparagraph1);


                    Chunk payment1addnoD = new Chunk(lblAdd_City.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase payment1addPhD = new Phrase
                {
                    payment1addnoD
                };
                    Paragraph payment1addparagraphD = new Paragraph(payment1addPhD);
                    payment1addparagraphD.Alignment = Element.ALIGN_RIGHT;
                    RightPaymentInfo.AddElement(payment1addparagraphD);


                    Chunk payment1addnoS1 = new Chunk(lblAdd_State.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase payment1addPhS = new Phrase
               {
               payment1addnoS1
               };
                    Paragraph payment1addparagraphS = new Paragraph(payment1addPhS);
                    payment1addparagraphS.Alignment = Element.ALIGN_RIGHT;
                    RightPaymentInfo.AddElement(payment1addparagraphS);

                    Chunk payment13 = new Chunk(lblAdd_PinCode.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase payment1ph3 = new Phrase
               {
                payment13
               };
                    Paragraph payment1paragraph3 = new Paragraph(payment1ph3);
                    payment1paragraph3.Alignment = Element.ALIGN_RIGHT;
                    RightPaymentInfo.AddElement(payment1paragraph3);

                    tablePaymentInfo.AddCell(RightPaymentInfo);
                    doc.Add(tablePaymentInfo);

                    doc.Add(new Paragraph(" "));

                    //Title Payment Receipt
                    PdfPTable tablepayment = new PdfPTable(1);
                    tablepayment.WidthPercentage = 100;
                    PdfPCell paymentcell = new PdfPCell();
                    paymentcell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    Chunk chpayment = new Chunk("PAYMENT RECEIPT", new Font(Font.FontFamily.TIMES_ROMAN, 16f, Font.BOLD, Color.BLACK));
                    Phrase phpayment = new Phrase
               {
               chpayment
               };
                    Paragraph chpaymentparagraph1 = new Paragraph(phpayment);
                    chpaymentparagraph1.Alignment = Element.ALIGN_CENTER;
                    paymentcell.AddElement(chpaymentparagraph1);
                    tablepayment.AddCell(paymentcell);
                    doc.Add(tablepayment);
                    doc.Add(new Paragraph(" "));

                    //Payment Detail---------------------------------------------------

                    PdfPTable NoteTable = new PdfPTable(1);
                    NoteTable.WidthPercentage = 100;
                    PdfPCell NoteCell = new PdfPCell();
                    NoteCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    NoteCell.AddElement(new Paragraph(new Chunk("Payment Date:" + Lblpdate1.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f))));

                    NoteCell.AddElement(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 35.0F, Color.BLACK, Element.ALIGN_LEFT, 1))));

                    NoteCell.AddElement(new Paragraph("Payment Mode :" + lblpayMode1.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f)));

                    NoteCell.AddElement(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 35.0F, Color.BLACK, Element.ALIGN_LEFT, 1))));

                    NoteCell.AddElement(new Paragraph("Transaction ID:" + lblPaytransaction1.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f)));

                    NoteCell.AddElement(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 35.0F, Color.BLACK, Element.ALIGN_LEFT, 1))));

                    NoteTable.AddCell(NoteCell);
                    doc.Add(NoteTable);
                    //------------------toal amount---------------------------------------


                    BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    Font font = new Font(bf, 14);
                    Chunk chunkRupee = new Chunk(" \u20B9 ", font);

                    doc.Add(new Paragraph("\n"));
                    PdfPTable outerTable = new PdfPTable(1);
                    outerTable.WidthPercentage = 100;
                    outerTable.DefaultCell.Border = PdfPCell.NO_BORDER;

                    PdfPTable innerTable = new PdfPTable(2);
                    innerTable.WidthPercentage = 100;
                    innerTable.SetWidths(new float[] { 1, 1 });

                    Chunk TotalChunk = new Chunk("Total Amount : ", new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD));
                    Chunk TotalAmountChunk = new Chunk(lbltotalamt.Text, new Font(Font.FontFamily.HELVETICA, 14f));

                    Phrase phraseAmount = new Phrase
                    {
                     TotalChunk,
                     chunkRupee,
                     TotalAmountChunk
                    };

                    PdfPCell totalAmountCell = new PdfPCell();
                    totalAmountCell.AddElement(phraseAmount);
                    totalAmountCell.Padding = 10;
                    totalAmountCell.BackgroundColor = Color.GREEN;
                    totalAmountCell.Border = PdfPCell.NO_BORDER;
                    totalAmountCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    totalAmountCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    innerTable.AddCell(totalAmountCell);


                    PdfPCell amountValueCell = new PdfPCell(new Phrase("", new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD, Color.WHITE)));
                    amountValueCell.Padding = 10;
                    amountValueCell.Border = PdfPCell.NO_BORDER;
                    innerTable.AddCell(amountValueCell);


                    innerTable.DefaultCell.Border = PdfPCell.NO_BORDER;


                    outerTable.AddCell(innerTable);


                    outerTable.DefaultCell.Border = PdfPCell.NO_BORDER;


                    doc.Add(outerTable);
                    doc.Add(new Paragraph(" "));
                    //------------------------------------------------

                    PdfPTable tableCompanyAddress = new PdfPTable(1);
                    tableCompanyAddress.WidthPercentage = 100;
                    PdfPCell CompanyAddress1 = new PdfPCell();
                    CompanyAddress1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    CompanyAddress1.AddElement(new Paragraph("Payment For", new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD, Color.BLACK)));
                    tableCompanyAddress.AddCell(CompanyAddress1);
                    doc.Add(tableCompanyAddress);
                    doc.Add(new Paragraph(" "));

                    if (GridInvoice != null && GridInvoice.Rows.Count > 0)
                    {
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("InvoiceNo");
                        dtExport.Columns.Add("Expiry_Date");
                        dtExport.Columns.Add("TotalAmount");
                        dtExport.Columns.Add("Amount_Recived");
                        dtExport.Columns.Add("AmountDeo");


                        foreach (DataRow row in GridInvoice.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["InvoiceNo"] = row["InvoiceNo"];
                            newRow["Expiry_Date"] = row["Expiry_Date"];
                            newRow["TotalAmount"] = row["TotalAmount"];
                            newRow["Amount_Recived"] = row["Amount_Recived"];
                            newRow["AmountDeo"] = row["AmountDeo"];

                            dtExport.Rows.Add(newRow);
                            tableC = dtExport;
                        }
                        dtExport.Columns["InvoiceNo"].ColumnName = "Invoice Number";
                        dtExport.Columns["Expiry_Date"].ColumnName = "Invoice Date";
                        dtExport.Columns["TotalAmount"].ColumnName = "Invoice Amount";
                        dtExport.Columns["Amount_Recived"].ColumnName = "Payment Amount";
                        dtExport.Columns["AmountDeo"].ColumnName = "AmountDeo";

                        float[] columnWidths = new float[tableC.Columns.Count];
                        for (int i = 0; i < tableC.Columns.Count; i++)
                        {
                            if (tableC.Columns[i].ColumnName == "InvoiceNo")
                            {
                                columnWidths[i] = 6f;
                            }
                            else if (tableC.Columns[i].ColumnName == "Expiry_Date")
                            {
                                columnWidths[i] = 4f;
                            }
                            else if (tableC.Columns[i].ColumnName == "TotalAmount")
                            {
                                columnWidths[i] = 4f;
                            }
                            else if (tableC.Columns[i].ColumnName == "Amount_Recived")
                            {
                                columnWidths[i] = 4f;
                            }
                            else
                            {
                                columnWidths[i] = 4f;
                            }
                        }

                        Font tableHeaderFont = new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL, Color.WHITE);

                        Font tableDataFont = new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL);
                        PdfPTable pdfTable = new PdfPTable(tableC.Columns.Count);
                        pdfTable.SetWidths(columnWidths);
                        pdfTable.WidthPercentage = 100;
                        foreach (DataColumn column in tableC.Columns)
                        {
                            string columnName = (column.ColumnName == "ID") ? "#" : column.ColumnName;
                            PdfPCell pdfCell = new PdfPCell(new Phrase(columnName, tableHeaderFont));
                            pdfCell.BackgroundColor = Color.BLACK;
                            pdfCell.Padding = 10;
                            pdfTable.AddCell(pdfCell);
                        }
                        foreach (DataRow row in tableC.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                PdfPCell dataCell = new PdfPCell(new Phrase(item.ToString(), tableDataFont));
                                dataCell.Padding = 10;
                                pdfTable.AddCell(dataCell);
                            }
                        }
                        doc.Add(pdfTable);
                    }
                    doc.Add(new Paragraph(" "));
                    //Grifview ViewInvoiceDetails------------------------------------------------

                    //
                    doc.Close();
                    writer.Close();
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=PAYMENTRECEIPT" + ".pdf");
                    HttpContext.Current.Response.BinaryWrite(memoryStream.ToArray());
                    HttpContext.Current.Response.End();
                }
                else if (RoleType == Designation)
                {
                    DataTable table2 = new DataTable();
                    DataTable tableC = new DataTable();
                    DataTable GridInvoice = ViewInvoiceDetails();

                    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
                    MemoryStream memoryStream = new MemoryStream();


                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, memoryStream);
                    doc.Open();
                    PdfPTable tablePaymentInfo = new PdfPTable(2);
                    tablePaymentInfo.WidthPercentage = 100;
                    PdfPCell LeftPaymentInfo = new PdfPCell();
                    LeftPaymentInfo.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    Chunk paymentfrom = new Chunk(lblCompanyName.Text, new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD, Color.BLACK));
                    Phrase paymentfromPh1 = new Phrase
                {
                paymentfrom
                };
                    Paragraph paymentfromparagraph1 = new Paragraph(paymentfromPh1);
                    paymentfromparagraph1.Alignment = Element.ALIGN_LEFT;
                    LeftPaymentInfo.AddElement(paymentfromparagraph1);

                    Chunk paymentaddno16 = new Chunk(lblCompanyaddress.Text, new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.NORMAL, Color.BLACK));
                    Phrase paymentaddPh6 = new Phrase
                {
               paymentaddno16
                };
                    Paragraph tendaddparagraph6 = new Paragraph(paymentaddPh6);
                    tendaddparagraph6.Alignment = Element.ALIGN_LEFT;
                    LeftPaymentInfo.AddElement(tendaddparagraph6);

                    Chunk paymentaddnoD1 = new Chunk("", new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Chunk paymentaddnoD = new Chunk(lblcompanycity.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase paymentaddPhD = new Phrase
                {
                paymentaddnoD1,
                paymentaddnoD
                };
                    Paragraph tendaddparagraphD = new Paragraph(paymentaddPhD);
                    tendaddparagraphD.Alignment = Element.ALIGN_LEFT;
                    LeftPaymentInfo.AddElement(tendaddparagraphD);

                    Chunk paymentaddnoS = new Chunk(companydist.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Chunk paymentaddnoS1 = new Chunk(" ", new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Chunk paymentaddnoS2 = new Chunk(lblcomapnystate.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase paymentaddPhS = new Phrase
                {
                paymentaddnoS,
                paymentaddnoS1,
                paymentaddnoS2
                };
                    Paragraph tendaddparagraphS = new Paragraph(paymentaddPhS);
                    tendaddparagraphS.Alignment = Element.ALIGN_LEFT;
                    LeftPaymentInfo.AddElement(tendaddparagraphS);


                    Chunk paymentaddno29 = new Chunk(lblcompanyPincode.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase paymentaddPh10 = new Phrase
                {
                paymentaddno29
                };
                    Paragraph tendaddparagraph10 = new Paragraph(paymentaddPh10);
                    tendaddparagraph10.Alignment = Element.ALIGN_LEFT;
                    LeftPaymentInfo.AddElement(tendaddparagraph10);

                    Chunk paymentpinaddno2 = new Chunk("Phone:", new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, Color.BLACK));
                    Chunk paymentaddnoP = new Chunk(lblCountry_Code.Text + lblcompnyphnnum.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase paymentaddPh2 = new Phrase
                {
               paymentpinaddno2,
               paymentaddnoP
                };
                    Paragraph tendaddparagraph2 = new Paragraph(paymentaddPh2);
                    tendaddparagraph2.Alignment = Element.ALIGN_LEFT;
                    LeftPaymentInfo.AddElement(tendaddparagraph2);

                    Chunk paymentpinaddno31 = new Chunk("GST No:", new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, Color.BLACK));
                    Chunk paymentaddnoP31 = new Chunk(lblGstno1.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase paymentaddPh31 = new Phrase
                {
               paymentpinaddno31,
               paymentaddnoP31
                };
                    Paragraph tendaddparagraph31 = new Paragraph(paymentaddPh31);
                    tendaddparagraph31.Alignment = Element.ALIGN_LEFT;
                    LeftPaymentInfo.AddElement(tendaddparagraph31);

                    tablePaymentInfo.AddCell(LeftPaymentInfo);

                    //Right 
                    PdfPCell RightPaymentInfo = new PdfPCell();
                    RightPaymentInfo.Border = iTextSharp.text.Rectangle.NO_BORDER;


                    Chunk payment12 = new Chunk(lblcustomerName.Text, new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD, Color.BLACK));
                    Phrase payment1Ph2 = new Phrase
               {
                 payment12
               };
                    Paragraph payment1paragraph2 = new Paragraph(payment1Ph2);
                    payment1paragraph2.Alignment = Element.ALIGN_RIGHT;
                    RightPaymentInfo.AddElement(payment1paragraph2);

                    Chunk payment1addno16 = new Chunk(lblAdd_Block.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase payment1addPh6 = new Phrase
               {
                payment1addno16
               };
                    Paragraph payment1addparagraph6 = new Paragraph(payment1addPh6);
                    payment1addparagraph6.Alignment = Element.ALIGN_RIGHT;
                    RightPaymentInfo.AddElement(payment1addparagraph6);


                    Chunk payment1addno6 = new Chunk(lblAdd_Street.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase payment1addPh1 = new Phrase
                {

                 payment1addno6
                   };
                    Paragraph payment1addparagraph1 = new Paragraph(payment1addPh1);
                    payment1addparagraph1.Alignment = Element.ALIGN_RIGHT;
                    RightPaymentInfo.AddElement(payment1addparagraph1);


                    Chunk payment1addnoD = new Chunk(lblAdd_City.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase payment1addPhD = new Phrase
                {
                    payment1addnoD
                };
                    Paragraph payment1addparagraphD = new Paragraph(payment1addPhD);
                    payment1addparagraphD.Alignment = Element.ALIGN_RIGHT;
                    RightPaymentInfo.AddElement(payment1addparagraphD);


                    Chunk payment1addnoS1 = new Chunk(lblAdd_State.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase payment1addPhS = new Phrase
               {
               payment1addnoS1
               };
                    Paragraph payment1addparagraphS = new Paragraph(payment1addPhS);
                    payment1addparagraphS.Alignment = Element.ALIGN_RIGHT;
                    RightPaymentInfo.AddElement(payment1addparagraphS);

                    Chunk payment13 = new Chunk(lblAdd_PinCode.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f));
                    Phrase payment1ph3 = new Phrase
               {
                payment13
               };
                    Paragraph payment1paragraph3 = new Paragraph(payment1ph3);
                    payment1paragraph3.Alignment = Element.ALIGN_RIGHT;
                    RightPaymentInfo.AddElement(payment1paragraph3);

                    tablePaymentInfo.AddCell(RightPaymentInfo);
                    doc.Add(tablePaymentInfo);

                    doc.Add(new Paragraph(" "));

                    //Title Payment Receipt
                    PdfPTable tablepayment = new PdfPTable(1);
                    tablepayment.WidthPercentage = 100;
                    PdfPCell paymentcell = new PdfPCell();
                    paymentcell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    Chunk chpayment = new Chunk("PAYMENT RECEIPT", new Font(Font.FontFamily.TIMES_ROMAN, 16f, Font.BOLD, Color.BLACK));
                    Phrase phpayment = new Phrase
               {
               chpayment
               };
                    Paragraph chpaymentparagraph1 = new Paragraph(phpayment);
                    chpaymentparagraph1.Alignment = Element.ALIGN_CENTER;
                    paymentcell.AddElement(chpaymentparagraph1);
                    tablepayment.AddCell(paymentcell);
                    doc.Add(tablepayment);
                    doc.Add(new Paragraph(" "));

                    //Payment Detail---------------------------------------------------

                    PdfPTable NoteTable = new PdfPTable(1);
                    NoteTable.WidthPercentage = 100;
                    PdfPCell NoteCell = new PdfPCell();
                    NoteCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    NoteCell.AddElement(new Paragraph(new Chunk("Payment Date:" + Lblpdate1.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f))));

                    NoteCell.AddElement(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 35.0F, Color.BLACK, Element.ALIGN_LEFT, 1))));

                    NoteCell.AddElement(new Paragraph("Payment Mode :" + lblpayMode1.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f)));

                    NoteCell.AddElement(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 35.0F, Color.BLACK, Element.ALIGN_LEFT, 1))));

                    NoteCell.AddElement(new Paragraph("Transaction ID:" + lblPaytransaction1.Text, new Font(Font.FontFamily.TIMES_ROMAN, 12f)));

                    NoteCell.AddElement(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 35.0F, Color.BLACK, Element.ALIGN_LEFT, 1))));

                    NoteTable.AddCell(NoteCell);
                    doc.Add(NoteTable);
                    //------------------toal amount---------------------------------------


                    BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    Font font = new Font(bf, 14);
                    Chunk chunkRupee = new Chunk(" \u20B9 ", font);

                    doc.Add(new Paragraph("\n"));
                    PdfPTable outerTable = new PdfPTable(1);
                    outerTable.WidthPercentage = 100;
                    outerTable.DefaultCell.Border = PdfPCell.NO_BORDER;

                    PdfPTable innerTable = new PdfPTable(2);
                    innerTable.WidthPercentage = 100;
                    innerTable.SetWidths(new float[] { 1, 1 });

                    Chunk TotalChunk = new Chunk("Total Amount : ", new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD));
                    Chunk TotalAmountChunk = new Chunk(lbltotalamt.Text, new Font(Font.FontFamily.HELVETICA, 14f));

                    Phrase phraseAmount = new Phrase
                    {
                     TotalChunk,
                     chunkRupee,
                     TotalAmountChunk
                    };

                    PdfPCell totalAmountCell = new PdfPCell();
                    totalAmountCell.AddElement(phraseAmount);
                    totalAmountCell.Padding = 10;
                    totalAmountCell.BackgroundColor = Color.GREEN;
                    totalAmountCell.Border = PdfPCell.NO_BORDER;
                    totalAmountCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    totalAmountCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    innerTable.AddCell(totalAmountCell);


                    PdfPCell amountValueCell = new PdfPCell(new Phrase("", new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD, Color.WHITE)));
                    amountValueCell.Padding = 10;
                    amountValueCell.Border = PdfPCell.NO_BORDER;
                    innerTable.AddCell(amountValueCell);


                    innerTable.DefaultCell.Border = PdfPCell.NO_BORDER;


                    outerTable.AddCell(innerTable);


                    outerTable.DefaultCell.Border = PdfPCell.NO_BORDER;


                    doc.Add(outerTable);
                    doc.Add(new Paragraph(" "));
                    //------------------------------------------------

                    PdfPTable tableCompanyAddress = new PdfPTable(1);
                    tableCompanyAddress.WidthPercentage = 100;
                    PdfPCell CompanyAddress1 = new PdfPCell();
                    CompanyAddress1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    CompanyAddress1.AddElement(new Paragraph("Payment For", new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD, Color.BLACK)));
                    tableCompanyAddress.AddCell(CompanyAddress1);
                    doc.Add(tableCompanyAddress);
                    doc.Add(new Paragraph(" "));

                    if (GridInvoice != null && GridInvoice.Rows.Count > 0)
                    {
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("InvoiceNo");
                        dtExport.Columns.Add("Expiry_Date");
                        dtExport.Columns.Add("TotalAmount");
                        dtExport.Columns.Add("Amount_Recived");
                        dtExport.Columns.Add("AmountDeo");


                        foreach (DataRow row in GridInvoice.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["InvoiceNo"] = row["InvoiceNo"];
                            newRow["Expiry_Date"] = row["Expiry_Date"];
                            newRow["TotalAmount"] = row["TotalAmount"];
                            newRow["Amount_Recived"] = row["Amount_Recived"];
                            newRow["AmountDeo"] = row["AmountDeo"];

                            dtExport.Rows.Add(newRow);
                            tableC = dtExport;
                        }
                        dtExport.Columns["InvoiceNo"].ColumnName = "Invoice Number";
                        dtExport.Columns["Expiry_Date"].ColumnName = "Invoice Date";
                        dtExport.Columns["TotalAmount"].ColumnName = "Invoice Amount";
                        dtExport.Columns["Amount_Recived"].ColumnName = "Payment Amount";
                        dtExport.Columns["AmountDeo"].ColumnName = "AmountDeo";

                        float[] columnWidths = new float[tableC.Columns.Count];
                        for (int i = 0; i < tableC.Columns.Count; i++)
                        {
                            if (tableC.Columns[i].ColumnName == "InvoiceNo")
                            {
                                columnWidths[i] = 6f;
                            }
                            else if (tableC.Columns[i].ColumnName == "Expiry_Date")
                            {
                                columnWidths[i] = 4f;
                            }
                            else if (tableC.Columns[i].ColumnName == "TotalAmount")
                            {
                                columnWidths[i] = 4f;
                            }
                            else if (tableC.Columns[i].ColumnName == "Amount_Recived")
                            {
                                columnWidths[i] = 4f;
                            }
                            else
                            {
                                columnWidths[i] = 4f;
                            }
                        }

                        Font tableHeaderFont = new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL, Color.WHITE);

                        Font tableDataFont = new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL);
                        PdfPTable pdfTable = new PdfPTable(tableC.Columns.Count);
                        pdfTable.SetWidths(columnWidths);
                        pdfTable.WidthPercentage = 100;
                        foreach (DataColumn column in tableC.Columns)
                        {
                            string columnName = (column.ColumnName == "ID") ? "#" : column.ColumnName;
                            PdfPCell pdfCell = new PdfPCell(new Phrase(columnName, tableHeaderFont));
                            pdfCell.BackgroundColor = Color.BLACK;
                            pdfCell.Padding = 10;
                            pdfTable.AddCell(pdfCell);
                        }
                        foreach (DataRow row in tableC.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                PdfPCell dataCell = new PdfPCell(new Phrase(item.ToString(), tableDataFont));
                                dataCell.Padding = 10;
                                pdfTable.AddCell(dataCell);
                            }
                        }
                        doc.Add(pdfTable);
                    }
                    doc.Add(new Paragraph(" "));
                    //Grifview ViewInvoiceDetails------------------------------------------------

                    //
                    doc.Close();
                    writer.Close();
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=PAYMENTRECEIPT" + ".pdf");
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

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                UserName = Session["UserName"].ToString();
                EmailID = Session["EmailID"].ToString();
                Designation = Session["Role"].ToString();
                DeptID = Session["DeptID"].ToString();
                //-----------------Sending Email------------------------//
                GETCredentials();//method for domain password
                EmailID1 = txtEmailto.Text;
                string cc = txtCC.Text;
                //Send Email User Password....//
                if (!string.IsNullOrEmpty(DevEmail))
                {
                    using (MailMessage mm = new MailMessage(DevEmail, EmailID1))
                    {
                        mm.CC.Add(new MailAddress(cc));
                        //  MailBody
                        mm.Subject = "Payment request for " + lblprojectname1.Text;
                        string body = "Hi " + lblFitstName.Text + "<br />";

                        if (txtEmailEditor.Text == "")
                        {
                            body += "I hope you are doing well.";
                            body += "Thank you for giving us the opportunity to collaborate on " + lblprojectname1.Text + "As discussed earlier, we charge a 30% down payment from our clients. For the same, I have attached a copy of the invoice.";
                            body += "Payment recorded for invoice " + lblInvNo12.Text;
                            body += "You can pay through any of the payment methods stated on the invoice. Please don’t hesitate to reach out in case of any queries.";
                            body += "I look forward to working with you.";
                            //string urllocal = HttpUtility.HtmlEncode("http://localhost:53687/UserLogIn/LogIn");
                            string url = HttpUtility.HtmlEncode("https://minteriors.lissomtech.in/LogIn");      
                            body += "Regards,";
                        }
                        else
                        {
                            body += txtEmailEditor.Text;
                        }
                        body += UserName;
                        body += Designation;
                        body += EmailID;
                        body += lblCompanyName.Text;
                        mm.Body = body;
                        mm.IsBodyHtml = true;
                        mm.Priority = MailPriority.Normal;
                        SmtpClient smtp = new SmtpClient();
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Host = DevHost;
                        //"mail.shinedatameterms.in"
                        //smtp.EnableSsl = false;
                        //smtp.Host = "relay-hosting.secureserver.net";
                        //smtp.UseDefaultCredentials = true;
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

        protected void LinkbtnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Payments.aspx", false);
        }
        #endregion

    }
}