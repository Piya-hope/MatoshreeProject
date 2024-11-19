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
using static System.Net.Mime.MediaTypeNames;
using iTextSharp.text.pdf;
using iTextSharp.text;


using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using iTextSharp.text.pdf;
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

#endregion

namespace MatoshreeProject
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result, Status;
        string DevEmail, DevPassword, DevPort, DevHost;
        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        Phrase phrase = null;


        #endregion

        #region " Constructor "
        #endregion

        #region " Private Variables "
        #endregion

        #region " Public Properties "


        #endregion

        #region " Shared Variables "
        #endregion

        #region " Public Variables "
        #endregion

        #region " Public Function "

        public void ClearReminder()
        {
            txtDateNotified.Text = string.Empty;
            ddlSetReminderStaff.SelectedIndex = 0;
            txtDescriptionReminder.Text = string.Empty;
            Chkboxformail.Checked = false;
        }


        //-----------------WorkOrder---------------------------------------//
        public DataTable ViewWorkorderDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_ViewWorkOrderDetailsByVendorID", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@VendorId", lblVendorID.Text);
                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                ad.Fill(table);
                GridWorkorderlist.DataSource = table;
                GridWorkorderlist.DataBind();
                ViewState["DataWorkOrder"] = table;
            }
            return table;


        }
        //-----------------payment & Expenses------------------------------//

        public DataTable ViewProjectPurchase()
        {


            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_ViewProjectPurchaseByVendorID", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@VendorId ", lblVendorID.Text);
                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                ad.Fill(table);
                GridProjectPurchase.DataSource = table;
                GridProjectPurchase.DataBind();
                ViewState["DataExpenses"] = table;
            }
            return table;
        }
        //---------------------------------Contract Vendor-----------------//
        public DataTable ViewContractVendor()
        {


            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_ViewContract_VendorByVenderID", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@VendorId", lblVendorID.Text);
                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                ad.Fill(table);
                GridContractVendor.DataSource = table;
                GridContractVendor.DataBind();
                ViewState["DataContract"] = table;
            }
            return table;
        }
        //---------------------------------Project-------------------------//


        public DataTable ViewProjetctDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_ViewProjectDetailsByVendorId", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@VendorId", lblVendorID.Text);
                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                ad.Fill(table);
                GridProject.DataSource = table;
                GridProject.DataBind();
                ViewState["DataProject"] = table;
            }
            return table;
        }
        //------------------------------TASK-------------------------------//
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
            }
            return table;
        }
        public DataTable GetTaskbyVendor()
        {
            DataTable table = new DataTable();
            DataColumn dataColumn = new DataColumn();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                // SqlCommand sqlCommand = new SqlCommand("SP_ViewTaskStaffByVendorID", con)
                SqlCommand sqlCommand = new SqlCommand("SP_ViewTaskStaffByVendorName", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                // sqlCommand.Parameters.AddWithValue("@VendorID ", lblVendorID.Text); 
                sqlCommand.Parameters.AddWithValue("@Vend_Name ", txtVendorName.Text);
                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                ad.Fill(table);
                GridTask1.DataSource = table;
                GridTask1.DataBind();
                ViewState["DataTask"] = table;
            }
            return table;
        }

        //----------------------------------File--------------------------//
        public DataTable ViewFilesDetails(string VendorId)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_ViewAttachmentFilesModules", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RelatedTOID", lblVendorID.Text);
                sqlCommand.Parameters.AddWithValue("@BelongTo", "Vendor");
                sqlCommand.Parameters.AddWithValue("@Related", txtVendorName.Text);
                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                ad.Fill(table);
                GridFile.DataSource = table;
                GridFile.DataBind();
                ViewState["DataFile"] = table;
            }
            return table;
        }


        //-----------------REMINDER-------------------------------------//
        protected void bindSetReminderStaff()
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
                    ddlSetReminderStaff.DataSource = ds.Tables[0];
                    ddlSetReminderStaff.DataTextField = "First_Name";
                    ddlSetReminderStaff.DataValueField = "Staff_ID";
                    ddlSetReminderStaff.DataBind();
                    ddlSetReminderStaff.Items.Insert(0, new ListItem("Select Reminder To", "0"));
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
                        // lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }
        }

        public DataTable ViewRemainderDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_ViewRemainderDetailsVendor", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@VendorID", lblVendorID.Text);
                sqlCommand.Parameters.AddWithValue("@Belong", "Vendor");
                sqlCommand.Parameters.AddWithValue("@vendor", txtVendorName.Text);
                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                ad.Fill(table);
                GridviewRemainder1.DataSource = table;
                GridviewRemainder1.DataBind();
                ViewState["DataReminder"] = table;
            }
            return table;
        }

        public void GETCredentials()
        {

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

        public void SendEmail()
        {
            //try
            //{
            //    UserName = Session["UserName"].ToString();
            //    EmailID = Session["EmailID"].ToString();
            //    Designation = Session["Role"].ToString();
            //    DeptID = Session["DeptID"].ToString();
            //    //  -----------------Sending Email------------------------//
            //    GETCredentials();//method for domain password
            //    string EmailID1 = lblContactEmail.Text;

            //    if (!string.IsNullOrEmpty(DevEmail))
            //    {
            //        using (MailMessage mm = new MailMessage(DevEmail, EmailID1))
            //        {
            //            //  MailBody
            //            mm.Subject = "Reminder of balance due for " + lblInvoiceno.Text;
            //            string body = "Dear" + lblFitstName.Text + "<br />";

            //            body += "This is a friendly reminder that your payment is now past due.";
            //            body += "According to our records," + lblInvoiceno.Text + "is past due for the payment of  " + lblInvoiceTotalAMT.Text + "as of  " + lblExpiry_Date1.Text;
            //            body += "In accordance with our policies, a late fee of " + lblInvoiceTotalAMT.Text + "has been assessed.";
            //            body += "At your earliest convenience, please make your payment here: " + lblPaymentMode1.Text;
            //            body += "If you have any questions or need to discuss your account, you can reach me at " + lblphoneNo.Text;
            //            body += "Thank you for your attention to this matter and your continued business.";
            //            body += "Sincerely,";
            //            body += UserName;
            //            body += Designation;
            //            body += EmailID;
            //            body += lbladdCompany11.Text;
            //            mm.Body = body;
            //            mm.IsBodyHtml = true;
            //            mm.Priority = MailPriority.Normal;
            //            SmtpClient smtp = new SmtpClient();
            //            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //            smtp.Host = DevHost;
            //            "mail.shinedatameterms.in"
            //                smtp.EnableSsl = false;
            //            smtp.Host = "relay-hosting.secureserver.net";
            //            smtp.UseDefaultCredentials = true;
            //            NetworkCredential NetworkCred = new NetworkCredential(DevEmail, DevPassword);
            //            smtp.Credentials = NetworkCred;
            //            smtp.Port = Convert.ToInt32(DevPort);

            //            try
            //            {
            //                smtp.Send(mm);
            //                ViewBag.Message = "Email Send Successfully";
            //            }
            //            catch (Exception ex)
            //            {
            //                Response.Write("<script>alert('Email Not Send '); </script>");
            //            }
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
            //finally { }
        }

        public void SendEmailInvoiceReminder()
        {
            //try
            //{
            //    UserName = Session["UserName"].ToString();
            //    EmailID = Session["EmailID"].ToString();
            //    Designation = Session["Role"].ToString();
            //    DeptID = Session["DeptID"].ToString();
            //    // -----------------Sending Email------------------------//
            //    GETCredentials();//method for domain password
            //    EmailID1 = lblContactEmail.Text;

            //    if (!string.IsNullOrEmpty(DevEmail))
            //    {
            //        using (MailMessage mm = new MailMessage(DevEmail, EmailID1))
            //        {

            //            mm.Subject = "Reminder of balance due for " + lblInvoiceno.Text;
            //            string body = "Dear" + lblFitstName.Text + "<br />";

            //            body += "I hope you’re doing well!.";
            //            body += "This is a friendly reminder that invoice" + lblInvoiceno.Text + "is due for payment on one week from today";
            //            body += "Please feel free to contact me if you have any questions about the invoice or payment details";
            //            body += "Thank you,";
            //            body += UserName;
            //            body += Designation;
            //            body += EmailID;
            //            body += lbladdCompany1.Text;
            //            mm.Body = body;
            //            mm.IsBodyHtml = true;
            //            mm.Priority = MailPriority.Normal;
            //            SmtpClient smtp = new SmtpClient();
            //            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //            smtp.Host = DevHost;
            //            "mail.shinedatameterms.in"
            //                    smtp.EnableSsl = false;
            //            smtp.Host = "relay-hosting.secureserver.net";
            //            smtp.UseDefaultCredentials = true;
            //            NetworkCredential NetworkCred = new NetworkCredential(DevEmail, DevPassword);
            //            smtp.Credentials = NetworkCred;
            //            smtp.Port = Convert.ToInt32(DevPort);

            //            try
            //            {
            //                smtp.Send(mm);
            //                ViewBag.Message = "Email Send Successfully";
            //            }
            //            catch (Exception ex)
            //            {
            //                Response.Write("<script>alert('Email Not Send '); </script>");
            //            }
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
            //finally { }
        }


        //---------------------Employee------------------------------------//
        public DataTable ViewContactDetailsEmpID()
        {
            UserId = Convert.ToInt32(Session["UserID"]);
            string Vend_ID = HttpUtility.UrlDecode(Request.QueryString["ID"]);
            lblVendorID.Text = Vend_ID;
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewVenderContactsDetailsbyEmpID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Vender_id", lblVendorID.Text);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GriExitingContact.DataSource = dt;
                GriExitingContact.DataBind();
                ViewState["Data"] = table;
            }
            return table;
        }

        public void VendorContactCount()
        {
            //-------------TotalCount----------------------//
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                con.Open();
                SqlCommand command = new SqlCommand("SP_GetTotalVendorContactssCount", con);
                command.CommandType = CommandType.StoredProcedure;
                int totalVendorContactssCount = (int)command.ExecuteScalar();

                //lblTotalProject_PurchaseCount.Text = Convert.ToString(totalVendorContactssCount);
            }

            //-------------ActiveCount----------------------//
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                con1.Open();
                SqlCommand command = new SqlCommand("SP_GetActiveVendorContactssCount", con1);
                command.CommandType = CommandType.StoredProcedure;
                int activeVendorContactssCount = (int)command.ExecuteScalar();

                // lblActiveProject_PurchaseCount.Text = Convert.ToString(activeVendorContactssCount);
            }

            //-------------InActiveCount----------------------//

            using (SqlConnection con2 = new SqlConnection(strconnect))
            {
                con2.Open();
                SqlCommand command = new SqlCommand("SP_GetInactiveVendorContactsCount", con2);
                command.CommandType = CommandType.StoredProcedure;
                int inactiveVendorContactssCount = (int)command.ExecuteScalar();

                // lblInActiveProject_PurchaseCount.Text = Convert.ToString(inactiveVendorContactssCount);
            }
        }
        public DataTable ViewVenderContactDetails()
        {
            string Vend_ID = HttpUtility.UrlDecode(Request.QueryString["ID"]);
            lblVendorID.Text = Vend_ID;
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewVenderContactsDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Vender_id", Vend_ID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
                GriExitingContact.DataSource = dt;
                GriExitingContact.DataBind();
                ViewState["ContactVendorData"] = dt;
            }
            return dt;
        }

        public void Clear()
        {

            ddlCountryBilling.SelectedIndex = -1;
            txtVendorName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtCompany.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtGSTNumber.Text = string.Empty;
            txtStreetBilling.Text = string.Empty;
            ddlBilingState.ClearSelection();
            ddlBillingdistrict.ClearSelection();
            ddlBillingcity.ClearSelection();
            txtflatBilling.Text = string.Empty;
            txtStreetBilling.Text = string.Empty;
            txtPinBilling.Text = string.Empty;
            ddlCountryBilling.ClearSelection();
            ddlCountryShipping.ClearSelection();
            ddlstateShipping1.ClearSelection();
            ddldistrictShipping.ClearSelection();
            ddlcityShipping1.ClearSelection();
            txtFlatSfipping.Text = string.Empty;
            txtFlatSfipping.Text = string.Empty;
            txtStreetShipping2.Text = string.Empty;
            txtPinShipping.Text = string.Empty;
            ddlCountryShipping.ClearSelection();

            ddlCountryShipping.SelectedIndex = -1;
            ddldistrictShipping.SelectedIndex = -1;
            ddlcityShipping1.SelectedIndex = -1;
            ddlstateShipping1.SelectedIndex = -1;

            ddlBilingState.SelectedIndex = -1;
            ddlBillingdistrict.SelectedIndex = -1;
            ddlBillingcity.SelectedIndex = -1;
            ddlCountryBilling.SelectedIndex = -1;
        }


        public void GetVendorDetailsByID()
        {
            try
            {
                string Vend_ID = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                lblVendorID.Text = Vend_ID;

                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetVendorDetailsByID", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Vend_ID", Vend_ID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ddlCountryBilling.SelectedItem.Text = dt.Rows[0]["VAdd_Country"].ToString();
                    ddlCountryShipping.SelectedItem.Text = dt.Rows[0]["VAdd_Country"].ToString();
                    txtVendorName.Text = dt.Rows[0]["Vend_Name"].ToString();
                    txtEmail.Text = dt.Rows[0]["Vend_Email"].ToString();
                    txtPhone.Text = dt.Rows[0]["Vend_phone"].ToString();
                    txtCompany.Text = dt.Rows[0]["Company"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtGSTNumber.Text = dt.Rows[0]["GST_No"].ToString();

                    txtflatBilling.Text = dt.Rows[0]["VAdd_Block"].ToString();
                    ddlBilingState.SelectedItem.Text = dt.Rows[0]["VAdd_State"].ToString();
                    txtStreetBilling.Text = dt.Rows[0]["VAdd_Street"].ToString();
                    ddlBillingcity.SelectedItem.Text = dt.Rows[0]["VAdd_City"].ToString();
                    txtPinBilling.Text = dt.Rows[0]["VAdd_PinCode"].ToString();
                    ddlBillingdistrict.SelectedItem.Text = dt.Rows[0]["VAdd_District"].ToString();
                    txtFlatSfipping.Text = dt.Rows[0]["Ship_Block"].ToString();

                    txtStreetShipping2.Text = dt.Rows[0]["Shipp_Add_Street"].ToString();
                    ddlcityShipping1.SelectedItem.Text = dt.Rows[0]["Shipp_Add_City"].ToString();
                    ddlstateShipping1.SelectedItem.Text = dt.Rows[0]["Shipp_Add_State"].ToString();
                    txtPinShipping.Text = dt.Rows[0]["Shipp_Add_PinCode"].ToString();
                    ddldistrictShipping.SelectedItem.Text = dt.Rows[0]["Shipp_Add_Distict"].ToString();


                    Status = dt.Rows[0]["Status"].ToString();
                    if (Status == "True")
                    {
                        RadioButtonListVendor.SelectedValue = "1";
                    }
                    else
                    {
                        RadioButtonListVendor.SelectedValue = "0";
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
            finally
            {
            }
        }
        #endregion

        #region " Private Functions "
        #endregion

        #region " Protected Functions "
        public void BindStateDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetState", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlstateShipping1.DataSource = ds.Tables[0];
                    ddlstateShipping1.DataTextField = "State_Name";
                    ddlstateShipping1.DataValueField = "ID";
                    ddlstateShipping1.DataBind();
                    ddlstateShipping1.Items.Insert(0, new ListItem("Select State", "0"));


                    ddlBilingState.DataSource = ds.Tables[0];
                    ddlBilingState.DataTextField = "State_Name";
                    ddlBilingState.DataValueField = "ID";
                    ddlBilingState.DataBind();
                    ddlBilingState.Items.Insert(0, new ListItem("Select State", "0"));
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

        public void BindDistrictDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetDistrict", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddldistrictShipping.DataSource = ds.Tables[0];
                    ddldistrictShipping.DataTextField = "Disttrict_Name";
                    ddldistrictShipping.DataValueField = "District_ID";
                    ddldistrictShipping.DataBind();
                    ddldistrictShipping.Items.Insert(0, new ListItem("Select District", "0"));

                    ddlBillingdistrict.DataSource = ds.Tables[0];
                    ddlBillingdistrict.DataTextField = "Disttrict_Name";
                    ddlBillingdistrict.DataValueField = "District_ID";
                    ddlBillingdistrict.DataBind();
                    ddlBillingdistrict.Items.Insert(0, new ListItem("Select District", "0"));
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

        public void BindCityDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetCity", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlcityShipping1.DataSource = ds.Tables[0];
                    ddlcityShipping1.DataTextField = "City";
                    ddlcityShipping1.DataValueField = "ID";
                    ddlcityShipping1.DataBind();
                    ddlcityShipping1.Items.Insert(0, new ListItem("Select City", "0"));

                    ddlBillingcity.DataSource = ds.Tables[0];
                    ddlBillingcity.DataTextField = "City";
                    ddlBillingcity.DataValueField = "ID";
                    ddlBillingcity.DataBind();
                    ddlBillingcity.Items.Insert(0, new ListItem("Select City", "0"));
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

        //---------------------Permission------------------------------------//
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
                    command.Parameters.AddWithValue("@SubModule", "VENDOR");
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
                            BindStateDetails();
                            BindDistrictDetails();
                            BindCityDetails();
                            GetVendorDetailsByID();

                            //VendorContactCount();
                            ViewVenderContactDetails();
                            GetCompanyAddress();

                            if (Create == "True")
                            {
                                //addnew.Visible = true;
                            }
                            else
                            {
                                //addnew.Visible = false;
                            }

                            if (Edit == "True")
                            {

                                GriExitingContact.Columns[8].Visible = true;

                            }
                            else
                            {

                                GriExitingContact.Columns[8].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                GriExitingContact.Columns[9].Visible = true;
                            }
                            else
                            {

                                GriExitingContact.Columns[9].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {
                            BindStateDetails();
                            BindDistrictDetails();
                            BindCityDetails();
                            GetVendorDetailsByID();

                            //VendorContactCount();
                            ViewContactDetailsEmpID();
                            GetCompanyAddress();

                            if (Create == "True")
                            {
                                // addnew.Visible = true;
                            }
                            else
                            {
                                //addnew.Visible = false;
                            }

                            if (Edit == "True")
                            {

                                GriExitingContact.Columns[8].Visible = true;

                            }
                            else
                            {

                                GriExitingContact.Columns[8].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                GriExitingContact.Columns[9].Visible = true;
                            }
                            else
                            {

                                GriExitingContact.Columns[9].Visible = false;
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
                            BindStateDetails();
                            BindDistrictDetails();
                            BindCityDetails();
                            GetVendorDetailsByID();

                            //VendorContactCount();
                            ViewVenderContactDetails();
                            GetCompanyAddress();

                            bindSetReminderStaff();
                            ViewWorkorderDetails();
                            ViewProjectPurchase();
                            ViewContractVendor();
                            ViewProjetctDetails();
                            ViewRemainderDetails();


                            GetTaskbyVendor();

                            //ViewRemainderDetails(lblID.Text);
                            ViewFilesDetails(lblID.Text);
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
                SqlConnection UserCon = new SqlConnection(strconnect);
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

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);  // db connect
                SqlCommand cmd = new SqlCommand("SP_UpdateVendor", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Vend_ID", lblVendorID.Text);
                cmd.Parameters.AddWithValue("@Vend_Name", txtVendorName.Text);
                cmd.Parameters.AddWithValue("@Vend_Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Vend_Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Company", txtCompany.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Gst_No", txtGSTNumber.Text);
                cmd.Parameters.AddWithValue("@VAdd_Country", ddlCountryBilling.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@VAdd_Block", txtflatBilling.Text);
                cmd.Parameters.AddWithValue("@VAdd_Street", txtStreetBilling.Text);
                cmd.Parameters.AddWithValue("@VAdd_City", ddlBillingcity.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@VAdd_District", ddlBillingdistrict.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@VAdd_State", ddlBilingState.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@VAdd_PinCode", txtPinBilling.Text);
                cmd.Parameters.AddWithValue("@Ship_Block", txtFlatSfipping.Text);
                cmd.Parameters.AddWithValue("@Shipp_Add_Street", txtStreetShipping2.Text);
                cmd.Parameters.AddWithValue("@Shipp_Add_City", ddlcityShipping1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Shipp_Add_Distict", ddldistrictShipping.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Shipp_Add_State", ddlstateShipping1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Shipp_Add_PinCode", txtPinShipping.Text);
                cmd.Parameters.AddWithValue("@Status", RadioButtonListVendor.SelectedValue);
                cmd.Parameters.AddWithValue("@Updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i < 0)
                {
                    string edit = "xcvfedit";
                    Response.Redirect("~/Vendor.aspx?edit1=" + edit + "", false);
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Vendor Details Not Edit Successfully";
                }
                Clear();
                con.Close();
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
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
            Response.Redirect("~/Vendor.aspx", false);
        }


        protected void btnCopyCustomerInfo_Click(object sender, EventArgs e)
        {
            try
            {

                ddlCountryShipping.SelectedItem.Text = ddlCountryBilling.SelectedItem.Text;
                ddlstateShipping1.SelectedItem.Text = ddlBilingState.SelectedItem.Text;
                int stateid = Convert.ToInt32(ddlBilingState.SelectedItem.Value);
                getdistrictbystateId(stateid);

                ddldistrictShipping.SelectedItem.Text = ddlBillingdistrict.SelectedItem.Text;
                int districtid = Convert.ToInt32(ddlBillingdistrict.SelectedItem.Value);
                getcitybydistrictid(districtid);

                ddlcityShipping1.SelectedItem.Text = ddlBillingcity.SelectedItem.Text;
                txtFlatSfipping.Text = txtflatBilling.Text;

                txtStreetShipping2.Text = txtStreetBilling.Text;

                txtPinShipping.Text = txtPinBilling.Text;
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

        protected void btnCopyBillingInfo_Click(object sender, EventArgs e)
        {
            try
            {
                //BindDistrictDetails();
                //BindCityDetails();
                ddlCountryBilling.SelectedItem.Text = ddlCountryShipping.SelectedItem.Text;
                ddlBilingState.SelectedItem.Text = ddlstateShipping1.SelectedItem.Text;
                int stateid = Convert.ToInt32(ddlstateShipping1.SelectedItem.Value);
                getdistrictbystateId1(stateid);

                ddlBillingdistrict.SelectedItem.Text = ddldistrictShipping.SelectedItem.Text;
                int districtid = Convert.ToInt32(ddldistrictShipping.SelectedItem.Value);
                getcitybydistrictid2(districtid);

                ddlBillingcity.SelectedItem.Text = ddlcityShipping1.SelectedItem.Text;
                txtflatBilling.Text = txtFlatSfipping.Text;
                txtStreetBilling.Text = txtStreetShipping2.Text;
                txtPinBilling.Text = txtPinShipping.Text;
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
        public void getdistrictbystateId(int stateid)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetDistrictbyStateid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@State_ID", stateid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddldistrictShipping.DataSource = ds.Tables[0];
                    ddldistrictShipping.DataTextField = "Disttrict_Name";
                    ddldistrictShipping.DataValueField = "District_ID";
                    ddldistrictShipping.DataBind();
                    ddldistrictShipping.Items.Insert(0, new ListItem("Select District Name", "0"));
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

        public void getdistrictbystateId1(int stateid)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetDistrictbyStateid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@State_ID", stateid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlBillingdistrict.DataSource = ds.Tables[0];
                    ddlBillingdistrict.DataTextField = "Disttrict_Name";
                    ddlBillingdistrict.DataValueField = "District_ID";
                    ddlBillingdistrict.DataBind();
                    ddlBillingdistrict.Items.Insert(0, new ListItem("Select District Name", "0"));
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

        public void getcitybydistrictid(int distrctid)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetcitybyDistrictid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@District_ID", distrctid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlcityShipping1.DataSource = ds.Tables[0];
                    ddlcityShipping1.DataTextField = "City";
                    ddlcityShipping1.DataValueField = "ID";
                    ddlcityShipping1.DataBind();
                    ddlcityShipping1.Items.Insert(0, new ListItem("Select City Name", "0"));
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

        public void getcitybydistrictid2(int distrctid)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetcitybyDistrictid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@District_ID", distrctid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlBillingcity.DataSource = ds.Tables[0];
                    ddlBillingcity.DataTextField = "City";
                    ddlBillingcity.DataValueField = "ID";
                    ddlBillingcity.DataBind();
                    ddlBillingcity.Items.Insert(0, new ListItem("Select City Name", "0"));
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

        protected void ddlstateShipping1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Stateid = Convert.ToInt32(ddlstateShipping1.SelectedValue);
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetDistrictbyStateid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@State_ID", Stateid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddldistrictShipping.DataSource = ds.Tables[0];
                    ddldistrictShipping.DataTextField = "Disttrict_Name";
                    ddldistrictShipping.DataValueField = "District_ID";
                    ddldistrictShipping.DataBind();
                    ddldistrictShipping.Items.Insert(0, new ListItem("Select District Name", "0"));
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


        protected void ddldistrictShipping_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Districtid = Convert.ToInt32(ddldistrictShipping.SelectedValue);
                //subcategory bind  @categyid = categoryid

                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetcitybyDistrictid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@District_ID", Districtid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlcityShipping1.DataSource = ds.Tables[0];
                    ddlcityShipping1.DataTextField = "City";
                    ddlcityShipping1.DataValueField = "ID";
                    ddlcityShipping1.DataBind();
                    ddlcityShipping1.Items.Insert(0, new ListItem("Select City Name", "0"));

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


        protected void ddlBillingdistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Districtid = Convert.ToInt32(ddlBillingdistrict.SelectedValue);
                //subcategory bind  @categyid = categoryid

                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetcitybyDistrictid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@District_ID", Districtid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlBillingcity.DataSource = ds.Tables[0];
                    ddlBillingcity.DataTextField = "City";
                    ddlBillingcity.DataValueField = "ID";
                    ddlBillingcity.DataBind();
                    ddlBillingcity.Items.Insert(0, new ListItem("Select City Name", "0"));

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

        protected void ddlBilingState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Stateid = Convert.ToInt32(ddlBilingState.SelectedValue);
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetDistrictbyStateid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@State_ID", Stateid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlBillingdistrict.DataSource = ds.Tables[0];
                    ddlBillingdistrict.DataTextField = "Disttrict_Name";
                    ddlBillingdistrict.DataValueField = "District_ID";
                    ddlBillingdistrict.DataBind();
                    ddlBillingdistrict.Items.Insert(0, new ListItem("Select District Name", "0"));
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

        //----------------------------------------------------------------------------//
        // Contact
        //----------------------------------------------------------------------------//
        protected void btnNewContact_Click(object sender, EventArgs e)
        {
            string ID = lblVendorID.Text;
            Response.Redirect("~/New_Vender_Contact.aspx?ID=" + ID + "", false);

        }

        protected void btnEditContacts11_Click(object sender, EventArgs e)
        {
            try
            {
                string ID1;
                var rows = GriExitingContact.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);

                ID1 = ((Label)rows[rowindex].FindControl("lblContact_id1")).Text;

                Response.Redirect("~/Edit_Vender_Contact.aspx?ID=" + ID1, false);
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

  
        protected void BTN_Visibility_Click1(object sender, EventArgs e)
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
                        SqlCommand cmd = new SqlCommand("SP_ViewVenderContactsDetailsVisibility", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@VendorID", lblVendorID.Text);
                        SqlDataAdapter ad = new SqlDataAdapter();
                        ad.Fill(table);
                        GriExitingContact.DataSource = table;
                        GriExitingContact.DataBind();

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

        protected void lnkbtnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    DataTable dt = ViewVenderContactDetails();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        Response.AddHeader("Content-Disposition", "attachment;filename=Vendor_Contact_Details.xls");

                        Response.Charset = " ";

                        // Create a new DataTable with only the desired columns
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("id");
                        dtExport.Columns.Add("FullName");
                        dtExport.Columns.Add("email");
                        dtExport.Columns.Add("direction");
                        dtExport.Columns.Add("Position");
                        dtExport.Columns.Add("phonenumber");

                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["id"];
                            newRow["FullName"] = row["FullName"];
                            newRow["Email"] = row["email"];
                            newRow["Direction"] = row["direction"];
                            newRow["Position"] = row["Position"];
                            newRow["phonenumber"] = row["phonenumber"];

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
                    DataTable dt = (DataTable)ViewState["ContactVendorData"];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        Response.AddHeader("Content-Disposition", "attachment;filename=Vendor_Contact_Details.xls");

                        Response.Charset = " ";

                        // Create a new DataTable with only the desired columns
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("id");
                        dtExport.Columns.Add("FullName");
                        dtExport.Columns.Add("email");
                        dtExport.Columns.Add("direction");
                        dtExport.Columns.Add("Position");
                        dtExport.Columns.Add("phonenumber");

                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["id"];
                            newRow["FullName"] = row["FullName"];
                            newRow["Email"] = row["email"];
                            newRow["Direction"] = row["direction"];
                            newRow["Position"] = row["Position"];
                            newRow["phonenumber"] = row["phonenumber"];

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

        //=====================================================================//
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


        protected void linkbtnPDF_Click(object sender, EventArgs e)
        {
            try
            {

                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    int _totalColumns = 6;//
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(6);//change
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
                        _pdfPTable.SetWidths(new float[] { 4f, 14f, 14f, 14f, 14f, 14f });//column width in doc       
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
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        _pdfPCell = new PdfPCell(phrase);
                        _pdfPCell.Colspan = 6;
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
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("VendorContactList", _fontStyle));
                        _pdfPCell.Colspan = 3;
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
                        _Vhrlist = ViewVenderContactDetails();
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("FullName", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Email", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Direction", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Position", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("MobileNo", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["FullName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["email"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["direction"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Position"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["phonenumber"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("VendorContactList" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
                    int _totalColumns = 6;//
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(6);//change
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
                        _pdfPTable.SetWidths(new float[] { 4f, 14f, 14f, 14f, 14f, 14f });//column width in doc       
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
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        _pdfPCell = new PdfPCell(phrase);
                        _pdfPCell.Colspan = 6;
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
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("VendorContactList", _fontStyle));
                        _pdfPCell.Colspan = 3;
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
                        _Vhrlist = ViewVenderContactDetails();
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("FullName", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Email", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Direction", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Position", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("MobileNo", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["FullName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["email"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["direction"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Position"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["phonenumber"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("VendorContactList" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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

        protected void btn_Reload_Click1(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    ViewVenderContactDetails();
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


        protected void chkIsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((CheckBox)sender).NamingContainer;
            CheckBox chkIsEnabled = (CheckBox)row.FindControl("chkIsEnabled");
            Label lblIsEnabled = (Label)row.FindControl("lblIsEnabled");


            lblIsEnabled.Text = chkIsEnabled.Checked.ToString();
        }

        protected void GriExitingContact_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GriExitingContact.Rows)
                {
                    //string  Status = Convert.ToString(e.Row.Cells[8].Text);

                    Label lblContact_id1 = (Label)gridviedrow.FindControl("lblContact_id1");
                    Label lblFullName1 = (Label)gridviedrow.FindControl("lblFullName1");
                    Label lblEmail1 = (Label)gridviedrow.FindControl("lblEmail1");
                    Label lbldirection1 = (Label)gridviedrow.FindControl("lbldirection1");
                    Label lblPosition1 = (Label)gridviedrow.FindControl("lblPosition1");
                    Label lblPhone1 = (Label)gridviedrow.FindControl("lblPhone1");
                    Label lblStatus1 = (Label)gridviedrow.FindControl("lblStatus1");

                    string status = ((Label)gridviedrow.FindControl("lblStatus1")).Text;
                    if (status == "True")
                    {
                        lblContact_id1.ForeColor = Color.Black;
                        lblFullName1.ForeColor = Color.Blue;
                        lblEmail1.ForeColor = Color.Black;
                        lbldirection1.ForeColor = Color.Blue;
                        lblPosition1.ForeColor = Color.Blue;
                        lblPhone1.ForeColor = Color.Blue;
                        lblStatus1.ForeColor = Color.Blue;
                    }
                    else
                    {
                        lblContact_id1.ForeColor = Color.Red;
                        lblFullName1.ForeColor = Color.Red;
                        lblEmail1.ForeColor = Color.Red;
                        lbldirection1.ForeColor = Color.Red;
                        lblPosition1.ForeColor = Color.Red;
                        lblPhone1.ForeColor = Color.Red;
                        lblStatus1.ForeColor = Color.Red;
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

        protected void btnDeleteContacts_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {
                        string ID;
                        var rows = GriExitingContact.Rows;
                        LinkButton btn = (LinkButton)sender;
                        GridViewRow row = (GridViewRow)btn.NamingContainer;
                        int rowindex = Convert.ToInt32(row.RowIndex);
                        ID = ((Label)rows[rowindex].FindControl("lblContact_id1")).Text;
                        SqlConnection con = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_DeleteVenderContactDetails", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.Parameters.AddWithValue("@CreateBy", UserName);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i < 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Vendor Contact Details Deleted Successfully";
                            ViewVenderContactDetails();
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Vendor Contact Details not Deleted Successfully";
                        }
               
                    }
                }
                else if (RoleType == Designation)
                {
                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {
                        string ID;
                        var rows = GriExitingContact.Rows;
                        LinkButton btn = (LinkButton)sender;
                        GridViewRow row = (GridViewRow)btn.NamingContainer;
                        int rowindex = Convert.ToInt32(row.RowIndex);
                        ID = ((Label)rows[rowindex].FindControl("lblContact_id1")).Text;
                        SqlConnection con = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_DeleteVenderContactDetailsForEmpID", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.Parameters.AddWithValue("@CreateBy", UserName);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i < 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Vendor Contact Details Deleted Successfully";
                            StaffOperationPermission();
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Vendor Contact Details not Deleted Successfully";
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
        }

        //----------------------------------------------------------------------------------------------------//


        //----------------------------------------------------------------------------//
        //WorkOrder
        //----------------------------------------------------------------------------//
        protected void btn_CreateWorkOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewWorkOrder.aspx", false);
        }
        protected void lnkBtnWorkorderExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ViewWorkorderDetails();
                if (dt != null && dt.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment;filename=WorkOrder_Details.xls");

                    Response.Charset = " ";


                    DataTable dtExport = new DataTable();
                    dtExport.Columns.Add("ID");
                    dtExport.Columns.Add("ContactVender");
                    dtExport.Columns.Add("VendorName");
                    dtExport.Columns.Add("ProjectName");
                    dtExport.Columns.Add("TenderNumber");
                    dtExport.Columns.Add("WorkOrderNumber");
                    dtExport.Columns.Add("PublishDate");
                    dtExport.Columns.Add("CompletionDate");
                    dtExport.Columns.Add("TotalAmountTender");

                    dtExport.Columns.Add("TenderBased");

                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow newRow = dtExport.NewRow();
                        newRow["ID"] = row["ID"];
                        newRow["ContactVender"] = row["ContactVender"];
                        newRow["VendorName"] = row["Vend_Name"];
                        newRow["ProjectName"] = row["ProjectName"];
                        newRow["TenderNumber"] = row["TenderNumber"];
                        newRow["WorkOrderNumber"] = row["WorkOrderNumber"];
                        newRow["PublishDate"] = row["publishdate"];
                        newRow["CompletionDate"] = row["CompletionDate"];
                        newRow["TotalAmountTender"] = row["TotalAmountTender"];
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

        protected void lnkBtnWorkorderPDF_Click(object sender, EventArgs e)
        {
            try
            {
                //RoleType = Session["LoginType"].ToString();
                //Designation = Session["Role"].ToString();
                //UserId = Convert.ToInt32(Session["UserID"]);
                //if (Session["LoginType"].ToString() == "Administrator")
                //{
                int _totalColumns = 9;//
                string path = Image1.ImageUrl;
                iTextSharp.text.Font _fontStyle;
                PdfPTable _pdfPTable = new PdfPTable(9);//change
                PdfPCell _pdfPCell;
                PdfPCell cell = null;


                Document _document = new Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0);
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
                    _pdfPTable.SetWidths(new float[] { 4f, 11f, 11f, 7f, 10f, 12f, 11f, 13f, 10f });//column width in doc       
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
                    _pdfPCell = new PdfPCell(new Phrase("WorkOrderList", _fontStyle));
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
                    _Vhrlist = ViewWorkorderDetails();
                    #region "Table Header"

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("ContactVend", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("VendName", _fontStyle));
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
                    _pdfPCell = new PdfPCell(new Phrase("TenderNo", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("WorkOrderNo", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("PublishDate", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("CompletionDate", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("TenderAmt", _fontStyle));
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

                        _pdfPCell = new PdfPCell(new Phrase(row["ContactVender"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["Vend_Name"].ToString(), _fontStyle));
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

                        _pdfPCell = new PdfPCell(new Phrase(row["TenderNumber"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["WorkOrderNumber"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["publishdate"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["CompletionDate"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["TotalAmountTender"].ToString(), _fontStyle));
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
                    string PDFFileName = string.Format("WorkOrderList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + PDFFileName);
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();

                }
                //}

                //else
                //{
                //    Response.Redirect("~/Expired.html", true);
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


        protected void BtnWorkorderReload_Click(object sender, EventArgs e)
        {
            ViewWorkorderDetails();
        }

        protected void BtnWorkorderVisibility_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable table = new DataTable();
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand sqlCommand = new SqlCommand("SP_ViewVendorWorkOrderDetailsVisibility", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@VendorId", lblVendorID.Text);
                    SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                    ad.Fill(table);
                    GridWorkorderlist.DataSource = table;
                    GridWorkorderlist.DataBind();
                    ViewState["Data"] = table;

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


        protected void Chk_Pulish_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                System.Web.UI.WebControls.CheckBox chkPublish = (System.Web.UI.WebControls.CheckBox)sender;
                GridViewRow row = (GridViewRow)chkPublish.NamingContainer;
                int rowIndex = row.RowIndex;
                int id = Convert.ToInt32(GridWorkorderlist.DataKeys[rowIndex]["ID"]);
                bool chk = chkPublish.Checked;
                using (SqlConnection connection = new SqlConnection(strconnect))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ViewOrderPublishWorkorderDetails", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@OrderPublish", chk);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@created_by", UserName);

                        connection.Open();
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
                            lblMesDelete.Text = "Work Order Publish Successfully";
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Work Order Not Publish Successfully";
                        }                       
                        connection.Close();
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
            finally { }

        }
        protected void btnEditWorkOrder_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string WorkOrderID;
                var rows = GridWorkorderlist.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                WorkOrderID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                Response.Redirect("~/EditWorkOrder.aspx?ID=" + WorkOrderID + "", false);
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
            finally { }
        }
        protected void btnDeleteWorkOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string ID;
                var rows = GridWorkorderlist.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                SqlConnection DeviceCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_DeleteWorkOrder", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Created_by", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Work Order Details Deleted Successfully";
                    ViewWorkorderDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Work Order Details Not Deleted";
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
            finally { }
        }

        //----------------------------------------------------------------------------//
        //Payment Amd EXpenses pdf code
        //----------------------------------------------------------------------------//
        protected void btnNewProjectExpense_Click(object sender, EventArgs e)
        {
            Response.Redirect("New_Project_Purchase.aspx");
        }
        protected void LnkbtnPaymentExpensesExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ViewProjectPurchase();
                if (dt != null && dt.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/ms-excel";
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ProjectPurchasesDetails " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));
                    Response.Charset = " ";

                    DataTable dtExport = new DataTable();

                    dtExport.Columns.Add("ID");
                    dtExport.Columns.Add("PurName");
                    dtExport.Columns.Add("PurAmount");
                    dtExport.Columns.Add("PurDate");
                    dtExport.Columns.Add("Customer");
                    dtExport.Columns.Add("Project");
                    dtExport.Columns.Add("PurPayment");
                    dtExport.Columns.Add("PurType");
                    dtExport.Columns.Add("CreatedBy");

                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow newRow = dtExport.NewRow();
                        newRow["ID"] = row["Pur_id"];
                        newRow["PurName"] = row["Pur_Name"];
                        newRow["PurAmount"] = row["Pur_Amount"];
                        newRow["PurDate"] = row["Pur_Date"];
                        newRow["Customer"] = row["Cust_Name"];
                        newRow["Project"] = row["ProjectName"];
                        newRow["PurPayment"] = row["Pur_Payment"];
                        newRow["PurType"] = row["Pur_Type"];
                        // newRow["BillNo"] = row["BillNo"];
                        newRow["CreatedBy"] = row["CreatedBy"];
                        // newRow["Other"] = row["Other"];
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
        protected void Btn_Import_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImportFile.aspx", true);

        }
        protected void LnkbtnPaymentExpensesPDF_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    int _totalColumns = 7;//
                    string path = Image1.ImageUrl;

                    //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(7);//change
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;


                    Document _document = new Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0);
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
                        _pdfPTable.SetWidths(new float[] { 4f, 12f, 12f, 12f, 11f, 11f, 14f });//column width in doc       
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
                        _pdfPCell.Colspan = 7;
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
                        _pdfPCell.Colspan = 7;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("ProjectPurchaseList", _fontStyle));
                        _pdfPCell.Colspan = 4;
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
                        _Vhrlist = ViewProjectPurchase();
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Purchase", _fontStyle));
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
                        _pdfPCell = new PdfPCell(new Phrase("ProjectName", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Date", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("PurchaseType", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("BillNo", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["Pur_Name"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Pur_Amount"].ToString(), _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["Pur_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Pur_Type"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["BillNo"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("ProjectPurchaseList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
                    int _totalColumns = 7;//
                    string path = Image1.ImageUrl;

                    //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(7);//change
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;


                    Document _document = new Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0);
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
                        _pdfPTable.SetWidths(new float[] { 4f, 12f, 12f, 12f, 11f, 11f, 14f });//column width in doc       
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
                        _pdfPCell.Colspan = 7;
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
                        _pdfPCell.Colspan = 7;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("ProjectPurchaseList", _fontStyle));
                        _pdfPCell.Colspan = 4;
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
                        _Vhrlist = ViewProjectPurchase();
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Purchase", _fontStyle));
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
                        _pdfPCell = new PdfPCell(new Phrase("ProjectName", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Date", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("PurchaseType", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("BillNo", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["Pur_Name"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Pur_Amount"].ToString(), _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["Pur_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Pur_Type"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["BillNo"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("ProjectPurchaseList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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

        protected void BtnPaymentExpensesVisibility_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable table = new DataTable();
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand sqlCommand = new SqlCommand("SP_ViewProjectPurchaseByVendorIDVisibility", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@VendorId ", lblVendorID.Text);
                    SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                    ad.Fill(table);
                    GridProjectPurchase.DataSource = table;
                    GridProjectPurchase.DataBind();
                    ViewState["Data"] = table;
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

        protected void BtnPaymentExpensesReload_Click(object sender, EventArgs e)
        {
            try
            {

                ViewProjectPurchase(); ;

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
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName);
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

        protected void GridProjectPurchase_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridProjectPurchase.Rows)
                {
                    string Status1 = ((Label)gridviedrow.FindControl("lblStatus")).Text;
                    Label lblPur_id1 = (Label)gridviedrow.FindControl("lblPur_id1");
                    Label lblPur_Name1 = (Label)gridviedrow.FindControl("lblPur_Name1");
                    Label lblPur_Customer1 = (Label)gridviedrow.FindControl("lblPur_Customer1");
                    Label lblPur_Project1 = (Label)gridviedrow.FindControl("lblPur_Project1");
                    Label lblPur_Date1 = (Label)gridviedrow.FindControl("lblPur_Date1");
                    Label lblExpenses_Type1 = (Label)gridviedrow.FindControl("lblExpenses_Type1");

                    if (Status1 == "True")
                    {
                        lblPur_id1.ForeColor = System.Drawing.Color.Black;
                        lblPur_Name1.ForeColor = System.Drawing.Color.Black;
                        lblPur_Customer1.ForeColor = System.Drawing.Color.Black;
                        lblPur_Project1.ForeColor = System.Drawing.Color.Black;
                        lblPur_Date1.ForeColor = System.Drawing.Color.Blue;
                        lblExpenses_Type1.ForeColor = System.Drawing.Color.Blue;


                    }
                    else
                    {

                        lblPur_id1.ForeColor = System.Drawing.Color.Red;
                        lblPur_Name1.ForeColor = System.Drawing.Color.Red;
                        lblPur_Customer1.ForeColor = System.Drawing.Color.Red;
                        lblPur_Project1.ForeColor = System.Drawing.Color.Red;
                        lblPur_Date1.ForeColor = System.Drawing.Color.Red;
                        lblExpenses_Type1.ForeColor = System.Drawing.Color.Red;



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

        protected void btnEditProjectPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string tableID;
                var rows = GridProjectPurchase.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                tableID = ((Label)rows[rowindex].FindControl("lblPur_id1")).Text;

                Response.Redirect("~/Edit_ProjectPurchase.aspx?ID=" + tableID + "", false);
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

        protected void btnDeleteProjectPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string tableID;
                var rows = GridProjectPurchase.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                tableID = ((Label)rows[rowindex].FindControl("lblPur_id1")).Text;

                SqlCommand cmd = new SqlCommand("SP_DeleteProjectPurchaseExpenses", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Pur_id", tableID);
                cmd.Parameters.AddWithValue("@CreatedBy", UserName);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Project Purchase Details Deleted Successfully";
                    GridProjectPurchase.EditIndex = -1;
                    ViewProjectPurchase();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Project Purchase Details Not Deleted Successfully";
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

        //----------------------------------------------------------------------------//
        //Contract Vendor
        //----------------------------------------------------------------------------//
        protected void btnNewContractVendor_Click(object sender, EventArgs e)
        {
            Response.Redirect("New_ContractVendor.aspx");
        }

        protected void GridContractVendor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridContractVendor.Rows)
                {
                    string Status = ((Label)gridviedrow.FindControl("lblstatus1")).Text;
                    Label lblContractvenderID1 = (Label)gridviedrow.FindControl("lblid1");
                    Label lblcontractsubject1 = (Label)gridviedrow.FindControl("lblsubject1");
                    Label lblContract_value1 = (Label)gridviedrow.FindControl("lblContract_value1");
                    Label lbldatestart1 = (Label)gridviedrow.FindControl("lblStartDate1");
                    Label lbldateend1 = (Label)gridviedrow.FindControl("lblEndDate1");
                    Label lblcontract_type1 = (Label)gridviedrow.FindControl("lblcontract_type1");
                    Label lblcontract_vender1 = (Label)gridviedrow.FindControl("lblcontract_vender1");
                    if (Status == "True")
                    {
                        lblContractvenderID1.ForeColor = System.Drawing.Color.Blue;
                        lblcontractsubject1.ForeColor = System.Drawing.Color.Black;
                        lblContract_value1.ForeColor = System.Drawing.Color.Blue;
                        lbldatestart1.ForeColor = System.Drawing.Color.Blue;
                        lbldateend1.ForeColor = System.Drawing.Color.Blue;
                        lblcontract_type1.ForeColor = System.Drawing.Color.Blue;
                        lblcontract_vender1.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        lblContractvenderID1.ForeColor = System.Drawing.Color.Red;
                        lblcontractsubject1.ForeColor = System.Drawing.Color.Red;
                        lblContract_value1.ForeColor = System.Drawing.Color.Red;
                        lbldatestart1.ForeColor = System.Drawing.Color.Red;
                        lbldateend1.ForeColor = System.Drawing.Color.Red;
                        lblcontract_type1.ForeColor = System.Drawing.Color.Red;
                        lblcontract_vender1.ForeColor = System.Drawing.Color.Red;
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

        protected void lblbtnContractVendorExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ViewContractVendor();
                if (dt != null && dt.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment;filename=Vendor_Contract.xls");

                    Response.Charset = " ";

                    DataTable dtExport = new DataTable();
                    dtExport.Columns.Add("ID");
                    dtExport.Columns.Add("Subject");
                    dtExport.Columns.Add("ContractValue");
                    dtExport.Columns.Add("StartDate");
                    dtExport.Columns.Add("EndDate");
                    dtExport.Columns.Add("Vendor");
                    dtExport.Columns.Add("ContractType");
                    dtExport.Columns.Add("ContractExpired");
                    dtExport.Columns.Add("Trash");

                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow newRow = dtExport.NewRow();
                        newRow["ID"] = row["id"];
                        newRow["Subject"] = row["subject"];
                        newRow["ContractValue"] = row["contract_value"];
                        newRow["StartDate"] = row["datestart"];
                        newRow["EndDate"] = row["dateend"];
                        newRow["Vendor"] = row["Vend_Name"];
                        newRow["ContractType"] = row["Contractype"];
                        newRow["ContractExpired"] = row["is_expiry_notified"];
                        newRow["Trash"] = row["trash"];

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

        protected void lblbtnContractVendorPDF_Click(object sender, EventArgs e)
        {

            try
            {
                int _totalColumns = 9;//
                string path = Image1.ImageUrl;

                //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                iTextSharp.text.Font _fontStyle;
                PdfPTable _pdfPTable = new PdfPTable(9);//change
                PdfPCell _pdfPCell;
                PdfPCell cell = null;


                Document _document = new Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0);
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
                    _pdfPTable.SetWidths(new float[] { 4f, 14f, 10f, 10f, 12f, 10f, 13f, 12f, 7f });//column width in doc       
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
                    _pdfPCell = new PdfPCell(new Phrase("ContractVendorList", _fontStyle));
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
                    _pdfPCell = new PdfPCell(new Phrase("---------------------------*-----------------------------", _fontStyle));
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
                    _Vhrlist = ViewContractVendor();
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
                    _pdfPCell = new PdfPCell(new Phrase("EndDate", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("ContractValue", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("Vendor", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);


                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("ContractType", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("ExpiryNotify", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("Trash", _fontStyle));
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

                        _pdfPCell = new PdfPCell(new Phrase(row["subject"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["datestart"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["dateend"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["contract_value"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["Vend_Name"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["Contractype"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["is_expiry_notified"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["trash"].ToString(), _fontStyle));
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
                    string PDFFileName = string.Format("ContractVendorList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + PDFFileName);
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();

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

        protected void btnContractVendorVisibility_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable table = new DataTable();
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand sqlCommand = new SqlCommand("SP_ViewVendorContract_VendorVisibility", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@VendorId ", lblVendorID.Text);
                    SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                    ad.Fill(table);
                    GridContractVendor.DataSource = table;
                    GridContractVendor.DataBind();
                    ViewState["Data"] = table;
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

        protected void btnContractVendorReload_Click(object sender, EventArgs e)
        {
            try
            {
                ViewContractVendor();


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

        protected void btnEditContractVendor_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string tableID;
                var rows = GridContractVendor.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                tableID = ((Label)rows[rowindex].FindControl("lblid1")).Text;
                Response.Redirect("~/Edit_Contract_Vendor.aspx?ID=" + tableID + "", false);
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

        protected void btnDeleteContractVendor_Click(object sender, EventArgs e)
        {

            try
            {

                DeviceCon = new SqlConnection(strconnect);
                string tableID;
                var rows = GridContractVendor.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                tableID = ((Label)rows[rowindex].FindControl("lblid1")).Text;

                SqlCommand cmd = new SqlCommand("SP_DeleteContract_Vendor", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", tableID);
                cmd.Parameters.AddWithValue("@add_by", UserName);
                cmd.Parameters.AddWithValue("@UserID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Contract Vendor Details Deleted Successfully";
                    GridContractVendor.EditIndex = -1;
                    ViewContractVendor();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Contract Vendor Details Not Deleted Successfully";
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

        //----------------------------------------------------------------------------//
        //Project
        //----------------------------------------------------------------------------//


        protected void btnAddProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewProject.aspx", true);
        }

        protected void lnkbtnExcelProject_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = ViewProjetctDetails();
                if (dt != null && dt.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment;filename=VendorProjectDetails.xls");

                    Response.Charset = " ";

                    // Create a new DataTable with only the desired columns
                    DataTable dtExport = new DataTable();
                    dtExport.Columns.Add("ID");
                    dtExport.Columns.Add("ProjectName");
                    dtExport.Columns.Add("Description");
                    dtExport.Columns.Add("StatusName");
                    dtExport.Columns.Add("ClientName");
                    dtExport.Columns.Add("BillingType");
                    dtExport.Columns.Add("StartDate");
                    dtExport.Columns.Add("DeadLine");
                    dtExport.Columns.Add("AddedFrom");
                    dtExport.Columns.Add("ProjectCreatedDate");

                    // Copy the data from the original DataTable to the export DataTable
                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow newRow = dtExport.NewRow();
                        newRow["ID"] = row["ID"];
                        newRow["ProjectName"] = row["ProjectName"];
                        newRow["Description"] = row["Description"];
                        newRow["StatusName"] = row["StatusName"];
                        newRow["ClientName"] = row["ClientName"];
                        newRow["BillingType"] = row["billing_type"];
                        newRow["StartDate"] = row["Start_Date"];
                        newRow["DeadLine"] = row["Deadline"];
                        newRow["AddedFrom"] = row["Addedfrom"];
                        newRow["ProjectCreatedDate"] = row["Project_CreatedDate"];
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

        protected void lnkbtnPDFProject_Click(object sender, EventArgs e)
        {
            try
            {
                //RoleType = Session["LoginType"].ToString();
                //Designation = Session["Role"].ToString();
                //UserId = Convert.ToInt32(Session["UserID"]);
                //if (Session["LoginType"].ToString() == "Administrator")
                //{
                int _totalColumns = 11;//
                string path = Image1.ImageUrl;

                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                iTextSharp.text.Font _fontStyle;
                PdfPTable _pdfPTable = new PdfPTable(11);//change
                PdfPCell _pdfPCell;
                PdfPCell cell = null;


                Document _document = new Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0);
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
                    Phrase phrase = null;

                    PdfPTable table = null;



                    _document.Open();
                    _pdfPTable.SetWidths(new float[] { 4f, 9f, 11f, 12f, 10f, 9f, 12f, 10f, 10f, 9f, 10f });//column width in doc       
                                                                                                            // ----Header PDF--------------------------//
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
                    _pdfPCell.Colspan = 11;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.Border = 2;
                    _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 4;
                    _pdfPTable.AddCell(_pdfPCell);
                    _pdfPTable.CompleteRow();

                    _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                    _pdfPCell = new PdfPCell(new Phrase("Projectlist", _fontStyle));
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
                    _pdfPCell.Colspan = 5;
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

                    // ----Header PDF--------------------------//


                    // ----------------------------------Table----------------------------------////

                    DataTable _Vhrlist = new DataTable();
                    _Vhrlist = ViewProjetctDetails();
                    #region "Table Header"

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
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
                    _pdfPCell = new PdfPCell(new Phrase("Customer", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    //_fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    //_pdfPCell = new PdfPCell(new Phrase("CustType", _fontStyle));
                    //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    //_pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    //_pdfPCell.BackgroundColor = Color.GRAY;
                    //_pdfPCell.ExtraParagraphSpace = 2;
                    //_pdfPTable.AddCell(_pdfPCell);

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
                    _pdfPCell = new PdfPCell(new Phrase("Duration", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("ProcurementCost", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("ServiceCost", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("ProjectCost", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("Address", _fontStyle));
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

                        _pdfPCell = new PdfPCell(new Phrase(row["ProjectName"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["ClientName"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        //_pdfPCell = new PdfPCell(new Phrase(row["Cust_Type"].ToString(), _fontStyle));
                        //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        //_pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //_pdfPCell.BackgroundColor = BaseColor.WHITE;
                        //_pdfPCell.ExtraParagraphSpace = 1;
                        //_pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["Start_Date"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["Deadline"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["TotalDuration"].ToString(), _fontStyle));//no
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["TotalProcurementCost"].ToString(), _fontStyle));//no
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["TotalServiceCost"].ToString(), _fontStyle));//no
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["TotalProjectCost"].ToString(), _fontStyle));//no
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["Address"].ToString(), _fontStyle));//no
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

                    // Move the pointer and draw line to separate footer section from rest of page
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

                    //--------------------PDF Generation------------------------------------//
                    _pdfPTable.HeaderRows = 1; //header method
                    _document.Add(_pdfPTable);

                    _document.Close();
                    byte[] bytes = memoryStream.ToArray();
                    DateTime dTime = DateTime.Now;
                    string PDFFileName = string.Format("Projectlist_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + PDFFileName);
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();

                }
                //}

                //else
                //{
                //    Response.Redirect("~/Expired.html", true);
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

        public DataTable GetStaffnamebyProjectname(string ProjectID)
        {
            DataTable table = new DataTable();
            DataColumn dataColumn = new DataColumn();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_GetProjectMemeberbyID", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
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

        protected void GridProject_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridProject.Rows)
                {

                    Button Status = (Button)gridviedrow.FindControl("btnStatus");
                    Label lblID1 = (Label)gridviedrow.FindControl("lblID1");
                    Label lblProjectName1 = (Label)gridviedrow.FindControl("lblProjectName1");
                    Label lblStart_Date1 = (Label)gridviedrow.FindControl("lblStart_Date1");
                    Label lblDeadline1 = (Label)gridviedrow.FindControl("lblDeadline1");
                    Label lblSClientName1 = (Label)gridviedrow.FindControl("lblSClientName1");
                    Label lblstatus1 = (Label)gridviedrow.FindControl("lblstatus1");

                    System.Web.UI.WebControls.BulletedList bulletlistMember = (System.Web.UI.WebControls.BulletedList)gridviedrow.FindControl("bulletlistMember");

                    string ProjectID = lblID1.Text;
                    string Stat1 = lblstatus1.Text;

                    if (Stat1 == "True")
                    {

                        lblID1.ForeColor = System.Drawing.Color.Blue;
                        lblSClientName1.ForeColor = System.Drawing.Color.Blue;
                        lblstatus1.ForeColor = System.Drawing.Color.Blue;

                        DataTable table = GetStaffnamebyProjectname(ProjectID);

                        bulletlistMember.DataSource = table;
                        bulletlistMember.DataTextField = "First_Name";
                        bulletlistMember.DataValueField = "First_Name";
                        bulletlistMember.DataBind();
                    }
                    else
                    {
                        lblID1.ForeColor = System.Drawing.Color.Red;
                        lblStart_Date1.ForeColor = System.Drawing.Color.Red;
                        lblDeadline1.ForeColor = System.Drawing.Color.Red;
                        lblSClientName1.ForeColor = System.Drawing.Color.Red;
                        lblProjectName1.ForeColor = System.Drawing.Color.Red;
                        lblstatus1.ForeColor = System.Drawing.Color.Red;

                        DataTable table = GetStaffnamebyProjectname(ProjectID);

                        bulletlistMember.DataSource = table;
                        bulletlistMember.DataTextField = "First_Name";
                        bulletlistMember.DataValueField = "First_Name";
                        bulletlistMember.DataBind();

                        bulletlistMember.ForeColor = System.Drawing.Color.Red;
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


        protected void btn_VisibilityProject_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable table = new DataTable();

                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand sqlCommand = new SqlCommand("SP_ViewProjectDetailsByVendorIdVisibility", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@VendorId", lblVendorID.Text);
                    SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                    ad.Fill(table);
                    GridProject.DataSource = table;
                    GridProject.DataBind();
                    ViewState["ProjectData"] = table;
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

        protected void BtnReloadProject_Click(object sender, EventArgs e)
        {
            try
            {

                ViewProjetctDetails();

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

        protected void btnEditProject_Click(object sender, EventArgs e)
        {
            try
            {
                string ID;
                var rows = GridProject.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;
                Response.Redirect("~/EditProjectDetails.aspx?ID=" + ID + "", false);
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



        protected void btnDeleteProjetct_Click(object sender, EventArgs e)
        {
            try
            {

                DeviceCon = new SqlConnection(strconnect);
                string tableID;
                var rows = GridProject.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                tableID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                SqlCommand cmd = new SqlCommand("SP_DeleteProjects", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Projectid", tableID);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Project Details Deleted Successfully";
                    GridProject.EditIndex = -1;
                    ViewProjetctDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Project Details Not Deleted Successfully";
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

        //----------------------------------------------------------------------------//
        //File
        //----------------------------------------------------------------------------//


        protected void Btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload.PostedFile.FileName.Length > 1)
                {
                    string uploadDirectory = Server.MapPath("~/VendorFiles/");

                    if (!Directory.Exists(uploadDirectory))
                    {
                        Directory.CreateDirectory(uploadDirectory);
                    }
                    string fileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
                    string filePath = System.IO.Path.Combine(uploadDirectory, fileName);
                    string extention = System.IO.Path.GetExtension(FileUpload.PostedFile.FileName);
                    FileUpload.PostedFile.SaveAs(filePath);
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_UploadAttachmentFilesModules", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BelongTo", "Vendor ");
                        cmd.Parameters.AddWithValue("@Related", txtVendorName.Text);
                        cmd.Parameters.AddWithValue("@RelatedTOID", lblVendorID.Text);
                        cmd.Parameters.AddWithValue("@FileName", fileName);
                        cmd.Parameters.AddWithValue("@FilePath", filePath);
                        cmd.Parameters.AddWithValue("@DocumentType", txtdocumenttype.Text);
                        cmd.Parameters.AddWithValue("@Extention", extention);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
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
                            lblMesDelete.Text = "File Uploaded Successfully";
                            ViewFilesDetails(lblVendorID.Text);
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "File Not Uploaded Successfully";
                        }
                    }
                }
                else
                {
                    //popup choose file
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Choose File For Uploaded!')", true);
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
                        // lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Save Successfully";
                    }
                    else
                    {
                        // lblMessage.Visible = false;
                        // lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }
            finally { }
        }

        protected void btnDeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string lblID1;
                var rows = GridFile.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                lblID1 = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                SqlCommand cmd = new SqlCommand("SP_DeleteFilesAllModules", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", lblID1);
                cmd.Parameters.AddWithValue("@Belong", "Vendor");
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
                    lblMesDelete.Text = "File Deleted Successfully";
                    GridFile.EditIndex = -1;
                    ViewFilesDetails(lblID.Text);
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "File Not Deleted Successfully";
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
                        // lblMessage.Visible = false;
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



        //----------------------------------------------------------------------------//
        //Task
        //----------------------------------------------------------------------------//


        protected void btn_New_Task_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewTaskStaff.aspx", true);

        }
        protected void btn_Task_Overview_Click(object sender, EventArgs e)
        {
            Response.Redirect("Task_Detail_Overview.aspx", true);
        }

        protected void lnkbtn1taskExcel_Click(object sender, EventArgs e)
        {
            try
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
                    DataTable dt = (DataTable)ViewState["DataTask"];
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
                    // GridTask1.HeaderRow.BackColor = BaseColor.WHITE;
                    foreach (System.Web.UI.WebControls.TableCell cell in GridTask1.HeaderRow.Cells)
                    {
                        cell.BackColor = GridTask1.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in GridTask1.Rows)
                    {
                        //  row.BackColor = BaseColor.WHITE;
                        foreach (System.Web.UI.WebControls.TableCell cell in row.Cells)
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

        protected void lnkbtnTaskPDF_Click(object sender, EventArgs e)
        {

            try
            {
                int _totalColumns = 8;
                string path = Image1.ImageUrl;

                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                iTextSharp.text.Font _fontStyle;
                PdfPTable _pdfPTable = new PdfPTable(8);//change
                PdfPCell _pdfPCell;
                PdfPCell cell = null;

                Document _document = new Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0);
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
                    Phrase phrase = null;

                    PdfPTable table = null;



                    _document.Open();
                    _pdfPTable.SetWidths(new float[] { 4f, 9f, 11f, 12f, 10f, 9f, 12f, 10f });//column width in doc       
                                                                                              // ----Header PDF--------------------------//
                                                                                              //Company Logo
                    cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 3;
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
                    _pdfPCell.Colspan = 5;
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
                    _pdfPCell.Colspan = 8;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.Border = 2;
                    _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 4;
                    _pdfPTable.AddCell(_pdfPCell);
                    _pdfPTable.CompleteRow();

                    _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                    _pdfPCell = new PdfPCell(new Phrase("TaskStaffList", _fontStyle));
                    _pdfPCell.Colspan = 5;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    _pdfPCell.Border = 0;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 4;
                    _pdfPTable.AddCell(_pdfPCell);

                    //----------------------Date------------------------------//
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
                    _Vhrlist = GetTaskbyVendor();
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
                    _pdfPCell = new PdfPCell(new Phrase("ReapetEvery", _fontStyle));
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

                        _pdfPCell = new PdfPCell(new Phrase(row["AssignTo"].ToString(), _fontStyle));
                        foreach (GridViewRow gridviedrow in GridTask1.Rows)
                        {
                            Label lbltaskName1 = (Label)gridviedrow.FindControl("lbltaskName1");
                            GetStaffnamebytaskname(lbltaskName1.Text);
                            foreach (DataRow row1 in _Vhrlist.Rows)
                            {
                                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                                _pdfPCell.ExtraParagraphSpace = 1;
                            }
                        }
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["TaskStatus"].ToString(), _fontStyle));
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
            catch (Exception ex)
            {
                DeviceCon = new SqlConnection(strconnect);
                string ErrorMessgage = ex.Message;
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
            }

        }

        protected void btnVisibilityTask_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable table = new DataTable();

                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand sqlCommand = new SqlCommand("SP_ViewTaskStaffByVendorNameVisibility", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Vend_Name ", txtVendorName.Text);
                    SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                    ad.Fill(table);
                    GridTask1.DataSource = table;
                    GridTask1.DataBind();
                    ViewState["TaskData"] = table;
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

        protected void BtnReloadTask_Click(object sender, EventArgs e)
        {
            StaffOperationPermission();
        }

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {

        }
        protected void GridTask1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                int _totalColumns = 9;
                string path = Image1.ImageUrl;

                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                iTextSharp.text.Font _fontStyle;
                PdfPTable _pdfPTable = new PdfPTable(9);//change
                PdfPCell _pdfPCell;
                PdfPCell cell = null;

                Document _document = new Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0);
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
                    Phrase phrase = null;

                    PdfPTable table = null;



                    _document.Open();
                    _pdfPTable.SetWidths(new float[] { 4f, 9f, 11f, 12f, 10f, 9f, 12f, 10f, 10f, 9f, 10f });//column width in doc       
                                                                                                            // ----Header PDF--------------------------//
                                                                                                            //Company Logo
                    cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 3;
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
                    _pdfPCell = new PdfPCell(new Phrase("TaskStaffList", _fontStyle));
                    _pdfPCell.Colspan = 3;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    _pdfPCell.Border = 0;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 4;
                    _pdfPTable.AddCell(_pdfPCell);

                    //----------------------Date------------------------------//
                    DateTime PrintTime = DateTime.Now;
                    _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                    _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                    _pdfPCell.Colspan = 2;
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
                    _Vhrlist = GetTaskbyVendor();
                    #region "Table Header"

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
                    _pdfPCell = new PdfPCell(new Phrase("ReapetEvery", _fontStyle));
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

                        _pdfPCell = new PdfPCell(new Phrase(row["AssignTo"].ToString(), _fontStyle));
                        foreach (GridViewRow gridviedrow in GridTask1.Rows)
                        {
                            Label lbltaskName1 = (Label)gridviedrow.FindControl("lbltaskName1");
                            GetStaffnamebytaskname(lbltaskName1.Text);
                            foreach (DataRow row1 in _Vhrlist.Rows)
                            {
                                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                                _pdfPCell.ExtraParagraphSpace = 1;
                            }
                        }
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
                        GetTaskbyVendor();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Status Not Change Successfully";
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
                        GetTaskbyVendor();
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
                string CustomerID = lblID.Text;
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
                    GetTaskbyVendor();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Task Details Not Deleted Successfully";
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


        //----------------------------------------------------------------------------//
        //Reminder
        //----------------------------------------------------------------------------//

        protected void LnkBtnReminderExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ViewRemainderDetails();
                if (dt != null && dt.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment;filename=VendorReminderDetails.xls");
                    Response.Charset = " ";


                    DataTable dtExport = new DataTable();

                    dtExport.Columns.Add("ID");
                    dtExport.Columns.Add("NotifyDate");
                    dtExport.Columns.Add("SetToReminder");
                    dtExport.Columns.Add("Description");
                    dtExport.Columns.Add("Belong");
                    dtExport.Columns.Add("RelatedTo");
                    //dtExport.Columns.Add("RelatedToID");

                    int rowplus = 1;
                    foreach (DataRow row in dt.Rows)
                    {

                        DataRow newRow = dtExport.NewRow();
                        newRow["ID"] = rowplus++.ToString();
                        newRow["NotifyDate"] = row["NotifyDate"];
                        newRow["SetToReminder"] = row["SetToReminder"];
                        newRow["Description"] = row["Description"];
                        newRow["Belong"] = row["Belong"];
                        newRow["RelatedTo"] = row["RelatedTo"];
                        // newRow["RelatedToID"] = row["RelatedToID"];

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
                        // lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }
        }

        protected void LnkBtnReminderPDF_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    int _totalColumns = 6;//
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));

                    Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(6);//change
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
                        Phrase phrase = null;
                        //PdfPCell cell = null;
                        PdfPTable table = null;
                        //Color color = new Color();

                        _document.Open();
                        _pdfPTable.SetWidths(new float[] { 4f, 14f, 14f, 14f, 14f, 14f });//column width in doc       
                                                                                          //  ----Header PDF--------------------------//
                                                                                          //    Company Logo
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
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        _pdfPCell = new PdfPCell(phrase);
                        _pdfPCell.Colspan = 6;
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
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("ReminderDetails", _fontStyle));
                        _pdfPCell.Colspan = 4;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        // -------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 2;
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
                        _Vhrlist = ViewRemainderDetails();
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("NotifyDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("SetToReminder", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Description", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Belong", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("RelatedTo", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["NotifyDate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["SetToReminder"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Description"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Belong"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["RelatedTo"].ToString(), _fontStyle));
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

                        //  Move the pointer and draw line to separate footer section from rest of page
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

                        //--------------------PDF Generation------------------------------------//
                        _pdfPTable.HeaderRows = 1; //header method
                        _document.Add(_pdfPTable);

                        _document.Close();
                        byte[] bytes = memoryStream.ToArray();
                        DateTime dTime = DateTime.Now;
                        string PDFFileName = string.Format("ReminderDetails" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
                    int _totalColumns = 6;//
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));

                    Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(6);//change
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
                        Phrase phrase = null;
                        //PdfPCell cell = null;
                        PdfPTable table = null;
                        //Color color = new Color();

                        _document.Open();
                        _pdfPTable.SetWidths(new float[] { 4f, 14f, 14f, 14f, 14f, 14f });//column width in doc       
                                                                                          //  ----Header PDF--------------------------//
                                                                                          //    Company Logo
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
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        _pdfPCell = new PdfPCell(phrase);
                        _pdfPCell.Colspan = 6;
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
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("ReminderDetails", _fontStyle));
                        _pdfPCell.Colspan = 4;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        // -------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 2;
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
                        _Vhrlist = ViewRemainderDetails();
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("NotifyDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("SetToReminder", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Description", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Belong", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("RelatedTo", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["NotifyDate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["SetToReminder"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Description"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Belong"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["RelatedTo"].ToString(), _fontStyle));
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

                        //  Move the pointer and draw line to separate footer section from rest of page
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

                        //--------------------PDF Generation------------------------------------//
                        _pdfPTable.HeaderRows = 1; //header method
                        _document.Add(_pdfPTable);

                        _document.Close();
                        byte[] bytes = memoryStream.ToArray();
                        DateTime dTime = DateTime.Now;
                        string PDFFileName = string.Format("ReminderDetails" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
        protected void btnVisibilityRemainder_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(strconnect))
                {

                    SqlCommand cmd = new SqlCommand("SP_ViewRemainderDetailsVendorVisibility", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VendorID", lblVendorID.Text);
                    cmd.Parameters.AddWithValue("@Belong", "Vendor");
                    cmd.Parameters.AddWithValue("@vendor", txtVendorName.Text);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    adpt.Fill(dt);
                    GridviewRemainder1.DataSource = dt;
                    GridviewRemainder1.DataBind();

                }
                // return dt;
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

        protected void btnReloadEminder_Click(object sender, EventArgs e)
        {
            ViewRemainderDetails();
        }
        protected void btnSaveRemainder_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    UserCon = new SqlConnection(strconnect);
                    SqlCommand UserCommand = new SqlCommand("SP_SaveRemainderVendor", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@NotifyDate", txtDateNotified.Text);
                    UserCommand.Parameters.AddWithValue("@SetToReminder", ddlSetReminderStaff.SelectedItem.Text);
                    UserCommand.Parameters.AddWithValue("@Description", txtDescriptionReminder.Text);
                    UserCommand.Parameters.AddWithValue("@SendMail", Chkboxformail.Checked);
                    UserCommand.Parameters.AddWithValue("@Belong", "Vendor");
                    UserCommand.Parameters.AddWithValue("@RelatedTo", txtVendorName.Text);
                    UserCommand.Parameters.AddWithValue("@RelatedToID", lblVendorID.Text);
                    UserCommand.Parameters.AddWithValue("@Createby", UserName);
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);
                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Reminder Save Successfully";
                        ViewRemainderDetails();
                        ClearReminder();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Reminder Already Available";
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
                finally { }
            }

        }

        protected void btnClearRemainder_Click(object sender, EventArgs e)
        {
            try
            {
                ClearReminder();
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
            finally { }
        }

        protected void btnUpdateReminder_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {

                        SqlCommand UserCommand = new SqlCommand("SP_UpdateRemainderVendor", UserCon);
                        UserCommand.Connection = UserCon;
                        UserCommand.CommandType = CommandType.StoredProcedure;
                        UserCommand.Parameters.AddWithValue("@R_ID", lblRemainderInfoWGV.Text);
                        UserCommand.Parameters.AddWithValue("@NotifyDate", txtDateNotified.Text);
                        UserCommand.Parameters.AddWithValue("@SetToReminder", ddlSetReminderStaff.SelectedItem.Text);
                        UserCommand.Parameters.AddWithValue("@Description", txtDescriptionReminder.Text);
                        UserCommand.Parameters.AddWithValue("@Belong", "Vendor");
                        UserCommand.Parameters.AddWithValue("@RelatedTo", txtVendorName.Text);
                        UserCommand.Parameters.AddWithValue("@RelatedToID", lblVendorID.Text);
                        UserCommand.Parameters.AddWithValue("@SendMail", Chkboxformail.Checked);
                        UserCommand.Parameters.AddWithValue("@Createby", UserName);
                        UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                        UserCommand.Parameters.AddWithValue("@Designation", Designation);
                        UserCon.Open();
                        int i = UserCommand.ExecuteNonQuery();
                        if (i < 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Vendor Reminder Edit Successfully";
                            ViewRemainderDetails();
                            ClearReminder();
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Vendor Reminder Not Edit Successfully";
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
                finally { }
            }
        }

        protected void btnCancelReminder_Click(object sender, EventArgs e)
        {
            /// divbtnsetRemider.Visible = true;
            string ID = lblID.Text;
            Response.Redirect("~/EditVendor.aspx?ID=" + ID + "", false);
        }

        protected void GridviewRemainder1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridviewRemainder1.Rows)
                {
                    string Status = ((Label)gridviedrow.FindControl("lblStatus")).Text;
                    Label lblR_ID1 = (Label)gridviedrow.FindControl("lblR_ID1");
                    Label lblDescription1 = (Label)gridviedrow.FindControl("lblDescription1");
                    Label lblNotifyDate1 = (Label)gridviedrow.FindControl("lblNotifyDate1");
                    Label lblSetToReminder1 = (Label)gridviedrow.FindControl("lblSetToReminder1");

                    if (Status == "True")
                    {
                        lblR_ID1.ForeColor = System.Drawing.Color.Blue;
                        lblDescription1.ForeColor = System.Drawing.Color.Blue;
                        lblNotifyDate1.ForeColor = System.Drawing.Color.Blue;
                        lblSetToReminder1.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        lblR_ID1.ForeColor = System.Drawing.Color.Red;
                        lblDescription1.ForeColor = System.Drawing.Color.Red;
                        lblNotifyDate1.ForeColor = System.Drawing.Color.Red;
                        lblSetToReminder1.ForeColor = System.Drawing.Color.Red;
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

        protected void LinkEditRemainder_Click(object sender, EventArgs e)
        {
            try
            {
                //  activeRemainder.Disabled = true;

                btnUpdateReminder.Visible = true;
                btnCancelReminder.Visible = true;
                btnSaveRemainder.Visible = false;
                btnClearRemainder.Visible = false;
                divbtnsetRemider.Visible = false;

                string SendMail;
                DeviceCon = new SqlConnection(strconnect);
                string remainderID;
                var rows = GridviewRemainder1.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                remainderID = ((Label)rows[rowindex].FindControl("lblR_ID1")).Text;

                lblRemainderInfoWGV.Text = remainderID;  //
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {

                    SqlCommand UserCommand = new SqlCommand("SP_GetRemainderByID", UserCon);
                    UserCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(UserCommand);
                    UserCommand.Parameters.AddWithValue("@R_ID", remainderID);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        //txtDateNotified.Text = dt.Rows[0]["NotifyDate"].ToString();
                        txtDateNotified.Text = DateTime.Parse(dt.Rows[0]["NotifyDate"].ToString()).ToString("yyyy-MM-dd");
                        //txtDateNotified.Attributes["value"] = DateTime.Parse(dt.Rows[0]["NotifyDate"].ToString()).ToString("yyyy-MM-dd");
                        ddlSetReminderStaff.SelectedItem.Text = dt.Rows[0]["SetToReminder"].ToString();
                        txtDescriptionReminder.Text = dt.Rows[0]["Description"].ToString();
                        SendMail = dt.Rows[0]["SendMail"].ToString();
                        if (SendMail == "True")
                        {
                            Chkboxformail.Checked = true;
                        }
                        else
                        {
                            Chkboxformail.Checked = false;

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

        protected void btnDeleteRemainder_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string remainderID;
                var rows = GridviewRemainder1.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                remainderID = ((Label)rows[rowindex].FindControl("lblR_ID1")).Text;
                lblRemainderInfoWGV.Text = remainderID;
                SqlCommand cmd = new SqlCommand("SP_DeleteRemainder", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@R_ID", remainderID);
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
                    lblMesDelete.Text = "Vendor Reminder Deleted Successfully";
                    GridviewRemainder1.EditIndex = -1;
                    ViewRemainderDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Vendor Reminder Not Deleted Successfully";
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
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName);
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

        //----------------------------------------------------------------------------//
        //Notes
        //----------------------------------------------------------------------------//
        protected void btnNotesSave_Click(object sender, EventArgs e)
        {
            try
            {
                string Customer = lblCustname1.Text;
                string CustomerID = lblID.Text;
                SqlConnection DeviceCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdatePersonalNoteVendor", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VendID", lblVendorID.Text);
                cmd.Parameters.AddWithValue("@Notes", txtNote.Text);
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
                    lblMesDelete.Text = "Vendor Note Added Successfully";
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Vendor  Note Not Added Successfully";
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
                        // lblMessage.Visible = false;
                        // lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }
            finally { }
        }

        protected void btnNoteClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtNote.Text = string.Empty;
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
                        // lblMessage.Visible = false;
                        //lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }
            finally { }
        }
        //----------------------------------------------------------------------------//
        //LinkBtn
        //----------------------------------------------------------------------------//
        protected void LinkButtonProfile_Click(object sender, EventArgs e)
        {
            ProfileDiv.Visible = true;
            ContactDiv.Visible = false;
            WorkOrderDiv.Visible = false;
            PaymentExpensesDiv.Visible = false;
            ContractDiv.Visible = false;
            ProjectDiv.Visible = false;
            TasksDiv.Visible = false;
            RemindersDiv.Visible = false;
            FilesDiv.Visible = false;
            NotesDiv.Visible = false;
        }

        protected void LinkButtonContact_Click(object sender, EventArgs e)
        {
            ProfileDiv.Visible = false;
            ContactDiv.Visible = true;
            WorkOrderDiv.Visible = false;
            PaymentExpensesDiv.Visible = false;
            ContractDiv.Visible = false;
            ProjectDiv.Visible = false;
            TasksDiv.Visible = false;
            RemindersDiv.Visible = false;
            FilesDiv.Visible = false;
            NotesDiv.Visible = false;

        }

        protected void LinkButtonWorkOrder_Click(object sender, EventArgs e)
        {
            ProfileDiv.Visible = false;
            ContactDiv.Visible = false;
            WorkOrderDiv.Visible = true;
            PaymentExpensesDiv.Visible = false;
            ContractDiv.Visible = false;
            ProjectDiv.Visible = false;
            TasksDiv.Visible = false;
            RemindersDiv.Visible = false;
            FilesDiv.Visible = false;
            NotesDiv.Visible = false;
            PaymentExpensesDiv.Visible = false;
        }

        protected void LinkButtonPaymentsExpenses_Click(object sender, EventArgs e)
        {
            ProfileDiv.Visible = false;
            ContactDiv.Visible = false;
            WorkOrderDiv.Visible = false;
            PaymentExpensesDiv.Visible = true;
            ContractDiv.Visible = false;
            ProjectDiv.Visible = false;
            TasksDiv.Visible = false;
            RemindersDiv.Visible = false;
            FilesDiv.Visible = false;
            NotesDiv.Visible = false;

        }
        protected void LinkButtonContracts_Click(object sender, EventArgs e)
        {
            ProfileDiv.Visible = false;
            ContactDiv.Visible = false;
            WorkOrderDiv.Visible = false;
            PaymentExpensesDiv.Visible = false;
            ContractDiv.Visible = true;
            ProjectDiv.Visible = false;
            TasksDiv.Visible = false;
            RemindersDiv.Visible = false;
            FilesDiv.Visible = false;
            NotesDiv.Visible = false;

        }

        protected void LinkButtonProjects_Click(object sender, EventArgs e)
        {
            ProfileDiv.Visible = false;
            ContactDiv.Visible = false;
            WorkOrderDiv.Visible = false;
            PaymentExpensesDiv.Visible = false;
            ContractDiv.Visible = false;
            ProjectDiv.Visible = true;
            TasksDiv.Visible = false;
            RemindersDiv.Visible = false;
            FilesDiv.Visible = false;
            NotesDiv.Visible = false;

        }
        protected void LinkButtonTasks_Click(object sender, EventArgs e)
        {
            ProfileDiv.Visible = false;
            ContactDiv.Visible = false;
            WorkOrderDiv.Visible = false;
            PaymentExpensesDiv.Visible = false;
            ContractDiv.Visible = false;
            ProjectDiv.Visible = false;
            TasksDiv.Visible = true;
            RemindersDiv.Visible = false;
            FilesDiv.Visible = false;
            NotesDiv.Visible = false;
        }

        protected void LinkButtonReminders_Click(object sender, EventArgs e)
        {

            ProfileDiv.Visible = false;
            ContactDiv.Visible = false;
            WorkOrderDiv.Visible = false;
            PaymentExpensesDiv.Visible = false;
            ContractDiv.Visible = false;
            ProjectDiv.Visible = false;
            TasksDiv.Visible = false;
            RemindersDiv.Visible = true;
            FilesDiv.Visible = false;
            NotesDiv.Visible = false;
        }
        protected void LinkButtonFiles_Click(object sender, EventArgs e)
        {

            ProfileDiv.Visible = false;
            ContactDiv.Visible = false;
            WorkOrderDiv.Visible = false;
            PaymentExpensesDiv.Visible = false;
            ContractDiv.Visible = false;
            ProjectDiv.Visible = false;
            TasksDiv.Visible = false;
            RemindersDiv.Visible = false;
            FilesDiv.Visible = true;
            NotesDiv.Visible = false;
        }
        protected void LinkButtonNotes_Click(object sender, EventArgs e)
        {

            ProfileDiv.Visible = false;
            ContactDiv.Visible = false;
            WorkOrderDiv.Visible = false;
            PaymentExpensesDiv.Visible = false;
            ContractDiv.Visible = false;
            ProjectDiv.Visible = false;
            TasksDiv.Visible = false;
            RemindersDiv.Visible = false;
            FilesDiv.Visible = false;
            NotesDiv.Visible = true;

        }

        //=====================================================================//
        //protected void chkIsEnabled_CheckedChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = (GridViewRow)((CheckBox)sender).NamingContainer;
        //    CheckBox chkIsEnabled = (CheckBox)row.FindControl("chkIsEnabled");
        //    Label lblIsEnabled = (Label)row.FindControl("lblIsEnabled");


        //    lblIsEnabled.Text = chkIsEnabled.Checked.ToString();
        //}

        #endregion
    }
}