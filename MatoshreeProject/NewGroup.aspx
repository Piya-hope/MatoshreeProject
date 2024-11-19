<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="NewGroup.aspx.cs" Inherits="MatoshreeProject.NewGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .required-label::after {
            content: '*';
            color: red;
            margin-left: 4px; /* Adjust the margin as needed */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
         <h5 class="font-weight-medium mb-0">New Group</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Article.aspx">Article
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Group.aspx">Group
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="#">New Group</li>
            </ol>
        </nav>
        <br />
        <br />
        <br />
        <div class="row">
            <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2"></div>
            <div class="col-md-8 col-sm-8 col-ld-8 col-xs-8">
                <div class="card">
                    <div class="card-body">
                        <div class="form-group mt-3">
                            <asp:Label ID="lblGroupName" runat="server" Text="Group Name" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txtGroupName" CssClass="form-control border" runat="server" placeholder="Enter Group Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvGroupName" runat="server" ControlToValidate="txtGroupName" Display="Dynamic" ErrorMessage="Enter Group Name" ForeColor="Red"  Font-Size="12px"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblColor" runat="server" Text="Color" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txtColor" CssClass="form-control border" runat="server" placeholder="Enter Color Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvColor" runat="server" ControlToValidate="txtColor" Display="Dynamic" ErrorMessage="Enter Color Name" ForeColor="Red"  Font-Size="12px"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblshortDescribtion" runat="server" Text="Short Description" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp; <%--<span style="color: #FF0000">*</span>--%>
                            <asp:TextBox ID="txtshortDescribtion" TextMode="MultiLine" CssClass="form-control border" runat="server" placeholder="Enter Short Description"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvShortDescription" runat="server" ControlToValidate="txtshortDescribtion" Display="Dynamic" ErrorMessage="Enter Short Description" ForeColor="Red"  Font-Size="12px"></asp:RequiredFieldValidator>--%>
                            <br />
                            <asp:Label ID="lblOrder" runat="server" Text="Order" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txtorder" CssClass="form-control border" runat="server" placeholder="Enter Order"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvOrder" runat="server" ControlToValidate="txtorder" Display="Dynamic" ErrorMessage="Enter Order" ForeColor="Red"  Font-Size="12px"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revOrder" runat="server" ControlToValidate="txtorder" Display="Dynamic" ErrorMessage="* Order must be a valid number" ValidationExpression="^\d+$" ForeColor="Red"></asp:RegularExpressionValidator>
                            <br />


                            <div class="checkbox checkbox-primary text-left">
                                <asp:CheckBox ID="chkboxfornewgroup" runat="server" CssClass=" mb-0 w-100 todo-label mr-2" />
                                <asp:Label ID="lblnewgroup" runat="server" Text="Disabled" CssClass="mt-1"></asp:Label><br />
                                <%--<asp:Label ID="lblforgroup" runat="server" Text="Note:All articles in this group will be hidden if disabled is checked" Style="color: grey;"></asp:Label>--%>
                            </div>

                        </div>
                        <div class="row">

                            <div class="col-md-4 col-sm-4 col-ld-4 col-xs-4">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnSubmit_Click" />
                                &nbsp; &nbsp;
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" OnClick="btnClear_Click" />


                            </div>
                            <div class="col-md-8 col-sm-8 col-ld-8 col-xs-8"></div>
                        </div>

                    </div>
                    <div class="card-footer">
                        <asp:GridView ID="GridviewGroup" runat="server" CssClass="table border table-bordered table-hover text-nowrap align-content-center"></asp:GridView>
                    </div>
                </div>
            </div>
            <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2"></div>
        </div>

    </div>


</asp:Content>
