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
using System.Data.OleDb;
using System.Data.Common;

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
using System.Net;
using System.Net.Mail;
using System.Text;
#endregion


namespace MatoshreeProject
{
    public partial class EditStaffDetails : System.Web.UI.Page
    {

        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr, dr1;
        int Result, Result1;
        string result, result1;

        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        int UserId;
        string SetAdmin;
        string StaffID;

        string DevEmail, DevPassword, DevPort, DevHost;
        string UserEmpName, Password, EmailID1, Designation1, Fname, Lname;
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
        //-----------------------------Partner By EmpID--------------------------------------//
        public DataTable ViewStaffLogInTaskDetailsEmpID(int UserID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_GetStaffLogInTimebyEmpID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", UserID);
                cmd.Parameters.AddWithValue("@StaffID", lblStaffID.Text);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridStaffLogIn.DataSource = table;
                GridStaffLogIn.DataBind();
                ViewState["Data"] = table;
            }
            return table;
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
                            StaffLogINdata();

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
                                GridStaffLogIn.Columns[12].Visible = true;
                            }
                            else
                            {
                                GridStaffLogIn.Columns[12].Visible = false;
                            }

                            if (Delete == "True")
                            {
                                GridStaffLogIn.Columns[13].Visible = true;
                            }
                            else
                            {
                                GridStaffLogIn.Columns[13].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {
                            ViewStaffLogInTaskDetailsEmpID(UserId);

                            if (Create == "True")
                            {
                                //GridStaffLogIn.Visible = true;
                            }
                            else
                            {
                               // GridStaffLogIn.Visible = false;
                            }

                            if (Edit == "True")
                            {
                                GridStaffLogIn.Columns[12].Visible = true;
                            }
                            else
                            {
                                GridStaffLogIn.Columns[12].Visible = false;
                            }

                            if (Delete == "True")
                            {
                                GridStaffLogIn.Columns[13].Visible = true;
                            }
                            else
                            {
                                GridStaffLogIn.Columns[13].Visible = false;
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
        //---------------------------------------------------------------------------------//
        public void StaffLogINdata()
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_GetStaffLogInTime", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@StaffID", lblStaffID.Text);

                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        GridStaffLogIn.DataSource = dt;
                        GridStaffLogIn.DataBind();

                        //Get the row that contains this button

                        foreach (GridViewRow gridviedrow in GridStaffLogIn.Rows)
                        {

                            Label lblRowNumber = (Label)gridviedrow.FindControl("lblRowNumber");

                            LinkButton btnEditTask = (LinkButton)gridviedrow.FindControl("btnEditTask");
                            LinkButton btnDeleteTask = (LinkButton)gridviedrow.FindControl("btnDeleteTask");

                            lblRowNumber.Visible = true;
                            btnEditTask.Visible = true;
                            btnDeleteTask.Visible = true;
                        }

                    }
                    else
                    {
                        GridStaffLogIn.DataSource = dt;
                        GridStaffLogIn.DataBind();
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
        public void Projectfilldata()
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_GetProjectByStaffID", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@StaffID", lblStaffID.Text);

                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        GridStaffProject.DataSource = dt;
                        GridStaffProject.DataBind();


                        foreach (GridViewRow gridviedrow in GridStaffProject.Rows)
                        {
                            Label lblStaffID = (Label)gridviedrow.FindControl("lblStaffID");
                            Label lblProjectID = (Label)gridviedrow.FindControl("lblProjectID");
                            Label lblProjectName = (Label)gridviedrow.FindControl("lblProjectName");
                            Label lblStatusBit = (Label)gridviedrow.FindControl("lblStatusBit");
                            Label lblStatusName = (Label)gridviedrow.FindControl("lblStatusName");
                            Label lblAllocate = (Label)gridviedrow.FindControl("lblAllocate");
                            Button btnDisAllocateProject = (Button)gridviedrow.FindControl("btnDisAllocateProject");

                            btnDisAllocateProject.Visible = true;

                            Label lblRowNumber = (Label)gridviedrow.FindControl("lblRowNumber");


                            lblRowNumber.Visible = true;
                            lblStatusName.Visible = true;


                        }
                    }
                    else
                    {
                        GridStaffProject.DataSource = dt;
                        GridStaffProject.DataBind();

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

        public void StaffNote()
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_GetStaffNote", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@StaffID", lblStaffID.Text);

                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        GridViewNote.DataSource = dt;
                        GridViewNote.DataBind();

