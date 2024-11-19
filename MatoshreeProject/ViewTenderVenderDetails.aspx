<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ViewTenderVenderDetails.aspx.cs" Inherits="MatoshreeProject.ViewTenderVenderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h5 class="font-weight-medium mb-0">View Tender Vendor Details</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Tender.aspx">Tender
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="SingleTenderDetails.aspx">Tender Detail
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="#">Tender Vendor Details</li>
            </ol>
        </nav>
        <br />


        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                <div class="card">
                    <div class="card-body">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-2">
                                    <asp:Label ID="lblStatus" runat="server" Text="" CssClass="btn btn-sm btn-light text-blue"></asp:Label>
                                    <asp:Label ID="lblstatus1" runat="server" Text="" CssClass="text-danger" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-8">
                                </div>
                                <div class="col-md-2">
                                    <div class="mb-2">
                                        <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-outline-info" title="Edit" OnClick="Linkbtnedit_Click"><i class="ti ti-edit"></i></asp:LinkButton>

                                        <asp:LinkButton ID="lnkbtnpdf" runat="server" CssClass="btn btn-sm btn-outline-danger" title="PDF" OnClick="lnkbtnpdf_Click"><iconify-icon icon="ph:file-pdf"></iconify-icon></asp:LinkButton>

                                        <asp:LinkButton ID="LinkbtnMessage" runat="server" CssClass="btn btn-sm btn-outline-primary" title="Email"><iconify-icon icon="solar:letter-unread-linear" class="aside-icon"></iconify-icon></asp:LinkButton>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <hr>

                        <div class="container">
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6  align-items-start">
                                    <asp:Image ID="Image1" Text="" runat="server" Height="80px" Width="130px" /><br />
                                    <asp:Label ID="lblid1" runat="server" Text="" Visible="false"></asp:Label><br />

                                    <asp:Label ID="lblfrom" runat="server" Text="From" CssClass="form-label"></asp:Label><br />
                                    <asp:Label ID="lbladdCompany11" runat="server" Text="" Font-Size="12px"></asp:Label><br />
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
                                    <asp:Label ID="lblTenderno" runat="server" Text="" CssClass="form-label text-info" Font-Size="12px" Visible="false"></asp:Label><br />
                                </div>

                                <div class="col-md-3 col-lg-3 col-sm-3 col-xs-3">
                                </div>

                                <div class="col-md-3 col-lg-3 col-sm-3 col-xs-3 text-right">

                                    <asp:Label ID="lblcontactId" runat="server" Text="" Visible="false"></asp:Label><br />
                                    <asp:Label ID="lblTenderID" runat="server" Text="" Visible="false"></asp:Label><br />
                                    <asp:Label ID="lblcustname" runat="server" Text="" Visible="false"></asp:Label><br />
                                    <asp:Label ID="lblURLname" runat="server" Text="This tender related to project:" Font-Size="12px" Visible="false"></asp:Label>
                                    <asp:Label ID="lblURLname1" runat="server" Text="" CssClass="form-label text-info " Visible="false"></asp:Label><br />
                                    <asp:Label ID="lblCustid" runat="server" Text="" Visible="false"></asp:Label><br />
                                    <asp:Label ID="lblprojectid" runat="server" Text="" Visible="false"></asp:Label><br />
                                    <asp:Label ID="lblto" runat="server" Text="To," CssClass="form-label"></asp:Label><br />
                                    <asp:Label ID="lblvendername" runat="server" Text="" Font-Size="12px" Font-Bold="true"></asp:Label><br />
                                    <asp:Label ID="lblvenconname1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenconposition" runat="server" Text="Position:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblvenconposition1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenconemail" runat="server" Text="Email:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblvenconemail1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenconphone" runat="server" Text="Phone No:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblvenconphone1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenderblock" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenderstreet" runat="server" Text="" Font-Size="12px"></asp:Label>
                                    <asp:Label ID="lblvendercity" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenderdistrict" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenderstate" runat="server" Text="" Font-Size="12px"></asp:Label>
                                    <asp:Label ID="lblvenercountry" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblvenderpin" runat="server" Text="PIN:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblvenderpin1" runat="server" Text="" Font-Size="12px"></asp:Label><br />

                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="container">
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12 text-center">
                                    <asp:Label ID="lblAppliedtender" runat="server" Text="Applied Tender Details" CssClass="form-label" Font-Size="18px"></asp:Label><br />
                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="container">
                            <div class="row">
                                <h5 class="text-purple">Current Tender Details:-</h5>
                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-lg-6">

                                        <div class="col-md-12 col-sm-12 col-lg-12">
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

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblprebidmeetdate" runat="server" Text="Pre Bid Meeting Date:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblprebidmeetdate1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>

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

                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="mb-2">
                                            <asp:Label ID="lblworkdesc" runat="server" Text="Work Description:" CssClass="form-label"></asp:Label>
                                            <asp:Label ID="lblworkdesc1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <br />

                        <div class="container">
                            <div class="row">
                                <h5 class="text-purple">Tener Items:</h5>
                                <br />
                                <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
                                    <div class="table-responsive">
                                    <asp:GridView ID="Gridtendervenderitem" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                        ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="Gridtendervenderitem_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px" HeaderStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="tendvenditemid1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Item" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblItem" runat="server" Text='<%# Bind("Item") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblItem1" runat="server" Text='<%# Bind("Item") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Description" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quantity" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Qnty") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Qnty") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rate" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblRate" runat="server" Text='<%# Bind("Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRate1" runat="server" Text='<%# Bind("Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax1" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblTax1Name" runat="server" Text='<%# Bind("Tax1Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTax1Name1" runat="server" Text='<%# Bind("Tax1Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax1Rate" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblTax1Rate" runat="server" Text='<%# Bind("Tax1Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTax1Rate1" runat="server" Text='<%# Bind("Tax1Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax2" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblTax2Name" runat="server" Text='<%# Bind("Tax2Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTax2Name1" runat="server" Text='<%# Bind("Tax2Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax2Rate" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblTax2Rate" runat="server" Text='<%# Bind("Tax2Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTax2Rate1" runat="server" Text='<%# Bind("Tax2Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Total" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblTotalAmountTender" runat="server" Text='<%# Bind("TotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalAmountTender1" runat="server" Text='<%# Bind("TotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                    </div>
                            </div>
                        </div>

                        <div class="container">
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 align-items-start">
                                </div>
                                <div class="col-md-3 col-lg-3 col-sm-3 col-xs-3">
                                </div>
                                <div class="col-md-3 col-lg-3 col-sm-3 col-xs-3 text-right">
                                    <asp:Label ID="lblsubtotal1" runat="server" Text=" Total Item Total:₹" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblsubtotal" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblcgst" runat="server" Text="Total CGST Amount:₹" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblcgst1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lblsgst" runat="server" Text="Total SGST Amount:₹" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblsgst1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lbligst" runat="server" Text="Total IGST Amount:₹" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lbligst1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lbltotaltax1" runat="server" Text="Total Tax:₹" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lbltotaltax" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <asp:Label ID="lbltotalamt" runat="server" Text="Grand Total Amount:₹" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lbltotal" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="container">
                              <h5 class="text-purple">Tener Questions and Answers:</h5>
                                <br />
                            <div class="row">
                                <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
                                    <asp:GridView ID="GridViewTendvendQueAns" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                        ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" OnRowDataBound="GridViewTendvendQueAns_RowDataBound" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="tendvendmapid1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Question" SortExpression="ID" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQuestion1" runat="server" Text='<%# Bind("Tend_Que") %>' CssClass="form-label" Font-Size="12px"></asp:Label><br />
                                                    <asp:Label ID="lblAnswer1" runat="server" Text='<%# Bind("Tend_Ans") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" CssClass="text-info"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblDoc_File1" runat="server" Text='<%# Bind("Doc_File") %>' CssClass="form-label" Font-Size="12px" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblFilePath" runat="server" Text='<%# Bind("Doc_Filepath") %>' CssClass="text-info" Font-Size="12px" Visible="false"></asp:Label>

                                                    <asp:LinkButton ID="Btn_Download" runat="server" Text="" CausesValidation="false" OnClick="Btn_Download_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="container">
                            <div class="row">

                                <h5 class="text-purple">Tender Inviting Authority:</h5>

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
                        </div>


                        <br />

                        <div class="container">
                            <div class="row">
                                <div class="col-md-12">
                                    <h6>Note :</h6>
                                    <asp:Label ID="lblclientnote" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                    <h6>Terms & Condition:</h6>
                                    <asp:Label ID="lbltermsandcodition" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <div class="col-md-12">
                                <div class="mb-2">
                                    <asp:Label runat="server" Text="Tender Number" Font-Bold="true" CssClass=" font-bold" Visible="false"></asp:Label>
                                    <asp:Label ID="lblInitialNumber" runat="server" Text="-" Font-Bold="true" CssClass="form-control col-1 col-md-1" ReadOnly="true" Visible="false"></asp:Label>
                                    <asp:TextBox ID="txtWorkOrderNumber" runat="server" CssClass="form-control col-md-11" ReadOnly="true" Visible="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
                                <div class="mb-2">
                                    <asp:Button ID="Btn_Allowcate" runat="server" Text="Allocate" CssClass="btn btn-success btn-sm" OnClick="Btn_Allowcate_Click" />&nbsp;&nbsp
                                        <asp:Button ID="Btn_Decline" runat="server" Text="Decline" CssClass="btn btn-sm btn-danger" OnClick="Btn_Decline_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
