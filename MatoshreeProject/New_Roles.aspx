<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="New_Roles.aspx.cs" Inherits="MatoshreeProject.New_Roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridRole = $("#GridRole").prepend($("<thead></thead>").append($("#GridRole").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "600px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h5 class="font-weight-medium  mb-0">New Role</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item text-muted" href="#">Expenses</li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Roles.aspx">Roles
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="#">New Role</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="col-md-7 col-sm-7 col-lg-7 col-xs-7">
                <div class="card">
                    <div class="card-body">
                        <h6>Permissions</h6>
                        <hr />
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="mb-2">
                                    <asp:Label ID="lbl_Role_Name" runat="server" Text="Role Name" CssClass="form-label"></asp:Label>&nbsp;<span id="ctl_YourContro112" style="color: red;">*</span>
                                    <asp:TextBox ID="txt_Role_Name" runat="server" CssClass="form-control" placeholder="Enter Role Name">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Role_Name" ForeColor="Red" Display="Dynamic" ErrorMessage="Please enter the roll name." ValidationGroup="Save1" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridRole" AutoGenerateColumns="false" CssClass="table table-bordered table-responsive table-responsive-sm table-responsive-md" runat="server" OnRowDataBound="GridRole_RowDataBound" Style="width: 100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" Text='<%#Eval("ID")%>' runat="server" Visible="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Permission">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblWebPage" Text='<%#Eval("WebPageName")%>' runat="server" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Global View">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAllGlobal" runat="server" Text="Global View" AutoPostBack="true" Checked="false" OnCheckedChanged="chkAllGlobal_CheckedChanged" CssClass="form-group" Font-Size="12px" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="GlobalChkView" runat="server" AutoPostBack="true" OnCheckedChanged="GlobalChkView_CheckedChanged" CssClass="form-group" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAllView" runat="server" Text="View" AutoPostBack="true" Checked="false" OnCheckedChanged="chkAllView_CheckedChanged" CssClass="form-group" Font-Size="12px" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkView" runat="server" AutoPostBack="true" OnCheckedChanged="ChkView_CheckedChanged" CssClass="form-group" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAllEdit" runat="server" Text="Edit" AutoPostBack="true" Checked="false" OnCheckedChanged="chkAllEdit_CheckedChanged" CssClass="form-group" Font-Size="12px" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkEdit" runat="server" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Create">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAllCreate" runat="server" Text="Create" AutoPostBack="true" Checked="false" OnCheckedChanged="chkAllCreate_CheckedChanged" CssClass="form-group" Font-Size="12px" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkCreate" runat="server" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAllDelete" runat="server" Text="Delete" AutoPostBack="true" Checked="false" OnCheckedChanged="chkAllDelete_CheckedChanged" CssClass="form-group" Font-Size="12px" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkDelete" runat="server" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="mb-2">
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="Save1" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Clear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" Style="position: relative; margin-left: 3%; margin-top: 0%;" OnClick="btn_Clear_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-5 col-sm-5 col-lg-5 col-xs-5"></div>
        </div>
    </div>


    <script>
        function SelectAllCheckboxes(checkbox) {
            var gridView = document.getElementById('<%= GridRole.ClientID %>');
            var checkboxes = gridView.getElementsByTagName('input');

            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].type === 'checkbox') {
                    checkboxes[i].checked = checkbox.checked;
                }
            }
        }
    </script>

</asp:Content>
