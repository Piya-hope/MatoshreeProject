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


#endregion

namespace MatoshreeProject
{
    public partial class Inventory_Product : System.Web.UI.Page
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

        //----------------------------------------------------//
        //int _totalColumns = 8;//
        //string strImgPath;
        //Document _document;
        //Font _fontStyle;
        //PdfPTable _pdfPTable = new PdfPTable(8);//change
        //PdfPCell _pdfPCell;
        //MemoryStream _memoryStream = new MemoryStream();

        Phrase phrase = null;

        //----------------------------------------------------//


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
                    ddlDepo.Items.Insert(0, new ListItem("Select Depo", "0"));
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

        public void GetCompanyAddress()
        {
            try
            {

                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetCompanyAddress", UserCon);
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
                using (SqlConnection DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    //System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    //string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    //string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    //Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    //SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    //cmdex.CommandType = CommandType.StoredProcedure;
                    //cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    //cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    //cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    //cmdex.Parameters.AddWithValue("@Method", method);
                    //cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    //DeviceCon.Open();
                    //int RowEx = cmdex.ExecuteNonQuery();
                    //if (RowEx < 0)
                    //{
                    //    //lblMessage.Visible = false;
                    //    //lblMessage.Text = "Error Details Save Successfully";
                    //}
                    //else
                    //{
                    //    //lblMessage.Visible = false;
                    //    //lblMessage.Text = "Error Details Not Save Successfully";
                    //}
                }
            }
            finally
            {
            }
        }

