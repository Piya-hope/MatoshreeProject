<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="InvoiceReport.aspx.cs" Inherits="MatoshreeProject.InvoiceReport" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        var GridInvoiceReport = $("#GridInvoiceReport").prepend($("<thead></thead>").append($("#GridInvoiceReport").find("tr:first"))).DataTable(
            {
                "responsive": true,
                "scrollY": "400px",
                "scrollX": "100%",
                "scrollCollapse": true,
                "searching": true,
                "paging": true,
            });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
     <div class="container-fluid">
          <h5 class="font-weight-medium mb-0">Invoice Report</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="#">Report
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="InvoiceReport.aspx">Invoice Report</li>
            </ol>
        </nav>
        <br />
         <div class="row">
             <div class="col-md-12 col-sm-12 col-lg-12">
                 <div class="card">
                     <div class="card-body">
                         <div class="row">
                             <div class="col-md-2 col-sm-2 col-lg-2">
                                 <asp:Label ID="lblCustomer" Text="Customer" runat="server" CssClass="form-label"></asp:Label>
                             </div>
                             <div class="col-md-4 col-sm-4 col-lg-4">
                                 <asp:DropDownList ID="ddlCustomer" CssClass="form-control form-select" runat="server" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                             </div>
                             <div class="col-md-2 col-sm-2 col-lg-2">
                                 <asp:Label ID="lblproject" Text="Project" runat="server" CssClass="form-label"></asp:Label><br />
                             </div>
                             <div class="col-md-4 col-sm-4 col-lg-4">
                                 <asp:DropDownList ID="ddlProject" CssClass="form-control form-select" runat="server" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" AutoPostBack="true">
                                 </asp:DropDownList>
                             </div>
                         </div>
                         <br />
                         <div class="row">
                             <div class="col-md-2 col-sm-2 col-lg-2">
                                 <asp:Label ID="lblInvoiceNumber" Text="Invoice Number" runat="server" CssClass="form-label"></asp:Label><br />
                             </div>
                             <div class="col-md-4 col-sm-4 col-lg-4">
                                 <asp:DropDownList ID="ddlInvoiceNumber" CssClass="form-control form-select" runat="server">
                                 </asp:DropDownList>
                             </div>
                             <div class="col-md-2 col-sm-2 col-lg-2">
                                 <asp:Label ID="lbldate" Text="Date" runat="server" CssClass="form-label"></asp:Label>
                             </div>
                             <div class="col-md-2 col-sm-2 col-lg-2">
                                 <asp:TextBox ID="txtStartDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="StartDate(mm/dd/yyyy)"></asp:TextBox>

                             </div>
                             <div class="col-md-2 col-sm-2 col-lg-2">
                                 <asp:TextBox ID="txtEndDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="EndDate(mm/dd/yyyy)"></asp:TextBox>
                             </div>
                         </div>

                         <br />
                         <div class="row">
                             <div class="col-md-4 col-sm-4 col-lg-4"></div>

                             <div class="col-md-1 col-sm-1 col-lg-1">
                                 <asp:Button ID="btnSearchRerort" runat="server" Text="View Report" CssClass="btn btn-primary mr-4 btn-sm" OnClick="btnSearchRerort_Click" /> 
                             </div>
                            &nbsp; &nbsp; &nbsp; &nbsp;
                                 <div class="col-md-1 col-sm-1 col-lg-1">
                                     <div class="bd-example">
                                         <div class="btn-group">
                                             <button class="btn btn-sm btn-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                             <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                             <div class="dropdown-menu">
                                                 <asp:LinkButton ID="lnkbtnExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                                                 <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDF_Click"></asp:LinkButton>
                                             </div>
                                         </div>

                                     </div>
                                 </div>
                               
                             <div class="col-md-1 col-sm-1 col-lg-1">
                                   <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-danger btn-sm" OnClick="btnClear_Click" />
                             </div>

                             <div class="col-md-5 col-sm-5 col-lg-5">
                                 <!------PDF code--------->
                                 <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />
                                 <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-dark " Visible="false"></asp:Label>
                                 <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                 <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                 <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                 <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                 <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," Font-Size="12px" Visible="false"></asp:Label>
                                 <asp:Label ID="lblpincode" runat="server" Text="PIN:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                 <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                 <asp:Label ID="lblphone" runat="server" Text="Phone:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                 <asp:Label ID="lblphoneNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                 <asp:Label ID="lblvat" runat="server" Text="VAT NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                 <asp:Label ID="lblVatNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                 <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                 <asp:Label ID="lblGSTNo1A" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                 <!------PDF code--------->

                             </div>
                         

                     </div>
                 </div>
            </div>
         </div>
             </div>

          <div class="row">
             <div class="col-md-12 col-sm-12 col-lg-12">
                 <div class="card">
                     <div class="card-body">
                          <h5>View Invoice Details</h5>
                         <hr />

                         <asp:GridView ID="GridInvoiceReport" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                             ClientIDMode="Static" EmptyDataText="No Records found" DataKeyNames="ID" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                             <Columns>

                                 <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px" >
                                     <ItemTemplate>
                                         <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px"/>
                                     </ItemTemplate>
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                     <EditItemTemplate>
                                         <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="InvoiceNo" SortExpression="InvoiceNo" HeaderStyle-Width="120px" HeaderStyle-Font-Size="12px">
                                     <EditItemTemplate>
                                         <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Bind("InvoiceNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="lblInvoiceNo1" runat="server" Text='<%# Bind("InvoiceNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                     </ItemTemplate>
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Amount" SortExpression="InvoiceTotalAmont" HeaderStyle-Font-Size="12px">
                                     <EditItemTemplate>
                                         <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("InvoiceTotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("InvoiceTotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Customer" SortExpression="Cust_Name" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                     <EditItemTemplate>
                                         <asp:Label ID="lblCustomer" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="lblCustomer1" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Project" SortExpression="ProjectName" HeaderStyle-Font-Size="12px">
                                     <EditItemTemplate>
                                         <asp:Label ID="lbProjectName" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="lblProjectName1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="InvoiceDate" SortExpression="InvoiceDate" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                     <EditItemTemplate>
                                         <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Bind("InvoiceDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="lblInvoiceDate1" runat="server" Text='<%# Bind("InvoiceDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                     </ItemTemplate>
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="DueDate" SortExpression="Expiry_Date" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                     <EditItemTemplate>
                                         <asp:Label ID="lblEndDate" runat="server" Text='<%# Bind("Expiry_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="lblEndDate1" runat="server" Text='<%# Bind("Expiry_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                     </ItemTemplate>
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="SalesAgent" SortExpression="SalesAgent" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                     <EditItemTemplate>
                                         <asp:Label ID="lblSalesAgent" runat="server" Text='<%# Bind("Sales_Agent") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="lblSalesAgent1" runat="server" Text='<%# Bind("Sales_Agent") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                     <EditItemTemplate>
                                         <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="lblStatus1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>

                                 
                             </Columns>
                             <EmptyDataTemplate>
                                 <div align="center" style="color: red">
                                     <h6>No records found.</h6>
                                 </div>
                             </EmptyDataTemplate>
                         </asp:GridView>
                     </div>
                 </div>
             </div>
         </div>
     </div>

    <%-- <div class="container-fluid">--%>
        
   <%--  </div>--%>
</asp:Content>
