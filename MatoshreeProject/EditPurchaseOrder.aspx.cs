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
using iTextSharp.text;
using System.Xml.Linq;
using System.Xml;

#endregion

namespace MatoshreeProject
{
    public partial class EditPurchaseOrder : System.Web.UI.Page
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

        string Size, Initial, ReceiptFor, Cash, Bank, reminder, filePath, fileName;

        string Day = Convert.ToString(DateTime.Today.Day);
        string year = Convert.ToString(DateTime.Today.Year);
        Double TenderTOTALAMONT;

        Double DiscountItem1 = 0, Adjustment1, TaxTotalItem1, SubtotalItem1;
        decimal TotalTEnderAmont;

        string PurchaseOrderNo;

      
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
        public void Clear()
        {
            //txt_LongDescription.Text = string.Empty;
            //txt_Description.Text = string.Empty;
            //txt_Rate.Text = string.Empty;
            //txtHSNCode.Text = string.Empty;
            //ddlTax.SelectedIndex = -1;
            //ddlTax1.SelectedIndex = -1;

            //txtPOName.Text = string.Empty;
            //txtAmount.Text = string.Empty;
            ddlCustomers.SelectedIndex = -1;
            ddlProjects.SelectedIndex = -1;
            ddlStatus.SelectedIndex = -1;
            ddlSalesAgent.SelectedIndex = -1;
            ddllocationcountry.SelectedIndex = -1;
            ddllocationstate.SelectedIndex = -1;
            ddllocationdistrict.SelectedIndex = -1;
            ddllocationcity.SelectedIndex = -1;
            txtaddressLine1.Text = string.Empty;
            txtlocationflatno.Text = string.Empty;
            txtlocationpincode.Text = string.Empty;

            txtClientNote.Text = string.Empty;
            txtTermsAndConditions.Text = string.Empty;

        }

        //protected void bindTax()
        //{
        //    try
        //    {
        //        SqlConnection conn = new SqlConnection(strconnect);
        //        SqlCommand cmd = new SqlCommand("SP_GetTaxename", conn);
        //        cmd.Connection = conn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //        {
        //            DataSet ds = new DataSet();
        //            sda.Fill(ds);
        //            ddlTax.DataSource = ds.Tables[0];
        //            ddlTax.DataTextField = "Tax_Name";
        //            ddlTax.DataValueField = "Tax_Name";
        //            ddlTax.DataBind();
        //            ddlTax.Items.Insert(0, new ListItem("Select Tax", "0"));

        //            ddlTax1.DataSource = ds.Tables[0];
        //            ddlTax1.DataTextField = "Tax_Name";
        //            ddlTax1.DataValueField = "Tax_Name";
        //            ddlTax1.DataBind();
        //            ddlTax1.Items.Insert(0, new ListItem("Select Tax", "0"));

        //            ddlTax2.DataSource = ds.Tables[0];
        //            ddlTax2.DataTextField = "Tax_Name";
        //            ddlTax2.DataValueField = "Tax_Name";
        //            ddlTax2.DataBind();
        //            ddlTax2.Items.Insert(0, new ListItem("Select Tax", "0"));

        //            ddlTax3.DataSource = ds.Tables[0];
        //            ddlTax3.DataTextField = "Tax_Name";
        //            ddlTax3.DataValueField = "Tax_Name";
        //            ddlTax3.DataBind();
        //            ddlTax3.Items.Insert(0, new ListItem("Select Tax", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        using (SqlConnection DeviceCon = new SqlConnection(strconnect))
        //        {
        //            string ErrorMessgage = ex.Message;
        //            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
        //            string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
        //            string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
        //            Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
        //            SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
        //            cmdex.CommandType = CommandType.StoredProcedure;
        //            cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
        //            cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
        //            cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
        //            cmdex.Parameters.AddWithValue("@Method", method);
        //            cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
        //            DeviceCon.Open();
        //            int RowEx = cmdex.ExecuteNonQuery();
        //            if (RowEx < 0)
        //            {
        //                //lblMessage.Visible = false;
        //                //lblMessage.Text = "Error Details Save Successfully";
        //            }
        //            else
        //            {
        //                //lblMessage.Visible = false;
        //                //lblMessage.Text = "Error Details Not Save Successfully";
        //            }
        //        }
        //    }

        //}

