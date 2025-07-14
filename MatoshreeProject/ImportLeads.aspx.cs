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
//using iText.Kernel.Pdf;
using System.IO.MemoryMappedFiles;
using System.Reflection;
using System.Dynamic;
using Color = System.Drawing.Color;
using System.Data.OleDb;

#endregion
namespace MatoshreeProject
{
    public partial class ImportLeads : System.Web.UI.Page
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
        int StaffId;
        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        string DevEmail, DevPassword, DevPort, DevHost;
        string Name, Company, Phone, LeadValue, AssignedName, StatusName, SourceName, Status, YearDifference, Role, Address, Position, Website, DefaultLanguage;
        int Id;
        System.DateTime ContactDate;
        int FinalCount = 0;
        string previousStaffID = string.Empty;
        string UserEmpName, Password, EmailID1, Designation1;
        string staffID, StaffName, Email, Remark;
        string Day = Convert.ToString(System.DateTime.Today.Day);
        string year = Convert.ToString(System.DateTime.Today.Year);
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

        #region " Private Functions 
        #endregion

        #region " Protected Functions "
        #endregion

        #region " Public Functions "
        public void SaveActivity()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_SaveImportActivityLeadDetails", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                    Result = int.Parse(result);
                    if (Result > 0)
                    {
                        //SaveActivity();
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Item Details Save Successfully!')", true);
                    }
                    else
                    {
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Item Details Not Save Successfully!')", true);
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
        public void Clear()
        {
            txtPassword.Text = string.Empty;
        }
            #endregion

            #region " Event "
            protected void Page_Load(object sender, EventArgs e)
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
                        GetLeadData();
                        //GetCompanyAddress();

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
                             GetLeadData();
                           //  StaffOperationPermission();
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
        public DataTable GetLeadData()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[]
            {
              new DataColumn("Id"),
              new DataColumn("Name"),
              new DataColumn("Address"),
               new DataColumn("Role"),
                 new DataColumn("City"),
              new DataColumn("Email"),
              new DataColumn("Website"),
              new DataColumn("Phone"),
              new DataColumn("LeadValue"),
              new DataColumn("DefaultLanguage"),
              new DataColumn("Company"),
              new DataColumn("SourceName"),
              new DataColumn("AssignedName"),
               new DataColumn("ContactDate")
           });

            dt.Rows.Add("1", "Sample Data", "Sample Data", "Sample Data", "Sample Data",  "Sample Data", "Sample Data", "Sample Data", "Sample Data", "Sample Data", "Sample Data", "Sample Data", "Sample Data", "Sample Data");

