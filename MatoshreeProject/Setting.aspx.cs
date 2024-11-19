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
    public partial class Setting : System.Web.UI.Page
    {

        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result, Role, CompID;
        String Admin_Area_RTL, Customer_Area_RTL, Disable_Language;
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

        #region " Public Functions "
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
                    command.Parameters.AddWithValue("@SubModule", "Settings");
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
                            string companyinfo = "{Company_Name}" + "\n" + "{Address}" + "\n" + "{City}" + "\n" + "{State}" + "\n" + "{Zip-Code}" + "\n" + "{Country-Code}" + "\n" + "{Phone}" + "\n" + "{Vat-Number}" + "\n" + "{Vat-Number-With-Lable}";
                            txtcompInfo.Text = companyinfo;
                            BindCityDetails();
                            BindDistrictDetails();
                            BindStateDetails();
                            GetCompanyDataByID();
                            Setting_General.Visible = true;
                            Setting_Company.Visible = false;

                            if (Create == "True")
                            {
                                addnew.Visible = true;
                            }
                            else
                            {
                                addnew.Visible = false;
                            }

                           
                        }
                        else if (View == "True")
                        {
                            string companyinfo = "{Company_Name}" + "\n" + "{Address}" + "\n" + "{City}" + "\n" + "{State}" + "\n" + "{Zip-Code}" + "\n" + "{Country-Code}" + "\n" + "{Phone}" + "\n" + "{Vat-Number}" + "\n" + "{Vat-Number-With-Lable}";
                            txtcompInfo.Text = companyinfo;
                            BindCityDetails();
                            BindDistrictDetails();
                            BindStateDetails();
                            GetCompanyDataByID();
                            Setting_General.Visible = true;
                            Setting_Company.Visible = false;

                            if (Create == "True")
                            {
                                addnew.Visible = true;
                            }
                            else
                            {
                                addnew.Visible = false;
                            }

                            //if (Edit == "True")
                            //{

                            //    GridTender.Columns[10].Visible = true;
                            //}
                            //else
                            //{

                            //    GridTender.Columns[10].Visible = false;
                            //}

                            //if (Delete == "True")
                            //{

                            //    GridTender.Columns[11].Visible = true;
                            //}
                            //else
                            //{

                            //    GridTender.Columns[11].Visible = false;
                            //}
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

        public void GetCompanyDataByID()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

                SqlConnection UserCon = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("SP_GetCompanyDetailsByID", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtcompanyname.Text = dt.Rows[0]["Company_Name"].ToString();
                    txt_Company_Name.Text = dt.Rows[0]["Company_Name"].ToString();
                    txtmaindomain.Text = dt.Rows[0]["Company_Main_Domain"].ToString();
                    ImgLogo.ImageUrl = dt.Rows[0]["Company_Logo"].ToString();
                    ImgdarkLogo.ImageUrl = dt.Rows[0]["Dark_Logo"].ToString();
                    txtfiletype.Text = dt.Rows[0]["Allowed_File_Types"].ToString();
                    txt_Address.Text = dt.Rows[0]["Address"].ToString();
                    ddlcity.SelectedItem.Text = dt.Rows[0]["City"].ToString();
                    ddlState1.SelectedItem.Text = dt.Rows[0]["State"].ToString();
                    ddldistrict.SelectedItem.Text = dt.Rows[0]["District"].ToString();
                    DropDownList4.SelectedItem.Text = "India";
                    txt_Country_Code.Text = dt.Rows[0]["Country_Code"].ToString();
                    txt_Zip_Code.Text = dt.Rows[0]["Zip_Code"].ToString();
                    txt_Phone.Text = dt.Rows[0]["Phone"].ToString();
                    txtvat.Text = dt.Rows[0]["VAT_Number"].ToString();
                    txtGSTNumber.Text = dt.Rows[0]["GST_NO"].ToString();
                    txtcompInfo.Text = dt.Rows[0]["Company_Format"].ToString();
                    ddldateformate.SelectedItem.Text = dt.Rows[0]["Date_Format"].ToString();
                    ddltimeformate.SelectedItem.Text = dt.Rows[0]["Time_Format"].ToString();
                    DDLtimezone.SelectedItem.Text = dt.Rows[0]["Default_Timezone"].ToString();
                    ddldefultlang.SelectedItem.Text = dt.Rows[0]["Default_Language"].ToString();
                    Admin_Area_RTL = dt.Rows[0]["Admin_Area_RTL"].ToString();
                    if (Admin_Area_RTL == "True")
                    {
                        RadioButtonListadmin.SelectedValue = "1";
                    }
                    else
                    {
                        RadioButtonListadmin.SelectedValue = "0";
                    }

                    //Customer_Area_RTL
                    Customer_Area_RTL = dt.Rows[0]["Customer_Area_RTL"].ToString();
                    if (Customer_Area_RTL == "True")
                    {
                        RadioButtonListcust.SelectedValue = "1";
                    }
                    else
                    {
                        RadioButtonListcust.SelectedValue = "0";
                    }

                    //Disable_Language
                    Disable_Language = dt.Rows[0]["Disable_Language"].ToString();
                    if (Disable_Language == "True")
                    {
                        RadioButtonListdefultlang.SelectedValue = "1";
                    }
                    else
                    {
                        RadioButtonListdefultlang.SelectedValue = "0";
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
            finally
            {
            }
        }

        #endregion

        #region " Protected Functions "
        public void BindStateDetails()
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
                    ddlState1.DataSource = ds.Tables[0];
                    ddlState1.DataTextField = "State_Name";
                    ddlState1.DataValueField = "ID";
                    ddlState1.DataBind();
                    ddlState1.Items.Insert(0, new ListItem("Select State", "0"));
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

        public void Errorlog(string ex)
        {
            try
            {
                string ErrorMessgage = ex;
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(Convert.ToInt32(ex), true);
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
            catch
            {

            }
        }


        public void BindDistrictDetails()
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
                    ddldistrict.DataSource = ds.Tables[0];
                    ddldistrict.DataTextField = "Disttrict_Name";
                    ddldistrict.DataValueField = "District_ID";
                    ddldistrict.DataBind();
                    ddldistrict.Items.Insert(0, new ListItem("Select District", "0"));

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

        public void BindCityDetails()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetCity", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlcity.DataSource = ds.Tables[0];
                    ddlcity.DataTextField = "City";
                    ddlcity.DataValueField = "ID";
                    ddlcity.DataBind();
                    ddlcity.Items.Insert(0, new ListItem("Select City", "0"));
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
                        Designation = Session["Role"].ToString();
                        DeptID = Session["DeptID"].ToString();

                        if (!IsPostBack)
                        {
                            string companyinfo = "{Company_Name}" + "\n" + "{Address}" + "\n" + "{City}" + "\n" + "{State}" + "\n" + "{Zip-Code}" + "\n" + "{Country-Code}" + "\n" + "{Phone}" + "\n" + "{Vat-Number}" + "\n" + "{Vat-Number-With-Lable}";
                            txtcompInfo.Text = companyinfo;
                            BindCityDetails();
                            BindDistrictDetails();                           
                            BindStateDetails();
                            GetCompanyDataByID();
                            Setting_General.Visible = true;
                            Setting_Company.Visible = false;
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

        protected void btn_Save_Settings_1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (ImgLogo.ImageUrl == "" || ImgdarkLogo.ImageUrl == "")
                    {
                        //select upload logo
                    }
                    else
                    {

                        SqlConnection con = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_SaveCompany", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Company_Name", txt_Company_Name.Text);
                        cmd.Parameters.AddWithValue("@Company_Main_Domain", txtmaindomain.Text);
                        cmd.Parameters.AddWithValue("@Company_Logo", ImgLogo.ImageUrl);
                        cmd.Parameters.AddWithValue("@Dark_Logo", ImgdarkLogo.ImageUrl);
                        cmd.Parameters.AddWithValue("@Admin_Area_RTL", RadioButtonListadmin.SelectedValue);
                        cmd.Parameters.AddWithValue("@Customer_Area_RTL", RadioButtonListcust.SelectedValue);
                        cmd.Parameters.AddWithValue("@Allowed_File_Types", txtfiletype.Text);
                        cmd.Parameters.AddWithValue("@Created_by", UserName); //Session value
                        cmd.Parameters.AddWithValue("@Address", txt_Address.Text);
                        cmd.Parameters.AddWithValue("@City", ddlcity.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@State", ddlState1.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@District", ddldistrict.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Country_Code", txt_Country_Code.Text);
                        cmd.Parameters.AddWithValue("@Zip_Code", txt_Zip_Code.Text);
                        cmd.Parameters.AddWithValue("@Phone", txt_Phone.Text);
                        cmd.Parameters.AddWithValue("@VAT_Number", txtvat.Text);
                        cmd.Parameters.AddWithValue("@GST_NO", txtGSTNumber.Text);
                        cmd.Parameters.AddWithValue("@Company_Format", txtcompInfo.Text);
                        cmd.Parameters.AddWithValue("@Date_Format", ddldateformate.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Time_Format", ddltimeformate.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Default_Timezone", DDLtimezone.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Default_Language", ddldefultlang.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Disable_Language", RadioButtonListdefultlang.SelectedValue);
                        cmd.Parameters.AddWithValue("@Output_Clint_PDF", "1");
                        //EmailID Setting
                        string Mailengin = RdiobtnEngine.SelectedItem.Text;
                        cmd.Parameters.AddWithValue("@Mail_Engine", Mailengin);
                        string Emailprotocal = RdiobtnProtocal.SelectedItem.Text;
                        cmd.Parameters.AddWithValue("@Email_Protocal", Emailprotocal);
                        cmd.Parameters.AddWithValue("@Email_Charset", txtCharset.Text);
                        cmd.Parameters.AddWithValue("@Bcc_All_Emails_To",txt_Bcc.Text);
                        cmd.Parameters.AddWithValue("@Email_Signature", txt_Email_Signature.Text);
                        cmd.Parameters.AddWithValue("@Predefind_Header", txtheader.Text);
                        cmd.Parameters.AddWithValue("@Predefind_Footer", txtfooter.Text);
                        string Emailqueue = Rdiobtnqueue.SelectedItem.Value;
                        cmd.Parameters.AddWithValue("@Enable_Email_Queue", Emailqueue);                        
                        string AddEmail = Rdiobtnattitchment.SelectedItem.Value;
                        cmd.Parameters.AddWithValue("@Add_Email", AddEmail);
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
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Company Details Save Successfully!')", true);
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Company Details already Available!')", true);
                        }
                        //Clear();
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
                finally { }
            }
        }

        protected void lnkbtn_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = true;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }

        protected void lnkbtncompany_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = true;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }

        protected void lnkbtnFinance_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = true;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = true;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }

        protected void lnkbtnemail_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = true;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }
      
        protected void lknbtnPayment_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = true;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }

        protected void lnkbtncustomer_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = true;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }
      
        protected void lnkbtntask_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = true;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }

        protected void lnkbtncalender_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = true;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }

        protected void lnkbtnPDF_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = true;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }

        protected void lnkbtncronJob_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = true;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;

        }

        protected void lnkbtnMisc_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = true;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }

        protected void lnkntnsms_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = true;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }

        protected void lnkbtnsign_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = true;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }

        protected void lnkbtntag_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = true;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }

        protected void lnkbtnpushar_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = true;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }

        protected void lnkbtngoogle_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = true;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }

        protected void lnkbtnsubscrip_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = true;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = false;
        }

        protected void lnkbtnsupport_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = true;
            Setting_Leads.Visible = false;
        }

        protected void lnkbtnLeads_Click(object sender, EventArgs e)
        {
            Setting_General.Visible = false;
            Setting_Company.Visible = false;
            Setting_Localization.Visible = false;
            Setting_Email.Visible = false;
            Setting_Finance.Visible = false;
            Setting_Payment_Gateway.Visible = false;
            Setting_Customer.Visible = false;
            Setting_Task.Visible = false;
            Setting_Calender.Visible = false;
            Setting_PDF.Visible = false;
            Cron_Job.Visible = false;
            Setting_MISC.Visible = false;
            Setting_SMS.Visible = false;
            setting_E_sign.Visible = false;
            Setting_Tag.Visible = false;
            Setting_pusher.Visible = false;
            Setting_Goole.Visible = false;
            Setting_subscription.Visible = false;
            Setting_Support.Visible = false;
            Setting_Leads.Visible = true;
        }

        protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Districtid = Convert.ToInt32(ddldistrict.SelectedValue);
                //subcategory bind  @categyid = categoryid

                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetcitybyDistrictid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@District_ID", Districtid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlcity.DataSource = ds.Tables[0];
                    ddlcity.DataTextField = "City";
                    ddlcity.DataValueField = "ID";
                    ddlcity.DataBind();
                    ddlcity.Items.Insert(0, new ListItem("Select City Name", "0"));

                }
                Setting_Company.Visible = true;
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

        protected void ddlState1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Stateid = Convert.ToInt32(ddlState1.SelectedValue);
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetDistrictbyStateid", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@State_ID", Stateid);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddldistrict.DataSource = ds.Tables[0];
                    ddldistrict.DataTextField = "Disttrict_Name";
                    ddldistrict.DataValueField = "District_ID";
                    ddldistrict.DataBind();
                    ddldistrict.Items.Insert(0, new ListItem("Select District Name", "0"));
                }
                Setting_Company.Visible = true;
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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.FileName == "")
                {
                    //upload file for logo
                }
                else
                {
                    string fileName = FileUpload1.FileName;
                    string filemyString = fileName.Substring(0, fileName.Length - 4);


                    if (filemyString == "CompanyDarkLogo")
                    {
                        string folderPath = Server.MapPath("~/Img_logo/");

                        //Check whether Directory (Folder) exists.
                        if (!Directory.Exists(folderPath))
                        {
                            //If Directory (Folder) does not exists Create it.
                            Directory.CreateDirectory(folderPath);
                        }

                        //Save the File to the Directory (Folder).
                        FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));

                        //Display the Picture in Image control.
                        ImgdarkLogo.ImageUrl = "~/Img_logo/" + Path.GetFileName(FileUpload1.FileName);
                        //upload file for logo
                        FileUpload1.Dispose();
                    }
                    else
                    {
                        string folderPath = Server.MapPath("~/Img_logo/");

                        //Check whether Directory (Folder) exists.
                        if (!Directory.Exists(folderPath))
                        {
                            //If Directory (Folder) does not exists Create it.
                            Directory.CreateDirectory(folderPath);
                        }

                        //Save the File to the Directory (Folder).
                        FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));

                        //Display the Picture in Image control.
                        ImgLogo.ImageUrl = "~/Img_logo/" + Path.GetFileName(FileUpload1.FileName);
                        FileUpload1.Dispose();
                    }

                }
            }
            catch(Exception ex)
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
        protected void linkbtngst_Click(object sender, EventArgs e)
        {
            txtcompInfo.Text = txtcompInfo.Text + "\n" + linkbtngst.Text;
        }

        protected void LinkBtncompname_Click(object sender, EventArgs e)
        {
            txtcompInfo.Text = string.Empty;
            //string companyinfo = "{Company_Name}" + "\n" + "{Address}" + "\n" + "{City}" + "\n" + "{State}" + "\n" + "{Zip-Code}" + "\n" + "{Country-Code}" + "\n" + "{Phone}" + "\n" + "{Vat-Number}" + "\n" + "{Vat-Number-With-Lable}";
            txtcompInfo.Text = LinkBtncompname.Text;
        }

        protected void LinkBtnaddress_Click(object sender, EventArgs e)
        {

            //string companyinfo = "{Company_Name}" + "\n" + "{Address}" + "\n" + "{City}" + "\n" + "{State}" + "\n" + "{Zip-Code}" + "\n" + "{Country-Code}" + "\n" + "{Phone}" + "\n" + "{Vat-Number}" + "\n" + "{Vat-Number-With-Lable}";
            txtcompInfo.Text = txtcompInfo.Text + "\n" + LinkBtnaddress.Text;
        }

        protected void linkbtncity_Click(object sender, EventArgs e)
        {
            txtcompInfo.Text = txtcompInfo.Text + "\n" + linkbtncity.Text;
        }

        protected void linkbtnstate_Click(object sender, EventArgs e)
        {
            txtcompInfo.Text = txtcompInfo.Text + "\n" + linkbtnstate.Text;
        }

        protected void btnGSTNOlink_Click(object sender, EventArgs e)
        {
            gstdiv.Visible = true;
            GetCompanyDataByID();
        }

        protected void linkbtnzip_Click(object sender, EventArgs e)
        {
            txtcompInfo.Text = txtcompInfo.Text + "\n" + linkbtnzip.Text;
        }

        protected void linkbtncontrycode_Click(object sender, EventArgs e)
        {
            txtcompInfo.Text = txtcompInfo.Text + "\n" + linkbtncontrycode.Text;
        }

        protected void linkbtnphn_Click(object sender, EventArgs e)
        {
            txtcompInfo.Text = txtcompInfo.Text + "\n" + linkbtnphn.Text;
        }

        protected void linkbtnvat_Click(object sender, EventArgs e)
        {
            txtcompInfo.Text = txtcompInfo.Text + "\n" + linkbtnvat.Text;
        }

        protected void linkbtnlable_Click(object sender, EventArgs e)
        {
            txtcompInfo.Text = txtcompInfo.Text + "\n" + linkbtnlable.Text;
        }

        protected void linkbtnclear_Click(object sender, EventArgs e)
        {
            txtcompInfo.Text = string.Empty;
        }
        #endregion

    }
}