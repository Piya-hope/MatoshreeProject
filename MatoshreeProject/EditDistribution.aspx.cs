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
using System.Diagnostics.Contracts;
using Newtonsoft.Json;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Security.Cryptography;
using static iTextSharp.tool.xml.html.HTML;
using System.Linq.Expressions;

#endregion;

namespace MatoshreeProject
{
    public partial class EditDistribution : System.Web.UI.Page
    {
        #region " Class Level Variable "

        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr, dr1, dr2, dr3;
        int Result, Result1, Result2, Result3;
        string result, result1, result2, result3;

        string Tenderid, Publish;
        int UserId;
        string UserName = "Trupti G", EmailID, Designation = "Admin", RoleType, Permission, DeptID;



        string Distribute;
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
        protected void bindProjectEmpID()
        {
            try
            {
                UserId = Convert.ToInt32(Session["UserID"]);
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetProjectByStaffID", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", UserId);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlProjects.DataSource = ds.Tables[0];
                    ddlProjects.DataTextField = "ProjectName";
                    ddlProjects.DataValueField = "ID";
                    ddlProjects.DataBind();
                    ddlProjects.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Project", "0"));
                  
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
        protected void bindDepoEmpID()
        {
            try
            {
                UserId = Convert.ToInt32(Session["UserID"]);
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetInventoryDepoByEmpID", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlDepo.DataSource = ds.Tables[0];
                    ddlDepo.DataTextField = "DepoName";
                    ddlDepo.DataValueField = "DepoID";
                    ddlDepo.DataBind();
                    ddlDepo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Depo", "0"));
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

        protected void bindProject1()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetProjectName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlProjects.DataSource = ds.Tables[0];
                    ddlProjects.DataTextField = "ProjectName";
                    ddlProjects.DataValueField = "ID";
                    ddlProjects.DataBind();
                    ddlProjects.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Project", "0"));
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

        public void GetProductbyDepo(int DEPOID)
        {
            
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad1 = new SqlDataAdapter("SP_GetStaffDepoAllocationByDepoID", con1))
                {
                    DataTable dtStaff = new DataTable();
                    ad1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    ad1.SelectCommand.Parameters.AddWithValue("@DepoID", ddlDepo.SelectedItem.Value);
                    ad1.Fill(dtStaff);
                    ddlStaff.DataSource = dtStaff;
                    ddlStaff.DataTextField = "StaffName";
                    ddlStaff.DataValueField = "Staff_ID";
                    ddlStaff.DataBind();
                    ddlStaff.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select StoreKeeper", "0"));

                }
            }


        }

        public DataTable ViewInvoProdByProjectAndDepo()
        {
            string ProjectID = HttpUtility.UrlDecode(Request.QueryString["Project"]);
            string DepoID = HttpUtility.UrlDecode(Request.QueryString["Depo"]);
            ddlProjects.SelectedItem.Value = ProjectID;
            int ProjectID1 = Convert.ToInt32(ddlProjects.SelectedItem.Value);
            GetDepoByProjectId(ProjectID1);

            ddlDepo.SelectedItem.Value = DepoID;
            int DEPOID = Convert.ToInt32(ddlDepo.SelectedItem.Value);
            GetProductbyDepo(DEPOID);

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_DistributionDetailsByProjectID&DepoID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 120;
                cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@DepoID", ddlDepo.SelectedItem.Value);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridProduct.DataSource = dt;
                    GridProduct.DataBind();
                    ddlProjects.SelectedItem.Value = dt.Rows[0]["ProjectID"].ToString();
                    ddlDepo.SelectedItem.Value = dt.Rows[0]["DepoID"].ToString();
                    ddlProjects.SelectedItem.Text = dt.Rows[0]["ProjectName"].ToString();
                    ddlDepo.SelectedItem.Text = dt.Rows[0]["DepoName"].ToString();
                    ddlStaff.SelectedItem.Text = dt.Rows[0]["SendBy"].ToString();
                    ddlWorkOrderNo.SelectedItem.Value = dt.Rows[0]["WorkOrderID"].ToString();
                    ddlWorkOrderNo.SelectedItem.Text = dt.Rows[0]["WorkOrderNumber"].ToString();
                    txtHandover.Text = dt.Rows[0]["Handover"].ToString();

                    foreach (GridViewRow row in GridProduct.Rows)
                    {
                        CheckBox chkInvDepopro = row.FindControl("chkInvDepopro") as CheckBox;
                        if (chkInvDepopro != null)
                        {
                            bool prodStatus = Convert.ToBoolean(dt.Rows[row.RowIndex]["ProdStatus"]);
                            chkInvDepopro.Checked = prodStatus;
                        }
                    }
                }
            }

