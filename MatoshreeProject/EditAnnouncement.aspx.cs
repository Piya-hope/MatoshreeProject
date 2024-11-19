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
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using Image = iTextSharp.text.Image;
using iTextSharp.text.pdf.draw;
using ListItem = System.Web.UI.WebControls.ListItem;
using Font = iTextSharp.text.Font;
//using iText.Kernel.Events;
//using iText.Kernel.Pdf;
//using static iTextSharp.text.TabStop;
//using iText.Forms.Form.Element;
using static iTextSharp.text.pdf.PdfDocument;

#endregion

namespace MatoshreeProject
{
    public partial class EditAnnouncement : System.Web.UI.Page
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
        public void GetbyAnnouncementID()
        {
            try
            {
                string ID = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                lblAnnouid.Text = ID;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetbyAnnouncementID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@id", lblAnnouid.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtsubject1.Text = dt.Rows[0]["name"].ToString();
                        txt_messages.Text = dt.Rows[0]["message"].ToString();

                        string client = dt.Rows[0]["show_to_users"].ToString();
                       
                        if (client != null)
                        {
                            chkclient.Checked = true;
                        }
                        else
                        {
                            chkclient.Checked = false;
                        }

                        string staff = dt.Rows[0]["show_to_staff"].ToString();
                       
                        if (staff != null)
                        {
                            chkstaff.Checked = true;
                        }
                        else
                        {
                            chkstaff.Checked = false;
                        }

                        string name = dt.Rows[0]["show_name"].ToString();
                        if (name != null)
                        {
                            chkname.Checked = true;
                        }
                        else
                        {
                            chkname.Checked = false;
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

        public void Clear()
        {
            txtsubject1.Text = string.Empty;
            txt_messages.Text = string.Empty;
            chkclient.Checked = false;
            chkname.Checked = false;
            chkstaff.Checked = false;
        }

        #endregion

        #region "Event"
        
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
                            GetbyAnnouncementID();
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
                                GetbyAnnouncementID();
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

        protected void btnclose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Announcement.aspx");
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkclient.Checked == true)
                {
                    chkclient.Text = "Show to client";
                }
                else
                {
                    chkclient.Text = "";
                }

                if (chkstaff.Checked == true)
                {
                    chkstaff.Text = "Show to staff";
                }
                else
                {
                    chkstaff.Text = "";
                }
                
                if (chkname.Checked == true)
                {
                    chkname.Text = UserName;
                }
                else
                {
                    chkname.Text = "";
                }

                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand UserCommand = new SqlCommand("SP_UpdateAnnouncement", UserCon);//store procedure
                UserCommand.Connection = UserCon;
                UserCommand.CommandType = CommandType.StoredProcedure;
                UserCommand.Parameters.AddWithValue("@id", lblAnnouid.Text);
                UserCommand.Parameters.AddWithValue("@name", txtsubject1.Text);
                UserCommand.Parameters.AddWithValue("@message", txt_messages.Text);
                UserCommand.Parameters.AddWithValue("@show_to_users", chkclient.Text);
                UserCommand.Parameters.AddWithValue("@show_to_staff", chkstaff.Text);
                UserCommand.Parameters.AddWithValue("@show_name", chkname.Text);
                UserCommand.Parameters.AddWithValue("@user_id", UserId);
                UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                UserCommand.Parameters.AddWithValue("@Designation", Designation);
                UserCommand.Parameters.AddWithValue("@created_by", UserName);
                UserCon.Open();
                int i = UserCommand.ExecuteNonQuery();
                UserCon.Close();
                if (i < 0)
                {
                    string edit = "xcvfedit";
                    Response.Redirect("~/Announcement.aspx?edit1=" + edit + "", false);
             
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Announcement Details NOT Updated Successfully";

                }
                Clear();
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