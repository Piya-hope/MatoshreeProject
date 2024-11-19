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
using ZXing;
using iTextSharp.text;
//using itextsharp.Kernel.Events;
//using iText.Kernel.Pdf;
//using static iTextSharp.text.TabStop;
//using iText.Forms.Form.Element;

#endregion

namespace MatoshreeProject
{
    public partial class ViewTenderVenderDetails : System.Web.UI.Page
    {
        #region " Class Level Variable "

        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result;

        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;

        Double TotalAmont, TotalTaxAmount;
        string Size, Initial, ReceiptFor, Cash, Bank, reminder;

        string Day = Convert.ToString(DateTime.Today.Day);

        string year = Convert.ToString(DateTime.Today.Year);

        Double TenderTOTALAMONT;

        Double DiscountItem1 = 0, Adjustment1, TaxTotalItem1, SubtotalItem1;
        decimal TotalTEnderAmont;
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
            cmd.Parameters.AddWithValue("@ReceiptFor", "Work_Order");
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

        public void GetByVenderMapID()
        {
            try
            {
                string Venderno = HttpUtility.UrlDecode(Request.QueryString["venderNo"]);
                lblid1.Text = Venderno;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetTenderVenderDetailsbyID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@id", lblid1.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblid1.Text = dt.Rows[0]["ID"].ToString();
                        lblTenderID.Text = dt.Rows[0]["Tend_id"].ToString();
                        lblTenderno.Text = dt.Rows[0]["TenderNo"].ToString();
                        lblcontactId.Text = dt.Rows[0]["ContactID"].ToString();
                        lblTendername.Text = dt.Rows[0]["TenderName"].ToString();
                        lblStatus.Text = dt.Rows[0]["Status"].ToString();

                        lblclientnote.Text = dt.Rows[0]["Client_Note"].ToString();
                        lbltermsandcodition.Text = dt.Rows[0]["Term_condition"].ToString();
                        lblprojectid.Text = dt.Rows[0]["ProjectID"].ToString();
                        lblCustid.Text = dt.Rows[0]["CustomerID"].ToString();
                        lblURLname1.Text = dt.Rows[0]["ProjectName"].ToString();
                        lblstatus1.Text = dt.Rows[0]["Status"].ToString();
                        lbltendno1.Text = dt.Rows[0]["TenderNo"].ToString();

                        lblecv1.Text = dt.Rows[0]["estimatecontractvalue"].ToString();
                        lbltendcat1.Text = dt.Rows[0]["TenderBased"].ToString();
                        lblbidenddate1.Text = DateTime.Parse(dt.Rows[0]["BidEndDate"].ToString()).ToString("yyyy-MM-dd");
                        lbltendtype1.Text = dt.Rows[0]["Status"].ToString();

                        lblworkdesc1.Text = dt.Rows[0]["Description"].ToString();
                        //lbltendvalue1.Text = dt.Rows[0]["estimatecontractvalue"].ToString();
                        lbllocCity1.Text = dt.Rows[0]["AddCity"].ToString();

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

                        //Vender
                        lblvendername.Text = dt.Rows[0]["Vend_Name"].ToString();
                        lblvenconname1.Text = dt.Rows[0]["First_Name"].ToString();
                        lblvenconemail1.Text = dt.Rows[0]["email"].ToString();
                        lblvenconphone1.Text = dt.Rows[0]["phonenumber"].ToString();
                        lblvenconposition1.Text = dt.Rows[0]["Position"].ToString();
                        lblvenderblock.Text = dt.Rows[0]["VAdd_Block"].ToString();
                        lblvenderstreet.Text = dt.Rows[0]["VAdd_Street"].ToString();
                        lblvendercity.Text = dt.Rows[0]["VAdd_City"].ToString();
                        lblvenderdistrict.Text = dt.Rows[0]["VAdd_District"].ToString();
                        lblvenderstate.Text = dt.Rows[0]["VAdd_State"].ToString();
                        lblvenercountry.Text = dt.Rows[0]["VAdd_Country"].ToString();
                        lblvenderpin1.Text = dt.Rows[0]["VAdd_PinCode"].ToString();

                        //tendervendercalculation
                        lbltotal.Text = dt.Rows[0]["TotalAmountTender"].ToString();
                        lbltotaltax.Text = dt.Rows[0]["TotalTaxTotal"].ToString();
                        lblsubtotal.Text = dt.Rows[0]["TotalSubTotal"].ToString();
                        //ViewTenderVenderItemDetails();
                        //ViewTenderVenderQueAnsDetails();
                        //GetTotalTenderItemVendorCount();

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

        public DataTable ViewTenderVenderItemDetails()
        {
            DataTable dt = new DataTable();
         
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewTenderVendorItemsByVendorId", con))
                {
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure; // Set command type to stored procedure                 
                    ad.SelectCommand.Parameters.AddWithValue("@id", lblcontactId.Text);
                    ad.SelectCommand.Parameters.AddWithValue("@TenderNumber", lblTenderno.Text);
                    ad.Fill(dt);
                    Gridtendervenderitem.DataSource = dt;
                    Gridtendervenderitem.DataBind();
                }
            }
            return dt;
        }

        public DataTable ViewTenderVenderQueAnsDetails()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewTenderVenderQueAnsByVenderId", con))
                {
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure; // Set command type to stored procedure                 
                    ad.SelectCommand.Parameters.AddWithValue("@id", lblcontactId.Text);
                    ad.SelectCommand.Parameters.AddWithValue("@TenderNumber", lblTenderno.Text);
                    ad.Fill(dt);
                    GridViewTendvendQueAns.DataSource = dt;
                    GridViewTendvendQueAns.DataBind();
                }
            }
            return dt;
        }