        public void BindStatusDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetStatusname", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BelongTo", "PurchaseOrder");
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlStatus.DataSource = ds.Tables[0];
                    ddlStatus.DataTextField = "ProgessStatus";
                    ddlStatus.DataValueField = "Status_ID";
                    ddlStatus.DataBind();
                    ddlStatus.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Status", "0"));
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
                // DeviceCon.Open();
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
                    ddlSalesAgent.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Sale Agent", "0"));

                    //ddlauthname.DataSource = ds.Tables[0];
                    //ddlauthname.DataTextField = "First_Name";
                    //ddlauthname.DataValueField = "Staff_ID";
                    //ddlauthname.DataBind();
                    //ddlauthname.Items.Insert(0, new ListItem("Select Authority Name", "0"));

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
                    ddlCustomers.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Customer", "0"));
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
                    ddllocationstate.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select State", "0"));
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
                    ddlItem.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Item", "0"));

                    ddlItemServices.DataSource = ds.Tables[0];
                    ddlItemServices.DataTextField = "Description";//Description
                    ddlItemServices.DataValueField = "ID";
                    ddlItemServices.DataBind();
                    ddlItemServices.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Item", "0"));
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
                    ddllocationdistrict.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select State", "0"));
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

        public void GetPOProcurementAmount()
        {
            try
            {
                using (SqlConnection Usercon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetPurchaseOrderProcurementTotalAmount", Usercon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PONumber", txtPONumber.Text);
                    cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblTotalAmountProcurement.Text = dt.Rows[0]["TotalProAmont"].ToString();
                    }
                    else
                    {
                        lblTotalAmountProcurement.Text = "₹" + "0.0";
                    }
                }

                using (SqlConnection Usercon1 = new SqlConnection(strconnect))
                {

                    SqlCommand cmd = new SqlCommand("SP_GetPurchaseOrderServiceTotalAmount", Usercon1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PONumber", txtPONumber.Text);
                    cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblTotalServiceAmount.Text = dt.Rows[0]["TotalServiceAmont"].ToString();
                    }
                    else
                    {
                        lblTotalServiceAmount.Text = "₹" + "0.0";
                    }

                    //--------------------------------------------------------------------//
                    // TotalAmount Purchase Order Costing
                    //----------------------------------------------------------------------//
                    double totalCostAmount = 0, totalProcurement, totalservise;
                    totalProcurement = Convert.ToDouble(lblTotalAmountProcurement.Text);
                    totalservise = Convert.ToDouble(lblTotalServiceAmount.Text);
                    totalCostAmount = totalProcurement + totalservise;
                    lblTotalProjectCost.Text = "₹" + totalCostAmount.ToString();

                    lblTotalServiceAmount.Text = "₹" + totalservise.ToString();
                    lblTotalAmountProcurement.Text = "₹" + totalProcurement.ToString();
                    //lblTotalcost.Text= lblTotalAmountProcu.Text + "+" + lblServicelistTotal.Text;

                    lblTotalAmountProcu.Text = lblTotalAmountProcurement.Text + "+" + lblTotalServiceAmount.Text;
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

        #region " Protected Functions "
        public void GetProjectByCustID(int CustID)
        {
            try
            {
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
        public void GetDistrictByStateID(int Stateid)
        {
            try
            {
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
                    ddllocationdistrict.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select District Name", "0"));
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

        public void GetCityByDistrictID(int DistrictId)
        {
            try
            {
                int Districtid = Convert.ToInt32(ddllocationdistrict.SelectedValue);

                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetcitybyDistrictid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@District_ID", DistrictId);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddllocationcity.DataSource = ds.Tables[0];
                    ddllocationcity.DataTextField = "City";
                    ddllocationcity.DataValueField = "ID";
                    ddllocationcity.DataBind();
                    ddllocationcity.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select City Name", "0"));

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
                    ddllocationcity.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select City", "0"));
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
        public void GetPurchaseOrederDetailsByID()
        {
            try
            {
                PurchaseOrderNo = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                lblPurchaseOrderid.Text = PurchaseOrderNo;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetPurchaseOrderByID", UserCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ID", lblPurchaseOrderid.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblPurchaseOrderid.Text = dt.Rows[0]["ID"].ToString();
                        txtPONumber.Text = dt.Rows[0]["PONumber"].ToString();
                        txtPOName.Text = dt.Rows[0]["POName"].ToString();
                        txtPODate.Text = DateTime.Parse(dt.Rows[0]["PODate"].ToString()).ToString("yyyy-MM-dd");
                        txtPOExpireDate.Text = DateTime.Parse(dt.Rows[0]["POExpireDate"].ToString()).ToString("yyyy-MM-dd");
                        txtPOAmount.Text = dt.Rows[0]["Amount"].ToString();
                        ddlCustomers.SelectedItem.Text = dt.Rows[0]["Cust_Name"].ToString();
                        ddlProjects.SelectedItem.Text = dt.Rows[0]["ProjectName"].ToString();
                        ddlCustomers.SelectedItem.Value = dt.Rows[0]["CustID"].ToString();
                        int CustID = Convert.ToInt32(ddlCustomers.SelectedItem.Value);
                        GetProjectByCustID(CustID);
                        ddlProjects.SelectedItem.Value = dt.Rows[0]["ProjectID"].ToString();
                        ddlProjects.SelectedItem.Text = dt.Rows[0]["ProjectName"].ToString();
                        int ProjectID = Convert.ToInt32(ddlProjects.SelectedItem.Value);
                        ddlStatus.SelectedItem.Value = dt.Rows[0]["StatusID"].ToString();
                        ddlStatus.SelectedItem.Text = dt.Rows[0]["StatusName"].ToString();
                        ddlSalesAgent.SelectedValue = dt.Rows[0]["SaleAgent"].ToString();
                        ddllocationcountry.SelectedItem.Text = dt.Rows[0]["Country"].ToString();
                        ddllocationstate.SelectedItem.Text = dt.Rows[0]["AddState"].ToString();
                        int StateID = Convert.ToInt32(ddllocationstate.SelectedItem.Value);
                        GetDistrictByStateID(StateID);
                        ddllocationdistrict.SelectedItem.Text = dt.Rows[0]["AddDistrict"].ToString();
                        int DistrictID = Convert.ToInt32(ddllocationdistrict.SelectedItem.Value);
                        GetCityByDistrictID(DistrictID);
                        ddllocationcity.SelectedItem.Text = dt.Rows[0]["AddCity"].ToString();

                        txtlocationflatno.Text = dt.Rows[0]["AddBlock"].ToString();
                        txtlocationpincode.Text = dt.Rows[0]["Pincode"].ToString();
                        txtaddressLine1.Text = dt.Rows[0]["AddStreet"].ToString();

                        txtClientNote.Text = dt.Rows[0]["ClientNote"].ToString();
                        txtTermsAndConditions.Text = dt.Rows[0]["Termcondition"].ToString();

                        lblFilePath.Text = dt.Rows[0]["FilePath"].ToString();
                        lblFileName.Text = dt.Rows[0]["FileName"].ToString();

                        //Retrieve and display the file path
                        string filePath = dt.Rows[0]["FilePath"].ToString();
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            lblFilePath.Visible = false;
                            lblFileName.Visible = true;
                        }
                        else
                        {
                            lblFilePath.Visible = false;
                        }

                        //ddlItem.SelectedItem.Text = dt.Rows[0]["ProductName"].ToString();
                        ViewPurchaseOrderProcurement(ProjectID);
                        //ddlItemServices.SelectedItem.Text = dt.Rows[0]["ServiceName"].ToString();
                        ViewPurchaseOrderServices(ProjectID);
                        //lblTotalAmountProcurement.Text = dt.Rows[0]["TotalCostProcurement"].ToString();
                        //lblTotalServiceAmount.Text = dt.Rows[0]["TotalCostService"].ToString();
                        //lblTotalProjectCost.Text = dt.Rows[0]["Amount"].ToString();
                        GetPOProcurementAmount();

                        //lblFileName.Text = dt.Rows[0]["FileName"].ToString();
                        //lblFilePath.Text = dt.Rows[0]["FilePath"].ToString();


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

        public DataTable ViewPurchaseOrderServices(int Projectid)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewPurchaseOrderServices", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@ProjectID", Projectid);
                cmd.Parameters.AddWithValue("@PONumber", txtPONumber.Text);
                ad.Fill(table);
                if (table.Rows.Count > 0)
                {
                    GridServicesList.DataSource = table;
                    GridServicesList.DataBind();

                    //Get the Row that contains this button 
                    foreach (GridViewRow gridviedrow in GridServicesList.Rows)
                    {
                        LinkButton btnEditServices = (LinkButton)gridviedrow.FindControl("btnEditServices");
                        LinkButton btnDeleteServices = (LinkButton)gridviedrow.FindControl("btnDeleteServices");

                        btnDeleteServices.Visible = true;
                        btnEditServices.Visible = true;
                    }
                }
                else
                {
                    table.Rows.Add(table.NewRow());
                    GridServicesList.DataSource = table;
                    GridServicesList.DataBind();
                    int totalcolumns = GridServicesList.Rows[0].Cells.Count;

                }
                return table;
            }

        }

        public DataTable ViewPurchaseOrderProcurement(int Projectid)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewPurchaseOrderProcurement", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@ProjectID", Projectid);
                cmd.Parameters.AddWithValue("@PONumber", txtPONumber.Text);
                ad.Fill(table);
                if (table.Rows.Count > 0)
                {
                    GridProcurement.DataSource = table;
                    GridProcurement.DataBind();

                    //Get the Row that contains this button 
                    foreach (GridViewRow gridviedrow in GridProcurement.Rows)
                    {
                        LinkButton btnEditProcurement = (LinkButton)gridviedrow.FindControl("btnEditProcurement");
                        LinkButton btnDeleteProcurement = (LinkButton)gridviedrow.FindControl("btnDeleteProcurement");


                        btnEditProcurement.Visible = true;
                        btnDeleteProcurement.Visible = true;
                    }
                }
                else
                {
                    table.Rows.Add(table.NewRow());
                    GridProcurement.DataSource = table;
                    GridProcurement.DataBind();
                    int totalcolumns = GridProcurement.Rows[0].Cells.Count;

                }
                return table;
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

                        if (!this.IsPostBack)
                        {
                            BindStateDetails();
                            BindDistrictDetails();
                            BindCityDetails();
                            bindProject();

                            bindcustomer();

                            bindStaff();
                            BindStatusDetails();

                            bindItem();
                            GetPurchaseOrederDetailsByID();

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

                                bindItem();
                                GetPurchaseOrederDetailsByID();

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

        protected void Btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                // if (FileUpload.PostedFile.FileName.Length > 1)
                if (FileUpload.HasFile)
                {

                    string uploadDirectory = Server.MapPath("~/PurchaseOrderFile/");

                    if (!Directory.Exists(uploadDirectory))
                    {
                        Directory.CreateDirectory(uploadDirectory);
                    }
                    string fileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
                    string filePath = System.IO.Path.Combine(uploadDirectory, fileName);
                    string extention = System.IO.Path.GetExtension(FileUpload.PostedFile.FileName);
                    FileUpload.PostedFile.SaveAs(filePath);
                    lblFileName.Text = fileName;
                    lblFilePath.Text = filePath;

                    lblFilePath.Visible = false;

                }
                else
                {
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
        }

        //--------------------------------------------------------------------------------------------------------
        //Purchase Order Modal Details Start
        //--------------------------------------------------------------------------------------------------------
        protected void btnPOCloseModalItem_Click(object sender, EventArgs e)
        {

        }
        protected void btnPOSaveModalItem_Click(object sender, EventArgs e)
        {

        }

        //--------------------------------------------------------------------------------------------------------
        //Purchase Order Modal Details END
        //--------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------
        //Purchase Order Details Start
        //--------------------------------------------------------------------------------------------------------

        protected void ddlProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Projectid = Convert.ToInt32(ddlProjects.SelectedValue);

            ViewPurchaseOrderProcurement(Projectid);
            ViewPurchaseOrderServices(Projectid);
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
        protected void btn_AddProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("Projects.aspx");
        }
        protected void btn_AddCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer.aspx");
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
                    ddllocationdistrict.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select District Name", "0"));
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
                    ddllocationcity.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select City Name", "0"));

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

        //--------------------------------------------------------------------------------------------------------
        //Purchase Order Details END
        //--------------------------------------------------------------------------------------------------------



        //--------------------------------------------------------------------------------------------------------
        //Purchase Order Procurement gridview Start
        //--------------------------------------------------------------------------------------------------------
        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ItemID = Convert.ToInt32(ddlItem.SelectedValue);

                Label lblProductID1 = (Label)GridProcurement.FooterRow.FindControl("lblProductID1");
                TextBox txtItem = (TextBox)GridProcurement.FooterRow.FindControl("txtItem");
                TextBox txtProduct = (TextBox)GridProcurement.FooterRow.FindControl("txtProduct");
                TextBox txtPrice = (TextBox)GridProcurement.FooterRow.FindControl("txtPrice");
                TextBox txtDescription = (TextBox)GridProcurement.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridProcurement.FooterRow.FindControl("txtQty");
                Label lblAmontP = (Label)GridProcurement.FooterRow.FindControl("lblAmontP");




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
                        lblProductID1.Text = dt.Rows[0]["ID"].ToString();
                        txtPrice.Text = dt.Rows[0]["Rate"].ToString();
                        txtProduct.Text = dt.Rows[0]["Description"].ToString();
                        txtDescription.Text = dt.Rows[0]["Long_Description"].ToString();

                    }

                    double Qunty, Price, Amount;
                    Qunty = Convert.ToDouble(txtQty.Text);
                    Price = Convert.ToDouble(txtPrice.Text);
                    Amount = Qunty * Price;

                    lblAmontP.Text = Amount.ToString();
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

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Label lblProductID1 = (Label)GridProcurement.FooterRow.FindControl("lblProductID1");
                TextBox txtItem = (TextBox)GridProcurement.FooterRow.FindControl("txtItem");
                TextBox txtProduct = (TextBox)GridProcurement.FooterRow.FindControl("txtProduct");
                TextBox txtPrice = (TextBox)GridProcurement.FooterRow.FindControl("txtPrice");
                TextBox txtDescription = (TextBox)GridProcurement.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridProcurement.FooterRow.FindControl("txtQty");
                Label lblAmontP = (Label)GridProcurement.FooterRow.FindControl("lblAmontP");

                double Qunty, Price, Amount;
                Qunty = Convert.ToDouble(txtQty.Text);
                Price = Convert.ToDouble(txtPrice.Text);
                Amount = Qunty * Price;

                lblAmontP.Text = Amount.ToString();

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
        protected void txtQty1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var rows = GridProcurement.Rows;
                TextBox txtQty = (TextBox)sender;
                GridViewRow row = (GridViewRow)txtQty.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                Label lblProductlist1 = (Label)row.FindControl("lblProductlist1");
                TextBox txtEditProduct = (TextBox)row.FindControl("txtEditProduct");
                TextBox txtEditDescription = (TextBox)row.FindControl("txtEditDescription");
                TextBox txtPrice1 = (TextBox)row.FindControl("txtPrice1");
                Label lblEditAmont1 = (Label)row.FindControl("lblEditAmont1");
                Label lblTotalAmount = (Label)row.FindControl("lblAmont1");
                string ProductID = ((Label)rows[rowindex].FindControl("lblProdID")).Text;
                int quantity = Convert.ToInt32(txtQty.Text);


                decimal price;
                if (string.IsNullOrEmpty(txtPrice1.Text))
                {
                    price = 0;
                }
                else
                {
                    price = Convert.ToDecimal(txtPrice1.Text);
                }

                //decimal Quantity = Convert.ToDecimal(txtQty.Text);
                // txtPrice1 = txtPrice1.Text;
                decimal Amount = price * quantity;
                decimal TotalAmount = decimal.Round(Amount, 2);

                lblEditAmont1.Text = TotalAmount.ToString();

                //using (SqlConnection con = new SqlConnection(strconnect))
                //{
                //    SqlCommand cmd = new SqlCommand("SP_UpdatePurchaseOrderProcurement", con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@ID", ProductID);
                //    //cmd.Parameters.AddWithValue("@ProjectName", lblProjectName1.Text);
                //    cmd.Parameters.AddWithValue("@ProjectName", ddlProjects.SelectedItem.Text);
                //    cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                //    cmd.Parameters.AddWithValue("@CustName", ddlCustomers.SelectedItem.Text);
                //    cmd.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                //    //cmd.Parameters.AddWithValue("ProductName", txtEditProduct.Text);
                //    cmd.Parameters.AddWithValue("@Description", txtEditDescription.Text);
                //    cmd.Parameters.AddWithValue("@ProductName", txtEditProduct.Text);
                //    cmd.Parameters.AddWithValue("@Quantity", txtQty.Text);
                //    cmd.Parameters.AddWithValue("@Price", txtPrice1.Text);
                //    cmd.Parameters.AddWithValue("@TotalAmont", lblEditAmont1.Text);
                //    //cmd.Parameters.AddWithValue("@ProjectID", ProjectId);
                //    //cmd.Parameters.AddWithValue("@CustName", lblClient1.Text);
                //    cmd.Parameters.AddWithValue("@CreateBy", UserName);
                //    cmd.Parameters.AddWithValue("@EmpID", UserId);
                //    cmd.Parameters.AddWithValue("@Designation", Designation);

                //    con.Open();
                //    int Result = cmd.ExecuteNonQuery();
                //    if (Result < 0)
                //    {
                //        Toasteralert.Visible = false;
                //        deleteToaster.Visible = true;
                //        lblMesDelete.Text = "Project  Procurement Update Successfully";
                //        GridProcurement.EditIndex = -1;
                //        //ViewPOProjectProcurement(lblProjectID.Text);
                //        // GetProcurementAmount(lblProjectID.Text);

                //    }
                //    else
                //    {
                //        Toasteralert.Visible = false;
                //        deleteToaster.Visible = true;
                //        lblMesDelete.Text = "Project  Procurement Not Update Successfully";
                //    }
                //    con.Close();
                //}


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
        protected void txtPrice1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var rows = GridProcurement.Rows;
                TextBox txtQty = (TextBox)sender;
                GridViewRow row = (GridViewRow)txtQty.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                Label lblProductlist1 = (Label)row.FindControl("lblProductlist1");
                TextBox txtProduct = (TextBox)row.FindControl("txtProduct");
                TextBox txtDescription = (TextBox)row.FindControl("txtDescription");
                //TextBox txtQty = (TextBox)row.FindControl("txtQty");
                TextBox txtPrice = (TextBox)row.FindControl("txtPrice");
                Label lblEditAmont1 = (Label)row.FindControl("lblEditAmont1");

                Label lblTotalAmount = (Label)row.FindControl("lblAmont1");

                string ProductID = ((Label)rows[rowindex].FindControl("lblProductID1")).Text;
                int quantity = Convert.ToInt32(txtQty.Text);

                float rate;
                if (string.IsNullOrEmpty(txtPrice.Text))
                {
                    rate = 0;
                }
                else
                {
                    rate = Convert.ToSingle(txtPrice.Text);
                }

                //Label lblAmont = (Label)GridServicesList.FooterRow.FindControl("lblAmont");

                decimal price = Convert.ToDecimal(txtPrice.Text);
                decimal Amount;
                decimal Quantity = Convert.ToDecimal(txtQty.Text);

                Amount = price * Quantity; //Formula

                decimal TotalAmount = decimal.Round(Amount, 2);
                // float Subtotal = quantity * rate;
                //float totalAmount = Subtotal + (Subtotal * tax1Rate / 100) + (Subtotal * tax2Rate / 100);
                lblEditAmont1.Text = TotalAmount.ToString();

                //using (SqlConnection con = new SqlConnection(strconnect))
                //{
                //    SqlCommand cmd = new SqlCommand("SP_UpdatePurchaseOrderProcurement", con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@ID", ProductID);
                //    cmd.Parameters.AddWithValue("@ProjectName", lblProjectName1.Text);
                //    cmd.Parameters.AddWithValue("@ProjectName", ddlProjects.SelectedItem.Text);
                //    cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                //    cmd.Parameters.AddWithValue("@CustName", ddlCustomers.SelectedItem.Text);
                //    cmd.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                //    cmd.Parameters.AddWithValue("@ProductName", txtProduct.Text);
                //    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);

                //    cmd.Parameters.AddWithValue("@Quantity", txtQty.Text);
                //    cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                //    cmd.Parameters.AddWithValue("@TotalAmont", lblEditAmont1);
                //    //cmd.Parameters.AddWithValue("@ProjectID", ProjectId);
                //    //cmd.Parameters.AddWithValue("@CustName", lblClient1.Text);
                //    cmd.Parameters.AddWithValue("@CreateBy", UserName);
                //    cmd.Parameters.AddWithValue("@EmpID", UserId);
                //    cmd.Parameters.AddWithValue("@Designation", Designation);

                //    con.Open();
                //    int Result = cmd.ExecuteNonQuery();
                //    if (Result < 0)
                //    {
                //        Toasteralert.Visible = false;
                //        deleteToaster.Visible = true;
                //        lblMesDelete.Text = "Project  Procurement Update Successfully";
                //        GridProcurement.EditIndex = -1;
                //        //ViewPOProjectProcurement(lblProjectID.Text);
                //        // GetProcurementAmount(lblProjectID.Text);

                //    }
                //    else
                //    {
                //        Toasteralert.Visible = false;
                //        deleteToaster.Visible = true;
                //        lblMesDelete.Text = "Project  Procurement Not Update Successfully";
                //    }
                //    con.Close();
                //}


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

        protected void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Label lblProductID1 = (Label)GridProcurement.FooterRow.FindControl("lblProductID1");
                TextBox txtItem = (TextBox)GridProcurement.FooterRow.FindControl("txtItem");
                TextBox txtProduct = (TextBox)GridProcurement.FooterRow.FindControl("txtProduct");
                TextBox txtPrice = (TextBox)GridProcurement.FooterRow.FindControl("txtPrice");
                TextBox txtDescription = (TextBox)GridProcurement.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridProcurement.FooterRow.FindControl("txtQty");
                Label lblAmontP = (Label)GridProcurement.FooterRow.FindControl("lblAmontP");

                double Qunty, Price, Amount;
                Qunty = Convert.ToDouble(txtQty.Text);
                Price = Convert.ToDouble(txtPrice.Text);
                Amount = Qunty * Price;

                lblAmontP.Text = Amount.ToString();

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

        protected void btnAddProcurement_Click(object sender, EventArgs e)
        {
            try
            {
                UserId = Convert.ToInt32(Session["UserID"]);
                UserName = Session["UserName"].ToString();
                // Retrieve controls in the footer row
                Label lblProductID1 = (Label)GridProcurement.FooterRow.FindControl("lblProductID1");

                TextBox txtProduct = (TextBox)GridProcurement.FooterRow.FindControl("txtProduct");
                TextBox txtDescription = (TextBox)GridProcurement.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridProcurement.FooterRow.FindControl("txtQty");
                TextBox txtPrice = (TextBox)GridProcurement.FooterRow.FindControl("txtPrice");
                Label lblAmont1 = (Label)GridProcurement.FooterRow.FindControl("lblAmont1");

                decimal price = Convert.ToDecimal(txtPrice.Text);
                decimal Amount;
                decimal Quantity = Convert.ToDecimal(txtQty.Text);

                Amount = price * Quantity; //Formula

                decimal TotalAmount = decimal.Round(Amount, 2);

                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    // db connect
                    SqlCommand cmd = new SqlCommand("SP_SavePurchaseOrderProcurement", con);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PONumber", txtPONumber.Text);
                    cmd.Parameters.AddWithValue("@ProductID", lblProductID1.Text);
                    cmd.Parameters.AddWithValue("@ProjectName", ddlProjects.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@CustName", ddlCustomers.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("ProductName", txtProduct.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@Quantity", txtQty.Text);
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@TotalAmont", TotalAmount);
                    cmd.Parameters.AddWithValue("@CreateBy", UserName);
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
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Service Order Item Details Save Successfully!')", true);
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Purchase Order Procurement Item Details Save Successfully";

                    }
                    else
                    {
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Service Order Item Details Not Save Successfully!')", true);
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Purchase Order Procurement Item Details Already Available";
                    }
                    int Projectid = Convert.ToInt32(ddlProjects.SelectedValue);
                    ViewPurchaseOrderProcurement(Projectid);
                    GetPOProcurementAmount();
                    // Clear();
                    con.Close();
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
                DeviceCon.Close();
            }
            finally

            {

            }
        }

        protected void btnCancelProcurement_Click(object sender, EventArgs e)
        {
            try
            {
                UserId = Convert.ToInt32(Session["UserID"]);
                UserName = Session["UserName"].ToString();

                TextBox txtProduct = (TextBox)GridProcurement.FooterRow.FindControl("txtProduct");
                TextBox txtDescription = (TextBox)GridProcurement.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridProcurement.FooterRow.FindControl("txtQty");
                TextBox txtPrice = (TextBox)GridProcurement.FooterRow.FindControl("txtPrice");

                txtProduct.Text = String.Empty;
                txtDescription.Text = String.Empty;
                txtQty.Text = String.Empty;
                txtPrice.Text = String.Empty;

                int Projectid = Convert.ToInt32(ddlProjects.SelectedValue);
                ViewPurchaseOrderProcurement(Projectid);
                GetPOProcurementAmount();
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

        //--------------------------------------------------------------------------------------------------------
        //Purchase Order Procurement gridview END
        //--------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------
        //Service Detailing Modalpopup Start
        //--------------------------------------------------------------------------------------------------------
        protected void btnCloseModalService_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaveModalservice_Click(object sender, EventArgs e)
        {

        }
        //--------------------------------------------------------------------------------------------------------
        //Service Detailing Modalpopup END
        //--------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------
        //Purchase Order Service gridview Start
        //--------------------------------------------------------------------------------------------------------
        protected void ddlItemServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                Label lblServiceID1 = (Label)GridServicesList.FooterRow.FindControl("lblServiceID1");
                int ItemID = Convert.ToInt32(ddlItemServices.SelectedValue);

                TextBox txtServices = (TextBox)GridServicesList.FooterRow.FindControl("txtServices");
                TextBox txtDescription = (TextBox)GridServicesList.FooterRow.FindControl("txtDescription");
                TextBox txtPrice = (TextBox)GridServicesList.FooterRow.FindControl("txtServicePrice");
                TextBox txtQty = (TextBox)GridServicesList.FooterRow.FindControl("txtServiceFoterrQty");
                Label lblAmont = (Label)GridServicesList.FooterRow.FindControl("lblAmont");


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
                        lblServiceID1.Text = dt.Rows[0]["ID"].ToString();
                        txtPrice.Text = dt.Rows[0]["Rate"].ToString();
                        txtServices.Text = dt.Rows[0]["Description"].ToString();
                        txtDescription.Text = dt.Rows[0]["Long_Description"].ToString();


                    }

                    double Qunty, Price, Amount;
                    Qunty = Convert.ToDouble(txtQty.Text);
                    Price = Convert.ToDouble(txtPrice.Text);
                    Amount = Qunty * Price;

                    lblAmont.Text = Amount.ToString();
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
        protected void txtServiceFoterrQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Label lblServiceID1 = (Label)GridServicesList.FooterRow.FindControl("lblServiceID1");
                TextBox txtServices = (TextBox)GridServicesList.FooterRow.FindControl("txtServices");
                TextBox txtDuration = (TextBox)GridServicesList.FooterRow.FindControl("txtDuration");
                TextBox txtDescription = (TextBox)GridServicesList.FooterRow.FindControl("txtDescription");
                TextBox txtServiceFoterrQty = (TextBox)GridServicesList.FooterRow.FindControl("txtServiceFoterrQty");
                TextBox txtServicePrice = (TextBox)GridServicesList.FooterRow.FindControl("txtServicePrice");
                Label lblAmont = (Label)GridServicesList.FooterRow.FindControl("lblAmont");

                double Qunty, Price, Amount;
                Qunty = Convert.ToDouble(txtServiceFoterrQty.Text);
                Price = Convert.ToDouble(txtServicePrice.Text);
                Amount = Qunty * Price;

                lblAmont.Text = Amount.ToString();



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
      
        protected void txtPrice1_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                var rows = GridServicesList.Rows;
                TextBox txtQty = (TextBox)sender;
                GridViewRow row = (GridViewRow)txtQty.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);

                Label lblServiceID1 = (Label)row.FindControl("lblServiceID1");
                TextBox txtServices = (TextBox)row.FindControl("txtServices");
                TextBox txtDescription = (TextBox)row.FindControl("txtDescription");
                //TextBox txtQty = (TextBox)row.FindControl("txtQty");
                TextBox txtPrice = (TextBox)row.FindControl("txtPrice");
                Label lblEditAmontService = (Label)row.FindControl("lblEditAmontService");

                Label lblTotalAmount = (Label)row.FindControl("lblEditAmontService");

                string ServiceID = ((Label)rows[rowindex].FindControl("lblServiceID1")).Text;
                int quantity = Convert.ToInt32(txtQty.Text);

                float rate;
                if (string.IsNullOrEmpty(txtPrice.Text))
                {
                    rate = 0;
                }
                else
                {
                    rate = Convert.ToSingle(txtPrice.Text);
                }

                //Label lblAmont = (Label)GridServicesList.FooterRow.FindControl("lblAmont");

                decimal price = Convert.ToDecimal(txtPrice.Text);
                decimal Amount;
                decimal Quantity = Convert.ToDecimal(txtQty.Text);

                Amount = price * Quantity; //Formula

                decimal TotalAmount = decimal.Round(Amount, 2);
                // float Subtotal = quantity * rate;
                //float totalAmount = Subtotal + (Subtotal * tax1Rate / 100) + (Subtotal * tax2Rate / 100);
                lblEditAmontService.Text = TotalAmount.ToString();

                //using (SqlConnection con = new SqlConnection(strconnect))
                //{
                //    SqlCommand cmd = new SqlCommand("SP_UpdatePurchaseOrderService", con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@ID", ServiceID);
                //    cmd.Parameters.AddWithValue("@ProjectName", lblProjectName1.Text);
                //    cmd.Parameters.AddWithValue("@ProjectName", ddlProjects.SelectedItem.Text);
                //    cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                //    cmd.Parameters.AddWithValue("@CustName", ddlCustomers.SelectedItem.Text);
                //    cmd.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                //    cmd.Parameters.AddWithValue("@ServiceName", txtServices.Text);
                //    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                //    cmd.Parameters.AddWithValue("@ProductName", lblProjectName1.Text);
                //    cmd.Parameters.AddWithValue("@Quantity", txtQty.Text);
                //    cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                //    cmd.Parameters.AddWithValue("@TotalAmont", lblEditAmontService);
                //    //cmd.Parameters.AddWithValue("@ProjectID", ProjectId);
                //    //cmd.Parameters.AddWithValue("@CustName", lblClient1.Text);
                //    cmd.Parameters.AddWithValue("@CreateBy", UserName);
                //    cmd.Parameters.AddWithValue("@EmpID", UserId);
                //    cmd.Parameters.AddWithValue("@Designation", Designation);

                //    con.Open();
                //    int Result = cmd.ExecuteNonQuery();
                //    if (Result < 0)
                //    {
                //        Toasteralert.Visible = false;
                //        deleteToaster.Visible = true;
                //        lblMesDelete.Text = "Project  Procurement Update Successfully";
                //        GridProcurement.EditIndex = -1;
                //        //ViewPOProjectProcurement(lblProjectID.Text);
                //        // GetProcurementAmount(lblProjectID.Text);

                //    }
                //    else
                //    {
                //        Toasteralert.Visible = false;
                //        deleteToaster.Visible = true;
                //        lblMesDelete.Text = "Project  Procurement Not Update Successfully";
                //    }
                //    con.Close();
                //}


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
        protected void txtQtyService1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var rows = GridServicesList.Rows;
                TextBox txtQty = (TextBox)sender;
                GridViewRow row = (GridViewRow)txtQty.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);

                Label lblServiceID1 = (Label)row.FindControl("lblProductServiceslist1");
                TextBox txtEditServices = (TextBox)row.FindControl("txtEditServices");
                TextBox txtDuration1 = (TextBox)row.FindControl("txtDuration1");
                TextBox txtEditDescription = (TextBox)row.FindControl("txtEditDescription");
                TextBox txtQty1 = (TextBox)row.FindControl("txtQty1");
                TextBox txtPrice1 = (TextBox)row.FindControl("txtPrice1");
                Label lblEditAmontService = (Label)row.FindControl("lblEditAmontService");

                //Label lblTotalAmount = (Label)row.FindControl("lblEditAmontService");lblServiceID

                string ServiceID = ((Label)rows[rowindex].FindControl("lblServiceID")).Text;
                int quantity = Convert.ToInt32(txtQty.Text);

                decimal price;
                if (string.IsNullOrEmpty(txtPrice1.Text))
                {
                    price = 0;
                }
                else
                {
                    price = Convert.ToDecimal(txtPrice1.Text);
                }

                //decimal Quantity = Convert.ToDecimal(txtQty.Text);
                // txtPrice1 = txtPrice1.Text;
                decimal Amount = price * quantity;
                decimal TotalAmount = decimal.Round(Amount, 2);

                lblEditAmontService.Text = TotalAmount.ToString();
                //lblEditAmontService.Text = TotalAmount.ToString();

                //using (SqlConnection con = new SqlConnection(strconnect))
                //{
                //    SqlCommand cmd = new SqlCommand("SP_UpdatePurchaseOrderService", con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@ID", ServiceID);

                //    cmd.Parameters.AddWithValue("@ProjectName", ddlProjects.SelectedItem.Text);
                //    cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                //    cmd.Parameters.AddWithValue("@CustName", ddlCustomers.SelectedItem.Text);
                //    cmd.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                //    cmd.Parameters.AddWithValue("@ServiceName", txtEditServices.Text);
                //    cmd.Parameters.AddWithValue("@Description", txtEditDescription.Text);
                //    cmd.Parameters.AddWithValue("@ProductName", lblProjectName1.Text);
                //    cmd.Parameters.AddWithValue("@Quantity", txtQty.Text);
                //    cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                //    cmd.Parameters.AddWithValue("@TotalAmont", lblEditAmontService);
                //    //cmd.Parameters.AddWithValue("@ProjectID", ProjectId);
                //    //cmd.Parameters.AddWithValue("@CustName", lblClient1.Text);
                //    cmd.Parameters.AddWithValue("@CreateBy", UserName);
                //    cmd.Parameters.AddWithValue("@EmpID", UserId);
                //    cmd.Parameters.AddWithValue("@Designation", Designation);

                //    con.Open();
                //    int Result = cmd.ExecuteNonQuery();
                //    if (Result < 0)
                //    {
                //        Toasteralert.Visible = false;
                //        deleteToaster.Visible = true;
                //        lblMesDelete.Text = "Project  Procurement Update Successfully";
                //        GridProcurement.EditIndex = -1;
                //        //ViewPOProjectProcurement(lblProjectID.Text);
                //        // GetProcurementAmount(lblProjectID.Text);

                //    }
                //    else
                //    {
                //        Toasteralert.Visible = false;
                //        deleteToaster.Visible = true;
                //        lblMesDelete.Text = "Project  Procurement Not Update Successfully";
                //    }
                //    con.Close();
                //}


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

        protected void txtServicePrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Label lblServiceID1 = (Label)GridServicesList.FooterRow.FindControl("lblServiceID1");
                TextBox txtServices = (TextBox)GridServicesList.FooterRow.FindControl("txtServices");
                TextBox txtDuration = (TextBox)GridServicesList.FooterRow.FindControl("txtDuration");
                TextBox txtDescription = (TextBox)GridServicesList.FooterRow.FindControl("txtDescription");
                TextBox txtServiceFoterrQty = (TextBox)GridServicesList.FooterRow.FindControl("txtServiceFoterrQty");
                TextBox txtServicePrice = (TextBox)GridServicesList.FooterRow.FindControl("txtServicePrice");
                Label lblAmont = (Label)GridServicesList.FooterRow.FindControl("lblAmont");

                double Qunty, Price, Amount;
                Qunty = Convert.ToDouble(txtServiceFoterrQty.Text);
                Price = Convert.ToDouble(txtServicePrice.Text);
                Amount = Qunty * Price;

                lblAmont.Text = Amount.ToString();



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

        protected void btnAddServices_Click(object sender, EventArgs e)
        {
            try
            {
                UserId = Convert.ToInt32(Session["UserID"]);
                UserName = Session["UserName"].ToString();
                // Retrieve controls in the footer row

                Label lblServiceID1 = (Label)GridServicesList.FooterRow.FindControl("lblServiceID1");
                TextBox txtServices = (TextBox)GridServicesList.FooterRow.FindControl("txtServices");
                TextBox txtDuration = (TextBox)GridServicesList.FooterRow.FindControl("txtDuration");
                TextBox txtDescription = (TextBox)GridServicesList.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridServicesList.FooterRow.FindControl("txtServiceFoterrQty");
                TextBox txtPrice = (TextBox)GridServicesList.FooterRow.FindControl("txtServicePrice");
                Label lblAmont = (Label)GridServicesList.FooterRow.FindControl("lblAmont");

                decimal price = Convert.ToDecimal(txtPrice.Text);
                decimal Amount;
                decimal Quantity = Convert.ToDecimal(txtQty.Text);

                Amount = price * Quantity; //Formula

                decimal TotalAmount = decimal.Round(Amount, 2);

                SqlConnection con = new SqlConnection(strconnect);  // db connect
                SqlCommand cmd = new SqlCommand("SP_SavePurchaseOrderServices", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PONumber", txtPONumber.Text);
                cmd.Parameters.AddWithValue("@ItemID", lblServiceID1.Text);
                cmd.Parameters.AddWithValue("@ProjectName", ddlProjects.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@CustName", ddlCustomers.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@ServiseName", txtServices.Text);
                cmd.Parameters.AddWithValue("@Duration", txtDuration.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Quantity", txtQty.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@TotalAmont", TotalAmount);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
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
                    lblMesDelete.Text = "Purchase Order Service Item Details Save Successfully";

                }
                else
                {

                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Purchase Order Service Item Details Already Available";
                }
                int Projectid = Convert.ToInt32(ddlProjects.SelectedValue);
                ViewPurchaseOrderServices(Projectid);
                GetPOProcurementAmount();
                // Clear();
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

        protected void btnCancelServices_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdatePurchaseOrder", con);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", lblPurchaseOrderid.Text);
                    cmd.Parameters.AddWithValue("@POName", txtPOName.Text);
                    cmd.Parameters.AddWithValue("@PODate", txtPODate.Text);
                    cmd.Parameters.AddWithValue("@POExpireDate", txtPOExpireDate.Text);
                    cmd.Parameters.AddWithValue("@Amount", txtPOAmount.Text);
                    cmd.Parameters.AddWithValue("@CustId", int.Parse(ddlCustomers.SelectedItem.Value));
                    cmd.Parameters.AddWithValue("@ProjectID", int.Parse(ddlProjects.SelectedItem.Value));
                    cmd.Parameters.AddWithValue("@AddCity", ddllocationcity.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Country", ddllocationcountry.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@AddState", ddllocationstate.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@AddDistrict", ddllocationdistrict.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@AddStreet", txtaddressLine1.Text);
                    cmd.Parameters.AddWithValue("@AddBlock", txtlocationflatno.Text);
                    cmd.Parameters.AddWithValue("@Pincode", txtlocationpincode.Text);
                    cmd.Parameters.AddWithValue("@StatusID", ddlStatus.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@StatusName", ddlStatus.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@SaleAgent", ddlSalesAgent.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@ClientNote", txtClientNote.Text);
                    cmd.Parameters.AddWithValue("@Termcondition", txtTermsAndConditions.Text);
                    cmd.Parameters.AddWithValue("@FileName", lblFileName.Text);
                    cmd.Parameters.AddWithValue("@FilePath", lblFilePath.Text);
                    cmd.Parameters.AddWithValue("@Status", "true");
                    cmd.Parameters.AddWithValue("@Accepted", "true");
                    cmd.Parameters.AddWithValue("@TotalCostProcurement", lblTotalAmountProcurement.Text);
                    cmd.Parameters.AddWithValue("@TotalCostService", lblTotalServiceAmount.Text);
                    cmd.Parameters.AddWithValue("@Createdby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);

                    con.Open();
                    int Result = cmd.ExecuteNonQuery();
                    if (Result < 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Purchase Order Details Update Successfully!')", true);
                        Response.Redirect("~/PurchaseOrder.aspx", false);
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Purchase Order Details Not Update Successfully!')", true);
                    }
                    con.Close();
                }

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

        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseOrder.aspx");
        }
        //--------------------------------------------------------------------------------------------------------
        //Purchase Order Service gridview Start
        //--------------------------------------------------------------------------------------------------------
        #endregion
    }
}