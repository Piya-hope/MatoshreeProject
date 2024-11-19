<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="MatoshreeProject.Roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridRole = $("#GridRole").prepend($("<thead></thead>").append($("#GridRole").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "500px",
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
    <div class="container-fluid">
        <%-- BreadCrumbs --%>
        <h5 class="font-weight-medium mb-0">Roles</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="#">STAFF
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="Roles.aspx">Roles</li>
            </ol>
        </nav>

        <%-- BreadCrumbs --%>
        <br />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                        <div id="addnew" runat="server">
                            <asp:Button ID="btn_New_Role" runat="server" Text="New Role" CssClass="btn btn-sm btn-primary" OnClick="btn_New_Role_Click" />

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

            </div>
            </div>
        <br />
        <br />
           <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="row">
                    <div class="card">
                        <div class="card-body">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <h6>View Roles</h6>
                                <hr />
                                <asp:Button ID="Btn_Export" runat="server" Text="Export" CssClass="btn btn-sm btn btn-outline-success" OnClick="Btn_Export_Click" />
                                <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn btn-outline-info" OnClick="Btn_Reload_Click" />
                                <br />
                                <br />

                                <asp:GridView ID="GridRole" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive table-responsive-sm table-responsive-md" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" Font-Bold="false" DataKeyNames="RoleName" OnRowDataBound="GridRole_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Role Name" SortExpression="Role Name" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblRoleName" runat="server" Text='<%# Bind("RoleName") %>' TabIndex="6" CssClass="form-label"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRoleName1" runat="server" Text='<%# Bind("RoleName") %>' TabIndex="6" CssClass="form-label"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblTotalUser" runat="server" Text="Total User:" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblCount" runat="server" Text="" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEditRole" runat="server" CssClass="btn btn-sm btn-outline-info" Text="" OnClick="btnEditRole_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDeleteRole" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteRole_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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
</asp:Content>
