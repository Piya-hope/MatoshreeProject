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

#endregion

namespace MatoshreeProject
{
    public partial class EditStaffTask : System.Web.UI.Page
    {
        #region " Class Level Variable "

        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result, UserId;
        string result, TasklistId;
        string folderPath, folderfile1, Followers;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        string chkPublic, chkBillable, Status;
        string Followers1;
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

        public void BindStaffName()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("[SP_GetStaffName]", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    gvStaffList.DataSource = ds.Tables[0];
                    gvStaffList.DataBind();

                    GridFollower.DataSource = ds.Tables[0];
                    GridFollower.DataBind();

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

        #region " Protected Functions "
        public void Clear()
        {
            txtDescription.Text = string.Empty;
            txt_Subject.Text = string.Empty;
            txt_Start_Date.Text = string.Empty;
            txt_Due_Date.Text = string.Empty;
            txt_Hourly_Rate.Text = string.Empty;
            txtevent1.Text = string.Empty;
            ddl_Priority.SelectedIndex = -1;
            ddl_Reapet_Every.SelectedIndex = -1;
            ddlRelatedCasted.SelectedIndex = -1;
            ddldays1.SelectedIndex = -1;
            file1.Visible = false;
            FileUploadtask.Dispose();
            FileUploadtask.Attributes.Clear();
            FileUploadtask.Visible = false;
            btnUpload.Visible = false;
            lblFileUploadtask.Visible = false;
            lblFileUploadFile1.Visible = false;
          
        }

        #endregion

        #region " Public Functions "
        public void GetRelatedModalNames()
        {
            try
            {
                UserId = Convert.ToInt32(Session["UserID"]);
                UserName = Session["UserName"].ToString();
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetTaskRealtedModule", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlRelatedTo.DataSource = ds.Tables[0];
                    ddlRelatedTo.DataTextField = "TaskModel";
                    ddlRelatedTo.DataValueField = "ID";
                    ddlRelatedTo.DataBind();
                    ddlRelatedTo.Items.Insert(0, new ListItem("Select Related To", "0"));
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
        public void GetTasksDataByID()
        {
            try
            {              
                TasklistId = HttpUtility.UrlDecode(Request.QueryString["task"]);
                lblID.Text = TasklistId;
                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetTaskDetailsByName", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Subject", lblID.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvStaffList.DataSource = dt;
                gvStaffList.DataBind();
                
                if (dt.Rows.Count > 0)
                {
                    //-----------------------follwers--------------------//

                    Followers = dt.Rows[0]["Follower"].ToString();
                    DataTable table = new DataTable();
                    string[] s2 = Followers.Split(',');
                    int cnt = s2.Length;
                    table.Clear();

                    foreach (string s3 in s2)
                    {
                        table.Columns.Add("Followers");
                        table.Rows.Add(s3);
                    }

                    GridFollower.DataSource = table;
                    GridFollower.DataBind();
                   
                    txt_Subject.Text = dt.Rows[0]["Subject"].ToString();
                    txt_Hourly_Rate.Text = dt.Rows[0]["Hourly_Rate"].ToString();
                    txt_Start_Date.Attributes["value"] = DateTime.Parse(dt.Rows[0]["Start_Date"].ToString()).ToString("yyyy-MM-dd");
                    txt_Due_Date.Attributes["value"] = DateTime.Parse(dt.Rows[0]["Due_Date"].ToString()).ToString("yyyy-MM-dd");

                    txtDescription.Text = dt.Rows[0]["Description"].ToString();
                    ddl_Priority.SelectedItem.Text = dt.Rows[0]["Priority"].ToString();

                    ddl_Reapet_Every.SelectedItem.Text = dt.Rows[0]["Reapet_Every"].ToString();
                    string selectedValue = dt.Rows[0]["Reapet_Every"].ToString();
                    if (selectedValue == "Custom")
                    {
                        Lblselect1.Visible = true;
                        txtevent1.Visible = true;
                        txtselectcustom1.Visible = true;
                        ddldays1.Visible = true;
                        txtselectcustom1.Text = dt.Rows[0]["Days"].ToString();
                        ddldays1.Text = dt.Rows[0]["Repeat_Wise"].ToString();
                        txtevent1.Text = dt.Rows[0]["Event"].ToString();
                    }
                    else
                    {
                        txtselectcustom1.Visible = false;
                        ddldays1.Visible = false;
                        Lblselect1.Visible = true;
                        txtevent1.Visible = true;
                        txtevent1.Text = dt.Rows[0]["Event"].ToString();

                    }


                    string fname= dt.Rows[0]["FileName"].ToString();
                    if(fname=="")
                    {
                        file1.Visible = false;
                        FileUploadtask.Visible = false;
                        btnUpload.Visible = false;
                        lblFileUploadFile1.Visible = false;
                        lblFileUploadtask.Visible = false;
                    }
                    else
                    {
                        file1.Visible = true;
                        FileUploadtask.Visible = true;
                        btnUpload.Visible = true;
                        lblFileUploadFile1.Visible = true;
                        lblFileUploadFile1.Text = dt.Rows[0]["FileName"].ToString();
                        lblFileUploadtask.Text = dt.Rows[0]["FilePath"].ToString();
                    }
                    

                    ////---------billable--------------------///
                    chkBillable = dt.Rows[0]["Billable"].ToString();//expensesstatus
                    if (chkBillable == "Billable")
                    {
                        Cbx_Cash.Checked = true;//checkbox
                    }
                    else
                    {
                        Cbx_Cash.Checked = false;
                    }
                    ////---------Public--------------------///
                    chkPublic = dt.Rows[0]["chkPublic"].ToString();
                    if (chkPublic == "Public")
                    {
                        Cbx_Bank.Checked = true;//checkbox
                    }
                    else
                    {
                        Cbx_Bank.Checked = false;
                    }

                    //-------------------expensesstatus---------------//
                    Status = dt.Rows[0]["Status"].ToString();
                    if (Status == "True")
                    {
                        RadioButtonListTask.SelectedValue = "1";
                    }
                    else
                    {
                        RadioButtonListTask.SelectedValue = "0";
                    }
                    GetRelatedModalNames();
                    ddlRelatedTo.SelectedItem.Text = dt.Rows[0]["RelatedTo"].ToString();
                    string RelatedTo = ddlRelatedTo.SelectedItem.Text;
                    GetByRelatedToCast(RelatedTo);
                    ddlRelatedCasted.SelectedItem.Text = dt.Rows[0]["RelatedToCast"].ToString();
                }
            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
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

       public void GetByRelatedToCast( string RelatedTo)
        {
            try
            {

                if (RelatedTo == "Select Related To")
                {
                    ddlRelatedCasted.Items.Insert(0, new ListItem("Nothing Selected", "0"));
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetRelatedToCast", conn);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RelatedTo", RelatedTo);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            ddlRelatedCasted.DataSource = ds.Tables[0];
                            ddlRelatedCasted.DataTextField = "Related";
                            ddlRelatedCasted.DataValueField = "ID";
                            ddlRelatedCasted.DataBind();
                            ddlRelatedCasted.Items.Insert(0, new ListItem("Nothing Selected", "0"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
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
                        DeptID = Session["DeptID"].ToString();

                        if (!IsPostBack)
                        {              
                            GetTasksDataByID();
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

                                GetTasksDataByID();
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
                using (DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
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
                int count = 0; // Initialize count variable
               
                List<string> selectedItems = new List<string>();

                foreach (GridViewRow row in gvStaffList.Rows)
                {
                    CheckBox chk1 = (CheckBox)gvStaffList.Rows[row.RowIndex].FindControl("chkRows");
                    if (chk1.Checked == true & chk1 != null)
                    {
                        count++;
                    }
                }

                if (count > 0)
                {
                    foreach (GridViewRow gvrow in gvStaffList.Rows)
                    {
                        CheckBox chk = (CheckBox)gvrow.FindControl("chkRows");
                        Label lblStaff1 = (Label)gvrow.FindControl("lblStaff");
                        if (chk != null & chk.Checked == true)
                        {

                            if (Cbx_Bank.Checked == true)
                            {
                                chkPublic = Cbx_Bank.Text;
                            }
                            else
                            {
                                chkPublic = "NOT Public";
                            }

                            if (Cbx_Cash.Checked == true)
                            {
                                chkBillable = Cbx_Cash.Text;
                            }
                            else
                            {
                                chkBillable = "NOT Billable";
                            }

                            SqlConnection con = new SqlConnection(strconnect);  // db connect
                            SqlCommand cmd = new SqlCommand("SP_UpdateTaskStaff", con);
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Billable", chkBillable);
                            cmd.Parameters.AddWithValue("@chkPublic", chkPublic);
                            cmd.Parameters.AddWithValue("@Subject", txt_Subject.Text);
                            cmd.Parameters.AddWithValue("@Hourly_Rate", txt_Hourly_Rate.Text);
                            cmd.Parameters.AddWithValue("@Start_Date", txt_Start_Date.Text);
                            cmd.Parameters.AddWithValue("@Due_Date", txt_Due_Date.Text);
                            cmd.Parameters.AddWithValue("@Priority", ddl_Priority.SelectedItem.Text);
                            cmd.Parameters.AddWithValue("@Reapet_Every", ddl_Reapet_Every.SelectedItem.Text);

                            if (ddlRelatedTo.SelectedItem.Text == "Select Related To")
                            {
                                string stringnull1 = "Nothing";
                                cmd.Parameters.AddWithValue("@Reletd_To", stringnull1);//related to Nothing
                                cmd.Parameters.AddWithValue("@RelatedToCast", stringnull1);//related to Nothing
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@Reletd_To", ddlRelatedTo.SelectedItem.Text);//related to name
                                cmd.Parameters.AddWithValue("@RelatedToCast", ddlRelatedCasted.SelectedItem.Text);//related to cast
                            }
                            cmd.Parameters.AddWithValue("@TaskStatus", "In Progress");//related to Task status
                            cmd.Parameters.AddWithValue("@AssignTo", lblStaff1.Text);// Staffname                           
                            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                            cmd.Parameters.AddWithValue("@Updateby", UserName);
                            cmd.Parameters.AddWithValue("@Days", txtselectcustom1.Text);
                            cmd.Parameters.AddWithValue("@Repeat_Wise", ddldays1.SelectedItem.Text);
                            cmd.Parameters.AddWithValue("@Event", txtevent1.Text);
                            cmd.Parameters.AddWithValue("@TaskRegards", "Staff Task");
                            Followers1 = null;
                            foreach (GridViewRow gvrow1 in GridFollower.Rows)
                            {
                                CheckBox chk1F = (CheckBox)gvrow1.FindControl("chkRows");
                                //Label lblStaff1F = (Label)gvrow1.FindControl("lblStaff1");
                                //string staffg = lblStaff1F.Text;

                                if (chk1F.Checked == true & chk1F != null)
                                {
                                    Label lblStaff1F = (Label)gvrow1.FindControl("lblStaff1");
                                    string staffg = lblStaff1F.Text;

                                    selectedItems.Add(staffg);
                                    Followers1 = string.Join(",", selectedItems);

                                }
                            }
                            cmd.Parameters.AddWithValue("@Status", RadioButtonListTask.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@Follower", Followers1);
                            cmd.Parameters.AddWithValue("@FilePath", lblFileUploadtask.Text);
                            cmd.Parameters.AddWithValue("@FileName", lblFileUploadFile1.Text);
                            cmd.Parameters.AddWithValue("@EmpID", UserId);
                            cmd.Parameters.AddWithValue("@Designation", Designation);
                            con.Open();
                            int Result = cmd.ExecuteNonQuery();
                            con.Close();
                            if (Result < 0)
                            {
                                string task = txt_Subject.Text;
                                string edit = "xcvfedit";
                                Response.Redirect("~/Schedule_Task.aspx?task=" + task + "&edit1" + edit, false);
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Task Details Not Update Successfully";
                        
                            }
                        }
                    }//foreach end
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Select Staff Member to Assign Task!')", true);
                }
               
            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                Response.Redirect("~/TaskDetailsStaff.aspx", false);
            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
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

        protected void ddl_Reapet_Every_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddl_Reapet_Every.SelectedItem.Text;


            if (selectedValue == "Custom")
            {

                Lblselect1.Visible = true;
                txtselectcustom1.Visible = true;
                ddldays1.Visible = true;
                txtevent1.Visible = true;

            }
            else
            {
                txtselectcustom1.Visible = false;
                ddldays1.Visible = false;
                Lblselect1.Visible = true;
                txtevent1.Visible = true;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                file1.Visible = true;


                if (FileUploadtask.PostedFile.FileName == "")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Upload file!')", true);
                }
                else
                {

                    folderPath = Server.MapPath("~/TaskUpload/");


                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    FileUploadtask.SaveAs(folderPath + Path.GetFileName(FileUploadtask.FileName));
                    folderfile1 = folderPath;
                    lblFileUploadtask.Text = folderfile1;
                    lblFileUploadFile1.Text = FileUploadtask.FileName;
                }
            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
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

        protected void linkAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                file1.Visible = true;
                FileUploadtask.Visible = true;
                btnUpload.Visible = true;
                lblFileUploadFile1.Visible = true;

            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
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

        protected void ddlRelatedTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string RelatedTo = ddlRelatedTo.SelectedItem.Text;
                string RelatedToID = ddlRelatedTo.SelectedItem.Value;

                if (RelatedTo == "Select Related To")
                {
                    ddlRelatedCasted.Items.Insert(0, new ListItem("Nothing Selected", "0"));
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetRelatedToCast", conn);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RelatedTo", RelatedTo);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            ddlRelatedCasted.DataSource = ds.Tables[0];
                            ddlRelatedCasted.DataTextField = "Related";
                            ddlRelatedCasted.DataValueField = "ID";
                            ddlRelatedCasted.DataBind();
                            ddlRelatedCasted.Items.Insert(0, new ListItem("Nothing Selected", "0"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
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

        protected void ddlRelatedCasted_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string RelatedTo = ddlRelatedTo.SelectedItem.Text;
                string RelatedCasted = ddlRelatedCasted.SelectedItem.Value;
                if (RelatedTo == "Project")
                {
                    using (SqlConnection conn = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetProjectMemeberbyID", conn);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProjectID", RelatedCasted);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            gvStaffList.DataSource = ds.Tables[0];
                            gvStaffList.DataBind();
                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
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

        protected void GridFollower_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow GridFollowerli in GridFollower.Rows)
            {
                CheckBox chk1f = (CheckBox)GridFollowerli.FindControl("chkRows");
                Label lblStaff1f = (Label)GridFollowerli.FindControl("lblStaff1");
                if (lblStaff1f.Text == "")
                {
                    chk1f.Checked = false;
                }
                else
                {
                    chk1f.Checked = true;
                }
            }
        }

        protected void gvStaffList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow gridviedrow in gvStaffList.Rows)
            {

                CheckBox chk = (CheckBox)gridviedrow.FindControl("chkRows");
                Label lblStaff1 = (Label)gridviedrow.FindControl("lblStaff");
                

                if(lblStaff1.Text == "")
                {
                    chk.Checked = false;
                }
                else
                {
                    chk.Checked = true;
                }
            }
        }

        //-----------------------------------------------------------------------------------
        // Save Modal Popup
        //---------------------------------------------------------------------
        protected void btnsaveModel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        // db connect
                        SqlCommand cmd = new SqlCommand("SP_SaveTaskModel", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TaskModel", txtRelatedModel.Text);
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
                            lblMesDelete.Text = "Task Related To Added Successfully";
                            txtRelatedModel.Text = string.Empty;
                            GetRelatedModalNames();
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Task Related To NOT Added Yet!!!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
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