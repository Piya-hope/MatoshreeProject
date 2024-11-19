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
using System.Web.UI.DataVisualization.Charting;

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
#endregion

namespace MatoshreeProject
{
    public partial class Dashboard : System.Web.UI.Page
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


        #endregion

        #region " Public Functions "
        protected void bindDepartment()
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
                    ddlDepartment.DataSource = ds.Tables[0];
                    ddlDepartment.DataTextField = "Dept_Name";
                    ddlDepartment.DataValueField = "Dept_ID";
                    ddlDepartment.DataBind();
                    ddlDepartment.Items.Insert(0, new ListItem("Select Department", "0"));
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

            ddlDepartment.SelectedIndex = -1;

            foreach (GridViewRow row in GVDBSetting.Rows)
            {
                CheckBox chkItem = row.FindControl("chkItem") as CheckBox;
                if (chkItem != null)
                {
                    chkItem.Checked = false;
                }
            }

        }

        public void GetDeptDetails()
        {
            try
            {
                string DivID;


                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand command = new SqlCommand("SP_GetDepartmentByStaffID", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StaffID", UserId);

                    DataTable dt = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter(command);
                    ad.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {


                        lblDepID.Text = dt.Rows[0]["Dept_ID"].ToString();
                        lblDeptName11.Text = dt.Rows[0]["Dept_Name"].ToString();

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

        public void ViewDashBoardDiv()
        {
            try
            {
                String RollName = Designation;

                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand command = new SqlCommand("SP_ViewDashBoardPermissionByRollName", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleName", RollName);
                    command.Parameters.AddWithValue("@DeptName", lblDeptName11.Text);
                    DataTable dt = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter(command);
                    ad.Fill(dt);
                    if (dt.Rows.Count > 0)
                    { //for loop 
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string DivID = dt.Rows[i]["DivID"].ToString();
                            string DivName = dt.Rows[i]["DivName"].ToString();

                            if (DivID == "DivProjectOverview")
                            {
                                DivProjectOverview.Visible = true;
                            }
                            else
                            {
                                DivProjectOverview.Visible = false;
                            }
                            //if (DivID == "DivStatistics")
                            //{
                            //   // DivStatistics.Visible = true;
                            //}
                            //else
                            //{
                            //    DivStatistics.Visible = false;
                            //}
                            //if (DivID == "DivProjectInvoiceChart")
                            //{
                            //    //DivProjectInvoiceChart.Visible = true;
                            //}
                            //else
                            //{
                            //    //DivProjectInvoiceChart.Visible = false;
                            //}
                            //if (DivID == "DivTaskChart")
                            //{
                            //    DivTaskChart.Visible = true;
                            //}
                            //else
                            //{
                            //    DivTaskChart.Visible = false;
                            //}
                            //if (DivID == "DivTaskChart")
                            //{
                            //    DivTaskChart.Visible = true;
                            //}
                            //else
                            //{
                            //    DivTaskChart.Visible = false;
                            //}
                            //if (DivID == "DivTaskChart")
                            //{
                            //    DivTaskChart.Visible = true;
                            //}
                            //else
                            //{
                            //    DivTaskChart.Visible = false;
                            //}
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

        public DataTable ViewDashBoardSetting()
        {

            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewDashBoardSettingDetails", con))
                {
                    ad.Fill(table);
                    GVDBSetting.DataSource = table;
                    GVDBSetting.DataBind();
                }
            }
            return table;

        }


        public DataTable ViewDashBoardSetting(string departmentId)
        {

            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewDashBoardSettingDetailsByDeptID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dept_ID", departmentId);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GVDBSetting.DataSource = table;
                GVDBSetting.DataBind();

            }
            return table;

        }

        //-----------------------------------------------------------------------//
        private void BindInvoicechart()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_BindInvoiceDoughnutChart", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adpt.Fill(dt);

                        string[] XPointMember = new string[dt.Rows.Count];
                        int[] YPointMember = new int[dt.Rows.Count];

                        for (int count = 0; count < dt.Rows.Count; count++)
                        {
                            XPointMember[count] = dt.Rows[count]["ProjectName"].ToString();

                            YPointMember[count] = Convert.ToInt32(dt.Rows[count]["TotalAmount"]);
                        }

                        ChartProjectInvoice.Series[0].Points.DataBindXY(XPointMember, YPointMember);
                        ChartProjectInvoice.Series[0].BorderWidth = 1;
                        ChartProjectInvoice.Series[0].ChartType = SeriesChartType.Doughnut;


                        for (int count = 0; count < ChartProjectInvoice.Series[0].Points.Count; count++)
                        {
                            DataPoint point = ChartProjectInvoice.Series[0].Points[count];
                            point.Label = $"{XPointMember[count]}:-{YPointMember[count]}";
                        }

                        ChartProjectInvoice.Legends[0].Enabled = false;


                        ChartProjectInvoice.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

                        con.Close();
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

        private void BindTaskchart()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_BindTaskDoughnutChart", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adpt.Fill(dt);

                        string[] XPointMember = new string[dt.Rows.Count];
                        int[] YPointMember = new int[dt.Rows.Count];

                        for (int count = 0; count < dt.Rows.Count; count++)
                        {
                            XPointMember[count] = dt.Rows[count]["TaskStatus"].ToString();

                            YPointMember[count] = Convert.ToInt32(dt.Rows[count]["Count"]);
                        }

                        ChartTask.Series[0].Points.DataBindXY(XPointMember, YPointMember);
                        ChartTask.Series[0].BorderWidth = 1;
                        ChartTask.Series[0].ChartType = SeriesChartType.Doughnut;


                        for (int count = 0; count < ChartTask.Series[0].Points.Count; count++)
                        {
                            DataPoint point = ChartTask.Series[0].Points[count];
                            point.Label = $"{XPointMember[count]}:-{YPointMember[count]}";
                        }

                        ChartTask.Legends[0].Enabled = false;


                        ChartTask.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

                        con.Close();
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
        private void BindPaymentchart()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_BindPaymentDoughnutChart", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adpt.Fill(dt);

                        string[] XPointMember = new string[dt.Rows.Count];
                        int[] YPointMember = new int[dt.Rows.Count];

                        for (int count = 0; count < dt.Rows.Count; count++)
                        {
                            XPointMember[count] = dt.Rows[count]["ProjectName"].ToString();

                            YPointMember[count] = Convert.ToInt32(dt.Rows[count]["Count"]);
                        }

                        ChartPayment.Series[0].Points.DataBindXY(XPointMember, YPointMember);
                        ChartPayment.Series[0].BorderWidth = 1;
                        ChartPayment.Series[0].ChartType = SeriesChartType.Pyramid;


                        for (int count = 0; count < ChartPayment.Series[0].Points.Count; count++)
                        {
                            DataPoint point = ChartPayment.Series[0].Points[count];
                            point.Label = $"{XPointMember[count]}:-{YPointMember[count]}";
                        }

                        ChartPayment.Legends[0].Enabled = false;


                        ChartPayment.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

                        con.Close();
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

        private void BindWorkOrderchart()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_BindWorkOrderDoughnutChart", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adpt.Fill(dt);

                        string[] XPointMember = new string[dt.Rows.Count];
                        int[] YPointMember = new int[dt.Rows.Count];

                        for (int count = 0; count < dt.Rows.Count; count++)
                        {
                            XPointMember[count] = dt.Rows[count]["ProjectName"].ToString();

                            YPointMember[count] = Convert.ToInt32(dt.Rows[count]["Percentage"]);
                        }

                        ChartWorkOrder.Series[0].Points.DataBindXY(XPointMember, YPointMember);
                        ChartWorkOrder.Series[0].BorderWidth = 1;
                        ChartWorkOrder.Series[0].ChartType = SeriesChartType.Doughnut;


                        for (int count = 0; count < ChartWorkOrder.Series[0].Points.Count; count++)
                        {
                            DataPoint point = ChartWorkOrder.Series[0].Points[count];
                            point.Label = $"{XPointMember[count]}:{YPointMember[count]}";
                        }

                        ChartWorkOrder.Legends[0].Enabled = false;


                        ChartWorkOrder.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

                        con.Close();
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

        //--------------------------------------------------------------------//
        public DataTable ProjectDetailReport()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ProjectDetailReport", con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                ViewState["ProjectData"] = table;

            }
            return table;
        }

        public DataTable ProjectDetailReportByEmpID(int UserID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ProjectDetailReportByEmpID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", UserID);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                //GridProject.DataSource = table;
                //GridProject.DataBind();
                ViewState["ProjectData"] = table;
            }
            return table;
        }
        //------------------TICKETS--------------------------------------------//
        public void StaffOperationPermissionTicket()
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
                    command.Parameters.AddWithValue("@SubModule", "Ticket");
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
                            GetCompanyAddress();
                            ViewTicketDetails();

                            if (Edit == "True")
                            {

                                Gridticket.Columns[10].Visible = true;
                            }
                            else
                            {

                                Gridticket.Columns[10].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                Gridticket.Columns[11].Visible = true;
                            }
                            else
                            {

                                Gridticket.Columns[11].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {
                            GetCompanyAddress();
                            ViewTicketDetailsEmpID(UserId);
                            GetCompanyAddress();


                            if (Edit == "True")
                            {

                                Gridticket.Columns[10].Visible = true;
                            }
                            else
                            {

                                Gridticket.Columns[10].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                Gridticket.Columns[11].Visible = true;
                            }
                            else
                            {

                                Gridticket.Columns[11].Visible = false;
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
        public DataTable ViewTicketDetails()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(strconnect);
            SqlCommand cmd = new SqlCommand("SP_TicketDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            Gridticket.DataSource = dt;
            Gridticket.DataBind();
            ViewState["TicketDATA"] = dt;

            return dt;
        }

        public DataTable ViewTicketDetailsEmpID(int UserID)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(strconnect);

            SqlCommand cmd = new SqlCommand("SP_TicketDetailsEmpID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpID", UserID);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            Gridticket.DataSource = dt;
            Gridticket.DataBind();
            ViewState["TicketDATA"] = dt;

            return dt;
        }

        //---------------------------------------------------------------------//
        protected void bindProjectByEmpID(int UserID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetProjectByStaffID", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", UserID);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlProjects.DataSource = ds.Tables[0];
                    ddlProjects.DataTextField = "ProjectName";
                    ddlProjects.DataValueField = "ID";
                    ddlProjects.DataBind();
                    ddlProjects.Items.Insert(0, new ListItem("Select Project", "0"));
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
        protected void bindProject()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetProjectName", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlProjects.DataSource = ds.Tables[0];
                    ddlProjects.DataTextField = "ProjectName";
                    ddlProjects.DataValueField = "ID";
                    ddlProjects.DataBind();
                    ddlProjects.Items.Insert(0, new ListItem("Select Project", "0"));
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

        public DataTable ViewWorkorderDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewWorkOrderDetails", con))
                {
                    ad.Fill(table);
                    GridWorkorderlist.DataSource = table;
                    GridWorkorderlist.DataBind();
                    ViewState["WorkData1"] = table;
                }
            }
            return table;
        }
        public DataTable ViewWorkorderDetailsByEmpID(int UserID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewWorkOrderDetailsEmpID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", UserID);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridWorkorderlist.DataSource = table;
                GridWorkorderlist.DataBind();
                ViewState["WorkData1"] = table;
            }
            return table;
        }

        public DataTable ViewAnnouncementDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewAnnouncementFORMonth", con))
                {
                    ad.Fill(table);
                    GridAnnouncement.DataSource = table;
                    GridAnnouncement.DataBind();

                }
            }
            return table;
        }

        public void EstimateStatusCountByEmpID(int UserID)
        {
            try
            {
                //-------------totalEstimateTotal----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateTotalCount", con);
                    command.CommandType = CommandType.StoredProcedure;
                    int totalEstimateTotal = (int)command.ExecuteScalar();

                    lblTotalEstimateCount.Text = Convert.ToString(totalEstimateTotal);
                    //TotalInvoiceCount = totalInvoiceTotal;
                }
                double TotaEstimateCount;
                TotaEstimateCount = Convert.ToDouble(lblTotalEstimateCount.Text);

                //3-------------EstimateNotInvoiced----------------------// 
                using (SqlConnection con7 = new SqlConnection(strconnect))
                {
                    con7.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateToInvoiceNotSendCountByEmpID", con7);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int EstimateNotInvoiced = (int)command.ExecuteScalar();

                    lblNotInvoiced.Text = Convert.ToString(EstimateNotInvoiced) + "/" + lblTotalEstimateCount.Text;

                    decimal TotalEstimateNotInvoiced = Convert.ToDecimal((EstimateNotInvoiced / TotaEstimateCount) * 100);
                    decimal totalEstimateNotInvoiced = decimal.Round(TotalEstimateNotInvoiced, 1);
                    lblPersentNotInvoiced.Text = Convert.ToString(totalEstimateNotInvoiced) + "%";

                    ProgressNotInvoiced.Style.Add("width", lblPersentNotInvoiced.Text);
                }

                //2-------------EstimateInvoiced----------------------//
                using (SqlConnection con5 = new SqlConnection(strconnect))
                {
                    con5.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateToInvoiceSendCountByEmpID", con5);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int EstimateInvoiced = (int)command.ExecuteScalar();

                    lblInvoiced.Text = Convert.ToString(EstimateInvoiced) + "/" + lblTotalEstimateCount.Text;

                    decimal TotalEstimateNotSend = Convert.ToDecimal((EstimateInvoiced / TotaEstimateCount) * 100);
                    decimal totalEstimateNotSend = decimal.Round(TotalEstimateNotSend, 1);
                    lblpercentInvoiced.Text = Convert.ToString(totalEstimateNotSend) + "%";
                    ProgressInvoiced.Style.Add("width", lblpercentInvoiced.Text);
                }

                //1-------------EstimateNotSend----------------------/
                using (SqlConnection con6 = new SqlConnection(strconnect))
                {
                    con6.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateNOTSendCountByEmpID", con6);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int EstimateNotSend = (int)command.ExecuteScalar();

                    lblNotsend.Text = Convert.ToString(EstimateNotSend) + "/" + lblTotalEstimateCount.Text;

                    decimal TotalEstimateNotSend = Convert.ToDecimal((EstimateNotSend / TotaEstimateCount) * 100);
                    decimal totalEstimateNotSend = decimal.Round(TotalEstimateNotSend, 1);
                    lblPersentNotSend.Text = Convert.ToString(totalEstimateNotSend) + "%";

                    ProgressNotSend.Style.Add("width", lblPersentNotSend.Text);
                }

                //4-------------EstimateDraft----------------------//
                using (SqlConnection con8 = new SqlConnection(strconnect))
                {
                    con8.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateDraftCountByEmpID", con8);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int EstimateDraft = (int)command.ExecuteScalar();

                    lblDraft.Text = Convert.ToString(EstimateDraft) + "/" + lblTotalEstimateCount.Text;

                    decimal TotalEstimateDraft = Convert.ToDecimal((EstimateDraft / TotaEstimateCount) * 100);
                    decimal totalEstimateDraft = decimal.Round(TotalEstimateDraft, 1);
                    lblPersentDraft.Text = Convert.ToString(totalEstimateDraft) + "%";
                    ProgressDraft.Style.Add("width", lblPersentDraft.Text);
                }

                //5-------------EstimateSend----------------------//
                using (SqlConnection con4 = new SqlConnection(strconnect))
                {
                    con4.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateSendCountByEmpID", con4);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int EstimateSend = (int)command.ExecuteScalar();

                    lblSend.Text = Convert.ToString(EstimateSend) + "/" + lblTotalEstimateCount.Text;

                    decimal TotalEstimateSend = Convert.ToDecimal((EstimateSend / TotaEstimateCount) * 100);
                    decimal totalEstimateSend = decimal.Round(TotalEstimateSend, 1);
                    lblPersentSend.Text = Convert.ToString(totalEstimateSend) + "%";

                    ProgressSend.Style.Add("width", lblPersentSend.Text);
                }

                //6-------------EstimateExpired----------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateExpiredCountByEmpID", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int EstimateExpired = (int)command.ExecuteScalar();

                    lblExpired.Text = Convert.ToString(EstimateExpired) + "/" + lblTotalEstimateCount.Text;

                    decimal PercentExpired = Convert.ToDecimal((EstimateExpired / TotaEstimateCount) * 100);
                    decimal totalExpired = decimal.Round(PercentExpired, 1);
                    lblPercentExpired.Text = Convert.ToString(totalExpired) + "%";

                    ProgressExpired.Style.Add("width", lblPercentExpired.Text);
                }

                //7-------------EstimateDeclined----------------------//
                using (SqlConnection con3 = new SqlConnection(strconnect))
                {
                    con3.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateDeclinedCountByEmpID", con3);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int EstimateDeclined = (int)command.ExecuteScalar();

                    lblEstimateDeclined.Text = Convert.ToString(EstimateDeclined) + "/" + lblTotalEstimateCount.Text;

                    decimal TotalEstimateDeclined = Convert.ToDecimal((EstimateDeclined / TotaEstimateCount) * 100);

                    decimal totalDeclined = decimal.Round(TotalEstimateDeclined, 1);
                    lblPercentEstimateDecline.Text = Convert.ToString(totalDeclined) + "%";

                    ProgressEstimateDecline.Style.Add("width", lblPercentEstimateDecline.Text);
                }

                //8-------------EstimateAccepted----------------------//
                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateAcceptedCountByEmpID", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int AcceptedCount = (int)command.ExecuteScalar();

                    lblEstimateAccepted.Text = Convert.ToString(AcceptedCount) + "/" + lblTotalEstimateCount.Text;

                    decimal TotalEstimateAccepted = Convert.ToDecimal((AcceptedCount / TotaEstimateCount) * 100);
                    decimal totalEstimateAccepted = decimal.Round(TotalEstimateAccepted, 1);
                    lblPercentEstimateAccepted.Text = Convert.ToString(totalEstimateAccepted) + "%";

                    ProgressEstimateAccepted.Style.Add("width", lblPercentEstimateAccepted.Text);
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

        public void InvoiceStatusCountByEmpID(int UserID)
        {
            try
            {
                //-------------totalInvoiceTotal----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceTotalCountByEmpID", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int totalInvoiceTotal = (int)command.ExecuteScalar();

                    lblTotalInvoiceCount.Text = Convert.ToString(totalInvoiceTotal);
                    //TotalInvoiceCount = totalInvoiceTotal;
                }
                double TotalInvoiceCount;
                TotalInvoiceCount = Convert.ToDouble(lblTotalInvoiceCount.Text);

                //-------------InvoiceOverdue----------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceOverdueCountByEmpID", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int InvoiceOverdue = (int)command.ExecuteScalar();

                    lblInvoiceOverdue.Text = Convert.ToString(InvoiceOverdue) + "/" + lblTotalInvoiceCount.Text;
                    decimal PercentOverDue = Convert.ToDecimal((InvoiceOverdue / TotalInvoiceCount) * 100);
                    decimal totalOverDue = decimal.Round(PercentOverDue, 1);
                    lblPercentOverdue.Text = Convert.ToString(totalOverDue) + "%";
                    ProgressOverdue.Style.Add("width", lblPercentOverdue.Text);
                }

                //-------------InvoiceDraft----------------------//
                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceDraftCountbyEmpID", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int InvoiceDraft = (int)command.ExecuteScalar();

                    lblInvoiceDraft.Text = Convert.ToString(InvoiceDraft) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoiceDraft = Convert.ToDecimal((InvoiceDraft / TotalInvoiceCount) * 100);
                    decimal totalDraft = decimal.Round(TotalInvoiceDraft, 1);
                    lblInvoicePercentDraft.Text = Convert.ToString(totalDraft) + "%";

                    ProgressInvoiceDraft.Style.Add("width", lblInvoicePercentDraft.Text);
                }

                //-------------InvoiceUnpaid----------------------//
                using (SqlConnection con3 = new SqlConnection(strconnect))
                {
                    con3.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceUnpaidCountByEmpID", con3);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int InvoiceUnpaid = (int)command.ExecuteScalar();

                    lblUnpaid.Text = Convert.ToString(InvoiceUnpaid) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoiceUnpaid = Convert.ToDecimal((InvoiceUnpaid / TotalInvoiceCount) * 100);

                    decimal totalunpaid = decimal.Round(TotalInvoiceUnpaid, 1);
                    lblPercentUnpaid.Text = Convert.ToString(totalunpaid) + "%";

                    ProgressUnpaid.Style.Add("width", lblPercentUnpaid.Text);
                }

                //-------------InvoicePaid----------------------//
                using (SqlConnection con4 = new SqlConnection(strconnect))
                {
                    con4.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoicePaidCountByEmpID", con4);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int InvoicePaid = (int)command.ExecuteScalar();

                    lblPaid.Text = Convert.ToString(InvoicePaid) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoicePaid = Convert.ToDecimal((InvoicePaid / TotalInvoiceCount) * 100);

                    decimal totalpaid = decimal.Round(TotalInvoicePaid, 1);
                    lblPercentPaid.Text = Convert.ToString(totalpaid) + "%";

                    ProgressPaid.Style.Add("width", lblPercentPaid.Text);
                }

                //-------------InvoicePartiallyPaid----------------------//
                using (SqlConnection con5 = new SqlConnection(strconnect))
                {
                    con5.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoicePartiallyPaidCountbyEmpID", con5);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int InvoicePartiallyPaid = (int)command.ExecuteScalar();

                    lblPartiallyPaid.Text = Convert.ToString(InvoicePartiallyPaid) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoicePartiallyPaid = Convert.ToDecimal((InvoicePartiallyPaid / TotalInvoiceCount) * 100);
                    decimal totalPartiallyPaid = decimal.Round(TotalInvoicePartiallyPaid, 1);
                    lblPercentPartiallyPaid.Text = Convert.ToString(totalPartiallyPaid) + "%";

                    ProgressPartiallyPaid.Style.Add("width", lblPercentPartiallyPaid.Text);
                }

                //-------------InvoiceCanceled----------------------//

                using (SqlConnection con6 = new SqlConnection(strconnect))
                {
                    con6.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceCancelledCountByEmpID", con6);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int InvoiceCanceled = (int)command.ExecuteScalar();

                    lblInvoiceCancele.Text = Convert.ToString(InvoiceCanceled) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoiceCancele = Convert.ToDecimal((InvoiceCanceled / TotalInvoiceCount) * 100);
                    decimal totalCancele = decimal.Round(TotalInvoiceCancele, 1);
                    lblPercentInvoiceCancele.Text = Convert.ToString(totalCancele) + "%";
                    ProgressInvoiceCancele.Style.Add("width", lblPercentPartiallyPaid.Text);
                }

                //---------------OverdueAmount Invoice Amount----------------------//
                using (SqlConnection conOver = new SqlConnection(strconnect))
                {
                    conOver.Open();
                    SqlCommand commandOver = new SqlCommand("SP_GetInvoiceOverdueAmountEMPID", conOver);
                    commandOver.CommandType = CommandType.StoredProcedure;
                    commandOver.Parameters.AddWithValue("@EmpID", UserID);
                    string totalInvoiceOverdueAmount = (string)commandOver.ExecuteScalar();

                    if (totalInvoiceOverdueAmount == null)
                    {
                        lbl_Past_Due_Invoice.Text = "₹" + Convert.ToString("0");
                    }
                    else
                    {
                        lbl_Past_Due_Invoice.Text = Convert.ToString(totalInvoiceOverdueAmount);
                    }


                }

                //---------------OutStanding Invoice Amount----------------------//
                using (SqlConnection const1 = new SqlConnection(strconnect))
                {
                    const1.Open();
                    SqlCommand commandst = new SqlCommand("SP_GetInvoiceOutStandingAmountEMPID", const1);
                    commandst.CommandType = CommandType.StoredProcedure;
                    commandst.Parameters.AddWithValue("@EmpID", UserID);
                    string totalInvoiceOutStAmount = (string)commandst.ExecuteScalar();

                    if (totalInvoiceOutStAmount == null)
                    {
                        lbl_Outstanding_Invoice.Text = "₹" + Convert.ToString("0");
                    }
                    else
                    {
                        lbl_Outstanding_Invoice.Text = Convert.ToString(totalInvoiceOutStAmount);
                    }

                }

                //---------------PAID Invoice Amount----------------------//
                using (SqlConnection conpaid = new SqlConnection(strconnect))
                {
                    conpaid.Open();
                    SqlCommand commandpaid = new SqlCommand("SP_GetInvoicePaidAmountEMPID", conpaid);
                    commandpaid.CommandType = CommandType.StoredProcedure;
                    commandpaid.Parameters.AddWithValue("@EmpID", UserID);
                    string totalInvoicepaid = (string)commandpaid.ExecuteScalar();

                    if (totalInvoicepaid == null)
                    {
                        lbl_Paid_Invoice.Text = "₹" + Convert.ToString("0");
                    }
                    else
                    {
                        lbl_Paid_Invoice.Text = Convert.ToString(totalInvoicepaid);
                    }

                }

                //---------------Wating Payment Invoice Amount----------------------//
                using (SqlConnection conpaid = new SqlConnection(strconnect))
                {
                    conpaid.Open();
                    SqlCommand commandpaid = new SqlCommand("SP_GetCountInvoiceWatingByEmpID", conpaid);
                    commandpaid.CommandType = CommandType.StoredProcedure;
                    commandpaid.Parameters.AddWithValue("@EmpID", UserID);
                    int totalInvoiceWating = (int)commandpaid.ExecuteScalar();

                    decimal TotalInvoiceWating = Convert.ToDecimal((totalInvoiceWating / TotalInvoiceCount) * 100);
                    decimal totalWating1 = decimal.Round(TotalInvoiceWating, 1);
                    lblinvWatingPer.Text = Convert.ToString(totalWating1) + "%";
                    DivInvoiceWati.Style.Add("width", lblinvWatingPer.Text);

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
        public void WorkOrderStatusCountByEmpID(int UserID)
        {
            try
            {
                //-------------totalWorkOrder----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetWorkOrderTotalCount", con);
                    command.CommandType = CommandType.StoredProcedure;
                    int totalWorkOrderCount = (int)command.ExecuteScalar();
                    lbltotatWorkOrdercount.Text = Convert.ToString(totalWorkOrderCount);
                }
                double TotaWorkOrderCount;
                TotaWorkOrderCount = Convert.ToDouble(lbltotatWorkOrdercount.Text);
                //------------- WorkOrder Number ---------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetWorkOrderNoCountbyEmpID", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int WorkOrderNo = (int)command.ExecuteScalar();
                    lblWorkOrder.Text = Convert.ToString(WorkOrderNo) + "/" + lbltotatWorkOrdercount.Text;
                    decimal PercentWorkorder = Convert.ToDecimal((WorkOrderNo / TotaWorkOrderCount) * 100);
                    decimal totalWorkorder = decimal.Round(PercentWorkorder, 1);
                    lblPercentWorkOrder.Text = Convert.ToString(totalWorkorder) + "%";
                    TotalProgressWorkOrderNumber.Style.Add("width", lblPercentWorkOrder.Text);
                }
                //------------- WorkOrderAccepeted ---------------------//
                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetWorkOrderAcceptedCountyEmpID", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int AcceptedCount = (int)command.ExecuteScalar();

                    lblWorkOrderaccept.Text = Convert.ToString(AcceptedCount) + "/" + lbltotatWorkOrdercount.Text;

                    decimal TotalAccepted = Convert.ToDecimal((AcceptedCount / TotaWorkOrderCount) * 100);
                    decimal totalAccepted = decimal.Round(TotalAccepted, 1);
                    lblWorkOrderPercentAccept.Text = Convert.ToString(totalAccepted) + "%";
                    ProgressAccepted.Style.Add("width", lblWorkOrderPercentAccept.Text);

                    lblPercentWorkOrderAccepted.Text = Convert.ToString(totalAccepted) + "%";
                    ProgressWorkOrderAccepted.Style.Add("width", lblPercentWorkOrderAccepted.Text);
                }

                //-------------WorkOrderDeclined----------------------//

                using (SqlConnection con3 = new SqlConnection(strconnect))
                {
                    con3.Open();
                    SqlCommand command = new SqlCommand("SP_GetWorkOrderDeclinedCountByEmpID", con3);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int WorkOrderDeclined = (int)command.ExecuteScalar();


                    lblWorkOrderdeclined.Text = Convert.ToString(WorkOrderDeclined) + "/" + lbltotatWorkOrdercount.Text;

                    decimal TotalDeclined = Convert.ToDecimal((WorkOrderDeclined / TotaWorkOrderCount) * 100);
                    decimal totalDeclined = decimal.Round(TotalDeclined, 1);
                    lblPercentDeclined.Text = Convert.ToString(totalDeclined) + "%";

                    ProgressDeclined.Style.Add("width", lblPercentDeclined.Text);
                }

                //-------------WorkOrderCanceled----------------------//

                using (SqlConnection con4 = new SqlConnection(strconnect))
                {
                    con4.Open();
                    SqlCommand command = new SqlCommand("SP_GetWorkOrderCanceledCountbyEmpID", con4);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int wrokordercanceled = (int)command.ExecuteScalar();

                    lblcanceled.Text = Convert.ToString(wrokordercanceled) + "/" + lbltotatWorkOrdercount.Text;

                    decimal Totalwrokordercanceled = Convert.ToDecimal((wrokordercanceled / TotaWorkOrderCount) * 100);
                    decimal totalwrokordercanceled = decimal.Round(Totalwrokordercanceled, 1);
                    lblPercentagecanceled.Text = Convert.ToString(totalwrokordercanceled) + "%";

                    ProgressCanceled.Style.Add("width", lblPercentagecanceled.Text);
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
        public void TaskStatusCountByEmpID(int UserID)
        {
            try
            {
                //-------------Total Task----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetTotalTaskCount", con);
                    command.CommandType = CommandType.StoredProcedure;
                    int totaltaskCount = (int)command.ExecuteScalar();
                    lblTotalTask.Text = Convert.ToString(totaltaskCount);
                }
                double TotalTaskCount;
                TotalTaskCount = Convert.ToDouble(lblTotalTask.Text);
                //------------- In Progress ---------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetInProgresstaskCountByEmpID", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int TaskNotFinished = (int)command.ExecuteScalar();
                    lblNotFinishedtask.Text = Convert.ToString(TaskNotFinished) + "/" + lblTotalTask.Text;
                    decimal PercentTaskNotFinished = Convert.ToDecimal((TaskNotFinished / TotalTaskCount) * 100);
                    decimal totalNotFinshedTask = decimal.Round(PercentTaskNotFinished, 1);
                    lblPercentTask.Text = Convert.ToString(totalNotFinshedTask) + "%";
                    ProgressNotFinished.Style.Add("width", lblPercentTask.Text);
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
        public void ProjectCountByEmpID(int UserID)
        {
            try
            {
                //-------------totalProject----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetTotalProjectCount", con);
                    command.CommandType = CommandType.StoredProcedure;
                    int totalProjectCount = (int)command.ExecuteScalar();
                    lblTotalProjectCount.Text = Convert.ToString(totalProjectCount);
                }
                double TotaProjectCount;
                TotaProjectCount = Convert.ToDouble(lblTotalProjectCount.Text);
                //---------------In Progress-------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetInProgressProjectCountByEmpID", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", UserID);
                    int ProjectInprogress = (int)command.ExecuteScalar();
                    lblInprogress.Text = Convert.ToString(ProjectInprogress) + "/" + lblTotalProjectCount.Text;
                    decimal PercentProject = Convert.ToDecimal((ProjectInprogress / TotaProjectCount) * 100);
                    decimal totalProject = decimal.Round(PercentProject, 1);
                    lblPercentInprogress.Text = Convert.ToString(totalProject) + "%";
                    ProgressInProgress.Style.Add("width", lblPercentInprogress.Text);
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
        //--------------------------------------------------------------------//
        public void MultilineChartOfProject()
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_ChartMultiline", con1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    con1.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        using (DataSet result = new DataSet())
                        {
                            DataTable Table1 = new DataTable();
                            DataTable Table2 = new DataTable();
                            DataTable Table3 = new DataTable();
                            result.Tables.Add(Table1);
                            result.Tables.Add(Table2);
                            result.Tables.Add(Table3);
                            result.Load(dr, LoadOption.OverwriteChanges, Table1, Table2, Table3);
                            if (result.Tables[0].Rows.Count > 0)
                            {
                                Chart2.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                                Chart2.BorderlineColor = System.Drawing.Color.FromArgb(26, 59, 105);
                                Chart2.BorderlineWidth = 3;
                                Chart2.BackColor = Color.White;

                                Chart2.ChartAreas.Add("chtArea");
                                Chart2.ChartAreas[0].AxisX.Title = "TotalDuration";
                                Chart2.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                                Chart2.ChartAreas[0].AxisY.Title = "TotalProjectCost";
                                Chart2.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                                Chart2.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
                                Chart2.ChartAreas[0].BorderWidth = 2;

                                Chart2.Legends.Add("TotalProjectCost");
                                Chart2.Series.Add("TotalProjectCost");
                                Chart2.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                                Chart2.Series[0].Points.DataBindXY(result.Tables[0].DefaultView, "TotalDuration", result.Tables[0].DefaultView, "TotalProjectCost");

                                Chart2.Series[0].IsVisibleInLegend = true;
                                Chart2.Series[0].IsValueShownAsLabel = true;
                                Chart2.Series[0].ToolTip = "Data Project Cost Point  Value: #VALY{G}";

                                // Setting Line Width
                                Chart2.Series[0].BorderWidth = 3;
                                Chart2.Series[0].Color = Color.Red;


                                Chart2.Series.Add("TotalExpenseAmont");
                                Chart2.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                                Chart2.Series[1].Points.DataBindXY(result.Tables[1].DefaultView, "IDays", result.Tables[1].DefaultView, "InvoiceTotalAmont");

                                Chart2.Series[1].IsVisibleInLegend = true;
                                Chart2.Series[1].IsValueShownAsLabel = true;
                                Chart2.Series[1].ToolTip = "Data Point Expense Amount Value: #VALY{G}";

                                Chart2.Series[1].BorderWidth = 3;
                                Chart2.Series[1].Color = Color.Yellow;

                                Chart2.Series.Add("Amount_Recived");
                                Chart2.Series[2].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                                Chart2.Series[2].Points.DataBindXY(result.Tables[2].DefaultView, "DayPayment", result.Tables[2].DefaultView, "Amount_Recived");

                                Chart2.Series[2].IsVisibleInLegend = true;
                                Chart2.Series[2].IsValueShownAsLabel = true;
                                Chart2.Series[2].ToolTip = "Data Point Payment Amount Value: #VALY{G}";

                                Chart2.Series[2].BorderWidth = 3;
                                Chart2.Series[2].Color = Color.GreenYellow;

                                // Setting Line Shadow
                                //Chart2.Series[0].ShadowOffset = 5;

                                //Legend Properties
                                Chart2.Legends[0].LegendStyle = LegendStyle.Table;
                                Chart2.Legends[0].TableStyle = LegendTableStyle.Wide;
                                Chart2.Legends[0].Docking = Docking.Bottom;
                                Chart2.Legends[0].Alignment = StringAlignment.Center;

                            }
                        }
                        dr.Close();
                    }

                    con1.Close();
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

        public void MultilineChartOfProjectByEmpID(int UserID)
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_ChartMultilinebyEmpID", con1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpID", UserID);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    con1.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        using (DataSet result = new DataSet())
                        {
                            DataTable Table1 = new DataTable();
                            DataTable Table2 = new DataTable();
                            DataTable Table3 = new DataTable();
                            result.Tables.Add(Table1);
                            result.Tables.Add(Table2);
                            result.Tables.Add(Table3);
                            result.Load(dr, LoadOption.OverwriteChanges, Table1, Table2, Table3);
                            if (result.Tables[0].Rows.Count > 0)
                            {
                                Chart2.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                                Chart2.BorderlineColor = System.Drawing.Color.FromArgb(26, 59, 105);
                                Chart2.BorderlineWidth = 3;
                                Chart2.BackColor = Color.White;

                                Chart2.ChartAreas.Add("chtArea");
                                Chart2.ChartAreas[0].AxisX.Title = "TotalDuration";
                                Chart2.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                                Chart2.ChartAreas[0].AxisY.Title = "TotalProjectCost";
                                Chart2.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                                Chart2.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
                                Chart2.ChartAreas[0].BorderWidth = 2;

                                Chart2.Legends.Add("TotalProjectCost");
                                Chart2.Series.Add("TotalProjectCost");
                                Chart2.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                                Chart2.Series[0].Points.DataBindXY(result.Tables[0].DefaultView, "TotalDuration", result.Tables[0].DefaultView, "TotalProjectCost");

                                Chart2.Series[0].IsVisibleInLegend = true;
                                Chart2.Series[0].IsValueShownAsLabel = true;
                                Chart2.Series[0].ToolTip = "Data Project Cost Point  Value: #VALY{G}";

                                // Setting Line Width
                                Chart2.Series[0].BorderWidth = 3;
                                Chart2.Series[0].Color = Color.Red;


                                Chart2.Series.Add("TotalExpenseAmont");
                                Chart2.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                                Chart2.Series[1].Points.DataBindXY(result.Tables[1].DefaultView, "IDays", result.Tables[1].DefaultView, "InvoiceTotalAmont");

                                Chart2.Series[1].IsVisibleInLegend = true;
                                Chart2.Series[1].IsValueShownAsLabel = true;
                                Chart2.Series[1].ToolTip = "Data Point Expense Amount Value: #VALY{G}";

                                Chart2.Series[1].BorderWidth = 3;
                                Chart2.Series[1].Color = Color.Yellow;

                                Chart2.Series.Add("Amount_Recived");
                                Chart2.Series[2].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                                Chart2.Series[2].Points.DataBindXY(result.Tables[2].DefaultView, "DayPayment", result.Tables[2].DefaultView, "Amount_Recived");

                                Chart2.Series[2].IsVisibleInLegend = true;
                                Chart2.Series[2].IsValueShownAsLabel = true;
                                Chart2.Series[2].ToolTip = "Data Point Payment Amount Value: #VALY{G}";

                                Chart2.Series[2].BorderWidth = 3;
                                Chart2.Series[2].Color = Color.GreenYellow;

                                // Setting Line Shadow
                                //Chart2.Series[0].ShadowOffset = 5;

                                //Legend Properties
                                Chart2.Legends[0].LegendStyle = LegendStyle.Table;
                                Chart2.Legends[0].TableStyle = LegendTableStyle.Wide;
                                Chart2.Legends[0].Docking = Docking.Bottom;
                                Chart2.Legends[0].Alignment = StringAlignment.Center;

                            }
                        }
                        dr.Close();
                    }

                    con1.Close();
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
        public void BindBarChartOfProject()
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_BarChartProject", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    Chart1.DataSource = dt;

                    Chart1.Series[0].XValueMember = "ProjectName";
                    Chart1.Series[0].YValueMembers = "TotalProjectCost";
                    Chart1.DataBind();

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

        public void BindBarChartOfProjectEmpID(int UserID)
        {
            try
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlConnection con = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_BarChartProjectEmpID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpID", UserID);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    Chart1.DataSource = dt;

                    Chart1.Series[0].XValueMember = "ProjectName";
                    Chart1.Series[0].YValueMembers = "TotalProjectCost";
                    Chart1.DataBind();

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
        public DataTable ViewUnfinsheddashDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewUnfinisheddash", con))
                {
                    ad.Fill(table);
                    GridTododash.DataSource = table;
                    GridTododash.DataBind();
                }
            }
            return table;
        }

        public DataTable ViewUnfinsheddashDetailsEmpID(int UserID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand command = new SqlCommand("SP_ViewUnfinisheddashbyEmpID", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmpID", UserID);
                SqlDataAdapter ad = new SqlDataAdapter(command);
                ad.Fill(table);
                GridTododash.DataSource = table;
                GridTododash.DataBind();

            }
            return table;
        }
        public DataTable ViewACtivityDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ActivityDetails", con))
                {
                    ad.Fill(table);
                    GridViewAct.DataSource = table;
                    GridViewAct.DataBind();
                }
            }
            return table;
        }

        public DataTable ViewActivityDetailsByEMPID(int UserID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_ActivityDetailsEmpID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpID", UserID);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    adpt.Fill(table);
                    GridViewAct.DataSource = table;
                    GridViewAct.DataBind();

                }
            }
            return table;
        }

        public DataTable ViewTaskDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewTaskStaff", con))
                {
                    ad.Fill(table);
                    GridTask.DataSource = table;
                    GridTask.DataBind();
                    ViewState["TaskDATA"] = table;
                }
            }
            return table;
        }

        //-----------------------------TASK By EmpID--------------------------------------//

        public DataTable ViewTaskDetailsEmpID(int UserID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewTaskStaffByEmpID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", UserID);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridTask.DataSource = table;
                GridTask.DataBind();
                ViewState["TaskDATA"] = table;
            }
            return table;
        }

        public DataTable GetStaffnamebytaskname(string task)
        {
            string str;
            DataTable table = new DataTable();
            DataRow dtrow;
            DataColumn dataColumn = new DataColumn();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_GetTaskDetailsByTaskname", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Subject", task);
                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                ad.Fill(table);

                //if (table.Rows.Count > 0)
                //{
                //    str = table.Rows[0]["Reletd_To"].ToString();

                //    string[] s2 = str.Split(',');
                //    int cnt = s2.Length;
                //    table.Clear();

                //    foreach (string s3 in s2)
                //    {
                //        table.Rows.Add(s3);
                //    }
                //}
            }
            return table;
        }

        //-----------------------------Project Emp ID-------------------------------//
        public DataTable ViewProjetctDetailsByEmpID(int UserID)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("SP_ViewProjectDetailsbyEmpID", con);
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", UserID);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                GridProject.DataSource = table;
                GridProject.DataBind();
                ViewState["ProjectData"] = table;
            }
            return table;
        }

        public DataTable ViewProjetctDetails()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewProjectDetails", con))
                {
                    ad.Fill(table);
                    GridProject.DataSource = table;
                    GridProject.DataBind();
                }
            }
            return table;
        }

        public DataTable GetStaffnamebyProjectname(string ProjectID)
        {
            DataTable table = new DataTable();
            DataColumn dataColumn = new DataColumn();
            using (SqlConnection con = new SqlConnection(strconnect))
            {
                SqlCommand sqlCommand = new SqlCommand("SP_GetProjectMemeberbyID", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                ad.Fill(table);

                //if (table.Rows.Count > 0)
                //{
                //    str = table.Rows[0]["Reletd_To"].ToString();

                //    string[] s2 = str.Split(',');
                //    int cnt = s2.Length;
                //    table.Clear();

                //    foreach (string s3 in s2)
                //    {
                //        table.Rows.Add(s3);
                //    }
                //}
            }
            return table;
        }

        public void WorkOrderAcceptedCount()
        {
            try
            {
                //-------------totalWorkOrderAccepted----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetWorkOrderTotalCount", con);
                    command.CommandType = CommandType.StoredProcedure;
                    int totalWorkOrderAcceptedCount = (int)command.ExecuteScalar();
                    lblTotalWorkOrderAccepted.Text = Convert.ToString(totalWorkOrderAcceptedCount);
                }
                double TotalWorkOrderAccepted;
                TotalWorkOrderAccepted = Convert.ToDouble(lblTotalWorkOrderAccepted.Text);
                //---------------WorkOrderAcceptedCount-------------------//
                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetWorkOrderAcceptedCount", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    int WorkOrderAcceptedCount = (int)command.ExecuteScalar();

                    lblWorkOrderAccepted.Text = Convert.ToString(WorkOrderAcceptedCount) + "/" + lblTotalWorkOrderAccepted.Text;

                    decimal TotalWorkOrderAccepted1 = Convert.ToDecimal((WorkOrderAcceptedCount / TotalWorkOrderAccepted) * 100);
                    decimal totalWorkOrderAccepted2 = decimal.Round(TotalWorkOrderAccepted1, 1);
                    lblPercentWorkOrderAccepted.Text = Convert.ToString(totalWorkOrderAccepted2) + "%";

                    ProgressWorkOrderAccepted.Style.Add("width", lblPercentWorkOrderAccepted.Text);
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
        public void ProjectStatusCount()
        {
            try
            {
                //-------------totalProject----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetTotalProjectCount", con);
                    command.CommandType = CommandType.StoredProcedure;
                    int totalProjectCount = (int)command.ExecuteScalar();
                    lblTotalProjectCount.Text = Convert.ToString(totalProjectCount);
                }
                double TotaProjectCount;
                TotaProjectCount = Convert.ToDouble(lblTotalProjectCount.Text);
                //---------------In Progress-------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetInProgressProjectCount", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    int ProjectInprogress = (int)command.ExecuteScalar();
                    lblInprogress.Text = Convert.ToString(ProjectInprogress) + "/" + lblTotalProjectCount.Text;
                    decimal PercentProject = Convert.ToDecimal((ProjectInprogress / TotaProjectCount) * 100);
                    decimal totalProject = decimal.Round(PercentProject, 1);
                    lblPercentInprogress.Text = Convert.ToString(totalProject) + "%";
                    ProgressInProgress.Style.Add("width", lblPercentInprogress.Text);
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

        public void TaskStatusCount()
        {
            try
            {
                //-------------Total Task----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetTotalTaskMapCount", con);
                    command.CommandType = CommandType.StoredProcedure;
                    int totaltaskCount = (int)command.ExecuteScalar();
                    lblTotalTask.Text = Convert.ToString(totaltaskCount);
                }
                double TotalTaskCount;
                TotalTaskCount = Convert.ToDouble(lblTotalTask.Text);
                //------------- In Progress ---------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetInProgresstaskCount", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    int TaskNotFinished = (int)command.ExecuteScalar();
                    lblNotFinishedtask.Text = Convert.ToString(TaskNotFinished) + "/" + lblTotalTask.Text;
                    decimal PercentTaskNotFinished = Convert.ToDecimal((TaskNotFinished / TotalTaskCount) * 100);
                    decimal totalNotFinshedTask = decimal.Round(PercentTaskNotFinished, 1);
                    lblPercentTask.Text = Convert.ToString(totalNotFinshedTask) + "%";
                    ProgressNotFinished.Style.Add("width", lblPercentTask.Text);
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

        public void WorkOrderStatusCount()
        {
            try
            {
                //----------------totalWorkOrder----------------------//

                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetWorkOrderTotalCount", con);
                    command.CommandType = CommandType.StoredProcedure;
                    int totalWorkOrderCount = (int)command.ExecuteScalar();
                    lbltotatWorkOrdercount.Text = Convert.ToString(totalWorkOrderCount);
                }

                double TotaWorkOrderCount;
                TotaWorkOrderCount = Convert.ToDouble(lbltotatWorkOrdercount.Text);

                //------------- WorkOrder Number ---------------------//

                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetWorkOrderNoCount", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    int WorkOrderNo = (int)command.ExecuteScalar();
                    lblWorkOrder.Text = Convert.ToString(WorkOrderNo) + "/" + lbltotatWorkOrdercount.Text;
                    decimal PercentWorkorder = Convert.ToDecimal((WorkOrderNo / TotaWorkOrderCount) * 100);
                    decimal totalWorkorder = decimal.Round(PercentWorkorder, 1);
                    lblPercentWorkOrder.Text = Convert.ToString(totalWorkorder) + "%";
                    TotalProgressWorkOrderNumber.Style.Add("width", lblPercentWorkOrder.Text);
                }

                //------------- WorkOrderAccepeted ---------------------//

                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetWorkOrderAcceptedCount", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    int AcceptedCount = (int)command.ExecuteScalar();

                    lblWorkOrderaccept.Text = Convert.ToString(AcceptedCount) + "/" + lbltotatWorkOrdercount.Text;

                    decimal TotalAccepted = Convert.ToDecimal((AcceptedCount / TotaWorkOrderCount) * 100);
                    decimal totalAccepted = decimal.Round(TotalAccepted, 1);
                    lblWorkOrderPercentAccept.Text = Convert.ToString(totalAccepted) + "%";

                    ProgressAccepted.Style.Add("width", lblWorkOrderPercentAccept.Text);
                }

                //-------------WorkOrderDeclined----------------------//

                using (SqlConnection con3 = new SqlConnection(strconnect))
                {
                    con3.Open();
                    SqlCommand command = new SqlCommand("SP_GetWorkOrderDeclinedCount", con3);
                    command.CommandType = CommandType.StoredProcedure;
                    int WorkOrderDeclined = (int)command.ExecuteScalar();


                    lblWorkOrderdeclined.Text = Convert.ToString(WorkOrderDeclined) + "/" + lbltotatWorkOrdercount.Text;

                    decimal TotalDeclined = Convert.ToDecimal((WorkOrderDeclined / TotaWorkOrderCount) * 100);
                    decimal totalDeclined = decimal.Round(TotalDeclined, 1);
                    lblPercentDeclined.Text = Convert.ToString(totalDeclined) + "%";

                    ProgressDeclined.Style.Add("width", lblPercentDeclined.Text);
                }

                //-------------WorkOrderCanceled----------------------//

                using (SqlConnection con4 = new SqlConnection(strconnect))
                {
                    con4.Open();
                    SqlCommand command = new SqlCommand("SP_GetWorkOrderCanceledCount", con4);
                    command.CommandType = CommandType.StoredProcedure;
                    int wrokordercanceled = (int)command.ExecuteScalar();

                    lblcanceled.Text = Convert.ToString(wrokordercanceled) + "/" + lbltotatWorkOrdercount.Text;

                    decimal Totalwrokordercanceled = Convert.ToDecimal((wrokordercanceled / TotaWorkOrderCount) * 100);
                    decimal totalwrokordercanceled = decimal.Round(Totalwrokordercanceled, 1);
                    lblPercentagecanceled.Text = Convert.ToString(totalwrokordercanceled) + "%";

                    ProgressCanceled.Style.Add("width", lblPercentagecanceled.Text);
                }

                //-------------WorkOrderNotPublished----------------------//

                using (SqlConnection con5 = new SqlConnection(strconnect))
                {
                    con5.Open();
                    SqlCommand command = new SqlCommand("SP_GetWorkOrderNotPublishedCount", con5);
                    command.CommandType = CommandType.StoredProcedure;
                    int WrokorderNotPublished = (int)command.ExecuteScalar();

                    lblWorkOrderNotPublished.Text = Convert.ToString(WrokorderNotPublished) + "/" + lbltotatWorkOrdercount.Text;

                    decimal TotalWrokorderNotPublished = Convert.ToDecimal((WrokorderNotPublished / TotaWorkOrderCount) * 100);
                    decimal totalWrokorderNotPublished = decimal.Round(TotalWrokorderNotPublished, 1);
                    lblPercentWorkOrderNotPublished.Text = Convert.ToString(totalWrokorderNotPublished) + "%";

                    ProgressWorkOrderNotPublished.Style.Add("width", lblPercentWorkOrderNotPublished.Text);
                }

                //-------------WorkOrderPublished----------------------//

                using (SqlConnection con6 = new SqlConnection(strconnect))
                {
                    con6.Open();
                    SqlCommand command = new SqlCommand("SP_GetWorkOrderPublishedCount", con6);
                    command.CommandType = CommandType.StoredProcedure;
                    int wrokordercanceled = (int)command.ExecuteScalar();

                    lblWorkOrderPublished.Text = Convert.ToString(wrokordercanceled) + "/" + lbltotatWorkOrdercount.Text;

                    decimal TotalTotalWrokorderPublished = Convert.ToDecimal((wrokordercanceled / TotaWorkOrderCount) * 100);
                    decimal totalTotalWrokorderPublished = decimal.Round(TotalTotalWrokorderPublished, 1);
                    lblPercentWorkOrderPublished.Text = Convert.ToString(totalTotalWrokorderPublished) + "%";

                    ProgressWorkOrderPublished.Style.Add("width", lblPercentWorkOrderPublished.Text);
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
                        //lblMessage.Visible = false;..
                        //lblMessage.Text = "Error Details Not Save Successfully";
                    }
                }
            }
        }

        public void EstimateStatusCount()
        {
            try
            {
                //-------------totalEstimateTotal----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateTotalCount", con);
                    command.CommandType = CommandType.StoredProcedure;
                    int totalEstimateTotal = (int)command.ExecuteScalar();

                    lblTotalEstimateCount.Text = Convert.ToString(totalEstimateTotal);
                    //TotalInvoiceCount = totalInvoiceTotal;
                }
                double TotaEstimateCount;
                TotaEstimateCount = Convert.ToDouble(lblTotalEstimateCount.Text);

                //3-------------EstimateNotInvoiced----------------------// 
                using (SqlConnection con7 = new SqlConnection(strconnect))
                {
                    con7.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateToInvoiceNotSendCount", con7);
                    command.CommandType = CommandType.StoredProcedure;
                    int EstimateNotInvoiced = (int)command.ExecuteScalar();

                    lblNotInvoiced.Text = Convert.ToString(EstimateNotInvoiced) + "/" + lblTotalEstimateCount.Text;

                    decimal TotalEstimateNotInvoiced = Convert.ToDecimal((EstimateNotInvoiced / TotaEstimateCount) * 100);
                    decimal totalEstimateNotInvoiced = decimal.Round(TotalEstimateNotInvoiced, 1);
                    lblPersentNotInvoiced.Text = Convert.ToString(totalEstimateNotInvoiced) + "%";

                    ProgressNotInvoiced.Style.Add("width", lblPersentNotInvoiced.Text);
                }

                //2-------------EstimateInvoiced----------------------//
                using (SqlConnection con5 = new SqlConnection(strconnect))
                {
                    con5.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateToInvoiceSendCount", con5);
                    command.CommandType = CommandType.StoredProcedure;
                    int EstimateInvoiced = (int)command.ExecuteScalar();

                    lblInvoiced.Text = Convert.ToString(EstimateInvoiced) + "/" + lblTotalEstimateCount.Text;

                    decimal TotalEstimateNotSend = Convert.ToDecimal((EstimateInvoiced / TotaEstimateCount) * 100);
                    decimal totalEstimateNotSend = decimal.Round(TotalEstimateNotSend, 1);
                    lblpercentInvoiced.Text = Convert.ToString(totalEstimateNotSend) + "%";
                    ProgressInvoiced.Style.Add("width", lblpercentInvoiced.Text);
                }

                //1-------------EstimateNotSend----------------------/
                using (SqlConnection con6 = new SqlConnection(strconnect))
                {
                    con6.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateNOTSendCount", con6);
                    command.CommandType = CommandType.StoredProcedure;
                    int EstimateNotSend = (int)command.ExecuteScalar();

                    lblNotsend.Text = Convert.ToString(EstimateNotSend) + "/" + lblTotalEstimateCount.Text;

                    decimal TotalEstimateNotSend = Convert.ToDecimal((EstimateNotSend / TotaEstimateCount) * 100);
                    decimal totalEstimateNotSend = decimal.Round(TotalEstimateNotSend, 1);
                    lblPersentNotSend.Text = Convert.ToString(totalEstimateNotSend) + "%";

                    ProgressNotSend.Style.Add("width", lblPersentNotSend.Text);
                }

                //4-------------EstimateDraft----------------------//
                using (SqlConnection con8 = new SqlConnection(strconnect))
                {
                    con8.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateDraftCount", con8);
                    command.CommandType = CommandType.StoredProcedure;
                    int EstimateDraft = (int)command.ExecuteScalar();

                    lblDraft.Text = Convert.ToString(EstimateDraft) + "/" + lblTotalEstimateCount.Text;

                    decimal TotalEstimateDraft = Convert.ToDecimal((EstimateDraft / TotaEstimateCount) * 100);
                    decimal totalEstimateDraft = decimal.Round(TotalEstimateDraft, 1);
                    lblPersentDraft.Text = Convert.ToString(totalEstimateDraft) + "%";
                    ProgressDraft.Style.Add("width", lblPersentDraft.Text);
                }

                //5-------------EstimateSend----------------------//
                using (SqlConnection con4 = new SqlConnection(strconnect))
                {
                    con4.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateSendCount", con4);
                    command.CommandType = CommandType.StoredProcedure;
                    int EstimateSend = (int)command.ExecuteScalar();

                    lblSend.Text = Convert.ToString(EstimateSend) + "/" + lblTotalEstimateCount.Text;

                    decimal TotalEstimateSend = Convert.ToDecimal((EstimateSend / TotaEstimateCount) * 100);
                    decimal totalEstimateSend = decimal.Round(TotalEstimateSend, 1);
                    lblPersentSend.Text = Convert.ToString(totalEstimateSend) + "%";

                    ProgressSend.Style.Add("width", lblPersentSend.Text);
                }

                //6-------------EstimateExpired----------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateExpiredCount", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    int EstimateExpired = (int)command.ExecuteScalar();

                    lblExpired.Text = Convert.ToString(EstimateExpired) + "/" + lblTotalEstimateCount.Text;

                    decimal PercentExpired = Convert.ToDecimal((EstimateExpired / TotaEstimateCount) * 100);
                    decimal totalExpired = decimal.Round(PercentExpired, 1);
                    lblPercentExpired.Text = Convert.ToString(totalExpired) + "%";

                    ProgressExpired.Style.Add("width", lblPercentExpired.Text);
                }

                //7-------------EstimateDeclined----------------------//
                using (SqlConnection con3 = new SqlConnection(strconnect))
                {
                    con3.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateDeclinedCount", con3);
                    command.CommandType = CommandType.StoredProcedure;
                    int EstimateDeclined = (int)command.ExecuteScalar();

                    lblEstimateDeclined.Text = Convert.ToString(EstimateDeclined) + "/" + lblTotalEstimateCount.Text;

                    decimal TotalEstimateDeclined = Convert.ToDecimal((EstimateDeclined / TotaEstimateCount) * 100);

                    decimal totalDeclined = decimal.Round(TotalEstimateDeclined, 1);
                    lblPercentEstimateDecline.Text = Convert.ToString(totalDeclined) + "%";

                    ProgressEstimateDecline.Style.Add("width", lblPercentEstimateDecline.Text);
                }

                //8-------------EstimateAccepted----------------------//
                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetEstimateAcceptedCount", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    int AcceptedCount = (int)command.ExecuteScalar();

                    lblEstimateAccepted.Text = Convert.ToString(AcceptedCount) + "/" + lblTotalEstimateCount.Text;

                    decimal TotalEstimateAccepted = Convert.ToDecimal((AcceptedCount / TotaEstimateCount) * 100);
                    decimal totalEstimateAccepted = decimal.Round(TotalEstimateAccepted, 1);
                    lblPercentEstimateAccepted.Text = Convert.ToString(totalEstimateAccepted) + "%";

                    ProgressEstimateAccepted.Style.Add("width", lblPercentEstimateAccepted.Text);
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
        protected void bindInvoiceYear()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_GetInvoiceYear", conn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    if (ds.Tables.Count == 0)
                    {
                        //DataSet is empty                    
                        string Year = Convert.ToString(DateTime.Now.Year);
                        ddlYear.DataSource = ds.Tables[0];
                        ddlYear.DataTextField = Year;
                        ddlYear.DataValueField = Year;
                        ddlYear.DataBind();
                    }
                    else
                    {
                        ddlYear.DataSource = ds.Tables[0];
                        ddlYear.DataTextField = "Year";
                        ddlYear.DataValueField = "Year";
                        ddlYear.DataBind();
                        ddlYear.Items.Insert(0, new ListItem("Select Year", "0"));
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
                cmdex.Parameters.AddWithValue("@CreatedBy", UserName); //Session UserLogIn
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
            finally { }

        }
        public void InvoiceStatusCount()
        {
            try
            {
                //-------------totalInvoiceTotal----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceTotalCount", con);
                    command.CommandType = CommandType.StoredProcedure;
                    int totalInvoiceTotal = (int)command.ExecuteScalar();

                    lblTotalInvoiceCount.Text = Convert.ToString(totalInvoiceTotal);
                    //TotalInvoiceCount = totalInvoiceTotal;
                }
                double TotalInvoiceCount;
                TotalInvoiceCount = Convert.ToDouble(lblTotalInvoiceCount.Text);

                //-------------InvoiceOverdue----------------------//
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    con1.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceOverdueCount", con1);
                    command.CommandType = CommandType.StoredProcedure;
                    int InvoiceOverdue = (int)command.ExecuteScalar();

                    lblInvoiceOverdue.Text = Convert.ToString(InvoiceOverdue) + "/" + lblTotalInvoiceCount.Text;
                    decimal PercentOverDue = Convert.ToDecimal((InvoiceOverdue / TotalInvoiceCount) * 100);
                    decimal totalOverDue = decimal.Round(PercentOverDue, 1);
                    lblPercentOverdue.Text = Convert.ToString(totalOverDue) + "%";
                    ProgressOverdue.Style.Add("width", lblPercentOverdue.Text);
                }

                //-------------InvoiceDraft----------------------//
                using (SqlConnection con2 = new SqlConnection(strconnect))
                {
                    con2.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceDraftCount", con2);
                    command.CommandType = CommandType.StoredProcedure;
                    int InvoiceDraft = (int)command.ExecuteScalar();

                    lblInvoiceDraft.Text = Convert.ToString(InvoiceDraft) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoiceDraft = Convert.ToDecimal((InvoiceDraft / TotalInvoiceCount) * 100);
                    decimal totalDraft = decimal.Round(TotalInvoiceDraft, 1);
                    lblInvoicePercentDraft.Text = Convert.ToString(totalDraft) + "%";

                    ProgressInvoiceDraft.Style.Add("width", lblInvoicePercentDraft.Text);
                }

                //-------------InvoiceUnpaid----------------------//
                using (SqlConnection con3 = new SqlConnection(strconnect))
                {
                    con3.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceUnpaidCount", con3);
                    command.CommandType = CommandType.StoredProcedure;
                    int InvoiceUnpaid = (int)command.ExecuteScalar();

                    lblUnpaid.Text = Convert.ToString(InvoiceUnpaid) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoiceUnpaid = Convert.ToDecimal((InvoiceUnpaid / TotalInvoiceCount) * 100);

                    decimal totalunpaid = decimal.Round(TotalInvoiceUnpaid, 1);
                    lblPercentUnpaid.Text = Convert.ToString(totalunpaid) + "%";

                    ProgressUnpaid.Style.Add("width", lblPercentUnpaid.Text);
                }

                //-------------InvoicePaid----------------------//
                using (SqlConnection con4 = new SqlConnection(strconnect))
                {
                    con4.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoicePaidCount", con4);
                    command.CommandType = CommandType.StoredProcedure;
                    int InvoicePaid = (int)command.ExecuteScalar();

                    lblPaid.Text = Convert.ToString(InvoicePaid) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoicePaid = Convert.ToDecimal((InvoicePaid / TotalInvoiceCount) * 100);

                    decimal totalpaid = decimal.Round(TotalInvoicePaid, 1);
                    lblPercentPaid.Text = Convert.ToString(totalpaid) + "%";

                    ProgressPaid.Style.Add("width", lblPercentPaid.Text);
                }

                //-------------InvoicePartiallyPaid----------------------//
                using (SqlConnection con5 = new SqlConnection(strconnect))
                {
                    con5.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoicePartiallyPaidCount", con5);
                    command.CommandType = CommandType.StoredProcedure;
                    int InvoicePartiallyPaid = (int)command.ExecuteScalar();

                    lblPartiallyPaid.Text = Convert.ToString(InvoicePartiallyPaid) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoicePartiallyPaid = Convert.ToDecimal((InvoicePartiallyPaid / TotalInvoiceCount) * 100);
                    decimal totalPartiallyPaid = decimal.Round(TotalInvoicePartiallyPaid, 1);
                    lblPercentPartiallyPaid.Text = Convert.ToString(totalPartiallyPaid) + "%";

                    ProgressPartiallyPaid.Style.Add("width", lblPercentPartiallyPaid.Text);
                }

                //-------------InvoiceCanceled----------------------//

                using (SqlConnection con6 = new SqlConnection(strconnect))
                {
                    con6.Open();
                    SqlCommand command = new SqlCommand("SP_GetInvoiceCancelledCount", con6);
                    command.CommandType = CommandType.StoredProcedure;
                    int InvoiceCanceled = (int)command.ExecuteScalar();

                    lblInvoiceCancele.Text = Convert.ToString(InvoiceCanceled) + "/" + lblTotalInvoiceCount.Text;

                    decimal TotalInvoiceCancele = Convert.ToDecimal((InvoiceCanceled / TotalInvoiceCount) * 100);
                    decimal totalCancele = decimal.Round(TotalInvoiceCancele, 1);
                    lblPercentInvoiceCancele.Text = Convert.ToString(totalCancele) + "%";
                    ProgressInvoiceCancele.Style.Add("width", lblPercentPartiallyPaid.Text);
                }

                //---------------OverdueAmount Invoice Amount----------------------//
                using (SqlConnection conOver = new SqlConnection(strconnect))
                {
                    conOver.Open();
                    SqlCommand commandOver = new SqlCommand("SP_GetInvoiceOverdueAmount", conOver);
                    commandOver.CommandType = CommandType.StoredProcedure;
                    string totalInvoiceOverdueAmount = (string)commandOver.ExecuteScalar();

                    if (totalInvoiceOverdueAmount == null)
                    {
                        lbl_Past_Due_Invoice.Text = "₹" + Convert.ToString("00.00");
                    }
                    else
                    {
                        lbl_Past_Due_Invoice.Text = Convert.ToString(totalInvoiceOverdueAmount);
                    }

                }

                //---------------OutStanding Invoice Amount----------------------//
                using (SqlConnection const1 = new SqlConnection(strconnect))
                {
                    const1.Open();
                    SqlCommand commandst = new SqlCommand("SP_GetInvoiceOutStandingAmount", const1);
                    commandst.CommandType = CommandType.StoredProcedure;
                    string totalInvoiceOutStAmount = (string)commandst.ExecuteScalar();

                    if (totalInvoiceOutStAmount == null)
                    {
                        lbl_Outstanding_Invoice.Text = "₹" + Convert.ToString("0");
                    }
                    else
                    {
                        lbl_Outstanding_Invoice.Text = Convert.ToString(totalInvoiceOutStAmount);
                    }
                }

                //---------------PAID Invoice Amount----------------------//
                using (SqlConnection conpaid = new SqlConnection(strconnect))
                {
                    conpaid.Open();
                    SqlCommand commandpaid = new SqlCommand("SP_GetInvoicePaidAmount", conpaid);
                    commandpaid.CommandType = CommandType.StoredProcedure;
                    string totalInvoicepaid = (string)commandpaid.ExecuteScalar();

                    if (totalInvoicepaid == null)
                    {
                        lbl_Paid_Invoice.Text = "₹" + Convert.ToString("0");
                    }
                    else
                    {
                        lbl_Paid_Invoice.Text = Convert.ToString(totalInvoicepaid);
                    }

                }


                //---------------Wating Payment Invoice Amount----------------------//
                using (SqlConnection conpaid = new SqlConnection(strconnect))
                {
                    conpaid.Open();
                    SqlCommand commandpaid = new SqlCommand("SP_GetCountInvoiceWating", conpaid);
                    commandpaid.CommandType = CommandType.StoredProcedure;
                    int totalInvoiceWating = (int)commandpaid.ExecuteScalar();

                    decimal TotalInvoiceWating = Convert.ToDecimal((totalInvoiceWating / TotalInvoiceCount) * 100);
                    decimal totalWating1 = decimal.Round(TotalInvoiceWating, 1);
                    lblinvWatingPer.Text = Convert.ToString(totalWating1) + "%";
                    DivInvoiceWati.Style.Add("width", lblinvWatingPer.Text);

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
                DeptID = Session["DeptID"].ToString();

                string View, Create, Edit, Delete, Globalview;
                //-------------Permission Modules----------------------//
                using (SqlConnection con = new SqlConnection(strconnect))
                {
                    SqlCommand command = new SqlCommand("SP_ViewWebPagesPemissionByStaffID", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StaffID", UserId);
                    command.Parameters.AddWithValue("@SubModule", "DASHBOARD");
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
                            showdashboard.Visible = true;
                            NotSHowPages.Visible = false;
                            bindProject();

                            //ViewUnfinsheddashDetails();
                            ViewUnfinsheddashDetailsEmpID(UserId);
                            ViewACtivityDetails();
                            BindBarChartOfProject();
                            MultilineChartOfProject();
                            bindInvoiceYear();
                            ProjectStatusCount();
                            InvoiceStatusCount();
                            EstimateStatusCount();
                            TaskStatusCount();
                            WorkOrderStatusCount();
                            ViewAnnouncementDetails();

                            //----------------------------------//
                            ViewTaskDetails();
                            ViewProjetctDetails();
                            ViewWorkorderDetails();
                            ViewTicketDetails();
                            //----------------------------------//
                            BindInvoicechart();
                            BindTaskchart();
                            BindPaymentchart();
                            BindWorkOrderchart();
                            //---------------------------------//
                            GetDeptDetails();
                            bindDepartment();
                            ViewDashBoardSetting();
                            ViewDashBoardDiv();

                            if (Create == "True")
                            {
                                //addnew.Visible = true;
                            }
                            else
                            {
                                //addnew.Visible = false;
                            }

                            if (Edit == "True")
                            {

                                //GridProject.Columns[8].Visible = true;
                            }
                            else
                            {

                                //GridProject.Columns[8].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                //GridProject.Columns[9].Visible = true;
                            }
                            else
                            {

                                //GridProject.Columns[9].Visible = false;
                            }
                        }
                        else if (View == "True")
                        {
                            showdashboard.Visible = true;
                            NotSHowPages.Visible = false;

                            bindProjectByEmpID(UserId);
                            ViewUnfinsheddashDetailsEmpID(UserId);
                            ViewActivityDetailsByEMPID(UserId);
                            BindBarChartOfProjectEmpID(UserId);
                            MultilineChartOfProjectByEmpID(UserId);
                            bindInvoiceYear();

                            ProjectCountByEmpID(UserId);
                            InvoiceStatusCountByEmpID(UserId);
                            EstimateStatusCountByEmpID(UserId);
                            TaskStatusCountByEmpID(UserId);
                            WorkOrderStatusCountByEmpID(UserId);
                            ViewAnnouncementDetails();

                            ViewWorkorderDetailsByEmpID(UserId);
                            ViewTicketDetailsEmpID(UserId);
                            ////----------------------------------//
                            ViewTaskDetailsEmpID(UserId);
                            ViewProjetctDetailsByEmpID(UserId);
                            //------------------------------------//
                            //----------------------------------//
                            BindInvoicechart();
                            BindTaskchart();
                            BindPaymentchart();
                            BindWorkOrderchart();
                            //--------------------------------------//
                            GetDeptDetails();
                            bindDepartment();
                            ViewDashBoardSetting();
                            ViewDashBoardDiv();
                          

                            if (Create == "True")
                            {
                                //addnew.Visible = true;
                            }
                            else
                            {
                                //addnew.Visible = false;
                            }

                            if (Edit == "True")
                            {

                                // GridProject.Columns[8].Visible = true;
                            }
                            else
                            {

                                // GridProject.Columns[8].Visible = false;
                            }

                            if (Delete == "True")
                            {

                                // GridProject.Columns[9].Visible = true;
                            }
                            else
                            {

                                //GridProject.Columns[9].Visible = false;
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

        #region " Events "
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
                        Permission = Session["Permission"].ToString();
                        DeptID = Session["DeptID"].ToString();

                        if (!IsPostBack)
                        {
                            showdashboard.Visible = true;
                            NotSHowPages.Visible = false;
                            bindProject();

                            //ViewUnfinsheddashDetails();
                            ViewUnfinsheddashDetailsEmpID(UserId);
                            ViewACtivityDetails();
                            BindBarChartOfProject();
                            MultilineChartOfProject();
                            bindInvoiceYear();
                            ProjectStatusCount();
                            InvoiceStatusCount();
                            EstimateStatusCount();
                            TaskStatusCount();
                            WorkOrderStatusCount();
                            ViewAnnouncementDetails();

                            //----------------------------------//
                            ViewTaskDetails();
                            ViewProjetctDetails();
                            ViewWorkorderDetails();
                            ViewTicketDetails();
                            //----------------------------------//
                            BindInvoicechart();
                            BindTaskchart();
                            BindPaymentchart();
                            BindWorkOrderchart();
                            //------------------------------------//
                            ViewDashBoardSetting();
                            //ViewDashBoardDiv();
                            GetDeptDetails();
                            bindDepartment();

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
                                //showdashboard.Visible = true;
                                //NotSHowPages.Visible = false;

                                
                            }
                        }
                        else
                        {
                            showdashboard.Visible = false;
                            NotSHowPages.Visible = true;
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
                    DeviceCon.Close();
                }
            }
        }


        protected void lnkNewAnnoucement_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/New_Annoucement.aspx");
        }

        protected void ChBoxfinished_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Boolean chk;
                string ToDoID;
                var rows = GridTododash.Rows;
                CheckBox btn = (CheckBox)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ToDoID = ((Label)rows[rowindex].FindControl("lbltodo_items_id1")).Text;
                chk = ((CheckBox)rows[rowindex].FindControl("ChBoxTodo")).Checked;

                SqlConnection con = new SqlConnection(strconnect);
                SqlCommand cmd = new SqlCommand("SP_UPDATEFinishedTODO", con);
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@todo_items_id", ToDoID);
                cmd.Parameters.AddWithValue("@staff_id", UserId);
                cmd.Parameters.AddWithValue("@finished", chk);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@updateby", UserName);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i < 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('ToDo item unfinshed!')", true);

                    ViewUnfinsheddashDetails();
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('ToDo Not Completed Details Not Save Successfully!')", true);
                }

                con.Close();
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



        protected void lnkbtnname_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string tableID;
                var rows = GridAnnouncement.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                tableID = ((Label)rows[rowindex].FindControl("lblAnnouncementID")).Text;
                Response.Redirect("~/DisplayAnnouncement.aspx?ID=" + tableID + "", false);
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

        protected void lnkviewAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Announcement.aspx");
        }

        //---------------------------------------------------------------------------------------------------//
        //   TASK DETAILS ON DASHBOARD
        //---------------------------------------------------------------------------------------------------//
        protected void btnDeleteTask_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string task;
                var rows = GridTask.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;

                SqlCommand cmd = new SqlCommand("SP_DeleteTaskbyTaskname", DeviceCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Subject", task);
                cmd.Parameters.AddWithValue("@Createby", UserName);
                cmd.Parameters.AddWithValue("@EmpID", UserId);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                DeviceCon.Open();
                int i = cmd.ExecuteNonQuery();
                DeviceCon.Close();
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Task Details Deleted Successfully!')", true);
                GridTask.EditIndex = -1;
                ViewTaskDetails();

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
            finally { }
        }

        protected void btnEditTask_Click(object sender, EventArgs e)
        {
            try
            {
                string task;
                var rows = GridTask.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;
                Response.Redirect("~/EditStaffTask.aspx?task=" + task + "", false);
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

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void linkbtnPDFTask_Click(object sender, EventArgs e)
        {
            try
            {
                GetCompanyAddress();
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    int _totalColumns = 10;
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(_totalColumns);
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;

                    Document _document = new Document(PageSize.A4, 0, 0, 0, 0);
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
                        _document.Open();
                        _pdfPTable.SetWidths(new float[] { 3f, 12f, 10f, 10f, 10f, 12f, 8f, 6f, 7f, 8f });
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 10;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPTable.AddCell(cell);
                        //.....image logo.....// 
                        phrase = new Phrase();
                        phrase.Add(new Chunk(lbladdCompany11.Text + "\n", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lbladdress11.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCity1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddDistrict1.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddState1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        _pdfPCell = new PdfPCell(phrase);
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.BorderColor = BaseColor.WHITE;
                        _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.PaddingBottom = 1f;
                        _pdfPCell.PaddingTop = 0f;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("TaskStaffList", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //----------------------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 4;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*------------------------------------", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = ViewTaskDetails();
                        #region "Table Header"
                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);


                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Subject", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StartDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("DueDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("AssignTo", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("TaskStatus", _fontStyle));
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

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Reapet", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);//Billable
                        _pdfPCell = new PdfPCell(new Phrase("Priority", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);//Billable
                        _pdfPCell = new PdfPCell(new Phrase("Billable", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["Subject"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Start_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Due_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            DataTable taskassign = GetStaffnamebytaskname(row["Subject"].ToString());
                            Phrase Pharse1 = new Phrase();
                            foreach (DataRow Rowassign in taskassign.Rows)
                            {

                                Pharse1.Add(new Chunk(Rowassign["AssignTo"].ToString() + ",", _fontStyle));


                            }

                            _pdfPCell = new PdfPCell(Pharse1);
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);


                            _pdfPCell = new PdfPCell(new Phrase(row["TaskStatus"].ToString(), _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["Reapet_Every"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Priority"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Billable"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("TaskStaffList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
                    int _totalColumns = 10;
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(_totalColumns);
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;

                    Document _document = new Document(PageSize.A4, 0, 0, 0, 0);
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
                        _document.Open();
                        _pdfPTable.SetWidths(new float[] { 3f, 12f, 10f, 10f, 10f, 12f, 8f, 6f, 7f, 8f });
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 10;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPTable.AddCell(cell);
                        //.....image logo.....// 
                        phrase = new Phrase();
                        phrase.Add(new Chunk(lbladdCompany11.Text + "\n", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lbladdress11.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCity1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddDistrict1.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddState1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk(lblcompanyaddCountry1.Text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("Pin:" + lblcompanyaddZIPCode11.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        phrase.Add(new Chunk("MobileNo:" + lblphoneNo1.Text + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                        _pdfPCell = new PdfPCell(phrase);
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.BorderColor = BaseColor.WHITE;
                        _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.PaddingBottom = 1f;
                        _pdfPCell.PaddingTop = 0f;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("TaskStaffList", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //----------------------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 4;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*------------------------------------", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = (DataTable)ViewState["TaskDATA"];
                        #region "Table Header"
                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);


                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Subject", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StartDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("DueDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("AssignTo", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("TaskStatus", _fontStyle));
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

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Reapet", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);//Billable
                        _pdfPCell = new PdfPCell(new Phrase("Priority", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);//Billable
                        _pdfPCell = new PdfPCell(new Phrase("Billable", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["Subject"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Start_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Due_Date"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            DataTable taskassign = GetStaffnamebytaskname(row["Subject"].ToString());
                            Phrase Pharse1 = new Phrase();
                            foreach (DataRow Rowassign in taskassign.Rows)
                            {

                                Pharse1.Add(new Chunk(Rowassign["AssignTo"].ToString() + ",", _fontStyle));


                            }

                            _pdfPCell = new PdfPCell(Pharse1);
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);


                            _pdfPCell = new PdfPCell(new Phrase(row["TaskStatus"].ToString(), _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["Reapet_Every"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Priority"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Billable"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("TaskStaffList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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

        protected void linkbtnExcelTask_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "TaskDetails " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    using (StringWriter sw = new StringWriter())
                    {
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        //To Export all pages
                        GridTask.AllowPaging = false;
                        DataTable dt = (DataTable)ViewState["TaskDATA"];
                        DataTable dt2 = new DataTable();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            dt2.Columns.Add(dt.Columns[i].ColumnName, typeof(string));
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt2.ImportRow(dt.Rows[i]);

                        }
                        this.GridTask.DataSource = dt2;
                        this.GridTask.DataBind();
                        GridTask.HeaderRow.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in GridTask.HeaderRow.Cells)
                        {
                            cell.BackColor = GridTask.HeaderStyle.BackColor;
                        }
                        foreach (GridViewRow row in GridTask.Rows)
                        {
                            row.BackColor = System.Drawing.Color.White;
                            foreach (TableCell cell in row.Cells)
                            {
                                if (row.RowIndex % 2 == 0)
                                {
                                    cell.BackColor = GridTask.AlternatingRowStyle.BackColor;
                                }
                                else
                                {
                                    cell.BackColor = GridTask.RowStyle.BackColor;
                                }
                                cell.CssClass = "textmode";
                            }
                        }
                        GridTask.RenderControl(hw);
                        //style to format numbers to string
                        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                        Response.Write(style);
                        Response.Output.Write(sw.ToString());
                        Response.Flush();
                        Response.End();
                    }
                }
                else if (RoleType == Designation)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "TaskDetails " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    using (StringWriter sw = new StringWriter())
                    {
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        //To Export all pages
                        GridTask.AllowPaging = false;
                        DataTable dt = (DataTable)ViewState["TaskDATA"];
                        DataTable dt2 = new DataTable();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            dt2.Columns.Add(dt.Columns[i].ColumnName, typeof(string));
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt2.ImportRow(dt.Rows[i]);

                        }
                        this.GridTask.DataSource = dt2;
                        this.GridTask.DataBind();
                        GridTask.HeaderRow.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in GridTask.HeaderRow.Cells)
                        {
                            cell.BackColor = GridTask.HeaderStyle.BackColor;
                        }
                        foreach (GridViewRow row in GridTask.Rows)
                        {
                            row.BackColor = System.Drawing.Color.White;
                            foreach (TableCell cell in row.Cells)
                            {
                                if (row.RowIndex % 2 == 0)
                                {
                                    cell.BackColor = GridTask.AlternatingRowStyle.BackColor;
                                }
                                else
                                {
                                    cell.BackColor = GridTask.RowStyle.BackColor;
                                }
                                cell.CssClass = "textmode";
                            }
                        }
                        GridTask.RenderControl(hw);
                        //style to format numbers to string
                        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                        Response.Write(style);
                        Response.Output.Write(sw.ToString());
                        Response.Flush();
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

        protected void btnVisibilityTask_Click(object sender, EventArgs e)
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
                        using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewTaskStatus", con))
                        {
                            ad.Fill(table);
                            GridTask.DataSource = table;
                            GridTask.DataBind();
                        }
                    }
                    //return table;
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

        protected void btnReloadTask_Click1(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    ViewTaskDetails();
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

        protected void GridTask_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridTask.Rows)
                {
                    //---------------Status-------------------------------///
                    string Status = ((Button)gridviedrow.FindControl("btnStatus")).Text;
                    Button btnStatusAssign = (Button)gridviedrow.FindControl("btnStatus");

                    Label lbltaskName1 = (Label)gridviedrow.FindControl("lbltaskName1");
                    Label lblStart_Date1 = (Label)gridviedrow.FindControl("lblStart_Date1");
                    Label lblDue_Date1 = (Label)gridviedrow.FindControl("lblDue_Date1");
                    Label lblTaskStatus1 = (Label)gridviedrow.FindControl("lblTaskStatus1");
                    DropDownList ddlTaskStatus1 = (DropDownList)gridviedrow.FindControl("ddlTaskStatus");

                    ddlTaskStatus1.SelectedItem.Text = lblTaskStatus1.Text;
                    Label lblstatus1 = (Label)gridviedrow.FindControl("lblstatus1");

                    Label lblReapet_Every1 = (Label)gridviedrow.FindControl("lblReapet_Every1");

                    Label lblPriority1 = (Label)gridviedrow.FindControl("lblPriority1");
                    DropDownList ddlPriority1 = (DropDownList)gridviedrow.FindControl("ddlPriority");
                    ddlPriority1.SelectedItem.Text = lblPriority1.Text;

                    Label lblBillable1 = (Label)gridviedrow.FindControl("lblBillable1");
                    LinkButton btnDeleteTask = (LinkButton)gridviedrow.FindControl("btnDeleteTask");
                    System.Web.UI.WebControls.Image Img1 = (System.Web.UI.WebControls.Image)gridviedrow.FindControl("img1");

                    //////////////////////////////////////////////////////////////////////////////////////////


                    BulletedList bulletListRelatedTo = (BulletedList)gridviedrow.FindControl("bulletlist1");

                    string task = lbltaskName1.Text;

                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    if (Status.Equals("True"))
                    {
                        btnStatusAssign.Text = "True";
                        btnStatusAssign.CssClass = "btn btn-outline-success";
                        lbltaskName1.ForeColor = System.Drawing.Color.Blue;
                        lblStart_Date1.ForeColor = System.Drawing.Color.Blue;
                        lblDue_Date1.ForeColor = System.Drawing.Color.Blue;
                        //lblReletd_To1.ForeColor = Color.Blue;
                        lblstatus1.ForeColor = System.Drawing.Color.Blue;
                        lblReapet_Every1.ForeColor = System.Drawing.Color.Blue;

                        lblBillable1.ForeColor = System.Drawing.Color.Blue;


                        DataTable table = GetStaffnamebytaskname(task);

                        bulletListRelatedTo.DataSource = table;
                        bulletListRelatedTo.DataTextField = "AssignTo";
                        bulletListRelatedTo.DataValueField = "AssignTo";
                        bulletListRelatedTo.DataBind();
                    }
                    else
                    {
                        btnDeleteTask.Visible = false;
                        btnStatusAssign.Text = "False";
                        btnStatusAssign.CssClass = "btn  btn-outline-dark";
                        lbltaskName1.ForeColor = System.Drawing.Color.Red;
                        lblStart_Date1.ForeColor = System.Drawing.Color.Red;
                        lblDue_Date1.ForeColor = System.Drawing.Color.Red;
                        lblstatus1.ForeColor = System.Drawing.Color.Red;
                        lblReapet_Every1.ForeColor = System.Drawing.Color.Red;
                        lblBillable1.ForeColor = System.Drawing.Color.Red;

                        using (SqlConnection con = new SqlConnection(strconnect))
                        {
                            SqlCommand sqlCommand = new SqlCommand("[SP_ViewTaskInActiveStatus]", con);//storeprocedure madhe status 0
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@Subject", task);

                            SqlDataAdapter ad = new SqlDataAdapter(sqlCommand);
                            DataTable dt = new DataTable();
                            ad.Fill(dt);

                            bulletListRelatedTo.DataSource = dt;
                            bulletListRelatedTo.DataTextField = "AssignTo";
                            bulletListRelatedTo.DataValueField = "AssignTo";
                            bulletListRelatedTo.DataBind();

                        }
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

        protected void ddlPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    string PriorityTo, ddlPriority1, task;

                    var rows = GridTask.Rows;
                    DropDownList btn = (DropDownList)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;
                    PriorityTo = ((Label)rows[rowindex].FindControl("lblPriority1")).Text;
                    ddlPriority1 = ((DropDownList)rows[rowindex].FindControl("ddlPriority")).SelectedItem.Text;

                    using (SqlConnection sqlConnection = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_UpdateTaskPriority", sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Subject", task);
                        cmd.Parameters.AddWithValue("@Priority", ddlPriority1);
                        cmd.Parameters.AddWithValue("@Updateby", UserName); // Use SelectedValue
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        sqlConnection.Open();
                        int Result = cmd.ExecuteNonQuery();
                        sqlConnection.Close();
                        if (Result < 0)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Task Priority Update Successfully!')", true);

                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Task Priority Not Update Successfully!')", true);

                        }
                    }
                }
                else if (RoleType == Designation)
                {
                    string PriorityTo, ddlPriority1, task;

                    var rows = GridTask.Rows;
                    DropDownList btn = (DropDownList)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;
                    PriorityTo = ((Label)rows[rowindex].FindControl("lblPriority1")).Text;
                    ddlPriority1 = ((DropDownList)rows[rowindex].FindControl("ddlPriority")).SelectedItem.Text;

                    using (SqlConnection sqlConnection = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_UpdateTaskPriority", sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Subject", task);
                        cmd.Parameters.AddWithValue("@Priority", ddlPriority1);
                        cmd.Parameters.AddWithValue("@Updateby", UserName); // Use SelectedValue
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        sqlConnection.Open();
                        int Result = cmd.ExecuteNonQuery();
                        sqlConnection.Close();
                        if (Result < 0)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Task Priority Update Successfully!')", true);
                            StaffOperationPermission();
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Task Priority Not Update Successfully!')", true);

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

        protected void ddlTaskStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    string TaskStatus1, ddlTaskStatus1, task;

                    var rows = GridTask.Rows;
                    DropDownList btn = (DropDownList)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;
                    TaskStatus1 = ((Label)rows[rowindex].FindControl("lblTaskStatus1")).Text;
                    ddlTaskStatus1 = ((DropDownList)rows[rowindex].FindControl("ddlTaskStatus")).SelectedItem.Text;

                    using (SqlConnection conn = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_UpdateTaskStaffStatus", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Subject", task);
                        cmd.Parameters.AddWithValue("@TaskStatus", ddlTaskStatus1);
                        cmd.Parameters.AddWithValue("@Updateby", UserName); // Use SelectedValue
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        conn.Open();
                        int Result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (Result < 0)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Task Status Update Successfully!')", true);

                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Task Status Not Update Successfully!')", true);

                        }
                    }
                }
                else if (RoleType == Designation)
                {
                    string TaskStatus1, ddlTaskStatus1, task;

                    var rows = GridTask.Rows;
                    DropDownList btn = (DropDownList)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    task = ((Label)rows[rowindex].FindControl("lbltaskName1")).Text;
                    TaskStatus1 = ((Label)rows[rowindex].FindControl("lblTaskStatus1")).Text;
                    ddlTaskStatus1 = ((DropDownList)rows[rowindex].FindControl("ddlTaskStatus")).SelectedItem.Text;

                    using (SqlConnection conn = new SqlConnection(strconnect))
                    {
                        SqlCommand cmd = new SqlCommand("SP_UpdateTaskStaffStatus", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Subject", task);
                        cmd.Parameters.AddWithValue("@TaskStatus", ddlTaskStatus1);
                        cmd.Parameters.AddWithValue("@Updateby", UserName); // Use SelectedValue
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        conn.Open();
                        int Result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (Result < 0)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Task Status Update Successfully!')", true);
                            StaffOperationPermission();
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Task Status Not Update Successfully!')", true);

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


        //---------------------------------------------------------------------------------------------------//
        //   Project DETAILS ON DASHBOARD
        //---------------------------------------------------------------------------------------------------//
        protected void LinkbtnProjectName1_Click(object sender, EventArgs e)
        {
            try
            {
                string ID;
                var rows = GridProject.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;
                Response.Redirect("~/Project_Overview.aspx?ID=" + ID + "", false);
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

        protected void GridProject_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridProject.Rows)
                {

                    Button Status = (Button)gridviedrow.FindControl("btnStatus");
                    Label lblID1 = (Label)gridviedrow.FindControl("lblID1");
                    LinkButton LinkbtnProjectName1 = (LinkButton)gridviedrow.FindControl("LinkbtnProjectName1");
                    Label lblStart_Date1 = (Label)gridviedrow.FindControl("lblStart_Date1");
                    Label lblDeadline1 = (Label)gridviedrow.FindControl("lblDeadline1");
                    Label lblSClientName1 = (Label)gridviedrow.FindControl("lblSClientName1");
                    Label lblstatus1 = (Label)gridviedrow.FindControl("lblstatus1");

                    BulletedList bulletlistMember = (BulletedList)gridviedrow.FindControl("bulletlistMember");

                    string ProjectID = lblID1.Text;
                    string Stat1 = lblstatus1.Text;
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    if (Stat1 == "True")
                    {

                        lblID1.ForeColor = Color.Blue;
                        //lblStart_Date1.ForeColor = Color.Blue;
                        //lblDeadline1.ForeColor = Color.Blue;
                        lblSClientName1.ForeColor = Color.Blue;
                        LinkbtnProjectName1.ForeColor = Color.Blue;
                        lblstatus1.ForeColor = Color.Blue;

                        DataTable table = GetStaffnamebyProjectname(ProjectID);

                        bulletlistMember.DataSource = table;
                        bulletlistMember.DataTextField = "First_Name";
                        bulletlistMember.DataValueField = "First_Name";
                        bulletlistMember.DataBind();
                    }
                    else
                    {
                        lblID1.ForeColor = Color.Red;
                        lblStart_Date1.ForeColor = Color.Red;
                        lblDeadline1.ForeColor = Color.Red;
                        lblSClientName1.ForeColor = Color.Red;
                        LinkbtnProjectName1.ForeColor = Color.Red;
                        lblstatus1.ForeColor = Color.Red;

                        DataTable table = GetStaffnamebyProjectname(ProjectID);

                        bulletlistMember.DataSource = table;
                        bulletlistMember.DataTextField = "First_Name";
                        bulletlistMember.DataValueField = "First_Name";
                        bulletlistMember.DataBind();

                        bulletlistMember.ForeColor = Color.Red;
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

        protected void btn_VisibilityProject_Click(object sender, EventArgs e)
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
                        using (SqlDataAdapter ad = new SqlDataAdapter("SP_ProjectVisibilityDetails", con))
                        {
                            ad.Fill(table);
                            GridProject.DataSource = table;
                            GridProject.DataBind();
                        }
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

        protected void BtnReloadProject_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    ViewProjetctDetails();
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

        protected void btnEditProject_Click(object sender, EventArgs e)
        {
            try
            {
                string ID;
                var rows = GridProject.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;
                Response.Redirect("~/EditProjectDetails.aspx?ID=" + ID + "", false);
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

        protected void btnDeleteProjetct_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    DeviceCon = new SqlConnection(strconnect);
                    string tableID;
                    var rows = GridProject.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    tableID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                    SqlCommand cmd = new SqlCommand("SP_DeleteProjects", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Projectid", tableID);
                    cmd.Parameters.AddWithValue("@updateby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Project Details Deleted Successfully!')", true);
                    GridProject.EditIndex = -1;
                    ViewProjetctDetails();
                    ProjectStatusCount();
                }
                else if (RoleType == Designation)
                {
                    DeviceCon = new SqlConnection(strconnect);
                    string tableID;
                    var rows = GridProject.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    tableID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                    SqlCommand cmd = new SqlCommand("SP_DeleteProjectsForEmpID", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Projectid", tableID);
                    cmd.Parameters.AddWithValue("@updateby", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Project Details Deleted Successfully!')", true);
                    GridProject.EditIndex = -1;

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
            finally { }
        }

        protected void linkbtnProjectExcel_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    DataTable dt = ViewProjetctDetails();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Project_Details " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));

                        Response.Charset = " ";

                        // Create a new DataTable with only the desired columns
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("ProjectName");
                        dtExport.Columns.Add("Description");
                        dtExport.Columns.Add("StatusName");
                        dtExport.Columns.Add("ClientName");
                        dtExport.Columns.Add("billing_type");
                        dtExport.Columns.Add("Start_Date");
                        dtExport.Columns.Add("Deadline");
                        dtExport.Columns.Add("Addedfrom");
                        dtExport.Columns.Add("Project_CreatedDate");

                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["ID"];
                            newRow["ProjectName"] = row["ProjectName"];
                            newRow["Description"] = row["Description"];
                            newRow["StatusName"] = row["StatusName"];
                            newRow["ClientName"] = row["ClientName"];
                            newRow["billing_type"] = row["billing_type"];
                            newRow["Start_Date"] = row["Start_Date"];
                            newRow["Deadline"] = row["Deadline"];
                            newRow["Addedfrom"] = row["Addedfrom"];
                            newRow["Project_CreatedDate"] = row["Project_CreatedDate"];
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
                    DataTable dt = (DataTable)ViewState["ProjectData"];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Project_Details " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));

                        Response.Charset = " ";

                        // Create a new DataTable with only the desired columns
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("ProjectName");
                        dtExport.Columns.Add("Description");
                        dtExport.Columns.Add("StatusName");
                        dtExport.Columns.Add("ClientName");
                        dtExport.Columns.Add("billing_type");
                        dtExport.Columns.Add("Start_Date");
                        dtExport.Columns.Add("Deadline");
                        dtExport.Columns.Add("Addedfrom");
                        dtExport.Columns.Add("Project_CreatedDate");

                        // Copy the data from the original DataTable to the export DataTable
                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["ID"];
                            newRow["ProjectName"] = row["ProjectName"];
                            newRow["Description"] = row["Description"];
                            newRow["StatusName"] = row["StatusName"];
                            newRow["ClientName"] = row["ClientName"];
                            newRow["billing_type"] = row["billing_type"];
                            newRow["Start_Date"] = row["Start_Date"];
                            newRow["Deadline"] = row["Deadline"];
                            newRow["Addedfrom"] = row["Addedfrom"];
                            newRow["Project_CreatedDate"] = row["Project_CreatedDate"];
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

        protected void linkbtnProjectPDF_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    int _totalColumns = 11;//
                    string path = Image1.ImageUrl;

                    //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(11);//change
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;


                    Document _document = new Document(PageSize.A4, 0, 0, 0, 0);
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
                        _pdfPTable.SetWidths(new float[] { 4f, 9f, 11f, 12f, 10f, 9f, 12f, 10f, 10f, 9f, 8f });//column width in doc       
                                                                                                               //----Header PDF--------------------------//
                                                                                                               //Company Logo
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 3;
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
                        _pdfPCell.Colspan = 11;
                        _pdfPCell.BorderColor = BaseColor.WHITE;
                        _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.PaddingBottom = 1f;
                        _pdfPCell.PaddingTop = 0f;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                        _pdfPCell.Colspan = 11;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Projectlist", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //-------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 5;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();


                        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*-------------------------------------", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = ProjectDetailReport();
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Project", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Customer", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        //_fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        //_pdfPCell = new PdfPCell(new Phrase("CustType", _fontStyle));
                        //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        //_pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //_pdfPCell.BackgroundColor = BaseColor.GRAY;
                        //_pdfPCell.ExtraParagraphSpace = 2;
                        //_pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StartDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("DueDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Duration", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ProcurementCost", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ServiceCost", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ProjectCost", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Address", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["ProjectName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["ClientName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            // _pdfPCell = new PdfPCell(new Phrase(row["Cust_Type"].ToString(), _fontStyle));
                            //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            //_pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
                            //_pdfPCell.ExtraParagraphSpace = 1;
                            //_pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["StartDate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Deadline"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["TotalDuration"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["TotalProcurementCost"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["TotalServiceCost"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["TotalProjectCost"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Address"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["StatusName"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("Projectlist_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
                    int _totalColumns = 11;//
                    string path = Image1.ImageUrl;

                    //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(11);//change
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;


                    Document _document = new Document(PageSize.A4, 0, 0, 0, 0);
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
                        _pdfPTable.SetWidths(new float[] { 4f, 9f, 11f, 12f, 10f, 9f, 12f, 10f, 10f, 9f, 8f });//column width in doc       
                                                                                                               //----Header PDF--------------------------//
                                                                                                               //Company Logo
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 3;
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
                        _pdfPCell.Colspan = 11;
                        _pdfPCell.BorderColor = BaseColor.WHITE;
                        _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.PaddingBottom = 1f;
                        _pdfPCell.PaddingTop = 0f;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                        _pdfPCell.Colspan = 11;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Projectlist", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //-------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 5;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();


                        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*-------------------------------------", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = (DataTable)ViewState["ProjectData"];
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Project", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Customer", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        //_fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        //_pdfPCell = new PdfPCell(new Phrase("CustType", _fontStyle));
                        //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        //_pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //_pdfPCell.BackgroundColor = BaseColor.GRAY;
                        //_pdfPCell.ExtraParagraphSpace = 2;
                        //_pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StartDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("DueDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Duration", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ProcurementCost", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ServiceCost", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ProjectCost", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Address", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["ProjectName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["ClientName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            // _pdfPCell = new PdfPCell(new Phrase(row["Cust_Type"].ToString(), _fontStyle));
                            //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            //_pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
                            //_pdfPCell.ExtraParagraphSpace = 1;
                            //_pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["StartDate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Deadline"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["TotalDuration"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["TotalProcurementCost"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["TotalServiceCost"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["TotalProjectCost"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Address"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["StatusName"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("Projectlist_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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

        //---------------------------------------------------------------------------------------
        // Filter Year Invoice
        //--------------------------------------------------------------------------------------
        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                //using (SqlConnection UserCon = new SqlConnection(strconnect))
                //{
                //    SqlCommand cmd = new SqlCommand("SP_ShowFilterInvoiceDetailsByYear", UserCon);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@ByYear", Convert.ToInt32(ddlYear.SelectedItem.Text));
                //    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                //    ad.Fill(table);
                //    GridInvoice.DataSource = table;
                //    GridInvoice.DataBind();
                //}

                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("ShowInvoiceAmountByYear", con1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ByYear", Convert.ToInt32(ddlYear.SelectedItem.Text));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string Paid = Convert.ToString(dt.Rows[0]["PaidAmount"]);
                        string UnPaid = Convert.ToString(dt.Rows[0]["UnpaidPaidAmount"]);
                        string OverDue = Convert.ToString(dt.Rows[0]["OverdueAmount"]);

                        if (Paid == "")
                        {
                            lbl_Paid_Invoice.Text = Convert.ToString("₹ ") + "0.0";
                        }
                        else
                        {
                            lbl_Paid_Invoice.Text = Convert.ToString("₹ ") + Paid.ToString();
                        }


                        if (UnPaid == "")
                        {
                            lbl_Outstanding_Invoice.Text = Convert.ToString("₹ ") + "0.0";
                        }
                        else
                        {
                            lbl_Outstanding_Invoice.Text = Convert.ToString("₹ ") + Paid.ToString();
                        }

                        if (OverDue == "")
                        {
                            lbl_Past_Due_Invoice.Text = Convert.ToString("₹ ") + "0.0";
                        }
                        else
                        {
                            lbl_Past_Due_Invoice.Text = Convert.ToString("₹ ") + Paid.ToString();
                        }

                    }
                    else
                    {
                        lbl_Past_Due_Invoice.Text = Convert.ToString("₹ ") + "0.0";
                        lbl_Paid_Invoice.Text = Convert.ToString("₹ ") + "0.0";
                        lbl_Outstanding_Invoice.Text = Convert.ToString("₹ ") + "0.0";
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
        }

        //----------------------------------------------------------------------------//
        // Work Order
        //-------------------------------------------------------------------------
        protected void LinkWorkOrderno_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string WorkOrderNo;
                var rows = GridWorkorderlist.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                WorkOrderNo = ((LinkButton)rows[rowindex].FindControl("LinkWorkOrderno")).Text;

                Response.Redirect("~/ViewWorkOrder.aspx?WorkOrderNo=" + WorkOrderNo + "", false);
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

        protected void GridWorkorderlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GridWorkorderlist.Rows)
                {
                    LinkButton LinkWorkOrderno = (LinkButton)gridviedrow.FindControl("LinkWorkOrderno");
                    Label lblTenderno1 = (Label)gridviedrow.FindControl("lblTenderno1");
                    Label lblVender1 = (Label)gridviedrow.FindControl("lblVender1");
                    Label lblContactPerson1 = (Label)gridviedrow.FindControl("lblContactPerson1");
                    Label lblProjectName1 = (Label)gridviedrow.FindControl("lblProjectName1");
                    Label lblStatusName1 = (Label)gridviedrow.FindControl("lblStatusName1");
                    Label lblTotalAmountTender1 = (Label)gridviedrow.FindControl("lblTotalAmountTender1");

                    string status = ((Label)gridviedrow.FindControl("lblStatusbit")).Text;
                    if (status == "True")
                    {
                        LinkWorkOrderno.ForeColor = System.Drawing.Color.Blue;
                        lblTenderno1.ForeColor = System.Drawing.Color.Blue;
                        lblVender1.ForeColor = System.Drawing.Color.Blue;

                        lblProjectName1.ForeColor = System.Drawing.Color.Blue;
                        lblStatusName1.ForeColor = System.Drawing.Color.Blue;
                        lblTotalAmountTender1.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        LinkWorkOrderno.ForeColor = System.Drawing.Color.Red;
                        lblTenderno1.ForeColor = System.Drawing.Color.Red;
                        lblVender1.ForeColor = System.Drawing.Color.Red;

                        lblProjectName1.ForeColor = System.Drawing.Color.Red;
                        lblStatusName1.ForeColor = System.Drawing.Color.Red;
                        lblTotalAmountTender1.ForeColor = System.Drawing.Color.Red;

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

        protected void Chk_Pulish_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox chkPublish = (CheckBox)sender;
                GridViewRow row = (GridViewRow)chkPublish.NamingContainer;
                int rowIndex = row.RowIndex;
                int id = Convert.ToInt32(GridWorkorderlist.DataKeys[rowIndex]["ID"]);
                bool chk = chkPublish.Checked;
                using (SqlConnection connection = new SqlConnection(strconnect))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ViewOrderPublishWorkorderDetails", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@OrderPublish", chk);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        cmd.Parameters.AddWithValue("@created_by", UserName);

                        connection.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            result = dr[0].ToString();
                        }
                        Result = int.Parse(result);
                        if (Result > 0)
                        {

                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Work Order Publish Successfully!')", true);

                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Work Order Not Publish Successfully!')", true);

                        }

                        connection.Close();


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

        protected void btnEditWorkOrder_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceCon = new SqlConnection(strconnect);
                string WorkOrderID;
                var rows = GridWorkorderlist.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                WorkOrderID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                Response.Redirect("~/EditWorkOrder.aspx?ID=" + WorkOrderID + "", false);
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

        protected void btnDeleteWorkOrder_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    string ID;
                    var rows = GridWorkorderlist.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                    SqlConnection DeviceCon = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteWorkOrder", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Created_by", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    if (i < 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Work Order Details Deleted Successfully!')", true);
                        ViewWorkorderDetails();
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Work Order Details Not Deleted!')", true);
                    }
                }
                else if (RoleType == Designation)
                {
                    string ID;
                    var rows = GridWorkorderlist.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;

                    SqlConnection DeviceCon = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_DeleteWorkOrderByEmpID", DeviceCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Created_by", UserName);
                    cmd.Parameters.AddWithValue("@EmpID", UserId);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    DeviceCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    DeviceCon.Close();
                    if (i < 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Work Order Details Deleted Successfully!')", true);
                        StaffOperationPermission();
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Work Order Details Not Deleted!')", true);
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

        protected void Btn_Reload_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    ViewWorkorderDetails();
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
            finally { }

        }


        protected void lnkbtnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    DataTable dt = ViewWorkorderDetails();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        //Response.AddHeader("Content-Disposition", "attachment;filename=WorkOrder_Details.xls");
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "WorkOrder_Details " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));

                        Response.Charset = " ";


                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("ContactVender");
                        dtExport.Columns.Add("Vend_Name");
                        dtExport.Columns.Add("ProjectName");
                        dtExport.Columns.Add("TenderNumber");
                        dtExport.Columns.Add("WorkOrderNumber");
                        dtExport.Columns.Add("publishdate");
                        dtExport.Columns.Add("CompletionDate");
                        dtExport.Columns.Add("TotalAmountTender");

                        dtExport.Columns.Add("TenderBased");

                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["ID"];
                            newRow["ContactVender"] = row["ContactVender"];
                            newRow["VendName"] = row["Vend_Name"];
                            newRow["ProjectName"] = row["ProjectName"];
                            newRow["TenderNumber"] = row["TenderNumber"];
                            newRow["WorkOrderNumber"] = row["WorkOrderNumber"];
                            newRow["publishdate"] = row["publishdate"];
                            newRow["CompletionDate"] = row["CompletionDate"];
                            newRow["TotalAmountTender"] = row["TotalAmountTender"];
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
                    DataTable dt = (DataTable)ViewState["WorkData1"];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        // Response.AddHeader("Content-Disposition", "attachment;filename=WorkOrder_Details.xls");
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "WorkOrder_Details " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));

                        Response.Charset = " ";


                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("ContactVender");
                        dtExport.Columns.Add("Vend_Name");
                        dtExport.Columns.Add("ProjectName");
                        dtExport.Columns.Add("TenderNumber");
                        dtExport.Columns.Add("WorkOrderNumber");
                        dtExport.Columns.Add("publishdate");
                        dtExport.Columns.Add("CompletionDate");
                        dtExport.Columns.Add("TotalAmountTender");

                        dtExport.Columns.Add("TenderBased");

                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["ID"];
                            newRow["ContactVender"] = row["ContactVender"];
                            newRow["VendName"] = row["Vend_Name"];
                            newRow["ProjectName"] = row["ProjectName"];
                            newRow["TenderNumber"] = row["TenderNumber"];
                            newRow["WorkOrderNumber"] = row["WorkOrderNumber"];
                            newRow["publishdate"] = row["publishdate"];
                            newRow["CompletionDate"] = row["CompletionDate"];
                            newRow["TotalAmountTender"] = row["TotalAmountTender"];
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

        protected void linkbtnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    int _totalColumns = 9;//
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(9);//change
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;


                    Document _document = new Document(PageSize.A4, 0, 0, 0, 0);
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
                        _pdfPTable.SetWidths(new float[] { 4f, 11f, 11f, 7f, 10f, 12f, 11f, 13f, 10f });//column width in doc       
                                                                                                        //----Header PDF--------------------------//
                                                                                                        //Company Logo
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 3;
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
                        _pdfPCell.Colspan = 9;
                        _pdfPCell.BorderColor = BaseColor.WHITE;
                        _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.PaddingBottom = 1f;
                        _pdfPCell.PaddingTop = 0f;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                        _pdfPCell.Colspan = 9;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("WorkOrderList", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //-------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 3;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();


                        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*-------------------------------------", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = ViewWorkorderDetails();
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ContactVend", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("VendName", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Project", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("TenderNo", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("WorkOrderNo", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("publishdate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("CompletionDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("TenderAmt", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["ContactVender"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Vend_Name"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["ProjectName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["TenderNumber"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["WorkOrderNumber"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["publishdate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["CompletionDate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["TotalAmountTender"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("WorkOrderList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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
                    int _totalColumns = 9;//
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(9);//change
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;


                    Document _document = new Document(PageSize.A4, 0, 0, 0, 0);
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
                        _pdfPTable.SetWidths(new float[] { 4f, 11f, 11f, 7f, 10f, 12f, 11f, 13f, 10f });//column width in doc       
                                                                                                        //----Header PDF--------------------------//
                                                                                                        //Company Logo
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 3;
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
                        _pdfPCell.Colspan = 9;
                        _pdfPCell.BorderColor = BaseColor.WHITE;
                        _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.PaddingBottom = 1f;
                        _pdfPCell.PaddingTop = 0f;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                        _pdfPCell.Colspan = 9;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("WorkOrderList", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //-------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 3;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();


                        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*-------------------------------------", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = (DataTable)ViewState["WorkData1"];
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ContactVend", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("VendName", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Project", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("TenderNo", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("WorkOrderNo", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("publishdate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("CompletionDate", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("TenderAmt", _fontStyle));
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

                            _pdfPCell = new PdfPCell(new Phrase(row["ContactVender"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Vend_Name"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["ProjectName"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["TenderNumber"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["WorkOrderNumber"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["publishdate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["CompletionDate"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["TotalAmountTender"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("WorkOrderList_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
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

        protected void BTN_Visibility_Click(object sender, EventArgs e)
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
                        using (SqlDataAdapter ad = new SqlDataAdapter("SP_ViewWorkOrderDetailsVisibility", con))
                        {
                            ad.Fill(table);
                            GridWorkorderlist.DataSource = table;
                            GridWorkorderlist.DataBind();
                        }
                    }
                    //return table;
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

        protected void ddlProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ProjectID = Convert.ToInt32(ddlProjects.SelectedItem.Value);
                using (SqlConnection con1 = new SqlConnection(strconnect))
                {
                    SqlCommand cmd = new SqlCommand("SP_ChartMultilinebyProjectID", con1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    con1.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        using (DataSet result = new DataSet())
                        {
                            DataTable Table1 = new DataTable();
                            DataTable Table2 = new DataTable();
                            DataTable Table3 = new DataTable();
                            result.Tables.Add(Table1);
                            result.Tables.Add(Table2);
                            result.Tables.Add(Table3);
                            result.Load(dr, LoadOption.OverwriteChanges, Table1, Table2, Table3);
                            if (result.Tables[0].Rows.Count > 0)
                            {
                                Chart2.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                                Chart2.BorderlineColor = System.Drawing.Color.FromArgb(26, 59, 105);
                                Chart2.BorderlineWidth = 3;
                                Chart2.BackColor = Color.White;

                                Chart2.ChartAreas.Add("chtArea");
                                Chart2.ChartAreas[0].AxisX.Title = "TotalDuration";
                                Chart2.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                                Chart2.ChartAreas[0].AxisY.Title = "TotalProjectCost";
                                Chart2.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Bold);
                                Chart2.ChartAreas[0].BorderDashStyle = ChartDashStyle.Solid;
                                Chart2.ChartAreas[0].BorderWidth = 2;

                                Chart2.Legends.Add("TotalProjectCost");
                                Chart2.Series.Add("TotalProjectCost");
                                Chart2.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                                Chart2.Series[0].Points.DataBindXY(result.Tables[0].DefaultView, "TotalDuration", result.Tables[0].DefaultView, "TotalProjectCost");

                                Chart2.Series[0].IsVisibleInLegend = true;
                                Chart2.Series[0].IsValueShownAsLabel = true;
                                Chart2.Series[0].ToolTip = "Data Project Cost Point  Value: #VALY{G}";

                                // Setting Line Width
                                Chart2.Series[0].BorderWidth = 3;
                                Chart2.Series[0].Color = Color.Red;


                                Chart2.Series.Add("TotalExpensesAmont");
                                Chart2.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                                Chart2.Series[1].Points.DataBindXY(result.Tables[1].DefaultView, "IDays", result.Tables[1].DefaultView, "InvoiceTotalAmont");

                                Chart2.Series[1].IsVisibleInLegend = true;
                                Chart2.Series[1].IsValueShownAsLabel = true;
                                Chart2.Series[1].ToolTip = "Data Point Expenses Amount Value: #VALY{G}";

                                Chart2.Series[1].BorderWidth = 3;
                                Chart2.Series[1].Color = Color.Yellow;

                                Chart2.Series.Add("Amount_Recived");
                                Chart2.Series[2].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                                Chart2.Series[2].Points.DataBindXY(result.Tables[2].DefaultView, "DayPayment", result.Tables[2].DefaultView, "Amount_Recived");

                                Chart2.Series[2].IsVisibleInLegend = true;
                                Chart2.Series[2].IsValueShownAsLabel = true;
                                Chart2.Series[2].ToolTip = "Data Point Payment Amount Value: #VALY{G}";

                                Chart2.Series[2].BorderWidth = 3;
                                Chart2.Series[2].Color = Color.GreenYellow;

                                // Setting Line Shadow
                                //Chart2.Series[0].ShadowOffset = 5;

                                //Legend Properties
                                Chart2.Legends[0].LegendStyle = LegendStyle.Table;
                                Chart2.Legends[0].TableStyle = LegendTableStyle.Wide;
                                Chart2.Legends[0].Docking = Docking.Bottom;
                                Chart2.Legends[0].Alignment = StringAlignment.Center;

                            }
                        }
                        dr.Close();
                    }

                    con1.Close();

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


        //--------------------------------------------------------------------------//
        // Tickets
        //--------------------------------------------------------------------------//

        protected void btnSubject1_Click(object sender, EventArgs e)
        {
            // Response.Redirect("TicketOverView.aspx");
            try
            {
                string ID;
                var rows = Gridticket.Rows;
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int rowindex = Convert.ToInt32(row.RowIndex);
                ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;
                Response.Redirect("~/TicketOverView.aspx?ID=" + ID + "", false);
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
        protected void Gridticket_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void btnEditticket_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string ID;
                    var rows = Gridticket.Rows;
                    LinkButton btn = (LinkButton)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    int rowindex = Convert.ToInt32(row.RowIndex);
                    ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;
                    Response.Redirect("~/Editticket.aspx?ID=" + ID + "", false);
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

        }

        protected void btnDeleteticket_Click(object sender, EventArgs e)
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
                        var rows = Gridticket.Rows;
                        LinkButton btn = (LinkButton)sender;
                        GridViewRow row = (GridViewRow)btn.NamingContainer;
                        int rowindex = Convert.ToInt32(row.RowIndex);
                        ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;
                        SqlConnection con = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_DeleteTicketDetails", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", ID);
                        cmd.Parameters.AddWithValue("@CreatedBy", UserName);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i < 0)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ticket Details Deleted Successfully!')", true);
                            ViewTicketDetails();
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ticket Details not Deleted Successfully!')", true);

                        }


                    }
                }
                else if (RoleType == Designation)
                {
                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {
                        string ID;
                        var rows = Gridticket.Rows;
                        LinkButton btn = (LinkButton)sender;
                        GridViewRow row = (GridViewRow)btn.NamingContainer;
                        int rowindex = Convert.ToInt32(row.RowIndex);
                        ID = ((Label)rows[rowindex].FindControl("lblID1")).Text;
                        SqlConnection con = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_DeleteTicketDetailsEmpID", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", ID);
                        cmd.Parameters.AddWithValue("@CreatedBy", UserName);
                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                        cmd.Parameters.AddWithValue("@Designation", Designation);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i < 0)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ticket Details Deleted Successfully!')", true);
                            StaffOperationPermissionTicket();
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ticket Details not Deleted Successfully!')", true);

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
        }



        protected void btn_ExportTicket_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    DataTable dt = ViewTicketDetails();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "TicketsDetails " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));
                        //Response.AddHeader("Content-Disposition", "attachment;filename=StaffExpensesDetails.xls");
                        Response.Charset = " ";
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("Subject");
                        dtExport.Columns.Add("Department");
                        dtExport.Columns.Add("Services");
                        dtExport.Columns.Add("Priority");
                        dtExport.Columns.Add("AssignTo");
                        dtExport.Columns.Add("RaiseBy");
                        dtExport.Columns.Add("StatusName");


                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["ID"];
                            newRow["Subject"] = row["Subject"];
                            newRow["Department"] = row["Department"];
                            newRow["Services"] = row["Services"];
                            newRow["Priority"] = row["Priority"];
                            newRow["AssignTo"] = row["AssignTo"];
                            newRow["RaiseBy"] = row["Raise_By"];
                            newRow["StatusName"] = row["StatusName"];


                            dtExport.Rows.Add(newRow);
                        }

                        StringWriter sw = new StringWriter();
                        HtmlTextWriter htw = new HtmlTextWriter(sw);


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
                    DataTable dt = (DataTable)ViewState["TicketDATA"];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "TicketsDetails " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xls"));
                        //Response.AddHeader("Content-Disposition", "attachment;filename=StaffExpensesDetails.xls");
                        Response.Charset = " ";
                        DataTable dtExport = new DataTable();
                        dtExport.Columns.Add("ID");
                        dtExport.Columns.Add("Subject");
                        dtExport.Columns.Add("Department");
                        dtExport.Columns.Add("Services");
                        dtExport.Columns.Add("Priority");
                        dtExport.Columns.Add("AssignTo");
                        dtExport.Columns.Add("RaiseBy");
                        dtExport.Columns.Add("StatusName");


                        foreach (DataRow row in dt.Rows)
                        {
                            DataRow newRow = dtExport.NewRow();
                            newRow["ID"] = row["ID"];
                            newRow["Subject"] = row["Subject"];
                            newRow["Department"] = row["Department"];
                            newRow["Services"] = row["Services"];
                            newRow["Priority"] = row["Priority"];
                            newRow["AssignTo"] = row["AssignTo"];
                            newRow["RaiseBy"] = row["Raise_By"];
                            newRow["StatusName"] = row["StatusName"];


                            dtExport.Rows.Add(newRow);
                        }

                        StringWriter sw = new StringWriter();
                        HtmlTextWriter htw = new HtmlTextWriter(sw);


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

        protected void linkPTicket_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    int _totalColumns = 7;//gridvie clumns
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(7);//change
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;


                    iTextSharp.text.Document _document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 0f, 0f, 0f, 0f);
                    _document.SetPageSize(iTextSharp.text.PageSize.A4);
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
                        _pdfPTable.SetWidths(new float[] { 3f, 9f, 9f, 9f, 9f, 9f, 9f });//column width in doc       
                                                                                         //----Header PDF--------------------------//
                                                                                         //Company Logo
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 3;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPTable.AddCell(cell);

                        //...!..image logo..// 
                        Phrase phrase = null;
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
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.BorderColor = BaseColor.WHITE;
                        _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.PaddingBottom = 1f;
                        _pdfPCell.PaddingTop = 0f;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("TicketDetails_", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //-------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 4;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();


                        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*-------------------------------------", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = ViewTicketDetails();
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Subject", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Department", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Services", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("AssignTo", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("RaiseBy", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StatusName", _fontStyle));
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

                        foreach (DataRow row in _Vhrlist.Rows)//Stored columns name
                        {
                            _pdfPCell = new PdfPCell(new Phrase(serialnumber++.ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Subject"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Department"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Services"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["AssignTo"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Raise_By"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["StatusName"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("TicketDetails_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=" + PDFFileName);
                        Response.Buffer = true;
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.BinaryWrite(bytes);
                        Response.End();

                        //}
                    }
                }
                else if (RoleType == Designation)
                {
                    int _totalColumns = 7;//gridvie clumns
                    string path = Image1.ImageUrl;
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));


                    Font _fontStyle;
                    PdfPTable _pdfPTable = new PdfPTable(7);//change
                    PdfPCell _pdfPCell;
                    PdfPCell cell = null;


                    iTextSharp.text.Document _document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 0f, 0f, 0f, 0f);
                    _document.SetPageSize(iTextSharp.text.PageSize.A4);
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
                        _pdfPTable.SetWidths(new float[] { 3f, 9f, 9f, 9f, 9f, 9f, 9f });//column width in doc       
                                                                                         //----Header PDF--------------------------//
                                                                                         //Company Logo
                        cell = ImageCell("~/Img_logo/M.png", 50f, PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 3;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPTable.AddCell(cell);

                        //...!..image logo..// 
                        Phrase phrase = null;
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
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.BorderColor = BaseColor.WHITE;
                        _pdfPCell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.PaddingBottom = 1f;
                        _pdfPCell.PaddingTop = 0f;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
                        _pdfPCell.Colspan = 10;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.Border = 2;
                        _pdfPCell.BorderColorBottom = BaseColor.BLACK;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        _fontStyle = FontFactory.GetFont("Arial", 14f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("TicketDetails_", _fontStyle));
                        _pdfPCell.Colspan = 6;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);

                        //-------Date------------------------------//
                        DateTime PrintTime = DateTime.Now;
                        _fontStyle = FontFactory.GetFont("Arial", 9f, 2);
                        _pdfPCell = new PdfPCell(new Phrase("Date:" + PrintTime, _fontStyle));
                        _pdfPCell.Colspan = 4;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 3;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();


                        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
                        _pdfPCell = new PdfPCell(new Phrase("-------------------------------------*-------------------------------------", _fontStyle));
                        _pdfPCell.Colspan = _totalColumns;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.Border = 0;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.ExtraParagraphSpace = 4;
                        _pdfPTable.AddCell(_pdfPCell);
                        _pdfPTable.CompleteRow();

                        //----Header PDF--------------------------//


                        //----------------------------------Table----------------------------------////

                        DataTable _Vhrlist = new DataTable();
                        _Vhrlist = (DataTable)ViewState["TicketDATA"];
                        #region "Table Header"

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("ID", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Subject", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Department", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("Services", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("AssignTo", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("RaiseBy", _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.GRAY;
                        _pdfPCell.ExtraParagraphSpace = 2;
                        _pdfPTable.AddCell(_pdfPCell);

                        _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1, BaseColor.WHITE);
                        _pdfPCell = new PdfPCell(new Phrase("StatusName", _fontStyle));
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

                        foreach (DataRow row in _Vhrlist.Rows)//Stored columns name
                        {
                            _pdfPCell = new PdfPCell(new Phrase(serialnumber++.ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Subject"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Department"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Services"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["AssignTo"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["Raise_By"].ToString(), _fontStyle));
                            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            _pdfPCell.BackgroundColor = BaseColor.WHITE;
                            _pdfPCell.ExtraParagraphSpace = 1;
                            _pdfPTable.AddCell(_pdfPCell);

                            _pdfPCell = new PdfPCell(new Phrase(row["StatusName"].ToString(), _fontStyle));
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
                        string PDFFileName = string.Format("TicketDetails_" + dTime.ToString("dd/MM/yyyy HH:mm") + ".pdf");
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=" + PDFFileName);
                        Response.Buffer = true;
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.BinaryWrite(bytes);
                        Response.End();

                        //}
                    }

                }
                else { }
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

        protected void btnTicketVisibility_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection UserCon = new SqlConnection(strconnect))
                    {
                        SqlConnection con = new SqlConnection(strconnect);
                        SqlCommand cmd = new SqlCommand("SP_TicketDetailsByStatus", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(dt);
                        Gridticket.DataSource = dt;
                        Gridticket.DataBind();

                    }
                }
                else if (RoleType == Designation)
                {
                    StaffOperationPermissionTicket();
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

        protected void btnTicketReload_Click(object sender, EventArgs e)
        {
            try
            {
                RoleType = Session["LoginType"].ToString();
                Designation = Session["Role"].ToString();
                UserId = Convert.ToInt32(Session["UserID"]);
                if (Session["LoginType"].ToString() == "Administrator")
                {
                    ViewTicketDetails();
                }
                else if (RoleType == Designation)
                {
                    StaffOperationPermissionTicket();
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

        protected void Gridticket_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in Gridticket.Rows)
                {  // string  Status = Convert.ToString(e.Row.Cells[8].Text);

                    LinkButton btnSubject1 = (LinkButton)gridviedrow.FindControl("btnSubject1");
                    // Label lblSubject1 = (Label)gridviedrow.FindControl("lblSubject1");
                    Label lblDepartment1 = (Label)gridviedrow.FindControl("lblDepartment1");
                    Label lblServices1 = (Label)gridviedrow.FindControl("lblServices1");
                    Label lblPriority1 = (Label)gridviedrow.FindControl("lblPriority1");
                    Label lblAssignTo1 = (Label)gridviedrow.FindControl("lblAssignTo1");
                    Label lblRaiseBy1 = (Label)gridviedrow.FindControl("lblRaiseBy1");
                    Label lblStatusNamee1 = (Label)gridviedrow.FindControl("lblStatusNamee1");
                    Label lblStatus1 = (Label)gridviedrow.FindControl("lblStatus1");

                    if (lblStatusNamee1.Text == "Open")
                    {
                        lblStatusNamee1.ForeColor = System.Drawing.Color.Green;

                    }
                    else if (lblStatusNamee1.Text == "In Progress")
                    {
                        lblStatusNamee1.ForeColor = System.Drawing.Color.Blue;

                    }
                    else if (lblStatusNamee1.Text == "Answered")
                    {
                        lblStatusNamee1.ForeColor = System.Drawing.Color.Red;

                    }
                    else if (lblStatusNamee1.Text == "On Hold")
                    {
                        lblStatusNamee1.ForeColor = System.Drawing.Color.SkyBlue;

                    }
                    else if (lblStatusNamee1.Text == "Closed")
                    {
                        lblStatusNamee1.ForeColor = System.Drawing.Color.Black;

                    }
                    string status = ((Label)gridviedrow.FindControl("lblStatus1")).Text;
                    if (status == "True")
                    {
                        btnSubject1.ForeColor = System.Drawing.Color.Blue;
                        lblDepartment1.ForeColor = System.Drawing.Color.Black;
                        lblServices1.ForeColor = System.Drawing.Color.Black;
                        lblPriority1.ForeColor = System.Drawing.Color.Black;
                        lblAssignTo1.ForeColor = System.Drawing.Color.Black;
                        lblRaiseBy1.ForeColor = System.Drawing.Color.Blue;
                        // lblStatusNamee1.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        btnSubject1.ForeColor = System.Drawing.Color.Red;
                        lblDepartment1.ForeColor = System.Drawing.Color.Red;
                        lblServices1.ForeColor = System.Drawing.Color.Red;
                        lblPriority1.ForeColor = System.Drawing.Color.Red;
                        lblAssignTo1.ForeColor = System.Drawing.Color.Red;
                        lblRaiseBy1.ForeColor = System.Drawing.Color.Red;
                        // lblStatusNamee1.ForeColor = System.Drawing.Color.Red;
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

        //---------------------------------------------------------------------------------//
        //
        //---------------------------------------------------------------------------------//

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string departmentId = ddlDepartment.SelectedItem.Value;

                if (ddlDepartment.SelectedIndex == 0)
                {
                    ViewDashBoardSetting();
                }
                else
                {
                    ViewDashBoardSetting(departmentId);
                }
            }
            catch(Exception ex)
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
        protected void btnPermission_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in GVDBSetting.Rows)
                {
                    Label lblDivID1 = row.FindControl("lblDivID1") as Label;
                    Label lblDBStatus1 = row.FindControl("lblDBStatus1") as Label;
                    CheckBoxList chkList = (CheckBoxList)row.FindControl("cHkListRole");

                    string DeptID = ddlDepartment.SelectedItem.Value;
                    string DeptName = ddlDepartment.SelectedItem.Text;
                    int departmentId = int.Parse(ddlDepartment.SelectedValue);
                    string RollName = "", visibility, Status;
                    Status = lblDBStatus1.Text;
                    bool anyItemSelected = false;

                    if (chkList != null)
                    {
                        foreach (ListItem item in chkList.Items)
                        {
                            if (item.Selected)
                            {
                                anyItemSelected = true;
                                break;
                            }
                        }
                        if (!anyItemSelected)
                        {
                            if (DeptName == "Select ddlDepartment")
                            {

                                foreach (ListItem item in chkList.Items)
                                {

                                    RollName = item.Text;
                                    visibility = "false";
                                    using (SqlConnection con = new SqlConnection(strconnect))
                                    {
                                        SqlCommand cmd = new SqlCommand("SP_UpdateDashBoardSettingPermission", con);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("@DivID", lblDivID1.Text);
                                        cmd.Parameters.AddWithValue("@RoleName", RollName);
                                        cmd.Parameters.AddWithValue("@CreateBy", UserName);
                                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                                        cmd.Parameters.AddWithValue("@Designation", Designation);
                                        cmd.Parameters.AddWithValue("@Visibility", visibility);
                                        con.Open();
                                        int Result = cmd.ExecuteNonQuery();
                                        if (Result < 0)
                                        {
                                            //string save = "fgsave123q";
                                            //Response.Redirect("~/Dashboard.aspx?svd1=" + save + "", false);

                                        }
                                        else
                                        {

                                            //  lblMesDelete.Text = "Leave Management Details already Available";

                                        }

                                    }

                                }
                              ViewDashBoardSetting();

                            }
                            else
                            {
                                foreach (ListItem item in chkList.Items)
                                {
                                    RollName = item.Text;
                                    visibility = "false";
                                   using (SqlConnection con = new SqlConnection(strconnect))
                                    {
                                        SqlCommand cmd = new SqlCommand("SP_UpdateDashBoardSettingPermissionByDeptID", con);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        // cmd.Parameters.AddWithValue("@ID", lblDB_ID1.Text);
                                        cmd.Parameters.AddWithValue("@DivID", lblDivID1.Text);
                                        cmd.Parameters.AddWithValue("@RoleName", RollName);
                                        cmd.Parameters.AddWithValue("@DeptName", DeptName);
                                        cmd.Parameters.AddWithValue("@CreateBy", UserName);
                                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                                        cmd.Parameters.AddWithValue("@Designation", Designation);
                                        cmd.Parameters.AddWithValue("@Visibility", visibility);
                                        con.Open();
                                        int Result = cmd.ExecuteNonQuery();
                                        if (Result < 0)
                                        {
                                            //string save = "fgsave123q";
                                            //Response.Redirect("~/Dashboard.aspx?svd1=" + save + "", false);

                                        }
                                        else
                                        {

                                            //  lblMesDelete.Text = "Leave Management Details already Available";

                                        }

                                    }
                                }
                                ViewDashBoardSetting(DeptID);
                            }
                        }
                        else
                        {
                            if (DeptName == "Select ddlDepartment")
                            {
                                foreach (ListItem item in chkList.Items)
                                {
                                    RollName = item.Text;
                                    if (!item.Selected)
                                    {
                                        continue;
                                    }
                                    visibility = "true";
                                    using (SqlConnection con = new SqlConnection(strconnect))
                                    {
                                        SqlCommand cmd = new SqlCommand("SP_UpdateDashBoardSettingPermission", con);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        // cmd.Parameters.AddWithValue("@ID", lblDB_ID1.Text);
                                        cmd.Parameters.AddWithValue("@DivID", lblDivID1.Text);
                                        cmd.Parameters.AddWithValue("@RoleName", RollName);
                                        cmd.Parameters.AddWithValue("@CreateBy", UserName);
                                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                                        cmd.Parameters.AddWithValue("@Designation", Designation);
                                        cmd.Parameters.AddWithValue("@Visibility", visibility);
                                        con.Open();
                                        int Result = cmd.ExecuteNonQuery();
                                        if (Result < 0)
                                        {
                                            //string save = "fgsave123q";
                                            //Response.Redirect("~/Dashboard.aspx?svd1=" + save + "", false);
                                        }
                                        else
                                        {
                                            //  lblMesDelete.Text = "Leave Management Details already Available";

                                        }

                                    }
                                }
                                ViewDashBoardSetting();

                            }
                            else
                            {
                                foreach (ListItem item in chkList.Items)
                                {
                                    RollName = item.Text;
                                    if (!item.Selected)
                                    {
                                        continue;
                                    }
                                    visibility = "true";
                                    using (SqlConnection con = new SqlConnection(strconnect))
                                    {
                                        SqlCommand cmd = new SqlCommand("SP_UpdateDashBoardSettingPermissionByDeptID", con);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        // cmd.Parameters.AddWithValue("@ID", lblDB_ID1.Text);
                                        cmd.Parameters.AddWithValue("@DivID", lblDivID1.Text);
                                        cmd.Parameters.AddWithValue("@RoleName", RollName);
                                        cmd.Parameters.AddWithValue("@DeptName", DeptName);
                                        cmd.Parameters.AddWithValue("@CreateBy", UserName);
                                        cmd.Parameters.AddWithValue("@EmpID", UserId);
                                        cmd.Parameters.AddWithValue("@Designation", Designation);
                                        cmd.Parameters.AddWithValue("@Visibility", visibility);
                                        con.Open();
                                        int Result = cmd.ExecuteNonQuery();
                                        if (Result < 0)
                                        {
                                            //string save = "fgsave123q";
                                            //Response.Redirect("~/Dashboard.aspx?svd1=" + save + "", false);

                                        }
                                        else
                                        {
                                            //  lblMesDelete.Text = "Leave Management Details already Available";

                                        }

                                    }
                                }
                                ViewDashBoardSetting(DeptID);
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

        protected void btnGVClear_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in GVDBSetting.Rows)
                {
                    CheckBoxList chkList = row.FindControl("CheckBoxList1") as CheckBoxList;
                    if (chkList != null)
                    {
                        foreach (ListItem item in chkList.Items)
                        {
                            item.Selected = false;
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

        protected void GVDBSetting_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gridviedrow in GVDBSetting.Rows)
                {
                    System.Web.UI.WebControls.Label lblDivID1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblDivID1");
                    System.Web.UI.WebControls.Label lblDivName1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblDivName1");
                    System.Web.UI.WebControls.Label lbDescription1 = (System.Web.UI.WebControls.Label)gridviedrow.FindControl("lbDescription1");

                    string status = ((System.Web.UI.WebControls.Label)gridviedrow.FindControl("lblDBStatus1")).Text;
                    if (status == "True")
                    {
                        lblDivID1.ForeColor = System.Drawing.Color.Blue;
                        lblDivName1.ForeColor = System.Drawing.Color.Blue;
                        lbDescription1.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        lblDivID1.ForeColor = System.Drawing.Color.Red;
                        lblDivName1.ForeColor = System.Drawing.Color.Red;
                        lbDescription1.ForeColor = System.Drawing.Color.Red;
                    }

                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CheckBoxList cHkListRole = (CheckBoxList)e.Row.FindControl("cHkListRole");
                    Label lblDivID1 = (Label)e.Row.FindControl("lblDivID1");

                    SqlConnection conn = new SqlConnection(strconnect);
                    SqlCommand cmd = new SqlCommand("SP_ViewRolesByDashboardSetting", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DivID", lblDivID1.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        cHkListRole.DataSource = dt;
                        cHkListRole.DataTextField = "RoleName";
                        cHkListRole.DataValueField = "RoleName";
                        cHkListRole.DataBind();
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
    }
}