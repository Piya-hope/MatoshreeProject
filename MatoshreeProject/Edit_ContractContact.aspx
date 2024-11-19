<%@ Page Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Edit_ContractContact.aspx.cs" Inherits="MatoshreeProject.Edit_ContractContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridTask1 = $("#GridTask1").prepend($("<thead></thead>").append($("#GridTask1").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
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
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">Edit Contract</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item text-decoration-none"><a href="#">Legal</a></li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Contract_Contact.aspx">Contract Partner
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="Edit_ContractContact.aspx">Edit Contract Partner</li>
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
            <div class="col-md-5 col-lg-5 col-sm-5 col-xs-5">
                <div class="card">
                    <div class="card-body">
                        <h6 class="text-purple">Contract Details</h6>
                        <hr />
                        <div class="row">
                            <div class="col-md-5 col-lg-5 col-sm-5 col-xs-5">
                                <div class="mb-2">
                                    <asp:CheckBox ID="ChBoxTrash" runat="server" Checked="false" Text="Trash" />
                                </div>
                            </div>
                            <div class="col-md-7 col-lg-7 col-sm-7 col-xs-7">
                                <div class="mb-2">
                                    <asp:CheckBox ID="CheckHidePartner" runat="server" Checked="false" Text="Hide From Partner" />
                                </div>
                            </div>
                        </div>

                        <div class="mb-2">
                            <asp:Label ID="lblContractPartnerID" runat="server" Visible="false" Text=""></asp:Label>

                        </div>

                        <div class="mb-2">
                            <asp:Label ID="lblpartnername" runat="server" Text="Patner Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:DropDownList ID="ddlpartnername" runat="server" CssClass="form-control form-select" Placeholder="Select Patner Name ">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Patner Name" ControlToValidate="ddlpartnername" ForeColor="Red" Font-Bold="false" ValidationGroup="Save" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-2">
                            <asp:Label ID="lblSubject" runat="server" Text="Subject" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txtSubject" runat="server" placeholder="Enter Subject" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldSubject" runat="server" ErrorMessage="Enter Contract Subject" ControlToValidate="txtSubject" ForeColor="Red" Font-Bold="false" ValidationGroup="Update" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>
                        <div class="row">
                            <div class="mb-2">
                                <div class="input-group">
                                    <asp:Label ID="lblContractValue" runat="server" Text="Contract Value" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtContractValue" runat="server" placeholder="Contract Value" type="number" name="hourly_rate" value="0" class="form-control" aria-invalid="false" Style="width: 132%"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldContractValue" runat="server" ErrorMessage="Enter Contract Value" ControlToValidate="txtContractValue" ForeColor="Red" Font-Bold="false" ValidationGroup="Update" Font-Size="12px"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>

                        <div class="mb-2">
                            <asp:Label ID="lblContracttype" runat="server" Text="Contract Type" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:DropDownList ID="ddlContracttype" runat="server" CssClass="form-control form-select" Placeholder="Select Contract Type">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Contract Type" ControlToValidate="ddlContracttype" ForeColor="Red" Font-Bold="false" ValidationGroup="Save" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>

                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblStartDate" runat="server" Text="Start Date" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtStartDate" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter Start Date" ReadOnly="true"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblEndDate" runat="server" Text="End Date" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtEndDate" CssClass="form-control" runat="server" placeholder="Enter End Date" ReadOnly="true"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                        <div class="mb-2">
                            <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtDescription" runat="server" placeholder="Description" class="form-control" TextMode="MultiLine" Height="200px"></asp:TextBox>
                        </div>

                        <div class="mb-2">
                            <asp:Label ID="lblstatus" runat="server" Text="Status" CssClass="form-label"></asp:Label>
                            <asp:RadioButtonList ID="RadioButtonListContract" runat="server" TabIndex="24" Font-Size="12px">
                                <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>

                        <div class="mb-2">
                            <asp:Button ID="btnEditProject" runat="server" Text="Update" CssClass="btn btn-sm btn-success" OnClick="btnEditProject_Click1" ValidationGroup="Update" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <%-- After Save  --%>
            <div class="col-md-7 col-lg-7 col-sm-7 col-xs-7">
                <div class="card">
                    <div class="card-body">
                        <h5 class="text-purple">Contract Overview</h5>
                        <hr />
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link active" data-bs-toggle="tab" href="#home" role="tab"><span class="hidden-sm-up"></span>
                                    <span class="hidden-xs-down">Contract</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-bs-toggle="tab" href="#profile" role="tab"><span class="hidden-sm-up"></span>
                                    <span class="hidden-xs-down">Attachment</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-bs-toggle="tab" href="#profile1" role="tab"><span class="hidden-sm-up"></span>
                                    <span class="hidden-xs-down">Contract Renewal History</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-bs-toggle="tab" href="#profile2" role="tab"><span class="hidden-sm-up"></span>
                                    <span class="hidden-xs-down">Task</span></a>
                            </li>
                        </ul>
                        <br />
                        <div class="tab-content tabcontent-border">
                            <div class="tab-pane active" id="home" role="tabpanel">
                                <div class="p-20">
                                    <div class="row">
                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12  text-end mt-3">
                                            <asp:LinkButton ID="Linkbtnprint" runat="server" CssClass="btn btn-sm btn-outline-dark" title="Printer"> <iconify-icon icon="ph:printer"></iconify-icon></asp:LinkButton>
                                            &nbsp
                                           <asp:LinkButton ID="Linkbtnpdf" runat="server" CssClass="btn btn-sm btn-outline-danger" title="PDF" OnClick="Linkbtnpdf_Click1"><iconify-icon icon="fa:file-pdf-o"></iconify-icon></asp:LinkButton>
                                            &nbsp 
                                           <asp:LinkButton ID="LinkbtnEmail" runat="server" CssClass="btn btn-sm btn-outline-primary" title="Email"><iconify-icon icon="ph:envelope-thin"></iconify-icon></asp:LinkButton>
                                        </div>
                                        <br />
                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                            <div class="mb-2">
                                                <asp:LinkButton ID="linkbtnMergeField" runat="server" Font-Size="12px" OnClick="linkbtnMergeField_Click">Availables Merge Fields</asp:LinkButton>

                                                <%-- Tables Files --%>
                                                <div class="row">

                                                    <div class="table-responsive h-25">
                                                        <table class="table table-bordered" id="tblcontract" runat="server" visible="false">
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label1" runat="server" Text="Contact Firstname" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncontract_Firstname" CssClass="text-right" runat="server" Font-Size="12px" Text="{contract_firstname}" OnClick="LinkButtoncontract_Firstname_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label2" runat="server" Text="Contact Lastname" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncontract_lastname" runat="server" Font-Size="12px" Text="{contract_lastname}" OnClick="LinkButtoncontract_lastname_Click1"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label3" runat="server" Text="Set New Password Url" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">

                                                                    <asp:LinkButton ID="LinkButtonset_password_url" runat="server" Font-Size="12px" Text="{set_password_url}" OnClick="LinkButtonset_password_url_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label4" runat="server" Text="Reset Password Url" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonreset_password_url" runat="server" Font-Size="12px" Text="{reset_password_url}" OnClick="LinkButtonreset_password_url_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label5" runat="server" Text="Contact Email" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncontact_email" runat="server" Font-Size="12px" Text="{contact_email}" OnClick="LinkButtoncontact_email_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label6" runat="server" Text="Client Company" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonclient_company" runat="server" Font-Size="12px" Text="{client_company}" OnClick="LinkButtonclient_company_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label7" runat="server" Text="Client Phonenumber" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonclient_phonenumber" runat="server" Font-Size="12px" Text="{client_phonenumber}" OnClick="LinkButtonclient_phonenumber_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label8" runat="server" Text="Client Country" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonclient_country" runat="server" Font-Size="12px" Text="{client_country}" OnClick="LinkButtonclient_country_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label9" runat="server" Text="Client City" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonclient_city" runat="server" Font-Size="12px" Text="{client_city}" OnClick="LinkButtonclient_city_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label10" runat="server" Text="Client Zip" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonclient_zip" runat="server" Font-Size="12px" Text="{client_zip}" OnClick="LinkButtonclient_zip_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label11" runat="server" Text="Client State" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonclient_state" runat="server" Font-Size="12px" Text="{client_state}" OnClick="LinkButtonclient_state_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label12" runat="server" Text="Client Address" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonclient_address" runat="server" Font-Size="12px" Text="{client_address}" OnClick="LinkButtonclient_address_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label13" runat="server" Text="Client Vat Number" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonclient_var_number" runat="server" Font-Size="12px" Text="{client_var_number}" OnClick="LinkButtonclient_var_number_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label14" runat="server" Text="GST No" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncustomer_gst_no" runat="server" Font-Size="12px" Text="{customer_gst_no}" OnClick="LinkButtoncustomer_gst_no_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label15" runat="server" Text="Contract ID" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncontract_id" runat="server" Font-Size="12px" Text="{contract_id}" OnClick="LinkButtoncontract_id_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label16" runat="server" Text="Contract Subject" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncontract_subject" runat="server" Font-Size="12px" Text="{contract_subject}" OnClick="LinkButtoncontract_subject_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label17" runat="server" Text="Contract Description" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncontract_description" runat="server" Font-Size="12px" Text="{contract_description}" OnClick="LinkButtoncontract_description_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label18" runat="server" Text="Contract Date Start" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncontract_datestart" runat="server" Font-Size="12px" Text="{contract_datestart}" OnClick="LinkButtoncontract_datestart_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label19" runat="server" Text="Contract Date End" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncontract_dateend" runat="server" Font-Size="12px" Text="{contract_dateend}" OnClick="LinkButtoncontract_dateend_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label20" runat="server" Text="Contract Value" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncontract_contract_value" runat="server" Font-Size="12px" Text="{contract_contract_value}" OnClick="LinkButtoncontract_contract_value_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label21" runat="server" Text="Logo Url" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonlogo_url" runat="server" Font-Size="12px" Text="{logo_url}" OnClick="LinkButtonlogo_url_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label22" runat="server" Text="CRM Url" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncrm_url" runat="server" Font-Size="12px" Text="{crm_url}" OnClick="LinkButtoncrm_url_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label23" runat="server" Text="Admin Url" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonatmin_url" runat="server" Font-Size="12px" Text="{atmin_url}" OnClick="LinkButtonatmin_url_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label24" runat="server" Text="Main Domain" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonmain_domain" runat="server" Font-Size="12px" Text="{main_domain}" OnClick="LinkButtonmain_domain_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label25" runat="server" Text="Company Name" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtoncompanyname" runat="server" Font-Size="12px" Text="{companyname}" OnClick="LinkButtoncompanyname_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <asp:Label ID="Label26" runat="server" Text="Email Signature" CssClass="font-12 font-bold"></asp:Label>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="LinkButtonemail_signature" runat="server" Font-Size="12px" Text="{email_signature}" OnClick="LinkButtonemail_signature_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="text-left">
                                                                    <%--<asp:Label ID="Label27" runat="server" Text="clear" CssClass="font-12 font-bold"></asp:Label>--%>
                                                                </td>
                                                                <td class="text-right">
                                                                    <asp:LinkButton ID="Linkclear" runat="server" Font-Size="12px" Text="{clear}" ForeColor="Red" OnClick="Linkclear_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>



                                                        </table>
                                                    </div>

                                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                        <asp:TextBox ID="textBox" runat="server" class="form-control" TextMode="MultiLine" Height="200px" Visible="false"></asp:TextBox>

                                                    </div>

                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12  text-end mt-3">
                                            <%--<asp:Button ID="Button1" runat="server" Text="Clear" CssClass="btn btn-dark" ForeColor="White" OnClick="Button1_Click" />--%>
                                            <%--<asp:LinkButton ID="LinkbtnClearselectedfield" runat="server" CssClass="btn btn-sm btn-outline-danger" OnClick="LinkbtnClearselectedfield_Click">clear</asp:LinkButton>--%>
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane p-20" id="profile" role="tabpanel">
                                <div class="p-20">
                                    <div class="row">
                                        <div class="mb-2">
                                            <div class="input-group">
                                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                                <asp:Button ID="Btn_Upload" runat="server" Text="Upload" CssClass="btn btn-sm btn-primary" OnClick="Btn_Upload_Click" />
                                            </div>
                                        </div>
                                        <div class="mb-2">
                                            <asp:Label ID="lblpartnerFilename" runat="server" Text="" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane p-20" id="profile1" role="tabpanel">
                                <div class="p-20">
                                    <div class="row">
                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                            <div class="mb-2">
                                                <button id="btn_RenewContract" class="btn btn-sm btn-dark" forecolor="White" type="button" onclick="toggleForm()">
                                                    <i class="ti ti-refresh"></i>&nbsp;&nbsp;Renew Contract
                                                </button>
                                            </div>
                                            <div class="row" id="renewForm" style="display: none;">
                                                <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                    <div class="row">

                                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblNewStartDate" runat="server" Text="New Start Date" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                <asp:TextBox ID="txtNewStartDate" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter New Start Date" type="date"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqNewStartDate" runat="server" ErrorMessage="Enter New Start Date" ControlToValidate="txtNewStartDate" ForeColor="Red" Font-Bold="false" ValidationGroup="RenewContract" Font-Size="12px"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblOldStartDate" runat="server" Text="Old Start Date" CssClass="form-label"></asp:Label>
                                                                <asp:TextBox ID="txtOldStartDate" runat="server" Text="" CssClass="form-control" placeholder="Enter Start Date" ReadOnly="true"></asp:TextBox>

                                                            </div>
                                                        </div>

                                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblNewEndDate" runat="server" Text="New End Date" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                <asp:TextBox ID="txtNewEndDate" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter New End Date" type="date"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqnewenddate" runat="server" ErrorMessage="Enter New End Date" ControlToValidate="txtNewEndDate" ForeColor="Red" Font-Bold="false" ValidationGroup="RenewContract" Font-Size="12px"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblOldEndDate" runat="server" Text="Old End Date" CssClass="form-label"></asp:Label>
                                                                <asp:TextBox ID="txtOldEndDate" runat="server" Text="" placeholder="Enter End Date" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                                            <div class="mb-2">
                                                                <div class="input-group">
                                                                    <asp:Label ID="lblNewContractValue" runat="server" Text="New Contract Value" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                    <asp:TextBox ID="txtNewContractValue" runat="server" placeholder="New Contract Value" type="number" value="0" class="form-control" aria-invalid="false" Style="width: 132%"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="reqnewcontractvalue1" runat="server" ErrorMessage="Enter New Contract Value" ControlToValidate="txtNewContractValue" ForeColor="Red" Font-Bold="false" ValidationGroup="RenewContract" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                                            <div class="mb-2">
                                                                <div class="input-group">
                                                                    <asp:Label ID="lblOldContractValue" runat="server" Text="Old Contract Value" CssClass="form-label"></asp:Label>
                                                                    <asp:TextBox ID="txtOldContractValue" runat="server" placeholder="Old Contract Value" type="number" ReadOnly="true" value="0" class="form-control" aria-invalid="false" Style="width: 132%"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="mb-2">
                                                                <asp:Button ID="btnRenewContract" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="RenewContract" OnClick="btnRenewContract_Click" />
                                                                &nbsp;&nbsp;
                                                              <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Close" OnClick="btnclear_Click" />
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane p-20" id="profile2" role="tabpanel">
                                 <div class="p-20">
                                    <div class="row">
                                          <div class="col-md-12 col-sm-12 col-lg-12 col-12 col-xl-12">
                                            <div class="mb-2">
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12 col-12 col-xl-12">

                                                            <h5 class="font-weight-medium mb-0">Task</h5>
                                                            <hr />
                                                            <div class="row">

                                                                <div id="addnewTask" runat="server" class="col-md-2 col-sm-2 col-2 col-lg-2">
                                                                    <asp:Button ID="btn_New_Task" runat="server" Text="New Task" CssClass="btn btn-sm btn-primary col-md-1" OnClick="btn_New_Task_Click" Style="width: 90px;" />&nbsp;
                                                                </div>
                                                                <div class="col-md-6 col-sm-6 col-lg-6  col-6"></div>
                                                                <div id="Div1" runat="server" class="col-md-4 col-sm-4 col-4 col-lg-4">
                                                                    <asp:Button ID="btn_Task_Overview" runat="server" Text="Task Overview" CssClass="btn btn-sm btn-primary col-md-2" Width="170px" BackColor="ForestGreen" ForeColor="White" OnClick="btn_Task_Overview_Click" />&nbsp;
                                                                </div>
                                                            </div>

                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="container-fluid">
                                                    <div class='row'>
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 p-2">
                                                            <h5>View Task Details</h5>
                                                            <hr />
                                                             <div class='row'>
                                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                                <div class="bd-example">
                                                                    <div class="btn-group">
                                                                        <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                                        <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                                                        <div class="dropdown-menu">
                                                                            <asp:LinkButton ID="lnkbtnTaskExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnTaskExcel_Click"></asp:LinkButton>
                                                                            <asp:LinkButton ID="linkTaskPDf" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkTaskPDf_Click"></asp:LinkButton>

                                                                        </div>
                                                                    </div>
                                                                    <asp:Button ID="btn_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btnVisibilityTask_Click" />
                                                                    <asp:Button ID="BtnReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-sm btn-outline-info" OnClick="BtnReloadTask_Click" />
                                                                </div>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <!------PDF code--------->

                                                                <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" Visible="false" />

                                                                <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-dark " Visible="false"></asp:Label>
                                                                <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," Font-Size="12px" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblpincode" runat="server" Text="PIN:" CssClass=" font-bold" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblphone" runat="server" Text="Phone:" CssClass=" font-bold" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblphoneNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblvat" runat="server" Text="VAT NO:" CssClass=" font-bold" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblVatNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" CssClass=" font-bold" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblGSTNo1A" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                                <!------PDF code--------->

                                                            </div>
                                                                 </div>
                                                            <br />
                                                            <br />
                                                            <div id="grd" style="width: 100%">
                                                                <asp:GridView ID="GridTask1" runat="server" ScrollBars="Both" CssClass="table border table-responsive table-bordered table-hover" Style="width: 100%" AutoGenerateColumns="false" CellPadding="4"
                                                                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" OnRowDataBound="GridTask1_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="ID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRowNumTask" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Name" SortExpression="Subject" HeaderStyle-Font-Size="12px">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txttaskName" runat="server" Text='<%# Bind("Subject") %>' Font-Size="12px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbltaskName1" runat="server" Text='<%# Bind("Subject") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="StartDate" SortExpression="Start_Date" HeaderStyle-Font-Size="12px">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblStart_Date" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblStart_Date1" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="DueDate" SortExpression="Due_Date" HeaderStyle-Font-Size="12px">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblDue_Date" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDue_Date1" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="AssignedTo" SortExpression="AssignTo" HeaderStyle-Font-Size="12px" HeaderStyle-Width="180px">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblReletd_To" runat="server" Text='<%# Bind("AssignTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:BulletedList ID="bulletlist1" runat="server" BulletStyle="Circle" CssClass="" Width="170px">
                                                                                </asp:BulletedList>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Status" SortExpression="TaskStatus" HeaderStyle-Font-Size="12px" HeaderStyle-Width="160px">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblTaskStatus" runat="server" Text='<%#Bind("TaskStatus") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="ddlTaskStatus" runat="server" CssClass="form-control " AutoPostBack="true" OnSelectedIndexChanged="ddlTaskStatus_SelectedIndexChanged" Style="width: 160px">
                                                                                    <asp:ListItem Text="In Progress" Value="In Progress"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mark as Not Started" Value="Mark as Not Started"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mark as Testing" Value="Mark as Testing"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mark as Awaiting Feedback" Value="Mark as Awaiting Feedback"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mark as Complete" Value="Mark as Complete"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:Label ID="lblTaskStatus1" runat="server" Text='<%#Bind("TaskStatus") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="false">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Button ID="btnStatus" runat="server" Text='<%# Bind("Status") %>' CssClass="btn btn-info pull-left display-block mright5" TabIndex="126" />
                                                                                <asp:Label ID="lblstatus1" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false" Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Reapeted" SortExpression="Reapet_Every" HeaderStyle-Font-Size="12px" Visible="false">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblReapet_Every" runat="server" Text='<%# Bind("Reapet_Every") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblReapet_Every1" runat="server" Text='<%# Bind("Reapet_Every") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Priority" SortExpression="Priority" HeaderStyle-Font-Size="12px" HeaderStyle-Width="120px">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblPriority" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control " AutoPostBack="true" OnSelectedIndexChanged="ddlPriority_SelectedIndexChanged" Style="width: 140px">
                                                                                    <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                                                                                    <asp:ListItem Text="High" Value="High"></asp:ListItem>
                                                                                    <asp:ListItem Text="Low" Value="Low"></asp:ListItem>
                                                                                    <asp:ListItem Text="Urgent" Value="Urgent"></asp:ListItem>
                                                                                </asp:DropDownList>

                                                                                <asp:Label ID="lblPriority1" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Billable" SortExpression="Billable" Visible="false">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblBillable" runat="server" Text='<%# Bind("Billable") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Button ID="btnBillable" runat="server" Text='<%# Bind("Billable") %>' CssClass="btn btn-info pull-left display-block mright5" TabIndex="126" />
                                                                                <asp:Label ID="lblBillable1" runat="server" Text='<%# Bind("Billable") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="btnEditTask" runat="server" CssClass="btn btn-sm btn-outline-info mb-3" OnClick="btnEditTask_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="btnDeleteTask" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteTask_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:TemplateField>

                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div align="center" style="color: red">
                                                                            <h6>No records found.</h6>
                                                                        </div>
                                                                    </EmptyDataTemplate>
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
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        function toggleForm() {
            var form = document.getElementById("renewForm");
            if (form.style.display === "none") {
                form.style.display = "block";
            } else {
                form.style.display = "none";
            }
        }
    </script>

</asp:Content>