        public DataTable ViewInventoryProdDetailsByEmpID(int UserID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_InventoryProduct_DetailsbyEmpID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", UserID);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridInventoryProd.DataSource = table;
                GridInventoryProd.DataBind();
                ViewState["DataInventoryProd"] = table;
            }
            return table;
        }

        public void InventoryProdCountByEmpID(int UserID)
        {
            try
            {
                //-------------TotalCount----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetTotalInventoryProdCountByEmpID", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int totalInventoryProdsCount = (int)command.ExecuteScalar();

                    lblTotalInventoryProdCount.Text = Convert.ToString(totalInventoryProdsCount);
                }

                //-------------ActiveCount----------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetActiveInventoryProdCountByEmpID", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int activeInventoryProdsCount = (int)command.ExecuteScalar();

                    lblActiveInventoryProdsCount.Text = Convert.ToString(activeInventoryProdsCount);
                }

                //-------------InActiveCount----------------------//

                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetInActiveInventoryProdCountByEmpID", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int inactiveInventoryProdsCount = (int)command.ExecuteScalar();

                    lblInActiveInventoryProdsCount.Text = Convert.ToString(inactiveInventoryProdsCount);
                }
            }
            catch (Exception ex)
            {
                using (SqlConnection DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    //System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    //string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    //string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    //Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    //SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    //cmdex.CommandType = CommandType.StoredProcedure;
                    //cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    //cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    //cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    //cmdex.Parameters.AddWithValue("@Method", method);
                    //cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    //DeviceCon.Open();
                    //int RowEx = cmdex.ExecuteNonQuery();
                    //if (RowEx < 0)
                    //{
                    //    //lblMessage.Visible = false;
                    //    //lblMessage.Text = "Error Details Save Successfully";
                    //}
                    //else
                    //{
                    //    //lblMessage.Visible = false;
                    //    //lblMessage.Text = "Error Details Not Save Successfully";
                    //}
                }
            }

        }
        //-----------------------------------------------------------------------------//
        public DataTable ViewInventoryProdDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_InventoryProduct_Details", con))
                {
                    ad.Fill(table);
                    GridInventoryProd.DataSource = table;
                    GridInventoryProd.DataBind();
                    ViewState["DataInventoryProd"] = table;
                }
            }
            return table;
        }

        public DataTable ViewInventoryProdDetailsByDepo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_InventoryProduct_DetailsByDepo", con))
                {
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure; // Set command type to stored procedure                 
                    ad.SelectCommand.Parameters.AddWithValue("@DepoID", ddlDepo.SelectedItem.Value);
                    ad.Fill(dt);
                    GridInventoryProd.DataSource = dt;
                    GridInventoryProd.DataBind();
                }
            }
            return dt;
        }

        //------------------------------------InventoryProdCount-----------------------------------------//
        public void InventoryProdCount()
        {
            try
            {
                //-------------TotalCount----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetTotalInventoryProdCount", con);
                    command.CommandType = CommandType.StoredProcedure;

                    int totalInventoryProdsCount = (int)command.ExecuteScalar();

                    lblTotalInventoryProdCount.Text = Convert.ToString(totalInventoryProdsCount);
                }

                //-------------ActiveCount----------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetActiveInventoryProdCount", con1);
                    command.CommandType = CommandType.StoredProcedure;

                    int activeInventoryProdsCount = (int)command.ExecuteScalar();

                    lblActiveInventoryProdsCount.Text = Convert.ToString(activeInventoryProdsCount);
                }

                //-------------InActiveCount----------------------//

                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetInactiveInventoryProdCount", con2);
                    command.CommandType = CommandType.StoredProcedure;

                    int inactiveInventoryProdsCount = (int)command.ExecuteScalar();

                    lblInActiveInventoryProdsCount.Text = Convert.ToString(inactiveInventoryProdsCount);
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

        //---------------------------------InventoryProdCountByDepo-----------------------------------------//
        public void InventoryProdCountByDepoID()
        {
            try
            {
                //-------------TotalCount----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetTotalInventoryProdCountByDepo", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DepoID", ddlDepo.SelectedItem.Value);
                    int totalInventoryProdsCount = (int)command.ExecuteScalar();

                    lblTotalInventoryProdCount.Text = Convert.ToString(totalInventoryProdsCount);
                }

                //-------------ActiveCount----------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetActiveInventoryProdCountByDepo", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DepoID", ddlDepo.SelectedItem.Value);
                    int activeInventoryProdsCount = (int)command.ExecuteScalar();

                    lblActiveInventoryProdsCount.Text = Convert.ToString(activeInventoryProdsCount);
                }

                //-------------InActiveCount----------------------//

                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetInactiveInventoryProdCountByDepo", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DepoID", ddlDepo.SelectedItem.Value);
                    int inactiveInventoryProdsCount = (int)command.ExecuteScalar();

                    lblInActiveInventoryProdsCount.Text = Convert.ToString(inactiveInventoryProdsCount);
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
                    command.Parameters.AddWithValue("@SubModule", "InventoryProduct");
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
                            ViewInventoryProdDetails();
                            InventoryProdCount();
                            GetCompanyAddress();

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

                                GridInventoryProd.Columns[14].Visible = true;
                            }
                            else
                            {

                                GridInventoryProd.Columns[14].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                GridInventoryProd.Columns[15].Visible = true;
                            }
                            else
                            {

                                GridInventoryProd.Columns[15].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {
                            ViewInventoryProdDetailsByEmpID(UserId);
                            InventoryProdCountByEmpID(UserId);
                            GetCompanyAddress();
                            bindDepoEmpID();
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

                                GridInventoryProd.Columns[14].Visible = true;
                            }
                            else
                            {

                                GridInventoryProd.Columns[14].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                GridInventoryProd.Columns[15].Visible = true;
                            }
                            else
                            {

                                GridInventoryProd.Columns[15].Visible = false;
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
                    lblMessage.Text = "Inventory Product Details Save Successfully";
                }
                else if (EdidDATA == "xcvfedit" && MSGdata == null)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Inventory Product Details Edit Successfully";
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

        #region " Events"

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

                        if (!this.IsPostBack)
                        {
                            bindDepo();
                            ViewInventoryProdDetails();
                            InventoryProdCount();
                            GetCompanyAddress();
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
                             
                                GetCompanyAddress();
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

        protected void btnNewInventoryProd_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewInventory_Product.aspx", false);
            //  Response.Redirect("~/NewInventory_Product.aspx?UserID=" + UserId + "", false);

        }

        protected void lnkbtnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ViewInventoryProdDetails();
                if (dt != null && dt.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/ms-excel";
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "InventoryProduct_Details " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));
                    Response.Charset = " ";
                    DataTable dtExport = new DataTable();
                    dtExport.Columns.Add("ID");
                    dtExport.Columns.Add("ProdName");
                    dtExport.Columns.Add("Usable");
                    dtExport.Columns.Add("DepoName");
                    dtExport.Columns.Add("Description");
                    dtExport.Columns.Add("Category");
                    dtExport.Columns.Add("Quantity");
                    dtExport.Columns.Add("Rate");
                    dtExport.Columns.Add("TotalAmount");
                    dtExport.Columns.Add("AddedBy");
                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow newRow = dtExport.NewRow();
                        newRow["ID"] = row["ID"];
                        newRow["ProdName"] = row["ProductName"];
                        newRow["Usable"] = row["ProductType"];
                        newRow["DepoName"] = row["DepoName"];
                        newRow["Description"] = row["Description"];
                        newRow["Category"] = row["Category"];
                        newRow["Quantity"] = row["Quantity"];
                        newRow["Rate"] = row["Rate"];
                        newRow["TotalAmount"] = row["TotalAmount"];
                        newRow["AddedBy"] = row["CreateBy"];
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

        private static void DrawLine(iTextSharp.text.pdf.PdfWriter writer, float x1, float y1, float x2, float y2, BaseColor color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(BaseColor.BLACK);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }

        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.Colspan = 4;
            cell.BorderColor = BaseColor.WHITE;
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
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 4f;
            cell.PaddingTop = 2f;
            return cell;
        }

        protected void linkbtnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                int _totalColumns = 10;//
                string path = Image1.ImageUrl;
                iTextSharp.text.Font _fontStyle;
                PdfPTable _pdfPTable = new PdfPTable(10);//change
                PdfPCell _pdfPCell;
                PdfPCell cell = null;


                Document _document = new Document(PageSize.A4, 0, 0, 0, 0);
                _document.SetPageSize(PageSize.A4);
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
                    _pdfPTable.SetWidths(new float[] { 4f, 11f, 11f, 14f, 9f, 10f, 11f, 11f, 9f, 9f });//column width in doc       
                    //----Header PDF--------------------------//
                    //Company Logo
                    cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 3;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPTable.AddCell(cell);

                    //...!..image logo..// 

                    phrase = new Phrase();
                    phrase.Add(new Chunk(lbladdCompany11.Text + "\n", FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk(lbladdress11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                    phrase.Add(new Chunk(lblcompanyaddCity1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                    phrase.Add(new Chunk(lblcompanyaddDistrict1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                    phrase.Add(new Chunk(lblcompanyaddState1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                    phrase.Add(new Chunk(lblcompanyaddCountry1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                    phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                    phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                    _pdfPCell = new PdfPCell(phrase);
                    _pdfPCell.Colspan = 10;
                    _pdfPCell.BorderColor = BaseColor.WHITE;
                    _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.PaddingBottom = 1f;
                    _pdfPCell.PaddingTop = 0f;
                    _pdfPCell.Border = 0;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 4;
                    _pdfPTable.AddCell(_pdfPCell);
                    _pdfPTable.CompleteRow();

                    _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                    _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                    _pdfPCell.Colspan = 11;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.Border = 2;
                    _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 4;
                    _pdfPTable.AddCell(_pdfPCell);
                    _pdfPTable.CompleteRow();

                    _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                    _pdfPCell = new PdfPCell(new Phrase("InventoryProductList", _fontStyle));
                    _pdfPCell.Colspan = 6;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    _pdfPCell.Border = 0;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 4;
                    _pdfPTable.AddCell(_pdfPCell);

                    //-------Date------------------------------//
                    DateTime PrintTime = DateTime.Now;
                    _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                    _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                    _pdfPCell.Colspan = 4;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    _pdfPCell.Border = 0;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 3;
                    _pdfPTable.AddCell(_pdfPCell);
                    _pdfPTable.CompleteRow();


                    _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                    _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*-------------------------------------", _fontStyle));
                    _pdfPCell.Colspan = _totalColumns;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.Border = 0;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 4;
                    _pdfPTable.AddCell(_pdfPCell);
                    _pdfPTable.CompleteRow();

                    DataTable _Vhrlist = new DataTable();
                    _Vhrlist = ViewInventoryProdDetails();
                    #region "Table Header"

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("ProdName", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("Usable", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("Depo", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("Desc", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("Category", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("Quantity", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("Rate", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("TotalAmt", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                    _pdfPCell = new PdfPCell(new Phrase("AddedBy", _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.GRAY;
                    _pdfPCell.ExtraParagraphSpace = 2;
                    _pdfPTable.AddCell(_pdfPCell);

                    _pdfPTable.CompleteRow();
                    #endregion

                    #region "Table Body"
                    _fontStyle = FontFactory.GetFont("Tahoma", 10f, 0);
                    int serialnumber = 1;

                    foreach (DataRow row in _Vhrlist.Rows)
                    {
                        _pdfPCell = new PdfPCell(new Phrase(serialnumber++.ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["ProductName"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["ProductType"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["DepoName"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["Description"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["Category"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["Quantity"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["Rate"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(row["TotalAmount"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 1;
                        _pdfPTable.AddCell(_pdfPCell);


                        _pdfPCell = new PdfPCell(new Phrase(row["CreateBy"].ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
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
                    string PDFFileName = string.Format("InventoryProductList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + PDFFileName);
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();

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
            try
            {
                string DepoID = ddlDepo.SelectedItem.Value;
                if (DepoID == "0")
                {
                    ViewInventoryProdDetails();
                    InventoryProdCount();
                }
                else
                {
                    ViewInventoryProdDetailsByDepo();
                    InventoryProdCountByDepoID();
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

        protected void BTN_Visibility_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_InventoryProdDetailsVisibility", con))
                    {
                        ad.Fill(table);
                        GridInventoryProd.DataSource = table;
                        GridInventoryProd.DataBind();
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

        protected void Btn_Reload_Click(object sender, EventArgs e)
        {
            try
            {
                ViewInventoryProdDetails();
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

        protected void GridInventoryProd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviewrow in GridInventoryProd.Rows)
                {
                    Label lblInventoryProdID1 = (Label)gridviewrow.FindControl("lblInventoryProdID1");
                    Label lblProductName1 = (Label)gridviewrow.FindControl("lblProductName1");
                    Label lblProductType1 = (Label)gridviewrow.FindControl("lblProductType1");
                    Label lblDepo1 = (Label)gridviewrow.FindControl("lblDepo1");
                    Label lblDescription1 = (Label)gridviewrow.FindControl("lblDescription1");
                    Label lblQuantity1 = (Label)gridviewrow.FindControl("lblQuantity1");
                    Label lblRate1 = (Label)gridviewrow.FindControl("lblRate1");
                    Label lblTotalAmount1 = (Label)gridviewrow.FindControl("lblTotalAmount1");
                    Label lblCategory1 = (Label)gridviewrow.FindControl("lblCategory1");
                    Label lblCreatedate1 = (Label)gridviewrow.FindControl("lblCreatedate1");
                    Label lblCreateBy1 = (Label)gridviewrow.FindControl("lblCreateBy1");
                    string status = ((Label)gridviewrow.FindControl("lblStatus1")).Text;
                    if (status == "True")
                    {
                        lblInventoryProdID1.ForeColor = System.Drawing.Color.Black;
                        lblProductName1.ForeColor = System.Drawing.Color.Blue;
                        lblProductType1.ForeColor = System.Drawing.Color.Blue;
                        lblDepo1.ForeColor = System.Drawing.Color.Black;
                        lblDescription1.ForeColor = System.Drawing.Color.Black;
                        lblQuantity1.ForeColor = System.Drawing.Color.Blue;
                        lblRate1.ForeColor = System.Drawing.Color.Black;
                        lblTotalAmount1.ForeColor = System.Drawing.Color.Blue;
                        lblCategory1.ForeColor = System.Drawing.Color.Black;
                        lblCreatedate1.ForeColor = System.Drawing.Color.Blue;
                        lblCreateBy1.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        lblInventoryProdID1.ForeColor = System.Drawing.Color.Red;
                        lblProductName1.ForeColor = System.Drawing.Color.Red;
                        lblProductType1.ForeColor = System.Drawing.Color.Red;
                        lblDepo1.ForeColor = System.Drawing.Color.Red;
                        lblDescription1.ForeColor = System.Drawing.Color.Red;
                        lblQuantity1.ForeColor = System.Drawing.Color.Red;
                        lblRate1.ForeColor = System.Drawing.Color.Red;
                        lblTotalAmount1.ForeColor = System.Drawing.Color.Red;
                        lblCategory1.ForeColor = System.Drawing.Color.Red;
                        lblCreatedate1.ForeColor = System.Drawing.Color.Red;
                        lblCreateBy1.ForeColor = System.Drawing.Color.Red;
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

        protected void btnEditProd_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string tableID;
                var rows = GridInventoryProd.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                tableID = ((Label)rows[rowindex].FindControl("lblDepoID")).Text;

                Response.Redirect("~/EditInventory_Product.aspx?ID=" + tableID + "", false);
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

        //protected void btnDeleteProd_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        RoleType = Session["LoginType"].ToString();
        //        Designation = Session["Role"].ToString();
        //        UserId = Convert.ToInt32(Session["UserID"]);
        //        string ID;
        //        var rows = GridInventoryProd.Rows;
        //        LinkButton btn = (LinkButton)sender;
        //        GridViewRow row = (GridViewRow)btn.NamingContainer;
        //        int rowindex = Convert.ToInt32(row.RowIndex);
        //        ID = ((Label)rows[rowindex].FindControl("lblInventoryProdID1")).Text;

        //        SqlConnection DeviceCon = new SqlConnection(strconnect);
        //        SqlCommand cmd = new SqlCommand("SP_DeleteInventoryProduct", DeviceCon);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@ID", ID);
        //        cmd.Parameters.AddWithValue("@CreateBy", UserName);
        //        cmd.Parameters.AddWithValue("@EmpID", UserId);
        //        cmd.Parameters.AddWithValue("@Designation", Designation);
        //        DeviceCon.Open();
        //        int i = cmd.ExecuteNonQuery();
        //        DeviceCon.Close();
        //        if (i < 0)
        //        {
        //            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Inventory Prod Deleted Successfully!')", true);

        //            ViewInventoryProdDetails();
        //        }
        //        else
        //        {
        //            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Inventory Prod Not Deleted!')", true);
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        using (SqlConnection DeviceCon = new SqlConnection(strconnect))
        //        {
        //            string ErrorMessgage = ex.Message;
        //            //System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
        //            //string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
        //            //string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
        //            //Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
        //            //SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
        //            //cmdex.CommandType = CommandType.StoredProcedure;
        //            //cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
        //            //cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
        //            //cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
        //            //cmdex.Parameters.AddWithValue("@Method", method);
        //            //cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
        //            //DeviceCon.Open();
        //            //int RowEx = cmdex.ExecuteNonQuery();
        //            //if (RowEx < 0)
        //            //{
        //            //    //lblMessage.Visible = false;
        //            //    //lblMessage.Text = "Error Details Save Successfully";
        //            //}
        //            //else
        //            //{
        //            //    //lblMessage.Visible = false;
        //            //    //lblMessage.Text = "Error Details Not Save Successfully";
        //            //}
        //        }
        //    }
        //    finally { }
        //}

        #endregion
    }
}