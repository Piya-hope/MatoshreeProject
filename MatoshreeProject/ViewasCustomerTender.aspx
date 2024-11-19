<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewasCustomerTender.aspx.cs" Inherits="MatoshreeProject.ViewasCustomerTender" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="robots" content="noindex,nofollow" />
    <title>Matoshree Interior</title>  
    <link rel="icon" type="image/png" sizes="50x50" href="Img_logo/MI Logo 2.png" />
    <link rel="stylesheet" type="text/css" href="AMatrix/assets/libs/select2/dist/css/select2.min.css" />
    <link href="AMatrix/assets/libs/flot/css/float-chart.css" rel="stylesheet" />
    <link href="AMatrix/assets/libs/fullcalendar/dist/fullcalendar.min.css" rel="stylesheet" />
    <link href="AMatrix/assets/extra-libs/calendar/calendar.css" rel="stylesheet" />
    <link href="AMatrix/assets/extra-libs/DataTables/DataTables-1.10.16/css/dataTables.foundation.min.css" rel="stylesheet" />
    <link href="AMatrix/dist/css/style.min.css" rel="stylesheet" />
   <style>
       
.card-container {
            background-color: #f0f0f0; /* Background color for the margins */
            margin-left: 30px;
            margin-right: 30px;
           
              }

.card-body {
  border: 1px solid #ccc;
  padding: 20px;
  background-color: #fff;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
}    
  .custom-margin::after {
    margin: 22px;
    background-color:#f0f0f0;
    content: "";
  display: block;
  height: 22px; /* Set the desired margin height */
  background-color: #f0f0f0;
  }
  .custom-label {
    display: inline-block;
    padding: 5px 10px; /* Adjust the padding to control the button size */
    border: 1px solid #ccc;
    border-radius: 5px; /* Adjust the border-radius to control the roundness */
    font-size: 10px;
    cursor: pointer;
    text-align: center;
}
.custom-label .icon {
    margin-right: 5px;
    color: black;/* Adjust the spacing between the icon and text */
}

.custom-label .text {
    font-size: 12px; 
    color: black;/* Adjust the font size for the text */
    
}

.custom-label:hover {
    background-color: #f0f0f0; /* Change the background color on hover */
}
    </style>
