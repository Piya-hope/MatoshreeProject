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

using System.Net;
using System.Net.Mail;
using System.Text;
#endregion

namespace MatoshreeProject
{
    public partial class BasicSetting : System.Web.UI.Page
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
        #endregion

        #region " Constructor "


        #endregion

        #region " Private Variables "


        #endregion

        #region " Shared Variables "


        #endregion

        #region " Public Variables "
        int Id;
        #endregion

        #region " Public Properties "


        #endregion

        #region " Private Functions "


        #endregion

        #region " Protected Functions "
        protected void bindCategory()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetExpCategory", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlExpCategory2.DataSource = ds.Tables[0];
                    ddlExpCategory2.DataTextField = "Category_Name";
                    ddlExpCategory2.DataValueField = "ID";
                    ddlExpCategory2.DataBind();
                    ddlExpCategory2.Items.Insert(0, new ListItem("Select Category", "0"));
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

        protected void bindState()
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
                    ddlStatename.DataSource = ds.Tables[0];
                    ddlStatename.DataTextField = "State_Name";
                    ddlStatename.DataValueField = "ID";
                    ddlStatename.DataBind();
                    ddlStatename.Items.Insert(0, new ListItem("Select State", "0"));
                    //---------------------------For City ddl-------------------------//
                    ddlState1.DataSource = ds.Tables[0];
                    ddlState1.DataTextField = "State_Name";
                    ddlState1.DataValueField = "ID";
                    ddlState1.DataBind();
                    ddlState1.Items.Insert(0, new ListItem("Select State", "0"));
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

        protected void binddistrict()
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
                    ddldistrict1.DataSource = ds.Tables[0];
                    ddldistrict1.DataTextField = "Disttrict_Name";
                    ddldistrict1.DataValueField = "District_ID";
                    ddldistrict1.DataBind();
                    ddldistrict1.Items.Insert(0, new ListItem("Select District", "0"));
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
        #endregion

