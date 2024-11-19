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
using System.EnterpriseServices.Internal;

#endregion

namespace MatoshreeProject
{
    public partial class EditTender : System.Web.UI.Page
    {
        #region " Class Level Variable "

        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection DeviceCon = new SqlConnection();
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

        protected void bindcustomer()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetCustomerName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlCustomers.DataSource = ds.Tables[0];
                    ddlCustomers.DataTextField = "Cust_Name";
                    ddlCustomers.DataValueField = "Cust_ID";
                    ddlCustomers.DataBind();
                    ddlCustomers.Items.Insert(0, new ListItem("Select Customer", "0"));
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

        protected void bindProject()
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
                    ddlProjects.Items.Insert(0, new ListItem("Select project", "0"));
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

        protected void bindTenderCategoryName()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetTenderCategoryName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlCategory.DataSource = ds.Tables[0];
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "ID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("Select Tender Category", "0"));
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
                    ddlItem.DataTextField = "Description";//Description
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

        protected void bindBillingType()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetBillingType", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    //ddlBillTask.DataSource = ds.Tables[0];
                    //ddlBillTask.DataTextField = "Billing_Type";
                    //ddlBillTask.DataValueField = "Billing_Type_ID";
                    //ddlBillTask.DataBind();
                    //ddlBillTask.Items.Insert(0, new ListItem("Select BillingType", "0"));
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
                    ddlSalesAgent.DataSource = ds.Tables[0];
                    ddlSalesAgent.DataTextField = "First_Name";
                    ddlSalesAgent.DataValueField = "Staff_ID";
                    ddlSalesAgent.DataBind();
                    ddlSalesAgent.Items.Insert(0, new ListItem("Select Sale Agent", "0"));

                    ddlauthname.DataSource = ds.Tables[0];
                    ddlauthname.DataTextField = "First_Name";
                    ddlauthname.DataValueField = "Staff_ID";
                    ddlauthname.DataBind();
                    ddlauthname.Items.Insert(0, new ListItem("Select Authority Name", "0"));

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

        private string generateOrderNo(string code, long id)
        {
            string oID = code;
            string space = "-";
            oID += space + id.ToString("00000");
            //oID += idWalletTransaction.ToString("0000000");
            return oID;
        }

        public string GETReceiptINITIAL()
        {
            SqlConnection conn = new SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand("SP_GeReceriptInitial", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReceiptFor", "Tender");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ReceiptFor = dt.Rows[0]["ReceiptFor"].ToString();
                Initial = dt.Rows[0]["Initial"].ToString();
                Size = dt.Rows[0]["size"].ToString();
                // lblInitialNumber.Text = year + "-" + Day + "/";
                //Initial = lblInitialNumber.Text;


            }
            return generateOrderNo(Initial, long.Parse(Size));
        }

