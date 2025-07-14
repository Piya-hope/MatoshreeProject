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
using iTextSharp.text;
#endregion

namespace MatoshreeProject
{
    public partial class EditSalaryStructure : System.Web.UI.Page
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
        string  UserName , EmailID, Designation , RoleType, Permission, DeptID;

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


        #endregion

        #region " Protected Functions "


        #endregion

        #region " Public Functions "
        public void BindSubCategory()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetAnnualSalarySubCategory", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlSubcategory.DataSource = ds.Tables[0];
                    ddlSubcategory.DataTextField = "Cat_Desc";//Description
                    ddlSubcategory.DataValueField = "ID";
                    ddlSubcategory.DataBind();
                    ddlSubcategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Perticular", "0"));


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

        public void BindCategory()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetSalaryCategory", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlCategory.DataSource = ds.Tables[0];
                    ddlCategory.DataTextField = "Short_Desc";//Description
                    ddlCategory.DataValueField = "ID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Perticular", "0"));


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

        public void GetSalaryDetails()
        {
            try
            {


                //string ProductID = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                //iblID1.Text = ProductID;

                //SqlConnection conn = new SqlConnection(strconnect);
                //SqlCommand cmd = new SqlCommand("SP_GetAnnualsalaryStructure", UserCon);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);

                //cmd.Parameters.AddWithValue("@ID", iblID1.Text);
                //DataTable dt = new DataTable();
                //sda.Fill(dt);
                ID = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                iblID1.Text = ID;
                SqlCommand cmd = new SqlCommand("SP_GetAnnualsalaryStructure", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@ID", iblID1.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    
                    ddlCategory.SelectedItem.Text = dt.Rows[0]["Category"].ToString();
                    txtPercentage.Text = dt.Rows[0]["Percentage"].ToString();

                    ddlPerticularType.SelectedItem.Text = dt.Rows[0]["PerticularType"].ToString();
                    ddlSubcategory.SelectedItem.Value = dt.Rows[0]["Subcategory"].ToString();
                    txtAmount.Text = dt.Rows[0]["Amount"].ToString();

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
            if (!IsPostBack)
            {
                GetSalaryDetails();
                BindCategory();
                BindSubCategory();
            }
        }


        protected void btnUpdateStructure_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateAnnualsalaryStructure", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@ID", iblID1.Text);
                //cmd.Parameters.AddWithValue("@Category", ddlCategory.SelectedItem.Text);
                //cmd.Parameters.AddWithValue("@Percentage", txtPercentage.Text);
                //cmd.Parameters.AddWithValue("@PerticularType", ddlPerticularType.SelectedItem.Text);
                //cmd.Parameters.AddWithValue("@SubCategory", ddlSubcategory.SelectedItem.Text);
                //cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                //cmd.Parameters.AddWithValue("@CreateBy", UserName);
                //cmd.Parameters.AddWithValue("@Designation", Designation);
                //cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@CatID", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@Category", ddlCategory.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@SubCatID", ddlSubcategory.SelectedValue);
                cmd.Parameters.AddWithValue("@SubCategory", ddlSubcategory.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Percentage", txtPercentage.Text);
                cmd.Parameters.AddWithValue("@PerticularID", ddlSubcategory.SelectedValue);
                cmd.Parameters.AddWithValue("@PerticularType", ddlPerticularType.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                cmd.Parameters.AddWithValue("@Created_by", UserName);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@EmpID", UserId);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Updated Successfully!')", true);
                    Response.Redirect("SalaryStructure.aspx", true);
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Details are already Available!')", true);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                // throw ex;
                DeviceCon = new SqlConnection(strconnect);
                string ErrorMessgage = ex.Message;
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
            }
        }





        protected void btnCancelStructure_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalaryStructure.aspx", true);
        }
    }
    #endregion
}