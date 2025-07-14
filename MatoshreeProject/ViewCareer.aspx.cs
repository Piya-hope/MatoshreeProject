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
using System.Net.Mail;
using System.Net;
#endregion

namespace MatoshreeProject
{
    public partial class ViewCareer : System.Web.UI.Page
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
        string UserName, EmailID, Designation, RoleType, Permission, DeptID, CareerID, sendMail, EmpNAME;

        string DevEmail, DevPassword, DevPort, DevHost;
        string UserEmpName, Password, EmailID1, Designation1;

        

        //protected void btnDownload_Click(object sender, EventArgs e)
        //{

        //}

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

        #region " Public Functions "

        //public void GetCareerDataByID1(string careerID)
        //{
        //    try
        //    {
        //        string CareerID = HttpUtility.UrlDecode(Request.QueryString["ID"]);
        //        lblID.Text = CareerID;
        //        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

        //        using (SqlConnection UserCon = new SqlConnection(strconnect))
        //        {
        //            SqlCommand cmd = new SqlCommand("SP_GetCareerDetailsByID", UserCon)
        //            {
        //                CommandType = CommandType.StoredProcedure
        //            };
        //            cmd.Parameters.AddWithValue("@id", lblID.Text);

        //            SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            sda.Fill(dt);

        //            if (dt.Rows.Count > 0)
        //            {
        //                byte[] bytes;
        //                string contenttype;

        //                using (SqlConnection Con = new SqlConnection(strconnect))
        //                {
        //                    string cvsql = "SELECT Resume FROM Tbl_Careers WHERE id = @id";
        //                    SqlCommand mycommand = new SqlCommand(cvsql, Con);
        //                    mycommand.Parameters.AddWithValue("@id", CareerID);

        //                    Con.Open();
        //                    SqlDataReader myreader = mycommand.ExecuteReader();

        //                    if (myreader.Read())
        //                    {
        //                        bytes = (byte[])myreader["Resume"];
        //                       // contenttype = myreader["ContentType"].ToString();

        //                        Response.Clear();
        //                        Response.Buffer = true;
        //                        Response.Charset = "";
        //                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //                       // Response.ContentType = contenttype;
        //                        Response.AppendHeader("Content-Disposition", "attachment; filename=resume.bin");
        //                        Response.BinaryWrite(bytes);
        //                        Response.Flush();
        //                        Response.End();
        //                    }

        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        //        using (SqlConnection DeviceCon = new SqlConnection(strconnect))
        //        {
        //            string ErrorMessage = ex.Message;
        //            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
        //            string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
        //            string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
        //            int lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
        //            SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon)
        //            {
        //                CommandType = CommandType.StoredProcedure
        //            };
        //            cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessage);
        //            cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
        //            cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
        //            cmdex.Parameters.AddWithValue("@Method", method);
        //            cmdex.Parameters.AddWithValue("@CreatedBy", "UserName"); // Replace with actual username

        //            DeviceCon.Open();
        //            int RowEx = cmdex.ExecuteNonQuery();
        //            if (RowEx < 0)
        //            {
        //                // Handle error details save failure
        //            }
        //            else
        //            {
        //                // Handle error details save success
        //            }
        //        }
        //    }
        //}
        public void Clear()
        {

            txtFirstName.Text = string.Empty;
            txtMiddleNm.Text = string.Empty;
            txtLastNm.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtCurrentLoc.Text = string.Empty;
            txtExperience.Text = string.Empty;
            txtQualification.Text = string.Empty;
            txtPostApplied.Text = string.Empty;
            txtEmployeement.Text = string.Empty;



        }

