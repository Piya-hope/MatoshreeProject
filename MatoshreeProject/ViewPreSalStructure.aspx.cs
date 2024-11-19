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
#endregion


namespace MatoshreeProject
{
    public partial class ViewPreSalStructure : System.Web.UI.Page
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
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;




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

        #region " Public Functions "
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

        public DataTable ViewClassDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewClassDetails", con))
                {
                    ad.Fill(table);
                    GridViewPreSalaryStructure.DataSource = table;
                    GridViewPreSalaryStructure.DataBind();
                    ViewState["PreStructure"] = table;
                }
            }
            return table;
        }

        public DataTable ViewClassDetailsbyEmpID(int UserID1)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewClassDetailByEmpID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", UserID1);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridViewPreSalaryStructure.DataSource = table;
                GridViewPreSalaryStructure.DataBind();
                ViewState["PreStructure"] = table;
            }
            return table;
        }
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
                    command.Parameters.AddWithValue("@SubModule", "PreStructure");
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
                            bindClass();
                            ViewClassDetails();
                            GetCompanyAddress();

                            if (Create == "True")
                            {
                                addnew.Visible = true;
                                btnNewPreSalaryStructure.Visible = true;
                            }
                            else
                            {
                                addnew.Visible = false;
                                btnNewPreSalaryStructure.Visible = false;
                            }

                            if (Edit == "True")
                            {

                                GridViewPreSalaryStructure.Columns[4].Visible = true;
                            }
                            else
                            {

                                GridViewPreSalaryStructure.Columns[4].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                GridViewPreSalaryStructure.Columns[5].Visible = true;
                            }
                            else
                            {

                                GridViewPreSalaryStructure.Columns[5].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {

                            bindClass();
                            ViewClassDetailsbyEmpID(UserId);
                            GetCompanyAddress();


                            if (Create == "True")
                            {
                                addnew.Visible = true;
                                btnNewPreSalaryStructure.Visible = true;
                            }
                            else
                            {
                                addnew.Visible = false;
                                btnNewPreSalaryStructure.Visible = false;
                            }

                            if (Edit == "True")
                            {

                                GridViewPreSalaryStructure.Columns[4].Visible = true;
                            }
                            else
                            {

                                GridViewPreSalaryStructure.Columns[4].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                GridViewPreSalaryStructure.Columns[5].Visible = true;
                            }
                            else
                            {

                                GridViewPreSalaryStructure.Columns[5].Visible = false;
                            }

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
                            ViewClassDetails();
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

                                StaffOperationPermission();
                                //GetMessageFromModules();
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


                ViewComponentpdf(ClassId);

                ViewEmpCompansionpdf(ClassId);


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
        protected void GridViewComponent_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void btnEditSalClass_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string tableID;
                var rows = GridViewPreSalaryStructure.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                tableID = ((Label)rows[rowindex].FindControl("lblSalClassID1")).Text;
                Response.Redirect("~/PreSalaryStructure.aspx?ID=" + tableID + "", false);
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

        protected void btnDeleteSalClass_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);

                if (Session["LoginType"].ToString() == "Administrator")
                {
                    string ID;
                    var rows = GridViewPreSalaryStructure.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    ID = ((Label)rows[rowindex].FindControl("lblSalClassID1")).Text;

                    SqlConnection DeviceCon = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteClassPresalary", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
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
                        lblMesDelete.Text = "Class Details Deleted Successfully";
                        ViewClassDetails();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Class Details Not Deleted";
                    }
                }
                else if (RoleType == Designation)
                {
                    string ID;
                    var rows = GridViewPreSalaryStructure.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    ID = ((Label)rows[rowindex].FindControl("lblSalClassID1")).Text;

                    SqlConnection DeviceCon = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteClassPresalaryForEmpID", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@UserID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();

                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Class Details Deleted Successfully";
                        StaffOperationPermission();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Class Details Not Deleted";
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

        protected void btnSalClassStatus_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    using (SqlConnection DeviceCon = new SqlConnection(strconnect))
                    {
                        UserId = Convert.ToInt32(Session["UserID"]);
                        UserName = Session["UserName"].ToString();
                        var rows = GridViewPreSalaryStructure.Rows;
                        Button Btn = (Button)sender;
                        GridViewRow row = (GridViewRow)Btn.NamingContainer;
                        int rowindex = Convert.ToInt32(row.RowIndex);
                        Button id = ((Button)rows[rowindex].FindControl("btnSalClassStatus"));
                        string ID = ((Label)rows[rowindex].FindControl("lblSalClassID1")).Text;
                        if (id.Text.Equals("Active"))
                        {
                            SqlCommand cmd = new SqlCommand("SP_UpdateSalaryClassStatus", DeviceCon);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Parameters.AddWithValue("@Status", "False");//Session
                            cmd.Parameters.AddWithValue("@UserName", UserName);//Session
                            cmd.Parameters.AddWithValue("@EmpID", UserId);
                            cmd.Parameters.AddWithValue("@Designation", Designation);
                            DeviceCon.Open();
                            int Result = cmd.ExecuteNonQuery();
                            if (Result < 0)
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Class Inactive Successfully";
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Class Active Successfully";
                            }
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("SP_UpdateSalaryClassStatus", DeviceCon);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Parameters.AddWithValue("@Status", "True");//Session
                            cmd.Parameters.AddWithValue("@UserName", UserName);//Session
                            cmd.Parameters.AddWithValue("@EmpID", UserId);
                            cmd.Parameters.AddWithValue("@Designation", Designation);
                            DeviceCon.Open();
                            int Result = cmd.ExecuteNonQuery();
                            if (Result < 0)
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Class Inactive Successfully";
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Class Active Successfully";
                            }

                        }

                    }
                    ViewClassDetails();
                    //ViewCustomerDetails();
                    //CustomerCount();
                }
                else if (RoleType == Designation)
                {
                    using (SqlConnection DeviceCon = new SqlConnection(strconnect))
                    {
                        UserId = Convert.ToInt32(Session["UserID"]);
                        UserName = Session["UserName"].ToString();
                        var rows = GridViewPreSalaryStructure.Rows;
                        Button Btn = (Button)sender;
                        GridViewRow row = (GridViewRow)Btn.NamingContainer;
                        int rowindex = Convert.ToInt32(row.RowIndex);
                        Button id = ((Button)rows[rowindex].FindControl("btnSalClassStatus"));
                        string ID = ((Label)rows[rowindex].FindControl("lblSalClassID1")).Text;
                        if (id.Text.Equals("Active"))
                        {
                            SqlCommand cmd = new SqlCommand("SP_UpdateSalaryClassStatus", DeviceCon);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Parameters.AddWithValue("@Status", "False");//Session
                            cmd.Parameters.AddWithValue("@UserName", UserName);//Session
                            cmd.Parameters.AddWithValue("@EmpID", UserId);
                            cmd.Parameters.AddWithValue("@Designation", Designation);
                            DeviceCon.Open();
                            int Result = cmd.ExecuteNonQuery();
                            if (Result < 0)
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Class Inactive Successfully";
                                ViewClassDetails();


                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Class Active Successfully";
                            }
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("SP_UpdateSalaryClassStatus", DeviceCon);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Parameters.AddWithValue("@Status", "True");//Session
                            cmd.Parameters.AddWithValue("@UserName", UserName);//Session
                            cmd.Parameters.AddWithValue("@EmpID", UserId);
                            cmd.Parameters.AddWithValue("@Designation", Designation);
                            DeviceCon.Open();
                            int Result = cmd.ExecuteNonQuery();
                            if (Result < 0)
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Class Inactive Successfully";
                                ViewClassDetails();
                            }
                            else
                            {
                                Toasteralert.Visible = false;
                                deleteToaster.Visible = true;
                                lblMesDelete.Text = "Class Active Successfully";
                            }
                        }

                    }
                    StaffOperationPermission();
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

        protected void lnkbtnSalClassName1_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string tableID;
                var rows = GridViewPreSalaryStructure.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                tableID = ((Label)rows[rowindex].FindControl("lblSalClassID1")).Text;
                Response.Redirect("~/PreSalaryStructure.aspx?ID=" + tableID + "", false);



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

        protected void btnNewPreSalaryStructure_Click(object sender, EventArgs e)
        {
            Response.Redirect("PreSalaryStructure.aspx", true);
        }
        protected void GridViewPreSalaryStructure_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviewdrow in GridViewPreSalaryStructure.Rows)
                {
                    // string  Status = Convert.ToString(e.Row.Cells[8].Text);
                    LinkButton lnkbtnSalClassName1 = (LinkButton)gridviewdrow.FindControl("lnkbtnSalClassName1");
                    Label lblSalClassID1 = (Label)gridviewdrow.FindControl("lblSalClassID1");
                    Label lblSalClassName1 = (Label)gridviewdrow.FindControl("lblSalClassName1");
                    Label lblSalClassCreateby1 = (Label)gridviewdrow.FindControl("lblSalClassCreateby1");

                    Button btnSalClassStatus = (Button)gridviewdrow.FindControl("btnSalClassStatus");
                    string Status = ((Label)gridviewdrow.FindControl("lblSalClassStatus1")).Text;


                    if (Status == "True")
                    {
                        btnSalClassStatus.Text = "InActive";
                        btnSalClassStatus.CssClass = "btn btn-sm btn-outline-danger";

                        lnkbtnSalClassName1.ForeColor = Color.Blue;
                        lblSalClassID1.ForeColor = Color.Blue;
                        lblSalClassName1.ForeColor = Color.Blue;
                        lblSalClassCreateby1.ForeColor = Color.Blue;
                    }
                    else
                    {

                        btnSalClassStatus.Text = "Active";

                        btnSalClassStatus.CssClass = "btn btn-sm btn-outline-success";


                        lnkbtnSalClassName1.ForeColor = Color.Red;
                        lblSalClassID1.ForeColor = Color.Red;
                        lblSalClassName1.ForeColor = Color.Red;
                        lblSalClassCreateby1.ForeColor = Color.Red;
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

        protected void lnkbtnExcelViewPreSalStruct_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    DataTable dt = ViewClassDetails();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        //Response.AddHeader("Content-Disposition", "attachment;filename=Customer_Details.xls");
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "PreSalary_Details " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));

                        Response.Charset = " ";

                        // Create a new DataTable with only the desired columns
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("ClassName");
                        dtExport.Columns.Add("Createby");
                        dtExport.Columns.Add("Status");

                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["ID"];
                            newRow["ClassName"] = row["ClassName"];
                            //newRow["Description"] = row["Description"];
                            newRow["Createby"] = row["Createby"];
                            //newRow["Createdate"] = row["Createdate"];
                            newRow["Status"] = row["Status"];

                            dtExport.Rows.Add(newRow);
                        }

                        StringWriter sw = new StringWriter();
                        HtmlTextWriter htw = new HtmlTextWriter(sw);

                        // Create a GridView to help render the data
                        GridView gridView = new GridView();
                        gridView.DataSource = dtExport;
                        gridView.DataBind();

                        gridView.RenderControl(htw);
                        Response.Write(sw.ToString());
                        Response.End();
                    }
                }
                else if (RoleType == Designation)
                {
                    DataTable dt = (DataTable)ViewState["PreStructure"];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        //Response.AddHeader("Content-Disposition", "attachment;filename=Customer_Details.xls");
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "PreSalary_Details " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));

                        Response.Charset = " ";

                        // Create a new DataTable with only the desired columns
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("ClassName");
                        //dtExport.Columns.Add("Description");
                        dtExport.Columns.Add("Createby");
                        //dtExport.Columns.Add("Createdate");
                        dtExport.Columns.Add("Status");

                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["ID"];
                            newRow["ClassName"] = row["ClassName"];
                            //newRow["Description"] = row["Description"];
                            newRow["Createby"] = row["Createby"];
                            //newRow["Createdate"] = row["Createdate"];
                            newRow["Status"] = row["Status"];
                            dtExport.Rows.Add(newRow);
                        }

                        StringWriter sw = new StringWriter();
                        HtmlTextWriter htw = new HtmlTextWriter(sw);

                        // Create a GridView to help render the data
                        GridView gridView = new GridView();
                        gridView.DataSource = dtExport;
                        gridView.DataBind();

                        gridView.RenderControl(htw);
                        Response.Write(sw.ToString());
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

        protected void linkbtnPDFViewPreSalStruct_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    //GetCompanyAddress();
                    int _totalColumns = 4;//
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(4);//change
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

                    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                    {
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(_document, memoryStream);
                        //Phrase phrase = null;
                        //PdfPCell cell = null;
                        //PdfPTable table = null;
                        //Color color = new Color();

                        _document.Open();
                        _pdfPTable.SetWidths(new float[] { 4f, 11f, 8f, 11f });//column width in doc       
                                                                               //----Header PDF--------------------------//
                                                                               //Company Logo
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 1;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPTable.AddCell(cell);

                        //...!..image logo..// 

                        phrase = new Phrase();
                        phrase.Add(new Chunk(lbladdCompany11.Text + "\n", FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lbladdress11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCity1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddDistrict1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddState1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
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

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("PreStructureList", _fontStyle));
                        _pdfPCell.Colspan = 3;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);

                        //-------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 1;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();


                        //_fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        //_pdfPCell = new PdfPCell(new Phrase("-------------------------------------*-------------------------------------", _fontStyle));
                        //_pdfPCell.Colspan = _totalColumns;
                        //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        //_pdfPCell.Border = 0;
                        //_pdfPCell.BackgroundColor = BaseColor.WHITE;
                        //_pdfPCell.ExtraParagraphSpace = 4;
                        //_pdfPTable.AddCell(_pdfPCell);
                        //_pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = ViewClassDetails();
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ClassName", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Createby", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["ClassName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Createby"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("PreStructureList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
                    int _totalColumns = 4;//
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(4);//change
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

                    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                    {
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(_document, memoryStream);
                        //Phrase phrase = null;
                        //PdfPCell cell = null;
                        //PdfPTable table = null;
                        //Color color = new Color();

                        _document.Open();
                        _pdfPTable.SetWidths(new float[] { 4f, 11f, 8f, 11f });//column width in doc       
                                                                               //----Header PDF--------------------------//
                                                                               //Company Logo
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 1;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPTable.AddCell(cell);

                        //...!..image logo..// 

                        phrase = new Phrase();
                        phrase.Add(new Chunk(lbladdCompany11.Text + "\n", FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lbladdress11.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCity1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddDistrict1.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddState1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text + "\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)));
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

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("PreStructureList", _fontStyle));
                        _pdfPCell.Colspan = 3;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                      
                        _pdfPTable.AddCell(_pdfPCell);

                        //-------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 1;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();


                        // Adding a "line break" by inserting an empty cell
                        PdfPCell emptyCell = new PdfPCell(new Phrase(" ", _fontStyle));
                        emptyCell.Colspan = _totalColumns;
                        emptyCell.Border = 0; // No border to make it look like a line break
                        emptyCell.FixedHeight = 10f; // Adjust height as needed to simulate a line break
                        _pdfPTable.AddCell(emptyCell);
                        _pdfPTable.CompleteRow();

                        //_fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        //_pdfPCell = new PdfPCell(new Phrase("-------------------------------------*-------------------------------------", _fontStyle));
                        //_pdfPCell.Colspan = _totalColumns;
                        //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        //_pdfPCell.Border = 0;
                        //_pdfPCell.BackgroundColor = BaseColor.WHITE;
                        //_pdfPCell.ExtraParagraphSpace = 4;
                        //_pdfPTable.AddCell(_pdfPCell);
                        //_pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = (DataTable)ViewState["PreStructure"];
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ClassName", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Createby", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["ClassName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Createby"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("PreStructureList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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

        protected void BTN_VisibilityViewPreSalStruct_Click(object sender, EventArgs e)
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
                        SqlCommand cmd = new SqlCommand("SP_ClassPrestructVisiblityDetails", con);
                        cmd.CommandTimeout = 600;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(table);
                        GridViewPreSalaryStructure.DataSource = table;
                        GridViewPreSalaryStructure.DataBind();
                        ViewState["PreStructure"] = table;
                    }
                }
                else if (RoleType == Designation)
                {
                    StaffOperationPermission();
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

        protected void Btn_ReloadViewPreSalStruct_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    ViewClassDetails();
                }
                else if (RoleType == Designation)
                {
                    StaffOperationPermission();
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

        #endregion

    }
}