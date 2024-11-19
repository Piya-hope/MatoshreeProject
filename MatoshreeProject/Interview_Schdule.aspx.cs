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
    public partial class Interview_Schdule : System.Web.UI.Page
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

        protected void GridViewInterviewSchedule_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridViewInterviewSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

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

        #endregion

        #region " Event "

        public void Clear()
        {

            txtFullNm.Text = string.Empty;
            txtPosition.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtInterviewDate.Text = string.Empty;
            txtInterviewTime.Text = string.Empty;
            rbtnList.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtInterviewerNm.Text = string.Empty;
            txtlink.Text = string.Empty;


        }

        public void GetInterviewSchduleDetailsByID()
        {
            try
            {
                CareerID = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                lblID.Text = CareerID;
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetInterviewSchduleDetailsByID", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@ID", lblID.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtFullNm.Text = dt.Rows[0]["FullName"].ToString();
                    txtPosition.Text = dt.Rows[0]["AppliedPost"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtPhone.Text = dt.Rows[0]["MobileNumber"].ToString();

                    //txtInterviewDate.Text = dt.Rows[0]["InterviewDate"].ToString();
                 
                    //rbtnList.Text = dt.Rows[0]["InterviewerLocation"].ToString();
                    //txtInterviewTime.Text = dt.Rows[0]["InterviewTime"].ToString();
                    //txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    //txtInterviewerNm.Text = dt.Rows[0]["InterviewerName"].ToString();
                    //txtlink.Text = dt.Rows[0]["MeetingLink"].ToString();

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
        protected void GridInterviewSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        public DataTable ViewGetInterviewSchduleDetail()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewGetInterviewSchduleDetail", con))
                {
                    ad.Fill(table);
                    GridInterviewSchedule.DataSource = table;
                    GridInterviewSchedule.DataBind();
                    ViewState["CareerData"] = table;
                }
            }
            return table;
        }

        //public DataTable ViewInterviewSchduleInfo()
        //{
        //    DataTable table = new DataTable();
        //    using (SqlConnection con = new SqlConnection(strconnect))
        //    {
        //        using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewGetInterviewSchduleDetail", con))
        //        {
        //            ad.Fill(table);
        //            GridViewInterviewSchedule.DataSource = table;
        //            GridViewInterviewSchedule.DataBind();
        //            ViewState["CareerData1"] = table;
        //        }
        //    }
        //    return table;
        //}
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
                            GetInterviewSchduleDetailsByID();
                            ViewGetInterviewSchduleDetail();

                            SetControlState();
                            // ViewInterviewSchduleInfo();

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
                                GetInterviewSchduleDetailsByID();
                                ViewGetInterviewSchduleDetail();

                                SetControlState();
                                // ViewInterviewSchduleInfo();
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
        private void SetControlState()
        {
            if (rbtnList.SelectedValue == "1") // Onsite
            {
                txtAddress.Enabled = true;
                txtlink.Enabled = false;
            }
            else if (rbtnList.SelectedValue == "2") // Online
            {
                txtAddress.Enabled = false;
                txtlink.Enabled = true;
            }

        }
            protected void rbtnList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetControlState();
        }

        protected void btnViewInterviewSchdule_Click(object sender, EventArgs e)
        {
            try
            {
                string ID;
                var rows = GridInterviewSchedule.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;
                Response.Redirect("~/Interview_Schdule.aspx?ID=" + ID + "", false);
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
        protected void GridInterviewSchedule_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_SaveInterviewSchdeule", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id", lblID.Text);
                cmd.Parameters.AddWithValue("@FullName", txtFullNm.Text);
                cmd.Parameters.AddWithValue("@AppliedPost", txtPosition.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@MobileNumber", txtPhone.Text);
                cmd.Parameters.AddWithValue("@InterviewDate", txtInterviewDate.Text);
                cmd.Parameters.AddWithValue("@InterviewTime", txtInterviewTime.Text);
                cmd.Parameters.AddWithValue("@InterviewerLocation", rbtnList.Text);
                if (rbtnList.SelectedValue == "1") // Onsite
                {
                    txtAddress.Enabled = true;
                    txtlink.Enabled = false;
                }
                else if (rbtnList.SelectedValue == "2") // Online
                {
                    txtAddress.Enabled = false;
                    txtlink.Enabled = true;
                }
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@InterviewerName", txtInterviewerNm.Text);
                cmd.Parameters.AddWithValue("@MeetingLink", txtlink.Text);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Created_by", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                //cmd.Parameters.AddWithValue("@ApprovalStatus", "Accept");
               


                con.Open();
                int Result = cmd.ExecuteNonQuery();
                if (Result < 0)

                {
                    GETStaffEmail(txtFullNm.Text);
                    SendEmail(txtFullNm.Text);

                    string save = "fgsave123q";
                    Response.Redirect("~/Interview_Schdule.aspx?svd1=" + save + "", false);

                }
                else
                {

                    lblMesDelete.Text = "Interview Schdule Details already Available";

                }
                //string managerEmail = "suvarnabansode718@gmail.com";
                //string employeeName = txtStaffName.Text;
                //string leaveType = ddlLeaveType.SelectedValue;
                //DateTime startDate = DateTime.Parse(txtStartDate.Text);
                //DateTime endDate = DateTime.Parse(txtEndDate.Text);

                //EmailService emailService = new EmailService();
                //emailService.SendLeaveRequestEmail(managerEmail, employeeName, leaveType, startDate, endDate);

                // Optionally, show a confirmation message to the user
                Response.Write("<script>alert('Interview Schdule submitted successfully.');</script>");

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
                    GETStaffEmail(txtFullNm.Text);
                    SendEmail(txtFullNm.Text);

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
                Designation1 = txtPosition.Text;
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
                        mm.Subject = "Interview Schedule for" + txtPosition.Text + " " + " Position";

                        //mm.Subject = "Subject: Confirmation of Receipt - Your Resume for"+ " "+ txtPostApplied.Text ;
                        mm.CC.Add(new MailAddress(ApprovalEmail));

                        //mm.Subject = "Leave Request" + txtStaffName.Text;
                        //mm.CC.Add(new MailAddress(ApprovalEmail));

                        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                        //string body = "Subject: Leave Request for " + txtStaffName.Text + " on " + currentDate + "<br />";
                        string body = "Subject: Interview Schedule for" + txtPosition.Text + " " + " on " + currentDate + "<br />";

                        body += "Dear " + txtFullNm.Text + ",<br />";
                        body += "I hope this email finds you well. We are pleased to inform you that you have been shortlisted for the   " + txtPosition.Text + "<br />";
                        body += "We would like to schedule an interview with you to discuss your application further and explore how your skills and experiences align with our team's needs." + "<br />";
                        body += "Please let us know your availability for an interview during the following times::" + txtInterviewDate.Text + "<br />";
                        // body += "Reason for Leave:" + txtResonReject.Text + "<br />";
                        body += "We appreciate your interest in joining Lissomtechnologies and look forward to our conversation." + " <br />";
                        body += "Best regards," + "<br />";
                        body += ApprovalName + "<br />";
                        body += ApprovalDesignation;

                        string urllocal = HttpUtility.HtmlEncode("http://localhost:53687/UserLogIn/LogIn");
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
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }


        #endregion
    }
}