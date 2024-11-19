<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ProjectReport.aspx.cs" Inherits="MatoshreeProject.ProjectReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridProjectReport = $("#GridProjectReport").prepend($("<thead></thead>").append($("#GridProjectReport").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Project Report</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="#">Report
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="#">Project Report</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <asp:Label ID="lblStatusNam" Text="StatusName" runat="server" CssClass="text-center text-info" Visible="false"></asp:Label><br />
                        <asp:TextBox ID="txtStatusNam" runat="server" CssClass="form-control" placeholder="" Visible="false"></asp:TextBox>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="lblCustomer" Text="Customer" runat="server" CssClass="text-center text-info  font-bold"></asp:Label><br />

                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="form-control form-select" Placeholder="Select Customer Name" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVddlCustomer" runat="server" ControlToValidate="ddlCustomer" ErrorMessage="Select Customer"
                                    Display="Dynamic" ForeColor="Red" ValidationGroup="View" InitialValue="0" Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-2">
                                <asp:Label ID="lblProjectName" Text="Project Name" runat="server" CssClass="text-center text-info"></asp:Label><br />

                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlProjectName" runat="server" CssClass="form-control form-select" Placeholder="Select Staff Name">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVddlddlProjectName" runat="server" ControlToValidate="ddlProjectName" ErrorMessage="Select Project Name"
                                    Display="Dynamic" ForeColor="Red" ValidationGroup="Allocate" InitialValue="0" Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <br />
                        <div class="row">

                            <div class="col-md-2">
                                <asp:Label ID="Label3" Text="Date" runat="server" CssClass="text-center text-info"></asp:Label><br />

                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtStartDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="StartDate(mm/dd/yyyy)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredPurchasestDate" runat="server" ErrorMessage="Enter Start Date" ControlToValidate="txtStartDate" ForeColor="Red" Font-Bold="false" ValidationGroup="View" Font-Size="12px"></asp:RequiredFieldValidator>


                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtEndDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="EndDate(mm/dd/yyyy)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter End Date" ControlToValidate="txtEndDate" ForeColor="Red" Font-Bold="false" ValidationGroup="View" Font-Size="12px"></asp:RequiredFieldValidator>


                            </div>

                        </div>

                        <br />
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-5">
                                <asp:Button ID="btnViewRerort" runat="server" Text="View Report" CssClass="btn btn-primary mr-4" ValidationGroup="View" OnClick="btnViewRerort_Click" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-danger " OnClick="btnClear_Click" />
                                <asp:Button ID="btnExportReport" runat="server" Text="Export Report" CssClass="btn btn-success mr-4" OnClick="btnExportReport_Click" />
                            </div>
                            <div class="col-md-4"></div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="card">
                    <div class="card-body">

                        <h5 >View Project Report</h5>
                        <hr />

                        <asp:GridView ID="GridProjectReport" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                            <Columns>

                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_id1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ProjectName" SortExpression="ProjectName" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPur_Name" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProjectName1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="StartDate" SortExpression="Start_Date" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStartDate" runat="server" Text='<%# Bind("Start_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStartDate1" runat="server" Text='<%# Bind("Start_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DuetDate" SortExpression="Deadline" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDuetDate" runat="server" Text='<%# Bind("Deadline","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDuetDate1" runat="server" Text='<%# Bind("Deadline","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ProjectCost" SortExpression="Project_Cost" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblProject_Cost" runat="server" Text='<%# Bind("Project_Cost") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProject_Cost1" runat="server" Text='<%# Bind("Project_Cost") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>


                    </div>
                </div>
            </div>
        </div>
    </div>




</asp:Content>