        public void GetCareerDataByID()
        {
            try
            {
                CareerID = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                lblID.Text = CareerID;
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetCareerDetailsByID", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@id", lblID.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                    txtMiddleNm.Text = dt.Rows[0]["MiddleName"].ToString();
                    txtLastNm.Text = dt.Rows[0]["LastName"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtPhone.Text = dt.Rows[0]["MobileNumber"].ToString();
                    txtCurrentLoc.Text = dt.Rows[0]["CurrentLocation"].ToString();
                    txtExperience.Text = dt.Rows[0]["Experience"].ToString();
                    txtQualification.Text = dt.Rows[0]["Qualification"].ToString();
                    txtEmployeement.Text = dt.Rows[0]["CurrentEmployer"].ToString();
                    txtPostApplied.Text = dt.Rows[0]["AppliedPost"].ToString();
                   // txtPostApplied.Text = dt.Rows[0]["AppliedPost"].ToString();
                   // lblAttachment.Text = dt.Rows[0]["Resume"].ToString();
                    // GetCareerDataByID1(CareerID);
                    // Handling Resume
                    //if (row["Resume"] != DBNull.Value)
                    //{
                    //    byte[] resumeBytes = (byte[])row["Resume"];
                    //    string resumeBase64 = Convert.ToBase64String(resumeBytes);
                    //    string resumeUrl = "data:application/pdf;base64," + resumeBase64;
                    //    hlResume.NavigateUrl = resumeUrl;
                    //    hlResume.Text = "Download Resume";
                    //    hlResume.Visible = true;
                    //}
                    //else
                    //{
                    //    hlResume.Visible = false;
                    //}

                    // Handling Resume
                    //if (row["Resume"] != DBNull.Value)
                    //{
                    //    Btn_Upload.Visible = true;
                    //}
                    //else
                    //{
                    //    Btn_Upload.Visible = false;
                    //}
                    // filepath = dt.Rows[0]["profile_image"].ToString();
                    //lblAttachment.Text = dt.Rows[0]["Resume"].ToString();

                    // Retrieve and display the file path
                    //string filePath = dt.Rows[0]["ResumeFilePath"].ToString();
                    //if (!string.IsNullOrEmpty(filePath))
                    //{
                    //    hlResume.NavigateUrl = filePath;
                    //    hlResume.Text = "Download Resume";
                    //    hlResume.Visible = true;
                    //}
                    //else
                    //{
                    //    hlResume.Visible = false;
                    //}
                    //sendMail = dt.Rows[0]["SendMail"].ToString();
                    //if (sendMail == "True")
                    //{
                    //    ChBoxSendMail.Checked = true;
                    //}
                    //else
                    //{
                    //    ChBoxSendMail.Checked = false;
                    //}
                    //Status = dt.Rows[0]["Status"].ToString();
                    //if (Status == "True")
                    //{
                    //    RadioButtonListCustomer.SelectedValue = "1";
                    //}
                    //else
                    //{
                    //    RadioButtonListCustomer.SelectedValue = "0";
                    //}

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
                            GetCareerDataByID();
                           
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
                                GetCareerDataByID();
                                //StaffOperationPermission();
                                //StaffOperationInvoicePermission();
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

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                //Stream fs = FileUpload.PostedFile.InputStream;
                //BinaryReader br = new BinaryReader(fs);
                //Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_AccepetResumeApproval", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", lblID.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@MiddleName", txtMiddleNm.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastNm.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@MobileNumber", txtPhone.Text);
                cmd.Parameters.AddWithValue("@CurrentLocation", txtCurrentLoc.Text);
                cmd.Parameters.AddWithValue("@Experience", txtExperience.Text); 
                cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text);
                cmd.Parameters.AddWithValue("@AppliedPost", txtPostApplied.Text);
               //cmd.Parameters.AddWithValue("@Resume", bytes);
                cmd.Parameters.AddWithValue("@CurrentEmployer", txtEmployeement.Text);
                cmd.Parameters.AddWithValue("@Approval", "True");
                cmd.Parameters.AddWithValue("@ApprovalBy", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@Updateby", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@ApprovalStatus", "Accept");


                con.Open();
                int Result = cmd.ExecuteNonQuery();
                if (Result < 0)

                {
                    GETStaffEmail(txtFirstName.Text + " " + txtLastNm.Text);
                    SendEmail(txtFirstName.Text + " " + txtLastNm.Text);

                    string save = "fgsave123q";
                    Response.Redirect("~/career.aspx?svd1=" + save + "", false);

                }
                else
                {

                    lblMesDelete.Text = "Resume Details already Available";

                }
                //string managerEmail = "suvarnabansode718@gmail.com";
                //string employeeName = txtStaffName.Text;
                //string leaveType = ddlLeaveType.SelectedValue;
                //DateTime startDate = DateTime.Parse(txtStartDate.Text);
                //DateTime endDate = DateTime.Parse(txtEndDate.Text);

                //EmailService emailService = new EmailService();
                //emailService.SendLeaveRequestEmail(managerEmail, employeeName, leaveType, startDate, endDate);

                // Optionally, show a confirmation message to the user
                Response.Write("<script>alert('Resume submitted successfully.');</script>");

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

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_AccepetResumeApproval", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", lblID.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@MiddleName", txtMiddleNm.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastNm.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@MobileNumber", txtPhone.Text);
                cmd.Parameters.AddWithValue("@CurrentLocation", txtCurrentLoc.Text);
                cmd.Parameters.AddWithValue("@Experience", txtExperience.Text);
                cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text);
                cmd.Parameters.AddWithValue("@AppliedPost", txtPostApplied.Text);
                cmd.Parameters.AddWithValue("@CurrentEmployer", txtEmployeement.Text);
                cmd.Parameters.AddWithValue("@Approval", "False");
                cmd.Parameters.AddWithValue("@ApprovalBy", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@Updateby", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@ApprovalStatus", "Reject");


