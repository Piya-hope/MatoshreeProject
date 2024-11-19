#region " Class Description "


#endregion

#region " Primary Namespaces "

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#endregion

#region " Additional Namespaces "

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Text;
using System.Net;
using System.Net.Mail;
#endregion


namespace MatoshreeProject
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        #region " Class Level Variable "

        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result;
        #endregion

        #endregion

        #region " Public Variables "
        int UserId;
        string UserName, EmailID, Designation;
        string EmailIDURL;
        #endregion

        #region " Public Functions " 
        public void ClearAll()
        {
            try
            {
                txtPassword.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;
            }
            catch (Exception ex)
            {
                //diverror.Visible = true;
                //lblMessage1.Text = Convert.ToString(ex);
            }
        }

        //---------------------------------------------------------------------
        // Small Logo Preloader Logo
        //---------------------------------------------------------------------
        public void getImageSmallLogoPreloaderLogo()
        {
            try
            {
                //Small Logo and Preloader Logo 
                using (SqlConnection UserCon1 = new SqlConnection(strconnect))
                {

                    SqlCommand cmd = new SqlCommand("SP_Getaimagelogousingfor", UserCon1);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ImageFor", "SmallIconLogo");
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string imgname = dt.Rows[0]["ImageName"].ToString();
                        string Extension = dt.Rows[0]["Extension"].ToString();
                        string imgpath = dt.Rows[0]["ImageFilePath"].ToString();

                        preloaderImg.Src = imgpath;//M.png

                    }
                }
            }
            catch (Exception ex)
            {
                string username = "LogInUser";
                string ErrorMessgage = ex.Message;
                SqlConnection con2 = new SqlConnection(strconnect);
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", con2);
                cmdex.CommandType = CommandType.StoredProcedure;
                cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                cmdex.Parameters.AddWithValue("@Method", method);
                cmdex.Parameters.AddWithValue("@CreatedBy", username); //Session UserLogIn
                con2.Open();
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


        //---------------------------------------------------------------------
        // Text Logo
        //---------------------------------------------------------------------
        public void getImagesidebarTextLogo()
        {
            try
            {
                //Sidebar Text Logo 
                using (SqlConnection UserCon1 = new SqlConnection(strconnect))
                {

                    SqlCommand cmd = new SqlCommand("SP_Getaimagelogousingfor", UserCon1);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ImageFor", "TextLogo");
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string imgname = dt.Rows[0]["ImageName"].ToString();
                        string Extension = dt.Rows[0]["Extension"].ToString();
                        string imgpath = dt.Rows[0]["ImageFilePath"].ToString();

                        textlogo1.Src = imgpath; //MI Logo
                        textlogo2.Src = imgpath; //MI Logo
                    }
                }
            }
            catch (Exception ex)
            {
                string username = "LogInUser";
                string ErrorMessgage = ex.Message;
                SqlConnection con2 = new SqlConnection(strconnect);
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", con2);
                cmdex.CommandType = CommandType.StoredProcedure;
                cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                cmdex.Parameters.AddWithValue("@Method", method);
                cmdex.Parameters.AddWithValue("@CreatedBy", username); //Session UserLogIn
                con2.Open();
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

        //-------------------------------------------------------------//
        //  Sidebar Logo
        //------------------------------------------------------------//
        public void getImagesidebarLogo()
        {
            try
            {
                //Sidebar Logo 
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_Getaimagelogousingfor", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ImageFor", "SidebarLogo");
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string imgname = dt.Rows[0]["ImageName"].ToString();
                        string Extension = dt.Rows[0]["Extension"].ToString();
                        string imgpath = dt.Rows[0]["ImageFilePath"].ToString();

                        smlogo1.Src = imgpath; //MI Logo 2

                    }
                }
            }
            catch (Exception ex)
            {
                string username = "LogInUser";
                string ErrorMessgage = ex.Message;
                SqlConnection con2 = new SqlConnection(strconnect);
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", con2);
                cmdex.CommandType = CommandType.StoredProcedure;
                cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                cmdex.Parameters.AddWithValue("@Method", method);
                cmdex.Parameters.AddWithValue("@CreatedBy", username); //Session UserLogIn
                con2.Open();
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

        #region " Private Functions "

        #endregion

        #region " Event "
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    getImagesidebarTextLogo();
                    getImagesidebarLogo();
                    getImageSmallLogoPreloaderLogo();

                    EmailIDURL = HttpUtility.UrlDecode(Request.QueryString["EmailID"]);
                    lblUserEmailIDurl.Text = EmailIDURL;
                }
            }
            catch (Exception ex)
            {
                string username = "admin3";
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
                cmdex.Parameters.AddWithValue("@CreatedBy", username); //Session UserLogIn
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
            finally
            {

            }
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UPDATEAdminPassword", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", lblUserEmailIDurl.Text);
                cmd.Parameters.AddWithValue("@Password", txtConfirmPassword.Text);
                con.Open();
                int Result = cmd.ExecuteNonQuery();
                if (Result < 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password Reset Successfully!')", true);
                    //  Response.Redirect("~/Projects.aspx", false);
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password Not Reset Successfully!')", true);
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
                cmdex.Parameters.AddWithValue("@CreatedBy", lblUserEmailIDurl.Text); //Session UserLogIn
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
    }
}