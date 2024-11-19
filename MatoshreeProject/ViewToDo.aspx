<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ViewToDo.aspx.cs" Inherits="MatoshreeProject.ViewToDo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridfinishedTodo = $("#GridfinishedTodo").prepend($("<thead></thead>").append($("#GridfinishedTodo").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "85%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridTodo = $("#GridTodo").prepend($("<thead></thead>").append($("#GridTodo").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "85%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h5 class="font-weight-medium mb-0">ToDo</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>

                <li class="breadcrumb-item text-muted" aria-current="page" href="ViewToDo.aspx">View ToDo</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                        <div id="addnew" runat="server">
                            <asp:Button ID="btn_Createtodo" runat="server" Text="New To Do" CssClass="btn btn-primary btn-sm" OnClick="btn_Createtodo_Click" />
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
            <div class="col-md-6 col-sm-6 col-lg-6 d-flex align-items-stretch">
                <div class="card w-100">
                    <div class="card-header text-bg-warning">
                         <h5 class="font-weight-medium mb-0">Unfinished to do's</h5>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <asp:GridView ID="GridfinishedTodo" runat="server" ScrollBars="Both" CssClass="table table-responsive table-bordered table-hover text-nowrap align-middle" AutoGenerateColumns="false" CellPadding="4" Width="100%"
                                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="todo_items_id">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Sr.No" SortExpression="todo_items_id" Visible="false" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lbltodo_items_id" runat="server" Text='<%# Bind("todo_items_id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbltodo_items_id1" runat="server" Text='<%# Bind("todo_items_id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="UnFinshed" SortExpression="finshed" HeaderStyle-Width="280px" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChBoxfinished" runat="server" Checked="false" Font-Bold="true" Font-Size="12px" AutoPostBack="true" OnCheckedChanged="ChBoxfinished_CheckedChanged" />&nbsp;&nbsp;
                                                 <asp:Label ID="lbltasks" runat="server" Text='<%#Bind("description") %>' Font-Bold="true" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                <br />
                                                <asp:Label ID="lbltimetodo" runat="server" Text='<%#Bind("date_added","{0:dd-MM-yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblCreated_by1" runat="server" Text='<%#Bind("Created_by") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEditfinished" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditfinished_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDeletefinshed" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeletefinshed_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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

            <div class="col-md-6 col-sm-6 col-lg-6 d-flex align-items-stretch">
                <div class="card w-100">
                    <div class="card-header text-bg-info">
                         <h5 class="font-weight-medium mb-0">Latest Finished to do's</h5>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <asp:GridView ID="GridTodo" runat="server" ScrollBars="Both" CssClass="table table-responsive table-bordered table-hover text-nowrap align-middle" AutoGenerateColumns="false" CellPadding="4"
                                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="todo_items_id">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No" SortExpression="todo_items_id" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lbltodo_items_id2" runat="server" Text='<%# Bind("todo_items_id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbltodo_items_id1" runat="server" Text='<%# Bind("todo_items_id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Finshed" SortExpression="Created_by" HeaderStyle-Width="280px " HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChBoxTodo" runat="server" Checked="false" Font-Bold="true" Font-Size="12px" AutoPostBack="true" OnCheckedChanged="ChBoxTodo_CheckedChanged" />&nbsp;&nbsp;
                                                 <asp:Label ID="lbltasks" runat="server" Text='<%#Bind("description") %>' Font-Bold="true" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                <br />
                                                <asp:Label ID="lbltimetodo" runat="server" Text='<%#Bind("date_finished","{0:dd-MMM-yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblCreated_by1" runat="server" Text='<%#Bind("Created_by") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnunfinishedEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info" OnClick="btnunfinishedEdit_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDeleteTodo" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteTodo_Click1"><i class="ti ti-trash"></i></asp:LinkButton>
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
