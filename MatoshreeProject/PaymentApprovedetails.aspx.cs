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
#endregion

namespace MatoshreeProject
{
    public partial class PaymentApprovedetails : System.Web.UI.Page
    {
        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr, dr1, dr2;
        int Result, Result1, Result2;
        string billchk, file1, Status, fileName, ChkboxcreateInvoce, ChkBoxcustomeremail, TotalAmount;
        string result, MID, ApprovalStatus;

        int UserId, SendEmpID;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;

        String SendDesignation, SendBy;

        #endregion

        #region " Constructor "


        #endregion

        #region " Private Variables "

        int Id;
        private object lblAccept;


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

        public void Clear()
        {
            foreach (GridViewRow row in GridViewOffice.Rows)
            {
                TextBox txtReason = (TextBox)row.FindControl("txtReason");

                txtReason.Text = string.Empty;

            }
        }
        public void Clear1()
        {
            txt_LongDescription.Text = string.Empty;
            txt_Description.Text = string.Empty;
            txt_Rate.Text = string.Empty;
            txtHSNCode.Text = string.Empty;
            ddlTaxitem.SelectedIndex = 0;
            ddlTaxItem1.SelectedIndex = 0;
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
        public void GetRelatedToRefrenceDetailsByID()
        {
            try
            {
                MID = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                lblRefPRimary.Text = MID;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetBelongToRefrenceDetailsByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", lblRefPRimary.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        lblRelatedTo1.Text = dt.Rows[0]["RelatedTo"].ToString();
                        lblRefID.Text = dt.Rows[0]["ReferenceID"].ToString();
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

        public void GetAllExpensesDetailsByIDAndBelongTO()
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetALLExpensesDetailsByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ReferenceID", lblRefID.Text);
                    cmd.Parameters.AddWithValue("@RelatedTo", lblRelatedTo1.Text);
                    cmd.Parameters.AddWithValue("@ID", lblRefPRimary.Text);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        string category;
                        string subcategory;
                        string Project;
                        string Customer1;
                        string staff;
                        string cust;

                        if (lblRelatedTo1.Text == "Payment Request")
                        {

                            lblExpName.Text = dt.Rows[0]["Exp_Name"].ToString();
                            lblExp_Type1.Text = dt.Rows[0]["Exp_Type"].ToString();
                            lblExpDate1.Text = DateTime.Parse(dt.Rows[0]["Exp_Date"].ToString()).ToString("yyyy-MM-dd");
                            lblBillno1.Text = dt.Rows[0]["BillNo"].ToString();
                            lblCurrency1.Text = dt.Rows[0]["Exp_Currency"].ToString();
                            lblPayementMode1.Text = dt.Rows[0]["Exp_Payment"].ToString();
                            lblRelatedTo1.Text = dt.Rows[0]["RelatedTo"].ToString();
                            lblAmount111.Text = dt.Rows[0]["Exp_Amount"].ToString();
                            lblexpid2.Text = dt.Rows[0]["Exp_id"].ToString();
                            category = dt.Rows[0]["Exp_Category"].ToString();
                            lblprojectId.Text = dt.Rows[0]["project_Id"].ToString();

                            if (category == "")
                            {
                                lblCategory.Visible = false;
                                lblCategory1.Visible = false;
                            }
                            else
                            {
                                lblCategory.Visible = true;
                                lblCategory1.Visible = true;
                            }
                            lblCategory1.Text = dt.Rows[0]["Exp_Category"].ToString();

                            subcategory = dt.Rows[0]["Exp_SubCategory"].ToString();


                            if (subcategory == "")
                            {
                                lblSub_Category.Visible = false;
                                lblSub_Category1.Visible = false;
                            }
                            else
                            {
                                lblSub_Category.Visible = true;
                                lblSub_Category1.Visible = true;
                            }
                            lblSub_Category1.Text = dt.Rows[0]["Exp_SubCategory"].ToString();

                            Customer1 = dt.Rows[0]["Cust_Name"].ToString();
                            if (Customer1 == "")
                            {
                                lblCustomer.Visible = false;
                                lblCustomer1.Visible = false;
                            }
                            else
                            {
                                lblCustomer.Visible = true;
                                lblCustomer1.Visible = true;
                            }
                            lblCustomer1.Text = dt.Rows[0]["Cust_Name"].ToString();

                            Project = dt.Rows[0]["ProjectName"].ToString();
                            if (Project == "")
                            {
                                lblProject.Visible = false;
                                lblProject1.Visible = false;
                            }
                            else
                            {
                                lblProject.Visible = true;
                                lblProject1.Visible = true;
                            }
                            lblProject1.Text = dt.Rows[0]["ProjectName"].ToString();

                        }
                        else if (lblRelatedTo1.Text == "Office Expenses")
                        {
                            lblExpName.Text = dt.Rows[0]["Exp_Name"].ToString();
                            lblExp_Type1.Text = dt.Rows[0]["Exp_Type"].ToString();
                            lblExpDate1.Text = DateTime.Parse(dt.Rows[0]["Exp_Date"].ToString()).ToString("yyyy-MM-dd");
                            lblBillno1.Text = dt.Rows[0]["BillNo"].ToString();
                            lblCurrency1.Text = dt.Rows[0]["Exp_Currency"].ToString();
                            lblPayementMode1.Text = dt.Rows[0]["Exp_Payment"].ToString();
                            lblRelatedTo1.Text = dt.Rows[0]["RelatedTo"].ToString();
                            lblAmount111.Text = dt.Rows[0]["Exp_Amount"].ToString();
                            lblexpid2.Text = dt.Rows[0]["Exp_id"].ToString();
                            category = dt.Rows[0]["Exp_Category"].ToString();
                            if (category == "")
                            {
                                lblCategory.Visible = false;
                                lblCategory1.Visible = false;
                            }
                            else
                            {
                                lblCategory.Visible = true;
                                lblCategory1.Visible = true;
                            }
                            lblCategory1.Text = dt.Rows[0]["Exp_Category"].ToString();
                            subcategory = dt.Rows[0]["Exp_SubCategory"].ToString();


                            if (subcategory == "")
                            {
                                lblSub_Category.Visible = false;
                                lblSub_Category1.Visible = false;
                            }
                            else
                            {
                                lblSub_Category.Visible = true;
                                lblSub_Category1.Visible = true;
                            }
                            lblSub_Category1.Text = dt.Rows[0]["Exp_SubCategory"].ToString();
                        }
                        else if (lblRelatedTo1.Text == "Staff Expenses")
                        {
                            lblExpName.Text = dt.Rows[0]["Exp_Name"].ToString();
                            lblExp_Type1.Text = dt.Rows[0]["Exp_Type"].ToString();
                            lblExpDate1.Text = DateTime.Parse(dt.Rows[0]["Exp_Date"].ToString()).ToString("yyyy-MM-dd");
                            lblBillno1.Text = dt.Rows[0]["BillNo"].ToString();
                            lblCurrency1.Text = dt.Rows[0]["Exp_Currency"].ToString();
                            lblPayementMode1.Text = dt.Rows[0]["Exp_Payment"].ToString();
                            lblRelatedTo1.Text = dt.Rows[0]["RelatedTo"].ToString();
                            lblAmount111.Text = dt.Rows[0]["Exp_Amount"].ToString();
                            lblexpid2.Text = dt.Rows[0]["Exp_id"].ToString();
                            lblstaffid.Text = dt.Rows[0]["Exp_StaffID"].ToString();

                            staff = dt.Rows[0]["First_Name"].ToString();


                            if (staff == "")
                            {
                                lblStaff.Visible = false;
                                lblStaff1.Visible = false;
                            }
                            else
                            {
                                lblStaff.Visible = true;
                                lblStaff1.Visible = true;
                            }
                            lblStaff1.Text = dt.Rows[0]["First_Name"].ToString();
                        }
                        else if (lblRelatedTo1.Text == "Project Purchase")
                        {
                            lblExpName.Text = dt.Rows[0]["Exp_Name"].ToString();
                            lblExp_Type1.Text = dt.Rows[0]["Exp_Type"].ToString();
                            lblExpDate1.Text = DateTime.Parse(dt.Rows[0]["Exp_Date"].ToString()).ToString("yyyy-MM-dd");
                            lblBillno1.Text = dt.Rows[0]["BillNo"].ToString();
                            lblCurrency1.Text = dt.Rows[0]["Exp_Currency"].ToString();
                            lblPayementMode1.Text = dt.Rows[0]["Exp_Payment"].ToString();
                            lblRelatedTo1.Text = dt.Rows[0]["RelatedTo"].ToString();
                            lblAmount111.Text = dt.Rows[0]["Exp_Amount"].ToString();
                            lblprojectId.Text = dt.Rows[0]["project_Id"].ToString();
                            lblexpid2.Text = dt.Rows[0]["Exp_id"].ToString();
                            Customer1 = dt.Rows[0]["Cust_Name"].ToString();
                            if (Customer1 == "")
                            {
                                lblCustomer.Visible = false;
                                lblCustomer1.Visible = false;
                            }
                            else
                            {
                                lblCustomer.Visible = true;
                                lblCustomer1.Visible = true;
                            }
                            lblCustomer1.Text = dt.Rows[0]["Cust_Name"].ToString();
                            Project = dt.Rows[0]["ProjectName"].ToString();
                            if (Project == "")
                            {
                                lblProject.Visible = false;
                                lblProject1.Visible = false;
                            }
                            else
                            {
                                lblProject.Visible = true;
                                lblProject1.Visible = true;
                            }
                            lblProject1.Text = dt.Rows[0]["ProjectName"].ToString();

                        }
                        else { }
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


        public void GetTotalAmount()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetTotalAmountALLBillItemExpensess", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1000;
                cmd.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);


                if (lblRelatedTo1.Text == "Payment Request")
                {
                    cmd.Parameters.AddWithValue("@PayReqID", lblexpid2.Text);

                }
                else if (lblRelatedTo1.Text == "Office Expenses")
                {
                    cmd.Parameters.AddWithValue("@OfiiceExpID", lblexpid2.Text);


                }
                else if (lblRelatedTo1.Text == "Staff Expenses")
                {
                    cmd.Parameters.AddWithValue("@StaffExpID", lblexpid2.Text);

                }
                else

                {
                    cmd.Parameters.AddWithValue("@ProjePurID", lblexpid2.Text);

                }



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
        public void GetTotalApprovalAmount()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetTotalAmountPaymentApprovalItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1000;
                cmd.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);


                if (lblRelatedTo1.Text == "Payment Request")
                {
                    cmd.Parameters.AddWithValue("@PayReqID", lblexpid2.Text);

                }
                else if (lblRelatedTo1.Text == "Office Expenses")
                {
                    cmd.Parameters.AddWithValue("@OfiiceExpID", lblexpid2.Text);


                }
                else if (lblRelatedTo1.Text == "Staff Expenses")
                {
                    cmd.Parameters.AddWithValue("@StaffExpID", lblexpid2.Text);

                }
                else

                {
                    cmd.Parameters.AddWithValue("@ProjePurID", lblexpid2.Text);

                }



                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    lblSubTotalCost1.Text = "₹ " + dt.Rows[0]["ApprovalAmount"].ToString();
                }
                else
                {

                    lblSubTotalCost1.Text = "₹ " + "0";
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

        public void UpdateTotalApprovalAmount()
        {
            try
            {
                UserCon = new SqlConnection(strconnect);
                UserCommand = new SqlCommand("SP_UpdateTotalAmountPaymentApproval", UserCon);
                UserCommand.Connection = UserCon;
                UserCommand.CommandType = CommandType.StoredProcedure;

                UserCommand.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                UserCommand.Parameters.AddWithValue("@BillNo", lblBillno1.Text);
                UserCommand.Parameters.AddWithValue("@TotalExp_Amount", lblSubTotalCost1.Text);
                UserCommand.Parameters.AddWithValue("@ApprovalBy", UserName);
                UserCommand.Parameters.AddWithValue("@Designation", Designation);
                UserCommand.Parameters.AddWithValue("@ApprovalEmpID", UserId);

                UserCon.Open();
                int Result = UserCommand.ExecuteNonQuery();

                if (Result < 0)
                {
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Approval Amount Updated Successfully!')", true);

                }
                else
                {
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Approval Amount Not Updated Successfully!')", true);
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

        public void Calculatefilldata()
        {
            try
            {

                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_GetBillOfficeExpenses", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                    com.Parameters.AddWithValue("@BillNo", lblBillno1.Text);
                    com.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);

                    if (lblRelatedTo1.Text == "Payment Request")
                    {
                        com.Parameters.AddWithValue("@OfiiceExpID", "0");
                        com.Parameters.AddWithValue("@StaffExpID", "0");
                        com.Parameters.AddWithValue("@ProjePurID", "0");
                        com.Parameters.AddWithValue("@PayRequestID", lblexpid2.Text);
                        com.Parameters.AddWithValue("@Exp_id", "0");
                    }
                    else if (lblRelatedTo1.Text == "Office Expenses")
                    {
                        com.Parameters.AddWithValue("@OfiiceExpID", lblexpid2.Text);
                        com.Parameters.AddWithValue("@StaffExpID", "0");
                        com.Parameters.AddWithValue("@ProjePurID", "0");
                        com.Parameters.AddWithValue("@PayRequestID", "0");
                        com.Parameters.AddWithValue("@Exp_id", "0");
                    }
                    else if (lblRelatedTo1.Text == "Staff Expenses")
                    {
                        com.Parameters.AddWithValue("@OfiiceExpID", "0");
                        com.Parameters.AddWithValue("@StaffExpID", lblexpid2.Text);
                        com.Parameters.AddWithValue("@ProjePurID", "0");
                        com.Parameters.AddWithValue("@PayRequestID", "0");
                        com.Parameters.AddWithValue("@Exp_id", "0");
                    }
                    else

                    {
                        com.Parameters.AddWithValue("@OfiiceExpID", "0");
                        com.Parameters.AddWithValue("@StaffExpID", "0");
                        com.Parameters.AddWithValue("@ProjePurID", lblexpid2.Text);
                        com.Parameters.AddWithValue("@PayRequestID", "0");
                        com.Parameters.AddWithValue("@Exp_id", "0");
                    }
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

        public void Calculatefilldata1()
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_GetPaymentApprovalItemList", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                    com.Parameters.AddWithValue("@BillNo", lblBillno1.Text);
                    com.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);

                    if (lblRelatedTo1.Text == "Payment Request")
                    {
                        com.Parameters.AddWithValue("@OfiiceExpID", "0");
                        com.Parameters.AddWithValue("@StaffExpID", "0");
                        com.Parameters.AddWithValue("@ProjePurID", "0");
                        com.Parameters.AddWithValue("@PayRequestID", lblexpid2.Text);
                        com.Parameters.AddWithValue("@Exp_id", "0");

                    }
                    else if (lblRelatedTo1.Text == "Office Expenses")
                    {
                        com.Parameters.AddWithValue("@OfiiceExpID", lblexpid2.Text);
                        com.Parameters.AddWithValue("@StaffExpID", "0");
                        com.Parameters.AddWithValue("@ProjePurID", "0");
                        com.Parameters.AddWithValue("@PayRequestID", "0");
                        com.Parameters.AddWithValue("@Exp_id", "0");


                    }
                    else if (lblRelatedTo1.Text == "Staff Expenses")
                    {
                        com.Parameters.AddWithValue("@OfiiceExpID", "0");
                        com.Parameters.AddWithValue("@StaffExpID", lblexpid2.Text);
                        com.Parameters.AddWithValue("@ProjePurID", "0");
                        com.Parameters.AddWithValue("@PayRequestID", "0");
                        com.Parameters.AddWithValue("@Exp_id", "0");

                    }
                    else

                    {
                        com.Parameters.AddWithValue("@OfiiceExpID", "0");
                        com.Parameters.AddWithValue("@StaffExpID", "0");
                        com.Parameters.AddWithValue("@ProjePurID", lblexpid2.Text);
                        com.Parameters.AddWithValue("@PayRequestID", "0");
                        com.Parameters.AddWithValue("@Exp_id", "0");

                    }
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        GridApprovalItem.DataSource = dt;
                        GridApprovalItem.DataBind();

                    }

                    GetTotalApprovalAmount();


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

        #region " Event "
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
                            bindItem();
                            bindTax();
                            GetRelatedToRefrenceDetailsByID();
                            GetAllExpensesDetailsByIDAndBelongTO();
                            Calculatefilldata();
                            ViewFileExpensesDetails();
                            Calculatefilldata1();
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
                                bindItem();
                                bindTax();
                                GetRelatedToRefrenceDetailsByID();
                                GetAllExpensesDetailsByIDAndBelongTO();
                                Calculatefilldata();
                                ViewFileExpensesDetails();
                                Calculatefilldata1();
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
        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void ddlExpensesCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //---------------------------------------------------------------------------------------------//
        // Expenses Item 
        //---------------------------------------------------------------------------------------------//
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
                    com.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                    com.Parameters.AddWithValue("@ID", ItemID);
                    com.Parameters.AddWithValue("@CreatedBy", UserName);

                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    con1.Open();
                    int i = com.ExecuteNonQuery();

                    if (i < 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Payment Approval Item Remove Successfully!')", true);
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Payment Approval Item Not Remove Available!')", true);
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

        protected void btnAddPaymentApprovalItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblExpName.Text == "" || lblBillno1.Text == "")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Enter Expenses Name AND Enter  Bill Number!')", true);
                }
                else
                {
                    TextBox txtItem = (TextBox)GridViewOffice.FooterRow.FindControl("txtItem");
                    TextBox txtDescription = (TextBox)GridViewOffice.FooterRow.FindControl("txtDescription");

                    TextBox txtQty = (TextBox)GridViewOffice.FooterRow.FindControl("txtQty");
                    TextBox txtRate = (TextBox)GridViewOffice.FooterRow.FindControl("txtRate");

                    float Rate = (float)Convert.ToDouble(txtRate.Text);
                    int Quantity = Convert.ToInt32(txtQty.Text);
                    float Amount = Rate * Quantity;
                    string TotalAmount = Convert.ToString(Amount);



                    using (SqlConnection con = new SqlConnection(strconnect))
                    {

                        SqlCommand cmd = new SqlCommand("SP_SaveBILLOfficeExpenses", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                        //cmd.Parameters.AddWithValue("@Exp_Category", ddlExpensesCategory.SelectedItem.Text);
                        //cmd.Parameters.AddWithValue("@Exp_SubCategory", ddlSubCategory.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Amount", TotalAmount);
                        cmd.Parameters.AddWithValue("@BillNo", lblBillno1.Text);
                        // cmd.Parameters.AddWithValue("@Exp_id", "0");
                        cmd.Parameters.AddWithValue("@Item", txtItem.Text);
                        cmd.Parameters.AddWithValue("@Quantity", txtQty.Text);
                        cmd.Parameters.AddWithValue("@Rate", txtRate.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@CreatedBy", UserName);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);

                        if (lblRelatedTo1.Text == "Payment Request")
                        {
                            cmd.Parameters.AddWithValue("@OfiiceExpID", "0");
                            cmd.Parameters.AddWithValue("@StaffExpID", "0");
                            cmd.Parameters.AddWithValue("@ProjePurID", "0");
                            cmd.Parameters.AddWithValue("@PayRequestID", lblexpid2.Text);

                        }
                        else if (lblRelatedTo1.Text == "Office Expenses")
                        {
                            cmd.Parameters.AddWithValue("@OfiiceExpID", lblexpid2.Text);
                            cmd.Parameters.AddWithValue("@StaffExpID", "0");
                            cmd.Parameters.AddWithValue("@ProjePurID", "0");
                            cmd.Parameters.AddWithValue("@PayRequestID", "0");


                        }
                        else if (lblRelatedTo1.Text == "Staff Expenses")
                        {
                            cmd.Parameters.AddWithValue("@OfiiceExpID", "0");
                            cmd.Parameters.AddWithValue("@StaffExpID", lblexpid2.Text);
                            cmd.Parameters.AddWithValue("@ProjePurID", "0");
                            cmd.Parameters.AddWithValue("@PayRequestID", "0");

                        }
                        else

                        {
                            cmd.Parameters.AddWithValue("@OfiiceExpID", "0");
                            cmd.Parameters.AddWithValue("@StaffExpID", "0");
                            cmd.Parameters.AddWithValue("@ProjePurID", lblexpid2.Text);
                            cmd.Parameters.AddWithValue("@PayRequestID", "0");

                        }
                        con.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {
                            //SuccessDiv1.Visible = true;
                            //lblMsg.Visible = true;
                            //lblMsg.Text = "Expenses New Item Added Successfully";

                        }
                        else
                        {
                            //SuccessDiv1.Visible = true;
                            //lblMsg.Visible = true;
                            ////  lblMsg.ForeColor = Color.Black;
                            //lblMsg.Text = "Expenses New Item Added Successfully";
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
        //--------------------------------Item1-----------------



        //=======================================================
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {

                    using (SqlConnection con = new SqlConnection(strconnect))
                    {

                        //   string amt =lblSubTotalCost1.Text;

                        SqlCommand cmd = new SqlCommand("SP_SavePaymentApproval", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExpensesBelong", lblRelatedTo1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                        cmd.Parameters.AddWithValue("@Exp_Type", lblExp_Type1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Date", lblExpDate1.Text);
                        cmd.Parameters.AddWithValue("@BillNo", lblBillno1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Currency", lblCurrency1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Payment", lblPayementMode1.Text);

                        cmd.Parameters.AddWithValue("@EmpID", UserId);

                        cmd.Parameters.AddWithValue("@ApprovalBy", UserName);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@ApprovalEmpID", UserId);

                        if (lblRelatedTo1.Text == "Office Expenses")
                        {
                            cmd.Parameters.AddWithValue("@Exp_Category", lblCategory1.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategory", lblSub_Category1.Text);
                            cmd.Parameters.AddWithValue("@Exp_CategoryId", lblCategoryid.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategoryId", lblSub_Category1id.Text);
                            cmd.Parameters.AddWithValue("@TotalExp_Amount", lblSubTotalCost1.Text);

                        }
                        else if (lblRelatedTo1.Text == "Payment Request")
                        {

                            cmd.Parameters.AddWithValue("@project_Id", lblprojectId.Text);
                            cmd.Parameters.AddWithValue("@Exp_Category", lblCategory1.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategory", lblSub_Category1.Text);
                            cmd.Parameters.AddWithValue("@Exp_CategoryId", lblCategoryid.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategoryId", lblSub_Category1id.Text);
                            cmd.Parameters.AddWithValue("@TotalExp_Amount", lblSubTotalCost1.Text);
                        }
                        else if (lblRelatedTo1.Text == "Staff Expenses")
                        {
                            cmd.Parameters.AddWithValue("@Exp_StaffID", lblstaffid.Text);
                            cmd.Parameters.AddWithValue("@TotalExp_Amount", lblSubTotalCost1.Text);
                        }
                        else //project
                        {
                            cmd.Parameters.AddWithValue("@Project_Id", lblprojectId.Text);
                            cmd.Parameters.AddWithValue("@TotalExp_Amount", lblSubTotalCost1.Text);
                        }


                        con.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {

                            //lblMsg.Visible = true;
                            //lblMsg.Text = "Approval Added Successfully";

                        }
                        else
                        {

                            //lblMsg.Visible = true;
                            //lblMsg.Text = "Appoval not Successfully";
                        }

                        con.Close();
                        GetTotalApprovalAmount();
                        UpdateTotalApprovalAmount();

                    }
                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {

                        var rows = GridViewOffice.Rows;
                        Button btn = (Button)sender;
                        GridViewRow row = (GridViewRow)btn.NamingContainer;
                        int rowindex = Convert.ToInt32(row.RowIndex);
                        string lblAmount1 = ((Label)rows[rowindex].FindControl("lblAmount1")).Text;
                        string txtReason = ((TextBox)rows[rowindex].FindControl("txtReason")).Text;
                        string lblItem1 = ((Label)rows[rowindex].FindControl("lblItem1")).Text;
                        string lblcreateby1 = ((Label)rows[rowindex].FindControl("lblcreateby1")).Text;
                        string lblEmpId = ((Label)rows[rowindex].FindControl("lblEmpId")).Text;
                        string lblsendDesignation = ((Label)rows[rowindex].FindControl("lblsendDesignation")).Text;
                        string lblDescription1 = ((Label)rows[rowindex].FindControl("lblDescription1")).Text;
                        string lblRate1 = ((Label)rows[rowindex].FindControl("lblRate1")).Text;
                        string lblQuantity1 = ((Label)rows[rowindex].FindControl("lblQuantity1")).Text;
                        //string lblAmount1 = ((Label)rows[rowindex].FindControl("lblAmount1")).Text;
                        string txtExpAmount = ((TextBox)rows[rowindex].FindControl("txtExpAmount")).Text;

                        float Amount1 = (float)Convert.ToDouble(lblAmount1);
                        float ExpAmount = (float)Convert.ToDouble(txtExpAmount);
                        float RemmainingAmount = Amount1 - ExpAmount;
                        lblRemmainingAmount12.Text = Convert.ToString(RemmainingAmount);

                        SqlCommand cmd1 = new SqlCommand("SP_SavePaymentApprovalItem", con1);
                        cmd1.Connection = con1;
                        cmd1.CommandType = CommandType.StoredProcedure;

                        cmd1.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                        //cmd.Parameters.AddWithValue("@Exp_Category", ddlExpensesCategory.SelectedItem.Text);
                        //cmd.Parameters.AddWithValue("@Exp_SubCategory", ddlSubCategory.SelectedItem.Text);
                        cmd1.Parameters.AddWithValue("@BillNo", lblBillno1.Text);

                        cmd1.Parameters.AddWithValue("@Item", lblItem1);
                        cmd1.Parameters.AddWithValue("@Description", lblDescription1);

                        cmd1.Parameters.AddWithValue("@Quantity", lblQuantity1);
                        cmd1.Parameters.AddWithValue("@Rate", lblRate1);
                        cmd1.Parameters.AddWithValue("@Approval", "True");
                        cmd1.Parameters.AddWithValue("@ApprovalBy", UserName);
                        cmd1.Parameters.AddWithValue("@ApprovalEmpID", UserId);
                        cmd1.Parameters.AddWithValue("@ApprovalDesignation", Designation);
                        cmd1.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);
                        cmd1.Parameters.AddWithValue("@Amount", txtExpAmount);
                        cmd1.Parameters.AddWithValue("@ApprovalAmount", txtExpAmount);//lblSubTotal1
                        cmd1.Parameters.AddWithValue("@ApprovalSatus", "Approved");
                        cmd1.Parameters.AddWithValue("@SendEmpID", lblEmpId);
                        cmd1.Parameters.AddWithValue("@SendBy", lblcreateby1);
                        cmd1.Parameters.AddWithValue("@SendDesignation", lblsendDesignation);
                        cmd1.Parameters.AddWithValue("@Reason", txtReason);
                        cmd1.Parameters.AddWithValue("@ViewApproval", "true");
                        cmd1.Parameters.AddWithValue("@RemainingAmount", lblRemmainingAmount12.Text);

                        if (lblRelatedTo1.Text == "Payment Request")
                        {
                            cmd1.Parameters.AddWithValue("@OfiiceExpID", "");
                            cmd1.Parameters.AddWithValue("@StaffExpID", "");
                            cmd1.Parameters.AddWithValue("@ProjePurID", "");
                            cmd1.Parameters.AddWithValue("@PayRequestID", lblexpid2.Text);

                        }
                        else if (lblRelatedTo1.Text == "Office Expenses")
                        {
                            cmd1.Parameters.AddWithValue("@OfiiceExpID", lblexpid2.Text);
                            cmd1.Parameters.AddWithValue("@StaffExpID", "");
                            cmd1.Parameters.AddWithValue("@ProjePurID", "");
                            cmd1.Parameters.AddWithValue("@PayRequestID", "");


                        }
                        else if (lblRelatedTo1.Text == "Staff Expenses")
                        {
                            cmd1.Parameters.AddWithValue("@OfiiceExpID", "");
                            cmd1.Parameters.AddWithValue("@StaffExpID", lblexpid2.Text);
                            cmd1.Parameters.AddWithValue("@ProjePurID", "");
                            cmd1.Parameters.AddWithValue("@PayRequestID", "");

                        }
                        else

                        {
                            cmd1.Parameters.AddWithValue("@OfiiceExpID", "");
                            cmd1.Parameters.AddWithValue("@StaffExpID", "");
                            cmd1.Parameters.AddWithValue("@ProjePurID", lblexpid2.Text);
                            cmd1.Parameters.AddWithValue("@PayRequestID", "");

                        }

                        con1.Open();
                        dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            result = dr1[0].ToString();
                        }
                        Result1 = int.Parse(result);
                        if (Result1 > 0)
                        {
                            //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses  Item Approval Added  Successfully!')", true);
                            //    //ViewFileExpensesDetails();
                        }
                        else
                        {
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses Item Approval Not Added  Successfully!')", true);
                        }


                        con1.Close();
                        Calculatefilldata();
                        Calculatefilldata1();
                        UpdateTotalApprovalAmount();
                        //GetTotalAmount();
                        //con1.Close();
                        Clear();
                    }
                    using (SqlConnection con2 = new SqlConnection(strconnect))
                    {
                        foreach (GridViewRow gvrow in GridExpensesFile.Rows)
                        {
                            Label lblcreateby = (Label)gvrow.FindControl("lblcreateby");
                            Label lblExpensesrFileName1 = (Label)gvrow.FindControl("lblExpensesrFileName1");
                            Label lblFilePath = (Label)gvrow.FindControl("lblFilePath");
                            // string fileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);

                            string Extention = System.IO.Path.GetExtension(lblExpensesrFileName1.Text);
                            SqlCommand cmd2 = new SqlCommand("SP_UploadPaymentApprovalAttachmentFile", con2);
                            cmd2.Connection = con2;
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                            cmd2.Parameters.AddWithValue("@Exp_id", "0");
                            //cmd.Parameters.AddWithValue("@OfficeID", lblexpid2.Text);
                            cmd2.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);

                            if (lblRelatedTo1.Text == "Payment Request")
                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", "");
                                cmd2.Parameters.AddWithValue("@SatffExpID", "");
                                cmd2.Parameters.AddWithValue("@ProjectPurID", "");
                                cmd2.Parameters.AddWithValue("@PayMentReqID", lblexpid2.Text);
                                // cmd.Parameters.AddWithValue("@Exp_id", "0");
                                // cmd.Parameters.AddWithValue("@BelongTo", "Payment Request");
                            }
                            else if (lblRelatedTo1.Text == "Office Expenses")
                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", lblexpid2.Text);
                                cmd2.Parameters.AddWithValue("@SatffExpID", "");
                                cmd2.Parameters.AddWithValue("@ProjectPurID", "");
                                cmd2.Parameters.AddWithValue("@PayMentReqID", "");
                                //cmd.Parameters.AddWithValue("@Exp_id", "0");
                                //  cmd.Parameters.AddWithValue("@BelongTo", "Office Expenses");

                            }
                            else if (lblRelatedTo1.Text == "Staff Expenses")
                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", "");
                                cmd2.Parameters.AddWithValue("@SatffExpID", lblexpid2.Text);
                                cmd2.Parameters.AddWithValue("@ProjectPurID", "");
                                cmd2.Parameters.AddWithValue("@PayMentReqID", "");
                                //cmd.Parameters.AddWithValue("@Exp_id", "0");
                                //cmd.Parameters.AddWithValue("@BelongTo", "Staff Expenses");
                            }
                            else

                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", "");
                                cmd2.Parameters.AddWithValue("@SatffExpID", "");
                                cmd2.Parameters.AddWithValue("@ProjectPurID", lblexpid2.Text);
                                cmd2.Parameters.AddWithValue("@PayMentReqID", "");
                                //cmd.Parameters.AddWithValue("@Exp_id", "0");
                                //cmd.Parameters.AddWithValue("@BelongTo", "Project Purchase");
                            }
                            cmd2.Parameters.AddWithValue("@FileName", lblExpensesrFileName1.Text);
                            cmd2.Parameters.AddWithValue("@FilePath", lblFilePath.Text);
                            cmd2.Parameters.AddWithValue("@EmpID", UserId);
                            cmd2.Parameters.AddWithValue("@Designation", Designation);
                            cmd2.Parameters.AddWithValue("@sendBY", lblcreateby.Text);
                            cmd2.Parameters.AddWithValue("@ApprovalBy", UserName);
                            cmd2.Parameters.AddWithValue("@Approval", "True");
                            cmd2.Parameters.AddWithValue("@Extention", Extention);
                            con2.Open();
                            int i = cmd2.ExecuteNonQuery();
                            if (i < 0)
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Payment Approval Item Approved  Successfully!')", true);
                                //ViewFileExpensesDetails();
                            }
                            else
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Payment Approval Item Approved  Successfully!')", true);
                            }
                            con2.Close();
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

        protected void btnDecline_Click1(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {

                        SqlCommand cmd = new SqlCommand("SP_SavePaymentApproval", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExpensesBelong", lblRelatedTo1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                        cmd.Parameters.AddWithValue("@Exp_Type", lblExp_Type1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Date", lblExpDate1.Text);
                        cmd.Parameters.AddWithValue("@BillNo", lblBillno1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Currency", lblCurrency1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Payment", lblPayementMode1.Text);
                        cmd.Parameters.AddWithValue("@ApprovalEmpID", UserId);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@ApprovalBy", UserName);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@TotalExp_Amount", lblSubTotalCost1.Text);

                        if (lblRelatedTo1.Text == "Office Expenses")
                        {
                            cmd.Parameters.AddWithValue("@Exp_Category", lblCategory1.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategory", lblSub_Category1.Text);
                            cmd.Parameters.AddWithValue("@Exp_CategoryId", lblCategoryid.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategoryId", lblSub_Category1id.Text);

                        }
                        else if (lblRelatedTo1.Text == "Payment Request")
                        {

                            cmd.Parameters.AddWithValue("@project_Id", lblprojectId.Text);
                            cmd.Parameters.AddWithValue("@Exp_Category", lblCategory1.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategory", lblSub_Category1.Text);
                            cmd.Parameters.AddWithValue("@Exp_CategoryId", lblCategoryid.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategoryId", lblSub_Category1id.Text);
                        }
                        else if (lblRelatedTo1.Text == "Staff Expenses")
                        {
                            cmd.Parameters.AddWithValue("@Exp_StaffID", lblstaffid.Text);
                        }
                        else //project
                        {
                            cmd.Parameters.AddWithValue("@Project_Id", lblprojectId.Text);
                        }


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
                            //  lblMsg.ForeColor = Color.Black;
                            lblMsg.Text = "Expenses NOT Item Added Successfully";
                        }

                        con.Close();

                        GetTotalApprovalAmount();
                    }
                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {

                        var rows = GridViewOffice.Rows;
                        Button btn = (Button)sender;
                        GridViewRow row = (GridViewRow)btn.NamingContainer;
                        int rowindex = Convert.ToInt32(row.RowIndex);
                        string lblAmount1 = ((Label)rows[rowindex].FindControl("lblAmount1")).Text;
                        string txtReason = ((TextBox)rows[rowindex].FindControl("txtReason")).Text;
                        string lblItem1 = ((Label)rows[rowindex].FindControl("lblItem1")).Text;
                        string lblcreateby1 = ((Label)rows[rowindex].FindControl("lblcreateby1")).Text;
                        string lblEmpId = ((Label)rows[rowindex].FindControl("lblEmpId")).Text;
                        string lblsendDesignation = ((Label)rows[rowindex].FindControl("lblsendDesignation")).Text;
                        string lblDescription1 = ((Label)rows[rowindex].FindControl("lblDescription1")).Text;
                        string lblRate1 = ((Label)rows[rowindex].FindControl("lblRate1")).Text;
                        string lblQuantity1 = ((Label)rows[rowindex].FindControl("lblQuantity1")).Text;
                        //string lblAmount1 = ((Label)rows[rowindex].FindControl("lblAmount1")).Text;
                        string txtExpAmount = ((TextBox)rows[rowindex].FindControl("txtExpAmount")).Text;

                        float Amount1 = (float)Convert.ToDouble(lblAmount1);
                        float ExpAmount = (float)Convert.ToDouble(txtExpAmount);
                        float RemmainingAmount = Amount1 - ExpAmount;
                        lblRemmainingAmount12.Text = Convert.ToString(RemmainingAmount);

                        SqlCommand cmd1 = new SqlCommand("SP_SavePaymentApprovalItem", con1);
                        cmd1.Connection = con1;
                        cmd1.CommandType = CommandType.StoredProcedure;

                        cmd1.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                        //cmd.Parameters.AddWithValue("@Exp_Category", ddlExpensesCategory.SelectedItem.Text);
                        //cmd.Parameters.AddWithValue("@Exp_SubCategory", ddlSubCategory.SelectedItem.Text);
                        cmd1.Parameters.AddWithValue("@BillNo", lblBillno1.Text);

                        cmd1.Parameters.AddWithValue("@Item", lblItem1);
                        cmd1.Parameters.AddWithValue("@Description", lblDescription1);

                        cmd1.Parameters.AddWithValue("@Quantity", lblQuantity1);
                        cmd1.Parameters.AddWithValue("@Rate", lblRate1);
                        cmd1.Parameters.AddWithValue("@Approval", "True");
                        cmd1.Parameters.AddWithValue("@ApprovalBy", UserName);
                        cmd1.Parameters.AddWithValue("@ApprovalEmpID", UserId);
                        cmd1.Parameters.AddWithValue("@ApprovalDesignation", Designation);
                        cmd1.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);
                        cmd1.Parameters.AddWithValue("@Amount", txtExpAmount);
                        cmd1.Parameters.AddWithValue("@ApprovalAmount", 0);
                        cmd1.Parameters.AddWithValue("@ApprovalSatus", "Decline");
                        cmd1.Parameters.AddWithValue("@SendEmpID", lblEmpId);
                        cmd1.Parameters.AddWithValue("@SendBy", lblcreateby1);
                        cmd1.Parameters.AddWithValue("@SendDesignation", lblsendDesignation);
                        cmd1.Parameters.AddWithValue("@Reason", txtReason);
                        cmd1.Parameters.AddWithValue("@ViewApproval", "false");
                        cmd1.Parameters.AddWithValue("@RemainingAmount", lblRemmainingAmount12.Text);

                        if (lblRelatedTo1.Text == "Payment Request")
                        {
                            cmd1.Parameters.AddWithValue("@OfiiceExpID", "");
                            cmd1.Parameters.AddWithValue("@StaffExpID", "");
                            cmd1.Parameters.AddWithValue("@ProjePurID", "");
                            cmd1.Parameters.AddWithValue("@PayRequestID", lblexpid2.Text);

                        }
                        else if (lblRelatedTo1.Text == "Office Expenses")
                        {
                            cmd1.Parameters.AddWithValue("@OfiiceExpID", lblexpid2.Text);
                            cmd1.Parameters.AddWithValue("@StaffExpID", "");
                            cmd1.Parameters.AddWithValue("@ProjePurID", "");
                            cmd1.Parameters.AddWithValue("@PayRequestID", "");


                        }
                        else if (lblRelatedTo1.Text == "Staff Expenses")
                        {
                            cmd1.Parameters.AddWithValue("@OfiiceExpID", "");
                            cmd1.Parameters.AddWithValue("@StaffExpID", lblexpid2.Text);
                            cmd1.Parameters.AddWithValue("@ProjePurID", "");
                            cmd1.Parameters.AddWithValue("@PayRequestID", "");

                        }
                        else

                        {
                            cmd1.Parameters.AddWithValue("@OfiiceExpID", "");
                            cmd1.Parameters.AddWithValue("@StaffExpID", "");
                            cmd1.Parameters.AddWithValue("@ProjePurID", lblexpid2.Text);
                            cmd1.Parameters.AddWithValue("@PayRequestID", "");

                        }

                        con1.Open();
                        dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            result = dr1[0].ToString();
                        }
                        Result1 = int.Parse(result);
                        if (Result1 > 0)
                        {
                            //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses  Item Approval Added  Successfully!')", true);
                            //    //ViewFileExpensesDetails();
                        }
                        else
                        {
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses Item Approval Not Added  Successfully!')", true);
                        }


                        con1.Close();
                        Calculatefilldata();
                        Calculatefilldata1();
                        UpdateTotalApprovalAmount();
                        //GetTotalAmount();
                        //con1.Close();
                        Clear();
                    }

                    using (SqlConnection con2 = new SqlConnection(strconnect))
                    {
                        foreach (GridViewRow gvrow in GridExpensesFile.Rows)
                        {
                            Label lblcreateby = (Label)gvrow.FindControl("lblcreateby");
                            Label lblExpensesrFileName1 = (Label)gvrow.FindControl("lblExpensesrFileName1");
                            Label lblFilePath = (Label)gvrow.FindControl("lblFilePath");

                            string Extention = System.IO.Path.GetExtension(lblExpensesrFileName1.Text);
                            SqlCommand cmd2 = new SqlCommand("SP_UploadPaymentApprovalAttachmentFile", con2);
                            cmd2.Connection = con2;
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                            cmd2.Parameters.AddWithValue("@Exp_id", "0");
                            cmd2.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);

                            if (lblRelatedTo1.Text == "Payment Request")
                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", "0");
                                cmd2.Parameters.AddWithValue("@SatffExpID", "0");
                                cmd2.Parameters.AddWithValue("@ProjectPurID", "0");
                                cmd2.Parameters.AddWithValue("@PayMentReqID", lblexpid2.Text);

                            }
                            else if (lblRelatedTo1.Text == "Office Expenses")
                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", lblexpid2.Text);
                                cmd2.Parameters.AddWithValue("@SatffExpID", "0");
                                cmd2.Parameters.AddWithValue("@ProjectPurID", "0");
                                cmd2.Parameters.AddWithValue("@PayMentReqID", "0");


                            }
                            else if (lblRelatedTo1.Text == "Staff Expenses")
                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", "0");
                                cmd2.Parameters.AddWithValue("@SatffExpID", lblexpid2.Text);
                                cmd2.Parameters.AddWithValue("@ProjectPurID", "0");
                                cmd2.Parameters.AddWithValue("@PayMentReqID", "0");

                            }
                            else

                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", "0");
                                cmd2.Parameters.AddWithValue("@SatffExpID", "0");
                                cmd2.Parameters.AddWithValue("@ProjectPurID", lblexpid2.Text);
                                cmd2.Parameters.AddWithValue("@PayMentReqID", "0");

                            }
                            cmd2.Parameters.AddWithValue("@FileName", lblExpensesrFileName1.Text);
                            cmd2.Parameters.AddWithValue("@FilePath", lblFilePath.Text);
                            cmd2.Parameters.AddWithValue("@EmpID", UserId);
                            cmd2.Parameters.AddWithValue("@Designation", Designation);
                            cmd2.Parameters.AddWithValue("@sendBY", lblcreateby.Text);
                            cmd2.Parameters.AddWithValue("@ApprovalBy", UserName);
                            cmd2.Parameters.AddWithValue("@Approval", "True");
                            cmd2.Parameters.AddWithValue("@Extention", Extention);
                            con2.Open();
                            int i = cmd2.ExecuteNonQuery();
                            if (i < 0)
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Payment Approval Item Approved  Successfully!')", true);

                            }
                            else
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Payment Approval Item Approved  Successfully!')", true);
                            }
                            con2.Close();
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

        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chckheader = (CheckBox)GridViewOffice.HeaderRow.FindControl("chkAll");
                foreach (GridViewRow row in GridViewOffice.Rows)
                {
                    System.Web.UI.WebControls.CheckBox chckITem = (System.Web.UI.WebControls.CheckBox)row.FindControl("chkItem");
                    if (chckheader.Checked == true)
                    {
                        chckITem.Checked = true;
                        GridViewOffice.Columns[10].Visible = false;
                        GridViewOffice.Columns[9].Visible = false;
                        btnAcceptALL.Visible = true;
                        btnDeclineALL.Visible = true;
                    }
                    else
                    {
                        chckITem.Checked = false;
                        GridViewOffice.Columns[10].Visible = true;
                        GridViewOffice.Columns[9].Visible = true;
                        btnAcceptALL.Visible = false;
                        btnDeclineALL.Visible = false;
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
            try
            {
                CheckBox chckheader = (CheckBox)GridViewOffice.HeaderRow.FindControl("chkAll");
                foreach (GridViewRow row in GridViewOffice.Rows)
                {
                    System.Web.UI.WebControls.CheckBox chckITem = (System.Web.UI.WebControls.CheckBox)row.FindControl("chkItem");
                    if (chckheader.Checked == true)
                    {
                        chckITem.Checked = true;
                        GridViewOffice.Columns[10].Visible = false;
                        GridViewOffice.Columns[9].Visible = false;
                        btnAcceptALL.Visible = true;
                        btnDeclineALL.Visible = true;
                    }
                    else
                    {
                        chckITem.Checked = false;
                        GridViewOffice.Columns[10].Visible = true;
                        GridViewOffice.Columns[9].Visible = true;
                        btnAcceptALL.Visible = false;
                        btnDeclineALL.Visible = false;
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



        protected void btnAcceptALL_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_SavePaymentApproval", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExpensesBelong", lblRelatedTo1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                        cmd.Parameters.AddWithValue("@Exp_Type", lblExp_Type1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Date", lblExpDate1.Text);
                        cmd.Parameters.AddWithValue("@BillNo", lblBillno1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Currency", lblCurrency1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Payment", lblPayementMode1.Text);

                        cmd.Parameters.AddWithValue("@EmpID", UserId);

                        cmd.Parameters.AddWithValue("@ApprovalBy", UserName);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@ApprovalEmpID", UserId);

                        if (lblRelatedTo1.Text == "Office Expenses")
                        {
                            cmd.Parameters.AddWithValue("@Exp_Category", lblCategory1.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategory", lblSub_Category1.Text);
                            cmd.Parameters.AddWithValue("@Exp_CategoryId", lblCategoryid.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategoryId", lblSub_Category1id.Text);
                            cmd.Parameters.AddWithValue("@TotalExp_Amount", lblSubTotalCost1.Text);

                        }
                        else if (lblRelatedTo1.Text == "Payment Request")
                        {

                            cmd.Parameters.AddWithValue("@project_Id", lblprojectId.Text);
                            cmd.Parameters.AddWithValue("@Exp_Category", lblCategory1.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategory", lblSub_Category1.Text);
                            cmd.Parameters.AddWithValue("@Exp_CategoryId", lblCategoryid.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategoryId", lblSub_Category1id.Text);
                            cmd.Parameters.AddWithValue("@TotalExp_Amount", lblSubTotalCost1.Text);
                        }
                        else if (lblRelatedTo1.Text == "Staff Expenses")
                        {
                            cmd.Parameters.AddWithValue("@Exp_StaffID", lblstaffid.Text);
                            cmd.Parameters.AddWithValue("@TotalExp_Amount", lblSubTotalCost1.Text);
                        }
                        else //project
                        {
                            cmd.Parameters.AddWithValue("@Project_Id", lblprojectId.Text);
                            cmd.Parameters.AddWithValue("@TotalExp_Amount", lblSubTotalCost1.Text);
                        }


                        con.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {

                            //lblMsg.Visible = true;
                            //lblMsg.Text = "Approval Added Successfully";

                        }
                        else
                        {

                            //lblMsg.Visible = true;
                            //lblMsg.Text = "Appoval not Successfully";
                        }

                        con.Close();
                        GetTotalApprovalAmount();
                        UpdateTotalApprovalAmount();

                    }
                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {

                        foreach (GridViewRow gvrow in GridViewOffice.Rows)
                        {
                            var checkbox = gvrow.FindControl("chkItem") as CheckBox;
                            if (checkbox.Checked)
                            {
                                TextBox txtReason = (TextBox)gvrow.FindControl("txtReason");
                                TextBox txtExpAmount = (TextBox)gvrow.FindControl("txtExpAmount");
                                Label lblItem1 = (Label)gvrow.FindControl("lblItem1");
                                Label lblcreateby1 = (Label)gvrow.FindControl("lblcreateby1");
                                Label lblEmpId = (Label)gvrow.FindControl("lblEmpId");
                                Label lblsendDesignation = (Label)gvrow.FindControl("lblsendDesignation");
                                Label lblDescription1 = (Label)gvrow.FindControl("lblDescription1");
                                Label lblRate1 = (Label)gvrow.FindControl("lblRate1");
                                Label lblQuantity1 = (Label)gvrow.FindControl("lblQuantity1");
                                Label lblAmount1 = (Label)gvrow.FindControl("lblAmount1");

                                //float Amount1 = (float)Convert.ToDouble(lblAmount1);
                                //float ExpAmount = (float)Convert.ToDouble(txtExpAmount);
                                float Amount1 = float.Parse(lblAmount1.Text);
                                float ExpAmount = float.Parse(txtExpAmount.Text);
                                float RemmainingAmount = Amount1 - ExpAmount;
                                lblRemmainingAmount12.Text = Convert.ToString(RemmainingAmount);

                                SqlCommand cmd1 = new SqlCommand("SP_SavePaymentApprovalItem", con1);
                                cmd1.Connection = con1;
                                cmd1.CommandType = CommandType.StoredProcedure;

                                cmd1.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                                //cmd.Parameters.AddWithValue("@Exp_Category", ddlExpensesCategory.SelectedItem.Text);
                                //cmd.Parameters.AddWithValue("@Exp_SubCategory", ddlSubCategory.SelectedItem.Text);
                                cmd1.Parameters.AddWithValue("@BillNo", lblBillno1.Text);

                                cmd1.Parameters.AddWithValue("@Item", lblItem1.Text);
                                cmd1.Parameters.AddWithValue("@Description", lblDescription1.Text);

                                cmd1.Parameters.AddWithValue("@Quantity", lblQuantity1.Text);
                                cmd1.Parameters.AddWithValue("@Rate", lblRate1.Text);
                                cmd1.Parameters.AddWithValue("@Approval", "True");
                                cmd1.Parameters.AddWithValue("@ApprovalBy", UserName);
                                cmd1.Parameters.AddWithValue("@ApprovalEmpID", UserId);
                                cmd1.Parameters.AddWithValue("@ApprovalDesignation", Designation);
                                cmd1.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);
                                cmd1.Parameters.AddWithValue("@Amount", txtExpAmount.Text);
                                cmd1.Parameters.AddWithValue("@ApprovalAmount", txtExpAmount.Text);//lblSubTotal1
                                cmd1.Parameters.AddWithValue("@ApprovalSatus", "Approved");
                                cmd1.Parameters.AddWithValue("@SendEmpID", lblEmpId.Text);
                                cmd1.Parameters.AddWithValue("@SendBy", lblcreateby1.Text);
                                cmd1.Parameters.AddWithValue("@SendDesignation", lblsendDesignation.Text);
                                cmd1.Parameters.AddWithValue("@Reason", txtReason.Text);
                                cmd1.Parameters.AddWithValue("@ViewApproval", "true");
                                cmd1.Parameters.AddWithValue("@RemainingAmount", lblRemmainingAmount12.Text);

                                if (lblRelatedTo1.Text == "Payment Request")
                                {
                                    cmd1.Parameters.AddWithValue("@OfiiceExpID", "");
                                    cmd1.Parameters.AddWithValue("@StaffExpID", "");
                                    cmd1.Parameters.AddWithValue("@ProjePurID", "");
                                    cmd1.Parameters.AddWithValue("@PayRequestID", lblexpid2.Text);

                                }
                                else if (lblRelatedTo1.Text == "Office Expenses")
                                {
                                    cmd1.Parameters.AddWithValue("@OfiiceExpID", lblexpid2.Text);
                                    cmd1.Parameters.AddWithValue("@StaffExpID", "");
                                    cmd1.Parameters.AddWithValue("@ProjePurID", "");
                                    cmd1.Parameters.AddWithValue("@PayRequestID", "");


                                }
                                else if (lblRelatedTo1.Text == "Staff Expenses")
                                {
                                    cmd1.Parameters.AddWithValue("@OfiiceExpID", "");
                                    cmd1.Parameters.AddWithValue("@StaffExpID", lblexpid2.Text);
                                    cmd1.Parameters.AddWithValue("@ProjePurID", "");
                                    cmd1.Parameters.AddWithValue("@PayRequestID", "");

                                }
                                else

                                {
                                    cmd1.Parameters.AddWithValue("@OfiiceExpID", "");
                                    cmd1.Parameters.AddWithValue("@StaffExpID", "");
                                    cmd1.Parameters.AddWithValue("@ProjePurID", lblexpid2.Text);
                                    cmd1.Parameters.AddWithValue("@PayRequestID", "");

                                }

                                con1.Open();
                                dr1 = cmd1.ExecuteReader();
                                while (dr1.Read())
                                {
                                    result = dr1[0].ToString();
                                }
                                Result1 = int.Parse(result);
                                if (Result1 > 0)
                                {
                                    //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses  Item Approval Added  Successfully!')", true);
                                    //    //ViewFileExpensesDetails();
                                }
                                else
                                {
                                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses Item Approval Not Added  Successfully!')", true);
                                }


                                con1.Close();
                                Calculatefilldata();

                                Calculatefilldata1();
                                UpdateTotalApprovalAmount();
                                //GetTotalAmount();
                                //con1.Close();
                                Clear();

                            }
                        }
                    }
                    using (SqlConnection con2 = new SqlConnection(strconnect))
                    {
                        foreach (GridViewRow gvrow in GridExpensesFile.Rows)
                        {
                            Label lblcreateby = (Label)gvrow.FindControl("lblcreateby");
                            Label lblExpensesrFileName1 = (Label)gvrow.FindControl("lblExpensesrFileName1");
                            Label lblFilePath = (Label)gvrow.FindControl("lblFilePath");
                            // string fileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);

                            string Extention = System.IO.Path.GetExtension(lblExpensesrFileName1.Text);
                            SqlCommand cmd2 = new SqlCommand("SP_UploadPaymentApprovalAttachmentFile", con2);
                            cmd2.Connection = con2;
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                            cmd2.Parameters.AddWithValue("@Exp_id", "0");
                            //cmd.Parameters.AddWithValue("@OfficeID", lblexpid2.Text);
                            cmd2.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);

                            if (lblRelatedTo1.Text == "Payment Request")
                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", "");
                                cmd2.Parameters.AddWithValue("@SatffExpID", "");
                                cmd2.Parameters.AddWithValue("@ProjectPurID", "");
                                cmd2.Parameters.AddWithValue("@PayMentReqID", lblexpid2.Text);
                                // cmd.Parameters.AddWithValue("@Exp_id", "0");
                                // cmd.Parameters.AddWithValue("@BelongTo", "Payment Request");
                            }
                            else if (lblRelatedTo1.Text == "Office Expenses")
                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", lblexpid2.Text);
                                cmd2.Parameters.AddWithValue("@SatffExpID", "");
                                cmd2.Parameters.AddWithValue("@ProjectPurID", "");
                                cmd2.Parameters.AddWithValue("@PayMentReqID", "");
                                //cmd.Parameters.AddWithValue("@Exp_id", "0");
                                //  cmd.Parameters.AddWithValue("@BelongTo", "Office Expenses");

                            }
                            else if (lblRelatedTo1.Text == "Staff Expenses")
                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", "");
                                cmd2.Parameters.AddWithValue("@SatffExpID", lblexpid2.Text);
                                cmd2.Parameters.AddWithValue("@ProjectPurID", "");
                                cmd2.Parameters.AddWithValue("@PayMentReqID", "");
                                //cmd.Parameters.AddWithValue("@Exp_id", "0");
                                //cmd.Parameters.AddWithValue("@BelongTo", "Staff Expenses");
                            }
                            else

                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", "");
                                cmd2.Parameters.AddWithValue("@SatffExpID", "");
                                cmd2.Parameters.AddWithValue("@ProjectPurID", lblexpid2.Text);
                                cmd2.Parameters.AddWithValue("@PayMentReqID", "");
                                //cmd.Parameters.AddWithValue("@Exp_id", "0");
                                //cmd.Parameters.AddWithValue("@BelongTo", "Project Purchase");
                            }
                            cmd2.Parameters.AddWithValue("@FileName", lblExpensesrFileName1.Text);
                            cmd2.Parameters.AddWithValue("@FilePath", lblFilePath.Text);
                            cmd2.Parameters.AddWithValue("@EmpID", UserId);
                            cmd2.Parameters.AddWithValue("@Designation", Designation);
                            cmd2.Parameters.AddWithValue("@sendBY", lblcreateby.Text);
                            cmd2.Parameters.AddWithValue("@ApprovalBy", UserName);
                            cmd2.Parameters.AddWithValue("@Approval", "True");
                            cmd2.Parameters.AddWithValue("@Extention", Extention);
                            con2.Open();
                            int i = cmd2.ExecuteNonQuery();
                            if (i < 0)
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Payment Approval Item Approved  Successfully!')", true);
                                //ViewFileExpensesDetails();
                            }
                            else
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Payment Approval Item Approved  Successfully!')", true);
                            }
                            con2.Close();
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

        protected void btnDeclineALL_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_SavePaymentApproval", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ExpensesBelong", lblRelatedTo1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                        cmd.Parameters.AddWithValue("@Exp_Type", lblExp_Type1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Date", lblExpDate1.Text);
                        cmd.Parameters.AddWithValue("@BillNo", lblBillno1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Currency", lblCurrency1.Text);
                        cmd.Parameters.AddWithValue("@Exp_Payment", lblPayementMode1.Text);

                        cmd.Parameters.AddWithValue("@EmpID", UserId);

                        cmd.Parameters.AddWithValue("@ApprovalBy", UserName);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@ApprovalEmpID", UserId);

                        if (lblRelatedTo1.Text == "Office Expenses")
                        {
                            cmd.Parameters.AddWithValue("@Exp_Category", lblCategory1.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategory", lblSub_Category1.Text);
                            cmd.Parameters.AddWithValue("@Exp_CategoryId", lblCategoryid.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategoryId", lblSub_Category1id.Text);
                            cmd.Parameters.AddWithValue("@TotalExp_Amount", lblSubTotalCost1.Text);

                        }
                        else if (lblRelatedTo1.Text == "Payment Request")
                        {

                            cmd.Parameters.AddWithValue("@project_Id", lblprojectId.Text);
                            cmd.Parameters.AddWithValue("@Exp_Category", lblCategory1.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategory", lblSub_Category1.Text);
                            cmd.Parameters.AddWithValue("@Exp_CategoryId", lblCategoryid.Text);
                            cmd.Parameters.AddWithValue("@Exp_SubCategoryId", lblSub_Category1id.Text);
                            cmd.Parameters.AddWithValue("@TotalExp_Amount", lblSubTotalCost1.Text);
                        }
                        else if (lblRelatedTo1.Text == "Staff Expenses")
                        {
                            cmd.Parameters.AddWithValue("@Exp_StaffID", lblstaffid.Text);
                            cmd.Parameters.AddWithValue("@TotalExp_Amount", lblSubTotalCost1.Text);
                        }
                        else //project
                        {
                            cmd.Parameters.AddWithValue("@Project_Id", lblprojectId.Text);
                            cmd.Parameters.AddWithValue("@TotalExp_Amount", lblSubTotalCost1.Text);
                        }


                        con.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {

                            //lblMsg.Visible = true;
                            //lblMsg.Text = "Approval Added Successfully";

                        }
                        else
                        {

                            //lblMsg.Visible = true;
                            //lblMsg.Text = "Appoval not Successfully";
                        }

                        con.Close();
                        GetTotalApprovalAmount();
                        UpdateTotalApprovalAmount();

                    }
                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {

                        foreach (GridViewRow gvrow in GridViewOffice.Rows)
                        {
                            var checkbox = gvrow.FindControl("chkItem") as CheckBox;
                            if (checkbox.Checked)
                            {
                                TextBox txtReason = (TextBox)gvrow.FindControl("txtReason");
                                TextBox txtExpAmount = (TextBox)gvrow.FindControl("txtExpAmount");
                                Label lblItem1 = (Label)gvrow.FindControl("lblItem1");
                                Label lblcreateby1 = (Label)gvrow.FindControl("lblcreateby1");
                                Label lblEmpId = (Label)gvrow.FindControl("lblEmpId");
                                Label lblsendDesignation = (Label)gvrow.FindControl("lblsendDesignation");
                                Label lblDescription1 = (Label)gvrow.FindControl("lblDescription1");
                                Label lblRate1 = (Label)gvrow.FindControl("lblRate1");
                                Label lblQuantity1 = (Label)gvrow.FindControl("lblQuantity1");
                                Label lblAmount1 = (Label)gvrow.FindControl("lblAmount1");
                                float Amount1 = float.Parse(lblAmount1.Text);
                                float ExpAmount = float.Parse(txtExpAmount.Text);
                                float RemmainingAmount = Amount1 - ExpAmount;
                                lblRemmainingAmount12.Text = Convert.ToString(RemmainingAmount);
                                SqlCommand cmd1 = new SqlCommand("SP_SavePaymentApprovalItem", con1);
                                cmd1.Connection = con1;
                                cmd1.CommandType = CommandType.StoredProcedure;

                                cmd1.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                                //cmd.Parameters.AddWithValue("@Exp_Category", ddlExpensesCategory.SelectedItem.Text);
                                //cmd.Parameters.AddWithValue("@Exp_SubCategory", ddlSubCategory.SelectedItem.Text);
                                cmd1.Parameters.AddWithValue("@BillNo", lblBillno1.Text);

                                cmd1.Parameters.AddWithValue("@Item", lblItem1.Text);
                                cmd1.Parameters.AddWithValue("@Description", lblDescription1.Text);

                                cmd1.Parameters.AddWithValue("@Quantity", lblQuantity1.Text);
                                cmd1.Parameters.AddWithValue("@Rate", lblRate1.Text);
                                cmd1.Parameters.AddWithValue("@Approval", "True");
                                cmd1.Parameters.AddWithValue("@ApprovalBy", UserName);
                                cmd1.Parameters.AddWithValue("@ApprovalEmpID", UserId);
                                cmd1.Parameters.AddWithValue("@ApprovalDesignation", Designation);
                                cmd1.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);
                                cmd1.Parameters.AddWithValue("@Amount", txtExpAmount.Text);
                                cmd1.Parameters.AddWithValue("@ApprovalAmount", 0);//lblSubTotal1
                                cmd1.Parameters.AddWithValue("@ApprovalSatus", "Decline");
                                cmd1.Parameters.AddWithValue("@SendEmpID", lblEmpId.Text);
                                cmd1.Parameters.AddWithValue("@SendBy", lblcreateby1.Text);
                                cmd1.Parameters.AddWithValue("@SendDesignation", lblsendDesignation.Text);
                                cmd1.Parameters.AddWithValue("@Reason", txtReason.Text);
                                cmd1.Parameters.AddWithValue("@ViewApproval", "true");
                                cmd1.Parameters.AddWithValue("@RemainingAmount", lblRemmainingAmount12.Text);

                                if (lblRelatedTo1.Text == "Payment Request")
                                {
                                    cmd1.Parameters.AddWithValue("@OfiiceExpID", "");
                                    cmd1.Parameters.AddWithValue("@StaffExpID", "");
                                    cmd1.Parameters.AddWithValue("@ProjePurID", "");
                                    cmd1.Parameters.AddWithValue("@PayRequestID", lblexpid2.Text);

                                }
                                else if (lblRelatedTo1.Text == "Office Expenses")
                                {
                                    cmd1.Parameters.AddWithValue("@OfiiceExpID", lblexpid2.Text);
                                    cmd1.Parameters.AddWithValue("@StaffExpID", "");
                                    cmd1.Parameters.AddWithValue("@ProjePurID", "");
                                    cmd1.Parameters.AddWithValue("@PayRequestID", "");


                                }
                                else if (lblRelatedTo1.Text == "Staff Expenses")
                                {
                                    cmd1.Parameters.AddWithValue("@OfiiceExpID", "");
                                    cmd1.Parameters.AddWithValue("@StaffExpID", lblexpid2.Text);
                                    cmd1.Parameters.AddWithValue("@ProjePurID", "");
                                    cmd1.Parameters.AddWithValue("@PayRequestID", "");

                                }
                                else

                                {
                                    cmd1.Parameters.AddWithValue("@OfiiceExpID", "");
                                    cmd1.Parameters.AddWithValue("@StaffExpID", "");
                                    cmd1.Parameters.AddWithValue("@ProjePurID", lblexpid2.Text);
                                    cmd1.Parameters.AddWithValue("@PayRequestID", "");

                                }

                                con1.Open();
                                dr1 = cmd1.ExecuteReader();
                                while (dr1.Read())
                                {
                                    result = dr1[0].ToString();
                                }
                                Result1 = int.Parse(result);
                                if (Result1 > 0)
                                {
                                    //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses  Item Approval Added  Successfully!')", true);
                                    //    //ViewFileExpensesDetails();
                                }
                                else
                                {
                                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses Item Approval Not Added  Successfully!')", true);
                                }


                                con1.Close();
                                Calculatefilldata();
                                Calculatefilldata1();
                                UpdateTotalApprovalAmount();
                                //GetTotalAmount();
                                //con1.Close();
                                Clear();

                            }
                        }
                    }
                    using (SqlConnection con2 = new SqlConnection(strconnect))
                    {
                        foreach (GridViewRow gvrow in GridExpensesFile.Rows)
                        {
                            Label lblcreateby = (Label)gvrow.FindControl("lblcreateby");
                            Label lblExpensesrFileName1 = (Label)gvrow.FindControl("lblExpensesrFileName1");
                            Label lblFilePath = (Label)gvrow.FindControl("lblFilePath");

                            string Extention = System.IO.Path.GetExtension(lblExpensesrFileName1.Text);
                            SqlCommand cmd2 = new SqlCommand("SP_UploadPaymentApprovalAttachmentFile", con2);
                            cmd2.Connection = con2;
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                            cmd2.Parameters.AddWithValue("@Exp_id", "0");
                            //cmd.Parameters.AddWithValue("@OfficeID", lblexpid2.Text);
                            cmd2.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);

                            if (lblRelatedTo1.Text == "Payment Request")
                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", "");
                                cmd2.Parameters.AddWithValue("@SatffExpID", "");
                                cmd2.Parameters.AddWithValue("@ProjectPurID", "");
                                cmd2.Parameters.AddWithValue("@PayMentReqID", lblexpid2.Text);
                                // cmd.Parameters.AddWithValue("@Exp_id", "0");
                                // cmd.Parameters.AddWithValue("@BelongTo", "Payment Request");
                            }
                            else if (lblRelatedTo1.Text == "Office Expenses")
                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", lblexpid2.Text);
                                cmd2.Parameters.AddWithValue("@SatffExpID", "");
                                cmd2.Parameters.AddWithValue("@ProjectPurID", "");
                                cmd2.Parameters.AddWithValue("@PayMentReqID", "");
                                //cmd.Parameters.AddWithValue("@Exp_id", "0");
                                //  cmd.Parameters.AddWithValue("@BelongTo", "Office Expenses");

                            }
                            else if (lblRelatedTo1.Text == "Staff Expenses")
                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", "");
                                cmd2.Parameters.AddWithValue("@SatffExpID", lblexpid2.Text);
                                cmd2.Parameters.AddWithValue("@ProjectPurID", "");
                                cmd2.Parameters.AddWithValue("@PayMentReqID", "");
                                //cmd.Parameters.AddWithValue("@Exp_id", "0");
                                //cmd.Parameters.AddWithValue("@BelongTo", "Staff Expenses");
                            }
                            else

                            {
                                cmd2.Parameters.AddWithValue("@OfficeID", "");
                                cmd2.Parameters.AddWithValue("@SatffExpID", "");
                                cmd2.Parameters.AddWithValue("@ProjectPurID", lblexpid2.Text);
                                cmd2.Parameters.AddWithValue("@PayMentReqID", "");
                                //cmd.Parameters.AddWithValue("@Exp_id", "0");
                                //cmd.Parameters.AddWithValue("@BelongTo", "Project Purchase");
                            }
                            cmd2.Parameters.AddWithValue("@FileName", lblExpensesrFileName1.Text);
                            cmd2.Parameters.AddWithValue("@FilePath", lblFilePath.Text);
                            cmd2.Parameters.AddWithValue("@EmpID", UserId);
                            cmd2.Parameters.AddWithValue("@Designation", Designation);
                            cmd2.Parameters.AddWithValue("@sendBY", lblcreateby.Text);
                            cmd2.Parameters.AddWithValue("@ApprovalBy", UserName);
                            cmd2.Parameters.AddWithValue("@Approval", "True");
                            cmd2.Parameters.AddWithValue("@Extention", Extention);
                            con2.Open();
                            int i = cmd2.ExecuteNonQuery();
                            if (i < 0)
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Payment Approval Item Approved  Successfully!')", true);

                            }
                            else
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Payment Approval  Item Not Approved  Successfully!')", true);
                            }
                            con2.Close();
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

        //File---------------------------------------------------------------------------------------
        public DataTable ViewFileExpensesDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {

                SqlCommand com = new SqlCommand("SP_ViewFileAllExpensesDetails", con1);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);
                if (lblRelatedTo1.Text == "Payment Request")
                {
                    com.Parameters.AddWithValue("@PayRequestID", lblexpid2.Text);

                }
                else if (lblRelatedTo1.Text == "Office Expenses")
                {
                    com.Parameters.AddWithValue("@OfiiceExpID", lblexpid2.Text);


                }
                else if (lblRelatedTo1.Text == "Staff Expenses")
                {

                    com.Parameters.AddWithValue("@StaffExpID", lblexpid2.Text);

                }
                else

                {
                    com.Parameters.AddWithValue("@ProjePurID", lblexpid2.Text);

                }


                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridExpensesFile.DataSource = dt;
                    GridExpensesFile.DataBind();
                    foreach (GridViewRow gridviedrow in GridExpensesFile.Rows)
                    {
                        LinkButton btnDeleteItemCal1 = (LinkButton)gridviedrow.FindControl("btnDeleteExpensesFile");

                        btnDeleteItemCal1.Visible = true;
                    }
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridExpensesFile.DataSource = dt;
                    GridExpensesFile.DataBind();
                    int totalcolums = GridExpensesFile.Rows[0].Cells.Count;
                }
            }
            return table;

        }
        protected void Btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblexpid2.Text == "" && lblExpName.Text == "")
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

