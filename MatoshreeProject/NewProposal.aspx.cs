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
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
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
using System.Dynamic;
using Color = System.Drawing.Color;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
//using static MatoshreeProject.ViewLeaveManagement;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using Document = iTextSharp.text.Document;
using PageSize = iTextSharp.text.PageSize;
using iTextSharp.tool.xml.parser.state;
using System.Security.Principal;
using Microsoft.Ajax.Utilities;
using iText.StyledXmlParser.Jsoup.Helper;
#endregion

namespace MatoshreeProject
{
    public partial class NewProposal : System.Web.UI.Page
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
        string UserName, EmailID, Designation, RoleType, Permission, DeptID, CareerID, sendMail, EmpNAME;
        double SubTotal, Discount, DiscountCost, TaxRateTotal, RoundUp;

        string Size, Initial, ReceiptFor, Cash, Bank, reminder;

        string Day = Convert.ToString(DateTime.Today.Day);
        string year = Convert.ToString(DateTime.Today.Year);
        string Month = Convert.ToString(DateTime.Today.Month);
        // Phrase phrase = null;


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
        public void BindStatusDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetStatusname", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BelongTo", "Proposal");
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

        public string GETReceiptINITIAL()
        {
            SqlConnection conn = new SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand("SP_GeReceriptInitial", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReceiptFor", "Proposal");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ReceiptFor = dt.Rows[0]["ReceiptFor"].ToString();
                Initial = dt.Rows[0]["Initial"].ToString();
                Size = dt.Rows[0]["size"].ToString();
                lblInitialNumber.Text = year + "-" + Day + ":";
                Initial = lblInitialNumber.Text + Initial;

            }
            return generateOrderNo(Initial, long.Parse(Size));
        }

        public void Calculatefilldata()
        {
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                SqlCommand com = new SqlCommand("SP_GetProposalByCal", con1);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ProposalNumber", txtProposalNumber.Text);
                com.Parameters.AddWithValue("@RelatedTo", ddlRelated.SelectedItem.Text);
                com.Parameters.AddWithValue("@RelatedID", ddlRelatedToCast.SelectedItem.Value);

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridProposal.DataSource = dt;
                    GridProposal.DataBind();

                    //Get the row that contains this button

                    foreach (GridViewRow gridviedrow in GridProposal.Rows)
                    {
                        //Label lblRowNumber = (Label)gridviedrow.FindControl("lblRowNumber");
                        Label lblHSN1 = (Label)gridviedrow.FindControl("lblHSN1");
                        Label lblItem1 = (Label)gridviedrow.FindControl("lblItem1");
                        Label lblDescription1 = (Label)gridviedrow.FindControl("lblDescription1");
                        TextBox txtQantity1 = (TextBox)gridviedrow.FindControl("txtQty1");
                        TextBox txtRate1 = (TextBox)gridviedrow.FindControl("txtRate1");
                        DropDownList ddlTaxCost = (DropDownList)gridviedrow.FindControl("ddlTaxCost");
                        DropDownList ddlTaxCost1A = (DropDownList)gridviedrow.FindControl("ddlTaxCost1A");
                        Label lblSubAmont1 = (Label)gridviedrow.FindControl("lblSubAmont1");
                        Label lblTax1Rate1 = (Label)gridviedrow.FindControl("lblTax1Rate1");
                        Label lblTax2Rate1 = (Label)gridviedrow.FindControl("lblTax2Rate1");
                        Label lblAmont1 = (Label)gridviedrow.FindControl("lblAmount1");
                        Label lblItemID1 = (Label)gridviedrow.FindControl("lblItemID1");
                        LinkButton btnDeleteItemCal1 = (LinkButton)gridviedrow.FindControl("btnDeleteItemCal");

                        lblDescription1.Visible = true;
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
                        //lblItemID1.Visible = true;
                        lblItem1.Visible = true;
                    }
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridProposal.DataSource = dt;
                    GridProposal.DataBind();
                    int totalcolums = GridProposal.Rows[0].Cells.Count;

                    SuccessDiv1.Visible = false;
                    lblMsg.Visible = false;
                    lblMsg1.Visible = false;
                    msgdiv.Visible = false;
                }
                SubTotalSum();
                DiscountCount();
                //SubCostTotalInvoiceAmont();
                //GetTaxlistCalculation();
                //string Invoice = txtInvoiceNumber.Text;
                //GetItemTax(Invoice); // Sum Total Item Tax               
                //TotalInvoiceCost();//Total Calculation For Invoice 
            }
        }

        public void Clear()
        {
            try
            {
                txtProposalNumber.Text = string.Empty;
                txtSubject.Text = string.Empty;
                txtDate.Text = string.Empty;
                ddlRelated.SelectedIndex = 0;
                ddlRelatedToCast.SelectedIndex = 0;
                ddlProject.SelectedIndex = 0;
                txtOpenTill.Text = string.Empty;
                ddlCurrency.SelectedIndex = 0;
                ddlDiscountType.SelectedIndex = 0;
                ddlStatus.SelectedIndex = 0;
                ddlAssigned.SelectedIndex = 0;
                txtTo.Text = string.Empty;
                txtAddress.Text = string.Empty;
                ddlCountry.SelectedIndex = 0;
                ddlState.SelectedIndex = 0;
                ddlDistrict.SelectedIndex = 0;
                ddlCity.SelectedIndex = 0;
                txtZipCode.Text = string.Empty;

                txtPhone.Text = string.Empty;
                txtEmail.Text = string.Empty;
                //ddlCatTypeModal.SelectedIndex = 0;
                lblSubTotalCost.Text = string.Empty;
                txtDiscount1.Text = string.Empty;
                lblDiscountCost.Text = string.Empty;
                listTaxNames1.Items.Clear();
                listTaxValues1.Items.Clear();
                TxtAdjustment1.Text = string.Empty;
                lblAdjustmentCost.Text = string.Empty;
                lbltotalAmonutProposalCost.Text = string.Empty;
                
                Calculatefilldata();
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
                    ddlState.DataSource = ds.Tables[0];
                    ddlState.DataTextField = "State_Name";
                    ddlState.DataValueField = "ID";
                    ddlState.DataBind();
                    ddlState.Items.Insert(0, new ListItem("Select State", "0"));

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
                    ddlDistrict.DataSource = ds.Tables[0];
                    ddlDistrict.DataTextField = "Disttrict_Name";
                    ddlDistrict.DataValueField = "District_ID";
                    ddlDistrict.DataBind();
                    ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));
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
                    ddlCity.DataSource = ds.Tables[0];
                    ddlCity.DataTextField = "City";
                    ddlCity.DataValueField = "ID";
                    ddlCity.DataBind();
                    ddlCity.Items.Insert(0, new ListItem("Select City", "0"));
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
        public void GetLeadDetailsByID()
        {
            //try
            //{
            //    using (SqlConnection UserCon = new SqlConnection(strconnect))
            //    {

            //        SqlCommand cmd = new SqlCommand("SP_GetLeadDetailsByID", UserCon);
            //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //        cmd.Parameters.AddWithValue("@Id", lblLeadIdd.Text);
            //        DataTable dt = new DataTable();
            //        sda.Fill(dt);
            //        if (dt.Rows.Count > 0)
            //        {
            //            txtTo.Text = dt.Rows[0]["Name"].ToString();
            //            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            //            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            //            ddlState.SelectedItem.Text = dt.Rows[0]["State"].ToString();
            //            ddlCountry.SelectedItem.Text = dt.Rows[0]["Country"].ToString();
            //            txtPhone.Text = dt.Rows[0]["Phone"].ToString();
            //            txtZipCode.Text = dt.Rows[0]["ZipCode"].ToString();
            //            ddlState.SelectedItem.Text = dt.Rows[0]["State"].ToString();
            //            ddlState.SelectedItem.Value = dt.Rows[0]["State"].ToString();
            //            ddldistrict.SelectedItem.Text = dt.Rows[0]["District"].ToString();
            //            ddlcity.SelectedItem.Text = dt.Rows[0]["City"].ToString();

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    using (SqlConnection DeviceCon = new SqlConnection(strconnect))
            //    {
            //        string ErrorMessgage = ex.Message;
            //        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
            //        string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
            //        string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
            //        Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
            //        SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
            //        cmdex.CommandType = CommandType.StoredProcedure;
            //        cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
            //        cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
            //        cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
            //        cmdex.Parameters.AddWithValue("@Method", method);
            //        cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
            //        DeviceCon.Open();
            //        int RowEx = cmdex.ExecuteNonQuery();
            //        if (RowEx < 0)
            //        {
            //            //lblMessage.Visible = false;
            //            //lblMessage.Text = "Error Details Save Successfully";
            //        }
            //        else
            //        {
            //            //lblMessage.Visible = false;
            //            //lblMessage.Text = "Error Details Not Save Successfully";
            //        }
            //    }
            //}
            //finally
            //{
            //}
        }

        public void getcitybydistrictid2(int distrctid)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetcitybyDistrictid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@District_ID", distrctid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlCity.DataSource = ds.Tables[0];
                    ddlCity.DataTextField = "City";
                    ddlCity.DataValueField = "ID";
                    ddlCity.DataBind();
                    ddlCity.Items.Insert(0, new ListItem("Select City Name", "0"));
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
        public void getdistrictbystateId1(int stateid)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetDistrictbyStateid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@State_ID", stateid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlDistrict.DataSource = ds.Tables[0];
                    ddlDistrict.DataTextField = "Disttrict_Name";
                    ddlDistrict.DataValueField = "District_ID";
                    ddlDistrict.DataBind();
                    ddlDistrict.Items.Insert(0, new ListItem("Select District Name", "0"));
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
        public void Clear1()
        {
            txt_LongDescription.Text = string.Empty;
            txt_Description.Text = string.Empty;
            txt_Rate.Text = string.Empty;
            txtHSNCode.Text = string.Empty;
            ddlTaxitem.SelectedIndex = 0;
            ddlTaxItem1.SelectedIndex = 0;
        }

        public void SubTotalSum()
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd1 = new SqlCommand("SP_GetProposalSubTotalSum", UserCon);
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                    cmd1.Parameters.AddWithValue("@ProposalNumber", txtProposalNumber.Text);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        lblSubTotalCost.Text = dt1.Rows[0]["SubTotal"].ToString();
                        SubTotal = Convert.ToDouble(lblSubTotalCost.Text);
                    }
                    else
                    {
                        lblSubTotalCost.Text = "₹0.00";
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

        public void DiscountCount()
        {
            try
            {
                Discount = Convert.ToDouble(txtDiscount1.Text);
                SubTotal = Convert.ToDouble(lblSubTotalCost.Text);
                if (Discount > 0)
                {
                    if (ddlDiscountCost.SelectedItem.Value == "%")
                    {
                        DiscountCost = (SubTotal * Discount) / 100;
                        double roundedMonthSal = Math.Round(DiscountCost, 2);
                        lblDiscountCost.Text = Convert.ToString(roundedMonthSal);
                    }
                    else if (ddlDiscountCost.SelectedItem.Value == "Fixed Amount")
                    {
                        lblDiscountCost.Text = txtDiscount1.Text;
                    }
                }
                else
                {
                    lblDiscountCost.Text = "₹0.00";
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

        public void RoundUpCount()
        {
            try
            {
                double DiscountCost = Convert.ToDouble(lblDiscountCost.Text);
                double Adjustment1 = Convert.ToDouble(TxtAdjustment1.Text);
                if (Adjustment1 > 0)
                {
                    RoundUp = Adjustment1 + DiscountCost;
                    double roundedSal = Math.Round(RoundUp, 2);
                    lblAdjustmentCost.Text = Convert.ToString(roundedSal);
                }
                else
                {
                    lblAdjustmentCost.Text = "₹0.00";
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

        public void GetTaxlistCalculationPROPOSAL()
        {
            try
            {
                listTaxNames1.Visible = true;
                listTaxValues1.Visible = true;
                using (SqlConnection conn2 = new SqlConnection(strconnect))
                {
                    double SubbTotal = Convert.ToDouble(lblSubTotalCost.Text);
                    double Discount1 = Convert.ToDouble(lblDiscountCost.Text);
                    string Taxname, Taxper, TaxAmountCost;
                    SqlCommand cmd2 = new SqlCommand("SP_TaxCalProposalItem", conn2);
                    cmd2.Connection = conn2;
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@ProposalNumber", txtProposalNumber.Text);
                    cmd2.Parameters.AddWithValue("@RealtedID", ddlRelatedToCast.SelectedItem.Value);
                    cmd2.Parameters.AddWithValue("@RelatedTo", ddlRelated.SelectedItem.Text);

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
                                    SqlCommand cmdtax = new SqlCommand("SP_GetCountTaxNameProposal", contax);
                                    cmdtax.Connection = contax;
                                    cmdtax.CommandType = CommandType.StoredProcedure;
                                    cmdtax.Parameters.AddWithValue("@ProposalNumber", txtProposalNumber.Text);
                                    cmdtax.Parameters.AddWithValue("@RealtedID", ddlRelatedToCast.SelectedItem.Value);
                                    cmdtax.Parameters.AddWithValue("@RelatedTo", ddlRelated.SelectedItem.Text);
                                    cmdtax.Parameters.AddWithValue("@TaxName", Taxname);

                                    SqlDataAdapter sdatax = new SqlDataAdapter(cmdtax);
                                    DataTable dttax = new DataTable();
                                    sdatax.Fill(dttax);
                                    if (dttax.Rows.Count > 0)
                                    {
                                        TaXcount = Convert.ToInt32(dttax.Rows[0]["TAXCountByName"]);
                                        lblTAxCount.Text = Convert.ToString(dttax.Rows[0]["TAXCountByName"]);
                                    }
                                    else
                                    {
                                        TaXcount = Convert.ToInt32(dttax.Rows[0]["TAXCountByName"]);
                                        lblTAxCount.Text = Convert.ToString(dttax.Rows[0]["TAXCountByName"]);
                                    }
                                }

                                using (SqlConnection contax2 = new SqlConnection(strconnect))
                                {
                                    SqlCommand cmdtax2 = new SqlCommand("SP_GetCountTaxName2Proposal", contax2);
                                    cmdtax2.Connection = contax2;
                                    cmdtax2.CommandType = CommandType.StoredProcedure;
                                    cmdtax2.Parameters.AddWithValue("@ProposalNumber", txtProposalNumber.Text);
                                    cmdtax2.Parameters.AddWithValue("@RealtedID", ddlRelatedToCast.SelectedItem.Value);
                                    cmdtax2.Parameters.AddWithValue("@RelatedTo", ddlRelated.SelectedItem.Text);
                                    cmdtax2.Parameters.AddWithValue("@TaxName", Taxname);
                                    SqlDataAdapter sdatax2 = new SqlDataAdapter(cmdtax2);
                                    DataTable dttax2 = new DataTable();
                                    sdatax2.Fill(dttax2);
                                    if (dttax2.Rows.Count > 0)
                                    {
                                        TaXcount2 = Convert.ToInt32(dttax2.Rows[0]["TAXCountByName"]);
                                        lblTAXCount2.Text = Convert.ToString(dttax2.Rows[0]["TAXCountByName"]);
                                    }
                                    else
                                    {
                                        TaXcount2 = Convert.ToInt32(dttax2.Rows[0]["TAXCountByName"]);
                                        lblTAXCount2.Text = Convert.ToString(dttax2.Rows[0]["TAXCountByName"]);
                                    }
                                }

                                TotalTaxCount = TaXcount2 + TaXcount;

                                Double PROPOSALTOTALAMONT1 = (SubbTotal - Discount1);

                                string propTotal = Convert.ToString(PROPOSALTOTALAMONT1);
                                string SubProp = Convert.ToString(SubbTotal);
                                string DicProp = Convert.ToString(Discount1);
                                Double TaxPerCount = TaxAmountPER * TotalTaxCount;
                                Double TaxAmountP1 = (PROPOSALTOTALAMONT1 * TaxPerCount) / 100;

                                decimal TaxAmountP11 = Convert.ToDecimal(TaxAmountP1);
                                decimal totalTaxAmountP11 = decimal.Round(TaxAmountP11, 2);
                                TaxAmountP1 = Convert.ToDouble(totalTaxAmountP11);

                                TaxAmount = TaxAmountP1;
                                TaxAmountCost = Convert.ToString(TaxAmount);

                                DataRow newRow1 = Taxdt.NewRow();
                                newRow1["TaxValesPer"] = TaxAmountCost;
                                Taxdt.Rows.Add(newRow1);

                            }

                            listTaxValues1.DataSource = Taxdt;
                            listTaxValues1.DataTextField = "TaxValesPer";
                            listTaxValues1.DataValueField = "TaxValesPer";
                            listTaxValues1.DataBind();
                            Taxdt.Clear();
                            TaxPerTotal();
                            GrandTotal();



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
                                    SqlCommand cmdtax = new SqlCommand("SP_GetCountTaxNameProposal", contax);
                                    cmdtax.Connection = contax;
                                    cmdtax.CommandType = CommandType.StoredProcedure;
                                    cmdtax.Parameters.AddWithValue("@ProposalNumber", txtProposalNumber.Text);
                                    cmdtax.Parameters.AddWithValue("@RealtedID", ddlRelatedToCast.SelectedItem.Value);
                                    cmdtax.Parameters.AddWithValue("@RelatedTo", ddlRelated.SelectedItem.Text);
                                    cmdtax.Parameters.AddWithValue("@TaxName", Taxname);

                                    SqlDataAdapter sdatax = new SqlDataAdapter(cmdtax);
                                    DataTable dttax = new DataTable();
                                    sdatax.Fill(dttax);
                                    if (dttax.Rows.Count > 0)
                                    {
                                        TaXcount = Convert.ToInt32(dttax.Rows[0]["TAXCountByName"]);
                                        lblTAxCount.Text = Convert.ToString(dttax.Rows[0]["TAXCountByName"]);
                                    }
                                    else
                                    {
                                        TaXcount = Convert.ToInt32(dttax.Rows[0]["TAXCountByName"]);
                                        lblTAxCount.Text = Convert.ToString(dttax.Rows[0]["TAXCountByName"]);
                                    }
                                }



                                using (SqlConnection contax2 = new SqlConnection(strconnect))
                                {
                                    SqlCommand cmdtax2 = new SqlCommand("SP_GetCountTaxName2Proposal", contax2);
                                    cmdtax2.Connection = contax2;
                                    cmdtax2.CommandType = CommandType.StoredProcedure;
                                    cmdtax2.Parameters.AddWithValue("@ProposalNumber", txtProposalNumber.Text);
                                    cmdtax2.Parameters.AddWithValue("@RealtedID", ddlRelatedToCast.SelectedItem.Value);
                                    cmdtax2.Parameters.AddWithValue("@RelatedTo", ddlRelated.SelectedItem.Text);
                                    cmdtax2.Parameters.AddWithValue("@TaxName", Taxname);
                                    SqlDataAdapter sdatax2 = new SqlDataAdapter(cmdtax2);
                                    DataTable dttax2 = new DataTable();
                                    sdatax2.Fill(dttax2);
                                    if (dttax2.Rows.Count > 0)
                                    {
                                        TaXcount2 = Convert.ToInt32(dttax2.Rows[0]["TAXCountByName"]);
                                        lblTAXCount2.Text = Convert.ToString(dttax2.Rows[0]["TAXCountByName"]);
                                    }
                                    else
                                    {
                                        TaXcount2 = Convert.ToInt32(dttax2.Rows[0]["TAXCountByName"]);
                                        lblTAXCount2.Text = Convert.ToString(dttax2.Rows[0]["TAXCountByName"]);
                                    }
                                }

                                TotalTaxCount = TaXcount2 + TaXcount;


                                Double PrposalTOTALAMONT1 = (SubbTotal - Discount1);

                                string invTotal = Convert.ToString(PrposalTOTALAMONT1);
                                string SubInv = Convert.ToString(SubbTotal);
                                string DicInv = Convert.ToString(Discount);
                                Double TaxPERCount = TaxAmountPER * TotalTaxCount;
                                Double TaxAmount1 = (PrposalTOTALAMONT1 * TaxPERCount) / 100;

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
                            TaxPerTotal();
                            GrandTotal();
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

        public void TaxPerTotal()
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd1 = new SqlCommand("SP_TaxProposalItemTotal", UserCon);
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                    cmd1.Parameters.AddWithValue("@ProposalNumber", txtProposalNumber.Text);
                    cmd1.Parameters.AddWithValue("@RealtedID", ddlRelatedToCast.SelectedItem.Value);
                    cmd1.Parameters.AddWithValue("@RelatedTo", ddlRelated.SelectedItem.Text);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        lblTaxRateTotal.Text = dt1.Rows[0]["TotalTaxItem"].ToString();

                        TaxRateTotal = Convert.ToDouble(lblTaxRateTotal.Text);

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

        public void GrandTotal()
        {
            try
            {
                double SubDis = SubTotal - Discount;
                double TotalTaxAmount = SubDis * TaxRateTotal / 100;
                lbltaxTotalAmont.Text = Convert.ToString(TotalTaxAmount);
                double GrandTotal = SubDis + TaxRateTotal + RoundUp;
                double roundedGrd = Math.Round(GrandTotal, 2);
                lbltotalAmonutProposalCost.Text = Convert.ToString(roundedGrd);
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

        #region " Private Functions "

        private string generateOrderNo(string code, long id)
        {
            string oID = code;
            string space = "-";
            oID += space + id.ToString("00000");
            //oID += idWalletTransaction.ToString("0000000");
            return oID;
        }

        #endregion

        #region " Protected Functions "
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
                    ddlAssigned.DataSource = ds.Tables[0];
                    ddlAssigned.DataTextField = "First_Name";
                    ddlAssigned.DataValueField = "Staff_ID";
                    ddlAssigned.DataBind();
                    ddlAssigned.Items.Insert(0, new ListItem("Select Sale Agent", "0"));
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

        protected void ddlTaxItem1_SelectedIndexChanged1(object sender, EventArgs e)
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

        protected void ddlTaxitem_SelectedIndexChanged(object sender, EventArgs e)
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


        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ItemID = Convert.ToInt32(ddlItem.SelectedValue);

                TextBox txtItem = (TextBox)GridProposal.FooterRow.FindControl("txtItem");
                TextBox txtDescription = (TextBox)GridProposal.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridProposal.FooterRow.FindControl("txtQty");
                TextBox txtRate = (TextBox)GridProposal.FooterRow.FindControl("txtRate");
                DropDownList ddlTax = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax");
                DropDownList ddlTax1A = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax1A");
                TextBox txtTax1Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax1Rate1F");
                TextBox txtTax2Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax2Rate1F");
                Label lblTaxValees1AF = (Label)GridProposal.FooterRow.FindControl("lblTaxValees1AF");
                Label lblTaxValeesF = (Label)GridProposal.FooterRow.FindControl("lblTaxValeesF");
                Label lblHSN = (Label)GridProposal.FooterRow.FindControl("lblHSN");
                Label lblSubAmont1F = (Label)GridProposal.FooterRow.FindControl("lblSubAmont1F");
                Label lblProposalAmont = (Label)GridProposal.FooterRow.FindControl("lblProposalAmont");
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
                        lblProposalAmont.Text = Convert.ToString(GrandTotal);

                    }
                }

                //SubCostTotalInvoiceAmont(); // SubCost Total OF Item
                //GetTaxlistCalculation(); // Total Cost per of Item price 
                //TotalInvoiceCost();//Total Calculation For Invoice 
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

                            BindStatusDetails();
                            bindStaff();
                            GETReceiptINITIAL();
                            //Calculatefilldata();
                            BindStateDetails();
                            BindDistrictDetails();
                            BindCityDetails();
                            bindItem();
                            bindTax();
                            string ReceiptNumner = GETReceiptINITIAL();
                            txtProposalNumber.Text = ReceiptNumner;
                            string Todaydate = Convert.ToString(DateTime.Today);
                            string WeekDate = Convert.ToString(DateTime.Today.AddDays(7));

                            txtDate.Attributes["value"] = DateTime.Parse(Todaydate.ToString()).ToString("yyyy-MM-dd");
                            txtOpenTill.Attributes["value"] = DateTime.Parse(WeekDate.ToString()).ToString("yyyy-MM-dd");
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
                                BindStatusDetails();
                                bindStaff();
                                GETReceiptINITIAL();
                                //Calculatefilldata();
                                BindStateDetails();
                                BindDistrictDetails();
                                BindCityDetails();
                                bindItem();
                                bindTax();
                                string ReceiptNumner = GETReceiptINITIAL();
                                txtProposalNumber.Text = ReceiptNumner;
                                string Todaydate = Convert.ToString(DateTime.Today);
                                string WeekDate = Convert.ToString(DateTime.Today.AddDays(7));

                                txtDate.Attributes["value"] = DateTime.Parse(Todaydate.ToString()).ToString("yyyy-MM-dd");
                                txtOpenTill.Attributes["value"] = DateTime.Parse(WeekDate.ToString()).ToString("yyyy-MM-dd");
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

        //--------------------------Footer Templete----------------------------------//
        protected void ddlRelated_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LeadProposal.Visible = true;
                if (ddlRelated.SelectedValue == "1")
                {
                    lblLead.Text = "Lead";
                    LeadProposal.Visible = true;
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetProposalLeadName", con);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        ddlRelatedToCast.DataSource = dt;
                        ddlRelatedToCast.DataTextField = "Name";
                        ddlRelatedToCast.DataValueField = "Id";
                        ddlRelatedToCast.DataBind();
                        ddlRelatedToCast.Items.Insert(0, new ListItem("Select Lead Name", "0"));
                    }
                }
                else if (ddlRelated.SelectedValue == "2")
                {
                    lblLead.Text = "Customer";
                    projectProposal.Visible = true;
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {

                        SqlCommand cmd = new SqlCommand("SP_GetCustomerName", con);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        ddlRelatedToCast.DataSource = dt;
                        ddlRelatedToCast.DataTextField = "Cust_Name";
                        ddlRelatedToCast.DataValueField = "Cust_ID";
                        ddlRelatedToCast.DataBind();
                        ddlRelatedToCast.Items.Insert(0, new ListItem("Select Customer Name", "0"));
                    }
                }
                else
                {
                    ddlRelatedToCast.Items.Insert(0, new ListItem("Nothing Selected", "0"));
                    LeadProposal.Visible = false;
                    projectProposal.Visible = false;
                }
                //Calculatefilldata();
                bindProject();
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

        protected void ddlRelatedToCast_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LeadProposal.Visible = true;
                string ddlRelatedToCast1 = ddlRelated.SelectedItem.Text;
                string ddlValue1 = ddlRelated.SelectedItem.Value;

                int RelatedID = Convert.ToInt32(ddlRelatedToCast.SelectedItem.Value);
                string RealtedValues = Convert.ToString(ddlRelatedToCast.SelectedItem.Text);
                if (ddlRelatedToCast1 == "Lead")
                {
                    projectProposal.Visible = false;
                    lblLead.Text = "Lead";

                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd1 = new SqlCommand("SP_GetLeadProposalDetails", UserCon);
                        cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                        cmd1.Parameters.AddWithValue("@Id", RelatedID);
                        DataTable dt1 = new DataTable();
                        sda1.Fill(dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            txtTo.Text = dt1.Rows[0]["Name"].ToString();
                            txtAddress.Text = dt1.Rows[0]["Address"].ToString();
                            txtEmail.Text = dt1.Rows[0]["Email"].ToString();
                            ddlState.SelectedItem.Text = dt1.Rows[0]["State"].ToString();
                            ddlCountry.SelectedItem.Text = dt1.Rows[0]["Country"].ToString();
                            txtPhone.Text = dt1.Rows[0]["Phone"].ToString();
                            txtZipCode.Text = dt1.Rows[0]["ZipCode"].ToString();
                            ddlDistrict.SelectedItem.Text = dt1.Rows[0]["District"].ToString();
                            ddlCity.SelectedItem.Text = dt1.Rows[0]["City"].ToString();
                        }
                    }
                }
                else if (ddlRelatedToCast1 == "Customer")
                {
                    lblLead.Text = "Customer";
                    projectProposal.Visible = true;

                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd1 = new SqlCommand("SP_GetcustomerProposalDetails", UserCon);
                        cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                        cmd1.Parameters.AddWithValue("@Cust_ID", RelatedID);
                        DataTable dt1 = new DataTable();
                        sda1.Fill(dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            txtTo.Text = dt1.Rows[0]["Cust_Name"].ToString();
                            txtAddress.Text = dt1.Rows[0]["Address"].ToString();
                            txtEmail.Text = dt1.Rows[0]["Cust_Email"].ToString();
                            ddlState.SelectedItem.Text = dt1.Rows[0]["Add_State"].ToString();
                            ddlCountry.SelectedItem.Text = dt1.Rows[0]["Add_Country"].ToString();
                            txtPhone.Text = dt1.Rows[0]["Cust_phone"].ToString();
                            txtZipCode.Text = dt1.Rows[0]["Add_PinCode"].ToString();
                            ddlDistrict.SelectedItem.Text = dt1.Rows[0]["Add_District"].ToString();
                            ddlCity.SelectedItem.Text = dt1.Rows[0]["Add_City"].ToString();
                            //int stateid = Convert.ToInt32(ddlState.SelectedItem.Value);
                            //getdistrictbystateId1(stateid);
                            //int districtid = Convert.ToInt32(ddlDistrict.SelectedItem.Value);
                            //getcitybydistrictid2(districtid);


                        }
                    }


                    using (SqlConnection conn = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetProjectNamebycustomerID", conn);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustID", RelatedID);
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
                }
                else
                {

                }

                Calculatefilldata();
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

        protected void GridProposal_RowDataBound(object sender, GridViewRowEventArgs e)
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
                            //*//---------------------------------------------------------------//*//
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

                //SubCostTotalInvoiceAmont(); // SubCost of Item                            
                //GetTaxlistCalculation(); // Total Cost per of Item price     

                //string Invoice = txtInvoiceNumber.Text;
                //GetItemTax(Invoice); // Sum Total Item Tax               
                //TotalInvoiceCost();//Total Calculation For Invoice 
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
                TextBox txtItem = (TextBox)GridProposal.FooterRow.FindControl("txtItem");
                TextBox txtDescription = (TextBox)GridProposal.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridProposal.FooterRow.FindControl("txtQty");
                TextBox txtRate = (TextBox)GridProposal.FooterRow.FindControl("txtRate");
                DropDownList ddlTax = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax");
                DropDownList ddlTax1A = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax1A");
                TextBox txtTax1Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax1Rate1F");
                TextBox txtTax2Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax2Rate1F");
                Label lblTaxValees1AF = (Label)GridProposal.FooterRow.FindControl("lblTaxValees1AF");
                Label lblTaxValeesF = (Label)GridProposal.FooterRow.FindControl("lblTaxValeesF");
                Label lblHSN = (Label)GridProposal.FooterRow.FindControl("lblHSN");
                Label lblSubAmont1F = (Label)GridProposal.FooterRow.FindControl("lblSubAmont1F");
                Label lblProposalAmont = (Label)GridProposal.FooterRow.FindControl("lblProposalAmont");

                Double SubTotal, TotalAmountTax1, TotalAmountTax2, GrandTotal;

                SubTotal = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text);

                lblSubAmont1F.Text = Convert.ToString(SubTotal);

                TotalAmountTax1 = SubTotal * Convert.ToDouble(lblTaxValeesF.Text) / 100;
                TotalAmountTax2 = SubTotal * Convert.ToDouble(lblTaxValees1AF.Text) / 100;

                txtTax1Rate1F.Text = Convert.ToString(TotalAmountTax1);
                txtTax2Rate1F.Text = Convert.ToString(TotalAmountTax2);
                GrandTotal = SubTotal + TotalAmountTax1 + TotalAmountTax2;

                lblProposalAmont.Text = Convert.ToString(GrandTotal);

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

        protected void txtRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtItem = (TextBox)GridProposal.FooterRow.FindControl("txtItem");
                TextBox txtDescription = (TextBox)GridProposal.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridProposal.FooterRow.FindControl("txtQty");
                TextBox txtRate = (TextBox)GridProposal.FooterRow.FindControl("txtRate");
                DropDownList ddlTax = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax");
                DropDownList ddlTax1A = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax1A");
                TextBox txtTax1Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax1Rate1F");
                TextBox txtTax2Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax2Rate1F");
                Label lblTaxValees1AF = (Label)GridProposal.FooterRow.FindControl("lblTaxValees1AF");
                Label lblTaxValeesF = (Label)GridProposal.FooterRow.FindControl("lblTaxValeesF");
                Label lblHSN = (Label)GridProposal.FooterRow.FindControl("lblHSN");
                Label lblSubAmont1F = (Label)GridProposal.FooterRow.FindControl("lblSubAmont1F");
                Label lblProposalAmont = (Label)GridProposal.FooterRow.FindControl("lblProposalAmont");

                Double SubTotal, TotalAmountTax1, TotalAmountTax2, GrandTotal;

                SubTotal = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text);

                lblSubAmont1F.Text = Convert.ToString(SubTotal);

                TotalAmountTax1 = SubTotal * Convert.ToDouble(lblTaxValeesF.Text) / 100;
                TotalAmountTax2 = SubTotal * Convert.ToDouble(lblTaxValees1AF.Text) / 100;

                txtTax1Rate1F.Text = Convert.ToString(TotalAmountTax1);
                txtTax2Rate1F.Text = Convert.ToString(TotalAmountTax2);
                GrandTotal = SubTotal + TotalAmountTax1 + TotalAmountTax2;

                lblProposalAmont.Text = Convert.ToString(GrandTotal);
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
        protected void btn_SubmitProposal_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SqlConnection con = new SqlConnection(strconnect);  // db connect
                    SqlCommand cmd = new SqlCommand("SP_SaveNewProposal", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProposalNo", txtProposalNumber.Text);
                    cmd.Parameters.AddWithValue("@Subject", txtSubject.Text);
                    cmd.Parameters.AddWithValue("@RelatedID", ddlRelatedToCast.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@RelatedTo", ddlRelated.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@RelatedName", ddlRelatedToCast.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@ProjectID", ddlProject.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@ProjectName", ddlProject.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@ProDate", txtDate.Text);
                    cmd.Parameters.AddWithValue("@ProOpenTillDate", txtOpenTill.Text);
                    cmd.Parameters.AddWithValue("@Currency", ddlCurrency.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@DiscountType", ddlDiscountType.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@AssignBy", ddlAssigned.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@AssignByID", ddlAssigned.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@To", txtTo.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@AddCity", ddlCity.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@AddState", ddlState.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Zipcode", txtZipCode.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@District", ddlDistrict.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@StatusID", ddlStatus.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@StatusName", ddlStatus.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@SubTotal", lblSubTotalCost.Text);
                    cmd.Parameters.AddWithValue("@Discount", lblDiscountCost.Text);
                    cmd.Parameters.AddWithValue("@TotalTax", lbltaxTotalAmont.Text);
                    cmd.Parameters.AddWithValue("@TotalPercentage", lblTaxRateTotal.Text);
                    cmd.Parameters.AddWithValue("@Adjustment", lblAdjustmentCost.Text);
                    cmd.Parameters.AddWithValue("@GrandTotal", lbltotalAmonutProposalCost.Text);
                    cmd.Parameters.AddWithValue("@Createdby", UserName);
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
                        lblMesDelete.Text = "Proposal Details Save Successfully";

                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Proposal Details Not Save Successfully";
                    }

                    Clear();
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

        protected void btnClearProposal_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void ddlTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtItem = (TextBox)GridProposal.FooterRow.FindControl("txtItem");
                TextBox txtDescription = (TextBox)GridProposal.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridProposal.FooterRow.FindControl("txtQty");
                TextBox txtRate = (TextBox)GridProposal.FooterRow.FindControl("txtRate");
                DropDownList ddlTax = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax");
                DropDownList ddlTax1A = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax1A");
                TextBox txtTax1Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax1Rate1F");
                TextBox txtTax2Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax2Rate1F");
                Label lblTaxValees1AF = (Label)GridProposal.FooterRow.FindControl("lblTaxValees1AF");
                Label lblTaxValeesF = (Label)GridProposal.FooterRow.FindControl("lblTaxValeesF");
                Label lblHSN = (Label)GridProposal.FooterRow.FindControl("lblHSN");
                Label lblSubAmont1F = (Label)GridProposal.FooterRow.FindControl("lblSubAmont1F");
                Label lblProposalAmont = (Label)GridProposal.FooterRow.FindControl("lblProposalAmont");

                double SubTotal, TotalAmountTax1, TotalAmountTax2, GrandTotal;

                SubTotal = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text);

                lblSubAmont1F.Text = Convert.ToString(SubTotal);

                TotalAmountTax1 = SubTotal * Convert.ToDouble(lblTaxValeesF.Text) / 100;
                TotalAmountTax2 = SubTotal * Convert.ToDouble(lblTaxValees1AF.Text) / 100;

                txtTax1Rate1F.Text = Convert.ToString(TotalAmountTax1);
                txtTax2Rate1F.Text = Convert.ToString(TotalAmountTax2);
                GrandTotal = SubTotal + TotalAmountTax1 + TotalAmountTax2;

                lblProposalAmont.Text = Convert.ToString(GrandTotal);
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
                TextBox txtItem = (TextBox)GridProposal.FooterRow.FindControl("txtItem");
                TextBox txtDescription = (TextBox)GridProposal.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridProposal.FooterRow.FindControl("txtQty");
                TextBox txtRate = (TextBox)GridProposal.FooterRow.FindControl("txtRate");
                DropDownList ddlTax = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax");
                DropDownList ddlTax1A = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax1A");
                TextBox txtTax1Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax1Rate1F");
                TextBox txtTax2Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax2Rate1F");
                Label lblTaxValees1AF = (Label)GridProposal.FooterRow.FindControl("lblTaxValees1AF");
                Label lblTaxValeesF = (Label)GridProposal.FooterRow.FindControl("lblTaxValeesF");
                Label lblHSN = (Label)GridProposal.FooterRow.FindControl("lblHSN");
                Label lblSubAmont1F = (Label)GridProposal.FooterRow.FindControl("lblSubAmont1F");
                Label lblProposalAmont = (Label)GridProposal.FooterRow.FindControl("lblProposalAmont");

                Double SubTotal, TotalAmountTax1, TotalAmountTax2, GrandTotal;

                SubTotal = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text);

                lblSubAmont1F.Text = Convert.ToString(SubTotal);

                TotalAmountTax1 = SubTotal * Convert.ToDouble(lblTaxValeesF.Text) / 100;
                TotalAmountTax2 = SubTotal * Convert.ToDouble(lblTaxValees1AF.Text) / 100;

                txtTax1Rate1F.Text = Convert.ToString(TotalAmountTax1);
                txtTax2Rate1F.Text = Convert.ToString(TotalAmountTax2);
                GrandTotal = SubTotal + TotalAmountTax1 + TotalAmountTax2;

                lblProposalAmont.Text = Convert.ToString(GrandTotal);
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

        protected void txtTax1Rate1F_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtItem = (TextBox)GridProposal.FooterRow.FindControl("txtItem");
                TextBox txtDescription = (TextBox)GridProposal.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridProposal.FooterRow.FindControl("txtQty");
                TextBox txtRate = (TextBox)GridProposal.FooterRow.FindControl("txtRate");
                DropDownList ddlTax = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax");
                DropDownList ddlTax1A = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax1A");
                TextBox txtTax1Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax1Rate1F");
                TextBox txtTax2Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax2Rate1F");
                Label lblTaxValees1AF = (Label)GridProposal.FooterRow.FindControl("lblTaxValees1AF");
                Label lblTaxValeesF = (Label)GridProposal.FooterRow.FindControl("lblTaxValeesF");
                Label lblHSN = (Label)GridProposal.FooterRow.FindControl("lblHSN");
                Label lblSubAmont1F = (Label)GridProposal.FooterRow.FindControl("lblSubAmont1F");
                Label lblProposalAmont = (Label)GridProposal.FooterRow.FindControl("lblProposalAmont");

                Double SubTotal, TotalAmountTax1, TotalAmountTax2, GrandTotal;

                SubTotal = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text);

                lblSubAmont1F.Text = Convert.ToString(SubTotal);

                TotalAmountTax1 = SubTotal * Convert.ToDouble(lblTaxValeesF.Text) / 100;
                TotalAmountTax2 = SubTotal * Convert.ToDouble(lblTaxValees1AF.Text) / 100;

                txtTax1Rate1F.Text = Convert.ToString(TotalAmountTax1);
                txtTax2Rate1F.Text = Convert.ToString(TotalAmountTax2);
                GrandTotal = SubTotal + TotalAmountTax1 + TotalAmountTax2;

                lblProposalAmont.Text = Convert.ToString(GrandTotal);
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

        protected void txtTax2Rate1F_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtItem = (TextBox)GridProposal.FooterRow.FindControl("txtItem");
                TextBox txtDescription = (TextBox)GridProposal.FooterRow.FindControl("txtDescription");
                TextBox txtQty = (TextBox)GridProposal.FooterRow.FindControl("txtQty");
                TextBox txtRate = (TextBox)GridProposal.FooterRow.FindControl("txtRate");
                DropDownList ddlTax = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax");
                DropDownList ddlTax1A = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax1A");
                TextBox txtTax1Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax1Rate1F");
                TextBox txtTax2Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax2Rate1F");
                Label lblTaxValees1AF = (Label)GridProposal.FooterRow.FindControl("lblTaxValees1AF");
                Label lblTaxValeesF = (Label)GridProposal.FooterRow.FindControl("lblTaxValeesF");
                Label lblHSN = (Label)GridProposal.FooterRow.FindControl("lblHSN");
                Label lblSubAmont1F = (Label)GridProposal.FooterRow.FindControl("lblSubAmont1F");
                Label lblProposalAmont = (Label)GridProposal.FooterRow.FindControl("lblProposalAmont");

                Double SubTotal, TotalAmountTax1, TotalAmountTax2, GrandTotal;

                SubTotal = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text);

                lblSubAmont1F.Text = Convert.ToString(SubTotal);

                TotalAmountTax1 = SubTotal * Convert.ToDouble(lblTaxValeesF.Text) / 100;
                TotalAmountTax2 = SubTotal * Convert.ToDouble(lblTaxValees1AF.Text) / 100;

                txtTax1Rate1F.Text = Convert.ToString(TotalAmountTax1);
                txtTax2Rate1F.Text = Convert.ToString(TotalAmountTax2);
                GrandTotal = SubTotal + TotalAmountTax1 + TotalAmountTax2;

                lblProposalAmont.Text = Convert.ToString(GrandTotal);
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

        protected void btnAddProposalItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {


                    if (ddlRelatedToCast.SelectedIndex == 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Lead or Cusstomer!')", true);
                    }
                    else
                    {
                        string RelatedTo = Convert.ToString(ddlRelatedToCast.SelectedItem.Text);
                        string RelatedID = Convert.ToString(ddlRelatedToCast.SelectedItem.Value);

                        TextBox txtItem = (TextBox)GridProposal.FooterRow.FindControl("txtItem");
                        TextBox txtDescription = (TextBox)GridProposal.FooterRow.FindControl("txtDescription");
                        Label lblHSN = (Label)GridProposal.FooterRow.FindControl("lblHSN");
                        TextBox txtQty = (TextBox)GridProposal.FooterRow.FindControl("txtQty");
                        TextBox txtRate = (TextBox)GridProposal.FooterRow.FindControl("txtRate");
                        Label lblSubAmont1F = (Label)GridProposal.FooterRow.FindControl("lblSubAmont1F");
                        TextBox txtTax1Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax1Rate1F");
                        DropDownList ddlTax = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax");
                        DropDownList ddlTax1A = (DropDownList)GridProposal.FooterRow.FindControl("ddlTax1A");
                        TextBox txtTax2Rate1F = (TextBox)GridProposal.FooterRow.FindControl("txtTax2Rate1F");
                        Label lblProposalAmont = (Label)GridProposal.FooterRow.FindControl("lblProposalAmont");
                        Label lblTaxValeesF = (Label)GridProposal.FooterRow.FindControl("lblTaxValeesF");
                        Label lblTaxValees1AF = (Label)GridProposal.FooterRow.FindControl("lblTaxValees1AF");

                        string TaxRate1 = Convert.ToString(lblTaxValeesF.Text);
                        string TaxRate2 = Convert.ToString(lblTaxValees1AF.Text);

                        using (SqlConnection con = new SqlConnection(strconnect))
                        {
                            SqlCommand cmd = new SqlCommand("SP_SaveProposalItem", con);
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.Parameters.AddWithValue("@ID", txtProposalNumber.Text);
                            cmd.Parameters.AddWithValue("@ProposalNumber", txtProposalNumber.Text);
                            cmd.Parameters.AddWithValue("@ProposalItem", txtItem.Text);
                            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                            cmd.Parameters.AddWithValue("@Qnty", txtQty.Text);
                            cmd.Parameters.AddWithValue("@Rate", txtRate.Text);
                            cmd.Parameters.AddWithValue("@SubTotal", lblSubAmont1F.Text);
                            cmd.Parameters.AddWithValue("@Tax1Name", ddlTax.SelectedItem.Text);
                            cmd.Parameters.AddWithValue("@Tax1Rate", TaxRate1);
                            cmd.Parameters.AddWithValue("@Tax1Amount", txtTax1Rate1F.Text);
                            cmd.Parameters.AddWithValue("@Tax2Name", ddlTax1A.SelectedItem.Text);
                            cmd.Parameters.AddWithValue("@Tax2Rate", TaxRate2);
                            cmd.Parameters.AddWithValue("@Tax2Amount", txtTax2Rate1F.Text);
                            cmd.Parameters.AddWithValue("@TotalAmount", lblProposalAmont.Text);
                            cmd.Parameters.AddWithValue("@RelatedTo", ddlRelated.SelectedItem.Text);
                            cmd.Parameters.AddWithValue("@RelatedID", ddlRelatedToCast.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@HSN", lblHSN.Text);
                            cmd.Parameters.AddWithValue("@CreateBy", UserName);
                            cmd.Parameters.AddWithValue("@UserID", UserId);
                            cmd.Parameters.AddWithValue("@Designation", Designation);
                            cmd.Parameters.AddWithValue("@ItemID", ddlItem.SelectedItem.Value);

                            con.Open();
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                result = dr[0].ToString();
                            }
                            Result = int.Parse(result);

                            if (Result > 0)
                            {
                                Toasteralert.Visible = true;
                                lblMessage.Text = "Proposal Item Save Successfully";
                                Calculatefilldata();
                                SubTotalSum();
                                GrandTotal();
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Proposal Item already Available";

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

        protected void btnDeleteItemCal_Click(object sender, EventArgs e)
        {
            try
            {
                string ID;
                var rows = GridProposal.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ID = ((Label)rows[rowindex].FindControl("lblID")).Text;
                SqlConnection DeviceCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_DeleteProposalItem", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@UserID", UserId);

                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Proposal Item Details Deleted Successfully!')", true);
                    Calculatefilldata();
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Proposal Item Details Not Deleted!')", true);
                }
            }
            catch (Exception ex)
            {
                SqlConnection DeviceCon = new SqlConnection(strconnect);
                string ErrorMessgage = ex.Message;

            }
            finally { }

        }

        //--------------------------Item Templete----------------------------------//
        protected void txtQty1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var rows = GridProposal.Rows;
                DropDownList btnMessage = sender as DropDownList;
                GridViewRow row = (GridViewRow)btnMessage.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                //string RowIndex;
                // Label lblDescription1 = GridCalculate.Rows[rowindex].FindControl("lblDescription1") as Label;
                Label lblItem1 = (Label)GridProposal.Rows[rowindex].FindControl("lblItem1");
                Label lblID = (Label)GridProposal.Rows[rowindex].FindControl("lblID");
                Label lblDescription1 = (Label)GridProposal.Rows[rowindex].FindControl("lblDescription1");
                TextBox txtQty1 = (TextBox)GridProposal.Rows[rowindex].FindControl("txtQty1");
                TextBox txtRate1 = (TextBox)GridProposal.Rows[rowindex].FindControl("txtRate1");
                DropDownList ddlTaxCost = (DropDownList)GridProposal.Rows[rowindex].FindControl("ddlTaxCost");
                DropDownList ddlTaxCost1A = (DropDownList)GridProposal.Rows[rowindex].FindControl("ddlTaxCost1A");
                Label lblTax1Rate1 = (Label)GridProposal.Rows[rowindex].FindControl("lblTax1Rate1");
                Label lblTax2Rate1 = (Label)GridProposal.Rows[rowindex].FindControl("lblTax2Rate1");
                Label lblTaxValees1A = (Label)GridProposal.Rows[rowindex].FindControl("lblTaxValees1A");
                Label lblTaxValees = (Label)GridProposal.Rows[rowindex].FindControl("lblTaxValees");
                Label lblHSN1 = (Label)GridProposal.Rows[rowindex].FindControl("lblHSN1");
                Label lblSubAmont1 = (Label)GridProposal.Rows[rowindex].FindControl("lblSubAmont1");
                Label lblAmount1 = (Label)GridProposal.Rows[rowindex].FindControl("lblAmount1");

                string TaxRateU1 = Convert.ToString(lblTaxValees.Text);
                string TaxRateU2 = Convert.ToString(lblTaxValees1A.Text);

                //----------------------------------------------------------------------//
                Double TaxCost, TaxCost1;
                int TaxID2 = Convert.ToInt32(ddlTaxCost1A.SelectedItem.Value);
                string TaxName1 = ddlTaxCost1A.SelectedItem.Text;
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmdtax1 = new SqlCommand("SP_GetTaxRateByID", conn);
                    cmdtax1.Connection = conn;
                    cmdtax1.CommandType = CommandType.StoredProcedure;
                    cmdtax1.Parameters.AddWithValue("@TaxID", TaxID2);
                    SqlDataAdapter sdatax1 = new SqlDataAdapter(cmdtax1);
                    DataTable dttax1 = new DataTable();
                    sdatax1.Fill(dttax1);
                    if (dttax1.Rows.Count > 0)
                    {
                        string prd = Convert.ToString(dttax1.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dttax1.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dttax1.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dttax1.Rows[0]["Tax_Rate"]);
                    }
                }


                int TaxID = Convert.ToInt32(ddlTaxCost.SelectedItem.Value);
                string TaxName = ddlTaxCost.SelectedItem.Text;
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmdtax2 = new SqlCommand("SP_GetTaxRateByID", conn);
                    cmdtax2.Connection = conn;
                    cmdtax2.CommandType = CommandType.StoredProcedure;
                    cmdtax2.Parameters.AddWithValue("@TaxID", TaxID);
                    SqlDataAdapter sdatax2 = new SqlDataAdapter(cmdtax2);
                    DataTable dttax2 = new DataTable();
                    sdatax2.Fill(dttax2);
                    if (dttax2.Rows.Count > 0)
                    {
                        string prd = Convert.ToString(dttax2.Rows[0]["Tax_Rate"]);
                        TaxCost = Convert.ToDouble(dttax2.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dttax2.Rows[0]["Tax_Rate"]);
                        TaxCost = Convert.ToDouble(dttax2.Rows[0]["Tax_Rate"]);
                    }
                }

                //--------------------------------------------------------------------------------//

                Double SubTotal, TotalAmountTax1, TotalAmountTax2, Grand1Total;

                SubTotal = Convert.ToDouble(txtQty1.Text) * Convert.ToDouble(txtRate1.Text);

                lblSubAmont1.Text = Convert.ToString(SubTotal);

                TotalAmountTax1 = SubTotal * Convert.ToDouble(TaxCost) / 100;
                TotalAmountTax2 = SubTotal * Convert.ToDouble(TaxCost1) / 100;

                lblTax1Rate1.Text = Convert.ToString(TotalAmountTax1);
                lblTax2Rate1.Text = Convert.ToString(TotalAmountTax2);
                Grand1Total = SubTotal + TotalAmountTax1 + TotalAmountTax2;

                lblAmount1.Text = Convert.ToString(Grand1Total);

                ///Using loop Update stoed prosser
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateProposalItem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", lblID.Text);
                cmd.Parameters.AddWithValue("@ProposalNumber", txtProposalNumber.Text);
                cmd.Parameters.AddWithValue("@ProposalItem", lblItem1.Text);
                cmd.Parameters.AddWithValue("@Description", lblDescription1.Text);
                cmd.Parameters.AddWithValue("@Qnty", txtQty1.Text);
                cmd.Parameters.AddWithValue("@Rate", txtRate1.Text);
                cmd.Parameters.AddWithValue("@SubTotal", lblSubAmont1.Text);
                cmd.Parameters.AddWithValue("@Tax1Name", ddlTaxCost.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Tax1Rate", TaxCost);
                cmd.Parameters.AddWithValue("@Tax1Amount", lblTax1Rate1.Text);
                cmd.Parameters.AddWithValue("@Tax2Name", ddlTaxCost1A.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Tax2Rate", TaxCost1);
                cmd.Parameters.AddWithValue("@Tax2Amount", lblTax2Rate1.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", lblAmount1.Text);
                cmd.Parameters.AddWithValue("@RelatedTo", ddlRelated.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@RelatedID", ddlRelatedToCast.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@HSN", lblHSN1.Text);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@UserID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                //cmd.Parameters.AddWithValue("@ItemID", ddlItem.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i < 0)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Proposal Item Quntity Update Successfully";
                    Calculatefilldata();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Proposal Item Quntity not Updated";

                }
                con.Close();
                GridProposal.EditIndex = -1;
                Calculatefilldata();
                SubTotalSum();
                GrandTotal();         
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
                var rows = GridProposal.Rows;
                DropDownList btnMessage = sender as DropDownList;
                GridViewRow row = (GridViewRow)btnMessage.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                //string RowIndex;
                // Label lblDescription1 = GridCalculate.Rows[rowindex].FindControl("lblDescription1") as Label;
                Label lblItem1 = (Label)GridProposal.Rows[rowindex].FindControl("lblItem1");
                Label lblID = (Label)GridProposal.Rows[rowindex].FindControl("lblID");
                Label lblDescription1 = (Label)GridProposal.Rows[rowindex].FindControl("lblDescription1");
                TextBox txtQty1 = (TextBox)GridProposal.Rows[rowindex].FindControl("txtQty1");
                TextBox txtRate1 = (TextBox)GridProposal.Rows[rowindex].FindControl("txtRate1");
                DropDownList ddlTaxCost = (DropDownList)GridProposal.Rows[rowindex].FindControl("ddlTaxCost");
                DropDownList ddlTaxCost1A = (DropDownList)GridProposal.Rows[rowindex].FindControl("ddlTaxCost1A");
                Label lblTax1Rate1 = (Label)GridProposal.Rows[rowindex].FindControl("lblTax1Rate1");
                Label lblTax2Rate1 = (Label)GridProposal.Rows[rowindex].FindControl("lblTax2Rate1");
                Label lblTaxValees1A = (Label)GridProposal.Rows[rowindex].FindControl("lblTaxValees1A");
                Label lblTaxValees = (Label)GridProposal.Rows[rowindex].FindControl("lblTaxValees");
                Label lblHSN1 = (Label)GridProposal.Rows[rowindex].FindControl("lblHSN1");
                Label lblSubAmont1 = (Label)GridProposal.Rows[rowindex].FindControl("lblSubAmont1");
                Label lblAmount1 = (Label)GridProposal.Rows[rowindex].FindControl("lblAmount1");

                string TaxRateU1 = Convert.ToString(lblTaxValees.Text);
                string TaxRateU2 = Convert.ToString(lblTaxValees1A.Text);


                //----------------------------------------------------------------------//
                Double TaxCost, TaxCost1;
                int TaxID2 = Convert.ToInt32(ddlTaxCost1A.SelectedItem.Value);
                string TaxName1 = ddlTaxCost1A.SelectedItem.Text;
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmdtax1 = new SqlCommand("SP_GetTaxRateByID", conn);
                    cmdtax1.Connection = conn;
                    cmdtax1.CommandType = CommandType.StoredProcedure;
                    cmdtax1.Parameters.AddWithValue("@TaxID", TaxID2);
                    SqlDataAdapter sdatax1 = new SqlDataAdapter(cmdtax1);
                    DataTable dttax1 = new DataTable();
                    sdatax1.Fill(dttax1);
                    if (dttax1.Rows.Count > 0)
                    {
                        string prd = Convert.ToString(dttax1.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dttax1.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dttax1.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dttax1.Rows[0]["Tax_Rate"]);
                    }
                }


                int TaxID = Convert.ToInt32(ddlTaxCost.SelectedItem.Value);
                string TaxName = ddlTaxCost.SelectedItem.Text;
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmdtax2 = new SqlCommand("SP_GetTaxRateByID", conn);
                    cmdtax2.Connection = conn;
                    cmdtax2.CommandType = CommandType.StoredProcedure;
                    cmdtax2.Parameters.AddWithValue("@TaxID", TaxID);
                    SqlDataAdapter sdatax2 = new SqlDataAdapter(cmdtax2);
                    DataTable dttax2 = new DataTable();
                    sdatax2.Fill(dttax2);
                    if (dttax2.Rows.Count > 0)
                    {
                        string prd = Convert.ToString(dttax2.Rows[0]["Tax_Rate"]);
                        TaxCost = Convert.ToDouble(dttax2.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dttax2.Rows[0]["Tax_Rate"]);
                        TaxCost = Convert.ToDouble(dttax2.Rows[0]["Tax_Rate"]);
                    }
                }

                //--------------------------------------------------------------------------------//

                Double SubTotal, TotalAmountTax1, TotalAmountTax2, Grand1Total;

                SubTotal = Convert.ToDouble(txtQty1.Text) * Convert.ToDouble(txtRate1.Text);

                lblSubAmont1.Text = Convert.ToString(SubTotal);

                TotalAmountTax1 = SubTotal * Convert.ToDouble(TaxCost) / 100;
                TotalAmountTax2 = SubTotal * Convert.ToDouble(TaxCost1) / 100;

                lblTax1Rate1.Text = Convert.ToString(TotalAmountTax1);
                lblTax2Rate1.Text = Convert.ToString(TotalAmountTax2);
                Grand1Total = SubTotal + TotalAmountTax1 + TotalAmountTax2;

                lblAmount1.Text = Convert.ToString(Grand1Total);

                ///Using loop Update stoed prosser
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateProposalItem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", lblID.Text);
                cmd.Parameters.AddWithValue("@ProposalNumber", txtProposalNumber.Text);
                cmd.Parameters.AddWithValue("@ProposalItem", lblItem1.Text);
                cmd.Parameters.AddWithValue("@Description", lblDescription1.Text);
                cmd.Parameters.AddWithValue("@Qnty", txtQty1.Text);
                cmd.Parameters.AddWithValue("@Rate", txtRate1.Text);
                cmd.Parameters.AddWithValue("@SubTotal", lblSubAmont1.Text);
                cmd.Parameters.AddWithValue("@Tax1Name", ddlTaxCost.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Tax1Rate", TaxCost);
                cmd.Parameters.AddWithValue("@Tax1Amount", lblTax1Rate1.Text);
                cmd.Parameters.AddWithValue("@Tax2Name", ddlTaxCost1A.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Tax2Rate", TaxCost1);
                cmd.Parameters.AddWithValue("@Tax2Amount", lblTax2Rate1.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", lblAmount1.Text);
                cmd.Parameters.AddWithValue("@RelatedTo", ddlRelated.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@RelatedID", ddlRelatedToCast.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@HSN", lblHSN1.Text);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@UserID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                //cmd.Parameters.AddWithValue("@ItemID", ddlItem.SelectedItem.Value);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i < 0)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Proposal Item Rate Update Successfully";
                    Calculatefilldata();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Proposal Item Rate not Updated";

                }
                con.Close();
                GridProposal.EditIndex = -1;
                Calculatefilldata();
                SubTotalSum();
                GrandTotal();
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
                var rows = GridProposal.Rows;
                DropDownList btnMessage = sender as DropDownList;
                GridViewRow row = (GridViewRow)btnMessage.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                //string RowIndex;
               // Label lblDescription1 = GridCalculate.Rows[rowindex].FindControl("lblDescription1") as Label;
                Label lblItem1 = (Label)GridProposal.Rows[rowindex].FindControl("lblItem1");
                Label lblID = (Label)GridProposal.Rows[rowindex].FindControl("lblID");
                Label lblDescription1 = (Label)GridProposal.Rows[rowindex].FindControl("lblDescription1");
                TextBox txtQty1 = (TextBox)GridProposal.Rows[rowindex].FindControl("txtQty1");
                TextBox txtRate1 = (TextBox)GridProposal.Rows[rowindex].FindControl("txtRate1");
                DropDownList ddlTaxCost = (DropDownList)GridProposal.Rows[rowindex].FindControl("ddlTaxCost");
                DropDownList ddlTaxCost1A = (DropDownList)GridProposal.Rows[rowindex].FindControl("ddlTaxCost1A");
                Label lblTax1Rate1 = (Label)GridProposal.Rows[rowindex].FindControl("lblTax1Rate1");
                Label lblTax2Rate1 = (Label)GridProposal.Rows[rowindex].FindControl("lblTax2Rate1");
                Label lblTaxValees1A = (Label)GridProposal.Rows[rowindex].FindControl("lblTaxValees1A");
                Label lblTaxValees = (Label)GridProposal.Rows[rowindex].FindControl("lblTaxValees");
                Label lblHSN1 = (Label)GridProposal.Rows[rowindex].FindControl("lblHSN1");
                Label lblSubAmont1 = (Label)GridProposal.Rows[rowindex].FindControl("lblSubAmont1");
                Label lblAmount1 = (Label)GridProposal.Rows[rowindex].FindControl("lblAmount1");

                string TaxRateU1 = Convert.ToString(lblTaxValees.Text);
                string TaxRateU2 = Convert.ToString(lblTaxValees1A.Text);


                //----------------------------------------------------------------------//
                Double TaxCost, TaxCost1;
                int TaxID2 = Convert.ToInt32(ddlTaxCost1A.SelectedItem.Value);
                string TaxName1 = ddlTaxCost1A.SelectedItem.Text;
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmdtax1 = new SqlCommand("SP_GetTaxRateByID", conn);
                    cmdtax1.Connection = conn;
                    cmdtax1.CommandType = CommandType.StoredProcedure;
                    cmdtax1.Parameters.AddWithValue("@TaxID", TaxID2);
                    SqlDataAdapter sdatax1 = new SqlDataAdapter(cmdtax1);
                    DataTable dttax1 = new DataTable();
                    sdatax1.Fill(dttax1);
                    if (dttax1.Rows.Count > 0)
                    {
                        string prd = Convert.ToString(dttax1.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dttax1.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dttax1.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dttax1.Rows[0]["Tax_Rate"]);
                    }
                }


                int TaxID = Convert.ToInt32(ddlTaxCost.SelectedItem.Value);
                string TaxName = ddlTaxCost.SelectedItem.Text;
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmdtax2 = new SqlCommand("SP_GetTaxRateByID", conn);
                    cmdtax2.Connection = conn;
                    cmdtax2.CommandType = CommandType.StoredProcedure;
                    cmdtax2.Parameters.AddWithValue("@TaxID", TaxID);
                    SqlDataAdapter sdatax2 = new SqlDataAdapter(cmdtax2);
                    DataTable dttax2 = new DataTable();
                    sdatax2.Fill(dttax2);
                    if (dttax2.Rows.Count > 0)
                    {
                        string prd = Convert.ToString(dttax2.Rows[0]["Tax_Rate"]);
                        TaxCost = Convert.ToDouble(dttax2.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dttax2.Rows[0]["Tax_Rate"]);
                        TaxCost = Convert.ToDouble(dttax2.Rows[0]["Tax_Rate"]);
                    }
                }

                //--------------------------------------------------------------------------------//
                Double SubTotal, TotalAmountTax1, TotalAmountTax2, Grand1Total;

                SubTotal = Convert.ToDouble(txtQty1.Text) * Convert.ToDouble(txtRate1.Text);

                lblSubAmont1.Text = Convert.ToString(SubTotal);

                TotalAmountTax1 = SubTotal * Convert.ToDouble(TaxCost) / 100;
                TotalAmountTax2 = SubTotal * Convert.ToDouble(TaxCost1) / 100;

                lblTax1Rate1.Text = Convert.ToString(TotalAmountTax1);
                lblTax2Rate1.Text = Convert.ToString(TotalAmountTax2);
                Grand1Total = SubTotal + TotalAmountTax1 + TotalAmountTax2;

                lblAmount1.Text = Convert.ToString(Grand1Total);

                ///Using loop Update stoed prosser
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateProposalItem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", lblID.Text);
                cmd.Parameters.AddWithValue("@ProposalNumber", txtProposalNumber.Text);
                cmd.Parameters.AddWithValue("@ProposalItem", lblItem1.Text);
                cmd.Parameters.AddWithValue("@Description", lblDescription1.Text);
                cmd.Parameters.AddWithValue("@Qnty", txtQty1.Text);
                cmd.Parameters.AddWithValue("@Rate", txtRate1.Text);
                cmd.Parameters.AddWithValue("@SubTotal", lblSubAmont1.Text);
                cmd.Parameters.AddWithValue("@Tax1Name", ddlTaxCost.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Tax1Rate", TaxCost);
                cmd.Parameters.AddWithValue("@Tax1Amount", lblTax1Rate1.Text);
                cmd.Parameters.AddWithValue("@Tax2Name", ddlTaxCost1A.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Tax2Rate", TaxCost1);
                cmd.Parameters.AddWithValue("@Tax2Amount", lblTax2Rate1.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", lblAmount1.Text);
                cmd.Parameters.AddWithValue("@RelatedTo", ddlRelated.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@RelatedID", ddlRelatedToCast.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@HSN", lblHSN1.Text);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@UserID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                //cmd.Parameters.AddWithValue("@ItemID", ddlItem.SelectedItem.Value);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i < 0)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Proposal Item Tax1 Update Successfully";
                    Calculatefilldata();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Proposal Item Tax1 not Updated";

                }
                con.Close();
                GridProposal.EditIndex = -1;
                SubTotalSum();
                GrandTotal();
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
                var rows = GridProposal.Rows;
                DropDownList btnMessage = sender as DropDownList;
                GridViewRow row = (GridViewRow)btnMessage.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                //string RowIndex;
                // Label lblDescription1 = GridCalculate.Rows[rowindex].FindControl("lblDescription1") as Label;
                Label lblItem1 = (Label)GridProposal.Rows[rowindex].FindControl("lblItem1");
                Label lblID = (Label)GridProposal.Rows[rowindex].FindControl("lblID");
                Label lblDescription1 = (Label)GridProposal.Rows[rowindex].FindControl("lblDescription1");
                TextBox txtQty1 = (TextBox)GridProposal.Rows[rowindex].FindControl("txtQty1");
                TextBox txtRate1 = (TextBox)GridProposal.Rows[rowindex].FindControl("txtRate1");
                DropDownList ddlTaxCost = (DropDownList)GridProposal.Rows[rowindex].FindControl("ddlTaxCost");
                DropDownList ddlTaxCost1A = (DropDownList)GridProposal.Rows[rowindex].FindControl("ddlTaxCost1A");
                Label lblTax1Rate1 = (Label)GridProposal.Rows[rowindex].FindControl("lblTax1Rate1");
                Label lblTax2Rate1 = (Label)GridProposal.Rows[rowindex].FindControl("lblTax2Rate1");
                Label lblTaxValees1A = (Label)GridProposal.Rows[rowindex].FindControl("lblTaxValees1A");
                Label lblTaxValees = (Label)GridProposal.Rows[rowindex].FindControl("lblTaxValees");
                Label lblHSN1 = (Label)GridProposal.Rows[rowindex].FindControl("lblHSN1");
                Label lblSubAmont1 = (Label)GridProposal.Rows[rowindex].FindControl("lblSubAmont1");
                Label lblAmount1 = (Label)GridProposal.Rows[rowindex].FindControl("lblAmount1");

                string TaxRateU1 = Convert.ToString(lblTaxValees.Text);
                string TaxRateU2 = Convert.ToString(lblTaxValees1A.Text);


                //----------------------------------------------------------------------//
                Double TaxCost, TaxCost1;
                int TaxID2 = Convert.ToInt32(ddlTaxCost1A.SelectedItem.Value);
                string TaxName1 = ddlTaxCost1A.SelectedItem.Text;
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmdtax1 = new SqlCommand("SP_GetTaxRateByID", conn);
                    cmdtax1.Connection = conn;
                    cmdtax1.CommandType = CommandType.StoredProcedure;
                    cmdtax1.Parameters.AddWithValue("@TaxID", TaxID2);
                    SqlDataAdapter sdatax1 = new SqlDataAdapter(cmdtax1);
                    DataTable dttax1 = new DataTable();
                    sdatax1.Fill(dttax1);
                    if (dttax1.Rows.Count > 0)
                    {
                        string prd = Convert.ToString(dttax1.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dttax1.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dttax1.Rows[0]["Tax_Rate"]);
                        TaxCost1 = Convert.ToDouble(dttax1.Rows[0]["Tax_Rate"]);
                    }
                }


                int TaxID = Convert.ToInt32(ddlTaxCost.SelectedItem.Value);
                string TaxName = ddlTaxCost.SelectedItem.Text;
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmdtax2 = new SqlCommand("SP_GetTaxRateByID", conn);
                    cmdtax2.Connection = conn;
                    cmdtax2.CommandType = CommandType.StoredProcedure;
                    cmdtax2.Parameters.AddWithValue("@TaxID", TaxID);
                    SqlDataAdapter sdatax2 = new SqlDataAdapter(cmdtax2);
                    DataTable dttax2 = new DataTable();
                    sdatax2.Fill(dttax2);
                    if (dttax2.Rows.Count > 0)
                    {
                        string prd = Convert.ToString(dttax2.Rows[0]["Tax_Rate"]);
                        TaxCost = Convert.ToDouble(dttax2.Rows[0]["Tax_Rate"]);
                    }
                    else
                    {
                        string prd = Convert.ToString(dttax2.Rows[0]["Tax_Rate"]);
                        TaxCost = Convert.ToDouble(dttax2.Rows[0]["Tax_Rate"]);
                    }
                }

                //--------------------------------------------------------------------------------//
                Double SubTotal, TotalAmountTax1, TotalAmountTax2, Grand1Total;

                SubTotal = Convert.ToDouble(txtQty1.Text) * Convert.ToDouble(txtRate1.Text);

                lblSubAmont1.Text = Convert.ToString(SubTotal);

                TotalAmountTax1 = SubTotal * Convert.ToDouble(TaxCost) / 100;
                TotalAmountTax2 = SubTotal * Convert.ToDouble(TaxCost1) / 100;

                lblTax1Rate1.Text = Convert.ToString(TotalAmountTax1);
                lblTax2Rate1.Text = Convert.ToString(TotalAmountTax2);
                Grand1Total = SubTotal + TotalAmountTax1 + TotalAmountTax2;

                lblAmount1.Text = Convert.ToString(Grand1Total);

                ///Using loop Update stoed prosser
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateProposalItem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", lblID.Text);
                cmd.Parameters.AddWithValue("@ProposalNumber", txtProposalNumber.Text);
                cmd.Parameters.AddWithValue("@ProposalItem", lblItem1.Text);
                cmd.Parameters.AddWithValue("@Description", lblDescription1.Text);
                cmd.Parameters.AddWithValue("@Qnty", txtQty1.Text);
                cmd.Parameters.AddWithValue("@Rate", txtRate1.Text);
                cmd.Parameters.AddWithValue("@SubTotal", lblSubAmont1.Text);
                cmd.Parameters.AddWithValue("@Tax1Name", ddlTaxCost.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Tax1Rate", TaxCost);
                cmd.Parameters.AddWithValue("@Tax1Amount", lblTax1Rate1.Text);
                cmd.Parameters.AddWithValue("@Tax2Name", ddlTaxCost1A.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Tax2Rate", TaxCost1);
                cmd.Parameters.AddWithValue("@Tax2Amount", lblTax2Rate1.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", lblAmount1.Text);
                cmd.Parameters.AddWithValue("@RelatedTo", ddlRelated.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@RelatedID", ddlRelatedToCast.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@HSN", lblHSN1.Text);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@UserID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                //cmd.Parameters.AddWithValue("@ItemID", ddlItem.SelectedItem.Value);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i < 0)
                {
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Proposal Item Tax2 Update Successfully";
                    Calculatefilldata();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Proposal Item Tax2 not Updated";

                }
                con.Close();
                GridProposal.EditIndex = -1;
                SubTotalSum();
                GrandTotal();
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
            DiscountCount();
            GetTaxlistCalculationPROPOSAL();
        }
        protected void TxtAdjustment1_TextChanged(object sender, EventArgs e)
        {
            RoundUpCount();
            GrandTotal();
        }
        #endregion
    }
}