<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="TicketPublicForm.aspx.cs" Inherits="MatoshreeProject.TicketPublicForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div id="Popmsg" runat="server" visible="false">
            <div class="row">
                 <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8"></div>
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
        <div class="row" >
            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                <div class="card">
                    <div class="card-body">
                        <asp:Label ID="Label2" runat="server" Visible="false" Text="You are logged in a staff member,If you want to reply to ticket as staff,you must make reply via admin area" Font-Size="12px"></asp:Label><asp:Label ID="lblpriority1" runat="server" Text="" Font-Size="12px"></asp:Label>

                    </div>
                </div>
            </div>
        </div>
        
            </div>
        <div class="container-fluid">
        <div class="row">
            <div class="col-md-5 col-sm-5 col-lg-5 col-xs-5">
                     <h5 >Ticket Information</h5>
                <div class="card">
                     <div class="card-body">
                    
                        <asp:Label ID="lblSubject" runat="server" Text="" CssClass="form-label"></asp:Label>
                        <asp:Label ID="lblTicketid" runat="server" Text="" Visible="false" CssClass="form-label"></asp:Label>
                         <asp:Label ID="lblCustomerID" runat="server" Text="" Visible="false" Font-Bold="true" CssClass="form-control col-1 col-md-1" ReadOnly="true"></asp:Label>

                        <br />
                        <br />
                        <asp:Label ID="lblDepartment" runat="server" Text="Department:" CssClass=""></asp:Label>
                        <asp:Label ID="lbldepartment1" runat="server" Text="" CssClass="form-label"></asp:Label>
                        <hr />
                        <asp:Label ID="lblsumitted" runat="server" Text="Sumitted:" CssClass=""></asp:Label>
                        <asp:Label ID="lblSubmitted1" runat="server" Text="" CssClass="form-label"></asp:Label>
                        <hr />
                        <asp:Label ID="lblContact" runat="server" Text="Contact" CssClass=""></asp:Label>
                        <asp:Label ID="lblContact1" runat="server" Text="" CssClass="form-label"></asp:Label>
                        <hr />
                        <asp:Label ID="lblStatusName" runat="server" Text="Status:" CssClass=""></asp:Label>
                      
                         <asp:Label ID="lblstatusname1" runat="server" Text="" Font-Size="10px" CssClass="btn  btn-sm btn-info"></asp:Label>
                         <hr />
                        <asp:Label ID="lblPriority" runat="server" Text="Priority:" CssClass=""></asp:Label>
                        <asp:Label ID="lblPriority111" runat="server" Text="" CssClass="form-label"></asp:Label>

                    </div>
                </div>
            </div>
            <div class="col-md-7 col-sm-7 col-lg-7 col-xs-7">
                
                <%--<asp:Label ID="Label3" runat="server" Text="Add Reply to this Ticket" CssClass="font-16 font-bold"></asp:Label>--%>
                  <h5>Add Reply to this Ticket</h5>
                
              
                      <div class="row">
                             <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                        <asp:TextBox ID="txtReply" CssClass="form-control"  placeholder="Reply" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <br />
                        <h6><asp:Label ID="lblAttachment" runat="server" Text="Attachment" CssClass="form-label"></asp:Label></h6>
                        <div class="row">
                                                <div class="input-group">
                                                    <asp:FileUpload ID="FileUpload" runat="server" Text="" CssClass="form-control" />
                                                    <asp:Button ID="Btn_Upload" runat="server" Text="Upload" CssClass="btn btn-sm btn-primary" OnClick="Btn_Upload_Click" />
                                                </div>
                                            </div>
                        <br />
                        <div class="row">

                            <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12 text-12">
                                <div class="mb-2">
                                    <asp:Button ID="btnaddReply" runat="server"  CssClass="btn btn-sm btn-primary text-center" OnClick="btnaddReply_Click" Text="Add Reply" />
                                </div>
                            </div>

                        </div>
                    </div>
                        </div>
                    
                <br />
            
                
                <div class="row">
            <div class="col-md-2 col-sm-2 col-lg-2 col-xs-2">
                <asp:Label ID="lblstaffname" runat="server" Text="" CssClass="form-label"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblstaffProf" runat="server" Text="Staff" CssClass="form-label"></asp:Label>
                <br />
                <br />
                <asp:LinkButton ID="LinkBtnconvtoTask" runat="server" OnClick="LinkBtnconvtoTask_Click" CssClass="btn btn-sm btn-outline-dark  p-1  ">Convert To Task</asp:LinkButton>

            </div>
            <div class="col-md-2 col-sm-2 col-lg-2 col-xs-2 border-right">
                 
            </div>
            <div class="col-md-8 col-sm-8 col-lg-8 col-xs-8">

                <div id="initialTenderno" runat="server" visible="false">
                    <asp:Label ID="lblInitialTicket1" runat="server" Text="Ticket Number" CssClass="form-label"></asp:Label>
                    <asp:Label ID="lblInitialNumber" runat="server" Text="-" Font-Bold="true" CssClass="form-control col-1 col-md-1" ReadOnly="true"></asp:Label>
                    <asp:TextBox ID="txtInitialTicket" runat="server" CssClass="form-control"></asp:TextBox>

                </div>

                <asp:GridView ID="GridTicketFile" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                    ClientIDMode="Static" ShowHeader="false" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                <asp:Label ID="lblTicketFileId" runat="server" Text="FileName" CssClass=" font-bold" Visible="false"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTicketFileId1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblTicketFileName" runat="server" Text="FileName" CssClass="form-label"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTicketFileName1" runat="server" Text='<%# Bind("Tick_File") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDeleteExpensesFile" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" Visible="false"  OnClick="btnDeleteExpensesFile_Click" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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