            GridImportLeads.DataSource = dt;
            GridImportLeads.DataBind();
            return dt;
        }

        public void GetStaffIDDetails(string Email)
        {
            try
            {
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetStaffIdByStaffEmail", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblStaffId.Text = dt.Rows[0]["Staff_ID"].ToString();
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
            finally
            {
            }
        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {

        }
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";
                string FileName = "Sample_Import_Lead" + ".xlsx";
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                GridImportLeads.GridLines = GridLines.Both;
                GridImportLeads.HeaderStyle.Font.Bold = true;
                GridImportLeads.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                using (SqlConnection DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
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

        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                UserId = Convert.ToInt32(Session["UserID"]);

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetStaffPasswordbyUserID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", UserId);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblPassword.Text = dt.Rows[0]["Password"].ToString();
                    }
                }
                if (lblPassword.Text == txtPassword.Text)
                {
                    if (FileUpload.PostedFile != null)
                    {
                        string FileName = FileUpload.FileName;
                        string FilemyString = FileName.Substring(0, FileName.Length - 5);
                        string Extension = Path.GetExtension(FileUpload.PostedFile.FileName);
                        if (Extension == ".xlsx")
                        {

                            if (FilemyString == "Sample_Import_Lead")
                            {
                                string excelPath = Server.MapPath("~/Leads_Import_Files/") + Path.GetFileName(FileUpload.PostedFile.FileName);
                                FileUpload.SaveAs(excelPath);
                                string conString = string.Empty;
                                string extension = Path.GetExtension(FileUpload.PostedFile.FileName);
                               
                                switch (extension)
                                {
                                    case ".xls": //Excel 97-03DBConnection

                                        conString = ConfigurationManager.ConnectionStrings["Excel03+ConString"].ConnectionString;
                                        break;
                                    case ".xlsx": //Excel 07 or higher
                                        conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                                        break;

                                }
                                conString = string.Format(conString, excelPath);
                            //    using (OleDbConnection excel_con = new OleDbConnection(conString))
                            //    {
                            //        excel_con.Open();
                            //        string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                            //        DataTable dtExcelData = new DataTable();
                            //        //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.  ID
                            //        dtExcelData.Columns.AddRange(new DataColumn[5] {new DataColumn("ID", typeof(int)),new DataColumn("DEVICE", typeof(string)),
                            //new DataColumn("MOBILENO", typeof(string)) ,new DataColumn("CPAName", typeof(string)), new DataColumn("ADDRESS", typeof(string))});
                                //    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID,DEVICE,MOBILENO,CPAName,ADDRESS FROM [" + sheet1 + "]", excel_con))
                                //    {
                                //        oda.Fill(dtExcelData);
                                //        GridView1.DataSource = dtExcelData;
                                //        GridView1.DataBind();
                                //    }
                                //    excel_con.Close();
                                //    if (dtExcelData.Rows.Count > 0)
                                //    {
                                //    }
                                //}
                                using (OleDbConnection excel_con = new OleDbConnection(conString))
                                {
                                    excel_con.Open();
                                    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                                    DataTable dtExcelData = new DataTable();
                                    dtExcelData.Columns.AddRange(new DataColumn[14] {new DataColumn("Id", typeof(int)),new DataColumn("Name", typeof(string)),  new DataColumn("Address", typeof(string)),
                                                 new DataColumn("Role", typeof(string)),new DataColumn("City", typeof(string)),new DataColumn("Email", typeof(string))  ,new DataColumn("Website", typeof(string)),new DataColumn("Phone", typeof(string)),new DataColumn("LeadValue", typeof(string)),
                                                        new DataColumn("DefaultLanguage", typeof(string)), new DataColumn("Company", typeof(string)), new DataColumn("SourceName", typeof(string)),new DataColumn("AssignedName", typeof(string))
                                                        , new DataColumn("ContactDate", typeof(System.DateTime))
                                });

                                    //using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT Id,Name,Address,Role,Email,Website,Phone,LeadValue,DefaultLanguage,Company,SourceName,AssignedName,ContactDate FROM [" + sheet1 + "]", excel_con))
                                    //{
                                    //    oda.Fill(dtExcelData);
                                    //    //GridImportLeads.DataSource = dtExcelData;
                                    //    //GridImportLeads.DataBind();

                                    //}
                                    //excel_con.Close();
                                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", excel_con))
                                    {
                                        oda.Fill(dtExcelData);

                                    }
                                    excel_con.Close();

                                    if (dtExcelData.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dtExcelData.Rows.Count; i++)
                                        {
                                            //Id = Convert.ToInt32(dtExcelData.Rows[i]["Id"]);
                                            Name = dtExcelData.Rows[i]["Name"].ToString();
                                            Address = dtExcelData.Rows[i]["Address"].ToString(); 
                                            Role = dtExcelData.Rows[i]["Role"].ToString();
                                          string  City = dtExcelData.Rows[i]["City"].ToString();
                                            Email = dtExcelData.Rows[i]["Email"].ToString();
                                            Website = dtExcelData.Rows[i]["Website"].ToString();
                                            Phone = dtExcelData.Rows[i]["Phone"].ToString();
                                            LeadValue = dtExcelData.Rows[i]["LeadValue"].ToString();
                                            DefaultLanguage = dtExcelData.Rows[i]["DefaultLanguage"].ToString();
                                            Company = dtExcelData.Rows[i]["Company"].ToString();
                                            SourceName = dtExcelData.Rows[i]["SourceName"].ToString();
                                            AssignedName = dtExcelData.Rows[i]["AssignedName"].ToString();
                                           ContactDate = Convert.ToDateTime(dtExcelData.Rows[i]["ContactDate"]);

                                            GetStaffIDDetails(Email);
                                            using (SqlConnection con1 = new SqlConnection(strconnect))
                                            {
                                                SqlCommand cmd = new SqlCommand("SP_SaveImportLeadsDetails", con1);
                                                cmd.CommandType = CommandType.StoredProcedure;
                                                //cmd.Parameters.AddWithValue("@Id", Id);
                                                cmd.Parameters.AddWithValue("@Name", Name);
                                                cmd.Parameters.AddWithValue("@Address", Address);
                                                cmd.Parameters.AddWithValue("@Position", Role);
                                                cmd.Parameters.AddWithValue("@City", City);
                                                cmd.Parameters.AddWithValue("@Email", Email);
                                                cmd.Parameters.AddWithValue("@Website", Website); 
                                                cmd.Parameters.AddWithValue("@Phone", Phone);
                                                cmd.Parameters.AddWithValue("@LeadValue", LeadValue);
                                                cmd.Parameters.AddWithValue("@DefaultLanguage", DefaultLanguage);
                                                cmd.Parameters.AddWithValue("@Company", Company);
                                                cmd.Parameters.AddWithValue("@SourceName", SourceName);
                                                cmd.Parameters.AddWithValue("@AssignedName", AssignedName);
                                                cmd.Parameters.AddWithValue("@ContactDate", ContactDate);
                                                cmd.Parameters.AddWithValue("@CreateBy", UserName);
                                                cmd.Parameters.AddWithValue("@EmpID", UserId);
                                               
  
                                                con1.Open();
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
                                                    lblMesDelete.Text = "Import Leads Details Save Successfully!";

                                                }
                                                else
                                                {
                                                    Toasteralert.Visible = false;
                                                    deleteToaster.Visible = true;
                                                    lblMesDelete.Text = "Import Leads Details Not Save Successfully!";

                                                }
                                            }

                                        }
                                        SaveActivity();
                                    }
                                }
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Does not Match FileName";
                            }
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Does not Match File Extension";
                        }

                    }
                   // Clear();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Password do not match";
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
            finally
            {
            }
        }

        #endregion
    }
}