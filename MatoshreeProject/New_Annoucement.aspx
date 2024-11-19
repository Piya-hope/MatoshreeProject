<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="New_Annoucement.aspx.cs" Inherits="MatoshreeProject.New_Annoucement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
          <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
         <h5 class="font-weight-medium mb-0">Add New Announcement</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Announcement.aspx">Announcement
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="#">New Announcement</li>
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
        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
            <div class="row">
                <div class="col-md-3 col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                    <div class="card shadow-lg border-dark">
                        <div class="card-body">
                            <div class="mb-2">
                                <asp:Label  ID="lbl_subject" runat="server" Text="Subject" CssClass="form-label"></asp:Label>
                                 <span  style="color: red;">*</span>
                                <asp:TextBox ID="txtsubject" runat="server" placeholder="Enter Subject" CssClass="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Subject" Display="Dynamic" ControlToValidate="txtsubject" ForeColor="Red" ValidationGroup="SAVE"  Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="lbl_message" runat="server" Text="Message" CssClass="form-label"></asp:Label>
                                 <span  style="color: red;">*</span>
                                <asp:TextBox ID="txt_message" runat="server" TextMode="MultiLine" placeholder=" Enter Message" CssClass="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Message" Display="Dynamic" ControlToValidate="txt_message" ForeColor="Red" ValidationGroup="SAVE"  Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>
                            
                            <div class="mb-2">
                                <div class="row">
                                   <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 " >       
                                        <asp:CheckBox ID="chkstaff" Text="Show to staff" runat="server" CssClass="custom-checkbox" style="margin-right: 10px;" />&nbsp; &nbsp;
                                        <asp:CheckBox ID="chkclient" Text="Show to client" runat="server" CssClass="custom-checkbox" style="margin-right: 10px;"/>&nbsp; &nbsp;
                                        <asp:CheckBox ID="chkname" Text="Show to name" runat="server" CssClass="custom-checkbox" style="margin-right: 10px;" />&nbsp; &nbsp;
                                    </div>
                                     </div>
                            </div>
                            <div class="mb-2">
                                <div class="row">
                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12  text-center" > 
                                        <asp:Button ID="btn_Save" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btn_Save_Click" ValidationGroup="SAVE" />&nbsp; &nbsp;
                                          <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger " OnClick="btnclear_Click" />
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
