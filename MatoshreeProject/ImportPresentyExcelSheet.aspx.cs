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
using System.IO.MemoryMappedFiles;
using System.Reflection;
using System.Dynamic;
using Color = System.Drawing.Color;

using System.Data.OleDb;



#endregion


namespace MatoshreeProject
{
    public partial class ImportPresentyExcelSheet : System.Web.UI.Page
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
        int UserId; int StaffId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        string DevEmail, DevPassword, DevPort, DevHost;
        int FinalCount = 0;
        string previousStaffID = string.Empty;
        string UserEmpName, Password, EmailID1, Designation1;
        int ID, TotalHRS, LateTime; string staffID,StaffName, Email, Remark; DateTime InTime, OutTime;
        string Size, Initial, ReceiptFor, Cash, Bank, reminder, Leaveid;
        string Day = Convert.ToString(DateTime.Today.Day);
        string year = Convert.ToString(DateTime.Today.Year);
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
            txtPassword.Text = string.Empty;
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
        public void GetShiftDetails(string Staffid)
        {
            try
            {
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetShiftDetailsByStaffID", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", Staffid);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblshiftstaffid.Text = dt.Rows[0]["Staff_ID"].ToString();
                    lblNameShift11.Text = dt.Rows[0]["ShiftName"].ToString();
                    lblShiftID.Text = dt.Rows[0]["ID"].ToString();
                    lblshiftHours.Text = dt.Rows[0]["Hours"].ToString();

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
       
        public void GetMarkDetails(string ReMark)
        {
            try
            {
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetLeaveMarksDetailsByMarkName", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MarkName", ReMark);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblLeabveMarkID.Text = dt.Rows[0]["ID"].ToString();
                    lblMarkName.Text = dt.Rows[0]["MarkName"].ToString();
                    lblMarkCount.Text = dt.Rows[0]["MarkCount"].ToString();
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
                    command.Parameters.AddWithValue("@SubModule", "CUSTOMERS");
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
                            GetData();
                            // GetCompanyAddress();

                            //if (Create == "True")
                            //{
                            //    addnew.Visible = true;
                            //    btnNewCustomer.Visible = true;
                            //}
                            //else
                            //{
                            //    addnew.Visible = false;
                            //    btnNewCustomer.Visible = false;
                            //}

                            //if (Edit == "True")
                            //{

                            //    GridCustomer.Columns[8].Visible = true;
                            //}
                            //else
                            //{

                            //    GridCustomer.Columns[8].Visible = false;
                            //}

                            //if (Delete == "True")
                            //{

                            //    GridCustomer.Columns[9].Visible = true;
                            //}
                            //else
                            //{

                            //    GridCustomer.Columns[9].Visible = false;
                            //}
                        }
                        else if (View == "True")
                        {
                            GetData();

                            //    GetCompanyAddress();

                            //    if (Create == "True")
                            //    {
                            //        addnew.Visible = true;
                            //        btnNewCustomer.Visible = true;
                            //    }
                            //    else
                            //    {
                            //        addnew.Visible = false;
                            //        btnNewCustomer.Visible = false;
                            //    }

                            //    if (Edit == "True")
                            //    {

                            //        GridCustomer.Columns[8].Visible = true;
                            //    }
                            //    else
                            //    {

                            //        GridCustomer.Columns[8].Visible = false;
                            //    }

                            //    if (Delete == "True")
                            //    {

                            //        GridCustomer.Columns[9].Visible = true;
                            //    }
                            //    else
                            //    {

                            //        GridCustomer.Columns[9].Visible = false;
                            //    }

                            //}
                            //else
                            //{
                            //    Response.Redirect("~/permission.html", true);
                            //}

                        }
                        else
                        {

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
        public void SaveActivity()
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_SaveImportActivity", con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Createby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                con1.Open();
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
                            GetData();
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
                SqlConnection UserCon = new SqlConnection(strconnect);

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
        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[]
            {
              new DataColumn("ID"),
              new DataColumn("StaffName"),
              new DataColumn("Email"),
              new DataColumn("InTime"),
              new DataColumn("OutTime"),
              new DataColumn("LateTime"),
              new DataColumn("TotalHRS"),
              new DataColumn("Remark")
           });

            dt.Rows.Add("1", "Sample Data", "Sample Data", "Sample Data", "Sample Data", "Sample Data", "Sample Data", "Sample Data");

            GridLeaveAnalysis.DataSource = dt;
            GridLeaveAnalysis.DataBind();
            return dt;
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
                string FileName = "Sample_Import_Attendance" + ".xlsx";
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                GridLeaveAnalysis.GridLines = GridLines.Both;
                GridLeaveAnalysis.HeaderStyle.Font.Bold = true;
                GridLeaveAnalysis.RenderControl(htmltextwrtter);
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

                            if (FilemyString == "Sample_Import_Attendance")
                            {
                                string excelPath = Server.MapPath("~/Presenty_Import_File/") + Path.GetFileName(FileUpload.PostedFile.FileName);
                                FileUpload.SaveAs(excelPath);
                                string conString = string.Empty;
                                string extension = Path.GetExtension(FileUpload.PostedFile.FileName);
                                string connectionString = ConfigurationManager.ConnectionStrings["MyAccessDatabase"].ConnectionString;
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

                                using (OleDbConnection excel_con = new OleDbConnection(conString))
                                {
                                    excel_con.Open();
                                    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                                    DataTable dtExcelData = new DataTable();

                                    dtExcelData.Columns.AddRange(new DataColumn[] {new DataColumn("ID", typeof(int)),new DataColumn("StaffName", typeof(string)),
                                                 new DataColumn("Email", typeof(string)),new DataColumn("InTime", typeof(DateTime)) ,new DataColumn("OutTime", typeof(DateTime)),new DataColumn("LateTime", typeof(int)),
                                                        new DataColumn("TotalHRS", typeof(int)), new DataColumn("Remark", typeof(string))
                                });

                              using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT ID,StaffName,Email,InTime,OutTime,LateTime,TotalHRS,Remark FROM [Sheet1$]", excel_con))
                                    {
                                        oda.Fill(dtExcelData);

                                    }
                                    excel_con.Close();

                                    if (dtExcelData.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dtExcelData.Rows.Count; i++)
                                        {
                                            ID = Convert.ToInt32(dtExcelData.Rows[i]["ID"]);
                                            StaffName = dtExcelData.Rows[i]["StaffName"].ToString();
                                            Email = dtExcelData.Rows[i]["Email"].ToString();
                                            InTime = Convert.ToDateTime(dtExcelData.Rows[i]["InTime"]);
                                            OutTime = Convert.ToDateTime(dtExcelData.Rows[i]["OutTime"]);
                                            LateTime = Convert.ToInt32(dtExcelData.Rows[i]["LateTime"]);
                                            TotalHRS = Convert.ToInt32(dtExcelData.Rows[i]["TotalHRS"]);
                                            Remark = dtExcelData.Rows[i]["Remark"].ToString();
                                            GetStaffIDDetails(Email);
                                            TimeSpan timeSpan = OutTime - InTime;
                                            int totalHours = (int)timeSpan.TotalHours;
                                            TotalHRS = totalHours;
                                            staffID = lblStaffId.Text;
                                            GetShiftDetails(staffID);
                                            int TotalHours = TotalHRS;
                                            int shiftHours = Convert.ToInt32(lblshiftHours.Text);

                                            if (TotalHRS < shiftHours)
                                            {
                                                LateTime = 1;

                                            }
                                            else
                                            {
                                                LateTime = 0;
                                            }

                                            int lCount = LateTime;

                                            int sID = Convert.ToInt32(staffID);

                                            previousStaffID = staffID;
                                            if (staffID != previousStaffID)
                                            {
                                                FinalCount = 0;
                                                previousStaffID = staffID;
                                            }
                                            TimeSpan INtimeString = InTime.TimeOfDay;
                                            TimeSpan OuttimeString = OutTime.TimeOfDay;
                                            string timeString = "09:30:00";
                                            TimeSpan timeEarly = TimeSpan.Parse(timeString);
                                            string timeString1 = "15:00:00";
                                            TimeSpan timeMid = TimeSpan.Parse(timeString1);
                                            string timeString2 = "18:00:00";
                                            TimeSpan timeAfter = TimeSpan.Parse(timeString2);
                                            if (TotalHours == shiftHours)
                                            {
                                                Remark = "Regulartime";
                                            }
                                            else if (TotalHours > shiftHours)
                                            {
                                                Remark = "Overtime";
                                            }
                                            else
                                            {
                                                Remark = "Late";
                                                GetMarkDetails(Remark);
                                                if (lCount == 1)
                                                {
                                                    FinalCount = FinalCount + lCount;
                                                }
                                                if (FinalCount >= 4)
                                                {
                                                    if (INtimeString > timeEarly)
                                                    {
                                                        Remark = "HalfDay";
                                                    }
                                                    else if (OuttimeString < timeMid)
                                                    {
                                                        Remark = "HalfDay";
                                                    }
                                                    else if ((OuttimeString < timeMid) && (INtimeString > timeEarly))
                                                    {
                                                        Remark = "HalfDay";
                                                    }
                                                    else if ((OuttimeString < timeAfter) && (TotalHours < shiftHours))
                                                    {
                                                        Remark = "Early Leave";
                                                    }
                                                }
                                            }
                                            using (SqlConnection con1 = new SqlConnection(strconnect))
                                            {
                                                SqlCommand cmd = new SqlCommand("SP_SaveImportPresenty", con1);
                                                cmd.CommandType = CommandType.StoredProcedure;
                                                cmd.Parameters.AddWithValue("@StaffName", StaffName);
                                                cmd.Parameters.AddWithValue("@Email", Email);
                                                cmd.Parameters.AddWithValue("@InTime", InTime);
                                                cmd.Parameters.AddWithValue("@OutTime", OutTime);
                                                cmd.Parameters.AddWithValue("@LateTime", LateTime);
                                                cmd.Parameters.AddWithValue("@TotalHRS", TotalHRS);
                                                cmd.Parameters.AddWithValue("@Remark", Remark);
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
                                                    lblMesDelete.Text = "Import Details Save Successfully!";
                                                   
                                                }
                                                else
                                                {
                                                    Toasteralert.Visible = false;
                                                    deleteToaster.Visible = true;
                                                    lblMesDelete.Text = "Import Details Not Save Successfully!";
                                                   
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
                    Clear();
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
    }
    #endregion
}