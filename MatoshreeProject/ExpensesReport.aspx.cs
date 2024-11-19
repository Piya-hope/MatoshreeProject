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

using Color = System.Drawing.Color;
using TableCell = System.Web.UI.WebControls.TableCell;
using System.Web.SessionState;
#endregion


namespace MatoshreeProject
{
    public partial class ExpensesReport : System.Web.UI.Page
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
        public void ClearGridview()
        {
            GridViewStaffReport.DataSource = null;
            GridViewStaffReport.DataBind();
            GridViewStaffReport.EmptyDataText = "No Records found";

            GridViewOfficeReport.DataSource = null;
            GridViewOfficeReport.DataBind();
            GridViewOfficeReport.EmptyDataText = "No Records found";

            GridViewStaffReport.DataSource = null;
            GridViewStaffReport.DataBind();
            GridViewStaffReport.EmptyDataText = "No Records found";
            ViewState["DataOffice"] = null;
        }
        public void Clear()
        {
            txtEndDate.Text = string.Empty;
            txtStartDate.Text = string.Empty;

            ddlSubCategory.SelectedIndex = 0;
            ddlExpensesCategory.SelectedIndex = 0;

            ddlExpensesType.SelectedIndex = 0;

           
        }
        #endregion

        #region " Public Functions "
        protected void bindSubCategory()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetExpSubCategory", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlExpensesCategory.DataSource = ds.Tables[0];
                    ddlExpensesCategory.DataTextField = "Sub_Category_Name";
                    ddlExpensesCategory.DataValueField = "ID";
                    ddlExpensesCategory.DataBind();
                    ddlExpensesCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select SubCategory", "0"));
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

        protected void BindCategoryName()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetExpCategory", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlExpensesCategory.DataSource = ds.Tables[0];
                    ddlExpensesCategory.DataTextField = "Category_Name";
                    ddlExpensesCategory.DataValueField = "ID";
                    ddlExpensesCategory.DataBind();
                    ddlExpensesCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Category", "0"));
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
                    command.Parameters.AddWithValue("@SubModule", "Reports Expenses"); 
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
                            BindCategoryName();
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
                            //    GridViewAllExpenses.Columns[9].Visible = true;
                            //}
                            //else
                            //{
                            //    GridViewAllExpenses.Columns[9].Visible = false;
                            //}

                            //if (Delete == "True")
                            //{

