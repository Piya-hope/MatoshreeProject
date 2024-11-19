<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ActivityLogs.aspx.cs" Inherits="MatoshreeProject.ActivityLogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridActivityReport = $("#GridActivityReport").prepend($("<thead></thead>").append($("#GridActivityReport").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Activity Report</h5>
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
                <li class="breadcrumb-item text-muted" aria-current="page" href="#">Activity Report</li>
            </ol>
        </nav>
        <br />

        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Label ID="lblBelong" Text="Belong" runat="server" CssClass="form-label"></asp:Label>
                                <asp:Label ID="lblActivityNamee" Text="" runat="server" Visible="false" CssClass="text-center  font-16 font-bold"></asp:Label>
                            </div>

                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <asp:DropDownList ID="ddlBelong" CssClass="form-control form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBelong_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Label ID="lblRelatedTo" Text="RelatedTo" runat="server" CssClass="form-label"></asp:Label><br />

                            </div>
                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <asp:DropDownList ID="ddlRelatedTo" CssClass="form-control form-select" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Label ID="lblActivity" Text="Activity By" runat="server" CssClass="form-label"></asp:Label><br />

                            </div>
                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <asp:DropDownList ID="ddlActivity" CssClass="form-control form-select" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Label ID="lbldate" Text="Date" runat="server" CssClass="form-label"></asp:Label>
                            </div>
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:TextBox ID="txtStartDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="StartDate(mm/dd/yyyy)"></asp:TextBox>

                            </div>
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:TextBox ID="txtEndDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="EndDate(mm/dd/yyyy)"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                          <div class="col-md-4 col-sm-4 col-lg-4"></div>

                             <div class="col-md-1 col-sm-1 col-lg-1">
                                <asp:Button ID="btnSearchRerort" runat="server" Text="View Report" CssClass="btn btn-primary btn-sm " OnClick="btnSearchRerort_Click" />  
                            </div>
                               &nbsp; &nbsp; &nbsp; &nbsp;
                           <div class="col-md-1 col-sm-1 col-lg-1">
                                <div class="bd-example">
                                    <div class="btn-group">
                                        <button class="btn btn-sm btn-success  dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                        <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="lnkbtnExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDF_Click"></asp:LinkButton>
                                        </div>
                                    </div>
                           
                                </div>
                            </div>
                          <div class="col-md-1 col-sm-1 col-lg-1">
                                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-danger btn-sm" OnClick="btnClear_Click" />

                            </div>



                            <div class="col-md-5 col-sm-5 col-lg-5">
                                <!------PDF code--------->

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
                                <br />
                                <!------PDF code--------->

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
                    <h5>View ActivityLog Details</h5>
                    <hr />
                    <asp:GridView ID="GridActivityReport" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                        ClientIDMode="Static" EmptyDataText="No Records found" DataKeyNames="ID" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
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
                                    <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Activity" SortExpression="ActivityType" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                <EditItemTemplate>
                                    <asp:Label ID="lblActivityType" runat="server" Text='<%# Bind("ActivityType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblActivityType1" runat="server" Text='<%# Bind("ActivityType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ActivityDate" SortExpression="ActivityDate" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                <EditItemTemplate>
                                    <asp:Label ID="lblActivityDate" runat="server" Text='<%# Bind("ActivityDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblActivityDate" runat="server" Text='<%# Bind("ActivityDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="UserName" SortExpression="UserID" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                <EditItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("UserID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName1" runat="server" Text='<%# Bind("UserID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EmpID" SortExpression="EmpID" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px" Visible="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblEmpID" runat="server" Text='<%# Bind("EmpID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpID1" runat="server" Text='<%# Bind("EmpID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Designation" SortExpression="Designation" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                <EditItemTemplate>
                                    <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("Designation") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignation1" runat="server" Text='<%# Bind("Designation") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Belong" SortExpression="ActivityBelong" HeaderStyle-Font-Size="12px">
                                <EditItemTemplate>
                                    <asp:Label ID="lbActivityBelong" runat="server" Text='<%# Bind("ActivityBelong") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblActivityBelong1" runat="server" Text='<%# Bind("ActivityBelong") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ActivityFor" SortExpression="ActivityFor" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                <EditItemTemplate>
                                    <asp:Label ID="lblActivityFor" runat="server" Text='<%# Bind("ActivityFor") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblActivityFor" runat="server" Text='<%# Bind("ActivityFor") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

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

</asp:Content>
