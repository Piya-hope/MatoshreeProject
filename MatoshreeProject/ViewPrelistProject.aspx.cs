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
using iTextSharp.tool.xml.html.pdfelement;
using ZXing;
using iTextSharp.text;
//using itextsharp.Kernel.Events;
//using iText.Kernel.Pdf;
//using static iTextSharp.text.TabStop;
//using iText.Forms.Form.Element;

#endregion

namespace MatoshreeProject
{
    public partial class ViewPrelistProject : System.Web.UI.Page
    {
        #region " Class Level Variable "

        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
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
        protected void bindDepo()
        {
            try
            {
                UserId = Convert.ToInt32(Session["UserID"]);
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetInventoryDepobyProject", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectID", lblProjectID1.Text);
                cmd.Parameters.AddWithValue("@staffID", UserId);
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



        public DataTable ViewPreList()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewProjectPrelist", con))
                {
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    ad.Fill(dt);
                    GridPrelist.DataSource = dt;
                    GridPrelist.DataBind();
                }
            }
            return dt;
        }

        public DataTable ViewPreListProduct()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewProjectPrelistDetails", con))
                {
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    ad.Fill(dt);
                    GridProduct.DataSource = dt;
                    GridProduct.DataBind();
                }
            }
            return dt;
        }



        //--------------------------------Permission---------------------------------------//


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

                            bindDepo();
                            ViewPreList();
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
                                ViewPreList();
                                bindDepo();
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
                using (SqlConnection UserCon = new SqlConnection(strconnect))
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
        }

        protected void GridPrelist_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void btnViewList_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string ProjectID, Project, SendBy;
    
                var rows = GridPrelist.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ProjectID = ((Label)rows[rowindex].FindControl("lblProjectID")).Text;
                Project = ((Label)rows[rowindex].FindControl("lblProjectName1")).Text;
                SendBy = ((Label)rows[rowindex].FindControl("lblSendBy1")).Text;

                lblProjectName.Text = Project;
                lblProjectID1.Text = ProjectID;
                lblSendByName.Text = SendBy;

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

        protected void ddlDepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewPreListProduct();
        }

        protected void GridProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Find the DropDownList in the Row.
                    Label lblProductName1 = (Label)e.Row.FindControl("lblProductName1");
                    Label lblProductType1 = (Label)e.Row.FindControl("lblProductType1");
                    Label lblQuantity1 = (Label)e.Row.FindControl("lblQuantity1");
                    Label lblCategory1 = (Label)e.Row.FindControl("lblCategory1");
                    Label lblcategoryId = (Label)e.Row.FindControl("lblcategoryId");
                    TextBox txtDistQuantity1 = (TextBox)e.Row.FindControl("txtQuantity1");
                    Label lblInstock = (Label)e.Row.FindControl("lblInstock");
                    Label lblRate1 = (Label)e.Row.FindControl("lblRate1");
                    Label lblTotalAmount1 = (Label)e.Row.FindControl("lblTotalAmount1");
                    Label lblRemark1 = (Label)e.Row.FindControl("lblRemark1");
                    Label lblItemID = (Label)e.Row.FindControl("lblItemID");
                    using (SqlConnection conn = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_ViewInventoryByProductAndDepo", conn);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Product", lblProductName1.Text);
                        cmd.Parameters.AddWithValue("@DepoID", ddlDepo.SelectedItem.Value);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                lblProductType1.Text = dt.Rows[0]["ProductType"].ToString();
                                lblCategory1.Text = dt.Rows[0]["Category"].ToString();
                                lblcategoryId.Text = dt.Rows[0]["CategoryID"].ToString();
                                txtDistQuantity1.Text = dt.Rows[0]["Quantity"].ToString();
                                lblInstock.Text = dt.Rows[0]["Instock"].ToString();
                                lblRate1.Text = dt.Rows[0]["Rate"].ToString();
                                lblTotalAmount1.Text = dt.Rows[0]["TotalAmount"].ToString();
                                lblRemark1.Text = dt.Rows[0]["Remark"].ToString();
                                lblItemID.Text = dt.Rows[0]["ItemID"].ToString();
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
        #endregion
    }
}