<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Ticket_Details.aspx.cs" Inherits="MatoshreeProject.Ticket_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var Gridticket = $("#Gridticket").prepend($("<thead></thead>").append($("#Gridticket").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Ticket Details</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="#">Support
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="Ticket_Details.aspx">Ticket Details</li>
            </ol>
        </nav>
        <br />

        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12 col-xl-12">
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                        <div id="addnew" runat="server">
                            <asp:Button ID="btnNewticket" runat="server" Text="New Ticket" CssClass="btn btn-sm btn-primary" OnClick="btnNewticket_Click" />
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
                <br />
                <div class="row">
                    <div class="col-sm-2 col-md-2 col-lg-2 col-xl-2">
                        <div class="card border-bottom border-success">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblopen" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-success mb-0">
                                            <asp:Label ID="lblopen1" runat="server" Text="Open" CssClass="text-success" Font-Size="14px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-success display-6">
                                            <iconify-icon icon="solar:clapperboard-edit-linear" class="aside-icon"></iconify-icon>
                                        </span>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-3 col-md-3 col-lg-3 col-xl-3">
                        <div class="card border-bottom border-info">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblProgress" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-success mb-0">
                                            <asp:Label ID="lblProgress1" runat="server" Text="In Progress" CssClass="text-info" Font-Size="14px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-info display-6">
                                            <iconify-icon icon="solar:clapperboard-edit-linear" class="aside-icon"></iconify-icon>
                                        </span>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-3 col-md-3 col-lg-3 col-xl-3">
                        <div class="card border-bottom border-danger">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblAnswered" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-success mb-0">
                                            <asp:Label ID="lblAnswered1" runat="server" Text="Answered" CssClass="text-danger" Font-Size="14px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-danger display-6">
                                            <iconify-icon icon="solar:clapperboard-edit-linear" class="aside-icon"></iconify-icon>
                                        </span>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="col-sm-2 col-md-2 col-lg-2 col-xl-2">
                        <div class="card border-bottom border-secondary">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblonHold" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-success mb-0">
                                            <asp:Label ID="lblonHold1" runat="server" Text="On Hold" CssClass="text-secondary" Font-Size="14px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-secondary display-6">
                                            <iconify-icon icon="solar:clapperboard-edit-linear" class="aside-icon"></iconify-icon>
                                        </span>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-2 col-md-2 col-lg-2 col-xl-2">
                        <div class="card border-bottom border-warning">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblClosed" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-warning mb-0">
                                            <asp:Label ID="lblClosed1" runat="server" Text="Closed" CssClass="text-warning" Font-Size="14px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-warning display-6">
                                            <iconify-icon icon="solar:clapperboard-edit-linear" class="aside-icon"></iconify-icon>
                                        </span>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="card">
                    <div class="card-body">
                        <h5>View Ticket Details</h5>
                        <hr />

                        <div class="row">
                            <div class="bd-example">
                                <div class="btn-group">
                                    <button class="btn btn-sm btn-outline-success dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                    <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                    <div class="dropdown-menu">
                                        <asp:Button ID="btn_Export" runat="server" Text="Excel" OnClick="btn_Export_Click" CssClass=" dropdown-item" />
                                        <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" OnClick="linkbtnPDF_Click" CssClass="dropdown-item"></asp:LinkButton>

                                    </div>
                                </div>
                                <asp:Button ID="btn_Visibility" runat="server" Text="Visibility" OnClick="btn_Visibility_Click" CssClass="btn btn-sm btn-outline-info" />
                                <asp:Button ID="btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btn_Reload_Click" />
                            </div>

                            <div id="companyData" runat="server" visible="false">
                                <asp:Label ID="lbladdCompany11" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lbladdress11" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblcompanyaddCity1" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblcompanyaddState1" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblcompanyaddCountry1" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblphoneNo1" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblVatNo1" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblGSTNo1A" runat="server" Text=""></asp:Label>
                                <asp:Image ID="Image1" Text="" runat="server" Height="80px" Width="130px" />
                            </div>
                        </div>
                        <br />
                        <asp:GridView ID="Gridticket" runat="server" ScrollBars="Both" CssClass="table border table-responsive table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Width="100%" OnRowDataBound="Gridticket_RowDataBound"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnSelectedIndexChanged="Gridticket_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" SortExpression="Subject" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject1" runat="server" Text='<%# Bind("Subject") %>' Visible="false" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        <asp:LinkButton ID="btnSubject1" runat="server" Text='<%# Bind("Subject") %>' CssClass="btn btn-sm text-info" OnClick="btnSubject1_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Department" SortExpression="Department" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDepartment" runat="server" Text='<%# Bind("Department") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepartment1" runat="server" Text='<%# Bind("Department") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Services" SortExpression="Services" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblServices" runat="server" Text='<%# Bind("Services") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblServices1" runat="server" Text='<%# Bind("Services") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Priority" SortExpression="Priority" Visible="false" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPriority" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPriority1" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AssignTo" SortExpression="AssignTo" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lbAssignTo" runat="server" Text='<%# Bind("AssignTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssignTo1" runat="server" Text='<%# Bind("AssignTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RaiseBy" SortExpression="RaiseBy" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRaiseBy" runat="server" Text='<%# Bind("Raise_By") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRaiseBy1" runat="server" Text='<%# Bind("Raise_By") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" SortExpression="StatusName" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStatusNamee" runat="server" Text='<%# Bind("StatusName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatusNamee1" runat="server" Text='<%# Bind("StatusName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status1" SortExpression="StatusName" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditticket" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditticket_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeleteticket" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteticket_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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

</asp:Content>
