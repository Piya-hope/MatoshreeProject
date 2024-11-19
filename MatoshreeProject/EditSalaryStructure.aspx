<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EditSalaryStructure.aspx.cs" Inherits="MatoshreeProject.EditSalaryStructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <div>
            <asp:Label ID="lblID" runat="server" Text=""></asp:Label><asp:Label ID="iblID1" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <div class="row">
            <div class="card-title">
                <asp:Label ID="lblTittle" runat="server" Text="Salary Slip" Font-Bold="true" Font-Size="20px"></asp:Label>
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Edit Salary Structure</h5>
                        <hr />

                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblCategory" runat="server" Text="Category" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:DropDownList ID="ddlCategory" runat="server" class="required form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="reqCategory" runat="server" ErrorMessage="Select Category" ControlToValidate="ddlCategory" ForeColor="Red" Font-Bold="false" ValidationGroup="Structure"></asp:RequiredFieldValidator>
                                </div>


                                <div class="mb-2">
                                    <asp:Label ID="lblPercentage" runat="server" Text="Percentage" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtPercentage" runat="server"  placeholder="Enter Percentage" class="required form-control"></asp:TextBox>
                                </div>
                                <div class="mb-2">
                                    <asp:Label ID="lblPerticularType" runat="server" Text="PerticularType" CssClass="form-label"></asp:Label>
                                    <asp:DropDownList ID="ddlPerticularType" runat="server" class="required form-control">
                                        <asp:ListItem Text="Select an option" Value="" />
                                        <asp:ListItem Text="Addition" Value="1" />
                                        <asp:ListItem Text="Dedution" Value="2" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblSubcategory" runat="server" Text="Subcategory" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:DropDownList ID="ddlSubcategory" runat="server" class="required form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="reqSubcategory" runat="server" ErrorMessage="Select Subcategory" ControlToValidate="ddlSubcategory" ForeColor="Red" Font-Bold="false" ValidationGroup="Structure"></asp:RequiredFieldValidator>
                                </div>


                                <div class="mb-2">
                                    <asp:Label ID="lblAmount" runat="server" Text="Amount" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtAmount" runat="server" class="required form-control" placeholder="Enter Amount"></asp:TextBox>
                                </div>

                            </div>
                            <br />
                            <div class="mb-2">
                                <center>
                                    <asp:Button ID="btnUpdateStructure" runat="server" Text="Update" CssClass="btn btn-sm btn-info" ValidationGroup="Structure" OnClick="btnUpdateStructure_Click" />
                                    &nbsp;&nbsp;
    
                                <asp:Button ID="btnCancelStructure" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" ValidationGroup="Cancel" OnClick="btnCancelStructure_Click" />
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
