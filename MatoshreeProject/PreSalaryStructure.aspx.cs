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
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
//using static MatoshreeProject.ViewLeaveManagement;
using System.Net.Mail;
using System.Net;
using System.ComponentModel;
using System.Data.SqlTypes;
#endregion

namespace MatoshreeProject
{
    public partial class PreSalaryStructure : System.Web.UI.Page
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
        string DevEmail, DevPassword, DevPort, DevHost;

        decimal a = 100m;
        decimal b;

        Decimal oldper, newper, totalper;



        string UserEmpName, Password, EmailID1, Designation1;
        decimal sumper1;
        decimal totalresult1;
        string sumper;

        decimal footerper1;
        Phrase phrase = null;
        string contributionPer;
        decimal contributionPer1;
        //string chkEmp;


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

        #endregion

        #region " Protected Functions "




        #endregion

        #region " Public Functions "
        protected void bindClass()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetEmpSalaryClass", conn);
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

        public void BindSubCategory(string ClassId)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                // SqlCommand cmd = new SqlCommand("SP_GetAnnualSalarySubCategory", conn);
                SqlCommand cmd = new SqlCommand("SP_ViewAnnualsalaryStructure", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PertCate_ID", "1");
                cmd.Parameters.AddWithValue("@ClassID", ClassId);

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    ddlComponents.DataSource = ds;
                    ddlComponents.DataTextField = "Perticular";//Description
                    ddlComponents.DataValueField = "ID";
                    ddlComponents.DataBind();
                    ddlComponents.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Category", "0"));
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

        public void totalCategoryonpercentage(string componentCatID, string ClassId)
        {
            try
            {
                string sumper;
                decimal sumper1;
                decimal footerper1;
                decimal totalresult1;
                decimal updatedResult;
                int decimalPlaces = 2;

                using (SqlConnection conn = new SqlConnection(strconnect))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GettotalCategoryonpercentage", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PertCate_ID", componentCatID);
                        cmd.Parameters.AddWithValue("@ClassID", ClassId);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable ds = new DataTable();
                            sda.Fill(ds);

                            if (ds.Rows.Count > 0)
                            {
                                sumper = ds.Rows[0]["totalper"].ToString();
                                sumper1 = Convert.ToDecimal(sumper);

                                foreach (GridViewRow gridviedrow in GridViewComponent.Rows)
                                {
                                    Label lblCompnent1 = (Label)gridviedrow.FindControl("lblCompnent1");
                                    decimal empContriPerValue = Convert.ToDecimal(txtContributionPer.Text);

                                    if (lblCompnent1.Text == "Basic")
                                    {
                                        totalresult1 = a - sumper1;
                                    }
                                    else
                                    {
                                        totalresult1 = a - sumper1;
                                        //totalresult1 = a - (sumper1 + footerper1);
                                    }

                                    updatedResult = totalresult1 - empContriPerValue;
                                    updatedResult = Math.Round(updatedResult, decimalPlaces);
                                    lblResult.Text = "Remaining Percentage: " + updatedResult.ToString();
                                }
                            }
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
                    int lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();

                    using (SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", DeviceCon))
                    {
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
                            // lblMessage.Visible = false;
                            // lblMessage.Text = "Error Details Save Successfully";
                        }
                        else
                        {
                            // lblMessage.Visible = false;
                            // lblMessage.Text = "Error Details Not Save Successfully";
                        }
                    }
                }
            }
            finally { }
        }

        public void BindEmpSubCategory(string ClassId)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);

                SqlCommand cmd = new SqlCommand("SP_ViewEmpCompansion", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PertCate_ID", "2");
                cmd.Parameters.AddWithValue("@ClassID", ClassId);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    ddlEmpCompansion.DataSource = ds;
                    ddlEmpCompansion.DataTextField = "Perticular";//Description
                    ddlEmpCompansion.DataValueField = "ID";
                    ddlEmpCompansion.DataBind();
                    ddlEmpCompansion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Category", "0"));
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

        public void BindEmpDeductionSubCategory(string ClassId)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);

                SqlCommand cmd = new SqlCommand("SP_ViewAnnualsalaryDeductionStructure", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PertCate_ID", "3");
                cmd.Parameters.AddWithValue("@ClassID", ClassId);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    ddlEmpContribution.DataSource = ds;
                    ddlEmpContribution.DataTextField = "Perticular";//Description
                    ddlEmpContribution.DataValueField = "ID";
                    ddlEmpContribution.DataBind();
                    ddlEmpContribution.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Category", "0"));
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

        public void ViewComponent(string ClassId)
        {
            using (SqlConnection con = new SqlConnection(strconnect))
            {

                SqlCommand cmd = new SqlCommand("SP_ViewAnnualsalaryStructure", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PertCate_ID", "1");

                cmd.Parameters.AddWithValue("@ClassID", ClassId);
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
                            LinkButton btnDeleteComponent = (LinkButton)gridviedrow.FindControl("btnDeleteComponent");

                            btnDeleteComponent.Visible = true;
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

        public void ViewTestComponent(string ClassId)
        {
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewTestAnnualSalStructure", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PertCate_ID", "1");
                cmd.Parameters.AddWithValue("@Perticular", "Basic ");
                cmd.Parameters.AddWithValue("@ClassID", ddlTestClass.SelectedItem.Value);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        GridViewComponentModal.DataSource = ds;
                        GridViewComponentModal.DataBind();

                        foreach (GridViewRow gridviedrow in GridViewComponentModal.Rows)
                        {
                            LinkButton btnDeleteAnnualSal = (LinkButton)gridviedrow.FindControl("btnDeleteAnnualSal");

                            btnDeleteAnnualSal.Visible = true;
                        }
                    }
                    else
                    {
                        ds.Rows.Add(ds.NewRow());
                        GridViewComponentModal.DataSource = ds;
                        GridViewComponentModal.DataBind();

                    }


                }

            }


        }

        public DataTable ViewComponentpdf(string ClassId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ViewAnnualsalaryStructure", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PertCate_ID", "1");
                    cmd.Parameters.AddWithValue("@ClassID", ClassId);

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        ad.Fill(dt);
                    }

                    GridViewComponent.DataSource = dt;
                    GridViewComponent.DataBind();
                }
            }

            return dt;
        }

        public void ViewEmpCompansion(string ClassId)
        {


            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewEmpCompansion", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PertCate_ID", "2");
                cmd.Parameters.AddWithValue("@ClassID", ClassId);
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
                            LinkButton btnDeleteComp = (LinkButton)gridviedrow.FindControl("btnDeleteComp");

                            btnDeleteComp.Visible = true;
                        }
                    }
                    else
                    {
                        ds.Rows.Add(ds.NewRow());
                        GridViewEmpCompansion.DataSource = ds;
                        GridViewEmpCompansion.DataBind();


                        //SuccessDiv1.Visible = false;
                        //lblMsg.Visible = false;
                        //lblMsg1.Visible = false;
                        //msgdiv.Visible = false;

                    }


                }

            }

        }
        public void ViewTestEmpCompansion(string ClassId)
        {
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewEmpCompansion", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PertCate_ID", "2");
                cmd.Parameters.AddWithValue("@ClassID", ClassId);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        GridViewEmpCompansionModal.DataSource = ds;
                        GridViewEmpCompansionModal.DataBind();

                        foreach (GridViewRow gridviedrow in GridViewEmpCompansionModal.Rows)
                        {
                            LinkButton btnDeleteAnnualComp = (LinkButton)gridviedrow.FindControl("btnDeleteAnnualComp");

                            btnDeleteAnnualComp.Visible = true;
                        }
                    }
                    else
                    {
                        ds.Rows.Add(ds.NewRow());
                        GridViewEmpCompansionModal.DataSource = ds;
                        GridViewEmpCompansionModal.DataBind();


                    }


                }

            }

        }

        public DataTable ViewEmpCompansionpdf(string ClassId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(strconnect))
            {
                // using (SqlCommand cmd = new SqlCommand("SP_ViewAnnualsalaryStructure", con))
                using (SqlCommand cmd = new SqlCommand("SP_ViewEmpCompansion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PertCate_ID", "2");
                    cmd.Parameters.AddWithValue("@ClassID", ClassId);

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        ad.Fill(dt);
                    }

                    GridViewEmpCompansion.DataSource = dt;
                    GridViewEmpCompansion.DataBind();
                }
            }

            return dt;
        }

        public void ViewEmployeeDeduction(string ClassId)
        {
            using (SqlConnection con = new SqlConnection(strconnect))
            {

                SqlCommand cmd = new SqlCommand("SP_ViewAnnualsalaryDeductionStructure", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PertCate_ID", "3");
                // cmd.Parameters.AddWithValue("@ClassID",ddlClass.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@ClassID", ClassId);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    DataTable ds = new DataTable();

                    sda.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        EmpContributionGridView.DataSource = ds;
                        EmpContributionGridView.DataBind();

                        foreach (GridViewRow gridviedrow in EmpContributionGridView.Rows)
                        {
                            LinkButton btnDeleteEmpDeduction = (LinkButton)gridviedrow.FindControl("btnDeleteEmpDeduction");

                            btnDeleteEmpDeduction.Visible = true;
                        }
                    }
                    else
                    {
                        ds.Rows.Add(ds.NewRow());
                        EmpContributionGridView.DataSource = ds;
                        EmpContributionGridView.DataBind();

                    }


                }

            }
        }
        public void ViewTestDeductionComponent(string ClassId)
        {
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewTestAnnualDeductionSalStructure", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PertCate_ID", "3");
                cmd.Parameters.AddWithValue("@Perticular", "Basic ");
                cmd.Parameters.AddWithValue("@ClassID", ddlTestClass.SelectedItem.Value);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        EmpContributionGridView.DataSource = ds;
                        EmpContributionGridView.DataBind();

                        foreach (GridViewRow gridviedrow in EmpContributionGridView.Rows)
                        {
                            LinkButton btnDeleteAnnualSal = (LinkButton)gridviedrow.FindControl("btnDeleteAnnualSal");

                            btnDeleteAnnualSal.Visible = true;
                        }
                    }
                    else
                    {
                        ds.Rows.Add(ds.NewRow());
                        EmpContributionGridView.DataSource = ds;
                        EmpContributionGridView.DataBind();

                    }


                }

            }
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

        public void Clear()
        {
            txtComponentModal.Text = string.Empty;
            txtPercentageModal.Text = string.Empty;
            //txtAmountModal.Text = string.Empty;
            ddlCatTypeModal.SelectedIndex = 0;


            txtComponentModComp.Text = string.Empty;
            txtPercentageModComp.Text = string.Empty;
            //txtAmountModComp.Text = string.Empty;


            txtDeductionComp.Text = string.Empty;
            txtDeductionPerccentage.Text = string.Empty;
            //txtDeductionAmount.Text = string.Empty;

        }

        

     

        public void GetClassDetails()
        {
            try
            {

                string ClassId;
                string ClassName = Convert.ToString(ddlClass.SelectedItem.Text);
                ClassId = HttpUtility.UrlDecode(Request.QueryString["ID"]);
                lblClassSalaryId.Text = ClassId;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_ViewAnnualsalaryStructure", UserCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    //cmd.Parameters.AddWithValue("@id", lblClassSalaryId.Text);
                    cmd.Parameters.AddWithValue("@PertCate_ID", "1");

                    cmd.Parameters.AddWithValue("@ClassID", ClassId);
                    //cmd.Parameters.AddWithValue("@ClassName", ClassName);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ddlClass.SelectedItem.Text = dt.Rows[0]["ClassName"].ToString();

                        lblClassSalaryId.Text = dt.Rows[0]["ClassId"].ToString();
                        string chkEmp;
                        chkEmp = dt.Rows[0]["status"].ToString();


                        if (chkEmp != null)
                        {
                            if (chkEmp == "True")
                            {

                                EmpCompansion.Visible = true;
                                EmployeeContribution.Visible = true;

                            }
                            else
                            {
                                EmpCompansion.Visible = false;
                                EmployeeContribution.Visible = false;
                            }




                            ClassName = Convert.ToString(ddlClass.SelectedItem.Text);
                            dt = new DataTable();
                            DataColumn dc = new DataColumn("ClassId", typeof(int));
                            dt.Columns.Add(dc);

                            dc = new DataColumn("ClassName", typeof(string));
                            dt.Columns.Add(dc);

                            DataRow firstRow;
                            for (int i = 0; i < 1; i++)
                            {
                                firstRow = dt.NewRow();
                                firstRow["ClassId"] = ClassId;
                                firstRow["ClassName"] = ClassName;
                                // Be sure to add the new row to the DataRowCollection.
                                dt.Rows.Add(firstRow);
                            }
                            ddlClass1.DataSource = dt;
                            ddlClass1.DataTextField = "ClassName";
                            ddlClass1.DataValueField = "ClassId";
                            ddlClass1.DataBind();

                            ddlClass2.DataSource = dt;
                            ddlClass2.DataTextField = "ClassName";
                            ddlClass2.DataValueField = "ClassId";
                            ddlClass2.DataBind();

                            ddlTestClass.DataSource = dt;
                            ddlTestClass.DataTextField = "ClassName";
                            ddlTestClass.DataValueField = "ClassId";
                            ddlTestClass.DataBind();

                            ddlEmpDeduction.DataSource = dt;
                            ddlEmpDeduction.DataTextField = "ClassName";
                            ddlEmpDeduction.DataValueField = "ClassId";
                            ddlEmpDeduction.DataBind();

                            ViewTestComponent(ClassId);
                            ViewTestEmpCompansion(ClassId);

                            ViewComponent(ClassId);
                            ViewEmpCompansion(ClassId);

                            BindSubCategory(ClassId);
                            BindEmpSubCategory(ClassId);

                            ViewEmployeeDeduction(ClassId);
                            BindEmpDeductionSubCategory(ClassId);

                            ViewComponentpdf(ClassId);

                            ViewEmpCompansionpdf(ClassId);

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
            finally
            {
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
                          
                            bindClass();

                            GetCompanyAddress();
                           
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
                                bindClass();
                                GetClassDetails();
                                GetCompanyAddress();
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

        protected void btnSaveEmpModalContribution_Click(object sender, EventArgs e)
        {

        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string ClassId = Convert.ToString(ddlClass.SelectedItem.Value);
                string ClassName = Convert.ToString(ddlClass.SelectedItem.Text);

                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn("ClassId", typeof(int));
                dt.Columns.Add(dc);

                dc = new DataColumn("ClassName", typeof(string));
                dt.Columns.Add(dc);

                DataRow firstRow;
                for (int i = 0; i < 1; i++)
                {
                    firstRow = dt.NewRow();
                    firstRow["ClassId"] = ClassId;
                    firstRow["ClassName"] = ClassName;
                    // Be sure to add the new row to the DataRowCollection.
                    dt.Rows.Add(firstRow);
                }

                ddlClass1.DataSource = dt;
                ddlClass1.DataTextField = "ClassName";
                ddlClass1.DataValueField = "ClassId";
                ddlClass1.DataBind();

                ddlClass2.DataSource = dt;
                ddlClass2.DataTextField = "ClassName";
                ddlClass2.DataValueField = "ClassId";
                ddlClass2.DataBind();

                ddlTestClass.DataSource = dt;
                ddlTestClass.DataTextField = "ClassName";
                ddlTestClass.DataValueField = "ClassId";
                ddlTestClass.DataBind();

                ddlEmpDeduction.DataSource = dt;
                ddlEmpDeduction.DataTextField = "ClassName";
                ddlEmpDeduction.DataValueField = "ClassId";
                ddlEmpDeduction.DataBind();

                //popup for test Class Selection for calculation
                //GetClassDetails(ClassId);
                ViewTestComponent(ClassId);
                ViewTestEmpCompansion(ClassId);

                ViewComponent(ClassId);
                ViewEmpCompansion(ClassId);

                BindSubCategory(ClassId);
                BindEmpSubCategory(ClassId);

                ViewEmployeeDeduction(ClassId);
                BindEmpDeductionSubCategory(ClassId);
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

        protected void ddlTestClass_SelectedIndexChanged(object sender, EventArgs e)
        {


            //BindSubCategory(ClassId);
            //ViewTestDeductionComponent(ClassId);

        }

        protected void btnAddEmpDeduction_Click(object sender, EventArgs e)
        {
            try
            {
                string ClassId = Convert.ToString(ddlClass.SelectedItem.Value);
                if (ClassId == "0")//item == "Select Item" ||AND Item
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Class!')", true);
                }
                else
                {
                    TextBox txtDeductionComp = (TextBox)EmpContributionGridView.FooterRow.FindControl("txtDeductionComp");
                    DropDownList ddlDeductionCat = (DropDownList)EmpContributionGridView.FooterRow.FindControl("ddlDeductionCat");
                    TextBox txtDeductionPercentages = (TextBox)EmpContributionGridView.FooterRow.FindControl("txtDeductionPercentages");
                    TextBox txtDeductionAmounts = (TextBox)EmpContributionGridView.FooterRow.FindControl("txtDeductionAmounts");


                    using (SqlConnection con = new SqlConnection(strconnect))
                    {

                        SqlCommand cmd = new SqlCommand("SP_SaveEmpDeductionComponent", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Perticular", txtDeductionComp.Text);
                        cmd.Parameters.AddWithValue("@PerticularType", ddlDeductionCat.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Percentage", txtDeductionPercentages.Text);
                        cmd.Parameters.AddWithValue("@Amount", txtDeductionAmounts.Text);
                        cmd.Parameters.AddWithValue("@PertCategory", ddlDeductionCat.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@PertCate_ID", ddlDeductionCat.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@ClassID", ClassId);
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
                            BindEmpDeductionSubCategory(ClassId);
                            ViewEmployeeDeduction(ClassId);
                            Toasteralert.Visible = true;
                            lblMessage.Text = "Component Deduction Save Successfully";
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Component Deduction already Available";

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
            finally { }
        }

        protected void btnDeleteEmpDeduction_Click(object sender, EventArgs e)
        {
            
            try
            {
                string ID;
                string ClassID;
                string PertiCateID;

                var rows = EmpContributionGridView.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);

                ID = ((Label)rows[rowindex].FindControl("lblDeductionCompID")).Text;
                ClassID = ((Label)rows[rowindex].FindControl("lblClassID")).Text;
                PertiCateID = ((Label)rows[rowindex].FindControl("lblDeductionPertCatID")).Text;

                SqlConnection DeviceCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_DeleteEmpDeduction", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@CreatedBy", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    ViewEmployeeDeduction(ClassID);
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Employee Deduction Deleted Successfully!";

                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Employee Deduction Details Not Deleted!";

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

        protected void btnEditComponent_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaveEmpDeductionModal_Click(object sender, EventArgs e)
        {
            try
            {
                string ClassId = Convert.ToString(ddlEmpDeduction.SelectedItem.Value);
                if (ClassId == "0")//item == "Select Item" ||AND Item
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Class!')", true);
                }
                else
                {
                    SqlConnection con = new SqlConnection(strconnect);  // db connect
                    SqlCommand cmd = new SqlCommand("SP_SaveDeductionComponentModal", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PertCategory", ddlDeductin.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@PertCate_ID", ddlDeductin.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@ClassID", ddlEmpDeduction.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Perticular", txtDeductionComp.Text);
                    cmd.Parameters.AddWithValue("@PerticularType", ddlDeductionType.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Percentage ", txtDeductionPerccentage.Text);
                    cmd.Parameters.AddWithValue("@Amount", txtDeductionAmount.Text);
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
                        // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Item Details Save Successfully!')", true);
                        //bindClass();
                        //BindSubCategory();
                        //ViewComponent(ClassId);
                        //BindEmpSubCategory();
                        //ViewEmpCompansion(ClassId);
                        //ViewEmployeeDeduction(ddlEmpDeduction.SelectedItem.Value);
                        //totalCategoryonpercentage(ddlComponentCat.SelectedItem.Value, ClassId);
                        //totalCategoryonpercentage(ddlComponentCat.SelectedItem.Value);

                        ViewEmployeeDeduction(ClassId);
                        Toasteralert.Visible = true;
                        lblMessage.Text = "Employee Deduction Save Successfully";

                    }
                    else
                    {
                        BindEmpDeductionSubCategory(ClassId);
                        ViewEmployeeDeduction(ClassId);
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Employee Deduction already Available";
                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Item Details Not Save Successfully!')", true);
                    }

                    Clear();
                    ViewEmployeeDeduction(ClassId);
                    con.Close();

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
                //bindItem();
                //Clear1();
                DeviceCon.Close();
            }
            finally

            {

            }
        }

        protected void ddlEmpContribution_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int lblDeductionCompID = Convert.ToInt32(ddlEmpContribution.SelectedValue);

                TextBox txtDeductionComp = (TextBox)EmpContributionGridView.FooterRow.FindControl("txtDeductionComp");
                TextBox txtDeductionPercentages = (TextBox)EmpContributionGridView.FooterRow.FindControl("txtDeductionPercentages");
                TextBox txtDeductionAmounts = (TextBox)EmpContributionGridView.FooterRow.FindControl("txtDeductionAmounts");

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetEmpDeductionContributionByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ID", lblDeductionCompID);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtDeductionComp.Text = dt.Rows[0]["Perticular"].ToString();
                        txtDeductionPercentages.Text = dt.Rows[0]["Percentage"].ToString();
                        txtDeductionAmounts.Text = dt.Rows[0]["Amount"].ToString();

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

        protected void GridViewComponent_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            // Decimal oldper, newper1, totalper;
            string CatId1, newper1, oldper1;

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                TextBox txtPercentage = (TextBox)e.Row.FindControl("txtPercentage");

                oldper1 = txtPercentage.Text;

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPercentage1 = (Label)e.Row.FindControl("lblPercentage1");
                Label lblPertCateID = (Label)e.Row.FindControl("lblPertCateID");


                newper1 = lblPercentage1.Text;
                CatId1 = lblPertCateID.Text;

            }

        }


        protected void btnCloseModal_Click(object sender, EventArgs e)
        {

        }

        protected void ddlComponents_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int ComponentID = Convert.ToInt32(ddlComponents.SelectedValue);

                TextBox txtCompnent = (TextBox)GridViewComponent.FooterRow.FindControl("txtCompnent");
                DropDownList ddlCatType1 = (DropDownList)GridViewComponent.FooterRow.FindControl("ddlCatType1");
                TextBox txtPercentage = (TextBox)GridViewComponent.FooterRow.FindControl("txtPercentage");
                TextBox txtAmount = (TextBox)GridViewComponent.FooterRow.FindControl("txtAmount");

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetComponentByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ID", ComponentID);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtCompnent.Text = dt.Rows[0]["Perticular"].ToString();
                        ddlCatType1.SelectedItem.Text = dt.Rows[0]["PerticularType"].ToString();
                        txtPercentage.Text = dt.Rows[0]["Percentage"].ToString();
                        txtAmount.Text = dt.Rows[0]["Amount"].ToString();

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

        protected void chkEmp_CheckedChanged(object sender, EventArgs e)
        {
            string ClassId = Convert.ToString(ddlClass.SelectedItem.Value);

            if (chkEmp.Checked)
            {
                EmpCompansion.Visible = true;
                EmployeeContribution.Visible = true;
            }
            else
            {

                EmpCompansion.Visible = false;
                EmployeeContribution.Visible = false;
            }

            BindEmpSubCategory(ClassId);
            BindEmpDeductionSubCategory(ClassId);
            ViewEmpCompansion(ClassId);

            ViewEmployeeDeduction(ClassId);

        }

        protected void ddlEmpCompansion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int EmpCompansionID = Convert.ToInt32(ddlEmpCompansion.SelectedValue);

                TextBox txtCompnents = (TextBox)GridViewEmpCompansion.FooterRow.FindControl("txtCompnents");
                TextBox txtPercentages = (TextBox)GridViewEmpCompansion.FooterRow.FindControl("txtPercentages");
                TextBox txtAmounts = (TextBox)GridViewEmpCompansion.FooterRow.FindControl("txtAmounts");


                //*//---------------------------------------------------------------//*//
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetEmpContributionByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ID", EmpCompansionID);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtCompnents.Text = dt.Rows[0]["Perticular"].ToString();
                        txtPercentages.Text = dt.Rows[0]["Percentage"].ToString();
                        txtAmounts.Text = dt.Rows[0]["Amount"].ToString();

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

        protected void btnDeleteComponent_Click(object sender, EventArgs e)
        {
            try
            {
                string ID;
                string ClassID;
                string PertCateID;

                var rows = GridViewComponent.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);

                ID = ((Label)rows[rowindex].FindControl("lblCompnentID")).Text;
                ClassID = ((Label)rows[rowindex].FindControl("lblCompnentClassID")).Text;
                PertCateID = ((Label)rows[rowindex].FindControl("lblComponentPertCateID")).Text;

                SqlConnection DeviceCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_DeleteComponent", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@CreatedBy", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    ViewComponent(ClassID);
                    Toasteralert.Visible = true;
                    lblMessage.Text = "Component Deleted Successfully!";
                    totalCategoryonpercentage(PertCateID, ClassID);

                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Component Details already Available";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Component Details Not Deleted!')", true);

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

        protected void btnAddComponent_Click(object sender, EventArgs e)
        {
            try
            {
                string ClassId = Convert.ToString(ddlClass.SelectedItem.Value);
                if (ClassId == "0")//item == "Select Item" ||AND Item
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Class!')", true);
                }
                else
                {
                    TextBox txtCompnent = (TextBox)GridViewComponent.FooterRow.FindControl("txtCompnent");
                    DropDownList ddlCatType1 = (DropDownList)GridViewComponent.FooterRow.FindControl("ddlCatType1");
                    TextBox txtPercentage = (TextBox)GridViewComponent.FooterRow.FindControl("txtPercentage");
                    TextBox txtAmount = (TextBox)GridViewComponent.FooterRow.FindControl("txtAmount");
                    DropDownList ddlComponentCat1 = (DropDownList)GridViewComponent.FooterRow.FindControl("ddlComponentCat1");
                    DropDownList ddlCompClass2 = (DropDownList)GridViewComponent.FooterRow.FindControl("ddlCompClass2");

                    using (SqlConnection con = new SqlConnection(strconnect))
                    {

                        SqlCommand cmd = new SqlCommand("SP_SaveComponent", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Perticular", txtCompnent.Text);
                        cmd.Parameters.AddWithValue("@PerticularType", ddlCatType1.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Percentage", txtPercentage.Text);
                        cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                        cmd.Parameters.AddWithValue("@PertCategory", ddlComponentCat1.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@PertCate_ID", ddlComponentCat1.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@ClassID", ClassId);
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
                            BindSubCategory(ClassId);
                            ViewComponent(ClassId);
                            BindEmpSubCategory(ClassId);
                            ViewEmpCompansion(ClassId);

                            Toasteralert.Visible = true;
                            lblMessage.Text = "Component Details Save Successfully";
                            totalCategoryonpercentage(ddlComponentCat1.SelectedItem.Value, ClassId);


                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Component Details already Available";

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
            finally { }
        }

        protected void btnDeleteComp_Click(object sender, EventArgs e)
        {
            try
            {
                string ID;
                string ClassID;
                string PertCateID1;

                var rows = GridViewEmpCompansion.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);

                ID = ((Label)rows[rowindex].FindControl("lblCompnentsID")).Text;
                ClassID = ((Label)rows[rowindex].FindControl("lblCompnentsClassID1")).Text;
                PertCateID1 = ((Label)rows[rowindex].FindControl("lblEmplyrCobtriPertCatID")).Text;

                SqlConnection DeviceCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_DeleteComponent", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@CreatedBy", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                //cmd.Parameters.AddWithValue("@PertCate_ID", "2");
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Employer Contribution Deleted Successfully!')", true);
                    //Toasteralert.Visible = false;
                    //deleteToaster.Visible = true;

                    Toasteralert.Visible = true;
                    lblMessage.Text = "Employer Contribution Deleted Successfully";
                    //lblMesDelete.Text = "Employer Contribution Deleted Successfully";
                    totalCategoryonpercentage(PertCateID1, ClassID);
                    ViewEmpCompansion(ClassID);
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Employer Contribution Details Not Deleted!";
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Employer Contribution Details Not Deleted!')", true);
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

        protected void btnAddComp_Click(object sender, EventArgs e)
        {
            try
            {
                string ClassId = Convert.ToString(ddlClass.SelectedItem.Value);
                if (ClassId == "0")//item == "Select Item" ||AND Item
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Class!')", true);
                }
                else
                {
                    TextBox txtCompnents = (TextBox)GridViewEmpCompansion.FooterRow.FindControl("txtCompnents");
                    DropDownList ddlCompasionCat = (DropDownList)GridViewEmpCompansion.FooterRow.FindControl("ddlCompasionCat");
                    TextBox txtPercentages = (TextBox)GridViewEmpCompansion.FooterRow.FindControl("txtPercentages");
                    TextBox txtAmounts = (TextBox)GridViewEmpCompansion.FooterRow.FindControl("txtAmounts");


                    using (SqlConnection con = new SqlConnection(strconnect))
                    {

                        SqlCommand cmd = new SqlCommand("SP_SaveEmpComp", con);
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Perticular", txtCompnents.Text);
                        cmd.Parameters.AddWithValue("@Percentage", txtPercentages.Text);
                        cmd.Parameters.AddWithValue("@Amount", txtAmounts.Text);
                        cmd.Parameters.AddWithValue("@PertCategory", ddlCompasionCat.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@PertCate_ID", ddlCompasionCat.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@ClassID", ddlClass.SelectedItem.Value);
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

                            BindEmpSubCategory(ClassId);
                            ViewEmpCompansion(ClassId);

                            Toasteralert.Visible = true;
                            lblMessage.Text = "Employer Contribution Save Successfully";


                            totalCategoryonpercentage(ddlCompasionCat.SelectedItem.Value, ddlClass.SelectedItem.Value);
                        }
                        else
                        {
                            Toasteralert.Visible = false;
                            deleteToaster.Visible = true;
                            lblMesDelete.Text = "Employer Contribution already Available";

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string ClassId = Convert.ToString(ddlClass1.SelectedItem.Value);
                if (ClassId == "0")//item == "Select Item" ||AND Item
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Class!')", true);
                }
                else
                {


                    SqlConnection con = new SqlConnection(strconnect);  // db connect
                    SqlCommand cmd = new SqlCommand("SP_SaveComponentModal", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PertCategory", ddlComponentCat.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@PertCate_ID", ddlComponentCat.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@ClassID", ClassId);
                    cmd.Parameters.AddWithValue("@Perticular", txtComponentModal.Text);
                    cmd.Parameters.AddWithValue("@PerticularType", ddlCatTypeModal.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Percentage ", txtPercentageModal.Text);
                    cmd.Parameters.AddWithValue("@Amount", txtAmountModal.Text);
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

                        BindSubCategory(ClassId);
                        ViewComponent(ClassId);
                        BindEmpSubCategory(ClassId);
                        ViewEmpCompansion(ClassId);
                        Toasteralert.Visible = true;
                        lblMessage.Text = "Component Details Save Successfully";
                        totalCategoryonpercentage(ddlComponentCat.SelectedItem.Value, ClassId);

                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Component Details already Available";

                    }


                    Clear();
                    ViewComponent(ClassId);
                    con.Close();
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
                //bindItem();
                //Clear1();
                DeviceCon.Close();
            }
            finally

            {

            }
        }

        protected void btnSaveModalComp_Click(object sender, EventArgs e)
        {
            try
            {
                string ClassId = Convert.ToString(ddlClass2.SelectedItem.Value);
                if (ClassId == "0")//item == "Select Item" ||AND Item
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Class!')", true);
                }
                else
                {
                    SqlConnection con = new SqlConnection(strconnect);  // db connect
                    SqlCommand cmd = new SqlCommand("SP_SaveEmpContributionModal", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PertCategory", ddlCompensionCat.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@PertCate_ID", ddlCompensionCat.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@ClassID", ClassId);
                    cmd.Parameters.AddWithValue("@Perticular", txtComponentModComp.Text);
                    cmd.Parameters.AddWithValue("@Percentage ", txtPercentageModComp.Text);
                    cmd.Parameters.AddWithValue("@Amount", txtAmountModComp.Text);
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
                        // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Item Details Save Successfully!')", true);
                        BindSubCategory(ClassId);
                        ViewComponent(ClassId);
                        BindEmpSubCategory(ClassId);
                        ViewEmpCompansion(ClassId);

                        //Toasteralert.Visible = false;
                        //deleteToaster.Visible = true;

                        Toasteralert.Visible = true;
                        lblMessage.Text = "Employer Contribution Save Successfully";
                        //lblMesDelete.Text = "Employer Contribution Save Successfully";

                        totalCategoryonpercentage(ddlComponentCat.SelectedItem.Value, ClassId);

                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Employer Contribution already Available";
                        // chkEmp.Checked = true;
                        // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Item Details Not Save Successfully!')", true);
                    }


                    Clear();
                    con.Close();
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

                DeviceCon.Close();
            }
            finally

            {

            }
        }

        protected void btnTest_Click1(object sender, EventArgs e)
        {
            Response.Redirect("TestPreSalary.aspx", true);
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string ClassId = Convert.ToString(ddlTestClass.SelectedItem.Value);
                if (ClassId == "0")//item == "Select Item" ||AND Item
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Class!')", true);
                }
                else
                {

                    Decimal AnnualSalary = Convert.ToDecimal(txtPackage.Text);
                    Decimal MonthlySalary = AnnualSalary / 12;
                    Decimal Amount, AmountAnnual, Percentage, basicSalaryAmount = 0, n = 0, ContributionPer;
                    SqlConnection UserCon = new SqlConnection(strconnect);
                    foreach (GridViewRow gridviedrow in GridViewComponentModal.Rows)
                    {
                        Label lblID = (Label)gridviedrow.FindControl("lblID");
                        Label lblComponentID = (Label)gridviedrow.FindControl("lblComponentID");
                        Label lblCompnent1 = (Label)gridviedrow.FindControl("lblCompnent1");
                        Label lblPercentage1 = (Label)gridviedrow.FindControl("lblPercentage1");
                        Label lblAmount1 = (Label)gridviedrow.FindControl("lblAmount1");
                        Label lblAmountYr1 = (Label)gridviedrow.FindControl("lblAmountYr1");
                        Percentage = Convert.ToDecimal(lblPercentage1.Text);
                        string component1 = lblCompnent1.Text;
                        Amount = MonthlySalary * (Percentage / 100);
                        lblAmount1.Text = Convert.ToString(Amount);
                        AmountAnnual = AnnualSalary * (Percentage / 100);
                        lblAmountYr1.Text = Convert.ToString(AmountAnnual);

                        //contributionPer = txtContributionTotal.Text * 100 / AnnualSalary;
                        if (lblCompnent1.Text == "Basic")
                        {
                            basicSalaryAmount = AmountAnnual;
                        }
                    }

                    foreach (GridViewRow gridviedrow in GridViewEmpCompansionModal.Rows)
                    {
                        Label lblComponentsID1 = (Label)gridviedrow.FindControl("lblComponentsID1");//lblComponentsID1
                        Label lblCompnents1 = (Label)gridviedrow.FindControl("lblCompnents1");
                        Label lblPercentages1 = (Label)gridviedrow.FindControl("lblPercentages1");
                        Label lblAmounts1 = (Label)gridviedrow.FindControl("lblAmounts1");
                        Percentage = Convert.ToDecimal(lblPercentages1.Text);
                        AmountAnnual = basicSalaryAmount * (Percentage / 100);
                        lblAmounts1.Text = Convert.ToString(AmountAnnual);

                        n = n + Decimal.Parse(lblAmounts1.Text);
                        txtContributionTotal.Text = n.ToString();
                        ContributionPer = n * 100 / AnnualSalary;
                        txtContributionPer.Text = ContributionPer.ToString();
                        string contributionPer = txtContributionPer.Text;
                        lblEmpContriPer.Text = "Employee Contribution Percentage : " + contributionPer;
                        lblpcatid.Text = lblComponentsID1.Text;
                    }

                    decimal empContriPerValue = Convert.ToDecimal(txtContributionPer.Text);
                    string PcatID = "1"; // Provide the appropriate CatId
                    //string PcatID = lblpcatid.Text;
                    totalCategoryonpercentage(PcatID, ClassId);

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

        //=====================================================================//
        protected void linkbtnPDFSalary_Click(object sender, EventArgs e)
        {
            try
            {
                string ClassId = Convert.ToString(ddlClass.SelectedItem.Value);
                if (ClassId == "0")//item == "Select Item" ||AND Item
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Class!')", true);
                }
                else
                {

                    int _totalColumns = 4;//
                    int _totalColumns1 = 4;
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(4);//change
                    PdfPTable _pdfPTable1 = new PdfPTable(4);
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

                    Document _document1 = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
                    _document1.SetPageSize(PageSize.A4);
                    _document1.SetMargins(20f, 20f, 20f, 20f);
                    _pdfPTable1.WidthPercentage = 500;
                    _pdfPTable1.TotalWidth = 500f;
                    _pdfPTable1.LockedWidth = true;
                    _pdfPTable1.HorizontalAlignment = Element.ALIGN_CENTER;
                    _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

                    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                    {
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(_document, memoryStream);
                        //Phrase phrase = null;
                        //PdfPCell cell = null;
                        //PdfPTable table = null;
                        //Color color = new Color();

                        _document.Open();
                        _pdfPTable.SetWidths(new float[] { 3f, 9f, 9f, 9f });//column width in doc       
                                                                             //----Header PDF--------------------------//
                                                                             //Company Logo

                        _pdfPTable1.SetWidths(new float[] { 3f, 9f, 9f, 9f });

                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 1;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPTable.AddCell(cell);
                        // _pdfPTable1.AddCell(cell);

                        //...!..image logo..// 

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
                        _pdfPCell.Colspan = 3;
                        _pdfPCell.BorderColor = BaseColor.WHITE;
                        _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.PaddingBottom = 1f;
                        _pdfPCell.PaddingTop = 0f;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();
                        //_pdfPTable1.AddCell(_pdfPCell);
                        //_pdfPTable1.CompleteRow();


                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                        _pdfPCell.Colspan = 4;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();
                        //_pdfPTable1.AddCell(_pdfPCell);
                        //_pdfPTable1.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("SalaryStructure", _fontStyle));
                        _pdfPCell.Colspan = 3;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPCell.PaddingRight = 40f;
                        _pdfPCell.PaddingTop = 15f;
                        _pdfPTable.AddCell(_pdfPCell);
                        //_pdfPTable1.AddCell(_pdfPCell);

                        //-------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 1;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPCell.PaddingTop = 15f;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();
                        //_pdfPTable1.AddCell(_pdfPCell);
                        //_pdfPTable1.CompleteRow();


                        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        _pdfPCell = new PdfPCell(new Phrase("------------------------*------------------------", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPCell.PaddingBottom = 5f;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();
                        //_pdfPTable1.AddCell(_pdfPCell);
                        //_pdfPTable1.CompleteRow();

                        // Add the "Component" label above the GridView content
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


                        // Add the "Employee Contribution" label above the second GridView content
                        _fontStyle = FontFactory.GetFont("Arial", 12f, Font.BOLD, BaseColor.BLACK);
                        _pdfPCell = new PdfPCell(new Phrase("Employee Contribution:", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns1;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPCell.PaddingBottom = 10f;
                        _pdfPTable1.AddCell(_pdfPCell);
                        _pdfPTable1.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table1----------------------------------////
                        //string ClassId = Convert.ToString(ddlClass.SelectedItem.Value);//give restriction for class selection 
                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = ViewComponentpdf(ClassId);
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Serial No", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Perticular", _fontStyle));
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
                        _pdfPCell = new PdfPCell(new Phrase("Amount", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["Perticular"].ToString(), _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["Amount"].ToString(), _fontStyle));
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

                        //----------------------------------Table2----------------------------------////

                        DataTable _Vhrlist1 = new DataTable();
                        _Vhrlist1 = ViewEmpCompansionpdf(ClassId);
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Serial No", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable1.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Perticular", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable1.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Percentage", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable1.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Amount", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable1.AddCell(_pdfPCell);


                        _pdfPTable1.CompleteRow();
                        #endregion

                        #region "Table Body"
                        _fontStyle = FontFactory.GetFont("Tahoma", 10f, 0);
                        int serialnumber1 = 1;

                        foreach (DataRow row in _Vhrlist1.Rows)
                        {
                            _pdfPCell = new PdfPCell(new Phrase(serialnumber1++.ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable1.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Perticular"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable1.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Percentage"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable1.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Amount"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable1.AddCell(_pdfPCell);


                        }
                        #endregion

                        #region "Table Footer"
                        String text1 = "Page " + writer.PageNumber + " of ";
                        BaseFont bf1 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        PdfContentByte cb1 = writer.DirectContent;
                        PdfTemplate footerTemplate1 = cb.CreateTemplate(40, 40);

                        //Move the pointer and draw line to separate footer section from rest of page  
                        cb.MoveTo(40, _document.PageSize.GetBottom(40));
                        cb.LineTo(_document.PageSize.Width - 40, _document.PageSize.GetBottom(40));
                        cb.Stroke();

                        cb.BeginText();
                        cb.SetFontAndSize(bf1, 9);
                        cb.SetTextMatrix(_document.PageSize.GetRight(100), _document.PageSize.GetBottom(30));
                        cb.ShowText(text1);
                        cb.EndText();
                        float len1 = bf1.GetWidthPoint(text1, 9);
                        cb.AddTemplate(footerTemplate1, _document.PageSize.GetRight(100) + len1, _document.PageSize.GetBottom(30));

                        footerTemplate.BeginText();
                        footerTemplate.SetFontAndSize(bf1, 9);
                        footerTemplate.SetTextMatrix(0, 0);
                        footerTemplate.ShowText((writer.PageNumber - 1).ToString());
                        footerTemplate.EndText();

                        #endregion

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
                        string PDFFileName = string.Format("SalaryStructure_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=" + PDFFileName);
                        Response.Buffer = true;
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.BinaryWrite(bytes);
                        Response.End();



                        //*****************************************************************************************************


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

        protected void txtPercentage_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnFetchValue_Click1(object sender, EventArgs e)
        {

        }

        #endregion
    }
}