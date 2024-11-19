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

using System.Web.UI.DataVisualization.Charting;
using System.Runtime.InteropServices.ComTypes;
using Org.BouncyCastle.Utilities;

using Org.BouncyCastle.Asn1.X509;
using CheckBox = System.Web.UI.WebControls.CheckBox;


using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.pdf.draw;
using Font = iTextSharp.text.Font;
using Color = iTextSharp.text.BaseColor;

#endregion;

namespace MatoshreeProject
{
    public partial class ActivityLogs : System.Web.UI.Page
    {
        #region " Class Level Variable "
        string strconnect = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
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

        #region " Protected Functions "
        public void BindActivityBelong()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetActivityBelong", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlBelong.DataSource = ds.Tables[0];
                    ddlBelong.DataTextField = "ActivityBelong";
                    ddlBelong.DataValueField = "ActivityBelong";
                    ddlBelong.DataBind();
                    ddlBelong.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select  ActivityBelong", "0"));
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
        public void BindActivityUserName()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetActivityUserName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlActivity.DataSource = ds.Tables[0];
                    ddlActivity.DataTextField = "UserID";
                    ddlActivity.DataValueField = "UserID";
                    ddlActivity.DataBind();
                    ddlActivity.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select UseName", "0"));
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

        public void Clear()
        {

            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            ddlBelong.SelectedIndex = 0;
            ddlActivity.SelectedIndex = 0;
            ddlRelatedTo.SelectedIndex = 0;
            ViewActivityReportDetails();
        }
        #endregion

        #region " Private Functions "
        private static void DrawLine(iTextSharp.text.pdf.PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(Color.BLACK);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.Colspan = 4;
            cell.BorderColor = Color.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 3f;
            cell.PaddingTop = 0f;
            return cell;
        }
        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = Color.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 4f;
            cell.PaddingTop = 2f;
            return cell;
        }
        #endregion

        #region " Public Functions "
        public void GetCompanyAddress()
        {
            try
            {

                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetCompanyDetailsByID", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lbladdCompany11.Text = dt.Rows[0]["Company_Name"].ToString() + ",";
                    lbladdress11.Text = dt.Rows[0]["Address"].ToString();
                    lblcompanyaddCity1.Text = dt.Rows[0]["City"].ToString() + ",";
                    lblcompanyaddDistrict1.Text = dt.Rows[0]["District"].ToString() + ",";
                    lblcompanyaddState1.Text = dt.Rows[0]["State"].ToString() + ",";
                    lblcompanyaddCountry1.Text = "India" + ",";
                    lblcompanyaddZIPCode11.Text = dt.Rows[0]["Zip_Code"].ToString() + ",";
                    lblphoneNo1.Text = dt.Rows[0]["Phone"].ToString() + ".";
                    lblVatNo1.Text = dt.Rows[0]["VAT_Number"].ToString() + ",";
                    lblGSTNo1A.Text = dt.Rows[0]["GST_NO"].ToString() + ",";
                    Image1.ImageUrl = dt.Rows[0]["Company_Logo"].ToString();
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
            finally
            {
            }
        }

        //public void Clear()
        //{SP_GetActivityType

        //    txtStartDate.Text = string.Empty;
        //    txtEndDate.Text = string.Empty;
        //    ddlCustomer.SelectedIndex = 0;
        //    ddlProject.SelectedIndex = 0;
        //    ddlInvoiceNumber.SelectedIndex = 0;
        //   /ViewPaymentReportDetails();
        //}


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

                        if (!IsPostBack)
                        {
                            BindActivityBelong();
                            BindActivityUserName();

                            ViewActivityReportDetails();
                            GetCompanyAddress();

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
                                BindActivityBelong();
                                BindActivityUserName();

                                ViewActivityReportEmpID(UserId);
                                GetCompanyAddress();
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
                SqlConnection UserCon = new SqlConnection(strconnect);

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
        public DataTable ViewActivityReportDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewActivityReport", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 120;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridActivityReport.DataSource = table;
                GridActivityReport.DataBind();

            }
            return table;
        }

