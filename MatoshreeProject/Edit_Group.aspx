<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Edit_Group.aspx.cs" Inherits="MatoshreeProject.Edit_Group" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
          <h5 class="font-weight-medium mb-0">Edit Group</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Group.aspx">Group
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="#">Edit Group</li>
            </ol>
        </nav>
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="lblID" runat="server" Text="Group ID::" Visible="false"></asp:Label>
        <asp:Label ID="lblGroupNameWGV" runat="server" Text="" Font-Bold="true" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>
        <div class="row">
            <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2"></div>
            <div class="col-md-8 col-sm-8 col-ld-8 col-xs-8">
                <div class="card">
                    <div class="card-body">
                        <h5  style="color:blue">Edit Group</h5>
                        <hr />
                        <div class="form-group mt-3">
                            <asp:Label ID="lblGroupName" runat="server" Text="Group Name" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txtGroupName" CssClass="form-control border" runat="server" placeholder="Enter Group Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvGroupName" runat="server" ControlToValidate="txtGroupName" Display="Dynamic" ErrorMessage="Enter Group Name" ForeColor="Red"  Font-Size="12px"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblColor" runat="server" Text="Color" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txtColor" CssClass="form-control border" runat="server" placeholder="Enter Color Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvColor" runat="server" ControlToValidate="txtColor" Display="Dynamic" ErrorMessage="Enter Color Name" ForeColor="Red"  Font-Size="12px"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblshortDescribtion" runat="server" Text="Short Description" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txtshortDescribtion" TextMode="MultiLine" CssClass="form-control border" runat="server" placeholder="Enter Short Description"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvShortDescription" runat="server" ControlToValidate="txtshortDescribtion" Display="Dynamic" ErrorMessage="Enter Short Description" ForeColor="Red"  Font-Size="12px"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblOrder" runat="server" Text="Order" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txtorder" CssClass="form-control border" runat="server" placeholder="Enter Order"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvOrder" runat="server" ControlToValidate="txtorder" Display="Dynamic" ErrorMessage="Enter Order" ForeColor="Red"  Font-Size="12px"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revOrder" runat="server" ControlToValidate="txtorder" Display="Dynamic" ErrorMessage="Order must be a valid number" ValidationExpression="^\d+$" ForeColor="Red"></asp:RegularExpressionValidator>
                            <br />

                            
                            <div class="checkbox checkbox-primary">
                                <asp:CheckBox ID="chkboxfornewgroup" runat="server" Text="Disabled" CssClass=" mb-0 w-100 todo-label mr-2" />
                               <%-- <asp:Label ID="lblnewgroup" runat="server" Text="Disabled"></asp:Label><br />--%>
                                <%--<asp:Label ID="lblforgroup" runat="server" Text="Note:All articles in this group will be hidden if disabled is checked" Style="color: grey;"></asp:Label>--%>
                            </div>
                             <br />
                            <div class="mb-2">
                                <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="form-label"></asp:Label>

                                <asp:RadioButtonList ID="RadioButtonListGroup" runat="server" TabIndex="24" Font-Size="12px">
                                    <asp:ListItem Text="Active" Value="1" Selected="True" Font-Size="12px"></asp:ListItem>
                                    <asp:ListItem Text="Inactive" Value="0" Font-Size="12px"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>


                        </div>
                        <div class="row">

                            <div class="col-md-4 col-sm-4 col-ld-4 col-xs-4">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-sm btn-success" OnClick="btnUpdate_Click" />
                                &nbsp; &nbsp;
                              
                                <asp:Button ID="btnBack" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnBack_Click" />
                            </div>
                            <div class="col-md-8 col-sm-8 col-ld-8 col-xs-8"></div>
                        </div>
                    </div>

                </div>
            </div>
            <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2"></div>
        </div>

    </div>
</asp:Content>
