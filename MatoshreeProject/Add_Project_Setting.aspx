<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Add_Project_Setting.aspx.cs" Inherits="MatoshreeProject.Add_Project_Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var GridPermission = $("#GridPermission").prepend($("<thead></thead>").append($("#GridPermission").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
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
        <h5 class="font-weight-medium mb-0">Project Setting</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Projects.aspx">Project
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="Add_Project_Setting.aspx">Project Setting</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="card-title">
                <asp:Label ID="lblTittle" runat="server" Text="Project Permission" Font-Size="12px" Font-Bold="true"></asp:Label>

                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8"></div>
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
            <div class="col-md-2 col-sm-2 col-lg-2">
            </div>
            <div class="col-md-8 col-sm-8 col-lg-8">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <h5 style="color: blue" class="fs-5 mt-3 mb-3">Add Project Permission</h5>
                                <hr />
                                <div class="mb-2">
                                    <asp:Label ID="lblPermissionName" runat="server" Text="Permission Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtPermissionName" runat="server" placeholder="Enter Permission Name" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Permission Name" ControlToValidate="txtPermissionName" ForeColor="Red" Font-Bold="true" ValidationGroup="ProjectPermission" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                                <div class="mb-2">
                                    <asp:Label ID="lblDescription" runat="server" Text="Permission Description" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtDescription" runat="server" placeholder="Enter Permission Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="mb-2">
                                <asp:Button ID="btnSavePermission" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="ProjectPermission" OnClick="btnSavePermission_Click" />
                                &nbsp;&nbsp;
                            <asp:Button ID="btnClearPermission" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Cancel" OnClick="btnClearPermission_Click" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                <h5 class="fs-5 mt-3 mb-3">View Project Permission</h5>
                                <hr />
                                <asp:GridView ID="GridPermission" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable"
                                    EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="true" DataKeyNames="Permission_id" OnRowDataBound="GridPermission_RowDataBound"
                                    OnRowEditing="GridPermission_RowEditing" OnRowUpdating="GridPermission_RowUpdating" OnRowCancelingEdit="GridPermission_RowCancelingEdit" OnRowDeleting="GridPermission_RowDeleting" OnPageIndexChanging="GridPermission_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID" SortExpression="Permission_id" HeaderStyle-Font-Size="12px" Visible="false">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblPermission_id" runat="server" Text='<%# Bind("Permission_id") %>' CssClass="form-label"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPermission_id1" runat="server" Text='<%# Bind("Permission_id") %>' CssClass="form-label"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" SortExpression="Permission_Name" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPermission_Name" runat="server" Text='<%# Bind("Permission_Name") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPermission_Name1" runat="server" Text='<%# Bind("Permission_Name") %>' TabIndex="6" CssClass="form-label"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description" SortExpression="Permission_Description" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPermission_Description" runat="server" Text='<%# Bind("Permission_Description") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPermission_Description1" runat="server" Text='<%# Bind("Permission_Description") %>' TabIndex="6" CssClass="form-label"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Createby" SortExpression="Createby" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblCreateby" runat="server" Text='<%#Bind("Createby") %>' CssClass="form-label"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCreateby1" runat="server" Text='<%#Bind("Createby") %>' CssClass="form-label"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger"><i class="ti ti-trash"></i></asp:LinkButton>
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

            <div class="col-md-2 col-sm-2 col-lg-2"></div>
        </div>
    </div>
</asp:Content>
