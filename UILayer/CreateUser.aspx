<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CreateUser.aspx.cs" Inherits="CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <table class="full-width">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        User Name *:
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" ClientIDMode="Static" CssClass="txtBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Full Name * :
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" placeholder="First Name" ClientIDMode="Static" CssClass="txtBox"
                            runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtLastName" placeholder="Last Name" ClientIDMode="Static" CssClass="txtBox"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email ID * :
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmailId" ClientIDMode="Static" CssClass="txtBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Contact No :
                    </td>
                    <td>
                        <asp:TextBox ID="txtContactNo" ClientIDMode="Static" CssClass="txtBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Language :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLanguage" ClientIDMode="Static" CssClass="dropdown" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Assign IP Address * :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlIPAddress" ClientIDMode="Static" CssClass="dropdown" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Assign User Role * :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUserRole" ClientIDMode="Static" CssClass="dropdown" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button blue" OnClick="btnSave_Click"
                            OnClientClick="return CheckFormValidity(this);" ValidationGroup="save" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="button blue" 
                            onclick="btnReset_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
