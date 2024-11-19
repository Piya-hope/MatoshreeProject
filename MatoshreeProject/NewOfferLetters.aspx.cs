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
using System.Net.Mail;
using System.Net;
using System.ComponentModel;
#endregion

namespace MatoshreeProject
{

    public partial class NewOfferLetters : System.Web.UI.Page
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
        string Day = Convert.ToString(DateTime.Today.Day);
        string year = Convert.ToString(DateTime.Today.Year);
        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID, CareerID, sendMail, EmpNAME;
        Decimal GrandTotal, ComponentTotal, ContributionTotal;
        string DevEmail, DevPassword, DevPort, DevHost;
        string UserEmpName, Password, EmailID1, Designation1;
        string Size, Initial, ReceiptFor, Cash, Bank, reminder;
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
        private string generateOrderNo(string code, long id)
        {
            string oID = code;
            string space = "-";
            oID += space + id.ToString("00000");

            return oID;
        }
        public string GETReceiptINITIAL()
        {
            SqlConnection conn = new SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand("SP_GeReceriptInitial", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReceiptFor", "CandOfferLetter");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ReceiptFor = dt.Rows[0]["ReceiptFor"].ToString();
                Initial = dt.Rows[0]["Initial"].ToString();
                Size = dt.Rows[0]["size"].ToString();
                lblInitialNumber.Text = year + "-" + Day + ":";
                Initial = lblInitialNumber.Text + Initial;

            }
            return generateOrderNo(Initial, long.Parse(Size));
        }
        public DataTable ViewComponent()
        {
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewCandAnnualSalStructure", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PertCate_ID", "1");
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        GridViewComponent.DataSource = ds;
                        GridViewComponent.DataBind();

