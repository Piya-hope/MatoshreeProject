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
    public partial class ViewWorkOrder : System.Web.UI.Page
    {
        #region " Class Level Variable "

        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection UserCon = new SqlConnection();
       
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result, Tenderid, Publish;



        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;

        Double TotalAmont, TotalTaxAmount;
        string Size, Initial, ReceiptFor, Cash, Bank, reminder;

        string Day = Convert.ToString(DateTime.Today.Day);
      
        string year = Convert.ToString(DateTime.Today.Year);
        Double TenderTOTALAMONT;

        Double DiscountItem1 = 0, Adjustment1, TaxTotalItem1, SubtotalItem1;


        decimal TotalTEnderAmont;


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
        public DataTable ViewWorkorderDetailsByEmpID(int UserID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewWorkOrderDetailsEmpID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", UserID);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridWorkorderlist.DataSource = table;
                GridWorkorderlist.DataBind();
                ViewState["WorkData"] = table;
            }
            return table;
        }

        public DataTable ViewWorkorderDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewWorkOrderDetails", con))
                {
                    ad.Fill(table);
                    GridWorkorderlist.DataSource = table;
                    GridWorkorderlist.DataBind();
                    ViewState["WorkData"] = table;
                }
            }
            return table;
        }

        public void GetCompanyAddress()
        {
            try
            {
                SqlConnection Usercon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetCompanyAddress", Usercon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblComanyname.Text = dt.Rows[0]["Company_Name"].ToString() + ",";
                    Image1.ImageUrl= dt.Rows[0]["Company_Logo"].ToString();
                    lbladdress.Text = dt.Rows[0]["Address"].ToString();
                    lblcompanyaddCity1.Text = dt.Rows[0]["City"].ToString() + ",";
                    lblcompanyaddDistrict1.Text = dt.Rows[0]["District"].ToString() + ",";
                    lblcompanyaddState1.Text = dt.Rows[0]["State"].ToString() + ",";
                    lblcompanyaddCountry1.Text = "India" + ",";
                    lblcompanyaddZIPCode11.Text = dt.Rows[0]["Zip_Code"].ToString() + ",";
                    lblphoneNo1.Text = dt.Rows[0]["Phone"].ToString() + ",";
                    lblVatNo1.Text = dt.Rows[0]["VAT_Number"].ToString() + ",";
                    lblGSTNo1A.Text = dt.Rows[0]["GST_NO"].ToString() + ",";
                   
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

        public void GetbyWorkOrderNo()
        {
            try
            {
                string WorkOrderNo = HttpUtility.UrlDecode(Request.QueryString["WorkOrderNo"]);
                lblworkno.Text = WorkOrderNo;
                using (SqlConnection Usercon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetWorkOrderByWorkOrderNO", Usercon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@WorkOrderNumber", lblworkno.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblworkorderno1.Text = dt.Rows[0]["WorkOrderNumber"].ToString();
                        lbltendno1.Text = dt.Rows[0]["TenderNumber"].ToString();                     
                        lbltendcat1.Text = dt.Rows[0]["TenderBased"].ToString();
                        lblbidenddate1.Text = DateTime.Parse(dt.Rows[0]["BidEndDate"].ToString()).ToString("yyyy-MM-dd");
                        lblworkdesc1.Text = dt.Rows[0]["Description"].ToString();
                        lbltendvalue1.Text = dt.Rows[0]["estimatecontractvalue"].ToString();
                        lbllocCity1.Text = dt.Rows[0]["AddCity"].ToString();
                        lbllocpin1.Text = dt.Rows[0]["Pincode"].ToString();
                        lblTenderName1.Text = dt.Rows[0]["TenderName"].ToString();

                        lblvendername.Text = dt.Rows[0]["Vend_Name"].ToString();
                        lblvenconname1.Text = dt.Rows[0]["First_Name"].ToString();
                        lblvenconemail1.Text = dt.Rows[0]["email"].ToString();
                        lblvenconphone1.Text = dt.Rows[0]["phonenumber"].ToString();
                        lblvenconposition1.Text = dt.Rows[0]["Position"].ToString();
                        lblvenderblock.Text = dt.Rows[0]["VAdd_Block"].ToString();
                        lblvenderstreet.Text = dt.Rows[0]["VAdd_Street"].ToString();
                        lblvendercity.Text = dt.Rows[0]["VAdd_City"].ToString();
                        lblvenderdistrict.Text = dt.Rows[0]["VAdd_District"].ToString();
                        lblvenderstate.Text = dt.Rows[0]["VAdd_State"].ToString();
                        lblvenercountry.Text = dt.Rows[0]["VAdd_Country"].ToString();
                        lblvenderpin1.Text = dt.Rows[0]["VAdd_PinCode"].ToString();

                        lblauthorityname1.Text = dt.Rows[0]["AuthorityName"].ToString();
                        lblauthorityadd1.Text = dt.Rows[0]["Authorityaddress"].ToString();
                        lblconno1.Text = dt.Rows[0]["Auth_Contact"].ToString();
                        lblauthposition1.Text = dt.Rows[0]["Auth_Position"].ToString();
                        lblauthemail1.Text = dt.Rows[0]["Auth_Email"].ToString();

                        lblclientnote.Text = dt.Rows[0]["Client_Note"].ToString();
                        lbltermsandcodition.Text = dt.Rows[0]["Term_condition"].ToString();

                        lblworkoderdeliverydate1.Text = DateTime.Parse(dt.Rows[0]["workorderEndDate"].ToString()).ToString("yyyy-MM-dd");
                        lblworkorderstartdate1.Text = DateTime.Parse(dt.Rows[0]["StartDate"].ToString()).ToString("yyyy-MM-dd");
                        lblworkorderdate1.Text = DateTime.Parse(dt.Rows[0]["workorderEndDate"].ToString()).ToString("yyyy-MM-dd");
                        lblActualcompdate1.Text = DateTime.Parse(dt.Rows[0]["CompletionDate"].ToString()).ToString("yyyy-MM-dd");
                        lblStatus.Text= dt.Rows[0]["WorkOrderstatus"].ToString();
                        ViewworkorderQue();
                        ViewWorkOrderItemDetails();
                        ViewworkorderFile();
                        ViewVendorAddressDetails();
                    }
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

        public DataTable ViewWorkOrderItemDetails()
        {
            DataTable dt = new DataTable();
            using (SqlConnection Usercon = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_GetWorkOrderItemByWorkNumber", Usercon))
                {
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure;             
                    ad.SelectCommand.Parameters.AddWithValue("@WorkOrderNumber", lblworkno.Text);
                    ad.Fill(dt);
                    Gridworkitem.DataSource = dt;
                    Gridworkitem.DataBind();
                }
            }
            return dt;
        }

        public DataTable ViewCompanyAddressDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection Usercon = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_GetCompanyAddress", Usercon))
                {
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    
                    ad.Fill(table);
                    GridViewcompany.DataSource = table;
                    GridViewcompany.DataBind();
                }
            }
            return table;
        }

        public DataTable ViewVendorAddressDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection Usercon = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_GetContactVendorAddress", Usercon))
                {
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure; // Set command type to stored procedure                 
                    ad.SelectCommand.Parameters.AddWithValue("@WorkOrderNumber", lblworkno.Text);
                    ad.Fill(table);
                    GridVendor.DataSource = table;
                    GridVendor.DataBind();
                }
            }
            return table;
        }

        public DataTable ViewworkorderQue()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewWorkorderQueAnsByWorkOrderNo", con))
                {
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure; // Set command type to stored procedure                 
                    ad.SelectCommand.Parameters.AddWithValue("@WorkOrderNumber", lblworkno.Text);
                    ad.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        GridWorkOrderQue.DataSource = dt;
                        GridWorkOrderQue.DataBind();
                    }
                    else
                    {
                        GridWorkOrderQue.Visible = false;
                    }
                   
                }
            }
            return dt;
        }      

        public DataTable ViewworkorderFile()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewWorkorderfileByWorkOrderNo", con))
                {
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure;     
                    ad.SelectCommand.Parameters.AddWithValue("@WorkOrderNumber", lblworkno.Text);
                    ad.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        GridWorkOrderFile.DataSource = dt;
                        GridWorkOrderFile.DataBind();
                    }
                    else
                    {
                        GridWorkOrderFile.Visible = false;
                    }
                  
                }
            }
            return dt;
        }

        public void GetTotalworkorderItemCount()
        {
            try
            {
                SqlConnection Usercon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetTotalAmountWorkOrderItem", Usercon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkorderNumber", lblworkno.Text);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lbltotal.Text = dt.Rows[0]["TotalAmount"].ToString();
                    
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

        public void ViewFilterByStatus(string status)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                con.Open(); 
                SqlCommand cmd = new SqlCommand("SP_ShowFilterWorkOrderDetailsByStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", status);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridWorkorderlist.DataSource = table;
                GridWorkorderlist.DataBind();
            }
        }

        protected void bindWorkOrderYear()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetWorkOrderYear", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    radiolistWorkOrderYear.DataSource = ds.Tables[0];
                    radiolistWorkOrderYear.DataTextField = "Year";
                    radiolistWorkOrderYear.DataValueField = "Year";
                    radiolistWorkOrderYear.DataBind();

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
            finally { }

        }

        protected void bindStaff()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetWorkOrderSaleAgent", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    radioSaleAgent.DataSource = ds.Tables[0];
                    radioSaleAgent.DataTextField = "saleAgent";
                    radioSaleAgent.DataValueField = "saleAgent";
                    radioSaleAgent.DataBind();
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
            finally { }

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
                    command.Parameters.AddWithValue("@SubModule", "Work Order");
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
                            GetCompanyAddress();
                            ViewWorkOrderItemDetails();
                            ViewCompanyAddressDetails();
                            ViewworkorderQue();
                            ViewWorkorderDetails();
                            GetbyWorkOrderNo();
                            GetTotalworkorderItemCount();
                            bindWorkOrderYear();
                            bindStaff();

                            if (Create == "True")
                            {
                                //addnew.Visible = true;
                            }
                            else
                            {
                                //addnew.Visible = false;
                            }

                            if (Edit == "True")
                            {

                               // GridWorkorderlist.Columns[10].Visible = true;
                            }
                            else
                            {

                                //GridWorkorderlist.Columns[10].Visible = false;
                            }

                            if (Delete == "True")
                            {

                               // GridWorkorderlist.Columns[11].Visible = true;
                            }
                            else
                            {

                               // GridWorkorderlist.Columns[11].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {
                            GetCompanyAddress();
                            ViewWorkOrderItemDetails();
                            ViewCompanyAddressDetails();
                            ViewworkorderQue();
                            ViewWorkorderDetailsByEmpID(UserId);
                            GetbyWorkOrderNo();
                            GetTotalworkorderItemCount();
                            bindWorkOrderYear();
                            bindStaff();

                            if (Create == "True")
                            {
                                //addnew.Visible = true;
                            }
                            else
                            {
                               // addnew.Visible = false;
                            }

                            if (Edit == "True")
                            {

                               // GridWorkorderlist.Columns[10].Visible = true;
                            }
                            else
                            {

                               // GridWorkorderlist.Columns[10].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                //GridWorkorderlist.Columns[11].Visible = true;
                            }
                            else
                            {

                               // GridWorkorderlist.Columns[11].Visible = false;
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
                            GetCompanyAddress();

                            ViewWorkOrderItemDetails();
                            ViewCompanyAddressDetails();

                            ViewworkorderQue();
                            ViewWorkorderDetails();
                            GetbyWorkOrderNo();
                            GetTotalworkorderItemCount();
                            bindWorkOrderYear();
                            bindStaff();
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
                            }
                        }
                        else
                        {

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

        protected void lnkbtnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Image1.ImageUrl;
                DataTable table2 = new DataTable();
                DataTable table12 = ViewWorkOrderItemDetails();
                DataTable tableA = new DataTable();
                DataTable Gridtenderfile = ViewworkorderFile();
                DataTable tableB = new DataTable();
                DataTable GridWorkOrderQue = ViewworkorderQue();
                DataTable tableC = new DataTable();
                DataTable GridViewcompany = ViewCompanyAddressDetails();
                DataTable tableD = new DataTable();
                DataTable GridVendor = ViewVendorAddressDetails();

                iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
                MemoryStream memoryStream = new MemoryStream();
                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, memoryStream);
                doc.Open();
                PdfPTable tableimage = new PdfPTable(1);
                tableimage.WidthPercentage = 100;
                PdfPCell imagecell = new PdfPCell();
                imagecell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));

                image.ScaleToFit(100f, 100f);
                imagecell.AddElement(image);
                tableimage.AddCell(imagecell);
                doc.Add(tableimage);
                doc.Add(new Paragraph(" "));

                PdfPTable tableAddress = new PdfPTable(2);
                tableAddress.WidthPercentage = 100;
                PdfPCell LeftAddresscell = new PdfPCell();
                LeftAddresscell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Chunk tenderfrom = new Chunk("From", new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK));
                Phrase tenderfromPh1 = new Phrase
                {
                tenderfrom
                };
                Paragraph tenderfromparagraph1 = new Paragraph(tenderfromPh1);
                tenderfromparagraph1.Alignment = Element.ALIGN_LEFT;
                LeftAddresscell.AddElement(tenderfromparagraph1);

                Chunk tenderaddno16 = new Chunk(lblComanyname.Text, new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK));
                Phrase tenderaddPh6 = new Phrase
                {
                tenderaddno16
                };
                Paragraph tendaddparagraph6 = new Paragraph(tenderaddPh6);
                tendaddparagraph6.Alignment = Element.ALIGN_LEFT;
                LeftAddresscell.AddElement(tendaddparagraph6);

                Chunk tenderaddno3 = new Chunk(lbladdress.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderaddno6 = new Chunk(lblcompanyaddCity1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddPh1 = new Phrase
                {
                tenderaddno3,
                tenderaddno6
                };
                Paragraph tendaddparagraph1 = new Paragraph(tenderaddPh1);
                tendaddparagraph1.Alignment = Element.ALIGN_LEFT;
                LeftAddresscell.AddElement(tendaddparagraph1);

                Chunk tenderaddnoD1 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderaddnoD = new Chunk(lblcompanyaddDistrict1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddPhD = new Phrase
                {
                tenderaddnoD1,
                tenderaddnoD
                };
                Paragraph tendaddparagraphD = new Paragraph(tenderaddPhD);
                tendaddparagraphD.Alignment = Element.ALIGN_LEFT;
                LeftAddresscell.AddElement(tendaddparagraphD);

                Chunk tenderaddnoS = new Chunk(lblcompanyaddState1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderaddnoS1 = new Chunk(lblcompanyaddCountry1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddPhS = new Phrase
                {
                tenderaddnoS,
                tenderaddnoS1
                };
                Paragraph tendaddparagraphS = new Paragraph(tenderaddPhS);
                tendaddparagraphS.Alignment = Element.ALIGN_LEFT;
                LeftAddresscell.AddElement(tendaddparagraphS);

                Chunk tenderaddno28 = new Chunk("PIN:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderaddno29 = new Chunk(lblcompanyaddZIPCode11.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddPh10 = new Phrase
                {
                tenderaddno28,
                tenderaddno29
                };
                Paragraph tendaddparagraph10 = new Paragraph(tenderaddPh10);
                tendaddparagraph10.Alignment = Element.ALIGN_LEFT;
                LeftAddresscell.AddElement(tendaddparagraph10);

                Chunk tenderpinaddno2 = new Chunk("Phone:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderaddnoP = new Chunk(lblphoneNo1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddPh2 = new Phrase
                {
                tenderpinaddno2,
                tenderaddnoP
                };
                Paragraph tendaddparagraph2 = new Paragraph(tenderaddPh2);
                tendaddparagraph2.Alignment = Element.ALIGN_LEFT;
                LeftAddresscell.AddElement(tendaddparagraph2);
                tableAddress.AddCell(LeftAddresscell);


                PdfPCell companyaddresscell = new PdfPCell();
                companyaddresscell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Chunk vender1 = new Chunk("To,", new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK));
                Phrase venderPh1 = new Phrase
               {
              vender1
               };
                Paragraph venderparagraph1 = new Paragraph(venderPh1);
                venderparagraph1.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderparagraph1);

                Chunk vender2 = new Chunk(lblvendername.Text, new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK));
                Phrase venderPh2 = new Phrase
               {
                 vender2
               };
                Paragraph venderparagraph2 = new Paragraph(venderPh2);
                venderparagraph2.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderparagraph2);

                Chunk venderaddno16 = new Chunk(lblvenconname1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderaddPh6 = new Phrase
               {
                 venderaddno16
               };
                Paragraph venderaddparagraph6 = new Paragraph(venderaddPh6);
                venderaddparagraph6.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderaddparagraph6);

                Chunk venderaddno3 = new Chunk("Position:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk venderaddno6 = new Chunk(lblvenconposition1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderaddPh1 = new Phrase
{
 venderaddno3,
 venderaddno6
};
                Paragraph venderaddparagraph1 = new Paragraph(venderaddPh1);
                venderaddparagraph1.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderaddparagraph1);

                Chunk venderaddnoD1 = new Chunk("Email:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk venderaddnoD = new Chunk(lblvenconemail1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderaddPhD = new Phrase
{
    venderaddnoD1,
   venderaddnoD
};
                Paragraph venderaddparagraphD = new Paragraph(venderaddPhD);
                venderaddparagraphD.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderaddparagraphD);

                Chunk venderaddnoS = new Chunk("Phone Number:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk venderaddnoS1 = new Chunk(lblvenconphone1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderaddPhS = new Phrase
               {
                venderaddnoS,
               venderaddnoS1
               };
                Paragraph venderaddparagraphS = new Paragraph(venderaddPhS);
                venderaddparagraphS.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderaddparagraphS);

                Chunk vender3 = new Chunk(lblvenderblock.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderph3 = new Phrase
               {
                vender3
               };
                Paragraph venderparagraph3 = new Paragraph(venderph3);
                venderparagraph3.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderparagraph3);

                Chunk venderaddno28 = new Chunk(lblvenderstreet.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk venderaddno29 = new Chunk(lblvendercity.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderaddPh10 = new Phrase
{
 venderaddno28,
 venderaddno29
};
                Paragraph venderaddparagraph10 = new Paragraph(venderaddPh10);
                venderaddparagraph10.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderaddparagraph10);

                Chunk vender4 = new Chunk(lblvenderdistrict.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk venderaddcomma = new Chunk(",", new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderph4 = new Phrase
               {
               vender4,
               venderaddcomma
              };
                Paragraph venderparagraph4 = new Paragraph(venderph4);
                venderparagraph4.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderparagraph4);

                Chunk venderpinaddno2 = new Chunk(lblvenderstate.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk venderaddcomma1 = new Chunk(",", new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk venderaddnoP = new Chunk(lblvenercountry.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderaddPh2 = new Phrase
               {
                 venderpinaddno2,
                 venderaddcomma1,
                 venderaddnoP
               };
                Paragraph venderaddparagraph2 = new Paragraph(venderaddPh2);
                venderaddparagraph2.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderaddparagraph2);

                Chunk vender6 = new Chunk("PIN:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk vender7 = new Chunk(lblvenderpin1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderph6 = new Phrase
               {
               vender6,
               vender7
               };
                Paragraph venderparagraph6 = new Paragraph(venderph6);
                venderparagraph6.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderparagraph6);

                tableAddress.AddCell(companyaddresscell);
                doc.Add(tableAddress);

                doc.Add(new Paragraph(" "));

                PdfPTable tabletender = new PdfPTable(1);
                tabletender.WidthPercentage = 100;
                PdfPCell tendercell = new PdfPCell();
                tendercell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Chunk chtender = new Chunk("Work Order Form", new Font(Font.FontFamily.HELVETICA, 16f, Font.BOLD, BaseColor.BLACK));
                Phrase phtender = new Phrase
               {
               chtender
               };
                Paragraph chtenderparagraph1 = new Paragraph(phtender);
                chtenderparagraph1.Alignment = Element.ALIGN_CENTER;
                tendercell.AddElement(chtenderparagraph1);
                tabletender.AddCell(tendercell);
                doc.Add(tabletender);
                doc.Add(new Paragraph(" "));


                //company details

                PdfPTable tableCompanyAddress = new PdfPTable(1);
                tableCompanyAddress.WidthPercentage = 100;
                PdfPCell CompanyAddress1 = new PdfPCell();
                CompanyAddress1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                CompanyAddress1.AddElement(new Paragraph("Company Details :-", new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK)));
                tableCompanyAddress.AddCell(CompanyAddress1);
                doc.Add(tableCompanyAddress);
                doc.Add(new Paragraph(" "));

                if (GridViewcompany != null && GridViewcompany.Rows.Count > 0)
                {
                    DataTable dtExport = new DataTable();
                    dtExport.Columns.Add("Company_Name");
                    dtExport.Columns.Add("Address");
                    dtExport.Columns.Add("Phone");

                    foreach (DataRow row in GridViewcompany.Rows)
                    {
                        DataRow newRow = dtExport.NewRow();
                        newRow["Company_Name"] = row["Company_Name"];
                        newRow["Address"] = row["Address"];
                        newRow["Phone"] = row["Phone"];

                        dtExport.Rows.Add(newRow);
                        tableC = dtExport;
                    }
                    dtExport.Columns["Company_Name"].ColumnName = "CompanyName";
                    dtExport.Columns["Phone"].ColumnName = "ContactDetails";
                    float[] columnWidths = new float[tableC.Columns.Count];
                    for (int i = 0; i < tableC.Columns.Count; i++)
                    {
                        if (tableC.Columns[i].ColumnName == "Company_Name")
                        {
                            columnWidths[i] = 6f;
                        }

                        else if (tableC.Columns[i].ColumnName == "Address")
                        {
                            columnWidths[i] = 8f;
                        }

                        else
                        {
                            columnWidths[i] = 4f;
                        }
                    }
                    Font tableHeaderFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.BLUE);
                    Font tableDataFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL);
                    PdfPTable pdfTable = new PdfPTable(tableC.Columns.Count);
                    pdfTable.SetWidths(columnWidths);
                    pdfTable.WidthPercentage = 100;
                    foreach (DataColumn column in tableC.Columns)
                    {
                        string columnName = (column.ColumnName == "ID") ? "#" : column.ColumnName;
                        PdfPCell pdfCell = new PdfPCell(new Phrase(columnName, tableHeaderFont));
                        pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        pdfCell.Padding = 10;
                        pdfTable.AddCell(pdfCell);
                    }
                    foreach (DataRow row in tableC.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            PdfPCell dataCell = new PdfPCell(new Phrase(item.ToString(), tableDataFont));
                            dataCell.Padding = 10;
                            pdfTable.AddCell(dataCell);
                        }
                    }
                    doc.Add(pdfTable);
                }
                doc.Add(new Paragraph(" "));

                //Vendor Details

                PdfPTable tablevendorAddress = new PdfPTable(1);
                tablevendorAddress.WidthPercentage = 100;
                PdfPCell Vendordetailscell = new PdfPCell();
                Vendordetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Vendordetailscell.AddElement(new Paragraph("Vendor Details :-", new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK)));
                tablevendorAddress.AddCell(Vendordetailscell);
                doc.Add(tablevendorAddress);
                doc.Add(new Paragraph(" "));

                if (GridVendor != null && GridVendor.Rows.Count > 0)
                {
                    DataTable dtExport = new DataTable();

                    dtExport.Columns.Add("Name");
                    //dtExport.Columns.Add("id");
                    dtExport.Columns.Add("BillingAddress");
                    dtExport.Columns.Add("phonenumber");
                    dtExport.Columns.Add("Position");                    
                    dtExport.Columns.Add("email");
                   
                    foreach (DataRow row in GridVendor.Rows)
                    {
                        DataRow newRow = dtExport.NewRow();
                        newRow["Name"] = row["Name"];
                        //newRow["id"] = row["id"];
                        newRow["BillingAddress"] = row["BillingAddress"];
                        newRow["phonenumber"] = row["phonenumber"];
                        newRow["Position"] = row["Position"];
                        newRow["email"] = row["email"];                      
                        dtExport.Rows.Add(newRow);
                        tableD = dtExport;
                    }
                    dtExport.Columns["Name"].ColumnName = "VendorName";
                    //dtExport.Columns["id"].ColumnName = "Vendor ID";
                    dtExport.Columns["BillingAddress"].ColumnName = "BillingAddress";
                    dtExport.Columns["phonenumber"].ColumnName = "PhoneNumber";
                    dtExport.Columns["Position"].ColumnName = "VendorPosition";
                    dtExport.Columns["email"].ColumnName = "EmailAddress";

                    float[] columnWidths = new float[tableD.Columns.Count];
                    for (int i = 0; i < tableD.Columns.Count; i++)
                    {
                        if (tableD.Columns[i].ColumnName == "Name")
                        {
                            columnWidths[i] = 4f;
                        }

                        //else if (tableD.Columns[i].ColumnName == "id")
                        //{
                        //    columnWidths[i] = 4f;
                        //}

                        else if (tableD.Columns[i].ColumnName == "BillingAddress")
                        {
                            columnWidths[i] = 6f;
                        }
                        else if (tableD.Columns[i].ColumnName == "email")
                        {
                            columnWidths[i] = 6f;
                        }

                        else
                        {
                            columnWidths[i] = 4f;
                        }
                    }
                    Font tableHeaderFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.BLUE);
                    Font tableDataFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL);
                    PdfPTable pdfTable = new PdfPTable(tableD.Columns.Count);
                    pdfTable.SetWidths(columnWidths);
                    pdfTable.WidthPercentage = 100;
                    foreach (DataColumn column in tableD.Columns)
                    {
                        string columnName = (column.ColumnName == "Name") ? "VendorName" : column.ColumnName;
                        PdfPCell pdfCell = new PdfPCell(new Phrase(columnName, tableHeaderFont));
                        pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        pdfCell.Padding = 10;
                        pdfTable.AddCell(pdfCell);
                    }
                    foreach (DataRow row in tableD.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            PdfPCell dataCell = new PdfPCell(new Phrase(item.ToString(), tableDataFont));
                            dataCell.Padding = 10;
                            pdfTable.AddCell(dataCell);
                        }
                    }
                    doc.Add(pdfTable);
                }
                doc.Add(new Paragraph(" "));

                PdfPTable tabletenderdetails = new PdfPTable(1);
                tabletenderdetails.WidthPercentage = 100;
                PdfPCell tendercelldetails = new PdfPCell();
                tendercelldetails.AddElement(new Paragraph("Current Tender Details :-", new Font(Font.FontFamily.HELVETICA, 14f, Font.NORMAL, BaseColor.BLUE)));
                tendercelldetails.BackgroundColor = BaseColor.LIGHT_GRAY;
                tendercelldetails.PaddingLeft = 5;
                tendercelldetails.PaddingBottom = 15;
                tabletenderdetails.AddCell(tendercelldetails);
                doc.Add(tabletenderdetails);
                doc.Add(new Paragraph(" "));

                PdfPTable tabledetails = new PdfPTable(2);
                tabledetails.WidthPercentage = 100;             
                PdfPCell leftdetailscell = new PdfPCell();
                leftdetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Chunk tenderno = new Chunk("Tender Number:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderno1 = new Chunk(lbltendno1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderno2 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderPh = new Phrase
               {
               tenderno,
               tenderno1,
               tenderno2
               };
                Paragraph tendparagraph = new Paragraph(tenderPh);
                tendparagraph.Alignment = Element.ALIGN_LEFT;
                leftdetailscell.AddElement(tendparagraph);

                Chunk tenderno9 = new Chunk("Tender Name:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderno10 = new Chunk(lblTenderName1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderno11 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderPh2 = new Phrase
               {
               tenderno9,
               tenderno10,
               tenderno11
               };
                Paragraph tendparagraph2 = new Paragraph(tenderPh2);
                tendparagraph2.Alignment = Element.ALIGN_LEFT;
                leftdetailscell.AddElement(tendparagraph2);

               

                Chunk tenderworkno13 = new Chunk("Work Address:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderworkno14 = new Chunk(lbllocCity1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderworkno15 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderworkPh4 = new Phrase
 {
 tenderworkno13,
tenderworkno14,
 tenderworkno15
 };
                Paragraph tendworkparagraph4 = new Paragraph(tenderworkPh4);
                tendworkparagraph4.Alignment = Element.ALIGN_LEFT;
                leftdetailscell.AddElement(tendworkparagraph4);

                Chunk chtenderwork31 = new Chunk("Work Description:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk chtenderwork41 = new Chunk(lblworkdesc1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase phtenderwork21 = new Phrase
                {
                chtenderwork31,
                chtenderwork41
                };
                Paragraph chtenderparagraphwork21 = new Paragraph(phtenderwork21);
                chtenderparagraphwork21.Alignment = Element.ALIGN_LEFT;
                leftdetailscell.AddElement(chtenderparagraphwork21);

                tabledetails.AddCell(leftdetailscell);

                PdfPCell rightdetailscell = new PdfPCell();
                rightdetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Chunk tenderno13 = new Chunk("Tender Category:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderno14 = new Chunk(lbltendcat1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderno15 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderPh4 = new Phrase
               {
               tenderno13,
               tenderno14,
               tenderno15
               };
                Paragraph tendparagraph4 = new Paragraph(tenderPh4);
                tendparagraph4.Alignment = Element.ALIGN_LEFT;
                rightdetailscell.AddElement(tendparagraph4);

                Chunk tenderno3 = new Chunk("Tender Value:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderno4 = new Chunk(lbltendvalue1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderno5 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderPh1 = new Phrase
               {
               tenderno3,
               tenderno4,
               tenderno5
               };
                Paragraph tendparagraph1 = new Paragraph(tenderPh1);
                tendparagraph1.Alignment = Element.ALIGN_LEFT;
                rightdetailscell.AddElement(tendparagraph1);

                Chunk tenderno6 = new Chunk("Bid Closing Date:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderno7 = new Chunk(lblbidenddate1.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase tenderPh3 = new Phrase
               {
               tenderno6,
               tenderno7

               };
                Paragraph tendparagraph3 = new Paragraph(tenderPh3);
                tendparagraph3.Alignment = Element.ALIGN_LEFT;
                rightdetailscell.AddElement(tendparagraph3);
               

                Chunk tenderaddpinno28 = new Chunk("PIN:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderaddpinno29 = new Chunk(lblcompanyaddZIPCode11.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddpinPh10 = new Phrase
                {
                 tenderaddpinno28,
                 tenderaddpinno29
                };
                Paragraph tendaddparagraphpin10 = new Paragraph(tenderaddpinPh10);
                tendaddparagraphpin10.Alignment = Element.ALIGN_LEFT;
                rightdetailscell.AddElement(tendaddparagraphpin10);
                tabledetails.AddCell(rightdetailscell);
                doc.Add(tabledetails);
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                PdfPTable tableitemdetails = new PdfPTable(1);
                tableitemdetails.WidthPercentage = 100;
                PdfPCell itemdetailscell = new PdfPCell();
              //  itemdetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                itemdetailscell.AddElement(new Paragraph("Work Details :-", new Font(Font.FontFamily.HELVETICA, 14f, Font.NORMAL, BaseColor.BLUE)));
                itemdetailscell.BackgroundColor = BaseColor.LIGHT_GRAY;
                itemdetailscell.PaddingLeft = 5;
                itemdetailscell.PaddingBottom = 15;
                tableitemdetails.AddCell(itemdetailscell);
                doc.Add(tableitemdetails);
                doc.Add(new Paragraph(" "));
               

                if (table12 != null && table12.Rows.Count > 0)
                {
                    DataTable dtExport1 = new DataTable();
                    dtExport1.Columns.Add("ID");
                    dtExport1.Columns.Add("Item");
                    dtExport1.Columns.Add("Description");
                    dtExport1.Columns.Add("Qnty");
                    dtExport1.Columns.Add("Rate");
                    dtExport1.Columns.Add("Tax1Name");
                    dtExport1.Columns.Add("Tax1Rate");
                    dtExport1.Columns.Add("Tax2Name");
                    dtExport1.Columns.Add("Tax2Rate");
                    dtExport1.Columns.Add("TotalAmont");
                    foreach (DataRow row in table12.Rows)
                    {
                        DataRow newRow = dtExport1.NewRow();
                        newRow["ID"] = row["ID"];
                        newRow["Item"] = row["Item"];
                        newRow["Description"] = row["Description"];
                        newRow["Qnty"] = row["Qnty"];
                        newRow["Rate"] = row["Rate"];
                        newRow["Tax1Name"] = row["Tax1Name"];
                        newRow["Tax1Rate"] = row["Tax1Rate"];
                        newRow["Tax2Name"] = row["Tax2Name"];
                        newRow["Tax2Rate"] = row["Tax2Rate"];
                        newRow["TotalAmont"] = row["TotalAmont"];

                        dtExport1.Rows.Add(newRow);
                        table2 = dtExport1;
                    }

                    float[] columnWidths1 = new float[table2.Columns.Count];
                    for (int i = 0; i < table2.Columns.Count; i++)
                    {
                        if (table2.Columns[i].ColumnName == "ID")
                        {
                            columnWidths1[i] = 2f;
                        }

                        else if (table2.Columns[i].ColumnName == "Item")
                        {
                            columnWidths1[i] = 4f;
                        }
                        else if (table2.Columns[i].ColumnName == "Description")
                        {
                            columnWidths1[i] = 6f;
                        }
                        else if (table2.Columns[i].ColumnName == "Qnty")
                        {
                            columnWidths1[i] = 4f;
                        }
                        else if (table2.Columns[i].ColumnName == "Rate")
                        {
                            columnWidths1[i] = 4f;
                        }
                        else
                        {
                            columnWidths1[i] = 4f;
                        }
                    }
                    Font tableHeaderFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.BLUE);
                    Font tableDataFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL);
                    PdfPTable pdfTable = new PdfPTable(table2.Columns.Count);
                    pdfTable.SetWidths(columnWidths1);
                    pdfTable.WidthPercentage = 100;
                    foreach (DataColumn column in table2.Columns)
                    {
                        string columnName = (column.ColumnName == "ID") ? "#" : column.ColumnName;
                        PdfPCell pdfCell = new PdfPCell(new Phrase(columnName, tableHeaderFont));
                        pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        pdfCell.Padding = 10;
                        pdfTable.AddCell(pdfCell);
                    }
                    foreach (DataRow row in table2.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            PdfPCell dataCell = new PdfPCell(new Phrase(item.ToString(), tableDataFont));
                            dataCell.Padding = 10;
                            pdfTable.AddCell(dataCell);
                        }
                    }
                    doc.Add(pdfTable);
                }
                doc.Add(new Paragraph(" "));

                PdfPTable tableItemdetails = new PdfPTable(1);
                tableItemdetails.WidthPercentage = 100;
                PdfPCell Itemdetailscell = new PdfPCell();
                Itemdetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Chunk itemtotal = new Chunk("Total Item Amount:₹", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk itemtotal1 = new Chunk(lbltotal.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase itemPH = new Phrase
  {
 itemtotal,
  itemtotal1

  };
                Paragraph itemPharagraph = new Paragraph(itemPH);
                itemPharagraph.Alignment = Element.ALIGN_LEFT;
                Itemdetailscell.AddElement(itemPharagraph);

                Chunk itemtotal2 = new Chunk("Delivery Date Of Work:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk itemtotal3 = new Chunk(lblworkoderdeliverydate1.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase itemPH1 = new Phrase
  {
 itemtotal2,
  itemtotal3

  };
                Paragraph itemPharagraph1 = new Paragraph(itemPH1);
                itemPharagraph1.Alignment = Element.ALIGN_LEFT;
                Itemdetailscell.AddElement(itemPharagraph1);

                Chunk itemtotal4 = new Chunk("Actual Date Of Completion:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk itemtotal5 = new Chunk(lblActualcompdate1.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase itemPH2 = new Phrase
  {
 itemtotal4,
  itemtotal5

  };
                Paragraph itemPharagraph2 = new Paragraph(itemPH2);
                itemPharagraph2.Alignment = Element.ALIGN_LEFT;
                Itemdetailscell.AddElement(itemPharagraph2);

                tableItemdetails.AddCell(Itemdetailscell);

                doc.Add(tableItemdetails);
                doc.Add(new Paragraph(" "));

                PdfPTable tableQuedetails = new PdfPTable(1);
                tableQuedetails.WidthPercentage = 100;
                PdfPCell Quedetailscell = new PdfPCell();
               // Quedetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Quedetailscell.AddElement(new Paragraph("Question & Answer :-", new Font(Font.FontFamily.HELVETICA, 14f, Font.NORMAL, BaseColor.BLUE)));
                Quedetailscell.BackgroundColor = BaseColor.LIGHT_GRAY;
                Quedetailscell.PaddingLeft = 5;
                Quedetailscell.PaddingBottom = 15;
                tableQuedetails.AddCell(Quedetailscell);
                doc.Add(tableQuedetails);
                doc.Add(new Paragraph(" "));

                if (GridWorkOrderQue != null && GridWorkOrderQue.Rows.Count > 0)
                {
                    DataTable dtExport2 = new DataTable();
                    dtExport2.Columns.Add("ID");
                    dtExport2.Columns.Add("Tend_Que");
                    
                    foreach (DataRow row2 in GridWorkOrderQue.Rows)
                    {
                        DataRow newRow = dtExport2.NewRow();
                        newRow["ID"] = row2["ID"];
                        newRow["Tend_Que"] = row2["Tend_Que"];
                       
                        dtExport2.Rows.Add(newRow);
                        tableA = dtExport2;
                    }
                    dtExport2.Columns["Tend_Que"].ColumnName = "TenderQuestion";
                    float[] columnWidths2 = new float[tableA.Columns.Count];
                    for (int i = 0; i < tableA.Columns.Count; i++)
                    {
                        if (tableA.Columns[i].ColumnName == "ID")
                        {
                            columnWidths2[i] = 2f;
                        }
                        else
                        {
                            columnWidths2[i] = 22f;
                        }

                    }
                    Font tableHeaderFont1 = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.BLUE);
                    Font tableDataFont1 = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL);
                    PdfPTable pdfTable1 = new PdfPTable(tableA.Columns.Count);
                    pdfTable1.SetWidths(columnWidths2);
                    pdfTable1.WidthPercentage = 100;
                    foreach (DataColumn column in tableA.Columns)
                    {
                        string columnName1 = (column.ColumnName == "ID") ? "#" : column.ColumnName;
                        PdfPCell pdfCell = new PdfPCell(new Phrase(columnName1, tableHeaderFont1));
                        pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        pdfCell.Padding = 10;
                        pdfTable1.AddCell(pdfCell);
                    }
                    foreach (DataRow row in tableA.Rows)
                    {
                        foreach (var que in row.ItemArray)
                        {
                            PdfPCell dataCell1 = new PdfPCell(new Phrase(que.ToString(), tableDataFont1));
                            dataCell1.Padding = 10;
                            pdfTable1.AddCell(dataCell1);
                        }
                    }
                    doc.Add(pdfTable1);
                }
                doc.Add(new Paragraph(" "));

                PdfPTable tabletenderAutoritydetails = new PdfPTable(1);
                tabletenderAutoritydetails.WidthPercentage = 100;
                PdfPCell tendercellAutoritydetails = new PdfPCell();
                //  tendercellAutoritydetails.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tendercellAutoritydetails.AddElement(new Paragraph("Tender Inviting Authority :-", new Font(Font.FontFamily.HELVETICA, 14f, Font.NORMAL, BaseColor.BLUE)));
                tendercellAutoritydetails.BackgroundColor = BaseColor.LIGHT_GRAY;
                tendercellAutoritydetails.PaddingLeft = 5;
                tendercellAutoritydetails.PaddingBottom = 15;
                tabletenderAutoritydetails.AddCell(tendercellAutoritydetails);
                doc.Add(tabletenderAutoritydetails);
                doc.Add(new Paragraph(" "));

                PdfPTable tableAuthoritydetails = new PdfPTable(2);
                tableAuthoritydetails.WidthPercentage = 100;
                PdfPCell leftAuthoritydetailscell = new PdfPCell();
                leftAuthoritydetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Chunk tenderAuthorityno = new Chunk("Authority Name:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderAuthorityno1 = new Chunk(lblauthorityname1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderAuthorityno2 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderAuthorityPh = new Phrase
                {
                tenderAuthorityno ,
   tenderAuthorityno1 ,
   tenderAuthorityno2
   };
                Paragraph tendAuthorityparagraph = new Paragraph(tenderAuthorityPh);
                tendAuthorityparagraph.Alignment = Element.ALIGN_LEFT;
                leftAuthoritydetailscell.AddElement(tendAuthorityparagraph);

                Chunk tenderAuthorityposition = new Chunk("Authority Email:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderAuthorityposition1 = new Chunk(lblauthemail1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderAuthorityposition2 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderAuthoritypositionPh = new Phrase
                {
                tenderAuthorityposition ,
   tenderAuthorityposition1 ,
   tenderAuthorityposition2
   };
                Paragraph tendAuthoritypositionparagraph = new Paragraph(tenderAuthoritypositionPh);
                tendAuthoritypositionparagraph.Alignment = Element.ALIGN_LEFT;
                leftAuthoritydetailscell.AddElement(tendAuthoritypositionparagraph);


                Chunk tenderAuthorityposition3 = new Chunk("Authority Address:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderAuthorityposition4 = new Chunk(lblauthorityadd1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderAuthorityposition5 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderAuthoritypositionPh1 = new Phrase
                {
                tenderAuthorityposition3 ,
   tenderAuthorityposition4 ,
   tenderAuthorityposition5
   };
                Paragraph tendAuthoritypositionparagraph1 = new Paragraph(tenderAuthoritypositionPh1);
                tendAuthoritypositionparagraph1.Alignment = Element.ALIGN_LEFT;
                leftAuthoritydetailscell.AddElement(tendAuthoritypositionparagraph1);

                tableAuthoritydetails.AddCell(leftAuthoritydetailscell);


                PdfPCell rightAuthoritydetailscell = new PdfPCell();
                rightAuthoritydetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Chunk tenderAuthorityno16 = new Chunk("Authority Position:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderAuthority17 = new Chunk(lblauthposition1.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase tenderAuthorityPh6 = new Phrase
   {
   tenderAuthorityno16,
   tenderAuthority17

   };
                Paragraph tendAuthorityparagraph6 = new Paragraph(tenderAuthorityPh6);
                tendAuthorityparagraph6.Alignment = Element.ALIGN_LEFT;
                rightAuthoritydetailscell.AddElement(tendAuthorityparagraph6);

                Chunk tenderAuthoritypositionno16 = new Chunk("Contact Number:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderAuthorityposition17 = new Chunk(lblconno1.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase tenderAuthoritypositionPh6 = new Phrase
   {
   tenderAuthoritypositionno16,
   tenderAuthorityposition17

   };
                Paragraph tendAuthoritypositionparagraph6 = new Paragraph(tenderAuthoritypositionPh6);
                tendAuthoritypositionparagraph6.Alignment = Element.ALIGN_LEFT;
                rightAuthoritydetailscell.AddElement(tendAuthoritypositionparagraph6);

                tableAuthoritydetails.AddCell(rightAuthoritydetailscell);
                doc.Add(tableAuthoritydetails);
                doc.Add(new Paragraph(" "));

                PdfPTable tableTermscondition = new PdfPTable(1);
                tableTermscondition.WidthPercentage = 100;
                PdfPCell Termsconditioncell = new PdfPCell();
                Termsconditioncell.AddElement(new Paragraph("ClientNotes & Terms&Conditions :-", new Font(Font.FontFamily.HELVETICA, 14f, Font.NORMAL, BaseColor.BLUE)));
                Termsconditioncell.BackgroundColor = BaseColor.LIGHT_GRAY;
                Termsconditioncell.PaddingLeft = 5;
                Termsconditioncell.PaddingBottom = 15;
                tableTermscondition.AddCell(Termsconditioncell);
                doc.Add(tableTermscondition);
              
                PdfPTable NoteTable = new PdfPTable(1);
                NoteTable.WidthPercentage = 100;
                PdfPCell NoteCell = new PdfPCell();
                NoteCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                NoteCell.AddElement(new Paragraph("NOTE :", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                NoteCell.AddElement(new Paragraph(lblclientnote.Text, new Font(Font.FontFamily.HELVETICA, 12f)));
                NoteCell.AddElement(new Paragraph("Terms & Conditions :", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                NoteCell.AddElement(new Paragraph(lbltermsandcodition.Text, new Font(Font.FontFamily.HELVETICA, 12f)));
                NoteCell.AddElement(new Paragraph("  "));
                NoteCell.AddElement(new Paragraph("  "));
                NoteCell.AddElement(new Paragraph("Thank You", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                NoteTable.AddCell(NoteCell);
                doc.Add(NoteTable);
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Close();
                writer.Close();
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + lblworkorderno1.Text + ".pdf");
                HttpContext.Current.Response.BinaryWrite(memoryStream.ToArray());
                HttpContext.Current.Response.Flush();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
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

        //------------------------------Filter----------------------------------//

        protected void lnkbtnALL_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                if (Session["LoginType"].ToString() == "Administrator")
                {

                    GetbyWorkOrderNo();
                    ViewWorkorderDetails();
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
            finally { }
        }

        protected void LinkViewNotsend_Click(object sender, EventArgs e)
        {
            try
            {
                string linkStatus = LinkViewDraft.Text;
                ViewFilterByStatus(linkStatus);
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

        protected void linkbtnpublished_Click(object sender, EventArgs e)
        {
            try
            {
                string linkStatus = linkbtnpublished.Text;
                ViewFilterByStatus(linkStatus);
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

        protected void linkbtnnotpublished_Click(object sender, EventArgs e)
        {
            try
            {
                string linkStatus = linkbtnnotpublished.Text;
                ViewFilterByStatus(linkStatus);
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

        protected void LinkViewAccept_Click(object sender, EventArgs e)
        {
            try
            {
                string linkStatus = LinkViewAccept.Text;
                ViewFilterByStatus(linkStatus);

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

        protected void LinkViewdeclined_Click(object sender, EventArgs e)
        {
            try
            {
                string linkStatus = LinkViewdeclined.Text;
                ViewFilterByStatus(linkStatus);

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

        protected void Linkbtnedit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditWorkOrder.aspx");
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
                    DataTable dt = ViewWorkorderDetails();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        Response.AddHeader("Content-Disposition", "attachment;filename=WorkOrder_Details.xls");

                        Response.Charset = " ";


                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("ContactVender");
                        dtExport.Columns.Add("Vend_Name");
                        dtExport.Columns.Add("ProjectName");
                        dtExport.Columns.Add("TenderNumber");
                        dtExport.Columns.Add("WorkOrderNumber");
                        dtExport.Columns.Add("publishdate");
                        dtExport.Columns.Add("CompletionDate");
                        dtExport.Columns.Add("TotalAmountTender");

                        dtExport.Columns.Add("TenderBased");

                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["ID"];
                            newRow["ContactVender"] = row["ContactVender"];
                            newRow["VendName"] = row["Vend_Name"];
                            newRow["ProjectName"] = row["ProjectName"];
                            newRow["TenderNumber"] = row["TenderNumber"];
                            newRow["WorkOrderNumber"] = row["WorkOrderNumber"];
                            newRow["publishdate"] = row["publishdate"];
                            newRow["CompletionDate"] = row["CompletionDate"];
                            newRow["TotalAmountTender"] = row["TotalAmountTender"];
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
                else if (RoleType == Designation)
                {
                    DataTable dt = (DataTable)ViewState["WorkData"];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        Response.AddHeader("Content-Disposition", "attachment;filename=WorkOrder_Details.xls");

                        Response.Charset = " ";


                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("ContactVender");
                        dtExport.Columns.Add("Vend_Name");
                        dtExport.Columns.Add("ProjectName");
                        dtExport.Columns.Add("TenderNumber");
                        dtExport.Columns.Add("WorkOrderNumber");
                        dtExport.Columns.Add("publishdate");
                        dtExport.Columns.Add("CompletionDate");
                        dtExport.Columns.Add("TotalAmountTender");

                        dtExport.Columns.Add("TenderBased");

                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["ID"];
                            newRow["ContactVender"] = row["ContactVender"];
                            newRow["VendName"] = row["Vend_Name"];
                            newRow["ProjectName"] = row["ProjectName"];
                            newRow["TenderNumber"] = row["TenderNumber"];
                            newRow["WorkOrderNumber"] = row["WorkOrderNumber"];
                            newRow["publishdate"] = row["publishdate"];
                            newRow["CompletionDate"] = row["CompletionDate"];
                            newRow["TotalAmountTender"] = row["TotalAmountTender"];
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

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void Btn_Reload_Click(object sender, EventArgs e)
        {
            ViewWorkorderDetails();
        }

        protected void Btn_CreateWorkOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewWorkOrder.aspx");
        }
      
        protected void LinkViewCancelled_Click(object sender, EventArgs e)
        {
            try
            {
                string linkStatus = LinkViewCancelled.Text;
                ViewFilterByStatus(linkStatus);

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

        protected void LinkViewDraft_Click(object sender, EventArgs e)
        {
            try
            {
                string linkStatus = LinkViewDraft.Text;
                ViewFilterByStatus(linkStatus);

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

        protected void radiolistWorkOrderYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_ShowFilterWorkOrderDetailsByYear", UserCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ByYear", Convert.ToInt32(radiolistWorkOrderYear.SelectedItem.Text));
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(table);
                    GridWorkorderlist.DataSource = table;
                    GridWorkorderlist.DataBind();
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

        protected void radioSaleAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_ShowFilterWorkOrderDetailsByYear", UserCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SaleAgent", radioSaleAgent.SelectedItem.Text);
               
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(table);
                    GridWorkorderlist.DataSource = table;
                    GridWorkorderlist.DataBind();
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
        //------------------------------More----------------------------------//

        protected void lnkbtnpublished_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    UserCon.Open();
                    using (SqlCommand UserCommand = new SqlCommand("SP_UpdateWorkOrderStatus", UserCon))
                    {
                        UserCommand.CommandType = CommandType.StoredProcedure;
                        UserCommand.Parameters.AddWithValue("@TenderNumber", lbltendno1.Text);
                        UserCommand.Parameters.AddWithValue("@WorkOrderNumber", lblworkno.Text);
                        UserCommand.Parameters.AddWithValue("@status", "Published");
                        UserCommand.Parameters.AddWithValue("@publish", "true");
                        UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                        UserCommand.Parameters.AddWithValue("@Designation", Designation);
                        UserCommand.Parameters.AddWithValue("@created_by", UserName);

                        int i = UserCommand.ExecuteNonQuery();

                        if (i < 0)
                        {
                            lblStatus.Text = "Published";
                            lblStatus.CssClass = "btn btn-sm btn-success";
                          
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Update Successfully!')", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Not Update Successfully!')", true);
                        }
                    }
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

        protected void lnkbtnNotPublished_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    UserCon.Open();
                    using (SqlCommand UserCommand = new SqlCommand("SP_UpdateWorkOrderStatus", UserCon))
                    {
                        UserCommand.CommandType = CommandType.StoredProcedure;
                        UserCommand.Parameters.AddWithValue("@TenderNumber", lbltendno1.Text);
                        UserCommand.Parameters.AddWithValue("@WorkOrderNumber", lblworkno.Text);
                        UserCommand.Parameters.AddWithValue("@status", "Not Published");
                        UserCommand.Parameters.AddWithValue("@publish", "false");
                        UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                        UserCommand.Parameters.AddWithValue("@Designation", Designation);
                        UserCommand.Parameters.AddWithValue("@created_by", UserName);

                        int i = UserCommand.ExecuteNonQuery();

                        if (i < 0)
                        {
                            lblStatus.Text = "Not Published";
                            lblStatus.CssClass = "btn btn-sm btn-danger";
                           
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Update Successfully!')", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Not Update Successfully!')", true);
                        }
                    }
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

        protected void LinkStatusAccepted_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    UserCon.Open();
                    using (SqlCommand UserCommand = new SqlCommand("SP_UpdateWorkOrderAccepted", UserCon))
                    {
                        UserCommand.CommandType = CommandType.StoredProcedure;
                        UserCommand.Parameters.AddWithValue("@TenderNumber", lbltendno1.Text);
                        UserCommand.Parameters.AddWithValue("@WorkOrderNumber", lblworkno.Text);
                        UserCommand.Parameters.AddWithValue("@status", "Accepted");
                        UserCommand.Parameters.AddWithValue("@Accepted", "true");
                        UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                        UserCommand.Parameters.AddWithValue("@Designation", Designation);
                        UserCommand.Parameters.AddWithValue("@created_by", UserName);

                        int i = UserCommand.ExecuteNonQuery();

                        if (i < 0)
                        {
                            lblStatus.Text = "Accepted";
                            lblStatus.CssClass = "btn btn-sm btn-success";
                            
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Update Successfully!')", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Not Update Successfully!')", true);
                        }
                        UserCon.Close();
                    }
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

        protected void LinkStatusdeclined_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    UserCon.Open();
                    using (SqlCommand UserCommand = new SqlCommand("SP_UpdateWorkOrderDeclined", UserCon))
                    {
                        UserCommand.CommandType = CommandType.StoredProcedure;
                        UserCommand.Parameters.AddWithValue("@TenderNumber", lbltendno1.Text);
                        UserCommand.Parameters.AddWithValue("@WorkOrderNumber", lblworkno.Text);
                        UserCommand.Parameters.AddWithValue("@status", "Declined");
                        UserCommand.Parameters.AddWithValue("@Declined", "true");
                        UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                        UserCommand.Parameters.AddWithValue("@Designation", Designation);
                        UserCommand.Parameters.AddWithValue("@created_by", UserName);

                        int i = UserCommand.ExecuteNonQuery();

                        if (i < 0)
                        {
                            lblStatus.Text = "Declined";
                            lblStatus.CssClass = "btn btn-sm btn-danger";
                          
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Update Successfully!')", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Not Update Successfully!')", true);
                        }
                        UserCon.Close();
                    }
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

        protected void LinkStatusCancelled_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    UserCon.Open();
                    using (SqlCommand UserCommand = new SqlCommand("SP_UpdateWorkOrderCanceled", UserCon))
                    {
                        UserCommand.CommandType = CommandType.StoredProcedure;
                        UserCommand.Parameters.AddWithValue("@TenderNumber", lbltendno1.Text);
                        UserCommand.Parameters.AddWithValue("@WorkOrderNumber", lblworkno.Text);
                        UserCommand.Parameters.AddWithValue("@status", "Canceled");
                        UserCommand.Parameters.AddWithValue("@Canceled", "true");
                        UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                        UserCommand.Parameters.AddWithValue("@Designation", Designation);
                        UserCommand.Parameters.AddWithValue("@created_by", UserName);

                        int i = UserCommand.ExecuteNonQuery();

                        if (i < 0)
                        {
                            lblStatus.Text = "Canceled";
                            lblStatus.CssClass = "btn btn-sm btn-danger";
                            
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Update Successfully!')", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Not Update Successfully!')", true);
                        }
                        UserCon.Close();
                    }
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

        protected void LinkStatusDraft_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    UserCon.Open();
                    using (SqlCommand UserCommand = new SqlCommand("SP_UpdateWorkOrderSaveAs", UserCon))
                    {
                        UserCommand.CommandType = CommandType.StoredProcedure;
                        UserCommand.Parameters.AddWithValue("@TenderNumber", lbltendno1.Text);
                        UserCommand.Parameters.AddWithValue("@WorkOrderNumber", lblworkno.Text);
                        UserCommand.Parameters.AddWithValue("@SaveAs", "Draft");
                        UserCommand.Parameters.AddWithValue("@status1", "false");
                        UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                        UserCommand.Parameters.AddWithValue("@Designation", Designation);
                        UserCommand.Parameters.AddWithValue("@created_by", UserName);

                        int i = UserCommand.ExecuteNonQuery();

                        if (i < 0)
                        {
                            lblStatus.Text = "Darft";
                            lblStatus.CssClass = "btn btn-sm btn-secondary";
                          
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Update Successfully!')", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Not Update Successfully!')", true);
                        }
                        UserCon.Close();
                    }
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

        protected void lnkbtncopyworkorder_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewWorkOrder.aspx");
        }

        protected void lnkbtndelworkorder_Click(object sender, EventArgs e)
        {
            try
            {
                string ID;
                var rows = GridWorkorderlist.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                SqlConnection DeviceCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_DeleteWorkOrder", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Created_by", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Work Order Details Deleted Successfully!')", true);

                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Work Order Details Not Deleted!')", true);
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
            finally { }
        }

        //----------------------------Unkown Operation------------------------------//

        protected void lnkbtnviewascustmer_Click(object sender, EventArgs e)
        {

        }

        protected void linkbtnSendOverDue_Click(object sender, EventArgs e)
        {

        }


        #endregion
    }
}