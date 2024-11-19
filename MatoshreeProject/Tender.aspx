<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Tender.aspx.cs" Inherits="MatoshreeProject.Tender" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridTender = $("#GridTender").prepend($("<thead></thead>").append($("#GridTender").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Tender</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="Tender.aspx">Tender</li>
            </ol>
        </nav>
        <br />


        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                        <div id="addnew" runat="server">
                           
                            <asp:Button ID="btn_CreateTender" runat="server" Text="New Tender" CssClass="btn btn-primary btn-sm" OnClick="btn_CreateTender_Click" />

                            <hr />
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

                <h5>Tender Summary</h5>

                <div class="row">
                    <div class="col-lg-3 col-md-6">
                        <div class="card border-bottom border-primary">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblPublishCount" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-primary mb-0">
                                            <asp:Label ID="lblPublishCount1" runat="server" Text="Published" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-primary display-6">
                                            <i class="ti ti-file-text"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="card border-bottom border-purple">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblNotPublishCount" runat="server" CssClass="text-center text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-purple mb-0">
                                            <asp:Label ID="lblNotPublishCount1" runat="server" Text="Not Published"  Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-purple display-6">
                                            <i class="ti ti-send"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="col-lg-3 col-md-6">
                        <div class="card border-bottom border-success">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblAllocateCount" runat="server" CssClass="text-center  text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label></h2>
                                        <h6 class="fw-medium text-success mb-0">
                                            <asp:Label ID="lblAllocateCount1" runat="server" Text="Allocated"  Font-Size="12px" Font-Bold="true"></asp:Label></h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-success display-6">
                                            <i class="ti ti-receipt-2"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-3 col-md-6">
                        <div class="card border-bottom border-danger">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblCanceledCount" runat="server" CssClass="text-center  text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label></h2>
                                        <h6 class="fw-medium text-danger mb-0">
                                            <asp:Label ID="lblCanceledCount1" runat="server" Text="Cancelled" Font-Size="12px" Font-Bold="true"></asp:Label></h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-danger display-6">
                                            <i class="ti ti-receipt-refund"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>


             <div class="col-md-12 col-sm-12 col-lg-12">
            <div class="card">
                <div class="card-body">
                    <h5 class="font-weight-medium mt-3 mb-3">View Tender Details</h5>
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
                                <asp:Button ID="Btn_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_Visibility_Click" />
                                <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-outline-info btn-sm" OnClick="Btn_Reload_Click" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <!------PDF code--------->

                            <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />

                            <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-dark " Visible="false"></asp:Label>
                            <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                            <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                            <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                            <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                            <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," CssClass="" Visible="false"></asp:Label>
                            <asp:Label ID="lblpincode" runat="server" Text="PIN:" CssClass=" font-bold" Visible="false"></asp:Label>
                            <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                            <asp:Label ID="lblphone" runat="server" Text="Phone:" CssClass=" font-bold" Visible="false"></asp:Label>
                            <asp:Label ID="lblphoneNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                            <asp:Label ID="lblvat" runat="server" Text="VAT NO:" CssClass=" font-bold" Visible="false"></asp:Label>
                            <asp:Label ID="lblVatNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                            <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" CssClass=" font-bold" Visible="false"></asp:Label>
                            <asp:Label ID="lblGSTNo1A" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                            <!------PDF code--------->

                        </div>
                    </div>

                    <br />
                    <br />

                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                            <asp:GridView ID="GridTender" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" HeaderStyle-Font-Size="12px"
                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridTender_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" ItemStyle-Width="100">
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

                                    <asp:TemplateField HeaderText="TenderNumber" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblTenderno" runat="server" Text='<%# Bind("TenderNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTenderno1" runat="server" Text='<%# Bind("TenderNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:LinkButton ID="LinkTenderNumber" runat="server" Text='<%# Bind("TenderNo") %>' OnClick="LinkTenderNumber_Click" Font-Size="12px"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="TenderName" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblTender" runat="server" Text='<%# Bind("TenderName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTender1" runat="server" Text='<%# Bind("TenderName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="TenderDate" SortExpression="TenderDate" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblTenderDate" runat="server" Text='<%# Bind("TenderDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTenderDate1" runat="server" Text='<%# Bind("TenderDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BidEndDate" SortExpression="BiddingDate" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("BidEndDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate1" runat="server" Text='<%# Bind("BidEndDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PublishDate" SortExpression="PublishDate" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblpublishdate" runat="server" Text='<%# Bind("publishdate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblpublishdate1" runat="server" Text='<%# Bind("publishdate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Category" SortExpression="Sales_Agent" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("TenderBased") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory1" runat="server" Text='<%# Bind("TenderBased") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Publish" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                        <ItemTemplate>

                                            <asp:CheckBox ID="Chk_Pulish" runat="server" Font-Bold="true" Checked='<%# Bind("Publish") %>' OnCheckedChanged="Chk_Pulish_CheckedChanged" AutoPostBack="true" />

                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="false">

                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status1") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditTender" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditTender_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteTender" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteTender_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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
</asp:Content>
