<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="NewToDo.aspx.cs" Inherits="MatoshreeProject.NewToDo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
            <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
        <h5 class="font-weight-medium mb-0">New ToDo</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="ViewToDo.aspx">To Do
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="#">New ToDo</li>
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
        <div class="col-md-12 col-lg-12 col-sm-12">
            <div class="row">
                <div class="col-md-3 col-lg-3 col-sm-3">
                </div>
                <div class="col-md-6 col-lg-6 col-sm-6">
                    <div class="card shadow-lg border-dark">
                        <div class="card-body">
                            <h6>
                                <asp:Label ID="lbltodotitle" runat="server" Text="New TODO item" Font-Bold="true" Font-Size="12px" ForeColor="Blue"></asp:Label></h6>

                            <asp:Label ID="lblnewtodoid" runat="server" Text="" Font-Bold="true" Font-Size="12px" ForeColor="Blue" Visible="false"></asp:Label>
                            <br />
                            <div class="mb-2">
                                <asp:Label ID="lblDecription" runat="server" Text="Description" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:TextBox ID="txttodotask" runat="server" placeholder="Enter ToDo Item" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatormsg" runat="server" ErrorMessage="Enter ToDo Item" Display="Dynamic" ControlToValidate="txttodotask" ForeColor="Red" ValidationGroup="TODO" Font-Size="12px"></asp:RequiredFieldValidator>

                            </div>

                            <hr />
                            <div class="mb-2">
                                <asp:Button ID="btnSaveTODO" runat="server" Text="Save" CssClass="btn btn-sm btn-info" OnClick="btnSaveTODO_Click" ValidationGroup="TODO" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnClearTODO" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" OnClick="btnClearTODO_Click" ValidationGroup="CLEAR" />

                            </div>

                            <div class="mb-2">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-sm btn-success" Visible="false" OnClick="btnUpdate_Click" ValidationGroup="UPDATETODO" />
                                &nbsp;&nbsp;
                             <asp:Button ID="btnClear" runat="server" Text="Close" CssClass="btn btn-sm btn-danger" Visible="false" OnClick="btnClear_Click" ValidationGroup="Cleat3" />
                            </div>
                        </div>

                    </div>
                </div>

                <div class="col-md-3 col-lg-3 col-sm-3">
                </div>
            </div>
        </div>
    </div>

</asp:Content>
