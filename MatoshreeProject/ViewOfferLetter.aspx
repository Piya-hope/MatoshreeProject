<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ViewOfferLetter.aspx.cs" Inherits="MatoshreeProject.ViewOfferLetter" %>

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
        <h5 class="font-weight-medium mb-0">View Offer Letter</h5>
<nav aria-label="breadcrumb">
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard </a>
        </li>
        <li class="breadcrumb-item">
            <a class="text-muted text-decoration-none" aria-current="page" href="OfferLetter.aspx">OfferLetter</a>
        </li>
        <li class="breadcrumb-item">
            <a class="text-muted text-decoration-none" aria-current="page" href="ViewOfferLetter.aspx">ViewOfferLetter</a>
        </li>
    </ol>
</nav>
        <br />
        <div class="row">
            <div class="card">
                <div class="card-body">
                        <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12 text-end">
                            <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-outline-info" title="Edit" OnClick="Linkbtnedit_Click"><iconify-icon icon="lucide:edit"></iconify-icon></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnpdf" runat="server" CssClass="btn btn-sm btn-outline-danger" title="PDF" OnClick="lnkbtnpdf_Click"><iconify-icon icon="teenyicons:pdf-outline"></iconify-icon></asp:LinkButton>
                            <asp:LinkButton ID="LinkbtnMessage" runat="server" CssClass="btn btn-sm btn-outline-primary" title="Email" OnClick="LinkbtnMessage_Click"><iconify-icon icon="quill:mail"></iconify-icon></iconify-icon></asp:LinkButton>
                        </div>
                    <hr />
                    <br />
                    <div class="row">                                       
                        <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2 text-left">
                            <asp:Image ID="Image1" Text="" runat="server" Height="150px" Width="200px" />
                            <asp:Label ID="lblCandid" runat="server" Text=" " Visible="false"></asp:Label>
                            <asp:Label ID="lblPackage" runat="server" Text=" " Visible="false"></asp:Label>
                        </div>
                       <div class="col-md-3 col-lg-3 col-sm-3 col-xs-3">

                         </div>
                           <div class="col-md-3 col-lg-3 col-sm-3 col-xs-3">

                         </div>
                        <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4 text-right">
                            <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-14 text-dark" Font-Bold="true"></asp:Label><br />
                            <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="font-14 text-dark"></asp:Label>
                            <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="text-dark font-14"></asp:Label><br />
                            <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="text-dark font-14"></asp:Label><br />
                            <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="text-dark font-14"></asp:Label>
                            <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," CssClass="text-dark font-14"></asp:Label><br />
                            <asp:Label ID="lblpincode" runat="server" Text="PIN:" CssClass="text-dark font-14" Font-Bold="true"></asp:Label>
                            <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" CssClass="text-dark font-14"></asp:Label><br />
                            <asp:Label ID="lblphone" runat="server" Text="Phone:" CssClass="text-dark font-14" Font-Bold="true"></asp:Label>
                            <asp:Label ID="lblphoneNo1" runat="server" Text="" CssClass="text-dark font-14"></asp:Label><br />
                        </div>

                    

                    </div>
                    <hr />
                    <br />
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="lblcandno" runat="server" Text=" " CssClass="font-14 text-dark" Font-Bold="true"></asp:Label>
                        </div>
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-4">
                              <asp:Label ID="lbldate" runat="server" Text="Date :" CssClass="font-14 text-dark" Font-Bold="true"></asp:Label>
                            <asp:Label ID="lblCandCreateDate" runat="server" Text=" " CssClass="font-12 text-dark"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12 text-center">
                            <asp:Label ID="lblCandOffLetter" runat="server" Text="Candidate Offer Letter" CssClass="font-16 text-dark" Font-Bold="true"></asp:Label><br />
                            <asp:Label ID="lblcandline" runat="server" Text="----------------------------" CssClass="font-16 font-bold text-dark"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12 text-left">
                            <asp:Label ID="lblcandto" runat="server" Text="To," CssClass="font-14 text-dark" Font-Bold="true"></asp:Label>
                            <br />
                            <asp:Label ID="lblCandName" runat="server" Text=" " CssClass="font-14 font-bold"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12 text-center">
                            <asp:Label ID="lblSub" runat="server" Text="Subject: Offer of Employment" CssClass="font-14 text-dark" Font-Bold="true"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2 col-xs-2 col-lg-2 col-sm-2 text-left">
                            <asp:Label ID="lbldear" runat="server" Text="Dear" CssClass="font-14"></asp:Label>&nbsp;
                          
                            <asp:Label ID="lblCandname1" runat="server" Text=" " CssClass="font-14 text-dark" Font-Bold="true"></asp:Label>
                        </div>
                        <div class="col-md-6 col-xs-6 col-lg-6 col-sm-6">
                        </div>
                        <div class="col-md-4 col-xs-4 col-lg-4 col-sm-4">
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12">
                        <asp:Label ID="lblpar" runat="server" Text=" " CssClass="font-14"></asp:Label>
                        <asp:Label ID="lblcompanyname" runat="server" Text=" " CssClass="font-14"></asp:Label>
                        <asp:Label ID="lblpar1" runat="server" Text="This offer is based on your profile and performance in the selection process. You have been selected for the position of" CssClass="font-14"></asp:Label>
                        <asp:Label ID="lbldesignation" runat="server" Text="" CssClass="font-14"></asp:Label>
                        <asp:Label ID="lblpar2" runat="server" Text=" " CssClass="font-14"></asp:Label>
                        <asp:Label ID="lblpar3" runat="server" Text="This offer is based on your profile and performance in the selection process. You have been selected for the position of" CssClass="font-14"></asp:Label>
                        <asp:Label ID="lblpar4" runat="server" Text="" CssClass="font-14"></asp:Label>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12">
                            <asp:Label ID="lblTermsCondition" runat="server" Text=" " CssClass="font-12"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <%-- A) Employeer Components--%>
                    <div class="row">
                        <h5 class="card-title">A) Component</h5>
                        <hr />
                        <asp:GridView ID="GridViewComponent" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                            ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true" DataKeyNames="CandID">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblCompnent" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("CandID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:Label ID="lblComponentID" runat="server" Text='<%# Bind("PerCATID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:Label ID="lblCompnent1" runat="server" Text='<%# Bind("Category") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblCompnent2" runat="server" Text="Total" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblPercentage" runat="server" Text="Percentage" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <asp:Label ID="lblPercentage1" runat="server" Text='<%# Bind("Percentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblPercentage2" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text="Monthly Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <asp:TextBox ID="txtAmount1" runat="server" Text='<%# Bind("MonthlyAmount") %>' Font-Size="12px" CssClass="form-control" Placeholder="Monthly Amount" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>
                                        <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("MonthlyAmount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblAmount2" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblAmountYr" runat="server" Text="Annual Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <asp:Label ID="lblAmountYr1" runat="server" Text='<%# Bind("AnnualAmount") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblAmountYr2" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                              
                            </Columns>
                        </asp:GridView>
                    </div>

                    <%-- B) Employeer Contribution--%>
                    <div class="row">
                        <h5 class="card-title">B) Employeer Contribution</h5>
                        <hr />
                        <asp:GridView ID="GridViewEmpCompansion" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                            ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblCompnent" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("CandID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:Label ID="lblComponentsID1" runat="server" Text='<%# Bind("PerCATID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:Label ID="lblCompnents1" runat="server" Text='<%# Bind("Category") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblCompnents2" runat="server" Text="Total" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblPercentages" runat="server" Text="Percentages" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPercentages1" runat="server" Text='<%# Bind("Percentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblAmounts" runat="server" Text="Annual Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmounts1" runat="server" Text='<%# Bind("AnnualAmount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblAmounts2" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div class="row">
                        <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12">
                            <asp:Label ID="lblcompanynote1" runat="server" Text=" " CssClass="font-12 text-dark" Font-Bold="true"></asp:Label>
                            <asp:Label ID="lblnote" runat="server" Text=" " CssClass="font-12"></asp:Label>
                        </div>
                    </div>

                    <br />
                    <div class="row">
                        <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12">
                            <asp:Label ID="lblParagraph2" runat="server" Text=" " CssClass="font-12"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12 text-center">
                            <asp:Button ID="BtnAccept" runat="server" Text="Accept" Visible="true" OnClick="BtnAccept_Click" CssClass="btn btn-sm btn-success"/>
                            <asp:Button ID="BtnDeclined" runat="server" Text="Decline" Visible="true" OnClick="BtnDeclined_Click" CssClass="btn btn-sm btn-danger"/>
                        </div>
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>
 </div>
</asp:Content>