                        foreach (GridViewRow gridviedrow in GridViewComponent.Rows)
                        {
                            LinkButton btnDeleteAnnualSal = (LinkButton)gridviedrow.FindControl("btnDeleteAnnualSal");

                            btnDeleteAnnualSal.Visible = true;
                        }
                    }
                    else
                    {
                        ds.Rows.Add(ds.NewRow());
                        GridViewComponent.DataSource = ds;
                        GridViewComponent.DataBind();

                    }
                    return ds;
                }
            }
        }
      
        public void ViewEmpCompansion()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ViewEmpCompansion", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PertCate_ID", "2");
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable ds = new DataTable();
                        sda.Fill(ds);
                        if (ds.Rows.Count > 0)
                        {
                            GridViewEmpCompansion.DataSource = ds;
                            GridViewEmpCompansion.DataBind();
                            foreach (GridViewRow gridviedrow in GridViewEmpCompansion.Rows)
                            {
                                LinkButton btnDeleteAnnualComp = (LinkButton)gridviedrow.FindControl("btnDeleteAnnualComp");

                                btnDeleteAnnualComp.Visible = true;
                            }
                        }
                        else
                        {
                            ds.Rows.Add(ds.NewRow());
                            GridViewEmpCompansion.DataSource = ds;
                            GridViewEmpCompansion.DataBind();
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

        public void ComponentPerTotal()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GettotalCategoryonpercentage", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PertCate_ID", "1");

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

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

        public void CompansionPerTotal()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GettotalCategoryonpercentage", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PertCate_ID", "2");

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

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
                    ddldepartement1.Items.Insert(0, new ListItem("Select Departement", "0"));
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
        }
        public void GetCompanytermsAndCondition()
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_ViewTermAndCondition", UserCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtTermsAndConditions.Text = dt.Rows[0]["TermsAndCondition"].ToString();
                        txtClientNote.Text = dt.Rows[0]["Note"].ToString();
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

        #endregion

        #region  "Event"
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
                            string ReceiptNumner = GETReceiptINITIAL();
                            txtCandNumber.Text = ReceiptNumner;
                            GetCompanytermsAndCondition();
                            BindDesignation();
                            BindDepartement();
                            ViewComponent();
                            ViewEmpCompansion();
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
                                string ReceiptNumner = GETReceiptINITIAL();
                                txtCandNumber.Text = ReceiptNumner;
                                GetCompanytermsAndCondition();
                                BindDesignation();
                                BindDepartement();
                                ViewComponent();
                                ViewEmpCompansion();
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

        protected void btnClearStructure_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btnCalculateStructure_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal AnnualSalary = Convert.ToDecimal(txtPackage.Text);
                Decimal MonthlySalary = AnnualSalary / 12;

                Decimal Amount, AmountAnnual, Percentage, basicSalaryAmount = 0, m = 0, n = 0, m1 = 0;
                SqlConnection UserCon = new SqlConnection(strconnect);
                foreach (GridViewRow gridviedrow in GridViewComponent.Rows)
                {
                    Label lblID = (Label)gridviedrow.FindControl("lblID");
                    Label lblComponentID = (Label)gridviedrow.FindControl("lblComponentID");
                    Label lblCompnent1 = (Label)gridviedrow.FindControl("lblCompnent1");
                    Label lblPercentage1 = (Label)gridviedrow.FindControl("lblPercentage1");
                    Label lblAmount1 = (Label)gridviedrow.FindControl("lblAmount1");
                    Label lblAmountYr1 = (Label)gridviedrow.FindControl("lblAmountYr1");
                    Label lblAmount2 = GridViewComponent.FooterRow.FindControl("lblAmount2") as Label;
                    Label lblAmountYr2 = GridViewComponent.FooterRow.FindControl("lblAmountYr2") as Label;
                    // Label lblTotalMonthlyComp1 = GridViewComponent.FooterRow.FindControl("lblTotalMonthlyComp1") as Label;
                    Percentage = Convert.ToDecimal(lblPercentage1.Text);
                    string component1 = lblCompnent1.Text;

                    Amount = MonthlySalary * (Percentage / 100);
                    decimal roundedMonthSal = Math.Round(Amount, 2);
                    lblAmount1.Text = Convert.ToString(roundedMonthSal);

                    AmountAnnual = AnnualSalary * (Percentage / 100);
                    decimal roundedYearSal = Math.Round(AmountAnnual, 2);
                    lblAmountYr1.Text = Convert.ToString(roundedYearSal);

                    if (lblCompnent1.Text == "Basic")
                    {
                        basicSalaryAmount = AmountAnnual;
                    }

                    m = m + Decimal.Parse(lblAmount1.Text);
                    decimal roundedMonthTot = Math.Round(m, 2);
                    lblAmount2.Text = Convert.ToString(roundedMonthTot);

                    m1 = m1 + Decimal.Parse(lblAmountYr1.Text);
                    decimal roundedYearTot = Math.Round(m1, 2);
                    lblAmountYr2.Text = Convert.ToString(roundedYearTot);

                    ComponentTotal = Convert.ToDecimal(lblAmountYr2.Text);
                }

                foreach (GridViewRow gridviedrow in GridViewEmpCompansion.Rows)
                {

                    Label lblComponentsID1 = (Label)gridviedrow.FindControl("lblComponentsID1");
                    Label lblCompnents1 = (Label)gridviedrow.FindControl("lblCompnents1");
                    Label lblPercentages1 = (Label)gridviedrow.FindControl("lblPercentages1");
                    Label lblAmounts2 = GridViewEmpCompansion.FooterRow.FindControl("lblAmounts2") as Label;
                    Label lblAmounts1 = (Label)gridviedrow.FindControl("lblAmounts1");
                    Percentage = Convert.ToDecimal(lblPercentages1.Text);

                    AmountAnnual = basicSalaryAmount * (Percentage / 100);
                    decimal roundedCompSal = Math.Round(AmountAnnual, 2);
                    lblAmounts1.Text = Convert.ToString(roundedCompSal);

                    n = n + Decimal.Parse(lblAmounts1.Text);
                    decimal roundedCompAmt = Math.Round(n, 2);
                    lblAmounts2.Text = Convert.ToString(roundedCompAmt);

                    ContributionTotal = Convert.ToDecimal(lblAmounts2.Text);
                    //string TotalmonthlyEmp;
                    //TotalmonthlyEmp = (ContributionTotal / 12).;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Save Candidate Salary Total
                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    SqlCommand cmd2 = new SqlCommand("SP_SaveCandSalaryTotal", con2);
                    cmd2.Connection = con2;
                    cmd2.CommandType = CommandType.StoredProcedure;
                    Label lblAmount2 = GridViewComponent.FooterRow.FindControl("lblAmount2") as Label;
                    Label lblAmountYr3 = GridViewComponent.FooterRow.FindControl("lblAmountYr2") as Label;
                    Label lblAmounts2 = GridViewEmpCompansion.FooterRow.FindControl("lblAmounts2") as Label;
                    decimal totalEmployeer = 0;
                    if (decimal.TryParse(lblAmounts2.Text, out totalEmployeer))
                    {
                        // Divide the value by 2
                        totalEmployeer /= 2;
                    }
                    cmd2.Parameters.AddWithValue("@Cand_Name", txtEmpName.Text);
                    cmd2.Parameters.AddWithValue("@Cand_Designation", ddldesignation1.SelectedItem.Text);
                    cmd2.Parameters.AddWithValue("@Cand_Department", ddldepartement1.SelectedItem.Text);
                    cmd2.Parameters.AddWithValue("@Cand_EmailID", txtEmail.Text);
                    cmd2.Parameters.AddWithValue("@Package", txtPackage.Text);
                    cmd2.Parameters.AddWithValue("@TotalComponent", lblAmountYr3.Text);
                    cmd2.Parameters.AddWithValue("@TotalEmployeer", lblAmounts2.Text);
                    cmd2.Parameters.AddWithValue("@GrandTotal", lblOfferedTotal.Text);
                    cmd2.Parameters.AddWithValue("@Createby", UserName);
                    cmd2.Parameters.AddWithValue("@EmpID", UserId);
                    cmd2.Parameters.AddWithValue("@Designation", Designation);
                    cmd2.Parameters.AddWithValue("@PhoneNo", txtphoneNo.Text);
                    cmd2.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd2.Parameters.AddWithValue("@Cand_No", txtCandNumber.Text);
                    cmd2.Parameters.AddWithValue("@TotalMonthlyComp", lblAmount2.Text);
                    cmd2.Parameters.AddWithValue("@TotalMonthlyEmp", totalEmployeer.ToString());
                    cmd2.Parameters.AddWithValue("@TermsCondition", txtTermsAndConditions.Text);
                    cmd2.Parameters.AddWithValue("@Note", txtClientNote.Text);
                    con2.Open();
                    int i = cmd2.ExecuteNonQuery();
                    if (i < 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Candidate Details Save Successfully !')", true);
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Candidate Details Not Save Successfully !')", true);
                    }
                    con2.Close();
                }

                //Save Candidate Salary Component
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    foreach (GridViewRow gridviedrow in GridViewComponent.Rows)
                    {
                        Label lblID = (Label)gridviedrow.FindControl("lblID");
                        Label lblComponentID = (Label)gridviedrow.FindControl("lblComponentID");
                        Label lblCompnent1 = (Label)gridviedrow.FindControl("lblCompnent1");
                        Label lblPercentage1 = (Label)gridviedrow.FindControl("lblPercentage1");
                        Label lblAmount1 = (Label)gridviedrow.FindControl("lblAmount1");
                        Label lblAmountYr1 = (Label)gridviedrow.FindControl("lblAmountYr1");

                        SqlCommand cmd = new SqlCommand("SP_SaveCandSalaryComponent", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CandName", txtEmpName.Text);
                        cmd.Parameters.AddWithValue("@CandDesignation", ddldesignation1.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@PerCATID", lblComponentID.Text);
                        cmd.Parameters.AddWithValue("@Category", lblCompnent1.Text);
                        cmd.Parameters.AddWithValue("@Percentage", lblPercentage1.Text);
                        cmd.Parameters.AddWithValue("@MonthlyAmount", lblAmount1.Text);
                        cmd.Parameters.AddWithValue("@AnnualAmount", lblAmountYr1.Text);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Createby", UserName);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@Cand_No", txtCandNumber.Text);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {

                            //lblMsg.Visible = true;
                            //lblMsg.Text = "Approval Added Successfully";

                        }
                        else
                        {

                            //lblMsg.Visible = true;
                            //lblMsg.Text = "Appoval not Successfully";
                        }

                        con.Close();
                    }
                }

                //Save Candidate Salary Contribution
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    foreach (GridViewRow gvrow in GridViewEmpCompansion.Rows)
                    {
                        Label lblID = (Label)gvrow.FindControl("lblID");
                        Label lblComponentsID1 = (Label)gvrow.FindControl("lblComponentsID1");
                        Label lblCompnents1 = (Label)gvrow.FindControl("lblCompnents1");
                        Label lblPercentages1 = (Label)gvrow.FindControl("lblPercentages1");
                        Label lblAmounts1 = (Label)gvrow.FindControl("lblAmounts1");

                        SqlCommand cmd1 = new SqlCommand("SP_SaveCandSalaryContribution", con1);
                        cmd1.Connection = con1;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@CandName", txtEmpName.Text);
                        cmd1.Parameters.AddWithValue("@candDesignation", lblDesignation.Text);
                        cmd1.Parameters.AddWithValue("@PerCATID", lblComponentsID1.Text);
                        cmd1.Parameters.AddWithValue("@Category", lblCompnents1.Text);
                        cmd1.Parameters.AddWithValue("@Percentage", lblPercentages1.Text);
                        cmd1.Parameters.AddWithValue("@AnnualAmount", lblAmounts1.Text);
                        cmd1.Parameters.AddWithValue("@Cand_No", txtCandNumber.Text);
                        cmd1.Parameters.AddWithValue("@EmpID", UserId);
                        cmd1.Parameters.AddWithValue("@Createby", UserName);
                        cmd1.Parameters.AddWithValue("@Designation", Designation);


                        con1.Open();
                        dr = cmd1.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {
                            //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses  Item Approval Added  Successfully!')", true);
                            //    //ViewFileExpensesDetails();
                        }
                        else
                        {
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses Item Approval Not Added  Successfully!')", true);
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
            Response.Redirect("OfferLetter.aspx",true);
        }

        protected void btnDeleteAnnualSal_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = GridViewEmpCompansion.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                string ComponentsID = ((Label)rows[rowindex].FindControl("lblCompnentsID")).Text;

                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_DeleteComponent", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@ID", ComponentsID);
                    com.Parameters.AddWithValue("@CreatedBy", UserName);
                    com.Parameters.AddWithValue("@EmpID", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    con1.Open();
                    int i = com.ExecuteNonQuery();
                    if (i < 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses Item Remove Successfully!')", true);
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses Item  Not Remove Yet!')", true);
                    }
                    con1.Close();
                    ViewComponent();
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

        protected void btnDeleteAnnualComp_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = GridViewEmpCompansion.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                string ComponentsID = ((Label)rows[rowindex].FindControl("lblCompnentsID")).Text;

                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_DeleteComponent", con1);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@ID", ComponentsID);
                    com.Parameters.AddWithValue("@CreatedBy", UserName);
                    com.Parameters.AddWithValue("@EmpID", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    con1.Open();
                    int i = com.ExecuteNonQuery();

                    if (i < 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses Item Remove Successfully!')", true);
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses Item  Not Remove Yet!')", true);
                    }
                    con1.Close();
                    ViewComponent();
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
    }
}