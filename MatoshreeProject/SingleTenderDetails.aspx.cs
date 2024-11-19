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
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using Image = iTextSharp.text.Image;
using iTextSharp.text.pdf.draw;
using ListItem = System.Web.UI.WebControls.ListItem;
using Font = iTextSharp.text.Font;
using iTextSharp.tool.xml.html.pdfelement;
using System.EnterpriseServices.Internal;
//using itextsharp.Kernel.Events;
//using iText.Kernel.Pdf;
//using static iTextSharp.text.TabStop;
//using iText.Forms.Form.Element;

#endregion

namespace MatoshreeProject
{
    public partial class SingleTenderDetails : System.Web.UI.Page
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

        #region " Protected Functions "
        #endregion

        #region " Public Functions "

        public DataTable ViewTenderVenderDetails()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewTenderVenderList", con))
                {
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    ad.SelectCommand.Parameters.AddWithValue("@TenderNumber", lblTenderno.Text);
                    ad.Fill(dt);
                    GridSingleVenderTenderDetail.DataSource = dt;
                    GridSingleVenderTenderDetail.DataBind();
                }
            }
            return dt;
        }

        public void GetbyTenderNo()
        {
            try
            {
                string Tenderno = HttpUtility.UrlDecode(Request.QueryString["TenderNo"]);
                lblTenderno.Text = Tenderno;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("[SP_GetbyTenderNo]", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@Tenderno", lblTenderno.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblid1.Text = dt.Rows[0]["ID"].ToString();
                        lblTenderno.Text = dt.Rows[0]["TenderNo"].ToString();
                        lblTendername.Text = dt.Rows[0]["TenderName"].ToString();
                        lblStatus.Text = dt.Rows[0]["Status"].ToString();

                        lblclientnote.Text = dt.Rows[0]["Client_Note"].ToString();
                        lbltermsandcodition.Text = dt.Rows[0]["Term_condition"].ToString();
                        lblURLname1.Text = dt.Rows[0]["ProjectName"].ToString();

                        lblProjectID.Text = dt.Rows[0]["ProjectID"].ToString();

                        lblstatus1.Text = dt.Rows[0]["Status"].ToString();
                        lbltendno1.Text = dt.Rows[0]["TenderNo"].ToString();

                        lblecv1.Text = dt.Rows[0]["estimatecontractvalue"].ToString();
                        lbltendcat1.Text = dt.Rows[0]["TenderBased"].ToString();
                        lblbidenddate1.Text = DateTime.Parse(dt.Rows[0]["BidEndDate"].ToString()).ToString("yyyy-MM-dd");

                        // lbltitle1.Text = dt.Rows[0]["TenderName"].ToString();
                        lblworkdesc1.Text = dt.Rows[0]["Description"].ToString();
                        lbltendtype1.Text = dt.Rows[0]["Status"].ToString();
                        lbllocCity1.Text = dt.Rows[0]["AddCity"].ToString();
                        // lbllocpin1.Text = dt.Rows[0]["Pincode"].ToString();
                        lblprebidmeetingadd1.Text = dt.Rows[0]["BidMeetingAddress"].ToString();
                        lblprebidmeetdate1.Text = DateTime.Parse(dt.Rows[0]["PreBidmeetingdate"].ToString()).ToString("yyyy-MM-dd");


                        lblpublishdate11.Text = DateTime.Parse(dt.Rows[0]["publishdate"].ToString()).ToString("yyyy-MM-dd");
                        lblbidopen1.Text = DateTime.Parse(dt.Rows[0]["TenderDate"].ToString()).ToString("yyyy-MM-dd");
                        lblbidstartdate1.Text = DateTime.Parse(dt.Rows[0]["TenderDate"].ToString()).ToString("yyyy-MM-dd");
                        lblbidsubmissionend1.Text = DateTime.Parse(dt.Rows[0]["BidEndDate"].ToString()).ToString("yyyy-MM-dd");

                        //Authority
                        lblauthorityname1.Text = dt.Rows[0]["AuthorityName"].ToString();
                        lblauthorityadd1.Text = dt.Rows[0]["Authorityaddress"].ToString();
                        lblconno1.Text = dt.Rows[0]["Auth_Contact"].ToString();
                        lblauthposition1.Text = dt.Rows[0]["Auth_Position"].ToString();
                        lblauthemail1.Text = dt.Rows[0]["Auth_Email"].ToString();
                    }

                    ViewItemDetails();
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

        public DataTable ViewItemDetails()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewTenderItemsDetailByTenderNo", con))
                {
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure; // Set command type to stored procedure                 
                    ad.SelectCommand.Parameters.AddWithValue("@TenderNumber", lblTenderno.Text);
                    ad.Fill(dt);
                    GridCalculate.DataSource = dt;
                    GridCalculate.DataBind();
                }
            }
            return dt;
        }

        public DataTable ViewTenderQuestionDetails()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewTenderQuestionDetail", con))
                {
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure; // Set command type to stored procedure
                    ad.SelectCommand.Parameters.AddWithValue("@TenderNumber", lblTenderno.Text);
                    ad.Fill(dt);
                    GridTenderQue.DataSource = dt;
                    GridTenderQue.DataBind();
                }
            }
            return dt;
        }

        public DataTable ViewTenderFile()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewTenderFileByTenderNo", con))
                {
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    ad.SelectCommand.Parameters.AddWithValue("@TenderNumber", lblTenderno.Text);
                    ad.SelectCommand.Parameters.AddWithValue("@ProjectID", lblProjectID.Text);
                    ad.SelectCommand.Parameters.AddWithValue("@Belong", "Tender");
                    ad.Fill(dt);
                    GridTenderFile.DataSource = dt;
                    GridTenderFile.DataBind();
                }
            }
            return dt;
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
                    command.Parameters.AddWithValue("@SubModule", "SingleTenderDetails");
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
                            GetbyTenderNo();
                            GetCompanyAddress();
                            string Tenderno = HttpUtility.UrlDecode(Request.QueryString["TenderNo"]);
                            lblTenderno.Text = Tenderno;
                            ViewTenderVenderDetails();
                            ViewItemDetails();
                            ViewTenderQuestionDetails();
                            ViewTenderFile();

                            if (Create == "True")
                            {
                                //link.Visible = true;
                                //linkbtnPaid.Visible = true;
                                //addnewTask.Visible = true;
                            }
                            else
                            {
                                //btn_CreateInvoice.Visible = false;
                                //linkbtnPaid.Visible = false;
                                //addnewTask.Visible = false;
                            }

                            if (Edit == "True")
                            {
                                //Linkbtnedit.Visible = true;
                                //lnkbtncopyestimate.Visible = true;
                                //GridTask1.Columns[10].Visible = true;
                            }
                            else
                            {
                                //Linkbtnedit.Visible = false;
                                //lnkbtncopyestimate.Visible = false;
                                //GridTask1.Columns[10].Visible = false;
                            }

                            if (Delete == "True")
                            {
                                //GridTask1.Columns[11].Visible = true;
                                //lnkbtndelInvoice.Visible = true;
                            }
                            else
                            {
                                //GridTask1.Columns[11].Visible = false;
                                //lnkbtndelInvoice.Visible = false;
                            }
                        }
                        else if (View == "True")
                        {
                            GetbyTenderNo();
                            GetCompanyAddress();
                            string Tenderno = HttpUtility.UrlDecode(Request.QueryString["TenderNo"]);
                            lblTenderno.Text = Tenderno;
                            ViewTenderVenderDetails();
                            ViewItemDetails();
                            ViewTenderQuestionDetails();
                            ViewTenderFile();

                            if (Create == "True")
                            {
                                //btn_CreateInvoice.Visible = true;
                                //linkbtnPaid.Visible = true;
                                //addnewTask.Visible = true;
                            }
                            else
                            {
                                //btn_CreateInvoice.Visible = false;
                                //linkbtnPaid.Visible = false;
                                //addnewTask.Visible = false;
                            }

                            if (Edit == "True")
                            {
                                //Linkbtnedit.Visible = true;
                                //lnkbtncopyestimate.Visible = true;
                                //GridTask1.Columns[10].Visible = true;
                            }
                            else
                            {
                                //Linkbtnedit.Visible = false;
                                //lnkbtncopyestimate.Visible = false;
                                //GridTask1.Columns[10].Visible = false;
                            }

                            if (Delete == "True")
                            {
                                //GridTask1.Columns[11].Visible = true;
                                //lnkbtndelInvoice.Visible = true;
                            }
                            else
                            {
                                //GridTask1.Columns[11].Visible = false;
                                //lnkbtndelInvoice.Visible = false;
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
                            GetbyTenderNo();
                            GetCompanyAddress();
                            string Tenderno = HttpUtility.UrlDecode(Request.QueryString["TenderNo"]);
                            lblTenderno.Text = Tenderno;
                            ViewTenderVenderDetails();
                            ViewItemDetails();
                            ViewTenderQuestionDetails();
                            ViewTenderFile();
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

        protected void Btn_Reload_Click(object sender, EventArgs e)
        {
            ViewTenderVenderDetails();
        }

        protected void lnkclear_Click(object sender, EventArgs e)
        {
            try
            {
                //  uploadFile1.Dispose();
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

        protected void Linkbtnedit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EditTender.aspx");
        }

        protected void lnkbtnpdf_Click1(object sender, EventArgs e)
        {
            try
            {
                string path = Image1.ImageUrl;
                DataTable table2 = new DataTable();
                DataTable table12 = ViewItemDetails();
                DataTable tableA = new DataTable();
                DataTable Gridtenderfile = ViewTenderFile();
                DataTable tableB = new DataTable();
                DataTable GridTenderQue = ViewTenderQuestionDetails();

                iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
                MemoryStream memoryStream = new MemoryStream();
                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, memoryStream);
                doc.Open();
                PdfPTable tableimage = new PdfPTable(2);
                tableimage.WidthPercentage = 100;
                PdfPCell imagecell = new PdfPCell();
                imagecell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));

                image.ScaleToFit(100f, 100f);
                imagecell.AddElement(image);
                tableimage.AddCell(imagecell);

                PdfPCell companyaddresscell = new PdfPCell();
                companyaddresscell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Chunk tenderaddno16 = new Chunk(lbladdCompany11.Text, new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK));
                Phrase tenderaddPh6 = new Phrase
                {
                tenderaddno16
                 };
                Paragraph tendaddparagraph6 = new Paragraph(tenderaddPh6);
                tendaddparagraph6.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(tendaddparagraph6);


                Chunk tenderaddno3 = new Chunk(lbladdress11.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderaddno6 = new Chunk(lblcompanyaddCity1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddPh1 = new Phrase
                {
                 tenderaddno3,
                 tenderaddno6
                };
                Paragraph tendaddparagraph1 = new Paragraph(tenderaddPh1);
                tendaddparagraph1.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(tendaddparagraph1);

                Chunk tenderaddnoD1 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderaddnoD = new Chunk(lblcompanyaddDistrict1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddPhD = new Phrase
                {
                    tenderaddnoD1,
                   tenderaddnoD
                };
                Paragraph tendaddparagraphD = new Paragraph(tenderaddPhD);
                tendaddparagraphD.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(tendaddparagraphD);

                Chunk tenderaddnoS = new Chunk(lblcompanyaddState1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderaddnoS1 = new Chunk(lblcompanyaddCountry1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddPhS = new Phrase
                {
                   tenderaddnoS,
                   tenderaddnoS1
                };
                Paragraph tendaddparagraphS = new Paragraph(tenderaddPhS);
                tendaddparagraphS.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(tendaddparagraphS);

                Chunk tenderaddno28 = new Chunk("PIN:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderaddno29 = new Chunk(lblcompanyaddZIPCode11.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddPh10 = new Phrase
                {
                 tenderaddno28,
                 tenderaddno29
                };
                Paragraph tendaddparagraph10 = new Paragraph(tenderaddPh10);
                tendaddparagraph10.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(tendaddparagraph10);

                Chunk tenderpinaddno2 = new Chunk("Phone:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderaddnoP = new Chunk(lblphoneNo1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddPh2 = new Phrase
                {
                 tenderpinaddno2,
                 tenderaddnoP
                };
                Paragraph tendaddparagraph2 = new Paragraph(tenderaddPh2);
                tendaddparagraph2.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(tendaddparagraph2);
                tableimage.AddCell(companyaddresscell);
                doc.Add(tableimage);

                doc.Add(new Paragraph(" "));

                PdfPTable tabletender = new PdfPTable(1);
                tabletender.WidthPercentage = 100;
                PdfPCell tendercell = new PdfPCell();
                tendercell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Chunk chtender = new Chunk("TENDER", new Font(Font.FontFamily.HELVETICA, 16f, Font.BOLD, BaseColor.BLACK));
                Phrase phtender = new Phrase
                {
                chtender
                };
                Paragraph chtenderparagraph1 = new Paragraph(phtender);
                chtenderparagraph1.Alignment = Element.ALIGN_CENTER;
                tendercell.AddElement(chtenderparagraph1);
                tabletender.AddCell(tendercell);
                doc.Add(tabletender);
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));

                PdfPTable tabletenderdetails = new PdfPTable(1);
                tabletenderdetails.WidthPercentage = 100;
                PdfPCell tendercelldetails = new PdfPCell();
                tendercelldetails.AddElement(new Paragraph("Current Tender Details :-", new Font(Font.FontFamily.HELVETICA, 14f, Font.NORMAL, BaseColor.BLUE)));
                tendercelldetails.BackgroundColor = BaseColor.LIGHT_GRAY;
                tendercelldetails.PaddingLeft = 5;
                tendercelldetails.PaddingBottom = 15;
                tabletenderdetails.AddCell(tendercelldetails);
                doc.Add(tabletenderdetails);
                doc.Add(new Paragraph(" "));

                PdfPTable tabledetails = new PdfPTable(2);
                tabledetails.WidthPercentage = 100;
                //tabledetails.Border = iTextSharp.text.Rectangle.NO_BORDER;


                PdfPCell leftdetailscell = new PdfPCell();
                leftdetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Chunk tenderno = new Chunk("Tender Number:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderno1 = new Chunk(lblTenderno.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderno2 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderPh = new Phrase
                {
                tenderno,
                tenderno1,
                tenderno2
                };
                Paragraph tendparagraph = new Paragraph(tenderPh);
                tendparagraph.Alignment = Element.ALIGN_LEFT;
                leftdetailscell.AddElement(tendparagraph);

                Chunk tenderno9 = new Chunk("Tender Name:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderno10 = new Chunk(lblTendername.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderno11 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderPh2 = new Phrase
                {
                tenderno9,
                tenderno10,
                tenderno11
                };
                Paragraph tendparagraph2 = new Paragraph(tenderPh2);
                tendparagraph2.Alignment = Element.ALIGN_LEFT;
                leftdetailscell.AddElement(tendparagraph2);

                Chunk tenderno13 = new Chunk("Tender Type:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderno14 = new Chunk(lblStatus.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderno15 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderPh4 = new Phrase
                {
                tenderno13,
                tenderno14,
                tenderno15
                };
                Paragraph tendparagraph4 = new Paragraph(tenderPh4);
                tendparagraph4.Alignment = Element.ALIGN_LEFT;
                leftdetailscell.AddElement(tendparagraph4);

                tabledetails.AddCell(leftdetailscell);


                PdfPCell rightdetailscell = new PdfPCell();
                rightdetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Chunk tenderno16 = new Chunk("Tender Category:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderno17 = new Chunk(lbltendcat1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderno18 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderPh6 = new Phrase
                {
                tenderno16,
                tenderno17,
                tenderno18
                };
                Paragraph tendparagraph6 = new Paragraph(tenderPh6);
                tendparagraph6.Alignment = Element.ALIGN_LEFT;
                rightdetailscell.AddElement(tendparagraph6);

                Chunk tenderno3 = new Chunk("Tender Value:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderno4 = new Chunk(lblecv1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderno5 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderPh1 = new Phrase
                {
                tenderno3,
                tenderno4,
                tenderno5
                };
                Paragraph tendparagraph1 = new Paragraph(tenderPh1);
                tendparagraph1.Alignment = Element.ALIGN_LEFT;
                rightdetailscell.AddElement(tendparagraph1);

                Chunk tenderno6 = new Chunk("Bid End Date:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderno7 = new Chunk(lblbidenddate1.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase tenderPh3 = new Phrase
                {
                tenderno6,
                tenderno7

                };
                Paragraph tendparagraph3 = new Paragraph(tenderPh3);
                tendparagraph3.Alignment = Element.ALIGN_LEFT;
                rightdetailscell.AddElement(tendparagraph3);

                tabledetails.AddCell(rightdetailscell);

                doc.Add(tabledetails);
                doc.Add(new Paragraph(" "));

                PdfPTable tabletenderworkdetails = new PdfPTable(1);
                tabletenderworkdetails.WidthPercentage = 100;
                PdfPCell tendercellworkdetails = new PdfPCell();
                tendercellworkdetails.AddElement(new Paragraph("Work Details -:", new Font(Font.FontFamily.HELVETICA, 14f, Font.NORMAL, BaseColor.BLUE)));
                tendercellworkdetails.BackgroundColor = BaseColor.LIGHT_GRAY;
                tendercellworkdetails.PaddingLeft = 5;
                tendercellworkdetails.PaddingBottom = 15;
                tabletenderworkdetails.AddCell(tendercellworkdetails);
                doc.Add(tabletenderworkdetails);

                doc.Add(new Paragraph(" "));

                PdfPTable tabletenderwork3 = new PdfPTable(1);
                tabletenderwork3.WidthPercentage = 100;
                PdfPCell leftworkitemdetailscell = new PdfPCell();
                leftworkitemdetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Chunk tenderworkno13 = new Chunk("Work Address:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderworkno14 = new Chunk(lbllocCity1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderworkno15 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderworkPh4 = new Phrase
  {
  tenderworkno13,
 tenderworkno14,
  tenderworkno15
  };
                Paragraph tendworkparagraph4 = new Paragraph(tenderworkPh4);
                tendworkparagraph4.Alignment = Element.ALIGN_LEFT;
                leftworkitemdetailscell.AddElement(tendworkparagraph4);

                Chunk tenderworkno22 = new Chunk("Pre Bid Meeting Date:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderworkno23 = new Chunk(lblprebidmeetdate1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderworkno24 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderworkPh8 = new Phrase
  {
  tenderworkno22,
  tenderworkno23,
  tenderworkno24
  };
                Paragraph tendworkparagraph8 = new Paragraph(tenderworkPh8);
                tendworkparagraph8.Alignment = Element.ALIGN_LEFT;
                leftworkitemdetailscell.AddElement(tendworkparagraph8);

                Chunk tenderworkno19 = new Chunk("Pre Bid Meeting Address:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderworkno20 = new Chunk(lblprebidmeetingadd1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderworkno21 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderworkPh7 = new Phrase
  {
  tenderworkno19,
  tenderworkno20,
  tenderworkno21
  };
                Paragraph tendworkparagraph7 = new Paragraph(tenderworkPh7);
                tendworkparagraph7.Alignment = Element.ALIGN_LEFT;
                leftworkitemdetailscell.AddElement(tendworkparagraph7);

                Chunk chtenderwork3 = new Chunk("Work Description:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk chtenderwork4 = new Chunk(lblworkdesc1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase phtenderwork2 = new Phrase
                {
                chtenderwork3 ,
                chtenderwork4
                };
                Paragraph chtenderparagraphwork2 = new Paragraph(phtenderwork2);
                chtenderparagraphwork2.Alignment = Element.ALIGN_LEFT;
                leftworkitemdetailscell.AddElement(chtenderparagraphwork2);

                tabletenderwork3.AddCell(leftworkitemdetailscell);

                doc.Add(tabletenderwork3);
                doc.Add(new Paragraph(" "));

                PdfPTable tabletenderdatedetails = new PdfPTable(1);
                tabletenderdatedetails.WidthPercentage = 100;
                PdfPCell tendercelldatedetails = new PdfPCell();
                // tendercelldatedetails.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tendercelldatedetails.AddElement(new Paragraph("Critical Date :-", new Font(Font.FontFamily.HELVETICA, 14f, Font.NORMAL, BaseColor.BLUE)));
                tendercelldatedetails.BackgroundColor = BaseColor.LIGHT_GRAY;
                tendercelldatedetails.PaddingLeft = 5;
                tendercelldatedetails.PaddingBottom = 15;

                tabletenderdatedetails.AddCell(tendercelldatedetails);
                doc.Add(tabletenderdatedetails);
                doc.Add(new Paragraph(" "));

                PdfPTable tabledatedetails = new PdfPTable(2);
                tabledatedetails.WidthPercentage = 100;
                PdfPCell leftdatedetailscell = new PdfPCell();
                leftdatedetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Chunk tenderdateno = new Chunk("Publish Date:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderdateno1 = new Chunk(lblpublishdate11.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderdateno2 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderdatePh = new Phrase
   {
   tenderdateno ,
   tenderdateno1 ,
   tenderdateno2
   };
                Paragraph tenddateparagraph = new Paragraph(tenderdatePh);
                tenddateparagraph.Alignment = Element.ALIGN_LEFT;
                leftdatedetailscell.AddElement(tenddateparagraph);



                Chunk tenderdateno13 = new Chunk("Bid Submission Start Date:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderdateno14 = new Chunk(lblbidstartdate1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderdateno15 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderdatePh4 = new Phrase
   {
  tenderdateno13 ,
   tenderdateno14,
   tenderdateno15
   };
                Paragraph tenddateparagraph4 = new Paragraph(tenderdatePh4);
                tenddateparagraph4.Alignment = Element.ALIGN_LEFT;
                leftdatedetailscell.AddElement(tenddateparagraph4);

                tabledatedetails.AddCell(leftdatedetailscell);
                PdfPCell rightdatedetailscell = new PdfPCell();
                rightdatedetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Chunk tenderdateno16 = new Chunk("Bid Opening Date:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderdateno17 = new Chunk(lblbidopen1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderdateno18 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderdatePh6 = new Phrase
   {
   tenderdateno16,
   tenderdateno17,
   tenderdateno18
   };
                Paragraph tenddateparagraph6 = new Paragraph(tenderdatePh6);
                tenddateparagraph6.Alignment = Element.ALIGN_LEFT;
                rightdatedetailscell.AddElement(tenddateparagraph6);





                Chunk tenderdateno6 = new Chunk("Bid Submission End Date:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderdateno7 = new Chunk(lblbidsubmissionend1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderdateno8 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderdatePh3 = new Phrase
   {
    tenderdateno6,
    tenderdateno7,
    tenderdateno8
   };
                Paragraph tenddateparagraph3 = new Paragraph(tenderdatePh3);
                tenddateparagraph3.Alignment = Element.ALIGN_LEFT;
                rightdatedetailscell.AddElement(tenddateparagraph3);

                tabledatedetails.AddCell(rightdatedetailscell);
                doc.Add(tabledatedetails);
                doc.Add(new Paragraph(" "));

                PdfPTable tabletenderAutoritydetails = new PdfPTable(1);
                tabletenderAutoritydetails.WidthPercentage = 100;
                PdfPCell tendercellAutoritydetails = new PdfPCell();
                //  tendercellAutoritydetails.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tendercellAutoritydetails.AddElement(new Paragraph("Tender Inviting Authority :-", new Font(Font.FontFamily.HELVETICA, 14f, Font.NORMAL, BaseColor.BLUE)));
                tendercellAutoritydetails.BackgroundColor = BaseColor.LIGHT_GRAY;
                tendercellAutoritydetails.PaddingLeft = 5;
                tendercellAutoritydetails.PaddingBottom = 15;
                tabletenderAutoritydetails.AddCell(tendercellAutoritydetails);
                doc.Add(tabletenderAutoritydetails);
                doc.Add(new Paragraph(" "));

                PdfPTable tableAuthoritydetails = new PdfPTable(2);
                tableAuthoritydetails.WidthPercentage = 100;
                PdfPCell leftAuthoritydetailscell = new PdfPCell();
                leftAuthoritydetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Chunk tenderAuthorityno = new Chunk("Authority Name:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderAuthorityno1 = new Chunk(lblauthorityname1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderAuthorityno2 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderAuthorityPh = new Phrase
                {
                tenderAuthorityno ,
   tenderAuthorityno1 ,
   tenderAuthorityno2
   };
                Paragraph tendAuthorityparagraph = new Paragraph(tenderAuthorityPh);
                tendAuthorityparagraph.Alignment = Element.ALIGN_LEFT;
                leftAuthoritydetailscell.AddElement(tendAuthorityparagraph);

                Chunk tenderAuthorityposition = new Chunk("Authority Email:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderAuthorityposition1 = new Chunk(lblauthemail1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderAuthorityposition2 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderAuthoritypositionPh = new Phrase
                {
                tenderAuthorityposition ,
   tenderAuthorityposition1 ,
   tenderAuthorityposition2
   };
                Paragraph tendAuthoritypositionparagraph = new Paragraph(tenderAuthoritypositionPh);
                tendAuthoritypositionparagraph.Alignment = Element.ALIGN_LEFT;
                leftAuthoritydetailscell.AddElement(tendAuthoritypositionparagraph);


                Chunk tenderAuthorityposition3 = new Chunk("Authority Address:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderAuthorityposition4 = new Chunk(lblauthorityadd1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderAuthorityposition5 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderAuthoritypositionPh1 = new Phrase
                {
                tenderAuthorityposition3 ,
   tenderAuthorityposition4 ,
   tenderAuthorityposition5
   };
                Paragraph tendAuthoritypositionparagraph1 = new Paragraph(tenderAuthoritypositionPh1);
                tendAuthoritypositionparagraph1.Alignment = Element.ALIGN_LEFT;
                leftAuthoritydetailscell.AddElement(tendAuthoritypositionparagraph1);

                tableAuthoritydetails.AddCell(leftAuthoritydetailscell);


                PdfPCell rightAuthoritydetailscell = new PdfPCell();
                rightAuthoritydetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Chunk tenderAuthorityno16 = new Chunk("Authority Position:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderAuthority17 = new Chunk(lblauthposition1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderAuthority18 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderAuthorityPh6 = new Phrase
   {
   tenderAuthorityno16,
   tenderAuthority17,
   tenderAuthority18
   };
                Paragraph tendAuthorityparagraph6 = new Paragraph(tenderAuthorityPh6);
                tendAuthorityparagraph6.Alignment = Element.ALIGN_LEFT;
                rightAuthoritydetailscell.AddElement(tendAuthorityparagraph6);

                Chunk tenderAuthoritypositionno16 = new Chunk("Contact Number:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderAuthorityposition17 = new Chunk(lblauthorityadd1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderAuthorityposition18 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase tenderAuthoritypositionPh6 = new Phrase
   {
   tenderAuthoritypositionno16,
   tenderAuthorityposition17,
   tenderAuthorityposition18
   };
                Paragraph tendAuthoritypositionparagraph6 = new Paragraph(tenderAuthoritypositionPh6);
                tendAuthoritypositionparagraph6.Alignment = Element.ALIGN_LEFT;
                rightAuthoritydetailscell.AddElement(tendAuthoritypositionparagraph6);

                tableAuthoritydetails.AddCell(rightAuthoritydetailscell);
                doc.Add(tableAuthoritydetails);
                doc.Add(new Paragraph(" "));

                PdfPTable tableQuedetails = new PdfPTable(1);
                tableQuedetails.WidthPercentage = 100;
                PdfPCell Quedetailscell = new PdfPCell();
                Quedetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Quedetailscell.AddElement(new Paragraph("Tender Question :-", new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK)));
                tableQuedetails.AddCell(Quedetailscell);
                doc.Add(tableQuedetails);
                doc.Add(new Paragraph(" "));

                if (GridTenderQue != null && GridTenderQue.Rows.Count > 0)
                {
                    DataTable dtExport2 = new DataTable();
                    dtExport2.Columns.Add("ID");
                    dtExport2.Columns.Add("Question");


                    foreach (DataRow row2 in GridTenderQue.Rows)
                    {
                        DataRow newRow = dtExport2.NewRow();
                        newRow["ID"] = row2["ID"];

                        newRow["Question"] = row2["Question"];


                        dtExport2.Rows.Add(newRow);
                        tableA = dtExport2;
                    }

                    float[] columnWidths2 = new float[tableA.Columns.Count];
                    for (int i = 0; i < tableA.Columns.Count; i++)
                    {
                        if (tableA.Columns[i].ColumnName == "ID")
                        {
                            columnWidths2[i] = 2f;
                        }
                        else
                        {
                            columnWidths2[i] = 22f;
                        }
                    }
                    Font tableHeaderFont1 = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.BLUE);
                    Font tableDataFont1 = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL);
                    PdfPTable pdfTable1 = new PdfPTable(tableA.Columns.Count);
                    pdfTable1.SetWidths(columnWidths2);
                    pdfTable1.WidthPercentage = 100;
                    foreach (DataColumn column in tableA.Columns)
                    {
                        string columnName1 = (column.ColumnName == "ID") ? "#" : column.ColumnName;
                        PdfPCell pdfCell = new PdfPCell(new Phrase(columnName1, tableHeaderFont1));
                        pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        pdfCell.Padding = 10;
                        pdfTable1.AddCell(pdfCell);
                    }
                    foreach (DataRow row in tableA.Rows)
                    {
                        foreach (var que in row.ItemArray)
                        {
                            PdfPCell dataCell1 = new PdfPCell(new Phrase(que.ToString(), tableDataFont1));
                            dataCell1.Padding = 10;
                            pdfTable1.AddCell(dataCell1);
                        }
                    }
                    doc.Add(pdfTable1);
                }
                doc.Add(new Paragraph(" "));

                PdfPTable tableitemdetails = new PdfPTable(1);
                tableitemdetails.WidthPercentage = 100;
                PdfPCell itemdetailscell = new PdfPCell();
                itemdetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                itemdetailscell.AddElement(new Paragraph("Tender Items :-", new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK)));
                tableitemdetails.AddCell(itemdetailscell);
                doc.Add(tableitemdetails);
                doc.Add(new Paragraph(" "));

                if (table12 != null && table12.Rows.Count > 0)
                {
                    DataTable dtExport = new DataTable();
                    dtExport.Columns.Add("ID");
                    dtExport.Columns.Add("Item");
                    dtExport.Columns.Add("Description");
                    dtExport.Columns.Add("Quantity");

                    foreach (DataRow row in table12.Rows)
                    {
                        DataRow newRow = dtExport.NewRow();
                        newRow["ID"] = row["ID"];
                        newRow["Item"] = row["Item"];
                        newRow["Description"] = row["Description"];
                        newRow["Quantity"] = row["Qnty"];


                        dtExport.Rows.Add(newRow);
                        table2 = dtExport;
                    }

                    float[] columnWidths = new float[table2.Columns.Count];
                    for (int i = 0; i < table2.Columns.Count; i++)
                    {
                        if (table2.Columns[i].ColumnName == "ID")
                        {
                            columnWidths[i] = 2f;
                        }

                        else if (table2.Columns[i].ColumnName == "Item")
                        {
                            columnWidths[i] = 8f;
                        }
                        else if (table2.Columns[i].ColumnName == "Description")
                        {
                            columnWidths[i] = 8f;
                        }

                        else
                        {
                            columnWidths[i] = 6f;
                        }
                    }
                    Font tableHeaderFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.BLUE);
                    Font tableDataFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL);
                    PdfPTable pdfTable = new PdfPTable(table2.Columns.Count);
                    pdfTable.SetWidths(columnWidths);
                    pdfTable.WidthPercentage = 100;
                    foreach (DataColumn column in table2.Columns)
                    {
                        string columnName = (column.ColumnName == "ID") ? "#" : column.ColumnName;
                        PdfPCell pdfCell = new PdfPCell(new Phrase(columnName, tableHeaderFont));
                        pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        pdfCell.Padding = 10;
                        pdfTable.AddCell(pdfCell);
                    }
                    foreach (DataRow row in table2.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            PdfPCell dataCell = new PdfPCell(new Phrase(item.ToString(), tableDataFont));
                            dataCell.Padding = 10;
                            pdfTable.AddCell(dataCell);
                        }
                    }
                    doc.Add(pdfTable);
                }
                doc.Add(new Paragraph(" "));


                PdfPTable tablefiledetails = new PdfPTable(1);
                tablefiledetails.WidthPercentage = 100;
                PdfPCell Filedetailscell = new PdfPCell();
                Filedetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Filedetailscell.AddElement(new Paragraph("Attached Files :-", new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK)));
                tablefiledetails.AddCell(Filedetailscell);
                doc.Add(tablefiledetails);
                doc.Add(new Paragraph(" "));

                if (Gridtenderfile != null && Gridtenderfile.Rows.Count > 0)
                {

                    DataTable dtExport3 = new DataTable();
                    dtExport3.Columns.Add("ID");

                    dtExport3.Columns.Add("FileName");

                    foreach (DataRow row3 in Gridtenderfile.Rows)
                    {
                        DataRow newRow = dtExport3.NewRow();
                        newRow["ID"] = row3["ID"];

                        newRow["FileName"] = row3["FileName"];


                        dtExport3.Rows.Add(newRow);
                        tableB = dtExport3;
                    }

                    float[] columnWidths1 = new float[tableB.Columns.Count];
                    for (int i = 0; i < tableB.Columns.Count; i++)
                    {
                        if (tableB.Columns[i].ColumnName == "ID")
                        {
                            columnWidths1[i] = 2f;
                        }
                        else
                        {
                            columnWidths1[i] = 22f;
                        }

                    }
                    Font tableHeaderFont3 = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.BLUE);
                    Font tableDataFont3 = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL);
                    PdfPTable pdfTable3 = new PdfPTable(tableB.Columns.Count);
                    pdfTable3.SetWidths(columnWidths1);
                    pdfTable3.WidthPercentage = 100;
                    foreach (DataColumn column in tableB.Columns)
                    {
                        string columnName3 = (column.ColumnName == "ID") ? "#" : column.ColumnName;
                        PdfPCell pdfCell3 = new PdfPCell(new Phrase(columnName3, tableHeaderFont3));
                        pdfCell3.BackgroundColor = BaseColor.LIGHT_GRAY;
                        pdfCell3.Padding = 10;
                        pdfTable3.AddCell(pdfCell3);
                    }
                    foreach (DataRow row1 in tableB.Rows)
                    {
                        foreach (var file in row1.ItemArray)
                        {
                            PdfPCell dataCell2 = new PdfPCell(new Phrase(file.ToString(), tableDataFont3));
                            dataCell2.Padding = 10;
                            pdfTable3.AddCell(dataCell2);
                        }
                    }
                    doc.Add(pdfTable3);
                }
                doc.Add(new Paragraph(" "));
                PdfPTable tableTermscondition = new PdfPTable(1);
                tableQuedetails.WidthPercentage = 100;
                PdfPCell Termsconditioncell = new PdfPCell();
                Termsconditioncell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Termsconditioncell.AddElement(new Paragraph("Terms & Condition :-", new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK)));
                tableTermscondition.AddCell(Termsconditioncell);
                doc.Add(tableTermscondition);
                doc.Add(new Paragraph(" "));
                PdfPTable NoteTable = new PdfPTable(1);
                NoteTable.WidthPercentage = 100;
                PdfPCell NoteCell = new PdfPCell();
                NoteCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                NoteCell.AddElement(new Paragraph("NOTE:", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD)));
                NoteCell.AddElement(new Paragraph(lblclientnote.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                NoteCell.AddElement(new Paragraph("Terms & Condition:", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD)));
                NoteCell.AddElement(new Paragraph(lbltermsandcodition.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                NoteCell.AddElement(new Paragraph("  "));
                NoteCell.AddElement(new Paragraph("  "));
                NoteCell.AddElement(new Paragraph("Thank You", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD)));
                NoteTable.AddCell(NoteCell);
                doc.Add(NoteTable);
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                doc.Close();
                writer.Close();
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + lblTenderno.Text + ".pdf");
                HttpContext.Current.Response.BinaryWrite(memoryStream.ToArray());
                HttpContext.Current.Response.Flush();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
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

        protected void btnEditTender_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EditTender.aspx");
        }

        protected void lnkbtndeltender_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {
                        string ID;
                        var rows = GridSingleVenderTenderDetail.Rows;
                        LinkButton btn = (LinkButton)sender;
                        GridViewRow row = (GridViewRow)btn.NamingContainer;
                        int rowindex = Convert.ToInt32(row.RowIndex);
                        ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;
                        SqlCommand cmd = new SqlCommand("SP_DeleteTender", UserCon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@Created_by", UserName);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        UserCon.Open();
                        int i = cmd.ExecuteNonQuery();
                        UserCon.Close();
                        if (i < 0)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tender Details Deleted Successfully!')", true);
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tender Details not Deleted Successfully!')", true);
                        }
                    }
                }
                else if (RoleType == Designation)
                {
                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {
                        string ID;
                        var rows = GridSingleVenderTenderDetail.Rows;
                        LinkButton btn = (LinkButton)sender;
                        GridViewRow row = (GridViewRow)btn.NamingContainer;
                        int rowindex = Convert.ToInt32(row.RowIndex);
                        ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;
                        SqlCommand cmd = new SqlCommand("SP_DeleteTenderForEmpID", UserCon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@Created_by", UserName);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        UserCon.Open();
                        int i = cmd.ExecuteNonQuery();
                        UserCon.Close();
                        if (i < 0)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tender Details Deleted Successfully!')", true);
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tender Details not Deleted Successfully!')", true);
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

        protected void LinkBtnvenderName_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string VenderMapID;
                var rows = GridSingleVenderTenderDetail.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                VenderMapID = ((Label)rows[rowindex].FindControl("lblVendmapid1")).Text;
                Response.Redirect("~/ViewTenderVenderDetails.aspx?venderNo=" + VenderMapID + "", false);
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

        protected void lnkbtnnotpublished_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    UserCon.Open();
                    using (SqlCommand UserCommand = new SqlCommand("SP_UpdateTenderStatus", UserCon))
                    {
                        UserCommand.CommandType = CommandType.StoredProcedure;
                        UserCommand.Parameters.AddWithValue("@TenderNo", lblTenderno.Text);
                        UserCommand.Parameters.AddWithValue("@status", "Not Published");
                        UserCommand.Parameters.AddWithValue("@publish", "false");
                        UserCommand.Parameters.AddWithValue("@EmpID", UserId);//session 
                        UserCommand.Parameters.AddWithValue("@Designation", Designation);
                        UserCommand.Parameters.AddWithValue("@created_by", UserName);

                        int i = UserCommand.ExecuteNonQuery();

                        if (i < 0)
                        {
                            lblStatus.Text = "Not Published";
                            lblStatus.CssClass = "btn btn-sm btn-danger";
                            lblStatus.Attributes["style"] = "border-radius: 8px;";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Update Successfully!')", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Not Update Successfully!')", true);
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

        protected void lnkbtnpublished_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    UserCon.Open();
                    using (SqlCommand UserCommand = new SqlCommand("SP_UpdateTenderStatus", UserCon))
                    {
                        UserCommand.CommandType = CommandType.StoredProcedure;
                        UserCommand.Parameters.AddWithValue("@TenderNo", lblTenderno.Text);
                        UserCommand.Parameters.AddWithValue("@status", "Published");
                        UserCommand.Parameters.AddWithValue("@publish", "true");
                        UserCommand.Parameters.AddWithValue("@EmpID", UserId);//session 
                        UserCommand.Parameters.AddWithValue("@Designation", Designation);
                        UserCommand.Parameters.AddWithValue("@created_by", UserName);

                        int i = UserCommand.ExecuteNonQuery();

                        if (i < 0)
                        {
                            lblStatus.Text = "Published";
                            lblStatus.CssClass = "btn btn-sm btn-success";
                            lblStatus.Attributes["style"] = "border-radius: 8px;";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Update Successfully!')", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status Not Update Successfully!')", true);
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

        protected void Btn_Export_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = ViewTenderVenderDetails();
                if (dt != null && dt.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment;filename=TenderSubmitedVenderList.xls");

                    Response.Charset = " ";


                    DataTable dtExport = new DataTable();
                    dtExport.Columns.Add("ID");
                    dtExport.Columns.Add("Vend_Name");
                    dtExport.Columns.Add("First_Name");
                    dtExport.Columns.Add("Position");
                    dtExport.Columns.Add("email");
                    dtExport.Columns.Add("phonenumber");
                    dtExport.Columns.Add("TenderNumber");
                    dtExport.Columns.Add("TotalAmountTender");

                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow newRow = dtExport.NewRow();
                        newRow["ID"] = row["ID"];
                        newRow["Vend_Name"] = row["Vend_Name"];
                        newRow["First_Name"] = row["First_Name"];
                        newRow["Position"] = row["Position"];
                        newRow["email"] = row["email"];
                        newRow["phonenumber"] = row["phonenumber"];
                        newRow["TenderNumber"] = row["TenderNumber"];
                        newRow["TotalAmountTender"] = row["TotalAmountTender"];
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

        #endregion
    }
}
