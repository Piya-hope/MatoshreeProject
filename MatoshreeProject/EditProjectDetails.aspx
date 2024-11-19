<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EditProjectDetails.aspx.cs" Inherits="MatoshreeProject.EditProjectDetails" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script> 
        tinymce.init({
            // selector: 'textarea',
            //selector : "textarea.Editor"
            selector: ".EditorNote",
            //theme: "modern",
            //plugins: ["lists link image charmap print preview hr anchor pagebreak"],

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">Edit Project</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item"><a class="text-muted text-decoration-none" href="Projects.aspx">Project</a></li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="#">Edit Profile</li>
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
            <div class="row">
                <div class="col-md-7 col-sm-7 col-lg-7 col-xs-7">
                    <div class="card">
                        <div class="card-body">
                            <div class="mb-2">
                                <asp:Label ID="lblID" runat="server" Text="Project ID:" Font-Bold="false" Font-Size="12px" ForeColor="Black" Visible="false"></asp:Label>
                                <asp:Label ID="lblProjectID" runat="server" Text="" Font-Bold="false" Font-Size="12px" ForeColor="Blue" Visible="false"></asp:Label>
                            </div>
                            <hr />
                            <div class="mb-2">
                                <asp:Label ID="lblProjectName" runat="server" Text="Project Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:TextBox ID="txtProjectName" runat="server" placeholder="Enter Project Name" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredProjectName" runat="server" ErrorMessage="Enter Project Name" ControlToValidate="txtProjectName" ForeColor="Red" Font-Bold="false" ValidationGroup="Projects" Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>

                            <div class="mb-2">
                                <asp:Label ID="lblCustomer" runat="server" Text="Customer" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="form-control form-select" Placeholder="Select Customer" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFielddlCustomer" runat="server" ErrorMessage="Select Customer" ControlToValidate="ddlCustomer" ForeColor="Red" Font-Bold="false" ValidationGroup="Projects" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblBillingType" runat="server" Text="Billing Type" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:DropDownList ID="ddlBillingType" runat="server" CssClass="form-control form-select" Placeholder="Select Billing Type" OnSelectedIndexChanged="ddlBillingType_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text="Select Billing Type"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldBillingType" runat="server" ErrorMessage="Select Billing Type" ControlToValidate="ddlBillingType" ForeColor="Red" Font-Bold="false" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-select" Placeholder="Status" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="lblProjectMem" runat="server" Text="Project Members" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:ListBox ID="ListProjectMembers" runat="server" Height="150px" SelectionMode="Multiple" CssClass="form-control" BackColor="#f8f9fa"></asp:ListBox>
                                <asp:RequiredFieldValidator ID="RequiredProjectMembers" runat="server" ErrorMessage="Select Project Member" ControlToValidate="ListProjectMembers" ForeColor="Red" Font-Bold="false" ValidationGroup="Projects" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                                <asp:Label ID="lblStaffEmail" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblStaffDesignation" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblEmpName11" runat="server" Text="" Visible="false"></asp:Label>

                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblStartDate" runat="server" Text="Start Date" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:TextBox ID="txtStartDate" CssClass="form-control" runat="server" placeholder="Enter Start Date(mm/dd/yyyy)" Text="" type="date" Style="display: inline-block;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredStartDate" runat="server" ErrorMessage="Enter Start Date" ControlToValidate="txtStartDate" ForeColor="Red" Font-Bold="false" ValidationGroup="Projects" Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblDeadLine" runat="server" Text="Dead Line" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:TextBox ID="txtDeadline" CssClass="form-control" runat="server" placeholder="Enter Dead line" Text="" type="date" Style="display: inline-block;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredDeadLine" runat="server" ErrorMessage="Enter Dead Line" ControlToValidate="txtDeadline" ForeColor="Red" Font-Bold="false" ValidationGroup="Projects" Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <%-- Address --%>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblBillingCountry" runat="server" Text="Country" Font-Bold="true" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlCountryBilling" runat="server" CssClass="form-select" name="CountryBilling">
                                            <asp:ListItem Value="0">Select Country</asp:ListItem>
                                            <asp:ListItem Value="India">India</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblBilingState" runat="server" Text="State" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:DropDownList ID="ddlBilingState" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlBilingState_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlBilingState" ForeColor="Red" Font-Bold="false" InitialValue="-1" Display="Dynamic" ValidationGroup="Projects" ErrorMessage="Select State" Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblBillingDistrict" runat="server" Text="District" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:DropDownList ID="ddlBillingdistrict" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlBillingdistrict_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlBillingdistrict" ForeColor="Red" Font-Bold="false" InitialValue="-1" Display="Dynamic" ValidationGroup="Projects" ErrorMessage="Select District" Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblBillingCity1" runat="server" Text="City/Taluka" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:DropDownList ID="ddlBillingcity" runat="server" CssClass="form-control form-select">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlBillingcity" ForeColor="Red" Font-Bold="false" InitialValue="-1" Display="Dynamic" ValidationGroup="Projects9" ErrorMessage="Select City" Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblBillingflat" runat="server" Text="Flat/Block/RoadNo" Font-Bold="true" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtflatBilling" runat="server" name="flatBilling" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblStreetShipping1" runat="server" Text="Address" Font-Bold="true" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtStreetBilling" runat="server" name="StreetShipping1" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblBillingPinCode" runat="server" Text="Pin Code" Font-Bold="true" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtPinBilling" runat="server" name="PinBilling" CssClass="form-control" MaxLength="6"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <%-- Address --%>

                            <div class="row">
                                <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                    <asp:Label ID="lblProjectDescription" runat="server" Text="Project Description" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtDescription" runat="server" placeholder="Description" TextMode="MultiLine" class="EditorNote"></asp:TextBox>


                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                    <asp:CheckBox ID="ChBoxEmail" runat="server" Checked="false" Text="Send project created email" Font-Bold="true" Font-Size="12px" />
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="row">
                                <div class="mb-2">
                                    <asp:Label ID="lblProjectStatus" runat="server" Text="Status" CssClass="form-label"></asp:Label>

                                    <asp:RadioButtonList ID="RadioButtonListProject" runat="server" TabIndex="24" Font-Size="12px">
                                        <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="mb-2">
                                <asp:Button ID="btnUpdateProject" runat="server" Text="Update" CssClass="btn btn-sm btn-success" ValidationGroup="Projects" OnClick="btnUpdateProject_Click" />
                                &nbsp;&nbsp;
                            <asp:Button ID="btnClear" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnClear_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-5 col-lg-5 col-sm-5 col-xs-5">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title mb-0" style="color: blue">Project Setting</h5>
                            <hr />
                            <div class="table-responsive">
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="mb-2">
                                            <asp:Label ID="lblCheckAll" runat="server" Text="Select All" CssClass="form-label"></asp:Label>
                                            <span class="text-center mt-3">
                                                <asp:CheckBox ID="chk_SelectAll" runat="server" OnClick="SelectAllCheckboxes(this)" /></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <asp:GridView ID="GridPermission" AutoGenerateColumns="false" CssClass="table table-hover table-responsive" runat="server" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="12px" OnRowDataBound="GridPermission_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Project Setting" ControlStyle-CssClass=" font-bold">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblID" Text='<%#Eval("Permission_id")%>' runat="server" Visible="false" Font-Bold="true" Font-Size="12px" />

                                                            <asp:CheckBox ID="ChkView" runat="server" Checked='<%#Eval("SetPermission")%>' Font-Size="12px" />&nbsp;   
                                                    <%--  --%>
                                                            <asp:Label ID="lblWebPage" Text='<%#Eval("PermissionName")%>' runat="server" Font-Bold="true" Font-Size="12px" />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
       </div>
        <script>
            function SelectAllCheckboxes(checkbox) {
                var gridView = document.getElementById('<%= GridPermission.ClientID %>');
                var checkboxes = gridView.getElementsByTagName('input');

                for (var i = 0; i < checkboxes.length; i++) {
                    if (checkboxes[i].type === 'checkbox') {
                        checkboxes[i].checked = checkbox.checked;
                    }
                }
            }
        </script>
</asp:Content>
