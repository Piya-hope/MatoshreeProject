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
using ListItem = System.Web.UI.WebControls.ListItem;
using System.Net;
using System.Net.Mail;
#endregion

namespace MatoshreeProject
{
    public partial class NewTicket : System.Web.UI.Page
    {
        #region " Class Level Variable "

        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result;

        string Tenderid, Publish;
        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        string Contractid;
        string Size, Initial, ReceiptFor, Cash, Bank, reminder;

        string Day = Convert.ToString(DateTime.Today.Day);
        string year = Convert.ToString(DateTime.Today.Year);
        Double TenderTOTALAMONT;

        Double DiscountItem1 = 0, Adjustment1, TaxTotalItem1, SubtotalItem1;
        decimal TotalTEnderAmont;

        string DevEmail, DevPassword, DevPort, DevHost;
        string UserEmpName, Password, EmailID1, Designation1;
        #endregion

        #region " strconnectuctor "
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

        public void GETStaffEmail(string StaffID)
        {
            //----Domail ID Password----//
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmailbyStaffID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", StaffID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    lblStaffEmail.Text = Convert.ToString(dt.Rows[0]["Email"].ToString());
                    lblStaffDesignation.Text = Convert.ToString(dt.Rows[0]["Role"].ToString());

                }
                con.Close();

            }

        }
        public void SendEmail(string EMPNamE)
        {
            try
            {
                //-----------------Sending Email------------------------//
                GETCredentials();//method for domain password


                EmailID1 = lblStaffEmail.Text;
                Designation1 = lblStaffDesignation.Text;
                lblEmpName11.Text = EMPNamE;
                UserEmpName = lblEmpName11.Text;
                //Send Email User Password....//
                if (!string.IsNullOrEmpty(EmailID1))
                {
                    using (MailMessage mm = new MailMessage(DevEmail, EmailID1))
                    {
                        //  MailBody
                        mm.Subject = "New Ticket generate" + txtInitialTicket.Text;

                        string body = "Hello Mr/Miss." + UserEmpName + "<br />";

                        body += "You have been assigned a new Ticket:  ";
                        body += "Project:" + ddlProject.SelectedItem.Text;
                        body += "Priority:" + ddlpriority.SelectedItem.Text;
                        body += "Department:" + ddldepart.SelectedItem.Text;
                        body += "Asssign Ticket:" + ddlassign.SelectedItem.Text;
                        body += "Service:" + txtservice.Text;
                        body += txtareabody.Text;

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

        public void SendEmailCustomer(string contact)
        {
            try
            {
                //-----------------Sending Email------------------------//
                GETCredentials();//method for domain password


                EmailID1 = txtemail.Text;
                Designation1 = lblStaffDesignation.Text;
                lblEmpName11.Text = contact;
                UserEmpName = lblEmpName11.Text;
                //Send Email User Password....//
                if (!string.IsNullOrEmpty(EmailID1))
                {
                    using (MailMessage mm = new MailMessage(DevEmail, EmailID1))
                    {
                        //  MailBody
                        string cc = txtcc.Text;
                        mm.Subject = "New Ticket generate" + txtInitialTicket.Text;
                        mm.CC.Add(new MailAddress(cc));
                        string body = "Hello Mr/Miss." + UserEmpName + "<br />";

                        body += "You have been generate a new Ticket:  ";
                        body += "Project:" + ddlProject.SelectedItem.Text;
                        body += "Priority:" + ddlpriority.SelectedItem.Text;
                        body += "Department:" + ddldepart.SelectedItem.Text;
                        body += "Asssign Ticket:" + ddlassign.SelectedItem.Text;
                        body += "Service:" + txtservice.Text;
                        body += txtareabody.Text;

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
        private string generateOrderNo(string code, long id)
        {
            string oID = code;
            string space = "-";
            oID += space + id.ToString("000A0");

            return oID;
        }
        #endregion

        #region " Protected Functions "
        protected void bindStaff()
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
                    ddlassign.DataSource = ds.Tables[0];
                    ddlassign.DataTextField = "First_Name";
                    ddlassign.DataValueField = "Staff_ID";
                    ddlassign.DataBind();
                    ddlassign.Items.Insert(0, new ListItem("Select AssignTo", "0"));
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

        public DataTable ViewFileTicketDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                SqlCommand com = new SqlCommand("SP_ViewFileTicketDetails", con1);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Ticket_Number", txtInitialTicket.Text);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridTicketFile.DataSource = dt;
                    GridTicketFile.DataBind();


                    foreach (GridViewRow gridviedrow in GridTicketFile.Rows)
                    {

                        LinkButton btnDeleteExpensesFile = (LinkButton)gridviedrow.FindControl("btnDeleteExpensesFile");

                        btnDeleteExpensesFile.Visible = true;

                    }
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridTicketFile.DataSource = dt;
                    GridTicketFile.DataBind();

                }
            }
            return table;

        }

        #endregion

        #region " Public Function "
        public void Clear()
        {
            txtsubject.Text = string.Empty;
            txtname.Text = string.Empty;
            txtcc.Text = string.Empty;
            txtemail.Text = string.Empty;
            ddlcontact.ClearSelection();
            txtareabody.Text = string.Empty;
            ddldepart.ClearSelection();
            ddlProject.ClearSelection();
            ddlStatus.ClearSelection();
            ddlassign.ClearSelection();
            ddlpriority.ClearSelection();
            txtservice.Text = string.Empty;
            chkSendEmail.Checked = false;

        }
        public string GETReceiptINITIAL()
        {

            SqlConnection conn = new SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand("SP_GeReceriptInitial", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReceiptFor", "Ticket");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ReceiptFor = dt.Rows[0]["ReceiptFor"].ToString();
                Initial = dt.Rows[0]["Initial"].ToString();
                Size = dt.Rows[0]["size"].ToString();
                lblInitialNumber.Text = year + "-" + Day + ":";
                Initial = lblInitialNumber.Text + Initial;

            }
            return generateOrderNo(Initial, long.Parse(Size));
        }

        public void BindContactDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetticketContactName", conn);

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlcontact.DataSource = ds.Tables[0];
                    ddlcontact.DataTextField = "ContactName";
                    ddlcontact.DataValueField = "ID";
                    ddlcontact.DataBind();
                    ddlcontact.Items.Insert(0, new ListItem("Select Contact Name", "0"));
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

        public void BindDepartmentDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetticketContactdepartment", conn);

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddldepart.DataSource = ds.Tables[0];
                    ddldepart.DataTextField = "Dept_Name";
                    ddldepart.DataValueField = "Dept_ID";
                    ddldepart.DataBind();
                    ddldepart.Items.Insert(0, new ListItem("Select Department Name", "0"));
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

        public void BindDepartmentDetailsbyEmpID(int UserId)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetticketContactdepartmentbyEmpID", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddldepart.DataSource = ds.Tables[0];
                    ddldepart.DataTextField = "Dept_Name";
                    ddldepart.DataValueField = "Dept_ID";
                    ddldepart.DataBind();
                    ddldepart.Items.Insert(0, new ListItem("Select Department Name", "0"));
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

        public void BindStatusDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetStatusname", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BelongTo", "Ticket");
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlStatus.DataSource = ds.Tables[0];
                    ddlStatus.DataTextField = "ProgessStatus";
                    ddlStatus.DataValueField = "Status_ID";
                    ddlStatus.DataBind();
                    ddlStatus.Items.Insert(0, new ListItem("Select Status", "0"));
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
                            string ReceiptNumner = GETReceiptINITIAL();
                            txtInitialTicket.Text = ReceiptNumner;
                            BindContactDetails();
                            BindDepartmentDetails();
                            bindStaff();
                            BindStatusDetails();
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
                                string ReceiptNumner = GETReceiptINITIAL();
                                txtInitialTicket.Text = ReceiptNumner;
                                BindContactDetails();
                                BindDepartmentDetailsbyEmpID(UserId);
                                bindStaff();
                                BindStatusDetails();
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

        protected void btn_Saveticket_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string SendMail;
                    if (chkSendEmail.Checked == true)
                    {
                        SendMail = "True";
                        string staffid = ddlassign.SelectedItem.Value;
                        string Assigneesname = ddlassign.SelectedItem.Text;
                        GETStaffEmail(staffid);
                        SendEmail(Assigneesname);

                        string cust = ddlcontact.SelectedItem.Text;
                        SendEmailCustomer(cust);

                    }
                    else
                    {
                        SendMail = "False";
                    }

                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_SaveTicket", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Project_ID", ddlProject.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Project_Name", ddlProject.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Subject", txtsubject.Text);
                        cmd.Parameters.AddWithValue("@Department", ddldepart.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Department_ID", ddldepart.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Services", txtservice.Text);
                        cmd.Parameters.AddWithValue("@Priority", ddlpriority.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Raise_ID", ddlcontact.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Raise_By", ddlcontact.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@LoginType", Designation);
                        cmd.Parameters.AddWithValue("@AssignID", ddlassign.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@AssignTo", ddlassign.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Send_Email", SendMail);
                        cmd.Parameters.AddWithValue("@StatusName", ddlStatus.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Ticket_Body", txtareabody.Text);
                        cmd.Parameters.AddWithValue("@Status", "True");
                        cmd.Parameters.AddWithValue("@CC", txtcc.Text);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@Createby", UserName);
                        cmd.Parameters.AddWithValue("@Ticket_Number", txtInitialTicket.Text);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {
                            string save = "fgsave123q";
                            Response.Redirect("~/Ticket_Details.aspx?svd1=" + save + "", false);
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ticket Details Save Successfully!')", true);
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Ticket Details already Available";
                        }
                        Clear();
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

        protected void btnClear_Click1(object sender, EventArgs e)
        {
            Clear();
        }


        protected void ddlcontact_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetticketContactNamebydetails", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@id", ddlcontact.SelectedItem.Value);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtemail.Text = dt.Rows[0]["email"].ToString();
                    txtname.Text = dt.Rows[0]["ContactName"].ToString();
                    lblCustomerID.Text = dt.Rows[0]["Cust_ID"].ToString();
                }

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd1 = new SqlCommand("SP_GetProjectNameByCustID", con);
                cmd1.Connection = con;
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@CustID", lblCustomerID.Text);
                using (SqlDataAdapter sda1 = new SqlDataAdapter(cmd1))
                {
                    DataSet ds = new DataSet();
                    sda1.Fill(ds);
                    ddlProject.DataSource = ds.Tables[0];
                    ddlProject.DataTextField = "ProjectName";
                    ddlProject.DataValueField = "ID";
                    ddlProject.DataBind();
                    ddlProject.Items.Insert(0, new ListItem("Select Project", "0"));
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

        //============================File Upload=====================================================//


        protected void Btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload.PostedFile == null && txtInitialTicket.Text == "")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ticket Not In Draft!')", true);
                }
                else
                {
                    if (FileUpload.PostedFile.FileName.Length > 1)
                    {
                        string uploadDirectory = Server.MapPath("~/Ticket_File/");

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
                            SqlCommand cmd = new SqlCommand("SP_UploadTicketAttachmentFile", con);
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Tick_File", fileName);
                            cmd.Parameters.AddWithValue("@Extension", extention);
                            cmd.Parameters.AddWithValue("@Tick_Filepath", filePath);
                            cmd.Parameters.AddWithValue("@EmpID", UserId);
                            cmd.Parameters.AddWithValue("@Designation", Designation);
                            cmd.Parameters.AddWithValue("@Ticket_Number", txtInitialTicket.Text);
                            cmd.Parameters.AddWithValue("@Createby", UserName);
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            if (i < 0)
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Ticket File Uploaded Successfully";
                                ViewFileTicketDetails();
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Ticket File Not Uploaded Successfully";

                            }
                        }
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Choose File For Uploaded!')", true);
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



        protected void btnDeleteExpensesFile_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = GridTicketFile.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                string ExpensesID1 = ((Label)rows[rowindex].FindControl("lblTicketFileId1")).Text;

                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_DeleteFileTicket", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@ID", ExpensesID1);
                    com.Parameters.AddWithValue("@EmpID", UserId);
                    com.Parameters.AddWithValue("@Designation", Designation);
                    com.Parameters.AddWithValue("@Createby", UserName);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    con1.Open();
                    int i = com.ExecuteNonQuery();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Ticket File  Remove Successfully";
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Ticket File  Not Remove Available";
                    }

                    con1.Close();
                    ViewFileTicketDetails();
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