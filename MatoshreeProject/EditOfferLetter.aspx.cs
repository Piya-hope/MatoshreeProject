#region "Class Level"
using System;
using System.Collections.Generic;
using System.Linq;
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
using iText.Kernel.Pdf;
using System.IO.MemoryMappedFiles;
using System.Reflection;
using System.Dynamic;
using Color = System.Drawing.Color;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
//using static MatoshreeProject.ViewLeaveManagement;
using System.Net.Mail;
using System.Net;
using System.ComponentModel;
#endregion

namespace MatoshreeProject
{
    public partial class EditOfferLetter : System.Web.UI.Page
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
        string UserName, EmailID, Designation, RoleType, Permission, DeptID, CareerID, sendMail, EmpNAME;
        Decimal GrandTotal, ComponentTotal, ContributionTotal;
        string DevEmail, DevPassword, DevPort, DevHost;
        string OfferLetterdate;
        string UserEmpName, Password, EmailID1, Designation1;
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
        public DataTable ViewComponent()
        {
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewCandSalaryComp", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cand_No", txtCandNumber.Text);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        GridViewCandComponent.DataSource = ds;
                        GridViewCandComponent.DataBind();                        
                        
                    }
                    else
                    {
                        ds.Rows.Add(ds.NewRow());
                        GridViewCandComponent.DataSource = ds;
                        GridViewCandComponent.DataBind();

                    }
                    return ds;
                }
            }
        }
        public DataTable ViewCandidateDetails()
        {
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewCandSalaryContr", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cand_No", txtCandNumber.Text);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        GridOfferLetter.DataSource = ds;
                        GridOfferLetter.DataBind();
                    }
                    else
                    {
                        ds.Rows.Add(ds.NewRow());
                        GridOfferLetter.DataSource = ds;
                        GridOfferLetter.DataBind();

                    }
                    return ds;

                }

            }

        }
        public DataTable ViewContr()
        {
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewCandSalaryContr", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cand_No", txtCandNumber.Text);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        GridViewCandContr.DataSource = ds;
                        GridViewCandContr.DataBind();                        
                       TotalMonthlyAndAnnualy();
                    }
                    else
                    {
                        ds.Rows.Add(ds.NewRow());
                        GridViewCandContr.DataSource = ds;
                        GridViewCandContr.DataBind();


                    }

                    return ds;
                }

            }

        }    
        public void BindDesignation()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ViewRolesByGroup", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            ddldesignation1.DataSource = ds.Tables[0];
                            ddldesignation1.DataTextField = "RoleName";
                            ddldesignation1.DataBind();
                            ddldesignation1.Items.Insert(0, new ListItem("Select Designation", "0"));
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
        protected void BindDepartement()
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
                    ddldepartement1.DataSource = ds.Tables[0];
                    ddldepartement1.DataTextField = "Dept_Name";
                    ddldepartement1.DataValueField = "Dept_ID";
                    ddldepartement1.DataBind();
                    ddldepartement1.Items.Insert(0, new ListItem("Select Project", "0"));
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
        public void ViewOffered()
        {
            try
            {
                GrandTotal = ComponentTotal + ContributionTotal;
                decimal roundedGrandTot = Math.Round(GrandTotal, 2);
                string Total = roundedGrandTot.ToString();
                lblOfferedTotal.Text = Total.ToString();
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
            ddldepartement1.SelectedIndex = 0;
            ddldesignation1.SelectedIndex = 0;
            txtEmpName.Text = string.Empty;
            txtPackage.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtphoneNo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtClientNote.Text = string.Empty;
            txtTermsAndConditions.Text = string.Empty;
            txtCandNumber.Text = string.Empty;
            ddlClass1.SelectedIndex = 0;
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
                    lbladdress11.Text = dt.Rows[0]["Address"].ToString();
                    lblcompanyaddCity1.Text = dt.Rows[0]["City"].ToString() + ",";
                    lblcompanyaddDistrict1.Text = dt.Rows[0]["District"].ToString() + ",";
                    lblcompanyaddState1.Text = dt.Rows[0]["State"].ToString() + ",";
                    lblcompanyaddCountry1.Text = "India" + ",";
                    lblcompanyaddZIPCode11.Text = dt.Rows[0]["Zip_Code"].ToString() + ",";
                    lblphoneNo1.Text = dt.Rows[0]["Phone"].ToString() + ",";
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
        public void GetCondidateDetails()
        {
            try
            {
                string CandidateID;
                CandidateID = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                lblCandidateId.Text = CandidateID;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_ViewCandidateDetailsById", UserCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@id", lblCandidateId.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ddlClass1.SelectedItem.Text = dt.Rows[0]["ClassName"].ToString();
                        txtCandNumber.Text = dt.Rows[0]["Cand_No"].ToString();
                        txtAddress.Text = dt.Rows[0]["Cand_Address"].ToString();
                        txtEmpName.Text = dt.Rows[0]["Cand_Name"].ToString();
                        txtPackage.Text = dt.Rows[0]["Package"].ToString();
                        txtphoneNo.Text = dt.Rows[0]["Cand_PhoneNo"].ToString();
                        txtEmail.Text = dt.Rows[0]["Cand_EmailID"].ToString();
                        ddldepartement1.SelectedItem.Text = dt.Rows[0]["Cand_Department"].ToString();
                        ddldesignation1.SelectedItem.Text = dt.Rows[0]["Cand_Designation"].ToString();
                        txtTermsAndConditions.Text = dt.Rows[0]["TermsAndCondition"].ToString();
                        txtClientNote.Text = dt.Rows[0]["Note"].ToString();
                        lblOfferedTotal.Text = dt.Rows[0]["GrandTotal"].ToString();
                        OfferLetterdate = dt.Rows[0]["Createdate"].ToString();
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
            finally
            {
            }
        }
        public void TotalMonthlyAndAnnualy()
        {
            try
            {
                Decimal AnnualSalary = Convert.ToDecimal(txtPackage.Text);
                Decimal MonthlySalary = AnnualSalary / 12;
                Decimal Amount, AmountAnnual, Percentage, basicSalaryAmount = 0, m = 0, n = 0, m1 = 0;
                SqlConnection UserCon = new SqlConnection(strconnect);
                foreach (GridViewRow gridviedrow in GridViewCandComponent.Rows)
                {
                    Label lblCandComponentID = (Label)gridviedrow.FindControl("lblCompPerCatId");
                    Label lblCandCompnent1 = (Label)gridviedrow.FindControl("lblComppert");
                    Label lblPercentage1 = (Label)gridviedrow.FindControl("lblCompPercentage");
                    Label lblmonthlyAmount1 = (Label)gridviedrow.FindControl("lblMonthlyAmtComp");
                    Label lblAmountYr1 = (Label)gridviedrow.FindControl("lblCompAnnAmtComp");//AnnualComponent
                    Label lblMonthlyTotalAmount2 = GridViewCandComponent.FooterRow.FindControl("lblMntAmtCompFtr") as Label;
                    Label lblAmountYr2 = GridViewCandComponent.FooterRow.FindControl("lblAnnAmtCompftr") as Label;//AnnualComponentTotal
                    Percentage = Convert.ToDecimal(lblPercentage1.Text);
                    string component1 = lblCandCompnent1.Text;
                    Amount = MonthlySalary * (Percentage / 100);
                    decimal roundedMonthSal = Math.Round(Amount, 2);
                    lblmonthlyAmount1.Text = Convert.ToString(roundedMonthSal);
                    AmountAnnual = AnnualSalary * (Percentage / 100);
                    decimal roundedYearSal = Math.Round(AmountAnnual, 2);
                    lblAmountYr1.Text = Convert.ToString(roundedYearSal);
                    if (lblCandCompnent1.Text == "Basic")
                    {
                        basicSalaryAmount = AmountAnnual;
                    }
                    m = m + Decimal.Parse(lblmonthlyAmount1.Text);
                    decimal roundedMonthTot = Math.Round(m, 2);
                    lblMonthlyTotalAmount2.Text = Convert.ToString(roundedMonthTot);
                    m1 = m1 + Decimal.Parse(lblAmountYr1.Text);
                    decimal roundedYearTot = Math.Round(m1, 2);
                    lblAmountYr2.Text = Convert.ToString(roundedYearTot);
                    ComponentTotal = Convert.ToDecimal(lblAmountYr2.Text);
                }

                foreach (GridViewRow gridviedrow in GridViewCandContr.Rows)
                {
                    Label lblComponentsID1 = (Label)gridviedrow.FindControl("lblContrPerID"); 
                    Label lblCompnents1 = (Label)gridviedrow.FindControl("lblContrPert");
                    Label lblPercentages1 = (Label)gridviedrow.FindControl("lblContrPer");
                    Label lblAmounts2 = GridViewCandContr.FooterRow.FindControl("lblContrAnnAmtFtr") as Label;
                    Label lblAmounts1 = (Label)gridviedrow.FindControl("lblContrAnnAmt");
                    Percentage = Convert.ToDecimal(lblPercentages1.Text);

                    AmountAnnual = basicSalaryAmount * (Percentage / 100);
                    decimal roundedCompSal = Math.Round(AmountAnnual, 2);
                    lblAmounts1.Text = Convert.ToString(roundedCompSal);

                    n = n + Decimal.Parse(lblAmounts1.Text);
                    decimal roundedCompAmt = Math.Round(n, 2);
                    lblAmounts2.Text = Convert.ToString(roundedCompAmt);

                    ContributionTotal = Convert.ToDecimal(lblAmounts2.Text);

                    ViewOffered();
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
        protected void bindClass()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetEmpSalaryClass", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            ddlClass1.DataSource = ds.Tables[0];
                            ddlClass1.DataTextField = "ClassName";
                            ddlClass1.DataValueField = "ID";
                            ddlClass1.DataBind();
                            ddlClass1.Items.Insert(0, new ListItem("Select Class", "0"));
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

        #endregion

        #region  " Event"
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
                            BindDesignation();
                            BindDepartement();
                            bindClass();
                            GetCondidateDetails();
                            ViewComponent();
                            GetCompanyAddress();
                            ViewContr();
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
                                BindDesignation();
                                BindDepartement();
                                bindClass();
                                GetCondidateDetails();
                                ViewComponent();
                                GetCompanyAddress();
                                ViewContr();
                            }
                        }
                        else
                        {

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

        protected void btnCalculateStructure_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal AnnualSalary = Convert.ToDecimal(txtPackage.Text);
                Decimal MonthlySalary = AnnualSalary / 12;
                Decimal Amount, AmountAnnual, Percentage, basicSalaryAmount = 0, m = 0, n = 0, m1 = 0;
                SqlConnection UserCon = new SqlConnection(strconnect);
                foreach (GridViewRow gridviedrow in GridViewCandComponent.Rows)
                {
                    Label lblCandComponentID = (Label)gridviedrow.FindControl("lblCompPerCatId");
                    Label lblCandCompnent1 = (Label)gridviedrow.FindControl("lblComppert");
                    Label lblPercentage1 = (Label)gridviedrow.FindControl("lblCompPercentage");
                    Label lblmonthlyAmount1 = (Label)gridviedrow.FindControl("lblMonthlyAmtComp");
                    Label lblAmountYr1 = (Label)gridviedrow.FindControl("lblCompAnnAmtComp");//AnnualComponent
                    Label lblMonthlyTotalAmount2 = GridViewCandComponent.FooterRow.FindControl("lblMntAmtCompFtr") as Label;
                    Label lblAmountYr2 = GridViewCandComponent.FooterRow.FindControl("lblAnnAmtComp") as Label;//AnnualComponentTotal
                    Percentage = Convert.ToDecimal(lblPercentage1.Text);
                    string component1 = lblCandCompnent1.Text;
                    Amount = MonthlySalary * (Percentage / 100);
                    decimal roundedMonthSal = Math.Round(Amount, 2);
                    lblmonthlyAmount1.Text = Convert.ToString(roundedMonthSal);
                    AmountAnnual = AnnualSalary * (Percentage / 100);
                    decimal roundedYearSal = Math.Round(AmountAnnual, 2);
                    lblAmountYr1.Text = Convert.ToString(roundedYearSal);
                    if (lblCandCompnent1.Text == "Basic")
                    {
                        basicSalaryAmount = AmountAnnual;
                    }
                    m = m + Decimal.Parse(lblmonthlyAmount1.Text);
                    decimal roundedMonthTot = Math.Round(m, 2);
                    lblMonthlyTotalAmount2.Text = Convert.ToString(roundedMonthTot);
                    m1 = m1 + Decimal.Parse(lblAmountYr1.Text);
                    decimal roundedYearTot = Math.Round(m1, 2);
                    lblAmountYr2.Text = Convert.ToString(roundedYearTot);
                    ComponentTotal = Convert.ToDecimal(lblAmountYr2.Text);
                }

                foreach (GridViewRow gridviedrow in GridViewCandContr.Rows)
                {
                    Label lblComponentsID1 = (Label)gridviedrow.FindControl("lblContrPerID");
                    Label lblCompnents1 = (Label)gridviedrow.FindControl("lblContrPert");
                    Label lblPercentages1 = (Label)gridviedrow.FindControl("lblContrPer");
                    Label lblAmounts2 = GridViewCandContr.FooterRow.FindControl("lblContrAnnAmtFtr") as Label;
                    Label lblAmounts1 = (Label)gridviedrow.FindControl("lblContrAnnAmt");
                    Percentage = Convert.ToDecimal(lblPercentages1.Text);

                    AmountAnnual = basicSalaryAmount * (Percentage / 100);
                    decimal roundedCompSal = Math.Round(AmountAnnual, 2);
                    lblAmounts1.Text = Convert.ToString(roundedCompSal);

                    n = n + Decimal.Parse(lblAmounts1.Text);
                    decimal roundedCompAmt = Math.Round(n, 2);
                    lblAmounts2.Text = Convert.ToString(roundedCompAmt);

                    ContributionTotal = Convert.ToDecimal(lblAmounts2.Text);

                    ViewOffered();
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
        protected void btnClearStructure_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //Save Candidate Salary Total
                using (SqlConnection con2 = new SqlConnection(strconnect))
                {                  
                    SqlCommand cmd2 = new SqlCommand("SP_UpdateCandSalaryTotal", con2);
                    cmd2.Connection = con2;
                    cmd2.CommandType = CommandType.StoredProcedure;
                    Label lblAnnualComp = GridViewCandComponent.FooterRow.FindControl("lblAnnAmtCompftr") as Label; //TotalComponentAnnualAmount
                    Label lblMonthlyComp = GridViewCandComponent.FooterRow.FindControl("lblMntAmtCompFtr") as Label;//TotalComponentMonthlyAmount
                    Label lblAnnualyEmp = GridViewCandContr.FooterRow.FindControl("lblContrAnnAmtFtr") as Label;//TotalContributionAnnualAmount
                   
                    decimal totalMonthlyEmployeer = 0;
                    if (decimal.TryParse(lblAnnualyEmp.Text, out totalMonthlyEmployeer))
                    {                        
                        totalMonthlyEmployeer /= 2;               //Total Contribution Monthly Amount=totalMonthlyEmployeer
                    }
                    cmd2.Parameters.AddWithValue("@ID", lblCandidateId.Text);
                    cmd2.Parameters.AddWithValue("@Cand_Name", txtEmpName.Text);
                    cmd2.Parameters.AddWithValue("@Cand_Designation", ddldesignation1.SelectedItem.Text);
                    cmd2.Parameters.AddWithValue("@Cand_Department", ddldepartement1.SelectedItem.Text);
                    cmd2.Parameters.AddWithValue("@Cand_EmailID", txtEmail.Text);
                    cmd2.Parameters.AddWithValue("@Package", txtPackage.Text);
                    cmd2.Parameters.AddWithValue("@TotalAnnualyComp", lblAnnualComp.Text);
                    cmd2.Parameters.AddWithValue("@TotalMonthlyComp", lblMonthlyComp.Text);
                    cmd2.Parameters.AddWithValue("@TotalAnnualyEmp", lblAnnualyEmp.Text);
                    cmd2.Parameters.AddWithValue("@TotalMonthlyEmp", totalMonthlyEmployeer.ToString());
                    cmd2.Parameters.AddWithValue("@GrandTotal", lblOfferedTotal.Text);
                    cmd2.Parameters.AddWithValue("@Createby", UserName);
                    cmd2.Parameters.AddWithValue("@EmpID", UserId);
                    cmd2.Parameters.AddWithValue("@PhoneNo", txtphoneNo.Text);
                    cmd2.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd2.Parameters.AddWithValue("@Status", "true");
                    cmd2.Parameters.AddWithValue("@Designation", Designation);
                    cmd2.Parameters.AddWithValue("@TermsCondition", txtTermsAndConditions.Text);
                    cmd2.Parameters.AddWithValue("@Note", txtClientNote.Text);
                    cmd2.Parameters.AddWithValue("@ClassID", ddlClass1.SelectedItem.Value);
                    con2.Open();
                    int i = cmd2.ExecuteNonQuery();
                    if (i < 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Candidate Details Update Successfully !')", true);
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Candidate Details Not Update Successfully !')", true);
                    }
                    con2.Close();
                }

                //Save Candidate Salary Component

                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    foreach (GridViewRow gridviedrow in GridViewCandComponent.Rows)
                    {
                        Label lblPerCatID = (Label)gridviedrow.FindControl("lblPerCatId");
                        Label lblCandCompnent1 = (Label)gridviedrow.FindControl("lblComppert");
                        Label lblPercentage1 = (Label)gridviedrow.FindControl("lblCompPercentage");
                        Label lblmonthlyAmount1 = (Label)gridviedrow.FindControl("lblMonthlyAmtComp");
                        Label lblAmountYr1 = (Label)gridviedrow.FindControl("lblCompAnnAmtComp");//AnnualComponent
                        Label lblID = (Label)gridviedrow.FindControl("lblCompId"); 
                        
                        SqlCommand cmd = new SqlCommand("SP_UpdateCandSalaryComponent", con);

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", lblCandidateId.Text);
                        cmd.Parameters.AddWithValue("@CandName", txtEmpName.Text);
                        cmd.Parameters.AddWithValue("@CandDesignation", ddldesignation1.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@PerCATID", lblPerCatID.Text);
                        cmd.Parameters.AddWithValue("@Category", lblCandCompnent1.Text);
                        cmd.Parameters.AddWithValue("@Percentage", lblPercentage1.Text);
                        cmd.Parameters.AddWithValue("@MonthlyAmount", lblmonthlyAmount1.Text);
                        cmd.Parameters.AddWithValue("@AnnualAmount", lblAmountYr1.Text);
                        cmd.Parameters.AddWithValue("@Status", "true");
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Createby", UserName);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@ClassID", ddlClass1.SelectedItem.Value);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i < 0)
                        {
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Update Candidate Details!')", true);
                        }


                        else
                        {

                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Candidate Details not Update successfully!')", true);
                        }

                        con.Close();
                    }
                }

                //Save Candidate Salary Contribution
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {

                    foreach (GridViewRow gvrow in GridViewCandContr.Rows)
                    {
                        Label lblComponentsID1 = (Label)gvrow.FindControl("lblContrPerID");
                        Label lblCompnents1 = (Label)gvrow.FindControl("lblContrPert");
                        Label lblPercentages1 = (Label)gvrow.FindControl("lblContrPer");
                        Label lblAmounts1 = (Label)gvrow.FindControl("lblContrAnnAmt");

                        SqlCommand cmd1 = new SqlCommand("SP_UpdateCandSalaryContribution", con1);
                        cmd1.Connection = con1;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@Id", lblCandidateId.Text);
                        cmd1.Parameters.AddWithValue("@CandName", txtEmpName.Text);
                        cmd1.Parameters.AddWithValue("@candDesignation", lblDesignation.Text);
                        cmd1.Parameters.AddWithValue("@PerCATID", lblComponentsID1.Text);
                        cmd1.Parameters.AddWithValue("@Category", lblCompnents1.Text);
                        cmd1.Parameters.AddWithValue("@Percentage", lblPercentages1.Text);
                        cmd1.Parameters.AddWithValue("@AnnualAmount", lblAmounts1.Text);
                        cmd1.Parameters.AddWithValue("@Status", "true");
                        cmd1.Parameters.AddWithValue("@EmpID", UserId);
                        cmd1.Parameters.AddWithValue("@Createby", UserName);
                        cmd1.Parameters.AddWithValue("@Designation", Designation);
                        cmd1.Parameters.AddWithValue("@ClassID", ddlClass1.SelectedItem.Value);
                        con1.Open();
                        int i = cmd1.ExecuteNonQuery();
                        if (i < 0)
                        {
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Update Candidate Details!')", true);
                        }

                        else
                        {
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Candidate Details not Update successfully!')", true);
                        }

                        con1.Close();

                    }
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
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
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

        protected void lnkbtnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                int _totalColumns = 5;
                int _totalColumns1 = 5;             
                string path = Image1.ImageUrl;
                Font _fontStyle;                
                PdfPTable _pdfPTable = new PdfPTable(5);//change
                PdfPTable _pdfPTable1 = new PdfPTable(5);

                PdfPCell _pdfPCell;
                PdfPCell cell = null;

                Document _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
                _document.SetPageSize(PageSize.A4);
                _document.SetMargins(20f, 20f, 20f, 20f);
                _pdfPTable.WidthPercentage = 500;
                _pdfPTable.TotalWidth = 500f;
                _pdfPTable.LockedWidth = true;
                _pdfPTable.HorizontalAlignment = Element.ALIGN_CENTER;
                _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();

                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(_document, memoryStream);
                _document.Open();
                _pdfPTable.SetWidths(new float[] { 3f, 9f, 9f, 9f, 9f });//column width in doc                                                                                //----Header PDF--------------------------//                                                                         //Company Logo
                _pdfPTable1.SetWidths(new float[] { 3f, 9f, 9f, 9f, 9f });
                cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                cell.Colspan = 3;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPTable.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk(lbladdCompany11.Text + "\n", FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK)));
                phrase.Add(new Chunk(lbladdress11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                phrase.Add(new Chunk(lblcompanyaddCity1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                phrase.Add(new Chunk(lblcompanyaddDistrict1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                phrase.Add(new Chunk(lblcompanyaddState1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                phrase.Add(new Chunk(lblcompanyaddCountry1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                _pdfPCell = new PdfPCell(phrase);

                _pdfPCell = new PdfPCell(phrase);
                _pdfPCell.Colspan = 3;
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
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 5;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 2;
                _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                //----------------------CandidateNumber--------------//
                _fontStyle = FontFactory.GetFont("Arial", 11f, 2);
                _pdfPCell = new PdfPCell(new Phrase(txtCandNumber.Text, _fontStyle));
                _pdfPCell.Colspan = 2;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPCell.PaddingRight = 40f;
                _pdfPCell.PaddingTop = 15f;
                _pdfPTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPCell.PaddingRight = 40f;
                _pdfPCell.PaddingTop = 15f;
                _pdfPTable.AddCell(_pdfPCell);

                //----------------------Date----------------------//
                DateTime PrintTime = DateTime.Now;
                _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                _pdfPCell.Colspan = 2;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 3;
                _pdfPCell.PaddingTop = 15f;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                _pdfPCell = new PdfPCell(new Phrase("Candidate Offer Letter", _fontStyle));
                _pdfPCell.Colspan = 5;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPCell.PaddingRight = 40f;
                _pdfPCell.PaddingTop = 15f;
                _pdfPTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                _pdfPCell = new PdfPCell(new Phrase("------------------------*------------------------", _fontStyle));
                _pdfPCell.Colspan = 5;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPCell.PaddingBottom = 5f;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();
                #region  "Candidates Details"
                //-----------------------------Candidate Details-----------------------------------//
                _fontStyle = FontFactory.GetFont("Arial", 12f, Font.BOLD, BaseColor.BLACK);
                _pdfPCell = new PdfPCell(new Phrase("To,", _fontStyle));
                _pdfPCell.Colspan = 5;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase(txtEmpName.Text, _fontStyle));              
                _pdfPCell.Colspan = 5;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                //_fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                //_pdfPCell = new PdfPCell(new Phrase("Address: " + txtAddress.Text, _fontStyle));
                //_pdfPCell.Colspan = 5;
                //_pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                //_pdfPCell.Border = 0;
                //_pdfPCell.BackgroundColor = BaseColor.WHITE;
                //_pdfPCell.ExtraParagraphSpace = 4;
                //_pdfPTable.AddCell(_pdfPCell);
                //_pdfPTable.CompleteRow();

                //_fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                //_pdfPCell = new PdfPCell(new Phrase("Contact No:" + txtphoneNo.Text, _fontStyle));
                ////_pdfPCell = new PdfPCell(new Phrase(ddldepartement1.SelectedItem.Text, _fontStyle));
                //_pdfPCell.Colspan = 5;
                //_pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                //_pdfPCell.Border = 0;
                //_pdfPCell.BackgroundColor = BaseColor.WHITE;
                //_pdfPCell.ExtraParagraphSpace = 4;
                //_pdfPTable.AddCell(_pdfPCell);
                //_pdfPTable.CompleteRow();

                //---------------------Email And Designation------------------//
                //_fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                //_pdfPCell = new PdfPCell(new Phrase(txtEmail.Text, _fontStyle));
                ////_pdfPCell = new PdfPCell(new Phrase(txtEmail.Text, _fontStyle));
                //_pdfPCell.Colspan = 5;
                //_pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                //_pdfPCell.Border = 0;
                //_pdfPCell.BackgroundColor = BaseColor.WHITE;
                //_pdfPCell.ExtraParagraphSpace = 4;
                //_pdfPTable.AddCell(_pdfPCell);
                //_pdfPTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Arial", 12f, Font.BOLD, BaseColor.BLACK);
                _pdfPCell = new PdfPCell(new Phrase("  ", _fontStyle));
                _pdfPCell.Colspan = 2;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Arial", 12f, Font.BOLD, BaseColor.BLACK);
                _pdfPCell = new PdfPCell(new Phrase("Subject: Offer of Employment ", _fontStyle));
                _pdfPCell.Colspan = 3;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);


           
                _pdfPTable.CompleteRow();

                //-----------------------Dear-----------------------//

                _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase("Dear" + " " + txtEmpName.Text + ",", _fontStyle));
                _pdfPCell.Colspan = 5;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 5;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                //------------------------Paragraph-----------------------------//

                _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase("We are pleased to offer you employment with " + lbladdCompany11.Text +
   "This offer is based on your profile and performance in the selection" +
   " process. You have been selected for the position of " + ddldesignation1.SelectedItem.Text +
   "which will commence on" + OfferLetterdate +
   ",  Attached are the specific terms and conditions " +
   "of our offer. Please read these important details carefully,including your benefits" +
   "and compensation", _fontStyle));
                _pdfPCell.Colspan = 5;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 5;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Arial", 10f, Font.BOLD, BaseColor.BLACK);
                _pdfPCell = new PdfPCell(new Phrase("TERMS AND CONDITIONS:", _fontStyle));
                _pdfPCell.Colspan = 5;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase(txtTermsAndConditions.Text, _fontStyle));
                _pdfPCell.Colspan = 5;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 5;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 5;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();
                _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 6;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow(); _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 6;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();
                _fontStyle = FontFactory.GetFont("Arial", 12f, Font.BOLD, BaseColor.BLACK);
                _pdfPCell = new PdfPCell(new Phrase("Component:", _fontStyle));
                _pdfPCell.Colspan = _totalColumns;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPCell.PaddingBottom = 10f;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();
              
              
                #endregion
                //-------------------------------Table1---------------------////
                DataTable _Vhrlist = new DataTable();
                _Vhrlist = ViewComponent();

                #region "Table Header"
                _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                _pdfPCell = new PdfPCell(new Phrase("Serial No", _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.GRAY;
                _pdfPCell.ExtraParagraphSpace = 2;
                _pdfPTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                _pdfPCell = new PdfPCell(new Phrase("Category", _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.GRAY;
                _pdfPCell.ExtraParagraphSpace = 2;
                _pdfPTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                _pdfPCell = new PdfPCell(new Phrase("Percentage", _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.GRAY;
                _pdfPCell.ExtraParagraphSpace = 2;
                _pdfPTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                _pdfPCell = new PdfPCell(new Phrase("MonthlyAmount", _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.GRAY;
                _pdfPCell.ExtraParagraphSpace = 2;
                _pdfPTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                _pdfPCell = new PdfPCell(new Phrase("AnnualAmount", _fontStyle));
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

                    _pdfPCell = new PdfPCell(new Phrase(row["Category"].ToString(), _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 1;
                    _pdfPTable.AddCell(_pdfPCell);

                    _pdfPCell = new PdfPCell(new Phrase(row["Percentage"].ToString(), _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 1;
                    _pdfPTable.AddCell(_pdfPCell);

                    _pdfPCell = new PdfPCell(new Phrase(row["MonthlyAmount"].ToString(), _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 1;
                    _pdfPTable.AddCell(_pdfPCell);

                    _pdfPCell = new PdfPCell(new Phrase(row["AnnualAmount"].ToString(), _fontStyle));
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


                _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 6;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                //----------------------------------Table2----------------------------------////

                _fontStyle = FontFactory.GetFont("Arial", 12f, Font.BOLD, BaseColor.BLACK);
                _pdfPCell = new PdfPCell(new Phrase("Employee Contribution:", _fontStyle));
                _pdfPCell.Colspan = _totalColumns1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPCell.PaddingBottom = 10f;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();


                _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 6;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();


                DataTable _Vhrlist1 = new DataTable();
                _Vhrlist1 = ViewContr();

                #region "Table Header"

                _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                _pdfPCell = new PdfPCell(new Phrase("Serial No", _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.GRAY;
                _pdfPCell.ExtraParagraphSpace = 2;
                _pdfPTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                _pdfPCell = new PdfPCell(new Phrase("Category", _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.GRAY;
                _pdfPCell.ExtraParagraphSpace = 2;
                _pdfPTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                _pdfPCell = new PdfPCell(new Phrase("Percentage", _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.GRAY;
                _pdfPCell.ExtraParagraphSpace = 2;
                _pdfPTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                _pdfPCell = new PdfPCell(new Phrase("MonthlyAmount", _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.GRAY;
                _pdfPCell.ExtraParagraphSpace = 2;
                _pdfPTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                _pdfPCell = new PdfPCell(new Phrase("AnnualAmount", _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.GRAY;
                _pdfPCell.ExtraParagraphSpace = 2;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPTable.CompleteRow();
                #endregion

                #region "Table Body"
                _fontStyle = FontFactory.GetFont("Tahoma", 10f, 0);
                int serialnumber1 = 1;

                foreach (DataRow row in _Vhrlist1.Rows)
                {
                    _pdfPCell = new PdfPCell(new Phrase(serialnumber++.ToString(), _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 1;
                    _pdfPTable.AddCell(_pdfPCell);

                    _pdfPCell = new PdfPCell(new Phrase(row["Category"].ToString(), _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 1;
                    _pdfPTable.AddCell(_pdfPCell);

                    _pdfPCell = new PdfPCell(new Phrase(row["Percentage"].ToString(), _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 1;
                    _pdfPTable.AddCell(_pdfPCell);

                    _pdfPCell = new PdfPCell(new Phrase(row["MonthlyAmount"].ToString(), _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 1;
                    _pdfPTable.AddCell(_pdfPCell);

                    _pdfPCell = new PdfPCell(new Phrase(row["AnnualAmount"].ToString(), _fontStyle));
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.ExtraParagraphSpace = 1;
                    _pdfPTable.AddCell(_pdfPCell);
                }
                #endregion

                #region "Table Footer"
                String text1 = "Page " + writer.PageNumber + " of ";
                BaseFont bf1 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                PdfContentByte cb1 = writer.DirectContent;
                PdfTemplate footerTemplate1 = cb1.CreateTemplate(40, 40);

                //Move the pointer and draw line to separate footer section from rest of page  
                cb1.MoveTo(40, _document.PageSize.GetBottom(40));
                cb1.LineTo(_document.PageSize.Width - 40, _document.PageSize.GetBottom(40));
                cb1.Stroke();

                cb1.BeginText();
                cb1.SetFontAndSize(bf1, 9);
                cb1.SetTextMatrix(_document.PageSize.GetRight(100), _document.PageSize.GetBottom(30));
                cb1.ShowText(text1);
                cb1.EndText();
                float len1 = bf1.GetWidthPoint(text, 9);
                cb1.AddTemplate(footerTemplate1, _document.PageSize.GetRight(100) + len1, _document.PageSize.GetBottom(30));

                footerTemplate1.BeginText();
                footerTemplate1.SetFontAndSize(bf, 9);
                footerTemplate1.SetTextMatrix(0, 0);
                footerTemplate1.ShowText((writer.PageNumber - 1).ToString());
                footerTemplate1.EndText();

                #endregion

                _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 6;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                //------------------Note-----------------------//
                _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase("Note", _fontStyle));
                _pdfPCell.Colspan = 6;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase(txtClientNote.Text, _fontStyle));
                _pdfPCell.Colspan = 6;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                //------------------Paragraph 2-----------------------//                
                _fontStyle = FontFactory.GetFont("Arial", 10f, 2);
                _pdfPCell = new PdfPCell(new Phrase("Please sign the duplicate copy of this letter in token of acceptance of the same to us for our \r\nrecord. Your signing this appointment letter confirms your acceptance of the terms and" +
                    " conditions \r\nand that you would be joining Lissom Technologies on the given date. \r\nThanking you,\r\n", _fontStyle));
                _pdfPCell.Colspan = 6;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 4;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();

                #region "Table Footer"

                String text11 = "Page " + writer.PageNumber + " of ";
                BaseFont bf11 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                PdfContentByte cb11 = writer.DirectContent;
                PdfTemplate footerTemplate11 = cb11.CreateTemplate(40, 40);
                //Move the pointer and draw line to separate footer section from rest of page  
                cb11.MoveTo(40, _document.PageSize.GetBottom(40));
                cb11.LineTo(_document.PageSize.Width - 40, _document.PageSize.GetBottom(40));
                cb11.Stroke();

                cb11.BeginText();
                cb11.SetFontAndSize(bf11, 9);
                cb11.SetTextMatrix(_document.PageSize.GetRight(100), _document.PageSize.GetBottom(30));
                cb11.ShowText(text11);
                cb11.EndText();
                float len11 = bf11.GetWidthPoint(text11, 9);
                cb11.AddTemplate(footerTemplate11, _document.PageSize.GetRight(100) + len11, _document.PageSize.GetBottom(30));
                footerTemplate11.BeginText();
                footerTemplate11.SetFontAndSize(bf11, 9);
                footerTemplate11.SetTextMatrix(0,0);
                footerTemplate11.ShowText((writer.PageNumber - 1).ToString());
                footerTemplate11.EndText();

                //-------------------- PDF Generation------------------------------------//
                _pdfPTable.HeaderRows = 1; //header method
                _document.Add(_pdfPTable);

                // Add an empty paragraph for spacing
                _document.Add(new Paragraph("\n"));
                _pdfPTable1.HeaderRows = 1;
                _document.Add(_pdfPTable1);

                _document.Close();
                byte[] bytes = memoryStream.ToArray();
                DateTime dTime = DateTime.Now;

                string PDFFileName = string.Format(txtEmpName.Text + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + PDFFileName);
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();

                #endregion
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

        protected void ddlClass1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ViewComponent();
                ViewContr();
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
    }
}