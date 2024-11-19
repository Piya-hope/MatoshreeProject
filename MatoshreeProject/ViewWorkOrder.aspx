<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ViewWorkOrder.aspx.cs" Inherits="MatoshreeProject.ViewWorkOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridWorkorderlist = $("#GridWorkorderlist").prepend($("<thead></thead>").append($("#GridWorkorderlist").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">WorkOrder Details</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="WorkOrder.aspx">WorkOrder
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="ViewWorkOrder.aspx">WorkOrder Details</li>
            </ol>
        </nav>
        <br />
        <div class="row">

            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <div class="d-flex justify-content-between align-items-center">
                            <asp:Button ID="Btn_CreateWorkOrder" runat="server" Text="New Work Order" CssClass="btn btn-primary btn-sm" OnClick="Btn_CreateWorkOrder_Click" />
                            <div>
                                <div class="bd-example">
                                    <div class="btn-group">
                                        <button class="btn btn-sm btn-primary" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class=" ti ti-filter align-content-end "></i></button>
                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="lnkbtnALL" Text="ALL" runat="server" CssClass="dropdown-item" OnClick="lnkbtnALL_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkViewNotsend" Text="Not send" runat="server" CssClass="dropdown-item" OnClick="LinkViewNotsend_Click"></asp:LinkButton>
                                            <hr />
                                            <asp:LinkButton ID="linkbtnpublished" Text="Published" runat="server" CssClass="dropdown-item" OnClick="linkbtnpublished_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="linkbtnnotpublished" Text="Not Published" runat="server" CssClass="dropdown-item" OnClick="linkbtnnotpublished_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkViewAccept" runat="server" Text="Accept" CssClass="dropdown-item" OnClick="LinkViewAccept_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkViewdeclined" runat="server" Text="Declined" CssClass="dropdown-item" OnClick="LinkViewdeclined_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkViewCancelled" runat="server" Text="Canceled" CssClass="dropdown-item" OnClick="LinkViewCancelled_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkViewDraft" runat="server" Text="Draft" CssClass="dropdown-item" OnClick="LinkViewDraft_Click"></asp:LinkButton>

                                            <hr />
                                            <asp:RadioButtonList ID="radiolistWorkOrderYear" runat="server" CssClass="dropdown-item" OnSelectedIndexChanged="radiolistWorkOrderYear_SelectedIndexChanged"></asp:RadioButtonList>
                                            <hr />

                                            <asp:RadioButtonList ID="radioSaleAgent" runat="server" CssClass="dropdown-item" AutoPostBack="true" OnSelectedIndexChanged="radioSaleAgent_SelectedIndexChanged"></asp:RadioButtonList>

                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>



                    </div>
                </div>
            </div>


            <div class="col-md-5 col-sm-5 col-lg-5">
                <div class="card">
                    <div class="card-body">
                        <h5>View Work Order Details</h5>
                        <hr />
                        <asp:Button ID="Btn_Export" runat="server" Text="Export" CssClass="btn btn-sm btn-outline-success" OnClick="Btn_Export_Click" />
                        <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_Reload_Click" />

                        <br />
                        <br />
                        <asp:GridView ID="GridWorkorderlist" runat="server" ScrollBars="Both" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" HeaderStyle-Font-Size="12px"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                            <Columns>

                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
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

                                <asp:TemplateField HeaderText="WorkOrderNumber" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblWorkOrderno" runat="server" Text='<%# Bind("WorkOrderNumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblWorkOrderno1" runat="server" Text='<%# Bind("WorkOrderNumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:LinkButton ID="LinkWorkOrderno" runat="server" Text='<%# Bind("WorkOrderNumber") %>' Font-Size="12px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="TenderNumber" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblTenderno" runat="server" Text='<%# Bind("TenderNumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTenderno1" runat="server" Text='<%# Bind("TenderNumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="StartDate" SortExpression="InvoiceDate">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("StartDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate1" runat="server" Text='<%# Bind("StartDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="VendorName" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblVender" runat="server" Text='<%# Bind("Vend_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblVender1" runat="server" Text='<%# Bind("Vend_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ContactPerson" SortExpression="ContactVender" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblContactPerson" runat="server" Text='<%# Bind("ContactVender") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblContactPerson1" runat="server" Text='<%# Bind("ContactVender") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ProjectName" SortExpression="BiddingDate" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblProjectName" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProjectName1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status" SortExpression="BiddingDate" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStatusName" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatusName1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Total" SortExpression="TotalAmountTender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblTotalAmountTender" runat="server" Text='<%# Bind("TotalAmountTender") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalAmountTender1" runat="server" Text='<%# Bind("TotalAmountTender") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>

                </div>
            </div>


            <div class="col-md-7 col-sm-7 col-lg-7 col-xs-12">
                <div class="card">
                    <div class="card-body">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-2 col-sm-2 col-lg-2 col-xs-2">
                                    <asp:Label ID="lblStatus" runat="server" Text="" CssClass="btn btn-sm btn-light text-info"></asp:Label>
                                    <asp:Label ID="lblstatus1" runat="server" Text="" CssClass="text-danger" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-5 col-sm-5 col-lg-5 col-xs-5">
                                </div>
                                <div class="col-md-3 col-sm-3 col-lg-3 col-xs-3">
                                    <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-outline-info" title="Edit" OnClick="Linkbtnedit_Click"><i class="ti ti-edit"></i></asp:LinkButton>

                                    <asp:LinkButton ID="lnkbtnpdf" runat="server" CssClass="btn btn-sm btn-outline-danger" title="PDF" OnClick="lnkbtnpdf_Click"><iconify-icon icon="ph:file-pdf"></iconify-icon></asp:LinkButton>

                                    <asp:LinkButton ID="LinkbtnMessage" runat="server" CssClass="btn btn-sm btn-outline-primary" title="Email"><iconify-icon icon="solar:letter-unread-linear" class="aside-icon"></iconify-icon></asp:LinkButton>
                                </div>

                                <div class="col-md-2 col-sm-2 col-lg-2 col-xs-2">
                                    <div class="mb-2">
                                        <div class="bd-example">
                                            <div class="btn-group">
                                                <button class="btn btn-sm btn-light dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">More</button>
                                                <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                                <div class="dropdown-menu">
                                                    <asp:LinkButton ID="lnkbtnviewascustmer" Text="View Work Order As Customer" runat="server" CssClass="dropdown-item" OnClick="lnkbtnviewascustmer_Click"></asp:LinkButton>
                                                    <asp:LinkButton ID="linkbtnSendOverDue" runat="server" Text="Sent Overdue Notice" CssClass="dropdown-item" OnClick="linkbtnSendOverDue_Click"></asp:LinkButton>
                                                    <hr />
                                                    <asp:LinkButton ID="lnkbtnpublished" runat="server" Text="Mark as Published" CssClass="dropdown-item" OnClick="lnkbtnpublished_Click"></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkbtnNotPublished" Text="Not Published" runat="server" CssClass="dropdown-item" OnClick="lnkbtnNotPublished_Click"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkStatusAccepted" runat="server" Text="Accepted" CssClass="dropdown-item" OnClick="LinkStatusAccepted_Click"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkStatusdeclined" runat="server" Text="Declined" CssClass="dropdown-item" OnClick="LinkStatusdeclined_Click"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkStatusCancelled" runat="server" Text="Canceled" CssClass="dropdown-item" OnClick="LinkStatusCancelled_Click"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkStatusDraft" runat="server" Text="Draft" CssClass="dropdown-item" OnClick="LinkStatusDraft_Click"></asp:LinkButton>
                                                    <hr />
                                                    <asp:LinkButton ID="lnkbtncopyworkorder" runat="server" Text="Copy Work Order" CssClass="dropdown-item" OnClick="lnkbtncopyworkorder_Click"></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkbtndelworkorder" runat="server" Text="Delete Work Order" CssClass="dropdown-item text-danger" OnClick="lnkbtndelworkorder_Click"></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="container">
                            <div class="row">

                                <div class="col-md-5 col-lg-5 col-sm-5 col-xs-5 text-start">
                                    <asp:Image ID="Image1" Text="" runat="server" Height="80px" Width="130px" /><br />
                                    <br />
                                    <asp:Label ID="lblworkno" runat="server" Text="" Visible="false"></asp:Label><br />
                                    <asp:Label ID="lblfrom" runat="server" Text="From" CssClass="form-label"></asp:Label><br />
                                    <asp:Label ID="lblComanyname" runat="server" Text="" CssClass="form-label"></asp:Label><br />
                                    <asp:Label ID="lbladdress" runat="server" Text="" Font-Size="12px"></asp:Label>
                                    <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblcompanyaddState1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                    <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblpincode" runat="server" Text="PIN:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblphone" runat="server" Text="Phone:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblphoneNo1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvat" runat="server" Text="VAT NO:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblVatNo1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblGSTNo1A" runat="server" Text="" Font-Size="12px"></asp:Label>
                                </div>
                                <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2"></div>

                                <div class="col-md-5 col-lg-5 col-sm-5 col-xs-5 text-end">

                                    <asp:Label ID="lblCustid" runat="server" Text="" Visible="false"></asp:Label><br />
                                    <asp:Label ID="lblprojectid" runat="server" Text="" Visible="false"></asp:Label><br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Label ID="lblto" runat="server" Text="To," CssClass="form-label"></asp:Label><br />
                                    <asp:Label ID="lblvendername" runat="server" Text="" CssClass="form-label"></asp:Label><br />
                                    <asp:Label ID="lblvenconname1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenconposition" runat="server" Text="Position:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblvenconposition1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenconemail" runat="server" Text="Email:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblvenconemail1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenconphone" runat="server" Text="Phone No:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblvenconphone1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenderblock" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenderstreet" runat="server" Text="" Font-Size="12px"></asp:Label>
                                    <asp:Label ID="lblvendercity" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenderdistrict" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenderstate" runat="server" Text="" Font-Size="12px"></asp:Label>
                                    <asp:Label ID="lblvenercountry" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenderpin" runat="server" Text="PIN:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblvenderpin1" runat="server" Text="" Font-Size="12px"></asp:Label><br />

                                </div>

                            </div>
                        </div>
                        <br />
                        <div class="container">
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12 text-center">
                                    <asp:Label ID="lbltenderheader" runat="server" Text=" Work Order Form " CssClass="font-bold text-dark" Font-Size="18px"></asp:Label><br />
                                </div>
                            </div>
                        </div>
                        <div class="container">
                            <div>
                                <h5 class="text-purple">Work Order Form :-</h5>
                            </div>
                            <br />
                            <div class="row">
                                <h5>Company Details :-</h5>
                                <div class="container">
                                    <div class="row">
                                        <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
                                            <asp:GridView ID="GridViewcompany" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="lblcompanyheaderID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblcompanyID" runat="server" Text='<%# Bind("ID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcompanyID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Name Of Company " SortExpression="ID" HeaderStyle-Font-Size="12px" HeaderStyle-Width="90px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblcompanyname" runat="server" Text='<%# Bind("Company_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcompanyname1" runat="server" Text='<%# Bind("Company_Name") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Address" SortExpression="Tender" HeaderStyle-Width="110px" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAddress1" runat="server" Text='<%# Bind("Address") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Contact" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("Phone") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPhone1" runat="server" Text='<%# Bind("Phone") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <h5>Vendor Details :-</h5>
                                <div class="container">
                                    <div class="row">
                                     
                                            <div class="table-responsive">
                                                <asp:GridView ID="GridVendor" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" style="width:100%"
                                                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="id">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Vendor Name" SortExpression="ID" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblVendorname" runat="server" Text='<%# Bind("Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVendorname1" runat="server" Text='<%# Bind("Name") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="VenderID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblVendorID" runat="server" Text='<%# Bind("id") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVendorID1" runat="server" Text='<%# Bind("id") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Address" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblBillingAddress" runat="server" Text='<%# Bind("BillingAddress") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBillingAddress1" runat="server" Text='<%# Bind("BillingAddress") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ContactDetails" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("phonenumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPhone1" runat="server" Text='<%# Bind("phonenumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Email" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("email") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmail1" runat="server" Text='<%# Bind("email") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Position" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblPosition" runat="server" Text='<%# Bind("Position") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPosition1" runat="server" Text='<%# Bind("Position") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                   
                                </div>
                                <br />
                                 <br />
                                <div class="container">
                                    <div class="row">
                                       
                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblworkorderno" runat="server" Text="Work-Order Number:" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lblworkorderno1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblworkorderdate" runat="server" Text="Work-Order Date:" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lblworkorderdate1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblworkorderstartdate" runat="server" Text="Work-order Start Date:" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lblworkorderstartdate1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                </div>
                                            </div>

                                        </div>
                                   
                                </div>
                            </div>
                        </div>
                         <br />
                        <div class="container">
                            <div class="row">
                                <div>
                                    <h5 class="text-purple">Current Tender Details :-</h5>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-lg-6 text-start">
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lbltendno" runat="server" Text="Tender Number:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lbltendno1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblTenderName" runat="server" Text="Tender Name:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblTenderName1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lbllocCity" runat="server" Text="Work Address:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lbllocCity1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblworkdesc" runat="server" Text="Work Description:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblworkdesc1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>

                                    </div>
                                  
                                    <div class="col-md-6 col-sm-6 col-lg-6">

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lbltendcat" runat="server" Text="Tender Category:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lbltendcat1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblbidenddate" runat="server" Text="Bid End Date:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblbidenddate1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lbltendvalue" runat="server" Text="Tender Value:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lbltendvalue1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lbllocpin" runat="server" Text="Pincode:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lbllocpin1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>

                                    </div>

                                </div>
                            </div>

                        </div>
                        <br />
                        <div class="container">
                            <div class="row">
                                <h5 class="text-purple">Questions & Answers :-</h5>

                                <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12">
                                    <asp:GridView ID="GridWorkOrderQue" runat="server" ScrollBars="Both" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                        ClientIDMode="Static" ShowHeader="false" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="tendvendmapid1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Question" SortExpression="ID" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQuestion1" runat="server" Text='<%# Bind("Tend_Que") %>' Font-Bold="false" Font-Size="12px"></asp:Label><br />
                                                    <asp:Label ID="lblAnswer1" runat="server" Text='<%# Bind("Tend_Ans") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblDoc_File1" runat="server" Text='<%# Bind("Doc_File") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblFilePath" runat="server" Text='<%# Bind("Doc_Filepath") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                         <br />
                        <div class="container">
                            <div class="row">
                                <div>
                                    <h5 class="text-purple">Work Details :-</h5>
                                </div>
                                <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
                                    <div class="table table-responsive">
                                        <asp:GridView ID="Gridworkitem" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px" HeaderStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="tendvenditemid1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Item" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblItem" runat="server" Text='<%# Bind("Item") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItem1" runat="server" Text='<%# Bind("Item") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Description" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quantity" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Qnty") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Qnty") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Rate" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblRate" runat="server" Text='<%# Bind("Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRate1" runat="server" Text='<%# Bind("Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tax1Name" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblTax1Name" runat="server" Text='<%# Bind("Tax1Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTax1Name1" runat="server" Text='<%# Bind("Tax1Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tax1Rate" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblTax1Rate" runat="server" Text='<%# Bind("Tax1Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTax1Rate1" runat="server" Text='<%# Bind("Tax1Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tax2Name" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblTax2Name" runat="server" Text='<%# Bind("Tax2Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTax2Name1" runat="server" Text='<%# Bind("Tax2Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tax2Rate" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblTax2Rate" runat="server" Text='<%# Bind("Tax2Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTax2Rate1" runat="server" Text='<%# Bind("Tax2Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="TotalAmountTender" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblTotalAmountTender" runat="server" Text='<%# Bind("TotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalAmountTender1" runat="server" Text='<%# Bind("TotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                         <br />
                        <div class="container">
                            <div class="row">
                                <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 text-start">
                                    <asp:Label ID="lbltotalamt" runat="server" Text="Total Price:₹" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lbltotal" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblworkoderdeliverydate" runat="server" Text="Delivery Date Of Work:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblworkoderdeliverydate1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblcompdate" runat="server" Text="Actual Date Of Completion:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblActualcompdate1" runat="server" Text="" Font-Size="12px"></asp:Label><br />

                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="container">
                            <div class="row">
                                <div>
                                    <h5 class="text-purple">Work Order Files :-</h5>
                                </div>

                                <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12">
                                    <asp:GridView ID="GridWorkOrderFile" runat="server" ScrollBars="Both" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                        ClientIDMode="Static" ShowHeader="false" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                                        <Columns>

                                            <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px" HeaderStyle-Width="5px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblWorkorderID" runat="server" Text="FileName" Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWorkorderID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblWorkorderFileName" runat="server" Text="FileName" CssClass="form-label"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWorkorderFileName1" runat="server" Text='<%# Bind("FileName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="false">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblWorkorderPath" runat="server" Text="FileName" Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWorkorderPath1" runat="server" Text='<%# Bind("FilePath") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="Document_Type" runat="server" Text="FileName" CssClass="form-label"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDocument_Type" runat="server" Text='<%# Bind("DocumentType") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>



                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="container">
                            <div class="row">
                                <div>
                                    <h5 class="text-purple">Tender Inviting Authority :-</h5>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-lg-6 text-start">
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblauthorityname" runat="server" Text="Authority Name:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblauthorityname1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblauthorityadd" runat="server" Text="Authority Address:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblauthorityadd1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblauthemail" runat="server" Text="Email:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblauthemail1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblconno" runat="server" Text="Contact No:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblconno1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <div class="mb-2">
                                        <asp:Label ID="lblauthposition" runat="server" Text="Authority Position:" CssClass="form-label"></asp:Label>
                                        <asp:Label ID="lblauthposition1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />

                        <div class="container">
                            <div class="row">
                                <div>
                                    <h5 class="text-purple">ClientNotes & Terms&Condition :-</h5>
                                </div>
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <h6>Note :</h6>
                                    <asp:Label ID="lblclientnote" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <br />
                                    <br />
                                    <h6>Terms & Condition</h6>
                                    <asp:Label ID="lbltermsandcodition" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                </div>
                            </div>

                        </div>


                        <br />

                    </div>
                </div>

            </div>
        </div>

    </div>
</asp:Content>