        public void Calculatefilldata()
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_GetTenderByICal", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@TenderNumber", txtTenderNumber.Text);
                    com.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        GridCalculate.DataSource = dt;
                        GridCalculate.DataBind();
                        foreach (GridViewRow gridviedrow in GridCalculate.Rows)
                        {
                            TextBox txtQantity1 = (TextBox)gridviedrow.FindControl("txtQty1");
                            LinkButton btnDeleteItemCal1 = (LinkButton)gridviedrow.FindControl("btnDeleteItemCal");
                            btnDeleteItemCal1.Visible = true;
                            txtQantity1.Visible = true;
                        }
                    }
                    else
                    {
                        dt.Rows.Add(dt.NewRow());
                        GridCalculate.DataSource = dt;
                        GridCalculate.DataBind();
                        int totalcolums = GridCalculate.Rows[0].Cells.Count;
                        SuccessDiv1.Visible = false;
                        lblMsg.Visible = false;
                        lblMsg1.Visible = false;
                        msgdiv.Visible = false;
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

        public void BindStateDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetState", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddllocationstate.DataSource = ds.Tables[0];
                    ddllocationstate.DataTextField = "State_Name";
                    ddllocationstate.DataValueField = "ID";
                    ddllocationstate.DataBind();
                    ddllocationstate.Items.Insert(0, new ListItem("Select State", "0"));
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

        public void BindDistrictDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetDistrict", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);


                    ddllocationdistrict.DataSource = ds.Tables[0];
                    ddllocationdistrict.DataTextField = "Disttrict_Name";
                    ddllocationdistrict.DataValueField = "District_ID";
                    ddllocationdistrict.DataBind();
                    ddllocationdistrict.Items.Insert(0, new ListItem("Select State", "0"));
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

        public void BindCityDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetCity", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddllocationcity.DataSource = ds.Tables[0];
                    ddllocationcity.DataTextField = "City";
                    ddllocationcity.DataValueField = "ID";
                    ddllocationcity.DataBind();
                    ddllocationcity.Items.Insert(0, new ListItem("Select City", "0"));
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

        public void Clear()
        {
            txtTenderNumber.Text = string.Empty;
            ddlCustomers.SelectedIndex = -1;
            ddlProjects.SelectedIndex = -1;
            ddlStatus.SelectedIndex = -1;
            ddlItem.SelectedIndex = -1;
            ddlSalesAgent.SelectedIndex = -1;
            txttendername.Text = string.Empty;
            txtTenderDate.Text = string.Empty;
            txtExpiryDate.Text = string.Empty;
            txtestimate.Text = string.Empty;
            //txtnameofwork.Text = string.Empty;
            txtperiodofwork.Text = string.Empty;
            txtlocationflatno.Text = string.Empty;
            txtlocationpincode.Text = string.Empty;
            txtAuthposition1.Text = string.Empty;
            txtAuthcontno.Text = string.Empty;
            txtAuthemail.Text = string.Empty;


            ddllocationcountry.SelectedIndex = -1;
            ddllocationstate.SelectedIndex = -1;
            ddllocationdistrict.SelectedIndex = -1;
            ddllocationcity.SelectedIndex = -1;
            ddlpaymentmode.SelectedIndex = -1;

            txtDescription1.Text = string.Empty;
            txtpublishDate.Text = string.Empty;
            txtprebid.Text = string.Empty;
            txtprebidMeetadd.Text = string.Empty;
            ddlauthname.SelectedIndex = -1;
            txtauthorityaddress.Text = string.Empty;
            txtdocumenttype.Text = string.Empty;


            txtClientNote.Text = string.Empty;
            txtTermsAndConditions.Text = string.Empty;
            GridTenderQue.DataSource = null;
            GridTenderQue.DataBind();
            GridTenderQue.SelectedIndex = 0;

            GridTenderFile.DataSource = null;
            GridTenderFile.DataBind();
            GridTenderQue.SelectedIndex = 0;

            GridCalculate.DataSource = null;
            GridCalculate.DataBind();
            GridCalculate.SelectedIndex = 0;

            string Todaydate = Convert.ToString(DateTime.Today);
            string WeekDate = Convert.ToString(DateTime.Today.AddDays(7));

        }

        public void CustAddress(int CustID)
        {
            SqlConnection UserCon = new SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand("SP_GetcustomerAddressByID", UserCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Cust_ID", CustID);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //lblbillTo1.Text = dt.Rows[0]["Add_Block"].ToString() + ",";
                //lblbillTo2.Text = dt.Rows[0]["Add_Street"].ToString() + ",";
                //lblbillTo3.Text = dt.Rows[0]["Add_City"].ToString() + ",";
                //lblbillTo4.Text = dt.Rows[0]["Add_District"].ToString() + ",";
                //lblbillTo5.Text = dt.Rows[0]["Add_State"].ToString() + ",";
                //lblbillTo7.Text = dt.Rows[0]["Add_Country"].ToString() + ",";
                //lblbillTo6.Text = "PIN :" + dt.Rows[0]["Add_PinCode"].ToString();

                //lblShipTo1.Text = dt.Rows[0]["Ship_Block"].ToString() + ",";
                //lblShipTo2.Text = dt.Rows[0]["Ship_Street"].ToString() + ",";
                //lblShipTo3.Text = dt.Rows[0]["Ship_City"].ToString() + ",";
                //lblShipTo4.Text = dt.Rows[0]["Ship_District"].ToString() + ",";
                //lblShipTo5.Text = dt.Rows[0]["Ship_State"].ToString() + ",";
                //lblShipTo7.Text = dt.Rows[0]["Add_Country"].ToString() + ",";
                //lblShipTo6.Text = "PIN :" + dt.Rows[0]["Ship_PinCode"].ToString();
            }
        }

        public void GetTenderDetailsByID()
        {
            try
            {
                Tenderid = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                lbltenderid.Text = Tenderid;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetTenderDetailsByID", UserCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@id", lbltenderid.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtTenderNumber.Text = dt.Rows[0]["TenderNo"].ToString();
                        txttendername.Text = dt.Rows[0]["TenderName"].ToString();
                        txtTenderDate.Text = DateTime.Parse(dt.Rows[0]["TenderDate"].ToString()).ToString("yyyy-MM-dd");
                        ddlCategory.SelectedItem.Text = dt.Rows[0]["TenderBased"].ToString();
                        ddlCustomers.SelectedItem.Text = dt.Rows[0]["Cust_Name"].ToString();
                        ddlProjects.SelectedItem.Text = dt.Rows[0]["ProjectName"].ToString();
                        ddlCustomers.SelectedItem.Value = dt.Rows[0]["CustomerID"].ToString();
                        ddlProjects.SelectedItem.Value = dt.Rows[0]["ProjectID"].ToString();
                        ddlSalesAgent.SelectedItem.Text = dt.Rows[0]["Sales_Agent"].ToString();
                        ddlSalesAgent.SelectedItem.Value = dt.Rows[0]["SaleagentID"].ToString();
                        txtClientNote.Text = dt.Rows[0]["Client_Note"].ToString();
                        txtTermsAndConditions.Text = dt.Rows[0]["Term_condition"].ToString();
                        ddlStatus.SelectedItem.Text = dt.Rows[0]["Status"].ToString();
                        txtpublishDate.Text = DateTime.Parse(dt.Rows[0]["publishdate"].ToString()).ToString("yyyy-MM-dd");
                        txtExpiryDate.Text = DateTime.Parse(dt.Rows[0]["BidEndDate"].ToString()).ToString("yyyy-MM-dd");
                        ddlauthname.SelectedItem.Text = dt.Rows[0]["AuthorityName"].ToString();
                        txtauthorityaddress.Text = dt.Rows[0]["Authorityaddress"].ToString();
                        txtaddressLine1.Text = dt.Rows[0]["AddressLine1"].ToString();
                        txtaddressline2.Text = dt.Rows[0]["AddressLine2"].ToString();
                        txtvillage.Text = dt.Rows[0]["Add_Street"].ToString();
                        txtDescription1.Text = dt.Rows[0]["Description"].ToString();
                        txtperiodofwork.Text = dt.Rows[0]["periodofwork"].ToString();
                        ddlpaymentmode.SelectedItem.Text = dt.Rows[0]["PaymentMode"].ToString();
                        txtprebid.Text = DateTime.Parse(dt.Rows[0]["PreBidmeetingdate"].ToString()).ToString("yyyy-MM-dd");

                        txtestimate.Text = dt.Rows[0]["estimatecontractvalue"].ToString();
                        txtprebidMeetadd.Text = dt.Rows[0]["BidMeetingAddress"].ToString();
                        ddllocationcountry.SelectedItem.Text = dt.Rows[0]["Country"].ToString();
                        ddllocationstate.SelectedItem.Text = dt.Rows[0]["AddState"].ToString();
                        ddllocationdistrict.SelectedItem.Text = dt.Rows[0]["AddDistrict"].ToString();
                        ddllocationcity.SelectedItem.Text = dt.Rows[0]["AddCity"].ToString();
                        txtlocationflatno.Text = dt.Rows[0]["Add_Block"].ToString();
                        txtlocationpincode.Text = dt.Rows[0]["Pincode"].ToString();
                        txtAuthcontno.Text = dt.Rows[0]["Auth_Contact"].ToString();
                        txtAuthposition1.Text = dt.Rows[0]["Auth_Position"].ToString();
                        txtAuthemail.Text = dt.Rows[0]["Auth_Email"].ToString();
                        Calculatefilldata();
                        ViewTenderFile();
                        ViewTenderQuestionDetails();
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

        public void BindStatusDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetStatusname", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BelongTo", "Tender");
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlStatus.DataSource = ds.Tables[0];
                    ddlStatus.DataTextField = "ProgessStatus";
                    ddlStatus.DataValueField = "Status_ID";
                    ddlStatus.DataBind();
                    ddlStatus.Items.Insert(0, new ListItem("Select Status", "0"));
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

        public DataTable ViewTenderFile()
        {

            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                SqlCommand com = new SqlCommand("SP_ViewTenderFileByTenderNo", con1);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@TenderNumber", txtTenderNumber.Text);
                com.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                com.Parameters.AddWithValue("@Belong", "Tender");
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridTenderFile.DataSource = dt;
                    GridTenderFile.DataBind();
                    GridTenderFile.Visible = true;
                    foreach (GridViewRow gridviedrow in GridTenderFile.Rows)
                    {
                        LinkButton btnDeleteItemCal1 = (LinkButton)gridviedrow.FindControl("btnDeleteTender");
                        btnDeleteItemCal1.Visible = true;
                    }
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridTenderFile.DataSource = dt;
                    GridTenderFile.DataBind();
                    int totalcolums = GridTenderFile.Rows[0].Cells.Count;
                    GridTenderFile.Visible = false;
                }
            }
            return table;
        }

        public DataTable ViewTenderQuestionDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                SqlCommand com = new SqlCommand("SP_ViewTenderQuestionDetail", con1);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@TenderNumber", txtTenderNumber.Text);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridTenderQue.DataSource = dt;
                    GridTenderQue.DataBind();
                    GridTenderQue.Visible = true;
                    foreach (GridViewRow gridviedrow in GridTenderQue.Rows)
                    {


                        LinkButton btnDeleteTenderQue = (LinkButton)gridviedrow.FindControl("btnDeleteTenderQue");

                        btnDeleteTenderQue.Visible = true;

                    }
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridTenderQue.DataSource = dt;
                    GridTenderQue.DataBind();
                    int totalcolums = GridTenderQue.Rows[0].Cells.Count;
                    GridTenderQue.Visible = false;
                }
            }
            return table;
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

                        if (!this.IsPostBack)
                        {
                            BindStateDetails();
                            BindDistrictDetails();
                            BindCityDetails();

                            bindProject();
                            bindcustomer();
                            bindStaff();
                            BindStatusDetails();
                            bindTenderCategoryName();
                            bindItem();
                            bindTax();
                            GetTenderDetailsByID();
                            ViewTenderFile();
                            ViewTenderQuestionDetails();
                            Calculatefilldata();
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
                            if (!this.IsPostBack)
                            {
                                BindStateDetails();
                                BindDistrictDetails();
                                BindCityDetails();

                                bindProject();
                                bindcustomer();
                                bindStaff();
                                BindStatusDetails();
                                bindTenderCategoryName();
                                bindItem();
                                bindTax();
                                GetTenderDetailsByID();
                                ViewTenderFile();
                                ViewTenderQuestionDetails();
                                Calculatefilldata();
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

        protected void btnDeleteTenderQue_Click(object sender, EventArgs e)
        {
            try
            {
                string ID;
                var rows = GridTenderQue.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ID = ((Label)rows[rowindex].FindControl("lblTenderQueID1")).Text;

                using (SqlConnection DeviceCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_DeleteTenderQue", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@createby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Tender Question Details Deleted Successfully";
                        ViewTenderQuestionDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Tender Question Details Not Deleted Successfully";
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

        protected void btnDeleteTender_Click(object sender, EventArgs e)
        {

            try
            {
                string ID;
                var rows = GridTenderFile.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ID = ((Label)rows[rowindex].FindControl("lblTenderID1")).Text;

                using (SqlConnection DeviceCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_DeleteTenderFile", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@createby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Tender File Details Deleted Successfully";
                        ViewTenderFile();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Tender File Details Not Deleted";
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

        protected void txtQty1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var rows = GridCalculate.Rows;
                TextBox txtQty = (TextBox)sender;
                GridViewRow row = (GridViewRow)txtQty.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                Label Item = (Label)row.FindControl("lblItem1");
                Label Description = (Label)row.FindControl("lblDescription1");

                string ItemID = ((Label)rows[rowindex].FindControl("lblItemid")).Text;

                int quantity = Convert.ToInt32(txtQty.Text);

                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateTenderItem", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ItemID);
                        cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Item", Item.Text);
                        cmd.Parameters.AddWithValue("@Description", Description.Text);
                        cmd.Parameters.AddWithValue("@TenderNumber", txtTenderNumber.Text);
                        cmd.Parameters.AddWithValue("@Qnty", quantity);
                        cmd.Parameters.AddWithValue("@Empid", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@Createby", UserName);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i < 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Item Quantity Details Updated Successfully";      
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Item Quantity Details Not Updated Successfully";

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

        protected void ddlauthname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetByAuthorityName", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@id", ddlauthname.SelectedItem.Value);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    txtAuthposition1.Text = dt.Rows[0]["role"].ToString();
                    txtAuthemail.Text = dt.Rows[0]["email"].ToString();
                    txtAuthcontno.Text = dt.Rows[0]["PhoneNumber"].ToString();
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

        //fileupload
        protected void Btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {

                if (FileUpload.PostedFile.FileName.Length > 1)
                {
                    string uploadDirectory = Server.MapPath("~/Tender_File/");

                    if (!Directory.Exists(uploadDirectory))
                    {
                        Directory.CreateDirectory(uploadDirectory);
                    }
                    string fileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
                    string filePath = System.IO.Path.Combine(uploadDirectory, fileName);
                    string extention = System.IO.Path.GetExtension(FileUpload.PostedFile.FileName);
                    FileUpload.PostedFile.SaveAs(filePath);
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_UploadTenderAttachmentFile", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TenderNumber", txtTenderNumber.Text);
                        cmd.Parameters.AddWithValue("@FileName", fileName);
                        cmd.Parameters.AddWithValue("@FilePath", filePath);
                        cmd.Parameters.AddWithValue("@DocumentType", txtdocumenttype.Text);
                        cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Belong", "Tender");
                        cmd.Parameters.AddWithValue("@Extention", extention);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@Createby", UserName);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i < 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Tender File Uploaded Successfully";
                            ViewTenderFile();
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Tender File Not Uploaded Successfully";
                        }
                    }
                }
                else
                {
                    // popup choose file
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Choose File For Uploaded!')", true);
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
        //add Question
        protected void Btn_TenderQue_Click(object sender, EventArgs e)
        {
            using (SqlConnection DeviceCon = new SqlConnection(strconnect))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[SP_SaveTenderQue]", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Question", txtque.Text);
                    cmd.Parameters.AddWithValue("@TenderNumber", txtTenderNumber.Text);
                    cmd.Parameters.AddWithValue("@createby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Tender Question Details Saved Successfully";
                        ViewTenderQuestionDetails();
                        txtque.Text = string.Empty;
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Tender Question Details Not Saved Successfully";
                    }
                }
                catch (Exception ex)
                {
                    using (SqlConnection DeviceCon1 = new SqlConnection(strconnect))
                    {
                        string ErrorMessgage = ex.Message;
                        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                        string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                        string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                        Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                        SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon1);
                        cmdex.CommandType = CommandType.StoredProcedure;
                        cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                        cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                        cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                        cmdex.Parameters.AddWithValue("@Method", method);
                        cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                        DeviceCon1.Open();
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
        }

        protected void ddllocationstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Stateid = Convert.ToInt32(ddllocationstate.SelectedValue);
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetDistrictbyStateid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@State_ID", Stateid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddllocationdistrict.DataSource = ds.Tables[0];
                    ddllocationdistrict.DataTextField = "Disttrict_Name";
                    ddllocationdistrict.DataValueField = "District_ID";
                    ddllocationdistrict.DataBind();
                    ddllocationdistrict.Items.Insert(0, new ListItem("Select District Name", "0"));
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

        protected void ddllocationdistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Districtid = Convert.ToInt32(ddllocationdistrict.SelectedValue);

                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetcitybyDistrictid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@District_ID", Districtid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddllocationcity.DataSource = ds.Tables[0];
                    ddllocationcity.DataTextField = "City";
                    ddllocationcity.DataValueField = "ID";
                    ddllocationcity.DataBind();
                    ddllocationcity.Items.Insert(0, new ListItem("Select City Name", "0"));

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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                Response.Redirect("~/Tender.aspx", false);
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

        protected void ddlCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int CustID = Convert.ToInt32(ddlCustomers.SelectedValue);



                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd1 = new SqlCommand("SP_GetProjectNamebycustomerID", conn);
                cmd1.Connection = conn;
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@CustID", CustID);
                using (SqlDataAdapter sda1 = new SqlDataAdapter(cmd1))
                {
                    DataSet ds = new DataSet();
                    sda1.Fill(ds);
                    ddlProjects.DataSource = ds.Tables[0];
                    ddlProjects.DataTextField = "ProjectName";
                    ddlProjects.DataValueField = "ID";
                    ddlProjects.DataBind();
                    ddlProjects.Items.Insert(0, new ListItem("Select Project", "0"));
                }


                //--------------------------customer Address---------------=========================>


                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetcustomerAddressByID", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Cust_ID", CustID);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //lblbillTo1.Text = dt.Rows[0]["Add_Block"].ToString() + ",";
                    //lblbillTo2.Text = dt.Rows[0]["Add_Street"].ToString() + ",";
                    //lblbillTo3.Text = dt.Rows[0]["Add_City"].ToString() + ",";
                    //lblbillTo4.Text = dt.Rows[0]["Add_District"].ToString() + ",";
                    //lblbillTo5.Text = dt.Rows[0]["Add_State"].ToString() + ",";
                    //lblbillTo7.Text = dt.Rows[0]["Add_Country"].ToString() + ",";
                    //lblbillTo6.Text = "PIN :" + dt.Rows[0]["Add_PinCode"].ToString();

                    //lblShipTo1.Text = dt.Rows[0]["Ship_Block"].ToString() + ",";
                    //lblShipTo2.Text = dt.Rows[0]["Ship_Street"].ToString() + ",";
                    //lblShipTo3.Text = dt.Rows[0]["Ship_City"].ToString() + ",";
                    //lblShipTo4.Text = dt.Rows[0]["Ship_District"].ToString() + ",";
                    //lblShipTo5.Text = dt.Rows[0]["Ship_State"].ToString() + ",";
                    //lblShipTo7.Text = dt.Rows[0]["Add_Country"].ToString() + ",";
                    //lblShipTo6.Text = "PIN :" + dt.Rows[0]["Ship_PinCode"].ToString();
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

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ItemID = Convert.ToInt32(ddlItem.SelectedValue);

                TextBox txtItem = (TextBox)GridCalculate.FooterRow.FindControl("txtItem");
                TextBox txtDescription = (TextBox)GridCalculate.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridCalculate.FooterRow.FindControl("txtQty");
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
                        txtDescription.Text = dt.Rows[0]["Long_Description"].ToString();
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

        protected void RadioButtonListQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //string quantitytext = Convert.ToString(RadioButtonListQty.SelectedItem.Text);

                // Label lblQnty = (Label)GridCalculate.HeaderRow.Cells[2].FindControl("lblQuantity");
                //GridCalculate.HeaderRow.Cells[2].Text = quantitytext;
                //   lblQnty.Text = quantitytext;
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

        protected void btnDeleteItemCal_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = GridCalculate.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                string ItemID = ((Label)rows[rowindex].FindControl("lblItem1")).Text;

                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_DeleteTenderItem", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@TenderNumber", txtTenderNumber.Text);
                    com.Parameters.AddWithValue("@Item", ItemID);
                    com.Parameters.AddWithValue("@createby", UserName);
                    com.Parameters.AddWithValue("@UserID", UserId);
                    com.Parameters.AddWithValue("@Designation", Designation);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    con1.Open();
                    int i = com.ExecuteNonQuery();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Tender Item Remove Successfully";
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Tender  Item Not Remove Successfully";
                    }
                    con1.Close();
                    Calculatefilldata();
                    // ViewItemDetails();
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

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);  // db connect
                SqlCommand cmd = new SqlCommand("SP_UpdateTender", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", lbltenderid.Text);
                cmd.Parameters.AddWithValue("@TenderNo", txtTenderNumber.Text);
                cmd.Parameters.AddWithValue("@TenderDate", txtTenderDate.Text);
                cmd.Parameters.AddWithValue("@CustomerID", ddlCustomers.SelectedValue);
                cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedValue);
                cmd.Parameters.AddWithValue("@TenderName", txttendername.Text);
                cmd.Parameters.AddWithValue("@BidEndDate", txtExpiryDate.Text);
                cmd.Parameters.AddWithValue("@Sales_Agent", ddlSalesAgent.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription1.Text);
                cmd.Parameters.AddWithValue("@TenderBased", ddlCategory.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Estimatecontractvalue", txtestimate.Text);
                cmd.Parameters.AddWithValue("@Country", ddllocationcountry.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@AddState", ddllocationstate.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@AddDistrict", ddllocationdistrict.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@AddCity", ddllocationcity.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Add_Block", txtlocationflatno.Text);
                cmd.Parameters.AddWithValue("@Add_Street", txtvillage.Text);
                cmd.Parameters.AddWithValue("@Addressline1", txtaddressLine1.Text);
                cmd.Parameters.AddWithValue("@Addressline2", txtaddressline2.Text);
                cmd.Parameters.AddWithValue("@BidMeetingAddress", txtprebidMeetadd.Text);
                cmd.Parameters.AddWithValue("@PrebidMeetingDate", txtprebid.Text);
                cmd.Parameters.AddWithValue("@PeriodOfWork", txtperiodofwork.Text);
                cmd.Parameters.AddWithValue("@Publishdate", txtpublishDate.Text);
                cmd.Parameters.AddWithValue("@AuthorityName", ddlauthname.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@AuthorityAddress", txtauthorityaddress.Text);
                cmd.Parameters.AddWithValue("@PaymentMode", ddlpaymentmode.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Pincode", txtlocationpincode.Text);
                cmd.Parameters.AddWithValue("@Client_Note", txtClientNote.Text);
                cmd.Parameters.AddWithValue("@Term_condition", txtTermsAndConditions.Text);
                cmd.Parameters.AddWithValue("@Created_by", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@Position", txtAuthposition1.Text);
                cmd.Parameters.AddWithValue("@Email", txtAuthemail.Text);
                cmd.Parameters.AddWithValue("@Phonenumber", txtAuthcontno.Text);

                con.Open();
                int Result = cmd.ExecuteNonQuery();
                if (Result < 0)
                {
                      string edit = "xcvfedit";
                    Response.Redirect("~/Tender.aspx?edit1=" + edit + "", false);
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Tender Details Not Edit Successfully";
                }
                Clear();
                con.Close();
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

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tender.aspx", false);
        }

        protected void btnAddTenderItem_Click(object sender, EventArgs e)
        {
            try
            {
                string Custid = Convert.ToString(ddlCustomers.SelectedItem.Text);
                string Projectid = Convert.ToString(ddlProjects.SelectedItem.Text);
                string Saleagentid = Convert.ToString(ddlSalesAgent.SelectedItem.Text);
                string item = Convert.ToString(ddlItem.SelectedItem.Text);


                if (Projectid == "Select Project")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Project AND Item!')", true);
                }
                else
                {
                    TextBox txtItem = (TextBox)GridCalculate.FooterRow.FindControl("txtItem");
                    TextBox txtDescription = (TextBox)GridCalculate.FooterRow.FindControl("txtDescription");
                    TextBox txtQty = (TextBox)GridCalculate.FooterRow.FindControl("txtQty");

                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_SaveTenderItemCalulation", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TenderNumber", txtTenderNumber.Text);
                        cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedValue);
                        cmd.Parameters.AddWithValue("@TenderCategory", ddlCategory.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@TenderCategoryId", ddlCategory.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@ItemID", ddlItem.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Quantity", txtQty.Text);
                        cmd.Parameters.AddWithValue("@Item", txtItem.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@UserID", UserId);
                        cmd.Parameters.AddWithValue("@Created_by", UserName);
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
                            lblMesDelete.Text = "Tender New Item Added Successfully";

                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Tender New Item Added Successfully";
                        }
                        Calculatefilldata();
                        // ViewItemDetails();
                        con.Close();
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
                    Clear();
                    bindItem();
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
        #endregion
    }

}