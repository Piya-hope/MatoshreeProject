using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MatoshreeProject
{
    public partial class EditCareer : System.Web.UI.Page
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
        string UserName, EmailID, Designation, RoleType, Permission, DeptID, CareerID;

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
        public void Clear()
        {

            txtFirstName.Text = string.Empty;
            txtMiddleNm.Text = string.Empty;
            txtLastNm.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtCurrentLoc.Text = string.Empty;
            txtExperience.Text = string.Empty;
            txtQualification.Text = string.Empty;
            txtPostApplied.Text = string.Empty;
            txtEmployeement.Text = string.Empty;



        }

        public void GetCareerDataByID()
        {
            try
            {
                CareerID = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                lblID.Text = CareerID;
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetCareerDetailsByID", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@id", lblID.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                    txtMiddleNm.Text = dt.Rows[0]["MiddleName"].ToString();
                    txtLastNm.Text = dt.Rows[0]["LastName"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtPhone.Text = dt.Rows[0]["MobileNumber"].ToString();
                    txtCurrentLoc.Text = dt.Rows[0]["CurrentLocation"].ToString();
                    txtExperience.Text = dt.Rows[0]["Experience"].ToString();
                    txtQualification.Text = dt.Rows[0]["Qualification"].ToString();
                    txtEmployeement.Text = dt.Rows[0]["CurrentEmployer"].ToString();
                    txtPostApplied.Text = dt.Rows[0]["AppliedPost"].ToString();
                    //txtPostApplied.Text = dt.Rows[0]["AppliedPost"].ToString();
                    // GetCareerDataByID1(CareerID);
                    // Handling Resume
                    //if (row["Resume"] != DBNull.Value)
                    //{
                    //    byte[] resumeBytes = (byte[])row["Resume"];
                    //    string resumeBase64 = Convert.ToBase64String(resumeBytes);
                    //    string resumeUrl = "data:application/pdf;base64," + resumeBase64;
                    //    hlResume.NavigateUrl = resumeUrl;
                    //    hlResume.Text = "Download Resume";
                    //    hlResume.Visible = true;
                    //}
                    //else
                    //{
                    //    hlResume.Visible = false;
                    //}

                    // Handling Resume
                    //if (row["Resume"] != DBNull.Value)
                    //{
                    //    Btn_Upload.Visible = true;
                    //}
                    //else
                    //{
                    //    Btn_Upload.Visible = false;
                    //}
                    // filepath = dt.Rows[0]["profile_image"].ToString();
                    //lblAttachment.Text = dt.Rows[0]["Resume"].ToString();

                    // Retrieve and display the file path
                    //string filePath = dt.Rows[0]["ResumeFilePath"].ToString();
                    //if (!string.IsNullOrEmpty(filePath))
                    //{
                    //    hlResume.NavigateUrl = filePath;
                    //    hlResume.Text = "Download Resume";
                    //    hlResume.Visible = true;
                    //}
                    //else
                    //{
                    //    hlResume.Visible = false;
                    //}
                    //sendMail = dt.Rows[0]["SendMail"].ToString();
                    //if (sendMail == "True")
                    //{
                    //    ChBoxSendMail.Checked = true;
                    //}
                    //else
                    //{
                    //    ChBoxSendMail.Checked = false;
                    //}
                    //Status = dt.Rows[0]["Status"].ToString();
                    //if (Status == "True")
                    //{
                    //    RadioButtonListCustomer.SelectedValue = "1";
                    //}
                    //else
                    //{
                    //    RadioButtonListCustomer.SelectedValue = "0";
                    //}
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
                            GetCareerDataByID();
                         
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
                                GetCareerDataByID();
                           
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UpdateCarrier", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", lblID.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@MiddleName", txtMiddleNm.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastNm.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@MobileNumber", txtPhone.Text);
                cmd.Parameters.AddWithValue("@CurrentLocation", txtCurrentLoc.Text);
                cmd.Parameters.AddWithValue("@Experience", txtExperience.Text);
                cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text);
                cmd.Parameters.AddWithValue("@AppliedPost", txtPostApplied.Text);
                cmd.Parameters.AddWithValue("@CurrentEmployer", txtEmployeement.Text);
                cmd.Parameters.AddWithValue("@Approval", "True");
                cmd.Parameters.AddWithValue("@ApprovalBy", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@Updateby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con.Open();
                int Result = cmd.ExecuteNonQuery();
                if (Result < 0)
                {
                    string edit = "xcvfedit";
                    Response.Redirect("~/career.aspx?edit1=" + edit + "", false);
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('career Details Edit Successfully!')", true);
                  
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Career Details Not Edit Successfully";
                    
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/career.aspx", true);
        }

        protected void Btn_Upload_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}