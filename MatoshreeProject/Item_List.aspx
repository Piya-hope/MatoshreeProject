<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Item_List.aspx.cs" Inherits="MatoshreeProject.Item_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridItem = $("#GridItem").prepend($("<thead></thead>").append($("#GridItem").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Item List</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="#">SALE
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="Item_List.aspx">Item List</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-sm-12">
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                        <div id="addnew" runat="server">
                        <asp:Button ID="btn_New_Item" runat="server" Text="New Item" CssClass="btn btn-sm btn-primary" OnClick="btn_New_Item_Click" />
                            </div>
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
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-sm-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="font-weight-medium mt-3 mb-3">View Item List</h5>
                        <hr />
                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                <div class="bd-example">
                                    <div class="btn-group">
                                        <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>

                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="linkbtnExcel" runat="server" Text="Excel" CssClass="dropdown-item" OnClick="linkbtnExcel_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDF_Click"></asp:LinkButton>

                                        </div>
                                    </div>


                                    <asp:Button ID="BTN_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="BTN_Visibility_Click" />
                                    <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_Reload_Click" />
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
                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <asp:GridView ID="GridItem" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID"
                                OnRowDataBound="GridItem_RowDataBound" OnRowEditing="GridItem_RowEditing" OnRowUpdating="GridItem_RowUpdating" OnRowCancelingEdit="GridItem_RowCancelingEdit"
                                OnRowDeleting="GridItem_RowDeleting" OnPageIndexChanging="GridItem_PageIndexChanging" HeaderStyle-Width="90px">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ItemID" SortExpression="ID" HeaderStyle-Width="50px" Visible="false" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblitemID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Width="80px"  HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' Font-Bold="false" Font-Size="12px" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LongDescription" SortExpression="Long_Description" ItemStyle-Width="100px" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtLong_Description" runat="server" Text='<%# Bind("Long_Description") %>' Font-Bold="false" Font-Size="12px" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                           
                                            <asp:Label ID="lblLong_Description1" runat="server" Text='<%# Bind("Long_Description") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate" SortExpression="Rate" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtRate" runat="server" Text='<%# Bind("Rate") %>' Font-Bold="false" Font-Size="12px" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRate2" runat="server" Text='<%# Bind("Rate") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="HSNCode" SortExpression="HSN" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtHSN" runat="server" Text='<%# Bind("HSN") %>' Font-Bold="false" Font-Size="12px" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblHSN2" runat="server" Text='<%# Bind("HSN") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TaxName1" SortExpression="Tax" HeaderStyle-Width="200px" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblTaxx1" runat="server" Text='<%#Bind("TaxAmunt") %>' Visible="false" Font-Bold="false" Font-Size="12px"></asp:Label>&nbsp; 
                              
                                        <asp:DropDownList ID="ddlTaxCost" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxCost_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTaxx1" runat="server" Text='<%#Bind("TaxName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>&nbsp; 
                                     <asp:Label ID="lblTax1" runat="server" Text='<%#Bind("TaxAmunt") %>' Font-Bold="false" Font-Size="12px" ForeColor="Black" Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TaxName2" SortExpression="Tax2" HeaderStyle-Width="200px" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblTaxCost1" runat="server" Text='<%#Bind("TaxAmunt2") %>' Visible="false" Font-Bold="false" Font-Size="12px"></asp:Label>&nbsp; 
                              
                                        <asp:DropDownList ID="ddlTaxCost1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxCost1_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTaxx2" runat="server" Text='<%#Bind("TaxName2") %>' Font-Bold="false" Font-Size="12px"></asp:Label>&nbsp; 
                                     <asp:Label ID="lblTax2" runat="server" Text='<%#Bind("TaxAmunt2") %>' Font-Bold="false" Font-Size="12px" ForeColor="Black" Visible="false"></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit1" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lnkUpdate1" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkCancel1" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete1" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger"><i class="ti ti-trash"></i></asp:LinkButton>
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
                        <div class="col-md-2 col-sm-2 col-lg-2"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

      
</asp:Content>
