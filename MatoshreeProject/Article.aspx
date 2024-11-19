<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="MatoshreeProject.Article" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridviewArticle1 = $("#GridviewArticle1").prepend($("<thead></thead>").append($("#GridviewArticle1").find("tr:first"))).DataTable(
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h5 class="font-weight-medium mb-0">Article</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Article.aspx">Article
                    </a>
                </li>
              
            </ol>
        </nav> 
        <br />


        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                    

                        <asp:Button ID="btn_New_Article" runat="server" Text="New Article" CssClass="btn btn-sm btn-primary" OnClick="btn_New_Article_Click" />
                        <asp:Button ID="btn_Group" runat="server" Text="Group" CssClass="btn btn-sm btn-primary" OnClick="btn_Group_Click" />

                        <hr />
                        <h5 class="font-weight-medium mb-0">Article Summary</h5>
                        <div class="row">
                            <div class="col-sm-2 col-md-2 col-lg-2 col-xl-2">
                                <div class="card">
                                    <div class="card-body border-right">
                                        <asp:Label ID="lblTotalArticleCount" CssClass="text-center  font-bold font12 text-success" runat="server"></asp:Label><br />
                                        <asp:Label ID="lblTotalArticles" runat="server" Text="Total Article" CssClass="font-bold font12  text-success"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2 col-md-2 col-lg-2 col-xl-2">
                                <div class="card">
                                    <div class="card-body  border-right">
                                        <asp:Label ID="lblActiveArticleCount" runat="server" CssClass="text-center text-info  font-bold font12"></asp:Label><br />
                                        <asp:Label ID="lblActiveArticles" runat="server" Text="Active Article" CssClass="font-bold font12  text-info"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2 col-md-2 col-lg-2 col-xl-2">
                                <div class="card">
                                    <div class="card-body  border-right">
                                        <asp:Label ID="lblInActiveArticleCount" runat="server" CssClass="text-center  font-bold font12 text-danger"></asp:Label><br />
                                        <asp:Label ID="lblInActiveArticle" runat="server" Text="Inactive Article" CssClass="font-bold font12  text-danger"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div id="Timesheet" runat="server" visible="true">
                    <div class="card">
                        <div class="card-body">

                            <h5 class="font-weight-medium mb-0">View Article Details</h5>
                            <hr />
                            <div class="row">
                                <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                    <div class="bd-example">
                                        <div class="btn-group">
                                            <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                            <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                            <div class="dropdown-menu">
                                                <asp:LinkButton ID="lnkbtnExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                                                <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDF_Click"></asp:LinkButton>

                                            </div>
                                        </div>
                                        <asp:Button ID="BTN_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-primary" OnClick="BTN_Visibility_Click" />
                                        <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-primary" OnClick="Btn_Reload_Click" />

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <!------PDF code--------->

                                    <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />

                                    <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font12 text-dark" Visible="false"></asp:Label>
                                    <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," Font-Size="12px" Visible="false"></asp:Label>
                                    <asp:Label ID="lblpincode" runat="server" Text="PIN:" Font-Size="12px" Visible="false"></asp:Label>
                                    <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                    <asp:Label ID="lblphone" runat="server" Text="Phone:" Font-Size="12px" Visible="false"></asp:Label>
                                    <asp:Label ID="lblphoneNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                    <asp:Label ID="lblvat" runat="server" Text="VAT NO:" Font-Size="12px" Visible="false"></asp:Label>
                                    <asp:Label ID="lblVatNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                    <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" Font-Size="12px" Visible="false"></asp:Label>
                                    <asp:Label ID="lblGSTNo1A" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                    <!------PDF code--------->

                                </div>
                            </div>

                            <br />
                            <br />

                            <asp:GridView ID="GridviewArticle1" runat="server" OnRowDataBound="GridviewArticle1_RowDataBound" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="true" DataKeyNames="Article_ID">
                                <Columns>
                                    <asp:TemplateField HeaderText="Subject Name" SortExpression="SubjectName" HeaderStyle-Font-Size="12px" Visible="false">

                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus1" runat="server" Text='<%#Bind("Status") %>' Font-Bold="true" Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" SortExpression="Article_ID" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblArticleID" runat="server" Text='<%# Bind("Article_ID") %>' CssClass="form-label"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblArticleID1" runat="server" Text='<%# Bind("Article_ID") %>' CssClass="form-label"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject Name" SortExpression="SubjectName" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblArticleName" runat="server" Text='<%#Bind("SubjectName") %>' Font-Bold="true"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblArticleName1" runat="server" Text='<%#Bind("SubjectName") %>' Font-Bold="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Group" SortExpression="Group" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblddlGroup" runat="server" Text='<%#Bind("Group") %>' Font-Bold="true"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblddlGroup1" runat="server" Text='<%#Bind("Group") %>' Font-Bold="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Article Description" SortExpression="Article Description" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblArticledescription" runat="server" Text='<%#Bind("Articledescription") %>' Font-Bold="true"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblArticledescription1" runat="server" Text='<%#Bind("Articledescription") %>' Font-Bold="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkEditGroup" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="LinkEditGroup_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteGroup" runat="server" CssClass="btn btn-sm btn-outline-danger" OnClick="btnDeleteGroup_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
