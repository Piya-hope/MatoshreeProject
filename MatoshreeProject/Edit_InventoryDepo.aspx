<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Edit_InventoryDepo.aspx.cs" Inherits="MatoshreeProject.Edit_InventoryDepo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
          <h5 class="font-weight-medium mb-0">Edit Depo & Warehouse</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="InventoryDepoDetails.aspx">Depo & Warehouse
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="Edit_InventoryDepo.aspx">Edit Depo Details</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2"></div>
            <div class="col-md-8 col-lg-8 col-sm-8 col-xs-8">
                <div class="card">
                    <div class="card-body">
                        <asp:Label ID="lblInventoryDepoid" runat="server" Text="" Visible="false"></asp:Label>
                        <hr />

                        <div class="col-md-12">
                            <div class="mb-2">
                                <asp:Label ID="lblDepoName" runat="server" Text="Depo Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:TextBox ID="txtDepoName" CssClass="form-control" runat="server" Placeholder="Enter Depo Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDepoName" Display="Dynamic" runat="server" ErrorMessage="Enter Depo Name" ForeColor="Red" ValidationGroup="Inventory1" Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="mb-2">
                                <asp:Label ID="lblPhone" for="Phone" runat="server" Text="Phone" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:TextBox ID="txtPhone" runat="server" name="phone" CssClass="form-control" placeholder="Enter Phone Number" MaxLength="10"></asp:TextBox>
                                <div class="validate">
                                    <asp:RequiredFieldValidator ID="rfv_Phone" runat="server" Display="Dynamic" ControlToValidate="txtPhone" ErrorMessage="Enter 10 digit Phone Number" ForeColor="Red" ValidationGroup="Inventory1"  Font-Size="12px"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="Regulexphone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone Number Invalid." ForeColor="Red" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ValidationGroup="Inventory1"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <asp:Label ID="lblDepoCategory" runat="server" Text="Depo Category" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlDepoCategory" name="CountryShipping" runat="server" CssClass="form-control form-select">
                                <asp:ListItem Value="0">Select Depo Category</asp:ListItem>
                                <asp:ListItem Value="Office">Office</asp:ListItem>
                                <asp:ListItem Value="Rental">Rental</asp:ListItem>
                                <asp:ListItem Value="Project">Project</asp:ListItem>
                            </asp:DropDownList>
                     
                        </div>
                        <br />
                        <asp:UpdatePanel ID="UpdatePanelddlState" runat="server">
                                <ContentTemplate>
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lbllocationcountry" runat="server" Text="Country" Font-Bold="true" CssClass="form-label"></asp:Label>
                                    <asp:DropDownList ID="ddllocationcountry" runat="server" CssClass="form-select" name="CountryBilling">
                                        <asp:ListItem Value="0">Select Country</asp:ListItem>
                                        <asp:ListItem Value="India">India</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddllocationcountry" Display="Dynamic" runat="server" ErrorMessage="Select Country" ForeColor="Red" ValidationGroup="Inventory1" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lbllocationstate" runat="server" Text="State" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:DropDownList ID="ddllocationstate" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddllocationstate_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddllocationstate" Display="Dynamic" runat="server" ErrorMessage="Select State" ForeColor="Red" ValidationGroup="Inventory1" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lbllocationdistrict" runat="server" Text="District" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:DropDownList ID="ddllocationdistrict" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddllocationdistrict_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddllocationdistrict" Display="Dynamic" runat="server" ErrorMessage="Select District" ForeColor="Red" ValidationGroup="Inventory1" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lbllocationcity" runat="server" Text="City/Taluka" CssClass="form-label"></asp:Label><%--&nbsp;<span style="color: #FF0000">*</span>--%>
                                    <asp:DropDownList ID="ddllocationcity" runat="server" CssClass="form-control form-select">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="ddllocationdistrict" Display="Dynamic" runat="server" ErrorMessage="Select District" ForeColor="Red" ValidationGroup="Inventory1" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblvillage" runat="server" Text="Village" Font-Bold="true" CssClass="form-label"></asp:Label><%--&nbsp;<span style="color: #FF0000">*</span>--%>
                                    <asp:TextBox ID="txtvillage" runat="server" CssClass="form-control"></asp:TextBox>
                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtvillage" Display="Dynamic" runat="server" ErrorMessage="Enter Village" ForeColor="Red" ValidationGroup="Inventory1" Font-Size="12px"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblflatno" runat="server" Text="Flat/Block/RoadNo" Font-Bold="true" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtlocationflatno" runat="server" name="flatLocation" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtlocationflatno" Display="Dynamic" runat="server" ErrorMessage="Enter Flat/Block/RoadNo" ForeColor="Red" ValidationGroup="Inventory1" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblpincode" runat="server" Text="Pin Code" Font-Bold="true" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtlocationpincode" runat="server" name="PinLocation" CssClass="form-control" MaxLength="6"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtlocationpincode" Display="Dynamic" runat="server" ErrorMessage="Enter Pincode" ForeColor="Red" ValidationGroup="Inventory1" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="form-label"></asp:Label>

                                    <asp:RadioButtonList ID="RadioButtonListVendor" runat="server" TabIndex="24" Font-Size="12px">
                                        <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <div class="mb-2">
                                <asp:Button ID="btn_UpdateInventory" runat="server" Text="Update" CssClass="btn btn-sm btn-success" ValidationGroup="Inventory1" OnClick="btn_UpdateInventory_Click" />
                                &nbsp;&nbsp;
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" ValidationGroup="Clear" OnClick="btnCancel_Click" />

                            </div>
                        </div>

                                     </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddllocationstate" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddllocationdistrict" EventName="SelectedIndexChanged" />

                                </Triggers>
                            </asp:UpdatePanel>
                    </div>
                </div>
                <%--  </div>--%>
                <%-- </div>--%>
            </div>
             <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2"></div>
        </div>


    </div>
   
  
</asp:Content>
