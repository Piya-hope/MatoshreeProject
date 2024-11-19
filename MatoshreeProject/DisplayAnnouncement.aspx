<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="DisplayAnnouncement.aspx.cs" Inherits="MatoshreeProject.DisplayAnnouncement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var GridDistribution = $("#GridDistribution").prepend($("<thead></thead>").append($("#GridDistribution").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">View Announcement</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="DisplayAnnouncement.aspx">View Announcement</li>
            </ol>
        </nav>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                    <div class="mb-2">
                        <div class="row">
                            <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 text-left" style="margin-left: -11px">
                                <asp:Label ID="lblsub" runat="server" Text="" CssClass="form-label"></asp:Label>
                                <asp:Label ID="lblannounceid1" runat="server" Visible="false" Text=""></asp:Label>
                            </div>
                            <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 text-end">
                                <asp:LinkButton ID="lnkbtnedit" runat="server" Text="Edit" OnClick="lnkbtnedit_Click" Font-Size="12px"></asp:LinkButton>

                            </div>
                        </div>
                    </div>

                    <br />
                    <div class="mb-2">
                        <div class="row">
                            <div class="card shadow-lg border-dark" style="margin-top: -14px">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                                            <asp:Label ID="lbldateposted" runat="server" Text="Data Posted:" CssClass="form-label"></asp:Label>
                                            <asp:Label ID="lbldataadded" runat="server" Text="" Font-Size="12px"></asp:Label>
                                        </div>
                                        <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 text-end">
                                            <asp:Label ID="lblnamePosted" runat="server" Text="Posted By:" CssClass="form-label" Visible="false"></asp:Label>
                                            <asp:Label ID="lblPosted1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                        </div>
                                        <hr />
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                <asp:Label ID="lblmessage" runat="server" Text="" CssClass="form-label"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