        #region " Public Functions "
        public DataTable GetDocFieldDetails()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewDocField", con))
                    {
                        ad.Fill(table);
                        GridField.DataSource = table;
                        GridField.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                string ErrorMessgage = ex.Message;
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", con1);
                cmdex.CommandType = CommandType.StoredProcedure;
                cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                cmdex.Parameters.AddWithValue("@Method", method);
                cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                con1.Open();
                int RowEx = cmdex.ExecuteNonQuery();
                if (RowEx < 0)
                {
                    //lblMessage.Visible = false;
                    //lblMessage.Text = "Error Details Save Successfully";
                }
                else
                {
                    //lblMessage.Visible = false;
                    //lblMessage.Text = "Error Details Not Save Successfully";
                }
            }
            return table;
        }

        protected void bindDepartment()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetDeptName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlDepartment.DataSource = ds.Tables[0];
                    ddlDepartment.DataTextField = "Dept_Name";
                    ddlDepartment.DataValueField = "Dept_ID";
                    ddlDepartment.DataBind();
                    ddlDepartment.Items.Insert(0, new ListItem("Select Department", "0"));


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

        protected void bindRole()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewRolesByGroup", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlRole.DataSource = ds.Tables[0];
                    ddlRole.DataTextField = "RoleName";
                    ddlRole.DataValueField = "RoleName";
                    ddlRole.DataBind();
                    ddlRole.Items.Insert(0, new ListItem("Select Role", "0"));


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
        public void LeaveTypeClear()
        {
            txtLeaveType.Text = string.Empty;
            txtNoOfleave.Text = string.Empty;
            txtDescLeave.Text = string.Empty;
        }

        public void DashPermissionClear()
        {
            txtDivName.Text = string.Empty;
            txtDivID.Text = string.Empty;
            txtDasDescription.Text = string.Empty;
            ddlDepartment.SelectedIndex = -1;
            ddlRole.SelectedIndex = -1;
        }
        public DataTable ViewLeaveType()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewLeaveType", con))
                {
                    ad.Fill(dt);
                    GridLeave.DataSource = dt;
                    GridLeave.DataBind();
                }
            }
            return dt;
        }
        public DataTable ViewDashBoardSetting()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewDashBoardSettingDetailsForBasicSetting", con))
                {
                    ad.Fill(table);
                    GVDBSetting.DataSource = table;
                    GVDBSetting.DataBind();
                }
            }
            return table;
        }
        public void MarkClear()
        {
            txtmark.Text = string.Empty;
            txthrms.Text = string.Empty;
        }

        public void ControlPanelClear()
        {
            txtname.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtpassword.Text = string.Empty;
            txtdescript.Text = string.Empty;
        }

        public void MsterLogoClear()
        {
            txtimg.Text = string.Empty;
            txtextion.Text = string.Empty;
            ddlfileimg.SelectedIndex = -1;

        }
        public DataTable GetMarkDetails()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewMark", con))
                    {
                        ad.Fill(table);
                        GridMark.DataSource = table;
                        GridMark.DataBind();
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
            return table;
        }

        public DataTable GetImglogoDetails()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewLogoimg", con))
                    {
                        ad.Fill(table);
                        Gridlogoimg.DataSource = table;
                        Gridlogoimg.DataBind();
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
            return table;
        }

        public DataTable GetControlPanelDetails()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewControlPanel", con))
                    {
                        ad.Fill(table);
                        GridControlPanel.DataSource = table;
                        GridControlPanel.DataBind();
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
            return table;
        }

        public DataTable ViewShifts()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewShift", con))
                {
                    ad.Fill(table);
                    GridViewShift.DataSource = table;
                    GridViewShift.DataBind();
                }
            }
            return table;
        }

        public void ClearPolicy()
        {
            txtPolicyName.Text = string.Empty;
            txtPolicyDescrip.Text = string.Empty;
        }

        public DataTable ViewPolicy()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewPolicy", con))
                {
                    ad.Fill(table);
                    GridViewPolicy.DataSource = table;
                    GridViewPolicy.DataBind();
                }
            }
            return table;
        }


        public DataTable ViewHoliday()
        {

            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewHoliday", con))
                {
                    ad.Fill(table);
                    GridHoliday.DataSource = table;
                    GridHoliday.DataBind();
                }
            }
            return table;

        }
        public DataTable ViewPerticular()
        {

            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewPerticular", con))
                {
                    ad.Fill(table);
                    GridPerticular.DataSource = table;
                    GridPerticular.DataBind();
                }
            }
            return table;

        }
        public DataTable ViewProductCategory()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewProductCategory", con))
                {
                    ad.Fill(table);
                    GridViewProductType.DataSource = table;
                    GridViewProductType.DataBind();
                }
            }
            return table;

        }
        public void ClearStorage()
        {
            txtproductcategory.Text = string.Empty;
            txtproductdesc.Text = string.Empty;
        }

        public DataTable ViewMeasurementDetails()
        {
            DataTable table2 = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewMeasurementProductDetails", con))
                {
                    ad.Fill(table2);
                    GridMeasurmentProd.DataSource = table2;
                    GridMeasurmentProd.DataBind();
                }
            }
            return table2;
        }

        public void ClearMeasurement()
        {
            txtMeasurement.Text = string.Empty;
            txtUnit.Text = string.Empty;
            txtAbbreviations.Text = string.Empty;
            txtDescription.Text = string.Empty;

        }
        public void WebpageClear()
        {
            txtPagename.Text = string.Empty;
            txtModule.Text = string.Empty;
            txtSubModule.Text = string.Empty;
            txtDesignpage.Text = string.Empty;
            txtDescripwebpage.Text = string.Empty;

        }

        public DataTable ViewWebPages()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewWebPages", con))
                {
                    ad.Fill(table);
                    GridViewPageName.DataSource = table;
                    GridViewPageName.DataBind();
                }
            }
            return table;
        }
        public DataTable ViewDepartmentDetails()
        {
            DataTable table1 = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewDepartmentDetails", con))
                {
                    ad.Fill(table1);
                    GridDepartment.DataSource = table1;
                    GridDepartment.DataBind();
                }
            }
            return table1;
        }

        public void ClearDepartment()
        {

            txtDepartmentName.Text = string.Empty;
            txtDepartDescription.Text = string.Empty;
        }

        public void Clearcategory()
        {
            txtTenderCategory.Text = string.Empty;
            txtdesc.Text = string.Empty;
        }
        public DataTable ViewTenderCategory()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewTenderCategory", con))
                {
                    ad.Fill(table);
                    GridTenderCategory.DataSource = table;
                    GridTenderCategory.DataBind();
                }
            }
            return table;
        }
        public DataTable GetStatusDetails()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewStatus", con))
                    {
                        ad.Fill(table);
                        GridStatus.DataSource = table;
                        GridStatus.DataBind();
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
            return table;
        }

        public DataTable GetBillingTypesDetalis()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewBillingType", con))
                    {
                        ad.Fill(table);
                        GridBillingType.DataSource = table;
                        GridBillingType.DataBind();
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
            return table;
        }

        public DataTable GetContracttypeDetails()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_Viewcontracttype", con))
                    {
                        ad.Fill(table);
                        GridContractType.DataSource = table;
                        GridContractType.DataBind();
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
            return table;
        }

        public DataTable GetSubCategoryDetails()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewSubCategory", con))
                    {
                        ad.Fill(table);
                        GridSubcategory.DataSource = table;
                        GridSubcategory.DataBind();
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
            return table;
        }

        public DataTable GetCategoryDetails()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewCategory", con))
                    {
                        ad.Fill(table);
                        GridCategory.DataSource = table;
                        GridCategory.DataBind();
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
            return table;
        }

        public DataTable GetDiscountDetails()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewDiscount", con))
                    {
                        ad.Fill(table);
                        GridViewDiscount.DataSource = table;
                        GridViewDiscount.DataBind();
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
            return table;
        }

        public DataTable GetReceiptInitialDetails()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewReceiptInitial", con))
                    {
                        ad.Fill(table);
                        GridViewReceipt.DataSource = table;
                        GridViewReceipt.DataBind();
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
            return table;
        }

        public DataTable GetStateDetails()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_Viewstate", con))
                    {
                        ad.Fill(table);
                        GridState.DataSource = table;
                        GridState.DataBind();
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
            return table;
        }

        public DataTable GetDistrictDetails()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewDistrict", con))
                    {
                        ad.Fill(table);
                        GridDistrict.DataSource = table;
                        GridDistrict.DataBind();
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
            return table;
        }

        public DataTable GetCityDetails()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewCity", con))
                    {
                        ad.Fill(table);
                        GridCity1.DataSource = table;
                        GridCity1.DataBind();
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
            return table;
        }

        public DataTable ViewTaxsDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewTaxDetails", con))
                {
                    ad.Fill(table);
                    GridViewTaxDetails.DataSource = table;
                    GridViewTaxDetails.DataBind();
                }
            }
            return table;
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
                    command.Parameters.AddWithValue("@SubModule", "Web Settings");
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
                            bindCategory();
                            GetStatusDetails();
                            GetBillingTypesDetalis();
                            GetContracttypeDetails();
                            GetCategoryDetails();
                            GetSubCategoryDetails();
                            GetDiscountDetails();
                            GetReceiptInitialDetails();
                            GetStateDetails();
                            bindState();
                            GetDistrictDetails();
                            binddistrict();
                            GetCityDetails();
                            ViewTaxsDetails();
                            ViewTenderCategory();
                            ViewDepartmentDetails();
                            ViewWebPages();
                            ViewMeasurementDetails();
                            ViewProductCategory();
                            ViewPolicy();
                            ViewShifts();
                            ViewPerticular();
                            ViewHoliday();
                            //------------------------------//
                            GetMarkDetails();
                            GetControlPanelDetails();
                            GetImglogoDetails();
                            ViewClass();
                            //-------------------------------//
                            bindDepartment();
                            bindRole();
                            ViewDashBoardSetting();
                            ViewLeaveType();
                            ViewTermAndCondition();
                            GetDocFieldDetails();
                            if (Create == "True")
                            {
                                addnew.Visible = true;
                                addnew1.Visible = true;
                                addnew2.Visible = true;
                                addnew3.Visible = true;
                                addnew4.Visible = true;
                                addnew5.Visible = true;
                                addnew6.Visible = true;
                                addnew7.Visible = true;
                                addnew8.Visible = true;
                                addnew9.Visible = true;
                                addnew10.Visible = true;
                                addnew11.Visible = true;
                                addnew12.Visible = true;
                                addnew13.Visible = true;
                                addnewMeasurement.Visible = true;
                                addStorage.Visible = true;
                                addPolicy.Visible = true;
                                addshift.Visible = true;
                                addparticular.Visible = true;

                                addHoliday.Visible = true;
                                addMarkleave.Visible = true;
                                addControlPanel.Visible = true;
                                addSavefileImg.Visible = true;
                                addNewClass.Visible = true;

                                addleadetype.Visible = true;
                                addDashsetting.Visible = true;
                                addterms.Visible = true;
                                addnewDocument.Visible = true;
                            }
                            else
                            {
                                addnew.Visible = false;
                                addnew1.Visible = false;
                                addnew2.Visible = false;
                                addnew3.Visible = false;
                                addnew4.Visible = false;
                                addnew5.Visible = false;
                                addnew6.Visible = false;
                                addnew7.Visible = false;
                                addnew8.Visible = false;
                                addnew9.Visible = false;
                                addnew10.Visible = false;
                                addnew11.Visible = false;
                                addnew12.Visible = false;
                                addnew13.Visible = false;
                                addnewMeasurement.Visible = false;
                                addStorage.Visible = false;
                                addPolicy.Visible = false;
                                addshift.Visible = false;
                                addparticular.Visible = false;

                                addHoliday.Visible = false;
                                addMarkleave.Visible = false;
                                addControlPanel.Visible = false;
                                addSavefileImg.Visible = false;
                                addNewClass.Visible = false;
                                addterms.Visible = false;

                                addleadetype.Visible = false;
                                addDashsetting.Visible = false;
                                addterms.Visible = false;
                                addnewDocument.Visible = false;
                            }

                            if (Edit == "True")
                            {
                                GridStatus.Columns[6].Visible = true;
                                GridContractType.Columns[5].Visible = true;
                                GridBillingType.Columns[6].Visible = true;
                                GridViewDiscount.Columns[7].Visible = true;
                                GridCategory.Columns[5].Visible = true;
                                GridSubcategory.Columns[6].Visible = true;
                                GridViewReceipt.Columns[7].Visible = true;
                                GridState.Columns[5].Visible = true;
                                GridDistrict.Columns[6].Visible = true;
                                GridCity1.Columns[7].Visible = true;
                                GridViewTaxDetails.Columns[6].Visible = true;
                                GridTenderCategory.Columns[4].Visible = true;
                                GridViewPageName.Columns[9].Visible = true;
                                GridDepartment.Columns[4].Visible = true;
                                GridMeasurmentProd.Columns[6].Visible = true;
                                GridViewProductType.Columns[5].Visible = true;
                                GridViewPolicy.Columns[7].Visible = true;
                                GridViewShift.Columns[7].Visible = true;
                                GridPerticular.Columns[6].Visible = true;

                                GridHoliday.Columns[9].Visible = true;
                                GridMark.Columns[6].Visible = true;
                                Gridlogoimg.Columns[8].Visible = true;
                                GridControlPanel.Columns[6].Visible = true;
                                GridViewClass.Columns[4].Visible = true;

                                GridLeave.Columns[7].Visible = true;
                                GVDBSetting.Columns[9].Visible = true;
                                GridViewTermAndCondition.Columns[7].Visible = true;
                                GridField.Columns[5].Visible = true;
                            }
                            else
                            {
                                GridStatus.Columns[6].Visible = false;
                                GridContractType.Columns[5].Visible = false;
                                GridBillingType.Columns[6].Visible = false;
                                GridViewDiscount.Columns[7].Visible = false;
                                GridCategory.Columns[5].Visible = false;
                                GridSubcategory.Columns[6].Visible = false;
                                GridViewReceipt.Columns[7].Visible = false;
                                GridState.Columns[5].Visible = false;
                                GridDistrict.Columns[6].Visible = false;
                                GridCity1.Columns[7].Visible = false;
                                GridViewTaxDetails.Columns[6].Visible = false;
                                GridTenderCategory.Columns[4].Visible = false;
                                GridViewPageName.Columns[9].Visible = false;
                                GridDepartment.Columns[4].Visible = false;
                                GridMeasurmentProd.Columns[6].Visible = false;
                                GridViewProductType.Columns[5].Visible = false;
                                GridViewPolicy.Columns[7].Visible = false;
                                GridViewShift.Columns[7].Visible = false;
                                GridPerticular.Columns[6].Visible = false;

                                GridHoliday.Columns[9].Visible = false;
                                GridMark.Columns[6].Visible = false;
                                Gridlogoimg.Columns[8].Visible = false;
                                GridControlPanel.Columns[6].Visible = false;
                                GridViewClass.Columns[4].Visible = false;

                                GridLeave.Columns[7].Visible = false;
                                GVDBSetting.Columns[9].Visible = false;
                                GridViewTermAndCondition.Columns[7].Visible = false;
                                GridField.Columns[5].Visible = false;
                            }

                            if (Delete == "True")
                            {
                                GridStatus.Columns[7].Visible = true;
                                GridContractType.Columns[6].Visible = true;
                                GridBillingType.Columns[7].Visible = true;
                                GridViewDiscount.Columns[8].Visible = true;
                                GridCategory.Columns[6].Visible = true;
                                GridSubcategory.Columns[7].Visible = true;
                                GridViewReceipt.Columns[8].Visible = true;
                                GridState.Columns[6].Visible = true;
                                GridDistrict.Columns[7].Visible = true;
                                GridCity1.Columns[8].Visible = true;
                                GridViewTaxDetails.Columns[7].Visible = true;
                                GridTenderCategory.Columns[5].Visible = true;
                                GridViewPageName.Columns[10].Visible = true;
                                GridDepartment.Columns[5].Visible = true;
                                GridMeasurmentProd.Columns[7].Visible = true;
                                GridViewProductType.Columns[6].Visible = true;
                                GridViewPolicy.Columns[8].Visible = true;
                                GridViewShift.Columns[8].Visible = true;
                                GridPerticular.Columns[7].Visible = true;

                                GridHoliday.Columns[10].Visible = true;
                                GridMark.Columns[7].Visible = true;
                                Gridlogoimg.Columns[9].Visible = true;
                                GridControlPanel.Columns[7].Visible = true;
                                GridViewClass.Columns[5].Visible = true;

                                GridLeave.Columns[8].Visible = true;
                                GVDBSetting.Columns[10].Visible = true;
                                GridViewTermAndCondition.Columns[8].Visible = true;
                                GridField.Columns[6].Visible = true;
                            }
                            else
                            {
                                GridStatus.Columns[7].Visible = false;
                                GridContractType.Columns[6].Visible = false;
                                GridBillingType.Columns[7].Visible = false;
                                GridViewDiscount.Columns[8].Visible = false;
                                GridCategory.Columns[6].Visible = false;
                                GridSubcategory.Columns[7].Visible = false;
                                GridViewReceipt.Columns[8].Visible = false;
                                GridState.Columns[6].Visible = false;
                                GridDistrict.Columns[7].Visible = false;
                                GridCity1.Columns[8].Visible = false;
                                GridViewTaxDetails.Columns[7].Visible = false;
                                GridTenderCategory.Columns[5].Visible = false;
                                GridViewPageName.Columns[10].Visible = false;
                                GridDepartment.Columns[5].Visible = false;
                                GridMeasurmentProd.Columns[7].Visible = false;
                                GridViewProductType.Columns[6].Visible = false;
                                GridViewPolicy.Columns[8].Visible = false;
                                GridViewShift.Columns[8].Visible = false;
                                GridPerticular.Columns[7].Visible = false;

                                GridHoliday.Columns[10].Visible = false;
                                GridMark.Columns[7].Visible = false;
                                Gridlogoimg.Columns[9].Visible = false;
                                GridControlPanel.Columns[7].Visible = false;
                                GridViewClass.Columns[5].Visible = false;

                                GridLeave.Columns[8].Visible = false;
                                GVDBSetting.Columns[10].Visible = false;
                                GridViewTermAndCondition.Columns[8].Visible = false;
                                GridField.Columns[6].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {
                            bindCategory();
                            GetStatusDetails();
                            GetBillingTypesDetalis();
                            GetContracttypeDetails();
                            GetCategoryDetails();
                            GetSubCategoryDetails();
                            GetDiscountDetails();
                            GetReceiptInitialDetails();
                            GetStateDetails();
                            bindState();
                            GetDistrictDetails();
                            binddistrict();
                            GetCityDetails();
                            ViewTaxsDetails();
                            ViewTenderCategory();
                            ViewDepartmentDetails();
                            ViewWebPages();
                            ViewMeasurementDetails();
                            ViewProductCategory();
                            ViewPolicy();
                            ViewShifts();
                            ViewPerticular();
                            ViewHoliday();
                            //------------------------------//
                            GetMarkDetails();
                            GetControlPanelDetails();
                            GetImglogoDetails();
                            ViewClass();
                            //-----------------------------//
                            bindDepartment();
                            bindRole();
                            ViewDashBoardSetting();
                            ViewLeaveType();
                            ViewTermAndCondition();
                            GetDocFieldDetails();
                            if (Create == "True")
                            {
                                addnew.Visible = true;
                                addnew1.Visible = true;
                                addnew2.Visible = true;
                                addnew3.Visible = true;
                                addnew4.Visible = true;
                                addnew5.Visible = true;
                                addnew6.Visible = true;
                                addnew7.Visible = true;
                                addnew8.Visible = true;
                                addnew9.Visible = true;
                                addnew10.Visible = true;
                                addnew11.Visible = true;
                                addnew12.Visible = true;
                                addnew13.Visible = true;
                                addnewMeasurement.Visible = true;
                                addStorage.Visible = true;
                                addPolicy.Visible = true;
                                addshift.Visible = true;
                                addparticular.Visible = true;

                                addHoliday.Visible = true;
                                addMarkleave.Visible = true;
                                addControlPanel.Visible = true;
                                addSavefileImg.Visible = true;
                                addNewClass.Visible = true;

                                addleadetype.Visible = true;
                                addDashsetting.Visible = true;
                                addterms.Visible = true;
                                addnewDocument.Visible = true;
                            }
                            else
                            {
                                addnew.Visible = false;
                                addnew1.Visible = false;
                                addnew2.Visible = false;
                                addnew3.Visible = false;
                                addnew4.Visible = false;
                                addnew5.Visible = false;
                                addnew6.Visible = false;
                                addnew7.Visible = false;
                                addnew8.Visible = false;
                                addnew9.Visible = false;
                                addnew10.Visible = false;
                                addnew11.Visible = false;
                                addnew12.Visible = false;
                                addnew13.Visible = false;
                                addnewMeasurement.Visible = false;
                                addStorage.Visible = false;
                                addPolicy.Visible = false;
                                addshift.Visible = false;
                                addparticular.Visible = false;

                                addHoliday.Visible = false;
                                addMarkleave.Visible = false;
                                addControlPanel.Visible = false;
                                addSavefileImg.Visible = false;
                                addNewClass.Visible = false;

                                addleadetype.Visible = false;
                                addDashsetting.Visible = false;
                                addterms.Visible = false;
                                addnewDocument.Visible = false;
                            }

                            if (Edit == "True")
                            {
                                GridStatus.Columns[6].Visible = true;
                                GridContractType.Columns[5].Visible = true;
                                GridBillingType.Columns[6].Visible = true;
                                GridViewDiscount.Columns[7].Visible = true;
                                GridCategory.Columns[5].Visible = true;
                                GridSubcategory.Columns[6].Visible = true;
                                GridViewReceipt.Columns[7].Visible = true;
                                GridState.Columns[5].Visible = true;
                                GridDistrict.Columns[6].Visible = true;
                                GridCity1.Columns[7].Visible = true;
                                GridViewTaxDetails.Columns[6].Visible = true;
                                GridTenderCategory.Columns[4].Visible = true;
                                GridViewPageName.Columns[9].Visible = true;
                                GridDepartment.Columns[4].Visible = true;
                                GridMeasurmentProd.Columns[6].Visible = true;
                                GridViewProductType.Columns[5].Visible = true;
                                GridViewPolicy.Columns[7].Visible = true;
                                GridViewShift.Columns[7].Visible = true;
                                GridPerticular.Columns[6].Visible = true;

                                GridHoliday.Columns[9].Visible = true;
                                GridMark.Columns[6].Visible = true;
                                Gridlogoimg.Columns[8].Visible = true;
                                GridControlPanel.Columns[6].Visible = true;
                                GridViewClass.Columns[4].Visible = true;

                                GridLeave.Columns[7].Visible = true;
                                GVDBSetting.Columns[9].Visible = true;
                                GridViewTermAndCondition.Columns[7].Visible = true;
                                GridField.Columns[5].Visible = true;
                            }
                            else
                            {
                                GridStatus.Columns[6].Visible = false;
                                GridContractType.Columns[5].Visible = false;
                                GridBillingType.Columns[6].Visible = false;
                                GridViewDiscount.Columns[7].Visible = false;
                                GridCategory.Columns[5].Visible = false;
                                GridSubcategory.Columns[6].Visible = false;
                                GridViewReceipt.Columns[7].Visible = false;
                                GridState.Columns[5].Visible = false;
                                GridDistrict.Columns[6].Visible = false;
                                GridCity1.Columns[7].Visible = false;
                                GridViewTaxDetails.Columns[6].Visible = false;
                                GridTenderCategory.Columns[4].Visible = false;
                                GridViewPageName.Columns[9].Visible = false;
                                GridDepartment.Columns[4].Visible = false;
                                GridMeasurmentProd.Columns[6].Visible = false;
                                GridViewProductType.Columns[5].Visible = false;
                                GridViewPolicy.Columns[7].Visible = false;
                                GridViewShift.Columns[7].Visible = false;
                                GridPerticular.Columns[6].Visible = false;

                                GridHoliday.Columns[9].Visible = false;
                                GridMark.Columns[6].Visible = false;
                                Gridlogoimg.Columns[8].Visible = false;
                                GridControlPanel.Columns[6].Visible = false;
                                GridViewClass.Columns[4].Visible = false;

                                GridLeave.Columns[7].Visible = false;
                                GVDBSetting.Columns[9].Visible = false;
                                GridViewTermAndCondition.Columns[7].Visible = false;
                                GridField.Columns[5].Visible = false;
                            }

                            if (Delete == "True")
                            {
                                GridStatus.Columns[7].Visible = true;
                                GridContractType.Columns[6].Visible = true;
                                GridBillingType.Columns[7].Visible = true;
                                GridViewDiscount.Columns[8].Visible = true;
                                GridCategory.Columns[6].Visible = true;
                                GridSubcategory.Columns[7].Visible = true;
                                GridViewReceipt.Columns[8].Visible = true;
                                GridState.Columns[6].Visible = true;
                                GridDistrict.Columns[7].Visible = true;
                                GridCity1.Columns[8].Visible = true;
                                GridViewTaxDetails.Columns[7].Visible = true;
                                GridTenderCategory.Columns[5].Visible = true;
                                GridViewPageName.Columns[10].Visible = true;
                                GridDepartment.Columns[5].Visible = true;
                                GridMeasurmentProd.Columns[7].Visible = true;
                                GridViewProductType.Columns[6].Visible = true;
                                GridViewPolicy.Columns[8].Visible = true;
                                GridViewShift.Columns[8].Visible = true;
                                GridPerticular.Columns[7].Visible = true;

                                GridHoliday.Columns[10].Visible = true;
                                GridMark.Columns[7].Visible = true;
                                Gridlogoimg.Columns[9].Visible = true;
                                GridControlPanel.Columns[7].Visible = true;
                                GridViewClass.Columns[5].Visible = true;

                                GridLeave.Columns[8].Visible = true;
                                GVDBSetting.Columns[10].Visible = true;
                                GridViewTermAndCondition.Columns[8].Visible = true;
                                GridField.Columns[6].Visible = true;
                            }
                            else
                            {
                                GridStatus.Columns[7].Visible = false;
                                GridContractType.Columns[6].Visible = false;
                                GridBillingType.Columns[7].Visible = false;
                                GridViewDiscount.Columns[8].Visible = false;
                                GridCategory.Columns[6].Visible = false;
                                GridSubcategory.Columns[7].Visible = false;
                                GridViewReceipt.Columns[8].Visible = false;
                                GridState.Columns[6].Visible = false;
                                GridDistrict.Columns[7].Visible = false;
                                GridCity1.Columns[8].Visible = false;
                                GridViewTaxDetails.Columns[7].Visible = false;
                                GridTenderCategory.Columns[5].Visible = false;
                                GridViewPageName.Columns[10].Visible = false;
                                GridDepartment.Columns[5].Visible = false;
                                GridMeasurmentProd.Columns[7].Visible = false;
                                GridViewProductType.Columns[6].Visible = false;
                                GridViewPolicy.Columns[8].Visible = false;
                                GridViewShift.Columns[8].Visible = false;
                                GridPerticular.Columns[7].Visible = false;

                                GridHoliday.Columns[10].Visible = false;
                                GridMark.Columns[7].Visible = false;
                                Gridlogoimg.Columns[9].Visible = false;
                                GridControlPanel.Columns[7].Visible = false;
                                GridViewClass.Columns[5].Visible = false;

                                GridLeave.Columns[8].Visible = false;
                                GVDBSetting.Columns[10].Visible = false;
                                GridViewTermAndCondition.Columns[8].Visible = false;
                                GridField.Columns[6].Visible = false;
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
                            bindCategory();
                            GetStatusDetails();
                            GetBillingTypesDetalis();
                            GetContracttypeDetails();
                            GetCategoryDetails();
                            GetSubCategoryDetails();
                            GetDiscountDetails();
                            GetReceiptInitialDetails();
                            GetStateDetails();
                            bindState();
                            GetDistrictDetails();
                            binddistrict();
                            GetCityDetails();
                            ViewTaxsDetails();
                            ViewTenderCategory();
                            ViewDepartmentDetails();
                            ViewWebPages();
                            //------------------------------//
                            ViewMeasurementDetails();
                            ViewProductCategory();
                            ViewPolicy();
                            ViewShifts();
                            ViewPerticular();
                            ViewHoliday();
                            //------------------------------//
                            GetMarkDetails();
                            GetControlPanelDetails();
                            GetImglogoDetails();
                            //-------------------------------//
                            bindDepartment();
                            bindRole();
                            ViewClass();
                            ViewDashBoardSetting();
                            ViewLeaveType();
                            ViewTermAndCondition();
                            //------------------------------//
                            GetDocFieldDetails();

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
                            Response.Redirect("~/permission.html", true);
                        }

                    }
                    else
                    {
                        Response.Redirect("~/LogIn.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("~/LogIn.aspx", false);
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

        //--------------------------------------------------------------------------------
        //Status...
        //--------------------------------------------------------------------------------
        protected void btnSaveStatus_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    UserId = Convert.ToInt32(Session["UserID"]);
                    UserName = Session["UserName"].ToString();

                    UserCon = new SqlConnection(strconnect);
                    UserCommand = new SqlCommand("SP_SaveStatusDetails", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@ProgessStatus", txtStatus.Text);
                    UserCommand.Parameters.AddWithValue("@BelongTo", ddlRelatedTo.SelectedItem.Text);
                    UserCommand.Parameters.AddWithValue("@CreateBy", UserName); //Session value
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);                                                            //
                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Status Save Successfully";
                        GetStatusDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Status Already Available";
                    }
                    txtStatus.Text = string.Empty;
                    ddlRelatedTo.SelectedIndex = -1;
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
        }

        protected void btnClearStatus_Click(object sender, EventArgs e)
        {
            try
            {
                txtStatus.Text = string.Empty;
                ddlRelatedTo.SelectedIndex = -1;
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

        protected void GridStatus_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridStatus.EditIndex = e.NewEditIndex;
                GetStatusDetails();
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

        protected void GridStatus_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string RowIndex;
                Label ID = GridStatus.Rows[e.RowIndex].FindControl("lblStatus_ID1") as Label;
                TextBox txtStatus = GridStatus.Rows[e.RowIndex].FindControl("txtProgessStatus") as TextBox;
                DropDownList ddlRelatedTo = GridStatus.Rows[e.RowIndex].FindControl("ddlRelatedTo") as DropDownList;
                int StatusID = Convert.ToInt32(GridStatus.DataKeys[e.RowIndex].Values["Status_ID"]);
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UPDATEStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Statusid", StatusID);
                cmd.Parameters.AddWithValue("@StatusName", txtStatus.Text);
                cmd.Parameters.AddWithValue("@BelongTo", ddlRelatedTo.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Status Details Edit Successfully";
                    GridStatus.EditIndex = -1;
                    GetStatusDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Status Details Not Edit Successfully";
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

        protected void GridStatus_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridStatus.EditIndex = -1;
                GetStatusDetails();
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
        protected void GridStatus_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int tableID = Convert.ToInt32(GridStatus.DataKeys[e.RowIndex].Values["Status_ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteStatusInfo", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status_ID", tableID);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Status Details Deleted Successfully";
                    GridStatus.EditIndex = -1;
                    GetStatusDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Status Details Not Deleted Successfully";
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

        protected void GridStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridStatus.PageIndex = e.NewPageIndex;
                GetStatusDetails();
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

        //--------------------------------------------------------------------------------
        //Billing Setting Code...
        //--------------------------------------------------------------------------------

        protected void btnSaveBillingType_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    UserCon = new SqlConnection(strconnect);
                    UserCommand = new SqlCommand("SP_SaveBillingTypes", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@Billing_Type", txtBillingType.Text);
                    UserCommand.Parameters.AddWithValue("@Description", txtDescription.Text);
                    UserCommand.Parameters.AddWithValue("@CreateBy", UserName); //Session value
                    UserCommand.Parameters.AddWithValue("@UserID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);
                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Billing Type Save Successfully";
                        GetBillingTypesDetalis();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Billing Type Already Available";
                    }
                    txtBillingType.Text = string.Empty;
                    txtDescription.Text = string.Empty;

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

        protected void btnClearBillingType_Click(object sender, EventArgs e)
        {
            try
            {
                txtBillingType.Text = string.Empty;
                txtDescription.Text = string.Empty;
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

        protected void GridBillingType_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridBillingType.EditIndex = e.NewEditIndex;
                GetBillingTypesDetalis();
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

        protected void GridBillingType_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ID = GridBillingType.Rows[e.RowIndex].FindControl("lblBilling_ID") as Label;
                TextBox txtBillingType = GridBillingType.Rows[e.RowIndex].FindControl("txtBillingType") as TextBox;
                TextBox txtDescription = GridBillingType.Rows[e.RowIndex].FindControl("txtDescription") as TextBox;
                int BillingTypeID = Convert.ToInt32(GridBillingType.DataKeys[e.RowIndex].Values["Billing_Type_ID"]);
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateBillingTypes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BillingID", BillingTypeID);
                cmd.Parameters.AddWithValue("@Billing_Type", txtBillingType.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Billing Type Details Edit Successfully";
                    GridBillingType.EditIndex = -1;
                    GetBillingTypesDetalis();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Billing Type Details not Edit Successfully";
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

        protected void GridBillingType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridBillingType.EditIndex = -1;
                GetBillingTypesDetalis();
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
        protected void GridBillingType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int tableID = Convert.ToInt32(GridBillingType.DataKeys[e.RowIndex].Values["Billing_Type_ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteBillingType", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BillingID", tableID);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@UserID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Billing Type Details Deleted Successfully";
                    GridBillingType.EditIndex = -1;
                    GetBillingTypesDetalis();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Billing Type Details not Deleted Successfully";
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

        protected void GridStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlRelatedTo = (e.Row.FindControl("ddlRelatedTo") as DropDownList);

                string itemName = e.Row.Cells[1].Text;
                foreach (LinkButton button in e.Row.Cells[5].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + itemName + "?')){ return false; };";
                    }
                }


                //Select the Country of Customer in DropDownList
                //string country = (e.Row.FindControl("lblRelatedTo1") as Label).Text;
                //ddlRelatedTo.Items.FindByText(country).Selected = true;
            }
        }

        protected void GridBillingType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridBillingType.PageIndex = e.NewPageIndex;
                GetBillingTypesDetalis();
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

        //--------------------------------------------------------------------------------
        //Billing Setting Code...Contract Type
        //--------------------------------------------------------------------------------
        protected void GridContractType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string itemName = e.Row.Cells[1].Text;
                foreach (LinkButton button in e.Row.Cells[5].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + itemName + "?')){ return false; };";
                    }
                }
            }

        }

        protected void GridContractType_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridContractType.EditIndex = e.NewEditIndex;
                GetContracttypeDetails();
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

        protected void GridContractType_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ID = GridContractType.Rows[e.RowIndex].FindControl("lblContracttypeID") as Label;
                TextBox txtContracttype = GridContractType.Rows[e.RowIndex].FindControl("txtContracttype") as TextBox;
                //TextBox txtDescription = GridContractType.Rows[e.RowIndex].FindControl("txtDescription") as TextBox;
                int contracttypeid = Convert.ToInt32(GridContractType.DataKeys[e.RowIndex].Values["id"]);//Datakey
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdatecontractTypes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", contracttypeid);
                cmd.Parameters.AddWithValue("@contractype", txtContracttype.Text);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Contract Type Details Edit Successfully";
                    GridContractType.EditIndex = -1;
                    GetContracttypeDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Contract Type Details Not Edit Successfully";
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

        protected void GridContractType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridContractType.EditIndex = -1;
                GetContracttypeDetails();
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

        protected void GridContractType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int contracttypeid = Convert.ToInt32(GridContractType.DataKeys[e.RowIndex].Values["id"]);//Datakey
                SqlCommand cmd = new SqlCommand("SP_DeleteContractType", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", contracttypeid);
                cmd.Parameters.AddWithValue("@createby", UserName);
                cmd.Parameters.AddWithValue("@UserID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Contract Type Details Deleted Successfully";
                    GridContractType.EditIndex = -1;
                    GetContracttypeDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Contract Type Details Not Deleted Successfully";
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

        protected void btnsaveContract_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SqlConnection UserCon = new SqlConnection(strconnect);
                    SqlCommand UserCommand = new SqlCommand("SP_SaveContractypeDetails", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@contracttypes", txtContractType.Text);
                    UserCommand.Parameters.AddWithValue("@Createby", UserName); //Session value
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);
                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Contract Type Details Save Successfully";
                        GetContracttypeDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Contract Type Already Available";
                    }
                    txtContractType.Text = string.Empty;
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

        protected void btnClearContract_Click(object sender, EventArgs e)
        {
            try
            {
                txtContractType.Text = string.Empty;

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
            //cler
        }

        protected void GridContractType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridContractType.PageIndex = e.NewPageIndex;
                GetContracttypeDetails();
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

        //--------------------------------------------------------------------------------//
        // Expenses Category
        //
        //----------------------------------------------------------------------------------//
        protected void btnSaveCategory_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //UserId = Convert.ToInt32(Session["EmpID"]);
                    //UserName = Session["EmployeeName"].ToString();

                    UserCon = new SqlConnection(strconnect);
                    UserCommand = new SqlCommand("SP_SaveCategory", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@Category_Name", txtCategory.Text);
                    UserCommand.Parameters.AddWithValue("@CreateBy", UserName); //Session value
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);
                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Category Save Successfully";
                        GetCategoryDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Category Already Available";
                    }
                    txtCategory.Text = string.Empty;


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

        protected void btnClearCategory_Click(object sender, EventArgs e)
        {
            try
            {
                txtCategory.Text = string.Empty;

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

        protected void GridCategory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridCategory.EditIndex = e.NewEditIndex;
                GetCategoryDetails();
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

        protected void GridCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ID = GridCategory.Rows[e.RowIndex].FindControl("lblID") as Label;
                TextBox txtCategory_Name = GridCategory.Rows[e.RowIndex].FindControl("txtCategory_Name") as TextBox;
                int CategoryaID = Convert.ToInt32(GridCategory.DataKeys[e.RowIndex].Values["ID"]);//Datakey
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", CategoryaID);
                cmd.Parameters.AddWithValue("@Category_Name", txtCategory_Name.Text);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Category Details Edit Successfully";
                    GridCategory.EditIndex = -1;
                    GetCategoryDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Category Details Not Edit Successfully";
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

        protected void GridCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridCategory.EditIndex = -1;
                GetCategoryDetails();
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

        protected void GridCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int CategoryaID = Convert.ToInt32(GridCategory.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteCategory", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", CategoryaID);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@UserID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Category Details Deleted Successfully";
                    GridCategory.EditIndex = -1;
                    GetCategoryDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Category Details Not Deleted Successfully";
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

        protected void GridCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridCategory.PageIndex = e.NewPageIndex;
                GetCategoryDetails();
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

        protected void GridCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string itemName = e.Row.Cells[1].Text;
                foreach (LinkButton button in e.Row.Cells[5].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + itemName + "?')){ return false; };";
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------//

        // Expenses Sub_Category

        //---------------------------------------------------------------------------------------//

        protected void btnSaveSubcategory_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SqlConnection UserCon = new SqlConnection(strconnect);
                    SqlCommand UserCommand = new SqlCommand("[SP_SaveSubCategory]", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@Sub_Category_Name", txtSubcategory.Text);
                    UserCommand.Parameters.AddWithValue("@Exp_Category_ID", ddlExpCategory2.SelectedItem.Value);
                    UserCommand.Parameters.AddWithValue("@Createby", UserName); //Session value
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);
                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "SubCategory Save Successfully";
                        GetSubCategoryDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "SubCategory Already Available";
                    }
                    txtSubcategory.Text = string.Empty;
                    ddlExpCategory2.SelectedIndex = -1;
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

        protected void GridSubcategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {
                        UserCon = new SqlConnection(strconnect);
                        UserCon.Open();
                        DropDownList ddlCategoryBind1 = (DropDownList)e.Row.FindControl("ddlCategoryBind");

                        //return DataTable havinf department data
                        SqlConnection conn = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_GetExpCategory", conn);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            ddlCategoryBind1.DataSource = dt;
                            ddlCategoryBind1.DataTextField = "Category_Name";
                            ddlCategoryBind1.DataValueField = "ID";
                            ddlCategoryBind1.DataBind();
                            ddlCategoryBind1.Items.Insert(0, new ListItem("Select Category", "0"));

                            DataRowView dr = e.Row.DataItem as DataRowView;
                            ddlCategoryBind1.SelectedValue = dr["ID"].ToString();
                        }
                    }
                }

                //----------------Deletion if loop add....///
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string itemName = e.Row.Cells[1].Text;
                    foreach (LinkButton button in e.Row.Cells[6].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + itemName + "?')){ return false; };";
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
            finally { }
        }

        protected void GridSubcategory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridSubcategory.EditIndex = e.NewEditIndex;
                GetSubCategoryDetails();
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

        protected void GridSubcategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ID = GridSubcategory.Rows[e.RowIndex].FindControl("lblID") as Label;

                TextBox txtSubCategory_Name = GridSubcategory.Rows[e.RowIndex].FindControl("txtSubCategory_Name") as TextBox;
                DropDownList ddlbindcategory = GridSubcategory.Rows[e.RowIndex].FindControl("ddlCategoryBind") as DropDownList;
                int SubCategoryaID = Convert.ToInt32(GridSubcategory.DataKeys[e.RowIndex].Values["ID"]);//Datakey
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateSubCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SubCategoryaID);
                cmd.Parameters.AddWithValue("@Sub_Category_Name", txtSubCategory_Name.Text);
                cmd.Parameters.AddWithValue("@Categoryid", ddlbindcategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "SubCategory Details Edit Successfully";
                    GridSubcategory.EditIndex = -1;
                    GetSubCategoryDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "SubCategory Details Not Edit Successfully";
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

        protected void GridSubcategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridSubcategory.EditIndex = -1;
                GetSubCategoryDetails();
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

        protected void GridSubcategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int SubCategoryaID = Convert.ToInt32(GridSubcategory.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteSubCategory", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SubCategoryaID);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@UserID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "SubCategory Details Deleted Successfully";
                    GridSubcategory.EditIndex = -1;
                    GetSubCategoryDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "SubCategory Details Not Deleted Successfully";
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

        protected void GridSubcategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridSubcategory.PageIndex = e.NewPageIndex;
                GetSubCategoryDetails();
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

        protected void btnClearSubcategory_Click(object sender, EventArgs e)
        {
            txtSubcategory.Text = string.Empty;
            ddlExpCategory2.SelectedIndex = -1;
        }

        /// <summary>
        /// ----------------------------------------------------------------------------------------
        /// ///Discount///
        /// ---------------------------------------------------------------------------------------------

        protected void GridViewDiscount_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridViewDiscount.EditIndex = e.NewEditIndex;
                GetDiscountDetails();
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

        protected void GridViewDiscount_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ID = GridViewDiscount.Rows[e.RowIndex].FindControl("lblDisc_ID") as Label;
                TextBox txtDiscName = GridViewDiscount.Rows[e.RowIndex].FindControl("txtDiscName") as TextBox;
                TextBox txtDiscParsnt = GridViewDiscount.Rows[e.RowIndex].FindControl("txtDiscParsnt") as TextBox;
                TextBox txtDescriptiondi = GridViewDiscount.Rows[e.RowIndex].FindControl("txtDescriptiondi") as TextBox;
                int DiscountID = Convert.ToInt32(GridViewDiscount.DataKeys[e.RowIndex].Values["DiscID"]);//Datakey
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateDiscount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DiscID", DiscountID);
                cmd.Parameters.AddWithValue("@DiscName", txtDiscName.Text);
                cmd.Parameters.AddWithValue("@DiscPercentage", txtDiscParsnt.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescriptiondi.Text);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Discount Details Edit Successfully";
                    GridViewDiscount.EditIndex = -1;
                    GetDiscountDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Discount Details Not Edit Successfully";
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

        protected void GridViewDiscount_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridViewDiscount.EditIndex = -1;
                GetDiscountDetails();
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

        protected void GridViewDiscount_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int DiscountID = Convert.ToInt32(GridViewDiscount.DataKeys[e.RowIndex].Values["DiscID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteDiscount", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DiscID", DiscountID);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@UserID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Discount Details Deleted Successfully";
                    GridViewDiscount.EditIndex = -1;
                    GetDiscountDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Discount Details Not Deleted Successfully";
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

        protected void GridViewDiscount_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridViewDiscount.PageIndex = e.NewPageIndex;
                GetDiscountDetails();
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

        protected void btnSaveDiscount_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SqlConnection UserCon = new SqlConnection(strconnect);
                    SqlCommand UserCommand = new SqlCommand("[SP_SaveDiscount]", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@DiscName", txtDiscount.Text);
                    UserCommand.Parameters.AddWithValue("@DiscPercentage", txtDiscper1.Text);
                    UserCommand.Parameters.AddWithValue("@Description", txtdicountDecription.Text);
                    UserCommand.Parameters.AddWithValue("@CreateBy", UserName); //Session value
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);
                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Discount Details Save Successfully";
                        GetDiscountDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Discount Already Available";
                    }
                    txtDiscount.Text = string.Empty;
                    txtDiscper1.Text = string.Empty;
                    txtdicountDecription.Text = string.Empty;
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

        protected void btnClearDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                txtDiscount.Text = string.Empty;
                txtDiscper1.Text = string.Empty;
                txtdicountDecription.Text = string.Empty;

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

        //-------------------------------------------------------------------------------
        //               // Receipt
        //-------------------------------------------------------------------------------
        protected void btnsavereciptfor_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    UserCon = new SqlConnection(strconnect);
                    UserCommand = new SqlCommand("SP_SaveReceiptlnitial", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@ReceiptFor", txtReceiptFor.Text);
                    UserCommand.Parameters.AddWithValue("@Initial", txtInitial.Text);
                    UserCommand.Parameters.AddWithValue("@Size", txtSize.Text);
                    UserCommand.Parameters.AddWithValue("@Createby", UserName); //Session value//
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);
                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Receipt Initial Save Successfully";
                        GetReceiptInitialDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Receipt Initial Already Available";
                    }
                    txtReceiptFor.Text = string.Empty;
                    txtInitial.Text = string.Empty;
                    txtSize.Text = string.Empty;
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

        protected void btnclrreciptfor_Click(object sender, EventArgs e)
        {
            try
            {
                txtdistrict1.Text = string.Empty;
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
        protected void GridViewReceipt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string itemName = e.Row.Cells[1].Text;
                foreach (LinkButton button in e.Row.Cells[6].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + itemName + "?')){ return false; };";
                    }
                }
            }
        }

        protected void GridViewReceipt_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridViewReceipt.EditIndex = e.NewEditIndex;
                GetReceiptInitialDetails();
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

        protected void GridViewReceipt_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ID = GridCategory.Rows[e.RowIndex].FindControl("lblID") as Label;
                TextBox txtReceiptFor = GridViewReceipt.Rows[e.RowIndex].FindControl("txtReceiptFor") as TextBox;
                TextBox txtInitial = GridViewReceipt.Rows[e.RowIndex].FindControl("txtInitial") as TextBox;
                TextBox txtSize = GridViewReceipt.Rows[e.RowIndex].FindControl("txtSize") as TextBox;
                int ReceiptID = Convert.ToInt32(GridViewReceipt.DataKeys[e.RowIndex].Values["ID"]);//Datakey
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateReceipt", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ReceiptID);
                cmd.Parameters.AddWithValue("@ReceiptFor", txtReceiptFor.Text);
                cmd.Parameters.AddWithValue("@Initial", txtInitial.Text);
                cmd.Parameters.AddWithValue("@Size", txtSize.Text);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Receipt Initial Details Edit Successfully";
                    GridViewReceipt.EditIndex = -1;
                    GetReceiptInitialDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Receipt Initial Details Not Edit Successfully";
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

        protected void GridViewReceipt_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridViewReceipt.EditIndex = -1;
                GetReceiptInitialDetails();
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

        protected void GridViewReceipt_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int ReceiptID = Convert.ToInt32(GridViewReceipt.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteReceiptInitial", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ReceiptID);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Receipt Initial Details Deleted Successfully";
                    GridViewReceipt.EditIndex = -1;
                    GetReceiptInitialDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Receipt Initial Details Not Deleted Successfully";
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

        protected void GridViewReceipt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridViewReceipt.PageIndex = e.NewPageIndex;
                GetReceiptInitialDetails();
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

        //-----------------------------------------------------------------------------------------
        //                       state
        //-----------------------------------------------------------------------------------------

        protected void btnStateSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    UserCon = new SqlConnection(strconnect);
                    UserCommand = new SqlCommand("SP_SaveState", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@State_Name", txtState.Text);
                    UserCommand.Parameters.AddWithValue("@Createby", UserName); //Session value
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);
                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "State Details Save Successfully";
                        GetStateDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "State Details Already Available";
                    }
                    txtState.Text = string.Empty;
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

        protected void btnStateclear_Click(object sender, EventArgs e)
        {
            txtState.Text = string.Empty;
        }

        protected void GridState_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string itemName = e.Row.Cells[1].Text;
                foreach (LinkButton button in e.Row.Cells[4].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + itemName + "?')){ return false; };";
                    }
                }
            }
        }

        protected void GridState_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridState.EditIndex = e.NewEditIndex;
                GetStateDetails();
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

        protected void GridState_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ID = GridState.Rows[e.RowIndex].FindControl("lblID") as Label;
                TextBox txtState_Name = GridState.Rows[e.RowIndex].FindControl("txtState_Name") as TextBox;
                int StateID = Convert.ToInt32(GridState.DataKeys[e.RowIndex].Values["ID"]);//Datakey
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_Updatestate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", StateID);
                cmd.Parameters.AddWithValue("@State_Name", txtState_Name.Text);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "State Details Edit Successfully";
                    GridState.EditIndex = -1;
                    GetStateDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "State Details Not Edit Successfully";
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

        protected void GridState_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridState.EditIndex = -1;
                GetStateDetails();
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

        protected void GridState_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int ststeID = Convert.ToInt32(GridState.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteState", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ststeID);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "State Details Deleted Successfully";
                    GridState.EditIndex = -1;
                    GetStateDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "State Details Not Deleted Successfully";
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

        protected void GridState_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridState.PageIndex = e.NewPageIndex;
                GetStateDetails();
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

        //  ------------------------------------------------------------------------------------------------------
        //                           District

        //---------------------------------------------------------------------------------------------------------

        protected void btnsavedistrict_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SqlConnection UserCon = new SqlConnection(strconnect);
                    SqlCommand UserCommand = new SqlCommand("SP_SaveDistrict", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@Disttrict_Name", txtdistrict1.Text);
                    UserCommand.Parameters.AddWithValue("@StateId", ddlStatename.SelectedItem.Value);
                    UserCommand.Parameters.AddWithValue("@created_by", UserName); //Session value
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);
                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "District Details Save Successfully";
                        GetDistrictDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "District Details Already Available";
                    }
                    txtdistrict1.Text = string.Empty;
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

        protected void btndistrictclear_Click(object sender, EventArgs e)
        {
            try
            {
                txtdistrict1.Text = string.Empty;
                ddlStatename.SelectedIndex = -1;

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

        protected void GridDistrict_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {
                        UserCon = new SqlConnection(strconnect);
                        UserCon.Open();
                        DropDownList ddlStateBind = (DropDownList)e.Row.FindControl("ddlStateBind");

                        //return DataTable havinf department data
                        SqlConnection conn = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_GetState", conn);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            ddlStateBind.DataSource = dt;
                            ddlStateBind.DataTextField = "State_Name";
                            ddlStateBind.DataValueField = "ID";
                            ddlStateBind.DataBind();
                            ddlStateBind.Items.Insert(0, new ListItem("Select State", "0"));

                            DataRowView dr = e.Row.DataItem as DataRowView;
                            ddlStateBind.SelectedValue = dr["ID"].ToString();
                        }
                    }
                }

                //----------------Deletion if loop add....///
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string itemName = e.Row.Cells[1].Text;
                    foreach (LinkButton button in e.Row.Cells[6].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + itemName + "?')){ return false; };";
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
            finally { }
        }

        protected void GridDistrict_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridDistrict.EditIndex = e.NewEditIndex;
                GetDistrictDetails();
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

        protected void GridDistrict_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ID = GridDistrict.Rows[e.RowIndex].FindControl("lblID") as Label;
                TextBox txtDisttrict_Name = GridDistrict.Rows[e.RowIndex].FindControl("txtDisttrict_Name") as TextBox;
                DropDownList ddlstate = GridDistrict.Rows[e.RowIndex].FindControl("ddlStateBind") as DropDownList;
                int DistrictID = Convert.ToInt32(GridDistrict.DataKeys[e.RowIndex].Values["District_ID"]);//Datakey
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateDistrict", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@District_ID", DistrictID);
                cmd.Parameters.AddWithValue("@Disttrict_Name", txtDisttrict_Name.Text);
                cmd.Parameters.AddWithValue("@StateId", ddlstate.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "District Details Edit Successfully";
                    GridDistrict.EditIndex = -1;
                    GetDistrictDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "District Details Not Edit Successfully";
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

        protected void GridDistrict_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridDistrict.EditIndex = -1;
                GetDistrictDetails();
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

        protected void GridDistrict_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int District_ID = Convert.ToInt32(GridDistrict.DataKeys[e.RowIndex].Values["District_ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteDistrict", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@District_ID", District_ID);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@UserID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "District Details Deleted Successfully";
                    GridDistrict.EditIndex = -1;
                    GetDistrictDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "District Details Not Deleted Successfully";
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

        protected void GridDistrict_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridDistrict.PageIndex = e.NewPageIndex;
                GetDistrictDetails();
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



        //------------------------------------------------------------------------------------------------------
        //                           City
        //---------------------------------------------------------------------------------------------------------

        protected void btnsavecity_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    SqlConnection UserCon = new SqlConnection(strconnect);
                    SqlCommand UserCommand = new SqlCommand("SP_Savecity", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@City", txtcity.Text);
                    UserCommand.Parameters.AddWithValue("@State_ID", ddlState1.SelectedItem.Value);
                    UserCommand.Parameters.AddWithValue("@District_ID", ddldistrict1.SelectedItem.Value);
                    UserCommand.Parameters.AddWithValue("@created_by", UserName); //Session value
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);
                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "City Details Save Successfully";
                        GetCityDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "City Details Already Available";
                    }
                    txtcity.Text = string.Empty;
                    ddlState1.SelectedIndex = -1;
                    ddldistrict1.SelectedIndex = -1;
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

        protected void btnclearcity_Click(object sender, EventArgs e)
        {
            try
            {

                txtcity.Text = string.Empty;
                ddlState1.SelectedIndex = -1;
                ddldistrict1.SelectedIndex = -1;

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

        protected void GridCity1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {
                        UserCon = new SqlConnection(strconnect);
                        UserCon.Open();
                        DropDownList ddlStateBind = (DropDownList)e.Row.FindControl("ddlStateBind");

                        //return DataTable havinf department data
                        SqlConnection conn = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_GetState", conn);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            ddlStateBind.DataSource = dt;
                            ddlStateBind.DataTextField = "State_Name";
                            ddlStateBind.DataValueField = "ID";
                            ddlStateBind.DataBind();
                            ddlStateBind.Items.Insert(0, new ListItem("Select State", "0"));

                            //DataRowView dr = e.Row.DataItem as DataRowView;
                            //ddlStateBind.SelectedValue = dr["ID"].ToString();
                        }
                    }
                }

                //-----------------------District---------------------------//

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {
                        UserCon = new SqlConnection(strconnect);
                        UserCon.Open();
                        DropDownList ddlDistrictBind = (DropDownList)e.Row.FindControl("ddlDistrictBind");

                        //return DataTable havinf department data
                        SqlConnection conn = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_GetDistrict", conn);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            ddlDistrictBind.DataSource = dt;
                            ddlDistrictBind.DataTextField = "Disttrict_Name";
                            ddlDistrictBind.DataValueField = "District_ID";
                            ddlDistrictBind.DataBind();
                            ddlDistrictBind.Items.Insert(0, new ListItem("Select District", "0"));

                            //DataRowView dr = e.Row.DataItem as DataRowView;
                            //ddlDistrictBind.SelectedValue = dr["District_ID"].ToString();
                        }
                    }
                }

                //----------------Deletion if loop add....///
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string itemName = e.Row.Cells[1].Text;
                    foreach (LinkButton button in e.Row.Cells[6].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + itemName + "?')){ return false; };";
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
            finally { }
        }

        protected void GridCity1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridCity1.EditIndex = e.NewEditIndex;
                GetCityDetails();
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

        protected void GridCity1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ID = GridCity1.Rows[e.RowIndex].FindControl("lblID") as Label;
                TextBox txtCity = GridCity1.Rows[e.RowIndex].FindControl("txtCity") as TextBox;
                DropDownList ddlState1 = GridCity1.Rows[e.RowIndex].FindControl("ddlStateBind") as DropDownList;
                DropDownList ddldistrict1 = GridCity1.Rows[e.RowIndex].FindControl("ddldistrictBind") as DropDownList;
                int CityID = Convert.ToInt32(GridCity1.DataKeys[e.RowIndex].Values["ID"]);//Datakey
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_Updatecity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", CityID);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@State_ID", ddlState1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@District_ID", ddldistrict1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "City Details Edit Successfully";
                    GridCity1.EditIndex = -1;
                    GetCityDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "City Details Not Edit Successfully";
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

        protected void GridCity1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridCity1.EditIndex = -1;
                GetCityDetails();
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

        protected void GridCity1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                SqlConnection DeviceCon = new SqlConnection(strconnect);
                int City_ID = Convert.ToInt32(GridCity1.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteCity", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", City_ID);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                cmd.Parameters.AddWithValue("@UserID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "City Details Deleted Successfully";
                    GridCity1.EditIndex = -1;
                    GetCityDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "City Details Not Deleted Successfully";
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

        protected void GridCity1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridCity1.PageIndex = e.NewPageIndex;
                GetCityDetails();
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



        protected void ddlState1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Stateid = Convert.ToInt32(ddlState1.SelectedValue);

                //subcategory bind  @categyid = categoryid

                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetDistrictbyStateid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@State_ID", Stateid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddldistrict1.DataSource = ds.Tables[0];
                    ddldistrict1.DataTextField = "Disttrict_Name";
                    ddldistrict1.DataValueField = "District_ID";
                    ddldistrict1.DataBind();
                    ddldistrict1.Items.Insert(0, new ListItem("Select District Name", "0"));
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

        protected void ddlStateBind_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var rows = GridCity1.Rows;
                DropDownList btn = (DropDownList)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);

                DropDownList ddldistrictBind = GridCity1.Rows[rowindex].FindControl("ddldistrictBind") as DropDownList;

                int Stateid = Convert.ToInt32(((DropDownList)rows[rowindex].FindControl("ddlStateBind")).SelectedValue);

                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetDistrictbyStateid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@State_ID", Stateid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddldistrictBind.DataSource = ds.Tables[0];
                    ddldistrictBind.DataTextField = "Disttrict_Name";
                    ddldistrictBind.DataValueField = "District_ID";
                    ddldistrictBind.DataBind();
                    ddldistrictBind.Items.Insert(0, new ListItem("Select District Name", "0"));
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

        //-----------------------------------------------------------------------------------------------------------//
        //........TAX Details
        //----------------------------------------------------------------------------------------------------------//
        public void ClearTax()
        {
            txtTax_Name.Text = string.Empty;
            txtTax_Value.Text = string.Empty;
        }

        protected void GridViewTaxDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);
                int id = Convert.ToInt16(GridViewTaxDetails.DataKeys[e.RowIndex].Values["Tax_Id"].ToString());
                Label lblTax_Id1 = GridViewTaxDetails.Rows[e.RowIndex].FindControl("lblTax_Id") as Label;
                UserCon = new SqlConnection(strconnect);
                UserCommand = new SqlCommand("SP_DeleteTaxDetail", UserCon);
                UserCommand.Connection = UserCon;
                UserCommand.CommandType = CommandType.StoredProcedure;
                UserCommand.Parameters.AddWithValue("@Tax_Id", id);
                UserCommand.Parameters.AddWithValue("@CreateBy", UserName);
                UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                UserCommand.Parameters.AddWithValue("@Designation", Designation);
                UserCon.Open();
                int i = UserCommand.ExecuteNonQuery();
                UserCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Tax Details Deleted Successfully";
                    GridViewTaxDetails.EditIndex = -1;
                    ViewTaxsDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Tax Details Not Deleted Successfully";
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

        protected void GridViewTaxDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridViewTaxDetails.EditIndex = e.NewEditIndex;
                ViewTaxsDetails();
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

        protected void GridViewTaxDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                SqlConnection UserCon = new SqlConnection(strconnect);
                TextBox txtTax_Name = GridViewTaxDetails.Rows[e.RowIndex].FindControl("txtTax_Name") as TextBox;
                TextBox txtTax_Value = GridViewTaxDetails.Rows[e.RowIndex].FindControl("txtTax_Value") as TextBox;
                int id = Convert.ToInt16(GridViewTaxDetails.DataKeys[e.RowIndex].Values["Tax_Id"].ToString());
                Label lblTax_Id1 = GridViewTaxDetails.Rows[e.RowIndex].FindControl("lblTax_Id") as Label;

                UserCommand = new SqlCommand("SP_UpdateTaxDetails", UserCon);
                UserCommand.Connection = UserCon;
                UserCommand.CommandType = CommandType.StoredProcedure;
                UserCommand.Parameters.AddWithValue("@Tax_Id", id);
                UserCommand.Parameters.AddWithValue("@Tax_Name", txtTax_Name.Text);
                UserCommand.Parameters.AddWithValue("@Tax_Value", txtTax_Value.Text);
                UserCommand.Parameters.AddWithValue("@CreateBy", UserName);
                UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                UserCommand.Parameters.AddWithValue("@Designation", Designation);
                UserCon.Open();
                int i = UserCommand.ExecuteNonQuery();
                UserCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Tax Details Edit Successfully";
                    GridViewTaxDetails.EditIndex = -1;
                    ViewTaxsDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Tax Details Not Edit Successfully";
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

        protected void GridViewTaxDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridViewTaxDetails.EditIndex = -1;
                ViewTaxsDetails();
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
        protected void btnTaxClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearTax();
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

        protected void btnSaveTax_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //Double TaxRate = Convert.ToDouble(txtTax_Value.Text);
                    SqlConnection UserCon = new SqlConnection(strconnect);
                    SqlCommand UserCommand = new SqlCommand("SP_SaveTaxDetails", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@Tax_Name", txtTax_Name.Text);
                    UserCommand.Parameters.AddWithValue("@Tax_Value", txtTax_Value.Text);
                    UserCommand.Parameters.AddWithValue("@CreateBy", UserName);
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);
                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Tax Details Save Successfully";
                        ClearTax();
                        ViewTaxsDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Tax Details Already Available";
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
        }

        //----------------------------------------------------------------------------------------------//
        // Tender Category
        //----------------------------------------------------------------------------------------------//

        protected void GridTenderCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridTenderCategory.EditIndex = -1;
                ViewTenderCategory();
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

        protected void GridTenderCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int tableID = Convert.ToInt32(GridTenderCategory.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteTenderCategory", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", tableID);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Tender Category Details Deleted Successfully";

                    GridTenderCategory.EditIndex = -1;
                    ViewTenderCategory();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Tender Category Details Not Deleted Successfully";
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

        protected void GridTenderCategory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridTenderCategory.EditIndex = e.NewEditIndex;
                ViewTenderCategory();
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

        protected void GridTenderCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string RowIndex;
                Label ID = GridTenderCategory.Rows[e.RowIndex].FindControl("lblCategoryID1") as Label;
                TextBox txtCategoryName = GridTenderCategory.Rows[e.RowIndex].FindControl("txtCategoryName") as TextBox;
                TextBox txtDesc = GridTenderCategory.Rows[e.RowIndex].FindControl("txtDescription") as TextBox;
                int CategoryID = Convert.ToInt32(GridTenderCategory.DataKeys[e.RowIndex].Values["ID"]);

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateTenderCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", CategoryID);
                cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);
                cmd.Parameters.AddWithValue("@Description", txtDesc.Text);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Tender Category Details Edit Successfully";

                    GridTenderCategory.EditIndex = -1;
                    ViewTenderCategory();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Tender Category Details Not Edit Successfully";
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

        protected void Btn_Saveted_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SqlConnection con = new SqlConnection(strconnect); // db connect
                    SqlCommand cmd = new SqlCommand("SP_SaveTenderCategory", con);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryName", txtTenderCategory.Text);
                    cmd.Parameters.AddWithValue("@Description", txtdesc.Text);
                    cmd.Parameters.AddWithValue("@CreateBy", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Tender Category Details Save Successfully";
                        Clearcategory();
                        ViewTenderCategory();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Tender Category Details Not Save Successfully";
                    }
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
        }

        //-------------------------------------------------------------------------------------------
        // Department
        //---------------------------------------------------------------------------------------------
        protected void Btn_Clearted_Click(object sender, EventArgs e)
        {
            Clearcategory();
        }


        protected void GridDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int tableID = Convert.ToInt32(GridDepartment.DataKeys[e.RowIndex].Values["Dept_ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteDepartmentDetails", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dept_ID", tableID);
                cmd.Parameters.AddWithValue("@Created_by", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);

                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Department Details Deleted Successfully";
                    GridDepartment.EditIndex = -1;
                    ViewDepartmentDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Department Details Not Deleted Successfully";
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

        protected void GridDepartment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridDepartment.EditIndex = e.NewEditIndex;
                ViewDepartmentDetails();
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

        protected void GridDepartment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string RowIndex;
                Label ID = GridDepartment.Rows[e.RowIndex].FindControl("lblDepartmentID1") as Label;
                TextBox txtCategoryName = GridDepartment.Rows[e.RowIndex].FindControl("txtDepartmentName") as TextBox;
                TextBox txtDesc = GridDepartment.Rows[e.RowIndex].FindControl("txtDescription") as TextBox;
                int DepartmentID = Convert.ToInt32(GridDepartment.DataKeys[e.RowIndex].Values["Dept_ID"]);

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateDepartmentDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dept_ID", DepartmentID);
                cmd.Parameters.AddWithValue("@Dept_Name", txtCategoryName.Text);
                cmd.Parameters.AddWithValue("@Description", txtDesc.Text);
                cmd.Parameters.AddWithValue("@Created_by", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Department Details Edit Successfully";
                    GridDepartment.EditIndex = -1;
                    ViewDepartmentDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Department Details Not Edit Successfully";
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

        protected void GridDepartment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridDepartment.EditIndex = -1;
                ViewDepartmentDetails();
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

        protected void Btn_SaveDepart_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SqlConnection con = new SqlConnection(strconnect); // db connect
                    SqlCommand cmd = new SqlCommand("SP_SaveDepartmentDetails", con);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dept_Name", txtDepartmentName.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDepartDescription.Text);
                    cmd.Parameters.AddWithValue("@Created_by", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Department Details Save Successfully";
                        ClearDepartment();
                        ViewDepartmentDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Department Details Not Save Successfully";
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
        }

        protected void Btn_ClearDepart_Click(object sender, EventArgs e)
        {
            ClearDepartment();
        }

        //-------------------------------------------------------------------------------------------//
        // WEB PAGE DESIGN
        //-------------------------------------------------------------------------------------------//
        protected void GridViewPageName_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int tableID = Convert.ToInt32(GridViewPageName.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteWebPages", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", tableID);
                cmd.Parameters.AddWithValue("@Createdby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Web Page Details Deleted Successfully";
                    GridViewPageName.EditIndex = -1;
                    ViewWebPages();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Web Page Details Not Deleted Successfully";
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

        protected void GridViewPageName_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridViewPageName.EditIndex = e.NewEditIndex;
                ViewWebPages();//ridview bindview
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

        protected void btnSavePagesClear_Click(object sender, EventArgs e)
        {
            WebpageClear();
            ViewWebPages();
        }

        protected void GridViewPageName_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string RowIndex;
                Label ID = GridViewPageName.Rows[e.RowIndex].FindControl("lblPage_ID1") as Label;
                TextBox txtPageName = GridViewPageName.Rows[e.RowIndex].FindControl("txtPageName") as TextBox;
                TextBox txtDescription1 = GridViewPageName.Rows[e.RowIndex].FindControl("txtDescription1") as TextBox;

                TextBox txtModule1 = GridViewPageName.Rows[e.RowIndex].FindControl("txtModule1") as TextBox;
                TextBox txtSubModule = GridViewPageName.Rows[e.RowIndex].FindControl("txtSubModule") as TextBox;
                TextBox txtDesign1 = GridViewPageName.Rows[e.RowIndex].FindControl("txtDesign1") as TextBox;
                int WebPageNameID = Convert.ToInt32(GridViewPageName.DataKeys[e.RowIndex].Values["ID"]);

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateWebPages", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", WebPageNameID);
                cmd.Parameters.AddWithValue("@WebPageName", txtPageName.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription1.Text);
                cmd.Parameters.AddWithValue("@Module", txtModule1.Text);
                cmd.Parameters.AddWithValue("@SubModule", txtSubModule.Text);
                cmd.Parameters.AddWithValue("@Design", txtDesign1.Text);
                cmd.Parameters.AddWithValue("@Createdby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Web Page Details Edit Successfully";
                    GridViewPageName.EditIndex = -1;
                    ViewWebPages();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Web Page Details Not Edit Successfully";
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

        protected void btnSavePagename_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SqlConnection con = new SqlConnection(strconnect);  // db connect
                    SqlCommand cmd = new SqlCommand("SP_SaveWebPages", con);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WebPageName", txtPagename.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescripwebpage.Text);
                    cmd.Parameters.AddWithValue("@Module", txtModule.Text);
                    cmd.Parameters.AddWithValue("@SubModule", txtSubModule.Text);
                    cmd.Parameters.AddWithValue("@Design", txtDesignpage.Text);
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
                        lblMesDelete.Text = "Web Page  Save Successfully";
                        WebpageClear();
                        ViewWebPages();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Web Page already Available";
                    }
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
        }

        protected void GridViewPageName_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridViewPageName.EditIndex = -1;
                ViewWebPages();
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

        //--------------------------------------------------------------------------------------------//
        //Measurements
        //-------------------------------------------------------------------------------------------//

        protected void GridMeasurmentProd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int tableID = Convert.ToInt32(GridMeasurmentProd.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteMeasurementProductDetails", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", tableID);
                cmd.Parameters.AddWithValue("@Created_by", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);

                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Measurement Product Deleted Successfully";
                    GridMeasurmentProd.EditIndex = -1;
                    ViewMeasurementDetails();

                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Measurement Product Not Deleted Successfully";
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
        protected void GridMeasurmentProd_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridMeasurmentProd.EditIndex = e.NewEditIndex;
                ViewMeasurementDetails();
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

        protected void GridMeasurmentProd_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string RowIndex;
                Label ID = GridMeasurmentProd.Rows[e.RowIndex].FindControl("lblMeasurmentID1") as Label;
                TextBox txtMeasurement = GridMeasurmentProd.Rows[e.RowIndex].FindControl("txtMeasurement") as TextBox;
                TextBox txtUnit = GridMeasurmentProd.Rows[e.RowIndex].FindControl("txtUnit") as TextBox;
                TextBox txtAbbreviations = GridMeasurmentProd.Rows[e.RowIndex].FindControl("txtAbbreviations") as TextBox;
                TextBox txtDescription = GridMeasurmentProd.Rows[e.RowIndex].FindControl("txtDescription") as TextBox;
                int MeasurmentID = Convert.ToInt32(GridMeasurmentProd.DataKeys[e.RowIndex].Values["ID"]);

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateMeasurementProductDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", MeasurmentID);
                cmd.Parameters.AddWithValue("@Measurement", txtMeasurement.Text);
                cmd.Parameters.AddWithValue("@Unit", txtUnit.Text);
                cmd.Parameters.AddWithValue("@Abbreviations", txtAbbreviations.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Created_by", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Measurement Product Edit Successfully";
                    GridMeasurmentProd.EditIndex = -1;
                    ViewMeasurementDetails();

                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Measurement Product Not Edit Successfully";
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


        protected void GridMeasurmentProd_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridMeasurmentProd.EditIndex = -1;
                ViewMeasurementDetails();
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



        protected void btnSaveMeasurement_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect); // db connect
                SqlCommand cmd = new SqlCommand("SP_SaveMeasurementProductDetails", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Measurement", txtMeasurement.Text);
                cmd.Parameters.AddWithValue("@Unit", txtUnit.Text);
                cmd.Parameters.AddWithValue("@Abbreviations", txtAbbreviations.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Created_by", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Measurement Product Save Successfully";
                    ClearMeasurement();
                    ViewMeasurementDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Measurement Product Not Save Successfully";
                }
                con.Close();
//tester  git hub rfdey66tfrdes
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


        protected void btnClearMeasurement_Click(object sender, EventArgs e)
        {
            ClearMeasurement();
        }


        //--------------------------------------------------------------------------------------------//
        //LinkButton Option  28
        //-------------------------------------------------------------------------------------------//
        protected void lnkbtnDivStatusOptions_Click(object sender, EventArgs e)
        {    
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DivProductStorageType.Visible = false;

            DivDepartmentDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivAddressDistrictDetails.Visible = false;

            DivAddressStateDetails.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivExpensesSubCategory.Visible = false;

            DivExpensesCategory.Visible = false;
            DivDiscountOptions.Visible = false;
            DivBillingOptions.Visible = false;
            DivContractType.Visible = false;
            DivStatusOptions.Visible = true;
        }
        protected void lnkbtnDivContractType_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;

            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DivProductStorageType.Visible = false;
            DivMeasurementProductDetails.Visible = false;

            DivDepartmentDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivAddressDistrictDetails.Visible = false;

            DivAddressStateDetails.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivExpensesSubCategory.Visible = false;

            DivExpensesCategory.Visible = false;
            DivDiscountOptions.Visible = false;
            DivBillingOptions.Visible = false;
            DivContractType.Visible = true;
       

        }
        protected void lnkbtnDivBillingOptions_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;

            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DivProductStorageType.Visible = false;
            DivMeasurementProductDetails.Visible = false;

            DivDepartmentDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivAddressDistrictDetails.Visible = false;

            DivAddressStateDetails.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivExpensesSubCategory.Visible = false;

            DivExpensesCategory.Visible = false;
            DivDiscountOptions.Visible = false;
            DivBillingOptions.Visible = true;
            

        }
        protected void lnkbtnDivDiscountOptions_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;

            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;

            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DivProductStorageType.Visible = false;
            DivMeasurementProductDetails.Visible = false;

            DivDepartmentDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivAddressDistrictDetails.Visible = false;

            DivAddressStateDetails.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivExpensesSubCategory.Visible = false;

            DivExpensesCategory.Visible = false;
            DivDiscountOptions.Visible = true;
           
        }
        protected void lnkbtnDivExpensesCategory_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;

            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;

            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DivProductStorageType.Visible = false;
            DivMeasurementProductDetails.Visible = false;

            DivDepartmentDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivAddressDistrictDetails.Visible = false;

            DivAddressStateDetails.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivExpensesSubCategory.Visible = false;

            DivExpensesCategory.Visible = true;
           
        }
        protected void lnkbtnDivExpensesSubCategory_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;

            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;

            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DivProductStorageType.Visible = false;
            DivMeasurementProductDetails.Visible = false;

            DivDepartmentDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivAddressDistrictDetails.Visible = false;

            DivAddressStateDetails.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivExpensesSubCategory.Visible = true;
        }
        protected void lknbtnDivReceiptInitialDetails_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;

            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;

            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DivProductStorageType.Visible = false;
            DivMeasurementProductDetails.Visible = false;

            DivDepartmentDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivAddressDistrictDetails.Visible = false;

            DivAddressStateDetails.Visible = false;
            DivReceiptInitialDetails.Visible = true;
          
        }
        protected void lnkbtnDivAddressStateDetails_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;

            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;

            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DivProductStorageType.Visible = false;
            DivMeasurementProductDetails.Visible = false;

            DivDepartmentDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivAddressDistrictDetails.Visible = false;

            DivAddressStateDetails.Visible = true;
          
        }
        protected void lnkbtnDivAddressDistrictDetails_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;

            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;

            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DivProductStorageType.Visible = false;
            DivMeasurementProductDetails.Visible = false;

            DivDepartmentDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivAddressDistrictDetails.Visible = true;

        }
        protected void linkbtnDivTenderCategory_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;

            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;
            DivProductStorageType.Visible = false;
            DivMeasurementProductDetails.Visible = false;

            DivDepartmentDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivTaxDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;

            DivTenderCategoryDetails.Visible = true;


        }
        protected void lnkbtnDivAddressCityTalukaDetails_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivTaxDetails.Visible = false;

            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DivProductStorageType.Visible = false;
            DivMeasurementProductDetails.Visible = false;

            DivDepartmentDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivTaxDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = true;

        }
        protected void lnkbtnDivTaxDetails_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;

            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DivProductStorageType.Visible = false;
            DivMeasurementProductDetails.Visible = false;

            DivDepartmentDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivTaxDetails.Visible = true;


           
        }
        protected void lnkbtnDivPagesOptions_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;

            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DivProductStorageType.Visible = false;
            DivMeasurementProductDetails.Visible = false;

            DivDepartmentDetails.Visible = false;
            DivPagesOptions.Visible = true;
 
        }
        protected void lnkbtnDivDepartmentDetails_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivPagesOptions.Visible = false;
         
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DivProductStorageType.Visible = false;
            DivMeasurementProductDetails.Visible = false;

            DivDepartmentDetails.Visible = true;


        }
        protected void lnkbtnDivMeasurementProductDetails_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivDepartmentDetails.Visible = false;
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DivProductStorageType.Visible = false;
            DivMeasurementProductDetails.Visible = true;
        }
        protected void linkbtnDIVProductStoragetype_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivDepartmentDetails.Visible = false;
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = false;

            DivProductStorageType.Visible = true;

        }
        protected void linkDIVbtnPolicy_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivDepartmentDetails.Visible = false;
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;

            DivProductStorageType.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = false;
            DIVPOLICY.Visible = true;

        }
        protected void likDIVShift_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivDepartmentDetails.Visible = false;
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;

            DivProductStorageType.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = true;
        }
        protected void linkDIVSalaryComponent_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivDepartmentDetails.Visible = false;
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;

            DivProductStorageType.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVParticular.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVParticular.Visible = true;

        }
        protected void linkDivHolidays_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivDepartmentDetails.Visible = false;
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;

            DivProductStorageType.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVParticular.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;
            DIVHoliday.Visible = true;
        }
        protected void linkDivLeaveMark_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivDepartmentDetails.Visible = false;
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;

            DivProductStorageType.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVParticular.Visible = false;
            DIVHoliday.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;
            DIVMaterLOGO.Visible = false;

            DIVLeaveMark.Visible = true;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;
        }
        protected void linkControlPanel_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivDepartmentDetails.Visible = false;
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;

            DivProductStorageType.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVParticular.Visible = false;
            DIVHoliday.Visible = false;

            DIVLeaveMark.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;
            DIVMaterLOGO.Visible = false;
            DIVControlPanel.Visible = true;
        }
        protected void linkMasterLogo_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivDepartmentDetails.Visible = false;
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;

            DivProductStorageType.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVParticular.Visible = false;
            DIVHoliday.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;
            DIVMaterLOGO.Visible = true;
        }
        protected void linkSalaryClass_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivDepartmentDetails.Visible = false;
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;

            DivProductStorageType.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVParticular.Visible = false;
            DIVHoliday.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = false;
            DIVSalaryClass.Visible = true;
        }
        protected void linkLeaveType_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivDepartmentDetails.Visible = false;
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;

            DivProductStorageType.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVParticular.Visible = false;
            DIVHoliday.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;
            DIVSalaryClass.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = false;
            DIVLeaveType.Visible = true;
        }
        protected void linkDashPermission_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivDepartmentDetails.Visible = false;
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;

            DivProductStorageType.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVParticular.Visible = false;
            DIVHoliday.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;
            DIVSalaryClass.Visible = false;
            DIVLeaveType.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = false;
            DIVDashboardPermission.Visible = true;
        }
        protected void linkCandidateTerms_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivDepartmentDetails.Visible = false;
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;

            DivProductStorageType.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVParticular.Visible = false;
            DIVHoliday.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;
            DIVSalaryClass.Visible = false;
            DIVLeaveType.Visible = false;
            DIVDashboardPermission.Visible = false;
            DivOfficialFields.Visible = false;
            DivCanTermCondi.Visible = true;
        }
        protected void linkOfficialDocFiled_Click(object sender, EventArgs e)
        {
            DivStatusOptions.Visible = false;
            DivContractType.Visible = false;
            DivBillingOptions.Visible = false;
            DivDiscountOptions.Visible = false;
            DivExpensesCategory.Visible = false;
            DivExpensesSubCategory.Visible = false;
            DivReceiptInitialDetails.Visible = false;
            DivAddressStateDetails.Visible = false;
            DivAddressDistrictDetails.Visible = false;
            DivAddressCityTalukaDetails.Visible = false;
            DivTaxDetails.Visible = false;
            DivPagesOptions.Visible = false;
            DivDepartmentDetails.Visible = false;
            DivMeasurementProductDetails.Visible = false;
            DivTenderCategoryDetails.Visible = false;

            DivProductStorageType.Visible = false;
            DIVPOLICY.Visible = false;
            DivShift.Visible = false;
            DIVParticular.Visible = false;
            DIVHoliday.Visible = false;

            DIVLeaveMark.Visible = false;
            DIVControlPanel.Visible = false;
            DIVMaterLOGO.Visible = false;
            DIVSalaryClass.Visible = false;
            DIVLeaveType.Visible = false;
            DIVDashboardPermission.Visible = false;
            DivCanTermCondi.Visible = false;
            DivOfficialFields.Visible = true;
        }

        //--------------------------------------------------------------------------------//
        //Product Storage Type
        //---------------------------------------------------------------------------------//

        protected void GridViewProductType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int tableID = Convert.ToInt32(GridViewProductType.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteProductCategory", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", tableID);
                cmd.Parameters.AddWithValue("@Createdby", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Product Storage Type Deleted Successfully";

                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Product Storage Type Not Deleted Successfully";
                }
                GridViewProductType.EditIndex = -1;
                ViewProductCategory();
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

        protected void btn_saveStorageType_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);  // db connect
                SqlCommand cmd = new SqlCommand("SP_SaveProductCategory", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductCategory", txtproductcategory.Text);
                cmd.Parameters.AddWithValue("@Description", txtproductdesc.Text);
                cmd.Parameters.AddWithValue("@Createdby", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
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
                    lblMesDelete.Text = "Product Storage Type Save Successfully";
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Product Storage Type Not Save Successfully";
                }

                ViewProductCategory();
                ClearStorage();
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

        protected void Btn_ClearStorageType_Click(object sender, EventArgs e)
        {
            ClearStorage();
        }

        protected void GridViewProductType_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridViewProductType.EditIndex = e.NewEditIndex;
                ViewProductCategory();
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

        protected void GridViewProductType_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string RowIndex;
                Label ID = GridViewProductType.Rows[e.RowIndex].FindControl("lblPage_ID1") as Label;
                TextBox txtProductCategory = GridViewProductType.Rows[e.RowIndex].FindControl("txtProductCategory") as TextBox;
                TextBox txtProductDescrip = GridViewProductType.Rows[e.RowIndex].FindControl("txtDescrip") as TextBox;
                int ProductCategoryID = Convert.ToInt32(GridViewProductType.DataKeys[e.RowIndex].Values["ID"]);

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateProductCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ProductCategoryID);
                cmd.Parameters.AddWithValue("@ProductCategory", txtProductCategory.Text);
                cmd.Parameters.AddWithValue("@Description", txtProductDescrip.Text);
                cmd.Parameters.AddWithValue("@Createdby", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Product Storage Type Update Successfully";

                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Product Storage Type Not Update Successfully";
                }
                GridViewProductType.EditIndex = -1;
                ViewProductCategory();
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

        protected void GridViewProductType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridViewProductType.EditIndex = -1;
                ViewProductCategory();
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

        //-----------------------------------------------------------------------//
        //Policy
        //--------------------------------------------------------------------------
        protected void GridViewPolicy_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridViewPolicy.EditIndex = e.NewEditIndex;
                ViewPolicy();//ridview bindview
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

        protected void GridViewPolicy_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int tableID = Convert.ToInt32(GridViewPolicy.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeletePolicy", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", tableID);
                cmd.Parameters.AddWithValue("@Createdby", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Policy Details Deleted Successfully";

                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Policy Details  Not Deleted Successfully";
                }
                GridViewPolicy.EditIndex = -1;
                ViewPolicy();
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

        protected void GridViewPolicy_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridViewPolicy.EditIndex = -1;
                ViewPolicy();
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

        protected void GridViewPolicy_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string RowIndex;
                Label ID = GridViewPolicy.Rows[e.RowIndex].FindControl("lblPolicy_ID1") as Label;
                TextBox txtPolicyName = GridViewPolicy.Rows[e.RowIndex].FindControl("txtPolicyName") as TextBox;
                TextBox txtPolicyDescription = GridViewPolicy.Rows[e.RowIndex].FindControl("txtPolicyDescription") as TextBox;
                int PolicyID = Convert.ToInt32(GridViewPolicy.DataKeys[e.RowIndex].Values["ID"]);

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdatePolicy", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", PolicyID);
                cmd.Parameters.AddWithValue("@PolicyName", txtPolicyName.Text);
                cmd.Parameters.AddWithValue("@Description", txtPolicyDescription.Text);
                cmd.Parameters.AddWithValue("@Createdby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Policy Details Update Successfully";
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Policy Details  Not Update Successfully";
                }
                GridViewPolicy.EditIndex = -1;
                ViewPolicy();
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

        protected void btnSavePolicy_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);  // db connect
                SqlCommand cmd = new SqlCommand("SP_SavePolicy", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PolicyName", txtPolicyName.Text);
                cmd.Parameters.AddWithValue("@Description", txtPolicyDescrip.Text);
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
                    lblMesDelete.Text = "Policy Details Save Successfully";
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Policy Details Not Save Successfully";
                }
                ClearPolicy();
                ViewPolicy();
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

        protected void btnPolicyClear_Click1(object sender, EventArgs e)
        {
            ClearPolicy();
        }

        //-----------------------------------------------------------------------//
        //Shift
        //--------------------------------------------------------------------------
        public void ClearShift()
        {
            txtShiftName1.Text = string.Empty;
            txtShiftHour1.Text = string.Empty;


        }
        protected void Btn_SaveShift_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);  // db connect
                SqlCommand cmd = new SqlCommand("SP_SaveShifts", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ShiftName", txtShiftName1.Text);
                cmd.Parameters.AddWithValue("@Hours", txtShiftHour1.Text);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
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
                    lblMesDelete.Text = "Shift Details Save Successfully";
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Shift Details already Available";
                }

                ViewShifts();
                ClearShift();
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



        protected void Btn_ClearShift_Click(object sender, EventArgs e)
        {
            ClearShift();
        }

        protected void GridViewShift_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int tableID = Convert.ToInt32(GridViewShift.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteShifts", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", tableID);
                cmd.Parameters.AddWithValue("@Createdby", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Shift Details Deleted Successfully";

                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Shift Details Not Deleted Successfully";
                }
                GridViewShift.EditIndex = -1;
                ViewShifts();

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

        protected void GridViewShift_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridViewShift.EditIndex = e.NewEditIndex;
                ViewShifts();
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

        protected void GridViewShift_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string RowIndex;
                Label ID = GridViewShift.Rows[e.RowIndex].FindControl("lblShift_ID1") as Label;
                TextBox txtShiftName = GridViewShift.Rows[e.RowIndex].FindControl("txtShiftName") as TextBox;
                TextBox txtShiftHour = GridViewShift.Rows[e.RowIndex].FindControl("txtHours") as TextBox;
                int ShiftID = Convert.ToInt32(GridViewShift.DataKeys[e.RowIndex].Values["ID"]);

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateShifts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ShiftID);
                cmd.Parameters.AddWithValue("@ShiftName", txtShiftName.Text);
                cmd.Parameters.AddWithValue("@Hours", txtShiftHour.Text);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Shift Details Update Successfully";

                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Shift Details Not Update Successfully";
                }
                GridViewShift.EditIndex = -1;
                ViewShifts();
                ClearShift();
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

        protected void GridViewShift_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridViewShift.EditIndex = -1;
                ViewShifts();
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

        //-----------------------------------------------------------------------//
        // Perticular /Salary Component
        //--------------------------------------------------------------------------
        public void ClearParticular()
        {
            txtPerticular1.Text = string.Empty;
            txtDescriptionParticular1.Text = string.Empty;
            ddlPerticularType1.SelectedValue = string.Empty;
            txtDescriptionParticular1.Text = string.Empty;
            txtPercentage1.Text = string.Empty;

        }

        protected void GridPerticular_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int tableID = Convert.ToInt32(GridPerticular.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeletePerticular", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", tableID);
                cmd.Parameters.AddWithValue("@Createdby", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Salary Perticular Deleted Successfully";

                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Salary Perticular Not Deleted Successfully";
                }
                GridPerticular.EditIndex = -1;
                ViewPerticular();

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


        protected void GridPerticular_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridPerticular.EditIndex = e.NewEditIndex;
                ViewPerticular();
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

        protected void GridPerticular_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string RowIndex;
                Label ID = GridPerticular.Rows[e.RowIndex].FindControl("lblPerticulars_ID1") as Label;
                TextBox txtPerticular = GridPerticular.Rows[e.RowIndex].FindControl("txtPerticular") as TextBox;
                DropDownList ddlPerticularType = GridPerticular.Rows[e.RowIndex].FindControl("ddlPerticularType") as DropDownList;
                TextBox txtPercentage = GridPerticular.Rows[e.RowIndex].FindControl("txtPercentage") as TextBox;
                TextBox txtDescriptionPerticular = GridPerticular.Rows[e.RowIndex].FindControl("txtDescriptionPerticular") as TextBox;
                int ParticularID = Convert.ToInt32(GridPerticular.DataKeys[e.RowIndex].Values["ID"]);

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdatePerticular", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ParticularID);
                cmd.Parameters.AddWithValue("@Perticular", txtPerticular.Text);
                cmd.Parameters.AddWithValue("@PerticularType", ddlPerticularType.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Percentage", txtPercentage.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescriptionPerticular.Text);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Salary Perticular Update Successfully";

                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Salary Perticular Not Update Successfully";
                }
                GridPerticular.EditIndex = -1;
                ViewPerticular();
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

        protected void GridPerticular_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridPerticular.EditIndex = -1;
                ViewPerticular();
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

        protected void btnSaveParticular_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);  // db connect
                SqlCommand cmd = new SqlCommand("SP_SavePerticular", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Perticular", txtPerticular1.Text);
                cmd.Parameters.AddWithValue("@Percentage", txtPercentage1.Text);
                cmd.Parameters.AddWithValue("@PerticularType", ddlPerticularType1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescriptionParticular1.Text);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
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
                    lblMesDelete.Text = "Salary Perticular Save Successfully";
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Salary Perticular already Available";
                }

                ViewPerticular();
                ClearParticular();
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

        protected void btnClearParticular_Click(object sender, EventArgs e)
        {
            ClearParticular();
        }

        //---------------------------------------------------------------
        // Holiday
        //--------------------------------------------------------------

        public void ClearHoliday()
        {
            txtHolidayNm.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            txtDescriptionH.Text = string.Empty;

        }
        protected void btnSaveHoliday_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    SqlConnection con = new SqlConnection(strconnect);  // db connect
                    SqlCommand cmd = new SqlCommand("SP_SaveHoliday", con);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HolidayName", txtHolidayNm.Text);
                    cmd.Parameters.AddWithValue("@StartDate", txtStartDate.Text);
                    cmd.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@CreateBy", UserName);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    con.Close();
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Holiday Details Save Successfully";

                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Holiday Details already Available";
                    }
                    ViewHoliday();
                    ClearHoliday();
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

        protected void btnClearHoliday_Click(object sender, EventArgs e)
        {
            ClearHoliday();
        }

        protected void GridHoliday_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridHoliday.EditIndex = -1;
                ViewHoliday();
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

        protected void lnkbtnExcelHoliday_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ViewHoliday();
                if (dt != null && dt.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment;filename=Holiday_Details.xls");
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Holiday_Details " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));
                    Response.Charset = " ";
                    // Create a new DataTable with only the desired columns
                    DataTable dtExport = new DataTable();
                    dtExport.Columns.Add("ID");
                    dtExport.Columns.Add("HolidayName");
                    dtExport.Columns.Add("Description");
                    dtExport.Columns.Add("StartDate");
                    dtExport.Columns.Add("EndDate");
                    dtExport.Columns.Add("Create_Date");
                    // Copy the data from the original DataTable to the export DataTable
                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow newRow = dtExport.NewRow();
                        newRow["ID"] = row["ID"];
                        newRow["HolidayName"] = row["HolidayName"];
                        newRow["Description"] = row["Description"];
                        newRow["StartDate"] = row["StartDate"];
                        newRow["EndDate"] = row["EndDate"];
                        newRow["Create_Date"] = row["Create_Date"];
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

        protected void GridHoliday_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridHoliday.EditIndex = e.NewEditIndex;
                ViewHoliday();
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

        protected void GridHoliday_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string RowIndex;
                Label ID = GridHoliday.Rows[e.RowIndex].FindControl("lblHoliday_ID1") as Label;
                TextBox txtHolidayName = GridHoliday.Rows[e.RowIndex].FindControl("txtHolidayName") as TextBox;
                TextBox txtHolidayDescription = GridHoliday.Rows[e.RowIndex].FindControl("txtHolidayDescription") as TextBox;
                int HoliDayID = Convert.ToInt32(GridHoliday.DataKeys[e.RowIndex].Values["ID"]);

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateHoliday", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", HoliDayID);
                cmd.Parameters.AddWithValue("@HolidayName", txtHolidayName.Text);
                cmd.Parameters.AddWithValue("@StartDate", txtStartDate.Text);
                cmd.Parameters.AddWithValue("@EndDate", txtEndDate.Text);
                cmd.Parameters.AddWithValue("@Description", txtHolidayDescription.Text);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Holiday Details Update Successfully";

                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Holiday Details Not Update Successfully";
                }
                GridHoliday.EditIndex = -1;
                ViewHoliday();
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

        protected void GridHoliday_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int tableID = Convert.ToInt32(GridHoliday.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteHoliday", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", tableID);
                cmd.Parameters.AddWithValue("@Createdby", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Holiday Details Deleted Successfully";

                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Holiday Details Not Deleted Successfully";
                }
                GridHoliday.EditIndex = -1;
                ViewHoliday();

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

        //----------------------------------------------------------------------------//
        // Leave Mark 
        //----------------------------------------------------------------------------//

        protected void btnMarksave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    using (UserCon = new SqlConnection(strconnect))
                    {
                        SqlCommand UserCommand = new SqlCommand("SP_SaveMark", UserCon);
                        UserCommand.Connection = UserCon;
                        UserCommand.CommandType = CommandType.StoredProcedure;
                        UserCommand.Parameters.AddWithValue("@MarkCount", txtmark.Text);
                        UserCommand.Parameters.AddWithValue("@MarkName", txthrms.Text);
                        UserCommand.Parameters.AddWithValue("@Createby", UserName); //Session value
                        UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                        UserCommand.Parameters.AddWithValue("@Designation", Designation);
                        UserCon.Open();
                        dr = UserCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Leave Mark Save Successfully!";
                            GetMarkDetails();
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Leave Mark Already Available!";
                        }

                        txtmark.Text = string.Empty;
                        txthrms.Text = string.Empty;
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

        protected void btnMarkclear_Click(object sender, EventArgs e)
        {
            try
            {
                MarkClear();
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

        protected void GridMark_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string itemName = e.Row.Cells[1].Text;
                    foreach (LinkButton button in e.Row.Cells[7].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + itemName + "?')){ return false; };";
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
            finally { }
        }

        protected void GridMark_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridMark.EditIndex = e.NewEditIndex;
                GetMarkDetails();
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

        protected void GridMark_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ID = GridMark.Rows[e.RowIndex].FindControl("lblID1") as Label;
                TextBox txthrms = GridMark.Rows[e.RowIndex].FindControl("txthrms") as TextBox;
                TextBox txtmark = GridMark.Rows[e.RowIndex].FindControl("txtmark") as TextBox;
                int Mark_ID = Convert.ToInt32(GridMark.DataKeys[e.RowIndex].Values["ID"]);//Datakey

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateMark", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Mark_ID);
                cmd.Parameters.AddWithValue("@MarkName", txthrms.Text);
                cmd.Parameters.AddWithValue("@MarkCount", txtmark.Text);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Leave Mark Details Update Successfully";
                    GridMark.EditIndex = -1;
                    GetMarkDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Leave Mark Details Not Update Successfully";
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

        protected void GridMark_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridMark.EditIndex = -1;
                GetMarkDetails();
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

        protected void GridMark_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                SqlConnection DeviceCon = new SqlConnection(strconnect);
                int Mark_ID = Convert.ToInt32(GridMark.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteMark", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Mark_ID);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Leave Mark Details Deleted Successfully";
                    GridMark.EditIndex = -1;
                    GetMarkDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Leave Mark Details Not Deleted Successfully";
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

        protected void GridMark_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridMark.PageIndex = e.NewPageIndex;
                GetMarkDetails();
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

        //-------------------------------------------------------------------------------
        // Control PANEL CRUD
        //-------------------------------------------------------------------------------

        protected void BtnControlSave1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    SqlConnection UserCon = new SqlConnection(strconnect);
                    SqlCommand UserCommand = new SqlCommand("SP_Saveuserpanel", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
                    UserCommand.Parameters.AddWithValue("@Password", txtpassword.Text);
                    UserCommand.Parameters.AddWithValue("@name", txtname.Text);
                    UserCommand.Parameters.AddWithValue("@Description", txtdescript.Text);
                    UserCommand.Parameters.AddWithValue("@Createby", UserName); //Session value
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);
                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Control Panel User Details Save Successfully!";
                        GetControlPanelDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Control Panel User Details Not Save Successfully!";
                    }

                    txtname.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtpassword.Text = string.Empty;
                    txtdescript.Text = string.Empty;
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

        protected void BtnControlclear1_Click(object sender, EventArgs e)
        {
            txtname.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtpassword.Text = string.Empty;
            txtdescript.Text = string.Empty;
            ControlPanelClear();
        }

        protected void GridControlPanel_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string itemName = e.Row.Cells[1].Text;
                    foreach (LinkButton button in e.Row.Cells[7].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + itemName + "?')){ return false; };";
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
            finally { }
        }

        protected void GridControlPanel_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridControlPanel.EditIndex = e.NewEditIndex;
                GetControlPanelDetails();
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

        protected void GridControlPanel_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ID = GridControlPanel.Rows[e.RowIndex].FindControl("lblID1") as Label;
                TextBox txtEmail = GridControlPanel.Rows[e.RowIndex].FindControl("txtEmail") as TextBox;
                //Label lblID1 = GridMark.Rows[e.RowIndex].FindControl("lblID1") as Label; 
                TextBox txtpassword = GridControlPanel.Rows[e.RowIndex].FindControl("txtpassword") as TextBox;
                TextBox txtname = GridControlPanel.Rows[e.RowIndex].FindControl("txtname") as TextBox;
                int User_ID = Convert.ToInt32(GridControlPanel.DataKeys[e.RowIndex].Values["UserId"]);//Datakey
                //int Mark_ID = lblID1.Text;
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateControlPanel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", User_ID);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Control Panel User Details Update Successfully";
                    GridControlPanel.EditIndex = -1;
                    GetControlPanelDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Control Panel User Details Not Update Successfully";
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

        protected void GridControlPanel_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridControlPanel.EditIndex = -1;
                GetControlPanelDetails();
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

        protected void GridControlPanel_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                SqlConnection DeviceCon = new SqlConnection(strconnect);
                int User_ID1 = Convert.ToInt32(GridControlPanel.DataKeys[e.RowIndex].Values["UserId"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteControlPanl", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", User_ID1);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Control Panel User Details Deleted Successfully";
                    GridControlPanel.EditIndex = -1;
                    GetControlPanelDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Control Panel User Details Not Deleted Successfully";
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

        protected void GridControlPanel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridControlPanel.PageIndex = e.NewPageIndex;
                GetControlPanelDetails();
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

        //-------------------------------------------------------------------------
        // Master Logo /Sidebar Logo Setting
        //-------------------------------------------------------------------------

        protected void ImgBtn_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                //if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {
                    string strname = FileUpload1.FileName.ToString();
                    Image1.Visible = true;
                    string folderPath = Server.MapPath("~/LogoImg/");

                    //Check whether Directory (Folder) exists.
                    if (!Directory.Exists(folderPath))
                    {
                        //If Directory (Folder) does not exists Create it.
                        Directory.CreateDirectory(folderPath);
                    }

                    //Save the File to the Directory (Folder).
                    FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));

                    //Display the Picture in Image control.
                    Image1.ImageUrl = "~/LogoImg/" + Path.GetFileName(FileUpload1.FileName);
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Choose Image to upload!')", true);
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

        protected void btnSavefileImg_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    SqlConnection UserCon = new SqlConnection(strconnect);
                    SqlCommand UserCommand = new SqlCommand("SP_Savelogo", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@ImageFilePath", Image1.ImageUrl);
                    UserCommand.Parameters.AddWithValue("@ImageName", txtimg.Text);
                    UserCommand.Parameters.AddWithValue("@ImageFor", ddlfileimg.SelectedItem.Text);
                    UserCommand.Parameters.AddWithValue("@Extension", txtextion.Text);
                    UserCommand.Parameters.AddWithValue("@Createby", UserName); //Session value
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);
                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Sidebar Image Logo Save Successfully!";
                        GetImglogoDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Sidebar Image Logo Already Available!";
                    }

                    txtimg.Text = string.Empty;
                    txtextion.Text = string.Empty;
                    ddlfileimg.SelectedIndex = -1;
                    Image1.ImageUrl = string.Empty;
                    Image1.Visible = false;
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

        protected void btnClosefileImg_Click(object sender, EventArgs e)
        {
            ControlPanelClear();
        }

        protected void Gridlogoimg_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Gridlogoimg.EditIndex = e.NewEditIndex;
                GetImglogoDetails();
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



        protected void Gridlogoimg_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ID = Gridlogoimg.Rows[e.RowIndex].FindControl("lblID1") as Label;
                TextBox txtIname = Gridlogoimg.Rows[e.RowIndex].FindControl("txtIname") as TextBox;
                DropDownList ddlfileimg = Gridlogoimg.Rows[e.RowIndex].FindControl("ddlfileimgeditor") as DropDownList;
                Label lblExtension = Gridlogoimg.Rows[e.RowIndex].FindControl("lblExtensionE") as Label;
                TextBox txtimgfor = Gridlogoimg.Rows[e.RowIndex].FindControl("txtimgfor") as TextBox;

                int LOGO_ID = Convert.ToInt32(Gridlogoimg.DataKeys[e.RowIndex].Values["ID"]);//Datakey
                //int Mark_ID = lblID1.Text;
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateImglogo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", LOGO_ID);
                cmd.Parameters.AddWithValue("@ImageName", txtIname.Text);
                cmd.Parameters.AddWithValue("@Extension", lblExtension.Text);
                cmd.Parameters.AddWithValue("@ImageFor", ddlfileimg.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Sidebar Image logo Details Update Successfully";
                    Gridlogoimg.EditIndex = -1;
                    GetImglogoDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Sidebar Image logo Details Not Update Successfully";
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
        protected void Gridlogoimg_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string itemName = e.Row.Cells[1].Text;
                    foreach (LinkButton button in e.Row.Cells[9].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + itemName + "?')){ return false; };";
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
        protected void Gridlogoimg_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                Gridlogoimg.EditIndex = -1;
                GetImglogoDetails();
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

        protected void Gridlogoimg_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int LOGO_ID = Convert.ToInt32(Gridlogoimg.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteImgLogo", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", LOGO_ID);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Sidebar Image logo Details Deleted Successfully";
                    Gridlogoimg.EditIndex = -1;
                    GetImglogoDetails();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Sidebar Image logo Details Not Deleted Successfully";
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

        protected void Gridlogoimg_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Gridlogoimg.PageIndex = e.NewPageIndex;
                GetImglogoDetails();
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

        //---------------------------------------------------------------------------------//
        // Salary Class CRUD
        //----------------------------------------------------------------------------------//

        public void ClearClass()
        {
            txtClass.Text = string.Empty;
            txtClassDescription.Text = string.Empty;
        }

        public DataTable ViewClass()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewClass", con))
                {
                    ad.Fill(table);
                    GridViewClass.DataSource = table;
                    GridViewClass.DataBind();
                }
            }
            return table;
        }

        protected void btnSaveClass_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);  // db connect
                SqlCommand cmd = new SqlCommand("SP_SaveClass", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClassName", txtClass.Text);
                cmd.Parameters.AddWithValue("@Description", txtClassDescription.Text);
                cmd.Parameters.AddWithValue("@Createby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);

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
                    lblMesDelete.Text = "Salary Class Save Successfully";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Class Save Successfully!')", true);
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Salary Class already Available!";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Class already Available!')", true);
                }
                ClearClass();
                ViewClass();
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

        protected void GridViewClass_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int tableID = Convert.ToInt32(GridViewClass.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteClass", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", tableID);
                cmd.Parameters.AddWithValue("@Createby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Salary Class Delete Successfully!";
                    GridViewClass.EditIndex = -1;
                    ViewClass();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Salary Class Not Delete Successfully!";
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



        protected void GridViewClass_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridViewClass_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridViewClass.EditIndex = e.NewEditIndex;
                ViewClass();//gridview bindview
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

        protected void GridViewClass_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ID = GridViewClass.Rows[e.RowIndex].FindControl("lblClassID") as Label;

                TextBox txtClassName = GridViewClass.Rows[e.RowIndex].FindControl("txtClassName") as TextBox;
                TextBox txtClassDescription = GridViewClass.Rows[e.RowIndex].FindControl("txtclassDescription1") as TextBox;
                int SalCategoryID = Convert.ToInt32(GridViewClass.DataKeys[e.RowIndex].Values["ID"]);

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SalCategoryID);
                cmd.Parameters.AddWithValue("@ClassName", txtClassName.Text);
                cmd.Parameters.AddWithValue("@Description", txtClassDescription.Text);
                cmd.Parameters.AddWithValue("@Createby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Salary Class Update Successfully!";
                    GridViewClass.EditIndex = -1;
                    ViewClass();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Salary Class Not Update Successfully!";
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

        protected void GridViewClass_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridViewClass.EditIndex = -1;
                ViewClass();
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

        protected void btnClearClass_Click(object sender, EventArgs e)
        {
            ClearClass();
        }

        //--------------------------------------------------------------------------//
        // Leave Type
        //--------------------------------------------------------------------------//
        protected void btnSaveLeave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);  // db connect
                SqlCommand cmd = new SqlCommand("SP_SaveLeaveType", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LeaveType", txtLeaveType.Text);
                cmd.Parameters.AddWithValue("@NoOfLeave", txtNoOfleave.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescLeave.Text);
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
                    lblMesDelete.Text = "Leave Type  Save Successfully!";

                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Leave Type already Available!";

                }
                LeaveTypeClear();
                ViewLeaveType();
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

        protected void btnClearLeave_Click(object sender, EventArgs e)
        {
            LeaveTypeClear();
        }

        protected void GridLeave_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int tableID = Convert.ToInt32(GridLeave.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeletePolicy", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", tableID);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Leave Type Deleted Successfully!";
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Leave Type Not Deleted Yet!";
                }
                GridLeave.EditIndex = -1;
                ViewLeaveType();

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

        protected void GridLeave_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridLeave.EditIndex = e.NewEditIndex;
                ViewLeaveType();//ridview bindview
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

        protected void GridLeave_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string RowIndex;
                Label ID = GridLeave.Rows[e.RowIndex].FindControl("lblLeaveType_ID1") as Label;
                TextBox txtLeaveType = GridLeave.Rows[e.RowIndex].FindControl("txtLeaveType") as TextBox;
                TextBox txtNoOfLeave = GridLeave.Rows[e.RowIndex].FindControl("txtNoOfLeave") as TextBox;
                TextBox txtDescript = GridLeave.Rows[e.RowIndex].FindControl("txtDescript") as TextBox;
                int LeaveID = Convert.ToInt32(GridLeave.DataKeys[e.RowIndex].Values["ID"]);

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateLeave", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", LeaveID);
                cmd.Parameters.AddWithValue("@LeaveType", txtLeaveType.Text);
                cmd.Parameters.AddWithValue("@NoOfLeave", txtNoOfLeave.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescript.Text);
                cmd.Parameters.AddWithValue("@Createdby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Leave Type Update Successfully!";
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Leave Type Not Update Yet!";
                }
                GridLeave.EditIndex = -1;
                ViewLeaveType();
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

        protected void GridLeave_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridLeave.EditIndex = -1;
                ViewLeaveType();
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



        //-------------------------------------------------------------------------
        // Dashboard Setting
        //-------------------------------------------------------------------------
        protected void btnDashsettingSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);  // db connect
                SqlCommand cmd = new SqlCommand("SP_SaveDashBoardSetting", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DivID", txtDivID.Text);
                cmd.Parameters.AddWithValue("@DivName", txtDivName.Text);
                cmd.Parameters.AddWithValue("@RoleName", ddlRole.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@DeptID", ddlDepartment.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@DeptName", ddlDepartment.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Description", txtDasDescription.Text);
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
                    lblMesDelete.Text = "DashBoard Setting  Save Successfully!";
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "DashBoard Setting already Available!";
                }

                con.Close();
                DashPermissionClear();
                ViewDashBoardSetting();

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

        protected void btndashSettingclear_Click(object sender, EventArgs e)
        {
            DashPermissionClear();
        }
        protected void GVDBSetting_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GVDBSetting.EditIndex = -1;
                ViewDashBoardSetting();
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

        protected void GVDBSetting_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string RowIndex;
                Label ID = GVDBSetting.Rows[e.RowIndex].FindControl("lblDB_ID1") as Label;
                TextBox txtDivID1 = GVDBSetting.Rows[e.RowIndex].FindControl("txtDivID1") as TextBox;
                TextBox txtDivName1 = GVDBSetting.Rows[e.RowIndex].FindControl("txtDivName1") as TextBox;
                DropDownList ddlRoleName = GVDBSetting.Rows[e.RowIndex].FindControl("ddlRoleName") as DropDownList;
                DropDownList ddlDeptName = GVDBSetting.Rows[e.RowIndex].FindControl("ddlDeptName") as DropDownList;

                TextBox txtDasDescription1 = GVDBSetting.Rows[e.RowIndex].FindControl("txtDasDescription1") as TextBox;
                int DBSettingID = Convert.ToInt32(GVDBSetting.DataKeys[e.RowIndex].Values["ID"]);

                SqlConnection con = new SqlConnection(strconnect);  // db connect
                SqlCommand cmd = new SqlCommand("SP_UpdateDashBoardSetting", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", DBSettingID);
                cmd.Parameters.AddWithValue("@DivID", txtDivID1.Text);
                cmd.Parameters.AddWithValue("@DivName", txtDivName1.Text);
                cmd.Parameters.AddWithValue("@RoleName", ddlRoleName.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@DeptID", ddlDeptName.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@DeptName", ddlDeptName.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Description", txtDasDescription1.Text);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "DashBoard Setting  Update Successfully!";
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "DashBoard Setting Not Update Successfully!";
                }
                GVDBSetting.EditIndex = -1;
                ViewDashBoardSetting();

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

        protected void GVDBSetting_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GVDBSetting.EditIndex = e.NewEditIndex;
                ViewDashBoardSetting();
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

        protected void GVDBSetting_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GVDBSetting.Rows)
                {
                    // string  Status = Convert.ToString(e.Row.Cells[8].Text);

                    //System.Web.UI.WebControls.Label lblDB_ID1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblDB_ID1");
                    System.Web.UI.WebControls.Label lblDivID1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblDivID1");
                    System.Web.UI.WebControls.Label lblDivName1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblDivName1");
                    System.Web.UI.WebControls.Label lblRoleName1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblRoleName1");
                    System.Web.UI.WebControls.Label lblDeptName1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblDeptName1");
                    System.Web.UI.WebControls.Label lbDescription1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lbDescription1");
                    System.Web.UI.WebControls.Label lblDBCreateby1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblDBCreateby1");
                    System.Web.UI.WebControls.Label lblDBCreateddate1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblDBCreateddate1");
                    System.Web.UI.WebControls.Label lblDBStatus1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblDBStatus1");
                    string status = lblDBStatus1.Text;

                    if (status == "True")
                    {

                        //lblDB_ID1.ForeColor = System.Drawing.Color.Black;
                        lblDivID1.ForeColor = System.Drawing.Color.Black;
                        lblDivName1.ForeColor = System.Drawing.Color.Blue;
                        lblRoleName1.ForeColor = System.Drawing.Color.Blue;
                        lblDeptName1.ForeColor = System.Drawing.Color.Blue;
                        lbDescription1.ForeColor = System.Drawing.Color.Black;
                        lblDBCreateby1.ForeColor = System.Drawing.Color.Black;
                        lblDBCreateddate1.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        //lblDB_ID1.ForeColor = System.Drawing.Color.Red;
                        lblDivID1.ForeColor = System.Drawing.Color.Red;
                        lblDivName1.ForeColor = System.Drawing.Color.Red;
                        lblRoleName1.ForeColor = System.Drawing.Color.Red;
                        lblDeptName1.ForeColor = System.Drawing.Color.Red;
                        lbDescription1.ForeColor = System.Drawing.Color.Red;
                        lblDBCreateby1.ForeColor = System.Drawing.Color.Red;
                        lblDBCreateddate1.ForeColor = System.Drawing.Color.Red;
                    }
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {
                        UserCon = new SqlConnection(strconnect);
                        UserCon.Open();
                        DropDownList ddlDeptName = (DropDownList)e.Row.FindControl("ddlDeptName");
                        DropDownList ddlRoleName = (DropDownList)e.Row.FindControl("ddlRoleName");

                        //return DataTable havinf department data
                        using (SqlConnection conn = new SqlConnection(strconnect))
                        {

                            SqlCommand cmd = new SqlCommand("SP_GetDeptName", conn);
                            cmd.Connection = conn;
                            cmd.CommandType = CommandType.StoredProcedure;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                ddlDeptName.DataSource = dt;

                                ddlDeptName.DataTextField = "Dept_Name";
                                ddlDeptName.DataValueField = "Dept_ID";
                                ddlDeptName.DataBind();
                                ddlDeptName.Items.Insert(0, new ListItem("Select Department", "0"));

                                DataRowView dr = e.Row.DataItem as DataRowView;
                                ddlDeptName.SelectedValue = dr["DeptID"].ToString();
                            }
                        }

                        using (SqlConnection conn = new SqlConnection(strconnect))
                        {
                            SqlCommand cmd = new SqlCommand("SP_ViewRolesByGroup", conn);

                            cmd.CommandType = CommandType.StoredProcedure;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                ddlRoleName.DataSource = dt;
                                ddlRoleName.DataTextField = "RoleName";
                                ddlRoleName.DataValueField = "RoleName";
                                ddlRoleName.DataBind();
                                ddlRoleName.Items.Insert(0, new ListItem("Select Roles", "0"));

                                DataRowView dr = e.Row.DataItem as DataRowView;
                                ddlRoleName.SelectedValue = dr["RoleName"].ToString();
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

        protected void GVDBSetting_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                SqlConnection DeviceCon = new SqlConnection(strconnect);
                int tableID = Convert.ToInt32(GVDBSetting.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteDashboardSetting", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", tableID);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "DashBoard Setting  Deleted Successfully!";
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "DashBoard Setting Not Deleted Yet!";
                }
                GVDBSetting.EditIndex = -1;
                ViewDashBoardSetting();
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

        //--------------------------------------------------------------------------------//
        //Candidate Term And Conditions
        //---------------------------------------------------------------------------------//
        public void clearTerms()
        {
            txtTermAndCond.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtParagraph1.Text = string.Empty;
            txtParagraph2.Text = string.Empty;
        }

        public DataTable ViewTermAndCondition()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewTermAndCondition", con))
                {
                    ad.Fill(table);
                    GridViewTermAndCondition.DataSource = table;
                    GridViewTermAndCondition.DataBind();
                }
            }
            return table;
        }
        protected void btnSaveTemsConditions_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);  // db connect
                SqlCommand cmd = new SqlCommand("SP_SaveTermsAndConditon", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TermsAndCondition", txtTermAndCond.Text);
                cmd.Parameters.AddWithValue("@Note", txtNote.Text);
                cmd.Parameters.AddWithValue("@Paragraph1", txtParagraph1.Text);
                cmd.Parameters.AddWithValue("@Paragraph2", txtParagraph2.Text);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
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
                    lblMesDelete.Text = "Terms and Condition Save Successfully!";
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Terms and Condition already Available!";
                }
              

                ViewTermAndCondition();
                clearTerms();
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

       

        protected void btnClearTemsConditions_Click(object sender, EventArgs e)
        {
            clearTerms();
        }

        protected void GridViewTermAndCondition_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                int tableID = Convert.ToInt32(GridViewTermAndCondition.DataKeys[e.RowIndex].Values["ID"].ToString());
                SqlCommand cmd = new SqlCommand("SP_DeleteTermsAndCondition", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", tableID);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Terms and Condition Deleted Successfully!";
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Terms and Condition Not Deleted Yet!";
                }
                GridViewTermAndCondition.EditIndex = -1;
                ViewTermAndCondition();

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

        protected void GridViewTermAndCondition_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {

                GridViewTermAndCondition.EditIndex = e.NewEditIndex;
                ViewTermAndCondition();

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

        protected void GridViewTermAndCondition_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ID = GridViewTermAndCondition.Rows[e.RowIndex].FindControl("lblTermAndCondition_ID1") as Label;
                TextBox txtTermsAndCondition = GridViewTermAndCondition.Rows[e.RowIndex].FindControl("txtTermsAndCondition") as TextBox;
                TextBox txtNote = GridViewTermAndCondition.Rows[e.RowIndex].FindControl("txtNote") as TextBox;
                TextBox txtParagraph1 = GridViewTermAndCondition.Rows[e.RowIndex].FindControl("txtParagraph1") as TextBox;
                TextBox txtParagraph2 = GridViewTermAndCondition.Rows[e.RowIndex].FindControl("txtParagraph2") as TextBox;

                int TermAndConditionID = Convert.ToInt32(GridViewTermAndCondition.DataKeys[e.RowIndex].Values["ID"]);


                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateTermsAndCondition", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", TermAndConditionID);
                cmd.Parameters.AddWithValue("@TermsAndCondition", txtTermsAndCondition.Text);
                cmd.Parameters.AddWithValue("@Note", txtNote.Text);
                cmd.Parameters.AddWithValue("@Paragraph1", txtParagraph1.Text);
                cmd.Parameters.AddWithValue("@Paragraph2", txtParagraph2.Text);
                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Terms and Condition Updated Successfully!";
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Terms and Condition Not Updated Yet!";
                }
                GridViewTermAndCondition.EditIndex = -1;
                ViewTermAndCondition();
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

        protected void GridViewTermAndCondition_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridViewTermAndCondition.EditIndex = -1;
                ViewTermAndCondition();
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

        //------------------------------------------------------------------------------------
        // Official Document Fields
        //------------------------------------------------------------------------------------
        protected void GridField_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string itemName = e.Row.Cells[1].Text;
                foreach (LinkButton button in e.Row.Cells[6].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + itemName + "?')){ return false; };";
                    }
                }
            }
        }

        protected void GridField_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridField.EditIndex = e.NewEditIndex;
                GetDocFieldDetails();
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

        protected void GridField_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                Label ID = GridField.Rows[e.RowIndex].FindControl("lblID") as Label;
                TextBox txtField = GridField.Rows[e.RowIndex].FindControl("txtField") as TextBox;
                TextBox txtDesc = GridField.Rows[e.RowIndex].FindControl("txtDesc") as TextBox;
                int Field_ID = Convert.ToInt32(GridField.DataKeys[e.RowIndex].Values["ID"]);//Datakey

                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateDocField", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", Field_ID);
                    cmd.Parameters.AddWithValue("@DocumentField", txtField.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDesc.Text);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Updateby", UserName);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Official Document Fields Updated Successfully";
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Official Document Fields Not Updated yet!";
                    }

                    GridField.EditIndex = -1;
                    GetDocFieldDetails();
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

        protected void btnsaveDocument_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    UserCon = new SqlConnection(strconnect);
                    UserCommand = new SqlCommand("SP_SaveDocField", UserCon);
                    UserCommand.Connection = UserCon;
                    UserCommand.CommandType = CommandType.StoredProcedure;
                    UserCommand.Parameters.AddWithValue("@DocumentField", txtfield.Text);
                    UserCommand.Parameters.AddWithValue("@Description", txtdisc.Text);
                    UserCommand.Parameters.AddWithValue("@Createby", UserName); //Session value
                    UserCommand.Parameters.AddWithValue("@EmpID", UserId);
                    UserCommand.Parameters.AddWithValue("@Designation", Designation);
                    UserCon.Open();
                    dr = UserCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Official Document Field Save Successfully";
                        GridField.EditIndex = -1;
                        GetDocFieldDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Official Document Field Already Available!";
                    }
                    clearfield();
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

        protected void btnclearDocument_Click(object sender, EventArgs e)
        {
            clearfield();
        }

        protected void GridField_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridField.EditIndex = -1;
                GetDocFieldDetails();
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

        protected void GridField_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection DeviceCon = new SqlConnection(strconnect))
                {
                    int Field_ID = Convert.ToInt32(GridField.DataKeys[e.RowIndex].Values["ID"].ToString());
                    SqlCommand cmd = new SqlCommand("SP_Deletedocfield", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", Field_ID);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@updateby", UserName);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Official Document Fields Delete Successfully";
                        GridField.EditIndex = -1;
                        GetDocFieldDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Official Document Fields Not Delete yet!";
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

        protected void GridField_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridField.PageIndex = e.NewPageIndex;
                GetDocFieldDetails();
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

        public void clearfield()
        {
            txtfield.Text = string.Empty;
            txtdisc.Text = string.Empty;
        }
        #endregion


    }
}