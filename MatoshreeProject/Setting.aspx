<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="MatoshreeProject.Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
          <%-- BreadCrumbs --%>
        <h5 class="font-weight-medium mb-0">Staff</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                 <li class="breadcrumb-item"><a class="text-muted text-decoration-none" href="#">SETUP</a></li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="#">Setting</li>
            </ol>
        </nav>
        <br />
        <%-- BreadCrumbs --%>
        <div class="row">
            <div class="col-md-3 col-sm-3 col-lg-3  col-xl-3">
                <table id="EmailTable" class="table table-bordered table-hover" style="width: 100%">
                    <tbody style="background-color: white">
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtn" runat="server" OnClick="lnkbtn_Click" class="btn btn-link" Font-Size="12px" ForeColor="Blue">General</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtncompany" runat="server" OnClick="lnkbtncompany_Click" class="btn btn-link" Font-Size="12px">Company</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtnlocalzation" runat="server" OnClick="LinkButton1_Click" CssClass="btn btn-link" Font-Size="12px">Localization</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtnemail" runat="server" OnClick="lnkbtnemail_Click" CssClass="btn btn-link" Font-Size="12px">Email</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtnFinance" runat="server" OnClick="lnkbtnFinance_Click" CssClass="btn btn-link" Font-Size="12px">Finance</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtnsubscrip" runat="server" OnClick="lnkbtnsubscrip_Click" CssClass="btn btn-link" Font-Size="12px">Subscriptions</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lknbtnPayment" runat="server" OnClick="lknbtnPayment_Click" CssClass="btn btn-link" Font-Size="12px">Payment Gateway</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtncustomer" runat="server" OnClick="lnkbtncustomer_Click" CssClass="btn btn-link" Font-Size="12px">Customer</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtntask" runat="server" OnClick="lnkbtntask_Click" CssClass="btn btn-link" Font-Size="12px">Tasks</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtnsupport" runat="server" OnClick="lnkbtnsupport_Click" CssClass="btn btn-link" Font-Size="12px">Support</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtnLeads" runat="server" OnClick="lnkbtnLeads_Click" CssClass="btn btn-link" Font-Size="12px">Leads</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtncalender" runat="server" OnClick="lnkbtncalender_Click" CssClass="btn btn-link" Font-Size="12px">Calender</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkntnsms" runat="server" OnClick="lnkntnsms_Click" CssClass="btn btn-link" Font-Size="12px">SMS</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtnPDF" runat="server" OnClick="lnkbtnPDF_Click" CssClass="btn btn-link" Font-Size="12px">PDF</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtnsign" runat="server" OnClick="lnkbtnsign_Click" CssClass="btn btn-link" Font-Size="12px">E-Sign</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtncronJob" runat="server" OnClick="lnkbtncronJob_Click" CssClass="btn btn-link" Font-Size="12px">Cron_Job</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtntag" runat="server" OnClick="lnkbtntag_Click" CssClass="btn btn-link" Font-Size="12px">Tags</asp:LinkButton>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtnpushar" runat="server" OnClick="lnkbtnpushar_Click" CssClass="btn btn-link" Font-Size="12px">Pushar.Com</asp:LinkButton>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtngoogle" runat="server" OnClick="lnkbtngoogle_Click" CssClass="btn btn-link" Font-Size="12px">Google</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkbtnMisc" runat="server" OnClick="lnkbtnMisc_Click" CssClass="btn btn-link" Font-Size="12px">MISC</asp:LinkButton>
                            </td>
                        </tr>
                       
                        <tr>
                            <td>
                                 <div id="addnew" runat="server">
                                <div class="row">
                                    <div class="mb-2">
                                        <asp:Button ID="Button1" runat="server" Text="Save Settings" CssClass="btn btn-info link  " Width="100%" OnClick="btn_Save_Settings_1_Click" ValidationGroup="company" />
                                    </div>
                                </div>
                                     </div>
                            </td>
                        </tr>
                       
                    </tbody>
                </table>

            </div>

            <!--General-->

            <div class="col-md-9 col-sm-9 col-lg-9 col-xl-9">
                <!--General-->
                <div id="Setting_General" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                          
                              <h5 class="text-purple">General</h5>
                          
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12">

                                    <asp:Image ID="ImgLogo" runat="server" alt="homepage" class="light-logo" Width="450" />
                                    <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <hr />
                            <br />
                            <div class="row">
                              
                                      
                                    <asp:Label ID="lblfileupload" runat="server" Text="Company Logo Dark" CssClass="form-label"></asp:Label>
                                  
                                    <div class="col-md-10 col-lg-10 col-sm-10 col-xs-10">
                                          
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control"  />
                                 
                                         </div>
                                 
                                     <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2">
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-info btn-sm" OnClick="btnUpload_Click" ValidationGroup="up" />
                                </div>
                                                       </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                    <asp:Image ID="ImgdarkLogo" runat="server" alt="homepage" class="light-logo" Width="450" />
                                </div>
                            </div>
                            <hr />
                            <br />
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <asp:Label ID="lblcompName" runat="server" Text="Company Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span><br />
                                    <asp:TextBox ID="txtcompanyname" runat="server" placeholder="Enter Company Name" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqcname" ControlToValidate="txtcompanyname" runat="server" ErrorMessage="Enter Company Name" ForeColor="Red" ValidationGroup="company"  Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <asp:Label ID="lblmaindomain" runat="server" Text="Company Main Domain" CssClass="form-label"></asp:Label><br />
                                    <asp:TextBox ID="txtmaindomain" runat="server" placeholder="Enter Company Main Domain" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <asp:Label ID="lblRTLadmin" runat="server" Text="RTL Admin Area(Right to Left)" CssClass="form-label"></asp:Label><br />
                                    <asp:RadioButtonList ID="RadioButtonListadmin" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Yes" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <asp:Label ID="lblRTLcustomer" runat="server" Text="RTL Customer Area(Right to Left)" CssClass="form-label"></asp:Label><br />
                                    <asp:RadioButtonList ID="RadioButtonListcust" runat="server" RepeatDirection="Horizontal" >
                                        <asp:ListItem Text="Yes&nbsp&nbsp" Value="1" Selected="True"></asp:ListItem>
                                         <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                    <asp:Label ID="lblfiletype" runat="server" Text="Allowed File Types" CssClass="form-label"></asp:Label><br />
                                    <asp:TextBox ID="txtfiletype" runat="server" placeholder=".gif,.png,.jpg,.pdf,.doc,.txt,.docx,.xls,.zip,.rar,.xlsx,.mp4,.psd,.csv" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <!--Company-->
                <div id="Setting_Company" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                             <h5 class="text-purple">Company</h5>
                          
                            <hr />
                            <div class="mb-2">
                                <div class="row">
                                    <p>This information will be displayed on Invoice/Estimate/Payment and other PDF document where company info is required</p>
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                        <asp:Label ID="lblCompany_Name" runat="server" Text="Company Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span><br />
                                        <asp:TextBox ID="txt_Company_Name" runat="server" placeholder="Company Name" Width="100%" Height="81%" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqcompanyname" ControlToValidate="txt_Company_Name" runat="server" ErrorMessage="Enter Company Name" ForeColor="Red" ValidationGroup="company"  Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="lblAddress" runat="server" Text="Address" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span><br />
                                        <asp:TextBox ID="txt_Address" runat="server" placeholder="Address" Width="100%" Height="81%" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqaddress" ControlToValidate="txt_Address" runat="server" ErrorMessage="Enter Address" ForeColor="Red" ValidationGroup="company"  Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-6 col-sm-6 col-lg-6" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="Label5" runat="server" Text="Country" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span><br />
                                        <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-select" name="CountryBilling">
                                            <asp:ListItem Value="0" Text="Select Country"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="India"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldCountry" runat="server" ControlToValidate="DropDownList4" ErrorMessage="Select Country" ForeColor="Red" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="company"  Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-6 col-sm-6 col-lg-6" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="lblstate" runat="server" Text="State" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span><br />
                                        <asp:DropDownList ID="ddlState1" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlState1_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlState1" ErrorMessage="Select State" ForeColor="Red" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="company"  Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-6 col-sm-6 col-lg-6" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="lbldistrict" runat="server" Text="District" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span><br />
                                        <asp:DropDownList ID="ddldistrict" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddldistrict" ErrorMessage="Select District" ForeColor="Red" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="company"  Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-6 col-sm-6 col-lg-6" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="lblCity" runat="server" Text="City" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span><br />
                                        <asp:DropDownList ID="ddlcity" runat="server" CssClass="form-control form-select">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlcity" ErrorMessage="Select City" ForeColor="Red" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="company"  Font-Size="12px"></asp:RequiredFieldValidator>

                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="lblCountry_Code" runat="server" Text="Country Code" CssClass="form-label"></asp:Label><br />
                                        <asp:TextBox ID="txt_Country_Code" runat="server" placeholder="Country Code" Width="100%" Height="81%" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="lblZip_Code" runat="server" Text="Zip Code" CssClass="form-label"></asp:Label><br />
                                        <asp:TextBox ID="txt_Zip_Code" runat="server" placeholder="Zip Code" CssClass="form-control" MaxLength="6"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_Zip_Code" ErrorMessage="Enter Zip Code" ForeColor="Red" Font-Bold="false" Display="Dynamic" ValidationGroup="company"  Font-Size="12px"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="Regulexzipcode" runat="server" ControlToValidate="txt_Zip_Code" ErrorMessage="Enter Correct Zip Code." ForeColor="Red" ValidationExpression="^[1-9]{1}[0-9]{2}\s{0,1}[0-9]{3}$" ValidationGroup="company"></asp:RegularExpressionValidator>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="lblPhone" runat="server" Text="Phone" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span><br />
                                        <asp:TextBox ID="txt_Phone" runat="server" placeholder="Phone Number" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqphone" ControlToValidate="txt_Phone" runat="server" ErrorMessage="Enter Phone Number." ForeColor="Red" ValidationGroup="company"  Font-Size="12px"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="Regulerphone" runat="server" ControlToValidate="txt_Phone" ErrorMessage="Enter Correct Phone Number." ForeColor="Red" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ValidationGroup="company"></asp:RegularExpressionValidator>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="lblvat" runat="server" Text="VAT Number" CssClass="form-label"></asp:Label><br />
                                        <asp:TextBox ID="txtvat" runat="server" placeholder="VAT Number" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtvat" runat="server" ErrorMessage="Enter Vat Number." ForeColor="Red" ValidationGroup="company"  Font-Size="12px"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="Regulervatno" runat="server" ControlToValidate="txtvat" ErrorMessage="Enter Correct Vat Number." ForeColor="Red" ValidationExpression="^([GB])*(([1-9]\d{8})|([1-9]\d{11}))$" ValidationGroup="company"></asp:RegularExpressionValidator>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:LinkButton ID="btnGSTNOlink" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnGSTNOlink_Click"><i class="ti ti-edit"></i></asp:LinkButton>&nbsp;&nbsp;
                                        <asp:Label ID="lblgst" runat="server" Text="GST NO" CssClass="form-label"></asp:Label>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <div id="gstdiv" runat="server" visible="false">
                                            <asp:Label ID="lblGSTNumber" for="GSTNumber" runat="server" Text="GST Number" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:TextBox ID="txtGSTNumber" runat="server" name="gstnumber" CssClass="form-control" placeholder="Enter GST number" MaxLength="15" ValidateRequestMode="Enabled"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_GSTNumber" runat="server" Display="Dynamic" ControlToValidate="txtGSTNumber" ValidationExpression="^ ([a-zA-Z0-9_.-])+@ (([a-zA-Z0-9-])+.)+ ([a-zA-Z0-9] {2,4}‌​)+$" ErrorMessage="Enter Alphanumeric GST Number" ForeColor="Red" ValidationGroup="company"  Font-Size="12px"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="Reg_Exp_Val_GST" ControlToValidate="txtGSTNumber" Display="Dynamic" ValidationExpression="^\d{2}[A-Z]{5}\d{4}[A-Z]{1}[1-9A-Z]{1}Z\d{1}$" runat="server" ErrorMessage="Enter only Alphanumeric GST Number" ForeColor="Red" ValidationGroup="company"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="lblcompInfo" runat="server" Text="Company Information Format(PDF and HTML)" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtcompInfo" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        <asp:LinkButton ID="LinkBtncompname" runat="server" CssClass="btn btn-sm btn-link" Text="{Company_Name}" ForeColor="Blue" OnClick="LinkBtncompname_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkBtnaddress" runat="server" CssClass="btn btn-sm btn-link" Text="{Address}" ForeColor="Blue" OnClick="LinkBtnaddress_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="linkbtncity" runat="server" CssClass="btn btn-sm btn-link" Text="{City}" ForeColor="Blue" OnClick="linkbtncity_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="linkbtnstate" runat="server" CssClass="btn btn-sm btn-link " Text="{State}" ForeColor="Blue" OnClick="linkbtnstate_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="linkbtnzip" runat="server" CssClass="btn btn-sm btn-link" Text="{Zip-Code}" ForeColor="Blue" OnClick="linkbtnzip_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="linkbtncontrycode" runat="server" CssClass="btn btn-sm btn-link" Text="{Country-Code}" ForeColor="Blue" OnClick="linkbtncontrycode_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="linkbtnphn" runat="server" CssClass="btn btn-sm btn-link" Text="{Phone}" ForeColor="Blue" OnClick="linkbtnphn_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="linkbtnvat" runat="server" CssClass="btn btn-sm btn-link" Text="{Vat-Number}" ForeColor="Blue" OnClick="linkbtnvat_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="linkbtnlable" runat="server" CssClass="btn btn-sm btn-link" Text="{Vat-Number-With-Lable}" ForeColor="Blue" OnClick="linkbtnlable_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="linkbtnclear" runat="server" CssClass="btn btn-sm btn-link" Text="{Clear}" ForeColor="Red" OnClick="linkbtnclear_Click"></asp:LinkButton>
                                        <br />
                                        <br />
                                        <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                            <asp:Label ID="lblfild" runat="server" Text="Custom Fields" CssClass="form-label"></asp:Label>
                                            <div class="from-group border">
                                                <asp:Label ID="lblgst1" runat="server" Text="GST:" CssClass="form-label"></asp:Label>
                                                <asp:LinkButton ID="linkbtngst" runat="server" Text="{CF_4}" CssClass="btn btn-sm btn-link" ForeColor="Blue" OnClick="linkbtngst_Click"></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--localization-->
                <div id="Setting_Localization" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                               <h5 class="text-purple">Localization</h5>
                          
                            <hr />
                            <div class="mb-2">
                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative">
                                    <asp:Label ID="lbllocal" runat="server" Text="Date Formate" CssClass="form-label"></asp:Label><br />
                                    <asp:DropDownList ID="ddldateformate" runat="server" Width="100%" Height="82%" CssClass="form-select">
                                        <asp:ListItem>Y-M-D</asp:ListItem>
                                        <asp:ListItem>D-M-Y</asp:ListItem>
                                        <asp:ListItem>D/M/Y</asp:ListItem>
                                        <asp:ListItem>M-D-Y</asp:ListItem>
                                        <asp:ListItem>M.D.Y</asp:ListItem>
                                        <asp:ListItem>M/D/Y</asp:ListItem>
                                        <asp:ListItem>D.M.Y</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <asp:Label ID="lbltimeformate" runat="server" Text="Time Format" CssClass="form-label"></asp:Label><br />
                                <asp:DropDownList ID="ddltimeformate" runat="server" Width="100%" Height="82%" CssClass="form-select">
                                    <asp:ListItem>24 hours</asp:ListItem>
                                    <asp:ListItem>12 hours</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <br />
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <asp:Label ID="lbltimezone" runat="server" Text="Default Timezone" CssClass="form-label"></asp:Label><br />
                                <asp:DropDownList ID="DDLtimezone" runat="server" Width="100%" Height="82%" CssClass="form-select">
                                    <asp:ListItem>(GMT +5:30) India Standard Time</asp:ListItem>
                                    <asp:ListItem>Asia/Jayapuura</asp:ListItem>
                                    <asp:ListItem>Asia/Jerusalem</asp:ListItem>
                                    <asp:ListItem>Asia/Kabul</asp:ListItem>
                                    <asp:ListItem>Asia/Kamchatka</asp:ListItem>
                                    <asp:ListItem>Asia/Karchi</asp:ListItem>
                                    <asp:ListItem>Asia/Kathamadu</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <br />
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <asp:Label ID="lblDlanguage" runat="server" Text="Default Language" CssClass="form-label"></asp:Label><br />
                                <asp:DropDownList ID="ddldefultlang" runat="server" Width="100%" Height="82%" CssClass="form-select">
                                    <asp:ListItem Value="1" Text="English" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Marathi"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Hindi"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <br />
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <asp:Label ID="lbldefaltlang" runat="server" Text="Default Language" CssClass="form-label"></asp:Label><br />
                                <asp:RadioButtonList ID="RadioButtonListdefultlang" runat="server" RepeatDirection="Vertical">
                                    <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Setting_Email-->
                <div id="Setting_Email" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                               <h5 class="text-purple">Email</h5>
                           
                            <hr />
                            <ul class="nav nav-tabs" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" data-bs-toggle="tab" href="#home" role="tab"><span class="hidden-sm-up"></span>
                                        <span class="hidden-sm-down">SMTP Settings</span></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-bs-toggle="tab" href="#profile" role="tab"><span class="hidden-sm-up"></span>
                                        <span class="hidden-sm-down">Email Queue</span></a>
                                </li>
                            </ul>
                            <br />
                            <div class="mb-2">

                                <div class="tab-content tabcontent-border">
                                    <div class="tab-pane active" id="home" role="tabpanel">
                                        <p style="font-size: 14px"><b>SMTP Settings</b>&nbsp<span>Setup main email</span></p>
                                        <hr />
                                        <div class="p-20">
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="lblemail" runat="server" Text="Mail Engine" CssClass="form-label"></asp:Label><br />
                                                    <br />
                                                    <asp:RadioButtonList ID="RdiobtnEngine" runat="server" RepeatDirection="Horizontal" class="round" CssClass="marleft50 col-md-3">
                                                        <asp:ListItem Text="PHPMailer" Value="0" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Codelgniter" Value="1"></asp:ListItem>
                                                    </asp:RadioButtonList>

                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class=" col-md-12 col-sm-12 col-lg-12">
                                                <asp:Label ID="lblprotocal" runat="server" Text="Email Protocal " CssClass="form-label"></asp:Label><br />
                                                <br />
                                                <asp:RadioButtonList ID="RdiobtnProtocal" runat="server" RepeatDirection="Horizontal" class="round" CssClass="marleft50 col-md-3">
                                                    <asp:ListItem Text="SMTP" Selected="True" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Sendmail" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Mail" Value="2"></asp:ListItem>
                                                </asp:RadioButtonList>

                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                <asp:Label ID="lblcharset" runat="server" Text="Email Charset" CssClass="form-label"></asp:Label><br />
                                                <asp:TextBox ID="txtCharset" runat="server" placeholder="Mail Lissom || No-Reply" Width="100%" Height="81%" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <br />

                                            <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                <asp:Label ID="lblbcc" runat="server" Text="Bcc All Emails To" CssClass="form-label"></asp:Label><br />
                                                <asp:TextBox ID="txt_Bcc" runat="server" placeholder="Bcc All Emails To" Width="100%" Height="81%" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <br />
                                            <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                <asp:Label ID="lblsignature" runat="server" Text="Email Signature" CssClass="form-label"></asp:Label><br />
                                                <asp:TextBox ID="txt_Email_Signature" runat="server" TextMode="MultiLine" placeholder="Email Signature" Width="100%" Height="81%" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <br />
                                            <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                <asp:Label ID="lblheder" runat="server" Text="Predefind Header" CssClass="form-label"></asp:Label><br />
                                                <asp:TextBox ID="txtheader" runat="server" TextMode="MultiLine" placeholder="Predefind Header" Width="100%" Height="81%" CssClass="form-control"></asp:TextBox>
                                            </div>
                                     
                                        <br />
                                        <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                            <asp:Label ID="lblfooter" runat="server" Text="Predefind Footer" CssClass="form-label"></asp:Label><br />
                                            <asp:TextBox ID="txtfooter" runat="server" TextMode="MultiLine" placeholder="Predefind Footer" Width="100%" Height="81%" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="row">

                                           <h5 >Send Test E-Mail</h5>
                                            <br />
                                            <p>Send test email to make sure that your SMTP settings is set correctly</p>
                                            <asp:TextBox ID="txtsendtest" runat="server" placeholder="Email Address" Width="90%" Height="81%" CssClass="form-control"></asp:TextBox>
                                            <asp:Button ID="btntest" runat="server" Text="Test" CssClass="btn btn-info link  " Width="10%" Height="81%" />
                                        </div>

                                    </div>
                                    <div class="tab-pane p-20" id="profile" role="tabpanel">
                                        <div class="p-20">
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="lblenableemail" runat="server" Text="Enable Email Queue" CssClass="form-label"></asp:Label><br />

                                                    <asp:RadioButtonList ID="Rdiobtnqueue" runat="server" RepeatDirection="Horizontal" class="round" CssClass="fa-pull-left col-md-1">
                                                        <asp:ListItem Text="Yes" Value="1" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>

                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="lblattachqueue" runat="server" Text="Do Not Add Email With Attchments In The Queue" CssClass="form-label"></asp:Label><br />
                                                    <asp:RadioButtonList ID="Rdiobtnattitchment" runat="server" RepeatDirection="Horizontal" class="round" CssClass="fa-pull-left">
                                                        <asp:ListItem Text="Yes" Value="1" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                        <div id="table" runat="server" class="table table-bordered table-hover table-responsive form-group" style="width: 100%">

                                                            <asp:Label ID="lblemailqueue" runat="server" Text="Email Queue" CssClass="form-label"></asp:Label><br />
                                                            <br />
                                                            <asp:Button ID="Btnexport" runat="server" Text="Export" CssClass="btn btn-sm btn-outline-success" />
                                                            &nbsp;
                                                            <%--<table>
                                                            <thead>
                                                                <tr style="background-color: gray;">
                                                                    <th style="color: white;">Subject</th>
                                                                    <th style="color: white;">To</th>
                                                                    <th style="color: white;">Status</th>
                                                                    
                                                                </tr>
                                                            </thead>
                                                                </table>--%>
                                                            <asp:GridView ID="GridEmail" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4"
                                                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="ID" SortExpression="ID"></asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Subject" SortExpression="Subject"></asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="To" SortExpression="To"></asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status" SortExpression="Status"></asp:TemplateField>

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
                    </div>
                </div>
                <!--Setting_Tickets-->
                <%--  <div id="Setting_Tickets" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                            <div class="d-md-flex align-items-center">
                                <div class="card-body">
                                    <!-- Nav tabs -->
                                    <ul class="nav nav-tabs" role="tablist">
                                        <li class="nav-item">
                                            <a class="nav-link active" data-bs-toggle="tab" href="#General_Settings" role="tab"><span class="hidden-sm-up"></span>
                                                <span class="hidden-xs-down  font-bold">General</span></a>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link" data-bs-toggle="tab" href="#Email_Piping" role="tab"><span class="hidden-sm-up"></span>
                                                <span class="hidden-xs-down  font-bold">Email_Piping</span></a>
                                        </li>

                                    </ul>
                                    <br />
                                    <!-- Tab panes -->
                                    <!-- General_Settings -->
                                    <div class="tab-content tabcontent-border">
                                        <div class="tab-pane active" id="General_Settings" role="tabpanel">
                                            <div class="p-20">
                                                <div id="Div4" runat="server" role="tabpanel">
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <asp:Label ID="Label21" runat="server" Text="Use Services" CssClass="form-label"></asp:Label><br />
                                                            <asp:RadioButtonList ID="RadioButtonList25" runat="server" RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <asp:Label ID="Label15" runat="server" Text="Allow staff to access only ticket that belongs to staff department" CssClass="form-label"></asp:Label><br />
                                                            <asp:RadioButtonList ID="RadioButtonList26" runat="server" RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <asp:Label ID="Label18" runat="server" Text="Recive Notification on new ticket opened" CssClass="form-label"></asp:Label><br />
                                                            <asp:RadioButtonList ID="RadioButtonList27" runat="server" RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <asp:Label ID="Label20" runat="server" Text="Allow access to ticket for non staff members" CssClass="form-label"></asp:Label><br />
                                                            <asp:RadioButtonList ID="RadioButtonList28" runat="server" RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <asp:Label ID="Label22" runat="server" Text="Allow customer to change ticket status from customer area" CssClass="form-label"></asp:Label><br />
                                                            <asp:RadioButtonList ID="RadioButtonList29" runat="server" RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <asp:Label ID="Label27" runat="server" Text="In customer profile only show tickets related to the logged in contact (Primary contact not applied)" CssClass="form-label"></asp:Label><br />
                                                            <asp:RadioButtonList ID="RadioButtonList30" runat="server" RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <asp:Label ID="Label28" runat="server" Text="Maximum ticket attachment" CssClass="form-label"></asp:Label><br />
                                                            <asp:TextBox ID="TextBox1" runat="server" placeholder="4" Width="100%" Height="81%"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <asp:Label ID="Label30" runat="server" Text="Allow attachment file extensions" CssClass="form-label"></asp:Label><br />
                                                            <asp:TextBox ID="TextBox2" runat="server" placeholder=".jpg, .png, .doc, .docx" Width="100%" Height="81%"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <br />
                                                </div>
                                            </div>
                                        </div>
                                        <!--Email_Piping-->
                                        <div class="tab-pane p-20" id="Email_Piping" role="tabpanel">
                                            <div class="p-20">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label31" runat="server" Text="Allow attachment file extensions" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="TextBox3" runat="server" placeholder=".jpg, .png, .doc, .docx" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!--Setting_Tickets-->
                        </div>
                    </div>
                </div>--%>
                <!--Setting_Finance-->
                <div id="Setting_Finance" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                            <div class="d-md-flex align-items-center">
                                <ul class="nav nav-tabs" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" data-bs-toggle="tab" href="#General" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down">General</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Invoice" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down">Invoice</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Estimate" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down">Estimate</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Praposal" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down">Praposal</span></a>
                                    </li>
                                </ul>
                            </div>
                            <br />
                            <br />
                            <div class="tab-content tabcontent-border">
                                <!-- General-->
                                <div class="tab-pane active" id="General" role="tabpanel">
                                    <div class="p-20">
                                        <div id="tab" runat="server" role="tabpanel">
                                            <div class="mb-2">
                                                 <h5 >General</h5>
                                                
                                                <h7 class="text-purple">General Setting's</h7>
                                                <hr />
                                                <div class="row">
                                                    <div class="col-md-6 col-sm-6 col-lg-6" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label1" runat="server" Text="Decimal Seperator" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Decimal_Seperator" runat="server" placeholder="Enter Decimal Seperator" CssClass="form-control" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-6 col-sm-6 col-lg-6" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label2" runat="server" Text="Thousand Seperator" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Thousand_Seperator" runat="server"  placeholder="Enter Thousand Seperator" CssClass="form-control" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label3" runat="server" Text="Number padding zero's for prefix format's" CssClass="form-label"></asp:Label><br />
                                                        <h7>eq. if this value is 3 the number will be formated: 005 or 025</h7>
                                                        <asp:TextBox ID="txt_Nuber_padding" runat="server" placeholder="Enter Number padding zero's for prefix format's" CssClass="form-control" Width="100%" Height="57%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label4" runat="server" Text="Show TAX per item" CssClass="form-label"></asp:Label><br />
                                                    
                                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server"   RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                    
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label7" runat="server" Text="Remove the tax name from item table now" CssClass="form-label"></asp:Label><br />
                                                    
                                                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal"  >
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                     
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label10" runat="server" Text="Remove decimal on Numbers/Money with zero decimal(2.00 will become 2, 2.25 will become 2.25)" CssClass="form-label"></asp:Label><br />
                                                   
                                                            <asp:RadioButtonList ID="RadioButtonList3" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                      
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label13" runat="server" Text="Currancy Placement" CssClass="form-label"></asp:Label><br />
                                                     
                                                            <asp:RadioButtonList ID="RadioButtonList4" runat="server"  RepeatDirection="Horizontal">
                                                                <asp:ListItem>Before Amount($25.00)</asp:ListItem>
                                                                <asp:ListItem>After Amount($25.00)</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                      
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label16" runat="server" Text="Currancy Placement" CssClass="form-label"></asp:Label><br />
                                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select" Width="100%"  Height="81%">
                                                         <asp:ListItem>Nothing Selected</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <h5>Amount to Words</h5>
                                                    <br />
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label19" runat="server" Text="Enable" CssClass="form-label"></asp:Label><br />
                                                     
                                                            <asp:RadioButtonList ID="RadioButtonList5" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                   
                                                    </div>
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label17" runat="server" Text="Number words into lowercase" CssClass="form-label"></asp:Label><br />
                                                      
                                                            <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                       
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Invoice-->
                                <div class="tab-pane p-20" id="Invoice" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div1" runat="server" role="tabpanel">
                                            <div class="mb-2">
                                                <div class="row">
                                                     <h5 class="text-purple">Invoice</h5>
                                                  
                                                    <hr />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label23" runat="server" Text="Invoice Number Prefix" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Invoice_Number_prefix" runat="server" CssClass="form-control" placeholder="2022/" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                        <asp:Label ID="Label24" runat="server" Text="Next Invoice Number" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Next_Invoice_Number_" runat="server" CssClass="form-control" placeholder="28" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                        <asp:Label ID="Label45" runat="server" Text="Invoice due after(days)" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Invoice_due_after" runat="server" CssClass="form-control" placeholder="7" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label26" runat="server" Text="Require client to be logged in to view invoice" CssClass="form-label"></asp:Label><br />
                                                       
                                                            <asp:RadioButtonList ID="RadioButtonList7" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                     
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label29" runat="server" Text="Deleted invoice allowed only on last invoice" CssClass="form-label"></asp:Label><br />
                                                      
                                                            <asp:RadioButtonList ID="RadioButtonList8" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                     
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label32" runat="server" Text="Decrement invoice number on delet" CssClass="form-label"></asp:Label><br />
                                                     
                                                            <asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                 </div>
                                              
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label250" runat="server" Text="Exclude invoice with draft status from customers area" CssClass="form-label"></asp:Label><br />
                                                      
                                                            <asp:RadioButtonList ID="RadioButtonList10" runat="server" RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                       
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label48" runat="server" Text="Show Sale Agent on invoice" CssClass="form-label"></asp:Label><br />
                                                   
                                                            <asp:RadioButtonList ID="RadioButtonList11" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                             
                                                             <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                    
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <h5>Invoice Number Format</h5>
                                                    <br />
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label39" runat="server" Text="Number Based(000001)" CssClass="form-label"></asp:Label><br />
                                                      
                                                            <asp:RadioButtonList ID="RadioButtonList12" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                     
                                                    </div>
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label42" runat="server" Text="Year Based(YYYY/000001)" CssClass="form-label"></asp:Label><br />
                                                      
                                                            <asp:RadioButtonList ID="RadioButtonList13" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                      
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label35" runat="server" Text="Predefined Terms & Conditions" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_predefined_terms" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="2022/" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label36" runat="server" Text="Predefined Client Note" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_predefined_client_Note" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="2022/" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Estimate-->
                                <div class="tab-pane p-20" id="Estimate" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div2" runat="server" role="tabpanel">
                                            <div class="mb-2">
                                                <div class="row">
                                                   <h5 class="text-purple">Estimate</h5>
                                                    <hr />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label25" runat="server" Text="Estimate Number Prefix" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Estimate_Number" runat="server" CssClass="form-control" placeholder="EST-" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                        <asp:Label ID="Label37" runat="server" Text="Next Estimate Number" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Estimate_Next_Number" runat="server" CssClass="form-control" placeholder="51" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label54" runat="server" Text="Deleted Estimate allowed only on last invoice" CssClass="form-label"></asp:Label><br />
                                                       
                                                            <asp:RadioButtonList ID="RadioButtonList14" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                     
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label57" runat="server" Text="Decrement Estimate number on delet" CssClass="form-label"></asp:Label><br />
                                                      
                                                            <asp:RadioButtonList ID="RadioButtonList15" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                       
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label51" runat="server" Text="Require client to be logged in to view invoice" CssClass="form-label"></asp:Label><br />
                                                       
                                                            <asp:RadioButtonList ID="RadioButtonList16" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                       
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label63" runat="server" Text="Show Sale Agent on Estimate" CssClass="form-label"></asp:Label><br />
                                                      
                                                            <asp:RadioButtonList ID="RadioButtonList17" runat="server" RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                     
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label60" runat="server" Text="Auto convert the estimate to invoice after client accept" CssClass="form-label"></asp:Label><br />
                                                    
                                                            <asp:RadioButtonList ID="RadioButtonList18" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                      
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label38" runat="server" Text="Exclude invoice with draft status from customers area" CssClass="form-label"></asp:Label><br />
                                                       
                                                            <asp:RadioButtonList ID="RadioButtonList19" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                       
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <h5>Estimate Number Format</h5>
                                                    <br />
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label66" runat="server" Text="Number Based(000001)" CssClass="form-label"></asp:Label><br />
                                                      
                                                            <asp:RadioButtonList ID="RadioButtonList20" runat="server" CssClass="" RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                       
                                                    </div>
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label69" runat="server" Text="Year Based(YYYY/000001)" CssClass="form-label"></asp:Label><br />
                                                      
                                                            <asp:RadioButtonList ID="RadioButtonList21" runat="server" CssClass="" RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                      
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label76" runat="server" Text="Pipeline limit per status" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_pipeline_limit" runat="server" CssClass="form-control" placeholder="2022/" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label80" runat="server" Text="Default pipeline sort" CssClass="form-label"></asp:Label><br />
                                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select" Width="100%" Height="82%">
                                                            <asp:ListItem>Nothing Selected</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class=" col-md-6 col-sm-6 col-lg-6" style="position: relative; margin-top: 3%;">
                                                        <asp:RadioButtonList ID="RadioButtonList23" runat="server"  RepeatDirection="Horizontal">
                                                            <asp:ListItem>Ascending</asp:ListItem>
                                                            <asp:ListItem>Descending</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label72" runat="server" Text="Predefined Terms & Conditions" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="TextBox4" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="2022/" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label73" runat="server" Text="Predefined Client Note" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="TextBox5" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="2022/" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--Praposal-->
                                <div class="tab-pane p-20" id="Praposal" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div3" runat="server" role="tabpanel">
                                            <div class="mb-2">
                                                <div class="row">
                                                   <h5 class="text-purple">Praposal</h5>
                                                    <hr />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label77" runat="server" Text="Praposal Number Prefix" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Praposal_Number" runat="server" CssClass="form-control" placeholder="PRO-" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                        <asp:Label ID="Label81" runat="server" Text="Praposal Due After (days)" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_New_Praposal" runat="server" CssClass="form-control" placeholder="7" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                        <asp:Label ID="Label82" runat="server" Text="Pipeline limit per status" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_pipeline_status" runat="server" CssClass="form-control" placeholder="50" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label107" runat="server" Text="Default pipeline sort" CssClass="form-label"></asp:Label><br />
                                                        <asp:DropDownList ID="DropDownList3" cssclass="form-select" runat="server" Width="100%" Height="82%">
                                                            <asp:ListItem>sort</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class=" col-md-6 col-sm-6 col-lg-6" style="position: relative; margin-t
    
    op: 3%;">
                                                        <asp:RadioButtonList ID="RadioButtonList22" runat="server"  RepeatDirection="Horizontal">
                                                            <asp:ListItem>Ascending</asp:ListItem>
                                                            <asp:ListItem>Descending</asp:ListItem>
                                                        </asp:RadioButtonList>
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
                <!--Subscription-->
                <div id="Setting_subscription" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                        </div>
                    </div>
                </div>
                <!--Setting_Payment_Gateway-->
                <div id="Setting_Payment_Gateway" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                            <div class="d-md-flex align-items-center">
                                <ul class="nav nav-tabs" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" data-bs-toggle="tab" href="#General_Payment_Settings" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">General</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Authorize_net_AIM" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">Authorize.net AIM</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Authorize_net_SIM" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">Authorize.net SIM</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Mollie" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">Mollie</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Paypal" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">Paypal</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Stripe" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">Stripe</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Checkout" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">2Checkout</span></a>
                                    </li>
                                </ul>
                            </div>
                            <br />
                            <br />
                            <div class="tab-content tabcontent-border">
                                <!-- General_Payment_Settings-->
                                <div class="tab-pane active" id="General_Payment_Settings" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div5" runat="server" role="tabpanel">
                                            <div class="mb-2">
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label41" runat="server" Text="Show TAX per item" CssClass="form-label"></asp:Label><br />
                                                      
                                                            <asp:RadioButtonList ID="RadioButtonList31" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                                <asp:ListItem cssclass="list-item-space">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                       
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label43" runat="server" Text="Remove the tax name from item table now" CssClass="form-label"></asp:Label><br />
                                                       
                                                            <asp:RadioButtonList ID="RadioButtonList32" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                      
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Authorize_net_AIM-->
                                <div class="tab-pane p-20" id="Authorize_net_AIM" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div6" runat="server" role="tabpanel">
                                            <div class="mb-2">

                                               <h5 class="text-purple">Authorize.net AIM</h5>
                                                <hr />
                                                <p>SSL is required if you're using the Authorize. et AIM payment API. Authorize.net only supports 1 currency per account, Make sure you add only 1 currency associated with your Authorize account in the currencies field.</p>
                                                <p>Currently supported currencies: USD, AUD, GBP, CAD, EUR, NZD</p>
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label33" runat="server" Text="Active" CssClass="form-label"></asp:Label><br />
                                                      
                                                            <asp:RadioButtonList ID="RadioButtonList33" runat="server" CssClass="link  font-bold "  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                      
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label52" runat="server" Text="Label" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_label" runat="server" CssClass="form-control" placeholder="Authorize.net" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label53" runat="server" Text="API Login ID" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_API_Login_Id" runat="server" CssClass="form-control" placeholder="API Login ID" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label55" runat="server" Text="Currency" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Currency" runat="server" CssClass="form-control" placeholder="USD" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label56" runat="server" Text="Enable Test Mode" CssClass="form-label"></asp:Label><br />
                                                     
                                                            <asp:RadioButtonList ID="RadioButtonList37" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                      
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label34" runat="server" Text="Developer Mode" CssClass="form-label"></asp:Label><br />
                                                       
                                                            <asp:RadioButtonList ID="RadioButtonList34" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                       
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Authorize_net_SIM-->
                                <div class="tab-pane p-20" id="Authorize_net_SIM" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div7" runat="server" role="tabpanel">
                                            <div class="mb-2">

                                               <h5 class="text-purple">Authorize.net SIM</h5>
                                                <hr />
                                                <p>Currently supported currencies: USD, AUD, GBP, CAD, EUR, NZD</p>
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label40" runat="server" Text="Active" CssClass="form-label"></asp:Label><br />
                                                      
                                                            <asp:RadioButtonList ID="RadioButtonList35" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                       
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label44" runat="server" Text="Label" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_label_SIM" runat="server" CssClass="form-control" placeholder="Authorize.net" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label46" runat="server" Text="API Login ID" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_API" runat="server" CssClass="form-control"  placeholder="API Login ID" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label47" runat="server" Text="Currency" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Currancy" runat="server" CssClass="form-control" placeholder="USD" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label49" runat="server" Text="Enable Test Mode" CssClass="form-label"></asp:Label><br />
                                                       
                                                            <asp:RadioButtonList ID="RadioButtonList36" runat="server" RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                       
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label50" runat="server" Text="Developer Mode" CssClass="form-label"></asp:Label><br />
                                                        
                                                            <asp:RadioButtonList ID="RadioButtonList38" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--Mollie-->
                                <div class="tab-pane p-20" id="Mollie" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div8" runat="server" role="tabpanel">
                                            <div class="mb-2">

                                               <h5 class="text-purple">Mollie</h5>
                                                <hr />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label58" runat="server" Text="Active" CssClass="form-label"></asp:Label><br />
                                                        
                                                            <asp:RadioButtonList ID="RadioButtonList39" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label59" runat="server" Text="Label" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Label_Mollie" runat="server" CssClass="form-control" placeholder="Mollie" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label61" runat="server" Text="API Key" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="TextBox10" runat="server" placeholder="API Key" CssClass="form-control" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label62" runat="server" Text="Currency" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control" placeholder="USD" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label64" runat="server" Text="Enable Test Mode" CssClass="form-label"></asp:Label><br />
                                                      
                                                            <asp:RadioButtonList ID="RadioButtonList40" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                       
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--Paypal-->
                                <div class="tab-pane p-20" id="Paypal" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div9" runat="server" role="tabpanel">
                                            <div class="mb-2">

                                               <h5 class="text-purple">Paypal</h5>
                                                <hr />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label65" runat="server" Text="Active" CssClass="form-label"></asp:Label><br />
                                                      
                                                            <asp:RadioButtonList ID="RadioButtonList41" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                       
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label71" runat="server" Text="Label" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Paypal_Label" runat="server" CssClass="form-control" placeholder="Mollie" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label74" runat="server" Text="Paypal API Username" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Paypal_API_Username" CssClass="form-control" runat="server" placeholder="Paypal API Username" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label75" runat="server" Text="Paypal API Password" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Paypal_API_Password" CssClass="form-control" runat="server" placeholder="Paypal API Password" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label79" runat="server" Text="API Signature" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_API_Signature" runat="server" CssClass="form-control" placeholder="USD" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label83" runat="server" Text="Currency" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_API_Signature_Currency" CssClass="form-control" runat="server" placeholder="USD" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label78" runat="server" Text="Enable Test Mode" CssClass="form-label"></asp:Label><br />
                                                       
                                                            <asp:RadioButtonList ID="RadioButtonList42" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                       
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--Stripe-->
                                <div class="tab-pane p-20" id="Stripe" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div10" runat="server" role="tabpanel">
                                            <div class="mb-2">

                                               <h5 class="text-purple">Stripe</h5>
                                                <hr />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label84" runat="server" Text="Active" CssClass="form-label"></asp:Label><br />
                                                     
                                                            <asp:RadioButtonList ID="RadioButtonList43" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                      
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label85" runat="server" Text="Label" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Label_Stripe" runat="server" CssClass="form-control" placeholder="Mollie" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label86" runat="server" Text="String API Secret Key" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_String_API_Secret_Key" CssClass="form-control" runat="server" placeholder="String API Secret Key" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label87" runat="server" Text="String Publishable Key" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_String_Publishable_Key" CssClass="form-control" runat="server" placeholder="String Publishable Key" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label89" runat="server" Text="Currency(Coma seoarated)" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Currency_Stripe" CssClass="form-control"  runat="server" placeholder="USD, CAD, INR" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label90" runat="server" Text="Enable Test Mode" CssClass="form-label"></asp:Label><br />
                                                      
                                                            <asp:RadioButtonList ID="RadioButtonList44" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                       
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--2Checkout-->
                                <div class="tab-pane p-20" id="Checkout" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div11" runat="server" role="tabpanel">
                                            <div class="mb-2">

                                               <h5 class="text-purple">Paypal</h5>
                                                <hr />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label88" runat="server" Text="Active" CssClass="form-label"></asp:Label><br />
                                                        <div class="form-control">
                                                            <asp:RadioButtonList ID="RadioButtonList45" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label91" runat="server" Text="Label" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_2Checkout" runat="server" CssClass="form-control" placeholder="2Checkout" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label92" runat="server" Text="Account Number (Seller ID)" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Account_Number" runat="server" CssClass="form-control" placeholder="" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label93" runat="server" Text="Private Key" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Private_Key" runat="server" CssClass="form-control" placeholder="" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label94" runat="server" Text="Publishable Key" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Publishable_Key" runat="server" CssClass="form-control" placeholder="USD" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label95" runat="server" Text="Currency (coma separated)" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Currency_2Checkout" runat="server" CssClass="form-control" placeholder="USD" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label96" runat="server" Text="Enable Test Mode" CssClass="form-label"></asp:Label><br />
                                                        <div class="form-control">
                                                            <asp:RadioButtonList ID="RadioButtonList46" runat="server"  RepeatDirection="Horizontal">
                                                               <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                               <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
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
                <!--Setting_Customer-->
                <div id="Setting_Customer" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                            <div class="mb-2">
                                <div class="row">
                                   <h5 class="text-purple">Customer</h5>
                                    <hr />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                        <asp:Label ID="Label101" runat="server" Text="Default customers theme" CssClass="form-label"></asp:Label><br />
                                        <asp:DropDownList ID="DropDownList7" runat="server" cssclass="form-select" Width="100%" Height="80%">
                                            <asp:ListItem>Prefix</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="Label102" runat="server" Text="Default Country" CssClass="form-label"></asp:Label><br />
                                        <asp:DropDownList ID="DropDownList8" runat="server" cssclass="form-select" Width="100%" Height="80%">
                                            <asp:ListItem>Country</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="Label109" runat="server" Text="Allow customer to register" CssClass="form-label"></asp:Label><br />
                                        <asp:RadioButtonList ID="RadioButtonList48" runat="server" RepeatDirection="Horizontal">
                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="Label110" runat="server" Text="Use Knowledge Base" CssClass="form-label"></asp:Label><br />
                                        <asp:RadioButtonList ID="RadioButtonList49" runat="server" RepeatDirection="Horizontal">
                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>

                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="Label111" runat="server" Text="Allow knowledge base to be viewed without registration" CssClass="form-label"></asp:Label><br />
                                        <asp:RadioButtonList ID="RadioButtonList50" runat="server" RepeatDirection="Horizontal">
                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="Label112" runat="server" Text="Default contact permissions" CssClass="form-label"></asp:Label><br />
                                        <asp:RadioButton ID="RadioButton1" runat="server" />&nbsp;<asp:Label ID="Label141" runat="server" Text="Invoice" CssClass="form-label"></asp:Label><br />
                                        <asp:RadioButton ID="RadioButton2" runat="server" />&nbsp;<asp:Label ID="Label142" runat="server" Text="Estimate" CssClass="form-label"></asp:Label><br />
                                        <asp:RadioButton ID="RadioButton3" runat="server" />&nbsp;<asp:Label ID="Label143" runat="server" Text="Contract" CssClass="form-label"></asp:Label><br />
                                        <asp:RadioButton ID="RadioButton4" runat="server" />&nbsp;<asp:Label ID="Label144" runat="server" Text="Proposals" CssClass="form-label"></asp:Label><br />
                                        <asp:RadioButton ID="RadioButton5" runat="server" />&nbsp;<asp:Label ID="Label145" runat="server" Text="Support" CssClass="form-label"></asp:Label><br />
                                        <asp:RadioButton ID="RadioButton6" runat="server" />&nbsp;<asp:Label ID="Label152" runat="server" Text="Projects" CssClass="form-label"></asp:Label><br />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Setting_Task-->
                <div id="Setting_Task" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                            <div class="mb-2">
                                <div class="row">
                                   <h5 class="text-purple">Task</h5>
                                    <hr />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                        <asp:Label ID="Label113" runat="server" Text="Limit task kan ban rows per status" CssClass="form-label"></asp:Label><br />
                                        <asp:TextBox ID="TextBox6" runat="server" placeholder="50" CssClass="form-control" Width="100%" Height="81%"></asp:TextBox>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="Label115" runat="server" Text="Allow all staff to see all tasks related to project (includes non-staff)" CssClass="form-label"></asp:Label><br />
                                        <asp:RadioButtonList ID="RadioButtonList52" runat="server"  RepeatDirection="Horizontal">
                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="Label116" runat="server" Text="Allow customers/staff to add/edit task comments only in the first hour(administration not applied)" CssClass="form-label"></asp:Label><br />
                                        <asp:RadioButtonList ID="RadioButtonList53" runat="server" RepeatDirection="Horizontal">
                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="Label117" runat="server" Text="Stop all other started timers when starting new timer" CssClass="form-label"></asp:Label><br />
                                        <asp:RadioButtonList ID="RadioButtonList54" runat="server" RepeatDirection="Horizontal">
                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="Label114" runat="server" Text="Default Priority" CssClass="form-label"></asp:Label><br />
                                        <asp:DropDownList ID="DropDownList10" runat="server" cssclass="form-select" Width="100%" Height="80%">
                                            <asp:ListItem>Medium</asp:ListItem>
                                            <asp:ListItem>Low</asp:ListItem>
                                            <asp:ListItem>High</asp:ListItem>
                                            <asp:ListItem>Urgent</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Setting_support-->
                <div id="Setting_Support" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                        </div>
                    </div>
                </div>
                <!--Setting_Leads-->
                <div id="Setting_Leads" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                            <div class="mb-2">
                                <div class="row">
                                   <h5 class="text-purple">Leads</h5>
                                    <hr />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                        <asp:Label ID="Label118" runat="server" Text="Limit task kan ban rows per status" CssClass="form-label"></asp:Label><br />
                                        <asp:TextBox ID="TextBox7" runat="server" cssclass="form-control" placeholder="50" Width="100%" Height="81%"></asp:TextBox>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="Label123" runat="server" Text="Default status" CssClass="form-label"></asp:Label><br />
                                        <asp:DropDownList ID="DropDownList12" runat="server" cssclass="form-select" Width="100%" Height="80%">
                                            <asp:ListItem>Nothing Selected</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="Label119" runat="server" Text="Default Source " CssClass="form-label"></asp:Label><br />
                                        <asp:DropDownList ID="DropDownList11" runat="server" cssclass="form-select" Width="100%" Height="80%">
                                            <asp:ListItem>Nothing Selected</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="Label120" runat="server" Text="Auto assign as admin to customer after convert" CssClass="form-label"></asp:Label><br />
                                        <asp:RadioButtonList ID="RadioButtonList56" runat="server" RepeatDirection="Horizontal">
                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="Label122" runat="server" Text="Default Leads kan ban sort" CssClass="form-label"></asp:Label><br />
                                        <asp:DropDownList ID="DropDownList9" runat="server" cssclass="form-select" Width="100%" Height="80%">
                                            <asp:ListItem>Date Created</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                        <asp:Label ID="Label121" runat="server" Text="Dont allow editing the lead after converting to customer (admins not applied)" CssClass="form-label"></asp:Label><br />
                                        <asp:RadioButtonList ID="RadioButtonList57" runat="server" RepeatDirection="Horizontal">
                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Setting_Calender-->
                <div id="Setting_Calender" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="text-purple">Calender</h5>
                            <hr />
                            <div class="d-md-flex align-items-center">
                                <ul class="nav nav-tabs" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" data-bs-toggle="tab" href="#General_Cal" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">General</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Styling" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">Styling</span></a>
                                    </li>
                                </ul>
                            </div>
                            <br />
                            <br />
                            <div class="tab-content tabcontent-border">
                                <!-- General-->
                                <div class="tab-pane active" id="General_Cal" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div12" runat="server" role="tabpanel">

                                            <div class="mb-2">
                                                <h4 style="font: bold">General</h4>
                                                <h7>Setup calender by Departments</h7>
                                                <hr />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label124" runat="server" Text="Google Calendar ID" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="TextBox8" cssclass="form-control" runat="server" placeholder="Google Calendar ID"  Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 4%">
                                                        <asp:Label ID="Label146" runat="server" Text="First Day" CssClass="form-label"></asp:Label><br />
                                                        <asp:DropDownList ID="DropDownList14" runat="server" cssclass="form-select" Width="100%" Height="81%">
                                                            <asp:ListItem>Monday</asp:ListItem>
                                                            <asp:ListItem>Tuesday</asp:ListItem>
                                                            <asp:ListItem>Wednesday</asp:ListItem>
                                                            <asp:ListItem>Thursday</asp:ListItem>
                                                            <asp:ListItem>Friday</asp:ListItem>
                                                            <asp:ListItem>Saturday</asp:ListItem>
                                                            <asp:ListItem>Sunday</asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <h4 style="font: bold; color: aqua">Show on Calender</h4>
                                                <hr />
                                                <div class="row">
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label126" runat="server" Text="Invoice" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList70" runat="server"  RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                    <br />
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label125" runat="server" Text="Last Reminders" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList71" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label127" runat="server" Text="Invoice" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList55" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                    <br />
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label128" runat="server" Text="Last Reminders" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList58" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label129" runat="server" Text="Estimate" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList59" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                    <br />
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label130" runat="server" Text="Customer Reminders" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList60" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label131" runat="server" Text="Proposal" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList61" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                    <br />
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label132" runat="server" Text="Estimate Reminders" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList62" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label133" runat="server" Text="Contract" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList72" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                    <br />
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label147" runat="server" Text="Invoice Reminders" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList73" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label148" runat="server" Text="Task" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList74" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                    <br />
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label149" runat="server" Text="Proposal Reminders" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList75" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label150" runat="server" Text="Project" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList76" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                    <br />
                                                    <div class=" col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="Label151" runat="server" Text="Expense Reminders" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList77" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Styling-->
                                <div class="tab-pane p-20" id="Styling" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div13" runat="server" role="tabpanel">

                                            <div class="mb-2">
                                                <div class="row">
                                                   <h5 >Invoice</h5>
                                                    <hr />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label134" runat="server" Text="Invoice Color" CssClass="form-label"></asp:Label><br />
                                                        <div class="input-group mb-3">
                                                            <input type="text" class="form-control" placeholder="#ff6f00" aria-label="Invoice Color" aria-describedby="basic-addon2" />
                                                            <div class="input-group-append">
                                                                <!--<asp:Button ID="btn_Invoice_Color" runat="server" CssClass="btn btn-orange" />-->
                                                                <input type="color" id="btn_Invoice_Color" value="#00FF00 " style="height: 100%" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label135" runat="server" Text="Estimate Color" CssClass="form-label"></asp:Label><br />
                                                        <div class="input-group mb-3">
                                                            <input type="text" class="form-control" placeholder="#ff6f00" aria-label="Estimate Color" aria-describedby="basic-addon2" />
                                                            <div class="input-group-append">
                                                                <!--<asp:Button ID="btn_Estimate_Color" runat="server" CssClass="btn btn-orange" />-->
                                                                <input type="color" id="btn_Estimate_Color" value="#00FF00 " style="height: 100%" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label136" runat="server" Text="Proposal Color" CssClass="form-label"></asp:Label><br />
                                                        <div class="input-group mb-3">
                                                            <input type="text" class="form-control" placeholder="#84c529" aria-label="Proposal Color" aria-describedby="basic-addon2" />
                                                            <div class="input-group-append">
                                                                <!--<asp:Button ID="btn_Proposal_Color" runat="server" CssClass="btn btn-success btn-sm" />-->
                                                                <input type="color" id="btn_Proposal_Color" value="#84c529 " style="height: 100%" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label140" runat="server" Text="Task Color" CssClass="form-label"></asp:Label><br />
                                                        <div class="input-group mb-3">
                                                            <input type="text" class="form-control" placeholder="#fca2d42" aria-label="Task Color" aria-describedby="basic-addon2" />
                                                            <div class="input-group-append">
                                                                <!--<asp:Button ID="txt_Task_Color" runat="server" CssClass="btn btn-danger" />-->
                                                                <input type="color" id="txt_Task_Color" value="#fca2d42 " style="height: 100%" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label137" runat="server" Text="Reminder Color" CssClass="form-label"></asp:Label><br />
                                                        <div class="input-group mb-3">
                                                            <input type="text" class="form-control" placeholder="#03a9f4" aria-label="Reminder Color" aria-describedby="basic-addon2" />
                                                            <div class="input-group-append">
                                                                <!-- <asp:Button ID="txt_Reminder_Color" runat="server" CssClass="btn btn-cyan" />-->
                                                                <input type="color" id="txt_Reminder_Color" value="#03a9f4 " style="height: 100%" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label138" runat="server" Text="Contract Color" CssClass="form-label"></asp:Label><br />
                                                        <div class="input-group mb-3">
                                                            <input type="text" class="form-control" placeholder="#b72974" aria-label="Contract Color" aria-describedby="basic-addon2" />
                                                            <div class="input-group-append">
                                                                <!--<asp:Button ID="txt_Contract_Color" runat="server" CssClass="btn btn-purple" />-->
                                                                <input type="color" id="txt_Contract_Color" value="#b72974 " style="height: 100%" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label139" runat="server" Text="Project Color" CssClass="form-label"></asp:Label><br />
                                                        <div class="input-group mb-3">
                                                            <input type="text" class="form-control" placeholder="#eda334" aria-label="Project Color" aria-describedby="basic-addon2" />
                                                            <div class="input-group-append">
                                                                <!--<asp:Button ID="txt_Project_Color" runat="server" CssClass="btn btn-warning" />-->
                                                                <input type="color" value="#eda334 " id="txt_Project_Color" style="height: 100%" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                </div>

                                                <!--Color-->
                                                <div class="modal fade" id="exampleModal2" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header ">
                                                                <button type="button" class="btn-close btn-sm" data-bs-dismiss="modal" aria-label="Close"></button>
                                                            </div>
                                                            <div class="modal-body">
                                                                <div class="row form-group">
                                                                    <label for="exampleColorInput" class="form-label"></label>
                                                                    <input type="color" class="form-control form-control-color" id="exampleColorInput9" value="#563d7c" />
                                                                </div>
                                                            </div>
                                                            <div class="modal-footer">
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
                <!--SMS-->
                <div id="Setting_SMS" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                        </div>
                    </div>
                </div>
                <!--Setting_PDF-->
                <div id="Setting_PDF" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                            <div class="d-md-flex align-items-center">
                                <ul class="nav nav-tabs" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" data-bs-toggle="tab" href="#General_PDF" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">General</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Document_Format" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">Document Format</span></a>
                                    </li>
                                </ul>
                            </div>
                            <br />
                            <br />
                            <div class="tab-content tabcontent-border">
                                <!-- General-->
                                <div class="tab-pane active" id="General_PDF" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div14" runat="server" role="tabpanel">
                                            <h5 >General</h5>
                                            <hr />
                                            <div class="mb-2">
                                                <h4 style="font: bold">General</h4>
                                                <h7 class="text-purple">Setup calender by Departments</h7>
                                                <hr />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label157" runat="server" Text="PDF Font" CssClass="form-label"></asp:Label><br />
                                                        <asp:DropDownList ID="DropDownList13" runat="server" cssclass="form-select" Width="100%" Height="81%">
                                                            <asp:ListItem>freesans</asp:ListItem>
                                                            <asp:ListItem>Times-Roman</asp:ListItem>
                                                            <asp:ListItem>Times-Bold</asp:ListItem>
                                                            <asp:ListItem>Times-Italik</asp:ListItem>
                                                            <asp:ListItem>Helvetica</asp:ListItem>
                                                            <asp:ListItem>Courier</asp:ListItem>
                                                            <asp:ListItem>Symbol</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label158" runat="server" Text="Swap Company/Customer Details(company details to right side, customer details to left side" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList_Swap" runat="server" RepeatDirection="Horizontal" CssClass="">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                        <asp:Label ID="Label163" runat="server" Text="Default font size" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_font_size" runat="server" cssclass="form-control"   Width="100%" Height="81%" placeholder="10"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                    <asp:Label ID="Label159" runat="server" Text="Invoice/Estimate text Color" CssClass="form-label"></asp:Label><br />
                                                    <div class="input-group mb-3">
                                                        <input type="text" class="form-control" placeholder="#ff6f00" aria-label="Estimate Color" aria-describedby="basic-addon2" />
                                                        <div class="input-group-append">
                                                            <!--
                                                            <asp:Button ID="btn_Invoice_Estimate" runat="server" CssClass="btn btn-orange" data-bs-toggle="modal" data-bs-target="#exampleModal" />
                                                            <button type="button" style="color: orange" data-bs-toggle="modal" data-bs-target="#exampleModal" />
                                                            <input id="Button1" type="button" value="" style="color:orange"  data-bs-toggle="modal" data-bs-target="#exampleModal" />-->
                                                            <input type="color" id="btn_Invoice_Estimate" value="#FFA500" style="height: 100%" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                    <asp:Label ID="Label179" runat="server" Text="Items table heading color" CssClass="form-label"></asp:Label><br />
                                                    <div class="input-group mb-3">
                                                        <input type="text" class="form-control" placeholder="#90ee90" aria-label="Proposal Color" aria-describedby="basic-addon2" />
                                                        <div class="input-group-append">
                                                            <!--<asp:Button ID="btn_Color_Picker" runat="server" CssClass="btn btn-success btn-sm" />-->
                                                            <input type="color" id="btn_Color_Picker" value="#00FF00 " style="height: 100%" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                    <asp:Label ID="Label180" runat="server" Text="Item table heading text color" CssClass="form-label"></asp:Label><br />
                                                    <div class="input-group mb-3">
                                                        <input type="text" class="form-control" placeholder="#ffffff" aria-label="Task Color" aria-describedby="basic-addon2" />
                                                        <div class="input-group-append">
                                                            <!--<asp:Button ID="btn_Item_text_Color" runat="server" CssClass="btn btn-danger" />-->
                                                            <input type="color" id="btn_Item_text_Color" value="#ff0000" style="height: 100%" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                        <asp:Label ID="Label156" runat="server" Text="Custom PDF Company Logo URL (JPG - 210*60)" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_PDF_Custom" runat="server" cssclass="form-control" placeholder="Custom PDF Company Logo URL (JPG - 210*60)"  Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                        <asp:Label ID="Label181" runat="server" Text="Logo Width (PX)" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_PDF_Logo_Width" placeholder="90" cssclass="form-control"  runat="server" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label161" runat="server" Text="Show Invoice/estimate status on PDF" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList64" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label160" runat="server" Text="Show Pay invoice to PDF (Not applied if invoice status is Cancelled)" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList63" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class=" col-md-12 col-sm-12 col-lg-12">
                                                        <asp:Label ID="Label162" runat="server" Text="Show invoice payment (transactions) on PDF" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList51" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>

                                                <!--Model Popup-->
                                                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header ">
                                                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                                            </div>
                                                            <div class="modal-body">
                                                                <div class="row form-group">
                                                                    <label for="exampleColorInput" class="form-label"></label>
                                                                    <input type="color" class="form-control form-control-color" id="exampleColorInput" value="#563d7c" />
                                                                </div>
                                                            </div>
                                                            <div class="modal-footer">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Document_Format-->
                                <div class="tab-pane p-20" id="Document_Format" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div15" runat="server" role="tabpanel">
                                            <h5>Document format</h5>
                                            <hr />
                                            <div class="mb-2">
                                                <div class="row">
                                                   <h5 class="text-purple">Document Formats</h5>
                                                    <hr />
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                            <asp:Label ID="Label165" runat="server" Text="Invoice" CssClass="form-label"></asp:Label><br />
                                                            <asp:DropDownList ID="DropDownList16" runat="server" cssclass="form-select" Width="100%" Height="81%">
                                                                <asp:ListItem>A4 Portrait</asp:ListItem>
                                                                <asp:ListItem>Legal</asp:ListItem>
                                                                <asp:ListItem>A4 Wide</asp:ListItem>

                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                            <asp:Label ID="Label166" runat="server" Text="Estimate" CssClass="form-label"></asp:Label><br />
                                                            <asp:DropDownList ID="DropDownList17" runat="server" cssclass="form-select" Width="100%" Height="81%">
                                                                <asp:ListItem>A4 Portrait</asp:ListItem>
                                                                <asp:ListItem>Legal</asp:ListItem>
                                                                <asp:ListItem>A4 Wide</asp:ListItem>

                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                            <asp:Label ID="Label167" runat="server" Text="Proposal" CssClass="form-label"></asp:Label><br />
                                                            <asp:DropDownList ID="DropDownList18" runat="server" cssclass="form-select" Width="100%" Height="81%">
                                                                <asp:ListItem>A4 Portrait</asp:ListItem>
                                                                <asp:ListItem>Legal</asp:ListItem>

                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                            <asp:Label ID="Label164" runat="server" Text="Payment" CssClass="form-label"></asp:Label><br />
                                                            <asp:DropDownList ID="DropDownList15" runat="server" cssclass="form-select" Width="100%" Height="81%">
                                                                <asp:ListItem>A4 Portrait</asp:ListItem>
                                                                <asp:ListItem>Legal</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                            <asp:Label ID="Label168" runat="server" Text="Contract" CssClass="form-label"></asp:Label><br />
                                                            <asp:DropDownList ID="DropDownList19" runat="server" cssclass="form-select" Width="100%" Height="81%">
                                                                <asp:ListItem>A4 Portrait</asp:ListItem>
                                                                <asp:ListItem>Legal</asp:ListItem>
                                                                <asp:ListItem>A4 Wide</asp:ListItem>
                                                            </asp:DropDownList>
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
                <!--E-Sign-->
                <div id="setting_E_sign" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                        </div>
                    </div>
                </div>
                <!--Setting_Cron_Jab-->
                <div id="Cron_Job" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                </div>
                            </div>
                            <div class="d-md-flex align-items-center">
                                <ul class="nav nav-tabs" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" data-bs-toggle="tab" href="#Cron_Job_Invoice" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">Invoice</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Cron_Job_Estimates" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">Estimates</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Cron_Job_Proposals" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">Proposals</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Cron_Job_Contracts" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">Contracts</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Cron_Job_Tasks" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">Tasks</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Cron_Job_Tickets" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">Tickets</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Cron_Job_Surveys" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">Surveys</span></a>
                                    </li>
                                </ul>
                            </div>
                            <br />
                            <br />
                            <div class="tab-content tabcontent-border">
                                <!-- Cron_Job_Invoice-->
                                <div class="tab-pane active" id="Setting_Cron_Job" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div16" runat="server" role="tabpanel">
                                            <h5>Invoice</h5>
                                            <hr />
                                            <div class="mb-2">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                        <asp:Label ID="Label170" runat="server" Text="Send invoice overdue reminder" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList_Send" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                        <asp:Label ID="Label169" runat="server" Text="Auto send reminder after (days)" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_7_days_reminder" runat="server" cssclass="form-control" placeholder="7" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                        <asp:Label ID="Label171" runat="server" Text="Auto re-send reminder after (days)" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_3_days_reminder" runat="server"  cssclass="form-control" placeholder="3" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                        <asp:Label ID="Label172" runat="server" Text="Create new invoice from main recuring invoice only if is with status Paid" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList65" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                        <asp:Label ID="Label173" runat="server" Text="Auto send the renewed invoice to the customer" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList66" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Cron_Job_Estimates-->
                                <div class="tab-pane p-20" id="Cron_Job_Estimates" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div17" runat="server" role="tabpanel">
                                            <h5>Estimate</h5>
                                            <hr />
                                            <div class="mb-2">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label174" runat="server" Text="Send expiration reminder" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList_Send_expiration_reminder" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                        <asp:Label ID="Label175" runat="server" Text="Send expiration reminder before (Days)" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="TextBox9" runat="server"  cssclass="form-control" placeholder="3" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Cron_Job_Proposals-->
                                <div class="tab-pane p-20" id="Cron_Job_Proposals" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div18" runat="server" role="tabpanel">
                                            <h5>Proposal</h5>
                                            <hr />
                                            <div class="mb-2">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                        <asp:Label ID="Label176" runat="server" Text="Send expiration reminder" CssClass="form-label"></asp:Label><br />
                                                        <asp:RadioButtonList ID="RadioButtonList_Send_expiration_Proposal" runat="server" RepeatDirection="Horizontal">
                                                           <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                           <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                        <asp:Label ID="Label177" runat="server" Text="Send expiration reminder before (Days)" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Send_expiration" runat="server"  cssclass="form-control" placeholder="3" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Cron_Job_Contracts-->
                                <div class="tab-pane p-20" id="Cron_Job_Contracts" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div19" runat="server" role="tabpanel">
                                            <h5>Contract</h5>
                                            <hr />
                                            <div class="mb-2">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                        <asp:Label ID="Label182" runat="server" Text="Contract expiration reminder before (Days)" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Contract_Reminder" runat="server"  cssclass="form-control" placeholder="3" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Cron_Job_Tasks-->
                                <div class="tab-pane p-20" id="Cron_Job_Tasks" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div20" runat="server" role="tabpanel">
                                            <h5>Tasks</h5>
                                            <hr />
                                            <div class="mb-2">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                        <asp:Label ID="Label178" runat="server" Text="Task deadline reminder before (Days)" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Task_deadline" runat="server" CssClass="form-control"  placeholder="2" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Cron_Job_Tickets-->
                                <div class="tab-pane p-20" id="Cron_Job_Tickets" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div21" runat="server" role="tabpanel">
                                            <h5>Tickets</h5>
                                            <hr />
                                            <div class="mb-2">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                        <asp:Label ID="Label183" runat="server" Text="Auto close ticket after (Hours)" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_ticket_Auto" runat="server"  CssClass="form-control" placeholder="48" Width="100%" Height="81%"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Cron_Job_Surveys-->
                                <div class="tab-pane p-20" id="Cron_Job_Surveys" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div22" runat="server" role="tabpanel">
                                            <h5>Surveys</h5>
                                            <hr />
                                            <div class="mb-2">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 2%">
                                                        <asp:Label ID="Label184" runat="server" Text="Howm much emails to sent per hour" CssClass="form-label"></asp:Label><br />
                                                        <asp:TextBox ID="txt_Survey_Cron_job" runat="server"  cssclass="form-control" placeholder="100" Width="100%" Height="81%"></asp:TextBox>
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
                <!--Tags-->
                <div id="Setting_Tag" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                        </div>
                    </div>
                </div>
                <!--Pusher.com-->
                <div id="Setting_pusher" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                        </div>
                    </div>
                </div>
                <!--Google-->
                <div id="Setting_Goole" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                        </div>
                    </div>
                </div>
                <!--Setting_MISC-->
                <div id="Setting_MISC" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                            <div class="d-md-flex align-items-center">
                                <ul class="nav nav-tabs" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" data-bs-toggle="tab" href="#Misc" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">MISC</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#Newsfeed" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">Newsfeed</span></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-bs-toggle="tab" href="#reCAPTCHA" role="tab"><span class="hidden-sm-up"></span>
                                            <span class="hidden-xs-down  font-bold">reCAPTCHA</span></a>
                                    </li>
                                </ul>
                            </div>
                            <br />
                            <br />
                            <div class="tab-content tabcontent-border">
                                <!--MISC-->
                                <div class="tab-pane active" id="Misc" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div23" runat="server" role="tabpanel">
                                            <h5 class="text-purple">MISC</h5>
                                            <hr />
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                    <asp:Label ID="Label185" runat="server" Text="Google API Key" CssClass="form-label"></asp:Label><br />
                                                    <asp:TextBox ID="txt_Google_API" runat="server" CssClass="form-control" placeholder="Google API Key" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="Label186" runat="server" Text="Dropbox APP Key" CssClass="form-label"></asp:Label><br />
                                                    <asp:TextBox ID="txt_Dropbox_APP" runat="server"  CssClass="form-control" placeholder="Dropbox APP Key" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="Label187" runat="server" Text="Table Pagination Limit" CssClass="form-label"></asp:Label><br />
                                                    <asp:TextBox ID="txt_Pagination" runat="server"  CssClass="form-control" placeholder="25" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="Label188" runat="server" Text="Auto check for new notification (Seconds - set 0 to disable)" CssClass="form-label"></asp:Label><br />
                                                    <asp:TextBox ID="txt_Auto_Check" runat="server"  CssClass="form-control" placeholder="0" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="Label189" runat="server" Text="Limit_Top Search Bar Results to" CssClass="form-label"></asp:Label><br />
                                                    <asp:TextBox ID="txt_Limit_Top_Search_Bar_Results_to" CssClass="form-control" runat="server" placeholder="10" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="Label190" runat="server" Text="Default Staff Role" CssClass="form-label"></asp:Label><br />
                                                    <asp:DropDownList ID="DropDownList20" runat="server" cssclass="form-select" Width="100%" Height="81%">
                                                        <asp:ListItem>Employee</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="Label191" runat="server" Text="Max file size upload in Media (MB)" CssClass="form-label"></asp:Label><br />
                                                    <asp:TextBox ID="txt_Max_file_size_upload_in_Media"  CssClass="form-control" runat="server" placeholder="10" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="Label192" runat="server" Text="Show help menu items on setup menu" CssClass="form-label"></asp:Label><br />
                                                    <asp:RadioButtonList ID="Rbtn_MISC" runat="server" CssClass="" RepeatDirection="Horizontal">
                                                       <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                       <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                        </div>
                                    </div>
                                </div>
                                <!--Newsfeed-->
                                <div class="tab-pane active" id="Newsfeed" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div24" runat="server" role="tabpanel">
                                            <h5 class="text-purple">Newsfeed</h5>
                                            <hr />
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                    <asp:Label ID="Label193" runat="server" Text="Maximum files upload on post" CssClass="form-label"></asp:Label><br />
                                                    <asp:TextBox ID="txt_Maximum_file_upload" runat="server"  CssClass="form-control" placeholder="20" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="Label194" runat="server" Text="Maximum file in size(MB)" CssClass="form-label"></asp:Label><br />
                                                    <asp:TextBox ID="txt_Maximum_file_Size" runat="server"  CssClass="form-control" placeholder="Maximum file in size(MB)" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--reCAPTCHA-->
                                <div class="tab-pane active" id="reCAPTCHA" role="tabpanel">
                                    <div class="p-20">
                                        <div id="Div25" runat="server" role="tabpanel">
                                            <h5 class="text-purple">ReCAPTCHA</h5>
                                            <hr />
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                    <asp:Label ID="Label195" runat="server" Text="Secret key" CssClass="form-label"></asp:Label><br />
                                                    <asp:TextBox ID="txt_Secret_Key" runat="server"  CssClass="form-control" placeholder="20" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="Label196" runat="server" Text="Site Key" CssClass="form-label"></asp:Label><br />
                                                    <asp:TextBox ID="txt_Site_Key" runat="server"  CssClass="form-control" placeholder="Site Key" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:RadioButtonList ID="RadioButtonList47" runat="server" RepeatDirection="Horizontal" Width="100%" CssClass="">
                                                       <asp:ListItem Value="1" Text="Yes&nbsp&nbsp" ></asp:ListItem>
                                                       <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                    </asp:RadioButtonList>
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
</asp:Content>