        public DataTable ViewActivityReportEmpID(int UserID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewActivityReportEmpID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", UserID);
                cmd.CommandTimeout = 120;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridActivityReport.DataSource = table;
                GridActivityReport.DataBind();

            }
            return table;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void ddlBelong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //int categoryid = Convert.ToInt32(ddlBelong.SelectedText);
               // string catName = ddlBelong.SelectedItem.Text;
                lblActivityNamee.Text = ddlBelong.SelectedItem.Text; ;
                if (lblActivityNamee.Text == "Project")
                {
                    // lblExpensesSubCategory.Text = "Project ";
                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "ProjectName";
                        ddlRelatedTo.DataValueField = "ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("ALL Project", "0"));
                    }
                }
                else if (lblActivityNamee.Text == "Work Order")
                {
                   // lblActivityNamee.Text = "Work Order";
                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "WorkOrderNumber"; 
                        ddlRelatedTo.DataValueField = "ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select WorkOrderNumber", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Estimate")
                {
                   // lblActivityNamee.Text = "Estimate";
                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "EstimateNo";
                        ddlRelatedTo.DataValueField = "ID"; 
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Estimate", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Product")
                {
                   // lblActivityNamee.Text = "Product";
                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "ProductName";
                        ddlRelatedTo.DataValueField = "ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Product", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Web Access")
                {
                 
                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "WebPageName";
                        ddlRelatedTo.DataValueField = "ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select WebAccess", "0"));
                    }

                }

                else if (lblActivityNamee.Text == "Group")
                {
                  //  lblActivityNamee.Text = "Group";
                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "Group_Name";
                        ddlRelatedTo.DataValueField = "Group_ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Group", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Contract")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "subject";
                        ddlRelatedTo.DataValueField = "id";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Contract", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Announcement")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "name";
                        ddlRelatedTo.DataValueField = "announcement_id";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Announcement", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Customer")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "Cust_Name";
                        ddlRelatedTo.DataValueField = "Cust_ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Customer", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Ticket")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "Ticket_Number";
                        ddlRelatedTo.DataValueField = "Ticket_ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Ticket", "0"));
                    }

                }
                //else if (lblActivityNamee.Text == "Profile")
                //{

                //    SqlConnection conn = new SqlConnection(strconnect);
                //    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                //    cmd.Connection = conn;
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                //    {
                //        DataSet ds = new DataSet();
                //        sda.Fill(ds);
                //        ddlRelatedTo.DataSource = ds.Tables[0];
                //        ddlRelatedTo.DataTextField = "WebPageName";
                //        ddlRelatedTo.DataValueField = "ID";
                //        ddlRelatedTo.DataBind();
                //        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Profile", "0"));
                //    }

                //}
                //else if (lblActivityNamee.Text == "Item Request")
                //{

                //    SqlConnection conn = new SqlConnection(strconnect);
                //    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                //    cmd.Connection = conn;
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                //    {
                //        DataSet ds = new DataSet();
                //        sda.Fill(ds);
                //        ddlRelatedTo.DataSource = ds.Tables[0];
                //        ddlRelatedTo.DataTextField = "WebPageName";
                //        ddlRelatedTo.DataValueField = "ID";
                //        ddlRelatedTo.DataBind();
                //        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Item Request", "0"));
                //    }

                //}
                //else if (lblActivityNamee.Text == "Setting")
                //{

                //    SqlConnection conn = new SqlConnection(strconnect);
                //    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                //    cmd.Connection = conn;
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                //    {
                //        DataSet ds = new DataSet();
                //        sda.Fill(ds);
                //        ddlRelatedTo.DataSource = ds.Tables[0];
                //        ddlRelatedTo.DataTextField = "WebPageName";
                //        ddlRelatedTo.DataValueField = "ID";
                //        ddlRelatedTo.DataBind();
                //        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Setting", "0"));
                //    }

                //}
                else if (lblActivityNamee.Text == "Article")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "SubjectName";
                        ddlRelatedTo.DataValueField = "Article_ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Article", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Item")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "Description";
                        ddlRelatedTo.DataValueField = "ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Item", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "ToDo Item")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "description";
                        ddlRelatedTo.DataValueField = "todo_items_id";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select ToDoItem", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Project Purchase")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "Pur_Name";
                        ddlRelatedTo.DataValueField = "Pur_id";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Project Purchase", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Vendor")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "Vend_Name";
                        ddlRelatedTo.DataValueField = "Vend_ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Vendor", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Task")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "subject";
                        ddlRelatedTo.DataValueField = "ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Task", "0"));
                    }


                }
                else if (lblActivityNamee.Text == "Partner")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "Patner_Name";
                        ddlRelatedTo.DataValueField = "Patner_ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Partner", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Inventory Product")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "ProductName";
                        ddlRelatedTo.DataValueField = "ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Inventory Product", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Office Expenses")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "Exp_Name";
                        ddlRelatedTo.DataValueField = "Exp_id";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select  Office Expenses", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Staff Expenses")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "Exp_Name";
                        ddlRelatedTo.DataValueField = "Exp_id";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select  Staff Expenses", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Inventory")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "DepoName";
                        ddlRelatedTo.DataValueField = "DepoID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Inventory", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Invoice")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "InvoiceNo";
                        ddlRelatedTo.DataValueField = "ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Invoice", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Tender")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "TenderNo";
                        ddlRelatedTo.DataValueField = "ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Tender", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Staff")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "FullName";
                        ddlRelatedTo.DataValueField = "Staff_ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Staff", "0"));
                    }

                }
                else if (lblActivityNamee.Text == "Profile")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "FullName";
                        ddlRelatedTo.DataValueField = "Staff_ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Staff", "0"));
                    }

                }
              
                else if (lblActivityNamee.Text == "Payment Approval")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "Exp_Name";
                        ddlRelatedTo.DataValueField = "ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Payments Approval", "0"));
                    }

                }
                else // if (lblActivityNamee.Text == "Payments")
                {

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ZModulewiseData", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActivityBelong", lblActivityNamee.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlRelatedTo.DataSource = ds.Tables[0];
                        ddlRelatedTo.DataTextField = "Payment_For";
                        ddlRelatedTo.DataValueField = "ID";
                        ddlRelatedTo.DataBind();
                        ddlRelatedTo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Payments", "0"));
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

        protected void lnkbtnExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = ViewActivityReportDetails();
            if (dt != null && dt.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=ActivityLogReport.xls");

                Response.Charset = " ";


                DataTable dtExport = new DataTable();
                dtExport.Columns.Add("ID");
                dtExport.Columns.Add("Activity");
                dtExport.Columns.Add("ActivityDate");
                dtExport.Columns.Add("UserName");
              //  dtExport.Columns.Add("EmpID");
                dtExport.Columns.Add("Designation");
                dtExport.Columns.Add("Belong");
                dtExport.Columns.Add("ActivityFor");
             





                foreach (DataRow row in dt.Rows)
                {
                    DataRow newRow = dtExport.NewRow();
                    newRow["ID"] = row["ID"];
                    newRow["Activity"] = row["ActivityType"];
                    newRow["ActivityDate"] = row["ActivityDate"];
                    newRow["UserName"] = row["UserID"];
                    //newRow["EmpID"] = row["EmpID"];
                    newRow["Designation"] = row["Designation"];
                    newRow["Belong"] = row["ActivityBelong"];
                    newRow["ActivityFor"] = row["ActivityFor"];
                    dtExport.Rows.Add(newRow);


                }

                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);


                GridView gridView = new GridView();
                gridView.DataSource = dtExport;
                gridView.DataBind();

                gridView.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();
            }

        }
       


        protected void linkbtnPDF_Click(object sender, EventArgs e)
        {
            try

            {
                //if (Session["LoginType"].ToString() == "Administrator")
                //{
                int _totalColumns = 7;//gridvie clumns
                string path = Image1.ImageUrl;
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                Font _fontStyle;
                PdfPTable _pdfPTable = new PdfPTable(7);//change
                PdfPCell _pdfPCell;
                PdfPCell cell = null;


                iTextSharp.text.Document _document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 0f, 0f, 0f, 0f);
                _document.SetPageSize(iTextSharp.text.PageSize.A4);
                _document.SetMargins(20f, 20f, 20f, 20f);
                _pdfPTable.WidthPercentage = 500;
                _pdfPTable.TotalWidth = 500f;
                _pdfPTable.LockedWidth = true;
                _pdfPTable.HorizontalAlignment = Element.ALIGN_CENTER;
                _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(_document, memoryStream);
                    //Phrase phrase = null;
                    //PdfPCell cell = null;
                    //PdfPTable table = null;
                    //Color color = new Color();

                    _document.Open();
                    _pdfPTable.SetWidths(new float[] { 3f, 7f, 7f, 5f, 7f, 5f, 7f });   
                                                                                                     //----Header PDF--------------------------//
                                                                                                    
                    cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 3;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPTable.AddCell(cell);

                    //...!..image logo..// 
                    Phrase phrase = null;
                    phrase = new Phrase();
                    phrase.Add(new Chunk(lbladdCompany11.Text + "\n", FontFactory.GetFont("Arial", 14, Font.BOLD, Color.BLACK)));
                    phrase.Add(new Chunk(lbladdress11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(lblcompanyaddCity1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(lblcompanyaddDistrict1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(lblcompanyaddState1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(lblcompanyaddCountry1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    _pdfPCell = new PdfPCell(phrase);
                    _pdfPCell.Colspan = 7;
                    _pdfPCell.BorderColor = Color.WHITE;
                    _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.PaddingBottom = 1f;
                    _pdfPCell.PaddingTop = 0f;
                    _pdfPCell.Border = 0;
                    _pdfPCell.BackgroundColor = Color.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 4;
                    _pdfPTable.AddCell(_pdfPCell);
                    _pdfPTable.CompleteRow();

                    _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                    _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                    _pdfPCell.Colspan = 7;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.Border = 2;
                    _pdfPCell.BorderColorBottom = Color.BLACK;
                    _pdfPCell.BackgroundColor = Color.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 4;
                    _pdfPTable.AddCell(_pdfPCell);
                    _pdfPTable.CompleteRow();

                    _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                    _pdfPCell = new PdfPCell(new Phrase("ActivityLogReport", _fontStyle));
                    _pdfPCell.Colspan = 5;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    _pdfPCell.Border = 0;
                    _pdfPCell.BackgroundColor = Color.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 4;
                    _pdfPTable.AddCell(_pdfPCell);

                    //-------Date------------------------------//
                    DateTime PrintTime = DateTime.Now;
                    _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                    _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                    _pdfPCell.Colspan = 2;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    _pdfPCell.Border = 0;
                    _pdfPCell.BackgroundColor = Color.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 3;
                    _pdfPTable.AddCell(_pdfPCell);
                    _pdfPTable.CompleteRow();


                    _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                    _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*-------------------------------------", _fontStyle));
                    _pdfPCell.Colspan = _totalColumns;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.Border = 0;
                    _pdfPCell.BackgroundColor = Color.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 4;
                    _pdfPTable.AddCell(_pdfPCell);
                    _pdfPTable.CompleteRow();

                    //----Header PDF--------------------------//


                    //----------------------------------Table----------------------------------////

                    DataTable _Vhrlist = new DataTable();
                    _Vhrlist = ViewActivityReportDetails();
                    #region "Table Header"

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("Activity", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("ActivityDate", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("UserName", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("Designation", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("Belong", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, Color.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("ActivityFor", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = Color.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);


                    _pdfPTable.CompleteRow();
                    #endregion

                    #region "Table Body"
                    _fontStyle = FontFactory.GetFont("Tahoma", 10f, 0);
                    int serialnumber = 1;

                    foreach (DataRow row in _Vhrlist.Rows)//Stored columns name
                    {
                        _pdfPCell = new PdfPCell(new Phrase(serialnumber++.ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["ActivityType"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["ActivityDate"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["UserID"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER; 
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                     


                        _pdfPCell = new PdfPCell(new Phrase(row["Designation"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);


                     
                        _pdfPCell = new PdfPCell(new Phrase(row["ActivityBelong"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);




                        _pdfPCell = new PdfPCell(new Phrase(row["ActivityFor"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = Color.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);


                     


                    }
                    #endregion

                    #region "Table Footer"
                    String text = "Page " + writer.PageNumber + " of ";
                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    PdfContentByte cb = writer.DirectContent;
                    PdfTemplate footerTemplate = cb.CreateTemplate(40, 40);

                    //Move the pointer and draw line to separate footer section from rest of page  
                    cb.MoveTo(40, _document.PageSize.GetBottom(40));
                    cb.LineTo(_document.PageSize.Width - 40, _document.PageSize.GetBottom(40));
                    cb.Stroke();

                    cb.BeginText();
                    cb.SetFontAndSize(bf, 9);
                    cb.SetTextMatrix(_document.PageSize.GetRight(100), _document.PageSize.GetBottom(30));
                    cb.ShowText(text);
                    cb.EndText();
                    float len = bf.GetWidthPoint(text, 9);
                    cb.AddTemplate(footerTemplate, _document.PageSize.GetRight(100) + len, _document.PageSize.GetBottom(30));

                    footerTemplate.BeginText();
                    footerTemplate.SetFontAndSize(bf, 9);
                    footerTemplate.SetTextMatrix(0, 0);
                    footerTemplate.ShowText((writer.PageNumber - 1).ToString());
                    footerTemplate.EndText();

                    #endregion

                    //-------------------- PDF Generation------------------------------------//
                    _pdfPTable.HeaderRows = 1; //header method
                    _document.Add(_pdfPTable);

                    _document.Close();
                    byte[] bytes = memoryStream.ToArray();
                    DateTime dTime = DateTime.Now;
                    string PDFFileName = string.Format("ActivityLogReport_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + PDFFileName);
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();

                    //}
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

        protected void btnSearchRerort_Click(object sender, EventArgs e)
        {
            try
            {
                string Belong;
                string RelatedTo;
                string Activity;
                string startDate;
                string endDate;

                if (ddlBelong.SelectedIndex == 0)
                {
                    Belong = null;
                }
                else
                {
                    Belong = ddlBelong.SelectedItem.Text;
                }


                if (ddlRelatedTo.SelectedIndex == 0)
                {
                    RelatedTo = null;
                }
                else
                {
                    RelatedTo = ddlRelatedTo.SelectedItem.Value;
                }

                if (ddlActivity.SelectedIndex == 0)
                {
                    Activity = null;
                }

                else
                {
                    Activity = ddlActivity.SelectedItem.Value;
                }

                if (txtEndDate.Text == "" && txtStartDate.Text == "")
                {
                    startDate = null;
                    endDate = null;
                }
                else if (txtStartDate.Text == "")
                {
                    startDate = null;
                    endDate = txtEndDate.Text;
                }
                else if (txtEndDate.Text == "")
                {
                    startDate = txtStartDate.Text;
                    endDate = null;
                }
                else
                {
                    startDate = txtStartDate.Text;
                    endDate = txtEndDate.Text;
                }

                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_SearchActivityLogReport", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 120;
                    cmd.Parameters.AddWithValue("@RelatedTo", RelatedTo);
                    cmd.Parameters.AddWithValue("@username", Activity);
                    cmd.Parameters.AddWithValue("@ActivityBelong", Belong);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridActivityReport.DataSource = dt;
                    GridActivityReport.DataBind();

                }
                //Clear();
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
        #endregion
    }
}