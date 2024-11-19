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
    public partial class EditInventory_Product : System.Web.UI.Page
    {
        #region " Class Level Variable "

        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result, InventoryProdid, Publish;
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

        #region " Private Functions "

        #endregion

        #region " Protected Functions "

        #endregion

        #region " Public Functions "
   

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
        protected void bindCategory()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetProjectCategory", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlProjectCategory.DataSource = ds.Tables[0];
                    ddlProjectCategory.DataTextField = "ProductCategory";
                    ddlProjectCategory.DataValueField = "ID";
                    ddlProjectCategory.DataBind();
                    ddlProjectCategory.Items.Insert(0, new ListItem("Select Category", "0"));
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

        protected void bindMeasurement()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetMeasurement", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlMeasurement.DataSource = ds.Tables[0];
                    ddlMeasurement.DataTextField = "Unit";
                    ddlMeasurement.DataValueField = "ID";
                    ddlMeasurement.DataBind();
                    ddlMeasurement.Items.Insert(0, new ListItem("Select Measurement", "0"));
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
            txtProdName.Text = string.Empty;
            ddlProdType.SelectedIndex = -1;
            ddlDepo.SelectedIndex = -1;
            txtDesp.Text = string.Empty;
            txtBrand.Text = string.Empty;
            ddlProjectCategory.SelectedIndex = -1;
            txtQuantity.Text = string.Empty;
            txtRate.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;

        }

        public void GetInventoryProdDetailsByID()
        {
            try
            {
                InventoryProdid = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                lblInventoryProdid.Text = InventoryProdid;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetInventoryProdDetailsByID", UserCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ID", lblInventoryProdid.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        txtProdName.Text = dt.Rows[0]["ProductName"].ToString();
                        ddlProdType.SelectedItem.Text = dt.Rows[0]["ProductType"].ToString();
                        ddlDepo.SelectedItem.Value = dt.Rows[0]["DepoID"].ToString();
                        ddlDepo.SelectedItem.Text = dt.Rows[0]["DepoName"].ToString();
                        txtDesp.Text = dt.Rows[0]["Description"].ToString();
                        txtBrand.Text = dt.Rows[0]["BrandName"].ToString();
                        ddlProjectCategory.SelectedItem.Text = dt.Rows[0]["Category"].ToString();
                        txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
                        ddlMeasurement.SelectedItem.Text = dt.Rows[0]["Measurement"].ToString();
                        string selectedMeasurement = ddlMeasurement.SelectedItem.Text;
                        Measuerment(selectedMeasurement);
                        txtRate.Text = dt.Rows[0]["Rate"].ToString();
                        txtTotalAmount.Text = dt.Rows[0]["TotalAmount"].ToString();
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

        public void Measuerment(string selectedMeasurement)
        {
            try
            {
                 selectedMeasurement = ddlMeasurement.SelectedItem.Text;

                switch (selectedMeasurement)
                {
                    case "millimeter":
                        txtAbbreviations.Attributes["placeholder"] = "mm";
                        break;
                    case "centimeter":
                        txtAbbreviations.Attributes["placeholder"] = "cm";
                        break;
                    case "meter":
                        txtAbbreviations.Attributes["placeholder"] = "m";
                        break;
                    case "kilogram":
                        txtAbbreviations.Attributes["placeholder"] = "kg";
                        break;
                    case "gram":
                        txtAbbreviations.Attributes["placeholder"] = "g";
                        break;
                    case "milligram":
                        txtAbbreviations.Attributes["placeholder"] = "mg";
                        break;
                    case "liter":
                        txtAbbreviations.Attributes["placeholder"] = "L";
                        break;
                    case "milliliter":
                        txtAbbreviations.Attributes["placeholder"] = "ml";
                        break;
                    case "inch":
                        txtAbbreviations.Attributes["placeholder"] = "in";
                        break;
                    case "foot":
                        txtAbbreviations.Attributes["placeholder"] = "ft";
                        break;
                    case "yard":
                        txtAbbreviations.Attributes["placeholder"] = "yd";
                        break;
                    case "mile":
                        txtAbbreviations.Attributes["placeholder"] = "mi";
                        break;
                    case "pound":
                        txtAbbreviations.Attributes["placeholder"] = "lb";
                        break;
                    case "degrees Celsius":
                        txtAbbreviations.Attributes["placeholder"] = "°C";
                        break;
                    case "degrees Fahrenheit":
                        txtAbbreviations.Attributes["placeholder"] = "°F";
                        break;
                    case "Kelvin":
                        txtAbbreviations.Attributes["placeholder"] = "K";
                        break;
                    default:
                        txtAbbreviations.Attributes["placeholder"] = "Enter Quantity";
                        txtAbbreviations.ReadOnly = false;

                        break;
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

                        if (!IsPostBack)
                        {
                         
                            bindCategory();
                            bindDepo();
                            bindMeasurement();
                            GetInventoryProdDetailsByID();
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
                               
                                bindDepoEmpID();
                                bindMeasurement();
                                GetInventoryProdDetailsByID();
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inventory_Product.aspx");
        }

        protected void ddlMeasurement_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedMeasurement = ddlMeasurement.SelectedItem.Text;

                switch (selectedMeasurement)
                {
                    case "millimeter":
                        txtAbbreviations.Attributes["placeholder"] = "mm";
                        break;
                    case "centimeter":
                        txtAbbreviations.Attributes["placeholder"] = "cm";
                        break;
                    case "meter":
                        txtAbbreviations.Attributes["placeholder"] = "m";
                        break;
                    case "kilogram":
                        txtAbbreviations.Attributes["placeholder"] = "kg";
                        break;
                    case "gram":
                        txtAbbreviations.Attributes["placeholder"] = "g";
                        break;
                    case "milligram":
                        txtAbbreviations.Attributes["placeholder"] = "mg";
                        break;
                    case "liter":
                        txtAbbreviations.Attributes["placeholder"] = "L";
                        break;
                    case "milliliter":
                        txtAbbreviations.Attributes["placeholder"] = "ml";
                        break;
                    case "inch":
                        txtAbbreviations.Attributes["placeholder"] = "in";
                        break;
                    case "foot":
                        txtAbbreviations.Attributes["placeholder"] = "ft";
                        break;
                    case "yard":
                        txtAbbreviations.Attributes["placeholder"] = "yd";
                        break;
                    case "mile":
                        txtAbbreviations.Attributes["placeholder"] = "mi";
                        break;
                    case "pound":
                        txtAbbreviations.Attributes["placeholder"] = "lb";
                        break;
                    case "degrees Celsius":
                        txtAbbreviations.Attributes["placeholder"] = "°C";
                        break;
                    case "degrees Fahrenheit":
                        txtAbbreviations.Attributes["placeholder"] = "°F";
                        break;
                    case "Kelvin":
                        txtAbbreviations.Attributes["placeholder"] = "K";
                        break;
                    default:
                        txtAbbreviations.Attributes["placeholder"] = "Enter Quantity";
                        txtAbbreviations.ReadOnly = false;

                        break;
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

        protected void btn_UpdateInventoryProd_Click(object sender, EventArgs e)
        {
            try
            {
                double rate = Convert.ToDouble(txtRate.Text);
                int quantity = Convert.ToInt32(txtQuantity.Text);

                double totalAmount = rate * quantity;

                txtTotalAmount.Text = totalAmount.ToString();

                SqlConnection con = new SqlConnection(strconnect);  // db connect
                SqlCommand cmd = new SqlCommand("SP_UpdateInventoryProd", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", lblInventoryProdid.Text);
                cmd.Parameters.AddWithValue("@ProductName", txtProdName.Text);
                cmd.Parameters.AddWithValue("@ProductType", ddlProdType.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@DepoID", ddlDepo.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@DepoName", ddlDepo.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Description", txtDesp.Text);
                cmd.Parameters.AddWithValue("@BrandName", txtBrand.Text);
                cmd.Parameters.AddWithValue("@Category", ddlProjectCategory.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@Measurement", ddlMeasurement.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Rate", txtRate.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", txtTotalAmount.Text);
                cmd.Parameters.AddWithValue("@Status", RadioButtonListVendor.SelectedValue);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i < 0)
                {
                    string edit = "xcvfedit";
                    Response.Redirect("~/Inventory_Product.aspx?edit1=" + edit + "", false);
                    
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Inventory Product Not Updated Successfully";
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
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double rate = Convert.ToDouble(txtRate.Text);
                int quantity = Convert.ToInt32(txtQuantity.Text);

                double totalAmount = rate * quantity;

                txtTotalAmount.Text = totalAmount.ToString();
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

        protected void txtRate_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double rate = Convert.ToDouble(txtRate.Text);
                int quantity = Convert.ToInt32(txtQuantity.Text);


                double totalAmount = rate * quantity;


                txtTotalAmount.Text = totalAmount.ToString();
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