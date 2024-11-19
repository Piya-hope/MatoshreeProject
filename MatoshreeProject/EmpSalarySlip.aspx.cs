#region " Class Description "


#endregion

#region " Primary Namespaces "

using System;
using System.Web;

#endregion

#region " Additional Namespaces "

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using iTextSharp.text;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using iTextSharp.text.pdf;
using System.IO;
using iText.Kernel.Pdf;
using System.Net.Mail;
using System.Net;

using Paragraph = iTextSharp.text.Paragraph;
//using static MatoshreeProject.ViewLeaveManagement;
#endregion

namespace MatoshreeProject
{
    public partial class EmpSalarySlip : System.Web.UI.Page
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
     
        Decimal GrandTotal, ComponentTotal, ContributionTotal, ContributionTotalFinal, PerDaySalary, LeaveDays, LeaveDaysTotal, DeductionTotal, AdditionTotal, NetSalary;


        string DevEmail, DevPassword, DevPort, DevHost, Date;



        string UserEmpName, Password, EmailID1, Designation1;


        Phrase phrase = null;

        private static String[] units = { "Zero", "One", "Two", "Three",
        "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
        "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
        "Seventeen", "Eighteen", "Nineteen" };
        private static String[] tens = { "", "", "Twenty", "Thirty", "Forty",
        "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        #endregion

        #region " Constructor "


        #endregion

        #region " Private Variables "


        #endregion

        #region " Shared Variables "


        #endregion

        #region " Public Variables "

        public void SendEmail()
        {
            //try
            //{
            //    UserName = Session["UserName"].ToString();
            //    EmailID = Session["EmailID"].ToString();
            //    Designation = Session["Role"].ToString();
            //    DeptID = Session["DeptID"].ToString();
            //    //-----------------Sending Email------------------------//
            //    GETCredentials();//method for domain password
            //    EmailID1 = lblContactEmail.Text;
            //    //Send Email User Password....//
            //    if (!string.IsNullOrEmpty(DevEmail))
            //    {
            //        using (MailMessage mm = new MailMessage(DevEmail, EmailID1))
            //        {
            //            //  MailBody
            //            mm.Subject = "Reminder of balance due for " + lblInvoiceno.Text;
            //            string body = "Dear" + lblFitstName.Text + "<br />";

            //            body += "This is a friendly reminder that your payment is now past due.";
            //            body += "According to our records," + lblInvoiceno.Text + "is past due for the payment of  " + lblInvoiceTotalAMT.Text + "as of  " + lblExpiry_Date1.Text;
            //            body += "In accordance with our policies, a late fee of " + lblInvoiceTotalAMT.Text + "has been assessed.";
            //            body += "At your earliest convenience, please make your payment here: " + lblPaymentMode1.Text;
            //            body += "If you have any questions or need to discuss your account, you can reach me at " + lblphoneNo.Text;
            //            body += "Thank you for your attention to this matter and your continued business.";
            //            body += "Sincerely,";
            //            body += UserName;
            //            body += Designation;
            //            body += EmailID;
            //            body += lbladdCompany1.Text;
            //            mm.Body = body;
            //            mm.IsBodyHtml = true;
            //            mm.Priority = MailPriority.Normal;
            //            SmtpClient smtp = new SmtpClient();
            //            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //            smtp.Host = DevHost;
            //            //"mail.shinedatameterms.in"
            //            //smtp.EnableSsl = false;
            //            //smtp.Host = "relay-hosting.secureserver.net";
            //            //smtp.UseDefaultCredentials = true;
            //            NetworkCredential NetworkCred = new NetworkCredential(DevEmail, DevPassword);
            //            smtp.Credentials = NetworkCred;
            //            smtp.Port = Convert.ToInt32(DevPort);

            //            try
            //            {
            //                smtp.Send(mm);
            //                //ViewBag.Message = "Email Send Successfully";
            //            }
            //            catch (Exception ex)
            //            {
            //                //Response.Write("<script>alert('Email Not Send '); </script>");
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
            //finally { }
        }
        #endregion

        #region " Public Properties "


        #endregion

        #region " Private Functions "


        #endregion

        #region " Protected Functions "


        #endregion

        #region " Public Functions "
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
                    command.Parameters.AddWithValue("@SubModule", "EmpSalarySlip");
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
                            GetEmployeeSalary();
                            ViewAddition();
                            ViewDeduction();
                            GetCompanyAddress();

                            //if (Create == "True")
                            //{
                            //    addnew.Visible = true;
                            //    btnNewCustomer.Visible = true;
                            //}
                            //else
                            //{
                            //    addnew.Visible = false;
                            //    btnNewCustomer.Visible = false;
                            //}

                            //if (Edit == "True")
                            //{

                            //    GridCustomer.Columns[8].Visible = true;
                            //}
                            //else
                            //{

                            //    GridCustomer.Columns[8].Visible = false;
                            //}

                            //if (Delete == "True")
                            //{

                            //    GridCustomer.Columns[9].Visible = true;
                            //}
                            //else
                            //{

                            //    GridCustomer.Columns[9].Visible = false;
                            //}
                        }
                        else if (View == "True")
                        {
                            GetEmployeeSalary();
                            ViewAddition();
                            ViewDeduction();
                            GetCompanyAddress();

                            //if (Create == "True")
                            //{
                            //    addnew.Visible = true;
                            //    btnNewCustomer.Visible = true;
                            //}
                            //else
                            //{
                            //    addnew.Visible = false;
                            //    btnNewCustomer.Visible = false;
                            //}

                            //if (Edit == "True")
                            //{

                            //    GridCustomer.Columns[8].Visible = true;
                            //}
                            //else
                            //{

                            //    GridCustomer.Columns[8].Visible = false;
                            //}

                            //if (Delete == "True")
                            //{

                            //    GridCustomer.Columns[9].Visible = true;
                            //}
                            //else
                            //{

                            //    GridCustomer.Columns[9].Visible = false;
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

        public static String ConvertAmount(double amount)
        {
            try
            {
                Int64 amount_int = (Int64)amount;
                Int64 amount_dec = (Int64)Math.Round((amount - (double)(amount_int)) * 100);
                if (amount_dec == 0)
                {
                    return Convert1(amount_int) + " Only Rupees.";
                }
                else
                {
                    return Convert1(amount_int) + " Point " + Convert1(amount_dec) + " Only Rupees.";
                }
            }
            catch (Exception e)
            {
                // TODO: handle exception  
            }
            return "";
        }
        public static String Convert1(Int64 i)
        {
            if (i < 20)
            {
                return units[i];
            }
            if (i < 100)
            {
                return tens[i / 10] + ((i % 10 > 0) ? " " + Convert1(i % 10) : "");
            }
            if (i < 1000)
            {
                return units[i / 100] + " Hundred"
                        + ((i % 100 > 0) ? " And " + Convert1(i % 100) : "");
            }
            if (i < 100000)
            {
                return Convert1(i / 1000) + " Thousand "
                + ((i % 1000 > 0) ? " " + Convert1(i % 1000) : "");
            }
            if (i < 10000000)
            {
                return Convert1(i / 100000) + " Lakh "
                        + ((i % 100000 > 0) ? " " + Convert1(i % 100000) : "");
            }
            if (i < 1000000000)
            {
                return Convert1(i / 10000000) + " Crore "
                        + ((i % 10000000 > 0) ? " " + Convert1(i % 10000000) : "");
            }
            return Convert1(i / 1000000000) + " Arab "
                    + ((i % 1000000000 > 0) ? " " + Convert1(i % 1000000000) : "");
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

        public DataTable ViewAddition()
        {
            DataTable ds = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewSalaryCompEdit", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", lblStaffID.Text);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        GridViewComponent.DataSource = ds;
                        GridViewComponent.DataBind();
                    }
                    else
                    {
                        ds.Rows.Add(ds.NewRow());
                        GridViewComponent.DataSource = ds;
                        GridViewComponent.DataBind();

                    }

                }

            }

            return ds;
        }

        public DataTable ViewDeduction()
        {
            DataTable adcomp = ViewAddition();
            DataTable ds1 = new DataTable();
            using (SqlConnection conn = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewSalaryContriEdit", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", lblStaffID.Text);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds1);
                    if (ds1.Rows.Count > 0)
                    {
                        //ds1.Merge(adcomp);
                        GridViewEmpCompansion.DataSource = ds1;
                        GridViewEmpCompansion.DataBind();
                    }
                    else
                    {
                        ds1.Rows.Add(ds1.NewRow());
                        GridViewEmpCompansion.DataSource = ds1;
                        GridViewEmpCompansion.DataBind();
                    }
                }

            }

            return ds1;
        }

        public void GetEmployeeSalary()
        {
            try
            {
                string StaffID = HttpUtility.UrlDecode(Request.QueryString["XCEEMPIDdfd"]);
                lblStaffID.Text = StaffID;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GETEmpSalaryEMPID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@StaffID", lblStaffID.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblName.Text = dt.Rows[0]["StaffName"].ToString();
                        lblDepartment.Text = dt.Rows[0]["Dept_Name"].ToString();
                        lblDesignation.Text = dt.Rows[0]["Role"].ToString();
                        lblPackage.Text = dt.Rows[0]["Package"].ToString();
                        lblDate.Text = dt.Rows[0]["Date"].ToString();
                        lblNetSalary.Text = dt.Rows[0]["NetSalary"].ToString();
                        lblDOJ.Text = dt.Rows[0]["DOJ"].ToString();
                        lblEMPNumber.Text = dt.Rows[0]["EMPNumber"].ToString();
                        lblDOB.Text = dt.Rows[0]["DOB"].ToString();

                        NetSalary = Convert.ToDecimal(lblNetSalary.Text);
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

        public DataTable GetEmployeeDocument(int StaffID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetDocumentsEmpID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    cmd.Parameters.AddWithValue("@StaffID", lblStaffID.Text);
                  
                    sda.Fill(dt);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    lblUAN.Text = dt.Rows[0]["UAN"].ToString();
                    //    lblPFNumber.Text = dt.Rows[0]["PFNumber"].ToString();
                    //    lblAdharCardNumber.Text = dt.Rows[0]["AdharCardNumber"].ToString();
                    //    lblBankName.Text = dt.Rows[0]["BankName"].ToString();
                    //    lblBankAccNumber.Text = dt.Rows[0]["BankAccNumber"].ToString();
                    //}
                    return dt;
                }
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
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
                return dt;
            }


        }

        #endregion

        #region "Event "
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
                            GetEmployeeSalary();
                            ViewAddition();
                            ViewDeduction();
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
                                //StaffOperationPermission();
                                //GetMessageFromModules();
                                GetEmployeeSalary();
                                ViewAddition();
                                ViewDeduction();
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
        protected void GridViewEmpCompansion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                String StaffID;
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblAmounts2 = (Label)e.Row.FindControl("lblAmounts2");
                    StaffID = lblStaffID.Text;
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand command = new SqlCommand("SP_ViewSalaryTotalContriEdit", con);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StaffID", StaffID);
                        con.Open();
                        SqlDataAdapter sd = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            lblAmounts2.Text = dt.Rows[0]["DtotalAnnualEmployeer"].ToString();
                            DeductionTotal = Convert.ToDecimal(lblAmounts2.Text);
                        }
                        else
                        {
                            lblAmounts2.Text = "0.0";
                        }
                        // ViewDeduction(StaffID);
                        // con.Close();

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

        protected void GridViewComponent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                String StaffID;
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblAmount2 = (Label)e.Row.FindControl("lblAmount2");
                    StaffID = lblStaffID.Text;
                    using (SqlConnection con = new SqlConnection(strconnect))
                    {
                        SqlCommand command = new SqlCommand("SP_ViewSalaryTotalCompEdit   ", con);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StaffID", StaffID);
                        con.Open();
                        SqlDataAdapter sd = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            lblAmount2.Text = dt.Rows[0]["TotalMonthlyComp"].ToString();
                            AdditionTotal = Convert.ToDecimal(lblAmount2.Text);
                        }
                        else
                        {
                            lblAmount2.Text = "0.0";
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

        protected void linkbtnPDFSalarySlip_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    if (lblStaffID.Text == "0")//item == "Select Item" ||AND Item
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Staff!')", true);
                    }
                    else
                    {
                        int _totalColumns = 4;//
                        int _totalColumns1 = 4;

                        string path = Image1.ImageUrl;
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));

                        Font _fontStyle, _fontStyle1;

                        PdfPTable _pdfPTable = new PdfPTable(4);//change col

                        PdfPTable _pdfPTable1 = new PdfPTable(4);
                        PdfPTable _pdfPTable2 = new PdfPTable(2);
                        PdfPTable _pdfPTable3 = new PdfPTable(1);

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

                        _document.SetPageSize(PageSize.A4);
                        _document.SetMargins(20f, 20f, 20f, 20f);
                        _pdfPTable1.WidthPercentage = 500;
                        _pdfPTable1.TotalWidth = 500f;
                        _pdfPTable1.LockedWidth = true;
                        _pdfPTable1.HorizontalAlignment = Element.ALIGN_CENTER;
                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

                        _document.SetPageSize(PageSize.A4);
                        _document.SetMargins(20f, 20f, 20f, 20f);
                        _pdfPTable2.WidthPercentage = 500;
                        _pdfPTable2.TotalWidth = 500f;
                        _pdfPTable2.LockedWidth = true;
                        _pdfPTable2.HorizontalAlignment = Element.ALIGN_CENTER;
                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

                        _document.SetPageSize(PageSize.A4);
                        _document.SetMargins(20f, 20f, 20f, 20f);
                        _pdfPTable3.WidthPercentage = 500;
                        _pdfPTable3.TotalWidth = 500f;
                        _pdfPTable3.LockedWidth = true;
                        _pdfPTable3.HorizontalAlignment = Element.ALIGN_CENTER;
                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

                        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                        {
                            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(_document, memoryStream);

                            _document.Open();
                            _pdfPTable.SetWidths(new float[] { 9f, 9f, 9f, 9f });//column width in doc       
                                                                                 //----Header PDF--------------------------//
                                                                                 //Company Logo

                            _pdfPTable1.SetWidths(new float[] { 3f, 9f, 9f, 9f });

                            cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                            cell.Colspan = 2;
                            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.PaddingRight = 6f;

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
                            _pdfPCell.Colspan = 2;
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
                            _pdfPCell.Colspan = 3;
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                            _pdfPCell.Border = 2;
                            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 4;
                            _pdfPTable.AddCell(_pdfPCell);
                            _pdfPTable.CompleteRow();

                            _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                            _pdfPCell.Colspan = 1;
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            _pdfPCell.Border = 0;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 4;
                            _pdfPCell.PaddingRight = 10f;
                            _pdfPCell.PaddingTop = 15f;
                            _pdfPTable.AddCell(_pdfPCell);

                            _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                             Date = Convert.ToString(lblDate.Text);
                            _pdfPCell = new PdfPCell(new Phrase("Pay Slip - " + Date.ToString(), _fontStyle));
                            _pdfPCell.Colspan = 2;
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.Border = 0;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 4;
                            _pdfPCell.PaddingRight = 10f;
                            _pdfPCell.PaddingTop = 15f;
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
                            _pdfPCell.PaddingTop = 15f;
                            _pdfPTable.AddCell(_pdfPCell);
                            _pdfPTable.CompleteRow();

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

                            //-----------------------Staff Detail---------------------------------------------//

                            #region "Table Header"
                            String Name = Convert.ToString(lblName.Text);
                            String Department = Convert.ToString(lblDepartment.Text);
                            String Designation = Convert.ToString(lblDesignation.Text);
                            String Package = Convert.ToString(lblPackage.Text);
                            String EMPNumber = Convert.ToString(lblEMPNumber.Text);
                            String AdharCardNumber = Convert.ToString(lblAdharCardNumber.Text);
                            String BankName = Convert.ToString(lblBankName.Text);
                            String BankAccNumber = Convert.ToString(lblBankAccNumber.Text);
                            String PFNumber = Convert.ToString(lblPFNumber.Text);
                            String UAN = Convert.ToString(lblUAN.Text);
                            String DOJ = Convert.ToString(lblDOJ.Text);
                            String DOB = Convert.ToString(lblDOB.Text);

                            PdfPTable Satfftable = new PdfPTable(4);
                            Satfftable.WidthPercentage = 100;
                            Satfftable.DefaultCell.Border = iTextSharp.text.Rectangle.BOX;

                            PdfPCell S9cell = new PdfPCell(new Phrase("EMPID", _fontStyle));
                            S9cell.Colspan = 1;
                            S9cell.HorizontalAlignment = 1;
                            S9cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S9cell.Border = 0;
                            Satfftable.AddCell(S9cell);

                            PdfPCell S10cell = new PdfPCell(new Phrase(EMPNumber.ToString(), _fontStyle));
                            S10cell.Colspan = 1;
                            S10cell.HorizontalAlignment = 1;
                            S10cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S10cell.Border = 0;
                            Satfftable.AddCell(S10cell);

                            PdfPCell S1cell = new PdfPCell(new Phrase("Name", _fontStyle));
                            S1cell.Colspan = 1;
                            S1cell.HorizontalAlignment = 1;
                            S1cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S1cell.Border = 0;
                            Satfftable.AddCell(S1cell);

                            PdfPCell S2cell = new PdfPCell(new Phrase(Name.ToString(), _fontStyle));
                            S2cell.Colspan = 1;
                            S2cell.HorizontalAlignment = 1;
                            S2cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S2cell.Border = 0;
                            Satfftable.AddCell(S2cell);

                            PdfPCell S3cell = new PdfPCell(new Phrase("Department", _fontStyle));
                            S3cell.Colspan = 1;
                            S3cell.HorizontalAlignment = 1;
                            S3cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S3cell.Border = 0;
                            Satfftable.AddCell(S3cell);

                            PdfPCell S4cell = new PdfPCell(new Phrase(Department.ToString(), _fontStyle));
                            S3cell.Colspan = 1;
                            S4cell.HorizontalAlignment = 1;
                            S4cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S4cell.Border = 0;
                            Satfftable.AddCell(S4cell);

                            PdfPCell S5cell = new PdfPCell(new Phrase("Designation", _fontStyle));
                            S5cell.Colspan = 1;
                            S5cell.HorizontalAlignment = 1;
                            S5cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S5cell.Border = 0;
                            Satfftable.AddCell(S5cell);

                            PdfPCell S6cell = new PdfPCell(new Phrase(Designation.ToString(), _fontStyle));
                            S6cell.Colspan = 1;
                            S6cell.HorizontalAlignment = 1;
                            S6cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S6cell.Border = 0;
                            Satfftable.AddCell(S6cell);

                            PdfPCell S7cell = new PdfPCell(new Phrase("Package", _fontStyle));
                            S7cell.Colspan = 1;
                            S7cell.HorizontalAlignment = 1;
                            S7cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S7cell.Border = 0;
                            Satfftable.AddCell(S7cell);

                            PdfPCell S8cell = new PdfPCell(new Phrase(Package.ToString(), _fontStyle));
                            S8cell.Colspan = 1;
                            S8cell.HorizontalAlignment = 1;
                            S8cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S8cell.Border = 0;
                            Satfftable.AddCell(S8cell);

                            PdfPCell S11cell = new PdfPCell(new Phrase("DOB", _fontStyle));
                            S11cell.Colspan = 1;
                            S11cell.HorizontalAlignment = 1;
                            S11cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S11cell.Border = 0;
                            Satfftable.AddCell(S11cell);

                            PdfPCell S12cell = new PdfPCell(new Phrase(DOB.ToString(), _fontStyle));
                            S12cell.Colspan = 1;
                            S12cell.HorizontalAlignment = 1;
                            S12cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S12cell.Border = 0;
                            Satfftable.AddCell(S12cell);

                            PdfPCell S13cell = new PdfPCell(new Phrase("DOJ", _fontStyle));
                            S13cell.Colspan = 1;
                            S13cell.HorizontalAlignment = 1;
                            S13cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S13cell.Border = 0;
                            Satfftable.AddCell(S13cell);

                            PdfPCell S14cell = new PdfPCell(new Phrase(DOJ.ToString(), _fontStyle));
                            S14cell.Colspan = 1;
                            S14cell.HorizontalAlignment = 1;
                            S14cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S14cell.Border = 0;
                            Satfftable.AddCell(S14cell);

                            PdfPCell S15cell = new PdfPCell(new Phrase("UAN", _fontStyle));
                            S15cell.Colspan = 1;
                            S15cell.HorizontalAlignment = 1;
                            S15cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S15cell.Border = 0;
                            Satfftable.AddCell(S15cell);

                            PdfPCell S16cell = new PdfPCell(new Phrase(UAN.ToString(), _fontStyle));
                            S16cell.Colspan = 1;
                            S16cell.HorizontalAlignment = 1;
                            S16cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S16cell.Border = 0;
                            Satfftable.AddCell(S16cell);

                            PdfPCell S17cell = new PdfPCell(new Phrase("BankAccNumber", _fontStyle));
                            S17cell.Colspan = 1;
                            S17cell.HorizontalAlignment = 1;
                            S17cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S17cell.Border = 0;
                            Satfftable.AddCell(S17cell);

                            PdfPCell S18cell = new PdfPCell(new Phrase(BankAccNumber.ToString(), _fontStyle));
                            S18cell.Colspan = 1;
                            S18cell.HorizontalAlignment = 1;
                            S18cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S18cell.Border = 0;
                            Satfftable.AddCell(S18cell);

                            PdfPCell S19cell = new PdfPCell(new Phrase("BankName", _fontStyle));
                            S19cell.Colspan = 1;
                            S19cell.HorizontalAlignment = 1;
                            S19cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S19cell.Border = 0;
                            Satfftable.AddCell(S19cell);

                            PdfPCell S20cell = new PdfPCell(new Phrase(BankName.ToString(), _fontStyle));
                            S20cell.Colspan = 1;
                            S20cell.HorizontalAlignment = 1;
                            S20cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S20cell.Border = 0;
                            Satfftable.AddCell(S20cell);

                            PdfPCell S21cell = new PdfPCell(new Phrase("AdharCardNumber", _fontStyle));
                            S21cell.Colspan = 1;
                            S21cell.HorizontalAlignment = 1;
                            S21cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S21cell.Border = 0;
                            Satfftable.AddCell(S21cell);

                            PdfPCell S22cell = new PdfPCell(new Phrase(AdharCardNumber.ToString(), _fontStyle));
                            S22cell.Colspan = 1;
                            S22cell.HorizontalAlignment = 1;
                            S22cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S22cell.Border = 0;
                            Satfftable.AddCell(S22cell);

                            PdfPCell S23cell = new PdfPCell(new Phrase("PF Number", _fontStyle));
                            S23cell.Colspan = 1;
                            S23cell.HorizontalAlignment = 1;
                            S23cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S23cell.Border = 0;
                            Satfftable.AddCell(S23cell);

                            PdfPCell S24cell = new PdfPCell(new Phrase(PFNumber.ToString(), _fontStyle));
                            S24cell.Colspan = 1;
                            S24cell.HorizontalAlignment = 1;
                            S24cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            S24cell.Border = 0;
                            Satfftable.AddCell(S24cell);
                            #endregion


                            //----------------------------------Componets and deduction----------------------------------//
                            _fontStyle1 = FontFactory.GetFont("Tahoma", 9f, Font.NORMAL);

                            PdfContentByte content = writer.DirectContent;
                            PdfPTable mtable = new PdfPTable(2);
                            mtable.WidthPercentage = 100;
                            mtable.DefaultCell.Border = iTextSharp.text.Rectangle.BOX;

                            PdfPTable Atable = new PdfPTable(2);
                            Atable.WidthPercentage = 100;
                            PdfPCell Acell = new PdfPCell(new Phrase("Addition"));
                            Acell.Colspan = 2;
                            Acell.HorizontalAlignment = 1;
                            Atable.AddCell(Acell);
                            DataTable _Vhrlist = new DataTable();
                            _Vhrlist = ViewAddition();

                            Atable.AddCell("Earnings");
                            Atable.AddCell("Amount");

                            foreach (DataRow row in _Vhrlist.Rows)
                            {
                                Atable.AddCell(new Phrase(row["Category"].ToString(), _fontStyle1));
                                Atable.AddCell(new Phrase(row["MonthlyAmount"].ToString(), _fontStyle1));
                            }

                            mtable.AddCell(Atable);

                            PdfPTable Atable1 = new PdfPTable(2);
                            Atable1.WidthPercentage = 100;
                            PdfPCell Acell1 = new PdfPCell(new Phrase("Deduction"));
                            Acell1.Colspan = 2;
                            Acell1.HorizontalAlignment = 1;
                            Atable1.AddCell(Acell1);
                            DataTable _Vhrlist1 = new DataTable();
                            _Vhrlist1 = ViewDeduction();
                            Atable1.AddCell("Deduction");
                            Atable1.AddCell("Amount");
                            foreach (DataRow row in _Vhrlist1.Rows)
                            {
                                Atable1.AddCell(new Phrase(row["Dcategory"].ToString(), _fontStyle1));
                                Atable1.AddCell(new Phrase(row["DannualAmount"].ToString(), _fontStyle1));

                            }

                            //-------------------------------------------------------------------------//
                            PdfPTable Dtable = new PdfPTable(4);
                            Dtable.WidthPercentage = 100;
                            PdfPCell Dcell = new PdfPCell(new Phrase("Total-A", _fontStyle));
                            Dcell.Colspan = 1;
                            Dcell.HorizontalAlignment = 1;
                            Dtable.AddCell(Dcell);

                            PdfPCell Dcell2 = new PdfPCell(new Phrase(AdditionTotal.ToString(), _fontStyle));
                            Dcell.Colspan = 1;
                            Dcell.HorizontalAlignment = 1;
                            Dtable.AddCell(Dcell2);

                            PdfPCell Dcell3 = new PdfPCell(new Phrase("Total-B", _fontStyle));
                            Dcell.Colspan = 1;
                            Dcell.HorizontalAlignment = 1;
                            Dtable.AddCell(Dcell3);

                            PdfPCell Dcell4 = new PdfPCell(new Phrase(DeductionTotal.ToString(), _fontStyle));
                            Dcell.Colspan = 1;
                            Dcell.HorizontalAlignment = 1;
                            Dtable.AddCell(Dcell4);

                            //----------------------------Net Salary------------------------------------//

                            PdfPTable Ntable = new PdfPTable(4);
                            Ntable.WidthPercentage = 100;

                            PdfPCell N1cell = new PdfPCell(new Phrase("Net Salary: " + NetSalary.ToString(), _fontStyle));
                            N1cell.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                            N1cell.Colspan = 1;
                            N1cell.HorizontalAlignment = 1;
                            Ntable.AddCell(N1cell);

                            PdfPCell N2cell = new PdfPCell(new Phrase("", _fontStyle));
                            N2cell.Border = iTextSharp.text.Rectangle.ALIGN_LEFT;
                            N2cell.Colspan = 1;
                            N2cell.HorizontalAlignment = 1;
                            Ntable.AddCell(N2cell);

                            PdfPCell N3cell = new PdfPCell(new Phrase("", _fontStyle));
                            N3cell.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                            N3cell.Colspan = 2;
                            N3cell.HorizontalAlignment = 1;
                            Ntable.AddCell(N3cell);

                            //------------ Total in Words-------------------------------//
                            PdfPTable InvoiceCostInword = new PdfPTable(1);
                            InvoiceCostInword.WidthPercentage = 100;
                            PdfPCell salaryword = new PdfPCell();
                            salaryword.Border = iTextSharp.text.Rectangle.RECTANGLE;
                            double NetSalaryWord = Convert.ToDouble(lblNetSalary.Text);
                            string number = ConvertAmount(NetSalaryWord);
                            Chunk Inword = new Chunk("In words: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                            Chunk Inwordvalue = new Chunk(number, new Font(Font.FontFamily.HELVETICA, 10f));
                            Phrase phraseInword = new Phrase
                        {
                         Inword,
                         Inwordvalue
                        };
                            Paragraph paraInword = new Paragraph(phraseInword);
                            paraInword.Alignment = Element.ALIGN_LEFT;
                            salaryword.AddElement(paraInword);

                            InvoiceCostInword.AddCell(salaryword);

                            //-------------------- PDF Generation------------------------------------//

                            _pdfPTable.HeaderRows = 1; //header method
                            _document.Add(_pdfPTable);

                            // Add an empty paragraph for spacing

                            _document.Add(new Paragraph("\n"));
                            _document.Add(Satfftable);
                            _document.Add(new Paragraph("\n"));
                            mtable.AddCell(Atable1);

                            _document.Add(mtable);
                            _document.Add(Dtable);
                            _document.Add(Ntable);
                            _document.Add(InvoiceCostInword);

                            _pdfPTable2.HeaderRows = 1;
                            _document.Add(_pdfPTable2);
                            _document.Add(new Paragraph("Note:This is Computer Generated Payslip Signature not required.", _fontStyle1));
                            _document.Close();
                            byte[] bytes = memoryStream.ToArray();
                            DateTime dTime = DateTime.Now;
                            string PDFFileName = string.Format("EmpolyeeMonthlySalarySlip_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
                else if (RoleType == Designation)
                {
                    if (lblStaffID.Text == "0")//item == "Select Item" ||AND Item
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select Staff!')", true);
                    }
                    else
                    {
                        int _totalColumns = 4;//
                        int _totalColumns1 = 4;

                        string path = Image1.ImageUrl;
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));

                        Font _fontStyle, _fontStyle1;

                        PdfPTable _pdfPTable = new PdfPTable(4);//change col

                        PdfPTable _pdfPTable1 = new PdfPTable(4);
                        PdfPTable _pdfPTable2 = new PdfPTable(2);
                        PdfPTable _pdfPTable3 = new PdfPTable(1);

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

                        _document.SetPageSize(PageSize.A4);
                        _document.SetMargins(20f, 20f, 20f, 20f);
                        _pdfPTable1.WidthPercentage = 500;
                        _pdfPTable1.TotalWidth = 500f;
                        _pdfPTable1.LockedWidth = true;
                        _pdfPTable1.HorizontalAlignment = Element.ALIGN_CENTER;
                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

                        _document.SetPageSize(PageSize.A4);
                        _document.SetMargins(20f, 20f, 20f, 20f);
                        _pdfPTable2.WidthPercentage = 500;
                        _pdfPTable2.TotalWidth = 500f;
                        _pdfPTable2.LockedWidth = true;
                        _pdfPTable2.HorizontalAlignment = Element.ALIGN_CENTER;
                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

                        _document.SetPageSize(PageSize.A4);
                        _document.SetMargins(20f, 20f, 20f, 20f);
                        _pdfPTable3.WidthPercentage = 500;
                        _pdfPTable3.TotalWidth = 500f;
                        _pdfPTable3.LockedWidth = true;
                        _pdfPTable3.HorizontalAlignment = Element.ALIGN_CENTER;
                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

                        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                        {
                            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(_document, memoryStream);

                            _document.Open();
                            _pdfPTable.SetWidths(new float[] { 9f, 9f, 9f, 9f });//column width in doc       
                                                                                 //----Header PDF--------------------------//
                                                                                 //Company Logo

                            _pdfPTable1.SetWidths(new float[] { 3f, 9f, 9f, 9f });

                            cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                            cell.Colspan = 2;
                            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.PaddingRight = 6f;

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
                            _pdfPCell.Colspan = 2;
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
                            _pdfPCell.Colspan = 3;
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                            _pdfPCell.Border = 2;
                            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 4;
                            _pdfPTable.AddCell(_pdfPCell);
                            _pdfPTable.CompleteRow();

                            _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                            _pdfPCell.Colspan = 1;
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            _pdfPCell.Border = 0;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 4;
                            _pdfPCell.PaddingRight = 10f;
                            _pdfPCell.PaddingTop = 15f;
                            _pdfPTable.AddCell(_pdfPCell);

                            _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                            Date = Convert.ToString(lblDate.Text);
                            _pdfPCell = new PdfPCell(new Phrase("Pay Slip - " + Date.ToString(), _fontStyle));
                            _pdfPCell.Colspan = 2;
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.Border = 0;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 4;
                            _pdfPCell.PaddingRight = 10f;
                            _pdfPCell.PaddingTop = 15f;
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
                            _pdfPCell.PaddingTop = 15f;
                            _pdfPTable.AddCell(_pdfPCell);
                            _pdfPTable.CompleteRow();

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

                            //-----------------------Staff Detail---------------------------------------------//

                            #region "Table Header"
                            String Name = Convert.ToString(lblName.Text);
                            String Department = Convert.ToString(lblDepartment.Text);
                            String Designation = Convert.ToString(lblDesignation.Text);
                            String Package = Convert.ToString(lblPackage.Text);
                            String EMPNumber = Convert.ToString(lblEMPNumber.Text);
                            String AdharCardNumber = Convert.ToString(lblAdharCardNumber.Text);
                            String BankName = Convert.ToString(lblBankName.Text);
                            String BankAccNumber = Convert.ToString(lblBankAccNumber.Text);
                            String PFNumber = Convert.ToString(lblPFNumber.Text);
                            String UAN = Convert.ToString(lblUAN.Text);
                            String DOJ = Convert.ToString(lblDOJ.Text);
                            String DOB = Convert.ToString(lblDOB.Text);

                            //-------------------DOC Dynamic--------------------------------------------//
                            int staffID1 = Convert.ToInt32(lblStaffID.Text);
                            DataTable vrdoclist = GetEmployeeDocument(staffID1);
                            _fontStyle1 = FontFactory.GetFont("Tahoma", 9f, Font.NORMAL);

                            PdfPTable Doctable = new PdfPTable(2);
                            Doctable.WidthPercentage = 100;
                            Doctable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                            PdfPTable Doc1table = new PdfPTable(2);
                            Doc1table.WidthPercentage = 100;
                            Doc1table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                           
                            Doc1table.AddCell(new Phrase("EMPID", _fontStyle));
                            Doc1table.AddCell(new Phrase(EMPNumber.ToString(), _fontStyle));
                            Doc1table.AddCell(new Phrase("Name", _fontStyle));
                            Doc1table.AddCell(new Phrase(Name.ToString(), _fontStyle));
                            Doc1table.AddCell(new Phrase("Department", _fontStyle));
                            Doc1table.AddCell(new Phrase(Department.ToString(), _fontStyle));
                            Doc1table.AddCell(new Phrase("Designation", _fontStyle));
                            Doc1table.AddCell(new Phrase(Designation.ToString(), _fontStyle));
                            Doc1table.AddCell(new Phrase("Package", _fontStyle));
                            Doc1table.AddCell(new Phrase(Package.ToString(), _fontStyle));
                            Doc1table.AddCell(new Phrase("DOB", _fontStyle));
                            Doc1table.AddCell(new Phrase(DOB.ToString(), _fontStyle));
                            Doc1table.AddCell(new Phrase("DOJ", _fontStyle));
                            Doc1table.AddCell(new Phrase(DOJ.ToString(), _fontStyle));

                            Doctable.AddCell(Doc1table);

                            PdfPTable Doc2table = new PdfPTable(2);
                            Doc2table.WidthPercentage = 100;
                            Doc2table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                           
                            foreach (DataRow row in vrdoclist.Rows)
                            {
                                Doc2table.AddCell(new Phrase(row["Field_Name"].ToString(), _fontStyle));
                                Doc2table.AddCell(new Phrase(row["DocumentNumbar"].ToString(), _fontStyle));

                            }
                            #endregion

                            //----------------------------------Componets and deduction----------------------------------//
                            _fontStyle1 = FontFactory.GetFont("Tahoma", 9f, Font.NORMAL);

                            PdfContentByte content = writer.DirectContent;
                            PdfPTable mtable = new PdfPTable(2);
                            mtable.WidthPercentage = 100;
                            mtable.DefaultCell.Border = iTextSharp.text.Rectangle.BOX;

                            PdfPTable Atable = new PdfPTable(2);
                            Atable.WidthPercentage = 100;
                            PdfPCell Acell = new PdfPCell(new Phrase("Addition"));
                            Acell.Colspan = 2;
                            Acell.HorizontalAlignment = 1;
                            Atable.AddCell(Acell);
                            DataTable _Vhrlist = new DataTable();
                            _Vhrlist = ViewAddition();

                            Atable.AddCell("Earnings");
                            Atable.AddCell("Amount");

                            foreach (DataRow row in _Vhrlist.Rows)
                            {
                                Atable.AddCell(new Phrase(row["Category"].ToString(), _fontStyle1));
                                Atable.AddCell(new Phrase(row["MonthlyAmount"].ToString(), _fontStyle1));
                            }

                            mtable.AddCell(Atable);

                            PdfPTable Atable1 = new PdfPTable(2);
                            Atable1.WidthPercentage = 100;
                            PdfPCell Acell1 = new PdfPCell(new Phrase("Deduction"));
                            Acell1.Colspan = 2;
                            Acell1.HorizontalAlignment = 1;
                            Atable1.AddCell(Acell1);
                            DataTable _Vhrlist1 = new DataTable();
                            _Vhrlist1 = ViewDeduction();
                            Atable1.AddCell("Deduction");
                            Atable1.AddCell("Amount");
                            foreach (DataRow row in _Vhrlist1.Rows)
                            {
                                Atable1.AddCell(new Phrase(row["Dcategory"].ToString(), _fontStyle1));
                                Atable1.AddCell(new Phrase(row["DannualAmount"].ToString(), _fontStyle1));

                            }

                            //-------------------------------------------------------------------------//
                            PdfPTable Dtable = new PdfPTable(4);
                            Dtable.WidthPercentage = 100;
                            PdfPCell Dcell = new PdfPCell(new Phrase("Total-A", _fontStyle));
                            Dcell.Colspan = 1;
                            Dcell.HorizontalAlignment = 1;
                            Dtable.AddCell(Dcell);

                            PdfPCell Dcell2 = new PdfPCell(new Phrase(AdditionTotal.ToString(), _fontStyle));
                            Dcell.Colspan = 1;
                            Dcell.HorizontalAlignment = 1;
                            Dtable.AddCell(Dcell2);

                            PdfPCell Dcell3 = new PdfPCell(new Phrase("Total-B", _fontStyle));
                            Dcell.Colspan = 1;
                            Dcell.HorizontalAlignment = 1;
                            Dtable.AddCell(Dcell3);

                            PdfPCell Dcell4 = new PdfPCell(new Phrase(DeductionTotal.ToString(), _fontStyle));
                            Dcell.Colspan = 1;
                            Dcell.HorizontalAlignment = 1;
                            Dtable.AddCell(Dcell4);

                            //----------------------------Net Salary------------------------------------//

                            PdfPTable Ntable = new PdfPTable(4);
                            Ntable.WidthPercentage = 100;

                            PdfPCell N1cell = new PdfPCell(new Phrase("Net Salary: " + NetSalary.ToString(), _fontStyle));
                            N1cell.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                            N1cell.Colspan = 1;
                            N1cell.HorizontalAlignment = 1;
                            Ntable.AddCell(N1cell);

                            PdfPCell N2cell = new PdfPCell(new Phrase("", _fontStyle));
                            N2cell.Border = iTextSharp.text.Rectangle.ALIGN_LEFT;
                            N2cell.Colspan = 1;
                            N2cell.HorizontalAlignment = 1;
                            Ntable.AddCell(N2cell);

                            PdfPCell N3cell = new PdfPCell(new Phrase("", _fontStyle));
                            N3cell.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                            N3cell.Colspan = 2;
                            N3cell.HorizontalAlignment = 1;
                            Ntable.AddCell(N3cell);

                            //------------ Total in Words-------------------------------//
                            PdfPTable InvoiceCostInword = new PdfPTable(1);
                            InvoiceCostInword.WidthPercentage = 100;
                            PdfPCell salaryword = new PdfPCell();
                            salaryword.Border = iTextSharp.text.Rectangle.RECTANGLE;
                            double NetSalaryWord = Convert.ToDouble(lblNetSalary.Text);
                            string number = ConvertAmount(NetSalaryWord);
                            Chunk Inword = new Chunk("In words: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                            Chunk Inwordvalue = new Chunk(number, new Font(Font.FontFamily.HELVETICA, 10f));
                            Phrase phraseInword = new Phrase
                            {
                             Inword,
                             Inwordvalue
                            };
                            Paragraph paraInword = new Paragraph(phraseInword);
                            paraInword.Alignment = Element.ALIGN_LEFT;
                            salaryword.AddElement(paraInword);

                            InvoiceCostInword.AddCell(salaryword);

                            //-------------------- PDF Generation------------------------------------//

                            _pdfPTable.HeaderRows = 1; //header method
                            _document.Add(_pdfPTable);

                            // Add an empty paragraph for spacing

                            Doctable.AddCell(Doc2table);
                            _document.Add(Doctable);
                            _document.Add(new Paragraph("\n"));
                            mtable.AddCell(Atable1);

                            _document.Add(mtable);
                            _document.Add(Dtable);
                            _document.Add(Ntable);
                            _document.Add(InvoiceCostInword);

                            _pdfPTable2.HeaderRows = 1;
                            _document.Add(_pdfPTable2);
                            _document.Add(new Paragraph("Note:This is Computer Generated Payslip Signature not required.", _fontStyle1));
                            _document.Close();
                            byte[] bytes = memoryStream.ToArray();
                            DateTime dTime = DateTime.Now;
                            string PDFFileName = string.Format("EmpolyeeMonthlySalarySlip_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
    }
}