            return dt;
        }

        protected void GetDepoByProjectId(int ProjectID1)
        {
            try
            {
                //int ProjectID= ProjectID1;                
                //ddlProjects.SelectedItem.Value = ProjectID1.ToString();
               
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewInventoryDepoProjectAllocationByProject", con))
                    {
                        DataTable dt = new DataTable();
                        ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                        ad.SelectCommand.Parameters.AddWithValue("@ProjectID", ProjectID1);
                        ad.Fill(dt);
                        ddlDepo.DataSource = dt;
                        ddlDepo.DataTextField = "DepoName1";
                        ddlDepo.DataValueField = "DepoID";
                        ddlDepo.DataBind();
                        ddlDepo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Depo", "0"));

                       
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

        protected void bindDepo()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetInventoryDepo", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlDepo.DataSource = ds.Tables[0];
                    ddlDepo.DataTextField = "DepoName";
                    ddlDepo.DataValueField = "DepoID";
                    ddlDepo.DataBind();
                    ddlDepo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Depo", "0"));
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

        protected void bindProductName()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetInvoProductName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlProdname.DataSource = ds.Tables[0];
                    ddlProdname.DataTextField = "ProductName";
                    ddlProdname.DataValueField = "ID";
                    ddlProdname.DataBind();
                    ddlProdname.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Product Name", "0"));
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

        public DataTable BindInvoProduct()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_DistributionDetails", con))
                {
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    ad.SelectCommand.Parameters.AddWithValue("@DepoID", ddlDepo.SelectedItem.Value);
                    ad.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        GridProduct.DataSource = dt;
                        GridProduct.DataBind();
                    }
                    else
                    {
                        dt.Rows.Add(dt.NewRow());
                        GridProduct.DataSource = dt;
                        GridProduct.DataBind();
                        int totalcolums = GridProduct.Rows[0].Cells.Count;
                    }
                }
            }

            return dt;
        }

        protected void bindStaff()
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
                    ddlStaff.DataSource = ds.Tables[0];
                    ddlStaff.DataTextField = "First_Name";
                    ddlStaff.DataValueField = "Staff_ID";
                    ddlStaff.DataBind();
                    ddlStaff.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select StoreKeeper", "0"));
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

        protected void BindWorkOrderNumber()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetWorkOrderNumber", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    DataRow firstRow;
                    firstRow = ds.NewRow();
                    int count1 = ds.Rows.Count;
                    int countTotal = count1 + 1;
                    firstRow["WorkOrderNumber"] = "NA";
                    firstRow["ID"] = countTotal;
                    ds.Rows.Add(firstRow);

                    ddlWorkOrderNo.DataSource = ds;
                    ddlWorkOrderNo.DataTextField = "WorkOrderNumber";
                    ddlWorkOrderNo.DataValueField = "ID";
                    ddlWorkOrderNo.DataBind();
                    ddlWorkOrderNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select WorkOrder No", "0"));
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

        #region " Event"
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
                            bindProject1();
                            BindWorkOrderNumber();
                            bindProductName();
                            ViewInvoProdByProjectAndDepo();
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
                                bindProjectEmpID();
                                BindWorkOrderNumber();
                                bindProductName();
                                ViewInvoProdByProjectAndDepo();
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

        protected void GridProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkInvDepopro = (CheckBox)e.Row.FindControl("chkInvDepopro");
                    TextBox txtQuantity1 = (TextBox)e.Row.FindControl("txtQuantity1");
                    Label lblInstock = (Label)e.Row.FindControl("lblInstock");
                    Label lblRemark1 = (Label)e.Row.FindControl("lblRemark1");
                    if (lblInstock.Text == "0" || string.IsNullOrEmpty(lblInstock.Text))
                    {
                        txtQuantity1.ReadOnly = true;
                        lblRemark1.Text = "Out Of Stock";
                        lblRemark1.ForeColor = System.Drawing.Color.Red;
                        chkInvDepopro.Enabled = false;
                    }
                    else
                    {
                        chkInvDepopro.Enabled = true;
                        lblRemark1.Text = "In Stock";
                        lblRemark1.ForeColor = System.Drawing.Color.Green;
                        txtQuantity1.ReadOnly = false;
                    }
                    //if (chkInvDepopro != null)
                    //{
                    //    bool prodStatus = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "ProdStatus"));
                    //    chkInvDepopro.Checked = prodStatus;
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

