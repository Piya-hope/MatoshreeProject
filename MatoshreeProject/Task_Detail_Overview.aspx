<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Task_Detail_Overview.aspx.cs" Inherits="MatoshreeProject.Task_Detail_Overview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridTaskoverview = $("#GridTaskoverview").prepend($("<thead></thead>").append($("#GridTaskoverview").find("tr:first"))).DataTable(
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
        <div class="container-fluid">
            <h5 class="font-weight-medium mb-0">Task Overview </h5>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item">
                        <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                        </a>
                    </li>
                    <li class="breadcrumb-item">
                        <a class="text-muted text-decoration-none" href="TaskDetailsStaff.aspx">Task Details
                        </a>
                    </li>
                    <li class="breadcrumb-item text-muted" aria-current="page" href="#">Task Overview </li>
                </ol>
            </nav>
            <br />
            <div class="row">
                <div class="col-md-12 col-sm-12 col-lg-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <h5>Task Detail Overview </h5>
                                <hr />
                                <div class="col-md-2 col-sm-2 col-lg-2">
                                    <asp:Button ID="btn_Back_to_Task_List" runat="server" Text="Back To Task List" CssClass="btn btn-sm btn-dark" OnClick="btn_Back_to_Task_List_Click" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-2 col-sm-2 col-lg-2">
                                    <asp:DropDownList ID="ddl_Staff_Member" CssClass="form-control form-select" runat="server"></asp:DropDownList>
                                </div>

                                <div class="col-md-2 col-sm-2 col-lg-2">
                                    <asp:DropDownList ID="ddl_All_Months" CssClass="form-control form-select" runat="server">
                                        <asp:ListItem Value="0" Text="Select Months"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="January"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="February"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="March"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="April"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="June"></asp:ListItem>
                                        <asp:ListItem Value="7" Text="July"></asp:ListItem>
                                        <asp:ListItem Value="8" Text="August"></asp:ListItem>
                                        <asp:ListItem Value="9" Text="September"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="October"></asp:ListItem>
                                        <asp:ListItem Value="11" Text="November"></asp:ListItem>
                                        <asp:ListItem Value="12" Text="December"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2 col-sm-2 col-lg-2">
                                    <asp:DropDownList ID="ddl_All" CssClass="form-control form-select" runat="server">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-2 col-sm-2 col-lg-2">
                                    <asp:DropDownList ID="ddl_Year" CssClass="form-control form-select" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2 col-sm-2 col-lg-2">
                                    <asp:Label ID="Label3" runat="server" Text="Fetch Month From" CssClass="font-14 font-bold" ForeColor="Blue"></asp:Label>&nbsp;<br />

                                    <asp:RadioButton ID="rbt_Due_Date" runat="server" Text="Due Date" /><br />
                                    <asp:RadioButton ID="rbt_Start_Date" runat="server" Text="Start Date" />
                                </div>
                                <div class="col-md-1 col-sm-1 col-lg-1">
                                    <asp:Button ID="btn_Filter" runat="server" Text="Filter" CssClass="btn btn-sm btn-primary" OnClick="btn_Filter_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12 col-sm-12 col-lg-12">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">View Task Details</h5>
                            <hr />

                            <br />
                            <asp:GridView ID="GridTaskoverview" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                ClientIDMode="Static" EmptyDataText="No Records found" DataKeyNames="ID" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
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
                                    <asp:TemplateField HeaderText="Priority" SortExpression="Priority" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblPriority" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPriority1" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Finished on time?" SortExpression="" Visible="false"></asp:TemplateField>
                                    <asp:TemplateField HeaderText="AssignedTo" SortExpression="Reletd_To" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblReletd_To" runat="server" Text='<%# Bind("Reletd_To") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>

                                        <ItemTemplate>
                                            <asp:Label ID="lblReletd_To1" runat="server" Text='<%# Bind("Reletd_To") %>' ClientIDMode="Static" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="StartDate" SortExpression="Start_Date" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblStart_Date" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblStart_Date1" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DueDate" SortExpression="Due_Date" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblDue_Date" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>

                                            <asp:Label ID="lblDue_Date1" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>

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
</asp:Content>
