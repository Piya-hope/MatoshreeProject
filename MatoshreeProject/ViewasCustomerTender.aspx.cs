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
//using iText.Kernel.Events;
//using iText.Kernel.Pdf;
using static iTextSharp.text.TabStop;

#endregion

namespace MatoshreeProject
{
    public partial class ViewasCustomerTender : System.Web.UI.Page
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
        string UserName, EmailID, Designation;
        private object lblTender;
        private object lblTenders;

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
          
        protected void lnkbtnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table2 = new DataTable();
                iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
                MemoryStream memoryStream = new MemoryStream();
                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, memoryStream);
                doc.Open();
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                //PdfPTable table = new PdfPTable(2);
                //table.WidthPercentage = 100;
                //PdfPCell leftCell1 = new PdfPCell();
                //leftCell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(@"D:\Company\Matoshree\MatoshreeProject\MatoshreeProject\Img_logo\Logo.png");
                //image.ScaleToFit(100f, 100f);
                //leftCell1.AddElement(image);
                //table.AddCell(leftCell1);
                //Font Pagename = new Font(Font.FontFamily.HELVETICA, 16f, Font.BOLD);
                //Font Page1 = new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.RED);
                //Font Page2 = new Font(Font.FontFamily.HELVETICA, 8f);
                //Font Page3 = new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD);
                //Font Page4 = new Font(Font.FontFamily.HELVETICA, 10f);
                //PdfPCell rightCell1 = new PdfPCell();
                //rightCell1.Border = PdfPCell.NO_BORDER;
                //rightCell1.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                //Paragraph paragraph1 = new Paragraph("TENDER", Pagename);
                //paragraph1.Alignment = Element.ALIGN_RIGHT;
                //rightCell1.AddElement(paragraph1);
                //Paragraph paragraph2 = new Paragraph(lblTenderno.Text, Page2);
                //paragraph2.Alignment = Element.ALIGN_RIGHT;
                //rightCell1.AddElement(paragraph2);
                //Paragraph paragraph3 = new Paragraph(lblstatus1.Text, Page1);
                //paragraph3.Alignment = Element.ALIGN_RIGHT;
                //rightCell1.AddElement(paragraph3);
                //table.AddCell(rightCell1);
                //doc.Add(table);
                Font Page1 = new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.RED);
                Font Page2 = new Font(Font.FontFamily.HELVETICA, 8f);
                Font Page3 = new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD);
                Font Page4 = new Font(Font.FontFamily.HELVETICA, 10f);

                PdfPTable table1 = new PdfPTable(2);
                table1.WidthPercentage = 100;
                PdfPCell leftCell = new PdfPCell();
                leftCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                leftCell.AddElement(new Paragraph("", new Font(Font.FontFamily.HELVETICA, 10f)));
                leftCell.AddElement(new Paragraph("", new Font(Font.FontFamily.HELVETICA, 10f)));
                leftCell.AddElement(new Paragraph(lbladdCompany1.Text, new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD)));
                leftCell.AddElement(new Paragraph(lbladdress1.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                leftCell.AddElement(new Paragraph(companylbladdress.Text, new Font(Font.FontFamily.HELVETICA, 10f)));
                Chunk PhoneChunk = new Chunk("Phone No: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                Chunk PhoneValueChunk = new Chunk(lblphoneNo.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase phrase5 = new Phrase
                {
                  PhoneChunk,
                     PhoneValueChunk
                };
                leftCell.AddElement(phrase5);
                Chunk GstNoChunk = new Chunk("GST No: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                Chunk GstNoValueChunk = new Chunk(lblGSTNo.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase phrase6 = new Phrase
                  {
                     GstNoChunk,
                     GstNoValueChunk
                  };
                leftCell.AddElement(phrase6);
                table1.AddCell(leftCell);
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));

                PdfPCell rightCell = new PdfPCell();
                rightCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Paragraph paragraph11 = new Paragraph("To,", Page3);
                paragraph11.Alignment = Element.ALIGN_RIGHT;
                rightCell.AddElement(paragraph11);

                Paragraph paragraph4 = new Paragraph(lblcustname.Text, Page3);
                paragraph4.Alignment = Element.ALIGN_RIGHT;
                rightCell.AddElement(paragraph4);

                Chunk Address1 = new Chunk(lblblock.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                Chunk Address8 = new Chunk(",", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase ph1 = new Phrase
                {
                Address1,
                Address8
                };
                Paragraph paragraphs1 = new Paragraph(ph1);
                paragraphs1.Alignment = Element.ALIGN_RIGHT;
                rightCell.AddElement(paragraphs1);

                Chunk Address2 = new Chunk(lblstreet.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                Chunk Address9 = new Chunk(",", new Font(Font.FontFamily.HELVETICA, 10f));
                Chunk Address3 = new Chunk(lblcity.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                Chunk Address10 = new Chunk(",", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase ph2 = new Phrase
                {
                Address2,
                Address9,
                Address3,
                Address10
                };
                Paragraph paragraphs2 = new Paragraph(ph2);
                paragraphs2.Alignment = Element.ALIGN_RIGHT;
                rightCell.AddElement(paragraphs2);


                Chunk Address4 = new Chunk(lbldistrict.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                Chunk Address13 = new Chunk(",", new Font(Font.FontFamily.HELVETICA, 10f));
                Chunk Address5 = new Chunk(lblstate.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                Chunk Address11 = new Chunk(",", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase ph3 = new Phrase
                {
                Address4,
                Address13,
                Address5,
                Address11
                };
                Paragraph paragraphs3 = new Paragraph(ph3);
                paragraphs3.Alignment = Element.ALIGN_RIGHT;
                rightCell.AddElement(paragraphs3);


                Chunk Address6 = new Chunk(lblcountry.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                Chunk Address12 = new Chunk(",", new Font(Font.FontFamily.HELVETICA, 10f));
                Chunk Address7 = new Chunk(lblpincode.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase ph4 = new Phrase
                {

                Address6,
                Address12,
                Address7
                };
                Paragraph paragraphs4 = new Paragraph(ph4);
                paragraphs4.Alignment = Element.ALIGN_RIGHT;
                rightCell.AddElement(paragraphs4);

                Chunk gstNoChunk = new Chunk("GST No: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                Chunk gstNoValueChunk = new Chunk(lblgstno1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase phrase = new Phrase
                {
                gstNoChunk,
                gstNoValueChunk
                };

                Paragraph paragraph6 = new Paragraph(phrase);
                paragraph6.Alignment = Element.ALIGN_RIGHT;

                rightCell.AddElement(paragraph6);

                Chunk TenderDate = new Chunk("Tender Date: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                Chunk TenderDatevalue = new Chunk(lbltenderdate1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase phrase1 = new Phrase
                 {
                   TenderDate,
                   TenderDatevalue
                 };

                Paragraph paragraph7 = new Paragraph(phrase1);
                paragraph7.Alignment = Element.ALIGN_RIGHT;

                rightCell.AddElement(paragraph7);

                Chunk ExpireDate = new Chunk("Expiry Date: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                Chunk ExpireDatevalue = new Chunk(lblExpiry_Date1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase phrase2 = new Phrase
                 {
                 ExpireDate,
                  ExpireDatevalue
                 };
                Paragraph paragraph8 = new Paragraph(phrase2);
                paragraph8.Alignment = Element.ALIGN_RIGHT;
                rightCell.AddElement(paragraph8);

                Chunk SaleAgent = new Chunk("Sale Agent: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                Chunk SaleAgentvalue = new Chunk(lblsaleagent1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase phrase3 = new Phrase
                 {
                  SaleAgent,
                 SaleAgentvalue
                 };
                Paragraph paragraph9 = new Paragraph(phrase3);
                paragraph9.Alignment = Element.ALIGN_RIGHT;
                rightCell.AddElement(paragraph9);

                Chunk Projectname = new Chunk("Project Name: ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                Chunk Projectnamevalue = new Chunk(lblprojectname1.Text, new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase phrase4 = new Phrase
                 {
               Projectname,
                Projectnamevalue
                   };
                Paragraph paragraph10 = new Paragraph(phrase4);
                paragraph10.Alignment = Element.ALIGN_RIGHT;
                rightCell.AddElement(paragraph10);
                table1.AddCell(rightCell);
                doc.Add(table1);

                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));
                float[] columnWidths = new float[table2.Columns.Count];
                for (int i = 0; i < table2.Columns.Count; i++)
                {
                    if (table2.Columns[i].ColumnName == "Description")
                    {
                        columnWidths[i] = 10f;
                    }
                    else
                    {
                        columnWidths[i] = 2f;
                    }
                }
                Font tableHeaderFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL, BaseColor.WHITE);
                Font tableDataFont = new Font(Font.FontFamily.HELVETICA, 10f, Font.NORMAL);
                PdfPTable pdfTable = new PdfPTable(table2.Columns.Count);
                pdfTable.SetWidths(columnWidths);
                pdfTable.WidthPercentage = 100;
                foreach (DataColumn column in table2.Columns)
                {
                    string columnName = (column.ColumnName == "ID") ? "#" : column.ColumnName;

                    PdfPCell pdfCell = new PdfPCell(new Phrase(columnName, tableHeaderFont));
                    pdfCell.BackgroundColor = new BaseColor(85, 85, 85);
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
                doc.Add(new Paragraph(" "));


                PdfPTable labelsTable = new PdfPTable(1);
                labelsTable.WidthPercentage = 100;
                PdfPCell labelCell = new PdfPCell();
                labelCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Chunk subtotal = new Chunk("Sub Total ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                Chunk subtotalspace = new Chunk("   "); // Add spaces as needed
                Chunk subtotalvalue = new Chunk("₹2,542.372", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase phrase7 = new Phrase
                {
                    subtotal,
                    subtotalspace,
                    subtotalvalue
                };
                Paragraph paragraph12 = new Paragraph(phrase7);
                paragraph12.Alignment = Element.ALIGN_RIGHT;
                labelCell.AddElement(paragraph12);
                labelCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                Chunk cgst = new Chunk("CGST (9.00%) ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                Chunk cgstvalue = new Chunk("₹228.81", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase phrase8 = new Phrase
                {
                 cgst,
                  subtotalspace,
                 cgstvalue
                };
                Paragraph paragraph13 = new Paragraph(phrase8);
                paragraph13.Alignment = Element.ALIGN_RIGHT;
                labelCell.AddElement(paragraph13);
                labelCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                Chunk sgst = new Chunk("SGST (9.00%) ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                Chunk sgstvalue = new Chunk("₹228.81", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase phrase9 = new Phrase
                {
                 sgst,
                  subtotalspace,
                 sgstvalue
                };
                Paragraph paragraph14 = new Paragraph(phrase9);
                paragraph14.Alignment = Element.ALIGN_RIGHT;
                labelCell.AddElement(paragraph14);
                labelCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                doc.Add(new Paragraph(" "));
                Chunk total = new Chunk("Total ", new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD));
                Chunk totalvalue = new Chunk("₹3,000.00", new Font(Font.FontFamily.HELVETICA, 10f));
                Phrase phrase10 = new Phrase
                {
                 total,
                  subtotalspace,
                 totalvalue
                };
                Paragraph paragraph15 = new Paragraph(phrase10);
                paragraph15.Alignment = Element.ALIGN_RIGHT;
                labelCell.AddElement(paragraph15);
                labelCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                labelsTable.AddCell(labelCell);
                doc.Add(labelsTable);
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
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=Tender Details .pdf ");
                HttpContext.Current.Response.BinaryWrite(memoryStream.ToArray());
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetbyTenderNo()
        {

            string Tenderid = HttpUtility.UrlDecode(Request.QueryString["Tenderid"]);
            lblid1.Text = Tenderid;
            using (SqlConnection UserCon = new SqlConnection(strconnect))
            {
                SqlCommand cmd = new SqlCommand("[SP_GetTenderDetailsByID]", UserCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@ID", lblid1.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblTenderno.Text = dt.Rows[0]["TenderNo"].ToString();
                    lblcustname.Text = dt.Rows[0]["Cust_Name"].ToString();
                    lblblock.Text = dt.Rows[0]["Add_Block"].ToString();
                    lblstreet.Text = dt.Rows[0]["Add_Street"].ToString();
                    lblcity.Text = dt.Rows[0]["Add_City"].ToString();
                    lbldistrict.Text = dt.Rows[0]["Add_District"].ToString();
                    lblstate.Text = dt.Rows[0]["Add_State"].ToString();
                    lblcountry.Text = dt.Rows[0]["Add_Country"].ToString();
                    lblpincode.Text = dt.Rows[0]["Add_PinCode"].ToString();
                    lblStatus.Text = dt.Rows[0]["Status"].ToString();
                    lblgstno1.Text = dt.Rows[0]["GST_No"].ToString();
                    lbltenderdate1.Text = dt.Rows[0]["TenderDate"].ToString();
                    lblExpiry_Date1.Text = dt.Rows[0]["Expiry_Date"].ToString();
                    lblsaleagent1.Text = dt.Rows[0]["Sales_Agent"].ToString();
                    lblprojectname1.Text = dt.Rows[0]["ProjectName"].ToString();
                    lblclientnote.Text = dt.Rows[0]["Client_Note"].ToString();
                    lbltermsandcodition.Text = dt.Rows[0]["Term_condition"].ToString();
                    lblURLname1.Text = dt.Rows[0]["ProjectName"].ToString();
                    lblstatus1.Text = dt.Rows[0]["Status"].ToString();

                }

                //ViewItemDetailDetails();
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                GetbyTenderNo();
                //ViewItemDetailDetails();
            }
        }
    }
}