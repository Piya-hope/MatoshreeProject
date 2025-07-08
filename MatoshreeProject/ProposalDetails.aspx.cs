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
using System.Net.Mail;
using System.Net;

#endregion

namespace MatoshreeProject
{
    public partial class ProposalDetails : System.Web.UI.Page
    {

        #region " Class Level Variable "
        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand DeviceCommand;
        SqlDataReader dr;
        int Result;
        string result, Name, NoteID;
        int UserId;
        string UserName , EmailID, Designation , RoleType, Permission, DeptID, CareerID, sendMail, EmpNAME, Initial, ReceiptFor, Size, year, Day;
        string chkReminder, Leaveid;
        string DevEmail, DevPassword, DevHost, DevPort;
        string UserEmpName, Password, EmailID1, Designation1;
        int UseID;

        List<string> FieldsList = new List<string>();


        int Count = 0;

        string ProposalID;

        // Phrase phrase = null;


        #endregion

        #region " Constructor "


        #endregion

        #region " Private Variables "


        #endregion

        #region " Shared Variables "


        #endregion

        #region " Public Variables "

        #endregion

        #region " Private Functions "




        #endregion

        #region " Protected Functions "


        #endregion

        #region " Public Functions "

        public void Clear()
        {

            txtcomment.Text = string.Empty;
            txtdinote.Text = string.Empty;

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
                    lblphoneNo1.Text = dt.Rows[0]["Phone"].ToString() + ".";
                    lblVatNo1.Text = dt.Rows[0]["VAT_Number"].ToString() + ",";
                    lblGSTNo1A.Text = dt.Rows[0]["GST_NO"].ToString() + ",";
                    //Image1.ImageUrl = dt.Rows[0]["Company_Logo"].ToString();
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

        public DataTable GridViewProposal()
        {
            DataTable ds = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_ViewProposal", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        GridPropsal.DataSource = ds;
                        GridPropsal.DataBind();
                        ViewState["Proposal"] = ds;
                    }
                    else
                    {
                        ds.Rows.Add(ds.NewRow());
                        GridPropsal.DataSource = ds;
                        GridPropsal.DataBind();
                    }

                }

            }
            return ds;
        }

        public DataTable ViewReminderDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                SqlCommand com = new SqlCommand("SP_ViewProposalRemainderDetails", con1);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", lblpraposalID.Text);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridProposalReminder.DataSource = dt;
                GridProposalReminder.DataBind();
                ViewState["ProposalReminder"] = dt;
            }

            return table;



        }

        /// <summary>
        /// /////For Employee//////
        public DataTable ViewReminderDetailFoeEmp()
        {
            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {


                SqlCommand com = new SqlCommand("SP_ViewReminderDetailsEmpID", con1);
                com.CommandType = CommandType.StoredProcedure;

                //com.Parameters.AddWithValue("@ID", lblpraposalID.Text);
                com.Parameters.AddWithValue("@UseID", UserId);
                com.Parameters.AddWithValue("@PraposalID", lblpraposalID.Text);

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridProposalReminder.DataSource = dt;
                GridProposalReminder.DataBind();
                ViewState["ProposalReminder"] = dt;
            }

            return table;



        }

        /// </summary>
        /// <param name="PraposalID"></param>
        /// <returns></returns>
        public DataTable GetTaskbyPraposalID(string PraposalID)
        {
            PraposalID = lblpraposalID.Text;
            DataTable table = new DataTable();
            try
            {
                DataColumn dataColumn = new DataColumn();
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand sqlCommand = new SqlCommand("SP_ViewTaskStaffByPraposalsID", con);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@PraposalID", lblpraposalID.Text);
                    //sqlCommand.Parameters.AddWithValue("@EmpID", UserID);
                    SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                    ad.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        GridTask1.DataSource = table;
                        GridTask1.DataBind();
                        ViewState["TaskLead"] = table;
                    }
                    else
                    {
                        GridTask1.DataSource = table;
                        GridTask1.DataBind();
                        ViewState["TaskLead"] = table;
                    }
                }
                return table;
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
                return table;
            }
            finally
            {

            }
        }

        public void bindStaff()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetStaffName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);


                    ddlreminderMember12.DataSource = ds.Tables[0];
                    ddlreminderMember12.DataTextField = "First_Name";
                    ddlreminderMember12.DataValueField = "Staff_ID";
                    ddlreminderMember12.DataBind();
                    ////ddlreminderMember12.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select AssignTo", "0"));
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

        public void bindTally()
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_GetProposalBindTally", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    com.Parameters.AddWithValue("@ProposalNumber", lblProposalNumber.Text);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblSubTotalCost.Text = dt.Rows[0]["SubTotal"].ToString();
                        lblDiscountCost.Text = dt.Rows[0]["Discount"].ToString();
                        lblAdjustmentCost.Text = dt.Rows[0]["Adjustment"].ToString();
                        lbltotalAmonutProposalCost.Text = dt.Rows[0]["GrandTotal"].ToString();

                        lblSubTotalWord.Visible = true;
                        lblSubTotalCost.Visible = true;
                        lblDiscountWord.Visible = true;
                        lblDiscountCost.Visible = true;
                        lblAdjustmentWorrd.Visible = true;
                        lblAdjustmentCost.Visible = true;
                        lblGrandTotalWord.Visible = true;
                        lbltotalAmonutProposalCost.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                SqlConnection DeviceCon = new SqlConnection();
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
                cmdex.Parameters.AddWithValue("@createby", UserName); //Session UserLogIn
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

        public void Calculatefilldata()
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand com = new SqlCommand("SP_GetProposalDetailsByCalValue", con1);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@ProposalNumber", lblProposalNumber.Text);

                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        GridProposalDetail.DataSource = dt;
                        GridProposalDetail.DataBind();
                        //Get the row that contains this button

                        foreach (GridViewRow gridviedrow in GridProposalDetail.Rows)
                        {

                            Label lblHSN1 = (Label)gridviedrow.FindControl("lblHSN1");
                            Label lblItem1 = (Label)gridviedrow.FindControl("lblItem1");
                            Label lblDescription1 = (Label)gridviedrow.FindControl("lblDescription1");
                            Label lblQuantity1 = (Label)gridviedrow.FindControl("lblQuantity1");
                            Label lblRate1 = (Label)gridviedrow.FindControl("lblRate1");
                            Label lblSubAmont1 = (Label)gridviedrow.FindControl("lblSubAmont1");
                            Label lblTax1 = (Label)gridviedrow.FindControl("lblTax1");
                            Label lblTax1Rate1 = (Label)gridviedrow.FindControl("lblTax1Rate1");
                            Label lblTax1A = (Label)gridviedrow.FindControl("lblTax1A");
                            Label lblTax2Rate1 = (Label)gridviedrow.FindControl("lblTax2Rate1");
                            Label lblAmount1 = (Label)gridviedrow.FindControl("lblAmount1");


                            lblDescription1.Visible = true;
                            lblSubAmont1.Visible = true;
                            lblTax1Rate1.Visible = true;
                            lblTax2Rate1.Visible = true;
                            lblQuantity1.Visible = true;
                            lblHSN1.Visible = true;
                            lblRate1.Visible = true;
                            lblItem1.Visible = true;
                            lblTax1.Visible = true;
                            lblTax1A.Visible = true;
                            lblAmount1.Visible = true;
                        }
                    }
                    else
                    {
                        dt.Rows.Add(dt.NewRow());
                        GridProposalDetail.DataSource = dt;
                        GridProposalDetail.DataBind();
                        int totalcolums = GridProposalDetail.Rows[0].Cells.Count;

                    }
                    bindTally();
                    //DiscountCount();

                }
            }
            catch (Exception ex)
            {
                SqlConnection DeviceCon = new SqlConnection();
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
                cmdex.Parameters.AddWithValue("@createby", UserName); //Session UserLogIn
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

        public void GetProposalByID()
        {
            try
            {  
                HttpUtility.UrlDecode(Request.QueryString["XCEEMPIDdfd"]);

                lblpraposalID.Text = ProposalID;
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetProposalDetails", UserCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ID", lblpraposalID.Text);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblpraposalID.Text = dt.Rows[0]["ID"].ToString();
                        lblProposalNumber.Text = dt.Rows[0]["ProposalNo"].ToString();
                        lblName1.Text = dt.Rows[0]["Name"].ToString();
                        lblToAddress1.Text = dt.Rows[0]["Address"].ToString();
                        lblCity1.Text = dt.Rows[0]["AddCity"].ToString();
                        lblDistrict1.Text = dt.Rows[0]["District"].ToString();
                        lblTostate1.Text = dt.Rows[0]["AddState"].ToString();
                        lblZipCode.Text = dt.Rows[0]["ZipCode"].ToString();
                        lblPhone1.Text = dt.Rows[0]["Phone"].ToString();
                        lblEmail1.Text = dt.Rows[0]["Email"].ToString();
                        // lblDesignation.Text = dt.Rows[0]["Designation"].ToString();
                        txtdinote.Text = dt.Rows[0]["Note"].ToString();
                        lblWordTo.Visible = true;
                    }
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
                cmdex.Parameters.AddWithValue("@CreatedBy", "Admin"); //Session UserLogIn
                DeviceCon.Open();
                int RowEx = cmdex.ExecuteNonQuery();
                if (RowEx < 0)
                {
                    //Response.Write("<script> alert('Error Log Inserted !!') </script>");
                }
                else
                {
                    //Response.Write("<script> alert('Error Log Inserted !!') </script>");
                }
            }
            finally
            {
            }
        }

        protected void bindProposalReminder()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetStaffName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlreminderMember1.DataSource = ds.Tables[0];
                    ddlreminderMember1.DataTextField = "First_Name";
                    ddlreminderMember1.DataValueField = "Staff_ID";
                    ddlreminderMember1.DataBind();
                    ddlreminderMember1.Items.Insert(0, new ListItem("Select Proposal Reminder", "0"));

                    ddlreminderMember12.DataSource = ds.Tables[0];
                    ddlreminderMember12.DataTextField = "First_Name";
                    ddlreminderMember12.DataValueField = "Staff_ID";
                    ddlreminderMember12.DataBind();
                    ddlreminderMember12.Items.Insert(0, new ListItem("Select Proposal Reminder", "0"));
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
                                                                       // DeviceCon.Open();
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

        public void GETStaffEmail(string EmpNAME)
        {
            //----Domail ID Password----//
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmailbyStaffName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffName", EmpNAME);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    lblStaffEmail.Text = Convert.ToString(dt.Rows[0]["Email"].ToString());
                    lblStaffDesignation.Text = Convert.ToString(dt.Rows[0]["Role"].ToString());

                }
                con.Close();

            }

        }

        public void GETCredentials()
        {
            //----Domail ID Password----//
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmailCreadential", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DevEmail = Convert.ToString(dt.Rows[0]["UserEmail_ID"].ToString());
                    DevPassword = Convert.ToString(dt.Rows[0]["Password"].ToString());
                    DevHost = Convert.ToString(dt.Rows[0]["Host"].ToString());
                    DevPort = Convert.ToString(dt.Rows[0]["PortNumber"].ToString());
                }
                con.Close();
            }
        }

        public void SendEmail(string EMPNamE, string dateNotified, string description)//DevEmail
        {
            try
            {
                //-----------------Accepting Email------------------------//
                GETCredentials();//method for domain password
                GETStaffEmail(EMPNamE);
                EmailID = Session["EmailID"].ToString();
                EmailID1 = lblStaffEmail.Text;
                //EmailID1 = lblEmailOP.Text;
                Designation1 = lblStaffDesignation.Text;
                lblEmpName11.Text = EMPNamE;
                UserEmpName = lblEmpName11.Text;
                //Send Email User Password....//
                if (!string.IsNullOrEmpty(EmailID1))
                {
                    using (MailMessage mm = new MailMessage(DevEmail, EmailID1))
                    {
                        DateTime dateNotifiedDate;
                        string formattedDateNotified = DateTime.TryParse(dateNotified, out dateNotifiedDate)
                            ? dateNotifiedDate.ToString("MMMM dd, yyyy hh:mm tt")
                            : dateNotified;

                        mm.Subject = "Reminder" + "    " + description + "  " + "on" + "   " + formattedDateNotified;
                        mm.CC.Add(new MailAddress(EmailID1));
                        // mm.Bcc.Add(new MailAddress(EmailID));

                        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                        string body = "Subject: Reminder" + "    " + description + "  " + "on" + "   " + formattedDateNotified + " <br/> ";
                        body += "Dear " + EMPNamE + ",<br/>";
                        body += "I hope  you're doing well. This is a friendly reminder about " + description + "   " + "scheduled for" + " " + formattedDateNotified + " <br/> ";
                        body += "Please make sure to prepare accordingly or reach out if you have any questions. Looking forward to your confirmation." + " <br/> ";
                        body += "Best regards," + "<br/>";
                        body += UserEmpName + "<br />";
                        body += Designation1;

                       string urllocal= HttpUtility.HtmlEncode("https://crm.matoshreeinteriors.com/LogIn");
                        ///string url = HttpUtility.HtmlEncode("https://newdesigncrm.lissomtech.in/LogIn");
                        body += "<html><body><br/><br/><a href=\"" + urllocal + "\">Click here to login </a></body></html>";
                        body += "<br /><br />Thanks";
                        mm.Body = body;
                        mm.IsBodyHtml = true;
                        mm.Priority = MailPriority.Normal;
                        SmtpClient smtp = new SmtpClient();
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Host = DevHost;
                        //"mail.shinedatameterms.in"
                        //smtp.EnableSsl = false;
                        //smtp.Host = "relay-hosting.secureserver.net";
                        //smtp.UseDefaultCredentials = true;
                        NetworkCredential NetworkCred = new NetworkCredential(DevEmail, DevPassword);
                        smtp.Credentials = NetworkCred;
                        smtp.Port = Convert.ToInt32(DevPort);

                        try
                        {
                            smtp.Send(mm);
                            //ViewBag.Message = "Email Send Successfully";
                        }
                        catch (Exception ex)
                        {
                            //Response.Write("<script>alert('Email Not Send '); </script>");
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

        public DataTable ViewFileProposalDetails()
        {

            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                SqlCommand com = new SqlCommand("SP_ViewFileProposalDetails", con1);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@ProposalID", lblpraposalID.Text);

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    GridProposalFile.DataSource = dt;
                    GridProposalFile.DataBind();
                    GridProposalFile.Visible = true;
                    ViewState["ProposalFile"] = dt;
                    foreach (GridViewRow gridviedrow in GridProposalFile.Rows)
                    {

                        LinkButton btnDownload = (LinkButton)gridviedrow.FindControl("btnDownload");

                        btnDownload.Visible = true;
                        LinkButton btnDeleteProposalFile = (LinkButton)gridviedrow.FindControl("btnDeleteProposalFile");

                        btnDeleteProposalFile.Visible = true;

                    }
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridProposalFile.DataSource = dt;
                    GridProposalFile.DataBind();
                    int totalcolums = GridProposalFile.Rows[0].Cells.Count;
                    GridProposalFile.Visible = false;
                }
            }

            return table;



        }

        public DataTable ViewFileProposalDetails(int UserId)
        {
            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {
                SqlCommand com = new SqlCommand("SP_ViewFileProposalDetailsEmpID", con1);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ProposalID", lblProposalID.Text);
                com.Parameters.AddWithValue("@EmpID", UserId);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridProposalFile.DataSource = dt;
                    GridProposalFile.DataBind();
                    GridProposalFile.Visible = true;
                    ViewState["ProposalFile"] = dt;
                    foreach (GridViewRow gridviedrow in GridProposalFile.Rows)
                    {

                        LinkButton btnDownload = (LinkButton)gridviedrow.FindControl("btnDownload");
                        btnDownload.Visible = true;
                        LinkButton DeleteLeadFile = (LinkButton)gridviedrow.FindControl("btnDeleteProposalFile");
                        DeleteLeadFile.Visible = true;

                    }
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GridProposalFile.DataSource = dt;
                    GridProposalFile.DataBind();
                    int totalcolums = GridProposalFile.Rows[0].Cells.Count;
                    GridProposalFile.Visible = false;
                }
            }

            return table;



        }

        public DataTable ViewActivityProposalDetails()
        {

            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {


                SqlCommand com = new SqlCommand("SP_ActivityDetailsByProposal", con1);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@ProposalID", lblProposalID.Text);

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewAct2.DataSource = dt;
                GridViewAct2.DataBind();
                ViewState["ProposalActivitylog"] = dt;
            }

            return table;



        }

        public DataTable ViewActivityProposalDetails(int UseID)
        {

            DataTable table = new DataTable();
            using (SqlConnection con1 = new SqlConnection(strconnect))
            {


                SqlCommand com = new SqlCommand("SP_ActivityDetailsByProposalEmpID", con1);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@ProposalID", lblProposalID.Text);
                com.Parameters.AddWithValue("@EmpID", UseID);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewAct2.DataSource = dt;
                GridViewAct2.DataBind();
                ViewState["ProposalActivitylog"] = dt;

            }

            return table;



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
                    command.Parameters.AddWithValue("@SubModule", "Proposal");
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

                            bindStaff();
                            GetCompanyAddress();
                            GridViewProposal();
                            GetTaskbyPraposalID(lblProposalID.Text);
                            GetProposalByID();
                            ViewFileProposalDetails();
                            //ViewReminderDetails();

                            if (Create == "True")
                            {
                                btnNewProposal.Visible = true;
                                LnkBtnTask.Visible = true;
                                lnkbtnCreateRemainder.Visible = true;
                            }
                            else
                            {
                                btnNewProposal.Visible = false;
                                LnkBtnTask.Visible = false;
                                lnkbtnCreateRemainder.Visible = false;
                            }

                            if (Edit == "True")
                            {
                                GridPropsal.Columns[8].Visible = true;
                                GridTask1.Columns[11].Visible = true;
                                GridProposalReminder.Columns[7].Visible = true;
                            }
                            else
                            {
                                GridPropsal.Columns[8].Visible = false;
                                GridTask1.Columns[11].Visible = false;
                                GridProposalReminder.Columns[7].Visible = false;
                            }

                            if (Delete == "True")
                            {
                                GridPropsal.Columns[9].Visible = true;
                                GridTask1.Columns[12].Visible = true;
                                GridProposalFile.Columns[4].Visible = true;
                                GridProposalReminder.Columns[7].Visible = true;
                            }
                            else
                            {
                                GridPropsal.Columns[9].Visible = false;
                                GridTask1.Columns[12].Visible = false;
                                GridProposalFile.Columns[4].Visible = false;
                                GridProposalReminder.Columns[7].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {


                            bindStaff();

                            GetProposalByID();
                            GetCompanyAddress();
                            GridViewProposal();
                            GetTaskbyPraposalID(lblProposalID.Text);
                            string Todaydate = Convert.ToString(DateTime.Today);
                            txtdinote.Attributes["value"] = DateTime.Parse(Todaydate.ToString()).ToString("yyyy-MM-dd");
                            ViewFileProposalDetails(UserId);
                            ViewActivityProposalDetails(UserId);

                            if (Create == "True")
                            {
                                btnNewProposal.Visible = true;
                                LnkBtnTask.Visible = true;
                                lnkbtnCreateRemainder.Visible = true;
                            }
                            else
                            {
                                btnNewProposal.Visible = false;
                                LnkBtnTask.Visible = false;
                                lnkbtnCreateRemainder.Visible = false;
                            }

                            if (Edit == "True")
                            {
                                GridPropsal.Columns[8].Visible = true;
                                GridTask1.Columns[11].Visible = true;
                                GridProposalReminder.Columns[7].Visible = true;
                            }
                            else
                            {
                                GridPropsal.Columns[8].Visible = false;
                                GridTask1.Columns[11].Visible = false;
                                GridProposalReminder.Columns[7].Visible = false;
                            }

                            if (Delete == "True")
                            {
                                GridPropsal.Columns[9].Visible = true;
                                GridTask1.Columns[12].Visible = true;
                                GridProposalFile.Columns[4].Visible = true;
                                GridProposalReminder.Columns[8].Visible = true;
                            }
                            else
                            {
                                GridPropsal.Columns[9].Visible = false;
                                GridTask1.Columns[12].Visible = false;
                                GridProposalFile.Columns[4].Visible = false;
                                GridProposalReminder.Columns[8].Visible = false;
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
                            GetProposalByID();
                            GetTaskbyPraposalID(lblpraposalID.Text);
                            ViewReminderDetails();
                            GetCompanyAddress();
                            GridViewProposal();
                            bindProposalReminder();
                            ViewFileProposalDetails();
                            ViewActivityProposalDetails();
                            ViewReminderDetails();
                            ViewReminderDetailFoeEmp();

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
                                GetProposalByID();
                                GetTaskbyPraposalID(lblpraposalID.Text);
                                GetCompanyAddress();
                                GridViewProposal();
                                bindProposalReminder();
                                ViewFileProposalDetails();
                                ViewActivityProposalDetails();
                                StaffOperationPermission();
                                //ViewProposalReminderDetails();
                                ViewReminderDetails();
                                ViewReminderDetailFoeEmp();
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
                using (DeviceCon = new SqlConnection(strconnect))
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

        protected void GridProposalReminder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridProposalReminder.Rows)
                {

                    System.Web.UI.WebControls.Label lblID1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblID1");
                    System.Web.UI.WebControls.Label lblRowNumber = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblRowNumber");
                    System.Web.UI.WebControls.Label lblnotifyDate1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblnotifyDate1");
                    System.Web.UI.WebControls.Label lblSetToReminder1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblSetToReminder1");
                    System.Web.UI.WebControls.Label lblDescription1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblDescription1");


                    LinkButton lnkbtnresult = (LinkButton)e.Row.FindControl("btnfileAttachment");
                    string status = ((System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblStatuse1")).Text;
                    if (status == "True")
                    {
                        lblRowNumber.ForeColor = System.Drawing.Color.Blue;
                        lblnotifyDate1.ForeColor = System.Drawing.Color.Blue;
                        lblSetToReminder1.ForeColor = System.Drawing.Color.Blue;
                        lblDescription1.ForeColor = System.Drawing.Color.Blue;

                    }
                    else
                    {

                        lblRowNumber.ForeColor = System.Drawing.Color.Red;
                        lblnotifyDate1.ForeColor = System.Drawing.Color.Red;
                        lblSetToReminder1.ForeColor = System.Drawing.Color.Red;
                        lblDescription1.ForeColor = System.Drawing.Color.Red;


                    }

                }
            }
            catch (Exception ex)
            {
                using (DeviceCon = new SqlConnection(strconnect))
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


        //============Proposal link btn=============================================================//
        protected void linkbtnMergeField_Click(object sender, EventArgs e)
        {
            tblcontract.Visible = true;
            textBox.Visible = true;
        }

        protected void lnkbtnCreateRemainder_Click(object sender, EventArgs e)
        {
            if (craeteButton.Visible == false)
            {
                craeteButton.Visible = true;
            }

            else
            {
                craeteButton.Visible = false;
            }
        }

        protected void LinkButtonsubtotal_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonsubtotal.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonsubject_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonsubject.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonnumber_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonnumber.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonitem_Click(object sender, EventArgs e)
        {
            FieldsList.Add(Convert.ToString(LinkButtonitem.Text));

            Count = FieldsList.Count;


            if (Count > 0)
            {
                foreach (var Fields in FieldsList)
                {
                    textBox.Text = Fields + ",";

                }
                ViewState["Data"] = textBox.Text;
            }
        }

        protected void LinkButtonopentill_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonopentill.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonAssigned_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonAssigned.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonTo_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonTo.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonAddress_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonAddress.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtoncity_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncity.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonstate_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonstate.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonzipcode_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonzipcode.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtoncountry_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncountry.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonEmail_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonEmail.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtoncontract_subject_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncontract_subject.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonphone_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonphone.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtontotal_Click(object sender, EventArgs e)
        {
            //string Name = ViewState["Data"].ToString();
            //FieldsList.Add(Convert.ToString(LinkButtonlink.Text));

            //Count = FieldsList.Count;

            //if (Name == null)//first fit
            //{
            //    if (Count > 0)
            //    {
            //        foreach (var Fields in FieldsList)
            //        {
            //            textBox.Text = Fields + ",";

            //        }
            //        ViewState["Data"] = textBox.Text;
            //    }
            //}
            //else//mutiple fit
            //{
            //    if (Count > 0)
            //    {
            //        foreach (var Fields in FieldsList)
            //        {
            //            textBox.Text = Name + Fields + ",";

            //        }
            //        ViewState["Data"] = textBox.Text;
            //    }
            //}
        }

        protected void LinkButtonlink_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonlink.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonAt_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonAt.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonDate_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonDate.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void btnEditProposal_Click(object sender, EventArgs e) //put
        {
            try
            {

                string ID;
                var rows = GridPropsal.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                Response.Redirect("~/EditNewProposal.aspx?XCEEMPIDdfd=" + ID + "", false);
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

        protected void LinkButtonlogo_url_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonlogo_url.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void btnDeletepro_Click(object sender, EventArgs e)
        {
            try
            {

                string ID;
                var rows = GridPropsal.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;
                SqlConnection DeviceCon = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_DeleteProposal", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Createdby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                if (i < 0)
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Proposal Details Delete Successfully";
                    GridViewProposal();
                }
                else
                {
                    Toasteralert.Visible = false;
                    deleteToaster.Visible = true;
                    lblMesDelete.Text = "Proposal Details Not Deleted";
                }
            }
            catch (Exception ex)
            {
                SqlConnection DeviceCon = new SqlConnection(strconnect);
                string ErrorMessgage = ex.Message;

            }
            finally { }
        }

        protected void lblProposalNo1_Click(object sender, EventArgs e)
        {
            try
            {
                string ID;
                var rows = GridPropsal.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;


                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetProposalDetails", UserCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ID", ID);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblpraposalID.Text = dt.Rows[0]["ID"].ToString();
                        lblProposalNumber.Text = dt.Rows[0]["ProposalNo"].ToString();
                        lblName1.Text = dt.Rows[0]["Name"].ToString();
                        lblToAddress1.Text = dt.Rows[0]["Address"].ToString();
                        lblCity1.Text = dt.Rows[0]["AddCity"].ToString();
                        lblDistrict1.Text = dt.Rows[0]["District"].ToString();
                        lblTostate1.Text = dt.Rows[0]["AddState"].ToString();
                        lblZipCode.Text = dt.Rows[0]["ZipCode"].ToString();
                        lblPhone1.Text = dt.Rows[0]["Phone"].ToString();
                        lblEmail1.Text = dt.Rows[0]["Email"].ToString();
                        txtdinote.Text = dt.Rows[0]["Note"].ToString();
                    }

                }
                Calculatefilldata();
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

        protected void LinkButtoncrm_url_Click1(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncrm_url.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonatmin_url_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonatmin_url.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtoncrmurl_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtoncrmurl.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonAdminurl_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonAdminurl.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtondomain_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtondomain.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButton_name_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButton_name.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonconditionurl_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonconditionurl.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void LinkButtonpolicyurl_Click(object sender, EventArgs e)
        {
            string Name = ViewState["Data"].ToString();
            FieldsList.Add(Convert.ToString(LinkButtonpolicyurl.Text));

            Count = FieldsList.Count;

            if (Name == null)//first fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
            else//mutiple fit
            {
                if (Count > 0)
                {
                    foreach (var Fields in FieldsList)
                    {
                        textBox.Text = Name + Fields + ",";

                    }
                    ViewState["Data"] = textBox.Text;
                }
            }
        }

        protected void Linkclear_Click(object sender, EventArgs e)
        {
            ViewState["Data"] = null;
            textBox.Text = "";
        }

        protected void GridPropsal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridPropsal.Rows)
                {

                    Label lblID1 = (Label)gridviedrow.FindControl("lblID1");

                    Label Status1 = (Label)gridviedrow.FindControl("lblStatus1");
                    string Status = ((Label)gridviedrow.FindControl("lblStatus1")).Text;
                    if (Status == "Draft")
                    {
                        Status1.CssClass = "btn btn-sm btn-outline-info";
                    }
                    else if (Status == "Revised")
                    {
                        Status1.CssClass = "btn btn-sm btn-outline-secondary";
                    }
                    else if (Status == "Send")
                    {
                        Status1.CssClass = "btn btn-sm btn-outline-primary";
                    }
                    else if (Status == "Declined")
                    {
                        Status1.CssClass = "btn btn-sm btn-outline-danger";
                    }
                    else if (Status == "Accepted")
                    {
                        Status1.CssClass = "btn btn-sm btn-outline-success";
                    }
                    else
                    {
                        Status1.CssClass = "btn btn-sm btn-outline-dark";
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

        //============Reminder=============================================================//
        protected void lnkbtnRemainder1_Click(object sender, EventArgs e)
        {
            if (craeteButton.Visible == false)
            {
                craeteButton.Visible = true;
            }

            else
            {
                craeteButton.Visible = false;
            }
        }

        protected void btnCreateRemainder12_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {

                    if (chksetRemainderforEmail2.Checked)
                    {
                        chkReminder = "true";

                        string dateNotified = txtDateNotified12.Text;
                        string reminderMember = ddlreminderMember12.SelectedItem.Text;
                        string description = txtDescription12.Text;
                        GETStaffEmail(reminderMember);
                        SendEmail(reminderMember, dateNotified, description);

                    }
                    else
                    {
                        chkReminder = "false";
                    }
                    if (string.IsNullOrEmpty(lblpraposalID.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter praposal ID');", true);
                        return;
                    }
                    else if (string.IsNullOrEmpty(txtDateNotified12.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter a Notification Date');", true);
                        return;
                    }
                    else if (ddlreminderMember12.SelectedIndex == -1 || ddlreminderMember12.SelectedItem.Text == "Select AssignTo")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select an Assignee');", true);
                        return;
                    }
                    else if (string.IsNullOrEmpty(txtDescription12.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter a Description');", true);
                        return;
                    }
                    else if (string.IsNullOrEmpty(Designation))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Designation is required');", true);
                        return;
                    }

                    else if (string.IsNullOrEmpty(lblProposalNumber.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter Proposal Number');", true);
                        return;
                    }

                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_SaveProposalRemainder", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DateTime dateNotifiedDate = Convert.ToDateTime(txtDateNotified12.Text);
                    cmd.Parameters.AddWithValue("@RelatedToID", lblpraposalID.Text);
                    cmd.Parameters.AddWithValue("@NotifyDate", dateNotifiedDate);
                    cmd.Parameters.AddWithValue("@SetToReminder", ddlreminderMember12.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription12.Text);
                    cmd.Parameters.AddWithValue("@SendMail", chkReminder);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@Belong", "Proposal");
                    cmd.Parameters.AddWithValue("@RelatedTo", lblProposalNumber.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i < 0)
                    {
                        bindStaff();

                        ViewReminderDetails();

                        Toasteralert.Visible = true;
                        lblMessage.Visible = true;
                        lblMessage.Text = "Praposal Reminders Details Save Successfully";
                        Clear();

                    }
                    else
                    {
                        Toasteralert.Visible = true;
                        lblMessage.Visible = true;
                        lblMessage.Text = "Praposal Reminders Not Save Successfully";

                    }




                }


            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;

            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    string chkReminder1;
                    if (chksetRemainderforEmail1.Checked)
                    {
                        chkReminder1 = "true";
                    }
                    else
                    {
                        chkReminder1 = "false";
                    }
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_UpdateProposalRemainder", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@R_ID", lblRID1.Text);
                    cmd.Parameters.AddWithValue("@RelatedToID", lblpraposalID.Text);
                    cmd.Parameters.AddWithValue("@NotifyDate", Convert.ToDateTime(txtDateNotified1.Text));
                    cmd.Parameters.AddWithValue("@SetToReminder", ddlreminderMember1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription1.Text);
                    cmd.Parameters.AddWithValue("@SendMail", chkReminder1);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@Belong", "Proposal");
                    cmd.Parameters.AddWithValue("@RelatedTo", lblProposalNumber.Text);
                    con.Open();
                    int Result = cmd.ExecuteNonQuery();
                    if (Result < 0)
                    {

                        ViewReminderDetails();
                        Clear();

                        Toasteralert.Visible = true;
                        lblMessage.Visible = true;
                        lblMessage.Text = "Proposal Reminders Details Update Successfully";

                    }
                    else
                    {

                        Toasteralert.Visible = true;
                        lblMessage.Visible = true;
                        lblMessage.Text = "Proposal Reminder Not Update Successfully";
                    }
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
                // cmdex.Parameters.AddWithValue("@CreatedBy", Userm); //Session UserLogIn
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

        protected void btnEditReminder_Click(object sender, EventArgs e)
        {
            try
            {
                string SendMail;
                DeviceCon = new SqlConnection(strconnect);
                string remainderID;
                var rows = GridProposalReminder.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                remainderID = ((Label)rows[rowindex].FindControl("lblID1")).Text;
                lblRID1.Text = remainderID;  //
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    UserCommand = new SqlCommand("SP_GetRemainderByID", UserCon);
                    UserCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(UserCommand);
                    UserCommand.Parameters.AddWithValue("@R_ID", lblRID1.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        DateTime contactDate = DateTime.Parse(dt.Rows[0]["NotifyDate"].ToString());
                        txtDateNotified1.Text = contactDate.ToString("yyyy-MM-ddTHH:mm");
                        ddlreminderMember1.SelectedItem.Text = dt.Rows[0]["SetToReminder"].ToString();
                        txtDescription1.Text = dt.Rows[0]["Description"].ToString();
                        SendMail = dt.Rows[0]["SendMail"].ToString();
                        if (SendMail == "True")
                        {
                            chksetRemainderforEmail1.Checked = true;
                            string dateNotified = txtDateNotified1.Text;
                            string reminderMember = ddlreminderMember1.SelectedItem.Text;
                            string description = txtDescription1.Text;
                            GETStaffEmail(reminderMember);
                            SendEmail(reminderMember, dateNotified, description);
                        }
                        else
                        {
                            chksetRemainderforEmail1.Checked = false;


                        }
                    }

                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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
                    cmdex.Parameters.AddWithValue("@CreatedBy", UserName);
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtDateNotified12.Text = string.Empty;
            txtDescription1.Text = string.Empty;
            ddlreminderMember12.SelectedIndex = 0;
            txtDescription12.Text = string.Empty;
            chksetRemainderforEmail2.Checked = false;
        }

        protected void btnvisiblity_Click(object sender, EventArgs e)
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
                        SqlCommand cmd = new SqlCommand("SP_ReminderVisiblityDetails", con);
                        cmd.CommandTimeout = 600;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(table);
                        GridProposalReminder.DataSource = table;
                        GridProposalReminder.DataBind();
                        ViewState["ProposalReminder"] = table;
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

        protected void btnreload_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    GridViewProposal();
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


        protected void btnDeleteReminder_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);

                if (Session["LoginType"].ToString() == "Administrator")
                {
                    string ID;
                    var rows = GridProposalReminder.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                    SqlConnection DeviceCon = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteRemainderProposal", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@R_ID", ID);
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
                        lblMesDelete.Text = "Proposal Reminder Details Deleted Successfully";
                        GridProposalReminder.EditIndex = -1;
                        ViewReminderDetails();


                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Proposal Reminder Details Not Deleted";
                    }

                }

                else if (RoleType == Designation)
                {
                    string ID;
                    var rows = GridProposalReminder.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                    SqlConnection DeviceCon = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteRemainderProposalEmpID", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@R_ID", ID);
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
                        lblMesDelete.Text = "Proposal Reminder Details Deleted Successfully";
                        GridProposalReminder.EditIndex = -1;
                        StaffOperationPermission();
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Proposal Reminder Details Not Deleted";
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


        protected void linkexcel_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    DataTable dt = ViewReminderDetails();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ProposalReminder_Details " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));

                        Response.Charset = " ";

                        // Create a new DataTable with only the desired columns
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("Description");
                        dtExport.Columns.Add("NotifyDate");
                        dtExport.Columns.Add("Remainder");

                        int serialnumber = 1;
                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            //newRow["ID"] = row["R_ID"];
                            newRow["ID"] = serialnumber++.ToString();
                            newRow["Description"] = row["Description"];
                            newRow["NotifyDate"] = row["NotifyDate"];
                            newRow["Remainder"] = row["SetToReminder"];

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
                    DataTable dt = (DataTable)ViewState["ProposalReminder"];
                    if (dt != null && dt.Rows.Count > 0)
                    {

                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ProposalReminder_Details " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));

                        Response.Charset = " ";

                        // Create a new DataTable with only the desired columns

                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("Description");
                        dtExport.Columns.Add("NotifyDate");
                        dtExport.Columns.Add("Remainder");

                        int serialnumber = 1;
                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = serialnumber++.ToString();
                            newRow["Description"] = row["Description"];
                            newRow["NotifyDate"] = row["NotifyDate"];
                            newRow["Remainder"] = row["SetToReminder"];

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


        }

        protected void linkpdf_Click(object sender, EventArgs e)
        {

        }




        //============Comment=============================================================//Excel
        protected void lnkbtnpdf_Click(object sender, EventArgs e)
        {

        }

        protected void btn_comment_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_SaveProposalComment", con);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Comment", txtcomment.Text);
                    cmd.Parameters.AddWithValue("@Createby", UserName);
                    cmd.Parameters.AddWithValue("@UserID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@ProposalNO", lblProposalNumber.Text);
                    cmd.Parameters.AddWithValue("@ProposalID", lblProposalID.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Comment Save Successfully!";

                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Comment Not Save Successfully!";
                    }
                    //Clear();
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

            }
            finally
            {

            }

            Clear();

        }

        //============NOTE=============================================================//
        protected void btnnote_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_SavePraposalNote", con);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", lblpraposalID.Text);
                    cmd.Parameters.AddWithValue("@Note", txtdinote.Text);
                    cmd.Parameters.AddWithValue("@Createdby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Praposal Note Successfully";
                    }
                    else
                    {

                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Praposal Note Not Successfully";
                    }
                    //Clear();
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

            }
            finally
            {

            }

            Clear();
        }

        //============AttachmentFile=============================================================//

        protected void GridProposalFile_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow gridviedrow in GridProposalFile.Rows)
            {
                System.Web.UI.WebControls.Label lblProposalFileName1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblProposalFileName1");
                LinkButton lnkbtnresult = (LinkButton)e.Row.FindControl("btnDownload");
                LinkButton lnkbtnresult1 = (LinkButton)e.Row.FindControl("btnDeleteProposalFile");
                string status = ((System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblProposalFileStatus1")).Text;
                if (status == "True")
                {
                    lblProposalFileName1.ForeColor = System.Drawing.Color.Blue;

                }
                else
                {
                    lblProposalFileName1.ForeColor = System.Drawing.Color.Red;

                }

            }
        }

        protected void Btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {

                if (FileUpload.PostedFile == null)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Proposal Not In Draft!')", true);
                }
                else
                {
                    if (FileUpload.PostedFile.FileName.Length > 1)
                    {
                        string uploadDirectory = Server.MapPath("~/Proposal_File/");

                        if (!Directory.Exists(uploadDirectory))
                        {
                            Directory.CreateDirectory(uploadDirectory);
                        }
                        string fileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
                        string filePath = System.IO.Path.Combine(uploadDirectory, fileName);
                        string extention = System.IO.Path.GetExtension(FileUpload.PostedFile.FileName);


                        FileUpload.PostedFile.SaveAs(filePath);
                        string contenttype = String.Empty;
                        switch (extention.ToLower())
                        {
                            case ".doc":
                                contenttype = "application/vnd.ms-word";
                                break;
                            case ".docx":
                                contenttype = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;
                            case ".xls":
                                contenttype = "application/vnd.ms-excel";
                                break;
                            case ".xlsx":
                                contenttype = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                break;
                            case ".jpg":
                                contenttype = "image/jpg";
                                break;
                            case ".png":
                                contenttype = "image/png";
                                break;
                            case ".gif":
                                contenttype = "image/gif";
                                break;
                            case ".pdf":
                                contenttype = "application/pdf";
                                break;
                        }

                        if (contenttype != String.Empty)
                        {
                            Stream fs = FileUpload.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            using (SqlConnection con = new SqlConnection(strconnect))
                            {
                                SqlCommand cmd = new SqlCommand("SP_UploadProposalAttachmentFile", con);
                                cmd.Connection = con;

                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@FileName", fileName);
                                cmd.Parameters.AddWithValue("@Extention", extention);
                                cmd.Parameters.AddWithValue("@FilePath", filePath);
                                cmd.Parameters.AddWithValue("@EmpID", UserId);
                                cmd.Parameters.AddWithValue("@Designation", Designation);
                                cmd.Parameters.AddWithValue("@Createby", UserName);
                                cmd.Parameters.AddWithValue("@ProposalID", lblpraposalID.Text);
                                cmd.Parameters.AddWithValue("@PropsalNo", lblProposalNumber.Text);
                                cmd.Parameters.AddWithValue("@ContentType", contenttype);
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                int i = cmd.ExecuteNonQuery();
                                if (i < 0)
                                {
                                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Leave Request File Uploaded Successfully!')", true);
                                    ViewFileProposalDetails();
                                    Toasteralert.Visible = false;
                                    deleteToaster.Visible = true;
                                    lblMesDelete.Text = "Proposal Details File Uploaded Successfully!";

                                }
                                else
                                {
                                    Toasteralert.Visible = false;
                                    deleteToaster.Visible = true;
                                    lblMesDelete.Text = "Proposal Details File Not  Uploaded Successfully!";

                                }
                            }
                        }
                        else
                        {
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Choose File For Uploaded!')", true);
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

        protected void btnDeleteProposalFile_Click(object sender, EventArgs e)
        {

            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);

                if (Session["LoginType"].ToString() == "Administrator")
                {
                    string ID;
                    var rows = GridProposalFile.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    ID = ((Label)rows[rowindex].FindControl("lblfileid")).Text;

                    SqlConnection DeviceCon = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteProposalFile", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", ID);
                    //cmd.Parameters.AddWithValue("@PropsalNo", lblProposalNumber.Text);
                    cmd.Parameters.AddWithValue("@CreateBy", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();

                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Proposal File Details Deleted Successfully";
                        ViewFileProposalDetails();
                        GridProposalFile.EditIndex = -1;

                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Proposal File Details Not Deleted";

                    }

                }

                else if (RoleType == Designation)
                {
                    string ID;
                    var rows = GridProposalFile.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    ID = ((Label)rows[rowindex].FindControl("lblfileid")).Text;

                    SqlConnection DeviceCon = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ViewFileProposalManger", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProposalID", ID);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();

                    if (i < 0)
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Proposal File Details Deleted Successfully";
                        StaffOperationPermission();
                        GridProposalFile.EditIndex = -1;
                    }
                    else
                    {
                        Toasteralert.Visible = false;
                        deleteToaster.Visible = true;
                        lblMesDelete.Text = "Proposal File Details Not Deleted";
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

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {


                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowIndex = row.RowIndex;

                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {


                    Leaveid = ((System.Web.UI.WebControls.Label)GridProposalFile.Rows[rowIndex].FindControl("lblfileid")).Text;
                    lbdLeaveMID.Text = Leaveid;
                    SqlCommand cmd = new SqlCommand("SP_GetProposalFileDetailsByID", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ID", lbdLeaveMID.Text);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);



                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string name = dt.Rows[0]["FileName"].ToString();
                        string FilePath = dt.Rows[0]["FilePath"].ToString();
                        string Extensation = dt.Rows[0]["Extensation"].ToString();
                        string ProposalID = dt.Rows[0]["ProposalID"].ToString();
                        string PropsalNo = dt.Rows[0]["PropsalNo"].ToString();
                        string contentType = dt.Rows[0]["ContentType"].ToString();
                        Byte[] bytes = (Byte[])dt.Rows[0]["Data"];

                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.ContentType = contentType;
                        Response.AddHeader("content-disposition", "attachment;filename=" + name);
                        Response.BinaryWrite(bytes);
                        Response.Flush();
                        Response.End();
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
    }
}