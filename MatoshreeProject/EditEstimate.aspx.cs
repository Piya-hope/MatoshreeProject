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

#endregion

namespace MatoshreeProject
{
    public partial class EditEstimate : System.Web.UI.Page
    {
        #region " Class Level Variable "

        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result, EstimateID;


        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        Double TotalAmont, TotalTaxAmount;
        string Size, Initial, ReceiptFor, Cash, Bank, reminder;

        string Day = Convert.ToString(DateTime.Today.Day);
        string year = Convert.ToString(DateTime.Today.Year);
        Double EastimateTOTALAMONT;

        Double DiscountItem1 = 0, Adjustment1 = 0, TaxTotalItem1, SubtotalItem1;
        decimal TotalEstimateAmont;
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

        /// -------------------------------------------------------------------------
        /// <summary>
        /// Code for bind the customer details to dropdown from database.
        /// </summary>
        /// -------------------------------------------------------------------------

        public DataTable EstimateTaxName(string Estimate)
        {
            DataTable dtNew = new DataTable();
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    string Taxname, Taxper, TaxAmountCost;

                    SqlCommand cmd = new SqlCommand("SP_TaxEstimateItem", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@EstimateNumber", Estimate);
                    cmd.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
                    DataTable dt2 = new DataTable();
                    sda.Fill(dt2);
                    if (dt2.Rows.Count > 0)
                    {
                        listTaxNames1.DataSource = dt2;
                        listTaxNames1.DataTextField = "TaxName";
                        listTaxNames1.DataValueField = "TaxName";
                        listTaxNames1.DataBind();

                        DataTable Taxdt = new DataTable();
                        Taxdt.Columns.Add("TaxValesPer");
                        Taxdt.Columns.Add("TAXNAMEV");
                        Double TaxAmount;
                        Double TotalTaxCount, TaXcount, TaXcount2;

                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            Double TaxAmountPER = Convert.ToDouble(dt2.Rows[i]["TaxRate"]);
                            Taxname = Convert.ToString(dt2.Rows[i]["TaxName"]);
                            Taxper = Convert.ToString(dt2.Rows[i]["TaxRate"]);

                            using (SqlConnection contax = new SqlConnection(strconnect))
                            {
                                SqlCommand cmdtax = new SqlCommand("SP_GetAmountTaxName1Estimate", contax);
                                cmdtax.Connection = contax;
                                cmdtax.CommandType = CommandType.StoredProcedure;
                                cmdtax.Parameters.AddWithValue("@EstimateNumber", Estimate);
                                cmdtax.Parameters.AddWithValue("@TaxName", Taxname);
                                cmdtax.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                                cmdtax.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                                cmdtax.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
                                SqlDataAdapter sdatax = new SqlDataAdapter(cmdtax);
                                DataTable dttax = new DataTable();
                                sdatax.Fill(dttax);
                                if (dttax.Rows.Count > 0)
                                {
                                    TaXcount = Convert.ToDouble(dttax.Rows[0]["Tax1Amount"]);
                                    TAXCount.Text = Convert.ToString(dttax.Rows[0]["Tax1Amount"]);
                                }
                                else
                                {
                                    TaXcount = Convert.ToDouble(0);
                                    TAXCount.Text = Convert.ToString(TaXcount);
                                }
                            }

                            using (SqlConnection contax2 = new SqlConnection(strconnect))
                            {
                                SqlCommand cmdtax2 = new SqlCommand("SP_GetAmountTaxName2Estimate", contax2);
                                cmdtax2.Connection = contax2;
                                cmdtax2.CommandType = CommandType.StoredProcedure;
                                cmdtax2.Parameters.AddWithValue("@EstimateNumber", Estimate);
                                cmdtax2.Parameters.AddWithValue("@TaxName", Taxname);
                                cmdtax2.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                                cmdtax2.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                                cmdtax2.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
                                SqlDataAdapter sdatax2 = new SqlDataAdapter(cmdtax2);
                                DataTable dttax2 = new DataTable();
                                sdatax2.Fill(dttax2);
                                if (dttax2.Rows.Count > 0)
                                {
                                    TaXcount2 = Convert.ToDouble(dttax2.Rows[0]["Tax2Amount"]);
                                    TAXCount2.Text = Convert.ToString(dttax2.Rows[0]["Tax2Amount"]);
                                }
                                else
                                {
                                    TaXcount2 = Convert.ToDouble(0);
                                    TAXCount.Text = Convert.ToString(TaXcount2);
                                }
                            }

                            TotalTaxCount = TaXcount2 + TaXcount;

                            TaxAmount = TotalTaxCount;
                            TaxAmountCost = Convert.ToString(TaxAmount);

                            DataRow newRow = Taxdt.NewRow();
                            newRow["TaxValesPer"] = TaxAmountCost;
                            newRow["TAXNAMEV"] = Taxname;
                            Taxdt.Rows.Add(newRow);
                        }

                        listTaxValues1.DataSource = Taxdt;
                        listTaxValues1.DataTextField = "TaxValesPer";
                        listTaxValues1.DataValueField = "TAXNAMEV";
                        listTaxValues1.DataBind();
                        //-------------------PDF Code------------------------------------//

                        dtNew = Taxdt;
                    }
                    else
                    {
                        dt2 = null;
                        dtNew = null;
                    }
                    return dtNew;
                }
            }
            catch (Exception ex)
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    dtNew = null;
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
                return dtNew;
            }
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

        public void BindStatusDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetStatusname", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BelongTo", "Estimate");
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
        protected void bindDiscount()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetDiscountName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    //ddlDiscountType.DataSource = ds.Tables[0];
                    //ddlDiscountType.DataTextField = "DiscName";
                    //ddlDiscountType.DataValueField = "DiscID";
                    //ddlDiscountType.DataBind();
                    //ddlDiscountType.Items.Insert(0, new ListItem("Select Discount", "0"));
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
                    //Response.Write("<script> alert('Error Log Inserted !!') </script>");
                }
                else
                {
                    //Response.Write("<script> alert('Error Log Inserted !!') </script>");
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
            cmd.Parameters.AddWithValue("@ReceiptFor", "Estimate");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ReceiptFor = dt.Rows[0]["ReceiptFor"].ToString();
                Initial = dt.Rows[0]["Initial"].ToString();
                Size = dt.Rows[0]["size"].ToString();
                lblInitialNumber.Text = year + "-" + Day + ":";
                //Initial = lblInitialNumber.Text;


            }
            return generateOrderNo(Initial, long.Parse(Size));
        }

        public void Calculatefilldata()
        {
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                SqlCommand com = new SqlCommand("SP_GetEstimateByICal", con1);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EstimateNumber", txtEstimateNumber.Text);
                com.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                com.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                com.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridCalculate.DataSource = dt;
                    GridCalculate.DataBind();

                    //Get the row that contains this button
                    foreach (GridViewRow gridviedrow in GridCalculate.Rows)
                    {
                        //Label lblRowNumber = (Label)gridviedrow.FindControl("lblRowNumber");

                        TextBox txtQantity1 = (TextBox)gridviedrow.FindControl("txtQty1");
                        TextBox txtRate1 = (TextBox)gridviedrow.FindControl("txtRate1");
                        DropDownList ddlTaxCost = (DropDownList)gridviedrow.FindControl("ddlTaxCost");
                        DropDownList ddlTaxCost1A = (DropDownList)gridviedrow.FindControl("ddlTaxCost1A");
                        Label lblSubAmont1 = (Label)gridviedrow.FindControl("lblSubAmont1");
                        Label lblTax1Rate1 = (Label)gridviedrow.FindControl("lblTax1Rate1");
                        Label lblTax2Rate1 = (Label)gridviedrow.FindControl("lblTax2Rate1");
                        Label lblAmont1 = (Label)gridviedrow.FindControl("lblAmont1");
                        Label lblHSN1 = (Label)gridviedrow.FindControl("lblHSN1");
                        Label lblItemID1 = (Label)gridviedrow.FindControl("lblItemID1");
                        LinkButton btnDeleteItemCal1 = (LinkButton)gridviedrow.FindControl("btnDeleteItemCal");

                        //lblRowNumber.Visible = false;
                        btnDeleteItemCal1.Visible = true;
                        txtRate1.Visible = true;
                        txtQantity1.Visible = true;
                        ddlTaxCost.Visible = true;
                        ddlTaxCost1A.Visible = true;
                        lblSubAmont1.Visible = true;
                        lblTax1Rate1.Visible = true;
                        lblTax2Rate1.Visible = true;
                        lblAmont1.Visible = true;
                        lblHSN1.Visible = true;
                        
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
                SubCostTotalEstimateAmont();
                GetTaxlistCalculation();
                string Estimate = txtEstimateNumber.Text;
                GetItemTax(Estimate); // Sum Total Item Tax               
                TotalEstimateCost();//Total Calculation For Invoice 
            }
        }


        #endregion

        #region " Public Functions "

        #endregion

        #region " Protected Functions "

        public void Clear()
        {
            //----------------------------------------------------------------------//
            //TextBox txtItem = (TextBox)GridCalculate.FooterRow.FindControl("txtItem");
            //TextBox txtDescription = (TextBox)GridCalculate.FooterRow.FindControl("txtDescription");
            //TextBox txtQty = (TextBox)GridCalculate.FooterRow.FindControl("txtQty");
            //TextBox txtRate = (TextBox)GridCalculate.FooterRow.FindControl("txtRate");
            //DropDownList ddlTax = (DropDownList)GridCalculate.FooterRow.FindControl("ddlTax");
            //----------------------------------------------------------------------//
            txtEstimateNumber.Text = string.Empty;
            txtEstimateDate.Text = string.Empty;
            ddlCustomers.SelectedIndex = -1;
            ddlProjects.SelectedIndex = -1;
            lblBillTo.Text = string.Empty;
            lblbillTo1.Text = string.Empty;
            lblbillTo2.Text = string.Empty;
            lblbillTo3.Text = string.Empty;
            lblbillTo4.Text = string.Empty;
            lblbillTo5.Text = string.Empty;
            lblbillTo6.Text = string.Empty;
            lblbillTo7.Text = string.Empty;
            txtExpiryDate.Text = string.Empty;

            lblShipTo.Text = string.Empty;
            lblShipTo1.Text = string.Empty;
            lblShipTo2.Text = string.Empty;
            lblShipTo3.Text = string.Empty;
            lblShipTo4.Text = string.Empty;
            lblShipTo5.Text = string.Empty;
            lblShipTo6.Text = string.Empty;
            lblShipTo7.Text = string.Empty;
            //ddlDiscountType.SelectedIndex = -1;
            ddlItem.SelectedIndex = -1;

            ddlCurrency.SelectedIndex = -1;
            ddlSalesAgent.SelectedIndex = -1;
            //ddlDiscountType.SelectedIndex = -1;
            //ddlBillTask.SelectedIndex = -1;
            ddlStatus.SelectedIndex = -1;
            txtAdminNote.Text = string.Empty;
            lbltotalAmonutInvoiceCost.Text = string.Empty;

            txtClientNote.Text = string.Empty;
            txtTermsAndConditions.Text = string.Empty;

            lblSubTotalCost.Text = string.Empty;
            txtDiscount1.Text = string.Empty;
            listTaxNames1.ClearSelection();
            listTaxValues1.ClearSelection();
            lblDiscountCost.Text = Convert.ToString("₹ " + "0.00");
            txtDiscount1.Text = Convert.ToString("₹ " + "0.00");

            listTaxNames1.DataSource = null;
            listTaxNames1.DataBind();

            DataTable dt = new DataTable();
            listTaxValues1.DataSource = dt;
            listTaxValues1.DataBind();

            listTaxValues1.DataSource = dt;
            listTaxValues1.DataBind();


            listTaxNames1.Visible = false;
            listTaxValues1.Visible = false;
            lblCostTaax.Visible = false;

            TxtAdjustment1.Text = Convert.ToString("₹ " + "0.00");
            lblAdjustmentCost.Text = Convert.ToString("₹ " + "0.00");
            lbltotalAmonutInvoiceCost.Text = Convert.ToString("₹ " + "0.00");

            string ReceiptNumner = GETReceiptINITIAL();
            txtEstimateNumber.Text = ReceiptNumner;
            string Todaydate = Convert.ToString(DateTime.Today);
            string WeekDate = Convert.ToString(DateTime.Today.AddDays(7));
            Calculatefilldata();
        }

        public void CustAddress(int CustID)
        {
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
                lblbillTo1.Text = dt.Rows[0]["Add_Block"].ToString() + ",";
                lblbillTo2.Text = dt.Rows[0]["Add_Street"].ToString() + ",";
                lblbillTo3.Text = dt.Rows[0]["Add_City"].ToString() + ",";
                lblbillTo4.Text = dt.Rows[0]["Add_District"].ToString() + ",";
                lblbillTo5.Text = dt.Rows[0]["Add_State"].ToString() + ",";
                lblbillTo7.Text = dt.Rows[0]["Add_Country"].ToString() + ",";
                lblbillTo6.Text = "PIN :" + dt.Rows[0]["Add_PinCode"].ToString();

                lblShipTo1.Text = dt.Rows[0]["Ship_Block"].ToString() + ",";
                lblShipTo2.Text = dt.Rows[0]["Ship_Street"].ToString() + ",";
                lblShipTo3.Text = dt.Rows[0]["Ship_City"].ToString() + ",";
                lblShipTo4.Text = dt.Rows[0]["Ship_District"].ToString() + ",";
                lblShipTo5.Text = dt.Rows[0]["Ship_State"].ToString() + ",";
                lblShipTo7.Text = dt.Rows[0]["Add_Country"].ToString() + ",";
                lblShipTo6.Text = "PIN :" + dt.Rows[0]["Ship_PinCode"].ToString();
            }
        }
        protected void GetEstimateDetailsByID()
        {
            try
            {
                EstimateID = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                lblEstimateID.Text = EstimateID;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetEstimateDetailsByID", UserCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ID", EstimateID);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblInitialNumber.Text = year + "-" + Day + "/";
                        txtEstimateNumber.Text = dt.Rows[0]["EstimateNo"].ToString();
                        txtEstimateDate.Attributes["value"] = DateTime.Parse(dt.Rows[0]["EstimateDate"].ToString()).ToString("yyyy-MM-dd");
                        txtExpiryDate.Attributes["value"] = DateTime.Parse(dt.Rows[0]["Expiry_Date"].ToString()).ToString("yyyy-MM-dd");
                        ddlCustomers.SelectedItem.Text = dt.Rows[0]["Cust_Name"].ToString();
                        ddlCustomers.SelectedValue = dt.Rows[0]["CustomerID"].ToString();

                        int CustID = Convert.ToInt32(ddlCustomers.SelectedItem.Value);
                        CustAddress(CustID);

                        ddlProjects.SelectedItem.Text = dt.Rows[0]["ProjectName"].ToString();
                        ddlProjects.SelectedValue = dt.Rows[0]["ProjectID"].ToString();

                        txtReference.Text = dt.Rows[0]["Reference"].ToString();
                        ddlCurrency.SelectedItem.Text = dt.Rows[0]["Currency"].ToString();
                        ddlSalesAgent.SelectedItem.Text = dt.Rows[0]["Sales_Agent"].ToString();
                        ddlSalesAgent.SelectedItem.Value = dt.Rows[0]["SaleagentID"].ToString();

                        //ddlDiscountType.SelectedItem.Text = dt.Rows[0]["Discount_Type"].ToString();
                        txtAdminNote.Text = dt.Rows[0]["Admin_Note"].ToString();
                        txtClientNote.Text = dt.Rows[0]["Client_Note"].ToString();
                        txtTermsAndConditions.Text = dt.Rows[0]["Term_condition"].ToString();
                        ddlStatus.SelectedItem.Text = dt.Rows[0]["Status"].ToString();
                        RadioButtonListQty.SelectedItem.Text = dt.Rows[0]["ShowQty"].ToString();

                        //ddlBillTask.SelectedItem.Value = dt.Rows[0]["BillingTypeID"].ToString();
                        //ddlBillTask.SelectedItem.Text = dt.Rows[0]["Billing_Type"].ToString();

                        GetItemTax(txtEstimateNumber.Text);
                        EstimateTaxName(txtEstimateNumber.Text);

                        lbltotaltaxPer.Text = dt.Rows[0]["TotalTaxPER"].ToString();
                        lbltotalcosttax.Text = dt.Rows[0]["TotalTax"].ToString();

                        lblSubTotalCost.Text = dt.Rows[0]["SubCostTotalAmont"].ToString();
                        txtDiscount1.Text = dt.Rows[0]["TotalDicountPer"].ToString();
                        lblDiscountCost.Text = dt.Rows[0]["TotalDicountAmont"].ToString();
                        string adj = dt.Rows[0]["AdjustmentCost"].ToString();
                        char[] arr = { '₹' };
                        TxtAdjustment1.Text = adj.Trim(arr).ToString();
                        lblAdjustmentCost.Text = dt.Rows[0]["AdjustmentCost"].ToString();
                        lbltotalAmonutInvoiceCost.Text = dt.Rows[0]["InvoiceTotalAmont"].ToString();
                        lblSAveAS.Text = dt.Rows[0]["SaveAs"].ToString();
                        string EstStatus = dt.Rows[0]["Status1"].ToString();
                        if (EstStatus == "True")
                        {
                            btnConvertDraft.Visible = false;
                            btnConvertDraft.Text = "Convet To Draft";
                            btnConvertDraft.CssClass = "btn btn-warning";
                        }
                        else
                        {
                            btnConvertDraft.Visible = true;
                            btnConvertDraft.Text = "Convet To Save";
                            btnConvertDraft.CssClass = "btn btn-info";
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
            finally
            {
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
                            bindBillingType();
                            bindcustomer();
                            bindProject();
                            bindStaff();
                            BindStatusDetails();
                            bindDiscount();
                            bindItem();
                            bindTax();
                            GetEstimateDetailsByID();
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
                                bindBillingType();
                                bindcustomer();
                                bindProject();
                                bindStaff();
                                BindStatusDetails();
                                bindDiscount();
                                bindItem();
                                bindTax();
                                GetEstimateDetailsByID();
                                Calculatefilldata();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);  // db connect
                SqlCommand cmd = new SqlCommand("SP_UpdateEstimate", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", lblEstimateID.Text);
                cmd.Parameters.AddWithValue("@EstimateNo", txtEstimateNumber.Text);
                cmd.Parameters.AddWithValue("@EstimateDate", txtEstimateDate.Text);
                cmd.Parameters.AddWithValue("@CustomerID", ddlCustomers.SelectedValue);
                cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedValue);

                string billaddressTo = lblBillTo.Text;
                string billaddress1 = lblbillTo1.Text;
                string billaddress2 = lblbillTo2.Text;
                string billaddress3 = lblbillTo3.Text;
                string billaddress4 = lblbillTo4.Text;
                string billaddress5 = lblbillTo5.Text;
                string billaddress6 = lblbillTo6.Text;
                string billaddress7 = lblbillTo7.Text;

                string shipaddressTo = lblShipTo.Text;
                string shipaddressTo1 = lblShipTo1.Text;
                string shipaddressTo2 = lblShipTo2.Text;
                string shipaddressTo3 = lblShipTo3.Text;
                string shipaddressTo4 = lblShipTo4.Text;
                string shipaddressTo5 = lblShipTo5.Text;
                string shipaddressTo6 = lblShipTo6.Text;
                string shipaddressTo7 = lblShipTo7.Text;

                string AddressCustomer = billaddressTo + billaddress1 + billaddress2 + billaddress3 + billaddress4 + billaddress5 + billaddress7 + billaddress6;
                string ShippAddressCustomer = shipaddressTo + shipaddressTo1 + shipaddressTo2 + shipaddressTo3 + shipaddressTo4 + shipaddressTo5 + shipaddressTo7 + shipaddressTo6;

                cmd.Parameters.AddWithValue("@Bill_To", AddressCustomer);
                cmd.Parameters.AddWithValue("@Ship_To", ShippAddressCustomer);
                cmd.Parameters.AddWithValue("@Expiry_Date", txtExpiryDate.Text);

                cmd.Parameters.AddWithValue("@Reference", txtReference.Text);
                cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Currency", ddlCurrency.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Sales_Agent", ddlSalesAgent.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Discount_Type", "0");
                cmd.Parameters.AddWithValue("@ShowQty", RadioButtonListQty.SelectedItem.Text);

                cmd.Parameters.AddWithValue("@BillingTypeID", "0");
                cmd.Parameters.AddWithValue("@Admin_Note", txtAdminNote.Text);
                cmd.Parameters.AddWithValue("@TotalTax", lbltotalcosttax.Text);
                cmd.Parameters.AddWithValue("@TotalTaxPER", lbltotaltaxPer.Text);
                cmd.Parameters.AddWithValue("@TotalDicountPer", txtDiscount1.Text);
                cmd.Parameters.AddWithValue("@TotalDicountAmont", lblDiscountCost.Text);
                cmd.Parameters.AddWithValue("@SubCostTotalAmont", lblSubTotalCost.Text);
                cmd.Parameters.AddWithValue("@InvoiceTotalAmont", lbltotalAmonutInvoiceCost.Text);
                cmd.Parameters.AddWithValue("@AdjustmentCost", lblAdjustmentCost.Text);
                cmd.Parameters.AddWithValue("@Total", lblAmont30.Text);

                cmd.Parameters.AddWithValue("@Client_Note", txtClientNote.Text);
                cmd.Parameters.AddWithValue("@Term_condition", txtTermsAndConditions.Text);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@SaveAS", "Saveu");
                con.Open();
                int Result = cmd.ExecuteNonQuery();
                if (Result < 0)
                {
                    string edit = "xcvfedit";
                    Response.Redirect("~/Estimates_Home.aspx?edit1=" + edit + "", false);
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Estimates Details Not Edit Successfully";
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                Response.Redirect("~/Estimates_Home.aspx", false);
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

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ItemID = Convert.ToInt32(ddlItem.SelectedValue);

                TextBox txtItem = (TextBox)GridCalculate.FooterRow.FindControl("txtItem");
                TextBox txtDescription = (TextBox)GridCalculate.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridCalculate.FooterRow.FindControl("txtQty");
                TextBox txtRate = (TextBox)GridCalculate.FooterRow.FindControl("txtRate");

                DropDownList ddlTax = (DropDownList)GridCalculate.FooterRow.FindControl("ddlTax");
                DropDownList ddlTax1A = (DropDownList)GridCalculate.FooterRow.FindControl("ddlTax1A");
                TextBox txtTax1Rate1F = (TextBox)GridCalculate.FooterRow.FindControl("txtTax1Rate1F");
                TextBox txtTax2Rate1F = (TextBox)GridCalculate.FooterRow.FindControl("txtTax2Rate1F");
                Label lblTaxValees1AF = (Label)GridCalculate.FooterRow.FindControl("lblTaxValees1AF");
                Label lblTaxValeesF = (Label)GridCalculate.FooterRow.FindControl("lblTaxValeesF");
                Label lblHSN = (Label)GridCalculate.FooterRow.FindControl("lblHSN");
                Label lblSubAmont1F = (Label)GridCalculate.FooterRow.FindControl("lblSubAmont1F");
                Label lblGrandAmontF = (Label)GridCalculate.FooterRow.FindControl("lblGrandAmontF");
                //subcategory bind  @categyid = categoryid

                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd1 = new SqlCommand("SP_GetTaxename", conn);
                    cmd1.Connection = conn;
                    cmd1.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda1 = new SqlDataAdapter(cmd1))
                    {
                        DataSet ds1 = new DataSet();
                        sda1.Fill(ds1);
                        ddlTax.DataSource = ds1.Tables[0];
                        ddlTax.DataTextField = "Tax_Name";
                        ddlTax.DataValueField = "Tax_Id";
                        ddlTax.DataBind();
                        ddlTax.Items.Insert(0, new ListItem("Select Tax", "0"));
                        //-----------------------------------------------------------//
                        ddlTax1A.DataSource = ds1.Tables[0];
                        ddlTax1A.DataTextField = "Tax_Name";
                        ddlTax1A.DataValueField = "Tax_Id";
                        ddlTax1A.DataBind();
                        ddlTax1A.Items.Insert(0, new ListItem("Select Tax", "0"));
                    }
                }

                //**//---------------------------------------------------------------//**//
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

                        //if (txtDescription.Text == "")
                        //{
                        //    txtDescription.Text = lblHSN.Text;
                        //}
                        //else
                        //{
                        //    txtDescription.Text = dt.Rows[0]["Long_Description"].ToString() + "\n" + lblHSN.Text;
                        //}

                        txtRate.Text = dt.Rows[0]["Rate"].ToString();
                        ddlTax.SelectedItem.Text = dt.Rows[0]["TaxName"].ToString();
                        lblTaxValeesF.Text = dt.Rows[0]["TaxAmunt"].ToString();

                        ddlTax1A.SelectedItem.Text = dt.Rows[0]["TaxName2"].ToString();
                        lblTaxValees1AF.Text = dt.Rows[0]["TaxAmunt2"].ToString();

                        Double SubTotal, TotalAmountTax1, TotalAmountTax2, GrandTotal;

                        SubTotal = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text);
                        lblSubAmont1F.Text = Convert.ToString(SubTotal);

                        TotalAmountTax1 = SubTotal * Convert.ToDouble(lblTaxValeesF.Text) / 100;
                        TotalAmountTax2 = SubTotal * Convert.ToDouble(lblTaxValees1AF.Text) / 100;

                        txtTax1Rate1F.Text = Convert.ToString(TotalAmountTax1);
                        txtTax2Rate1F.Text = Convert.ToString(TotalAmountTax2);
                        GrandTotal = SubTotal + TotalAmountTax1 + TotalAmountTax2;
                        lblGrandAmontF.Text = Convert.ToString(GrandTotal);

                    }
                }

                SubCostTotalEstimateAmont(); // SubCost Total OF Item
                GetTaxlistCalculation(); // Total Cost per of Item price 
                TotalEstimateCost();//Total Calculation For Estimate 
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

        protected void ddlCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int CustID = Convert.ToInt32(ddlCustomers.SelectedValue);

                //subcategory bind  @categyid = categoryid

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
                    lblbillTo1.Text = dt.Rows[0]["Add_Block"].ToString() + ",";
                    lblbillTo2.Text = dt.Rows[0]["Add_Street"].ToString() + ",";
                    lblbillTo3.Text = dt.Rows[0]["Add_City"].ToString() + ",";
                    lblbillTo4.Text = dt.Rows[0]["Add_District"].ToString() + ",";
                    lblbillTo5.Text = dt.Rows[0]["Add_State"].ToString() + ",";
                    lblbillTo7.Text = dt.Rows[0]["Add_Country"].ToString() + ",";
                    lblbillTo6.Text = "PIN :" + dt.Rows[0]["Add_PinCode"].ToString();

                    lblShipTo1.Text = dt.Rows[0]["Ship_Block"].ToString() + ",";
                    lblShipTo2.Text = dt.Rows[0]["Ship_Street"].ToString() + ",";
                    lblShipTo3.Text = dt.Rows[0]["Ship_City"].ToString() + ",";
                    lblShipTo4.Text = dt.Rows[0]["Ship_District"].ToString() + ",";
                    lblShipTo5.Text = dt.Rows[0]["Ship_State"].ToString() + ",";
                    lblShipTo7.Text = dt.Rows[0]["Add_Country"].ToString() + ",";
                    lblShipTo6.Text = "PIN :" + dt.Rows[0]["Ship_PinCode"].ToString();
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


        protected void btnCopyAddresslink_Click(object sender, EventArgs e)
        {
            lblShipTo.Text = lblBillTo.Text;
            lblShipTo1.Text = lblbillTo1.Text;
            lblShipTo2.Text = lblbillTo2.Text;
            lblShipTo3.Text = lblbillTo3.Text;
            lblShipTo4.Text = lblbillTo4.Text;
            lblShipTo5.Text = lblbillTo5.Text;
            lblShipTo6.Text = lblbillTo6.Text;
            lblShipTo7.Text = lblbillTo7.Text;
        }

        protected void RadioButtonListQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string quantitytext = Convert.ToString(RadioButtonListQty.SelectedItem.Text);

                Label lblQnty = (Label)GridCalculate.HeaderRow.Cells[2].FindControl("lblQuantity");
                //GridCalculate.HeaderRow.Cells[2].Text = quantitytext;
                lblQnty.Text = quantitytext;
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
                    SqlCommand com = new SqlCommand("SP_DeleteEstimateItem", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@EstimateNumber", txtEstimateNumber.Text);
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
                        lblMesDelete.Text = "Eastimate Item Remove Successfully";
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Eastimate  Item Not Remove Successfully";
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

        protected void btnAddInvoiceItem_Click(object sender, EventArgs e)
        {
            try
            {
                string Custid = Convert.ToString(ddlCustomers.SelectedItem.Text);
                string Projectid = Convert.ToString(ddlProjects.SelectedItem.Text);
                string Saleagentid = Convert.ToString(ddlSalesAgent.SelectedItem.Text);
                string item = Convert.ToString(ddlItem.SelectedItem.Text);

                if (Custid == "Select Customer" || Saleagentid == "Select Sale Agent")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Customer AND Sale Agent!')", true);
                }
                else if (Projectid == "Select Project")//item == "Select Item" ||AND Item
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Project !')", true);
                }
                else
                {
                    UserId = Convert.ToInt32(Session["UserID"]);
                    UserName = Session["UserName"].ToString();

                    TextBox txtItem = (TextBox)GridCalculate.FooterRow.FindControl("txtItem");
                    TextBox txtDescription = (TextBox)GridCalculate.FooterRow.FindControl("txtDescription");
                    TextBox txtQty = (TextBox)GridCalculate.FooterRow.FindControl("txtQty");
                    TextBox txtRate = (TextBox)GridCalculate.FooterRow.FindControl("txtRate");

                    DropDownList ddlTax = (DropDownList)GridCalculate.FooterRow.FindControl("ddlTax");
                    DropDownList ddlTax1A = (DropDownList)GridCalculate.FooterRow.FindControl("ddlTax1A");
                    TextBox txtTax1Rate1F = (TextBox)GridCalculate.FooterRow.FindControl("txtTax1Rate1F");
                    TextBox txtTax2Rate1F = (TextBox)GridCalculate.FooterRow.FindControl("txtTax2Rate1F");
                    Label lblTax1Rate1 = (Label)GridCalculate.FooterRow.FindControl("lblTaxValeesF");
                    Label lblTax2Rate1 = (Label)GridCalculate.FooterRow.FindControl("lblTaxValees1AF");
                    Label lblHSN = (Label)GridCalculate.FooterRow.FindControl("lblHSN");

                    Label lblSubAmont1F = (Label)GridCalculate.FooterRow.FindControl("lblSubAmont1F");

                    Label lblGrandAmontF = (Label)GridCalculate.FooterRow.FindControl("lblGrandAmontF");


                    string TaxRate1 = Convert.ToString(lblTax1Rate1.Text);
                    string TaxRate2 = Convert.ToString(lblTax2Rate1.Text);


                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_SaveEstimateItemCalulation", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EstimateNumber", txtEstimateNumber.Text);
                        cmd.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedValue);
                        cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedValue);
                        cmd.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Amount", lblGrandAmontF.Text);
                        cmd.Parameters.AddWithValue("@Quantity", txtQty.Text);
                        cmd.Parameters.AddWithValue("@Rate", txtRate.Text);
                        cmd.Parameters.AddWithValue("@Subtotal", lblSubAmont1F.Text);
                        cmd.Parameters.AddWithValue("@ItemID", ddlItem.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Item", txtItem.Text);
                        cmd.Parameters.AddWithValue("@HSN", lblHSN.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@Tax1Name", ddlTax.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Tax1Rate", TaxRate1);
                        cmd.Parameters.AddWithValue("@Tax1Amunt", txtTax1Rate1F.Text);
                        cmd.Parameters.AddWithValue("@Tax2Name", ddlTax1A.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Tax2Rate", TaxRate2);
                        cmd.Parameters.AddWithValue("@Tax2Amunt", txtTax2Rate1F.Text);
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
                            lblMesDelete.Text = "Estimate New Item Added Successfully";
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Estimate New Item Added Successfully";
                        }
                        Calculatefilldata();
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

        protected void GridCalculate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    DropDownList ddlTax = (DropDownList)e.Row.FindControl("ddlTax");
                    DropDownList ddlTax1A = (DropDownList)e.Row.FindControl("ddlTax1A");

                    using (SqlConnection conn = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetTaxename", conn);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            //------------------------Footer----------------------//
                            ddlTax.DataSource = ds.Tables[0];
                            ddlTax.DataTextField = "Tax_Name";
                            ddlTax.DataValueField = "Tax_Id";
                            ddlTax.DataBind();
                            ddlTax.Items.Insert(0, new ListItem("Select Tax", "0"));

                            ddlTax1A.DataSource = ds.Tables[0];
                            ddlTax1A.DataTextField = "Tax_Name";
                            ddlTax1A.DataValueField = "Tax_Id";
                            ddlTax1A.DataBind();
                            ddlTax1A.Items.Insert(0, new ListItem("Select Tax", "0"));
                        }
                    }
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Find the DropDownList in the Row.
                    DropDownList ddlTaxCost = (DropDownList)e.Row.FindControl("ddlTaxCost");
                    DropDownList ddlTaxCost1A = (DropDownList)e.Row.FindControl("ddlTaxCost1A");

                    using (SqlConnection conn = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetTaxename", conn);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            //**//---------------------------------------------------------------//**//
                            ddlTaxCost.DataSource = ds.Tables[0];
                            ddlTaxCost.DataTextField = "Tax_Name";
                            ddlTaxCost.DataValueField = "Tax_Id";
                            ddlTaxCost.DataBind();
                            ddlTaxCost.Items.Insert(0, new ListItem("Select Tax", "0"));

                            ddlTaxCost1A.DataSource = ds.Tables[0];
                            ddlTaxCost1A.DataTextField = "Tax_Name";
                            ddlTaxCost1A.DataValueField = "Tax_Id";
                            ddlTaxCost1A.DataBind();
                            ddlTaxCost1A.Items.Insert(0, new ListItem("Select Tax", "0"));

                            //Select the Country of Customer in DropDownList.
                            string taxtcost = (e.Row.FindControl("lblTax1") as Label).Text;
                            string taxtcost1 = (e.Row.FindControl("lblTax1A") as Label).Text;
                            if (taxtcost == "" || taxtcost1 == "")
                            {
                                taxtcost = "Select Tax";
                                ddlTaxCost1A.Items.FindByText(taxtcost).Selected = true;
                                ddlTaxCost.Items.FindByText(taxtcost).Selected = true;
                            }
                            else
                            {
                                ddlTaxCost1A.Items.FindByText(taxtcost1).Selected = true;
                                ddlTaxCost.Items.FindByText(taxtcost).Selected = true;
                            }

                        }
                    }
                }

                ////------------------------TaxItemCost-------------------------------------------////

                SubCostTotalEstimateAmont(); // SubCost of Item                            
                GetTaxlistCalculation(); // Total Cost per of Item price     

                string Estimate = txtEstimateNumber.Text;
                GetItemTax(Estimate); // Sum Total Item Tax               
                TotalEstimateCost();//Total Calculation For Estimate 
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

        //-----------------------------------------------------------------------
        // Calculate Footer Template 
        //-----------------------------------------------------------------------
        protected void txtRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtQty = (TextBox)GridCalculate.FooterRow.FindControl("txtQty");
                TextBox txtRate = (TextBox)GridCalculate.FooterRow.FindControl("txtRate");

                DropDownList ddlTax = (DropDownList)GridCalculate.FooterRow.FindControl("ddlTax");
                DropDownList ddlTax1A = (DropDownList)GridCalculate.FooterRow.FindControl("ddlTax1A");
                TextBox txtTax1Rate1F = (TextBox)GridCalculate.FooterRow.FindControl("txtTax1Rate1F");
                TextBox txtTax2Rate1F = (TextBox)GridCalculate.FooterRow.FindControl("txtTax2Rate1F");
                Label lblSubAmont1F = (Label)GridCalculate.FooterRow.FindControl("lblSubAmont1F");
                Label lblGrandAmontF = (Label)GridCalculate.FooterRow.FindControl("lblGrandAmontF");

                Label lblTaxValees1AF = (Label)GridCalculate.FooterRow.FindControl("lblTaxValees1AF");
                Label lblTaxValeesF = (Label)GridCalculate.FooterRow.FindControl("lblTaxValeesF");

                Double SubTotal, TotalAmountTax1, TotalAmountTax2, GrandTotal;

                SubTotal = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text);

                lblSubAmont1F.Text = Convert.ToString(SubTotal);

                TotalAmountTax1 = SubTotal * Convert.ToDouble(lblTaxValeesF.Text) / 100;
                TotalAmountTax2 = SubTotal * Convert.ToDouble(lblTaxValees1AF.Text) / 100;

                txtTax1Rate1F.Text = Convert.ToString(TotalAmountTax1);
                txtTax2Rate1F.Text = Convert.ToString(TotalAmountTax2);
                GrandTotal = SubTotal + TotalAmountTax1 + TotalAmountTax2;

                lblGrandAmontF.Text = Convert.ToString(GrandTotal);
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
                TextBox txtQty = (TextBox)GridCalculate.FooterRow.FindControl("txtQty");
                TextBox txtRate = (TextBox)GridCalculate.FooterRow.FindControl("txtRate");

                DropDownList ddlTax = (DropDownList)GridCalculate.FooterRow.FindControl("ddlTax");
                DropDownList ddlTax1A = (DropDownList)GridCalculate.FooterRow.FindControl("ddlTax1A");
                TextBox txtTax1Rate1F = (TextBox)GridCalculate.FooterRow.FindControl("txtTax1Rate1F");
                TextBox txtTax2Rate1F = (TextBox)GridCalculate.FooterRow.FindControl("txtTax2Rate1F");
                Label lblSubAmont1F = (Label)GridCalculate.FooterRow.FindControl("lblSubAmont1F");
                Label lblGrandAmontF = (Label)GridCalculate.FooterRow.FindControl("lblGrandAmontF");

                Label lblTaxValees1AF = (Label)GridCalculate.FooterRow.FindControl("lblTaxValees1AF");
                Label lblTaxValeesF = (Label)GridCalculate.FooterRow.FindControl("lblTaxValeesF");

                Double SubTotal, TotalAmountTax1, TotalAmountTax2, GrandTotal;

                SubTotal = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text);

                lblSubAmont1F.Text = Convert.ToString(SubTotal);

                TotalAmountTax1 = SubTotal * Convert.ToDouble(lblTaxValeesF.Text) / 100;
                TotalAmountTax2 = SubTotal * Convert.ToDouble(lblTaxValees1AF.Text) / 100;

                txtTax1Rate1F.Text = Convert.ToString(TotalAmountTax1);
                txtTax2Rate1F.Text = Convert.ToString(TotalAmountTax2);
                GrandTotal = SubTotal + TotalAmountTax1 + TotalAmountTax2;

                lblGrandAmontF.Text = Convert.ToString(GrandTotal);
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

        protected void ddlTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtQty = (TextBox)GridCalculate.FooterRow.FindControl("txtQty");
                TextBox txtRate = (TextBox)GridCalculate.FooterRow.FindControl("txtRate");

                DropDownList ddlTax = (DropDownList)GridCalculate.FooterRow.FindControl("ddlTax");//TAX ID,NAME
                DropDownList ddlTax1A = (DropDownList)GridCalculate.FooterRow.FindControl("ddlTax1A");//TAX ID,NAME

                Label lblTaxValeesF = (Label)GridCalculate.FooterRow.FindControl("lblTaxValeesF");//tax1
                Label lblTax1F = (Label)GridCalculate.FooterRow.FindControl("lblTax1F");//tax1

                Label lblTaxValees1AF = (Label)GridCalculate.FooterRow.FindControl("lblTaxValees1AF");//tax2
                Label lblTax1AF = (Label)GridCalculate.FooterRow.FindControl("lblTax1AF");//tax2

                TextBox txtTax1Rate1F = (TextBox)GridCalculate.FooterRow.FindControl("txtTax1Rate1F");
                TextBox txtTax2Rate1F = (TextBox)GridCalculate.FooterRow.FindControl("txtTax2Rate1F");
                Label lblSubAmont1F = (Label)GridCalculate.FooterRow.FindControl("lblSubAmont1F");
                Label lblGrandAmontF = (Label)GridCalculate.FooterRow.FindControl("lblGrandAmontF");

                int TaxID = Convert.ToInt32(ddlTax.SelectedItem.Value);
                lblTax1F.Text = ddlTax.SelectedItem.Text;
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
                        lblTaxValeesF.Text = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        lblTaxValeesF.Text = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                    }
                }


                //int TaxID2 = Convert.ToInt32(ddlTax1A.SelectedItem.Value);
                //lblTax1AF.Text = ddlTax1A.SelectedItem.Text;
                //using (SqlConnection conn = new SqlConnection(strconnect))
                //{
                //    SqlCommand cmd = new SqlCommand("SP_GetTaxRateByID", conn);
                //    cmd.Connection = conn;
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@TaxID", TaxID2);
                //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //    DataTable dt = new DataTable();
                //    sda.Fill(dt);
                //    if (dt.Rows.Count > 0)
                //    {
                //        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                //        lblTaxValees1AF.Text = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                //    }
                //    else
                //    {
                //        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                //        lblTaxValees1AF.Text = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                //    }
                //}


                Double SubTotal, TotalAmountTax1, TotalAmountTax2, GrandTotal;

                SubTotal = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text);

                lblSubAmont1F.Text = Convert.ToString(SubTotal);
                TotalAmountTax1 = SubTotal * Convert.ToDouble(lblTaxValeesF.Text) / 100;
                TotalAmountTax2 = SubTotal * Convert.ToDouble(lblTaxValees1AF.Text) / 100;

                txtTax1Rate1F.Text = Convert.ToString(TotalAmountTax1);
                txtTax2Rate1F.Text = Convert.ToString(TotalAmountTax2);
                GrandTotal = SubTotal + TotalAmountTax1 + TotalAmountTax2;

                lblGrandAmontF.Text = Convert.ToString(GrandTotal);
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

        protected void ddlTax1A_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtQty = (TextBox)GridCalculate.FooterRow.FindControl("txtQty");
                TextBox txtRate = (TextBox)GridCalculate.FooterRow.FindControl("txtRate");

                DropDownList ddlTax = (DropDownList)GridCalculate.FooterRow.FindControl("ddlTax");//TAX ID,NAME
                DropDownList ddlTax1A = (DropDownList)GridCalculate.FooterRow.FindControl("ddlTax1A");//TAX ID,NAME

                Label lblTaxValeesF = (Label)GridCalculate.FooterRow.FindControl("lblTaxValeesF");//tax1
                Label lblTax1F = (Label)GridCalculate.FooterRow.FindControl("lblTax1F");//tax1

                Label lblTaxValees1AF = (Label)GridCalculate.FooterRow.FindControl("lblTaxValees1AF");//tax2
                Label lblTax1AF = (Label)GridCalculate.FooterRow.FindControl("lblTax1AF");//tax2

                TextBox txtTax1Rate1F = (TextBox)GridCalculate.FooterRow.FindControl("txtTax1Rate1F");
                TextBox txtTax2Rate1F = (TextBox)GridCalculate.FooterRow.FindControl("txtTax2Rate1F");
                Label lblSubAmont1F = (Label)GridCalculate.FooterRow.FindControl("lblSubAmont1F");
                Label lblGrandAmontF = (Label)GridCalculate.FooterRow.FindControl("lblGrandAmontF");

                int TaxID2 = Convert.ToInt32(ddlTax1A.SelectedItem.Value);
                lblTax1AF.Text = ddlTax1A.SelectedItem.Text;
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetTaxRateByID", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaxID", TaxID2);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        lblTaxValees1AF.Text = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        lblTaxValees1AF.Text = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                    }
                }

                //int TaxID = Convert.ToInt32(ddlTax.SelectedItem.Value);
                //lblTax1F.Text = ddlTax.SelectedItem.Text;
                //using (SqlConnection conn = new SqlConnection(strconnect))
                //{
                //    SqlCommand cmd = new SqlCommand("SP_GetTaxRateByID", conn);
                //    cmd.Connection = conn;
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@TaxID", TaxID);
                //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //    DataTable dt = new DataTable();
                //    sda.Fill(dt);
                //    if (dt.Rows.Count > 0)
                //    {
                //        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                //        lblTaxValeesF.Text = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                //    }
                //    else
                //    {
                //        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                //        lblTaxValeesF.Text = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                //    }
                //}

                Double SubTotal, TotalAmountTax1, TotalAmountTax2, GrandTotal;

                SubTotal = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text);

                lblSubAmont1F.Text = Convert.ToString(SubTotal);
                TotalAmountTax1 = SubTotal * Convert.ToDouble(lblTaxValeesF.Text) / 100;
                TotalAmountTax2 = SubTotal * Convert.ToDouble(lblTaxValees1AF.Text) / 100;

                txtTax1Rate1F.Text = Convert.ToString(TotalAmountTax1);
                txtTax2Rate1F.Text = Convert.ToString(TotalAmountTax2);
                GrandTotal = SubTotal + TotalAmountTax1 + TotalAmountTax2;

                lblGrandAmontF.Text = Convert.ToString(GrandTotal);
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

        //-----------------------------------------------------------------------
        // Calculate Item Template 
        //-----------------------------------------------------------------------
        protected void txtQty1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var rows = GridCalculate.Rows;
                TextBox btnMessage = sender as TextBox;
                GridViewRow row = (GridViewRow)btnMessage.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                string Quantity = (btnMessage.NamingContainer.FindControl("txtQty1") as TextBox).Text;
                string Rate1 = (btnMessage.NamingContainer.FindControl("txtRate1") as TextBox).Text;
                string ItemID = ((Label)rows[rowindex].FindControl("lblItem1")).Text;

                Label lblDescription1 = GridCalculate.Rows[rowindex].FindControl("lblDescription1") as Label;

                DropDownList ddlTaxCost = GridCalculate.Rows[rowindex].FindControl("ddlTaxCost") as DropDownList;
                Label lblTax1Rate1 = GridCalculate.Rows[rowindex].FindControl("lblTax1Rate1") as Label;
                DropDownList ddlTaxCost1A = GridCalculate.Rows[rowindex].FindControl("ddlTaxCost1A") as DropDownList;
                Label lblTax2Rate1 = GridCalculate.Rows[rowindex].FindControl("lblTax2Rate1") as Label;

                Label lblSubAmont1 = GridCalculate.Rows[rowindex].FindControl("lblSubAmont1") as Label;
                Label lblHSN = (Label)GridCalculate.Rows[rowindex].FindControl("lblHSN1");
                Label lblItemID1 = (Label)GridCalculate.Rows[rowindex].FindControl("lblItemID1");

                //---------------------------------------------------------------//
                Double TaxCost, TaxCost1;
                int TaxID = Convert.ToInt32(ddlTaxCost.SelectedItem.Value);
                string TaxName = ddlTaxCost.SelectedItem.Text;
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
                        TaxCost = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        TaxCost = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                }

                int TaxID2 = Convert.ToInt32(ddlTaxCost1A.SelectedItem.Value);
                string TaxName1 = ddlTaxCost1A.SelectedItem.Text;
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetTaxRateByID", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaxID", TaxID2);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                }


                Double SubTotal, TotalTaxAmount1, TotalTaxAmount2, TotalAmount;

                Double Rate = Convert.ToDouble(Rate1);
                int QRate = Convert.ToInt32(Rate);
                Double QQuantity = Convert.ToDouble(Quantity);

                SubTotal = Rate * QQuantity;//formulla 

                TotalTaxAmount1 = SubTotal * TaxCost / 100;
                TotalTaxAmount2 = SubTotal * TaxCost1 / 100;

                TotalAmount = SubTotal + TotalTaxAmount1 + TotalTaxAmount2;

                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_UpdateEstimateItem", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@EstimateNumber", txtEstimateNumber.Text);
                    com.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedValue);
                    com.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedValue);
                    com.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
                    com.Parameters.AddWithValue("@Amount", TotalAmount);
                    com.Parameters.AddWithValue("@Quantity", QQuantity);
                    com.Parameters.AddWithValue("@Rate", Rate);
                    com.Parameters.AddWithValue("@Subtotal", SubTotal);
                    com.Parameters.AddWithValue("@ItemID", lblItemID1.Text);
                    com.Parameters.AddWithValue("@Item", ItemID);
                    com.Parameters.AddWithValue("@Description", lblDescription1.Text);
                    com.Parameters.AddWithValue("@HSN", lblHSN.Text);
                    com.Parameters.AddWithValue("@Tax1Name", TaxName);
                    com.Parameters.AddWithValue("@Tax1Rate", TaxCost);
                    com.Parameters.AddWithValue("@Tax1Amunt", TotalTaxAmount1);
                    com.Parameters.AddWithValue("@Tax2Name", TaxName1);
                    com.Parameters.AddWithValue("@Tax2Rate", TaxCost1);
                    com.Parameters.AddWithValue("@Tax2Amunt", TotalTaxAmount2);
                    com.Parameters.AddWithValue("@UserID", UserId);
                    com.Parameters.AddWithValue("@Created_by", UserName);
                    com.Parameters.AddWithValue("@Designation", Designation);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    con1.Open();
                    int i = com.ExecuteNonQuery();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Estimate Item Quantity Change Successfully";
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Estimate Item Quantity Not Change Successfully";
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

        protected void txtRate1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var rows = GridCalculate.Rows;
                TextBox btnMessage = sender as TextBox;
                GridViewRow row = (GridViewRow)btnMessage.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                string Quantity = (btnMessage.NamingContainer.FindControl("txtQty1") as TextBox).Text;
                string Rate1 = (btnMessage.NamingContainer.FindControl("txtRate1") as TextBox).Text;
                string ItemID = ((Label)rows[rowindex].FindControl("lblItem1")).Text;

                Label lblDescription1 = GridCalculate.Rows[rowindex].FindControl("lblDescription1") as Label;

                DropDownList ddlTaxCost = GridCalculate.Rows[rowindex].FindControl("ddlTaxCost") as DropDownList;
                Label lblTax1Rate1 = GridCalculate.Rows[rowindex].FindControl("lblTax1Rate1") as Label;
                DropDownList ddlTaxCost1A = GridCalculate.Rows[rowindex].FindControl("ddlTaxCost1A") as DropDownList;
                Label lblTax2Rate1 = GridCalculate.Rows[rowindex].FindControl("lblTax2Rate1") as Label;

                Label lblSubAmont1 = GridCalculate.Rows[rowindex].FindControl("lblSubAmont1") as Label;
                Label lblHSN = (Label)GridCalculate.Rows[rowindex].FindControl("lblHSN1");
                Label lblItemID1 = (Label)GridCalculate.Rows[rowindex].FindControl("lblItemID1");

                //---------------------------------------------------------------//
                Double TaxCost, TaxCost1;
                int TaxID = Convert.ToInt32(ddlTaxCost.SelectedItem.Value);
                string TaxName = ddlTaxCost.SelectedItem.Text;
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
                        TaxCost = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        TaxCost = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                }

                int TaxID2 = Convert.ToInt32(ddlTaxCost1A.SelectedItem.Value);
                string TaxName1 = ddlTaxCost1A.SelectedItem.Text;
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetTaxRateByID", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaxID", TaxID2);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                }


                Double SubTotal, TotalTaxAmount1, TotalTaxAmount2, TotalAmount;

                Double Rate = Convert.ToDouble(Rate1);
                int QRate = Convert.ToInt32(Rate);
                Double QQuantity = Convert.ToDouble(Quantity);

                SubTotal = Rate * QQuantity;//formulla 

                TotalTaxAmount1 = SubTotal * TaxCost / 100;
                TotalTaxAmount2 = SubTotal * TaxCost1 / 100;

                TotalAmount = SubTotal + TotalTaxAmount1 + TotalTaxAmount2;

                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_UpdateEstimateItem", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@EstimateNumber", txtEstimateNumber.Text);
                    com.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedValue);
                    com.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedValue);
                    com.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
                    com.Parameters.AddWithValue("@Amount", TotalAmount);
                    com.Parameters.AddWithValue("@Quantity", QQuantity);
                    com.Parameters.AddWithValue("@Rate", Rate);
                    com.Parameters.AddWithValue("@Subtotal", SubTotal);
                    com.Parameters.AddWithValue("@ItemID", lblItemID1.Text);
                    com.Parameters.AddWithValue("@Item", ItemID);
                    com.Parameters.AddWithValue("@Description", lblDescription1.Text);
                    com.Parameters.AddWithValue("@HSN", lblHSN.Text);
                    com.Parameters.AddWithValue("@Tax1Name", TaxName);
                    com.Parameters.AddWithValue("@Tax1Rate", TaxCost);
                    com.Parameters.AddWithValue("@Tax1Amunt", TotalTaxAmount1);
                    com.Parameters.AddWithValue("@Tax2Name", TaxName1);
                    com.Parameters.AddWithValue("@Tax2Rate", TaxCost1);
                    com.Parameters.AddWithValue("@Tax2Amunt", TotalTaxAmount2);
                    com.Parameters.AddWithValue("@UserID", UserId);
                    com.Parameters.AddWithValue("@Created_by", UserName);
                    com.Parameters.AddWithValue("@Designation", Designation);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    con1.Open();
                    int i = com.ExecuteNonQuery();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Estimate Item Rate Change Successfully";
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Estimate Item Rate Not Change Successfully";
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

        protected void ddlTaxCost_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var rows = GridCalculate.Rows;
                DropDownList btnMessage = sender as DropDownList;
                GridViewRow row = (GridViewRow)btnMessage.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                string Quantity = (btnMessage.NamingContainer.FindControl("txtQty1") as TextBox).Text;
                string Rate1 = (btnMessage.NamingContainer.FindControl("txtRate1") as TextBox).Text;
                string ItemID = ((Label)rows[rowindex].FindControl("lblItem1")).Text;

                Label lblDescription1 = GridCalculate.Rows[rowindex].FindControl("lblDescription1") as Label;

                DropDownList ddlTaxCost = GridCalculate.Rows[rowindex].FindControl("ddlTaxCost") as DropDownList;
                Label lblTax1Rate1 = GridCalculate.Rows[rowindex].FindControl("lblTax1Rate1") as Label;
                DropDownList ddlTaxCost1A = GridCalculate.Rows[rowindex].FindControl("ddlTaxCost1A") as DropDownList;
                Label lblTax2Rate1 = GridCalculate.Rows[rowindex].FindControl("lblTax2Rate1") as Label;

                Label lblSubAmont1 = GridCalculate.Rows[rowindex].FindControl("lblSubAmont1") as Label;
                Label lblHSN = (Label)GridCalculate.Rows[rowindex].FindControl("lblHSN1");
                Label lblItemID1 = (Label)GridCalculate.Rows[rowindex].FindControl("lblItemID1");

                //---------------------------------------------------------------//
                Double TaxCost, TaxCost1;
                int TaxID = Convert.ToInt32(ddlTaxCost.SelectedItem.Value);
                string TaxName = ddlTaxCost.SelectedItem.Text;
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
                        TaxCost = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        TaxCost = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                }

                int TaxID2 = Convert.ToInt32(ddlTaxCost1A.SelectedItem.Value);
                string TaxName1 = ddlTaxCost1A.SelectedItem.Text;
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetTaxRateByID", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaxID", TaxID2);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                }


                Double SubTotal, TotalTaxAmount1, TotalTaxAmount2, TotalAmount;

                Double Rate = Convert.ToDouble(Rate1);
                int QRate = Convert.ToInt32(Rate);
                Double QQuantity = Convert.ToDouble(Quantity);

                SubTotal = Rate * QQuantity;//formulla 

                TotalTaxAmount1 = SubTotal * TaxCost / 100;
                TotalTaxAmount2 = SubTotal * TaxCost1 / 100;

                TotalAmount = SubTotal + TotalTaxAmount1 + TotalTaxAmount2;

                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_UpdateEstimateItem", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@EstimateNumber", txtEstimateNumber.Text);
                    com.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedValue);
                    com.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedValue);
                    com.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
                    com.Parameters.AddWithValue("@Amount", TotalAmount);
                    com.Parameters.AddWithValue("@Quantity", QQuantity);
                    com.Parameters.AddWithValue("@Rate", Rate);
                    com.Parameters.AddWithValue("@Subtotal", SubTotal);
                    com.Parameters.AddWithValue("@ItemID", lblItemID1.Text);
                    com.Parameters.AddWithValue("@Item", ItemID);
                    com.Parameters.AddWithValue("@Description", lblDescription1.Text);
                    com.Parameters.AddWithValue("@HSN", lblHSN.Text);
                    com.Parameters.AddWithValue("@Tax1Name", TaxName);
                    com.Parameters.AddWithValue("@Tax1Rate", TaxCost);
                    com.Parameters.AddWithValue("@Tax1Amunt", TotalTaxAmount1);
                    com.Parameters.AddWithValue("@Tax2Name", TaxName1);
                    com.Parameters.AddWithValue("@Tax2Rate", TaxCost1);
                    com.Parameters.AddWithValue("@Tax2Amunt", TotalTaxAmount2);
                    com.Parameters.AddWithValue("@UserID", UserId);
                    com.Parameters.AddWithValue("@Created_by", UserName);
                    com.Parameters.AddWithValue("@Designation", Designation);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    con1.Open();
                    int i = com.ExecuteNonQuery();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Estimate Item GST1 Change Successfully";
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Estimate Item GST1 Not Change Successfully";
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

        protected void ddlTaxCost1A_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var rows = GridCalculate.Rows;
                DropDownList btnMessage = sender as DropDownList;
                GridViewRow row = (GridViewRow)btnMessage.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                string Quantity = (btnMessage.NamingContainer.FindControl("txtQty1") as TextBox).Text;
                string Rate1 = (btnMessage.NamingContainer.FindControl("txtRate1") as TextBox).Text;
                string ItemID = ((Label)rows[rowindex].FindControl("lblItem1")).Text;

                Label lblDescription1 = GridCalculate.Rows[rowindex].FindControl("lblDescription1") as Label;

                DropDownList ddlTaxCost = GridCalculate.Rows[rowindex].FindControl("ddlTaxCost") as DropDownList;
                Label lblTax1Rate1 = GridCalculate.Rows[rowindex].FindControl("lblTax1Rate1") as Label;
                DropDownList ddlTaxCost1A = GridCalculate.Rows[rowindex].FindControl("ddlTaxCost1A") as DropDownList;
                Label lblTax2Rate1 = GridCalculate.Rows[rowindex].FindControl("lblTax2Rate1") as Label;

                Label lblSubAmont1 = GridCalculate.Rows[rowindex].FindControl("lblSubAmont1") as Label;
                Label lblHSN = (Label)GridCalculate.Rows[rowindex].FindControl("lblHSN1");
                Label lblItemID1 = (Label)GridCalculate.Rows[rowindex].FindControl("lblItemID1");

                //----------------------------------------------------------------------//
                Double TaxCost, TaxCost1;
                int TaxID2 = Convert.ToInt32(ddlTaxCost1A.SelectedItem.Value);
                string TaxName1 = ddlTaxCost1A.SelectedItem.Text;
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetTaxRateByID", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaxID", TaxID2);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                }


                int TaxID = Convert.ToInt32(ddlTaxCost.SelectedItem.Value);
                string TaxName = ddlTaxCost.SelectedItem.Text;
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
                        TaxCost = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dt.Rows[0]["Tax_Rate"]);
                        TaxCost = Convert.ToDouble(dt.Rows[0]["Tax_Rate"]);
                    }
                }


                Double SubTotal, TotalTaxAmount1, TotalTaxAmount2, TotalAmount;

                Double Rate = Convert.ToDouble(Rate1);
                int QRate = Convert.ToInt32(Rate);
                Double QQuantity = Convert.ToDouble(Quantity);

                SubTotal = Rate * QQuantity;//formulla 

                TotalTaxAmount1 = SubTotal * TaxCost / 100;
                TotalTaxAmount2 = SubTotal * TaxCost1 / 100;

                TotalAmount = SubTotal + TotalTaxAmount1 + TotalTaxAmount2;

                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_UpdateEstimateItem", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@EstimateNumber", txtEstimateNumber.Text);
                    com.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedValue);
                    com.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedValue);
                    com.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
                    com.Parameters.AddWithValue("@Amount", TotalAmount);
                    com.Parameters.AddWithValue("@Quantity", QQuantity);
                    com.Parameters.AddWithValue("@Rate", Rate);
                    com.Parameters.AddWithValue("@Subtotal", SubTotal);
                    com.Parameters.AddWithValue("@ItemID", lblItemID1.Text);
                    com.Parameters.AddWithValue("@Item", ItemID);
                    com.Parameters.AddWithValue("@Description", lblDescription1.Text);
                    com.Parameters.AddWithValue("@HSN", lblHSN.Text);
                    com.Parameters.AddWithValue("@Tax1Name", TaxName);
                    com.Parameters.AddWithValue("@Tax1Rate", TaxCost);
                    com.Parameters.AddWithValue("@Tax1Amunt", TotalTaxAmount1);
                    com.Parameters.AddWithValue("@Tax2Name", TaxName1);
                    com.Parameters.AddWithValue("@Tax2Rate", TaxCost1);
                    com.Parameters.AddWithValue("@Tax2Amunt", TotalTaxAmount2);
                    com.Parameters.AddWithValue("@UserID", UserId);
                    com.Parameters.AddWithValue("@Created_by", UserName);
                    com.Parameters.AddWithValue("@Designation", Designation);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    con1.Open();
                    int i = com.ExecuteNonQuery();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Estimate Item GST2 Change Successfully";
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Estimate Item GST2 Not Change Successfully";
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

        protected void txtDiscount1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string DiscountCost = Convert.ToString(ddlDiscountCost.SelectedItem.Text);
                double PerCost;
                SubCostTotalEstimateAmont(); // SubCost Total OF Item
                if (txtDiscount1.Text == "")
                {
                    PerCost = '0';
                }
                else
                {
                    PerCost = Convert.ToDouble(txtDiscount1.Text);
                }
                if (DiscountCost == "%")
                {
                    double SubbTotal = Convert.ToDouble(SubtotalItem1);
                    double Dicountcost;
                    Dicountcost = (SubbTotal * PerCost) / 100;
                    DiscountItem1 = Dicountcost;

                    lblDiscountCost.Text = Convert.ToString("-  " + "₹ " + Dicountcost);

                    string Estimate = txtEstimateNumber.Text;

                    GetItemTax(Estimate); // Sum Total Item Tax      
                    GetTaxlistCalculation(); // Total Cost per of Item price 
                    TotalEstimateCost();//Total Calculation For Estimate 
                }
                else if (DiscountCost == "Fixed Amount")
                {
                    double AmountCost = Convert.ToDouble(txtDiscount1.Text);
                    DiscountItem1 = AmountCost;
                    lblDiscountCost.Text = Convert.ToString("-  " + "₹ " + AmountCost);

                    string Estimate = txtEstimateNumber.Text;

                    GetItemTax(Estimate); // Sum Total Item Tax      
                    GetTaxlistCalculation(); // Total Cost per of Item price 
                    TotalEstimateCost();//Total Calculation For Estimate 
                }
                else
                {
                    DiscountItem1 = 0;

                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Select Discount % or Fixed Amount";
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

        //------------------------------------------------------------//
        // Total Sum Tax Percent of Item
        //------------------------------------------------------------//
        public string GetItemTax(string Estimattteno)
        {
            string Sumtax1;
            SqlConnection conn = new SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand("SP_TaxEstimateItemTotal", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EstimateNumber", Estimattteno);
            cmd.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string prd = Convert.ToString(dt.Rows[0]["TotalTaxItembyInv"]);
                if (prd == "")
                {
                    TaxTotalItem1 = Convert.ToDouble(0.0);
                    Sumtax1 = "0";
                }
                else
                {
                    TaxTotalItem1 = Convert.ToDouble(dt.Rows[0]["TotalTaxItembyInv"]);
                    Sumtax1 = dt.Rows[0]["TotalTaxItembyInv"].ToString();
                }
            }
            else
            {
                TaxTotalItem1 = Convert.ToDouble(0.0);
                Sumtax1 = "0";
            }
            return Sumtax1;
        }

        //------------------------------------------------------------//
        // Total Sum Cost of Item
        //------------------------------------------------------------//
        public void TotalEstimateCost()
        {
            try
            {
                string Estimate = txtEstimateNumber.Text;
                GetItemTax(Estimate);

                //---------------------Discount-------------------------------------------//
                string DiscountCost = Convert.ToString(ddlDiscountCost.SelectedItem.Text);
                string txtDist = Convert.ToString(txtDiscount1.Text);

                if (txtDist == "- 0.00" || txtDist == "")
                {
                    txtDiscount1.Text = "0.0";
                }
                else
                {
                    txtDiscount1.Text = txtDist;
                }

                if (DiscountCost == "%")
                {
                    double PerCost = Convert.ToDouble(txtDiscount1.Text);

                    double SubbTotal = Convert.ToDouble(SubtotalItem1);
                    double Dicountcost;
                    Dicountcost = (SubbTotal * PerCost) / 100;
                    DiscountItem1 = Dicountcost;
                }
                else if (DiscountCost == "Fixed Amount")
                {
                    double AmountCost = Convert.ToDouble(txtDiscount1.Text);
                    DiscountItem1 = AmountCost;
                }
                else
                {
                    DiscountItem1 = 0.0;
                }

                //---------------------Adjustment-------------------------------------------//

                string ADJ;
                if (TxtAdjustment1.Text == "")
                {
                    ADJ = "0";
                }
                else
                {
                    ADJ = TxtAdjustment1.Text;
                }

                if (ADJ == "0")
                {
                    Adjustment1 = Convert.ToDouble(0);
                }
                else
                {
                    double adjvalue = Convert.ToDouble(ADJ);
                    double Roundup1 = Math.Round(adjvalue);
                    Adjustment1 = Convert.ToDouble(Roundup1);
                }

                Double EstimateTOTALAMONT1 = (SubtotalItem1 - DiscountItem1);

                Double TaxEstimateAMOUNT = (EstimateTOTALAMONT1 * TaxTotalItem1) / 100;

                GetTaxlistCalculation();

                lbltotaltaxPer.Text = Convert.ToString("% " + TaxTotalItem1);
                lbltotalcosttax.Text = Convert.ToString("₹ " + TaxEstimateAMOUNT);

                EastimateTOTALAMONT = EstimateTOTALAMONT1 + TaxEstimateAMOUNT + Adjustment1;

                if (EastimateTOTALAMONT == 0)
                {
                    lbltotalAmonutInvoiceCost.Text = Convert.ToString("₹ " + "0.00");
                    TotalEstimateAmont = '0';
                    lblAmont30.Text = "0";
                }
                else
                {
                    lbltotalAmonutInvoiceCost.Text = Convert.ToString("₹ " + EastimateTOTALAMONT);
                    TotalEstimateAmont = Convert.ToDecimal(EastimateTOTALAMONT);
                    TotalEstimateAmont = Math.Round(TotalEstimateAmont);
                    lblAmont30.Text = Convert.ToString(TotalEstimateAmont);
                    lbltotalAmonutInvoiceCost.Text = Convert.ToString("₹ " + TotalEstimateAmont);
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

        //------------------------------------------------------------//
        //  SubCost of Item
        //------------------------------------------------------------//
        public void SubCostTotalEstimateAmont()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_TotalCostEstimateItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EstimateNumber", txtEstimateNumber.Text);
                cmd.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string prd = Convert.ToString(dt.Rows[0]["TotalItemCost"]);
                    if (prd == "")
                    {
                        SubtotalItem1 = Convert.ToDouble(0);
                        lblSubTotalCost.Text = Convert.ToString("₹ ") + "0.0";
                    }
                    else
                    {
                        SubtotalItem1 = Convert.ToDouble(dt.Rows[0]["TotalItemCost"]);
                        lblSubTotalCost.Text = Convert.ToString("₹ ") + dt.Rows[0]["TotalItemCost"].ToString();
                    }
                }
                else
                {
                    SubtotalItem1 = Convert.ToDouble(0);
                    lblSubTotalCost.Text = Convert.ToString("₹ ") + "0.0";
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

        //------------------------------------------------------------//
        //  Taxlist Display  of Item calculation
        //------------------------------------------------------------//
        public void GetTaxlistCalculation()
        {
            try
            {
                listTaxNames1.Visible = true;
                listTaxValues1.Visible = true;
                using (SqlConnection conn2 = new SqlConnection(strconnect))
                {
                    double SubbTotal = Convert.ToDouble(SubtotalItem1);
                    double Discount = Convert.ToDouble(DiscountItem1);
                    string Taxname, Taxper, TaxAmountCost;
                    SqlCommand cmd2 = new SqlCommand("SP_TaxEstimateItem", conn2);
                    cmd2.Connection = conn2;
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@EstimateNumber", txtEstimateNumber.Text);
                    cmd2.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                    cmd2.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                    cmd2.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
                    using (SqlDataAdapter sda2 = new SqlDataAdapter(cmd2))
                    {
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            listTaxNames1.DataSource = dt2;
                            listTaxNames1.DataTextField = "TaxName";
                            listTaxNames1.DataValueField = "TaxRate";
                            listTaxNames1.DataBind();

                            DataTable Taxdt = new DataTable();
                            Taxdt.Columns.Add("TaxValesPer");
                            Double TaxAmount;
                            int TotalTaxCount, TaXcount, TaXcount2;
                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                Double TaxAmountPER = Convert.ToDouble(dt2.Rows[i]["TaxRate"]);
                                Taxname = Convert.ToString(dt2.Rows[i]["TaxName"]);
                                Taxper = Convert.ToString(dt2.Rows[i]["TaxRate"]);

                                using (SqlConnection contax = new SqlConnection(strconnect))
                                {
                                    SqlCommand cmdtax = new SqlCommand("SP_GetCountTaxNameEstimate", contax);
                                    cmdtax.Connection = contax;
                                    cmdtax.CommandType = CommandType.StoredProcedure;
                                    cmdtax.Parameters.AddWithValue("@EstimateNumber", txtEstimateNumber.Text);
                                    cmdtax.Parameters.AddWithValue("@TaxName", Taxname);
                                    cmdtax.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                                    cmdtax.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                                    cmdtax.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
                                    SqlDataAdapter sdatax = new SqlDataAdapter(cmdtax);
                                    DataTable dttax = new DataTable();
                                    sdatax.Fill(dttax);
                                    if (dttax.Rows.Count > 0)
                                    {
                                        TaXcount = Convert.ToInt32(dttax.Rows[0]["TAXCountByName"]);
                                        TAXCount.Text = Convert.ToString(dttax.Rows[0]["TAXCountByName"]);
                                    }
                                    else
                                    {
                                        TaXcount = Convert.ToInt32(dttax.Rows[0]["TAXCountByName"]);
                                        TAXCount.Text = Convert.ToString(dttax.Rows[0]["TAXCountByName"]);
                                    }
                                }

                                using (SqlConnection contax2 = new SqlConnection(strconnect))
                                {
                                    SqlCommand cmdtax2 = new SqlCommand("SP_GetCountTaxName2Estimate", contax2);
                                    cmdtax2.Connection = contax2;
                                    cmdtax2.CommandType = CommandType.StoredProcedure;
                                    cmdtax2.Parameters.AddWithValue("@EstimateNumber", txtEstimateNumber.Text);
                                    cmdtax2.Parameters.AddWithValue("@TaxName", Taxname);
                                    cmdtax2.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                                    cmdtax2.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                                    cmdtax2.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
                                    SqlDataAdapter sdatax2 = new SqlDataAdapter(cmdtax2);
                                    DataTable dttax2 = new DataTable();
                                    sdatax2.Fill(dttax2);
                                    if (dttax2.Rows.Count > 0)
                                    {
                                        TaXcount2 = Convert.ToInt32(dttax2.Rows[0]["TAXCountByName"]);
                                        TAXCount2.Text = Convert.ToString(dttax2.Rows[0]["TAXCountByName"]);
                                    }
                                    else
                                    {
                                        TaXcount2 = Convert.ToInt32(dttax2.Rows[0]["TAXCountByName"]);
                                        TAXCount2.Text = Convert.ToString(dttax2.Rows[0]["TAXCountByName"]);
                                    }
                                }

                                TotalTaxCount = TaXcount2 + TaXcount;


                                Double INVOICETOTALAMONT1 = (SubtotalItem1 - Discount);

                                string invTotal = Convert.ToString(INVOICETOTALAMONT1);
                                string SubInv = Convert.ToString(SubtotalItem1);
                                string DicInv = Convert.ToString(Discount);
                                Double TaxPERCount = TaxAmountPER * TotalTaxCount;
                                Double TaxAmount1 = (INVOICETOTALAMONT1 * TaxPERCount) / 100;

                                decimal TaxAmount11 = Convert.ToDecimal(TaxAmount1);
                                decimal totalTaxAmount11 = decimal.Round(TaxAmount11, 2);
                                TaxAmount1 = Convert.ToDouble(totalTaxAmount11);

                                TaxAmount = TaxAmount1;
                                TaxAmountCost = Convert.ToString(TaxAmount);

                                DataRow newRow = Taxdt.NewRow();
                                newRow["TaxValesPer"] = TaxAmountCost;
                                Taxdt.Rows.Add(newRow);
                            }

                            listTaxValues1.DataSource = Taxdt;
                            listTaxValues1.DataTextField = "TaxValesPer";
                            listTaxValues1.DataValueField = "TaxValesPer";
                            listTaxValues1.DataBind();
                            Taxdt.Clear();
                        }
                        else
                        {
                            DataTable dtnull = new DataTable();
                            listTaxNames1.DataSource = dtnull;
                            listTaxNames1.DataTextField = "TaxName";
                            listTaxNames1.DataValueField = "TaxRate";
                            listTaxNames1.DataBind();

                            DataTable Taxdt = new DataTable();
                            Taxdt.Columns.Add("TaxValesPer");
                            Double TaxAmount;
                            int TotalTaxCount, TaXcount, TaXcount2;
                            for (int i = 0; i < dtnull.Rows.Count; i++)
                            {
                                Double TaxAmountPER = Convert.ToDouble(dt2.Rows[i]["TaxRate"]);
                                Taxname = Convert.ToString(dt2.Rows[i]["TaxName"]);
                                Taxper = Convert.ToString(dt2.Rows[i]["TaxRate"]);

                                using (SqlConnection contax = new SqlConnection(strconnect))
                                {
                                    SqlCommand cmdtax = new SqlCommand("SP_GetCountTaxNameEstimate", contax);
                                    cmdtax.Connection = contax;
                                    cmdtax.CommandType = CommandType.StoredProcedure;
                                    cmdtax.Parameters.AddWithValue("@EstimateNumber", txtEstimateNumber.Text);
                                    cmdtax.Parameters.AddWithValue("@TaxName", Taxname);
                                    cmdtax.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                                    cmdtax.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                                    cmdtax.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
                                    SqlDataAdapter sdatax = new SqlDataAdapter(cmdtax);
                                    DataTable dttax = new DataTable();
                                    sdatax.Fill(dttax);
                                    if (dttax.Rows.Count > 0)
                                    {
                                        TaXcount = Convert.ToInt32(dttax.Rows[0]["TAXCountByName"]);
                                        TAXCount.Text = Convert.ToString(dttax.Rows[0]["TAXCountByName"]);
                                    }
                                    else
                                    {
                                        TaXcount = Convert.ToInt32(dttax.Rows[0]["TAXCountByName"]);
                                        TAXCount.Text = Convert.ToString(dttax.Rows[0]["TAXCountByName"]);
                                    }
                                }

                                using (SqlConnection contax2 = new SqlConnection(strconnect))
                                {
                                    SqlCommand cmdtax2 = new SqlCommand("SP_GetCountTaxName2Estimate", contax2);
                                    cmdtax2.Connection = contax2;
                                    cmdtax2.CommandType = CommandType.StoredProcedure;
                                    cmdtax2.Parameters.AddWithValue("@EstimateNumber", txtEstimateNumber.Text);
                                    cmdtax2.Parameters.AddWithValue("@TaxName", Taxname);
                                    cmdtax2.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                                    cmdtax2.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                                    cmdtax2.Parameters.AddWithValue("@Saleagent", ddlSalesAgent.SelectedItem.Value);
                                    SqlDataAdapter sdatax2 = new SqlDataAdapter(cmdtax2);
                                    DataTable dttax2 = new DataTable();
                                    sdatax2.Fill(dttax2);
                                    if (dttax2.Rows.Count > 0)
                                    {
                                        TaXcount2 = Convert.ToInt32(dttax2.Rows[0]["TAXCountByName"]);
                                        TAXCount2.Text = Convert.ToString(dttax2.Rows[0]["TAXCountByName"]);
                                    }
                                    else
                                    {
                                        TaXcount2 = Convert.ToInt32(dttax2.Rows[0]["TAXCountByName"]);
                                        TAXCount2.Text = Convert.ToString(dttax2.Rows[0]["TAXCountByName"]);
                                    }
                                }

                                TotalTaxCount = TaXcount2 + TaXcount;


                                Double INVOICETOTALAMONT1 = (SubtotalItem1 - Discount);

                                string invTotal = Convert.ToString(INVOICETOTALAMONT1);
                                string SubInv = Convert.ToString(SubtotalItem1);
                                string DicInv = Convert.ToString(Discount);
                                Double TaxPERCount = TaxAmountPER * TotalTaxCount;
                                Double TaxAmount1 = (INVOICETOTALAMONT1 * TaxPERCount) / 100;

                                decimal TaxAmount11 = Convert.ToDecimal(TaxAmount1);
                                decimal totalTaxAmount11 = decimal.Round(TaxAmount11, 2);
                                TaxAmount1 = Convert.ToDouble(totalTaxAmount11);

                                TaxAmount = TaxAmount1;
                                TaxAmountCost = Convert.ToString(TaxAmount);

                                DataRow newRow = Taxdt.NewRow();
                                newRow["TaxValesPer"] = TaxAmountCost;
                                Taxdt.Rows.Add(newRow);
                            }

                            listTaxValues1.DataSource = Taxdt;
                            listTaxValues1.DataTextField = "TaxValesPer";
                            listTaxValues1.DataValueField = "TaxValesPer";
                            listTaxValues1.DataBind();
                            Taxdt.Clear();
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

        protected void TxtAdjustment1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtAdjustment1.Text == "")
                {
                    lblAdjustmentCost.Text = Convert.ToString("₹ " + "0");
                }
                else
                {
                    double Adjustmentvalue = Convert.ToDouble(TxtAdjustment1.Text);
                    double roundupvalue = Math.Round(Adjustmentvalue);
                    lblAdjustmentCost.Text = Convert.ToString("₹ " + roundupvalue);                   
                    Adjustment1 = Convert.ToDouble(roundupvalue);

                    //lblAdjustmentCost.Text = Convert.ToString("₹ " + TxtAdjustment1.Text);

                    //Adjustment1 = Convert.ToDouble(TxtAdjustment1.Text);
                }


                string Estimate = txtEstimateNumber.Text;
                GetItemTax(Estimate); // Sum Total Item Tax
                SubCostTotalEstimateAmont(); // SubCost Total OF Item
                GetTaxlistCalculation(); // Total Cost per of Item price 
                TotalEstimateCost();//Total Calculation For Estimate 
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

        protected void ddlDiscountCost_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string DiscountCost = Convert.ToString(ddlDiscountCost.SelectedItem.Text);

                if (DiscountCost == "%")
                {
                    string Cost = "0.0";
                    lblDiscountCost.Text = Convert.ToString("-" + "₹ " + Cost);
                    txtDiscount1.Text = "0.0";
                }
                else if (DiscountCost == "Fixed Amount")
                {
                    string Cost = "0.0";
                    lblDiscountCost.Text = Convert.ToString("-" + "₹ " + Cost);
                    txtDiscount1.Text = "0.0";
                }
                else
                {
                    msgdiv.Visible = true;
                    lblMsg1.Visible = true;
                    lblMsg1.Text = "Select Discount % or Fixed Amount";
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

        protected void btnConvertDraft_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);  // db connect
                SqlCommand cmd = new SqlCommand("SP_ConvertToSaveEstimate", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SaveAS", lblSAveAS.Text);
                cmd.Parameters.AddWithValue("@EstimateID", lblEstimateID.Text);
                cmd.Parameters.AddWithValue("@Created_by", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Estimate Details Save Successfully";
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Estimate Details Not Save Successfully";
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