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

#endregion

namespace MatoshreeProject
{
    public partial class New_ContractVendor : System.Web.UI.Page
    {
        #region " Class Level Variable "

        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result, trash, visible;
        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        List<string> FieldsList = new List<string>();
        int Count = 0;
        Phrase phrase = null;
        #endregion

        #region " Constructor "


        #endregion

        #region " Private Variables "


        #endregion

        #region " Shared Variables "


        #endregion

        #region " Public Variables "
        int  Id;
        #endregion

        #region " Public Properties "


        #endregion

        #region " Private Functions "


        #endregion

        #region " Public Functions "
        public DataTable GetTaskbyModuleWise()
        {
            DataTable table = new DataTable();
            DataColumn dataColumn = new DataColumn();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_ViewTaskModuleVise", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ModuleNAME", txtSubject.Text);
                sqlCommand.Parameters.AddWithValue("@BelongTo", "Contract Vendor");
                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                ad.Fill(table);
                GridTask1.DataSource = table;
                GridTask1.DataBind();
                ViewState["TaskDATA"] = table;
            }
            return table;
        }

        //------------------------------TASK---------------------------------------//
        public DataTable GetStaffnamebytaskname(string task)
        {
            string str;
            DataTable table = new DataTable();
            DataRow dtrow;
            DataColumn dataColumn = new DataColumn();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_GetTaskDetailsByTaskname", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Subject", task);
                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                ad.Fill(table);
            }
            return table;
        }
        public void Clear()
        {
            txtDescription.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            txtContractValue.Text = string.Empty;          
            ddlContracttype.SelectedIndex = 0;
            ddlVendor.SelectedIndex = 0;          
            ChBoxTrash.Checked = false;
            CheckHideCustomer.Checked = false;
        }

        protected void bindVendor()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetVendor", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlVendor.DataSource = ds.Tables[0];
                    ddlVendor.DataTextField = "Vend_Name";
                    ddlVendor.DataValueField = "Vend_ID";
                    ddlVendor.DataBind();
                    ddlVendor.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Vendor", "0"));
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

        protected void bindContractType()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetcontractType", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlContracttype.DataSource = ds.Tables[0];
                    ddlContracttype.DataTextField = "Contractype";
                    ddlContracttype.DataValueField = "id";
                    ddlContracttype.DataBind();
                    ddlContracttype.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Contract Type", "0"));
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

        #region "Events"
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
                            bindVendor();
                            bindContractType();
                            GetTaskbyModuleWise();
                            string Todaydate = Convert.ToString(DateTime.Today);
                            string WeekDate = Convert.ToString(DateTime.Today.AddDays(7));
                            txtStartDate.Attributes["value"] = DateTime.Parse(Todaydate.ToString()).ToString("yyyy-MM-dd");
                            txtEndDate.Attributes["value"] = DateTime.Parse(WeekDate.ToString()).ToString("yyyy-MM-dd");
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
                                bindVendor();
                                bindContractType();
                                GetTaskbyModuleWise();
                                string Todaydate = Convert.ToString(DateTime.Today);
                                string WeekDate = Convert.ToString(DateTime.Today.AddDays(7));
                                txtStartDate.Attributes["value"] = DateTime.Parse(Todaydate.ToString()).ToString("yyyy-MM-dd");
                                txtEndDate.Attributes["value"] = DateTime.Parse(WeekDate.ToString()).ToString("yyyy-MM-dd");
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
             
        protected void btnSaveContractVendor_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (CheckHideCustomer.Checked == true)
                    {
                        visible = "True";
                    }
                    else
                    {
                        visible = "False";
                    }

                    if (ChBoxTrash.Checked == true)
                    {
                        trash = "True";
                    }
                    else
                    {
                        trash = "False";
                    }

                    string uploadDirectory = Server.MapPath("~/Contract_vender_Details_Upload/");
                    string fileName;
                    string filePath;
                    if (FileUpload1.HasFile)
                    {
                        if (!Directory.Exists(uploadDirectory))
                        {
                            Directory.CreateDirectory(uploadDirectory);
                        }

                        fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        filePath = Path.Combine(uploadDirectory, fileName);
                        FileUpload1.PostedFile.SaveAs(filePath);
                    }
                    else
                    {
                        // If no file is uploaded, set fileName and filePath to null
                        fileName = null;
                        filePath = null;
                    }
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        // db connect
                        SqlCommand cmd = new SqlCommand("[SP_SaveContract_Vendor]", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@subject", txtSubject.Text);
                        cmd.Parameters.AddWithValue("@VendorID", ddlVendor.SelectedValue);
                        cmd.Parameters.AddWithValue("@datestart", txtStartDate.Text);
                        cmd.Parameters.AddWithValue("@dateend", txtEndDate.Text);
                        cmd.Parameters.AddWithValue("@contract_type", ddlContracttype.SelectedValue);
                        cmd.Parameters.AddWithValue("@add_by", UserName);
                        cmd.Parameters.AddWithValue("@trash", trash);
                        cmd.Parameters.AddWithValue("@FileName", fileName);
                        cmd.Parameters.AddWithValue("@FilePath", filePath);
                        cmd.Parameters.AddWithValue("@visible", visible);
                        cmd.Parameters.AddWithValue("@contract_value", txtContractValue.Text);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@contract_type_name", ddlContracttype.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i < 0)
                        {
                            string save = "fgsave123q";
                            Response.Redirect("~/Contract_Vendor.aspx?svd1=" + save + "", false);
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Contract Vendor Details Not Save Successfully";
                        }                       
                        Clear();
                        con.Close();
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
        }

        protected void Linkbtnpdf_Click(object sender, EventArgs e)
        {

        }

        protected void linkbtnMergeField_Click(object sender, EventArgs e)
        {
            tblcontract.Visible = true;
                textBox.Visible = true;
            textBox.Text = "Contract Data" + "\n";
            ViewState["Data"] = textBox.Text;
        }
        //1
        protected void LinkButtoncontract_Firstname_Click(object sender, EventArgs e)
        {
            ViewState["Data"] = null;
            FieldsList.Add(Convert.ToString(LinkButtoncontract_Firstname.Text));

            Count = FieldsList.Count;


            if (Count > 0)
            {
                foreach (var Fields in FieldsList)
                {
                    textBox.Text = Fields + ",";

                }
                ViewState["Data"] = textBox.Text;
            }
        }
        //2
        protected void LinkButtoncontract_lastname_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncontract_lastname.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }

        }
        //3
        protected void LinkButtonset_password_url_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonset_password_url.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }

        }
        //4
        protected void LinkButtonreset_password_url_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonreset_password_url.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //5
        protected void LinkButtoncontact_email_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncontact_email.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //6
        protected void LinkButtonclient_company_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonclient_company.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //7
        protected void LinkButtonclient_phonenumber_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonclient_phonenumber.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //8
        protected void LinkButtonclient_country_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonclient_country.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //9
        protected void LinkButtonclient_city_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonclient_city.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //10
        protected void LinkButtonclient_zip_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonclient_zip.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //11
        protected void LinkButtonclient_state_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonclient_state.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //12
        protected void LinkButtonclient_address_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonclient_address.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //13
        protected void LinkButtonclient_var_number_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonclient_var_number.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //14
        protected void LinkButtoncustomer_gst_no_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncustomer_gst_no.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //15
        protected void LinkButtoncontract_id_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncontract_id.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //16
        protected void LinkButtoncontract_subject_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncontract_subject.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //17
        protected void LinkButtoncontract_description_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncontract_description.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //18
        protected void LinkButtoncontract_datestart_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncontract_datestart.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //19
        protected void LinkButtoncontract_dateend_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncontract_dateend.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //20
        protected void LinkButtoncontract_contract_value_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncontract_contract_value.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //21
        protected void LinkButtonlogo_url_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonlogo_url.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //22
        protected void LinkButtoncrm_url_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncrm_url.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //23
        protected void LinkButtonatmin_url_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonatmin_url.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //24
        protected void LinkButtonmain_domain_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonmain_domain.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //25
        protected void LinkButtoncompanyname_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncompanyname.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit.....FirstName
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }
        //26
        protected void LinkButtonemail_signature_Click(object sender, EventArgs e)
        {
            string Name = (ViewState["Data"] != null) ? ViewState["Data"].ToString() : "";
            FieldsList.Add(Convert.ToString(LinkButtonemail_signature.Text));

            Count = FieldsList.Count;

            if (Name == "") // first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";
                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else // multiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";
                    }
                    ViewState["Data"] = textBox.Text;
                }
            }

        }
     
        protected void Linkclear_Click1(object sender, EventArgs e)
        {
            textBox.Text = "Contract Data" + "\n";
            ViewState["Data"] = textBox.Text;
        }

        protected void Linkbtnpdf_Click1(object sender, EventArgs e)
        {

            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
            try
            {
                PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
                pdfDoc.Open();

                //Set Font Properties for PDF File
                iTextSharp.text.Font fnt = FontFactory.GetFont("Times New Roman", 14);

                PdfPTable PdfTable = new PdfPTable(1);
                PdfPCell PdfPCell = null;

                //Retrieve content from design side
                string s = textBox.Text;

                if (textBox.Text == "")
                {
                    s = " Field's are Empty";
                }
                else
                {
                    s = textBox.Text;
                }

                PdfPCell bodyCell1 = new PdfPCell(new Phrase(new Chunk(s, fnt)));
                // PdfPCell.Border = PdfPCell.NO_BORDER;

                bodyCell1.Border = 0;

                PdfTable.AddCell(bodyCell1);
                pdfDoc.Add(PdfTable);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";

                string Vendername ="";
                if (ddlVendor.SelectedItem.Text == "Select Vendor")
                {
                    Vendername = "Contract_Vender ";
                   
                }
                else
                {
                    Vendername = ddlVendor.SelectedItem.Text;

                }

                Response.AddHeader("content-disposition", "attachment; filename=" + Vendername + ".pdf");

                System.Web.HttpContext.Current.Response.Write(pdfDoc);

                Response.Flush();
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //----------------------------------------------------------------------------//
        // Task 
        //-----------------------------------------------------------------------------//
        protected void btnVisibilityTask_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    DataTable table = new DataTable();
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_ViewTaskModuleViseVisibility", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ModuleNAME", txtSubject.Text);
                        cmd.Parameters.AddWithValue("@BelongTo", "Contract Staff");
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(table);
                        GridTask1.DataSource = table;
                        GridTask1.DataBind();
                    }
                }
                else if (RoleType == Designation)
                {

                }
                else
                {
                    Response.Redirect("~/Expired.html", true);
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

        protected void BtnReloadTask_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {

                }
                else if (RoleType == Designation)
                {

                }
                else
                {
                    Response.Redirect("~/Expired.html", true);
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

        protected void btnEditTask_Click(object sender, EventArgs e)
        {
            try
            {
                string task;
                var rows = GridTask1.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;
                Response.Redirect("~/EditStaffTask.aspx?task=" + task + "", false);
            }
            catch (Exception ex)
            {
                using (SqlConnection DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                    string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                    Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                    SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
                    cmdex.CommandType = CommandType.StoredProcedure;
                    cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                    cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                    cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                    cmdex.Parameters.AddWithValue("@Method", method);
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                    DeviceCon.Open();
                    int RowEx = cmdex.ExecuteNonQuery();
                    if (RowEx < 0)
                    {
                        //lblMessage.Visible = false;
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

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private static void DrawLine(iTextSharp.text.pdf.PdfWriter writer, float x1, float y1, float x2, float y2, BaseColor color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(BaseColor.BLACK);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }

        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.Colspan = 4;
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 3f;
            cell.PaddingTop = 0f;
            return cell;
        }
        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 4f;
            cell.PaddingTop = 2f;
            return cell;
        }

        public void GetCompanyAddress()
        {
            try
            {

                SqlConnection UserCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetCompanyAddress", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lbladdCompany11.Text = dt.Rows[0]["Company_Name"].ToString() + ",";
                    lbladdress11.Text = dt.Rows[0]["Address"].ToString() + ",";
                    lblcompanyaddCity1.Text = dt.Rows[0]["City"].ToString() + ",";
                    lblcompanyaddDistrict1.Text = dt.Rows[0]["District"].ToString() + ",";
                    lblcompanyaddState1.Text = dt.Rows[0]["State"].ToString() + ",";
                    lblcompanyaddCountry1.Text = "India" + ",";
                    lblcompanyaddZIPCode11.Text = dt.Rows[0]["Zip_Code"].ToString() + ",";

                    lblphoneNo1.Text = dt.Rows[0]["Phone"].ToString() + ",";
                    lblVatNo1.Text = dt.Rows[0]["VAT_Number"].ToString() + ",";
                    lblGSTNo1A.Text = dt.Rows[0]["GST_NO"].ToString() + ",";

                    Image1.ImageUrl = dt.Rows[0]["Company_Logo"].ToString();
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
        protected void linkTaskPDf_Click(object sender, EventArgs e)
        {
            try
            {
                GetCompanyAddress();
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    int _totalColumns = 10;
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(_totalColumns);
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;

                    Document _document = new Document(PageSize.A4, 0, 0, 0, 0);
                    _document.SetPageSize(PageSize.A4);
                    _document.SetMargins(20f, 20f, 20f, 20f);
                    _pdfPTable.WidthPercentage = 500;
                    _pdfPTable.TotalWidth = 500f;
                    _pdfPTable.LockedWidth = true;
                    _pdfPTable.HorizontalAlignment = Element.ALIGN_CENTER;
                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

                    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                    {
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(_document, memoryStream);
                        _document.Open();
                        _pdfPTable.SetWidths(new float[] { 3f, 12f, 10f, 10f, 10f, 12f, 8f, 6f, 7f, 8f });
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 10;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPTable.AddCell(cell);
                        //.....image logo.....// 
                        phrase = new Phrase();
                        phrase.Add(new Chunk(lbladdCompany11.Text + "\n", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lbladdress11.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCity1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddDistrict1.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddState1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        _pdfPCell = new PdfPCell(phrase);
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.BorderColor = BaseColor.WHITE;
                        _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.PaddingBottom = 1f;
                        _pdfPCell.PaddingTop = 0f;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("TaskStaffList", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //----------------------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 4;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*------------------------------------", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = GetTaskbyModuleWise();
                        #region "Table Header"
                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);


                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Subject", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StartDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("DueDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("AssignTo", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("TaskStatus", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Status", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Reapet", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);//Billable
                        _pdfPCell = new PdfPCell(new Phrase("Priority", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);//Billable
                        _pdfPCell = new PdfPCell(new Phrase("Billable", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPTable.CompleteRow();
                        #endregion

                        #region "Table Body"
                        _fontStyle = FontFactory.GetFont("Tahoma", 10f, 0);
                        int serialnumber = 1;

                        foreach (DataRow row in _Vhrlist.Rows)
                        {
                            _pdfPCell = new PdfPCell(new Phrase(serialnumber++.ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Subject"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Start_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Due_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            DataTable taskassign = GetStaffnamebytaskname(row["Subject"].ToString());
                            Phrase Pharse1 = new Phrase();
                            foreach (DataRow Rowassign in taskassign.Rows)
                            {

                                Pharse1.Add(new Chunk(Rowassign["AssignTo"].ToString() + ",", _fontStyle));


                            }

                            _pdfPCell = new PdfPCell(Pharse1);
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);


                            _pdfPCell = new PdfPCell(new Phrase(row["TaskStatus"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Status"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Reapet_Every"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Priority"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Billable"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                        }
                        #endregion

                        #region "Table Footer"
                        String text = "Page " + writer.PageNumber + " of ";
                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        PdfContentByte cb = writer.DirectContent;
                        PdfTemplate footerTemplate = cb.CreateTemplate(40, 40);

                        //Move the pointer and draw line to separate footer section from rest of page  
                        cb.MoveTo(40, _document.PageSize.GetBottom(40));
                        cb.LineTo(_document.PageSize.Width - 40, _document.PageSize.GetBottom(40));
                        cb.Stroke();

                        cb.BeginText();
                        cb.SetFontAndSize(bf, 9);
                        cb.SetTextMatrix(_document.PageSize.GetRight(100), _document.PageSize.GetBottom(30));
                        cb.ShowText(text);
                        cb.EndText();
                        float len = bf.GetWidthPoint(text, 9);
                        cb.AddTemplate(footerTemplate, _document.PageSize.GetRight(100) + len, _document.PageSize.GetBottom(30));

                        footerTemplate.BeginText();
                        footerTemplate.SetFontAndSize(bf, 9);
                        footerTemplate.SetTextMatrix(0, 0);
                        footerTemplate.ShowText((writer.PageNumber - 1).ToString());
                        footerTemplate.EndText();

                        #endregion

                        //-------------------- PDF Generation------------------------------------//
                        _pdfPTable.HeaderRows = 1; //header method
                        _document.Add(_pdfPTable);

                        _document.Close();
                        byte[] bytes = memoryStream.ToArray();
                        DateTime dTime = DateTime.Now;
                        string PDFFileName = string.Format("TaskStaffList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=" + PDFFileName);
                        Response.Buffer = true;
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.BinaryWrite(bytes);
                        Response.End();

                    }
                }
                else if (RoleType == Designation)
                {
                    int _totalColumns = 10;
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(_totalColumns);
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;

                    Document _document = new Document(PageSize.A4, 0, 0, 0, 0);
                    _document.SetPageSize(PageSize.A4);
                    _document.SetMargins(20f, 20f, 20f, 20f);
                    _pdfPTable.WidthPercentage = 500;
                    _pdfPTable.TotalWidth = 500f;
                    _pdfPTable.LockedWidth = true;
                    _pdfPTable.HorizontalAlignment = Element.ALIGN_CENTER;
                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

                    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                    {
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(_document, memoryStream);
                        _document.Open();
                        _pdfPTable.SetWidths(new float[] { 3f, 12f, 10f, 10f, 10f, 12f, 8f, 6f, 7f, 8f });
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 10;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPTable.AddCell(cell);
                        //.....image logo.....// 
                        phrase = new Phrase();
                        phrase.Add(new Chunk(lbladdCompany11.Text + "\n", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lbladdress11.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCity1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddDistrict1.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddState1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        _pdfPCell = new PdfPCell(phrase);
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.BorderColor = BaseColor.WHITE;
                        _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.PaddingBottom = 1f;
                        _pdfPCell.PaddingTop = 0f;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("TaskStaffList", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //----------------------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 4;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*------------------------------------", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = (DataTable)ViewState["TaskDATA"];
                        #region "Table Header"
                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);


                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Subject", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StartDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("DueDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("AssignTo", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("TaskStatus", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Status", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Reapet", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);//Billable
                        _pdfPCell = new PdfPCell(new Phrase("Priority", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);//Billable
                        _pdfPCell = new PdfPCell(new Phrase("Billable", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _pdfPTable.CompleteRow();
                        #endregion

                        #region "Table Body"
                        _fontStyle = FontFactory.GetFont("Tahoma", 10f, 0);
                        int serialnumber = 1;

                        foreach (DataRow row in _Vhrlist.Rows)
                        {
                            _pdfPCell = new PdfPCell(new Phrase(serialnumber++.ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Subject"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Start_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Due_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            DataTable taskassign = GetStaffnamebytaskname(row["Subject"].ToString());
                            Phrase Pharse1 = new Phrase();
                            foreach (DataRow Rowassign in taskassign.Rows)
                            {

                                Pharse1.Add(new Chunk(Rowassign["AssignTo"].ToString() + ",", _fontStyle));


                            }

                            _pdfPCell = new PdfPCell(Pharse1);
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);


                            _pdfPCell = new PdfPCell(new Phrase(row["TaskStatus"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Status"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Reapet_Every"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Priority"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Billable"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                        }
                        #endregion

                        #region "Table Footer"
                        String text = "Page " + writer.PageNumber + " of ";
                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        PdfContentByte cb = writer.DirectContent;
                        PdfTemplate footerTemplate = cb.CreateTemplate(40, 40);

                        //Move the pointer and draw line to separate footer section from rest of page  
                        cb.MoveTo(40, _document.PageSize.GetBottom(40));
                        cb.LineTo(_document.PageSize.Width - 40, _document.PageSize.GetBottom(40));
                        cb.Stroke();

                        cb.BeginText();
                        cb.SetFontAndSize(bf, 9);
                        cb.SetTextMatrix(_document.PageSize.GetRight(100), _document.PageSize.GetBottom(30));
                        cb.ShowText(text);
                        cb.EndText();
                        float len = bf.GetWidthPoint(text, 9);
                        cb.AddTemplate(footerTemplate, _document.PageSize.GetRight(100) + len, _document.PageSize.GetBottom(30));

                        footerTemplate.BeginText();
                        footerTemplate.SetFontAndSize(bf, 9);
                        footerTemplate.SetTextMatrix(0, 0);
                        footerTemplate.ShowText((writer.PageNumber - 1).ToString());
                        footerTemplate.EndText();

                        #endregion

                        //-------------------- PDF Generation------------------------------------//
                        _pdfPTable.HeaderRows = 1; //header method
                        _document.Add(_pdfPTable);

                        _document.Close();
                        byte[] bytes = memoryStream.ToArray();
                        DateTime dTime = DateTime.Now;
                        string PDFFileName = string.Format("TaskStaffList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=" + PDFFileName);
                        Response.Buffer = true;
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.BinaryWrite(bytes);
                        Response.End();

                    }
                }
                else
                {
                    Response.Redirect("~/Expired.html", true);
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

        protected void lnkbtnTaskExcel_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "TaskDetails " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    using (StringWriter sw = new StringWriter())
                    {
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        //To Export all pages
                        GridTask1.AllowPaging = false;
                        DataTable dt = (DataTable)ViewState["TaskDATA"];
                        DataTable dt2 = new DataTable();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            dt2.Columns.Add(dt.Columns[i].ColumnName, typeof(string));
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt2.ImportRow(dt.Rows[i]);

                        }
                        this.GridTask1.DataSource = dt2;
                        this.GridTask1.DataBind();
                        GridTask1.HeaderRow.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in GridTask1.HeaderRow.Cells)
                        {
                            cell.BackColor = GridTask1.HeaderStyle.BackColor;
                        }
                        foreach (GridViewRow row in GridTask1.Rows)
                        {
                            row.BackColor = System.Drawing.Color.White;
                            foreach (TableCell cell in row.Cells)
                            {
                                if (row.RowIndex % 2 == 0)
                                {
                                    cell.BackColor = GridTask1.AlternatingRowStyle.BackColor;
                                }
                                else
                                {
                                    cell.BackColor = GridTask1.RowStyle.BackColor;
                                }
                                cell.CssClass = "textmode";
                            }
                        }
                        GridTask1.RenderControl(hw);
                        //style to format numbers to string
                        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                        Response.Write(style);
                        Response.Output.Write(sw.ToString());
                        Response.Flush();
                        Response.End();
                    }
                }
                else if (RoleType == Designation)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "TaskDetails " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    using (StringWriter sw = new StringWriter())
                    {
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        //To Export all pages
                        GridTask1.AllowPaging = false;
                        DataTable dt = (DataTable)ViewState["TaskDATA"];
                        DataTable dt2 = new DataTable();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            dt2.Columns.Add(dt.Columns[i].ColumnName, typeof(string));
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt2.ImportRow(dt.Rows[i]);

                        }
                        this.GridTask1.DataSource = dt2;
                        this.GridTask1.DataBind();
                        GridTask1.HeaderRow.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in GridTask1.HeaderRow.Cells)
                        {
                            cell.BackColor = GridTask1.HeaderStyle.BackColor;
                        }
                        foreach (GridViewRow row in GridTask1.Rows)
                        {
                            row.BackColor = System.Drawing.Color.White;
                            foreach (TableCell cell in row.Cells)
                            {
                                if (row.RowIndex % 2 == 0)
                                {
                                    cell.BackColor = GridTask1.AlternatingRowStyle.BackColor;
                                }
                                else
                                {
                                    cell.BackColor = GridTask1.RowStyle.BackColor;
                                }
                                cell.CssClass = "textmode";
                            }
                        }
                        GridTask1.RenderControl(hw);
                        //style to format numbers to string
                        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                        Response.Write(style);
                        Response.Output.Write(sw.ToString());
                        Response.Flush();
                        Response.End();
                    }
                }
                else
                {
                    Response.Redirect("~/Expired.html", true);
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

        protected void btnDeleteTask_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {

                    DeviceCon = new SqlConnection(strconnect);
                    string task;
                    var rows = GridTask1.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;

                    SqlCommand cmd = new SqlCommand("SP_DeleteTaskbyTaskname", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Subject", task);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Details Deleted Successfully";
                        GridTask1.EditIndex = -1;
                        GetTaskbyModuleWise();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Details Not Deleted Successfully";
                    }
                }
                else if (RoleType == Designation)
                {

                    DeviceCon = new SqlConnection(strconnect);
                    string task;
                    var rows = GridTask1.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;

                    SqlCommand cmd = new SqlCommand("SP_DeleteTaskbyTasknameForEmpID", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Subject", task);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Details Deleted Successfully";
                        GridTask1.EditIndex = -1;
                        GetTaskbyModuleWise();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Details Not Deleted Successfully";
                    }

                }
                else
                {
                    Response.Redirect("~/Expired.html", true);
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

        protected void btn_New_Task_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewTaskStaff.aspx", true);
        }

        protected void ddlTaskStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string TaskStatus1, ddlTaskStatus1, task;

                var rows = GridTask1.Rows;
                DropDownList btn = (DropDownList)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;
                TaskStatus1 = ((Label)rows[rowindex].FindControl("lblTaskStatus1")).Text;
                ddlTaskStatus1 = ((DropDownList)rows[rowindex].FindControl("ddlTaskStatus")).SelectedItem.Text;

                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateTaskStaffStatus", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Subject", task);
                    cmd.Parameters.AddWithValue("@TaskStatus", ddlTaskStatus1);
                    cmd.Parameters.AddWithValue("@Updateby", UserName); // Use SelectedValue
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    conn.Open();
                    int Result = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (Result < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Status Change Successfully";
                        GridTask1.EditIndex = -1;
                        GetTaskbyModuleWise();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Status Change Successfully";
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
        protected void GridTask1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridTask1.Rows)
                {
                    //---------------Status-------------------------------///
                    string Status = ((Button)gridviedrow.FindControl("btnStatus")).Text;
                    Button btnStatusAssign = (Button)gridviedrow.FindControl("btnStatus");

                    Label lbltaskName1 = (Label)gridviedrow.FindControl("lbltaskName1");
                    Label lblStart_Date1 = (Label)gridviedrow.FindControl("lblStart_Date1");
                    Label lblDue_Date1 = (Label)gridviedrow.FindControl("lblDue_Date1");
                    Label lblTaskStatus1 = (Label)gridviedrow.FindControl("lblTaskStatus1");
                    DropDownList ddlTaskStatus1 = (DropDownList)gridviedrow.FindControl("ddlTaskStatus");

                    ddlTaskStatus1.SelectedItem.Text = lblTaskStatus1.Text;
                    Label lblstatus1 = (Label)gridviedrow.FindControl("lblstatus1");

                    Label lblReapet_Every1 = (Label)gridviedrow.FindControl("lblReapet_Every1");

                    Label lblPriority1 = (Label)gridviedrow.FindControl("lblPriority1");
                    DropDownList ddlPriority1 = (DropDownList)gridviedrow.FindControl("ddlPriority");
                    ddlPriority1.SelectedItem.Text = lblPriority1.Text;

                    Label lblBillable1 = (Label)gridviedrow.FindControl("lblBillable1");
                    LinkButton btnDeleteTask = (LinkButton)gridviedrow.FindControl("btnDeleteTask");
                    System.Web.UI.WebControls.Image Img1 = (System.Web.UI.WebControls.Image)gridviedrow.FindControl("img1");

                    //////////////////////////////////////////////////////////////////////////////////////////


                    BulletedList bulletListRelatedTo = (BulletedList)gridviedrow.FindControl("bulletlist1");

                    string task = lbltaskName1.Text;

                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    if (Status.Equals("True"))
                    {
                        btnStatusAssign.Text = "True";
                        btnStatusAssign.CssClass = "btn btn-outline-success";
                        lbltaskName1.ForeColor = Color.Blue;
                        lblStart_Date1.ForeColor = Color.Blue;
                        lblDue_Date1.ForeColor = Color.Blue;
                        //lblReletd_To1.ForeColor = Color.Blue;
                        lblstatus1.ForeColor = Color.Blue;
                        lblReapet_Every1.ForeColor = Color.Blue;

                        lblBillable1.ForeColor = Color.Blue;


                        DataTable table = GetStaffnamebytaskname(task);

                        bulletListRelatedTo.DataSource = table;
                        bulletListRelatedTo.DataTextField = "AssignTo";
                        bulletListRelatedTo.DataValueField = "AssignTo";
                        bulletListRelatedTo.DataBind();
                    }
                    else
                    {
                        btnDeleteTask.Visible = false;
                        btnStatusAssign.Text = "False";
                        btnStatusAssign.CssClass = "btn  btn-outline-dark";
                        lbltaskName1.ForeColor = Color.Red;
                        lblStart_Date1.ForeColor = Color.Red;
                        lblDue_Date1.ForeColor = Color.Red;
                        lblstatus1.ForeColor = Color.Red;
                        lblReapet_Every1.ForeColor = Color.Red;
                        lblBillable1.ForeColor = Color.Red;

                        using (SqlConnection con = new SqlConnection(strconnect))
                        {
                            SqlCommand sqlCommand = new SqlCommand("[SP_ViewTaskInActiveStatus]", con);//storeprocedure madhe status 0
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@Subject", task);

                            SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                            DataTable dt = new DataTable();
                            ad.Fill(dt);

                            bulletListRelatedTo.DataSource = dt;
                            bulletListRelatedTo.DataTextField = "AssignTo";
                            bulletListRelatedTo.DataValueField = "AssignTo";
                            bulletListRelatedTo.DataBind();

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
        protected void ddlPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string PriorityTo, ddlPriority1, task;

                var rows = GridTask1.Rows;
                DropDownList btn = (DropDownList)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;
                PriorityTo = ((Label)rows[rowindex].FindControl("lblPriority1")).Text;
                ddlPriority1 = ((DropDownList)rows[rowindex].FindControl("ddlPriority")).SelectedItem.Text;

                using (SqlConnection sqlConnection = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateTaskPriority", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Subject", task);
                    cmd.Parameters.AddWithValue("@Priority", ddlPriority1);
                    cmd.Parameters.AddWithValue("@Updateby", UserName); // Use SelectedValue
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    sqlConnection.Open();
                    int Result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (Result < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Priority Chnage Successfully";
                        GridTask1.EditIndex = -1;
                        GetTaskbyModuleWise();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Task Priority Not Chnage Successfully";
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

        protected void btn_Task_Overview_Click(object sender, EventArgs e)
        {
            Response.Redirect("Task_Detail_Overview.aspx", true);
        }

    #endregion
    }

}