        protected void btnDistribute_Click(object sender, EventArgs e)
        {
            try
            {
                string DepoName = ddlDepo.SelectedItem.Text;
                int DepoID = Convert.ToInt32(ddlDepo.SelectedItem.Value);
                string StaffName = ddlStaff.SelectedItem.Text;
                int staffID = Convert.ToInt32(ddlStaff.SelectedItem.Value);

                if (DepoName == "Select Depo" || StaffName == "Select StoreKeeper")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Depo And Select Sale Agent')", true);
                }
                else
                {
                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {
                        foreach (GridViewRow gvrow in GridProduct.Rows)
                        {
                            CheckBox chkInvDepopro = (CheckBox)gvrow.FindControl("chkInvDepopro");
                            if (chkInvDepopro != null && chkInvDepopro.Checked)
                            {
                                string ProductID = GridProduct.DataKeys[gvrow.RowIndex].Value.ToString();
                                Label lblInventoryProdID1 = (Label)gvrow.FindControl("lblInventoryProdID1");
                                Label lblProductName1 = (Label)gvrow.FindControl("lblProductName1");
                                Label lblDepoName = (Label)gvrow.FindControl("lblDepoName");
                                TextBox txtQuantity1 = (TextBox)gvrow.FindControl("txtQuantity1");
                                Label lblInstock = (Label)gvrow.FindControl("lblInstock");
                                Label lblRate1 = (Label)gvrow.FindControl("lblRate1");
                                Label lblTotalAmount1 = (Label)gvrow.FindControl("lblTotalAmount1");
                                Label lblDepoID1 = (Label)gvrow.FindControl("lblDepoID1");
                                int ProjectID = Convert.ToInt32(ddlProjects.SelectedItem.Value);
                                int depoid = Convert.ToInt32(lblDepoID1.Text);
                                int ProductID1 = Convert.ToInt32(lblInventoryProdID1.Text);
                                int DisQnty = Convert.ToInt32(txtQuantity1.Text);
                                int Instock = Convert.ToInt32(lblInstock.Text);
                                int newQuantity = Instock - DisQnty;

                                if (Instock == 0)
                                {
                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Check Distribution Product In Stock/ OUT OF STOCK !')", true);
                                }
                                else if (Instock >= DisQnty)
                                {
                                    SqlCommand cmd = new SqlCommand("SP_SaveDistribution", con1);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@DepoName", lblDepoName.Text);
                                    cmd.Parameters.AddWithValue("@DepoID", ddlDepo.SelectedItem.Value);
                                    cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                                    cmd.Parameters.AddWithValue("@ProductID", ProductID1);
                                    cmd.Parameters.AddWithValue("@ProductName", lblProductName1.Text);
                                    cmd.Parameters.AddWithValue("@WorkOrderID", ddlWorkOrderNo.SelectedItem.Value);
                                    cmd.Parameters.AddWithValue("@WorkOrderNumber", ddlWorkOrderNo.SelectedItem.Text);
                                    cmd.Parameters.AddWithValue("@Quantity", DisQnty);
                                    cmd.Parameters.AddWithValue("@Rate", lblRate1.Text);
                                    cmd.Parameters.AddWithValue("@DepoStatus", true);
                                    cmd.Parameters.AddWithValue("@Status", true);
                                    cmd.Parameters.AddWithValue("@ProjectStatus", true);
                                    cmd.Parameters.AddWithValue("@ProdStatus", chkInvDepopro.Checked);
                                    cmd.Parameters.AddWithValue("@Handover", txtHandover.Text);
                                    cmd.Parameters.AddWithValue("@Instock", newQuantity);
                                    cmd.Parameters.AddWithValue("@TotalAmount", lblTotalAmount1.Text);
                                    cmd.Parameters.AddWithValue("@SendBy", ddlStaff.SelectedItem.Value);
                                    cmd.Parameters.AddWithValue("@DestributeBy", UserName);
                                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(UserId));
                                    cmd.Parameters.AddWithValue("@Designation", Designation);
                                    con1.Open();
                                    dr = cmd.ExecuteReader();
                                    while (dr.Read())
                                    {
                                        result = dr[0].ToString();
                                    }
                                    //dr.Close();
                                    Result = int.Parse(result);
                                    if (Result > 0)
                                    {
                                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Product Distributed Successfully!')", true);
                                    }
                                    else
                                    {
                                       // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Already Product Distributed Successfully')", true);
                                    }
                                    con1.Close();
                                }
                                else
                                {
                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Already Product Distributed Successfully')", true);
                                }
                            }

                           
                        }
                    }

                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        foreach (GridViewRow gvrow in GridProduct.Rows)
                        {
                            CheckBox chkInvDepopro = (CheckBox)gvrow.FindControl("chkInvDepopro");

                            if (chkInvDepopro != null && chkInvDepopro.Checked)
                            {
                                string ID = GridProduct.DataKeys[gvrow.RowIndex].Value.ToString();
                                Label lblInventoryProdID1 = (Label)gvrow.FindControl("lblInventoryProdID1");
                                Label lblItemId = (Label)gvrow.FindControl("LblItemID");
                                Label lblProductName1 = (Label)gvrow.FindControl("lblProductName1");
                                Label lbldesc1 = (Label)gvrow.FindControl("lbldesc1");
                                Label lblCategory1 = (Label)gvrow.FindControl("lblCategory1");
                                Label lblcategoryId = (Label)gvrow.FindControl("lblcategoryId");
                                Label lblProductType1 = (Label)gvrow.FindControl("lblProductType1");
                                Label lblDepoName = (Label)gvrow.FindControl("lblDepoName");
                                TextBox txtQuantity1 = (TextBox)gvrow.FindControl("txtQuantity1");
                                Label lblQuantity1 = (Label)gvrow.FindControl("lblQuantity1");
                                Label lblRate1 = (Label)gvrow.FindControl("lblRate1");
                                Label lblTotalAmount1 = (Label)gvrow.FindControl("lblTotalAmount1");
                                Label lblDepoID1 = (Label)gvrow.FindControl("lblDepoID1");
                                Label lblInstock = (Label)gvrow.FindControl("lblInstock");
                                int ProjectID = Convert.ToInt32(ddlProjects.SelectedItem.Value);
                                int depoid = Convert.ToInt32(lblDepoID1.Text);
                                int ProductID = Convert.ToInt32(lblInventoryProdID1.Text);
                                int ItemId = Convert.ToInt32(lblItemId.Text);
                                int Instock= Convert.ToInt32(lblInstock.Text);
                                int distributedQuantity = Convert.ToInt32(txtQuantity1.Text);
                                int newQuantity = Instock - distributedQuantity;
                                string Remark = (newQuantity == 0) ? "Out Of Stock" : "In Stock";
                                if(newQuantity > 0)
                                { 
                                using (SqlCommand cmd = new SqlCommand("SP_UpdateInventoryProd", con))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@ID", ProductID);
                                    cmd.Parameters.AddWithValue("@ProductName", lblProductName1.Text);
                                    cmd.Parameters.AddWithValue("@ProductType", lblProductType1.Text);
                                    cmd.Parameters.AddWithValue("@DepoID", lblDepoID1.Text);
                                    cmd.Parameters.AddWithValue("@Description", lbldesc1.Text);
                                    cmd.Parameters.AddWithValue("@Quantity", newQuantity);
                                    cmd.Parameters.AddWithValue("@Rate", lblRate1.Text);
                                    cmd.Parameters.AddWithValue("@TotalAmount", lblTotalAmount1.Text);
                                    cmd.Parameters.AddWithValue("@Category", lblCategory1.Text);
                                    cmd.Parameters.AddWithValue("@CategoryId", lblcategoryId.Text);
                                    cmd.Parameters.AddWithValue("@Remark", Remark);
                                    cmd.Parameters.AddWithValue("@Status", true);
                                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                                    cmd.Parameters.AddWithValue("@Created_by", UserName);
                                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                                    cmd.Parameters.AddWithValue("@ItemID", ItemId);
                                    cmd.Parameters.AddWithValue("@Designation", Designation);
                                    con.Open();
                                    int i = cmd.ExecuteNonQuery();
                                    if (i > 0)
                                    {
                                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Product Details Updated Successfully!')", true);
                                    }
                                    else
                                    {
                                       // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Product Details not Updated Successfully!')", true);
                                    }
                                    con.Close();
                                }
                                }
                                else
                                {
                                    using (SqlCommand cmd = new SqlCommand("SP_UpdateInventoryProd", con))
                                    {
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("@ID", ProductID);
                                        cmd.Parameters.AddWithValue("@ProductName", lblProductName1.Text);
                                        cmd.Parameters.AddWithValue("@ProductType", lblProductType1.Text);
                                        cmd.Parameters.AddWithValue("@DepoID", lblDepoID1.Text);
                                        cmd.Parameters.AddWithValue("@Description", lbldesc1.Text);
                                        cmd.Parameters.AddWithValue("@Quantity", 0);
                                        cmd.Parameters.AddWithValue("@Rate", lblRate1.Text);
                                        cmd.Parameters.AddWithValue("@TotalAmount", lblTotalAmount1.Text);
                                        cmd.Parameters.AddWithValue("@Category", lblCategory1.Text);
                                        cmd.Parameters.AddWithValue("@CategoryId", lblcategoryId.Text);
                                        cmd.Parameters.AddWithValue("@Remark", Remark);
                                        cmd.Parameters.AddWithValue("@Status", true);
                                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                                        cmd.Parameters.AddWithValue("@Created_by", UserName);
                                        cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                                        cmd.Parameters.AddWithValue("@ItemID", ItemId);
                                        cmd.Parameters.AddWithValue("@Designation", Designation);
                                        con.Open();
                                        int i = cmd.ExecuteNonQuery();
                                        if (i > 0)
                                        {
                                          //  this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Product Details Updated Successfully!')", true);
                                        }
                                        else
                                        {
                                          //  this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Product Details not Updated Successfully!')", true);
                                        }
                                        con.Close();
                                    }
                                }
                            }
                        }

                    }
                }
                string edit = "xcvfedit";
                Response.Redirect("~/Distribution.aspx?edit1=" + edit + "", false);

             
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
                    if (RowEx > 0)
                    {
                        // Error details saved successfully
                    }
                    else
                    {
                        // Error details not saved successfully
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Distribution.aspx", true);
        }

        protected void ddlDepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string DepoName = ddlDepo.SelectedItem.Text;
                int DepoID = Convert.ToInt32(ddlDepo.SelectedItem.Value);
                //--------------------------------BindDepoByProject&staff--------------------------------------//
                if (DepoName == "Select Depo")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Depo And Select Sale Agent')", true);
                }
                else
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        using (SqlDataAdapter ad = new SqlDataAdapter("SP_DistributionDetails", con))
                        {
                            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                            ad.SelectCommand.Parameters.AddWithValue("@DepoID", ddlDepo.SelectedItem.Value);
                            ad.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                GridProduct.DataSource = dt;
                                GridProduct.DataBind();
                            }
                            else
                            {
                                dt.Rows.Add(dt.NewRow());
                                GridProduct.DataSource = dt;
                                GridProduct.DataBind();
                                int totalcolums = GridProduct.Rows[0].Cells.Count;
                            }

                        }
                    }

                    //--------------------------------BindStaffByDepo--------------------------------------//


                    DataTable dtStaff = new DataTable();
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        using (SqlDataAdapter ad = new SqlDataAdapter("SP_GetStaffDepoAllocationByDepoID", con))
                        {
                            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                            ad.SelectCommand.Parameters.AddWithValue("@DepoID", ddlDepo.SelectedItem.Value);
                            ad.Fill(dtStaff);
                            ddlStaff.DataSource = dtStaff;
                            ddlStaff.DataTextField = "StaffName";
                            ddlStaff.DataValueField = "Staff_ID";
                            ddlStaff.DataBind();
                            ddlStaff.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select StoreKeeper", "0"));

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

        protected void ddlProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string projectname = ddlProjects.SelectedItem.Text;
                int projectID = Convert.ToInt32(ddlProjects.SelectedItem.Value);
                if (projectname == "Select Project")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Project!')", true);
                }
                else
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewInventoryDepoProjectAllocationByProject", con))
                        {
                            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                            ad.SelectCommand.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                            ad.Fill(dt);
                            ddlDepo.DataSource = dt;
                            ddlDepo.DataTextField = "DepoName1";
                            ddlDepo.DataValueField = "DepoID";
                            ddlDepo.DataBind();
                            ddlDepo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Depo", "0"));
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

        protected void AllchkInvPro_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerCheckBox = (CheckBox)sender;
                GridView gridView = (GridView)headerCheckBox.NamingContainer.NamingContainer;

                foreach (GridViewRow row in gridView.Rows)
                {
                    CheckBox checkBox = (CheckBox)row.FindControl("chkInvDepopro");


                    checkBox.Checked = headerCheckBox.Checked;
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