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
//using DocumentFormat.OpenXml.Office.Word;

#endregion


namespace MatoshreeProject
{
    public partial class NewPaymentRequest : System.Web.UI.Page
    {
        #region " Class Level Variable "
         string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string billchk, ChkboxcreateInvoce, ChkBoxcustomeremail;
        string Size, Initial, ReceiptFor, Cash, Bank, reminder;
        string result;
        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        string  Infinitychk, TaxName;




        #endregion

        #region " Constructor "


        #endregion

        #region " Private Variables "


        #endregion

        #region " Shared Variables "


        #endregion

        #region " Public Variables "
        int  Id;
        #endregion

        #region " Public Properties "


        #endregion

        #region " Private Functions "


        #endregion

        #region " Protected Functions "
        public void Clear()
        {
            //txtItem.Text = string.Empty;
            //txtQty.Text = string.Empty;
            //txtRate.Text = string.Empty;
            //txtDescription.Text = string.Empty;
            txtCurrency.Text = string.Empty;
            //txtExpenseName.Text = string.Empty;
            txtExpensesDate.Text = string.Empty;
            txtNote.Text = string.Empty;
            // txtReference.Text = string.Empty;
            ddlSubCategory.SelectedIndex = 0;
            ddlExpensesCategory.SelectedIndex = 0;
            ddlPaymentMode.SelectedIndex = 0;
            ddlProject.SelectedIndex = 0;
            ddlCustomer.SelectedIndex = 0;
            // txtBillno.Text = string.Empty;
            txtother.Text = string.Empty;
            ddlExpensesType.SelectedIndex = 0;

            Calculatefilldata();
            ViewFileExpensesDetails();
            bindItem();
            bindTax();
        }



        #endregion

        #region " Public Functions "
        protected void bindItem()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetItemName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlItem.DataSource = ds.Tables[0];
                    ddlItem.DataTextField = "Description";//Description item
                    ddlItem.DataValueField = "ID";
                    ddlItem.DataBind();
                    ddlItem.Items.Insert(0, new ListItem("Select Item", "0"));
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

        protected void bindTax()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetTaxename", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlTaxitem.DataSource = ds.Tables[0];
                    ddlTaxitem.DataTextField = "Tax_Name";
                    ddlTaxitem.DataValueField = "Tax_Id";
                    ddlTaxitem.DataBind();
                    ddlTaxitem.Items.Insert(0, new ListItem("Select Tax", "0"));

                    ddlTaxItem1.DataSource = ds.Tables[0];
                    ddlTaxItem1.DataTextField = "Tax_Name";
                    ddlTaxItem1.DataValueField = "Tax_Id";
                    ddlTaxItem1.DataBind();
                    ddlTaxItem1.Items.Insert(0, new ListItem("Select Tax", "0"));
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
        protected void bindcustomer()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetCustomerName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlCustomer.DataSource = ds.Tables[0];
                    ddlCustomer.DataTextField = "Cust_Name";
                    ddlCustomer.DataValueField = "Cust_ID";
                    ddlCustomer.DataBind();
                    ddlCustomer.Items.Insert(0, new ListItem("Select Customer", "0"));
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
        protected void bindproject()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetProjectName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlProject.DataSource = ds.Tables[0];
                    ddlProject.DataTextField = "ProjectName";
                    ddlProject.DataValueField = "ID";
                    ddlProject.DataBind();
                    ddlProject.Items.Insert(0, new ListItem("Select Project", "0"));
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


