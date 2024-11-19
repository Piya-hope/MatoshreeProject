#region " Class Description "


#endregion

#region " Primary Namespaces "

using System;
using System.Web.UI.WebControls;

#endregion

#region " Additional Namespaces "

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Contracts;
using System.Web;

#endregion

namespace MatoshreeProject
{
    public partial class renewContract : System.Web.UI.Page
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
        string  isExpired, Partner, RenewContractExpired;
       
        int UserId;
        string UserName,Designation,EmailID, RoleType, Permission, DeptID;


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

        #region " Protected Functions "


        #endregion

        #region " Public Functions "



        #endregion

        public void ClearAll()
        {
             txtOldStartDate.Text = string.Empty;
            txtNewStartDate.Text = string.Empty;
            txtOldEndDate.Text = string.Empty;
            txtNewEndDate.Text = string.Empty;
            txtOldContractValue.Text = string.Empty;
            txtNewContractValue.Text = string.Empty;
            UserName = string.Empty;
            isExpired = string.Empty;
            Partner = string.Empty;


        }


        public void GetrenewContractrByID()
        {
            try
            {

              string   Contractid = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                lblContractRenewID.Text = Contractid;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetrenewContractByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@ID", lblContractRenewID.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtOldStartDate.Text = dt.Rows[0]["datestart"].ToString();
                        txtOldEndDate.Text = dt.Rows[0]["dateend"].ToString();
                        txtOldContractValue.Text = dt.Rows[0]["contract_value"].ToString();
                        RenewContractExpired = dt.Rows[0]["is_expiry_notified"].ToString();

                    }

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

                            GetrenewContractrByID();
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
                                GetrenewContractrByID();
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

        protected void btnRenewSaveContract_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    DateTime OldStartDate = Convert.ToDateTime(txtOldStartDate.Text).Date;
                    DateTime OldEndDate = Convert.ToDateTime(txtOldEndDate.Text).Date;
                    DateTime Today = DateTime.Now.Date;
                    if (OldEndDate.Date > OldStartDate.Date && OldStartDate.Date == Today)
                    {
                        RenewContractExpired = "False";//contract valid not exipred
                    }
                    else if (OldEndDate.Date == Today)
                    {
                        RenewContractExpired = "true";//renew exipred
                    }
                    else
                    {
                        RenewContractExpired = "true";//endate currendate past date
                    }


                    DateTime NewStartDate = Convert.ToDateTime(txtNewStartDate.Text).Date;
                    DateTime NewEndDate = Convert.ToDateTime(txtNewEndDate.Text).Date;
                   
                    if (NewEndDate.Date > NewStartDate.Date && RenewContractExpired == "true" || NewStartDate.Date == Today && RenewContractExpired == "true")
                    {
                        using (SqlConnection con = new SqlConnection(strconnect))
                        {
                         

                            SqlCommand cmd = new SqlCommand("SP_SaveRenewalcontractDetails", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@old_start_date", OldStartDate);
                            cmd.Parameters.AddWithValue("@new_start_date", NewStartDate);
                            cmd.Parameters.AddWithValue("@old_end_date", OldEndDate);
                            cmd.Parameters.AddWithValue("@new_end_date", NewEndDate);
                            cmd.Parameters.AddWithValue("@old_value", txtOldContractValue.Text);
                            cmd.Parameters.AddWithValue("@new_value", txtNewContractValue.Text);
                            cmd.Parameters.AddWithValue("@renewed_by", UserName);
                            cmd.Parameters.AddWithValue("@contract_id", lblContractRenewID.Text);
                            cmd.Parameters.AddWithValue("@is_on_old_expiry_notified", RenewContractExpired);
                            cmd.Parameters.AddWithValue("@renewContractFor", "Partner");
                            cmd.Parameters.AddWithValue("@UserID", UserId);
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
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('ReNew Contract Details Successfully!')", true);
                            }
                            else
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('ReNew Contract Details Already Available!')", true);
                            }
                            ClearAll();
                        }
                    }
                    else if (NewEndDate.Date == Today)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Check End date Renew Contract !')", true);

                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Check Date Renew Contract !')", true);

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
        }

        protected void btnCloseContract_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Contract_Contact.aspx");
        }
    }
}