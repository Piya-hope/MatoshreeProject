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
    public partial class Roles : System.Web.UI.Page
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
        //-----------------------------Partner By EmpID--------------------------------------//
        public DataTable ViewRoleByEmpID(int UserID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewRolesByGroupByEmpID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", UserID);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridRole.DataSource = table;
                GridRole.DataBind();
                ViewState["Data"] = table;
            }
            return table;
        }
        //---------------------------------------------------------------------//
        public DataTable ViewRole()
        {
            DataTable table1 = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewRolesByGroup", con))
                {
                    ad.Fill(table1);
                    GridRole.DataSource = table1;
                    GridRole.DataBind();
                    ViewState["Data"] = table1;
                }
            }
            return table1;
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
                    command.Parameters.AddWithValue("@SubModule", "Roles");
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
                            ViewRole();

                            if (Create == "True")
                            {
                                addnew.Visible = true;
                            }
                            else
                            {
                                addnew.Visible = false;
                            }

                            if (Edit == "True")
                            {
                                GridRole.Columns[2].Visible = true;
                            }
                            else
                            {
                                GridRole.Columns[2].Visible = false;
                            }

                            if (Delete == "True")
                            {
                                GridRole.Columns[3].Visible = true;
                            }
                            else
                            {
                                GridRole.Columns[3].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {
                            ViewRoleByEmpID(UserId);

                            if (Create == "True")
                            {
                                addnew.Visible = true;
                            }
                            else
                            {
                                addnew.Visible = false;
                            }

                            if (Edit == "True")
                            {
                                GridRole.Columns[2].Visible = true;
                            }
                            else
                            {
                                GridRole.Columns[2].Visible = false;
                            }

                            if (Delete == "True")
                            {
                                GridRole.Columns[3].Visible = true;
                            }
                            else
                            {
                                GridRole.Columns[3].Visible = false;
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

        public void GetMessageFromModules()
        {
            try
            {
                string MSGdata = HttpUtility.UrlDecode(Request.QueryString["svd1"]);
                string EdidDATA = HttpUtility.UrlDecode(Request.QueryString["edit1"]);
                if (MSGdata == "fgsave123q" && EdidDATA == null)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Vendor Details Save Successfully";
                }
                else if (EdidDATA == "xcvfedit" && MSGdata == null)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Vendor Details Edit Successfully";
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

        #region " Event "
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["LoginType"] != null)
                {
                    RoleType = Session["LoginType"].ToString();
                    Designation = Session["Role"].ToString();
                    //branch change
                    if (Session["LoginType"].ToString() == "Administrator")
                    {
                        UserId = Convert.ToInt32(Session["UserID"]);
                        UserName = Session["UserName"].ToString();
                        EmailID = Session["EmailID"].ToString();
                        Designation = Session["Role"].ToString();
                        DeptID = Session["DeptID"].ToString();

                        if (!IsPostBack)
                        {
                            ViewRole();
                            GetMessageFromModules();
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
                                GetMessageFromModules();
                            }
                        }
                        else
                        {
                            Response.Redirect("~/permission.html", true);
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

        protected void btn_New_Role_Click(object sender, EventArgs e)
        {
            Response.Redirect("New_Roles.aspx");
        }

        protected void Btn_Export_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewRolesExportPages", con))
                        {
                            DataTable dt = new DataTable();
                            ad.Fill(dt);

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                Response.Clear();
                                Response.Buffer = true;
                                Response.ContentType = "application/ms-excel";
                                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "RoleAndAccess_Details " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));

                                // Response.AddHeader("Content-Disposition", "attachment;filename=Tender_Details.xls");

                                Response.Charset = " ";

                                // Create a new DataTable with only the desired columns
                                DataTable dtExport = new DataTable();
                                dtExport.Columns.Add("ID");
                                dtExport.Columns.Add("RoleName");
                                dtExport.Columns.Add("WebPageName");
                                dtExport.Columns.Add("Global");
                                dtExport.Columns.Add("View");
                                dtExport.Columns.Add("Create");
                                dtExport.Columns.Add("Edit");
                                dtExport.Columns.Add("Delete");
                                dtExport.Columns.Add("Createdby");

                                // Copy the data from the original DataTable to the export DataTable
                                foreach (DataRow row in dt.Rows)
                                {
                                    DataRow newRow = dtExport.NewRow();
                                    newRow["ID"] = row["ID"];
                                    newRow["RoleName"] = row["RoleName"];
                                    newRow["WebPageName"] = row["WebPageName"];
                                    newRow["Global"] = row["GlobalView"];
                                    newRow["View"] = row["View"];
                                    newRow["Create"] = row["Create"];
                                    newRow["Edit"] = row["Edit"];
                                    newRow["Delete"] = row["Delete"];
                                    newRow["Createdby"] = row["Createdby"];

                                    dtExport.Rows.Add(newRow);
                                }

                                StringWriter sw = new StringWriter();
                                HtmlTextWriter htw = new HtmlTextWriter(sw);

                                // Create a GridView to help render the data
                                GridView gridView = new GridView();
                                gridView.DataSource = dtExport;
                                gridView.DataBind();

                                gridView.RenderControl(htw);
                                Response.Write(sw.ToString());
                                Response.End();
                            }
                        }
                    }
                }
                else if (RoleType == Designation)
                {
                    DataTable dt = (DataTable)ViewState["Data"];

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "RoleAndAccess_Details " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));

                        Response.Charset = " ";

                        // Create a new DataTable with only the desired columns
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("RoleName");
                        dtExport.Columns.Add("WebPageName");
                        dtExport.Columns.Add("Global");
                        dtExport.Columns.Add("View");
                        dtExport.Columns.Add("Create");
                        dtExport.Columns.Add("Edit");
                        dtExport.Columns.Add("Delete");
                        dtExport.Columns.Add("Createdby");

                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["ID"];
                            newRow["RoleName"] = row["RoleName"];
                            newRow["WebPageName"] = row["WebPageName"];
                            newRow["Global"] = row["GlobalView"];
                            newRow["View"] = row["View"];
                            newRow["Create"] = row["Create"];
                            newRow["Edit"] = row["Edit"];
                            newRow["Delete"] = row["Delete"];
                            newRow["Createdby"] = row["Createdby"];

                            dtExport.Rows.Add(newRow);
                        }

                        StringWriter sw = new StringWriter();
                        HtmlTextWriter htw = new HtmlTextWriter(sw);

                        // Create a GridView to help render the data
                        GridView gridView = new GridView();
                        gridView.DataSource = dtExport;
                        gridView.DataBind();

                        gridView.RenderControl(htw);
                        Response.Write(sw.ToString());
                        Response.End();
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

        protected void Btn_Reload_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    ViewRole();
                }
                else if (RoleType == Designation)
                {
                    StaffOperationPermission();
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
            finally { }
        }

        protected void GridRole_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridRole.Rows)
                {
                    Label lblCount = (Label)gridviedrow.FindControl("lblCount");
                    Label lblRoleName1 = (Label)gridviedrow.FindControl("lblRoleName1");

                    string Count;
                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_GetRoleUserCount", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@RoleName", lblRoleName1.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Count = dt.Rows[0]["TotalRoleUser"].ToString();
                        lblCount.Text = Count;
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

        protected void btnEditRole_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string tableID;
                var rows = GridRole.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                tableID = ((Label)rows[rowindex].FindControl("lblRoleName1")).Text;

                Response.Redirect("~/EditRole.aspx?ID=" + tableID + "", false);
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

        protected void btnDeleteRole_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    DeviceCon = new SqlConnection(strconnect);
                    string tableID;
                    var rows = GridRole.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    tableID = ((Label)rows[rowindex].FindControl("lblRoleName1")).Text;

                    SqlCommand cmd = new SqlCommand("SP_DeleteRoles", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleName", tableID);
                    cmd.Parameters.AddWithValue("@Createdby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Role Details Deleted Successfully";
                        GridRole.EditIndex = -1;
                        ViewRole();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Role Details Not Deleted";
                    }
                   
                }
                else if (RoleType == Designation)
                {
                    DeviceCon = new SqlConnection(strconnect);
                    string tableID;
                    var rows = GridRole.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    tableID = ((Label)rows[rowindex].FindControl("lblRoleName1")).Text;

                    SqlCommand cmd = new SqlCommand("SP_DeleteRolesForEmpID", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleName", tableID);
                    cmd.Parameters.AddWithValue("@Createdby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Role Details Deleted Successfully";
                        GridRole.EditIndex = -1;

                        StaffOperationPermission();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Role Details Not Deleted";
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
            finally { }
        }

        #endregion

    }
}