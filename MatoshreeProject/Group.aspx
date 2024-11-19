<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="MatoshreeProject.Group" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
   <script type="text/javascript">
        $(document).ready(function () {
            var GridviewGroup1 = $("#GridviewGroup1").prepend($("<thead></thead>").append($("#GridviewGroup1").find("tr:first"))).DataTable(
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
         <h5 class="font-weight-medium mb-0">Group</h5>
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
                <li class="breadcrumb-item text-muted" aria-current="page" href="Group.aspx">Group</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">


                <div class="card">
                    <div class="card-body">
                     
                        <asp:Button ID="btn_New_Group" runat="server" Text="New Group" CssClass="btn btn-sm btn-primary" OnClick="btn_New_Group_Click" />
                        <hr />
                         <h5 class="font-weight-medium mb-0">Group Summary</h5>
                        <div class="row">
                            <div class="col-sm-2 col-md-2 col-lg-2 col-xl-2">
                                <div class="card">
                                    <div class="card-body border-right">
                                        <asp:Label ID="lblTotalGroupCount" CssClass="text-center font-18 font-bold text-success" runat="server"></asp:Label><br />
                                        <asp:Label ID="lblTotalGroups" runat="server" Text="Total Group" CssClass="font-bold  text-success"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2 col-md-2 col-lg-2 col-xl-2">
                                <div class="card">
                                    <div class="card-body  border-right">
                                        <asp:Label ID="lblActiveGroupCount" runat="server" CssClass="text-center text-info font-18 font-bold"></asp:Label><br />
                                        <asp:Label ID="lblActiveGroup" runat="server" Text="Active Group" CssClass="font-bold  text-info"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2 col-md-2 col-lg-2 col-xl-2">
                                <div class="card">
                                    <div class="card-body  border-right">
                                        <asp:Label ID="lblInActiveGroupCount" runat="server" CssClass="text-center font-18 font-bold text-danger"></asp:Label><br />
                                        <asp:Label ID="lblInActiveGroup" runat="server" Text="Inactive Group" CssClass="font-bold  text-danger"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="Timesheet" runat="server" visible="true">
                    <div class="card">
                        <div class="card-body">

                             <h5 class="font-weight-medium mb-0">View Group Details</h5>
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
                                 <%--  <asp:Button ID="Btn_Export" runat="server" Text="Export" CssClass="btn btn-sm btn-outline-success" OnClick="Btn_Export_Click" />--%>
                            <asp:Button ID="BTN_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-primary" OnClick="BTN_Visibility_Click" />
                            <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-primary" OnClick="Btn_Reload_Click" />
                                   
                                </div>
                            </div>
                            <div class="col-md-4">
                                <!------PDF code--------->

                                <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />

                                <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-dark " Visible="false"></asp:Label>
                                <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblpincode" runat="server" Text="PIN:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblphone" runat="server" Text="Phone:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblphoneNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblvat" runat="server" Text="VAT NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblVatNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblGSTNo1A" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <!------PDF code--------->

                            </div>
                        </div>
                           
                            <br />
                            <br />

                            <asp:GridView ID="GridviewGroup1" runat="server" ScrollBars="Both" OnRowDataBound="GridviewGroup1_RowDataBound" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Group_ID">
                                <Columns>
                                     <asp:TemplateField HeaderText="Status" SortExpression="Order" HeaderStyle-Font-Size="12px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ID" SortExpression="Groupid" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblGroupID" runat="server" Text='<%# Bind("Group_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblGroupID1" runat="server" Text='<%# Bind("Group_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GroupName" SortExpression="GroupName"  HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblGroupName" runat="server" Text='<%#Bind("Group_Name") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblGroupName1" runat="server" Text='<%#Bind("Group_Name") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Color" SortExpression="Color"  HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblColor" runat="server" Text='<%#Bind("Color") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblColor1" runat="server" Text='<%#Bind("Color") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Short Description" SortExpression="Shortdescription"  HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblShortdescription" runat="server" Text='<%#Bind("Shortdescription") %>' Font-Bold="false" Font-Size="12px" TextMode="MultiLine"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblShortdescription1" runat="server" Text='<%#Bind("Shortdescription") %>' Font-Bold="false" Font-Size="12px" TextMode="MultiLine"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order" SortExpression="Order" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblOrder" runat="server" Text='<%#Bind("order") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrder1" runat="server" Text='<%#Bind("order") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
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
