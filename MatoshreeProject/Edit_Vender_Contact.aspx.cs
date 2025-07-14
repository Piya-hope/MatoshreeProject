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
using static System.Net.WebRequestMethods;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using System.Diagnostics.Contracts;

using System.Text;
using System.Net;
using System.Net.Mail;
#endregion

namespace MatoshreeProject
{
    public partial class Edit_Vender_Contact : System.Web.UI.Page
    {
        #region "Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result, file1, Vend_ID, ID1;

        int UserId;

        string UserName, EmailID, Designation, RoleType, Permission, DeptID;


        string DevEmail, DevPassword, DevPort, DevHost;

        string UserEmpName, Password, EmailID1, Designation1, Fname, Lname;

        string inv, project, tendor, primarycontact, Do_Not_Send_WC_Email, annoncement;
        string Send_Set_Password_Email1, contract1, Status, Estimate, ticket, Default;


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

        #region " Private Functions "
        #endregion

        #region " Public Function "
        private static Random random = new Random((int)DateTime.Now.Ticks);
        private string RandomString(int size)
        {

            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public void SendEmail()
        {
            try
            {
                //-----------------Sending Email------------------------//
                GETCredentials();//method for domain password
                Password = txt_Password.Text;
                EmailID1 = txt_Email.Text;
                Designation1 = txt_Position.Text;
                lblEmpName11.Text = txtFirst_Name.Text + " " + txt_Last_Name.Text;
                UserEmpName = lblEmpName11.Text;
                //Send Email User Password....//
                if (!string.IsNullOrEmpty(Password))
                {
                    using (MailMessage mm = new MailMessage(DevEmail, EmailID1))
                    {
                        //  MailBody
                        mm.Subject = "Welcome in Matoshree Interior Your LogIn ID And Password";
                        string body = "Hello Mr/Miss." + UserEmpName + "<br />";

                        if (txtEmailDescription.Text == "")
                        {
                            body += "Congratulations on being part of the team! The whole company welcomes you, and we look forward to a successful journey with you! Welcome aboard!";
                            body += "<br /><br />Your Designation is: " + Designation1 + "";
                            body += "<br /><br />Your Login Id  is: " + EmailID1 + "";
                            body += "<br /><br />Your Password is: " + Password + " ";
                            body += "<br /><br />Your LogIn Url given below";
                        }
                        else
                        {
                            body += "Congratulations on " + txtEmailDescription.Text + "";
                            body += "<br /><br />Your Designation is: " + Designation1 + "";
                            body += "<br /><br />Your Login Id  is: " + EmailID1 + "";
                            body += "<br /><br />Your Password is: " + Password + " ";
                            body += "<br /><br />Your LogIn Url given below";
                        }

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


        public void ClearContact()
        {
            txtFirst_Name.Text = string.Empty;
            txt_Last_Name.Text = string.Empty;
            txt_Phone.Text = string.Empty;
            txt_Email.Text = string.Empty;
            txt_Password.Text = string.Empty;
            txt_Position.Text = string.Empty;
            ddlDirection.SelectedIndex = 0;
            CheckBPrimary.Checked = false;
            CheckBoxwelcome.Checked = false;
            CheckBoxpassword.Checked = false;
            chkInvoices.Checked = false;
            chkEstimate.Checked = false;
            chkContracts.Checked = false;
            chkTender.Checked = false;
            chkProjects.Checked = false;
            chkTickets.Checked = false;
            chkAnnouncement.Checked = false;
        }

        public void GetVendorContactDetailsByID()
        {
            try
            {
                //Vend_ID = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                //lblVendorID.Text = Vend_ID;

                ID1 = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                lblVendorContactID.Text = ID1;

                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetVendorContactDetailsByID", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactID", ID1);
                //cmd.Parameters.AddWithValue("@Vender_id", Vend_ID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblVendorID.Text = dt.Rows[0]["Vender_id"].ToString();
                    lblfilepath.Text = dt.Rows[0]["profile_image"].ToString();
                    lblfilename.Text = dt.Rows[0]["FileName"].ToString();
                    txtFirst_Name.Text = dt.Rows[0]["firstname"].ToString();
                    txt_Last_Name.Text = dt.Rows[0]["lastname"].ToString();
                    txt_Position.Text = dt.Rows[0]["Position"].ToString();
                    txt_Email.Text = dt.Rows[0]["email"].ToString();
                    txt_Phone.Text = dt.Rows[0]["phonenumber"].ToString();
                    ddlDirection.SelectedItem.Text = dt.Rows[0]["direction"].ToString();
                    txt_Password.Text = dt.Rows[0]["password"].ToString();

                    string inv, project, tendor, primarycontact, Do_Not_Send_WC_Email,annoncement;
                    string Send_Set_Password_Email1, contract1, Status, Estimate, ticket;

                    inv = dt.Rows[0]["invoice"].ToString();
                    project = dt.Rows[0]["project"].ToString();
                    tendor = dt.Rows[0]["tender"].ToString();
                    primarycontact = dt.Rows[0]["Primary_Contact"].ToString();
                    Do_Not_Send_WC_Email = dt.Rows[0]["Do_Not_Send_WC_Email"].ToString();
                    Send_Set_Password_Email1 = dt.Rows[0]["Send_Set_Password_Email"].ToString();
                    Estimate = dt.Rows[0]["estimate"].ToString();
                    // Estimate = dt.Rows[0]["estimate"].ToString();
                    ticket = dt.Rows[0]["ticket"].ToString();
                    contract1 = dt.Rows[0]["contract"].ToString();
                    annoncement = dt.Rows[0]["announcement"].ToString();

                    if (primarycontact == "True")
                    {

                        CheckBPrimary.Checked = true;
                    }
                    else
                    {
                        CheckBPrimary.Checked = false;
                    }

                    if (Do_Not_Send_WC_Email == "True")
                    {
                        CheckBoxwelcome.Checked = true;
                    }
                    else
                    {
                        CheckBoxwelcome.Checked = false;
                    }

                    if (Send_Set_Password_Email1 == "True")
                    {
                        CheckBoxpassword.Checked = true;
                    }
                    else
                    {
                        CheckBoxpassword.Checked = false;
                    }

                    if (inv == "True")
                    {
                        chkInvoices.Checked = true;
                    }
                    else
                    {
                        chkInvoices.Checked = false;
                    }
                    if (project == "True")
                    {
                        chkProjects.Checked = true;
                    }
                    else
                    {
                        chkProjects.Checked = false;
                    }

                    if (Estimate == "True")
                    {
                        chkEstimate.Checked = true;
                    }
                    else
                    {
                        chkEstimate.Checked = false;
                    }

                    if (contract1 == "True")
                    {
                        chkContracts.Checked = true;
                    }
                    else
                    {
                        chkContracts.Checked = false;
                    }
                    if (tendor == "True")
                    {
                        chkTender.Checked = true;
                    }
                    else
                    {
                        chkTender.Checked = false;
                    }

                    if (annoncement == "True")
                    {
                        chkAnnouncement.Checked = true;
                    }
                    else
                    {
                        chkAnnouncement.Checked = false;
                    }

                    Default = dt.Rows[0]["Flag"].ToString();
                    if (Default == "True")
                    {
                        RadioButtonList1.SelectedValue = "1";
                    }
                    else
                    {
                        RadioButtonList1.SelectedValue = "0";
                    }
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
                            GetVendorContactDetailsByID();
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
                                GetVendorContactDetailsByID();
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
       
        protected void btnUpdateVenderContacts_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string fileName = null;
                    string filePath = null;

                    if (FileUpload1.PostedFile == null)
                    {
                        if (lblfilename.Text == "")
                        {
                            string uploadDirectory = Server.MapPath("~/Upload/");
                           
                            if (FileUpload1.HasFile)
                            {
                                if (!Directory.Exists(uploadDirectory))
                                {
                                    Directory.CreateDirectory(uploadDirectory);
                                }

                                fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                                filePath = Path.Combine(uploadDirectory, fileName);
                                FileUpload1.PostedFile.SaveAs(filePath);
                            }
                        }
                        else
                        {
                            fileName = lblfilename.Text;
                            filePath=lblfilepath.Text;
                        }
                    }
                    else
                    {
                        if (lblfilename.Text == "")
                        {
                            string uploadDirectory = Server.MapPath("~/Upload/");
                           
                            if (FileUpload1.HasFile)
                            {
                                if (!Directory.Exists(uploadDirectory))
                                {
                                    Directory.CreateDirectory(uploadDirectory);
                                }

                                fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                                filePath = Path.Combine(uploadDirectory, fileName);
                                FileUpload1.PostedFile.SaveAs(filePath);
                            }
                        }
                        else
                        {
                            fileName = lblfilename.Text;
                            filePath = lblfilepath.Text;
                        }
                    }
                  

                    if (CheckBPrimary.Checked)
                    {

                        primarycontact = "true";
                    }
                    else
                    {
                        primarycontact = "false";
                    }

                    if (CheckBoxwelcome.Checked)
                    {
                        Do_Not_Send_WC_Email  = "true";
                    }
                    else
                    {
                        Do_Not_Send_WC_Email = "false";
                    }

                    if (CheckBoxpassword.Checked)
                    {
                        Send_Set_Password_Email1  = "true";
                    }
                    else
                    {
                        Send_Set_Password_Email1 = "false";
                    }

                    if (chkInvoices.Checked)
                    {
                        inv  = "true";
                    }
                    else
                    {
                        inv = "false";
                    }
                    if (chkProjects.Checked)
                    {
                        project  = "true";
                    }
                    else
                    {
                        project = "false";
                    }

                    if (chkEstimate.Checked)
                    {
                        Estimate  = "true";
                    }
                    else
                    {
                        Estimate = "false";
                    }

                    if (chkContracts.Checked)
                    {
                        contract1 = "true";
                    }
                    else
                    {
                        contract1 = "false";
                    }
                    if (chkTender.Checked)
                    {
                        tendor = "true";
                    }
                    else
                    {
                        tendor = "false";
                    }

                    if (chkAnnouncement.Checked)
                    {
                        annoncement  = "true";
                    }
                    else
                    {
                        annoncement = "false";
                    }

                   
                    SqlConnection UserCon = new SqlConnection(strconnect);
                    SqlCommand UserCommand = new SqlCommand("UpdateVenderContactsDetails", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;                
                    UserCommand.Parameters.AddWithValue("@Vender_id", lblVendorID.Text);
                    UserCommand.Parameters.AddWithValue("@VendorContanctId", lblVendorContactID.Text);
                    UserCommand.Parameters.AddWithValue("@firstname", txtFirst_Name.Text);
                    UserCommand.Parameters.AddWithValue("@lastname", txt_Last_Name.Text);
                    UserCommand.Parameters.AddWithValue("@phonenumber", txt_Phone.Text);
                    UserCommand.Parameters.AddWithValue("@email", txt_Email.Text);
                    UserCommand.Parameters.AddWithValue("@password", txt_Password.Text);
                    UserCommand.Parameters.AddWithValue("@direction", ddlDirection.SelectedItem.Text);
                    UserCommand.Parameters.AddWithValue("@Position", txt_Position.Text);
                    UserCommand.Parameters.AddWithValue("@Primary_Contact", CheckBPrimary.Checked);
                    UserCommand.Parameters.AddWithValue("@Do_Not_Send_WC_Email", CheckBoxwelcome.Checked);
                    UserCommand.Parameters.AddWithValue("@Send_Set_Password_Email", CheckBoxpassword.Checked);
                    UserCommand.Parameters.AddWithValue("@profile_image", filePath);
                    UserCommand.Parameters.AddWithValue("@FileName", fileName);
                    UserCommand.Parameters.AddWithValue("@invoice", chkInvoices.Checked);
                    UserCommand.Parameters.AddWithValue("@estimate", chkEstimate.Checked);
                    UserCommand.Parameters.AddWithValue("@contract", chkContracts.Checked);
                    UserCommand.Parameters.AddWithValue("@tender", chkTender.Checked);
                    UserCommand.Parameters.AddWithValue("@project", chkProjects.Checked);
                    UserCommand.Parameters.AddWithValue("@ticket", chkTickets.Checked);
                    UserCommand.Parameters.AddWithValue("@announcement", chkAnnouncement.Checked);
                    UserCommand.Parameters.AddWithValue("@Status", RadioButtonListVendor.SelectedValue);
                    UserCommand.Parameters.AddWithValue("@Flag", RadioButtonList1.SelectedValue);
                    UserCommand.Parameters.AddWithValue("@belong", "Vendor");
                    UserCommand.Parameters.AddWithValue("@CreateBy", UserName);//session 
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);//session
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);//session save/update/delete
                    UserCon.Open();
                    int i = UserCommand.ExecuteNonQuery();
                    if (i < 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Vendor Contact Details Updated Successfully!')", true);
                        string Vend_ID = lblVendorID.Text ;
                        
                        Response.Redirect("~/EditVendor.aspx?ID=" + Vend_ID + "" , false);
                        // Response.Redirect("~/EditVendor.aspx", false);
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Vendor Contact Details Not Updated Successfully!')", true);
                    }
                    ClearContact();
                    UserCon.Close();
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
        }

        protected void btnCancelVenderContacts_Click(object sender, EventArgs e)
        {
            string Vend_ID = lblVendorID.Text;

            Response.Redirect("~/EditVendor.aspx?ID=" + Vend_ID + "", false);
            //Response.Redirect("~/EditVendor.aspx", false);
        }

        protected void LinkbtnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                //-----Password By Admin-----//
                if (txt_Password.Text == "")
                {
                    string Password = RandomString(8);
                    txt_Password.Text = Password;
                }
                else
                {
                    string Password = txt_Password.Text;
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
        protected void CheckBoxwelcome_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxwelcome.Checked == false)
                {
                    txtEmailDescription.Visible = true;

                }
                else
                {
                    txtEmailDescription.Visible = true;//do not send password

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