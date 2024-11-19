<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ViewPrelistProject.aspx.cs" Inherits="MatoshreeProject.ViewPrelistProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridPrelist = $("#GridPrelist").prepend($("<thead></thead>").append($("#GridPrelist").find("tr:first"))).DataTable(
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
        <%-- BreadCrumbs --%>
        <h5 class="font-weight-medium mb-0">Item Request</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="ItemRequest.aspx">Item Request
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="#">View PreList</li>
            </ol>
        </nav>
        <%-- BreadCrumbs --%>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
                                <asp:GridView ID="GridPrelist" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ProjectID" OnRowDataBound="GridPrelist_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="ProjectID" SortExpression="ProjectID" HeaderStyle-Font-Size="12px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProjectID" runat="server" Text='<%# Bind("ProjectID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Project" SortExpression="ProjectName" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProjectName1" runat="server" Text='<%# Bind("ProjectName") %>' CssClass="form-label" Font-Size="12px"></asp:Label><br />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SendBy" SortExpression="SendBy" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSendBy1" runat="server" Text='<%# Bind("SendBy") %>' CssClass="form-label" Font-Size="12px"></asp:Label><br />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Requetdate" SortExpression="Requetdate" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRequetdate1" runat="server" Text='<%# Bind("Requetdate") %>' CssClass="form-label" Font-Size="12px"></asp:Label><br />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnViewList" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnViewList_Click"><i class="ti ti-eye"></i></asp:LinkButton>
                                            </ItemTemplate>
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

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <div class="mb-2">
                                    <asp:Label ID="lblProjectID1" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblProject" runat="server" Text="Project Name:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblProjectName" runat="server" Text="" CssClass="form-label" ForeColor="Blue"></asp:Label>

                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <div class="mb-2">
                                    <asp:Label ID="lblSendBy" runat="server" Text="SendBy:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblSendByName" runat="server" Text="" CssClass="form-label" ForeColor="Blue"></asp:Label>

                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <div class="mb-2">
                                    <asp:Label ID="lblDepo" runat="server" Text="Depo" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                    <asp:DropDownList ID="ddlDepo" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlDepo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDepo" ErrorMessage="Select Depo" ForeColor="Red" Display="Dynamic" InitialValue="0" ValidationGroup="Inventory" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>

                        <br />

                        <h5>Accept Project Prelist</h5>

                        <div class="row">
                            <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
                                <div class="table-responsive">
                                <asp:GridView ID="GridProduct" runat="server" ScrollBars="Both" CssClass="table border table-responsive table-bordered text-nowrap align-middle" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false"
                                    ClientIDMode="Static" ShowHeader="true" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" OnRowDataBound="GridProduct_RowDataBound" EmptyDataRowStyle-ForeColor="Red" DataKeyNames="ID">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblchk" runat="server" Text="" CssClass="form-label"></asp:Label>
                                                <asp:CheckBox ID="AllchkInvPro" runat="server" OnCheckedChanged="AllchkInvPro_CheckedChanged" AutoPostBack="true" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkInvDepopro" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID" SortExpression="ProductID" HeaderStyle-Font-Size="12px" Visible="false">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblProductID" runat="server" Text='<%# Bind("ProductID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                     <asp:Label ID="lblItemID" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                           
                                                <asp:Label ID="lblProductID1" runat="server" Text='<%# Bind("ProductID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ProductName" SortExpression="ProductName" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductName1" runat="server" Text='<%# Bind("ProductName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label><br />
                                             </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity" HeaderStyle-Font-Size="12px" Visible="false">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Quantity") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label><br />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Usable" SortExpression="ProductType" HeaderStyle-Font-Size="12px">                                           
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductType1" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Category" SortExpression="Category" HeaderStyle-Font-Size="12px" HeaderStyle-Width="120px">                                           
                                            <ItemTemplate>
                                                <asp:Label ID="lblCategory1" runat="server" Text='<%# Bind("Category") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblcategoryId" runat="server" Text='<%# Bind("CategoryID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity" HeaderStyle-Font-Size="12px">                                           
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQuantity1" runat="server" Text="" CssClass="form-control" Placeholder="Quantity" Font-Size="12px" TextMode="Number" Style="width: 150px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Instock" SortExpression="Instock" HeaderStyle-Font-Size="12px">
                                         <ItemTemplate>
                                               <asp:Label ID="lblInstock" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate" SortExpression="Rate" HeaderStyle-Font-Size="12px">                                         
                                            <ItemTemplate>
                                                <asp:Label ID="lblRate1" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TotalAmount" SortExpression="TotalAmount" HeaderStyle-Font-Size="12px" Visible="false">
                                            <ItemTemplate>
                                               <asp:Label ID="lblTotalAmount1" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                           
                                        <asp:TemplateField HeaderText="Remark" SortExpression="AcceptRequest" HeaderStyle-Font-Size="12px" Visible="false">                            
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemark1" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <center>
                                <asp:Button ID="btnAcceptPrelist" runat="server" Text="Accept" CssClass="btn btn-sm btn-success" ValidationGroup="Accept"/> &nbsp;&nbsp;
                                 <asp:Button ID="btnRejectPrelist" runat="server" Text="Reject" CssClass="btn btn-sm btn-danger" ValidationGroup="Reject"/> &nbsp;&nbsp;

                            </center>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