                            //    GridViewAllExpenses.Columns[10].Visible = true;
                            //}
                            //else
                            //{
                            //    GridViewAllExpenses.Columns[10].Visible = false;
                            //}
                        }
                        else if (View == "True")
                        {
                            BindCategoryName();

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
                            //    GridOfficeExpenses.Columns[9].Visible = true;
                            //}
                            //else
                            //{
                            //    GridOfficeExpenses.Columns[9].Visible = false;
                            //}

                            //if (Delete == "True")
                            //{

                            //    GridOfficeExpenses.Columns[10].Visible = true;
                            //}
                            //else
                            //{
                            //    GridOfficeExpenses.Columns[10].Visible = false;
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
                            BindCategoryName();
                            //DataTable dt = new DataTable();
                            //GridViewOfficeReport.DataSource = dt;
                            //GridViewOfficeReport.DataBind();
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
                                //DataTable dt = new DataTable();
                                //GridViewOfficeReport.DataSource = dt;
                                //GridViewOfficeReport.DataBind();
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

        protected void ddlExpensesCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int categoryid = Convert.ToInt32(ddlExpensesCategory.SelectedValue);
                string catName = ddlExpensesCategory.SelectedItem.Text;
                lblExpensesNamee.Text = catName;
                if (catName == "Project Purchase")
                {
                    lblExpensesSubCategory.Text = "Project ";
                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_GetProjectName", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlSubCategory.DataSource = ds.Tables[0];
                        ddlSubCategory.DataTextField = "ProjectName";
                        ddlSubCategory.DataValueField = "ID";
                        ddlSubCategory.DataBind();
                        ddlSubCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("ALL Project", "0"));
                    }
                }
                else if (catName == "Staff Expenses")
                {
                    lblExpensesSubCategory.Text = "Staff Name";
                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_GetStaffName", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlSubCategory.DataSource = ds.Tables[0];
                        ddlSubCategory.DataTextField = "First_Name";
                        ddlSubCategory.DataValueField = "Staff_ID";
                        ddlSubCategory.DataBind();
                        ddlSubCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Staff", "0"));
                    }

                }
                else
                {
                    lblExpensesSubCategory.Text = "Expenses SubCategory";
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd1 = new SqlCommand("SP_GetSubCategorybycatid", con);
                    cmd1.Connection = con;
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@Exp_Category_ID", categoryid);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlSubCategory.DataSource = ds.Tables[0];
                        ddlSubCategory.DataTextField = "Sub_Category_Name";
                        ddlSubCategory.DataValueField = "ID";
                        ddlSubCategory.DataBind();
                        ddlSubCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select SubCategory", "0"));
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
       
        protected void GridViewAllExpenses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //foreach (GridViewRow gridviedrow in GridViewAllExpenses.Rows)
            //{  // string  Status = Convert.ToString(e.Row.Cells[8].Text);
            //    Label lblExp_id1 = (Label)gridviedrow.FindControl("lblExp_id1");

            //    Label lblExp_Name1 = (Label)gridviedrow.FindControl("lblExp_Name1");
            //    Label lblRelatedTo1 = (Label)gridviedrow.FindControl("lblRelatedTo1");
            //    Label lblExp_Category1 = (Label)gridviedrow.FindControl("lblExp_Category1");
            //    Label lblfor1 = (Label)gridviedrow.FindControl("lblfor1");
            //    Label lblExp_Date1 = (Label)gridviedrow.FindControl("lblExp_Date1");
            //    // Label lblExp_Reference1 = (Label)gridviedrow.FindControl("lblExp_Reference1");
            //    Label lblExp_Type1 = (Label)gridviedrow.FindControl("lblExp_Type1");
                
            //    string RelatedTo = ((Label)gridviedrow.FindControl("lblRelatedTo1")).Text;

            //    if (RelatedTo == "Project Purchase")
            //    {
            //        lblRelatedTo1.Text= RelatedTo;
               
            //    }
            //    else if(RelatedTo == "Office Expenses")
            //    {
            //        lblRelatedTo1.Text = RelatedTo;

            //    }
            //    else if (RelatedTo == "Staff Expenses")
            //    {
            //        lblRelatedTo1.Text = RelatedTo;

            //    }
            //    else
            //    {
                    
            //    }




            //}
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btnExportReport_Click(object sender, EventArgs e)
        {
            try
            {
                //DataTable dt = (DataTable)ViewState["DataOffice"];
                //if (ViewState["DataOffice"] != null)
                //{
                if (lblExpensesNamee.Text == "Office Expenses")
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ExpensesReport_" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    using (StringWriter sw = new StringWriter())
                    {
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        //To Export all pages
                        GridViewOfficeReport.AllowPaging = false;
                        DataTable dt = (DataTable)ViewState["DataOffice"];
                        //int PIs = GridView1.PageIndex;
                        //DataTable dt = GetDeviceDetails(PIs);
                        DataTable dt2 = new DataTable();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            dt2.Columns.Add(dt.Columns[i].ColumnName, typeof(string));
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt2.ImportRow(dt.Rows[i]);

                        }
                        this.GridViewOfficeReport.DataSource = dt2;
                        this.GridViewOfficeReport.DataBind();
                        GridViewOfficeReport.HeaderRow.BackColor = Color.White;
                        foreach (TableCell cell in GridViewOfficeReport.HeaderRow.Cells)
                        {
                            cell.BackColor = GridViewOfficeReport.HeaderStyle.BackColor;
                        }
                        foreach (GridViewRow row in GridViewOfficeReport.Rows)
                        {
                            row.BackColor = Color.White;
                            foreach (TableCell cell in row.Cells)
                            {
                                if (row.RowIndex % 2 == 0)
                                {
                                    cell.BackColor = GridViewOfficeReport.AlternatingRowStyle.BackColor;
                                }
                                else
                                {
                                    cell.BackColor = GridViewOfficeReport.RowStyle.BackColor;
                                }
                                cell.CssClass = "textmode";
                            }
                        }
                        GridViewOfficeReport.RenderControl(hw);
                        //style to format numbers to string
                        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                        Response.Write(style);
                        Response.Output.Write(sw.ToString());
                        Response.Flush();
                        Response.End();

                    }
                }
                else if (lblExpensesNamee.Text == "Project Purchase")
                {

                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ExpensesReport_" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    using (StringWriter sw = new StringWriter())
                    {
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        //To Export all pages
                        GridViewProjectReport.AllowPaging = false;
                        DataTable dt = (DataTable)ViewState["DataProject"];
                        //int PIs = GridView1.PageIndex;
                        //DataTable dt = GetDeviceDetails(PIs);
                        DataTable dt2 = new DataTable();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            dt2.Columns.Add(dt.Columns[i].ColumnName, typeof(string));
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt2.ImportRow(dt.Rows[i]);

                        }
                        this.GridViewProjectReport.DataSource = dt2;
                        this.GridViewProjectReport.DataBind();
                        GridViewProjectReport.HeaderRow.BackColor = Color.White;
                        foreach (TableCell cell in GridViewProjectReport.HeaderRow.Cells)
                        {
                            cell.BackColor = GridViewProjectReport.HeaderStyle.BackColor;
                        }
                        foreach (GridViewRow row in GridViewProjectReport.Rows)
                        {
                            row.BackColor = Color.White;
                            foreach (TableCell cell in row.Cells)
                            {
                                if (row.RowIndex % 2 == 0)
                                {
                                    cell.BackColor = GridViewProjectReport.AlternatingRowStyle.BackColor;
                                }
                                else
                                {
                                    cell.BackColor = GridViewProjectReport.RowStyle.BackColor;
                                }
                                cell.CssClass = "textmode";
                            }
                        }
                        GridViewProjectReport.RenderControl(hw);
                        //style to format numbers to string
                        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                        Response.Write(style);
                        Response.Output.Write(sw.ToString());
                        Response.Flush();
                        Response.End();

                    }
                }
                else if (lblExpensesNamee.Text == "Staff Expenses")
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ExpensesReport_" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    using (StringWriter sw = new StringWriter())
                    {
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        //To Export all pages
                        GridViewStaffReport.AllowPaging = false;
                        DataTable dt = (DataTable)ViewState["DataStaff"];
                        //int PIs = GridView1.PageIndex;
                        //DataTable dt = GetDeviceDetails(PIs);
                        DataTable dt2 = new DataTable();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            dt2.Columns.Add(dt.Columns[i].ColumnName, typeof(string));
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt2.ImportRow(dt.Rows[i]);

                        }
                        this.GridViewStaffReport.DataSource = dt2;
                        this.GridViewStaffReport.DataBind();
                        GridViewStaffReport.HeaderRow.BackColor = Color.White;
                        foreach (TableCell cell in GridViewStaffReport.HeaderRow.Cells)
                        {
                            cell.BackColor = GridViewStaffReport.HeaderStyle.BackColor;
                        }
                        foreach (GridViewRow row in GridViewStaffReport.Rows)
                        {
                            row.BackColor = Color.White;
                            foreach (TableCell cell in row.Cells)
                            {
                                if (row.RowIndex % 2 == 0)
                                {
                                    cell.BackColor = GridViewStaffReport.AlternatingRowStyle.BackColor;
                                }
                                else
                                {
                                    cell.BackColor = GridViewStaffReport.RowStyle.BackColor;
                                }
                                cell.CssClass = "textmode";
                            }
                        }
                        GridViewStaffReport.RenderControl(hw);
                        //style to format numbers to string
                        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                        Response.Write(style);
                        Response.Output.Write(sw.ToString());
                        Response.Flush();
                        Response.End();

                    }
                }
                else { }

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

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnViewRerort_Click(object sender, EventArgs e)
        {
            try
            {
                string Searchproject,SearchCategory,SearchExpType,SearchSubCat,ProjectID,StaffID,SearchStaff,To,From;

                if (txtEndDate.Text == "")
                {
                    From = null;
                    To = null;
                    
                }
                else
                {
                    From = txtStartDate.Text;
                    To = txtEndDate.Text;
                  
                }

                if (ddlExpensesCategory.SelectedIndex == 0)
                {
                    SearchCategory = null;
                }
                else
                {
                    SearchCategory = ddlExpensesCategory.SelectedItem.Text;
                }

                if (ddlExpensesType.SelectedIndex == 0)
                {
                    SearchExpType = null;
                }
                else
                {
                    SearchExpType = ddlExpensesType.SelectedItem.Text;
                }

                if (SearchCategory == "Office Expenses")
                {
                    if (ddlSubCategory.SelectedIndex == 0)
                    {
                        SearchSubCat = null;
                        Searchproject = null;
                        ProjectID = null;
                        StaffID = null;
                        SearchStaff = null;
                    }
                    else
                    {
                        SearchSubCat = ddlSubCategory.SelectedItem.Text;

                        Searchproject = null;
                        ProjectID = null;
                        StaffID = null;
                        SearchStaff = null;
                    }

                    GridViewOfficeReport.Visible = true;
                    GridViewProjectReport.Visible = false;
                    GridViewStaffReport.Visible = false;
                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {
                        SqlCommand com = new SqlCommand("SP_SearchExpensesReports", con1);
                        com.CommandTimeout = 120;
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@SearchByFromDate", From);
                        com.Parameters.AddWithValue("@SearchByToDate", To);
                        com.Parameters.AddWithValue("@SearchProject", Searchproject);

                        com.Parameters.AddWithValue("@SearchStaff", SearchStaff);
                        com.Parameters.AddWithValue("@SearchReltedTo", SearchCategory);
                        com.Parameters.AddWithValue("@ProjectID", ProjectID);

                        com.Parameters.AddWithValue("@Exp_SubCategory", SearchSubCat);
                        com.Parameters.AddWithValue("@Exp_StaffID", StaffID);
                        com.Parameters.AddWithValue("@SearchByExpType", SearchExpType);
                        SqlDataAdapter da = new SqlDataAdapter(com);
                        DataTable dtOffice = new DataTable();
                        da.Fill(dtOffice);
                        if (dtOffice.Rows.Count > 0)
                        {
                            GridViewOfficeReport.DataSource = dtOffice;
                            GridViewOfficeReport.DataBind();
                            ViewState["DataOffice"] = dtOffice;
                        }
                        else
                        {
                            dtOffice.Rows.Add(dtOffice.NewRow());
                            GridViewOfficeReport.DataSource = dtOffice;
                            GridViewOfficeReport.DataBind();
                            int totalcolums = GridViewOfficeReport.Rows[0].Cells.Count;
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Not Found!')", true);
                        }
                        Clear();
                    }
                }

                else if (SearchCategory == "Project Purchase")
                {
                    if (ddlSubCategory.SelectedIndex == 0)
                    {
                        SearchSubCat = null;
                        Searchproject = null;
                        ProjectID = null;
                        StaffID = null;
                        SearchStaff = null;
                    }
                    else
                    {
                        SearchSubCat = null;

                        Searchproject = ddlSubCategory.SelectedItem.Text;
                        ProjectID = ddlSubCategory.SelectedItem.Value;
                        StaffID = null;
                        SearchStaff = null;

                    }

                    GridViewOfficeReport.Visible = false;
                    GridViewProjectReport.Visible = true;
                    GridViewStaffReport.Visible = false;
                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {
                        SqlCommand com = new SqlCommand("SP_SearchExpensesReports", con1);
                        com.CommandTimeout = 120;
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@SearchByFromDate", From);
                        com.Parameters.AddWithValue("@SearchByToDate", To);
                        com.Parameters.AddWithValue("@SearchProject", Searchproject);

                        com.Parameters.AddWithValue("@SearchStaff", SearchStaff);
                        com.Parameters.AddWithValue("@SearchReltedTo", SearchCategory);
                        com.Parameters.AddWithValue("@ProjectID", ProjectID);

                        com.Parameters.AddWithValue("@Exp_SubCategory", SearchSubCat);
                        com.Parameters.AddWithValue("@Exp_StaffID", StaffID);
                        com.Parameters.AddWithValue("@SearchByExpType", SearchExpType);
                        SqlDataAdapter da = new SqlDataAdapter(com);
                        DataTable dtProject = new DataTable();
                        da.Fill(dtProject);
                        if (dtProject.Rows.Count > 0)
                        {
                            GridViewProjectReport.DataSource = dtProject;
                            GridViewProjectReport.DataBind();
                            ViewState["DataProject"] = dtProject;
                        }
                        else
                        {
                            dtProject.Rows.Add(dtProject.NewRow());
                            GridViewProjectReport.DataSource = dtProject;
                            GridViewProjectReport.DataBind();
                            int totalcolums = GridViewProjectReport.Rows[0].Cells.Count;
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Not Found!')", true);

                        }
                       Clear();
                    }
                }
                else if (SearchCategory == "Staff Expenses")
                {
                    if (ddlSubCategory.SelectedIndex == 0)
                    {
                        SearchSubCat = null;
                        Searchproject = null;
                        ProjectID = null;
                        StaffID = null;
                        SearchStaff = null;
                    }
                    else
                    {
                        SearchSubCat = null;
                        Searchproject = null;
                        ProjectID = null;
                        StaffID = ddlSubCategory.SelectedItem.Value;
                        SearchStaff = ddlSubCategory.SelectedItem.Text; ;

                    }

                    GridViewOfficeReport.Visible = false;
                    GridViewProjectReport.Visible = false;
                    GridViewStaffReport.Visible = true;
                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {
                        SqlCommand com = new SqlCommand("SP_SearchExpensesReports", con1);
                        com.CommandTimeout = 120;
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@SearchByFromDate", From);
                        com.Parameters.AddWithValue("@SearchByToDate", To);
                        com.Parameters.AddWithValue("@SearchProject", Searchproject);

                        com.Parameters.AddWithValue("@SearchStaff", SearchStaff);
                        com.Parameters.AddWithValue("@SearchReltedTo", SearchCategory);
                        com.Parameters.AddWithValue("@ProjectID", ProjectID);

                        com.Parameters.AddWithValue("@Exp_SubCategory", SearchSubCat);
                        com.Parameters.AddWithValue("@Exp_StaffID", StaffID);
                        com.Parameters.AddWithValue("@SearchByExpType", SearchExpType);
                        SqlDataAdapter da = new SqlDataAdapter(com);
                        DataTable dtStaff = new DataTable();
                        da.Fill(dtStaff);
                        if (dtStaff.Rows.Count > 0)
                        {
                            GridViewStaffReport.DataSource = dtStaff;
                            GridViewStaffReport.DataBind();
                            ViewState["DataStaff"] = dtStaff;

                        }
                        else
                        {
                            dtStaff.Rows.Add(dtStaff.NewRow());
                            GridViewStaffReport.DataSource = dtStaff;
                            GridViewStaffReport.DataBind();
                            int totalcolums = GridViewStaffReport.Rows[0].Cells.Count;
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Not Found!')", true);

                        }
                        Clear();
                    }
                }
                else
                {

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



        //protected void bindproject()
        //{
        //    try
        //    {
        //        SqlConnection conn = new SqlConnection(strconnect);
        //        SqlCommand cmd = new SqlCommand("SP_GetProjectName", conn);
        //        cmd.Connection = conn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //        {
        //            DataSet ds = new DataSet();
        //            sda.Fill(ds);
        //            ddlProject.DataSource = ds.Tables[0];
        //            ddlProject.DataTextField = "ProjectName";
        //            ddlProject.DataValueField = "ID";
        //            ddlProject.DataBind();
        //            ddlProject.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Project", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SqlConnection DeviceCon = new SqlConnection(strconnect);
        //        string ErrorMessgage = ex.Message;
        //        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
        //        string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
        //        string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
        //        Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();

        //    }
        //}

        //public DataTable viewExpensesReport()
        //{
        //    DataTable table = new DataTable();
        //    using (SqlConnection con = new SqlConnection(strconnect))
        //    {
        //        using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewExpensesReport", con))
        //        {
        //            ad.Fill(table);
        //            GridViewAllExpenses.DataSource = table;
        //            GridViewAllExpenses.DataBind();
        //            //GridViewAllExpenses.AutoGenerateDeleteButton = false;
        //        }
        //    }
        //    return table;
        //}

        #endregion


    }
}