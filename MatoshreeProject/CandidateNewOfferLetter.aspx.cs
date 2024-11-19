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
using static iTextSharp.text.pdf.PdfDocument;
#endregion

namespace MatoshreeProject
{
    public partial class CandidateNewOfferLetter : System.Web.UI.Page
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
        int UserId = 1;
        string UserName = "Admin", EmailID, Designation = "Admin", RoleType, Permission, DeptID, CareerID, sendMail, EmpNAME;
        Decimal GrandTotal, ComponentTotal, ContributionTotal;
        string UserEmpName, Password, EmailID1, Designation1;
        string Size, Initial, ReceiptFor, Cash, Bank, reminder;
        string Day = Convert.ToString(DateTime.Today.Day);
        string year = Convert.ToString(DateTime.Today.Year);
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

        #region " Public Function "
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

        //------------------GridView--------------------//
        public DataTable ViewComponent()
        {
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewCandAnnualSalStructure", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PertCate_ID", "1");
                cmd.Parameters.AddWithValue("@ClassID", ddlClass1.SelectedItem.Value);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        GridViewCandComponent.DataSource = ds;
                        GridViewCandComponent.DataBind();

                        
                        totalAnnualAndMonthly();
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
        public DataTable ViewContr()
        {
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewCandAnnualSalStructure", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PertCate_ID", "2");
                cmd.Parameters.AddWithValue("@ClassID", ddlClass1.SelectedItem.Value);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        GridViewCandContr.DataSource = ds;
                        GridViewCandContr.DataBind();
                        
                        totalAnnualAndMonthly();
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

