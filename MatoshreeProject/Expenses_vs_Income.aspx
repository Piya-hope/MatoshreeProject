<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Expenses_vs_Income.aspx.cs" Inherits="MatoshreeProject.Expenses_vs_Income" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="page-breadcrumb">
            <div class="row">
                <div class="col-12 d-flex no-block align-items-center">
                    <div class="ms-auto text-end">
                        <nav aria-label="breadcrumb">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
                                  <li class="breadcrumb-item"><a href="#">Reports</a></li>
                                <li class="breadcrumb-item active" aria-current="page"><a href="Expenses_vs_Income.aspx">Expenses_vs_Income</a></li>
                             
                            </ol>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
     <div class="container-fluid">
        <div class="card">
            <div class="card-body">
                <h5>Expenses Vs Income</h5>
                <div class="row">
                    <div class="col-md-4">
                        <div class="mb-2">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control form-select">
                                <asp:ListItem>2022</asp:ListItem>
                                <asp:ListItem>2021</asp:ListItem>
                                <asp:ListItem>2020</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <hr />
                    <p class="text-danger bold">Amount is displayed in your base currency - Only use this report if you are using 1 currency for payments and expenses.</p><br />

                    <div class="container-fluid panel-body mdi-responsive bars" id="expenses_vs_income" style="height: 350px;" onclick="link_btn_Total_Income"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
