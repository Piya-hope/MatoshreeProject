
#region " Class Description ";


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
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
#endregion

namespace MatoshreeProject
{
    public partial class Schedule_Task : System.Web.UI.Page
    {
        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result, TaskName, chkMember, chkReminder;

        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        string DevEmail, DevPassword, DevPort, DevHost;
        string UserEmpName, Password, EmailID1, Designation1;

        int UserId;
        string Contractid;

        public string Today { get; private set; }
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

                    lblStaffEmail.Text = Convert.ToString(dt.Rows[0]["Email"].ToString());
                    lblStaffDesignation.Text = Convert.ToString(dt.Rows[0]["Role"].ToString());

                }
                con.Close();

            }

        }


        public void GetLOGINTIME(int UserID)
        {
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_GetStaffLogInTimeToday", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Staffid", UserID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lbllogtime.Text = Convert.ToString(dt.Rows[0]["LastLoginHours"].ToString()) +" Hours"; ;
                }
                else if (dt.Rows.Count == 0)
                {
                    lbllogtime.Text = "0:0" +" Hours";
                }
                else
                {
                    lbllogtime.Text = "0:0" + " Hours"; 
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
                        mm.Subject = "Task Assigned to You Reminder" + lblTaskName.Text;

                        string body = "Hello Mr/Miss." + UserEmpName + "<br />";

                        body += "Reminder,You have been assigned a task:  ";
                        body += "Name :  " + lblTaskName.Text;
                        body += "Notified date : " + txtDateNotified.Text;
                        body += "Due date : " + txtDueDate.Text;
                        body += "Priority : " + ddlPriority.SelectedItem.Text;
                        body += "Status : " + lblstatusname.Text;
                        body += "<br /><br />Your Designation is: " + Designation1 + "";
                        body += "<br /><br />Your Login Id  is: " + EmailID1 + "";
                        body += "<br /><br />Your LogIn Url given below";

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


        public void Clear()
        {
            txtStartDtae.Text = string.Empty;
            ddlPriority.SelectedIndex = 0;
            txtDueDate.Text = string.Empty;
            ddlMember.SelectedIndex = 0;
            txtareaNote1.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtendtime.Text = string.Empty;
            txtDateNotified.Text = string.Empty;
            txtDescription.Text = string.Empty;
            ddlreminderMember.SelectedIndex = 0;
            chksetRemainderforEmail.Checked = false;
            //txtcomment.Text = string.Empty;
        }
        // -------------------MAIN GRIDVIEW------------------
        public void GetStaffnamebytaskname(string task)
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

                ddlMember.DataSource = table;
                ddlMember.DataTextField = "AssignTo";
                ddlMember.DataValueField = "AssignTo";
                ddlMember.DataBind();
                ddlMember.Items.Insert(0, new ListItem("Select Member", "0"));
            }

        }
        public void GetTaskByTaskName()
        {
            try
            {

                TaskName = HttpUtility.UrlDecode(Request.QueryString["task"]);
                lblTaskNameWGV.Text = TaskName;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetTaskDataByName", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@Subject", lblTaskNameWGV.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        DateTime s1 = Convert.ToDateTime(dt.Rows[0]["Start_Date"].ToString());
                        DateTime e1 = Convert.ToDateTime(dt.Rows[0]["Due_Date"].ToString());

                        string StartDate1 = s1.ToString("yyyy-MM-dd HH:mm tt");
                        string Enddate1 = e1.ToString("yyyy-MM-dd HH:mm tt");

                        txtStartDtae.Attributes["value"] = DateTime.Parse(StartDate1.ToString()).ToString("yyyy-MM-dd HH:mm tt");
                        txtDueDate.Attributes["value"] = DateTime.Parse(Enddate1.ToString()).ToString("yyyy-MM-dd HH:mm tt");
                        ddlPriority.SelectedItem.Text = dt.Rows[0]["Priority"].ToString();
                        BTNBIIL1.InnerText = dt.Rows[0]["Billable"].ToString();
                        txtHourly_Rate.Text = dt.Rows[0]["Hourly_Rate"].ToString();
                        lblRelatedTo.Text = dt.Rows[0]["RelatedToCast"].ToString();
                        ddlProcess.SelectedItem.Text = dt.Rows[0]["TaskStatus"].ToString();
                        lblstatusname.Text = dt.Rows[0]["TaskStatus"].ToString();
                        lblTaskName.Text = dt.Rows[0]["Subject"].ToString();
                        lblCreateBy.Text = dt.Rows[0]["CreateBy"].ToString();
                        lblCreateTim.Text = dt.Rows[0]["Createdate"].ToString();
                        //ddlMember.SelectedItem.Text = dt.Rows[0]["AssignTo"].ToString();
                        txtTag.Text = dt.Rows[0]["Tag"].ToString();
                        lblSceduletaskTime.Text = dt.Rows[0]["FileName"].ToString();
                        lblassigntaskby.Text = dt.Rows[0]["CreateBy"].ToString();
                        lblSceduletask.Text = dt.Rows[0]["StartTimer"].ToString();

                        if (lblSceduletask.Text =="True")
                        {
                            Linkbtntimer.CssClass = "btn btn-sm btn-success";
                            Linkbtntimer.Enabled = false;
                            
                        }
                        else
                        {
                            Linkbtntimer.CssClass = "btn btn-sm btn-light";
                            Linkbtntimer.Enabled = true;
                        }

                        if (lblstatusname.Text == "Mark as Not Started")
                        {
                            lblstatusname.CssClass = "btn btn-sm btn-danger";
                            LinkbtnCheck.CssClass = "btn btn-info btn-sm";
                            Linkbtntimer.CssClass = "btn btn-sm btn-danger";
                        }
                        else if (lblstatusname.Text == "Mark as Started")
                        {

                            lblstatusname.CssClass = "btn btn-sm btn-primary";
                            LinkbtnCheck.CssClass = "btn btn-info btn-sm";
                            Linkbtntimer.CssClass = "btn btn-sm btn-success";
                        }
                        else if (lblstatusname.Text == "Mark as Testing")
                        {
                            lblstatusname.CssClass = "btn btn-sm btn-warning";
                            LinkbtnCheck.CssClass = "btn btn-primary btn-sm";
                        }
                        else if (lblstatusname.Text == "In Progress")
                        {
                            lblstatusname.CssClass = "btn btn-sm btn-info";
                            LinkbtnCheck.CssClass = "btn btn-info btn-sm";
                        }
                        else if (lblstatusname.Text == "Mark as Awaiting Feedback")
                        {
                            lblstatusname.CssClass = "btn btn-sm btn-light";
                            LinkbtnCheck.CssClass = "btn btn-info btn-sm";
                        }
                        else if (lblstatusname.Text == "Mark as Complete")
                        {
                            lblstatusname.CssClass = "btn btn-sm btn-success";
                            LinkbtnCheck.CssClass = "btn btn-success btn-sm";
                        }
                    }
                    GetStaffnamebytaskname(lblTaskNameWGV.Text);
                    ViewSheduleTaskDetails();

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
                    command.Parameters.AddWithValue("@SubModule", "TASKS");
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
                            GetTaskByTaskName();
                            BindGVCheckListItem();
                            BindGVComment();
                            bindReminderMember();
                            bindBulletlistAssigness();
                            bindBulletlistFollower();
                            GetReminderByTaskName();

                            //if (Create == "True")
                            //{
                            //    addnew.Visible = true;
                            //}
                            //else
                            //{
                            //    addnew.Visible = false;
                            //}

                            //if (Edit == "True")
                            //{

                            //    GridTender.Columns[10].Visible = true;
                            //}
                            //else
                            //{

                            //    GridTender.Columns[10].Visible = false;
                            //}

                            //if (Delete == "True")
                            //{

                            //    GridTender.Columns[11].Visible = true;
                            //}
                            //else
                            //{

                            //    GridTender.Columns[11].Visible = false;
                            //}
                        }
                        else if (View == "True")
                        {
                            GetTaskByTaskName();
                            BindGVCheckListItem();
                            BindGVComment();
                            bindReminderMember();
                            bindBulletlistAssigness();
                            bindBulletlistFollower();
                            GetReminderByTaskName();

                            //if (Create == "True")
                            //{
                            //    addnew.Visible = true;
                            //}
                            //else
                            //{
                            //    addnew.Visible = false;
                            //}

                            //if (Edit == "True")
                            //{

                            //    GridTender.Columns[10].Visible = true;
                            //}
                            //else
                            //{

                            //    GridTender.Columns[10].Visible = false;
                            //}

                            //if (Delete == "True")
                            //{

                            //    GridTender.Columns[11].Visible = true;
                            //}
                            //else
                            //{

                            //    GridTender.Columns[11].Visible = false;
                            //}
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

        public void GetMessageFromModules()
        {
            try
            {
                string MSGdata = HttpUtility.UrlDecode(Request.QueryString["svd1"]);
                string EdidDATA = HttpUtility.UrlDecode(Request.QueryString["edit1"]);
                if (MSGdata == "fgsave123q" && EdidDATA == null)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Task Details Save Successfully";
                }
                else if (EdidDATA == "xcvfedit" && MSGdata == null)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Task Details Edit Successfully";
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
        #endregion

        #region "Event "
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
                          
                            GetTaskByTaskName();
                            BindGVCheckListItem();
                            BindGVComment();
                            bindReminderMember();
                            bindBulletlistAssigness();
                            bindBulletlistFollower();
                            GetReminderByTaskName();
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
                                GetLOGINTIME(UserId);
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

        //---------linkcheckbtn event--------------------------
        protected void LinkbtnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    if (LinkbtnCheck.CssClass.Contains("btn btn-success btn-sm"))
                    {
                        LinkbtnCheck.CssClass = "btn btn-sm btn-primary";

                        using (SqlConnection UserCon = new SqlConnection(strconnect))
                        {
                            SqlConnection con = new SqlConnection(strconnect);
                            SqlCommand cmd = new SqlCommand("SP_updateTaskStatus", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TaskStatus", "In Progress");
                            cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            con.Close();
                            if (i > 0)
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Task In Progress Successfully";
                                GetTaskByTaskName();
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Task Status Not Change Successfully";
                            }
                        }
                    }
                    else
                    {

                        LinkbtnCheck.CssClass = "btn btn-success btn-sm";


                        using (SqlConnection UserCon = new SqlConnection(strconnect))
                        {
                            SqlConnection con = new SqlConnection(strconnect);
                            SqlCommand cmd = new SqlCommand("SP_updateTaskStatus", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TaskStatus", "Mark as Complete");
                            cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            con.Close();
                            if (i > 0)
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Task Mark as Complete  Successfully";
                                GetTaskByTaskName();
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Task Status Not Change Successfully";
                            }
                        }
                    }
                }
                else if (RoleType == Designation)
                {
                    if (LinkbtnCheck.CssClass.Contains("btn btn-success btn-sm"))
                    {
                        LinkbtnCheck.CssClass = "btn btn-sm btn-primary";

                        using (SqlConnection UserCon = new SqlConnection(strconnect))
                        {
                            SqlConnection con = new SqlConnection(strconnect);
                            SqlCommand cmd = new SqlCommand("SP_updateTaskStatusbyEmpID", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TaskStatus", "In Progress");
                            cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                            cmd.Parameters.AddWithValue("@EmpID", UserId);
                            cmd.Parameters.AddWithValue("@Createby", UserName);
                            cmd.Parameters.AddWithValue("@Designation", Designation);
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            con.Close();
                            if (i > 0)
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Task In Progress Successfully";
                                GetTaskByTaskName();
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Task Status Not Change Successfully";
                            }
                        }
                    }
                    else
                    {

                        LinkbtnCheck.CssClass = "btn btn-success btn-sm";

                        using (SqlConnection UserCon = new SqlConnection(strconnect))
                        {
                            SqlConnection con = new SqlConnection(strconnect);
                            SqlCommand cmd = new SqlCommand("SP_updateTaskStatusbyEmpID", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TaskStatus", "Mark as Complete");
                            cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                            cmd.Parameters.AddWithValue("@EmpID", UserId);
                            cmd.Parameters.AddWithValue("@Createby", UserName);
                            cmd.Parameters.AddWithValue("@Designation", Designation);
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            con.Close();
                            if (i > 0)
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Task Mark as Complete  Successfully";
                                GetTaskByTaskName();
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Task Status Not Change Successfully";
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

        //--------DDL FOLLOWERS--------------------------------
        protected void ddlDevlopername_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlDevlopername = (DropDownList)sender;

            GridViewRow footerRow = (GridViewRow)ddlDevlopername.NamingContainer;
            DropDownList DevMember = (DropDownList)footerRow.FindControl("ddlDevlopername");
            Label DevMemberName = (Label)footerRow.FindControl("ddldevmsg");
            string ms = DevMember.SelectedItem.Text;

            DevMemberName.Text = ms;

        }

        //-------------------------SEDULE--------------------------
        public DataTable ViewSheduleTaskDetails()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_ViewSheduleTaskStaff", UserCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    adpt.Fill(dt);
                    GridSheduleTask.DataSource = dt;
                    GridSheduleTask.DataBind();
                }
                return dt;
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
                return dt;
            }

        }

        //SAVE SEDULE---------------------------------------------
        protected void ChBoxAllMember_CheckedChanged(object sender, EventArgs e)
        {


            bool checkMember = ChBoxAllMember.Checked;

            if (checkMember == true)
            {
                lblmember.Visible = false;
                ddlMember.Visible = false;
            }
            else
            {
                lblmember.Visible = true;
                ddlMember.Visible = true;
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                try
                {
                    string member;
                    if (ChBoxAllMember.Checked == false)
                    {
                        member = "false";
                    }
                    else
                    {
                        member = "true";
                    }
                    if (member == "false" && ddlMember.SelectedItem.Text == "Select Member")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Select  Member for Task Time Schedule ')", true);

                    }
                    else if (member == "true")//All member
                    {
                        using (SqlConnection UserCon = new SqlConnection(strconnect))
                        {
                            SqlCommand cmd = new SqlCommand("SP_UpdateAllMembersheduleTaskDetails", UserCon);
                            cmd.CommandType = CommandType.StoredProcedure;
                            DateTime startDate = Convert.ToDateTime(txtStartDate.Text);
                            DateTime stopDate = Convert.ToDateTime(txtendtime.Text);
                            cmd.Parameters.AddWithValue("@StartTaskTime", Convert.ToDateTime(txtStartDate.Text));
                            cmd.Parameters.AddWithValue("@StopTaskTime", Convert.ToDateTime(txtendtime.Text));
                            cmd.Parameters.AddWithValue("@Note", txtareaNote1.Text);
                            cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                            cmd.Parameters.AddWithValue("@EmpID", UserId);
                            cmd.Parameters.AddWithValue("@Designation", Designation);
                            cmd.Parameters.AddWithValue("@CreateBy", UserName);
                            UserCon.Open();
                            int i = cmd.ExecuteNonQuery();
                            UserCon.Close();
                            if (i < 0)
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Task Schedule Save Successfully";
                                ViewSheduleTaskDetails();
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Task Schedule not Update Successfully";

                            }
                            Clear();
                        }
                    }
                    else//ddl select 
                    {
                        using (SqlConnection UserCon = new SqlConnection(strconnect))
                        {
                            SqlConnection con = new SqlConnection(strconnect);
                            SqlCommand cmd = new SqlCommand("SP_UpdatesheduleTaskDetails", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            DateTime startDate = Convert.ToDateTime(txtStartDate.Text);
                            DateTime stopDate = Convert.ToDateTime(txtendtime.Text);
                            cmd.Parameters.AddWithValue("@StartTaskTime", startDate);
                            cmd.Parameters.AddWithValue("@StopTaskTime", stopDate);
                            cmd.Parameters.AddWithValue("@AssignTo", ddlMember.SelectedItem.Text);
                            cmd.Parameters.AddWithValue("@Note", txtareaNote1.Text);
                            cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                            cmd.Parameters.AddWithValue("@EmpID", UserId);
                            cmd.Parameters.AddWithValue("@Designation", Designation);
                            cmd.Parameters.AddWithValue("@CreateBy", UserName);
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            con.Close();
                            if (i < 0)
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Task Schedule Save Successfully";
                                ViewSheduleTaskDetails();
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Task Schedule not Update Successfully";

                            }
                            Clear();
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
        }

        //---------------------SAVE TIMESEET--------------------
        protected void LinkbtnTimesheet_Click(object sender, EventArgs e)
        {
            if (Timesheet.Visible == false)
            {
                Timesheet.Visible = true;
            }

            else
            {
                Timesheet.Visible = false;
            }
        }

        //--------CHECKLIST_iTEM-----------------------------
        protected void btnchklistitem_Click(object sender, EventArgs e)
        {

            if (chklistitem.Visible == false)
            {
                chklistitem.Visible = true;
                BindGVCheckListItem();
            }
            else
            {
                chklistitem.Visible = false;
            }
        }

        public void BindGVCheckListItem()
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewCheckListItem_Task", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridViewCheckListItemTask.DataSource = dt;
                    GridViewCheckListItemTask.DataBind();
                    GridViewCheckListItemTask.Visible = true;
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridViewCheckListItemTask.DataSource = dt;
                    GridViewCheckListItemTask.DataBind();
                    int totalcolums = GridViewCheckListItemTask.Rows[0].Cells.Count;

                    GridViewCheckListItemTask.Visible = false;
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

        ///------CECKLIST ROWBINDING METHOD--------------------
        protected void GridViewCheckListItemTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DropDownList ddlIdType = (DropDownList)e.Row.FindControl("ddlDevlopername");

                string str;
                DataTable table = new DataTable();
                DataRow dtrow;
                DataColumn dataColumn = new DataColumn();
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand sqlCommand = new SqlCommand("SP_GetDevlopersName", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                    SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                    ad.Fill(table);

                    if (table.Rows.Count > 0)//commam separator
                    {
                        str = table.Rows[0]["Follower"].ToString();

                        string[] s2 = str.Split(',');
                        int cnt = s2.Length;
                        table.Clear();

                        foreach (string s3 in s2)
                        {
                            table.Rows.Add(s3);
                        }
                    }
                    ddlIdType.DataSource = table;
                    ddlIdType.DataTextField = "Follower";
                    ddlIdType.DataValueField = "TaskName";
                    ddlIdType.DataBind();
                    ddlIdType.Items.Insert(0, new ListItem("Select Member"));

                }
            }
        }

        //cecklistItem save

        protected void btnchekItemAdd_Click(object sender, EventArgs e)
        {
            try
            {

                string txtcheckItem1, ddldevmember;
                Boolean ChkBox;

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_UpdateChecklistItemTask", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Checklist_Item", txthide.Text);
                    cmd.Parameters.AddWithValue("@CheckStatus", "1");
                    cmd.Parameters.AddWithValue("@AssignTo", lblnameAssignees.Text);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();

                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task check Item Save Successfully";
                        BindGVCheckListItem();
                        GridViewCheckListItemTask.Visible = true;
                        txthide.Text = string.Empty;

                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task check Item not Update Successfully";
                        BindGVCheckListItem();
                        GridViewCheckListItemTask.Visible = false;
                    }
                    Clear();
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
        protected void txtcheckItem1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string txtcheckItem1, ddldevmember;
                Boolean ChkBox;
                var rows = GridViewCheckListItemTask.Rows;
                TextBox btn = (TextBox)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ChkBox = (GridViewCheckListItemTask.FooterRow.FindControl("ChBoxB1") as CheckBox).Checked;
                txtcheckItem1 = (GridViewCheckListItemTask.FooterRow.FindControl("txtcheckItem1") as TextBox).Text;
                ddldevmember = (GridViewCheckListItemTask.FooterRow.FindControl("ddlDevlopername") as DropDownList).SelectedItem.Text;

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_UpdateChecklistItemTask", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Checklist_Item", txtcheckItem1);
                    cmd.Parameters.AddWithValue("@CheckStatus", ChkBox);
                    cmd.Parameters.AddWithValue("@AssignTo", ddldevmember);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();

                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task check Item Save Successfully";
                        BindGVCheckListItem();


                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task check Item not Update Successfully";
                        BindGVCheckListItem();
                    }
                    Clear();
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

        protected void ddlMerbersTaskCheck_SelectedIndexChanged(object sender, EventArgs e)
        {


            string ms = ddlMerbersTaskCheck.SelectedItem.Text;

            lblnameAssignees.Text = ms;
        }

        ///-----------------------------------checklist Delete Operation---------------------------------
        protected void LinkButtonDelete_Click2(object sender, EventArgs e)
        {
            try
            {
                string CID;
                var rows = GridViewCheckListItemTask.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                CID = ((Label)rows[rowindex].FindControl("lblID")).Text;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {

                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteCheckitemListTask", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CL_ID", CID);
                    cmd.Parameters.AddWithValue("@CreateBy", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();

                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task check Item Delete Successfully";
                        BindGVCheckListItem();


                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task check Item not Delete Successfully";
                        BindGVCheckListItem();
                    }
                    Clear();
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

        //---------DESCRIPTION--------------------------------
        protected void btndescriptionedit_Click(object sender, EventArgs e)
        {
            if (txtareaDesc.Visible == false)
            {
                txtareaDesc.Visible = true;

            }
            else
            {
                txtareaDesc.Visible = false;

            }
        }

        // Description--- SAVE /UPDATE-----------------------------------------
        protected void txtareaDesc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_updateDescriptionTaskStaff", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Description", txtareaDesc.Text);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@CreateBy", UserName);
                    cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                    cmd.Parameters.AddWithValue("@AssignTo", ddlMember.SelectedItem.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Description Save Successfully";

                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Description not Save Successfully";

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

        //--------COMMENT-------------------------------------
        public void BindGVComment()
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewCommentTask", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@commentFor", lblTaskNameWGV.Text);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridComment.DataSource = dt;
                    GridComment.DataBind();
                    GridComment.Visible = true;
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridComment.DataSource = dt;
                    GridComment.DataBind();
                    GridComment.Visible = false;
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

        protected void Lbtncomment_Click(object sender, EventArgs e)
        {

            if (Commentshide.Visible == false)
            {
                Commentshide.Visible = true;
                BindGVComment();
            }
            else
            {
                Commentshide.Visible = false;
            }
        }

        //------Comment SAVE AND UPDATE-------------------------------------------
        protected void btnaddcomnt_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_updateCommentTaskStaff", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@comment", txttypewriter1.Text);
                    cmd.Parameters.AddWithValue("@user_id", UserId);
                    cmd.Parameters.AddWithValue("@post_id", UserId);
                    cmd.Parameters.AddWithValue("@commentmodulebelong", lblTaskName.Text);
                    cmd.Parameters.AddWithValue("@commentFor", lblTaskNameWGV.Text);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Comment Save Successfully";
                        txttypewriter1.Text = string.Empty;
                        Commentshide.Visible = true;
                        BindGVComment();

                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Comment not Save Successfully";

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

        protected void GridComment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);

                int CommentID = Convert.ToInt32(GridComment.DataKeys[e.RowIndex].Values["id"].ToString());


                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    TextBox txtcomment = GridComment.Rows[e.RowIndex].FindControl("txtcomment") as TextBox;
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_updateComment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", CommentID);
                    cmd.Parameters.AddWithValue("@comment", txtcomment.Text);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@commentFor", lblTaskNameWGV.Text);
                    cmd.Parameters.AddWithValue("@user_id", UserId);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task comment update Successfully";
                        GridComment.EditIndex = -1;
                        BindGVComment();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Comment not update Successfully";
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

        protected void GridComment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridComment.EditIndex = e.NewEditIndex;
            BindGVComment();
        }

        protected void GridComment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            GridComment.EditIndex = -1;
            BindGVComment();
        }

        protected void GridComment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int CommentID = Convert.ToInt32(GridComment.DataKeys[e.RowIndex].Values["id"].ToString());
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {

                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteCommentTask", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", CommentID);
                    cmd.Parameters.AddWithValue("@commentFor", lblTaskNameWGV.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();

                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Comment Delete Successfully";
                        BindGVComment();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Comment not Delete Successfully";

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

        protected void GridComment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        //---------------------------4DIV-----------------------------------------------------

        //-----------------------------------status------------------------------------------------
        protected void ddlProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_updateTaskStatus", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaskStatus", ddlProcess.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Status Change Successfully";
                        GetTaskByTaskName();
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

        //-------------------------------------stratDate--------------------------------
        protected void txtStartDtae_TextChanged1(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_updateTaskStratDate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DateTime startDate = Convert.ToDateTime(txtStartDtae.Text);
                    cmd.Parameters.AddWithValue("@Start_Date", Convert.ToDateTime(txtStartDtae.Text));
                    cmd.Parameters.AddWithValue("@Subject", lblTaskNameWGV.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Start Date Change Successfully";
                        GetTaskByTaskName();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Start not Change Successfully";

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

        //--------------------------------Duedate----------------------------
        protected void txtDueDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_updateTaskDueDate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DateTime DueDate = Convert.ToDateTime(txtDueDate.Text);
                    cmd.Parameters.AddWithValue("@Due_Date", Convert.ToDateTime(txtDueDate.Text));
                    cmd.Parameters.AddWithValue("@Subject", lblTaskNameWGV.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Due Date Change Successfully";
                        GetTaskByTaskName();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Due Date not Change Successfully";

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

        //----------------------------Priority------------------------------------
        protected void ddlPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_updateTaskPriority", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Priority", ddlPriority.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Subject", lblTaskNameWGV.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Priority Change Successfully";
                        GetTaskByTaskName();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Priority not Change Successfully";

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

        //---------------------------Billable------------------------------------
        protected void lnkbtnbillable_Click(object sender, EventArgs e)
        {
            string billable = lnkbtnbillable.Text;
            try
            {
                if (BillableAmount1.Visible == false)
                {
                    BillableAmount1.Visible = true;
                }

                else
                {
                    BillableAmount1.Visible = false;
                }
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_updateTaskBillable", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Billable", billable);
                    cmd.Parameters.AddWithValue("@Subject", lblTaskNameWGV.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Billable Change Successfully";
                        GetTaskByTaskName();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Billable not Change Successfully";

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


        protected void lnkbtnNotbillable_Click(object sender, EventArgs e)
        {
            string notbillable = lnkbtnNotbillable.Text;
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_updateTaskBillable", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Billable", notbillable);
                    cmd.Parameters.AddWithValue("@Subject", lblTaskNameWGV.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Billable Change Successfully";
                        GetTaskByTaskName();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Billable not Change Successfully";

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

        //------------------------------Hourly------------------------------
        protected void txtHourly_Rate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_updateTaskHourly_Rate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Hourly_Rate", txtHourly_Rate.Text);
                    cmd.Parameters.AddWithValue("@Subject", lblTaskNameWGV.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Hourly Rate Change Successfully";
                        GetTaskByTaskName();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Hourly Rate not Change Successfully";
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

        //------------------Tag---------------------------------------
        protected void txtTag_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_updateTaskTag", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Tag", txtTag.Text);
                    cmd.Parameters.AddWithValue("@Subject", lblTaskNameWGV.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Tag Change Successfully";
                        GetTaskByTaskName();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Tag not Change Successfully";
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


        protected void lnkbtnattachfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EditTaskDetails.aspx?task=", false);
        }

        protected void lnkbtnviewascustmer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EditTaskDetails.aspx?task=", false);

        }

        //----------------file-----------------------------------------
        protected void Linkupload_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (File1.PostedFile != null)
                    {
                        string uploadDirectory = Server.MapPath("~/TaskFile/");

                        if (!Directory.Exists(uploadDirectory))
                        {
                            Directory.CreateDirectory(uploadDirectory);
                        }

                        string fileName = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                        string filePath = System.IO.Path.Combine(uploadDirectory, fileName);
                        File1.PostedFile.SaveAs(filePath);

                        SqlConnection UserCon = new SqlConnection(strconnect);
                        SqlCommand UserCommand = new SqlCommand("SP_UpdateTaskFile", UserCon);
                        UserCommand.Connection = UserCon;
                        UserCommand.CommandType = CommandType.StoredProcedure;
                        UserCommand.Parameters.AddWithValue("@FileName", fileName);
                        UserCommand.Parameters.AddWithValue("@FilePath", filePath);
                        UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                        UserCommand.Parameters.AddWithValue("@Designation", Designation);
                        UserCommand.Parameters.AddWithValue("@CreateBy", UserName);
                        UserCommand.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);

                        UserCon.Open();
                        int i = UserCommand.ExecuteNonQuery();
                        UserCon.Close();
                        if (i < 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Task File Update Successfully";

                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Task File  not Update Successfully";

                        }

                    }
                    else
                    {

                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Choose File For Uploaded!')", true);
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

        }


        //-----------------------Reminder---------------------------------------------------------------------//
        public void GetReminderByTaskName()
        {
            try
            {
                TaskName = HttpUtility.UrlDecode(Request.QueryString["task"]);
                lblTaskNameWGV.Text = TaskName;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetTaskReminderaByTaskName", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        DateTime notifyDate = Convert.ToDateTime(dt.Rows[0]["NotifyDate"]);
                        txtDateNotified.Text = notifyDate.ToString("yyyy-MM-ddTHH:mm");
                        ddlreminderMember.SelectedItem.Text = dt.Rows[0]["SetToReminder"].ToString();
                        lblremMember.Text = dt.Rows[0]["SetToReminder"].ToString();
                        txtDescription.Text = dt.Rows[0]["Description"].ToString();
                        lblremdate.Text = dt.Rows[0]["NotifyDate"].ToString();
                        if (chksetRemainderforEmail.Checked)
                        {
                            chkReminder = "true";
                        }
                        else
                        {
                            chkReminder = "false";
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

        protected void bindReminderMember()
        {
            string str;
            DataTable table = new DataTable();
            DataRow dtrow;
            DataColumn dataColumn = new DataColumn();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_GetReminderMemberbyName", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);

                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                ad.Fill(table);

                ddlreminderMember.DataSource = table;
                ddlreminderMember.DataTextField = "AssignTo";
                ddlreminderMember.DataValueField = "TaskName";
                ddlreminderMember.DataBind();
                ddlreminderMember.Items.Insert(0, new ListItem("Select Member", "0"));
            }

        }

        protected void btnCreateRemainder_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDateNotified.Text != "" && ddlreminderMember.SelectedIndex != 0)
                {
                    UserId = Convert.ToInt32(Session["UserID"]);
                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {
                        if (chksetRemainderforEmail.Checked == true)
                        {
                            chkReminder = "true";
                            string EmpNAME = ddlreminderMember.SelectedItem.Text;
                            GETStaffEmail(EmpNAME);
                            SendEmail(EmpNAME);
                        }
                        else
                        {
                            chkReminder = "false";
                        }

                        SqlConnection con = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_updateReminderTaskStaff", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        DateTime dateNotifiedDate = Convert.ToDateTime(txtDateNotified.Text);
                        cmd.Parameters.AddWithValue("@NotifyDate", Convert.ToDateTime(txtDateNotified.Text));
                        cmd.Parameters.AddWithValue("@SetToReminder", ddlreminderMember.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@SendMail", chkReminder);
                        cmd.Parameters.AddWithValue("@Createby", UserName);
                        cmd.Parameters.AddWithValue("@R_ID", lblRID.Text);
                        cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i < 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Task Reminder Save Successfully";
                            bindReminderMember();
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Task not Update Successfully";
                        }
                        Clear();
                    }
                }
                else
                {

                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Choose Reminder Date and Member!')", true);

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
            craeteButton.Visible = true;
            txtDateNotified.Text = lblremdate.Text;
            ddlreminderMember.SelectedItem.Text = lblremMember.Text;
            string Todaydate = Convert.ToString(DateTime.Today);
            txtDateNotified.Attributes["value"] = DateTime.Parse(Todaydate.ToString()).ToString("dd-MM-yyyy HH:mm");
        }

        protected void btnDeleteTask_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {

                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteReminderbyTaskname", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Reminder Delete Successfully";
                        bindReminderMember();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task not Delete Successfully";
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


        ///----------------Assign--------------------------------------------------
        protected void bindBulletlistAssigness()
        {
            string str;
            DataTable table = new DataTable();
            DataRow dtrow;
            DataColumn dataColumn = new DataColumn();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_GetTaskAssignessbyName", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                ad.Fill(table);

                //--------------bulletlist-----------------------//
                BulletedListAsssigness.DataSource = table;
                BulletedListAsssigness.DataTextField = "AssignTo";
                BulletedListAsssigness.DataValueField = "TaskName";
                BulletedListAsssigness.DataBind();


            }

        }

        protected void bindBulletlistFollower()
        {
            string str1;
            DataTable table1 = new DataTable();
            DataTable table12 = new DataTable();
            DataRow dtrow1;
            DataColumn dataColumn = new DataColumn();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_GetTaskBulletlistFollowersName", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                ad.Fill(table1);
                if (table1.Rows.Count > 0)
                {
                    str1 = table1.Rows[0]["Follower"].ToString();

                    string[] s21 = str1.Split(',');
                    table12.Columns.Add("Follower");

                    foreach (string s31 in s21)
                    {
                        table12.Rows.Add(s31);
                    }
                }
                else
                {
                    string s31 = "Not Found";
                    table12.Columns.Add("Follower");
                    table12.Rows.Add(s31);
                }

                BulletedListfollwers.DataSource = table12;
                BulletedListfollwers.DataTextField = "Follower";
                BulletedListfollwers.DataValueField = "Follower";
                BulletedListfollwers.DataBind();

                ddlMerbersTaskCheck.DataSource = table12;
                ddlMerbersTaskCheck.DataTextField = "Follower";
                ddlMerbersTaskCheck.DataValueField = "Follower";
                ddlMerbersTaskCheck.DataBind();
                ddlMerbersTaskCheck.Items.Insert(0, new ListItem("Select Member", "0"));

            }

        }

        protected void Linkbtntimer_Click(object sender, EventArgs e)
        {
            //StartTimer For Task
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();

                if (Session["LoginType"].ToString() == "Administrator")
                {
                    UserId = Convert.ToInt32(Session["UserID"]);
                    UserName = Session["UserName"].ToString();
                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {
                        SqlConnection con = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_StartTaskTimer", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TaskStatus", "Mark as Started");
                        cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                        cmd.Parameters.AddWithValue("@Timer", "True");
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i > 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Task Timer Start Successfully";
                            Linkbtntimer.CssClass = "btn btn-sm btn-success";
                           // Linkbtntimer.Enabled = false;
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Task Timer Not Start Successfully";
                            Linkbtntimer.CssClass = "btn btn-sm btn-light";
                           // Linkbtntimer.Enabled = true;
                        }
                        GetTaskByTaskName();
                    }
                }
                else if (RoleType == Designation)
                {
                    UserId = Convert.ToInt32(Session["UserID"]);
                    UserName = Session["UserName"].ToString();
                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {
                        SqlConnection con = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_StartTaskTimerEmpID", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TaskStatus", "Mark as Started");
                        cmd.Parameters.AddWithValue("@TaskName", lblTaskNameWGV.Text);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Timer", "True");
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i <= 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Task Timer Start Successfully";
                            Linkbtntimer.CssClass = "btn btn-sm btn-success";
                            Linkbtntimer.Enabled = false;
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Task Timer Not Start Successfully";
                            Linkbtntimer.CssClass = "btn btn-sm btn-light";
                            Linkbtntimer.Enabled = true;
                        }
                        GetTaskByTaskName();
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

        #endregion
    }
}