        public void GetTotalAmount()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetTotalAmountBillItemExpenses", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PayReqID", lblexpid2.Text);
                cmd.Parameters.AddWithValue("@Belong", "Payment Request");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    lblSubTotalCost.Text = "₹ " + dt.Rows[0]["Amount"].ToString();
                }
                else
                {
                    lblSubTotalCost.Text = "₹ " + "0";
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
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlExpensesCategory.DataSource = ds.Tables[0];
                    ddlExpensesCategory.DataTextField = "Category_Name";
                    ddlExpensesCategory.DataValueField = "ID";
                    ddlExpensesCategory.DataBind();
                    ddlExpensesCategory.Items.Insert(0, new ListItem("Select Category", "0"));
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

        protected void bindSubCategory()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetExpSubCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlExpensesCategory.DataSource = ds.Tables[0];
                    ddlExpensesCategory.DataTextField = "Sub_Category_Name";
                    ddlExpensesCategory.DataValueField = "ID";
                    ddlExpensesCategory.DataBind();
                    ddlExpensesCategory.Items.Insert(0, new ListItem("Select Sub Category", "0"));
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

        protected void bindSubCategory(string category)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetExpSubCategory1", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Category", category);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlSubCategory.DataSource = ds.Tables[0];
                    ddlSubCategory.DataTextField = "Sub_Category_Name";
                    ddlSubCategory.DataValueField = "ID";
                    ddlSubCategory.DataBind();
                    ddlSubCategory.Items.Insert(0, new ListItem("Select SubCategory", "0"));
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
        #endregion

        #region "Events "
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
                            string Todaydate = Convert.ToString(DateTime.Today);
                            txtExpensesDate.Attributes["value"] = DateTime.Parse(Todaydate.ToString()).ToString("yyyy-MM-dd");
                            bindcustomer();
                            bindproject();
                            bindItem();
                            bindTax();
                            Calculatefilldata();
                            ViewFileExpensesDetails();
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
                                BindCategoryName();
                                string Todaydate = Convert.ToString(DateTime.Today);
                                txtExpensesDate.Attributes["value"] = DateTime.Parse(Todaydate.ToString()).ToString("yyyy-MM-dd");
                                bindcustomer();
                                bindproject();
                                bindItem();
                                bindTax();
                                Calculatefilldata();
                                ViewFileExpensesDetails();
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

        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSubCategory.SelectedItem.Text == "Other")
                {
                    txtother.Visible = true;
                }
                else
                {
                    txtother.Visible = false;
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
                if (ddlExpensesCategory.SelectedItem.Text == "Project Expenses")
                {
                    DDLAll.Visible = true;
                }
                else
                {
                    DDLAll.Visible = false;
                }

                int categoryid = Convert.ToInt32(ddlExpensesCategory.SelectedValue);

                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetSubCategorybycatid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Exp_Category_ID", categoryid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlSubCategory.DataSource = ds.Tables[0];
                    ddlSubCategory.DataTextField = "Sub_Category_Name";
                    ddlSubCategory.DataValueField = "ID";
                    ddlSubCategory.DataBind();
                    ddlSubCategory.Items.Insert(0, new ListItem("Select SubCategory", "0"));
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


        public void GetMaxID(string BillNo)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GeTMaxIDExpensesMiss ", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BillNo", BillNo);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblexpid2.Text = dt.Rows[0]["MaxExpID"].ToString();

                    //GetPaymentReqExpensesDataByID();
                }
                else
                {
                    lblexpid2.Text = dt.Rows[0]["MaxExpID"].ToString();//null not generated
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

        protected void btnSaveAll_Click1(object sender, EventArgs e)
        {
            try
            {
                txtCurrency.Text = "INR";
                lblBillNoretrive.Text = txtBillno.Text;
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand UserCommand = new SqlCommand("SP_SaveMiscellaneousExpenses", UserCon);
                UserCommand.Connection = UserCon;
                UserCommand.CommandType = CommandType.StoredProcedure;
                UserCommand.Parameters.AddWithValue("@Exp_Name", txtExpenseName.Text);
                UserCommand.Parameters.AddWithValue("@Exp_Note", txtNote.Text);
                UserCommand.Parameters.AddWithValue("@Exp_Category", ddlExpensesCategory.SelectedItem.Text);
                UserCommand.Parameters.AddWithValue("@Exp_SubCategory", ddlSubCategory.SelectedItem.Text);
                UserCommand.Parameters.AddWithValue("@Exp_Date", txtExpensesDate.Text);
                UserCommand.Parameters.AddWithValue("@Exp_Currency", txtCurrency.Text);
                UserCommand.Parameters.AddWithValue("@Exp_Payment", ddlPaymentMode.SelectedItem.Text);
                UserCommand.Parameters.AddWithValue("@CreatedBy", UserName);
                UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                UserCommand.Parameters.AddWithValue("@Designation", Designation);
                UserCommand.Parameters.AddWithValue("@Other", txtother.Text);
                UserCommand.Parameters.AddWithValue("@Customer_id", ddlCustomer.SelectedItem.Value);
                UserCommand.Parameters.AddWithValue("@project_Id", ddlProject.SelectedItem.Value);
                UserCommand.Parameters.AddWithValue("@BillNo", txtBillno.Text);
                UserCommand.Parameters.AddWithValue("@Exp_Type", ddlExpensesType.SelectedItem.Text);
                UserCommand.Parameters.AddWithValue("@SaveAS", "Save");
                UserCon.Open();
                dr = UserCommand.ExecuteReader();
                while (dr.Read())
                {
                    result = dr[0].ToString();
                }
                Result = int.Parse(result);
                if (Result > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Payment Request  Save Successfully!')", true);

                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Payment Request  Already Available!')", true);
                }

                GetMaxID(lblBillNoretrive.Text);
                itemtable.Visible = true;
                btnSaveAll.Visible = true;
                btnSavePaymentRequest.Visible = false;
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
            finally { }
        }

      

        protected void btnSavePaymentRequest_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    txtCurrency.Text = "INR";
                    lblBillNoretrive.Text = txtBillno.Text;
                    UserCon = new SqlConnection(strconnect);
                    UserCommand = new SqlCommand("SP_SaveMiscellaneousExpenses", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@Exp_Name", txtExpenseName.Text);
                    UserCommand.Parameters.AddWithValue("@Exp_Note", txtNote.Text);
                    UserCommand.Parameters.AddWithValue("@Exp_Category", ddlExpensesCategory.SelectedItem.Text);
                    UserCommand.Parameters.AddWithValue("@Exp_SubCategory", ddlSubCategory.SelectedItem.Text);
                    UserCommand.Parameters.AddWithValue("@Exp_Date", txtExpensesDate.Text);
                    UserCommand.Parameters.AddWithValue("@Exp_Currency", txtCurrency.Text);
                    UserCommand.Parameters.AddWithValue("@Exp_Payment", ddlPaymentMode.SelectedItem.Text);
                    UserCommand.Parameters.AddWithValue("@CreatedBy", UserName);
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);
                    UserCommand.Parameters.AddWithValue("@Other", txtother.Text);
                    UserCommand.Parameters.AddWithValue("@Customer_id", ddlCustomer.SelectedItem.Value);
                    UserCommand.Parameters.AddWithValue("@project_Id", ddlProject.SelectedItem.Value);
                    UserCommand.Parameters.AddWithValue("@BillNo", txtBillno.Text);
                    UserCommand.Parameters.AddWithValue("@Exp_Type", ddlExpensesType.SelectedItem.Text);
                    UserCommand.Parameters.AddWithValue("@SaveAS", "Draft");

                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Payment Request  Save Successfully!')", true);

                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Payment Request  Already Available!')", true);
                    }

                    GetMaxID(lblBillNoretrive.Text);                
                    itemtable.Visible = true;
                    btnSaveAll.Visible = true;
                    btnSavePaymentRequest.Visible = false;
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

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            Calculatefilldata();

        }


        //-----------------------------Item Table-------------------------------------------------------


        //---------------------------------------------------------------------------------------------//
        // Expenses Item 
        //---------------------------------------------------------------------------------------------//

        public void Clear1()
        {
            txt_LongDescription.Text = string.Empty;
            txt_Description.Text = string.Empty;
            txt_Rate.Text = string.Empty;
            txtHSNCode.Text = string.Empty;
            ddlTaxitem.SelectedIndex = 0;
            ddlTaxItem1.SelectedIndex = 0;
        }
        protected void ddlTaxitem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int TaxID = Convert.ToInt32(ddlTaxitem.SelectedItem.Value);

                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetTaxRateByID", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaxID", TaxID);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        lblTaxValues1.Text = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        lblTaxValues1.Text = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                    }
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
            finally
            {

            }
        }

        protected void ddlTaxItem1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int TaxID = Convert.ToInt32(ddlTaxItem1.SelectedItem.Value);

                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetTaxRateByID", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaxID", TaxID);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        lblTaxValues2.Text = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        lblTaxValues2.Text = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                    }
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
            finally
            {

            }
        }

        protected void btnSaveItem_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SqlConnection con = new SqlConnection(strconnect);  // db connect
                    SqlCommand cmd = new SqlCommand("SP_SaveItem", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Long_Description", txt_LongDescription.Text);
                    cmd.Parameters.AddWithValue("@Description", txt_Description.Text);
                    cmd.Parameters.AddWithValue("@Rate", txt_Rate.Text);
                    cmd.Parameters.AddWithValue("@HSN", txtHSNCode.Text);
                    cmd.Parameters.AddWithValue("@TaxAmunt", lblTaxValues1.Text);
                    cmd.Parameters.AddWithValue("@TaxName", ddlTaxitem.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@TaxAmunt2", lblTaxValues2.Text);
                    cmd.Parameters.AddWithValue("@TaxName2", ddlTaxItem1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    con.Open();
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
                        lblMesDelete.Text = "Item Details Save Successfully";
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Item Details Not Save Successfully";
                    }
                    bindItem();
                    Clear1();
                    con.Close();
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
                    DeviceCon.Close();
                }
                finally

                {

                }
            }

        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ItemID = Convert.ToInt32(ddlItem.SelectedValue);

                TextBox txtItem = (TextBox)GridViewOffice.FooterRow.FindControl("txtItem");
                TextBox txtDescription = (TextBox)GridViewOffice.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridViewOffice.FooterRow.FindControl("txtQty");
                TextBox txtRate = (TextBox)GridViewOffice.FooterRow.FindControl("txtRate");


                Label lblHSN = (Label)GridViewOffice.FooterRow.FindControl("lblHSN");
                Label lblTotalAmount = (Label)GridViewOffice.FooterRow.FindControl("lblTotalAmount");

                //*//---------------------------------------------------------------//*//
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetItemByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ID", ItemID);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtItem.Text = dt.Rows[0]["Description"].ToString();
                        lblHSN.Text = dt.Rows[0]["HSN"].ToString();
                        txtDescription.Text = dt.Rows[0]["Long_Description"].ToString();

                        if (txtDescription.Text == "")
                        {
                            txtDescription.Text = lblHSN.Text;
                        }
                        else
                        {
                            txtDescription.Text = dt.Rows[0]["Long_Description"].ToString() + "\n" + lblHSN.Text;
                        }

                        txtRate.Text = dt.Rows[0]["Rate"].ToString();
    
                        Double SubTotal;

                        SubTotal = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text);
                        lblTotalAmount.Text = Convert.ToString(SubTotal);



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

        protected void txtRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtQty = (TextBox)GridViewOffice.FooterRow.FindControl("txtQty");
                TextBox txtrate1 = (TextBox)GridViewOffice.FooterRow.FindControl("txtrate1");
                Label lblAmontP = (Label)GridViewOffice.FooterRow.FindControl("lblAmontP");

                float quantity = float.Parse(txtQty.Text);
                float rate = float.Parse(txtrate1.Text);
                float subtotal = quantity * rate;

                lblAmontP.Text = subtotal.ToString();
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
        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtQty = (TextBox)GridViewOffice.FooterRow.FindControl("txtQty");
                TextBox txtrate1 = (TextBox)GridViewOffice.FooterRow.FindControl("txtrate1");
                Label lblTotalAmount = (Label)GridViewOffice.FooterRow.FindControl("lblTotalAmount");

                float quantity = float.Parse(txtQty.Text);
                float rate = float.Parse(txtrate1.Text);
                float subtotal = quantity * rate;

                lblTotalAmount.Text = subtotal.ToString();
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
        public void Calculatefilldata()
        {
            try
            { 
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_GetBillOfficeExpenses", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Exp_Name", txtExpenseName.Text);
                    com.Parameters.AddWithValue("@BillNo", txtBillno.Text);
                    com.Parameters.AddWithValue("@OfiiceExpID", "0");
                    com.Parameters.AddWithValue("@StaffExpID", "0");
                    com.Parameters.AddWithValue("@ProjePurID", "0");
                    com.Parameters.AddWithValue("@PayRequestID", lblexpid2.Text);
                    com.Parameters.AddWithValue("@Exp_id","0");                                  
                    com.Parameters.AddWithValue("@BelongTo", "Payment Request");
                    
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        GridViewOffice.DataSource = dt;
                        GridViewOffice.DataBind();

                        foreach (GridViewRow gridviedrow in GridViewOffice.Rows)
                        {
                            LinkButton btnDeleteItemCal1 = (LinkButton)gridviedrow.FindControl("btnDeleteItemCal");
                            btnDeleteItemCal1.Visible = true;
                        }
                    }
                    else
                    {
                        dt.Rows.Add(dt.NewRow());
                        GridViewOffice.DataSource = dt;
                        GridViewOffice.DataBind();
                        int totalcolums = GridViewOffice.Rows[0].Cells.Count;
                        SuccessDiv1.Visible = false;
                        lblMsg.Visible = false;
                        lblMsg1.Visible = false;
                        msgdiv.Visible = false;

                    }
                    GetTotalAmount();
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
        protected void btnDeleteItemCal_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = GridViewOffice.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                string ItemID = ((Label)rows[rowindex].FindControl("lblItemID")).Text;

                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_DeleteBillOfficeExpenses", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Exp_Name", txtExpenseName.Text);
                    com.Parameters.AddWithValue("@ID", ItemID);
                    com.Parameters.AddWithValue("@CreatedBy", UserName);


                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    con1.Open();
                    int i = com.ExecuteNonQuery();

                    if (i < 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Office Expenses Remove Successfully!')", true);
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Office Expenses Not Remove Available!')", true);
                    }
                    con1.Close();
                    Calculatefilldata();
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

        protected void btnAddBillPaymentRequestItem_Click(object sender, EventArgs e)
        {
            try
            {
                string EmpID;
                if (txtExpenseName.Text == "" || txtBillno.Text == "")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Enter Expenses Name AND Enter  Bill Number!')", true);
                }

                else
                {
                    UserId = Convert.ToInt32(Session["UserID"]);
                    UserName = Session["UserName"].ToString();
                    TextBox txtItem = (TextBox)GridViewOffice.FooterRow.FindControl("txtItem");
                    TextBox txtDescription = (TextBox)GridViewOffice.FooterRow.FindControl("txtDescription");

                    TextBox txtQty = (TextBox)GridViewOffice.FooterRow.FindControl("txtQty");
                    TextBox txtRate = (TextBox)GridViewOffice.FooterRow.FindControl("txtRate");



                    // float Rate = Convert.Tofloat(txtRate.Text);
                    float Rate = (float)Convert.ToDouble(txtRate.Text);
                    int Quantity = Convert.ToInt32(txtQty.Text);
                    float Amount = Rate * Quantity;
                    string TotalAmount = Convert.ToString(Amount);

                    using (SqlConnection con = new SqlConnection(strconnect))
                    {

                        SqlCommand cmd = new SqlCommand("SP_SaveBILLOfficeExpenses", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Exp_Name", txtExpenseName.Text);
                        //cmd.Parameters.AddWithValue("@Exp_Category", ddlExpensesCategory.SelectedItem.Text);
                        //cmd.Parameters.AddWithValue("@Exp_SubCategory", ddlSubCategory.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Amount", TotalAmount);
                        cmd.Parameters.AddWithValue("@BillNo", txtBillno.Text);
                        cmd.Parameters.AddWithValue("@Exp_id", "0");
                        cmd.Parameters.AddWithValue("@Item", txtItem.Text);
                        cmd.Parameters.AddWithValue("@Quantity", txtQty.Text);
                        cmd.Parameters.AddWithValue("@Rate", txtRate.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@CreatedBy", UserName);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                       // cmd.Parameters.AddWithValue("@Amount", Amount);
                        cmd.Parameters.AddWithValue("@OfiiceExpID", "0");
                        cmd.Parameters.AddWithValue("@StaffExpID", "0");
                        cmd.Parameters.AddWithValue("@ProjePurID", "0");
                        cmd.Parameters.AddWithValue("@PayRequestID", lblexpid2.Text);
                        cmd.Parameters.AddWithValue("@BelongTo", "Payment Request");

                        con.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {
                            SuccessDiv1.Visible = true;
                            lblMsg.Visible = true;
                            lblMsg.Text = "Expenses New Item Added Successfully";

                        }
                        else
                        {
                            SuccessDiv1.Visible = true;
                            lblMsg.Visible = true;
                            lblMsg.ForeColor = Color.Black;
                            lblMsg.Text = "Expenses New Item Added Successfully";
                        }
                        Calculatefilldata();
                        GetTotalAmount();
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

        //-------------------------------file upload------------------------


        public DataTable ViewFileExpensesDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                SqlCommand com = new SqlCommand("SP_ViewFileExpensesDetails", con1);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@PayRequestID", lblexpid2.Text);
                com.Parameters.AddWithValue("@BelongTo", "Payment Request");
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridExpensesFile.DataSource = dt;
                    GridExpensesFile.DataBind();
                    GridExpensesFile.Visible = true;

                    foreach (GridViewRow gridviedrow in GridExpensesFile.Rows)
                    {

                        LinkButton btnDeleteExpensesFile = (LinkButton)gridviedrow.FindControl("btnDeleteExpensesFile");

                        btnDeleteExpensesFile.Visible = true;

                    }
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridExpensesFile.DataSource = dt;
                    GridExpensesFile.DataBind();
                    GridExpensesFile.Visible = false;
                    int totalcolums = GridViewOffice.Rows[0].Cells.Count;
                }
            }
            return table;

        }

        protected void Btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblexpid2.Text == "" && txtExpenseName.Text == "")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses Not In Draft!')", true);
                }
                else
                {
                    if (FileUpload.PostedFile.FileName.Length > 1)
                    {
                        string uploadDirectory = Server.MapPath("~/Expenses_File/");

                        if (!Directory.Exists(uploadDirectory))
                        {
                            Directory.CreateDirectory(uploadDirectory);
                        }
                        string fileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
                        string filePath = System.IO.Path.Combine(uploadDirectory, fileName);
                        FileUpload.PostedFile.SaveAs(filePath);
                        string ExpName = Convert.ToString(txtExpenseName.Text);
                        using (SqlConnection con = new SqlConnection(strconnect))
                        {
                            SqlCommand cmd = new SqlCommand("SP_UploadExpensesAttachmentFile", con);
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Exp_Name", txtExpenseName.Text);
                            cmd.Parameters.AddWithValue("@Exp_id", "0");
                            cmd.Parameters.AddWithValue("@OfficeID", "0");
                            cmd.Parameters.AddWithValue("@StaffExpID", "0");
                            cmd.Parameters.AddWithValue("@ProjectPurID", "0");
                            cmd.Parameters.AddWithValue("@PayMentReqID", lblexpid2.Text);
                            cmd.Parameters.AddWithValue("@BelongTo", "Payment Request");
                            cmd.Parameters.AddWithValue("@FileName", fileName);
                            cmd.Parameters.AddWithValue("@FilePath", filePath);
                            cmd.Parameters.AddWithValue("@EmpID", UserId);
                            cmd.Parameters.AddWithValue("@Designation", Designation);
                            cmd.Parameters.AddWithValue("@Createby", UserName);
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            if (i < 0)
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses File Uploaded   Successfully!')", true);
                                ViewFileExpensesDetails();
                            }
                            else
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses File Not Uploaded Successfully!')", true);
                            }

                        }
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Choose File For Uploaded!')", true);
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

        protected void btnDeleteExpensesFile_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = GridExpensesFile.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                string ExpensesID1 = ((Label)rows[rowindex].FindControl("lblExpensesFileId1")).Text;
                string ExpName = Convert.ToString(txtExpenseName.Text);
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_DeleteFileExpenses", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Exp_Name", txtExpenseName.Text);
                    com.Parameters.AddWithValue("@ID", ExpensesID1);
                    com.Parameters.AddWithValue("@CreatedBy", UserName);
                    com.Parameters.AddWithValue("@EmpID", UserId);
                    com.Parameters.AddWithValue("@BelongTo", "Payment Request");
                    com.Parameters.AddWithValue("@Designation", Designation);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    con1.Open();
                    int i = com.ExecuteNonQuery();

                    if (i < 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Office File Expenses Remove Successfully!')", true);
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Office File Expenses Not Remove Available!')", true);
                    }
                    con1.Close();
                    ViewFileExpensesDetails();
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