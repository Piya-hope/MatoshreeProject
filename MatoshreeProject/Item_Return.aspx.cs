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
using iTextSharp.text.html.simpleparser;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Xml.Linq;
using iTextSharp.tool.xml;
using Image = iTextSharp.text.Image;
using iTextSharp.text.pdf.draw;
using ListItem = System.Web.UI.WebControls.ListItem;
using Font = iTextSharp.text.Font;
using iTextSharp.tool.xml.html.pdfelement;
using iText.Kernel.Pdf;
using System.IO.MemoryMappedFiles;
using System.Reflection;
using static iTextSharp.text.pdf.AcroFields;
using static iText.IO.Image.Jpeg2000ImageData;
#endregion

namespace MatoshreeProject
{
    public partial class Item_Return : System.Web.UI.Page
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
        string Remark;

        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;

        Phrase phrase = null;


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
        protected void GetStaffdetails()
        {
            try
            {
                UserId = Convert.ToInt32(Session["UserID"]);
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetStaffByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@Staff_ID", UserId);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtusername.Text = dt.Rows[0]["Full_Name"].ToString();
                        txtDesignation.Text = dt.Rows[0]["Role"].ToString();
                        txtEmail.Text = dt.Rows[0]["Email"].ToString();
                        txtPhoneNo.Text = dt.Rows[0]["PhoneNumber"].ToString();
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

        protected void BindProject()
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

        public DataTable ViewItemReturn()
        {
            DataTable dt = new DataTable();
            string projectname = ddlProjects.SelectedItem.Text;
            int projectID = Convert.ToInt32(ddlProjects.SelectedItem.Value);
            if (projectname == "Select Project")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Project!')", true);
            }
            else
            {

                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_DestributedProduct_DetailsByDepo", con))
                    {
                        ad.SelectCommand.CommandType = CommandType.StoredProcedure;

                        ad.SelectCommand.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
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

            }
            return dt;
        }
        public void Clear()
        {
            try
            {

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
                    command.Parameters.AddWithValue("@SubModule", "ItemReturn");
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
                            BindProject();
                            GetStaffdetails();

                            if (Create == "True")
                            {
                                btnReturn.Visible = true;
                                btnCancel.Visible = true;
                            }
                            else
                            {
                                btnReturn.Visible = false;
                                btnCancel.Visible = true;
                            }

                            if (Edit == "True")
                            {

                                //GridProduct.Columns[9].Visible = true;
                            }
                            else
                            {

                                //GridDepo.Columns[9].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                //GridDepo.Columns[10].Visible = true;
                            }
                            else
                            {

                                //GridDepo.Columns[10].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {

                            bindProjectEmpID();
                            GetStaffdetails();

                            if (Create == "True")
                            {
                                btnReturn.Visible = true;
                                btnCancel.Visible = true;
                            }
                            else
                            {
                                btnReturn.Visible = false;
                                btnCancel.Visible = true;
                            }

                            if (Edit == "True")
                            {

                                //GridDepo.Columns[9].Visible = true;
                            }
                            else
                            {

                                //GridDepo.Columns[9].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                //GridDepo.Columns[10].Visible = true;
                            }
                            else
                            {

                                //GridDepo.Columns[10].Visible = false;
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
                    lblMessage.Text = "Item Return Request Save Successfully";
                }
                else if (EdidDATA == "xcvfedit" && MSGdata == null)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Item Return Request Edit Successfully";
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

        #region " Events "
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
                            BindProject();
                            GetStaffdetails();
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
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    foreach (GridViewRow gvrow in GridProduct.Rows)
                    {
                        CheckBox chkItemReturn = (CheckBox)gvrow.FindControl("chkItemReturn");
                        CheckBox chkTrash1 = (CheckBox)gvrow.FindControl("chkTrash1");
                        if (chkItemReturn != null && chkItemReturn.Checked)
                        {
                            string ItemRetId = GridProduct.DataKeys[gvrow.RowIndex].Value.ToString();

                            Label lblProductName1 = (Label)gvrow.FindControl("lblProductName1");
                            Label lblProdId = (Label)gvrow.FindControl("lblProdId");
                            Label lblProductType1 = (Label)gvrow.FindControl("lblProductType1");

                            Label lblDepoName = (Label)gvrow.FindControl("lblDepoName");
                            Label lblDepoID1 = (Label)gvrow.FindControl("lblDepoID1");

                            TextBox txtQuantity1 = (TextBox)gvrow.FindControl("txtQuantity1");
                            TextBox txtTrashQnty1 = (TextBox)gvrow.FindControl("txtTrashQnty1");
                            Label lblQuantity1 = (Label)gvrow.FindControl("lblQuantity1");

                            TextBox ReturnReason1 = (TextBox)gvrow.FindControl("ReturnReason1");
                            TextBox txtTrashReason1 = (TextBox)gvrow.FindControl("txtTrashReason1");


                            Label lblRate1 = (Label)gvrow.FindControl("lblRate1");
                            Label lblTotalAmount1 = (Label)gvrow.FindControl("lblTotalAmount1");

                            Label lblCategory1 = (Label)gvrow.FindControl("lblCategory1");
                            Label lblcategoryId = (Label)gvrow.FindControl("lblcategoryId");

                            int ProjectID = Convert.ToInt32(ddlProjects.SelectedItem.Value);
                            int depoid = Convert.ToInt32(lblDepoID1.Text);
                            int ProQuantity = Convert.ToInt32(lblQuantity1.Text);
                            int ReturnQuantity = Convert.ToInt32(txtQuantity1.Text);

                            int InvProID = Convert.ToInt32(lblProdId.Text);
                            string ReturnItem;
                            if (chkTrash1 != null && chkTrash1.Checked)
                            {
                                ReturnItem = "false";
                            }
                            else
                            {
                                ReturnItem = "true";
                            }
                            if (ProQuantity == 0)
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Check Distribution Product In Stock/ OUT OF STOCK !')", true);
                            }
                            else if (ProQuantity >= ReturnQuantity)
                            {
                                SqlCommand cmd = new SqlCommand("SP_UpdateItemRequest", con1);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@ID", ItemRetId);
                                cmd.Parameters.AddWithValue("@DepoName", lblDepoName.Text);
                                cmd.Parameters.AddWithValue("@ProductType", lblProductType1.Text);
                                cmd.Parameters.AddWithValue("@DepoID", depoid);
                                cmd.Parameters.AddWithValue("@ProductID", InvProID);
                                cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                                cmd.Parameters.AddWithValue("@ProjectName", ddlProjects.SelectedItem.Text);
                                cmd.Parameters.AddWithValue("@ProductName", lblProductName1.Text);
                                cmd.Parameters.AddWithValue("@Quantity", ReturnQuantity);
                                cmd.Parameters.AddWithValue("@Rate", lblRate1.Text);
                                cmd.Parameters.AddWithValue("@ReturnItem", ReturnItem);
                                cmd.Parameters.AddWithValue("@Status", true);
                                cmd.Parameters.AddWithValue("@Category", lblCategory1.Text);
                                cmd.Parameters.AddWithValue("@CategoryID", lblcategoryId.Text);
                                cmd.Parameters.AddWithValue("@ReturnReason", ReturnReason1.Text);
                                cmd.Parameters.AddWithValue("@TrashReason", txtTrashReason1.Text);
                                cmd.Parameters.AddWithValue("@TrashQunty", txtTrashQnty1.Text);
                                cmd.Parameters.AddWithValue("@ProdStatus", chkItemReturn.Checked);
                                //cmd.Parameters.AddWithValue("@Handover", txtHandover.Text);
                                cmd.Parameters.AddWithValue("@TotalAmount", lblTotalAmount1.Text);
                                cmd.Parameters.AddWithValue("@RetItemBy", UserName);
                                cmd.Parameters.AddWithValue("@RetEmpID", Convert.ToInt32(UserId));
                                cmd.Parameters.AddWithValue("@RetStaffRole", Designation);
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
                                    Toasteralert.Visible = false;
                                    deleteToaster.Visible = true;
                                    lblMesDelete.Text = "Product Return Request Save Successfully";

                                }
                                else
                                {
                                    Toasteralert.Visible = false;
                                    deleteToaster.Visible = true;
                                    lblMesDelete.Text = "Product Return Request Not Save Successfully";
                                }
                                con1.Close();
                            }
                            else
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Already Have Product Return Request')", true);
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
        protected void GridProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

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
        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {



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
        protected void ddlProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string ProductType = ddlProductType.SelectedItem.Text;

                if (ProductType == "Select NA")
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        using (SqlDataAdapter ad = new SqlDataAdapter("SP_DestributedProduct_DetailsByProject", con))
                        {
                            ad.SelectCommand.CommandType = CommandType.StoredProcedure;


                            ad.SelectCommand.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
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

                }
                else if (ProductType == "OneTime")
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        using (SqlDataAdapter ad = new SqlDataAdapter("SP_DestributedProduct_DetailsByProdType", con))
                        {
                            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                            ad.SelectCommand.Parameters.AddWithValue("@ProductType", ddlProductType.SelectedItem.Text);
                            ad.SelectCommand.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
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

                }
                else
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        using (SqlDataAdapter ad = new SqlDataAdapter("SP_DestributedProduct_DetailsByProdType", con))
                        {
                            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                            ad.SelectCommand.Parameters.AddWithValue("@ProductType", ddlProductType.SelectedItem.Text);
                            ad.SelectCommand.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
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

        protected void chkTrash1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chkTrash = (CheckBox)sender;
                GridViewRow row = (GridViewRow)chkTrash.NamingContainer;
                int rowIndex = row.RowIndex;
                int id = Convert.ToInt32(GridProduct.DataKeys[rowIndex]["ID"]);
                bool isChecked = chkTrash.Checked;
                using (SqlConnection connection = new SqlConnection(strconnect))
                {

                    using (SqlCommand cmd = new SqlCommand("SP_ViewTrashProductDetails", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Trash", isChecked);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@created_by", UserName);

                        connection.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Item Added In Trash";
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Item Not Added In Trash";
                        }

                        connection.Close();
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
                    CheckBox checkBox = (CheckBox)row.FindControl("chkItemReturn");


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
        protected void ddlProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string projectname = ddlProjects.SelectedItem.Text;
                int projectID = Convert.ToInt32(ddlProjects.SelectedItem.Value);
                if (projectname == "Select Project")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Project!')", true);
                    lblprodType.Visible = false;
                    ddlProductType.Visible = false;
                }
                else
                {
                    lblprodType.Visible = true;
                    ddlProductType.Visible = true;
                    DataTable dt = new DataTable();
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        using (SqlDataAdapter ad = new SqlDataAdapter("SP_DestributedProduct_DetailsByProject", con))
                        {
                            ad.SelectCommand.CommandType = CommandType.StoredProcedure;

                            ad.SelectCommand.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {



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