                con.Open();
                int Result = cmd.ExecuteNonQuery();
                if (Result < 0)

                {
                    GETStaffEmail(txtFirstName.Text + " " + txtLastNm.Text);
                    SendEmail(txtFirstName.Text + " " + txtLastNm.Text);

                    string save = "fgsave123q";
                    Response.Redirect("~/career.aspx?svd1=" + save + "", false);

                }
                else
                {

                    lblMesDelete.Text = "Resume Details already Available";

                }
                //string managerEmail = "suvarnabansode718@gmail.com";
                //string employeeName = txtStaffName.Text;
                //string leaveType = ddlLeaveType.SelectedValue;
                //DateTime startDate = DateTime.Parse(txtStartDate.Text);
                //DateTime endDate = DateTime.Parse(txtEndDate.Text);

                //EmailService emailService = new EmailService();
                //emailService.SendLeaveRequestEmail(managerEmail, employeeName, leaveType, startDate, endDate);

                // Optionally, show a confirmation message to the user
                Response.Write("<script>alert('Resume submitted successfully.');</script>");

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
                    GETStaffEmail(txtFirstName.Text + " " + txtLastNm.Text);
                    SendEmail(txtFirstName.Text + " " + txtLastNm.Text);

                    lblStaffEmail.Text = Convert.ToString(dt.Rows[0]["Email"].ToString());
                    lblStaffDesignation.Text = Convert.ToString(dt.Rows[0]["Role"].ToString());

                }
                con.Close();

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
        public void SendEmail(string EMPNamE)//DevEmail
        {
            try
            {
                //-----------------Accepting Email------------------------//
                GETCredentials();//method for domain password
                string ApprovalEmail = EmailID;
                string ApprovalName = UserName;
                string ApprovalDesignation = Designation;

                EmailID1 = txtEmail.Text;
                Designation1 = txtPostApplied.Text;
                lblEmpName11.Text = EMPNamE;
                UserEmpName = lblEmpName11.Text;

                //EmailID1 = lblStaffEmail.Text;
                //Designation1 = lblStaffDesignation.Text;
                //lblEmpName11.Text = EMPNamE;
                //UserEmpName = lblEmpName11.Text;
                //Send Email User Password....//
                if (!string.IsNullOrEmpty(EmailID1))
                {
                    using (MailMessage mm = new MailMessage(DevEmail, EmailID1))
                    {
                        //  MailBody
                        mm.Subject = "Confirmation of Receipt - Your Resume for " + txtPostApplied.Text + " " + " Position";

                        //mm.Subject = "Subject: Confirmation of Receipt - Your Resume for"+ " "+ txtPostApplied.Text ;
                        mm.CC.Add(new MailAddress(ApprovalEmail));

                        //mm.Subject = "Leave Request" + txtStaffName.Text;
                        //mm.CC.Add(new MailAddress(ApprovalEmail));

                        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                        //string body = "Subject: Leave Request for " + txtStaffName.Text + " on " + currentDate + "<br />";
                        string body = "Subject: Confirmation of Receipt - Your Resume for" + txtPostApplied.Text + " "  + " on " + currentDate + "<br />";

                        body += "Dear " + txtFirstName.Text + " " + txtLastNm.Text + ",<br />";
                        body += "I hope this email finds you well. I am writing to confirm that we have received your resume in application for the  " + txtPostApplied.Text + "<br />";
                        //body += "Details of theInterview: " + "<br />";
                        //body += "Leave Date:" + currentDate + "<br />";
                       // body += "Reason for Leave:" + txtResonReject.Text + "<br />";
                        body += "We appreciate your interest in joining our team and taking the time to submit your application. Your resume will be reviewed thoroughly by our hiring team. If your qualifications and experience align with the requirements of the position, we will contact you to schedule an interview." + "<br />";
                        body += "Best regards," + "<br />";
                        body += ApprovalName + "<br />";
                        body += ApprovalDesignation;

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
                  //  smtp.Host = EmailID;
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


        protected void btnResumeDownload_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetCareerDetailsByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@id", lblID.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string name = dt.Rows[0]["LastName"].ToString();
                        Byte[] bytes = (Byte[])dt.Rows[0]["Resume"];

                        // Set content type to PDF
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=" + name + ".pdf");

                        // Write the binary data to the response stream
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
        #endregion
    }
}