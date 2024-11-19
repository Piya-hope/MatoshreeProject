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
    public partial class EditRole : System.Web.UI.Page
    {
        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result, Role;

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
        public void GetRoleDetails()
        {
            try
            {
                int count = 0;
                Role = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                txt_Role_Name.Text = Role;
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("[SP_GetRolesByRoleName]", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@RoleName", Role);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridRoleEdit.DataSource = dt;
                    GridRoleEdit.DataBind();
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
                            GetRoleDetails();
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
                                GetRoleDetails();
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

        protected void GridRoleEdit_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0; // Initialize count variable

                foreach (GridViewRow gvrow in GridRoleEdit.Rows)
                {
                    CheckBox chkGlobalView = (CheckBox)gvrow.FindControl("GlobalChkView");
                    CheckBox chkView = (CheckBox)gvrow.FindControl("ChkView");
                    CheckBox chkEdit = (CheckBox)gvrow.FindControl("ChkEdit");
                    CheckBox chkCreate = (CheckBox)gvrow.FindControl("ChkCreate");
                    CheckBox chkDelete = (CheckBox)gvrow.FindControl("ChkDelete");

                    if (chkView != null && chkView.Checked || chkGlobalView != null && chkGlobalView.Checked)
                    {
                        count++;
                    }               
                }

                if (count > 0)
                {
                    foreach (GridViewRow gvrow in GridRoleEdit.Rows)
                    {
                        //string roleID = GridViewAuto.DataKeys[gvrow.RowIndex].Value.ToString();
                        CheckBox chkGlobalView = (CheckBox)gvrow.FindControl("GlobalChkView");
                        CheckBox chkView = (CheckBox)gvrow.FindControl("ChkView");
                        CheckBox chkEdit = (CheckBox)gvrow.FindControl("ChkEdit");
                        CheckBox chkCreate = (CheckBox)gvrow.FindControl("ChkCreate");
                        CheckBox chkDelete = (CheckBox)gvrow.FindControl("ChkDelete");
                        string Global;
                        string View;
                        string Edit;
                        string Create;
                        string Delete;

                        if (chkGlobalView != null && chkGlobalView.Checked == true)
                        {
                            Global = "true";
                        }
                        else
                        {
                            Global = "false";
                        }

                        if (chkView != null && chkView.Checked==true)
                        {
                            View = "true";
                        }
                        else
                        {
                            View = "false";
                        }


                        if (chkEdit != null && chkEdit.Checked==true)
                        {
                            Edit = "true";
                        }
                        else
                        {
                            Edit = "false";
                        }


                        if (chkCreate != null && chkCreate.Checked==true)
                        {
                            Create = "true";
                        }
                        else
                        {
                            Create = "false";
                        }


                        if (chkDelete != null && chkDelete.Checked==true)
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

                        SqlConnection con = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_UpdateRoles", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RoleName", txt_Role_Name.Text);
                        cmd.Parameters.AddWithValue("@GlobalView", Global);
                        cmd.Parameters.AddWithValue("@View", View);
                        cmd.Parameters.AddWithValue("@Edit", Edit);
                        cmd.Parameters.AddWithValue("@Create", Create);
                        cmd.Parameters.AddWithValue("@Delete", Delete);
                        cmd.Parameters.AddWithValue("@PageID", ID);
                        cmd.Parameters.AddWithValue("@WebPageName", WebPage); 
                        cmd.Parameters.AddWithValue("@Createby", UserName);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected < 0)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Role Details Updated Successfully!')", true);
                            Response.Redirect("~/Roles.aspx", false);
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Role Details Not Updated Successfully!')", true);
                        }

                        con.Close();

                    }

                }
                
            }
            catch (Exception ex)
            {
                string ErrorMessgage = ex.Message;
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                SqlConnection DeviceCon = new SqlConnection(strconnect);
                SqlCommand cmdex11 = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                cmdex11.CommandType = CommandType.StoredProcedure;
                cmdex11.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                cmdex11.Parameters.AddWithValue("@ErrorLine", lineNumber);
                cmdex11.Parameters.AddWithValue("@ErrorPath", pagename);
                cmdex11.Parameters.AddWithValue("@Method", method);
                cmdex11.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                DeviceCon.Open();
                int RowEx11 = cmdex11.ExecuteNonQuery();
                if (RowEx11 < 0)
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

       

        protected void btn_Close_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Roles.aspx", false);
        }

        protected void ChkView_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                Boolean ChkView;
                var rows = GridRoleEdit.Rows;
                CheckBox btn = (CheckBox)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ChkView = ((CheckBox)rows[rowindex].FindControl("ChkView")).Checked;
                CheckBox chkGlobalview1 = (CheckBox)rows[rowindex].FindControl("GlobalChkView");

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

        protected void GlobalChkView_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                Boolean ChkGlobal;
                var rows = GridRoleEdit.Rows;
                CheckBox btn = (CheckBox)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ChkGlobal = ((CheckBox)rows[rowindex].FindControl("GlobalChkView")).Checked;
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

        protected void chkAllGlobal_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chkAllGlobal = (CheckBox)GridRoleEdit.HeaderRow.FindControl("chkAllGlobal");
                CheckBox chkAllView = (CheckBox)GridRoleEdit.HeaderRow.FindControl("chkAllView");
                foreach (GridViewRow row in GridRoleEdit.Rows)
                {

                    CheckBox ChkGlobal = ((CheckBox)row.FindControl("GlobalChkView"));
                    CheckBox chkview1 = ((CheckBox)row.FindControl("ChkView"));
                    CheckBox ChkEdit = ((CheckBox)row.FindControl("ChkEdit"));
                    CheckBox ChkCreate = ((CheckBox)row.FindControl("ChkCreate"));
                    CheckBox ChkDelete = ((CheckBox)row.FindControl("ChkDelete"));

                    if (chkAllGlobal.Checked == true)
                    {
                        chkAllView.Enabled = false;
                        chkAllView.Checked = false;
                        chkview1.Checked = false;
                        ChkGlobal.Checked = true;
                    }
                    else
                    {
                        chkAllView.Enabled = true;
                        chkAllView.Checked = true;
                        chkview1.Checked = true;
                        ChkGlobal.Checked = false;
                    }

                    //if (chkAllGlobal.Checked == true)
                    //{
                    //    chkAllView.Checked = false;
                    //    chkAllView.Enabled = true;
                    //    chkview1.Enabled = false;
                    //    chkview1.Checked = false;
                    //}
                    //else
                    //{
                    //    chkAllView.Checked = true;
                    //    chkAllView.Enabled = false;
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
        }

        protected void chkAllView_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chkAllGlobal = (CheckBox)GridRoleEdit.HeaderRow.FindControl("chkAllGlobal");
                CheckBox chkAllView = (CheckBox)GridRoleEdit.HeaderRow.FindControl("chkAllView");
                foreach (GridViewRow row in GridRoleEdit.Rows)
                {
                    CheckBox ChkGlobal = ((CheckBox)row.FindControl("GlobalChkView"));
                    CheckBox chkview1 = ((CheckBox)row.FindControl("ChkView"));
                    CheckBox ChkEdit = ((CheckBox)row.FindControl("ChkEdit"));
                    CheckBox ChkCreate = ((CheckBox)row.FindControl("ChkCreate"));
                    CheckBox ChkDelete = ((CheckBox)row.FindControl("ChkDelete"));

                    if (chkAllView.Checked == true)
                    {
                        chkAllGlobal.Enabled = false;
                        chkAllGlobal.Checked = false;
                        chkview1.Checked = true;
                        ChkGlobal.Checked = false;
                    }
                    else
                    {
                        chkAllGlobal.Enabled = true;
                        chkAllGlobal.Checked = true;
                        chkview1.Checked = false;
                        ChkGlobal.Checked = true;
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

        protected void chkAllEdit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chkAllGlobal = (CheckBox)GridRoleEdit.HeaderRow.FindControl("chkAllGlobal");
                CheckBox chkAllView = (CheckBox)GridRoleEdit.HeaderRow.FindControl("chkAllView");
                CheckBox chkAllEdit = (CheckBox)GridRoleEdit.HeaderRow.FindControl("chkAllEdit");
                foreach (GridViewRow row in GridRoleEdit.Rows)
                {
                    CheckBox ChkGlobal = ((CheckBox)row.FindControl("GlobalChkView"));
                    CheckBox chkview1 = ((CheckBox)row.FindControl("ChkView"));
                    CheckBox ChkEdit = ((CheckBox)row.FindControl("ChkEdit"));
                    CheckBox ChkCreate = ((CheckBox)row.FindControl("ChkCreate"));
                    CheckBox ChkDelete = ((CheckBox)row.FindControl("ChkDelete"));

                    if (chkAllView.Checked == true || chkAllGlobal.Checked == true)
                    {
                        if (chkAllEdit.Checked == true)
                        {
                            ChkEdit.Checked = true;
                        }
                        //else
                        //{
                        //    ChkEdit.Checked = false;
                        //}
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Choose View OR Global View Permission!')", true);
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

        protected void chkAllCreate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chkAllGlobal = (CheckBox)GridRoleEdit.HeaderRow.FindControl("chkAllGlobal");
                CheckBox chkAllView = (CheckBox)GridRoleEdit.HeaderRow.FindControl("chkAllView");
                CheckBox chkAllCreate = (CheckBox)GridRoleEdit.HeaderRow.FindControl("chkAllCreate");
                foreach (GridViewRow row in GridRoleEdit.Rows)
                {
                    CheckBox ChkGlobal = ((CheckBox)row.FindControl("GlobalChkView"));
                    CheckBox chkview1 = ((CheckBox)row.FindControl("ChkView"));
                    CheckBox ChkEdit = ((CheckBox)row.FindControl("ChkEdit"));
                    CheckBox ChkCreate = ((CheckBox)row.FindControl("ChkCreate"));
                    CheckBox ChkDelete = ((CheckBox)row.FindControl("ChkDelete"));

                    if (chkAllView.Checked == true || chkAllGlobal.Checked == true)
                    {
                        if (chkAllCreate.Checked == true)
                        {
                            ChkCreate.Checked = true;
                        }
                        //else
                        //{
                        //    ChkEdit.Checked = false;
                        //}
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Choose View OR Global View Permission!')", true);
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

        protected void chkAllDelete_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chkAllGlobal = (CheckBox)GridRoleEdit.HeaderRow.FindControl("chkAllGlobal");
                CheckBox chkAllView = (CheckBox)GridRoleEdit.HeaderRow.FindControl("chkAllView");
                CheckBox chkAllDelete = (CheckBox)GridRoleEdit.HeaderRow.FindControl("chkAllDelete");
                foreach (GridViewRow row in GridRoleEdit.Rows)
                {
                    CheckBox ChkGlobal = ((CheckBox)row.FindControl("GlobalChkView"));
                    CheckBox chkview1 = ((CheckBox)row.FindControl("ChkView"));
                    CheckBox ChkEdit = ((CheckBox)row.FindControl("ChkEdit"));
                    CheckBox ChkCreate = ((CheckBox)row.FindControl("ChkCreate"));
                    CheckBox ChkDelete = ((CheckBox)row.FindControl("ChkDelete"));

                    if (chkAllView.Checked == true || chkAllGlobal.Checked == true)
                    {
                        if (chkAllDelete.Checked == true)
                        {
                            ChkDelete.Checked = true;
                        }
                        //else
                        //{
                        //    ChkEdit.Checked = false;
                        //}
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Choose View OR Global View Permission!')", true);
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
        #endregion
    }
}