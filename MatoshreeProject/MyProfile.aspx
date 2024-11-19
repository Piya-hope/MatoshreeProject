<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="MatoshreeProject.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .image img {
            border-radius: 50%;
            width: 150px;
            height: 150px;
            object-fit: cover;
            margin-bottom: 30px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="container-fluid">
            <h5 class="font-weight-medium mb-0">My Profile</h5>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item">
                        <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                        </a>
                    </li>
                    <li class="breadcrumb-item text-muted" aria-current="page" href="MyProfile.aspx">My Profile</li>
                </ol>
            </nav>
            <br />

            <div class="row">
                <!-- Column -->
                <div class="col-md-4 col-sm-6 col-xs-12">
                    <div class="card border">
                        <div class="card-body">
                            <h6>Total Logged Time &nbsp;&nbsp;<span class="text-right pull-right"> <asp:Label ID="lblTodayHours" runat="server" Text="" CssClass="text-dark form-label" ></asp:Label> / <asp:Label ID="lblTotalHours" runat="server" Text="24" CssClass="text-dark form-label"></asp:Label></span></h6>
                            <div class="mt-3">
                                <asp:Label ID="lblPercent" runat="server" Text="" CssClass="text-success form-label text-end" ></asp:Label>
                                <div class="progress">
                                    <div class="progress-bar progress-bar-animated progress-bar-striped bg-success" role="progressbar" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100" id="pgTodayHr" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Column -->
                  <div class="col-md-4 col-sm-6 col-xs-12">
                    <div class="card border">
                        <div class="card-body" style="border: medium">
                            <h6>This Week Logged Time &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="text-right pull-right"><asp:Label ID="lblWeekLog" runat="server" Text="" CssClass="text-dark form-label" ></asp:Label> / <asp:Label ID="TotalWeekDay" runat="server" Text="7" CssClass="text-dark form-label"></asp:Label></span></h6>
                            <div class="mt-3">
                                  <asp:Label ID="lblWeekPercent" runat="server" Text="" CssClass="text-info form-label text-end" ></asp:Label>
                              
                                <div class="progress">
                                    <div class="progress-bar progress-bar-animated bg-info" role="progressbar" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100" id="pgWeek" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Column -->
                <div class="col-md-4 col-sm-6 col-xs-12">
                    <div class="card border">
                        <div class="card-body" style="border: medium">
                            <h6>This Month Logged Time &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="text-right pull-right"><asp:Label ID="lblLogInMonth" runat="server" Text="" CssClass="text-dark form-label" ></asp:Label> / <asp:Label ID="lblTotalMonth" runat="server" Text="12" CssClass="text-dark form-label"></asp:Label></span></h6>
                            <div class="mt-3">
                                  <asp:Label ID="lblPercentMonth" runat="server" Text="" CssClass="text-warning form-label text-end" ></asp:Label>
                              
                                <div class="progress">
                                    <div class="progress-bar progress-bar-animated bg-warning" role="progressbar" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100" id="pgMonth" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Column -->
            </div>


            <div class="row">
                <div class="col-md-4 col-sm-4 col-lg-4">
                    <h5>Profile</h5>
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="mb-2">
                                    <div class="fa ms-2">
                                        <asp:LinkButton ID="Linkfacebook" runat="server" CssClass="link-opacity-100-hover text-decoration-underline" href="https://www.facebook.com/login/"  Font-Size="16px"  Text="" ForeColor="Black"><iconify-icon icon="jam:facebook-square"></iconify-icon> </asp:LinkButton>
                                        <asp:LinkButton ID="Linklinkedin" runat="server" CssClass="link-opacity-100-hover text-decoration-underline" href="https://www.linkedin.com/login/"  Font-Size="16px"  Text="" ForeColor="Black"><iconify-icon icon="bi:linkedin"></iconify-icon></asp:LinkButton>
                                        <asp:LinkButton ID="Linkskype" runat="server" CssClass="link-opacity-100-hover text-decoration-underline" href="https://www.skype.com/login/"  Font-Size="16px"  ForeColor="Black"> <iconify-icon icon="teenyicons:skype-outline"></iconify-icon></asp:LinkButton>
                                        <asp:LinkButton ID="Linkgithub" runat="server" CssClass="link-opacity-100-hover text-decoration-underline" href="https://www.github.com/login/"  Font-Size="16px"  Text="" ForeColor="Black"><iconify-icon icon="iconoir:github"></iconify-icon></asp:LinkButton>
                                        <asp:LinkButton ID="LinkEdit" runat="server" CssClass="link-opacity-100-hover text-decoration-underline" Font-Size="16px" Text="" ForeColor="Black" OnClick="LinkEdit_Click"><iconify-icon icon="lucide:edit"></iconify-icon></asp:LinkButton>
                                    </div>
                                </div>
                                <div class="mb-2">
                                    <div class="ti ms-2">
                                        <asp:Label ID="lblpripfiledata" runat="server" Text="This is" CssClass="" Font-Size="14px" ForeColor="Blue"></asp:Label>&nbsp;<asp:Label ID="lblRele1" runat="server" Font-Size="14px" Text="" CssClass="" ForeColor="Blue"></asp:Label>&nbsp;<asp:Label ID="lblii" runat="server" Text="Profile" CssClass="" Font-Size="14px" ForeColor="Blue"></asp:Label>
                                        <br />
                                    </div>
                                </div>
                            </div>
                       
                             <div class="mb-2">
                                    <asp:Label ID="lbltest" runat="server" Text="" Visible="false"></asp:Label>
                                    <div class="image">
                                        <asp:Image ID="ImgUser" runat="server" ImageUrl="Image\user.jpg" />
                                        <%-- <img src="" alt="img" />--%>
                                        <span><iconify-icon icon="healthicons:ui-user-profile-outline"></iconify-icon></span>
                                    </div>
                                    <asp:Label ID="lblFname" runat="server" Text="" CssClass="fw-bold" Font-Size="16px"></asp:Label>
                                    <br />
                                    <span><i class="ti ti-mail"></i>&nbsp;<asp:Label ID="lblEmail" runat="server" CssClass="" Text=""></asp:Label></span>
                                    <br />
                                    <span><i class="ti ti-phone"></i>&nbsp;<asp:Label ID="lblPhonenumber" runat="server" CssClass="" Text=""></asp:Label></span>
                                    <div>
                                    </div>
                                </div>
                           </div>
                    </div>
                </div>
                <div class="col-md-8 col-sm-8 col-lg-8">
                    <h5>Notification</h5>
                    <div class="card">
                        <div class="card-body">
                            <img src="Image\user.jpg" alt="img" style="border-radius: 50%; height: 50px; width: 50px" />&nbsp;&nbsp;
                        <span>
                            <asp:Label ID="Label1" runat="server" Text="Congratulations...!We achived new goal." CssClass="form-label"></asp:Label><br />
                        </span>
                            <h8>a weeks ago</h8>
                            <hr />
                            <img src="Image\user.jpg" alt="img" style="border-radius: 50%; height: 50px; width: 50px" />&nbsp;&nbsp;
                        <span>
                            <asp:Label ID="Label2" runat="server" Text="Congratulations...!We achived new goal." CssClass="form-label"></asp:Label><br />
                        </span>
                            <h8>a weeks ago</h8>
                            <hr />
                            <img src="Image\user.jpg" alt="img" style="border-radius: 50%; height: 50px; width: 50px" />&nbsp;&nbsp;
                        <span>
                            <asp:Label ID="Label3" runat="server" Text="Congratulations...!We achived new goal." CssClass="form-label"></asp:Label><br />
                        </span>
                            <h8>a weeks ago</h8>
                            <hr />
                            <img src="Image\user.jpg" alt="img" style="border-radius: 50%; height: 50px; width: 50px" />&nbsp;&nbsp;
                        <span>
                            <asp:Label ID="Label4" runat="server" Text="Congratulations...!We achived new goal." CssClass="form-label"></asp:Label><br />
                        </span>
                            <h8>a weeks ago</h8>
                            <h8>a weeks ago</h8>
                            <hr />
                            <img src="Image\user.jpg" alt="img" style="border-radius: 50%; height: 50px; width: 50px" />&nbsp;&nbsp;
                        <span>
                            <asp:Label ID="Label5" runat="server" Text="Congratulations...!We achived new goal." CssClass="form-label"></asp:Label><br />
                        </span>
                            <h8>a weeks ago</h8>
                            <hr />
                            <img src="Image\user.jpg" alt="img" style="border-radius: 50%; height: 50px; width: 50px" />&nbsp;&nbsp;
                        <span>
                            <asp:Label ID="Label6" runat="server" Text="Congratulations...!We achived new goal." CssClass="form-label"></asp:Label><br />
                        </span>
                            <h8>a weeks ago</h8>
                            <br />
                            <br />
                            <br />
                            <asp:Button ID="Button1" CssClass="btn btn-sm btn-info" runat="server" Text="Load More" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
