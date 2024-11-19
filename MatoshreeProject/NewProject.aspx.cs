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
using System.Text;
using System.Net;
using System.Net.Mail;
#endregion

namespace MatoshreeProject
{
    public partial class NewProject : System.Web.UI.Page
    {
        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr, drpm;
        int Result, Result1, Resultpm;
        string result, result1, resultpm;

        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;

        string DevEmail, DevPassword, DevPort, DevHost;
        string UserEmpName, Password, EmailID1, Designation1, Fname, Lname;
        string StaffEmail1;
        #endregion

        #region " Constructor "


        #endregion

        #region " Private Variables "


        #endregion

        #region " Shared Variables "


        #endregion

        #region " Public Variables "
        int Id;
        #endregion

        #region " Public Properties "


        #endregion

        #region " Private Functions "


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
                    StaffEmail1 = Convert.ToString(dt.Rows[0]["Email"].ToString());
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
                        mm.Subject = "You Allocated  New Project";
                        string body = "Hello Mr/Miss." + UserEmpName + "<br />";
                        if (txtDescription.Text == "")
                        {
                            body += "Congratulations on being part of the team! The whole Project" + txtProjectName.Text + " team welcomes you, and we look forward to a successful team with you! Welcome aboard!";
                            body += "<br /><br />Your Designation is: " + Designation1 + "";
                            body += "<br /><br />Your Login Id  is: " + EmailID1 + "";
                            body += "<br /><br />Your LogIn Url given below";
                        }
                        else
                        {
                            body += "Congratulations on being part of the team! The whole Project" + txtProjectName.Text + "team welcomes you, and we look forward to a successful team with you! Welcome aboard!";
                            body += "<br /><br />" + txtDescription.Text + "";
                            body += "<br /><br />Your Designation is: " + Designation1 + "";
                            body += "<br /><br />Your Login Id  is: " + EmailID1 + "";
                            body += "<br /><br />Your LogIn Url given below";
                        }

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