        public void GetTotalTenderItemVendorCount()
        {
            try
            {
                SqlConnection Usercon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetTotalTenderItemVendorCount", Usercon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenderNumber", lblcontactId.Text);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lbltotalamt.Text = dt.Rows[0]["TotalAmount"].ToString();
                    lbltotaltax.Text = dt.Rows[0]["TotalTaxAmount"].ToString();
                    lblsubtotal.Text = dt.Rows[0]["SubTotal"].ToString();
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
                            GetByVenderMapID();
                            GetCompanyAddress();
                            ViewTenderVenderItemDetails();
                            ViewTenderVenderQueAnsDetails();

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
                            GetByVenderMapID();
                            GetCompanyAddress();
                            ViewTenderVenderItemDetails();
                            ViewTenderVenderQueAnsDetails();

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
                            GetByVenderMapID();
                            GetCompanyAddress();
                            ViewTenderVenderItemDetails();
                            ViewTenderVenderQueAnsDetails();
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

        protected void Btn_Allowcate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_AllowcateTenderToVender", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenderID", lblTenderID.Text);
                    cmd.Parameters.AddWithValue("@VendID", lblcontactId.Text);
                    cmd.Parameters.AddWithValue("@Empid", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@Createby", UserName);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i < 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Allocated Vendor Successfully!')", true);
                        Response.Redirect("~/NewWorkOrder.aspx?VendorID=" + lblcontactId.Text + "", false);
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Vendor Not Allocated Successfully!')", true);
                    }
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
        }

        protected void GridViewTendvendQueAns_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridViewTendvendQueAns.Rows)
                {
                    Label tendvendmapid1 = (Label)gridviedrow.FindControl("tendvendmapid1");
                    Label lblQuestion1 = (Label)gridviedrow.FindControl("lblQuestion1");
                    Label lblAnswer1 = (Label)gridviedrow.FindControl("lblAnswer1");
                    Label lblDoc_File1 = (Label)gridviedrow.FindControl("lblDoc_File1");

                    Label lblFilePath = (Label)gridviedrow.FindControl("lblFilePath");

                    LinkButton Btn_Download = (LinkButton)gridviedrow.FindControl("Btn_Download");

                    if (lblQuestion1.Text == "Upload" || lblQuestion1.Text == "Attachment")
                    {
                        lblDoc_File1.Visible = true;
                        lblFilePath.Visible = true;
                        Btn_Download.Visible = true;
                        string extention = System.IO.Path.GetExtension(lblDoc_File1.Text);

                    }
                    else
                    {
                        lblDoc_File1.Visible = false;
                        lblFilePath.Visible = false;
                        Btn_Download.Visible = false;
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

        protected void Gridtendervenderitem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                float TotalCGST_ddlTax11 = 0;
                float TotalSGST_ddlTax11 = 0;
                float TotalIGST_ddlTax11 = 0;

                float TotalCGST_ddlTax22 = 0;
                float TotalSGST_ddlTax22 = 0;
                float TotalIGST_ddlTax22 = 0;

                foreach (GridViewRow gridviedrow in Gridtendervenderitem.Rows)
                {
                    Label lblQuantity1 = (Label)gridviedrow.FindControl("lblQuantity1");
                    Label lblTax1Name1 = (Label)gridviedrow.FindControl("lblTax1Name1");
                    Label lblTax2Name1 = (Label)gridviedrow.FindControl("lblTax2Name1");
                    Label lblRate1 = (Label)gridviedrow.FindControl("lblRate1");
                    Label lblTax1Rate1 = (Label)gridviedrow.FindControl("lblTax1Rate1");
                    Label lblTax2Rate1 = (Label)gridviedrow.FindControl("lblTax2Rate1");

                    float Rate = Convert.ToSingle(lblRate1.Text);
                    float Qantity = Convert.ToSingle(lblQuantity1.Text);
                    float Rate1 = Convert.ToSingle(lblTax1Rate1.Text);
                    float Rate2 = Convert.ToSingle(lblTax2Rate1.Text);

                    if (lblTax1Name1.Text == "CGST")
                    {
                        TotalCGST_ddlTax11 += (Rate * Qantity * Rate1 / 100);
                    }
                    else if (lblTax1Name1.Text == "SGST")
                    {
                        TotalSGST_ddlTax11 += (Rate * Qantity * Rate1 / 100);
                    }
                    else
                    {
                        TotalIGST_ddlTax11 += (Rate * Qantity * Rate1 / 100);
                    }

                    if (lblTax2Name1.Text == "CGST")
                    {
                        TotalCGST_ddlTax22 += (Rate * Qantity * Rate2 / 100);
                    }
                    else if (lblTax2Name1.Text == "SGST")
                    {
                        TotalSGST_ddlTax22 += (Rate * Qantity * Rate2 / 100);
                    }
                    else
                    {
                        TotalIGST_ddlTax22 += (Rate * Qantity * Rate2 / 100);
                    }
                }

                // Update labels outside the loop
                lblcgst1.Text = (TotalCGST_ddlTax11 + TotalCGST_ddlTax22).ToString();
                lblsgst1.Text = (TotalSGST_ddlTax11 + TotalSGST_ddlTax22).ToString();
                lbligst1.Text = (TotalIGST_ddlTax11 + TotalIGST_ddlTax22).ToString();

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

        protected void Btn_Decline_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_DeallowcateTenderToVender", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenderID", lblTenderID.Text);
                    cmd.Parameters.AddWithValue("@VendID", lblcontactId.Text);
                    cmd.Parameters.AddWithValue("@Empid", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@Createby", UserName);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i < 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Deallocated Vendor Successfully!')", true);

                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Vendor Not Deallocated Successfully!')", true);
                    }
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
        }

        protected void lnkbtnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Image1.ImageUrl;
                DataTable table2 = new DataTable();
                DataTable table12 = ViewTenderVenderItemDetails();
                DataTable tableA = new DataTable();
                DataTable tableB = new DataTable();
                DataTable GridTenderQue = ViewTenderVenderQueAnsDetails();

                iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
                MemoryStream memoryStream = new MemoryStream();
                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, memoryStream);
                doc.Open();
                PdfPTable tableimage = new PdfPTable(1);
                tableimage.WidthPercentage = 100;
                PdfPCell imagecell = new PdfPCell();
                imagecell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));

                image.ScaleToFit(100f, 100f);
                imagecell.AddElement(image);
                tableimage.AddCell(imagecell);
                doc.Add(tableimage);
                doc.Add(new Paragraph(" "));

                PdfPTable tableAddress = new PdfPTable(2);
                tableAddress.WidthPercentage = 100;
                PdfPCell LeftAddresscell = new PdfPCell();
                LeftAddresscell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Chunk tenderfrom = new Chunk("From", new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK));
                Phrase tenderfromPh1 = new Phrase
               {
                tenderfrom
               };
                Paragraph tenderfromparagraph1 = new Paragraph(tenderfromPh1);
                tenderfromparagraph1.Alignment = Element.ALIGN_LEFT;
                LeftAddresscell.AddElement(tenderfromparagraph1);

                Chunk tenderaddno16 = new Chunk(lbladdCompany11.Text, new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK));
                Phrase tenderaddPh6 = new Phrase
 {
 tenderaddno16
 };
                Paragraph tendaddparagraph6 = new Paragraph(tenderaddPh6);
                tendaddparagraph6.Alignment = Element.ALIGN_LEFT;
                LeftAddresscell.AddElement(tendaddparagraph6);

                Chunk tenderaddno3 = new Chunk(lbladdress11.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderaddno6 = new Chunk(lblcompanyaddCity1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddPh1 = new Phrase
 {
  tenderaddno3,
  tenderaddno6
 };
                Paragraph tendaddparagraph1 = new Paragraph(tenderaddPh1);
                tendaddparagraph1.Alignment = Element.ALIGN_LEFT;
                LeftAddresscell.AddElement(tendaddparagraph1);

                Chunk tenderaddnoD1 = new Chunk("", new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderaddnoD = new Chunk(lblcompanyaddDistrict1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddPhD = new Phrase
 {
     tenderaddnoD1,
    tenderaddnoD
 };
                Paragraph tendaddparagraphD = new Paragraph(tenderaddPhD);
                tendaddparagraphD.Alignment = Element.ALIGN_LEFT;
                LeftAddresscell.AddElement(tendaddparagraphD);

                Chunk tenderaddnoS = new Chunk(lblcompanyaddState1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk tenderaddnoS1 = new Chunk(lblcompanyaddCountry1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddPhS = new Phrase
 {
    tenderaddnoS,
    tenderaddnoS1
 };
                Paragraph tendaddparagraphS = new Paragraph(tenderaddPhS);
                tendaddparagraphS.Alignment = Element.ALIGN_LEFT;
                LeftAddresscell.AddElement(tendaddparagraphS);

                Chunk tenderaddno28 = new Chunk("PIN:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderaddno29 = new Chunk(lblcompanyaddZIPCode11.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddPh10 = new Phrase
 {
  tenderaddno28,
  tenderaddno29
 };
                Paragraph tendaddparagraph10 = new Paragraph(tenderaddPh10);
                tendaddparagraph10.Alignment = Element.ALIGN_LEFT;
                LeftAddresscell.AddElement(tendaddparagraph10);

                Chunk tenderpinaddno2 = new Chunk("Phone:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderaddnoP = new Chunk(lblphoneNo1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderaddPh2 = new Phrase
 {
  tenderpinaddno2,
  tenderaddnoP
 };
                Paragraph tendaddparagraph2 = new Paragraph(tenderaddPh2);
                tendaddparagraph2.Alignment = Element.ALIGN_LEFT;
                LeftAddresscell.AddElement(tendaddparagraph2);
                tableAddress.AddCell(LeftAddresscell);


                PdfPCell companyaddresscell = new PdfPCell();
                companyaddresscell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Chunk vender1 = new Chunk("To,", new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK));
                Phrase venderPh1 = new Phrase
               {
              vender1
               };
                Paragraph venderparagraph1 = new Paragraph(venderPh1);
                venderparagraph1.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderparagraph1);

                Chunk vender2 = new Chunk(lblvendername.Text, new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK));
                Phrase venderPh2 = new Phrase
               {
                 vender2
               };
                Paragraph venderparagraph2 = new Paragraph(venderPh2);
                venderparagraph2.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderparagraph2);

                Chunk venderaddno16 = new Chunk(lblvenconname1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderaddPh6 = new Phrase
               {
                 venderaddno16
               };
                Paragraph venderaddparagraph6 = new Paragraph(venderaddPh6);
                venderaddparagraph6.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderaddparagraph6);

                Chunk venderaddno3 = new Chunk("Position:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk venderaddno6 = new Chunk(lblvenconposition1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderaddPh1 = new Phrase
{
 venderaddno3,
 venderaddno6
};
                Paragraph venderaddparagraph1 = new Paragraph(venderaddPh1);
                venderaddparagraph1.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderaddparagraph1);

                Chunk venderaddnoD1 = new Chunk("Email:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk venderaddnoD = new Chunk(lblvenconemail1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderaddPhD = new Phrase
{
    venderaddnoD1,
   venderaddnoD
};
                Paragraph venderaddparagraphD = new Paragraph(venderaddPhD);
                venderaddparagraphD.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderaddparagraphD);

                Chunk venderaddnoS = new Chunk("Phone Number:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk venderaddnoS1 = new Chunk(lblvenconphone1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderaddPhS = new Phrase
               {
                venderaddnoS,
               venderaddnoS1
               };
                Paragraph venderaddparagraphS = new Paragraph(venderaddPhS);
                venderaddparagraphS.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderaddparagraphS);

                Chunk vender3 = new Chunk(lblvenderblock.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderph3 = new Phrase
               {
                vender3
               };
                Paragraph venderparagraph3 = new Paragraph(venderph3);
                venderparagraph3.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderparagraph3);



                Chunk venderaddno28 = new Chunk(lblvenderstreet.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk venderaddno29 = new Chunk(lblvendercity.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderaddPh10 = new Phrase
{
 venderaddno28,
 venderaddno29
};
                Paragraph venderaddparagraph10 = new Paragraph(venderaddPh10);
                venderaddparagraph10.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderaddparagraph10);

                Chunk vender4 = new Chunk(lblvenderdistrict.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk venderaddcomma = new Chunk(",", new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderph4 = new Phrase
               {
               vender4,
               venderaddcomma
              };
                Paragraph venderparagraph4 = new Paragraph(venderph4);
                venderparagraph4.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderparagraph4);

                Chunk venderpinaddno2 = new Chunk(lblvenderstate.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk venderaddcomma1 = new Chunk(",", new Font(Font.FontFamily.HELVETICA, 12f));
                Chunk venderaddnoP = new Chunk(lblvenercountry.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderaddPh2 = new Phrase
               {
                 venderpinaddno2,
                 venderaddcomma1,
                 venderaddnoP
               };
                Paragraph venderaddparagraph2 = new Paragraph(venderaddPh2);
                venderaddparagraph2.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderaddparagraph2);

                Chunk vender6 = new Chunk("PIN:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk vender7 = new Chunk(lblvenderpin1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase venderph6 = new Phrase
               {
               vender6,
               vender7
               };
                Paragraph venderparagraph6 = new Paragraph(venderph6);
                venderparagraph6.Alignment = Element.ALIGN_RIGHT;
                companyaddresscell.AddElement(venderparagraph6);

                tableAddress.AddCell(companyaddresscell);
                doc.Add(tableAddress);

                doc.Add(new Paragraph(" "));

                PdfPTable tabletender = new PdfPTable(1);
                tabletender.WidthPercentage = 100;
                PdfPCell tendercell = new PdfPCell();
                tendercell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Chunk chtender = new Chunk("Applied Tender Details", new Font(Font.FontFamily.HELVETICA, 16f, Font.BOLD, BaseColor.BLACK));
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

                PdfPTable tabletenderdetails = new PdfPTable(1);
                tabletenderdetails.WidthPercentage = 100;
                PdfPCell tendercelldetails = new PdfPCell();

                tendercelldetails.AddElement(new Paragraph("Current Tender Details", new Font(Font.FontFamily.HELVETICA, 14f, Font.NORMAL, BaseColor.BLUE)));
                tendercelldetails.BackgroundColor = BaseColor.LIGHT_GRAY;
                tendercelldetails.PaddingLeft = 5;
                tendercelldetails.PaddingBottom = 15;
                tabletenderdetails.AddCell(tendercelldetails);
                doc.Add(tabletenderdetails);
                doc.Add(new Paragraph(" "));

                PdfPTable tabledetails = new PdfPTable(2);
                tabledetails.WidthPercentage = 100;
                //   tabledetails.Border = iTextSharp.text.Rectangle.NO_BORDER;
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
                Chunk tenderno14 = new Chunk(lbltendtype1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
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
                leftdetailscell.AddElement(tendworkparagraph4);


                Chunk tenderworkno22 = new Chunk("Pre Bid Meeting Address:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderworkno23 = new Chunk(lblprebidmeetingadd1.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase tenderworkPh8 = new Phrase
 {
 tenderworkno22,
 tenderworkno23

 };
                Paragraph tendworkparagraph8 = new Paragraph(tenderworkPh8);
                tendworkparagraph8.Alignment = Element.ALIGN_LEFT;
                leftdetailscell.AddElement(tendworkparagraph8);



                Chunk tenderdateno = new Chunk("Publish Date:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderdateno1 = new Chunk(lblpublishdate11.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase tenderdatePh = new Phrase
  {
  tenderdateno ,
  tenderdateno1

  };
                Paragraph tenddateparagraph = new Paragraph(tenderdatePh);
                tenddateparagraph.Alignment = Element.ALIGN_LEFT;
                leftdetailscell.AddElement(tenddateparagraph);



                Chunk tenderdateno13 = new Chunk("Bid Submission Start Date:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderdateno14 = new Chunk(lblbidstartdate1.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase tenderdatePh4 = new Phrase
  {
 tenderdateno13 ,
  tenderdateno14

  };
                Paragraph tenddateparagraph4 = new Paragraph(tenderdatePh4);
                tenddateparagraph4.Alignment = Element.ALIGN_LEFT;
                leftdetailscell.AddElement(tenddateparagraph4);


                Chunk chtenderwork31 = new Chunk("Work Description:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk chtenderwork41 = new Chunk(lblworkdesc1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase phtenderwork21 = new Phrase
                {
                chtenderwork31,
                chtenderwork41
                };
                Paragraph chtenderparagraphwork21 = new Paragraph(phtenderwork21);
                chtenderparagraphwork21.Alignment = Element.ALIGN_LEFT;
                leftdetailscell.AddElement(chtenderparagraphwork21);

                tabledetails.AddCell(leftdetailscell);

                PdfPCell rightdetailscell = new PdfPCell();
                rightdetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Chunk tenderno16 = new Chunk("Tender Category:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderno17 = new Chunk(lbltendcat1.Text, new Font(Font.FontFamily.HELVETICA, 12f));
                Phrase tenderPh6 = new Phrase
               {
               tenderno16,
               tenderno17

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

                Chunk tenderno6 = new Chunk("Bid Closing Date:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderno7 = new Chunk(lblbidenddate1.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase tenderPh3 = new Phrase
               {
               tenderno6,
               tenderno7

               };
                Paragraph tendparagraph3 = new Paragraph(tenderPh3);
                tendparagraph3.Alignment = Element.ALIGN_LEFT;
                rightdetailscell.AddElement(tendparagraph3);



                Chunk tenderworkno19 = new Chunk("Pre Bid Meeting Date:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderworkno20 = new Chunk(lblprebidmeetdate1.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase tenderworkPh7 = new Phrase
 {
 tenderworkno19,
 tenderworkno20

 };
                Paragraph tendworkparagraph7 = new Paragraph(tenderworkPh7);
                tendworkparagraph7.Alignment = Element.ALIGN_LEFT;
                rightdetailscell.AddElement(tendworkparagraph7);

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
                rightdetailscell.AddElement(tenddateparagraph6);

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
                rightdetailscell.AddElement(tenddateparagraph3);

                tabledetails.AddCell(rightdetailscell);
                doc.Add(tabledetails);
                doc.Add(new Paragraph(" "));

                PdfPTable tableitemdetails = new PdfPTable(1);
                tableitemdetails.WidthPercentage = 100;
                PdfPCell itemdetailscell = new PdfPCell();
                itemdetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                itemdetailscell.AddElement(new Paragraph("Tender Items", new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK)));
                tableitemdetails.AddCell(itemdetailscell);
                doc.Add(tableitemdetails);
                doc.Add(new Paragraph(" "));

                if (table12 != null && table12.Rows.Count > 0)
                {
                    DataTable dtExport = new DataTable();
                    dtExport.Columns.Add("ID");
                    dtExport.Columns.Add("Item");
                    dtExport.Columns.Add("Description");
                    dtExport.Columns.Add("Qnty");
                    dtExport.Columns.Add("Rate");
                    dtExport.Columns.Add("Tax1Name");
                    dtExport.Columns.Add("Tax1Rate");
                    dtExport.Columns.Add("Tax2Name");
                    dtExport.Columns.Add("Tax2Rate");
                    dtExport.Columns.Add("TotalAmont");
                    foreach (DataRow row in table12.Rows)
                    {
                        DataRow newRow = dtExport.NewRow();
                        newRow["ID"] = row["ID"];
                        newRow["Item"] = row["Item"];
                        newRow["Description"] = row["Description"];
                        newRow["Qnty"] = row["Qnty"];
                        newRow["Rate"] = row["Rate"];
                        newRow["Tax1Name"] = row["Tax1Name"];
                        newRow["Tax1Rate"] = row["Tax1Rate"];
                        newRow["Tax2Name"] = row["Tax2Name"];
                        newRow["Tax2Rate"] = row["Tax2Rate"];
                        newRow["TotalAmont"] = row["TotalAmont"];

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
                            columnWidths[i] = 4f;
                        }
                        else if (table2.Columns[i].ColumnName == "Description")
                        {
                            columnWidths[i] = 6f;
                        }
                        else if (table2.Columns[i].ColumnName == "Qnty")
                        {
                            columnWidths[i] = 4f;
                        }
                        else if (table2.Columns[i].ColumnName == "Rate")
                        {
                            columnWidths[i] = 4f;
                        }
                        else
                        {
                            columnWidths[i] = 4f;
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

                PdfPTable tableItemdetails = new PdfPTable(1);
                tableItemdetails.WidthPercentage = 100;
                PdfPCell Itemdetailscell = new PdfPCell();
                Itemdetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Chunk itemtotal = new Chunk("Total Item Amount:₹", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk itemtotal1 = new Chunk(lbltotal.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase itemPH = new Phrase
  {
 itemtotal,
  itemtotal1

  };
                Paragraph itemPharagraph = new Paragraph(itemPH);
                itemPharagraph.Alignment = Element.ALIGN_RIGHT;
                Itemdetailscell.AddElement(itemPharagraph);

                Chunk itemtotal2 = new Chunk("Total Sub Total Amount:₹", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk itemtotal3 = new Chunk(lblsubtotal.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase itemPH1 = new Phrase
  {
 itemtotal2,
  itemtotal3

  };
                Paragraph itemPharagraph1 = new Paragraph(itemPH1);
                itemPharagraph1.Alignment = Element.ALIGN_RIGHT;
                Itemdetailscell.AddElement(itemPharagraph1);

                Chunk itemtotal4 = new Chunk("Total Tax Amount:₹", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk itemtotal5 = new Chunk(lbltotaltax.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase itemPH2 = new Phrase
  {
 itemtotal4,
  itemtotal5

  };
                Paragraph itemPharagraph2 = new Paragraph(itemPH2);
                itemPharagraph2.Alignment = Element.ALIGN_RIGHT;
                Itemdetailscell.AddElement(itemPharagraph2);

                tableItemdetails.AddCell(Itemdetailscell);

                doc.Add(tableItemdetails);
                doc.Add(new Paragraph(" "));

                PdfPTable tableQuedetails = new PdfPTable(1);
                tableQuedetails.WidthPercentage = 100;
                PdfPCell Quedetailscell = new PdfPCell();
                Quedetailscell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Quedetailscell.AddElement(new Paragraph("Tender Question", new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, BaseColor.BLACK)));
                tableQuedetails.AddCell(Quedetailscell);
                doc.Add(tableQuedetails);
                doc.Add(new Paragraph(" "));

                if (GridTenderQue != null && GridTenderQue.Rows.Count > 0)
                {
                    DataTable dtExport2 = new DataTable();
                    dtExport2.Columns.Add("ID");
                    dtExport2.Columns.Add("Tend_Que");
                    dtExport2.Columns.Add("Tend_Ans");

                    foreach (DataRow row2 in GridTenderQue.Rows)
                    {
                        DataRow newRow = dtExport2.NewRow();
                        newRow["ID"] = row2["ID"];
                        newRow["Tend_Que"] = row2["Tend_Que"];
                        newRow["Tend_Ans"] = row2["Tend_Ans"];

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

                PdfPTable tabletenderAutoritydetails = new PdfPTable(1);
                tabletenderAutoritydetails.WidthPercentage = 100;
                PdfPCell tendercellAutoritydetails = new PdfPCell();
                //  tendercellAutoritydetails.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tendercellAutoritydetails.AddElement(new Paragraph("Tender Inviting Authority", new Font(Font.FontFamily.HELVETICA, 14f, Font.NORMAL, BaseColor.BLUE)));
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

                Phrase tenderAuthorityPh6 = new Phrase
   {
   tenderAuthorityno16,
   tenderAuthority17

   };
                Paragraph tendAuthorityparagraph6 = new Paragraph(tenderAuthorityPh6);
                tendAuthorityparagraph6.Alignment = Element.ALIGN_LEFT;
                rightAuthoritydetailscell.AddElement(tendAuthorityparagraph6);

                Chunk tenderAuthoritypositionno16 = new Chunk("Contact Number:", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD, BaseColor.BLACK));
                Chunk tenderAuthorityposition17 = new Chunk(lblconno1.Text, new Font(Font.FontFamily.HELVETICA, 12f));

                Phrase tenderAuthoritypositionPh6 = new Phrase
   {
   tenderAuthoritypositionno16,
   tenderAuthorityposition17

   };
                Paragraph tendAuthoritypositionparagraph6 = new Paragraph(tenderAuthoritypositionPh6);
                tendAuthoritypositionparagraph6.Alignment = Element.ALIGN_LEFT;
                rightAuthoritydetailscell.AddElement(tendAuthoritypositionparagraph6);

                tableAuthoritydetails.AddCell(rightAuthoritydetailscell);
                doc.Add(tableAuthoritydetails);
                doc.Add(new Paragraph(" "));



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
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + lblvenconname1.Text + ".pdf");
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

        protected void Linkbtnedit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EditTender.aspx");
        }

        protected void Btn_Download_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    LinkButton btn = (LinkButton)sender;
            //    GridViewRow row = (GridViewRow)btn.NamingContainer;
            //    int rowIndex = row.RowIndex;

            //    using (SqlConnection UserCon = new SqlConnection(strconnect))
            //    {


            //        Label tendvendmapid1 = (Label)GridViewTendvendQueAns.Rows[rowIndex].FindControl("tendvendmapid1");
            //        Label lblDoc_File1 = (Label)GridViewTendvendQueAns.Rows[rowIndex].FindControl("lblDoc_File1");

            //        Label lblFilePath = (Label)GridViewTendvendQueAns.Rows[rowIndex].FindControl("lblFilePath");
            //        //SqlCommand cmd = new SqlCommand("SP_GetLeaveManagementFileDetailsByID", UserCon);
            //        //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //        //cmd.Parameters.AddWithValue("@ID", lbdLeaveMID.Text);
            //        //DataTable dt = new DataTable();
            //        //sda.Fill(dt);



            //        //if (dt != null && dt.Rows.Count > 0)
            //        //{
            //            string name = lblDoc_File1.Text;
            //            string FilePath = lblFilePath.Text;
            //            string Extention = ".pdf";
            //            string contentType = "application/pdf";

            //            Byte[] bytes = (Byte[])dt.Rows[0]["Data"];

            //            Response.Buffer = true;
            //            Response.Charset = "";
            //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //            Response.ContentType = contentType;
            //            Response.AddHeader("content-disposition", "attachment;filename=" + name);
            //            Response.BinaryWrite(bytes);
            //            Response.Flush();
            //            Response.End();
            //        //}
            //    }


            //}
            //catch (Exception ex)
            //{
            //    using (SqlConnection UserCon = new SqlConnection(strconnect))
            //    {
            //        string ErrorMessgage = ex.Message;
            //        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
            //        string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
            //        string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
            //        Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
            //        SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", UserCon);
            //        cmdex.CommandType = CommandType.StoredProcedure;
            //        cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
            //        cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
            //        cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
            //        cmdex.Parameters.AddWithValue("@Method", method);
            //        cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
            //        UserCon.Open();
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
            //finally
            //{
            //}
        }

        #endregion
    }
}