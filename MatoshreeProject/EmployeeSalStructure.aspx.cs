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
using iText.Kernel.Pdf;
using System.IO.MemoryMappedFiles;
using System.Reflection;
using System.Dynamic;
using Color = System.Drawing.Color;
#endregion

namespace MatoshreeProject
{

    public partial class EmployeeSalStructure : System.Web.UI.Page
    {

        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        SqlDataReader dr1;
        SqlDataReader dr2;
        int Result, Result1, Result2;
        string result, result1, result2;

        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        
        Decimal GrandTotal, ComponentTotal, ContributionTotal, ContibutionMonthly;


        string DevEmail, DevPassword, DevPort, DevHost;



      

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


        public void ViewComponent()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ViewEmpCompansion", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PertCate_ID", "1");
                    cmd.Parameters.AddWithValue("@ClassID", ddlClass.SelectedItem.Value);
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

        public void ViewEmpCompansion()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_ViewEmpCompansion", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PertCate_ID", "2");
                    cmd.Parameters.AddWithValue("@ClassID", ddlClass.SelectedItem.Value);
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

        public void ViewDeduction()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_ViewEmpCompansion", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PertCate_ID", "3");
                    cmd.Parameters.AddWithValue("@ClassID", ddlClass.SelectedItem.Value);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        DataTable ds = new DataTable();
                        sda.Fill(ds);
                        if (ds.Rows.Count > 0)
                        {
                            GridViewDeduction.DataSource = ds;
                            GridViewDeduction.DataBind();

                        }
                        else
                        {
                            ds.Rows.Add(ds.NewRow());
                            GridViewDeduction.DataSource = ds;
                            GridViewDeduction.DataBind();


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

        public void BindSalaryClass()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetSalaryClass", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlClass.DataSource = ds.Tables[0];
                    ddlClass.DataTextField = "ClassName";
                    ddlClass.DataValueField = "ID";
                    ddlClass.DataBind();
                    ddlClass.Items.Insert(0, new ListItem("Select Class", "0"));
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
            txtempname.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            txtShiftName.Text = string.Empty;
            txtPackage.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDepartment.Text = string.Empty;
            txtEmail.Text = string.Empty;
            BTNDIV.Visible = false;
            ViewComponent();
            ViewEmpCompansion();
            //GridViewComponent.DataSource = null;
            //GridViewComponent.DataBind();
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
                            BindSalaryClass();
                          
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
                                BindSalaryClass();
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

        protected void btnCalculateStructure_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal AnnualSalary = Convert.ToDecimal(txtPackage.Text);
                Decimal MonthlySalary = AnnualSalary / 12;

                Decimal Amount, AmountAnnual, Percentage, basicSalaryAmount = 0, m = 0, n = 0, m1 = 0, p = 0;
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
                    Label lblMonthlyAmounts1 = (Label)gridviedrow.FindControl("lblMonthlyAmounts1");
                    Label lblAmounts2 = GridViewEmpCompansion.FooterRow.FindControl("lblAmounts2") as Label;
                    Label lblMonthlyAmounts2 = GridViewEmpCompansion.FooterRow.FindControl("lblMonthlyAmounts2") as Label;

                    Label lblAmounts1 = (Label)gridviedrow.FindControl("lblAmounts1");
                    Percentage = Convert.ToDecimal(lblPercentages1.Text);

                    AmountAnnual = basicSalaryAmount * (Percentage / 100);
                    decimal roundedCompSal = Math.Round(AmountAnnual, 2);
                    lblAmounts1.Text = Convert.ToString(roundedCompSal);

                    n = n + Decimal.Parse(lblAmounts1.Text);
                    decimal roundedCompAmt = Math.Round(n, 2);
                    lblAmounts2.Text = Convert.ToString(roundedCompAmt);

                    ContributionTotal = Convert.ToDecimal(lblAmounts2.Text);

                    ContibutionMonthly = ContributionTotal / 12;
                    lblMonthlyAmounts2.Text = Convert.ToString(ContibutionMonthly);
                    lblPFMonthly.Text = Convert.ToString(ContibutionMonthly);
                    ViewOffered();

                }

                foreach (GridViewRow gridviedrow in GridViewDeduction.Rows)
                {

                    Label lblPerCateIDDed = (Label)gridviedrow.FindControl("lblPerCateIDDed");
                    Label lblPerDed = (Label)gridviedrow.FindControl("lblPerDed");
                    Label lblPercentages1Ded = (Label)gridviedrow.FindControl("lblPercentages1Ded");
                    Label lblAmountsDed1 = (Label)gridviedrow.FindControl("lblAmountsDed1");

                    Label lblAmountsDed2 = GridViewDeduction.FooterRow.FindControl("lblAmountsDed2") as Label;
                    //lblAmountsDed1.Text = Convert.ToString(ContibutionMonthly);


                    if (lblPerDed.Text == "PF" || lblPerDed.Text == "Provided Fund")
                    {
                        lblAmountsDed1.Text = lblPFMonthly.Text;
                    }
                    else
                    {
                        p = p + Decimal.Parse(lblAmountsDed1.Text);

                        decimal FinalDeduction = ContibutionMonthly + p;
                        decimal roundedDedAmt = Math.Round(FinalDeduction, 2);
                        lblAmountsDed2.Text = Convert.ToString(roundedDedAmt);
                    }
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

        protected void btnDeleteAnnualSal_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = GridViewComponent.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                string ComponentID = ((Label)rows[rowindex].FindControl("lblCompnentID")).Text;

                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_DeleteComponent", con1);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@ID", ComponentID);
                    com.Parameters.AddWithValue("@CreatedBy", UserName);
                    com.Parameters.AddWithValue("@EmpID", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    con1.Open();
                    int i = com.ExecuteNonQuery();

                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Delete Component Successfully!";

                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses Item Remove Successfully!')", true);
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Delete Component Not Remove Yet!";
                        // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expenses Item  Not Remove Yet!')", true);
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

        protected void btnAddAnnualSal_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    TextBox txtCompnent = (TextBox)GridViewComponent.FooterRow.FindControl("txtCompnent");
            //    //DropDownList ddlCatType1 = (DropDownList)GridViewComponent.FooterRow.FindControl("ddlCatType1");
            //    TextBox txtPercentage = (TextBox)GridViewComponent.FooterRow.FindControl("txtPercentage");
            //    TextBox txtAmount = (TextBox)GridViewComponent.FooterRow.FindControl("txtAmount");

            //    // float Rate = Convert.Tofloat(txtRate.Text);


            //    using (SqlConnection con = new SqlConnection(strconnect))
            //    {

            //        SqlCommand cmd = new SqlCommand("SP_SaveComponent", con);
            //        cmd.Connection = con;
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@Perticular", txtCompnent.Text);
            //        // cmd.Parameters.AddWithValue("@PerticularType", ddlCatType1.Text);
            //        cmd.Parameters.AddWithValue("@Percentage", txtPercentage.Text);
            //        cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
            //        cmd.Parameters.AddWithValue("@CreateBy", UserName);
            //        cmd.Parameters.AddWithValue("@EmpID", UserId);
            //        cmd.Parameters.AddWithValue("@Designation", Designation);

            //        con.Open();
            //        dr = cmd.ExecuteReader();
            //        while (dr.Read())
            //        {
            //            result = dr[0].ToString();
            //        }
            //        Result = int.Parse(result);
            //        if (Result > 0)
            //        {
            //            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Details Save Successfully!')", true);
            //            ViewComponent();

            //        }
            //        else
            //        {
            //            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Try Again!')", true);
            //        }

            //    }


            //}
            //catch (Exception ex)
            //{
            //    using (SqlConnection DeviceCon = new SqlConnection(strconnect))
            //    {
            //        string ErrorMessgage = ex.Message;
            //        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
            //        string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
            //        string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
            //        Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
            //        SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
            //        cmdex.CommandType = CommandType.StoredProcedure;
            //        cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
            //        cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
            //        cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
            //        cmdex.Parameters.AddWithValue("@Method", method);
            //        cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
            //        DeviceCon.Open();
            //        int RowEx = cmdex.ExecuteNonQuery();
            //        if (RowEx < 0)
            //        {
            //            //lblMessage.Visible = false;
            //            //lblMessage.Text = "Error Details Save Successfully";
            //        }
            //        else
            //        {
            //            //lblMessage.Visible = false;
            //            //lblMessage.Text = "Error Details Not Save Successfully";
            //        }
            //    }
            //}
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
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Delete Employeer Contribution Item Successfully !";
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Delete Employeer Contribution Item Not Remove Yet !";
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

        protected void GridViewOffered_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    if (e.Row.RowType == DataControlRowType.Header)
            //    {
            //        string itemName = e.Row.Cells[1].Text;
            //        Label lblOfferedTotal1 = e.Row.FindControl("lblOfferedTotal1") as Label;

            //        GrandTotal = ComponentTotal + ContributionTotal;
            //        decimal roundedGrandTot = Math.Round(GrandTotal, 2);
            //        string Total = roundedGrandTot.ToString();
            //        lblOfferedTotal1.Text = Total.ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    using (SqlConnection DeviceCon = new SqlConnection(strconnect))
            //    {
            //        string ErrorMessgage = ex.Message;
            //        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
            //        string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
            //        string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
            //        Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
            //        SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
            //        cmdex.CommandType = CommandType.StoredProcedure;
            //        cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
            //        cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
            //        cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
            //        cmdex.Parameters.AddWithValue("@Method", method);
            //        cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
            //        DeviceCon.Open();
            //        int RowEx = cmdex.ExecuteNonQuery();
            //        if (RowEx < 0)
            //        {
            //            //lblMessage.Visible = false;
            //            //lblMessage.Text = "Error Details Save Successfully";
            //        }
            //        else
            //        {
            //            //lblMessage.Visible = false;
            //            //lblMessage.Text = "Error Details Not Save Successfully";
            //        }
            //    }
            //}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (GridViewRow gridviedrow in GridViewComponent.Rows)
                {
                    Label lblID = (Label)gridviedrow.FindControl("lblID");
                    Label lblComponentID = (Label)gridviedrow.FindControl("lblComponentID");
                    Label lblCompnent1 = (Label)gridviedrow.FindControl("lblCompnent1");
                    Label lblPercentage1 = (Label)gridviedrow.FindControl("lblPercentage1");
                    Label lblAmount1 = (Label)gridviedrow.FindControl("lblAmount1");
                    Label lblAmountYr1 = (Label)gridviedrow.FindControl("lblAmountYr1");

                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_SaveSalaryEmpComponent", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StaffID", lblStaffID1.Text);
                        cmd.Parameters.AddWithValue("@StaffDesignation", txtDesignation.Text);
                        cmd.Parameters.AddWithValue("@PerCATID", lblComponentID.Text);
                        cmd.Parameters.AddWithValue("@Category", lblCompnent1.Text);
                        cmd.Parameters.AddWithValue("@Percentage", lblPercentage1.Text);
                        cmd.Parameters.AddWithValue("@MonthlyAmount", lblAmount1.Text);
                        cmd.Parameters.AddWithValue("@AnnualAmount", lblAmountYr1.Text);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Createby", UserName);
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

                foreach (GridViewRow gvrow in GridViewEmpCompansion.Rows)
                {
                    Label lblID = (Label)gvrow.FindControl("lblID");
                    Label lblComponentsID1 = (Label)gvrow.FindControl("lblComponentsID1");
                    Label lblCompnents1 = (Label)gvrow.FindControl("lblCompnents1");
                    Label lblPercentages1 = (Label)gvrow.FindControl("lblPercentages1");
                    Label lblAmounts1 = (Label)gvrow.FindControl("lblAmounts1");

                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd1 = new SqlCommand("SP_SaveSalaryEmpContribution", con1);
                        cmd1.Connection = con1;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@StaffID", lblStaffID1.Text);
                        cmd1.Parameters.AddWithValue("@StaffDesignation", txtDesignation.Text);
                        cmd1.Parameters.AddWithValue("@PerCATID", lblComponentsID1.Text);
                        cmd1.Parameters.AddWithValue("@Category", lblCompnents1.Text);
                        cmd1.Parameters.AddWithValue("@Percentage", lblPercentages1.Text);
                        cmd1.Parameters.AddWithValue("@AnnualAmount", lblAmounts1.Text);
                        cmd1.Parameters.AddWithValue("@EmpID", UserId);
                        cmd1.Parameters.AddWithValue("@Createby", UserName);
                        cmd1.Parameters.AddWithValue("@Designation", Designation);
                        con1.Open();
                        dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            result1 = dr1[0].ToString();
                        }
                        Result1 = int.Parse(result1);
                        if (Result1 > 0)
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

                foreach (GridViewRow gvrow1 in GridViewDeduction.Rows)
                {
                    Label lblID = (Label)gvrow1.FindControl("lblID");
                    Label lblPerCateIDDed = (Label)gvrow1.FindControl("lblPerCateIDDed");
                    Label lblPerDed = (Label)gvrow1.FindControl("lblPerDed");
                    Label lblPercentages1Ded = (Label)gvrow1.FindControl("lblPercentages1Ded");
                    Label lblAmountsDed1 = (Label)gvrow1.FindControl("lblAmountsDed1");
                    Label lblAmountsDed2 = GridViewDeduction.FooterRow.FindControl("lblAmountsDed2") as Label;

                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd1 = new SqlCommand("SP_SaveSalaryEmpDeduction", con1);
                        cmd1.Connection = con1;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@StaffID", lblStaffID1.Text);
                        cmd1.Parameters.AddWithValue("@StaffDesignation", txtDesignation.Text);
                        cmd1.Parameters.AddWithValue("@PerCATID", lblPerCateIDDed.Text);
                        cmd1.Parameters.AddWithValue("@Category", lblPerDed.Text);
                        cmd1.Parameters.AddWithValue("@Percentage", lblPercentages1Ded.Text);
                        cmd1.Parameters.AddWithValue("@MonthlyAmount", lblAmountsDed1.Text);
                        // cmd1.Parameters.AddWithValue("@AnnualAmount", lblAmountsDed2.Text);
                        cmd1.Parameters.AddWithValue("@EmpID", UserId);
                        cmd1.Parameters.AddWithValue("@Createby", UserName);
                        cmd1.Parameters.AddWithValue("@Designation", Designation);
                        con1.Open();
                        dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            result1 = dr1[0].ToString();
                        }
                        Result1 = int.Parse(result1);
                        if (Result1 > 0)
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

                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    Label lblAmountYr2 = GridViewComponent.FooterRow.FindControl("lblAmountYr2") as Label;

                    Label lblAmounts2 = GridViewEmpCompansion.FooterRow.FindControl("lblAmounts2") as Label;

                    Label lblMonthlyAmounts2 = GridViewEmpCompansion.FooterRow.FindControl("lblMonthlyAmounts2") as Label;
                    Label lblAmount2 = GridViewComponent.FooterRow.FindControl("lblAmount2") as Label;
                    Label lblAmountsDed2 = GridViewDeduction.FooterRow.FindControl("lblAmountsDed2") as Label;

                    SqlCommand cmd2 = new SqlCommand("SP_SaveSalaryGrandTotal", con2);
                    cmd2.Connection = con2;
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@StaffID", lblStaffID1.Text);
                    cmd2.Parameters.AddWithValue("@StaffName", txtName.Text);
                    cmd2.Parameters.AddWithValue("@StaffDesignation", txtDesignation.Text);
                    cmd2.Parameters.AddWithValue("@Package", txtPackage.Text);
                    cmd2.Parameters.AddWithValue("@EmailID", txtEmail.Text);
                    cmd2.Parameters.AddWithValue("@Department", txtDepartment.Text);
                    cmd2.Parameters.AddWithValue("@TotalComponent", lblAmountYr2.Text);
                    cmd2.Parameters.AddWithValue("@TotalEmployeer", lblAmountsDed2.Text);
                    cmd2.Parameters.AddWithValue("@TotalMonthlyComp", lblAmount2.Text);
                    cmd2.Parameters.AddWithValue("@TotalAnnualEmployeer", lblMonthlyAmounts2.Text);
                    cmd2.Parameters.AddWithValue("@GrandTotal", lblOfferedTotal.Text);
                    cmd2.Parameters.AddWithValue("@EmpID", UserId);
                    cmd2.Parameters.AddWithValue("@Createby", UserName);
                    cmd2.Parameters.AddWithValue("@Designation", Designation);
                    con2.Open();
                    dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        result2 = dr2[0].ToString();
                    }
                    Result2 = int.Parse(result2);
                    if (Result2 > 0)
                    {
                        string save = "fgsave123q";
                        Response.Redirect("~/EmployeeSalDetails.aspx?svd1=" + save + "", false);

                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Employee Salary Details Not Edit Yet!";
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

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx", true);
        }

        protected void LnkEmpName_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
                Label lblEmpID = (Label)row.FindControl("lblEmpID");
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetStaffByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@Staff_ID", lblEmpID.Text);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtName.Text = dt.Rows[0]["Full_Name"].ToString();
                        txtDesignation.Text = dt.Rows[0]["Role"].ToString();
                        txtDepartment.Text = dt.Rows[0]["Dept_Name"].ToString();
                        txtempname.Text = dt.Rows[0]["Name"].ToString();
                        lblStaffID1.Text = dt.Rows[0]["Staff_ID"].ToString();
                        txtEmail.Text = dt.Rows[0]["Email"].ToString();
                        txtShiftName.Text = dt.Rows[0]["ShiftName"].ToString();
                    }
                }
                txtempname.Text = string.Empty;
                BTNDIV.Visible = false;
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

        protected void btnSearch2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetEmpName", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", txtempname.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    List<string> EmpNames = new List<string>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        EmpNames.Add(dt.Rows[i].ToString());
                        //BTNDIV.InnerHtml = "<a href=\"Dashboard.aspx\"></a>";

                        if (dt.Rows.Count > 0)
                        {
                            GVEMpName.DataSource = dt;
                            GVEMpName.DataBind();

                            Divshowdash.Visible = false;
                            BTNDIV.Visible = true;
                        }
                        else
                        {
                            GVEMpName.Visible = false;
                            Divshowdash.Visible = true;
                        }
                        txtempname.Text = string.Empty;
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

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AllGrid.Visible = true;
                ViewComponent();
                ViewEmpCompansion();
                ViewDeduction();
                ViewOffered();
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

        protected void GridViewDeduction_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //  Decimal p = 0;

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

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    using (SqlConnection con = new SqlConnection(strconnect))
            //    {
            //        SqlCommand cmd = new SqlCommand("SP_GetWebPagesName", con);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@Name", txtWebPage.Text);
            //        SqlDataAdapter da = new SqlDataAdapter(cmd);
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        List<string> WebpageNames = new List<string>();
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            WebpageNames.Add(dt.Rows[i].ToString());
            //            //BTNDIV.InnerHtml = "<a href=\"Dashboard.aspx\"></a>";

            //            if (dt.Rows.Count > 0)
            //            {
            //                GVWebPage.DataSource = dt;
            //                GVWebPage.DataBind();

            //                Divshowdash.Visible = false;
            //                BTNDIV.Visible = true;
            //            }
            //            else
            //            {
            //                GVWebPage.Visible = false;
            //                Divshowdash.Visible = true;
            //            }

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    using (SqlConnection DeviceCon = new SqlConnection(strconnect))
            //    {
            //        string ErrorMessgage = ex.Message;
            //        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
            //        string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
            //        string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
            //        Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
            //        SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon);
            //        cmdex.CommandType = CommandType.StoredProcedure;
            //        cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
            //        cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
            //        cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
            //        cmdex.Parameters.AddWithValue("@Method", method);
            //        cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
            //        DeviceCon.Open();
            //        int RowEx = cmdex.ExecuteNonQuery();
            //        if (RowEx < 0)
            //        {
            //            //lblMessage.Visible = false;
            //            //lblMessage.Text = "Error Details Save Successfully";
            //        }
            //        else
            //        {
            //            //lblMessage.Visible = false;
            //            //lblMessage.Text = "Error Details Not Save Successfully";
            //        }
            //    }
            //}

        }

        #endregion
    }
}