                        foreach (GridViewRow gridviedrow in GridViewNote.Rows)
                        {

                            Label lblRowNumber = (Label)gridviedrow.FindControl("lblRowNumber");

                            LinkButton btnEditNote = (LinkButton)gridviedrow.FindControl("btnEditNote");
                            LinkButton btnDeleteNote = (LinkButton)gridviedrow.FindControl("btnDeleteNote");

                            lblRowNumber.Visible = true;
                            btnEditNote.Visible = true;
                            btnDeleteNote.Visible = true;
                        }
                    }
                    else
                    {

                        GridViewNote.DataSource = dt;
                        GridViewNote.DataBind();
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

        #endregion

        #region " Protected Functions "


        #endregion

        #region " Public Functions " 
        public void SendEmail()
        {
            try
            {
                //-----------------Sending Email------------------------//
                GETCredentials();//method for domain password
                Password = txt_Password.Text;
                EmailID1 = txt_Email.Text;
                Designation1 = ddlRoleType.SelectedItem.Text;
                lblEmpName11.Text = txt_First_Name.Text + " " + txt_Last_Name.Text;
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
        protected void bindDeptName()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetDeptName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlDeptStaffName.DataSource = ds.Tables[0];
                    ddlDeptStaffName.DataTextField = "Dept_Name";
                    ddlDeptStaffName.DataValueField = "Dept_ID";
                    ddlDeptStaffName.DataBind();
                    ddlDeptStaffName.Items.Insert(0, new ListItem("Select Department", "0"));
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
                        //Response.Write("<script> alert('Error Log Inserted !!') </script>");
                    }
                    else
                    {
                        //Response.Write("<script> alert('Error Log Inserted !!') </script>");
                    }
                }
            }
        }

        protected void bindShiftName()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetShiftName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlShift.DataSource = ds.Tables[0];
                    ddlShift.DataTextField = "ShiftName";
                    ddlShift.DataValueField = "ID";
                    ddlShift.DataBind();
                    ddlShift.Items.Insert(0, new ListItem("Select Shift", "0"));
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
                        //Response.Write("<script> alert('Error Log Inserted !!') </script>");
                    }
                    else
                    {
                        //Response.Write("<script> alert('Error Log Inserted !!') </script>");
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

        public void GetRoleType()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewRolesByGroup", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlRoleType.DataSource = ds.Tables[0];
                    ddlRoleType.DataTextField = "RoleName";
                    ddlRoleType.DataValueField = "RoleName";
                    ddlRoleType.DataBind();
                    ddlRoleType.Items.Insert(0, new ListItem("Select Role", "0"));
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
                //txtHourRate.Text = string.Empty;
                txt_Email.Text = string.Empty;
                txt_Email_Signature.Text = string.Empty;
                txt_First_Name.Text = string.Empty;
                txt_Last_Name.Text = string.Empty;
                txt_LinkedIn.Text = string.Empty;
                txt_Note_description.Text = string.Empty;
                txt_Password.Text = string.Empty;
                txt_Phone.Text = string.Empty;
                txt_Skype.Text = string.Empty;
                Image1.ImageUrl = string.Empty;
                Image1.Visible = false;
                ddlLanguage.SelectedIndex = 0;
                ddlDirection.SelectedIndex = 0;
                ddlRoleType.SelectedIndex = 0;

                GetEmpRolePagesPermission();
                StaffNote();
                Projectfilldata();
                StaffLogINdata();
            }
            catch (Exception ex)
            {
                //diverror.Visible = true;
                //lblMessage1.Text = Convert.ToString(ex);
            }
        }

        public void GetEmpRolePagesPermission()
        {
            try
            {
                StaffID = HttpUtility.UrlDecode(Request.QueryString["Staff_ID"]);
                lblStaffID.Text = StaffID;

                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetRolesByStaffID", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@StaffID", StaffID);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridRole.DataSource = dt;
                    GridRole.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void GetStaffDetailsID()
        {
            try
            {
                string Status, SelectedStaffMember, Checkboxsendemail, mediapath;
                StaffID = HttpUtility.UrlDecode(Request.QueryString["Staff_ID"]);
                lblStaffID.Text = StaffID;
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetStaffDetailsBYID", UserCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@StaffID", StaffID);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txt_First_Name.Text = dt.Rows[0]["First_Name"].ToString();
                    txt_Last_Name.Text = dt.Rows[0]["LastName"].ToString();
                    txt_Email.Text = dt.Rows[0]["Email"].ToString();
                    txt_Facebook.Text = dt.Rows[0]["Facebook"].ToString();
                    txt_LinkedIn.Text = dt.Rows[0]["Linkedn"].ToString();
                    txt_Phone.Text = dt.Rows[0]["PhoneNumber"].ToString();
                    txt_Skype.Text = dt.Rows[0]["Skype"].ToString();
                    Image1.ImageUrl = dt.Rows[0]["Profile_image"].ToString();

                    ddlDirection.SelectedItem.Text = dt.Rows[0]["Direction"].ToString();
                    ddlLanguage.SelectedItem.Text = dt.Rows[0]["Default_language"].ToString();
                    ddlRoleType.SelectedItem.Text = dt.Rows[0]["Role"].ToString();

                    ddlDeptStaffName.SelectedItem.Value = dt.Rows[0]["Dept_ID"].ToString();
                    ddlDeptStaffName.SelectedItem.Text = dt.Rows[0]["Dept_Name"].ToString();

                    ddlShift.SelectedItem.Value = dt.Rows[0]["ShiftID"].ToString();
                    ddlShift.SelectedItem.Text = dt.Rows[0]["ShiftName"].ToString();

                    txt_Password.Text = dt.Rows[0]["Password"].ToString();
                    txt_Note_description.Text = dt.Rows[0]["Description"].ToString();
                    txt_Email_Signature.Text = dt.Rows[0]["email_signature"].ToString();
                    //txtHourRate.Text = dt.Rows[0]["hourly_rate"].ToString();
                    SelectedStaffMember = dt.Rows[0]["is_not_staff"].ToString();
                    if (SelectedStaffMember == "True")
                    {
                        RadioSelectedStaff.SelectedValue = "1";
                    }
                    else
                    {
                        RadioSelectedStaff.SelectedValue = "0";
                    }


                    Status = dt.Rows[0]["Statusactive"].ToString();
                    if (Status == "True")
                    {
                        RadiobtnStatusStaff.SelectedValue = "1";
                    }
                    else
                    {
                        RadiobtnStatusStaff.SelectedValue = "0";
                    }

                    Checkboxsendemail = dt.Rows[0]["SendWelcomeEmail"].ToString();
                    if (Checkboxsendemail == "True")
                    {
                        CheckBoxSendEmail.Checked = true;
                        txtEmailDescription.Visible = true;
                        txtEmailDescription.Text = dt.Rows[0]["media_path_slug"].ToString();
                    }
                    else
                    {
                        CheckBoxSendEmail.Checked = false;
                        txtEmailDescription.Visible = false;
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
                            div_notes.Visible = true;
                            div_log.Visible = false;

                            bindDeptName();
                            bindShiftName();
                            GetRoleType();
                            GetStaffDetailsID();
                            GetEmpRolePagesPermission();
                            StaffNote();
                            Projectfilldata();
                            StaffLogINdata();
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
                                div_notes.Visible = true;
                                div_log.Visible = false;

                                bindDeptName();
                                bindShiftName();
                                GetRoleType();
                                GetStaffDetailsID();
                                GetEmpRolePagesPermission();
                                StaffNote();
                                Projectfilldata();
                                StaffLogINdata();
                            }
                        }
                        else
                        {

                        }

                    }
                    else
                    {
                        Response.Redirect("~/LogIn.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("~/LogIn.aspx", false);
                }
            }
            catch (Exception ex)
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


        protected void btnImgUpload_Click(object sender, EventArgs e)
        {
            try
            {
                Image1.Visible = true;
                string folderPath = Server.MapPath("~/EmpProfile/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists Create it.
                    Directory.CreateDirectory(folderPath);
                }

                //Save the File to the Directory (Folder).
                FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));

                //Display the Picture in Image control.
                Image1.ImageUrl = "~/EmpProfile/" + Path.GetFileName(FileUpload1.FileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btn_New_Item_Click(object sender, EventArgs e)
        {
            txt_Note_description.Visible = true;
        }


        protected void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                Response.Redirect("Setup_StaffDetails.aspx");
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
            finally { }
        }

       

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    int count = 0; // Initialize count variable
                    Boolean sendemail;
                    foreach (GridViewRow gvrow in GridRole.Rows)
                    {
                        CheckBox chkGlobalView = (CheckBox)gvrow.FindControl("ChkGlobal");
                        CheckBox chkView = (CheckBox)gvrow.FindControl("ChkView");
                        CheckBox chkEdit = (CheckBox)gvrow.FindControl("chkEdit");
                        CheckBox chkCreate = (CheckBox)gvrow.FindControl("chkCreate");
                        CheckBox chkDelete = (CheckBox)gvrow.FindControl("chkDelete");

                        if (chkView != null && chkView.Checked || chkGlobalView != null && chkGlobalView.Checked)
                        {
                            count++;
                        }
                    }

                    if (count > 0)
                    {
                        foreach (GridViewRow gvrow in GridRole.Rows)
                        {
                            //string roleID = GridViewAuto.DataKeys[gvrow.RowIndex].Value.ToString();
                            CheckBox chkGlobalView = (CheckBox)gvrow.FindControl("ChkGlobal");
                            CheckBox chkView = (CheckBox)gvrow.FindControl("ChkView");
                            CheckBox chkEdit = (CheckBox)gvrow.FindControl("chkEdit");
                            CheckBox chkCreate = (CheckBox)gvrow.FindControl("chkCreate");
                            CheckBox chkDelete = (CheckBox)gvrow.FindControl("chkDelete");
                            string GlobalView;
                            string View;
                            string Edit;
                            string Create;
                            string Delete;

                            if (chkGlobalView != null && chkGlobalView.Checked == true)
                            {
                                GlobalView = "true";
                            }
                            else
                            {
                                GlobalView = "false";
                            }

                            if (chkView != null && chkView.Checked == true)
                            {
                                View = "true";
                            }
                            else
                            {
                                View = "false";
                            }


                            if (chkEdit != null && chkEdit.Checked == true)
                            {
                                Edit = "true";
                            }
                            else
                            {
                                Edit = "false";
                            }


                            if (chkCreate != null && chkCreate.Checked == true)
                            {
                                Create = "true";
                            }
                            else
                            {
                                Create = "false";
                            }


                            if (chkDelete != null && chkDelete.Checked == true)
                            {
                                Delete = "true";
                            }
                            else
                            {
                                Delete = "false";
                            }

                            string WebPage = ((Label)gvrow.FindControl("lblWebPage")).Text;
                            Label PageID = (Label)gvrow.FindControl("lblID");
                            string ID = PageID.Text;

                            using (SqlConnection con1 = new SqlConnection(strconnect))
                            {
                                SqlCommand cmd1 = new SqlCommand("SP_UpdateStaffAccess", con1);
                                cmd1.Connection = con1;
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.Parameters.AddWithValue("@RoleName", ddlRoleType.SelectedItem.Text);
                                cmd1.Parameters.AddWithValue("@GlobalView", GlobalView);
                                cmd1.Parameters.AddWithValue("@View", View);
                                cmd1.Parameters.AddWithValue("@Edit", Edit);
                                cmd1.Parameters.AddWithValue("@Create", Create);
                                cmd1.Parameters.AddWithValue("@Delete", Delete);
                                cmd1.Parameters.AddWithValue("@PageID", ID);
                                cmd1.Parameters.AddWithValue("@WebPageName", WebPage);
                                cmd1.Parameters.AddWithValue("@Createby", UserName);
                                cmd1.Parameters.AddWithValue("@EmpID", UserId);
                                cmd1.Parameters.AddWithValue("@StaffID", lblStaffID.Text);
                                con1.Open();
                                int Result1 = cmd1.ExecuteNonQuery();
                                if (Result1 < 0)
                                {
                                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Role Details Save Successfully!')", true);
                                }
                                else
                                {
                                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Role Details already Available!')", true);
                                }
                                con1.Close();
                            }
                        }
                    }
                    //---------------------------------------------------------------//

                    if (ddlRoleType.SelectedItem.Text == "Admin")
                    {
                        SetAdmin = "True";
                    }
                    else
                    {
                        SetAdmin = "False";
                    }


                    if (CheckBoxSendEmail.Checked == true)
                    {
                        sendemail = true;
                        SendEmail();
                    }
                    else
                    {
                        sendemail = false;
                    }

                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_UPDATEStaffDetails", con);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Staffid", lblStaffID.Text);
                    cmd.Parameters.AddWithValue("@FirstName", txt_First_Name.Text);
                    cmd.Parameters.AddWithValue("@LastName", txt_Last_Name.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_Email.Text);
                    cmd.Parameters.AddWithValue("@FaceBook", txt_Facebook.Text);
                    cmd.Parameters.AddWithValue("@Linkedn", txt_LinkedIn.Text);
                    cmd.Parameters.AddWithValue("@Skypee", txt_Skype.Text);
                    cmd.Parameters.AddWithValue("@Password", txt_Password.Text);
                    cmd.Parameters.AddWithValue("@ProfileImage", Image1.ImageUrl);
                    cmd.Parameters.AddWithValue("@AdminId", SetAdmin);
                    cmd.Parameters.AddWithValue("@Deafult_Lang", ddlLanguage.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Direction", ddlDirection.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Media_Path", txtEmailDescription.Text);
                    cmd.Parameters.AddWithValue("@Is_Not_Staff", RadioSelectedStaff.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Description", txt_Note_description.Text);
                    cmd.Parameters.AddWithValue("@Hour_Rate","0");// txtHourRate.Text
                    cmd.Parameters.AddWithValue("@email_signature", txt_Email_Signature.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txt_Phone.Text);
                    cmd.Parameters.AddWithValue("@RoleType", ddlRoleType.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Dept_ID", ddlDeptStaffName.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Dept_Name", ddlDeptStaffName.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@ShifID", ddlShift.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@ShiftName", ddlShift.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Status", RadiobtnStatusStaff.SelectedValue);
                    cmd.Parameters.AddWithValue("@sendEmail", sendemail);
                    cmd.Parameters.AddWithValue("@updateby", UserName); //Session value
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    con.Open();
                    int Result = cmd.ExecuteNonQuery();
                    if (Result < 0)
                    {
                        string edit = "xcvfedit";
                        Response.Redirect("~/Setup_StaffDetails.aspx?edit1=" + edit + "", false);
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Staff Details Not Edit Successfully";
                    }
                    ClearAll();
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
                finally { }
            }
        }

        protected void CheckBoxSendEmail_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxSendEmail.Checked == true)
                {
                    txtEmailDescription.Visible = true;

                }
                else
                {
                    txtEmailDescription.Visible = false;

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

        protected void GridRole_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Boolean Global, View;
                    CheckBox ChkGlobal = (CheckBox)e.Row.FindControl("ChkGlobal");
                    CheckBox ChkView = (CheckBox)e.Row.FindControl("ChkView");
                    Global = ChkGlobal.Checked;

                    Global = ChkGlobal.Checked;
                    if (Global == true)
                    {
                        ChkView.Enabled = false;
                        ChkView.Checked = false;
                    }
                    else
                    {
                        ChkView.Enabled = true;
                        ChkView.Checked = true;
                    }

                    View = ChkView.Checked;

                    if (View == true)
                    {
                        ChkGlobal.Enabled = false;
                        ChkGlobal.Checked = false;
                    }
                    else
                    {
                        ChkGlobal.Enabled = true;
                        ChkGlobal.Checked = true;
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
            finally { }
        }

        protected void ddlRoleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Rolename = Convert.ToString(ddlRoleType.SelectedItem.Text);

                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetRolesByRoleName", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@RoleName", Rolename);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridRole.DataSource = dt;
                    GridRole.DataBind();
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

        //------------------------Staff Project  Allocaion AND Deallocation ------------------------------//
        protected void GridStaffProject_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridStaffProject.Rows)
                {
                    Label lblStaffID = (Label)gridviedrow.FindControl("lblStaffID");
                    Label lblProjectID = (Label)gridviedrow.FindControl("lblProjectID");
                    Label lblProjectName = (Label)gridviedrow.FindControl("lblProjectName");
                    Label lblStart_Date = (Label)gridviedrow.FindControl("lblStart_Date");
                    Label lblDeadline = (Label)gridviedrow.FindControl("lblDeadline");
                    Label lblStatusBit = (Label)gridviedrow.FindControl("lblStatusBit");
                    Label lblProjectStatus = (Label)gridviedrow.FindControl("lblStatusName");
                    Label lblAllocate = (Label)gridviedrow.FindControl("lblAllocate");
                    Button btnDisAllocateProject = (Button)gridviedrow.FindControl("btnDisAllocateProject");

                    string Status1 = lblStatusBit.Text;

                    if (Status1 == "True")
                    {

                        lblStaffID.ForeColor = Color.Blue;
                        lblStart_Date.ForeColor = Color.Blue;
                        lblDeadline.ForeColor = Color.Blue;
                        lblProjectName.ForeColor = Color.Blue;
                    }
                    else
                    {
                        lblStaffID.ForeColor = Color.Red;
                        lblStart_Date.ForeColor = Color.Red;
                        lblDeadline.ForeColor = Color.Red;
                        lblProjectName.ForeColor = Color.Red;

                    }

                    string buttonAllocate = lblAllocate.Text;

                    if (buttonAllocate == "False")
                    {
                        btnDisAllocateProject.CssClass = "btn btn-sm btn-success";
                        btnDisAllocateProject.Text = "Allocate";

                    }
                    else if(buttonAllocate == "True")
                    {
                        btnDisAllocateProject.CssClass = "btn btn-sm btn-danger";
                        btnDisAllocateProject.Text = "DeAllocate";
                    }
                    else
                    {
                        btnDisAllocateProject.CssClass = "btn btn-sm btn-success";
                        btnDisAllocateProject.Text = "Allocate";
                    }


                    string Projectstatus1 = lblProjectStatus.Text;

                    if (Projectstatus1 == "On Hold")
                    {
                        lblProjectStatus.CssClass = "btn btn-warning";

                    }
                    else if (Projectstatus1 == "Finished")
                    {
                        lblProjectStatus.CssClass = "btn btn-success";

                    }
                    else if (Projectstatus1 == "Cancelled")
                    {
                        lblProjectStatus.CssClass = "btn btn-danger";

                    }
                    else //In Progress
                    {
                        lblProjectStatus.CssClass = "btn btn-light";
                        lblProjectStatus.BorderColor = Color.Blue;
                        lblProjectStatus.ForeColor = Color.Black;
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

        protected void btnDisAllocateProject_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblStaffID.Text == "0")
                {

                }
                else
                {
                    foreach (GridViewRow gridviedrow in GridStaffProject.Rows)
                    {
                        Label lblStaffID = (Label)gridviedrow.FindControl("lblStaffID");
                        Label lblProjectID = (Label)gridviedrow.FindControl("lblProjectID");
                        Label lblProjectName = (Label)gridviedrow.FindControl("lblProjectName");
                        Label lblStart_Date = (Label)gridviedrow.FindControl("lblStart_Date");
                        Label lblDeadline = (Label)gridviedrow.FindControl("lblDeadline");
                        Label lblStatusBit = (Label)gridviedrow.FindControl("lblStatusBit");
                        Label lblProjectStatus = (Label)gridviedrow.FindControl("lblStatusName");
                        Button btnDisAllocateProject = (Button)gridviedrow.FindControl("btnDisAllocateProject");

                        if (btnDisAllocateProject.Text == "DeAllocate")
                        {
                            using (SqlConnection con12 = new SqlConnection(strconnect))
                            {
                                SqlCommand cmd12 = new SqlCommand("SP_DeAllocateProjectStaff", con12);
                                cmd12.Connection = con12;
                                cmd12.CommandType = CommandType.StoredProcedure;
                                cmd12.Parameters.AddWithValue("@Staff_ID", lblStaffID.Text);
                                cmd12.Parameters.AddWithValue("@Project_ID", lblProjectID.Text);
                                cmd12.Parameters.AddWithValue("@Allocate", "False");
                                cmd12.Parameters.AddWithValue("@updateby", UserName);
                                cmd12.Parameters.AddWithValue("@EmpID", UserId);
                                cmd12.Parameters.AddWithValue("@Designation", Designation);
                                con12.Open();
                                int Result = cmd12.ExecuteNonQuery();
                                if (Result < 0)
                                {
                                    Toasteralert.Visible = false;
                                    deleteToaster.Visible = true;
                                    lblMesDelete.Text = "Project Member Deallocated";
                                    Projectfilldata();
                                    btnDisAllocateProject.CssClass = "btn btn-sm btn-success";
                                    btnDisAllocateProject.Text = "Allocate";
                                }
                                else
                                {
                                    Toasteralert.Visible = false;
                                    deleteToaster.Visible = true;
                                    lblMesDelete.Text = "Project Member Not Deallocated";
                                }
                            }
                        }
                        else
                        {
                            using (SqlConnection con12 = new SqlConnection(strconnect))
                            {
                                SqlCommand cmd12 = new SqlCommand("SP_DeAllocateProjectStaff", con12);
                                cmd12.Connection = con12;
                                cmd12.CommandType = CommandType.StoredProcedure;
                                cmd12.Parameters.AddWithValue("@Staff_ID", lblStaffID.Text);
                                cmd12.Parameters.AddWithValue("@Project_ID", lblProjectID.Text);
                                cmd12.Parameters.AddWithValue("@Allocate", "True");
                                cmd12.Parameters.AddWithValue("@updateby", UserName);
                                cmd12.Parameters.AddWithValue("@EmpID", UserId);
                                cmd12.Parameters.AddWithValue("@Designation", Designation);
                                con12.Open();
                                int Result = cmd12.ExecuteNonQuery();
                                if (Result < 0)
                                {
                                    Toasteralert.Visible = false;
                                    deleteToaster.Visible = true;
                                    lblMesDelete.Text = "Project Member Allocate";

                                    Projectfilldata();
                                    btnDisAllocateProject.CssClass = "btn btn-sm btn-danger";
                                    btnDisAllocateProject.Text = "DeAllocate";
                                }
                                else
                                {
                                    Toasteralert.Visible = false;
                                    deleteToaster.Visible = true;
                                    lblMesDelete.Text = "Project Member Not Allocate YET";
                                                           }
                            }
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


        //------------------------Staff Note------------------------------//
        protected void btn_New_Item_Click1(object sender, EventArgs e)
        {
            dtaffnote.Visible = true;
            txt_Note_description.Visible = true;
        }

        protected void btnSavenote_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblStaffID.Text == "0")
                {

                }
                else
                {
                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd1 = new SqlCommand("SP_SaveStaffNOTE", con1);
                        cmd1.Connection = con1;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@ID", "");
                        cmd1.Parameters.AddWithValue("@StaffID", lblStaffID.Text);
                        cmd1.Parameters.AddWithValue("@DeptID", ddlDeptStaffName.SelectedItem.Value);
                        cmd1.Parameters.AddWithValue("@ProjectID", "");
                        cmd1.Parameters.AddWithValue("@Note", txt_Note_description.Text);
                        cmd1.Parameters.AddWithValue("@created_by", UserName);
                        cmd1.Parameters.AddWithValue("@EmpID", UserId);
                        cmd1.Parameters.AddWithValue("@Designation", Designation);

                        con1.Open();
                        dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            result1 = dr1[0].ToString();
                        }
                        Result1 = int.Parse(result1);
                        if (Result1 > 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Note  Save Successfully!";

                            StaffNote();
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Note  already Available!!";
                        }
                        dr1.Close();
                        con1.Close();
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
        protected void btnEditNote_Click(object sender, EventArgs e)
        {
            try
            {
                dtaffnote.Visible = true;
                txt_Note_description.Visible = true;

                DeviceCon = new SqlConnection(strconnect);
                string tableID, tableStaffID;
                var rows = GridViewNote.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                tableStaffID = ((Label)rows[rowindex].FindControl("lblStaffID")).Text;
                tableID = ((Label)rows[rowindex].FindControl("lblNoteID")).Text;

                if (tableStaffID == "")
                {

                }
                else
                {
                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd1 = new SqlCommand("SP_SaveStaffNOTE", con1);
                        cmd1.Connection = con1;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@ID", tableID);
                        cmd1.Parameters.AddWithValue("@StaffID", tableStaffID);
                        cmd1.Parameters.AddWithValue("@DeptID", ddlDeptStaffName.SelectedItem.Value);
                        cmd1.Parameters.AddWithValue("@ProjectID", "");
                        cmd1.Parameters.AddWithValue("@Note", txt_Note_description.Text);
                        cmd1.Parameters.AddWithValue("@created_by", UserName);
                        cmd1.Parameters.AddWithValue("@EmpID", UserId);
                        cmd1.Parameters.AddWithValue("@Designation", Designation);

                        con1.Open();
                        dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            result1 = dr1[0].ToString();
                        }
                        Result1 = int.Parse(result1);
                        if (Result1 > 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Note  Save Successfully";

                             StaffNote();
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Note  Modify Successfully";
                        }
                        dr1.Close();
                        con1.Close();
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

        protected void btnDeleteNote_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    DeviceCon = new SqlConnection(strconnect);
                    string tableID, Note;
                    var rows = GridViewNote.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    tableID = ((Label)rows[rowindex].FindControl("lblStaffID")).Text;
                    Note = ((Label)rows[rowindex].FindControl("lblNoteID")).Text;
                    if (tableID == "")
                    {

                    }
                    else
                    {
                        SqlConnection DeviceCon = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_DeleteStaffNote", DeviceCon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StaffID", tableID);
                        cmd.Parameters.AddWithValue("@NoteID", Note);
                        cmd.Parameters.AddWithValue("@created_by", UserName);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        DeviceCon.Open();
                        int i = cmd.ExecuteNonQuery();
                        DeviceCon.Close();
                        if (i < 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Note  Deleted Successfully";

                            StaffNote();
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Staff Note Details Not Deleted";
                        }
                    }
                }
                else if (RoleType == Designation)
                {
                    DeviceCon = new SqlConnection(strconnect);
                    string tableID, Note;
                    var rows = GridViewNote.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    tableID = ((Label)rows[rowindex].FindControl("lblStaffID")).Text;
                    Note = ((Label)rows[rowindex].FindControl("lblNoteID")).Text;
                    if (tableID == "")
                    {

                    }
                    else
                    {
                        SqlConnection DeviceCon = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_DeleteStaffNoteForEmpID", DeviceCon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StaffID", tableID);
                        cmd.Parameters.AddWithValue("@NoteID", Note);
                        cmd.Parameters.AddWithValue("@created_by", UserName);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        DeviceCon.Open();
                        int i = cmd.ExecuteNonQuery();
                        DeviceCon.Close();
                        if (i < 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Note  Deleted Successfully";
                      
                            StaffNote();
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Staff Note Details Not Deleted";
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
        //-----------------------------Staff LOGIN DATA----------------------------------//
        protected void GridStaffLogIn_RowDataBound(object sender, GridViewRowEventArgs e)
        {

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
                    DeviceCon = new SqlConnection(strconnect);
                    string task;
                    var rows = GridStaffLogIn.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    task = ((Label)rows[rowindex].FindControl("lblTaskName")).Text;

                    if (task == "")
                    {
                        Response.Redirect("~/AddNewTaskStaff.aspx", true);
                    }
                    else
                    {
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
                            GridStaffLogIn.EditIndex = -1;
                            StaffLogINdata();
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Task Details Not Deleted Successfully";
                        }                       
                    }
                }
                else if (RoleType == Designation)
                {
                    DeviceCon = new SqlConnection(strconnect);
                    string task;
                    var rows = GridStaffLogIn.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    task = ((Label)rows[rowindex].FindControl("lblTaskName")).Text;

                    if (task == "")
                    {
                        Response.Redirect("~/AddNewTaskStaff.aspx", true);
                    }
                    else
                    {
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
                            GridStaffLogIn.EditIndex = -1;
                            StaffLogINdata();
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Task Details Not Deleted Successfully";
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
            finally { }
        }

        protected void btnEditTask_Click(object sender, EventArgs e)
        {
            try
            {
                string task;
                var rows = GridStaffLogIn.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                task = ((Label)rows[rowindex].FindControl("lblTaskName")).Text;

                if (task == "")
                {
                    Response.Redirect("~/AddNewTaskStaff.aspx", true);
                }
                else
                {
                    Response.Redirect("~/EditStaffTask.aspx?task=" + task + "", false);
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

        protected void ChkGlobal_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                Boolean ChkGlobal;
                var rows = GridRole.Rows;
                CheckBox btn = (CheckBox)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ChkGlobal = ((CheckBox)rows[rowindex].FindControl("ChkGlobal")).Checked;
                CheckBox chkview1 = (CheckBox)rows[rowindex].FindControl("ChkView");

                if (ChkGlobal == true)
                {
                    chkview1.Enabled = false;
                    chkview1.Checked = false;
                }
                else
                {
                    chkview1.Enabled = true;
                    chkview1.Checked = true;
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

        protected void ChkView_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                Boolean ChkView;
                var rows = GridRole.Rows;
                CheckBox btn = (CheckBox)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ChkView = ((CheckBox)rows[rowindex].FindControl("ChkView")).Checked;
                CheckBox chkGlobalview1 = (CheckBox)rows[rowindex].FindControl("ChkGlobal");

                if (ChkView == true)
                {
                    chkGlobalview1.Enabled = false;
                    chkGlobalview1.Checked = false;
                }
                else
                {
                    chkGlobalview1.Enabled = true;
                    chkGlobalview1.Checked = true;
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