        public void ClearAll()
        {
            try
            {
                txtDeadline.Text = string.Empty;
                txtDescription.Text = string.Empty;
                txtProjectName.Text = string.Empty;
                txtStartDate.Text = string.Empty;
                ddlBillingType.SelectedIndex = 0;
                ddlCustomer.SelectedIndex = 0;
                // ChkListProjectMembers.SelectedIndex = 0;
                ListProjectMembers.SelectedIndex = 0;
                ddlStatus.SelectedIndex = 0;

                ddlBilingState.SelectedIndex = -1;
                ddlBillingdistrict.SelectedIndex = -1;
                ddlBillingcity.SelectedIndex = -1;
                ddlCountryBilling.SelectedIndex = -1;

                txtflatBilling.Text = string.Empty;
                txtStreetBilling.Text = string.Empty;
                txtPinBilling.Text = string.Empty;

                lblStaffEmail.Text = string.Empty;
                lblStaffDesignation.Text = string.Empty;
                lblEmpName11.Text = string.Empty;
               
                foreach (GridViewRow gvrow in GridPermission.Rows)
                {
                    CheckBox chkView = (CheckBox)gvrow.FindControl("ChkView");

                    if (chkView != null)
                        chkView.Checked = false;
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

        public void GetPermission()
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetProjecttPermission", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridPermission.DataSource = dt;
                    GridPermission.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void BindCustomerDetails()
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
                    ddlCustomer.Items.Insert(0, new ListItem("Select Customer", "0"));
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
                // DeviceCon.Open();
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

        public void BindStaffDetails()
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
                    ListProjectMembers.DataSource = ds.Tables[0];
                    ListProjectMembers.DataTextField = "First_Name";
                    ListProjectMembers.DataValueField = "Staff_ID";
                    ListProjectMembers.DataBind();
                    ListProjectMembers.Items.Insert(0, new ListItem("Select Project Members ", "0"));

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
                // DeviceCon.Open();
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

        public void BindBillingTypeDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetBillingTypename", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlBillingType.DataSource = ds.Tables[0];
                    ddlBillingType.DataTextField = "Billing_Type";
                    ddlBillingType.DataValueField = "Billing_Type_ID";
                    ddlBillingType.DataBind();
                    ddlBillingType.Items.Insert(0, new ListItem("Select Billing Type", "0"));
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
                // DeviceCon.Open();
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

        public void BindStatusDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetStatusname", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BelongTo", "Project");
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
                // DeviceCon.Open();
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
                            BindStateDetails();
                            GetPermission();
                            BindCustomerDetails();
                            BindStaffDetails();
                            BindBillingTypeDetails();
                            BindStatusDetails();

                            string Todaydate = Convert.ToString(DateTime.Today);
                            string WeekDate = Convert.ToString(DateTime.Today.AddDays(7));
                            txtStartDate.Attributes["value"] = DateTime.Parse(Todaydate.ToString()).ToString("yyyy-MM-dd");
                            txtDeadline.Attributes["value"] = DateTime.Parse(WeekDate.ToString()).ToString("yyyy-MM-dd");
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
                                BindStateDetails();
                                GetPermission();
                                BindCustomerDetails();
                                BindStaffDetails();
                                BindBillingTypeDetails();
                                BindStatusDetails();

                                string Todaydate = Convert.ToString(DateTime.Today);
                                string WeekDate = Convert.ToString(DateTime.Today.AddDays(7));
                                txtStartDate.Attributes["value"] = DateTime.Parse(Todaydate.ToString()).ToString("yyyy-MM-dd");
                                txtDeadline.Attributes["value"] = DateTime.Parse(WeekDate.ToString()).ToString("yyyy-MM-dd");
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

        protected void btnSaveProject_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //------------------------------------------------//
                    int Demolead = '0';
                    int df = '0';
                    string ct = "0.0";
                    string ctsa = "0.0";
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_SaveProjectDetails", con);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProjectName", txtProjectName.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    //cmd.Parameters.AddWithValue("@StaffID", memberid);//staff assign to project.
                    if(ddlStatus.SelectedItem.Value =="0")
                    {
                        cmd.Parameters.AddWithValue("@StatusShow", "8");
                        cmd.Parameters.AddWithValue("@StatusName", "Not Started");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@StatusShow", ddlStatus.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@StatusName", ddlStatus.SelectedItem.Text);
                    }
                    
                    cmd.Parameters.AddWithValue("@ClientName", ddlCustomer.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@ClientID", ddlCustomer.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@billing_type", ddlBillingType.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@billing_typeID", ddlBillingType.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Start_Date", txtStartDate.Text);
                    cmd.Parameters.AddWithValue("@Deadline", txtDeadline.Text);
                    cmd.Parameters.AddWithValue("@Progress", Demolead);
                    cmd.Parameters.AddWithValue("@Progress_from_tasks", df);
                    cmd.Parameters.AddWithValue("@Project_Cost", ct);
                    cmd.Parameters.AddWithValue("@Project_rate_per_hour", ctsa);

                    cmd.Parameters.AddWithValue("@SendEmail", ChBoxEmail.Checked);
                    cmd.Parameters.AddWithValue("@Add_Block", txtflatBilling.Text);
                    cmd.Parameters.AddWithValue("@Add_Street", txtStreetBilling.Text);
                    cmd.Parameters.AddWithValue("@Add_City", ddlBillingcity.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Add_State", ddlBilingState.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Add_PinCode", txtPinBilling.Text);
                    cmd.Parameters.AddWithValue("@Add_Country", ddlCountryBilling.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Add_District", ddlBillingdistrict.SelectedItem.Text);

                    cmd.Parameters.AddWithValue("@AddedfromID", UserId);
                    cmd.Parameters.AddWithValue("@Addedfrom", UserName); //Session value
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    //==========================================================================//
                    //--------------------Member Allocate----------------------------//
                    int membercount = 0; // Initialize count variable
                    string memberid, membername;
                    for (int i = 0; i < ListProjectMembers.Items.Count; i++)
                    {
                        if (ListProjectMembers.Items[i].Selected == true)// getting selected value from CheckBox List  
                        {
                            membercount++;
                        }
                    }
                    if (membercount > 0)
                    {
                        for (int i = 0; i < ListProjectMembers.Items.Count; i++)
                        {
                            if (ListProjectMembers.Items[i].Selected == true)// getting selected value from CheckBox List  
                            {
                                memberid = ListProjectMembers.Items[i].Value;
                               
                                membername = ListProjectMembers.Items[i].Text;

                                GETStaffEmail(memberid);

                                using (SqlConnection con12 = new SqlConnection(strconnect))
                                {
                                    SqlCommand cmd12 = new SqlCommand("SP_SaveProjectMember", con12);
                                    cmd12.Connection = con12;
                                    cmd12.CommandType = CommandType.StoredProcedure;
                                    cmd12.Parameters.AddWithValue("@ProjectName", txtProjectName.Text);
                                    cmd12.Parameters.AddWithValue("@StaffID", memberid);
                                    cmd12.Parameters.AddWithValue("@ClientID", ddlCustomer.SelectedItem.Value);
                                    cmd12.Parameters.AddWithValue("@Addedfrom", UserName);
                                    cmd12.Parameters.AddWithValue("@AddedfromID",UserId );
                                    cmd12.Parameters.AddWithValue("@Designation", Designation);
                                    con12.Open();                                  
                                    drpm = cmd12.ExecuteReader();
                                    while (drpm.Read())
                                    {
                                        resultpm = drpm[0].ToString();
                                    }
                                    Resultpm = int.Parse(resultpm);
                                    if (Resultpm < 0)
                                    {
                                        
                                        // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Project Details Save Successfully!')", true);
                                    }
                                    else
                                    {
                                        // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Project Details already Available!')", true);
                                    }
                                }

                                if (ChBoxEmail.Checked == true)
                                {
                                    SendEmail(membername);
                                }
                                else
                                {

                                }
                            }
                        }
                    }
                    //--------------------Member Allocate----------------------------//
                    //===========================setting================//
                    int count = 0; // Initialize count variable

                    foreach (GridViewRow gvrow in GridPermission.Rows)
                    {
                        CheckBox chkView = (CheckBox)gvrow.FindControl("ChkView");

                        if (chkView != null && chkView.Checked)
                        {
                            count++;
                        }
                    }

                    if (count >= 0)
                    {
                        foreach (GridViewRow gvrow in GridPermission.Rows)
                        {
                            //string roleID = GridViewAuto.DataKeys[gvrow.RowIndex].Value.ToString();
                            CheckBox chkView = (CheckBox)gvrow.FindControl("ChkView");

                            string View;

                            if (chkView != null && chkView.Checked == true)
                            {
                                View = "true";
                            }
                            else
                            {
                                View = "false";
                            }


                            string permission = ((Label)gvrow.FindControl("lblWebPage")).Text;
                            Label permissionID = (Label)gvrow.FindControl("lblID");
                            string perID = permissionID.Text;

                            using (SqlConnection con1 = new SqlConnection(strconnect))
                            {
                                SqlCommand cmd1 = new SqlCommand("SP_SaveProjectSetting", con1);
                                cmd1.Connection = con1;
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.Parameters.AddWithValue("@PermissionName", permission);
                                cmd1.Parameters.AddWithValue("@Permission_id", perID);
                                cmd1.Parameters.AddWithValue("@Check", View);
                                con1.Open();
                                Result1 = cmd1.ExecuteNonQuery();
                                if (Result1 < 0)
                                {
                                    // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Project Details Save Successfully!')", true);
                                }
                                else
                                {
                                    // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Project Details already Available!')", true);
                                }
                            }

                        }
                    }

                    //----------------------------------------------------------------------------//

                    if (Result > 0)
                    {
                        string save = "fgsave123q";
                        Response.Redirect("~/Projects.aspx?svd1=" + save + "", false);
                     }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Project Details already Available";
                    }
                    ClearAll();


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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                Response.Redirect("~/Projects.aspx", false);
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

        protected void linkAddNewProjectSetting_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Add_Project_Setting.aspx", false);
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
        #endregion
    }
}