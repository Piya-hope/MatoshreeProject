<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EditDistribution.aspx.cs" Inherits="MatoshreeProject.EditDistribution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h5 class="font-weight-medium mb-0">Edit Distribution</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Distribution.aspx">Distribution
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="EditDistribution.aspx">Edit Distribution</li>
            </ol>
        </nav>
        <br />
         <div class="row">
            <div class="row">
                <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
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

        <asp:UpdatePanel ID="UpdatePanelddlState" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">


                                    <asp:Label ID="lblDistID1" runat="server" Text="" Visible="false"></asp:Label>
                                    <div class="col-md-3 col-sm-3 col-lg-3">
                                        <div class="mb-2">
                                            <asp:Label ID="lblProjects" runat="server" Text="Projects" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                            <asp:DropDownList ID="ddlProjects" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlProjects_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlProjects" ErrorMessage="Select Project" ForeColor="Red" Display="Dynamic" InitialValue="0" ValidationGroup="Inventory" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-md-3 col-sm-3 col-lg-3">
                                        <div class="mb-2">
                                            <asp:Label ID="lblDepo" for="Depo" runat="server" Text="Depo" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:DropDownList ID="ddlDepo" runat="server" CssClass="form-control form-select" Placeholder="Select Category" AutoPostBack="true" OnSelectedIndexChanged="ddlDepo_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select Depo" ControlToValidate="ddlDepo" ForeColor="Red" Font-Bold="false" ValidationGroup="Inventory" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-md-3 col-sm-3 col-lg-3">
                                        <div class="mb-2">
                                            <asp:Label ID="lblStaff" runat="server" Text="Staff Allocated" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>

                                            <asp:DropDownList ID="ddlStaff" runat="server" CssClass="form-control form-select" Placeholder="Select Staff">
                                            </asp:DropDownList>

                                        </div>
                                    </div>

                                    <div class="col-md-3 col-sm-3 col-lg-3">
                                        <div class="mb-2">
                                            <asp:Label ID="lblWorkorderNo" runat="server" Text="Work Order" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:DropDownList ID="ddlWorkOrderNo" runat="server" CssClass="form-control form-select" Placeholder="Select WorkOrder No">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
                                        <div class="col-md-3 col-sm-3 col-lg-3">
                                            <asp:Label ID="lblHandover" runat="server" Text="HandOver" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtHandover" runat="server" Placeholder="Enter HandOver Details" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
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
                                 <h5>Product List</h5>
                            <hr />
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                                        <div class="col-md-3 col-sm-3 col-xs-3 col-lg-3">
                                            <asp:Label runat="server" ID="lblProdname" Text="Product" Visible="false" CssClass="form-label"></asp:Label>
                                            <asp:DropDownList ID="ddlProdname" runat="server" Visible="false" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-md-3 col-sm-3 col-xs-3 col-lg-3">
                                        </div>
                                        <div class="col-md-3 col-sm-3 col-xs-3 col-lg-3">
                                        </div>
                                        <div class="col-md-3 col-sm-3 col-xs-3 col-lg-3">
                                        </div>
                                    </div>
                                </div>
                             
                                <div class="row">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridProduct" runat="server" ScrollBars="Both" CssClass="table border table-bordered text-nowrap align-middle" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false"
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
                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblInventoryProdID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInventoryProdID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ProductName" SortExpression="ProductName" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProductName1" runat="server" Text='<%# Bind("ProductName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label><br />
                                                        <asp:Label ID="LblItemID" runat="server" Text='<%# Bind("ItemID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Desc" SortExpression="Desc" HeaderStyle-Font-Size="12px" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lbldesc" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldesc1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label><br />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Usable" SortExpression="ProductType" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblProductType" runat="server" Text='<%# Bind("ProductType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProductType1" runat="server" Text='<%# Bind("ProductType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Category" SortExpression="Category" HeaderStyle-Font-Size="12px" HeaderStyle-Width="120px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCategory1" runat="server" Text='<%# Bind("Category") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        <asp:Label ID="lblcategoryId" runat="server" Text='<%# Bind("CategoryID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="DepoName" SortExpression="DepoName" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblDepo" runat="server" Text='<%# Bind("DepoName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDepoID1" runat="server" Text='<%# Bind("DepoID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblDepoName" runat="server" Text='<%# Bind("DepoName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Quantity") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:TextBox ID="txtQuantity1" runat="server" Text='<%# Bind("Quantity") %>' CssClass="form-control" Placeholder="Quantity" Font-Size="12px" TextMode="Number" Style="width: 150px"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Instock" SortExpression="TotalAmount" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblInstock" runat="server" Text='<%# Bind("Instock") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>

                                                        <asp:Label ID="lblInstock" runat="server" Text='<%# Bind("Instock") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Rate" SortExpression="Rate" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblRate" runat="server" Text='<%# Bind("Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRate1" runat="server" Text='<%# Bind("Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="TotalAmount" SortExpression="TotalAmount" HeaderStyle-Font-Size="12px" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Bind("TotalAmount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>

                                                        <asp:Label ID="lblTotalAmount1" runat="server" Text='<%# Bind("TotalAmount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-Font-Size="12px" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Remark" SortExpression="Status" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRemark1" runat="server" Text='<%# Bind("Remark") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <br />
                                    <center>
                                        <div class="mb-2">
                                            <asp:Button ID="btnDistribute" runat="server" CssClass="btn btn-success btn-sm" ValidationGroup="Inventory" Text="Distribute" OnClick="btnDistribute_Click" />
                                            &nbsp;&nbsp;    
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-sm btn-danger" Text="Cancel" OnClick="btnCancel_Click" />

                                        </div>

                                    </center>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlProjects" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlDepo" EventName="SelectedIndexChanged" />

            </Triggers>
        </asp:UpdatePanel>
    </div>
        </div>
</asp:Content>


