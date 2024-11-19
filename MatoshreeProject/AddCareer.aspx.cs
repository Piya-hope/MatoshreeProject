using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MatoshreeProject
{
    public partial class AddCareer : System.Web.UI.Page
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
                            //ViewCustomerDetails();
                            //CustomerCount();
                            //CustomerDetailReport();
                            //GetCompanyAddress();
                            //GetMessageFromModules();
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
                                //StaffOperationPermission();
                                //GetMessageFromModules();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Stream fs = FileUpload.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);


                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_SaveCarrier", con);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@MiddleName", txtMiddleNm.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastNm.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@MobileNumber", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@CurrentLocation", txtCurrentLoc.Text);
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text);
                    cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text);
                    cmd.Parameters.AddWithValue("@AppliedPost", txtPostApplied.Text);
                    cmd.Parameters.AddWithValue("@Resume", bytes);
                    cmd.Parameters.AddWithValue("@CurrentEmployer", txtEmployeement.Text);
                    cmd.Parameters.AddWithValue("@Approval", "True");
                    cmd.Parameters.AddWithValue("@ApprovalBy", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@CreateBy", UserName); //Session value
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
                        string save = "fgsave123q";
                        Response.Redirect("~/career.aspx?svd1=" + save + "", false);

                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "career Details already Available";

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
                finally { }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void Btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {



                if (FileUpload.PostedFile == null )
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Career Not In Draft!')", true);
                }
                else
                {
                    if (FileUpload.PostedFile.FileName.Length > 1)
                    {
                        string uploadDirectory = Server.MapPath("~/Career_File/");

                        if (!Directory.Exists(uploadDirectory))
                        {
                            Directory.CreateDirectory(uploadDirectory);
                        }
                        string fileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
                        string filePath = System.IO.Path.Combine(uploadDirectory, fileName);
                        string extention = System.IO.Path.GetExtension(FileUpload.PostedFile.FileName);


                        FileUpload.PostedFile.SaveAs(filePath);
                        string contenttype = String.Empty;
                        switch (extention.ToLower())
                        {
                            case ".doc":
                                contenttype = "application/vnd.ms-word";
                                break;
                            case ".docx":
                                contenttype = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;
                            case ".xls":
                                contenttype = "application/vnd.ms-excel";
                                break;
                            case ".xlsx":
                                contenttype = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                break;
                            case ".jpg":
                                contenttype = "image/jpg";
                                break;
                            case ".png":
                                contenttype = "image/png";
                                break;
                            case ".gif":
                                contenttype = "image/gif";
                                break;
                            case ".pdf":
                                contenttype = "application/pdf";
                                break;
                        }

                        if (contenttype != String.Empty)
                        {
                            Stream fs = FileUpload.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            using (SqlConnection con = new SqlConnection(strconnect))
                            {
                                SqlCommand cmd = new SqlCommand("SP_UploadCareerAttachmentFile", con);
                                cmd.Connection = con;

                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@FileName", fileName);
                               // cmd.Parameters.AddWithValue("@Extention", extention);
                                cmd.Parameters.AddWithValue("@FilePath", filePath);
                                cmd.Parameters.AddWithValue("@Resume", bytes);
                                cmd.Parameters.AddWithValue("@EmpID", UserId);
                                cmd.Parameters.AddWithValue("@Designation", Designation);
                                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                                //cmd.Parameters.AddWithValue("@UniqueNo", lblInitialNumber.Text);
                                //cmd.Parameters.AddWithValue("@ContentType", contenttype);
                                //cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                int i = cmd.ExecuteNonQuery();
                                if (i < 0)
                                {
                                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Leave Request File Uploaded Successfully!')", true);
                                    //ViewFileRequestDetails();

                                }
                                else
                                {
                                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Leave Request File  Uploaded Successfully!')", true);
                                }

                            }
                        }
                    }
                    else
                    {
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Choose File For Uploaded!')", true);
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
        #endregion
    }
}