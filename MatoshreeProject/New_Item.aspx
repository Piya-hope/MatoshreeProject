<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="New_Item.aspx.cs" Inherits="MatoshreeProject.New_Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">New Item</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Item_List.aspx">Items</a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="#">New Item</li>
                    </ol>
                </nav>
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
            <br />
            <div class="col-md-12 col-lg-12 col-sm-12">
                <div class="row">
                    <div class="col-md-3 col-lg-3 col-sm-3">
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-6">
                        <div class="card shadow-lg border-dark">
                            <div class="card-body">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="mb-2">
                                            <asp:Label ID="lbl_Description" runat="server" Text="Description" Font-Bold="true" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txt_Description" runat="server" CssClass="form-control" placeholder="Enter Description"></asp:TextBox>
                                        </div>
                                        <div class="mb-2">
                                            <asp:Label ID="lbl_Rate" runat="server" Text="Rate" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:TextBox ID="txt_Rate" runat="server" CssClass="form-control" placeholder="Enter Rate"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Rate" runat="server" ErrorMessage="Enter Rate" Display="Dynamic" ControlToValidate="txt_Rate" ForeColor="Red" ValidationGroup="Save" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="mb-2">
                                            <asp:Label ID="lblHSNCode" runat="server" Text="HSNCode" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:TextBox ID="txtHSNCode" runat="server" CssClass="form-control" placeholder="Enter HSNCode"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtHSNCode" ErrorMessage="Enter HSNCode" ForeColor="Red" ValidationGroup="Save" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="mb-2">
                                            <asp:Label ID="lbl_LongDescription" runat="server" Font-Bold="true" Text="Long Description" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txt_LongDescription" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Enter Long Description"></asp:TextBox>
                                        </div>
                                        <div class="mb-2">
                                            <asp:Label ID="lbl_Tax" runat="server" Text="Tax1" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:DropDownList ID="ddlTax" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTax_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblTaxValues1" runat="server" Font-Bold="true" Text="" CssClass=" font-bold" Visible="false"></asp:Label>


                                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlTax" ErrorMessage="Select TAX1" InitialValue="0" ForeColor="Red" ValidationGroup="Save" Font-Size="12px"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="mb-2">
                                            <asp:Label ID="lbl_Tax2" runat="server" Text="Tax2" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:DropDownList ID="ddlTax1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTax1_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblTaxValues2" runat="server" Font-Bold="true" Text="" CssClass=" font-bold" Visible="false"></asp:Label>

                                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlTax1" ErrorMessage="Select TAX2" InitialValue="0" ForeColor="Red" ValidationGroup="Save" Font-Size="12px"></asp:RequiredFieldValidator>

                                        </div>

                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlTax1" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlTax" EventName="SelectedIndexChanged" />

                                    </Triggers>
                                </asp:UpdatePanel>
                                <div class="mb-2">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="Save" OnClick="btn_Save_Click" />
                                    &nbsp;&nbsp;
                                <asp:Button ID="btn_Close" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="clear" OnClick="btn_Close_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                    </div>
                </div>

            </div>
        </div>
</asp:Content>
