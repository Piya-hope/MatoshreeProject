#region " Class Description "


#endregion

#region " Primary Namespaces "

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#endregion

#region " Additional Namespaces "

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web.UI.HtmlControls;

#endregion

namespace MatoshreeProject
{
    public partial class MyMaster : System.Web.UI.MasterPage
    {
        #region " Class Level Variable "

        string strconnect = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        SqlConnection UserCon = new SqlConnection();
        SqlConnection DeviceCon = new SqlConnection();
        SqlCommand UserCommand;
        SqlDataReader dr;
        string EmpID;

        int UserId;
        string UserName, EmailID, Designation, RoleType, Permission, DeptID;
        #endregion

        #region " Public Variables "
        public void AnnouncementCount()
        {
            try
            {

                //-------------TotalAmt----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetCountCurrentAnnouncement", con);
                    command.CommandType = CommandType.StoredProcedure;
                    int totalamt = (int)command.ExecuteScalar();

                    lblAnnouncementCount.Text = Convert.ToString(totalamt);
                    AnnoucementCount.Text = Convert.ToString(totalamt);
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
        public void ActivityCount()
        {
            try
            {

                //-------------TotalAmt----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetCountCurrentActivity", con);
                    command.CommandType = CommandType.StoredProcedure;
                    int totalamt = (int)command.ExecuteScalar();

                    lblActivityCount.Text = Convert.ToString(totalamt);
                    lblActivitylg.Text = Convert.ToString(totalamt);
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

        public void ActivityCountEmpID(int UserID)
        {
            try
            {

                //-------------TotalAmt----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetCountCurrentActivityEmpID", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int totalamt = (int)command.ExecuteScalar();

                    lblActivityCount.Text = Convert.ToString(totalamt);
                    lblActivitylg.Text = Convert.ToString(totalamt);
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
        public void GetbyCurrentDateAndTime()
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    using (SqlCommand command = new SqlCommand("SP_ViewCurrentAnnouncement", UserCon))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count == 1)
                            {
                                Annoucement.Visible = true;
                                DataRow firstRow = dataTable.Rows[0];

                                DateTime dateAdded = Convert.ToDateTime(firstRow["date_added"]);
                                string name = firstRow["name"].ToString();
                                string message = firstRow["message"].ToString();
                                string Createby = firstRow["Createby"].ToString();
                                lbldateadded1.Text = dateAdded.ToString("yyyy-MM-dd hh:mm:ss tt");
                                datepostAnnoucement.Text = dateAdded.ToString("yyyy-MM-dd hh:mm:ss tt");

                                lblsubject.Text = name;
                                lblmessage.Text = message;
                                //lblcreatedBy1.Text= Createby;

                                GridViewAnnounceView.DataSource = dataTable;
                                GridViewAnnounceView.DataBind();
                                gvAnnouncement.DataSource = dataTable;
                                gvAnnouncement.DataBind();
                            }
                            else if (dataTable.Rows.Count > 1)
                            {
                                lblsubject.Visible = false;
                                lblmessage.Visible = false;

                                Annoucement.Visible = true;
                                Annoucementdiv.Visible = true;
                                DataRow firstRow = dataTable.Rows[0];

                                DateTime dateAdded = Convert.ToDateTime(firstRow["date_added"]);

                                lbldateadded1.Text = dateAdded.ToString("yyyy-MM-dd HH:mm:ss tt");
                                datepostAnnoucement.Text = dateAdded.ToString("yyyy-MM-dd HH:mm:ss tt");
                                string Createby = firstRow["Createby"].ToString();
                                //lblcreatedBy1.Text = Createby;
                                GridViewAnnounceView.DataSource = dataTable;
                                GridViewAnnounceView.DataBind();
                                gvAnnouncement.DataSource = dataTable;
                                gvAnnouncement.DataBind();
                            }
                            else
                            {
                                lbldateadded1.Text = "No announcements found";
                                lblsubject.Text = string.Empty;
                                lblmessage.Text = string.Empty;
                                Annoucement.Visible = false;
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

        public void GetActivityCurrentDateAndTime()
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    using (SqlCommand command = new SqlCommand("SP_ViewCurrentActivity", UserCon))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count == 1)
                            {

                                DataRow firstRow = dataTable.Rows[0];

                                DateTime dateAdded = Convert.ToDateTime(firstRow["ActivityDate"]);
                                string name = firstRow["ActivityType"].ToString();

                                //string Createby = firstRow["UserID"].ToString();
                                lblActiviylogdate2.Text = dateAdded.ToString("yyyy-MM-dd hh:mm:ss tt");
                                lblActiviylogdate1.Text = dateAdded.ToString("yyyy-MM-dd hh:mm:ss tt");

                                GridViewActivity.DataSource = dataTable;
                                GridViewActivity.DataBind();

                                gvActivity.DataSource = dataTable;
                                gvActivity.DataBind();

                            }
                            else if (dataTable.Rows.Count > 1)
                            {

                                DataRow firstRow = dataTable.Rows[0];

                                DateTime dateAdded = Convert.ToDateTime(firstRow["ActivityDate"]);
                                lblActiviylogdate1.Text = dateAdded.ToString("yyyy-MM-dd hh:mm:ss tt");
                                lblActiviylogdate2.Text = dateAdded.ToString("yyyy-MM-dd HH:mm:ss");
                                //string Createby = firstRow["UserID"].ToString();
                                //lblActivityby1.Text = Createby;
                                GridViewActivity.DataSource = dataTable;
                                GridViewActivity.DataBind();

                                gvActivity.DataSource = dataTable;
                                gvActivity.DataBind();
                            }
                            else
                            {
                                lbldateadded1.Text = "No Activity found";

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



        public void GetActivityCurrentDateAndTimeEmpID(int UserID)
        {
            try
            {
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand command = new SqlCommand("SP_ViewCurrentActivityEmpID", UserCon);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 600;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    if (dataTable.Rows.Count == 1)
                    {

                        DataRow firstRow = dataTable.Rows[0];

                        DateTime dateAdded = Convert.ToDateTime(firstRow["ActivityDate"]);
                        string name = firstRow["ActivityType"].ToString();

                        //string Createby = firstRow["UserID"].ToString();
                        lblActiviylogdate2.Text = dateAdded.ToString("yyyy-MM-dd hh:mm:ss tt");
                        lblActiviylogdate1.Text = dateAdded.ToString("yyyy-MM-dd hh:mm:ss tt");

                        GridViewActivity.DataSource = dataTable;
                        GridViewActivity.DataBind();
                        gvActivity.DataSource = dataTable;
                        gvActivity.DataBind();
                    }
                    else if (dataTable.Rows.Count > 1)
                    {

                        DataRow firstRow = dataTable.Rows[0];

                        DateTime dateAdded = Convert.ToDateTime(firstRow["ActivityDate"]);
                        lblActiviylogdate1.Text = dateAdded.ToString("yyyy-MM-dd hh:mm:ss tt");
                        lblActiviylogdate2.Text = dateAdded.ToString("yyyy-MM-dd hh:mm:ss tt");
                        //string Createby = firstRow["UserID"].ToString();
                        //lblActivityby1.Text = Createby;
                        GridViewActivity.DataSource = dataTable;
                        GridViewActivity.DataBind();
                        gvActivity.DataSource = dataTable;
                        gvActivity.DataBind();
                    }
                    else
                    {
                        lbldateadded1.Text = "No Activity found";
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

        #region " Public Functions " 
        //---------------------------------------------------------------------
        // Small Logo Preloader Logo
        //---------------------------------------------------------------------
        public void getImageSmallLogoPreloaderLogo()
        {
            try
            {
                //Small Logo and Preloader Logo 
                using (SqlConnection UserCon1 = new SqlConnection(strconnect))
                {

                    SqlCommand cmd = new SqlCommand("SP_Getaimagelogousingfor", UserCon1);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ImageFor", "SmallIconLogo");
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string imgname = dt.Rows[0]["ImageName"].ToString();
                        string Extension = dt.Rows[0]["Extension"].ToString();
                        string imgpath = dt.Rows[0]["ImageFilePath"].ToString();

                        preloaderImg.Src = imgpath;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                string ErrorMessgage = ex.Message;
                SqlConnection con2 = new SqlConnection(strconnect);
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", con2);
                cmdex.CommandType = CommandType.StoredProcedure;
                cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                cmdex.Parameters.AddWithValue("@Method", method);
                cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                con2.Open();
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


        //---------------------------------------------------------------------
        // Text Logo
        //---------------------------------------------------------------------
        public void getImagesidebarTextLogo()
        {
            try
            {
                //Sidebar Text Logo 
                using (SqlConnection UserCon1 = new SqlConnection(strconnect))
                {

                    SqlCommand cmd = new SqlCommand("SP_Getaimagelogousingfor", UserCon1);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ImageFor", "TextLogo");
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string imgname = dt.Rows[0]["ImageName"].ToString();
                        string Extension = dt.Rows[0]["Extension"].ToString();
                        string imgpath = dt.Rows[0]["ImageFilePath"].ToString();

                        textLogo1.Src = imgpath;
                        textLogo2.Src = imgpath;
                        textImglogo3.Src = imgpath;
                        textImglogo4.Src = imgpath;
                    }
                }
            }
            catch (Exception ex)
            {
                string ErrorMessgage = ex.Message;
                SqlConnection con2 = new SqlConnection(strconnect);
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", con2);
                cmdex.CommandType = CommandType.StoredProcedure;
                cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                cmdex.Parameters.AddWithValue("@Method", method);
                cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                con2.Open();
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

        //-------------------------------------------------------------//
        //  Sidebar Logo
        //------------------------------------------------------------//
        public void getImagesidebarLogo()
        {
            try
            {
                //Sidebar Logo 
                using (SqlConnection UserCon = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_Getaimagelogousingfor", UserCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@ImageFor", "SidebarLogo");
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string imgname = dt.Rows[0]["ImageName"].ToString();
                        string Extension = dt.Rows[0]["Extension"].ToString();
                        string imgpath = dt.Rows[0]["ImageFilePath"].ToString();

                        smlogo1.Src = imgpath;
                        smlogo2.Src = imgpath;
                        smImg3.Src = imgpath;
                        smImg4.Src = imgpath;
                    }
                }

               
                //Master Header Logo
                //using (SqlConnection UserCon2 = new SqlConnection(strconnect))
                //{

                //    SqlCommand cmd = new SqlCommand("SP_Getaimagelogousingfor", UserCon2);
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //    cmd.Parameters.AddWithValue("@ImageFor", "SmallIconLogo");
                //    DataTable dt = new DataTable();
                //    sda.Fill(dt);

                //    if (dt.Rows.Count > 0)
                //    {
                //        string imgname = dt.Rows[0]["ImageName"].ToString();
                //        string Extension = dt.Rows[0]["Extension"].ToString();
                //        string imgpath = dt.Rows[0]["ImageFilePath"].ToString();

                      
                //    }
                //}
            }
            catch (Exception ex)
            {
                string ErrorMessgage = ex.Message;
                SqlConnection con2 = new SqlConnection(strconnect);
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                SqlCommand cmdex = new SqlCommand("SP_SaveErrorDetails", con2);
                cmdex.CommandType = CommandType.StoredProcedure;
                cmdex.Parameters.AddWithValue("@ErroMessage", ErrorMessgage);
                cmdex.Parameters.AddWithValue("@ErrorLine", lineNumber);
                cmdex.Parameters.AddWithValue("@ErrorPath", pagename);
                cmdex.Parameters.AddWithValue("@Method", method);
                cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
                con2.Open();
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


        //-------------------------------------------------------------//
        //  Dymanic Permission Side bar
        //------------------------------------------------------------//
        public void ViewaSidebarbyRole()
        {
            try
            {
                StringBuilder _StrB = new StringBuilder();

                UserId = Convert.ToInt32(Session["UserID"]);
                UserName = Session["UserName"].ToString();
                EmailID = Session["EmailID"].ToString();
                Designation = Session["Role"].ToString();
                Permission = Session["Permission"].ToString();
                //----Total Count Alert----//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_ViewWebPagesByStaffID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;
                    cmd.Parameters.AddWithValue("@StaffID", UserId);
                    cmd.Parameters.AddWithValue("@RoleName", Designation);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    con.Open();
                    sda.Fill(dt);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dt.Rows.Count > 0)
                    {
                        while (dr.Read())
                        {
                            HtmlGenericControl li = new HtmlGenericControl("li");
                            HtmlGenericControl EXPENSESli = new HtmlGenericControl("li");
                            HtmlGenericControl SALEli = new HtmlGenericControl("li");
                            HtmlGenericControl LEGALli = new HtmlGenericControl("li");
                            HtmlGenericControl ContractLEGALli = new HtmlGenericControl("li");
                            HtmlGenericControl STAFFli = new HtmlGenericControl("li");
                            HtmlGenericControl SETUPli = new HtmlGenericControl("li");
                            HtmlGenericControl REPORTSli = new HtmlGenericControl("li");
                            HtmlGenericControl SUPPORTSli = new HtmlGenericControl("li");
                            HtmlGenericControl Inventoryli = new HtmlGenericControl("li");
                            HtmlGenericControl InventorySettingli = new HtmlGenericControl("li");
                            HtmlGenericControl HRMSli = new HtmlGenericControl("li");
                            HtmlGenericControl Leaveli = new HtmlGenericControl("li");
                            HtmlGenericControl Salaryli = new HtmlGenericControl("li");
                            HtmlGenericControl Leadsli = new HtmlGenericControl("li");

                            string Modulename = dr["Module"].ToString();

                            if (Modulename == "EXPENSES")
                            {
                                EXPENSESCAP.Visible = true;
                                EXPENSESID.Visible = true;
                                ulEXPENSESID.Visible = true;
                                ulEXPENSESID.Controls.Add(EXPENSESli);
                                EXPENSESli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "SALE")
                            {
                                saleCap.Visible = true;
                                saleID.Visible = true;
                                ulsaleID.Visible = true;
                                ulsaleID.Controls.Add(SALEli);
                                SALEli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "LEGAL")
                            {
                                LEGALCAP.Visible = true;
                                LEGALID.Visible = true;
                                ulLEGALID.Visible = true;
                                ulLEGALID.Controls.Add(LEGALli);
                                LEGALli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "CONTRACT")
                            {
                                LEGALCAP.Visible = true;
                                LEGALID.Visible = true;
                                ulLEGALID.Visible = true;
                                ContractID.Visible = true;

                                ulContractID.Visible = true;
                                ulContractID.Controls.Add(ContractLEGALli);
                                ContractLEGALli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "STAFF")
                            {
                                EmployeesCapID.Visible = true;
                                EmployeesID.Visible = true;
                                ulEmployeesID.Visible = true;
                                ulEmployeesID.Controls.Add(STAFFli);
                                STAFFli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "SETUP")
                            {
                                SETUPCapID.Visible = true;
                                SETUPID.Visible = true;
                                ulSETUPID.Visible = true;
                                ulSETUPID.Controls.Add(SETUPli);
                                SETUPli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "Inventory")
                            {
                                InventoryCap.Visible = true;
                                InventoryLi1.Visible = true;
                                ulInventory1.Visible = true;
                                ulInventory1.Controls.Add(Inventoryli);
                                Inventoryli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "InventorySetting")
                            {
                                InventoryCap.Visible = true;
                                InventoryLi1.Visible = true;
                                ulInventory1.Visible = true;
                                SettingINVENTORYLi.Visible = true;
                                ulsettInv1.Visible = true;
                                ulsettInv1.Controls.Add(InventorySettingli);
                                InventorySettingli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "REPORTS")
                            {
                                REPORTCAP.Visible = true;
                                REPORTS.Visible = true;
                                ulREPORTID.Visible = true;
                                ulREPORTID.Controls.Add(REPORTSli);
                                REPORTSli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "HRMS")
                            {
                                HRMSCapID.Visible = true;
                                HRMSID.Visible = true;
                                ulHRMSID.Visible = true;
                                ulHRMSID.Controls.Add(HRMSli);
                                HRMSli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "HRMSLeave")
                            {
                                HRMSCapID.Visible = true;
                                HRMSID.Visible = true;
                                ulHRMSID.Visible = true;
                                LeaveLiID.Visible = true;
                                ulLeaveLiID.Visible = true;
                                ulLeaveLiID.Controls.Add(Leaveli);
                                Leaveli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "HRMSSalary")
                            {
                                HRMSCapID.Visible = true;
                                HRMSID.Visible = true;
                                ulHRMSID.Visible = true;
                                SalaryLiID.Visible = true;
                                ulSalaryLiID.Visible = true;
                                ulSalaryLiID.Controls.Add(Salaryli);
                                Salaryli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "DASHBOARD")
                            {
                                DashboardCap.Visible = true;
                                //sidebarnav.Controls.Add(li);
                                //li.InnerHtml += dr["Design"];
                                DashboardID.Visible = true;
                            }
                            else if (Modulename == "CUSTOMERS")
                            {
                                //sidebarnav.Controls.Add(li);
                                //li.InnerHtml += dr["Design"];
                                CustomerCap.Visible = true;
                                CustomerID.Visible = true;
                            }
                            else if (Modulename == "Leads")
                            {
                                //sidebarnav.Controls.Add(li);
                                //li.InnerHtml += dr["Design"];
                                //CustomerCap.Visible = true;
                                LeadsLi1.Visible = true;
                            }
                            else if (Modulename == "PROJECTS")
                            {
                                //sidebarnav.Controls.Add(li);
                                //li.InnerHtml += dr["Design"];

                                ProjectsID.Visible = true;

                            }
                            else if (Modulename == "VENDOR")
                            {
                                //sidebarnav.Controls.Add(li);
                                //li.InnerHtml += dr["Design"];
                                VendorID.Visible = true;
                            }
                            else if (Modulename == "TENDER")
                            {
                                //sidebarnav.Controls.Add(li);
                                //li.InnerHtml += dr["Design"];
                                TenderID.Visible = true;
                            }
                            else if (Modulename == "TASKS")
                            {
                                //sidebarnav.Controls.Add(li);
                                //li.InnerHtml += dr["Design"];
                                TASKSID.Visible = true;
                            }
                            else if (Modulename == "SUPPORT")
                            {
                                SupportCap.Visible = true;

                                SupportLi.Visible = true;
                            }
                            else
                            {
                                sidebarnav.Controls.Add(li);
                                li.InnerHtml += dr["Design"];
                            }
                        }
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You do not have permission to access!')", true);
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


        public void ViewSideBarAdministrator()
        {
            try
            {
                StringBuilder _StrB = new StringBuilder();

                UserId = Convert.ToInt32(Session["UserID"]);
                UserName = Session["UserName"].ToString();
                EmailID = Session["EmailID"].ToString();
                Designation = Session["Role"].ToString();
                Permission = Session["Permission"].ToString();
                //----Total Count Alert----//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_ViewWebPages", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    con.Open();
                    sda.Fill(dt);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dt.Rows.Count > 0)
                    {
                        while (dr.Read())
                        {
                            HtmlGenericControl li = new HtmlGenericControl("li");
                            HtmlGenericControl EXPENSESli = new HtmlGenericControl("li");
                            HtmlGenericControl SALEli = new HtmlGenericControl("li");
                            HtmlGenericControl LEGALli = new HtmlGenericControl("li");
                            HtmlGenericControl ContractLEGALli = new HtmlGenericControl("li");
                            HtmlGenericControl STAFFli = new HtmlGenericControl("li");
                            HtmlGenericControl SETUPli = new HtmlGenericControl("li");
                            HtmlGenericControl REPORTSli = new HtmlGenericControl("li");
                            HtmlGenericControl SUPPORTSli = new HtmlGenericControl("li");
                            HtmlGenericControl Inventoryli = new HtmlGenericControl("li");
                            HtmlGenericControl InventorySettingli = new HtmlGenericControl("li");
                            HtmlGenericControl HRMSli = new HtmlGenericControl("li");
                            HtmlGenericControl Leaveli = new HtmlGenericControl("li");
                            HtmlGenericControl Salaryli = new HtmlGenericControl("li");
                            HtmlGenericControl Leadsli = new HtmlGenericControl("li");

                            string Modulename = dr["Module"].ToString();

                            if (Modulename == "EXPENSES")
                            {
                                EXPENSESCAP.Visible = true;
                                EXPENSESID.Visible = true;
                                ulEXPENSESID.Visible = true;
                                ulEXPENSESID.Controls.Add(EXPENSESli);
                                EXPENSESli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "SALE")
                            {
                                saleCap.Visible = true;
                                saleID.Visible = true;
                                ulsaleID.Visible = true;
                                ulsaleID.Controls.Add(SALEli);
                                SALEli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "LEGAL")
                            {
                                LEGALCAP.Visible = true;
                                LEGALID.Visible = true;
                                ulLEGALID.Visible = true;
                                ulLEGALID.Controls.Add(LEGALli);
                                LEGALli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "CONTRACT")
                            {
                                LEGALCAP.Visible = true;
                                LEGALID.Visible = true;
                                ulLEGALID.Visible = true;
                                ContractID.Visible = true;

                                ulContractID.Visible = true;
                                ulContractID.Controls.Add(ContractLEGALli);
                                ContractLEGALli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "STAFF")
                            {
                                EmployeesCapID.Visible = true;
                                EmployeesID.Visible = true;
                                ulEmployeesID.Visible = true;
                                ulEmployeesID.Controls.Add(STAFFli);
                                STAFFli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "SETUP")
                            {
                                SETUPCapID.Visible = true;
                                SETUPID.Visible = true;
                                ulSETUPID.Visible = true;
                                ulSETUPID.Controls.Add(SETUPli);
                                SETUPli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "Inventory")
                            {
                                InventoryCap.Visible = true;
                                InventoryLi1.Visible = true;
                                ulInventory1.Visible = true;
                                ulInventory1.Controls.Add(Inventoryli);
                                Inventoryli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "InventorySetting")
                            {
                                InventoryCap.Visible = true;
                                InventoryLi1.Visible = true;
                                ulInventory1.Visible = true;
                                SettingINVENTORYLi.Visible = true;
                                ulsettInv1.Visible = true;
                                ulsettInv1.Controls.Add(InventorySettingli);
                                InventorySettingli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "REPORTS")
                            {
                                REPORTCAP.Visible = true;
                                REPORTS.Visible = true;
                                ulREPORTID.Visible = true;
                                ulREPORTID.Controls.Add(REPORTSli);
                                REPORTSli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "HRMS")
                            {
                                HRMSCapID.Visible = true;
                                HRMSID.Visible = true;
                                ulHRMSID.Visible = true;
                                ulHRMSID.Controls.Add(HRMSli);
                                HRMSli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "HRMSLeave")
                            {
                                HRMSCapID.Visible = true;
                                HRMSID.Visible = true;
                                ulHRMSID.Visible = true;
                                LeaveLiID.Visible = true;
                                ulLeaveLiID.Visible = true;
                                ulLeaveLiID.Controls.Add(Leaveli);
                                Leaveli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "HRMSSalary")
                            {
                                HRMSCapID.Visible = true;
                                HRMSID.Visible = true;
                                ulHRMSID.Visible = true;
                                SalaryLiID.Visible = true;
                                ulSalaryLiID.Visible = true;
                                ulSalaryLiID.Controls.Add(Salaryli);
                                Salaryli.InnerHtml += dr["Design"];
                            }
                            else if (Modulename == "DASHBOARD")
                            {
                                DashboardCap.Visible = true;
                                //sidebarnav.Controls.Add(li);
                                //li.InnerHtml += dr["Design"];
                                DashboardID.Visible = true;
                            }
                            else if (Modulename == "CUSTOMERS")
                            {
                                //sidebarnav.Controls.Add(li);
                                //li.InnerHtml += dr["Design"];
                                CustomerCap.Visible = true;
                                CustomerID.Visible = true;
                            }
                            else if (Modulename == "Leads")
                            {
                                //sidebarnav.Controls.Add(li);
                                //li.InnerHtml += dr["Design"];
                                //CustomerCap.Visible = true;
                                LeadsLi1.Visible = true;
                            }
                            else if (Modulename == "PROJECTS")
                            {
                                //sidebarnav.Controls.Add(li);
                                //li.InnerHtml += dr["Design"];

                                ProjectsID.Visible = true;

                            }
                            else if (Modulename == "VENDOR")
                            {
                                //sidebarnav.Controls.Add(li);
                                //li.InnerHtml += dr["Design"];
                                VendorID.Visible = true;
                            }
                            else if (Modulename == "TENDER")
                            {
                                //sidebarnav.Controls.Add(li);
                                //li.InnerHtml += dr["Design"];
                                TenderID.Visible = true;
                            }
                            else if (Modulename == "TASKS")
                            {
                                //sidebarnav.Controls.Add(li);
                                //li.InnerHtml += dr["Design"];
                                TASKSID.Visible = true;
                            }
                            else if (Modulename == "SUPPORT")
                            {
                                SupportCap.Visible = true;

                                SupportLi.Visible = true;
                            }
                            else
                            {
                                sidebarnav.Controls.Add(li);
                                li.InnerHtml += dr["Design"];
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

                    if (RoleType == "Administrator")
                    {
                        if (!IsPostBack==true)
                        {
                            UserId = Convert.ToInt32(Session["UserID"]);
                            UserName = Session["UserName"].ToString();
                            EmailID = Session["EmailID"].ToString();
                            Designation = Session["Role"].ToString();
                            Permission = Session["Permission"].ToString();
                            DeptID = Session["DeptID"].ToString();
                            
                            lblUserID.Text = Session["UserID"].ToString();
                            lblFirstName.Text = Session["UserName"].ToString();
                            lblEmailID.Text = Session["EmailID"].ToString();

                            AnnouncementCount();
                            ActivityCount();
                            GetbyCurrentDateAndTime();
                            GetActivityCurrentDateAndTime();

                            ViewSideBarAdministrator();

                            getImagesidebarTextLogo();
                            getImagesidebarLogo();
                            getImageSmallLogoPreloaderLogo();

                            AdminSidebar.Visible = true;

                            navbardiv.Visible = true;
                            navbardiv2.Visible = true;
                            navbardiv3.Visible = true;
                            navbardiv4.Visible = true;

                        }

                        
                    }
                    else if (RoleType == Designation)
                    {
                        if (!IsPostBack == true)
                        {
                            UserId = Convert.ToInt32(Session["UserID"]);
                            UserName = Session["UserName"].ToString();
                            EmailID = Session["EmailID"].ToString();
                            Designation = Session["Role"].ToString();
                            Permission = Session["Permission"].ToString();
                            DeptID = Session["DeptID"].ToString();

                            lblUserID.Text = Session["UserID"].ToString();
                            lblFirstName.Text = Session["UserName"].ToString();
                            lblEmailID.Text = Session["EmailID"].ToString();
                            lblPermission.Text = Session["Permission"].ToString();

                            getImagesidebarTextLogo();
                            getImagesidebarLogo();
                            getImageSmallLogoPreloaderLogo();

                            AnnouncementCount();
                            ActivityCountEmpID(UserId);
                            GetbyCurrentDateAndTime();
                            GetActivityCurrentDateAndTimeEmpID(UserId);
                            ////----------------SideBar-----------------//
                            if (lblPermission.Text == "True")
                            {
                                navbardiv.Visible = true;

                                ViewaSidebarbyRole();

                                AdminSidebar.Visible = true;
                            }
                            else
                            {
                                navbardiv.Visible = false;
                                navbardiv2.Visible = false;
                                navbardiv3.Visible = false;
                                navbardiv4.Visible = false;
                                AdminSidebar.Visible = true;

                            }

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

        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetWebPagesName", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", txtWebPage.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    List<string> WebpageNames = new List<string>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        WebpageNames.Add(dt.Rows[i].ToString());
                        //BTNDIV.InnerHtml = "<a href=\"Dashboard.aspx\"></a>";

                        if (dt.Rows.Count > 0)
                        {
                            GVWebPage.DataSource = dt;
                            GVWebPage.DataBind();

                            Divshowdash.Visible = false;
                            BTNDIV.Visible = true;
                        }
                        else
                        {
                            GVWebPage.Visible = false;
                            Divshowdash.Visible = true;
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

        void clearCache()
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
            Response.Redirect("~/LogIn.aspx", false);
        }


        protected void LinkbtnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                UserId = Convert.ToInt32(Session["UserID"]);
                Designation = Session["Role"].ToString();
                if (Designation == "Administrator" && UserId == 1)
                {
                    Session.Remove("LoginType");
                    Session.Remove("Role");
                    Session.Remove("UserID");
                    Session.Remove("UserName");
                    Session.Remove("EmailID");
                    Session.Remove("DeptID");
                    Session.Remove("EmailID");
                    Session.Remove("CreateBy");
                    Session.Clear();
                    clearCache();
                    Response.Redirect("~/LogIn.aspx", false);
                }
                else
                {
                    //-------------Log Out Staff----------------------//
                    using (SqlConnection con1 = new SqlConnection(strconnect))
                    {

                        SqlCommand command = new SqlCommand("SP_UserAuthenticationLogOut", con1);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", lblUserID.Text);
                        command.Parameters.AddWithValue("@Username", lblEmailID.Text);
                        con1.Open();
                        int i = command.ExecuteNonQuery();
                        if (i < 0)
                        {
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Staff Logout !')", true);              
                        }
                        else
                        {
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Staff Not Logout!')", true);
                        }

                    }

                    Session.Remove("LoginType");
                    Session.Remove("Role");
                    Session.Remove("UserID");
                    Session.Remove("UserName");
                    Session.Remove("EmailID");
                    Session.Remove("DeptID");
                    Session.Remove("EmailID");
                    Session.Remove("CreateBy");
                    Session.Clear();
                    clearCache();
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


        protected void linkAnnoucementName_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string tableID;
                var rows = GridViewAnnounceView.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                tableID = ((Label)rows[rowindex].FindControl("lblAnnouncementID")).Text;
                Response.Redirect("~/DisplayAnnouncement.aspx?ID=" + tableID + "", false);
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

                    }
                    else
                    {

                    }
                }
            }
        }



        protected void linkActivityType1_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/ActivityLogs.aspx", false);
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

                    }
                    else
                    {

                    }
                }
            }
        }

        #endregion
    }
}