                        string ExpName = Convert.ToString(lblExpName.Text);
                        using (SqlConnection con = new SqlConnection(strconnect))
                        {
                            SqlCommand cmd = new SqlCommand("SP_UploadExpensesAttachmentFile", con);
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                            cmd.Parameters.AddWithValue("@Exp_id", "0");
                            cmd.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);
                            if (lblRelatedTo1.Text == "Payment Request")
                            {
                                cmd.Parameters.AddWithValue("@OfficeID", "0");
                                cmd.Parameters.AddWithValue("@SatffExpID", "0");
                                cmd.Parameters.AddWithValue("@ProjectPurID", "0");
                                cmd.Parameters.AddWithValue("@PayMentReqID", lblexpid2.Text);

                            }
                            else if (lblRelatedTo1.Text == "Office Expenses")
                            {
                                cmd.Parameters.AddWithValue("@OfficeID", lblexpid2.Text);
                                cmd.Parameters.AddWithValue("@SatffExpID", "0");
                                cmd.Parameters.AddWithValue("@ProjectPurID", "0");
                                cmd.Parameters.AddWithValue("@PayMentReqID", "0");


                            }
                            else if (lblRelatedTo1.Text == "Staff Expenses")
                            {
                                cmd.Parameters.AddWithValue("@OfficeID", "0");
                                cmd.Parameters.AddWithValue("@SatffExpID", lblexpid2.Text);
                                cmd.Parameters.AddWithValue("@ProjectPurID", "0");
                                cmd.Parameters.AddWithValue("@PayMentReqID", "0");

                            }
                            else

                            {
                                cmd.Parameters.AddWithValue("@OfficeID", "0");
                                cmd.Parameters.AddWithValue("@StaffExpID", "0");
                                cmd.Parameters.AddWithValue("@ProjectPurID", lblexpid2.Text);
                                cmd.Parameters.AddWithValue("@PayMentReqID", "0");

                            }
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
                string ExpName = Convert.ToString(lblExpName.Text);
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_DeleteFileExpenses", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Exp_Name", lblExpName.Text);
                    com.Parameters.AddWithValue("@ID", ExpensesID1);
                    com.Parameters.AddWithValue("@CreatedBy", UserName);
                    com.Parameters.AddWithValue("@EmpID", UserId);
                    com.Parameters.AddWithValue("@Designation", Designation);
                    com.Parameters.AddWithValue("@BelongTo", lblRelatedTo1.Text);

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