<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="MatoshreeProject.Projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridProject = $("#GridProject").prepend($("<thead></thead>").append($("#GridProject").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
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
        <%-- BreadCrumbs --%>
        <h5 class="font-weight-medium mb-0">Project</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="Projects.aspx">Project Details</li>
            </ol>
        </nav>

        <%-- BreadCrumbs --%>


        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">

                        <div id="addnew" runat="server">
                            <br />
                            <div class="row">
                                <div class="Col-md-2 col-sm-2 col-lg-2">
                                    <asp:Button ID="btnAddProject" runat="server" Text="New Project" CssClass="btn btn-sm btn-primary" OnClick="btnAddProject_Click" />
                                </div>

                            </div>
                            <hr />
                        </div>
                    </div>
                    <%-- Toaster --%>
                    <div class="col-md-4 col-sm-4 col-xl-4 col-lg-4">
                        <div id="Toasteralert"  runat="server" visible="false">
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
                <h5 class="fs-5 mt-3 mb-3">Project Summary</h5>
                <div class="row">
                    <div class="col-lg-3 col-md-3">
                        <div class="card border-bottom border-success">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblNotStartedProjectCount" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-success mb-0">
                                            <asp:Label ID="lblNotStartedProject" runat="server" Text="Not Started" CssClass="text-success" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-success display-6">
                                            <iconify-icon icon="bi:briefcase" class="aside-icon"></iconify-icon>
                                            <%--  <iconify-icon icon="solar:user-plus-rounded-linear" class="aside-icon"></iconify-icon>--%>
                                        </span>
                                        <%--  <span class="text-success display-6"><i class="ti ti-file-text"></i></span>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-3 col-md-3">
                        <div class="card border-bottom border-info">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblInProgressProjectCount" runat="server" CssClass="text-center text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-info mb-0">
                                            <asp:Label ID="lblInProgressProject" runat="server" Text="In Progress" CssClass="text-info" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-info display-6">
                                            <%--  <iconify-icon icon="solar:user-plus-rounded-linear" class="aside-icon"></iconify-icon>--%>
                                            <iconify-icon icon="bi:briefcase" class="aside-icon"></iconify-icon>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-3 col-md-3">
                        <div class="card border-bottom border-danger">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblOnHoldProjectCount" runat="server" CssClass="text-center text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-danger mb-0">
                                            <asp:Label ID="lblOnHoldProject" runat="server" Text="On Hold" CssClass="text-danger" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-danger display-6">
                                            <%--  <iconify-icon icon="solar:user-plus-rounded-linear" class="aside-icon"></iconify-icon>--%>
                                            <iconify-icon icon="bi:briefcase" class="aside-icon"></iconify-icon>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-3 col-md-3">
                        <div class="card border-bottom border-dark">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblFinishedProjectCount" runat="server" CssClass="text-center text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-dark mb-0">
                                            <asp:Label ID="lblFinishedProject" runat="server" Text="Finished" CssClass="text-dark" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-dark display-6">
                                            <%--  <iconify-icon icon="solar:user-plus-rounded-linear" class="aside-icon"></iconify-icon>--%>
                                            <iconify-icon icon="bi:briefcase" class="aside-icon"></iconify-icon>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                 <h5 class="font-weight-medium mb-0">View Project Details</h5>
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

                                            <asp:Button ID="btn_VisibilityProject" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btn_VisibilityProject_Click" />
                                            <asp:Button ID="BtnReloadProject" runat="server" Text="Reload" CssClass="btn btn-sm btn-sm btn-outline-info" OnClick="BtnReloadProject_Click" />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <!------PDF code--------->

                                        <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />

                                        <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-dark font-14" Visible="false"></asp:Label>
                                        <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
                                        <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
                                        <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
                                        <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
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

                                <br />

                                <asp:GridView ID="GridProject" runat="server" ScrollBars="Both" CssClass="table border table-bordered text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridProject_RowDataBound">
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
                                        <asp:TemplateField HeaderText="ProjectName" SortExpression="ProjectName" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblProjectName" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblProjectName1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                <asp:LinkButton ID="LinkbtnProjectName1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" CssClass="link-info" OnClick="LinkbtnProjectName1_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Customer" SortExpression="Customer" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblClientName" runat="server" Text='<%# Bind("ClientName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblSClientName1" runat="server" Text='<%# Bind("ClientName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="StartDate" SortExpression="Start_Date" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblStart_Date" runat="server" Text='<%# Bind("Start_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblStart_Date1" runat="server" Text='<%# Bind("Start_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Deadline" SortExpression="Deadline" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblDeadline" runat="server" Text='<%# Bind("Deadline","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeadline1" runat="server" Text='<%# Bind("Deadline","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" SortExpression="StatusProject" Visible="false" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("StatusProject") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblstatus1" runat="server" Text='<%#Bind("StatusProject") %>' Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Members" SortExpression="Member" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblTagsName" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <div class="m-2">
                                                    <asp:BulletedList ID="bulletlistMember" runat="server" BulletStyle="Circle" Font-Size="12px">
                                                    </asp:BulletedList>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEditProject" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditProject_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDeleteProjetct" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteProjetct_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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