        //------------------DropDown------------------//
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
                    ddlCanddepartement1.DataSource = ds.Tables[0];
                    ddlCanddepartement1.DataTextField = "Dept_Name";
                    ddlCanddepartement1.DataValueField = "Dept_ID";
                    ddlCanddepartement1.DataBind();
                    ddlCanddepartement1.Items.Insert(0, new ListItem("Select Departement", "0"));
                }
            }
            catch (Exception ex)
            {
                using (SqlConnection DeviceCon = new SqlConnection(strconnect))
                {
                    string ErrorMessgage = ex.Message;

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
        //--------------------Get And Parameter Passing Method------------//
        public void ViewOffered()
        {
            try
            {
                GrandTotal = ComponentTotal+ ContributionTotal;
                decimal roundedGrandTot = Math.Round(GrandTotal, 2);
                string Total = roundedGrandTot.ToString();
                lblcandOfferedTotal.Text = Total.ToString();
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
            ddlCanddepartement1.SelectedIndex = 0;
            ddldesignation1.SelectedIndex = 0;
            txtCandName.Text = string.Empty;
            txtCandPackage.Text = string.Empty;
            txtCandAddress.Text = string.Empty;
            txtCandphoneNo.Text = string.Empty;
            txtCandEmail.Text = string.Empty;
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

                }
            }
            finally
            {
            }
        }
        public void totalAnnualAndMonthly()
        {
            try
            {
                Decimal AnnualSalary = Convert.ToDecimal(txtCandPackage.Text);
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
        #endregion

        #region   "Event"
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string ReceiptNumner = GETReceiptINITIAL();
                    txtCandNumber.Text = ReceiptNumner;
                    GetCompanytermsAndCondition();
                    BindDesignation();
                    BindDepartement();
                    bindClass();
                  

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

        protected void btnclosecanddetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        protected void btnSavecanddetails_Click(object sender, EventArgs e)
        {
            try
            {
                //Save Candidate Salary Component
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    foreach (GridViewRow gridviedrow in GridViewCandComponent.Rows)
                    {                      
                        Label lblCandComponentID = (Label)gridviedrow.FindControl("lblCompPerCatId");
                        Label lblCandCompnent1 = (Label)gridviedrow.FindControl("lblComppert");
                        Label lblPercentage1 = (Label)gridviedrow.FindControl("lblCompPercentage");
                        Label lblmonthlyAmount1 = (Label)gridviedrow.FindControl("lblMonthlyAmtComp");
                        Label lblAmountYr1 = (Label)gridviedrow.FindControl("lblCompAnnAmtComp");//AnnualComponent

                        SqlCommand cmd = new SqlCommand("SP_SaveCandSalaryComponent", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CandName", txtCandName.Text);
                        cmd.Parameters.AddWithValue("@CandDesignation", ddldesignation1.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@PerCATID", lblCandComponentID.Text);
                        cmd.Parameters.AddWithValue("@Category", lblCandCompnent1.Text);
                        cmd.Parameters.AddWithValue("@Percentage", lblPercentage1.Text);
                        cmd.Parameters.AddWithValue("@MonthlyAmount", lblmonthlyAmount1.Text);
                        cmd.Parameters.AddWithValue("@AnnualAmount", lblAmountYr1.Text);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Createby", UserName);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@Cand_No", txtCandNumber.Text);
                        cmd.Parameters.AddWithValue("@ClassID", ddlClass1.SelectedItem.Value);
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
                    foreach (GridViewRow gvrow in GridViewCandContr.Rows)
                    {
                        Label lblComponentsID1 = (Label)gvrow.FindControl("lblContrPerID");
                        Label lblCompnents1 = (Label)gvrow.FindControl("lblContrPert");
                        Label lblPercentages1 = (Label)gvrow.FindControl("lblContrPer");                       
                        Label lblAmounts1 = (Label)gvrow.FindControl("lblContrAnnAmt");
                        SqlCommand cmd1 = new SqlCommand("SP_SaveCandSalaryContribution", con1);
                        cmd1.Connection = con1;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        Label lblContrAnnAmtFtr = GridViewCandContr.FooterRow.FindControl("lblContrAnnAmtFtr") as Label;
                        decimal totalMonthlyEmployeer = 0;
                        if (decimal.TryParse(lblContrAnnAmtFtr.Text, out totalMonthlyEmployeer))
                        {
                            // Divide the value by 2
                            totalMonthlyEmployeer /= 2;
                        }
                        cmd1.Parameters.AddWithValue("@CandName", txtCandName.Text);
                        cmd1.Parameters.AddWithValue("@candDesignation", lblDesignation.Text);
                        cmd1.Parameters.AddWithValue("@PerCATID", lblComponentsID1.Text);
                        cmd1.Parameters.AddWithValue("@Category", lblCompnents1.Text);
                        cmd1.Parameters.AddWithValue("@Percentage", lblPercentages1.Text);
                        cmd1.Parameters.AddWithValue("@AnnualAmount", lblAmounts1.Text);
                        cmd1.Parameters.AddWithValue("@MonthlyAmount", totalMonthlyEmployeer.ToString()); 
                        cmd1.Parameters.AddWithValue("@Cand_No", txtCandNumber.Text);
                        cmd1.Parameters.AddWithValue("@EmpID", UserId);
                        cmd1.Parameters.AddWithValue("@Createby", UserName);
                        cmd1.Parameters.AddWithValue("@Designation", Designation);
                        cmd1.Parameters.AddWithValue("@ClassID", ddlClass1.SelectedItem.Value);
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

                //Save Candidate Salary Total
                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    SqlCommand cmd2 = new SqlCommand("SP_SaveCandSalaryTotal", con2);
                    cmd2.Connection = con2;
                    cmd2.CommandType = CommandType.StoredProcedure;
                    Label lblMntAmtCompFtr = GridViewCandComponent.FooterRow.FindControl("lblMntAmtCompFtr") as Label;
                    Label lblAnnAmtCompftr = GridViewCandComponent.FooterRow.FindControl("lblAnnAmtCompftr") as Label;
                    Label lblContrAnnAmtFtr = GridViewCandContr.FooterRow.FindControl("lblContrAnnAmtFtr") as Label;
                    decimal totalMonthlyEmployeer = 0;
                    if (decimal.TryParse(lblContrAnnAmtFtr.Text, out totalMonthlyEmployeer))
                    {
                        // Divide the value by 2
                        totalMonthlyEmployeer /= 2;
                    }
                    cmd2.Parameters.AddWithValue("@Cand_Name", txtCandName.Text);
                    cmd2.Parameters.AddWithValue("@Cand_Designation", ddldesignation1.SelectedItem.Text);
                    cmd2.Parameters.AddWithValue("@Cand_Department", ddlCanddepartement1.SelectedItem.Text);
                    cmd2.Parameters.AddWithValue("@Cand_EmailID", txtCandEmail.Text);
                    cmd2.Parameters.AddWithValue("@Package", txtCandPackage.Text);
                    cmd2.Parameters.AddWithValue("@TotalComponent", lblAnnAmtCompftr.Text);
                    cmd2.Parameters.AddWithValue("@TotalEmployeer", lblContrAnnAmtFtr.Text);
                    cmd2.Parameters.AddWithValue("@GrandTotal", lblcandOfferedTotal.Text);
                    cmd2.Parameters.AddWithValue("@Createby", UserName);
                    cmd2.Parameters.AddWithValue("@EmpID", UserId);
                    cmd2.Parameters.AddWithValue("@Designation", Designation);
                    cmd2.Parameters.AddWithValue("@PhoneNo", txtCandphoneNo.Text);
                    cmd2.Parameters.AddWithValue("@Address", txtCandAddress.Text);
                    cmd2.Parameters.AddWithValue("@Cand_No", txtCandNumber.Text);
                    cmd2.Parameters.AddWithValue("@TotalMonthlyComp", lblMntAmtCompFtr.Text);
                    cmd2.Parameters.AddWithValue("@TotalMonthlyEmp", totalMonthlyEmployeer.ToString());
                    cmd2.Parameters.AddWithValue("@TermsCondition", txtTermsAndConditions.Text);
                    cmd2.Parameters.AddWithValue("@Note", txtClientNote.Text);
                    cmd2.Parameters.AddWithValue("@ClassID", ddlClass1.SelectedItem.Value);
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

        protected void btncalpackage_Click(object sender, EventArgs e)
        {
            totalAnnualAndMonthly();
        }

        protected void btnclecandinfo_Click(object sender, EventArgs e)
        {
            Clear();
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