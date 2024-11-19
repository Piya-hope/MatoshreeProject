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

#endregion

namespace MatoshreeProject
{
    public partial class NewWorkOrder : System.Web.UI.Page
    {

        #region " Class Level Variable "

        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr, dr1, dr2, dr3;
        int Result, Result1, Result2, Result3;
        string result, result1, result2, result3;

        string Tenderid, Publish;
        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;

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
        public void getdistrictbystateId(int stateid)
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

        public void getcitybydistrictid(int distrctid)
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
        private string generateOrderNo(string code, long id)
        {
            string oID = code;
            string space = "-";
            oID += space + id.ToString("00000");

            return oID;
        }

        public string GETReceiptINITIAL()
        {
            SqlConnection conn = new SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand("SP_GeReceriptInitial", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReceiptFor", "Work_Order");
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
                    ddlProjects.Items.Insert(0, new ListItem("Select Project", "0"));
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
                    ddlProjects.Items.Insert(0, new ListItem("Select Project", "0"));
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
        public void GetTenderToVendorDetailByTenderNumber()
        {
            try
            {
                string VendorID = HttpUtility.UrlDecode(Request.QueryString["VendorID"]);
                //lbltenid.Text = Tendid;
                //ddltenderNumber.SelectedItem.Value = lbltenid.Text;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetTenderVenderDetailsbyTenderID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@id", VendorID);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txttendername.Text = dt.Rows[0]["TenderName"].ToString();
                        lblContactVendorid.Text = dt.Rows[0]["ContactID"].ToString();
                        ddlCategory.SelectedItem.Text = dt.Rows[0]["TenderBased"].ToString();
                        ddlSalesAgent.SelectedItem.Text = dt.Rows[0]["Sales_Agent"].ToString();
                        ddlSalesAgent.SelectedItem.Value = dt.Rows[0]["SaleagentID"].ToString();
                        txtClientNote.Text = dt.Rows[0]["Client_Note"].ToString();
                        txtTermsAndConditions.Text = dt.Rows[0]["Term_condition"].ToString();
                        ddlStatus.SelectedItem.Text = dt.Rows[0]["Status"].ToString();
                        txtpublishDate.Text = DateTime.Parse(dt.Rows[0]["publishdate"].ToString()).ToString("yyyy-MM-dd");

                        ddlCustomers.SelectedItem.Value = dt.Rows[0]["Cust_ID"].ToString();
                        ddlCustomers.SelectedItem.Text = dt.Rows[0]["Cust_Name"].ToString();
                        int CustID = Convert.ToInt32(ddlCustomers.SelectedItem.Value);
                        GetProjectByCustID(CustID);

                        ddlProjects.SelectedItem.Text = dt.Rows[0]["ProjectName"].ToString();
                        ddlProjects.SelectedItem.Value = dt.Rows[0]["ProjectID"].ToString();
                        int ProjectID = Convert.ToInt32(ddlProjects.SelectedItem.Value);
                        GetTenderNumberByProjectID(ProjectID);
                        ddltenderNumber.SelectedItem.Text = dt.Rows[0]["TenderNo"].ToString();
                        ddltenderNumber.SelectedItem.Value = dt.Rows[0]["Tend_ID"].ToString();
                        ddlauthname.SelectedItem.Text = dt.Rows[0]["AuthorityName"].ToString();
                        txtauthorityaddress.Text = dt.Rows[0]["Authorityaddress"].ToString();
                        txtaddressLine1.Text = dt.Rows[0]["AddressLine1"].ToString();
                        txtaddressline2.Text = dt.Rows[0]["AddressLine2"].ToString();
                        txtvillage.Text = dt.Rows[0]["Add_Street"].ToString();
                        txtDescription1.Text = dt.Rows[0]["Description"].ToString();
                        txtperiodofwork.Text = dt.Rows[0]["periodofwork"].ToString();
                        ddlpaymentmode.SelectedItem.Text = dt.Rows[0]["PaymentMode"].ToString();
                        txttendervalue.Text = dt.Rows[0]["estimatecontractvalue"].ToString();

                        ddllocationcountry.SelectedItem.Text = dt.Rows[0]["Country"].ToString();
                        ddllocationstate.SelectedItem.Text = dt.Rows[0]["AddState"].ToString();
                        int StateID = Convert.ToInt32(ddllocationstate.SelectedItem.Value);
                        GetDistrictByStateID(StateID);
                        ddllocationdistrict.SelectedItem.Text = dt.Rows[0]["AddDistrict"].ToString();
                        int DistrictID = Convert.ToInt32(ddllocationdistrict.SelectedItem.Value);
                        GetCityByDistrictID(DistrictID);
                        ddllocationcity.SelectedItem.Text = dt.Rows[0]["AddCity"].ToString();

                        txtlocationflatno.Text = dt.Rows[0]["Add_Block"].ToString();
                        txtlocationpincode.Text = dt.Rows[0]["Pincode"].ToString();

                        txtAuthcontno.Text = dt.Rows[0]["Auth_Contact"].ToString();
                        txtAuthposition1.Text = dt.Rows[0]["Auth_Position"].ToString();
                        txtAuthemail.Text = dt.Rows[0]["Auth_Email"].ToString();
                        ddlVenderName.SelectedItem.Text = dt.Rows[0]["Vend_Name"].ToString();
                        lblVendorName.Text = dt.Rows[0]["Vend_Name"].ToString();
                        lblContactPersonName1.Text = dt.Rows[0]["First_Name"].ToString();
                        lblContactPersonEmail1.Text = dt.Rows[0]["email"].ToString();
                        lblContactPersonPosition1.Text = dt.Rows[0]["Position"].ToString();
                        lblContactPersonmobno1.Text = dt.Rows[0]["phonenumber"].ToString();
                        lblvenderblock.Text = dt.Rows[0]["VAdd_Block"].ToString();
                        lblvenderstreet.Text = dt.Rows[0]["VAdd_Street"].ToString();
                        lblvendercity.Text = dt.Rows[0]["VAdd_City"].ToString();
                        lblvenderdistrict.Text = dt.Rows[0]["VAdd_District"].ToString();
                        lblvenderstate.Text = dt.Rows[0]["VAdd_State"].ToString();
                        lblvenercountry.Text = dt.Rows[0]["VAdd_Country"].ToString();
                        lblvenderpin1.Text = dt.Rows[0]["VAdd_PinCode"].ToString();

                        Calculatefilldata();
                        ViewTenderFile();
                        ViewTenderQuestionDetails();
                        CalculateTempdata();
                        GetTotalTenderItemVendorCount();
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

        public void GetTenderNumberByProjectID(int ProjectID)
        {
            try
            {

                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd1 = new SqlCommand("SP_GetTenderNumberByProjectID", conn);
                cmd1.Connection = conn;
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@ProjectId", ProjectID);
                using (SqlDataAdapter sda1 = new SqlDataAdapter(cmd1))
                {
                    DataSet ds = new DataSet();
                    sda1.Fill(ds);
                    ddltenderNumber.DataSource = ds.Tables[0];
                    ddltenderNumber.DataTextField = "TenderNo";
                    ddltenderNumber.DataValueField = "ID";
                    ddltenderNumber.DataBind();
                    ddltenderNumber.Items.Insert(0, new ListItem("NA", "0"));
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
                    ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
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

        protected void bindVendorName()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetVendorName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlVenderName.DataSource = ds.Tables[0];
                    ddlVenderName.DataTextField = "Vend_Name";
                    ddlVenderName.DataValueField = "Vend_ID";
                    ddlVenderName.DataBind();
                    ddlVenderName.Items.Insert(0, new ListItem("Select Vendor Name", "0"));
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

        protected void bindTenderNumber()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetTenderNumber", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable ds = new DataTable();
                    sda.Fill(ds);

                    ddltenderNumber.DataSource = ds;
                    ddltenderNumber.DataTextField = "TenderNo";
                    ddltenderNumber.DataValueField = "ID";
                    ddltenderNumber.DataBind();
                    ddltenderNumber.Items.Insert(0, new ListItem("Select Tender", "0"));
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

        public void BindStatusDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetStatusname", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BelongTo", "WorkOrder");
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

        public void Calculatefilldata()
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_ViewTenderVendorItemsByTenderNumber", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@id", ddltenderNumber.SelectedItem.Value);
                    com.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                    com.Parameters.AddWithValue("@VendorID", lblContactVendorid.Text);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        GridCalculate.DataSource = dt;
                        GridCalculate.DataBind();
                        SaveDataToTempItem(dt);
                        foreach (GridViewRow gridviedrow in GridCalculate.Rows)
                        {
                            // txtRate1
                            TextBox txtQantity1 = (TextBox)gridviedrow.FindControl("txtQty1");
                            LinkButton btnDeleteItemCal1 = (LinkButton)gridviedrow.FindControl("btnDeleteItemCal");
                            TextBox txtTax1Rate1 = (TextBox)gridviedrow.FindControl("txtTax1Rate1");
                            TextBox txtTax2Rate1 = (TextBox)gridviedrow.FindControl("txtTax2Rate1");
                            TextBox txtRate1 = (TextBox)gridviedrow.FindControl("txtRate1");
                            DropDownList ddlTax11 = (DropDownList)gridviedrow.FindControl("ddlTax11");
                            DropDownList ddlTax22 = (DropDownList)gridviedrow.FindControl("ddlTax22");

                            btnDeleteItemCal1.Visible = true;
                            txtQantity1.Visible = true;
                            ddlTax11.Visible = true;
                            ddlTax22.Visible = true;
                            txtTax1Rate1.Visible = true;
                            txtTax2Rate1.Visible = true;
                            txtRate1.Visible = true;
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

        private void SaveDataToTempItem(DataTable dt)
        {
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                foreach (DataRow row in dt.Rows)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_SaveTenderToVenderItem", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TenderID", ddltenderNumber.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@VendID", lblContactVendorid.Text);
                        cmd.Parameters.AddWithValue("@CustomerID", ddlCustomers.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Item", row["Item"]);
                        cmd.Parameters.AddWithValue("@Description", row["Description"]);
                        cmd.Parameters.AddWithValue("@Qnty", row["Qnty"]);
                        cmd.Parameters.AddWithValue("@Rate", row["Rate"]);
                        cmd.Parameters.AddWithValue("@Tax1Name", row["Tax1Name"]);
                        cmd.Parameters.AddWithValue("@Tax2Name", row["Tax2Name"]);
                        cmd.Parameters.AddWithValue("@Tax1Rate", row["Tax1Rate"]);
                        cmd.Parameters.AddWithValue("@Tax2Rate", row["Tax2Rate"]);
                        cmd.Parameters.AddWithValue("@TotalAmont", row["TotalAmont"]);
                        cmd.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Empid", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@Createby", UserName);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {
                            //  this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tender Details Save Successfully!')", true);

                        }
                        else
                        {
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tender  Details Not Save Successfully!')", true);

                        }
                        con.Close();
                    }
                }
            }
        }

        protected void TruncateData()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_TruncateTempITEM", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Empid", UserId);
                cmd.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                conn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i < 0)
                {
                    //Truncatetable data item 
                }
                else
                {
                    //Truncatetable data item  NOT
                }
                conn.Close();
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

        public void CalculateTempdata()
        {
            try
            {
                string tendername = ddltenderNumber.SelectedItem.Text;
                string Item = ddlItem.SelectedItem.Text;
                string category = ddlCategory.SelectedItem.Text;
                if (tendername == "NA")
                {
                    if (Item != "Select Item" || category != "Select Category")
                    {
                        using (SqlConnection con1 = new SqlConnection(strconnect))
                        {
                            SqlCommand com = new SqlCommand("SP_ViewTempItemsByTenderNumber", con1);
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddWithValue("@id", tendername);
                            com.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                            com.Parameters.AddWithValue("@VendorID", lblContactVendorid.Text);
                            SqlDataAdapter da = new SqlDataAdapter(com);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                GridCalculate.DataSource = dt;
                                GridCalculate.DataBind();

                                foreach (GridViewRow gridviedrow in GridCalculate.Rows)
                                {
                                    // txtRate1
                                    TextBox txtQantity1 = (TextBox)gridviedrow.FindControl("txtQty1");
                                    LinkButton btnDeleteItemCal1 = (LinkButton)gridviedrow.FindControl("btnDeleteItemCal");
                                    TextBox txtTax1Rate1 = (TextBox)gridviedrow.FindControl("txtTax1Rate1");
                                    TextBox txtTax2Rate1 = (TextBox)gridviedrow.FindControl("txtTax2Rate1");
                                    TextBox txtRate1 = (TextBox)gridviedrow.FindControl("txtRate1");
                                    DropDownList ddlTax11 = (DropDownList)gridviedrow.FindControl("ddlTax11");
                                    DropDownList ddlTax22 = (DropDownList)gridviedrow.FindControl("ddlTax22");

                                    divitem.Visible = true;
                                    btnDeleteItemCal1.Visible = true;
                                    txtQantity1.Visible = true;
                                    ddlTax11.Visible = true;
                                    ddlTax22.Visible = true;
                                    txtTax1Rate1.Visible = true;
                                    txtTax2Rate1.Visible = true;
                                    txtRate1.Visible = true;
                                }
                                GetTotalTenderItemVendorCount();
                            }
                            else
                            {

                                //If NA Selected//...Workorder NOT Available
                                DataTable dtExport = new DataTable();
                                dtExport.Columns.Add("ID");
                                dtExport.Columns.Add("Item");
                                dtExport.Columns.Add("Description");
                                dtExport.Columns.Add("Qnty");
                                dtExport.Columns.Add("Rate");
                                dtExport.Columns.Add("Tax1Name");
                                dtExport.Columns.Add("Tax1Rate");
                                dtExport.Columns.Add("Tax2Name");
                                dtExport.Columns.Add("Tax2Rate");
                                dtExport.Columns.Add("TotalAmont");

                                for (int i = 1; i <= 1; i++)
                                {
                                    DataRow newRow = dtExport.NewRow();
                                    newRow["ID"] = "1";
                                    newRow["Item"] = "NA";
                                    newRow["Description"] = "NA";
                                    newRow["Qnty"] = "0";
                                    newRow["Rate"] = "0";
                                    newRow["Tax1Name"] = "No Tax Apply";
                                    newRow["Tax1Rate"] = "0";
                                    newRow["Tax2Name"] = "No Tax Apply";
                                    newRow["Tax2Rate"] = "0";
                                    newRow["TotalAmont"] = "0";

                                    dtExport.Rows.Add(newRow);
                                }

                                //  dt.Rows.Add(dt.NewRow());
                                GridCalculate.DataSource = dtExport;
                                GridCalculate.DataBind();
                                // int totalcolums = GridCalculate.Rows[0].Cells.Count;
                                SuccessDiv1.Visible = false;
                                lblMsg.Visible = false;
                                lblMsg1.Visible = false;
                                msgdiv.Visible = false;
                            }

                        }
                    }
                    else
                    {
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("Item");
                        dtExport.Columns.Add("Description");
                        dtExport.Columns.Add("Qnty");
                        dtExport.Columns.Add("Rate");
                        dtExport.Columns.Add("Tax1Name");
                        dtExport.Columns.Add("Tax1Rate");
                        dtExport.Columns.Add("Tax2Name");
                        dtExport.Columns.Add("Tax2Rate");
                        dtExport.Columns.Add("TotalAmont");

                        for (int i = 1; i <= 1; i++)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = "1";
                            newRow["Item"] = "NA";
                            newRow["Description"] = "NA";
                            newRow["Qnty"] = "0";
                            newRow["Rate"] = "0";
                            newRow["Tax1Name"] = "No Tax Apply";
                            newRow["Tax1Rate"] = "0";
                            newRow["Tax2Name"] = "No Tax Apply";
                            newRow["Tax2Rate"] = "0";
                            newRow["TotalAmont"] = "0";

                            dtExport.Rows.Add(newRow);
                        }

                        //  dt.Rows.Add(dt.NewRow());
                        GridCalculate.DataSource = dtExport;
                        GridCalculate.DataBind();
                        // int totalcolums = GridCalculate.Rows[0].Cells.Count;
                        SuccessDiv1.Visible = false;
                        lblMsg.Visible = false;
                        lblMsg1.Visible = false;
                        msgdiv.Visible = false;
                    }
                    //If NA Selected//...Workorder NOT Available

                }
                else
                {
                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {
                        SqlCommand com = new SqlCommand("SP_ViewTempItemsByTenderNumber", con1);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@id", tendername);
                        com.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                        com.Parameters.AddWithValue("@VendorID", lblContactVendorid.Text);
                        SqlDataAdapter da = new SqlDataAdapter(com);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            GridCalculate.DataSource = dt;
                            GridCalculate.DataBind();

                            foreach (GridViewRow gridviedrow in GridCalculate.Rows)
                            {
                                // txtRate1
                                TextBox txtQantity1 = (TextBox)gridviedrow.FindControl("txtQty1");
                                LinkButton btnDeleteItemCal1 = (LinkButton)gridviedrow.FindControl("btnDeleteItemCal");
                                TextBox txtTax1Rate1 = (TextBox)gridviedrow.FindControl("txtTax1Rate1");
                                TextBox txtTax2Rate1 = (TextBox)gridviedrow.FindControl("txtTax2Rate1");
                                TextBox txtRate1 = (TextBox)gridviedrow.FindControl("txtRate1");
                                DropDownList ddlTax11 = (DropDownList)gridviedrow.FindControl("ddlTax11");
                                DropDownList ddlTax22 = (DropDownList)gridviedrow.FindControl("ddlTax22");

                                divitem.Visible = true;
                                btnDeleteItemCal1.Visible = true;
                                txtQantity1.Visible = true;
                                ddlTax11.Visible = true;
                                ddlTax22.Visible = true;
                                txtTax1Rate1.Visible = true;
                                txtTax2Rate1.Visible = true;
                                txtRate1.Visible = true;
                            }
                            GetTotalTenderItemVendorCount();
                        }
                        else
                        {

                            //If NA Selected//...Workorder NOT Available
                            DataTable dtExport = new DataTable();
                            dtExport.Columns.Add("ID");
                            dtExport.Columns.Add("Item");
                            dtExport.Columns.Add("Description");
                            dtExport.Columns.Add("Qnty");
                            dtExport.Columns.Add("Rate");
                            dtExport.Columns.Add("Tax1Name");
                            dtExport.Columns.Add("Tax1Rate");
                            dtExport.Columns.Add("Tax2Name");
                            dtExport.Columns.Add("Tax2Rate");
                            dtExport.Columns.Add("TotalAmont");

                            for (int i = 1; i <= 1; i++)
                            {
                                DataRow newRow = dtExport.NewRow();
                                newRow["ID"] = "1";
                                newRow["Item"] = "NA";
                                newRow["Description"] = "NA";
                                newRow["Qnty"] = "0";
                                newRow["Rate"] = "0";
                                newRow["Tax1Name"] = "No Tax Apply";
                                newRow["Tax1Rate"] = "0";
                                newRow["Tax2Name"] = "No Tax Apply";
                                newRow["Tax2Rate"] = "0";
                                newRow["TotalAmont"] = "0";

                                dtExport.Rows.Add(newRow);
                            }

                            //  dt.Rows.Add(dt.NewRow());
                            GridCalculate.DataSource = dtExport;
                            GridCalculate.DataBind();
                            // int totalcolums = GridCalculate.Rows[0].Cells.Count;
                            SuccessDiv1.Visible = false;
                            lblMsg.Visible = false;
                            lblMsg1.Visible = false;
                            msgdiv.Visible = false;
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

        public DataTable ViewTenderFile()
        {
            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                SqlCommand com = new SqlCommand("SP_ViewTenderFileByTenderNo", con1);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                com.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                if (ddltenderNumber.SelectedItem.Text == "NA")
                {
                    com.Parameters.AddWithValue("@Belong", "WorkOrder");
                }
                else
                {
                    com.Parameters.AddWithValue("@Belong", "");
                }
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridWorkOrderFile.DataSource = dt;
                    GridWorkOrderFile.DataBind();
                    GridWorkOrderFile.Visible = true;
                    foreach (GridViewRow gridviedrow in GridWorkOrderFile.Rows)
                    {
                        LinkButton btnDeleteMeasurementFile = (LinkButton)gridviedrow.FindControl("btnDeleteMeasurementFile");
                        btnDeleteMeasurementFile.Visible = true;
                    }
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridWorkOrderFile.DataSource = dt;
                    GridWorkOrderFile.DataBind();
                    int totalcolums = GridWorkOrderFile.Rows[0].Cells.Count;
                    GridWorkOrderFile.Visible = false;
                }
            }
            return table;
        }

        public DataTable ViewTenderQuestionDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                SqlCommand com = new SqlCommand("SP_ViewTendervendorQuestionDetailbyTenderNumber", con1);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                com.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                if (ddltenderNumber.SelectedItem.Text == "NA")
                {
                    com.Parameters.AddWithValue("@Belong", "WorkOrder");
                }
                else
                {
                    com.Parameters.AddWithValue("@Belong", "");
                }
                com.Parameters.AddWithValue("@VendID", lblContactVendorid.Text);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridWorkOrderQue.DataSource = dt;
                    GridWorkOrderQue.DataBind();
                    GridWorkOrderQue.Visible = true;
                    foreach (GridViewRow gridviedrow in GridWorkOrderQue.Rows)
                    {

                        LinkButton btnDeleteTenderQue = (LinkButton)gridviedrow.FindControl("btnDeleteWorkorderQue");

                        btnDeleteTenderQue.Visible = true;

                    }
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridWorkOrderQue.DataSource = dt;
                    GridWorkOrderQue.DataBind();
                    int totalcolums = GridWorkOrderQue.Rows[0].Cells.Count;
                    GridWorkOrderQue.Visible = false;
                }
            }
            return table;
        }

        public void Clear()
        {
            ddltenderNumber.SelectedIndex = -1;
            ddlCustomers.SelectedIndex = -1;
            ddlProjects.SelectedIndex = -1;

            ddlItem.SelectedIndex = -1;
            ddlSalesAgent.SelectedIndex = -1;
            txttendername.Text = string.Empty;
            txttendervalue.Text = string.Empty;

            txtperiodofwork.Text = string.Empty;
            txtlocationflatno.Text = string.Empty;
            txtlocationpincode.Text = string.Empty;
            txtAuthposition1.Text = string.Empty;
            txtAuthcontno.Text = string.Empty;
            txtAuthemail.Text = string.Empty;

            ddllocationcountry.SelectedIndex = 0;
            ddllocationstate.SelectedIndex = 0;
            ddllocationdistrict.SelectedIndex = 0;
            ddllocationcity.SelectedIndex = 0;
            ddlpaymentmode.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            txtDescription1.Text = string.Empty;
            txtpublishDate.Text = string.Empty;

            lblsubtotal1.Text = string.Empty;
            lbltotaltax1.Text = string.Empty;
            lbltotalamt1.Text = string.Empty;
            ddlauthname.SelectedIndex = -1;
            txtauthorityaddress.Text = string.Empty;
            txtdocumenttype.Text = string.Empty;
            txtvillage.Text = string.Empty;
            ddlVenderName.SelectedIndex = 0;
            txtaddressLine1.Text = string.Empty;
            txtaddressline2.Text = string.Empty;

            lblVendorName.Text = string.Empty;
            lblContactPersonName1.Text = string.Empty;
            lblContactPersonEmail1.Text = string.Empty;
            lblContactPersonmobno1.Text = string.Empty;
            lblContactPersonPosition1.Text = string.Empty;
            lblvenderblock.Text = string.Empty;
            lblvenderstreet.Text = string.Empty;
            lblvendercity.Text = string.Empty;
            lblvenderdistrict.Text = string.Empty;
            lblvenderstate.Text = string.Empty;
            lblvenercountry.Text = string.Empty;
            lblvenderpin1.Text = string.Empty;

            txtstartdate.Text = string.Empty;
            txtenddate.Text = string.Empty;

            txtClientNote.Text = string.Empty;
            txtTermsAndConditions.Text = string.Empty;
            GridWorkOrderQue.DataSource = null;
            GridWorkOrderQue.DataBind();
            GridWorkOrderQue.SelectedIndex = 0;

            GridWorkOrderFile.DataSource = null;
            GridWorkOrderFile.DataBind();
            GridWorkOrderQue.SelectedIndex = 0;

            GridCalculate.DataSource = null;
            GridCalculate.DataBind();
            GridCalculate.SelectedIndex = 0;

            SuccessDiv1.Visible = false;
            lblMsg.Visible = false;
            divitem.Visible = false;

            string Todaydate = Convert.ToString(DateTime.Today);
            string WeekDate = Convert.ToString(DateTime.Today.AddDays(7));


            //ViewTenderFile();
            //ViewTenderQuestionDetails();

        }

        public void GetTotalTenderItemVendorCount()
        {
            try
            {
                SqlConnection Usercon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetTotalTempItemCount", Usercon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@CustID", ddlCustomers.SelectedItem.Value);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lbltotalamt1.Text = dt.Rows[0]["TotalAmount"].ToString();
                    lbltotaltax1.Text = dt.Rows[0]["TotalTaxAmount"].ToString();
                    lblsubtotal1.Text = dt.Rows[0]["SubTotal"].ToString();
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

                        if (!this.IsPostBack)
                        {
                            string ReceiptNumner = GETReceiptINITIAL();
                            txtworkorderNumber.Text = ReceiptNumner;
                            string Todaydate = Convert.ToString(DateTime.Today);
                            string WeekDate = Convert.ToString(DateTime.Today.AddDays(7));
                            txtstartdate.Attributes["value"] = DateTime.Parse(Todaydate.ToString()).ToString("yyyy-MM-dd");
                            txtenddate.Attributes["value"] = DateTime.Parse(WeekDate.ToString()).ToString("yyyy-MM-dd");
                            // bindTenderNumber();
                            BindStateDetails();
                            //BindDistrictDetails();
                            //BindCityDetails();
                            bindVendorName();
                            bindTenderCategoryName();
                            BindStatusDetails();
                            bindcustomer();

                            bindStaff();
                            bindItem();
                            bindTax();
                            string VendorID = HttpUtility.UrlDecode(Request.QueryString["VendorID"]);
                            if (VendorID != null)
                            {
                                GetTenderToVendorDetailByTenderNumber();
                            }


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
                                string ReceiptNumner = GETReceiptINITIAL();
                                txtworkorderNumber.Text = ReceiptNumner;
                                string Todaydate = Convert.ToString(DateTime.Today);
                                string WeekDate = Convert.ToString(DateTime.Today.AddDays(7));
                                txtstartdate.Attributes["value"] = DateTime.Parse(Todaydate.ToString()).ToString("yyyy-MM-dd");
                                txtenddate.Attributes["value"] = DateTime.Parse(WeekDate.ToString()).ToString("yyyy-MM-dd");
                                bindTenderNumber();
                                BindStateDetails();
                                //BindDistrictDetails();
                                //BindCityDetails();
                                bindVendorName();
                                bindTenderCategoryName();
                                BindStatusDetails();
                                bindcustomer();
                                //GetTotalTenderItemVendorCount();
                                //bindProject();
                                bindStaff();
                                bindItem();
                                bindTax();
                                string Tendid = HttpUtility.UrlDecode(Request.QueryString["TenderID"]);
                                if (Tendid != null)
                                {
                                    GetTenderToVendorDetailByTenderNumber();
                                }


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

        protected void GridCalculate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                string tendername = ddltenderNumber.SelectedItem.Text;
                if (tendername == "NA")
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {

                        DropDownList ddltax11 = (DropDownList)e.Row.FindControl("ddltax11");
                        DropDownList ddltax22 = (DropDownList)e.Row.FindControl("ddltax22");

                        Label lblTax1tax11 = (Label)e.Row.FindControl("lblTax1tax11");
                        Label lblTax2Name1 = (Label)e.Row.FindControl("lblTax2Name1");


                        if (lblTax1tax11.Text == "" || lblTax2Name1.Text == "")
                        {
                            lblTax1tax11.Text = "No Tax Apply";
                            ddltax11.Items.FindByText(lblTax1tax11.Text).Selected = true;

                            lblTax2Name1.Text = "No Tax Apply";
                            ddltax22.Items.FindByText(lblTax2Name1.Text).Selected = true;
                        }
                        else
                        {

                            ddltax22.Items.FindByText(lblTax2Name1.Text).Selected = true;
                            ddltax11.Items.FindByText(lblTax1tax11.Text).Selected = true;

                        }
                        //ddltax22.ClearSelection();
                        //ddltax11.ClearSelection();


                    }

                    float TotalCGST_ddlTax11 = 0;
                    float TotalSGST_ddlTax11 = 0;
                    float TotalIGST_ddlTax11 = 0;

                    float TotalCGST_ddlTax22 = 0;
                    float TotalSGST_ddlTax22 = 0;
                    float TotalIGST_ddlTax22 = 0;

                    foreach (GridViewRow gridviedrow in GridCalculate.Rows)
                    {
                        TextBox txtQantity1 = (TextBox)gridviedrow.FindControl("txtQty1");
                        TextBox txtTax1Rate1 = (TextBox)gridviedrow.FindControl("txtTax1Rate1");
                        TextBox txtTax2Rate1 = (TextBox)gridviedrow.FindControl("txtTax2Rate1");
                        TextBox txtRate1 = (TextBox)gridviedrow.FindControl("txtRate1");
                        DropDownList ddlTax11 = (DropDownList)gridviedrow.FindControl("ddlTax11");
                        DropDownList ddlTax22 = (DropDownList)gridviedrow.FindControl("ddlTax22");

                        Label lblTax1tax11A = (Label)gridviedrow.FindControl("lblTax1tax11");
                        Label lblTax2Name1A = (Label)gridviedrow.FindControl("lblTax2Name1");



                        float Rate = Convert.ToSingle(txtRate1.Text);
                        float Qantity = Convert.ToSingle(txtQantity1.Text);
                        float Rate1 = Convert.ToSingle(txtTax1Rate1.Text);
                        float Rate2 = Convert.ToSingle(txtTax2Rate1.Text);

                        if (ddlTax11.SelectedItem.Text == "CGST")
                        {
                            TotalCGST_ddlTax11 += (Rate * Qantity * Rate1 / 100);
                        }
                        else if (ddlTax11.SelectedItem.Text == "SGST")
                        {
                            TotalSGST_ddlTax11 += (Rate * Qantity * Rate1 / 100);
                        }
                        else
                        {
                            TotalIGST_ddlTax11 += (Rate * Qantity * Rate1 / 100);
                        }

                        if (ddlTax22.SelectedItem.Text == "CGST")
                        {
                            TotalCGST_ddlTax22 += (Rate * Qantity * Rate2 / 100);
                        }
                        else if (ddlTax22.SelectedItem.Text == "SGST")
                        {
                            TotalSGST_ddlTax22 += (Rate * Qantity * Rate2 / 100);
                        }
                        else
                        {
                            TotalIGST_ddlTax22 += (Rate * Qantity * Rate2 / 100);
                        }
                    }

                    lblcgst1.Text = (TotalCGST_ddlTax11 + TotalCGST_ddlTax22).ToString();
                    lblsgst1.Text = (TotalSGST_ddlTax11 + TotalSGST_ddlTax22).ToString();
                    lbligst1.Text = (TotalIGST_ddlTax11 + TotalIGST_ddlTax22).ToString();
                }
                else
                {
                    float TotalCGST_ddlTax11 = 0;
                    float TotalSGST_ddlTax11 = 0;
                    float TotalIGST_ddlTax11 = 0;

                    float TotalCGST_ddlTax22 = 0;
                    float TotalSGST_ddlTax22 = 0;
                    float TotalIGST_ddlTax22 = 0;

                    foreach (GridViewRow gridviedrow in GridCalculate.Rows)
                    {
                        TextBox txtQantity1 = (TextBox)gridviedrow.FindControl("txtQty1");
                        TextBox txtTax1Rate1 = (TextBox)gridviedrow.FindControl("txtTax1Rate1");
                        TextBox txtTax2Rate1 = (TextBox)gridviedrow.FindControl("txtTax2Rate1");
                        TextBox txtRate1 = (TextBox)gridviedrow.FindControl("txtRate1");
                        DropDownList ddlTax11 = (DropDownList)gridviedrow.FindControl("ddlTax11");
                        DropDownList ddlTax22 = (DropDownList)gridviedrow.FindControl("ddlTax22");

                        float Rate = Convert.ToSingle(txtRate1.Text);
                        float Qantity = Convert.ToSingle(txtQantity1.Text);
                        float Rate1 = Convert.ToSingle(txtTax1Rate1.Text);
                        float Rate2 = Convert.ToSingle(txtTax2Rate1.Text);

                        if (ddlTax11.SelectedItem.Text == "CGST")
                        {
                            TotalCGST_ddlTax11 += (Rate * Qantity * Rate1 / 100);
                        }
                        else if (ddlTax11.SelectedItem.Text == "SGST")
                        {
                            TotalSGST_ddlTax11 += (Rate * Qantity * Rate1 / 100);
                        }
                        else
                        {
                            TotalIGST_ddlTax11 += (Rate * Qantity * Rate1 / 100);
                        }

                        if (ddlTax22.SelectedItem.Text == "CGST")
                        {
                            TotalCGST_ddlTax22 += (Rate * Qantity * Rate2 / 100);
                        }
                        else if (ddlTax22.SelectedItem.Text == "SGST")
                        {
                            TotalSGST_ddlTax22 += (Rate * Qantity * Rate2 / 100);
                        }
                        else
                        {
                            TotalIGST_ddlTax22 += (Rate * Qantity * Rate2 / 100);
                        }
                    }

                    lblcgst1.Text = (TotalCGST_ddlTax11 + TotalCGST_ddlTax22).ToString();
                    lblsgst1.Text = (TotalSGST_ddlTax11 + TotalSGST_ddlTax22).ToString();
                    lbligst1.Text = (TotalIGST_ddlTax11 + TotalIGST_ddlTax22).ToString();
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

        protected void LinkBtn_createvendor_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewVendor.aspx");
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
                int ProjectID = Convert.ToInt32(ddlProjects.SelectedValue);
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd1 = new SqlCommand("SP_GetTenderNumberByProjectID", conn);
                cmd1.Connection = conn;
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@ProjectId", ProjectID);
                using (SqlDataAdapter sda1 = new SqlDataAdapter(cmd1))
                {
                    DataTable ds = new DataTable();
                    sda1.Fill(ds);

                    DataRow firstRow;
                    firstRow = ds.NewRow();

                    int count1 = ds.Rows.Count;
                    int countTotal = count1 + 1;
                    firstRow["TenderNo"] = "NA";
                    firstRow["ID"] = countTotal;
                    ds.Rows.Add(firstRow);

                    ddltenderNumber.DataSource = ds;
                    ddltenderNumber.DataTextField = "TenderNo";
                    ddltenderNumber.DataValueField = "ID";
                    ddltenderNumber.DataBind();
                    ddltenderNumber.Items.Insert(0, new ListItem("Select Tender Number", "0"));


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

        protected void Btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
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

        protected void Btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                string tenNo = ddltenderNumber.SelectedItem.Text;

                if (tenNo == "NA")
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
                            cmd.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                            cmd.Parameters.AddWithValue("@FileName", fileName);
                            cmd.Parameters.AddWithValue("@FilePath", filePath);
                            cmd.Parameters.AddWithValue("@DocumentType", txtdocumenttype.Text);
                            cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@Belong", "WorkOrder");
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
                                lblMesDelete.Text = "WorkOrder File Uploaded Successfully";
                                ViewTenderFile();
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "WorkOrder File Not Uploaded Successfully";
                            }

                        }
                    }
                    else
                    {
                        // popup choose file
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Choose File For Uploaded!')", true);
                    }
                }
                else
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

                            cmd.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                            cmd.Parameters.AddWithValue("@FileName", fileName);
                            cmd.Parameters.AddWithValue("@FilePath", filePath);
                            cmd.Parameters.AddWithValue("@DocumentType", txtdocumenttype.Text);
                            cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@Belong", "WorkOrder");
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
                                lblMesDelete.Text = "WorkOrder File Uploaded Successfully";
                                ViewTenderFile();
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "WorkOrder File Not Uploaded Successfully";
                            }

                        }
                    }
                    else
                    {
                        // popup choose file
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

        protected void Btn_TenderQue_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection DeviceCon = new SqlConnection(strconnect))
                {
                    string tenNo = ddltenderNumber.SelectedItem.Text;
                    if (tenNo == "NA")
                    {
                        SqlCommand cmd = new SqlCommand("SP_SaveTenderVendorQue", DeviceCon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Question", txtque.Text);
                        cmd.Parameters.AddWithValue("@vendid", lblContactVendorid.Text);
                        cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Belong", "WorkOrder");
                        cmd.Parameters.AddWithValue("@tendid", '0');
                        cmd.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
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
                            lblMesDelete.Text = "WorkOrder Question Saved Successfully";
                            ViewTenderQuestionDetails();
                            txtque.Text = string.Empty;
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "WorkOrder Question  Not Saved Successfully";
                        }
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("SP_SaveTenderVendorQue", DeviceCon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Question", txtque.Text);
                        cmd.Parameters.AddWithValue("@vendid", lblContactVendorid.Text);
                        cmd.Parameters.AddWithValue("@tendid", ddltenderNumber.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Belong", "WorkOrder");
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
                            lblMesDelete.Text = "WorkOrder Question  Saved Successfully";
                            ViewTenderQuestionDetails();
                            txtque.Text = string.Empty;
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "WorkOrder Question  Not Saved Successfully";
                        }

                    }

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

        protected void ddltenderNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string tendername = ddltenderNumber.SelectedItem.Text;
                if (tendername == "NA")
                {
                    divitem.Visible = true;
                    CalculateTempdata();
                }
                else
                {
                    divitem.Visible = true;
                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetTenderVenderDetailsbyTenderID", UserCon);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);

                        cmd.Parameters.AddWithValue("@id", ddltenderNumber.SelectedItem.Value);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txttendername.Text = dt.Rows[0]["TenderName"].ToString();
                            lblContactVendorid.Text = dt.Rows[0]["id"].ToString();
                            ddlCategory.SelectedItem.Text = dt.Rows[0]["TenderBased"].ToString();
                            ddlSalesAgent.SelectedItem.Text = dt.Rows[0]["Sales_Agent"].ToString();
                            ddlSalesAgent.SelectedItem.Value = dt.Rows[0]["SaleagentID"].ToString();
                            txtClientNote.Text = dt.Rows[0]["Client_Note"].ToString();
                            txtTermsAndConditions.Text = dt.Rows[0]["Term_condition"].ToString();
                            ddlStatus.SelectedItem.Text = dt.Rows[0]["Status"].ToString();
                            txtpublishDate.Text = DateTime.Parse(dt.Rows[0]["publishdate"].ToString()).ToString("yyyy-MM-dd");

                            ddlauthname.SelectedItem.Text = dt.Rows[0]["AuthorityName"].ToString();
                            txtauthorityaddress.Text = dt.Rows[0]["Authorityaddress"].ToString();
                            txtaddressLine1.Text = dt.Rows[0]["AddressLine1"].ToString();
                            txtaddressline2.Text = dt.Rows[0]["AddressLine2"].ToString();
                            txtvillage.Text = dt.Rows[0]["Add_Street"].ToString();
                            txtDescription1.Text = dt.Rows[0]["Description"].ToString();
                            txtperiodofwork.Text = dt.Rows[0]["periodofwork"].ToString();
                            ddlpaymentmode.SelectedItem.Text = dt.Rows[0]["PaymentMode"].ToString();
                            txttendervalue.Text = dt.Rows[0]["estimatecontractvalue"].ToString();

                            ddllocationcountry.SelectedItem.Text = dt.Rows[0]["Country"].ToString();
                            ddllocationstate.SelectedItem.Text = dt.Rows[0]["AddState"].ToString();
                            int stateID = Convert.ToInt32(ddllocationstate.SelectedItem.Value);
                            getdistrictbystateId(stateID);
                            ddllocationdistrict.SelectedItem.Text = dt.Rows[0]["AddDistrict"].ToString();
                            int districtID = Convert.ToInt32(ddllocationdistrict.SelectedItem.Value);
                            getcitybydistrictid(districtID);
                            ddllocationcity.SelectedItem.Text = dt.Rows[0]["AddCity"].ToString();
                            txtlocationflatno.Text = dt.Rows[0]["Add_Block"].ToString();
                            txtlocationpincode.Text = dt.Rows[0]["Pincode"].ToString();

                            txtAuthcontno.Text = dt.Rows[0]["Auth_Contact"].ToString();
                            txtAuthposition1.Text = dt.Rows[0]["Auth_Position"].ToString();
                            txtAuthemail.Text = dt.Rows[0]["Auth_Email"].ToString();
                            ddlVenderName.SelectedItem.Text = dt.Rows[0]["Vend_Name"].ToString();
                            lblVendorName.Text = dt.Rows[0]["Vend_Name"].ToString();
                            lblContactPersonName1.Text = dt.Rows[0]["First_Name"].ToString();
                            lblContactPersonEmail1.Text = dt.Rows[0]["email"].ToString();
                            lblContactPersonPosition1.Text = dt.Rows[0]["Position"].ToString();
                            lblContactPersonmobno1.Text = dt.Rows[0]["phonenumber"].ToString();
                            lblvenderblock.Text = dt.Rows[0]["VAdd_Block"].ToString();
                            lblvenderstreet.Text = dt.Rows[0]["VAdd_Street"].ToString();
                            lblvendercity.Text = dt.Rows[0]["VAdd_City"].ToString();
                            lblvenderdistrict.Text = dt.Rows[0]["VAdd_District"].ToString();
                            lblvenderstate.Text = dt.Rows[0]["VAdd_State"].ToString();
                            lblvenercountry.Text = dt.Rows[0]["VAdd_Country"].ToString();
                            lblvenderpin1.Text = dt.Rows[0]["VAdd_PinCode"].ToString();

                            Calculatefilldata();
                            ViewTenderFile();
                            ViewTenderQuestionDetails();
                            CalculateTempdata();
                            GetTotalTenderItemVendorCount();
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

        protected void ddlVenderName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetByVendorAddress", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@id", ddlVenderName.SelectedItem.Value);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblContactVendorid.Text = dt.Rows[0]["ContactID"].ToString();
                    lblVendorName.Text = dt.Rows[0]["Vend_Name"].ToString();
                    lblContactPersonName1.Text = dt.Rows[0]["First_Name"].ToString();
                    lblContactPersonEmail1.Text = dt.Rows[0]["email"].ToString();
                    lblContactPersonPosition1.Text = dt.Rows[0]["Position"].ToString();
                    lblContactPersonmobno1.Text = dt.Rows[0]["phonenumber"].ToString();
                    lblvenderblock.Text = dt.Rows[0]["VAdd_Block"].ToString();
                    lblvenderstreet.Text = dt.Rows[0]["VAdd_Street"].ToString();
                    lblvendercity.Text = dt.Rows[0]["VAdd_City"].ToString();
                    lblvenderdistrict.Text = dt.Rows[0]["VAdd_District"].ToString();
                    lblvenderstate.Text = dt.Rows[0]["VAdd_State"].ToString();
                    lblvenercountry.Text = dt.Rows[0]["VAdd_Country"].ToString();
                    lblvenderpin1.Text = dt.Rows[0]["VAdd_PinCode"].ToString();
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

        protected void btnAddTenderItem_Click(object sender, EventArgs e)
        {
            try
            {
                string Custid = Convert.ToString(ddlCustomers.SelectedItem.Text);
                string Projectid = Convert.ToString(ddlProjects.SelectedItem.Text);
                string Saleagentid = Convert.ToString(ddlSalesAgent.SelectedItem.Text);
                string Category = Convert.ToString(ddlCategory.SelectedItem.Text);

                if (Custid == "Select Customer" || Saleagentid == "Select Sale Agent")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Customer AND Sale Agent!')", true);
                }
                else if (Category == "Select Category" || Projectid == "Select Project")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Project AND Category!')", true);
                }
                else
                {

                    TextBox txtItem = (TextBox)GridCalculate.FooterRow.FindControl("txtItem");
                    TextBox txtDescription = (TextBox)GridCalculate.FooterRow.FindControl("txtDescription");
                    TextBox txtQty = (TextBox)GridCalculate.FooterRow.FindControl("txtQty");
                    TextBox txtRate = (TextBox)GridCalculate.FooterRow.FindControl("txtRate");
                    TextBox txtRate1 = (TextBox)GridCalculate.FooterRow.FindControl("txtTax1Rate1");
                    TextBox txtRate2 = (TextBox)GridCalculate.FooterRow.FindControl("txtTax2Rate1");
                    DropDownList ddlTax1 = (DropDownList)GridCalculate.FooterRow.FindControl("ddltax1");
                    DropDownList ddlTax2 = (DropDownList)GridCalculate.FooterRow.FindControl("ddltax2");
                    float Rate = Convert.ToSingle(txtRate.Text);
                    float Subtotal = Convert.ToSingle(txtQty.Text) * Rate;
                    float Rate1 = Subtotal * (Convert.ToSingle(txtRate1.Text) / 100);
                    float Rate2 = Subtotal * (Convert.ToSingle(txtRate2.Text) / 100);

                    float TotalAmount = Rate1 + Rate2 + Subtotal;

                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_SaveTenderToVenderItem", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TenderID", ddltenderNumber.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@VendID", lblContactVendorid.Text);
                        cmd.Parameters.AddWithValue("@CustomerID", ddlCustomers.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Item", txtItem.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@Qnty", txtQty.Text);
                        cmd.Parameters.AddWithValue("@Rate", txtRate.Text);
                        cmd.Parameters.AddWithValue("@Tax1Name", ddlTax1.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Tax2Name", ddlTax2.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Tax1Rate", txtRate1.Text);
                        cmd.Parameters.AddWithValue("@Tax2Rate", txtRate2.Text);
                        cmd.Parameters.AddWithValue("@TotalAmont", TotalAmount);
                        cmd.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Empid", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@Createby", UserName);
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
                            lblMesDelete.Text = "Work Order New Item Added Successfully";
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Work Order New Item Not Added Successfully";
                        }
                        CalculateTempdata();
                        GetTotalTenderItemVendorCount();
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
                    SqlCommand com = new SqlCommand("SP_DeleteTenderToVendorItem", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
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
                        lblMesDelete.Text = "Tender Item Not Remove Successfully";
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

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_SaveWorkOrder", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@TenderID", int.Parse(ddltenderNumber.SelectedItem.Value));
                        cmd.Parameters.AddWithValue("@VendorID", int.Parse(lblContactVendorid.Text));
                        cmd.Parameters.AddWithValue("@Startdate", txtstartdate.Text);
                        cmd.Parameters.AddWithValue("@Enddate", txtenddate.Text);
                        cmd.Parameters.AddWithValue("@CompletionDate", txtcompletiondate.Text);
                        cmd.Parameters.AddWithValue("@WorkOrderNumber", txtworkorderNumber.Text);
                        cmd.Parameters.AddWithValue("@CustomerID", int.Parse(ddlCustomers.SelectedItem.Value));
                        cmd.Parameters.AddWithValue("@ProjectID", int.Parse(ddlProjects.SelectedItem.Value));
                        cmd.Parameters.AddWithValue("@TenderName", txttendername.Text);
                        cmd.Parameters.AddWithValue("@Sales_Agent", int.Parse(ddlSalesAgent.SelectedItem.Value));
                        cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription1.Text);
                        cmd.Parameters.AddWithValue("@TenderBased", ddlCategory.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Estimatecontractvalue", txttendervalue.Text);
                        cmd.Parameters.AddWithValue("@Country", ddllocationcountry.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@AddState", ddllocationstate.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@AddDistrict", ddllocationdistrict.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@AddCity", ddllocationcity.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Add_Block", txtlocationflatno.Text);
                        cmd.Parameters.AddWithValue("@Add_Street", txtvillage.Text);
                        cmd.Parameters.AddWithValue("@Addressline1", txtaddressLine1.Text);
                        cmd.Parameters.AddWithValue("@Addressline2", txtaddressline2.Text);
                        cmd.Parameters.AddWithValue("@PeriodOfWork", int.Parse(txtperiodofwork.Text));
                        cmd.Parameters.AddWithValue("@Publishdate", txtpublishDate.Text);
                        cmd.Parameters.AddWithValue("@AuthorityName", ddlauthname.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@AuthorityAddress", txtauthorityaddress.Text);
                        cmd.Parameters.AddWithValue("@PaymentMode", ddlpaymentmode.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Pincode", txtlocationpincode.Text);
                        cmd.Parameters.AddWithValue("@SaveAs", "Save");
                        cmd.Parameters.AddWithValue("@Status1", "true");
                        cmd.Parameters.AddWithValue("@Client_Note", txtClientNote.Text);
                        cmd.Parameters.AddWithValue("@Term_condition", txtTermsAndConditions.Text);
                        cmd.Parameters.AddWithValue("@Created_by", UserName);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@Email", txtAuthemail.Text);
                        cmd.Parameters.AddWithValue("@Position", txtAuthposition1.Text);
                        cmd.Parameters.AddWithValue("@Contact", txtAuthcontno.Text);
                        cmd.Parameters.AddWithValue("@TotalAmountTender", lbltotalamt1.Text);
                        cmd.Parameters.AddWithValue("@TotalSubTotal", lblsubtotal1.Text);
                        cmd.Parameters.AddWithValue("@TotalTaxTotal", lbltotaltax1.Text);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {
                            //string save = "fgsave123q";
                            //Response.Redirect("~/WorkOrder.aspx?svd1=" + save + "", false);
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Work Order Details Not Save Successfully";
                        }
                    }

                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {
                        foreach (GridViewRow gvrow in GridCalculate.Rows)
                        {

                            string roleID = GridCalculate.DataKeys[gvrow.RowIndex].Value.ToString();
                            Label lblItem1 = (Label)gvrow.FindControl("lblItem1");
                            Label lblDescription1 = (Label)gvrow.FindControl("lblDescription1");
                            Label lblQuantity1 = (Label)gvrow.FindControl("lblQuantity1");
                            Label lblRate1 = (Label)gvrow.FindControl("lblRate1");
                            Label lblTax1Name1 = (Label)gvrow.FindControl("lblTax1tax11");
                            Label lblTax1Rate1 = (Label)gvrow.FindControl("lblTax1Rate1");
                            Label lblTax2Name1 = (Label)gvrow.FindControl("lblTax2Name1");
                            Label lblTax2Rate1 = (Label)gvrow.FindControl("lblTax2Rate1");
                            Label lblTotalAmountTender1 = (Label)gvrow.FindControl("lblTotalAmountTender1");

                            SqlCommand cmd1 = new SqlCommand("SP_SaveTenderToVenderWorkOrderItem", con1);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@TenderID", ddltenderNumber.SelectedItem.Value);
                            cmd1.Parameters.AddWithValue("@VendID", lblContactVendorid.Text);
                            cmd1.Parameters.AddWithValue("@CustomerID", ddlCustomers.SelectedItem.Value);
                            cmd1.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                            cmd1.Parameters.AddWithValue("@Item", lblItem1.Text);
                            cmd1.Parameters.AddWithValue("@Description", lblDescription1.Text);
                            cmd1.Parameters.AddWithValue("@Qnty", lblQuantity1.Text);
                            cmd1.Parameters.AddWithValue("@Rate", lblRate1.Text);
                            cmd1.Parameters.AddWithValue("@Tax1Name", lblTax1Name1.Text);
                            cmd1.Parameters.AddWithValue("@Tax2Name", lblTax2Name1.Text);
                            cmd1.Parameters.AddWithValue("@Tax1Rate", lblTax1Rate1.Text);
                            cmd1.Parameters.AddWithValue("@Tax2Rate", lblTax2Rate1.Text);
                            cmd1.Parameters.AddWithValue("@TotalAmont", lblTotalAmountTender1.Text);
                            cmd1.Parameters.AddWithValue("@WorkOrderNumber", txtworkorderNumber.Text);
                            cmd1.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                            cmd1.Parameters.AddWithValue("@Empid", UserId);
                            cmd1.Parameters.AddWithValue("@Designation", Designation);
                            cmd1.Parameters.AddWithValue("@Createby", UserName);
                            con1.Open();
                            dr1 = cmd1.ExecuteReader();
                            while (dr1.Read())
                            {
                                result1 = dr1[0].ToString();
                            }
                            Result1 = int.Parse(result1);
                            if (Result1 > 0)
                            {
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tender Allocated Successfully!')", true);
                            }
                            else
                            {
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tender Not Allocated Successfully!')", true);
                            }
                            con1.Close();
                        }

                    }

                    using (SqlConnection con2 = new SqlConnection(strconnect))
                    {
                        foreach (GridViewRow gvrow in GridWorkOrderQue.Rows)
                        {
                            string roleID1 = GridWorkOrderQue.DataKeys[gvrow.RowIndex].Value.ToString();
                            Label lblQuestion1 = (Label)gvrow.FindControl("lblQuestion1");
                            Label lblAnswer1 = (Label)gvrow.FindControl("lblAnswer1");
                            Label lblDoc_File1 = (Label)gvrow.FindControl("lblDoc_File1");
                            Label lblDoc_Filepath = (Label)gvrow.FindControl("lblFilePath");
                            string extention = System.IO.Path.GetExtension(lblDoc_File1.Text);
                            SqlCommand cmd2 = new SqlCommand("SP_SaveWorkOrderQueAns", con2);
                            cmd2.CommandType = CommandType.StoredProcedure;

                            cmd2.Parameters.AddWithValue("@TenderID", ddltenderNumber.SelectedItem.Value);
                            cmd2.Parameters.AddWithValue("@VendID", lblContactVendorid.Text);
                            cmd2.Parameters.AddWithValue("@Tend_Que", lblQuestion1.Text);
                            cmd2.Parameters.AddWithValue("@Tend_Ans", lblAnswer1.Text);
                            cmd2.Parameters.AddWithValue("@Doc_File", lblDoc_File1.Text);
                            cmd2.Parameters.AddWithValue("@Doc_Extension", extention);
                            cmd2.Parameters.AddWithValue("@filepath", lblDoc_Filepath.Text);
                            cmd2.Parameters.AddWithValue("@WorkOrderNumber", txtworkorderNumber.Text);
                            cmd2.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                            cmd2.Parameters.AddWithValue("@Empid", UserId);
                            cmd2.Parameters.AddWithValue("@Designation", Designation);
                            cmd2.Parameters.AddWithValue("@Createby", UserName);
                            con2.Open();
                            dr2 = cmd2.ExecuteReader();
                            while (dr2.Read())
                            {
                                result2 = dr2[0].ToString();
                            }
                            Result2 = int.Parse(result2);
                            if (Result2 > 0)
                            {
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Save Work Order Question Successfully!')", true);
                            }
                            else
                            {
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Save Work Order QuestionSuccessfully!')", true);
                            }
                            con2.Close();
                        }


                    }

                    using (SqlConnection con3 = new SqlConnection(strconnect))
                    {
                        foreach (GridViewRow gvrow in GridWorkOrderFile.Rows)
                        {
                            string roleID1 = GridWorkOrderFile.DataKeys[gvrow.RowIndex].Value.ToString();
                            Label lblDocument_Type = (Label)gvrow.FindControl("lblDocument_Type");
                            Label lblTenderFileName1 = (Label)gvrow.FindControl("lblTenderFileName1");
                            Label lblTenderFilePath1 = (Label)gvrow.FindControl("lblTenderFilePath1");
                            string extention = System.IO.Path.GetExtension(lblTenderFileName1.Text);
                            SqlCommand cmd3 = new SqlCommand("SP_UploadWorkOrderAttachmentFile", con3);
                            cmd3.CommandType = CommandType.StoredProcedure;
                            cmd3.Parameters.AddWithValue("@FileName", lblTenderFileName1.Text);
                            cmd3.Parameters.AddWithValue("@Extention", extention);
                            cmd3.Parameters.AddWithValue("@filepath", lblTenderFilePath1.Text);
                            cmd3.Parameters.AddWithValue("@WorkOrderNumber", txtworkorderNumber.Text);
                            cmd3.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                            cmd3.Parameters.AddWithValue("@DocumentType", lblDocument_Type.Text);
                            cmd3.Parameters.AddWithValue("@EmpId", UserId);
                            cmd3.Parameters.AddWithValue("@Designation", Designation);
                            cmd3.Parameters.AddWithValue("@Createby", UserName);
                            con3.Open();
                            dr3 = cmd3.ExecuteReader();
                            while (dr3.Read())
                            {
                                result3 = dr3[0].ToString();
                            }
                            Result3 = int.Parse(result3);
                            if (Result3 > 0)
                            {
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tender Allocated Successfully!')", true);
                            }
                            else
                            {
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tender Not Allocated Successfully!')", true);
                            }
                            con3.Close();
                        }
                    }
                    Clear();
                    TruncateData();
                    string save = "fgsave123q";
                    Response.Redirect("~/WorkOrder.aspx?svd1=" + save + "", false);

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

        protected void Btn_SaveAsdraft_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_SaveWorkOrder", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@TenderID", ddltenderNumber.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@VendorID", lblContactVendorid.Text);
                        cmd.Parameters.AddWithValue("@Startdate", txtstartdate.Text);
                        cmd.Parameters.AddWithValue("@Enddate", txtenddate.Text);
                        cmd.Parameters.AddWithValue("@CompletionDate", txtcompletiondate.Text);
                        cmd.Parameters.AddWithValue("@WorkOrderNumber", txtworkorderNumber.Text);
                        cmd.Parameters.AddWithValue("@CustomerID", ddlCustomers.SelectedValue);
                        cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedValue);
                        cmd.Parameters.AddWithValue("@TenderName", txttendername.Text);
                        cmd.Parameters.AddWithValue("@Sales_Agent", ddlSalesAgent.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription1.Text);
                        cmd.Parameters.AddWithValue("@TenderBased", ddlCategory.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Estimatecontractvalue", txttendervalue.Text);
                        cmd.Parameters.AddWithValue("@Country", ddllocationcountry.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@AddState", ddllocationstate.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@AddDistrict", ddllocationdistrict.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@AddCity", ddllocationcity.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Add_Block", txtlocationflatno.Text);
                        cmd.Parameters.AddWithValue("@Add_Street", txtvillage.Text);
                        cmd.Parameters.AddWithValue("@Addressline1", txtaddressLine1.Text);
                        cmd.Parameters.AddWithValue("@Addressline2", txtaddressline2.Text);
                        cmd.Parameters.AddWithValue("@PeriodOfWork", txtperiodofwork.Text);
                        cmd.Parameters.AddWithValue("@Publishdate", txtpublishDate.Text);
                        cmd.Parameters.AddWithValue("@AuthorityName", ddlauthname.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@AuthorityAddress", txtauthorityaddress.Text);
                        cmd.Parameters.AddWithValue("@PaymentMode", ddlpaymentmode.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Pincode", txtlocationpincode.Text);
                        cmd.Parameters.AddWithValue("@SaveAs", "Draft");
                        cmd.Parameters.AddWithValue("@Status1", "false");
                        cmd.Parameters.AddWithValue("@Client_Note", txtClientNote.Text);
                        cmd.Parameters.AddWithValue("@Term_condition", txtTermsAndConditions.Text);
                        cmd.Parameters.AddWithValue("@Created_by", UserName);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@Email", txtAuthemail.Text);
                        cmd.Parameters.AddWithValue("@Position", txtAuthposition1.Text);
                        cmd.Parameters.AddWithValue("@Contact", txtAuthcontno.Text);
                        cmd.Parameters.AddWithValue("@TotalAmountTender", lbltotalamt1.Text);
                        cmd.Parameters.AddWithValue("@TotalSubTotal", lblsubtotal1.Text);
                        cmd.Parameters.AddWithValue("@TotalTaxTotal", lbltotaltax1.Text);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {
                            //string Draft = "fgdraft1234q";
                            //Response.Redirect("~/WorkOrder.aspx?Draft1=" + Draft + "", false);
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "WorkOrder  Details Not Added In Draft";
                        }
                    }
                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {
                        foreach (GridViewRow gvrow in GridCalculate.Rows)
                        {

                            string roleID = GridCalculate.DataKeys[gvrow.RowIndex].Value.ToString();
                            Label lblItem1 = (Label)gvrow.FindControl("lblItem1");
                            Label lblDescription1 = (Label)gvrow.FindControl("lblDescription1");
                            Label lblQuantity1 = (Label)gvrow.FindControl("lblQuantity1");
                            Label lblRate1 = (Label)gvrow.FindControl("lblRate1");
                            Label lblTax1Name1 = (Label)gvrow.FindControl("lblTax1tax11");
                            Label lblTax1Rate1 = (Label)gvrow.FindControl("lblTax1Rate1");
                            Label lblTax2Name1 = (Label)gvrow.FindControl("lblTax2Name1");
                            Label lblTax2Rate1 = (Label)gvrow.FindControl("lblTax2Rate1");
                            Label lblTotalAmountTender1 = (Label)gvrow.FindControl("lblTotalAmountTender1");

                            SqlCommand cmd1 = new SqlCommand("SP_SaveTenderToVenderWorkOrderItem", con1);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@TenderID", ddltenderNumber.SelectedItem.Value);
                            cmd1.Parameters.AddWithValue("@VendID", lblContactVendorid.Text);
                            cmd1.Parameters.AddWithValue("@CustomerID", ddlCustomers.SelectedItem.Value);
                            cmd1.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                            cmd1.Parameters.AddWithValue("@Item", lblItem1.Text);
                            cmd1.Parameters.AddWithValue("@Description", lblDescription1.Text);
                            cmd1.Parameters.AddWithValue("@Qnty", lblQuantity1.Text);
                            cmd1.Parameters.AddWithValue("@Rate", lblRate1.Text);
                            cmd1.Parameters.AddWithValue("@Tax1Name", lblTax1Name1.Text);
                            cmd1.Parameters.AddWithValue("@Tax2Name", lblTax2Name1.Text);
                            cmd1.Parameters.AddWithValue("@Tax1Rate", lblTax1Rate1.Text);
                            cmd1.Parameters.AddWithValue("@Tax2Rate", lblTax2Rate1.Text);
                            cmd1.Parameters.AddWithValue("@TotalAmont", lblTotalAmountTender1.Text);
                            cmd1.Parameters.AddWithValue("@WorkOrderNumber", txtworkorderNumber.Text);
                            cmd1.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                            cmd1.Parameters.AddWithValue("@Empid", UserId);
                            cmd1.Parameters.AddWithValue("@Designation", Designation);
                            cmd1.Parameters.AddWithValue("@Createby", UserName);
                            con1.Open();
                            dr1 = cmd1.ExecuteReader();
                            while (dr1.Read())
                            {
                                result1 = dr1[0].ToString();
                            }
                            Result1 = int.Parse(result1);
                            if (Result1 > 0)
                            {
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tender Allocated Successfully!')", true);
                            }
                            else
                            {
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tender Not Allocated Successfully!')", true);
                            }
                            con1.Close();
                        }

                    }

                    using (SqlConnection con2 = new SqlConnection(strconnect))
                    {
                        foreach (GridViewRow gvrow in GridWorkOrderQue.Rows)
                        {
                            string roleID1 = GridWorkOrderQue.DataKeys[gvrow.RowIndex].Value.ToString();
                            Label lblQuestion1 = (Label)gvrow.FindControl("lblQuestion1");
                            Label lblAnswer1 = (Label)gvrow.FindControl("lblAnswer1");
                            Label lblDoc_File1 = (Label)gvrow.FindControl("lblDoc_File1");
                            Label lblDoc_Filepath = (Label)gvrow.FindControl("lblFilePath");
                            string extention = System.IO.Path.GetExtension(lblDoc_File1.Text);
                            SqlCommand cmd2 = new SqlCommand("SP_SaveWorkOrderQueAns", con2);
                            cmd2.CommandType = CommandType.StoredProcedure;

                            cmd2.Parameters.AddWithValue("@TenderID", ddltenderNumber.SelectedItem.Value);
                            cmd2.Parameters.AddWithValue("@VendID", lblContactVendorid.Text);
                            cmd2.Parameters.AddWithValue("@Tend_Que", lblQuestion1.Text);
                            cmd2.Parameters.AddWithValue("@Tend_Ans", lblAnswer1.Text);
                            cmd2.Parameters.AddWithValue("@Doc_File", lblDoc_File1.Text);
                            cmd2.Parameters.AddWithValue("@Doc_Extension", extention);
                            cmd2.Parameters.AddWithValue("@filepath", lblDoc_Filepath.Text);
                            cmd2.Parameters.AddWithValue("@WorkOrderNumber", txtworkorderNumber.Text);
                            cmd2.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                            cmd2.Parameters.AddWithValue("@Empid", UserId);
                            cmd2.Parameters.AddWithValue("@Designation", Designation);
                            cmd2.Parameters.AddWithValue("@Createby", UserName);
                            con2.Open();
                            dr2 = cmd2.ExecuteReader();
                            while (dr2.Read())
                            {
                                result2 = dr2[0].ToString();
                            }
                            Result2 = int.Parse(result2);
                            if (Result2 > 0)
                            {
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Save Work Order Question Successfully!')", true);
                            }
                            else
                            {
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Save Work Order QuestionSuccessfully!')", true);
                            }
                            con2.Close();
                            TruncateData();
                        }


                    }

                    using (SqlConnection con3 = new SqlConnection(strconnect))
                    {
                        foreach (GridViewRow gvrow in GridWorkOrderFile.Rows)
                        {
                            string roleID1 = GridWorkOrderFile.DataKeys[gvrow.RowIndex].Value.ToString();
                            Label lblDocument_Type = (Label)gvrow.FindControl("lblDocument_Type");
                            Label lblTenderFileName1 = (Label)gvrow.FindControl("lblTenderFileName1");
                            Label lblTenderFilePath1 = (Label)gvrow.FindControl("lblTenderFilePath1");
                            string extention = System.IO.Path.GetExtension(lblTenderFileName1.Text);
                            SqlCommand cmd3 = new SqlCommand("SP_UploadWorkOrderAttachmentFile", con3);
                            cmd3.CommandType = CommandType.StoredProcedure;
                            cmd3.Parameters.AddWithValue("@FileName", lblTenderFileName1.Text);
                            cmd3.Parameters.AddWithValue("@Extention", extention);
                            cmd3.Parameters.AddWithValue("@filepath", lblTenderFilePath1.Text);
                            cmd3.Parameters.AddWithValue("@WorkOrderNumber", txtworkorderNumber.Text);
                            cmd3.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                            cmd3.Parameters.AddWithValue("@DocumentType", lblDocument_Type.Text);
                            cmd3.Parameters.AddWithValue("@EmpId", UserId);
                            cmd3.Parameters.AddWithValue("@Designation", Designation);
                            cmd3.Parameters.AddWithValue("@Createby", UserName);
                            con3.Open();
                            dr3 = cmd3.ExecuteReader();
                            while (dr3.Read())
                            {
                                result3 = dr3[0].ToString();
                            }
                            Result3 = int.Parse(result3);
                            if (Result3 > 0)
                            {
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tender Allocated Successfully!')", true);
                            }
                            else
                            {
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tender Not Allocated Successfully!')", true);
                            }
                            con3.Close();
                        }
                    }

                    Clear();
                    TruncateData();
                    string Draft = "fgdraft1234q";
                    Response.Redirect("~/WorkOrder.aspx?Draft1=" + Draft + "", false);

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

        protected void btnDeleteMeasurementFile_Click(object sender, EventArgs e)
        {
            try
            {
                string ID;
                var rows = GridWorkOrderFile.Rows;
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
                        lblMesDelete.Text = "WorkOrder File Details Deleted Successfully";
                        ViewTenderFile();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "WorkOrder File Details Not Deleted";
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

        protected void btnDeleteWorkorderQue_Click_Click(object sender, EventArgs e)
        {
            try
            {
                string ID;
                var rows = GridWorkOrderQue.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ID = ((Label)rows[rowindex].FindControl("tendvendmapid1")).Text;

                using (SqlConnection DeviceCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_DeleteTenderVenderQue", DeviceCon);
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
                        lblMesDelete.Text = "WorkOrder Question Details Deleted Successfully";
                        ViewTenderQuestionDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "WorkOrder Question Details Not Deleted Successfully";
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
                TextBox txtRate = (TextBox)row.FindControl("txtRate1");
                TextBox txtTax1Rate = (TextBox)row.FindControl("txtTax1Rate1");
                TextBox txtTax2Rate = (TextBox)row.FindControl("txtTax2Rate1");
                Label lblTotalAmount = (Label)row.FindControl("lblTotalAmountTender1");
                DropDownList ddlTax11 = (DropDownList)row.FindControl("ddlTax11");
                DropDownList ddlTax22 = (DropDownList)row.FindControl("ddlTax22");
                string ItemID = ((Label)rows[rowindex].FindControl("WorkOrderitemid1")).Text;
                int quantity = Convert.ToInt32(txtQty.Text);

                float rate;
                if (string.IsNullOrEmpty(txtRate.Text))
                {
                    rate = 0;
                }
                else
                {
                    rate = Convert.ToSingle(txtRate.Text);
                }

                float tax1Rate;
                if (string.IsNullOrEmpty(txtTax1Rate.Text))
                {
                    tax1Rate = 0;
                }
                else
                {
                    tax1Rate = Convert.ToSingle(txtTax1Rate.Text);
                }

                float tax2Rate;
                if (string.IsNullOrEmpty(txtTax2Rate.Text))
                {
                    tax2Rate = 0;
                }
                else
                {
                    tax2Rate = Convert.ToSingle(txtTax2Rate.Text);
                }
                float Subtotal = quantity * rate;
                float totalAmount = Subtotal + (Subtotal * tax1Rate / 100) + (Subtotal * tax2Rate / 100);
                lblTotalAmount.Text = totalAmount.ToString();

                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateTenderToVenderItem", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ItemID);
                        cmd.Parameters.AddWithValue("@TenderID", ddltenderNumber.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@VendID", lblContactVendorid.Text);
                        cmd.Parameters.AddWithValue("@CustomerID", ddlCustomers.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Item", Item.Text);
                        cmd.Parameters.AddWithValue("@Description", Description.Text);
                        cmd.Parameters.AddWithValue("@Qnty", quantity);
                        cmd.Parameters.AddWithValue("@Rate", rate);
                        cmd.Parameters.AddWithValue("@Tax1Name", ddlTax11.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Tax2Name", ddlTax22.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Tax1Rate", tax1Rate);
                        cmd.Parameters.AddWithValue("@Tax2Rate", tax2Rate);
                        cmd.Parameters.AddWithValue("@TotalAmont", totalAmount);
                        cmd.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
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

                        CalculateTempdata();
                        GetTotalTenderItemVendorCount();
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

        protected void txtRate1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var rows = GridCalculate.Rows;
                TextBox txtRate = (TextBox)sender;
                GridViewRow row = (GridViewRow)txtRate.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                Label Item = (Label)row.FindControl("lblItem1");
                Label Description = (Label)row.FindControl("lblDescription1");
                TextBox txtQty = (TextBox)row.FindControl("txtQty1");
                TextBox txtTax1Rate = (TextBox)row.FindControl("txtTax1Rate1");
                TextBox txtTax2Rate = (TextBox)row.FindControl("txtTax2Rate1");
                Label lblTotalAmount = (Label)row.FindControl("lblTotalAmountTender1");
                DropDownList ddlTax11 = (DropDownList)row.FindControl("ddlTax11");
                DropDownList ddlTax22 = (DropDownList)row.FindControl("ddlTax22");
                string ItemID = ((Label)rows[rowindex].FindControl("WorkOrderitemid1")).Text;
                int quantity = Convert.ToInt32(txtQty.Text);

                float rate;
                if (string.IsNullOrEmpty(txtRate.Text))
                {
                    rate = 0;
                }
                else
                {
                    rate = Convert.ToSingle(txtRate.Text);
                }

                float tax1Rate;
                if (string.IsNullOrEmpty(txtTax1Rate.Text))
                {
                    tax1Rate = 0;
                }
                else
                {
                    tax1Rate = Convert.ToSingle(txtTax1Rate.Text);
                }

                float tax2Rate;
                if (string.IsNullOrEmpty(txtTax2Rate.Text))
                {
                    tax2Rate = 0;
                }
                else
                {
                    tax2Rate = Convert.ToSingle(txtTax2Rate.Text);
                }
                float Subtotal = quantity * rate;
                float totalAmount = Subtotal + (Subtotal * tax1Rate / 100) + (Subtotal * tax2Rate / 100);
                lblTotalAmount.Text = totalAmount.ToString();

                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateTenderToVenderItem", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ItemID);
                        cmd.Parameters.AddWithValue("@TenderID", ddltenderNumber.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@VendID", lblContactVendorid.Text);
                        cmd.Parameters.AddWithValue("@CustomerID", ddlCustomers.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Item", Item.Text);
                        cmd.Parameters.AddWithValue("@Description", Description.Text);
                        cmd.Parameters.AddWithValue("@Qnty", quantity);
                        cmd.Parameters.AddWithValue("@Rate", rate);
                        cmd.Parameters.AddWithValue("@Tax1Name", ddlTax11.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Tax2Name", ddlTax22.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Tax1Rate", tax1Rate);
                        cmd.Parameters.AddWithValue("@Tax2Rate", tax2Rate);
                        cmd.Parameters.AddWithValue("@TotalAmont", totalAmount);
                        cmd.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Empid", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@Createby", UserName);

                        con.Open();

                        int i = cmd.ExecuteNonQuery();

                        if (i < 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Item Rate Details Updated  Successfully";
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Item Rate Details Not Updated Successfully";
                        }

                        CalculateTempdata();
                        GetTotalTenderItemVendorCount();
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

        protected void txtTax1Rate1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var rows = GridCalculate.Rows;
                TextBox txtTax1Rate = (TextBox)sender;
                GridViewRow row = (GridViewRow)txtTax1Rate.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                Label Item = (Label)row.FindControl("lblItem1");
                Label Description = (Label)row.FindControl("lblDescription1");
                TextBox txtQty = (TextBox)row.FindControl("txtQty1");
                TextBox txtRate = (TextBox)row.FindControl("txtRate1");
                TextBox txtTax2Rate = (TextBox)row.FindControl("txtTax2Rate1");
                Label lblTotalAmount = (Label)row.FindControl("lblTotalAmountTender1");
                DropDownList ddlTax11 = (DropDownList)row.FindControl("ddlTax11");
                DropDownList ddlTax22 = (DropDownList)row.FindControl("ddlTax22");
                string ItemID = ((Label)rows[rowindex].FindControl("WorkOrderitemid1")).Text;
                int quantity = Convert.ToInt32(txtQty.Text);

                float rate;
                if (string.IsNullOrEmpty(txtRate.Text))
                {
                    rate = 0;
                }
                else
                {
                    rate = Convert.ToSingle(txtRate.Text);
                }

                float tax1Rate;
                if (string.IsNullOrEmpty(txtTax1Rate.Text))
                {
                    tax1Rate = 0;
                }
                else
                {
                    tax1Rate = Convert.ToSingle(txtTax1Rate.Text);
                }

                float tax2Rate;
                if (string.IsNullOrEmpty(txtTax2Rate.Text))
                {
                    tax2Rate = 0;
                }
                else
                {
                    tax2Rate = Convert.ToSingle(txtTax2Rate.Text);
                }
                float Subtotal = quantity * rate;
                float totalAmount = Subtotal + (Subtotal * tax1Rate / 100) + (Subtotal * tax2Rate / 100);
                lblTotalAmount.Text = totalAmount.ToString();

                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateTenderToVenderItem", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ItemID);
                        cmd.Parameters.AddWithValue("@TenderID", ddltenderNumber.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@VendID", lblContactVendorid.Text);
                        cmd.Parameters.AddWithValue("@CustomerID", ddlCustomers.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Item", Item.Text);
                        cmd.Parameters.AddWithValue("@Description", Description.Text);
                        cmd.Parameters.AddWithValue("@Qnty", quantity);
                        cmd.Parameters.AddWithValue("@Rate", rate);
                        cmd.Parameters.AddWithValue("@Tax1Name", ddlTax11.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Tax2Name", ddlTax22.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Tax1Rate", tax1Rate);
                        cmd.Parameters.AddWithValue("@Tax2Rate", tax2Rate);
                        cmd.Parameters.AddWithValue("@TotalAmont", totalAmount);
                        cmd.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Empid", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@Createby", UserName);

                        con.Open();

                        int i = cmd.ExecuteNonQuery();

                        if (i < 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Item Tax Rate Details Updated Successfully";
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Item Tax Rate Details Not Updated Successfully";
                        }

                        CalculateTempdata();
                        GetTotalTenderItemVendorCount();
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


        protected void txtTax2Rate1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                var rows = GridCalculate.Rows;
                TextBox txtTax2Rate = (TextBox)sender;
                GridViewRow row = (GridViewRow)txtTax2Rate.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                Label Item = (Label)row.FindControl("lblItem1");
                Label Description = (Label)row.FindControl("lblDescription1");
                TextBox txtQty = (TextBox)row.FindControl("txtQty1");
                TextBox txtRate = (TextBox)row.FindControl("txtRate1");
                TextBox txtTax1Rate = (TextBox)row.FindControl("txtTax1Rate1");
                Label lblTotalAmount = (Label)row.FindControl("lblTotalAmountTender1");
                DropDownList ddlTax11 = (DropDownList)row.FindControl("ddlTax11");
                DropDownList ddlTax22 = (DropDownList)row.FindControl("ddlTax22");
                string ItemID = ((Label)rows[rowindex].FindControl("WorkOrderitemid1")).Text;
                int quantity = Convert.ToInt32(txtQty.Text);

                float rate;
                if (string.IsNullOrEmpty(txtRate.Text))
                {
                    rate = 0;
                }
                else
                {
                    rate = Convert.ToSingle(txtRate.Text);
                }

                float tax1Rate;
                if (string.IsNullOrEmpty(txtTax1Rate.Text))
                {
                    tax1Rate = 0;
                }
                else
                {
                    tax1Rate = Convert.ToSingle(txtTax1Rate.Text);
                }

                float tax2Rate;
                if (string.IsNullOrEmpty(txtTax2Rate.Text))
                {
                    tax2Rate = 0;
                }
                else
                {
                    tax2Rate = Convert.ToSingle(txtTax2Rate.Text);
                }
                float Subtotal = quantity * rate;
                float totalAmount = Subtotal + (Subtotal * tax1Rate / 100) + (Subtotal * tax2Rate / 100);
                lblTotalAmount.Text = totalAmount.ToString();

                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateTenderToVenderItem", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ItemID);
                        cmd.Parameters.AddWithValue("@TenderID", ddltenderNumber.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@VendID", lblContactVendorid.Text);
                        cmd.Parameters.AddWithValue("@CustomerID", ddlCustomers.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@ProjectID", ddlProjects.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Item", Item.Text);
                        cmd.Parameters.AddWithValue("@Description", Description.Text);
                        cmd.Parameters.AddWithValue("@Qnty", quantity);
                        cmd.Parameters.AddWithValue("@Rate", rate);
                        cmd.Parameters.AddWithValue("@Tax1Name", ddlTax11.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Tax2Name", ddlTax22.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Tax1Rate", tax1Rate);
                        cmd.Parameters.AddWithValue("@Tax2Rate", tax2Rate);
                        cmd.Parameters.AddWithValue("@TotalAmont", totalAmount);
                        cmd.Parameters.AddWithValue("@TenderNumber", ddltenderNumber.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Empid", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@Createby", UserName);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i < 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Item Tax Rate Details Updated Successfully";
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Item Details Not Updated Successfully";
                        }

                        CalculateTempdata();
                        GetTotalTenderItemVendorCount();
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

        //--------------------------------------------------------------------------//

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