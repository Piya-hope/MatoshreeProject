<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Proposal.aspx.cs" Inherits="MatoshreeProject.Proposal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <style type="text/css">
        #leftPanel {
            width: 600px;
            float: left;
            position: relative;
        }

        #rightPanel {
            width: 600px;
            float: right;
            position: relative;
        }
    </style>
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
                <li class="breadcrumb-item text-muted" aria-current="page" href="Proposal.aspx">Proposal</li>
            </ol>
        </nav>
        <%-- BreadCrumbs --%>

        <%-- Toaster --%>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <br />
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                        <div id="addnew" runat="server">
                            <asp:Button ID="btnNewProposal" runat="server" Text="New Proposal" CssClass="btn btn-sm btn-primary" OnClick="btnNewProposal_Click" />
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

                <h5 class="font-weight-medium mt-3 mb-3">Proposal Summary</h5>
              
                <div class="row">
                    <%-- Draft --%>
                    <div class="col-sm-4 col-xs-4 col-lg-4 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="d-flex align-items-center mb-3">
                                    <div>
                                        <h3 class="fs-6">
                                            <asp:Label ID="lblDraft" runat="server" Text="" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblPercentDraft" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            <asp:Label ID="lblTotalProposalCount" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true" Visible="false"></asp:Label>
                                        </h3>
                                        <h6 class="card-subtitle mb-1 text-muted">
                                            <asp:Label ID="LabelDraft" runat="server" Text="Draft" CssClass="text-danger" Font-Size="12px"></asp:Label></h6>
                                        <asp:Label ID="lblTotalDraftCount" runat="server" Text="" Visible="false" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-danger display-6"><i class="ti ti-package"></i></span>
                                    </div>
                                </div>
                                <div class="progress text-bg-light">
                                    <div class="progress-bar text-bg-danger" role="progressbar"
                                        aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="PgBarDraft" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- revised --%>
                    <div class="col-sm-4 col-xs-4 col-lg-4 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="d-flex align-items-center mb-3">
                                    <div>
                                        <h3 class="fs-6">
                                            <asp:Label ID="lblRevised" runat="server" Text="" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblRevisedPercent" runat="server" Text="" Font-Size="12px"></asp:Label>
                                        </h3>
                                        <h6 class="card-subtitle mb-1 text-muted">
                                            <asp:Label ID="LabelRevised" runat="server" Text="Revised" CssClass="text-success" Font-Size="12px"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-success display-6"><i class="ti ti-receipt-2"></i></span>
                                    </div>
                                </div>
                                <div class="progress text-bg-light">
                                    <div class="progress-bar text-bg-success" role="progressbar"
                                        aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="PgBarRevised" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- Send --%>
                    <div class="col-sm-4 col-xs-4 col-lg-4 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-12">
                                        <div class="d-flex align-items-center mb-3">
                                            <div>
                                                <h3 class="fs-6">
                                                    <asp:Label ID="lblSend" runat="server" Text="" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>

                                                    <asp:Label ID="lblSendpercent" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                </h3>
                                                <h6 class="card-subtitle mb-1 text-muted">
                                                    <asp:Label ID="LabelSend" runat="server" Text="Send" CssClass="text-info" Font-Size="12px"></asp:Label>

                                                </h6>

                                            </div>
                                            <div class="ms-auto">
                                                <span class="text-info display-6"><i class="ti ti-recharging"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-12">
                                        <div class="progress text-bg-light">
                                            <div class="progress-bar text-bg-info" role="progressbar"
                                                aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="PgBarSend" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <%-- Declined --%>
                    <div class="col-sm-4 col-xs-4 col-lg-4 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-12">
                                        <div class="d-flex align-items-center mb-3">
                                            <div>
                                                <h3 class="fs-6">
                                                    <asp:Label ID="lblDeclined" runat="server" Text="" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>

                                                    <asp:Label ID="lblDeclinedPercent" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                </h3>
                                                <h6 class="card-subtitle mb-1 text-muted">
                                                    <asp:Label ID="LabelDeclined" runat="server" Text="Declined" CssClass="text-warning" Font-Size="12px"></asp:Label>

                                                </h6>

                                            </div>
                                            <div class="ms-auto">
                                                <span class="text-warning display-6"><i class="ti ti-receipt"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-12">
                                        <div class="progress text-bg-light">
                                            <div class="progress-bar text-bg-warning" role="progressbar"
                                                aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="PgBarDeclined" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- Accepted --%>
                    <div class="col-sm-4 col-xs-4 col-lg-4 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-12">
                                        <div class="d-flex align-items-center mb-3">
                                            <div>
                                                <h3 class="fs-6">
                                                    <asp:Label ID="lblAccepted" runat="server" Text="" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>

                                                    <asp:Label ID="lblAcceptedPercent" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                </h3>
                                                <h6 class="card-subtitle mb-1 text-muted">
                                                    <asp:Label ID="LabelAccepted" runat="server" Text="Accepted" CssClass="text-dark" Font-Size="12px"></asp:Label>

                                                </h6>

                                            </div>
                                            <div class="ms-auto">
                                                <span class="text-dark display-6"><i class="ti ti-file-text"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-12">
                                        <div class="progress text-bg-light">
                                            <div class="progress-bar text-bg-dark" role="progressbar"
                                                aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="PgBarAccepted" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- Open --%>
                    <div class="col-sm-4 col-xs-4 col-lg-4 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-12">
                                        <div class="d-flex align-items-center mb-3">
                                            <div>
                                                <h3 class="fs-6">
                                                    <asp:Label ID="lblOpen" runat="server" Text="" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>

                                                    <asp:Label ID="lblOpenPercent" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                </h3>
                                                <h6 class="card-subtitle mb-1 text-muted">
                                                    <asp:Label ID="LabelOpen" runat="server" CssClass="text-danger" Text="Open" ForeColor="Red" Font-Size="12px"></asp:Label>

                                                </h6>

                                            </div>
                                            <div class="ms-auto">
                                                <span class="text-danger display-6"><i class="ti ti-receipt-refund"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-12">
                                        <div class="progress text-bg-light">
                                            <div class="progress-bar text-bg-danger" role="progressbar"
                                                aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="PgBarOpen" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- End Row -->

                </div>
            </div>

            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="font-weight-medium mt-3 mb-3">View Proposal Details</h5>
                        <hr />

                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                <div class="bd-example">
                                    <div class="btn-group">
                                        <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                        <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="lnkbtnExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDF_Click"></asp:LinkButton>

                                        </div>
                                    </div>
                                    <asp:Button ID="BTN_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="BTN_Visibility_Click" />

                                    <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_Reload_Click" />


                                </div>
                            </div>
                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />
                                <asp:Image ID="Image2" runat="server" Style="display: none; border: 1px solid #ccc" />
                                <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-dark " Visible="false"></asp:Label>
                                <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblpincode" runat="server" Text="PIN:" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblphone" runat="server" Text="Phone:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblphoneNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblvat" runat="server" Text="VAT NO:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblVatNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblGSTNo1A" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                            </div>
                        </div>

                        <br />
                        <br />

                        <asp:GridView ID="GridPropsal" runat="server" ScrollBars="Both" CssClass="table border table-hover table-bordered text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" OnRowDataBound="GridPropsal_RowDataBound" DataKeyNames="ID">
                            <Columns>

                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px">
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
                                        <asp:LinkButton ID="lblProposalNo1" runat="server" Text='<%# Bind("ProposalNO") %>' OnClick="lblProposalNo1_Click" TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="#0099ff"></asp:LinkButton>
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
                                        <asp:LinkButton ID="btnEditProposal" runat="server" CausesValidation="false" OnClick="btnEditProposal_Click" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"  ></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeleteProposal" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteProposal_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                    </ItemTemplate>
                                   
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
</asp:Content>

