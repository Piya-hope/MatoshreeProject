<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Announcement.aspx.cs" Inherits="MatoshreeProject.Announcement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridAnnouncement = $("#GridAnnouncement").prepend($("<thead></thead>").append($("#GridAnnouncement").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Announcement</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="Announcement.aspx">Announcement</li>
            </ol>
        </nav>
        <br />


        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                        <div id="addnew" runat="server">
                            <asp:Button ID="btnnewannouncement" runat="server" Text="New Announcement" CssClass="btn btn-primary btn-sm" OnClick="btnnewannouncement_Click" />
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
        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="font-weight-medium mt-3 mb-3">View Announcement Details</h5>
                        <hr />
                        <asp:Button ID="Btn_Export" runat="server" Text="Export" CssClass="btn btn-sm btn-outline-success" OnClick="Btn_Export_Click" />
                        <asp:Button ID="Btn_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-primary" OnClick="Btn_Visibility_Click" />
                        <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-primary" OnClick="Btn_Reload_Click" />
                        <br />
                        <br />
                        <asp:Label ID="lblAnnouncementid1" runat="server" Text=""></asp:Label>
                        <asp:GridView ID="GridAnnouncement" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4"
                            ClientIDMode="Static" Style="width: 100%" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="true" DataKeyNames="announcement_id" OnRowDataBound="GridAnnouncement_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="txtAnnouncementID" runat="server" Text='<%# Bind("announcement_id") %>' CssClass="form-label"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAnnouncementID" runat="server" Text='<%# Bind("announcement_id") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" HeaderStyle-Width="250px" SortExpression="ID" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="txtname" runat="server" Text='<%# Bind("name") %>' CssClass="form-label"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblname1" runat="server" Text='<%# Bind("name") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:LinkButton ID="lnkbtnname" runat="server" Text='<%# Bind("name") %>' TabIndex="6" OnClick="lnkbtnname_Click1" Font-Size="12px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Width="250px" SortExpression="ID" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="txtname" runat="server" Text='<%# Bind("date_added") %>' CssClass="form-label"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblname" runat="server" Text='<%# Bind("date_added") %>' CssClass="form-label"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditAnnouncement" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditAnnouncement_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeleteAnnouncement" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClick="btnDeleteAnnouncement_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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
</asp:Content>