</head>
<body>

  <form id="form1" runat="server">
   <div style="background-color: #f0f0f0;">
       <div class="row card-container">
              <asp:Image ID="Image1" runat="server" ImageUrl="Img_logo/Logo.png" CssClass="mt-2" Height="75px" Width="125px"  />
          </div>
        <div class="row card-container mt-2">            
            <div class="col-md-12 col-sm-12 col-lg-12 ">
                    <div class="d-flex justify-content-between align-items-center">                      
                          <asp:Label ID="lblbtndraft" runat="server" CssClass="btn btn-sm btn-default btn-rounded mb-2 custom-label text-black" >
                                <span class="text">Draft

                                </span>
                          </asp:Label>
                            <div>
                            <asp:LinkButton ID="lnkbtnpdf" runat="server" CssClass="btn btn-sm btn-default btn-rounded mb-2 custom-label" OnClick="lnkbtnpdf_Click">
                            <span class="icon"><i class="far fa-file-pdf"></i></span>
                                   <span class="text">Download</span>
                                      </asp:LinkButton>
                            <asp:Label ID="lblStatus" runat="server" Text="" CssClass="btn-danger btn-sm text-white text-left font-2 mb-2" Visible="false"></asp:Label>
                            <asp:Label ID="lblstatus1" runat="server" Text="" CssClass=" text-danger mb-2" Visible="false"></asp:Label>      
                                 <asp:Label ID="lblstatusstatic" runat="server" Text="" CssClass="btn btn-sm btn-default mb-2 custom-label" Visible="true">
                                     <span class="icon"><i class=" fas fa-times"></i></span>
                                   <span class="text">Declined</span>
                                 </asp:Label>
                            <asp:Label ID="lblstatusstatic1" runat="server" Text="" CssClass=" btn btn-sm btn-success text-white custom-label mb-2" Visible="true">
                                <span class="icon"><i class=" ti ti-check"></i></span>
                                   <span class="text">Accept</span>
                            </asp:Label>          
                            </div>
                        </div>
                     </div>
            </div>                             
               <div class="col-md-12">
                     <div class="card-container">
                          <div class="card-body">
                     <div class="row">
                           <div>
                                <asp:Label ID="lblURLname" runat="server" Text="This tender related to project:" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblURLname1" runat="server" Text="" CssClass="font-weight-bold text-info " Visible="false"></asp:Label>
                            </div>
                            <br />
                            <div class="col-md-8 col-lg-8 col-sm-8 col-xs-8  text-left ml-3 p-2">
                                <asp:Label ID="lblid1" runat="server" Text=""  Visible="false"></asp:Label>
                                <asp:Label ID="lblTenderno" runat="server" Text="" CssClass="font-bold text-info" Font-Size="12px"></asp:Label><br />
                                <asp:Label ID="lbladdCompany1" runat="server" Text="Lissom Technologies Pvt.Ltd," CssClass="font-bold text-dark" Font-Size="12px"></asp:Label><br />
                                <asp:Label ID="lbladdress1" runat="server" Text="RH 01, Richmond Park, OPP, " Font-Size="12px"></asp:Label>                                
                                 <asp:Label ID="companylbladdress" runat="server" Text=" Orchid School, baner, Pune, "  Font-Size="12px"></asp:Label><br />
                                 <asp:Label ID="companylbladdress1" runat="server" Text="  Maharashtra, IN 411045"  Font-Size="12px"></asp:Label><br />
                                <asp:Label ID="lblphone" runat="server" Text="Phone:" CssClass="form-label"></asp:Label>
                                 <asp:Label ID="lblphoneNo" runat="server" Text="8380037766," Font-Bold="false" Font-Size="12px"></asp:Label><br />
                                <asp:Label ID="lblGST" runat="server" Text="GST NO:" CssClass="form-label"></asp:Label>
                                 <asp:Label ID="lblGSTNo" runat="server" Text="27AACCL9655M2ZS" Font-Bold="false" Font-Size="12px"></asp:Label>
                            </div>

                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4  text-end">
                                 <asp:Label ID="lblspace" runat="server" Text=""></asp:Label><br />
                                  <asp:Label ID="lblspace1" runat="server" Text=""></asp:Label><br />
                                <asp:Label ID="lbladdcust1" runat="server" Text="To," CssClass="font-bold " ></asp:Label><br />
                                <asp:Label ID="lblcustname" runat="server" Text="" CssClass=" font-bold text-info " ></asp:Label><br />
                                <asp:Label ID="lblblock"  runat="server" Text=""   Font-Size="12px" ></asp:Label> 
                                 <asp:Label ID="lblcomma"  runat="server" Text=","   Font-Size="12px" ></asp:Label> <br />
                                <asp:Label ID="lblstreet"  runat="server" Text=""   Font-Size="12px" ></asp:Label>
                                 <asp:Label ID="lblcomma1"  runat="server" Text=","   Font-Size="12px" ></asp:Label> 
                                <asp:Label ID="lblcity"  runat="server" Text=""   Font-Size="12px" ></asp:Label>
                                   <asp:Label ID="lblcomma2"  runat="server" Text=","   Font-Size="12px" ></asp:Label> <br />
                                <asp:Label ID="lbldistrict"  runat="server" Text=""   Font-Size="12px" ></asp:Label>
                                <asp:Label ID="lblcomma3"  runat="server" Text=","   Font-Size="12px" ></asp:Label>
                                <asp:Label ID="lblstate"  runat="server" Text=""   Font-Size="12px" ></asp:Label>
                                <asp:Label ID="lblcomma4"  runat="server" Text=","   Font-Size="12px" ></asp:Label><br />
                                <asp:Label ID="lblcountry"  runat="server" Text=""   Font-Size="12px" ></asp:Label>
                                <asp:Label ID="lblcomma5"  runat="server" Text=","   Font-Size="12px" ></asp:Label>
                                <asp:Label ID="lblpincode"  runat="server" Text=""   Font-Size="12px" ></asp:Label><br />
                                <asp:Label ID="lblgstnoA" runat="server" Text="GST No:" CssClass="form-label"></asp:Label>
                                <asp:Label ID="lblgstno1" runat="server" Text=""  Font-Size="12px"></asp:Label><br />
                                <asp:Label ID="lbltenderdate" runat="server" Text="Tender Date:" CssClass="font-bold"  Font-Size="12px"></asp:Label>
                                <asp:Label ID="lbltenderdate1" runat="server" Text=""  Font-Size="12px"></asp:Label><br />
                                <asp:Label ID="lblExpiry_Date" runat="server" Text="Expiry Date:" CssClass="font-bold"  Font-Size="12px"></asp:Label>
                                <asp:Label ID="lblExpiry_Date1" runat="server" Text=""  Font-Size="12px"></asp:Label><br />
                                <asp:Label ID="lblsaleagent" runat="server" Text="Sale Agent:" CssClass="font-bold"  Font-Size="12px"></asp:Label>
                                <asp:Label ID="lblsaleagent1" runat="server" Text=""  Font-Size="12px"></asp:Label><br />
                                <asp:Label ID="lblprojectname" runat="server" Text="Project Name:" CssClass="font-bold"  Font-Size="12px"></asp:Label>
                                <asp:Label ID="lblprojectname1" runat="server" Text=""  Font-Size="12px"></asp:Label><br />                        
                            </div>
                       </div>
                      <br />                       
                        <div class="table-responsive">
                            <asp:GridView ID="GridViewItemDetails" runat="server" CssClass="table table-bordered table-responsive" AutoGenerateColumns="false">
                                <HeaderStyle BackColor="gray" ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField HeaderText="#" SortExpression="#" ControlStyle-Font-Size="12px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblitemID" runat="server" Text='<%# Bind("ID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item" SortExpression="Item">
                                        <ItemTemplate>
                                            <asp:Label ID="lblitemDescription" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblitemQty" runat="server" Text='<%# Bind("Qty") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate" SortExpression="Rate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblitemRate" runat="server" Text='<%# Bind("Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax" SortExpression="Tax">
                                        <ItemTemplate>
                                            <asp:Label ID="lblitemTax" runat="server" Text='<%# Bind("Tax") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblitemAmount" runat="server" Text='<%# Bind("Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                           <br />  
                        <div class="row">
                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6  text-left ml-3 p-2">                      
                    </div>
                   <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 text-end">
                        <asp:Label ID="lblsubtotalname" runat="server" Text="Sub Total" Font-Size="12px" Font-Bold="true"></asp:Label> &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="lblsubtotalamount" runat="server" Text="₹2,542.372" Font-Size="12px"></asp:Label><br />                     
                        <asp:Label ID="lblcgst" runat="server" Text="CGST (9.00%)" Font-Size="12px" Font-Bold="true"></asp:Label> &nbsp; &nbsp;
                        <asp:Label ID="lblcgstno" runat="server" Text="₹228.81" Font-Size="12px"></asp:Label><br />
                        <asp:Label ID="lblsgst" runat="server" Text="SGST (9.00%)" Font-Size="12px" Font-Bold="true"></asp:Label> &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="lblsgstno" runat="server" Text="₹228.81" Font-Size="12px" ></asp:Label><br />
                        <asp:Label ID="lbltotal" runat="server" Text="Total" Font-Size="12px" Font-Bold="true"></asp:Label> &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="tbltoatalno" runat="server" Text="₹3,000.00" Font-Size="12px"></asp:Label><br />
                        <asp:Label ID="lbltotalpaid" runat="server" Text="Total Paid" Font-Size="12px" Font-Bold="true"></asp:Label> &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="lbltotalpaidno" runat="server" Text="₹3,000.00" Font-Size="12px"></asp:Label><br />
                        <asp:Label ID="lblamountdue" runat="server" Text="Amount Due" Font-Size="12px" Font-Bold="true"></asp:Label> &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="lblamountdueno" runat="server" Text="₹0.00" Font-Size="12px"></asp:Label>
                    </div>                        
                <br />                         
                        <h6>Note :</h6>
                        <asp:Label ID="lblclientnote" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                        <h6>Terms & Condition</h6>
                        <asp:Label ID="lbltermsandcodition" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                    </div>
               </div>
                     </div>                
                   
         </div>
                                    
     
       </div>
          
    </form>
    <!-- All Jquery -->
   

    <script src="AMatrix/assets/libs/jquery/dist/jquery.min.js"></script>    
    <script src="AMatrix/assets/libs/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="AMatrix/assets/libs/perfect-scrollbar/dist/perfect-scrollbar.jquery.min.js"></script>
    <script src="AMatrix/assets/extra-libs/sparkline/sparkline.js"></script>
    <script src="AMatrix/dist/js/waves.js"></script>
    <script src="AMatrix/dist/js/sidebarmenu.js"></script>
    <script src="AMatrix/dist/js/custom.min.js"></script>
    <script src="AMatrix/assets/libs/flot/excanvas.js"></script>
    <script src="AMatrix/assets/libs/flot/jquery.flot.js"></script>
    <script src="AMatrix/assets/libs/flot/jquery.flot.pie.js"></script>
    <script src="AMatrix/assets/libs/flot/jquery.flot.time.js"></script>
    <script src="AMatrix/assets/libs/flot/jquery.flot.stack.js"></script>
    <script src="AMatrix/assets/libs/flot/jquery.flot.crosshair.js"></script>
    <script src="AMatrix/assets/libs/flot.tooltip/js/jquery.flot.tooltip.min.js"></script>
    <script src="AMatrix/dist/js/pages/chart/chart-page-init.js"></script>
    <script src="AMatrix/dist/js/jquery-ui.min.js"></script>
    <!-- Charts js -->
    <script src="AMatrix/assets/libs/chart/matrix.interface.js"></script>
    <script src="AMatrix/assets/libs/chart/jquery.peity.min.js"></script>
    <script src="AMatrix/assets/libs/chart/matrix.charts.js"></script>
    <script src="AMatrix/assets/libs/chart/jquery.flot.pie.min.js"></script>
    <script src="AMatrix/dist/js/pages/chart/chart-page-init.js"></script>
    <!-- Calender js -->
    <script src="AMatrix/assets/libs/moment/min/moment.min.js"></script>
    <script src="AMatrix/assets/libs/fullcalendar/dist/fullcalendar.min.js"></script>
    <script src="AMatrix/dist/js/pages/calendar/cal-init.js"></script>
    <script src="AMatrix/assets/libs/chart/turning-series.js"></script>
    <!----Fount----->
    <link href="AMatrix/dist/css/icons/font-awesome/css/fa-brands.css" rel="stylesheet" />
    <link href="AMatrix/dist/css/icons/font-awesome/css/fa-brands.min.css" rel="stylesheet" />
    <link href="AMatrix/dist/css/icons/font-awesome/css/fa-regular.css" rel="stylesheet" />
    <link href="AMatrix/dist/css/icons/font-awesome/css/fa-regular.min.css" rel="stylesheet" />
    <link href="AMatrix/dist/css/icons/font-awesome/css/fontawesome-all.css" rel="stylesheet" />
    <link href="AMatrix/dist/css/icons/font-awesome/css/fontawesome-all.min.css" rel="stylesheet" />
    <link href="AMatrix/dist/css/icons/font-awesome/css/fontawesome.css" rel="stylesheet" />
    <link href="AMatrix/dist/css/icons/font-awesome/css/fontawesome.min.css" rel="stylesheet" />
    <!-- Table js -->
    <script src="Content/richtexteditor/res/patch.js"></script>
    <script src="AMatrix/assets/extra-libs/DataTables/datatables.min.js"></script>

    <script type="text/javascript" defer="defer">
        $(document).ready(function () {
            $("table[id^='table']").DataTable({
                "scrollY": "400px",
                "scrollX": "100%",
                "scrollCollapse": true,
                "searching": true,
                "paging": true
            });
        });
    </script>
</body>
</html>
