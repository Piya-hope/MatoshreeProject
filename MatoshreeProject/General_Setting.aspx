<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="General_Setting.aspx.cs" Inherits="LissomBillingPortal.General_Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
         <h5 class="font-weight-medium mb-0">General Setting</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="#">SETTING
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="General_Setting.aspx">General Setting</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="col-md-3 col-sm-3 col-lg-3">
                <div class="card">
                    <div class="card-body">
                        <div class="form-group form-control-lg" style="font-size: medium">
                            <div class="form-control-sm">
                                <asp:LinkButton ID="link_btn_General" runat="server" Text="General" Height="25px" margin-bottom="1%" CssClass="link font-18  "></asp:LinkButton><br />
                                <asp:LinkButton ID="link_btn_Company" runat="server" Text="Company" Height="25px" CssClass="link font-18 " margin-bottom="1%"></asp:LinkButton><br />
                                <asp:LinkButton ID="link_btn_Localization" runat="server" Text="Localization" Height="25px" CssClass="link font-18 " margin-bottom="1%"></asp:LinkButton><br />
                                <asp:LinkButton ID="link_btn_Tickets" runat="server" Text="Ticket" Height="25px" CssClass="link font-18 " margin-bottom="1%"></asp:LinkButton><br />
                                <asp:LinkButton ID="link_btn_Finance" runat="server" Text="Finance" Height="25px" CssClass="link font-18 " margin-bottom="1%"></asp:LinkButton><br />
                                <asp:LinkButton ID="link_btn_Payment_Gateway" runat="server" Text="Payment Gateway" Height="25px" CssClass="link font-18 " margin-bottom="1%"></asp:LinkButton><br />
                                <asp:LinkButton ID="link_btn_Email" runat="server" Text="Email" Height="25px" CssClass="link font-18 " margin-bottom="1%"></asp:LinkButton><br />
                                <asp:LinkButton ID="link_btn_Customer" runat="server" Text="Customer" Height="25px" CssClass="link font-18 " margin-bottom="1%"></asp:LinkButton><br />
                                <asp:LinkButton ID="link_btn_Task" runat="server" Text="Task" Height="25px" CssClass="link font-18 " margin-bottom="1%"></asp:LinkButton><br />
                                <asp:LinkButton ID="link_btn_Leads" runat="server" Text="Leads" Height="25px" CssClass="link font-18 " margin-bottom="1%"></asp:LinkButton><br />
                                <asp:LinkButton ID="link_btn_Calender" runat="server" Text="Calender" Height="25px" CssClass="link font-18 " margin-bottom="1%"></asp:LinkButton><br />
                                <asp:LinkButton ID="link_btn_Pdf" runat="server" Text="PDF" Height="25px" CssClass="link font-18 " margin-bottom="1%"></asp:LinkButton><br />
                                <asp:LinkButton ID="link_btn_Cron_Job" runat="server" Text="Cron Job" Height="25px" CssClass="link font-18 " margin-bottom="1%"></asp:LinkButton><br />
                                <asp:LinkButton ID="link_btn_Misc" runat="server" Text="Misc" Height="25px" CssClass="link font-18 " margin-bottom="1%"></asp:LinkButton><br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-2">
                                <asp:Button ID="btn_Save_Settings" runat="server" Text="Save Settings" CssClass="btn btn-info link  " Width="100%" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--General-->
            <div class="col-md-9 col-sm-9 col-lg-9">
                <div class="card">
                    <div class="card-body">
                        <div class="d-md-flex align-items-center">
                            <!-- Tabs -->
                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" data-bs-toggle="tab" href="#General" role="tab"><span class="hidden-sm-up"></span>
                                        <span class="hidden-xs-down  font-bold">General</span></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-bs-toggle="tab" href="#Invoice" role="tab"><span class="hidden-sm-up"></span>
                                        <span class="hidden-xs-down  font-bold">Invoice</span></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-bs-toggle="tab" href="#Estimate" role="tab"><span class="hidden-sm-up"></span>
                                        <span class="hidden-xs-down  font-bold">Estimate</span></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-bs-toggle="tab" href="#Praposal" role="tab"><span class="hidden-sm-up"></span>
                                        <span class="hidden-xs-down  font-bold">Praposal</span></a>
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
                                            <h4 style="font: bold">General</h4>
                                            <h7>General Setting's</h7>
                                            <hr />
                                            <div class="row">
                                                <div class="col-md-6 col-sm-6 col-lg-6" style="position: relative; margin-top: 6%">
                                                    <asp:Label ID="Label1" runat="server" Text="Decimal Seperator" CssClass="link  "></asp:Label><br />
                                                    <asp:TextBox ID="txt_Decimal_Seperator" runat="server" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                                <br />
                                                <div class="col-md-6 col-sm-6 col-lg-6" style="position: relative; margin-top: 6%">
                                                    <asp:Label ID="Label2" runat="server" Text="Thousand Seperator" CssClass="link  "></asp:Label><br />
                                                    <asp:TextBox ID="txt_Thousand_Seperator" runat="server" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label3" runat="server" Text="Number padding zero's for prefix format's" CssClass="link  "></asp:Label><br />
                                                    <h7>eq. if this value is 3 the number will be formated: 005 or 025</h7>
                                                    <asp:TextBox ID="txt_Nuber_padding" runat="server" Width="100%" Height="57%"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label4" runat="server" Text="Show TAX per item" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label7" runat="server" Text="Remove the tax name from item table now" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList2" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label10" runat="server" Text="Remove decimal on Numbers/Money with zero decimal(2.00 will become 2, 2.25 will become 2.25)" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList3" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label13" runat="server" Text="Currancy Placement" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList4" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Before Amount($25.00)</asp:ListItem>
                                                            <asp:ListItem>After Amount($25.00)</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label16" runat="server" Text="Currancy Placement" CssClass="link  "></asp:Label><br />
                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="100%" Height="81%"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <h5>Amount to Words</h5>
                                                <br />
                                                <div class=" col-md-6 col-sm-6 col-lg-6">
                                                    <asp:Label ID="Label19" runat="server" Text="Enable" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList5" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <div class=" col-md-6 col-sm-6 col-lg-6">
                                                    <asp:Label ID="Label17" runat="server" Text="Number words into lowercase" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList6" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
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
                                                <h5 style="font: bold">Invoice</h5>
                                                <hr />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                    <asp:Label ID="Label23" runat="server" Text="Invoice Number Prefix" CssClass="link  "></asp:Label><br />
                                                    <asp:TextBox ID="txt_Invoice_Number_prefix" runat="server" placeholder="2022/" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="Label24" runat="server" Text="Next Invoice Number" CssClass="link  "></asp:Label><br />
                                                    <asp:TextBox ID="txt_Next_Invoice_Number_" runat="server" placeholder="28" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="Label45" runat="server" Text="Invoice due after(days)" CssClass="link  "></asp:Label><br />
                                                    <asp:TextBox ID="txt_Invoice_due_after" runat="server" placeholder="7" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label26" runat="server" Text="Require client to be logged in to view invoice" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList7" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label29" runat="server" Text="Deleted invoice allowed only on last invoice" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList8" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label32" runat="server" Text="Decrement invoice number on delet" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList9" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label250" runat="server" Text="Exclude invoice with draft status from customers area" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList10" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label48" runat="server" Text="Show Sale Agent on invoice" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList11" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <h5>Invoice Number Format</h5>
                                                <br />
                                                <div class=" col-md-6 col-sm-6 col-lg-6">
                                                    <asp:Label ID="Label39" runat="server" Text="Number Based(000001)" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList12" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <div class=" col-md-6 col-sm-6 col-lg-6">
                                                    <asp:Label ID="Label42" runat="server" Text="Year Based(YYYY/000001)" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList13" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label35" runat="server" Text="Predefined Terms & Conditions" CssClass="link  "></asp:Label><br />
                                                    <asp:TextBox ID="txt_predefined_terms" TextMode="MultiLine" runat="server" plaholder="2022/" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label36" runat="server" Text="Predefined Client Note" CssClass="link  "></asp:Label><br />
                                                    <asp:TextBox ID="txt_predefined_client_Note" TextMode="MultiLine" runat="server" plaholder="2022/" Width="100%" Height="81%"></asp:TextBox>
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
                                                <h5 style="font: bold">Estimate</h5>
                                                <hr />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                    <asp:Label ID="Label25" runat="server" Text="Estimate Number Prefix" CssClass="link  "></asp:Label><br />
                                                    <asp:TextBox ID="txt_Estimate_Number" runat="server" placeholder="EST-" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="Label37" runat="server" Text="Next Estimate Number" CssClass="link  "></asp:Label><br />
                                                    <asp:TextBox ID="txt_Estimate_Next_Number" runat="server" placeholder="51" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label54" runat="server" Text="Deleted Estimate allowed only on last invoice" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList14" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label57" runat="server" Text="Decrement Estimate number on delet" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList15" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label51" runat="server" Text="Require client to be logged in to view invoice" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList16" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label63" runat="server" Text="Show Sale Agent on Estimate" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList17" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label60" runat="server" Text="Auto convert the estimate to invoice after client accept" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList18" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label38" runat="server" Text="Exclude invoice with draft status from customers area" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList19" runat="server" CssClass=" " RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <h5>Estimate Number Format</h5>
                                                <br />
                                                <div class=" col-md-6 col-sm-6 col-lg-6">
                                                    <asp:Label ID="Label66" runat="server" Text="Number Based(000001)" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList20" runat="server" CssClass="" RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <div class=" col-md-6 col-sm-6 col-lg-6">
                                                    <asp:Label ID="Label69" runat="server" Text="Year Based(YYYY/000001)" CssClass="link  "></asp:Label><br />
                                                    <div class="form-control">
                                                        <asp:RadioButtonList ID="RadioButtonList21" runat="server" CssClass="" RepeatDirection="Horizontal">
                                                            <asp:ListItem>Yes</asp:ListItem>
                                                            <asp:ListItem>No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label76" runat="server" Text="Pipeline limit per status" CssClass="link  "></asp:Label><br />
                                                    <asp:TextBox ID="txt_pipeline_limit" runat="server" plaholder="2022/" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-6 col-sm-6 col-lg-6">
                                                    <asp:Label ID="Label80" runat="server" Text="Default pipeline sort" CssClass="link  "></asp:Label><br />
                                                    <asp:DropDownList ID="DropDownList2" runat="server" Width="100%" Height="82%"></asp:DropDownList>
                                                </div>
                                                <div class=" col-md-6 col-sm-6 col-lg-6" style="position: relative; margin-top: 3%;">
                                                    <asp:RadioButtonList ID="RadioButtonList23" runat="server" CssClass=" fa ms-2" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Ascending</asp:ListItem>
                                                        <asp:ListItem>Descending</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label72" runat="server" Text="Predefined Terms & Conditions" CssClass="link  "></asp:Label><br />
                                                    <asp:TextBox ID="TextBox4" TextMode="MultiLine" runat="server" plaholder="2022/" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="Label73" runat="server" Text="Predefined Client Note" CssClass="link  "></asp:Label><br />
                                                    <asp:TextBox ID="TextBox5" TextMode="MultiLine" runat="server" plaholder="2022/" Width="100%" Height="81%"></asp:TextBox>
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
                                                <h5 style="font: bold">Praposal</h5>
                                                <hr />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 0%">
                                                    <asp:Label ID="Label77" runat="server" Text="Praposal Number Prefix" CssClass="link  "></asp:Label><br />
                                                    <asp:TextBox ID="txt_Praposal_Number" runat="server" placeholder="PRO-" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="Label81" runat="server" Text="Praposal Due After (days)" CssClass="link  "></asp:Label><br />
                                                    <asp:TextBox ID="txt_New_Praposal" runat="server" placeholder="7" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="col-md-12 col-sm-12 col-lg-12" style="position: relative; margin-top: 3%">
                                                    <asp:Label ID="Label82" runat="server" Text="Pipeline limit per status" CssClass="link  "></asp:Label><br />
                                                    <asp:TextBox ID="txt_pipeline_status" runat="server" placeholder="50" Width="100%" Height="81%"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class=" col-md-6 col-sm-6 col-lg-6">
                                                    <asp:Label ID="Label107" runat="server" Text="Default pipeline sort" CssClass="link  "></asp:Label><br />
                                                    <asp:DropDownList ID="DropDownList3" runat="server" Width="100%" Height="82%"></asp:DropDownList>
                                                </div>
                                                <div class=" col-md-6 col-sm-6 col-lg-6" style="position: relative; margin-top: 3%; ">
                                                    <asp:RadioButtonList ID="RadioButtonList22" runat="server" CssClass="radioButtonList  fa ms-2" RepeatDirection="Horizontal">
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
        </div>
    </div>
</asp:Content>
