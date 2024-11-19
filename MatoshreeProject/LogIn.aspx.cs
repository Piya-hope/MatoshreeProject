#region " Class Description "


#endregion

#region " Primary Namespaces "

using System;
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

#endregion

namespace MatoshreeProject
{
    public partial class LogIn : System.Web.UI.Page
    {

        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlConnection DeviceCon = new SqlConnection();

        #endregion


        #region " Public Variables "

        #endregion

        #region " Public Functions " 

        public void ClearAll()
        {
            try
            {
                txtEmailAddress.Text = string.Empty;
                txtPassword.Text = string.Empty;
                ChkRemberMe1.Checked = false;

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
                }
            }
            catch (Exception ex)
            {
                string username = "LogInUser";
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

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                string UserName = txtEmailAddress.Text;
                string PassWord = txtPassword.Text;

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd1 = new SqlCommand("SP_AdminAuthentication", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                cmd1.Parameters.AddWithValue("@EmailID", txtEmailAddress.Text);
                cmd1.Parameters.AddWithValue("@Password", txtPassword.Text);
                sda1.Fill(dt1);
                if (dt1.Rows.Count == 1)
                {
                    string Designation = dt1.Rows[0]["Role"].ToString();
                    if (Designation.Equals("Administrator"))
                    {
                        string EmpId = dt1.Rows[0]["UserID"].ToString();
                        string EmpName = dt1.Rows[0]["UserName"].ToString();
                        string EmailID = dt1.Rows[0]["EmailID"].ToString();
                        string CreatedBy = dt1.Rows[0]["CreateBy"].ToString();
                        string Permission = dt1.Rows[0]["webAccess"].ToString();
                        string DeptID = "0";
                        //-----------------RemberMe Code-----------------------//
                        if (ChkRemberMe1.Checked == true)
                        {
                            Response.Cookies["EmailID"].Value = txtEmailAddress.Text;
                            Response.Cookies["Password"].Value = txtPassword.Text;
                            Response.Cookies["EmailID"].Expires = DateTime.Now.AddDays(8);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(8);
                        }
                        else
                        {
                            Response.Cookies["EmailID"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                        }

                        if (Designation.Equals("Administrator"))
                        {
                            Session["LoginType"] = "Administrator";
                        }
                        Session["UserID"] = EmpId;
                        Session["UserName"] = EmpName;
                        Session["CreateBy"] = CreatedBy;
                        Session["Role"] = Designation;
                        Session["EmailID"] = EmailID;
                        Session["Permission"] = Permission;
                        Session["DeptID"] = DeptID;
                        Response.Redirect("~/Dashboard.aspx", false);
                    }
                    else//SAME USER TYPE YA ERROR
                    {
                        string EmpId = dt1.Rows[0]["UserID"].ToString();
                        string EmpName = dt1.Rows[0]["UserName"].ToString();
                        string EmailID = dt1.Rows[0]["EmailID"].ToString();
                        string CreatedBy = dt1.Rows[0]["CreateBy"].ToString();
                        string Permission = dt1.Rows[0]["webAccess"].ToString();
                        string DeptID = dt.Rows[0]["DeptID"].ToString();
                        //-----------------RemberMe Code-----------------------//
                        if (ChkRemberMe1.Checked == true)
                        {
                            Response.Cookies["EmailID"].Value = txtEmailAddress.Text;
                            Response.Cookies["Password"].Value = txtPassword.Text;
                            Response.Cookies["EmailID"].Expires = DateTime.Now.AddDays(8);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(8);
                        }
                        else
                        {
                            Response.Cookies["EmailID"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                        }

                        Session["LoginType"] = Designation;
                        Session["UserID"] = EmpId;
                        Session["UserName"] = EmpName;
                        Session["CreateBy"] = CreatedBy;
                        Session["Role"] = Designation;
                        Session["EmailID"] = EmailID;
                        Session["Permission"] = Permission;
                        Session["DeptID"] = DeptID;
                        Response.Redirect("~/Dashboard.aspx", false);
                    }

                }
                else //dt.cont=0//all staff//ALL STAFF Going To Access 
                {
                    ////////////////////////////---------------------HR---------------------------///////////////////
                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_UserAuthentication", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@Username", UserName);
                    cmd.Parameters.AddWithValue("@Password", PassWord);
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string Designation = dt.Rows[0]["Role"].ToString();
                       

                        if (Designation != null )
                        {
                            string EmpId = dt.Rows[0]["Staff_ID"].ToString();
                            string EmpName = dt.Rows[0]["UserName"].ToString();
                            string EmailID = dt.Rows[0]["Email"].ToString();
                            string CreatedBy = dt.Rows[0]["CreateBy"].ToString();
                            string Permission = dt.Rows[0]["webAccess"].ToString();
                            string DeptID = dt.Rows[0]["DeptID"].ToString();
                            //-----------------RemberMe Code-----------------------//
                            if (ChkRemberMe1.Checked == true)
                            {
                                Response.Cookies["EmailID"].Value = txtEmailAddress.Text;
                                Response.Cookies["Password"].Value = txtPassword.Text;
                                Response.Cookies["EmailID"].Expires = DateTime.Now.AddDays(8);
                                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(8);
                            }
                            else
                            {
                                Response.Cookies["EmailID"].Expires = DateTime.Now.AddDays(-1);
                                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                            }

                            Session["LoginType"] = Designation;
                            Session["UserID"] = EmpId;
                            Session["UserName"] = EmpName;
                            Session["CreateBy"] = CreatedBy;
                            Session["Role"] = Designation;
                            Session["EmailID"] = EmailID;
                            Session["Permission"] = Permission;
                            Session["DeptID"] = DeptID;
                            Response.Redirect("~/Dashboard.aspx", false);
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please check EmailID Or Password')", true);
                        }
                    }
                }

                ClearAll();
            }
            catch (Exception ex)
            {
                string username = "LogInUser";
                SqlConnection Con = new SqlConnection(strconnect);
                string ErrorMessgage = ex.Message;
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", Con);
                cmdex.CommandType = CommandType.StoredProcedure;
                cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                cmdex.Parameters.AddWithValue("@Method", method);
                cmdex.Parameters.AddWithValue("@CreatedBy", username);// Session UserLogIn
                Con.Open();
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

        protected void btnForgetPassWord_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/ForgetPassword.aspx", false);
            }
            catch (Exception ex)
            {
                string username = "LogInUser";
                SqlConnection Con = new SqlConnection(strconnect);
                string ErrorMessgage = ex.Message;
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", Con);
                cmdex.CommandType = CommandType.StoredProcedure;
                cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                cmdex.Parameters.AddWithValue("@Method", method);
                cmdex.Parameters.AddWithValue("@CreatedBy", username);// Session UserLogIn
                Con.Open();
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
    }
}