<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EditArticle.aspx.cs" Inherits="MatoshreeProject.EditTestArticle" %>

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
        <h5 class="font-weight-medium  mb-0">Edit Article</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Article.aspx">Article
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="#">Edit Article</li>
            </ol>
        </nav>
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="lblID" runat="server" Text="Group ID::" Visible="false"></asp:Label>
        <asp:Label ID="lblArticleNameWGV" runat="server" Text="" Font-Bold="true" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>
        <div class="row">
            <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2"></div>
            <div class="col-md-8 col-sm-8 col-ld-8 col-xs-8">
                <div class="card">
                    <div class="card-body">
                        <div class="form-group mt-3">
                            <asp:Label ID="lblSubject" runat="server" Text="Subject Name" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txtSubjectName" CssClass="form-control border" runat="server" placeholder="Enter SubjectName"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSubjectName" runat="server" ControlToValidate="txtSubjectName" Display="Dynamic" ErrorMessage="Enter SubjectName" ForeColor="Red" Font-Size="12px"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblGroup" runat="server" Text="Group" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control"></asp:DropDownList>

                            <%--   <asp:TextBox ID="txtGroup" CssClass="form-control border" runat="server" placeholder="Enter Group"></asp:TextBox>--%>
                            <asp:RequiredFieldValidator ID="rfvColor" runat="server" ControlToValidate="ddlGroup" Display="Dynamic" ErrorMessage="Enter Group" ForeColor="Red" Font-Size="12px"></asp:RequiredFieldValidator>
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
                            <div class="mb-2">
                                <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="form-label"></asp:Label>

                                <asp:RadioButtonList ID="RadioButtonListArticle" runat="server" TabIndex="24" Font-Size="12px">
                                    <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-md-4 col-sm-4 col-ld-4 col-xs-4">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-sm btn-success" OnClick="btnUpdate_Click" />
                                &nbsp; &nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnCancel_Click" />


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
