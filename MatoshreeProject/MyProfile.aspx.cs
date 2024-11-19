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
#endregion

namespace MatoshreeProject
{
    public partial class MyProfile : System.Web.UI.Page
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
        public void GetAdminByID(int UserID1)
        {
            try
            {
                Designation = Session["Role"].ToString();
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GETAdminProfile", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ID", UserID1);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblFname.Text = dt.Rows[0]["UserName"].ToString();
                        lblPhonenumber.Visible = false;
                        lblEmail.Text = dt.Rows[0]["EmailID"].ToString();
                        lblRele1.Text = dt.Rows[0]["Role"].ToString();

                        string imageUrl = "Image/user.jpg";

                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            ImgUser.ImageUrl = imageUrl; // Display the retrieved image
                        }
                        else
                        {
                            ImgUser.ImageUrl = "Image/user.jpg"; // Set default image path
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
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName);
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
        public void GetStaffByID(int UserID1)
        {
            try
            {
                Designation = Session["Role"].ToString();
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("[SP_GetStaffByID]", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@Staff_ID", UserID1);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblFname.Text = dt.Rows[0]["Full_Name"].ToString();
                        lblPhonenumber.Text = dt.Rows[0]["PhoneNumber"].ToString();
                        lblEmail.Text = dt.Rows[0]["Email"].ToString();
                        lblRele1.Text = dt.Rows[0]["Role"].ToString();

                        string imageUrl = dt.Rows[0]["Profile_image"].ToString();

                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            ImgUser.ImageUrl = imageUrl; // Display the retrieved image
                        }
                        else
                        {
                            ImgUser.ImageUrl = "Image/user.jpg"; // Set default image path
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
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName);
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

        public void StaffLogINStatusCount()
        {
            try
            {
                UserId = Convert.ToInt32(Session["UserID"]);
                //-------------Today ----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetStaffLogInTimeToday1", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Staffid", UserId);
                    int TodaylogInHr = (int)command.ExecuteScalar();

                    lblTodayHours.Text = Convert.ToString(TodaylogInHr);

                    lblTotalHours.Text = "24";

                    Decimal TodayHR = Convert.ToDecimal(lblTodayHours.Text);
                    Decimal CurrentHR = Convert.ToDecimal(lblTotalHours.Text);

                    decimal totalHours = Convert.ToDecimal((TodayHR / CurrentHR) * 100);
                    decimal totalHours1 = decimal.Round(totalHours, 1);
                    lblPercent.Text = Convert.ToString(totalHours1) + "%";

                    pgTodayHr.Style.Add("width", lblPercent.Text);
                }


                //-------------loginmonth----------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetStaffLogInTimeMonth", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Staffid", UserId);
                    int TimeMonth = (int)command.ExecuteScalar();

                    lblLogInMonth.Text = Convert.ToString(TimeMonth);

                    lblTotalMonth.Text = "12";

                    Decimal TodayMonth = Convert.ToDecimal(lblLogInMonth.Text);
                    Decimal CurrentMonth = Convert.ToDecimal(lblTotalHours.Text);

                    decimal totalMonth = Convert.ToDecimal((TodayMonth / CurrentMonth) * 100);
                    decimal totalMonth1 = decimal.Round(totalMonth, 1);
                    lblPercentMonth.Text = Convert.ToString(totalMonth1) + "%";

                    pgMonth.Style.Add("width", lblPercentMonth.Text);
                }

                //-------------LogINWeek----------------------//
                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetStaffLogInTimeWeek", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Staffid", UserId);
                    int Week = (int)command.ExecuteScalar();

                    lblWeekLog.Text = Convert.ToString(Week);
                    TotalWeekDay.Text = "52";

                    Decimal TodayWeek = Convert.ToDecimal(lblWeekLog.Text);
                    Decimal CurrentWeek = Convert.ToDecimal(TotalWeekDay.Text);

                    decimal totalWeek = Convert.ToDecimal((TodayWeek / CurrentWeek) * 100);
                    decimal totalWeek1 = decimal.Round(totalWeek, 1);
                    lblWeekPercent.Text = Convert.ToString(totalWeek1) + "%";

                    pgWeek.Style.Add("width", lblWeekPercent.Text);
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

                        lblRele1.Text = Designation.ToString();

                        if (!IsPostBack)
                        {
                            if (Designation == "Administrator")
                            {
                                GetAdminByID(UserId);
                                //StaffLogINStatusCount();
                            }
                            else
                            {
                                GetStaffByID(UserId);
                                StaffLogINStatusCount();
                            }

                               
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
                            lblRele1.Text = Designation.ToString();
                            if (!IsPostBack)
                            {
                                if (Designation == "Administrator")
                                {
                                    GetAdminByID(UserId);
                                    //StaffLogINStatusCount();
                                }
                                else
                                {
                                    GetStaffByID(UserId);
                                    StaffLogINStatusCount();
                                }
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
                    DeviceCon.Close();
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
        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Designation == "Administrator")
                {
                    GetAdminByID(UserId);
                }
                else
                {
                    Response.Redirect("~/Edit_Staff_Member.aspx?ID=" + UserId, false);
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
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); 
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