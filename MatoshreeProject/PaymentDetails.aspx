<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="PaymentDetails.aspx.cs" Inherits="MatoshreeProject.PaymentDetails" EnableEventValidation="false" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridInvoice = $("#GridInvoice").prepend($("<thead></thead>").append($("#GridInvoice").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

        });
    </script>

    <script> 
        tinymce.init({
            // selector: 'textarea',
            //selector : "textarea.Editor"
            selector: ".EditorNote",
            //theme: "modern",
            //plugins: ["lists link image charmap print preview hr anchor pagebreak"],

        });

    </script>
    <%-- Module Popup --%>

    <style>
        .Background {
            background-color: Black;
            /*  filter: alpha(opacity=90);*/
            opacity: 0.8;
        }

        .Popup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 1000px;
            height: 950px;
        }

        .lbl {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
         <h5 class="font-weight-medium  mb-0">Payment Details</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" href="Payments.aspx">Payments</li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="#">Payment Details</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="col-md-5 col-sm-5 col-lg-5">
                <asp:Label ID="lblInvNo1" runat="server" Text="Payment For Invoice:" Font-Bold="true" CssClass="text-dark" Style="font-size: 14px;"></asp:Label>
                <asp:Label ID="lblInvNo12" runat="server" Text="" CssClass="text-info" Font-Bold="true" Style="font-size: 14px;"></asp:Label>
                <asp:Label ID="lblAmtDeo" runat="server" Text="" CssClass="text-info" Visible="false" Font-Bold="true" Style="font-size: 14px;"></asp:Label>
                <asp:Label ID="lblCustID" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Label ID="lblContactID" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Label ID="lblFitstName" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Label ID="lblContactPosition" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Label ID="lblContactPhone" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Label ID="lblContactEmail" runat="server" Text="" Visible="false"></asp:Label>

                 <asp:Label ID="iblinvoiceid" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Label ID="lblProjectID" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Label ID="lblcustname" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Label ID="lblInvoicedate1" runat="server" Text="" Visible="false"></asp:Label>
                   <asp:Label ID="lblExpiry_Date1" runat="server" Text="" Visible="false"></asp:Label>
                   <asp:Label ID="lblprojectname1" runat="server" Text="" Visible="false"></asp:Label>
                  <asp:Label ID="lblInvoiceTotalAMT" runat="server" Text="" Visible="false"></asp:Label>

            </div>

            <div class="col-md-3 col-sm-3 col-lg-3">
                <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6  text-left">
                    <asp:Label ID="lblpay" runat="server" Text="Payment" CssClass="text-dark" Font-Bold="true" Style="font-size: 14px;"></asp:Label>
                </div>
            </div>
            <div class="col-md-4 col-sm-4 col-lg-4  text-end">
                <div class="row">
                     <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 "></div>
                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 text-end">
                        <asp:LinkButton ID="LinkbtnMessage" runat="server" CssClass="btn btn-sm btn-outline-info" title="Email"><iconify-icon icon="solar:letter-unread-linear" class="aside-icon"></iconify-icon></asp:LinkButton>
                        <div class="btn-group">
                            <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                            <asp:Button ID="btnmore" runat="server" Style="display: none" />
                            <div class="dropdown-menu">
                                <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDF_Click1"></asp:LinkButton>

                            </div>
                        </div>

                        <asp:LinkButton ID="LinkbtnClose" runat="server" CssClass="btn btn-sm btn-outline-danger btn-lg" title="Close" OnClick="LinkbtnClose_Click"><i class="fas fa-times"></i></asp:LinkButton>

                    </div>

                </div>
                <div class="row">
                    <div id="Emailmodal1">
                        <%-- Msg DIV popup for save --%>
                        <asp:Label ID="lblStaffEmail" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblStaffDesignation" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblEmpName11" runat="server" Text="" Visible="false"></asp:Label>


                        <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="LinkbtnMessage"
                            CancelControlID="btnCloseemail" BackgroundCssClass="Background">
                        </cc1:ModalPopupExtender>

                        <asp:Panel ID="Panl1" runat="server" CssClass="Popup table-responsive table-responsive-md" align="left" Style="display: none; width: 330px; height: 600px; top: 40px;">

                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-ld-12">
                                    <div class="card">

                                        <div class="card-body">
                                            <h5 class="text-purple">Send Payment Receipt To Client</h5>
                                            <hr />

                                            <div class="mb-2">
                                                <asp:Label ID="lblEmailTo" runat="server" Text="Email to" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                <asp:TextBox ID="txtEmailto" runat="server" placeholder="Enter Email to" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldFirst_Name" runat="server" ErrorMessage="Enter Email To Send" ControlToValidate="txtEmailto" ForeColor="Red" Font-Bold="false" ValidationGroup="sendemail"  Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lblCC" runat="server" Text="CC" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txtCC" runat="server" placeholder="Enter CC" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lblEmailEditor" runat="server" Text="Preview Email Template" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txtEmailEditor" runat="server" placeholder="Email Template" CssClass="EditorNote" TextMode="MultiLine"></asp:TextBox>

                                            </div>

                                            <div class="mb-2">
                                                <asp:Button ID="btnSendEmail" runat="server" Text="Send Email" CssClass="btn btn-sm btn-primary" ValidationGroup="sendemail" OnClick="btnSendEmail_Click" />
                                                &nbsp;&nbsp;
                                                                        <asp:Button ID="btnCloseemail" runat="server" Text="Close" ValidationGroup="closee" CssClass="btn btn-sm btn-danger " />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </asp:Panel>

                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row">

            <div class="col-md-5 col-sm-5 col-lg-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="mb-2">


                                            <asp:Label ID="lblRefPRimary" runat="server" Text="" Font-Bold="true" Visible="false" Font-Size="12px"></asp:Label>

                                            <asp:Label ID="lblAmount" runat="server" Text="Amount Received" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:TextBox ID="txtAmount" runat="server" placeholder="Amount Received" TextMode="Number" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Amount" ControlToValidate="txtAmount" ForeColor="Red" Font-Bold="false" ValidationGroup="Amount"  Font-Size="12px"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="mb-2">
                                            <asp:Label ID="lblpaymentDate" runat="server" Text="Payment Date" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:TextBox ID="txtpaymentDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter Payment Date(mm/dd/yyyy)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredpaymentDate" runat="server" ControlToValidate="txtpaymentDate" ForeColor="Red" Font-Bold="false" ValidationGroup="Amount" ErrorMessage="Enter Payment Date"  Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="mb-2">
                                            <asp:Label ID="lblpaymentType" runat="server" Text="Payment Mode" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:DropDownList ID="ddlpaymentType" runat="server" CssClass="form-control form-select" Placeholder="Select Payment">
                                                <asp:ListItem Value="Ns" Text="Nothing Selected"></asp:ListItem>
                                                <asp:ListItem Value="Bank" Text="Bank"></asp:ListItem>
                                                <asp:ListItem Value="Cash" Text="Cash"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldpaymentType" runat="server" ErrorMessage="Select Payment Mode" ControlToValidate="ddlpaymentType" ForeColor="Red" Font-Bold="false" ValidationGroup="Amount" InitialValue="0" Display="Dynamic"  Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="mb-2">
                                            <asp:Label ID="lblPaymentMethod" runat="server" Text="Payment Method" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtPaymentMethod" runat="server" placeholder="Enter PaymentMethod" class="form-control"></asp:TextBox>

                                        </div>

                                        <div class="mb-2">
                                            <asp:Label ID="lbltransationid" runat="server" Text="Transaction ID" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txttransationid" runat="server" placeholder="Enter Teansation ID" class="form-control"></asp:TextBox>

                                        </div>
                                        <div class="mb-2">
                                            <asp:Label ID="Label1" runat="server" Text="Note" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtnote" runat="server" CssClass="form-control" placeholder="Admin Note" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                        <div class="mb-2">
                                            <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" CssClass="btn btn-sm btn-success" ValidationGroup="upAmount" Visible="true" />
                                            &nbsp;&nbsp;
                                            <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btn btn-sm  btn-danger" OnClick="btncancel_Click" ValidationGroup="DeleteAmount" Visible="true" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>



            <div class="col-md-7 col-sm-7 col-lg-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6  text-left">
                                <asp:Label ID="lblpayname1111" runat="server" Text="" Visible="true" CssClass="text-dark" Style="font-size: 14px;"></asp:Label>


                                <asp:Label ID="lblCompanyName" runat="server" Text="" CssClass="font-weight-bold text-dark" Style="font-size: 14px;"></asp:Label>
                                <br />
                                <asp:Label ID="lblCompanyaddress" runat="server" Text="" CssClass="text-dark" Style="font-size: 14px;"></asp:Label>
                                <br />
                                <asp:Label ID="lblcompanycity" runat="server" Text="" CssClass="text-dark" Style="font-size: 12px;"></asp:Label>
                                <asp:Label ID="companydist" runat="server" Text="" CssClass="text-dark" Style="font-size: 12px;"></asp:Label>
                                <asp:Label ID="lblcomapnystate" runat="server" Text="" CssClass="text-dark" Style="font-size: 12px;"></asp:Label>

                                <br />
                                <asp:Label ID="lblcompanyPincode" runat="server" Text="" CssClass="text-dark" Style="font-size: 14px;"></asp:Label>
                                <br />
                                <asp:Label ID="lblPhone" runat="server" Text="Phone:" CssClass="text-dark" Style="font-size: 14px;"></asp:Label>
                                <asp:Label ID="lblCountry_Code" runat="server" Text="" CssClass="text-dark" Style="font-size: 14px;"></asp:Label>
                                <asp:Label ID="lblcompnyphnnum" runat="server" Text="" CssClass="text-dark" Style="font-size: 14px;"></asp:Label>

                                <br />
                                <asp:Label ID="lblGstNo" runat="server" Text="GST No:" CssClass="text-dark" Style="font-size: 14px;"></asp:Label>
                                <asp:Label ID="lblGstno1" runat="server" Text="" CssClass="text-dark" Style="font-size: 14px;"></asp:Label>
                                <asp:Label ID="Label3" runat="server" Text="" CssClass="text-dark" Style="font-size: 14px;"></asp:Label>

                                <br />

                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6  text-end mt-3">
                                <asp:Label ID="lblcustomerName" runat="server" Text="" CssClass="font-weight-bold    text-info" Style="font-size: 14px;"></asp:Label>
                                <br />
                                <asp:Label ID="lblAdd_Block" runat="server" Text="" CssClass="text-dark" Style="font-size: 14px;"></asp:Label>
                                <asp:Label ID="lblAdd_Street" runat="server" Text="" CssClass="text-dark" Style="font-size: 14px;"></asp:Label>
                                <asp:Label ID="lblAdd_City" runat="server" Text="" CssClass="text-dark" Style="font-size: 14px;"></asp:Label>
                                <br />
                                <asp:Label ID="lblAdd_State" runat="server" Text="" CssClass=" text-dark" Style="font-size: 14px;"></asp:Label>
                                <br />
                                <asp:Label ID="lblAdd_PinCode" runat="server" Text="" CssClass="text-dark" Style="font-size: 14px;"></asp:Label>
                            </div>

                        </div>
                        <br />
                        <br />
                        <div class="row">
                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                <center>
                                    <asp:Label ID="lblPayRec" runat="server" Text="PAYMENT RECEIPT" CssClass="font-weight-bold    text-dark" Style="font-size: 25px;"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <br />

                        <br />
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                                <div class="row">
                                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6  text-left">
                                        <asp:Label ID="Lblpdate" runat="server" Text="Payment Date:" CssClass="font-weight-bold    text-dark" Style="font-size: 14px;"></asp:Label>

                                    </div>

                                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6  text-end ">
                                        <asp:Label ID="Lblpdate1" runat="server" Text="" CssClass="font-weight-bold  text-dark" Style="font-size: 14px;"></asp:Label>

                                    </div>
                                </div>
                                <hr />
                                <br />
                                <div class="row">
                                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6  text-left">
                                        <asp:Label ID="lblpayMode" runat="server" Text="Payment Mode:" CssClass="font-weight-bold text-dark" Style="font-size: 14px;"></asp:Label>


                                    </div>

                                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6  text-end ">
                                        <asp:Label ID="lblpayMode1" runat="server" Text="" CssClass="font-weight-bold  text-dark" Style="font-size: 14px;"></asp:Label>

                                    </div>
                                </div>
                                <hr />
                                <br />
                                <div class="row">
                                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6  text-left">
                                        <asp:Label ID="lblPaytransaction" runat="server" Text="Transaction ID:" CssClass="font-weight-bold text-dark" Style="font-size: 14px;"></asp:Label>
                                        <asp:Label ID="lblPaytransaction1" runat="server" Text="" CssClass="font-weight-bold text-dark" Style="font-size: 14px;"></asp:Label>


                                    </div>

                                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6  text-end ">
                                        <asp:Label ID="lblinvoiceAmount" runat="server" Text="" Visible="false" CssClass="font-weight-bold text-dark" Style="font-size: 14px;"></asp:Label>
                                        <asp:Label ID="lblPaymentAmount" runat="server" Text="" Visible="false" CssClass="font-weight-bold text-dark" Style="font-size: 14px;"></asp:Label>
                                        <asp:Label ID="lblAmountDeo" runat="server" Text="" Visible="false" CssClass="font-weight-bold text-dark" Style="font-size: 14px;"></asp:Label>
                                        <asp:Label ID="lbldeoamt" runat="server" Text="" Visible="false" CssClass="font-weight-bold text-white" Style="font-size: 14px;"></asp:Label>

                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12  bg-success p-2">
                                        <center>
                                            <asp:Label ID="lblpayamount" runat="server" Text="Total Amount:" CssClass="font-weight-bold text-white" Style="font-size: 14px;"></asp:Label>
                                            <br />
                                            <asp:Label ID="lbltotalamt" runat="server" Text="" CssClass="font-weight-bold text-white" Style="font-size: 14px;"></asp:Label>
                                        </center>

                                    </div>

                                </div>


                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                <asp:Label ID="Label2" runat="server" Text="Payment For" CssClass="font-weight-bold text-dark" Style="font-size: 16px;"></asp:Label>
                                <br />
                                <asp:GridView ID="GridInvoice" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" Width="100%" CellPadding="4" OnRowDataBound="GridInvoice_RowDataBound"
                                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Invoice Number" SortExpression="InvoiceNo" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblInvoiceNumber" runat="server" Text='<%# Bind("InvoiceNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvoiceNumber1" runat="server" Text='<%# Bind("InvoiceNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice Date" SortExpression="Expiry_Date" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Bind("Expiry_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvoiceDate1" runat="server" Text='<%# Bind("Expiry_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice Amount" SortExpression="TotalAmount" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblInvoiceAmount" runat="server" Text='<%# Bind("TotalAmount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvoiceAmount1" runat="server" Text='<%# Bind("TotalAmount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Payment Amount" SortExpression="Amount_Recived" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblPaymentAmount" runat="server" Text='<%# Bind("Amount_Recived") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPaymentAmount1" runat="server" Text='<%# Bind("Amount_Recived") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount_Deo" SortExpression="Amount_Deo" HeaderStyle-Font-Size="12px" HeaderStyle-ForeColor="Red">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblAmountDeo" runat="server" Text='<%# Bind("AmountDeo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmountDeo1" runat="server" Text='<%# Bind("AmountDeo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Red"></asp:Label>
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

</asp:Content>
