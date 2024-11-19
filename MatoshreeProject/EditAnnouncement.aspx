<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EditAnnouncement.aspx.cs" Inherits="MatoshreeProject.EditAnnouncement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium  mb-0">Edit Announcement</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Announcement.aspx">Announcement
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="#">Edit Announcement</li>
                    </ol>
                </nav>
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
        <br />
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-3 col-lg-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblAnnouid" runat="server" Text="" Visible="false"></asp:Label>
                </div>
                <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                    <div class="card shadow-lg border-dark">
                        <div class="card-body">
                            <hr />
                            <div class="mb-2">
                                <asp:Label ID="lbl_subject1" runat="server" Text="Subject" CssClass="form-label"></asp:Label>
                                <span style="color: red;">*</span>
                                <asp:TextBox ID="txtsubject1" runat="server" placeholder="Enter Subject" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAnnoumcement" runat="server" ErrorMessage="Enter Subject" Display="Dynamic" ControlToValidate="txtsubject1" ForeColor="Red" ValidationGroup="EDIT" Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="lbl_message1" runat="server" Text="Message" CssClass="form-label"></asp:Label>
                                <span style="color: red;">*</span>
                                <asp:TextBox ID="txt_messages" runat="server" placeholder="Message" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatormsg" runat="server" ErrorMessage="Enter Message" Display="Dynamic" ControlToValidate="txt_messages" ForeColor="Red" ValidationGroup="EDIT" Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>
                            <div class="mb-2">
                                <div class="row">
                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 ">
                                        <asp:CheckBox ID="chkstaff" Text="Show to staff" runat="server" CssClass="custom-checkbox" Style="margin-right: 10px;" />&nbsp; &nbsp;
                                        <asp:CheckBox ID="chkclient" Text="Show to client" runat="server" CssClass="custom-checkbox" Style="margin-right: 10px;" />&nbsp; &nbsp;
                                        <asp:CheckBox ID="chkname" Text="Show to name" runat="server" CssClass="custom-checkbox" Style="margin-right: 10px;" />&nbsp; &nbsp;
                                    </div>
                                </div>
                            </div>
                            <div class="mb-2">
                                <div class="row">
                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12  text-center">
                                        <asp:Button ID="btn_Edit" runat="server" Text="Update" CssClass="btn btn-sm btn-success" OnClick="btn_Edit_Click" ValidationGroup="EDIT" />&nbsp; &nbsp;
                                          <asp:Button ID="btnclose" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnclose_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-lg-3 col-sm-3 col-xs-3">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
