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
    public partial class EditProfile : System.Web.UI.Page
    {
        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
   

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

        protected void GetProfileDetailsAdministratorID(int UserID)
        {
            try
            {
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetAdministatorDetailsByID", UserCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@ID", UserID);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txt_First_Name.Text = dt.Rows[0]["UserName"].ToString();
                    txt_Last_Name.ReadOnly = true;
                    txt_Email.Text = dt.Rows[0]["EmailID"].ToString();
                    txt_Facebook.ReadOnly = true;
                    txt_LinkedIn.ReadOnly = true;
                    txt_Phone.ReadOnly = true;
                    txt_Skype.ReadOnly = true;

                    Image1.ImageUrl = "Image/user.jpg";
                    Image1.Visible = true;
                    ddlDirection.SelectedItem.Text = "LTR";
                    ddlLanguage.SelectedItem.Text = "English";

                    txt_OldPassword.Text = dt.Rows[0]["Password"].ToString();
                    txt_Email_Signature.ReadOnly = true;
                    lblProfileName.Text = UserName;
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
        protected void GetProfileDetailsID(int UserID)
        {
            try
            {
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetStaffDetailsBYID", UserCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@StaffID", UserID);
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
                    Image1.Visible = true;
                    ddlDirection.SelectedItem.Text = dt.Rows[0]["Direction"].ToString();
                    ddlLanguage.SelectedItem.Text = dt.Rows[0]["Default_language"].ToString();
                  
                    txt_OldPassword.Text = dt.Rows[0]["Password"].ToString();           
                    txt_Email_Signature.Text = dt.Rows[0]["email_signature"].ToString();
                    lblProfileName.Text = UserName;
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

                        lblProfileName.Text = UserName;


                        if (!IsPostBack)
                        {
                            if(Designation == "Administrator")
                            {
                                GetProfileDetailsAdministratorID(UserId);
                            }
                            else
                            {
                                GetProfileDetailsID(UserId);
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
                            if (!IsPostBack)
                            {
                                GetProfileDetailsID(UserId);
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

        protected void btnImgUpload_Click(object sender, EventArgs e)
        {
            try
            {
                Image1.Visible = true;
                string folderPath = Server.MapPath("~/Upload/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists Create it.
                    Directory.CreateDirectory(folderPath);
                }

                //Save the File to the Directory (Folder).
                FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));

                //Display the Picture in Image control.
                Image1.ImageUrl = "~/Upload/" + Path.GetFileName(FileUpload1.FileName);
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

        protected void btnChnagePassword_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (Designation == "Administrator")
                    {
                        UserId = Convert.ToInt32(Session["UserID"]);
                        EmailID = Session["EmailID"].ToString();
                        SqlConnection con = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_AdminPasswordChange", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", EmailID);
                        cmd.Parameters.AddWithValue("@Password", txt_ConfirmPassword.Text);
                        con.Open();
                        int Result = cmd.ExecuteNonQuery();
                        if (Result < 0)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password Change Successfully!')", true);

                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password Not Change Successfully!')", true);
                        }
                        txt_ConfirmPassword.Text = string.Empty;
                        txt_NewPassword.Text = string.Empty;

                        GetProfileDetailsAdministratorID(UserId);
                    }
                    else
                    {
                        UserId = Convert.ToInt32(Session["UserID"]);
                        EmailID = Session["EmailID"].ToString();
                        SqlConnection con = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_UPDATEUserPassword", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", EmailID);
                        cmd.Parameters.AddWithValue("@Password", txt_ConfirmPassword.Text);
                        con.Open();
                        int Result = cmd.ExecuteNonQuery();
                        if (Result < 0)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password Change Successfully!')", true);

                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password Not Change Successfully!')", true);
                        }
                        txt_ConfirmPassword.Text = string.Empty;
                        txt_NewPassword.Text = string.Empty;
                        GetProfileDetailsID(UserId);
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
                finally
                {

                }
            }
        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        UserId = Convert.ToInt32(Session["UserID"]);
                        UserName = Session["UserName"].ToString();
                        string md = "nothimg";
                        SqlCommand cmd = new SqlCommand("SP_UPDATEUserProfile", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Staffid", UserId);
                        cmd.Parameters.AddWithValue("@FirstName", txt_First_Name.Text);
                        cmd.Parameters.AddWithValue("@LastName", txt_Last_Name.Text);
                        cmd.Parameters.AddWithValue("@Email", txt_Email.Text);
                        cmd.Parameters.AddWithValue("@FaceBook", txt_Facebook.Text);
                        cmd.Parameters.AddWithValue("@Linkedn", txt_LinkedIn.Text);
                        cmd.Parameters.AddWithValue("@Skypee", txt_Skype.Text);
                        cmd.Parameters.AddWithValue("@Password", txt_OldPassword.Text);
                        cmd.Parameters.AddWithValue("@ProfileImage", Image1.ImageUrl);
                        cmd.Parameters.AddWithValue("@Deafult_Lang", ddlLanguage.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Direction", ddlDirection.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Media_Path", md);////////////                
                        cmd.Parameters.AddWithValue("@email_signature", txt_Email_Signature.Text);
                        cmd.Parameters.AddWithValue("@PhoneNumber", txt_Phone.Text);
                        cmd.Parameters.AddWithValue("@updateby", UserName); //Session value
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        con.Open();
                        int Result = cmd.ExecuteNonQuery();
                        if (Result < 0)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Edit Profile Successfully!')", true);
                            GetProfileDetailsID(UserId);
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Profile Not Edit Successfully!')", true);
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
                            //Response.Write("<script> alert('Error Log Inserted !!') </script>");
                        }
                        else
                        {
                            //Response.Write("<script> alert('Error Log Inserted !!') </script>");
                        }
                    }

                }
                finally { }
            }
        }
        #endregion
    }
}