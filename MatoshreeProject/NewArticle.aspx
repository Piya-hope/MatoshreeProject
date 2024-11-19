<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="NewArticle.aspx.cs" Inherits="MatoshreeProject.NewArticle" %>

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
          <h5 class="font-weight-medium mb-0">New Article</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                  <li class="breadcrumb-item"><a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard</a></li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Article.aspx">Article
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="#">New Article</li>
            </ol>
        </nav>
        <br />
       
        <br />
        <div class="row">
            <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2"></div>
            <div class="col-md-8 col-sm-8 col-ld-8 col-xs-8">
                <div class="card">
                    <div class="card-body">
                        <div class="form-group mt-3">
                            <asp:Label ID="lblSubject" runat="server" Text="Subject" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txtSubject" CssClass="form-control border" runat="server" placeholder="Enter Subject"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject" Display="Dynamic" ErrorMessage="Enter Subject" ForeColor="Red"  Font-Size="12px"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblGroup" runat="server" Text="Group" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvGroup" runat="server" ControlToValidate="ddlGroup" Display="Dynamic" ErrorMessage="Select Group" ForeColor="Red"  Font-Size="12px"></asp:RequiredFieldValidator>

                            <%--   <asp:TextBox ID="txtGroup" CssClass="form-control border" runat="server" placeholder="Enter Group"></asp:TextBox>--%>
                            <asp:RequiredFieldValidator ID="rfvColor" runat="server" ControlToValidate="ddlGroup" Display="Dynamic" ErrorMessage="Enter Group" ForeColor="Red"  Font-Size="12px"></asp:RequiredFieldValidator>
                            <br />

                            <div class="checkbox checkbox-primary">
                                <asp:CheckBox ID="chkinternalArticle" Text="Internal Article" runat="server" CssClass="mb-0 w-100 todo-label mr-2" /><br />
                                <asp:CheckBox ID="chkDisabled" Text="Disabled" runat="server" CssClass="mb-0 w-100 todo-label mr-2" />
                               
                            </div>

                            <br />
                            <asp:Label ID="lblarticleDescribtion" runat="server" Text="Article Description" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp; <%--<span style="color: #FF0000">*</span>--%>
                            <asp:TextBox ID="txtArticleDescribtion" TextMode="MultiLine" CssClass="form-control border" runat="server" placeholder="Enter Article Description"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvShortDescription" runat="server" ControlToValidate="txtarticleDescribtion" Display="Dynamic" ErrorMessage="Enter Article Description" ForeColor="Red"  Font-Size="12px"></asp:RequiredFieldValidator>--%>
                            <br />

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
