<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="SingleTenderDetails.aspx.cs" Inherits="MatoshreeProject.SingleTenderDetails" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>


    <script type="text/javascript">
        $(document).ready(function () {
            var GridSingleVenderTenderDetail = $("#GridSingleVenderTenderDetail").prepend($("<thead></thead>").append($("#GridSingleVenderTenderDetail").find("tr:first"))).DataTable(
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
        <%-- BreadCrumbs --%>
        <h5 class="font-weight-medium mb-0">Tender Details</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item"><a class="text-muted text-decoration-none" href="Tender.aspx">Tender</a></li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="#">Tender Details</li>
            </ol>
        </nav>
        <br />
        <%-- BreadCrumbs --%>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h5>View Tender Details</h5>
                        <hr />
                        <asp:Button ID="Btn_Export" runat="server" Text="Export" CssClass="btn btn-sm btn-outline-success" OnClick="Btn_Export_Click" />
                        <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-primary" OnClick="Btn_Reload_Click" />

                        <br />
                        <br />
                        <asp:GridView ID="GridSingleVenderTenderDetail" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px" HeaderStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="vendmapid" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendmapid1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="VenderID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="VenderID1" runat="server" Text='<%# Bind("id") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="VenderName" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblVendername" runat="server" Text='<%# Bind("Vend_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendername1" runat="server" Text='<%# Bind("Vend_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:LinkButton ID="LinkBtnvenderName" runat="server" Text='<%# Bind("Vend_Name") %>' OnClick="LinkBtnvenderName_Click" CssClass="text-info" Font-Size="12px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ContactPerson" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblVendercontractname" runat="server" Text='<%# Bind("First_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendercontractname1" runat="server" Text='<%# Bind("First_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblemail" runat="server" Text='<%# Bind("email") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblemail1" runat="server" Text='<%# Bind("email") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Position" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPosition" runat="server" Text='<%# Bind("Position") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPosition1" runat="server" Text='<%# Bind("Position") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PhoneNumber" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblphonenumber" runat="server" Text='<%# Bind("phonenumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblphonenumber1" runat="server" Text='<%# Bind("phonenumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TenderNumber" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblTenderNumber" runat="server" Text='<%# Bind("TenderNumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTenderNumber1" runat="server" Text='<%# Bind("TenderNumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TotalAmountTender" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblTotalAmountTender" runat="server" Text='<%# Bind("TotalAmountTender") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalAmountTender1" runat="server" Text='<%# Bind("TotalAmountTender") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>



                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">

            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                <div class="card">
                    <div class="card-body">
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link active" data-bs-toggle="tab" href="#TenderNo" role="tab"><span class="hidden-sm-up"></span>
                                    <span class="hidden-xs-down fs-3px">Tender Number</span></a>
                            </li>

                        </ul>
                        <br />
                        <div class="tab-content tabcontent-border">
                            <div id="TenderNo" class="tab-pane active" role="tabpanel">
                                <div class="container">

                                    <div class="row">
                                        <div class="col-md-2 col-sm-2 col-lg-2">
                                            <asp:Label ID="lblStatus" runat="server" Text="" CssClass="btn btn-sm btn-light text-blue"></asp:Label>
                                            <asp:Label ID="lblstatus1" runat="server" Text="" CssClass="text-danger" Visible="false"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                        </div>
                                        <div class="col-md-2 col-sm-2 col-lg-2">
                                            <div class="mb-2">
                                                <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="Linkbtnedit_Click" title="Edit"><i class="ti ti-edit"></i></asp:LinkButton>

                                                <asp:LinkButton ID="lnkbtnpdf" runat="server" CssClass="btn btn-sm btn-outline-danger" OnClick="lnkbtnpdf_Click1" title="PDF"><iconify-icon icon="ph:file-pdf"></iconify-icon></asp:LinkButton>

                                                <asp:LinkButton ID="LinkbtnMessage" runat="server" CssClass="btn btn-sm btn-outline-primary" title="Email"><iconify-icon icon="solar:letter-unread-linear" class="aside-icon"></iconify-icon></asp:LinkButton>
                                            </div>

                                        </div>
                                        <div class="col-md-2 col-sm-2 col-lg-2">
                                            <div class="mb-2">
                                                <div class="bd-example">
                                                    <div class="btn-group">
                                                        <button class="btn btn-sm btn-light dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">More</button>
                                                        <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                                        <div class="dropdown-menu">
                                                            <asp:LinkButton ID="lnkbtnpublished" Text="Published" runat="server" CssClass="dropdown-item" OnClick="lnkbtnpublished_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkbtnnotpublished" Text="Not Published" runat="server" CssClass="dropdown-item" OnClick="lnkbtnnotpublished_Click"></asp:LinkButton>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <hr />

                                <div class="container">
                                    <div class="row">

                                        <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 align-items-start">
                                            <asp:Image ID="Image1" Text="" runat="server" Height="80px" Width="130px" />
                                            <asp:Label ID="lblProjectID" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:Label ID="lblid1" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:Label ID="lblcustname" runat="server" Text="" Visible="false"></asp:Label>
                                        </div>
                                        <div class="col-md-2 col-lg-2 col-sm-2 col-xs-3">
                                        </div>

                                        <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4 text-right">
                                            <asp:Label ID="lblURLname" runat="server" Text="This tender related to project:" Font-Size="12px"></asp:Label>
                                            <asp:Label ID="lblURLname1" runat="server" Text="" CssClass="form-label text-info "></asp:Label><br />
                                            <asp:Label ID="lblTenderno" runat="server" Text="" CssClass="form-label text-info" Font-Size="12px"></asp:Label><br />
                                            <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="form-label "></asp:Label><br />
                                            <asp:Label ID="lbladdress11" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                            <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                            <asp:Label ID="lblcompanyaddState1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," Font-Size="12px"></asp:Label><br />
                                            <asp:Label ID="lblpincode" runat="server" Text="PIN:" CssClass="form-label"></asp:Label>
                                            <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                            <asp:Label ID="lblphone" runat="server" Text="Phone:" CssClass="form-label"></asp:Label>
                                            <asp:Label ID="lblphoneNo1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                            <asp:Label ID="lblvat" runat="server" Text="VAT NO:" CssClass="form-label"></asp:Label>
                                            <asp:Label ID="lblVatNo1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                            <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" CssClass="form-label"></asp:Label>
                                            <asp:Label ID="lblGSTNo1A" runat="server" Text="" Font-Size="12px"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />

                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12 text-center">
                                        <asp:Label ID="lbltenderheader" runat="server" Text=" Tender " CssClass="form-label text-dark" Font-Size="18px"></asp:Label><br />
                                    </div>
                                </div>

                                <br />
                                <br />

                                <div class="row">
                                    <h5 class="text-purple">Current Tender Details:-</h5>
                                    <div class="row">

                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                            <div class="col-md-12 col-sm-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lbltendno" runat="server" Text="Tender Number:" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lbltendno1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblnamework" runat="server" Text="Tender Name:" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lblTendername" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                </div>

                                            </div>

                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lbltendtype" runat="server" Text="Tender Type:" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lbltendtype1" runat="server" Text="" Font-Size="12px"></asp:Label>

                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-6 col-sm-6 col-lg-6">


                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lbltendcat" runat="server" Text="Tender Category:" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lbltendcat1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                </div>

                                            </div>

                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblecv" runat="server" Text="Tender Value:" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lblecv1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                </div>

                                            </div>

                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblbidenddate" runat="server" Text="Bid End Date:" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lblbidenddate1" runat="server" Text="" Font-Size="12px"></asp:Label>

                                                </div>
                                            </div>



                                        </div>

                                    </div>
                                </div>
                                 <br />
                                <div class="row">
                                  <h5 class="text-purple">Work Details:-</h5>
                                       <div class="row">

                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lbllocCity" runat="server" Text="Work Address:" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lbllocCity1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblprebidmeetingadd" runat="server" Text="Pre Bid Meeting Address:" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lblprebidmeetingadd1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblprebidmeetdate" runat="server" Text="Pre Bid Meeting Date:" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lblprebidmeetdate1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblworkdesc" runat="server" Text="Work Description:" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lblworkdesc1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                               </div>
                                 <br />
                                <div class="row">
                                  <h5 class="text-purple">Critical Dates:-</h5>
                                      <div class="row">
                                            <div class="col-md-6 col-sm-6 col-lg-6">

                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblpublishdate" runat="server" Text="Publish Date:" CssClass="form-label"></asp:Label>
                                                        <asp:Label ID="lblpublishdate11" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                    </div>

                                                </div>


                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblbidstartdate" runat="server" Text="Bid Submission Start Date:" CssClass="form-label"></asp:Label>
                                                        <asp:Label ID="lblbidstartdate1" runat="server" Text="" Font-Size="12px"></asp:Label>

                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-md-6 col-sm-6 col-lg-6">

                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblbidopen" runat="server" Text="Bid Opening Date:" CssClass="form-label"></asp:Label>
                                                        <asp:Label ID="lblbidopen1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                    </div>

                                                </div>

                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblbidsubmissionend" runat="server" Text="Bid Submission End Date:" CssClass="form-label"></asp:Label>
                                                        <asp:Label ID="lblbidsubmissionend1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                   </div>
                                 <br />
                                <div class="row">
                                   <h5 class="text-purple">Tender Inviting Authority:-</h5>                                     
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 col-lg-6">

                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblauthorityname" runat="server" Text="Authority Name:" CssClass="form-label"></asp:Label>
                                                        <asp:Label ID="lblauthorityname1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblauthorityadd" runat="server" Text="Authority Address:" CssClass="form-label"></asp:Label>
                                                        <asp:Label ID="lblauthorityadd1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblauthemail" runat="server" Text="Email:" CssClass="form-label"></asp:Label>
                                                        <asp:Label ID="lblauthemail1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblconno" runat="server" Text="Contact No:" CssClass="form-label"></asp:Label>
                                                        <asp:Label ID="lblconno1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblauthposition" runat="server" Text="Authority Position:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblauthposition1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                <br />

                                <div class="container">
                                     <h5 class="text-purple">Tender Questions:-</h5>
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12">

                                        <asp:GridView ID="GridTenderQue" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                            ClientIDMode="Static" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" HeaderStyle-Font-Bold="true">
                                            <Columns>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblTenderQueID" runat="server" Text="ID" Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTenderQueID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblTenderQueName" runat="server" Text="Question" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTenderQueName1" runat="server" Text='<%# Bind("Question") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>

                                    </div>
                                </div>
                                <br />

                                <div class="container">
                                     <h5 class="text-purple">Tender Items:-</h5>
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="table-responsive">
                                        <asp:GridView ID="GridCalculate" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                            ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" HeaderStyle-Font-Bold="true">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblItem" runat="server" Text="Item" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItem1" runat="server" Text='<%# Bind("Item") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="120px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Qnty") %>' CssClass="form-label"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    </div>

                                </div>
                                <br />

                                <div class="container">
                                    <h5 class="text-purple">Tender Files:-</h5>
                                    <br />
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <asp:GridView ID="GridTenderFile" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                            ClientIDMode="Static" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" HeaderStyle-Font-Bold="true">
                                            <Columns>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblTenderID" runat="server" Text="FileName" Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTenderID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblTenderFileName" runat="server" Text="FileName" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTenderFileName1" runat="server" Text='<%# Bind("FileName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                                <br />
                                <div class="container">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <h6>Note :</h6>
                                            <asp:Label ID="lblclientnote" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                            <br />
                                            <h6>Terms & Condition:</h6>
                                            <asp:Label ID="lbltermsandcodition" runat="server" Text="" Font-Size="12px"></asp:Label><br />
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

