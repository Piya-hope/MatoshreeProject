<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ProposalDetails.aspx.cs" Inherits="MatoshreeProject.ProposalDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="text/css" href="https://cdn.datatabls.net/responsive/1.0.7/js/dataTabls.responsive.min.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatabls.net/responsive/1.10.9/js/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatabls.net/responsive/1.0.7/js/dataTabls.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatabls.net/1.10.9/js/dataTabls.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridPropsal = $("#GridPropsal").prepend($("<thead></thead>").append($("#GridPropsal").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridLeadReminder = $("#GridLeadReminder").prepend($("<thead></thead>").append($("#GridLeadReminder").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
            var GridTask1 = $("#GridTask1").prepend($("<thead></thead>").append($("#GridTask1").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
        });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <%-- BreadCrumbs --%>
        <h5 class="font-weight-medium mb-0">Proposal</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="PraposalsDetails.aspx">Proposal</li>
            </ol>
        </nav>
        <%-- BreadCrumbs --%>
        <br />
        <%-- Toaster --%>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="row">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                                    <div id="addnew" runat="server">
                                        <asp:Button ID="btnNewProposal" runat="server" Text="New Proposal" CssClass="btn btn-sm btn-primary" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- Toaster --%>
                    <div class="col-md-4 col-sm-4 col-xl-4 col-lg-4">
                        <div id="Toasteralert" runat="server" visible="false">
                            <div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
                                <div class="d-flex">
                                    <div class="toast-body">
                                        <asp:Label ID="lblMessage" runat="server" Text="" Font-Size="13.5px" ForeColor="Black"></asp:Label>
                                    </div>
                                    <button type="button" class="btn-close me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                                </div>
                            </div>
                        </div>

                        <div id="deleteToaster" runat="server" visible="false">
                            <div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
                                <div class="d-flex">
                                    <div class="toast-body">
                                        <asp:Label ID="lblMesDelete" runat="server" Text="" Font-Size="13.5px" ForeColor="Black"></asp:Label>
                                    </div>
                                    <button type="button" class="btn-close me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- Toaster --%>
                </div>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-md-5 col-sm-5 col-xl-5 col-lg-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                                <h5 class="font-weight-medium mt-3 mb-3">View Proposal Details</h5>
                                <asp:Label ID="lblpraposalID" runat="server" Text="" Visible="false"></asp:Label>
                                <hr />
                                <br />
                                <asp:GridView ID="GridPropsal" runat="server" ScrollBars="Both" CssClass="table border table-hover table-bordered text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" OnRowDataBound="GridPropsal_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID1" SortExpression="ID1" HeaderStyle-Font-Size="14px" Visible="false">

                                            <ItemTemplate>
                                                <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ProposalNumber" SortExpression="Proposal" HeaderStyle-Font-Size="12px">

                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblProposalNo1" runat="server" Text='<%# Bind("ProposalNO") %>' TabIndex="6" OnClick="lblProposalNo1_Click" Font-Bold="false" Font-Size="12px" ForeColor="#0099ff"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Subject" SortExpression="Subject" HeaderStyle-Font-Size="12px">

                                            <ItemTemplate>
                                                <asp:Label ID="lblSubject1" runat="server" Text='<%# Bind("Subject") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total" SortExpression="Total" HeaderStyle-Font-Size="12px">

                                            <ItemTemplate>
                                                <asp:Label ID="lblTotal1" runat="server" Text='<%# Bind( "GrandTotal") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Date" SortExpression="Date" HeaderStyle-Font-Size="12px">

                                            <ItemTemplate>
                                                <asp:Label ID="lblDate1" runat="server" Text='<%# Bind("ProDate", "{0:yyyy-MM-dd}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="To" SortExpression="To" HeaderStyle-Font-Size="12px">

                                            <ItemTemplate>
                                                <asp:Label ID="lblTo1" runat="server" Text='<%# Bind("To") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label><br />
                                                <asp:Label ID="lblRealetedTo1" runat="server" Text='<%# Bind("RelatedTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Black"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Project" SortExpression="Project" HeaderStyle-Font-Size="12px">

                                            <ItemTemplate>
                                                <asp:Label ID="lblProject1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="OpenTill" SortExpression="Open_Till" HeaderStyle-Font-Size="12px">

                                            <ItemTemplate>
                                                <asp:Label ID="lblOpenTill" runat="server" Text='<%# Bind("ProOpenTillDate", "{0:yyyy-MM-dd}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="RealetedTo" SortExpression="RealetedTo" HeaderStyle-Font-Size="12px" Visible="false">

                                            <ItemTemplate>
                                                <asp:Label ID="lblRealetedTo12" runat="server" Text='<%# Bind("RelatedTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="CreateDate" SortExpression="Create_Date" HeaderStyle-Font-Size="12px" Visible="false">

                                            <ItemTemplate>
                                                <asp:Label ID="lblCreateDate1" runat="server" Text='<%# Bind("CreateDate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-Font-Size="12px">

                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus1" runat="server" Text='<%# Bind("StatusName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEditpro" runat="server" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDeletepro" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClick="btnDeletepro_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
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

            <div class="col-md-7 col-lg-7 col-sm-7 col-xs-7">
                <asp:Label ID="lblpraposalnote" runat="server" Visible="false"></asp:Label>
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                                <ul class="nav nav-tabs" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" data-bs-toggle="tab" href="#home" role="tab"><span class="hidden-sm-up" font-size="12px"></span>
                                            <span class="hidden-xs-down">Proposal</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#profile" role="tab"><span class="hidden-sm-up" font-size="12px"></span>
                                            <span class="hidden-xs-down">Comments</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#profile1" role="tab"><span class="hidden-sm-up" font-size="12px"></span>
                                            <span class="hidden-xs-down">Reminders</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#profile2" role="tab"><span class="hidden-sm-up" font-size="12px"></span>
                                            <span class="hidden-xs-down">Tasks</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#profile3" role="tab"><span class="hidden-sm-up" font-size="12px"></span>
                                            <span class="hidden-xs-down">Notes</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#profile4" role="tab"><span class="hidden-sm-up" font-size="12px"></span>
                                            <span class="hidden-xs-down">Attach File</span></a>
                                    </li>

                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#profile5" role="tab"><span class="hidden-sm-up" font-size="12px"></span>
                                            <span class="hidden-xs-down">ActivityLongs</span></a>
                                    </li>
                                </ul>
                            </div>

                        </div>

                        <hr />
                        <br />
                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4  text-lg-star">
                                <div id="Div1" runat="server">
                                    <asp:Button ID="btndraft" runat="server" Text="Draft" CssClass="btn btn-sm btn-outline-info" />
                                </div>
                            </div>

                            <div class="col-md-8 col-lg-8 col-sm-8 col-xs-8 text-end">
                                <div class="mb-2">
                                    <button class="btn btn-sm btn-outline-info"><i class='ti ti-edit'></i></button>
                                    &nbsp;
                                    <asp:LinkButton ID="lnkbtnpdf" runat="server" CssClass="btn btn-sm btn-outline-danger"><iconify-icon icon="ph:file-pdf"></iconify-icon></asp:LinkButton>
                                    &nbsp;
                                   <asp:LinkButton ID="LinkbtnMessage" runat="server" CssClass="btn btn-sm btn-outline-primary"><iconify-icon icon="solar:letter-unread-linear" class="aside-icon"></iconify-icon></asp:LinkButton>
                                    &nbsp;
                                    <div class="btn-group">
                                        <button class="btn btn-sm btn-outline-info dropdown-toggle " data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">More</button>
                                        <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="lnkview" runat="server" Text="View Proposal" CssClass="dropdown-item "></asp:LinkButton>
                                            <asp:LinkButton ID="lnkcopy" runat="server" Text="Copy" CssClass="dropdown-item "></asp:LinkButton>
                                            <asp:LinkButton ID="lnksend" runat="server" Text="Mark as Send" CssClass="dropdown-item "></asp:LinkButton>
                                            <asp:LinkButton ID="lnkopen" runat="server" Text="Mark As Open" CssClass="dropdown-item "></asp:LinkButton>
                                            <asp:LinkButton ID="lnkrevised" runat="server" Text="Mark As Revised" CssClass="dropdown-item "></asp:LinkButton>
                                            <asp:LinkButton ID="lnkdeclined" runat="server" Text="Mark As Declined" CssClass="dropdown-item "></asp:LinkButton>
                                            <asp:LinkButton ID="lnkaccpt" runat="server" Text="Mark As Accepted" CssClass="dropdown-item"></asp:LinkButton>
                                            <asp:LinkButton ID="linkdelete" Text="Delete" runat="server" CssClass="dropdown-item text-danger"></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="btn-group">
                                        <button class="btn btn-sm btn-outline-success dropdown-toggle " data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Convert</button>
                                        <asp:Button ID="btnconvert" runat="server" Style="display: none" />
                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="LinkButton4" runat="server" Text="Estimate" CssClass="dropdown-item text-info"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton5" runat="server" Text="Invoice" CssClass="dropdown-item text-danger "></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="tab-content tabcontent-border">

                            <div class="tab-pane active" id="home" role="tabpanel">
                                <div class="p-20">
                                    <div class="row">
                                        <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                                            <div class="mb-2">
                                                <div class="row">
                                                    <asp:LinkButton ID="lnkPrint" runat="server" CssClass="btn-dark p-1 rounded-3 font-18">
                                                        <i class="fas fa-print"></i> 
                                                    </asp:LinkButton>
                                                    &nbsp;&nbsp;
                                                    <asp:LinkButton ID="lnkViewPDF" runat="server" CssClass="btn-dark  p-1 rounded-3 font-18">
                                                        <i class="fas fa-file-pdf"></i> 
                                                    </asp:LinkButton>
                                                    &nbsp;&nbsp;
                                                    <asp:LinkButton ID="lnkSendEmail" runat="server" CssClass="btn-dark  p-1 rounded-3 font-18">
                                                        <i class="fas fa-envelope"></i> 
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%-- Proposal Details and address--%>
                                    <div class="row">
                                        <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                                            <div class="mb-2">
                                                <%-- <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />
                                                <asp:Image ID="Image2" runat="server" Style="display: none; border: 1px solid #ccc" />--%>
                                                <asp:Label ID="lblProposalNumber" runat="server" Text="" CssClass="font-bold text-primary "></asp:Label><br />
                                                <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-primary "></asp:Label><br />
                                                <asp:Label ID="lbladdress11" runat="server" Text="" CssClass=""></asp:Label>
                                                <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass=""></asp:Label><br />
                                                <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass=""></asp:Label>
                                                <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass=""></asp:Label>
                                                <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," CssClass=""></asp:Label><br />
                                                <asp:Label ID="lblpincode" runat="server" Text="PIN:" CssClass=""></asp:Label>
                                                <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" CssClass=""></asp:Label><br />
                                                <asp:Label ID="Label6" runat="server" Text="Phone:" CssClass="" Font-Bold="true"></asp:Label>
                                                <asp:Label ID="lblphoneNo1" runat="server" Text="" CssClass=""></asp:Label><br />
                                                <asp:Label ID="lblvat" runat="server" Text="VAT NO:" CssClass="" Font-Bold="true"></asp:Label>
                                                <asp:Label ID="lblVatNo1" runat="server" Text="" CssClass=""></asp:Label><br />
                                                <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" CssClass="" Font-Bold="true"></asp:Label>
                                                <asp:Label ID="lblGSTNo1A" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                        </div>

                                        <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 text-end">
                                            <asp:Label ID="lblID" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                            <asp:Label ID="lblWordTo" runat="server" Text="To" CssClass="font-bold text-primary"></asp:Label><br />
                                            <asp:Label ID="lblName1" runat="server" Text="" CssClass=""></asp:Label><br />
                                            <asp:Label ID="lblToAddress1" runat="server" Text="" CssClass=""></asp:Label><br />
                                            <asp:Label ID="lblCity1" runat="server" Text="" CssClass=""></asp:Label><br />
                                            <asp:Label ID="lblDistrict1" runat="server" Text="" CssClass=""></asp:Label>
                                            <asp:Label ID="lblTostate1" runat="server" Text="" CssClass=""></asp:Label><br />
                                            <asp:Label ID="lblZipCode" runat="server" Text="" CssClass=""></asp:Label><br />
                                            <asp:Label ID="lblPhone1" runat="server" Text="" CssClass=""></asp:Label><br />
                                            <asp:Label ID="lblEmail1" runat="server" Text="" CssClass="" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                    <br />

                                    <%--Proposal Table--%>

                                    <div class="row">
                                        <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                                            <div class="table-responsive">
                                                <asp:GridView ID="GridProposalDetail" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4"
                                                    ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="130px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblItem" runat="server" Text="Item" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblItem1" runat="server" Text='<%# Bind("ProposalItem") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="180px" ItemStyle-Width="200px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' Font-Bold="false" Font-Size="12px" Width="180px" Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblHSNname" runat="server" Text="HSN" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblHSN1" runat="server" Text='<%# Bind("HSN") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="60px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblQuantity" runat="server" Text="Qnty" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Qnty") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="60px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblRate" runat="server" Text="Rate" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRate1" runat="server" Text='<%# Bind("Rate") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblSubAmont" runat="server" Text="SubTotal" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubAmont1" runat="server" Text='<%# Bind("SubTotal") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="120px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblTax" runat="server" Text="GST1" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTaxValees" runat="server" Text='<%# Bind("Tax1Rate") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblTax1" runat="server" Text='<%# Bind("Tax1Name") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="GSTAmt" SortExpression="Tax1Amount" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="true">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblTax1Rate" runat="server" Text='<%# Bind("Tax1Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTax1Rate1" runat="server" Text='<%# Bind("Tax1Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="120px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblTax1A" runat="server" Text="GST2" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTaxValees1A" runat="server" Text='<%# Bind("Tax2Rate") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblTax1A" runat="server" Text='<%# Bind("Tax2Name") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="GST2Amt" SortExpression="Tax2Amount" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="true">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblTax2Rate" runat="server" Text='<%# Bind("Tax2Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTax2Rate1" runat="server" Text='<%# Bind("Tax2Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblAmount" runat="server" Text="GrandAmount" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("TotalAmont") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                    </Columns>

                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>

                                    <%-- subcost--%>
                                    <div class="row">
                                        <asp:Table ID="Table2" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12">
                                            <asp:TableRow ID="TableRow3" runat="server" class="mb-2">
                                                <asp:TableCell CssClass="col-md-8 col-sm-8 col-lg-8">
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                    <asp:Label ID="lblSubTotalWord" CssClass="form-label me-2 ms-2" runat="server" Text="Sub Total :" Visible="false"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                    <asp:Label ID="lblSubTotalCost" runat="server" Text="₹ 0.00" Font-Size="12px" Font-Bold="false" Visible="false"></asp:Label>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </div>

                                    <%-- Discount--%>
                                    <div class="row">
                                        <asp:Table ID="Table3" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12">
                                            <asp:TableRow ID="TableRow4" runat="server" class="mb-2">
                                                <asp:TableCell CssClass="col-md-8 col-sm-8 col-lg-8">
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                    <asp:Label ID="lblDiscountWord" runat="server" Text="Discount :" CssClass="form-label me-2 ms-2" Visible="false"></asp:Label>
                                                </asp:TableCell>

                                                <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                    <%--Labels--%>
                                                    <asp:Label ID="lblDiscountCost" runat="server" Text="₹ 0.00" Font-Size="12px" Font-Bold="false" Visible="false"></asp:Label>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </div>

                                    <%-- Adjustment--%>
                                    <div class="row">
                                        <asp:Table ID="Table4" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12">
                                            <asp:TableRow ID="TableRow5" runat="server" class="mb-2">
                                                <asp:TableCell CssClass="col-md-8 col-sm-8 col-lg-8">
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                    <asp:Label ID="lblAdjustmentWorrd" runat="server" Text="RoundUp:" CssClass="form-label ms-2" Visible="false"></asp:Label>
                                                </asp:TableCell>

                                                <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                    <%--Labels--%>
                                                    <asp:Label ID="lblAdjustmentCost" runat="server" Text="₹0.00" Font-Size="12px" Font-Bold="false" Visible="false"></asp:Label>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </div>

                                    <%-- Total--%>
                                    <div class="row">
                                        <asp:Table ID="Table5" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12">
                                            <asp:TableRow ID="TableRow6" runat="server" class="mb-2">
                                                <asp:TableCell CssClass="col-md-8 col-sm-8 col-lg-8"></asp:TableCell>
                                                <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                    <asp:Label ID="lblGrandTotalWord" CssClass="form-label" runat="server" Text="Total:" Visible="false"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                    <%--Labels--%>
                                                    <asp:Label ID="lbltotalAmonutProposalCost" runat="server" Text="₹0.00" Font-Size="12px" Font-Bold="false" Visible="false"></asp:Label>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                            <div class="mb-2">
                                                <asp:LinkButton ID="linkbtnMergeField" runat="server" Font-Size="12px" OnClick="linkbtnMergeField_Click">Availables Merge Fields</asp:LinkButton>
                                                <br />
                                                <div class="row">
                                                    <div class="table-responsive h-25">
                                                        <table class="table table-bordered" id="tblcontract" runat="server" visible="false">
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblitem" runat="server" Text="Item Table" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonitem" CssClass="text-right" runat="server" Font-Size="12px" Text="{Item_Table}" OnClick="LinkButtonitem_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label3" runat="server" Text="ProPosal Number" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">

                                                                    <asp:LinkButton ID="LinkButtonnumber" runat="server" Font-Size="12px" Text="{ProPosal_Number}" OnClick="LinkButtonnumber_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblsub" runat="server" Text="Subject" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonsubject" runat="server" Font-Size="12px" Text="{Subject}" OnClick="LinkButtonsubject_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lbltotal" runat="server" Text="Proposal Total" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtontotal" runat="server" Font-Size="12px" Text="{Proposal_Total}" OnClick="LinkButtontotal_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblsubtotal" runat="server" Text="Proposal subtotal" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonsubtotal" runat="server" Font-Size="12px" Text="{Proposal_subtotal}" OnClick="LinkButtonsubtotal_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblopen" runat="server" Text="Open Till" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonopentill" runat="server" Font-Size="12px" Text="{Open_Till}" OnClick="LinkButtonopentill_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblassign" runat="server" Text="Proposal Assigned" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonAssigned" runat="server" Font-Size="12px" Text="{Proposal_Assigned}" OnClick="LinkButtonAssigned_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblTo" runat="server" Text="Proposal To" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonTo" runat="server" Font-Size="12px" Text="{Proposal_To}" OnClick="LinkButtonTo_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblAddress" runat="server" Text="Address" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonAddress" runat="server" Font-Size="12px" Text="{Address}" OnClick="LinkButtonAddress_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblcity" runat="server" Text="City" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncity" runat="server" Font-Size="12px" Text="{City}" OnClick="LinkButtoncity_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblstate" runat="server" Text="State" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonstate" runat="server" Font-Size="12px" Text="{State}" OnClick="LinkButtonstate_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblZip" runat="server" Text="Zip Code" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonzipcode" runat="server" Font-Size="12px" Text="{Zip_Code}" OnClick="LinkButtonzipcode_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblcountry" runat="server" Text="Country" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncountry" runat="server" Font-Size="12px" Text="{Country}" OnClick="LinkButtoncountry_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblemail" runat="server" Text="Email" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonEmail" runat="server" Font-Size="12px" Text="{Email}" OnClick="LinkButtonEmail_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblcontractsubj" runat="server" Text="Contract Subject" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncontract_subject" runat="server" Font-Size="12px" Text="{Contract Subject}" OnClick="LinkButtoncontract_subject_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblphone" runat="server" Text="Phone" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonphone" runat="server" Font-Size="12px" Text="{Phone}" OnClick="LinkButtonphone_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lbllink" runat="server" Text="Proposal Link" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonlink" runat="server" Font-Size="12px" Text="{Proposal Link}" OnClick="LinkButtonlink_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblAt" runat="server" Text="Created At" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonAt" runat="server" Font-Size="12px" Text="{Created_At}" OnClick="LinkButtonAt_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lbldate" runat="server" Text="Proposal Date" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonDate" runat="server" Font-Size="12px" Text="{Proposal_Date}" OnClick="LinkButtonDate_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblurl" runat="server" Text="Logo Url" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonlogo_url" runat="server" Font-Size="12px" Text="{Logo Url}" OnClick="LinkButtonlogo_url_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblimg" runat="server" Text="Logo Image With URL" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncrm_url" runat="server" Font-Size="12px" Text="{Logo_Image_With_URL}" OnClick="LinkButtoncrm_url_Click1"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lbldark" runat="server" Text="Dark Logo With Url" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonatmin_url" runat="server" Font-Size="12px" Text="{Dark_Logo_With_Url}" OnClick="LinkButtonatmin_url_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblcrm" runat="server" Text="CRM Url" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncrmurl" runat="server" Font-Size="12px" Text="{CRM_Url}" OnClick="LinkButtoncrmurl_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lbladmin" runat="server" Text="Admin Url" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonAdminurl" runat="server" Font-Size="12px" Text="{Admin_Url}" OnClick="LinkButtonAdminurl_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lbldomain" runat="server" Text="Main Domain" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtondomain" runat="server" Font-Size="12px" Text="{Main_Domain}" OnClick="LinkButtondomain_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblname" runat="server" Text="Company Name" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButton_name" runat="server" Font-Size="12px" Text="{Company_Name}" OnClick="LinkButton_name_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblgdpr" runat="server" Text="(GDPR)Terms & Condition URL" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonconditionurl" runat="server" Font-Size="12px" Text="{(GDPR)Terms_Condition_URL}" OnClick="LinkButtonconditionurl_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="lblPolicy" runat="server" Text="(GDPR)Privacy Policy URL" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonpolicyurl" runat="server" Font-Size="12px" Text="{(GDPR)Privacy_Policy_URL}" OnClick="LinkButtonpolicyurl_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <%--<asp:Label ID="Label27" runat="server" Text="clear" Font-Bold="true" Font-Size="12px"></asp:Label>--%>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="Linkclear" runat="server" CssClass="text-danger" Font-Size="12px" Text="{clear}" OnClick="Linkclear_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="textBox" runat="server" class="required form-control" Text="Proposal_Items" TextMode="MultiLine" Height="200px" Visible="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane p-20" id="profile" role="tabpanel">
                                <div class="p-20">
                                    <div class="row">
                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblcomment" runat="server" Text="Comment" Font-Bold="true" Font-Size="14px"></asp:Label>&nbsp;<span></span>
                                                <asp:TextBox ID="txtcomment" CssClass="form-control" runat="server" placeholder="Enter comment" TextMode="MultiLine"></asp:TextBox>
                                                <br />

                                                <div class="mb-2">
                                                    <asp:Button ID="btn_comment" runat="server" Text="Add Comment" class="btn btn-info btn-sm" OnClick="btn_comment_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane p-20" id="profile1" role="tabpanel">
                                <div class="p-20">
                                    <div class="row">
                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                            <div class="mb-2">
                                                <asp:LinkButton ID="lnkbtnCreateRemainder" runat="server" ValidationGroup="btn14" CssClass="btn btn-sm font-medium btnmodalPopup btn-outline-info btn-sm " data-bs-toggle="modal"
                                                    data-bs-target="#ReminderID" OnClick="lnkbtnCreateRemainder_Click"> <i class="ti ti-bell"></i>Set Proposal Reminder</asp:LinkButton>
                                            </div>
                                            <div class="modal fade" id="ReminderID" data-bs-backdrop="static"
                                                data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                                                aria-hidden="true">
                                                <div class="modal-dialog modal-dialog-scrollable">
                                                    <div class="modal-content">
                                                        <div class="modal-header d-flex align-items-center">
                                                            <h4 class="modal-title" id="myLargeModalLabel"></h4>
                                                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                                        </div>
                                                        <div class="modal-body">
                                                            <div id="craeteButton" runat="server" visible="true">
                                                                <h5 class="card-title" style="color: blue">Add Reminder</h5>
                                                                <hr />

                                                                <div id="Div2" runat="server" visible="true">

                                                                    <div class="mb-2">

                                                                        <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                            <asp:Label ID="Label1" runat="server" CssClass="form-label" Text="Date To be Notified"></asp:Label>
                                                                            <br />
                                                                            <asp:Label ID="lbldate1" runat="server" Text="" Visible="false"></asp:Label>
                                                                            <asp:TextBox ID="txtDateNotified12" type="DateTime-Local" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter Date"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtDateNotified12" Display="Dynamic" runat="server" ErrorMessage="Enter Date" ForeColor="Red" ValidationGroup="RemainderLeads" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="mb-2">

                                                                        <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                            <asp:Label ID="lblsetto" runat="server" CssClass="form-label" Text="Set To Remainder"></asp:Label>
                                                                            <br />

                                                                            <asp:DropDownList ID="ddlreminderMember12" runat="server" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddlreminderMember12" Display="Dynamic" runat="server" ErrorMessage="Select Member" ForeColor="Red" ValidationGroup="RemainderLeads" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>

                                                                    <div class="mb-2">


                                                                        <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                            <asp:Label ID="lbldescricpt" runat="server" CssClass="form-label" Text="Description"></asp:Label>
                                                                            <br />

                                                                            <asp:TextBox ID="txtDescription12" TextMode="MultiLine" CssClass="form-control border" Style="display: inline-block;" runat="server" placeholder="Enter Description"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                    <div class="mb-2">

                                                                        <div class="checkbox checkbox-primary">
                                                                            <asp:CheckBox ID="chksetRemainderforEmail2" runat="server" CssClass="w-50 h-50" />
                                                                            <asp:Label ID="lblReminder" runat="server" Text="Send also an email for this reminder"></asp:Label>

                                                                        </div>
                                                                    </div>

                                                                    <div class="mb-2">

                                                                        <div class="row">

                                                                            <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6 text-left">
                                                                                <asp:Button ID="btnCreateRemainder12" runat="server" CssClass="btn btn-info btn-sm " Text="Create Reminder" OnClick="btnCreateRemainder12_Click" />
                                                                                &nbsp
                                                                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" OnClick="btnClear_Click" />

                                                                            </div>
                                                                            <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6"></div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="modal-footer">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div id="myModal" class="modal">
                                                    <div class="modal-dialog">

                                                        <div class="modal-content">
                                                            <div class="modal-header">

                                                                <h5 class="modal-title">Update Reminder</h5>
                                                                <hr />
                                                            </div>
                                                            <div class="modal-body">

                                                                <div class="row">
                                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                                        <h5 class="card-title" style="color: blue">Update Reminder</h5>
                                                                        <hr />

                                                                        <div id="Div3" runat="server" visible="true">

                                                                            <div class="mb-2">

                                                                                <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                                    <asp:Label ID="lblDateNotified1" runat="server" CssClass="form-label" sText="Date To be Notified"></asp:Label>
                                                                                    <br />
                                                                                    <asp:Label ID="lblRID1" runat="server" Text="" Visible="false"></asp:Label>
                                                                                    <asp:TextBox ID="txtDateNotified1" type="DateTime-Local" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter Date"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDateNotified1" Display="Dynamic" runat="server" ErrorMessage="Enter Date" ForeColor="Red" ValidationGroup="RemainderLeads" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="mb-2">

                                                                                <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                                    <asp:Label ID="lblSetRemainder1" runat="server" CssClass="form-label" Text="Set To Remainder"></asp:Label>
                                                                                    <br />

                                                                                    <asp:DropDownList ID="ddlreminderMember1" runat="server" CssClass="form-control">
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlreminderMember1" Display="Dynamic" runat="server" ErrorMessage="Select Member" ForeColor="Red" ValidationGroup="RemainderLeads" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                            <div class="mb-2">


                                                                                <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                                    <asp:Label ID="lbldescript1" runat="server" CssClass="form-label" Text="Description"></asp:Label>
                                                                                    <br />

                                                                                    <asp:TextBox ID="txtDescription1" TextMode="MultiLine" CssClass="form-control border" Style="display: inline-block;" runat="server" placeholder="Enter Description"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="mb-2">

                                                                                <div class="checkbox checkbox-primary">
                                                                                    <asp:CheckBox ID="chksetRemainderforEmail1" runat="server" CssClass="w-50 h-50" />
                                                                                    <asp:Label ID="lblsetRemainderforEmail1" runat="server" Text="Send also an email for this reminder"></asp:Label>

                                                                                </div>
                                                                            </div>
                                                                            <asp:Label ID="lblStaffEmail" runat="server" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblStaffDesignation" runat="server" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblEmpName11" runat="server" Visible="false"></asp:Label>

                                                                            <div class="mb-2">

                                                                                <div class="row">

                                                                                    <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6 text-left">
                                                                                        <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="btn btn-sm btn-success" OnClick="btnupdate_Click" />
                                                                                        &nbsp
                                                                
                                                                                   <button type="button" id="btnCloseModalFooter" class="btn btn-danger btn-sm">Close</button>

                                                                                    </div>
                                                                                    <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6"></div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="modal-footer">
                                                                <%-- <button type="button" id="btnCloseModalFooter" class="btn btn-danger btn-sm">Close</button>--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <hr />
                                        <div class="tab-pane " id="Reminders" role="tabpanel">
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                                                    <h5 class="mb-3">View Reminder Details</h5>
                                                    <hr />
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                                                            <div class="bd-example">
                                                                <div class="btn-group">
                                                                    <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                                    <asp:Button ID="Button2" runat="server" Style="display: none" />
                                                                    <div class="dropdown-menu">
                                                                        <asp:LinkButton ID="linkexcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="linkexcel_Click"></asp:LinkButton>
                                                                        <asp:LinkButton ID="linkpdf" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkpdf_Click"></asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <asp:Button ID="btnvisiblity" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btnvisiblity_Click" />
                                                                <asp:Button ID="btnreload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btnreload_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                            <asp:GridView ID="GridProposalReminder" runat="server" ScrollBars="Both" CssClass="table border table-hover table-bordered text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="R_ID" OnRowDataBound="GridProposalReminder_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("R_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblID1" runat="server" Text='<%# Bind("R_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px">
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="NotifyDate" SortExpression="NotifyDate" HeaderStyle-Font-Size="12px">
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblnotifyDate" runat="server" Text='<%# Bind("NotifyDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblnotifyDate1" runat="server" Text='<%# Bind("NotifyDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remainder" SortExpression="SetToReminder" HeaderStyle-Font-Size="12px">
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblSetToReminder" runat="server" Text='<%# Bind("SetToReminder") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSetToReminder1" runat="server" Text='<%# Bind("SetToReminder") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="status" SortExpression="status" HeaderStyle-Font-Size="12px" Visible="false">
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblStatuse" runat="server" Text='<%# Bind("status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatuse1" runat="server" Text='<%# Bind("status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnEditReminder" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditReminder_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnDeleteReminder" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteReminder_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                        </EditItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane p-20" id="profile2" role="tabpanel">
                                <div class="p-20">
                                    <div class="row">
                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                            <div class="mb-2">
                                                <asp:LinkButton ID="LnkBtnTask" runat="server" ControlToValidate="LnkBtnTask" CssClass="btn btn-sm btn-info">
                                          New Task </asp:LinkButton>
                                            </div>
                                            <hr />
                                            <div class="mb-2">
                                                <div class="row">
                                                    <div class="tab-pane " id="Tasks" role="tabpanel">
                                                        <div class="row">
                                                            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                                                                <h5 class="mb-3">View Task Details</h5>
                                                                <hr />
                                                                <div class="row">
                                                                    <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                                                                        <div class="bd-example">
                                                                            <div class="btn-group">
                                                                                <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                                                <%--<asp:Button ID="Button1" runat="server" Style="display: none" />--%>
                                                                                <div class="dropdown-menu">
                                                                                    <asp:LinkButton ID="lnkbtnLeadTaskExcel" Text="Excel" runat="server" CssClass="dropdown-item"></asp:LinkButton>
                                                                                    <asp:LinkButton ID="linkbtnLeadTaskPDF" runat="server" Text="PDF" CssClass="dropdown-item"></asp:LinkButton>
                                                                                </div>
                                                                            </div>
                                                                            <asp:Button ID="lnkbtnLeadTaskVisibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" />
                                                                            <asp:Button ID="lnkbtnLeadTaskReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <br />
                                                                <br />
                                                                <asp:GridView ID="GridTask1" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-responsive table-hover text-nowrap align-content-center" Style="width: 150%" AutoGenerateColumns="false" CellPadding="4"
                                                                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="ID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Name" SortExpression="Subject" HeaderStyle-Font-Size="12px">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txttaskName" runat="server" Text='<%# Bind("Subject") %>' Font-Size="12px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbltaskName1" runat="server" Text='<%# Bind("Subject") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Start_Date" SortExpression="Start_Date" HeaderStyle-Font-Size="12px">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblStart_Date" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblStart_Date1" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Due_Date" SortExpression="Due_Date" HeaderStyle-Font-Size="12px">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblDue_Date" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDue_Date1" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Assigned To" SortExpression="AssignTo" HeaderStyle-Font-Size="12px">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblReletd_To" runat="server" Text='<%# Bind("AssignTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <div class="m-2">
                                                                                    <asp:BulletedList ID="bulletlist1" runat="server" BulletStyle="Circle" CssClass="" Font-Size="12px">
                                                                                    </asp:BulletedList>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Status" SortExpression="TaskStatus" HeaderStyle-Font-Size="12px">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblTaskStatus" runat="server" Text='<%#Bind("TaskStatus") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="ddlTaskStatus" runat="server" CssClass="form-control " AutoPostBack="true" Font-Size="12px">
                                                                                    <asp:ListItem Text="In Progress" Value="In Progress"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mark as Not Started" Value="Mark as Not Started"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mark as Testing" Value="Mark as Testing"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mark as Awaiting Feedback" Value="Mark as Awaiting Feedback"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mark as Complete" Value="Mark as Complete"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:Label ID="lblTaskStatus1" runat="server" Text='<%#Bind("TaskStatus") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="false">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Button ID="btnStatus" runat="server" Text='<%# Bind("Status") %>' CssClass="btn btn-info pull-left display-block mright5" TabIndex="126" />
                                                                                <asp:Label ID="lblstatus1" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false" Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Reapeted" SortExpression="Reapet_Every" HeaderStyle-Font-Size="12px" Visible="false">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblReapet_Every" runat="server" Text='<%# Bind("Reapet_Every") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblReapet_Every1" runat="server" Text='<%# Bind("Reapet_Every") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Priority" SortExpression="Priority" HeaderStyle-Font-Size="12px">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblPriority" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control " AutoPostBack="true">
                                                                                    <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                                                                                    <asp:ListItem Text="High" Value="High"></asp:ListItem>
                                                                                    <asp:ListItem Text="Low" Value="Low"></asp:ListItem>
                                                                                    <asp:ListItem Text="Urgent" Value="Urgent"></asp:ListItem>
                                                                                </asp:DropDownList>

                                                                                <asp:Label ID="lblPriority1" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Billable" SortExpression="Billable" Visible="false">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblBillable" runat="server" Text='<%# Bind("Billable") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Button ID="btnBillable" runat="server" Text='<%# Bind("Billable") %>' CssClass="btn btn-info pull-left display-block mright5" TabIndex="126" />
                                                                                <asp:Label ID="lblBillable1" runat="server" Text='<%# Bind("Billable") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="btnEditTask" runat="server" CssClass="btn btn-sm btn-outline-info mb-3"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="btnDeleteTask" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane p-20" id="profile3" role="tabpanel">
                                <div class="p-20">
                                    <asp:Label ID="lblProposalID" runat="server" Visible="false"></asp:Label>
                                    <div class="row">
                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblnote" runat="server" Text="Note" Font-Bold="true" Font-Size="14px"></asp:Label>
                                                <asp:TextBox ID="txtdinote" runat="server" placeholder="Enter Note" class=" form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>

                                            <br />
                                            <div class="mb-2">
                                                <asp:Button ID="btnnote" runat="server" Text="Save Note" CssClass="btn btn-sm btn btn-info" OnClick="btnnote_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane p-20" id="profile4" role="tabpanel">


                                <asp:UpdatePanel runat="server" UpdateMode="Always" ID="upAttachments">
                                    <ContentTemplate>
                                        <div class="p-20">
                                            <div class="row">
                                                <div class="col-md-8 col-sm-8 col-lg-8  col-xs-8">

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblAttachment" runat="server" Text="Attachment" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>


                                                        <div class="input-group">
                                                            <asp:FileUpload ID="FileUpload" runat="server" Text="" CssClass="form-control mdi-file-import" />
                                                            <asp:Button ID="Btn_Upload" runat="server" Text="Upload" CssClass="btn btn-primary btn-sm " OnClick="Btn_Upload_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4 col-sm-4 col-lg-4  col-xs-4">
                                                </div>

                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="lbdLeaveMID" runat="server" Text="" Font-Size="12px" Font-Bold="false" Visible="true"></asp:Label>

                                                    <asp:GridView ID="GridProposalFile" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" OnRowDataBound="GridProposalFile_RowDataBound" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                        ClientIDMode="Static" ShowHeader="false" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblProposalFileId" runat="server" Text="FileName" Font-Size="12px" Font-Bold="false" Visible="false"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblfileid" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblProposalFileName" runat="server" Font-Size="12px" Text="FileName" Font-Bold="false"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblProposalFileName1" runat="server" Text='<%# Bind("FileName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField Visible="false">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblProposalFileStatus" runat="server" Font-Size="12px" Text='<%# Bind("Status") %>' Font-Bold="false"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblProposalFileStatus1" runat="server" Text='<%# Bind("Status") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Download" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDownload" runat="server" CausesValidation="false" CommandName="Delete" CssClass="btn btn-sm btn-success " OnClick="btnDownload_Click" Visible="false"><i class="ti ti-download"></i></asp:LinkButton>
                                                                </ItemTemplate>

                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDeleteProposalFile" runat="server" CausesValidation="false" CommandName="Delete" CssClass="btn btn-sm btn-danger" Visible="false" OnClick="btnDeleteProposalFile_Click" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                </ItemTemplate>

                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                    </asp:GridView>

                                                </div>

                                            </div>

                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="Btn_Upload" />
                                        <%-- <asp:AsyncPostBackTrigger ControlID="Btn_Upload" EventName="Click" />--%>
                                        <%-- <asp:AsyncPostBackTrigger ControlID="btnDownload" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnDeleteLeadFile" EventName="Click" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                            <div class="tab-pane " id="ActivityLongs" role="tabpanel">
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-12 col-xs-12">
                                        <h5 class="mb-3">View Activity Details</h5>

                                        <hr />
                                        <div class="todo-widget scrollable" style="height: 600px">
                                            <asp:GridView ID="GridViewAct2" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" Style="width: 100%" AutoGenerateColumns="false" CellPadding="4"
                                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRowNumAct" Text='<%# Container.DataItemIndex + 1 %>' Font-Size="12px" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Proposal Activity" SortExpression="Activity" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblUserID11" runat="server" Text='<%# Bind("UserID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <%--<i class="mdi mdi-leaf fs-4 w-30px mt-1"></i>--%>
                                                            <asp:Label ID="lblDifd" runat="server" Text='<%# Bind("Diff")%>' TabIndex="6" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                            &nbsp;
                                                                 <asp:Label ID="lblAgo" runat="server" Text="MONTH  AGO" TabIndex="6" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                            &nbsp;
                                                                 <asp:Label ID="lblDate" runat="server" Text='<%# Bind("ActivityDate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                            &nbsp;
                                                               <%--  <br />
                                                            <asp:Label ID="Label1" runat="server" Text="---------------------------------------------------------------------" TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="LightGray"></asp:Label>
                                                            <br />--%>
                                                            <asp:Label ID="lblUserID1" runat="server" Text='<%# Bind("UserID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            <asp:Label ID="Designation1" runat="server" Text='<%# Bind("Designation") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            &nbsp;&nbsp;
                                                                 <asp:Label ID="lbldash" runat="server" Text="-" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            <asp:Label ID="lblActivityType" runat="server" Text='<%# Bind("ActivityType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            &nbsp;&nbsp;
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
                    </div>
                </div>
            </div>
        </div>
    </div>
   <%-- </div>
        </div>
    </div>--%>
</asp:Content>
